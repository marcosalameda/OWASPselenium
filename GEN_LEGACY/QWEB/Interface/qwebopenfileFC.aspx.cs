using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using System.Text;
using System.IO;

public partial class qwebopenfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    
        string nomeFile = "";
        ArrayList result = new ArrayList();
        string pathdocu = "";
        bool entra = true;

        if (Request.QueryString.Count > 0)
        {
            nomeFile = Request.QueryString[0];
            nomeFile = HttpUtility.ParseQueryString(Request.Url.Query, Encoding.GetEncoding("iso-8859-1"))[0];
            nomeFile = HttpUtility.UrlDecode(nomeFile);

            result.Add(AppDomain.CurrentDomain.BaseDirectory+"temp\\" + nomeFile);
            pathdocu =AppDomain.CurrentDomain.BaseDirectory+ "temp\\" + nomeFile;
        }

        if (result.Count == 1)
        {
            string path = ConversaoQweb.ToString(result[0]);
            #region old code
            /*            path.LastIndexOf('.');
            string ext = path.Substring(path.LastIndexOf('.'), path.Length - path.LastIndexOf('.'));
            ext = ext.ToLower();*/

          /*    switch (ext)
            {
             case ".pdf":
                    {
                        Response.ContentType = "Application/pdf";
                        Response.Clear();
                        break;
                    }
                case ".gif":
                    {
                        Response.ContentType = "Image/GIF";
                        Response.Clear();
                        break;
                    }
                case ".bmp":
                    {
                        Response.ContentType = "image/bmp";
                        Response.Clear();
                        break;
                    }
                case ".png":
                    {
                        Response.ContentType = "image/png";
                        Response.Clear();
                        break;
                    }
                case ".jpeg":
                    {
                        Response.ContentType = "image/JPEG";
                        Response.Clear();
                        break;
                    }
                case ".jpg":
                    {
                        Response.ContentType = "image/JPEG";
                        Response.Clear();
                        break;
                    }
                case ".avi":
                    {
                        Response.ContentType = "video/msvideo";
                        Response.Clear();
                        break;
                    }
                case ".zip":
                    {
                        Response.ContentType = "application/x-zip-compressed";
                        Response.Clear();
                        break;
                    }
                case ".txt":
                    {
                        Response.ContentType = "text/plain";
                        Response.Clear();
                        break;
                    }
                case ".htm":
                    {
                        Response.ContentType = "text/HTML";
                        Response.Clear();
                        break;
                    }
                case ".html":
                    {
                        Response.ContentType = "text/HTML";
                        Response.Clear();
                        break;
                    
                default:
                    {}*/
#endregion
                        //se não for nenhum dos tipos de ficheiros referidos anteriormente faz-se o downloaddo mesmo
                        try
                        {
                            Response.ContentType = "APPLICATION/OCTET-STREAM";
                            String disHeader = "";

                            if (Request.QueryString.Count > 0)
                            {
                                disHeader = "Attachment; Filename=\"" +  HttpUtility.UrlEncode(nomeFile.Replace(" ","_")) + "\"";
                            }

                            Response.AppendHeader("Content-Disposition", disHeader); // transfer the file byte-by-byte to the response object
                            //System.IO.FileInfo fileToDownload = new System.IO.FileInfo(pathdocu + "\\" + subdir + "\\" + path);

                            System.IO.FileInfo fileToDownload = new System.IO.FileInfo(path);
                            Response.Flush();
                            entra = false;
                        }
                        catch (Exception ex)
                        {
                            throw new BusinessException(" Erro ao fazer Download do ficheiro", "qwebopenfile.aspx", "Erro ao fazer Download do ficheiro erro: " + ex.ToString());
                        }

                       // break;
                   // }
           // }
            if (entra)
            {
                String disHead = "";

                if (Request.QueryString.Count > 0)
                {
                    disHead = "Filename=\"" + HttpUtility.UrlEncode(nomeFile.Replace(" ","_")) + "\"";
                }
              
                Response.AppendHeader("Content-Disposition", disHead);
            }
            //Write the file directly to the HTTP content output stream.
            //Response.WriteFile(pathdocu + "\\" + subdir + "\\" + path);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>parent.ExecCmd('','ClosePage(')</scrip" + "t>");
            Response.WriteFile(path);
            Response.End();
            Response.Flush();

        }

    }
}
