using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSGenio.framework;

public partial class UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string vTitle = "";
        string vDesc = "";
        string FilePath = Configuration.PathDocuments; //TODO: verificar se esta será a melhor variável to colocar os ficheiros
        if (FilePath == "")
            FilePath = Server.MapPath("/files/");
		else if (FilePath.Substring(FilePath.Length - 1) != "/")
            FilePath += "/";

        //criar a pasta onde vão ser gravados os ficheiros caso ainda não exista
        bool exists = System.IO.Directory.Exists(FilePath);
        if (!exists)
            System.IO.Directory.CreateDirectory(FilePath);

        if (!string.IsNullOrEmpty(Request.Form["title"]))
        {
            //deve ser passado o name do file com extensão
            vTitle = Request.Form["title"];
        }
        //neste momento a description ainda não está a ser utilizado
        if (!string.IsNullOrEmpty(Request.Form["description"]))
        {
            vDesc = Request.Form["description"];
        }

        HttpFileCollection MyFileCollection = Request.Files;
        //verificar se existem ficheiros to serem gravados
        if (MyFileCollection.Count > 0)
        {
            try
            {
                //criar name único to os ficheiros
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid().ToString().Replace("-","");
                //adicionar extensão ao file
                if (vTitle.LastIndexOf(".") != -1)
                    fileName += vTitle.Substring(vTitle.LastIndexOf(".")-1);
                // Grava o file
                MyFileCollection[0].SaveAs(FilePath + fileName);
            }
            catch (Exception) { }
        }
    }
}