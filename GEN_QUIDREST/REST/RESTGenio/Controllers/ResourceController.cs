using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace RESTGenio.Resources;

[ApiController]
[Route("Resources")]
public class ResourceController : Controller
{


    /// <summary>
    /// Downloads a binary resource from its access ticket.
    /// Tickets can be obtained from the [field]_ticket properties of other REST method responses.
    /// </summary>
    /// <param name="ticket">The access ticket</param>
    /// <returns>A stream to with with binary resource</returns>
    [Authorize]
    [HttpGet("file/{ticket}", Name = "ResourceFileGet")]
    [SwaggerOperation(Tags = new[] { "Resources" })]
    [SwaggerResponse(200, "File", typeof(FileContentResult), contentTypes: new string[] { "application/octet-stream" })]
    [SwaggerResponse(404, "File is empty or any access error")]
    public IActionResult FileGet(string ticket)
    {
        try
        {
            User user = AuthService.ValidateAuthentication(HttpContext, "");

            var sp = PersistentSupport.getPersistentSupport(user.Year);
            sp.openConnection();

            var resource = DatabaseService.DecodeResourceRef(ticket, user);

            byte[]? bytes;
            string fileDownloadName;

            switch (resource)
            {
                case ResourceQuery rec: //Docums
                    {
                        DbArea area = DatabaseService.PositionDocumentRow(user, sp, rec);

                        if (!area.AccessRightsToConsult(user))
                            throw new Exception("User does not have sufficient access rights");

                        bytes = area.returnLastVersionFileDocum(sp, rec.KeyData)?.File;
                        fileDownloadName = rec.Name;
                    }
                    break;
                case ResourceBinary binFile: //Image
                    {
                        DbArea area = DatabaseService.PositionBinaryRow(user, sp, binFile);

                        if (!area.AccessRightsToConsult(user))
                            throw new Exception("User does not have sufficient access rights");

                        bytes = (byte[])area.returnValueField(binFile.Table + "." + binFile.Field);
                        fileDownloadName = binFile.Field + ".bin";
                    }
                    break;
                case ResourceFile resFile: //External file
                    bytes = resFile.GetContent(sp);
                    fileDownloadName = resFile.Name;
                    break;
                default:
                    throw new Exception("Invalid ticket type");
            }

            sp.closeConnection();
            if (bytes is null || bytes.Length == 0) return NotFound("File does not exist");
            return File(bytes, "application/octet-stream", fileDownloadName);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Uploads a binary resource using its access ticket.
    /// Tickets can be obtained from the [field]_ticket properties of other REST method responses.
    /// </summary>
    /// <param name="ticket">The access ticket</param>
    /// <param name="file">The file stream upload</param>
    /// <returns>The result of the operation</returns>
    [Authorize]
    [HttpPost("file/{ticket}", Name = "ResourceFilePost")]
    [SwaggerOperation(Tags = new[] { "Resources" })]
    public ActionResult<Response> FilePut(string ticket, IFormFile? file)
    {
        var response = new Response();
        PersistentSupport? sp = null;

        // Utility function to extract the byte array from the uploaded stream
        static byte[] GetFileArray(IFormFile f)
        {
            using (var memory = new MemoryStream())
            {
                f.CopyTo(memory);
                return memory.ToArray();
            }
        }

        try
        {
            var user = AuthService.ValidateAuthentication(HttpContext, "");
            var resource = DatabaseService.DecodeResourceRef(ticket, user);

            sp = PersistentSupport.getPersistentSupport(user.Year);
            sp.openTransaction();

            switch (resource)
            {
                case ResourceQuery docRes: //Docums
                    {
                        DbArea area = DatabaseService.PositionDocumentRow(user, sp, docRes);
                        var value = file is null ? Array.Empty<byte>() : GetFileArray(file);
                        //Clients like NSwag cannot handle optional file uploads,
                        // also in our current API, saving an empty file is equivalent to no file.
                        if (file is null || value.Length == 0)
                        {
                            area.removeDocums(sp, docRes.KeyData);
                            area.update(sp);
                        }
                        else
                        {
                            // Using only the last version, ignores CHECKOUT versions
                            // This method should not be used for full versioned document workflows.
                            string? lastVersion = area.returnLastVersionDocum(sp, docRes.KeyData)?[0];
                            area.commitDocum(sp, docRes.KeyData, value, Path.GetFileName(file.FileName)+"_sucess", lastVersion);
                        }
                    }
                    break;
                case ResourceBinary binRes: //Image
                    {
                        DbArea area = DatabaseService.PositionBinaryRow(user, sp, binRes);
                        var value = file is null ? Array.Empty<byte>() : GetFileArray(file);
                        area.insertNameValueField(area.Alias + "." + binRes.Field, value);
                        area.update(sp);
                    }
                    break;
                case ResourceFile extRes: //External file
                    throw new InvalidOperationException("Upload operation is not available for server based filenames");
                default:
                    throw new Exception("Invalid ticket type");
            }

            response.Ok();
            sp.closeTransaction();
        }
        catch (GenioException ep)
        {
            sp?.rollbackTransaction();
            response.Error(ep.UserMessage);
        }
        catch (Exception e)
        {
            sp?.rollbackTransaction();
            response.Error(e.Message);
        }

        return response;
    }
}
