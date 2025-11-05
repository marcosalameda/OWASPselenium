<%@ Page Language="C#"%>
<%@ Import namespace="CSGenio.framework" %>
<%@ Import namespace="CSGenio.persistence" %>
<% if(open == "1") { %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head id="Head1" runat="server">
    <title></title>
</head>

<body onload='load()'>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
        <script type='text/javascript'>
            function embedPDF(name) {

                window.open("js/PDFJS/web/viewer.html?file=" + name);
            }

</script>
</body>
</html>
<%}%>
<script runat="server">

	protected string open = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
    
    
        // obter o conteudo do resource
        string recSer = Request.Params["rec"];
        // parametro to verificar se é to abrir com o preview de pdfs
        open = Request.Params["open"];
        // obter o user da sessão
        User user = (User)Session["utilizador"];

        if (user == null)
            throw new Exception("Invalid session values");

        // decifra o ticket, devolvendo um array com os objectos instanciados
        object[] objs = QResources.DecryptTicketBase64(recSer);
        // na primeira posição do array está o IP
        string username = (string)objs[0];
        string ip = (string)objs[1];

        // validate o IP e o username
        if (!username.Equals(user.Name) && !ip.Equals(Request.UserHostAddress))
            throw new Exception("Invalid ticket");

        // na segunda posição do array está o objecto do resource
        Resource rec = (Resource)objs[2];

        // cria-se um suporte persistente e invoca-se a função que devolve o conteúdo do resource
        PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
        sp.openConnection();
        byte[] conteudo = rec.GetContent(sp);
        sp.closeConnection();
		//abrir com o preview to docs pdf
		if (open == "1")
        {
            string nomeencrip = HttpUtility.UrlEncode(rec.Name);
            nomeencrip = nomeencrip.Replace("%2b", "?");
            string[] pasta = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            string _FileName = @"/" + pasta[pasta.Length - 2] + @"/temp/" + rec.Name;
            HttpResponse.RemoveOutputCacheItem(@"/" + pasta[pasta.Length - 2] + @"/temp/");
            string popupScript = "<script language='javascript'>" +
             "function load(){ embedPDF('" + _FileName + "');}" + "</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(),"PopupScript", popupScript);
        }
        else
        {
			// construir a resposta com o conteudo do resource
			Response.ContentType = "APPLICATION/OCTET-STREAM";
			string disHeader = "Attachment; Filename=\"" + HttpUtility.UrlPathEncode(rec.Name) + "\"";
			Response.AppendHeader("Content-Disposition", disHeader);
			Response.AddHeader("Content-Length", conteudo.Length.ToString());
			Response.BinaryWrite(conteudo);
			//TODO: verificar como funciona o buffering
			//Response.Buffer = true;
			HttpContext.Current.ApplicationInstance.CompleteRequest();
		}
    }
    
</script>