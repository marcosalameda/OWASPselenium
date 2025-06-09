using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace RESTGenio.Auth;

[ApiController]
[Route("Auth")]
public class AuthController : Controller
{
    /// <summary>
    /// Acquires authentication token needed to use the secure api methods
    /// </summary>
    /// <param name="request">Login Information</param>
	[AllowAnonymous]
    [HttpPost("Login", Name = "AuthLogin")]
    [SwaggerOperation(Tags = new[] { "Authentication" })]
    public ActionResult<LoginResponse> Login(LoginRequest request)
    {
        LoginResponse Response = new LoginResponse();

        try
        {
			string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
            var user = AuthService.AuthenticateUser(request.username, request.password, request.year, ip);
            Response.token = AuthService.CreateToken(user, request.timeout);
            Response.Ok();
        }
        catch(Exception e) { 
            Response.Error(e.Message);
            return Response;
        }

        return Response;
    }
	
    /// <summary>
    /// Refreshes a previously secured token.
    /// 
    /// Can also be used to request short lived tokens to be lent out to 3rd parties for a single operation.
    /// </summary>
    /// <param name="timeout">The timeout to use for the token obtained</param>
    /// <param name="lease">Pass true to create a single use token that cannot be used to refresh again</param>
    /// <returns>A refresh token</returns>
    [Authorize]
    [HttpGet("Refresh", Name = "AuthRefresh")]
    [SwaggerOperation(Tags = new[] { "Authentication" })]
    public ActionResult<LoginResponse> Refresh(float ?timeout, bool ?lease)
    {
        LoginResponse Response = new LoginResponse();

        try
        {
            AuthService.ValidateLease(HttpContext);
            var user = AuthService.ValidateAuthentication(HttpContext, "");
            Response.token = AuthService.CreateToken(user, timeout, lease ?? false);
            Response.Ok();
        }
        catch (Exception e)
        {
            Response.Error(e.Message);
            return Response;
        }

        return Response;
    }
}
