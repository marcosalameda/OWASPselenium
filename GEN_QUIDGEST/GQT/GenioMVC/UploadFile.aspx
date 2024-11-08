<%@ Page Language="C#" %>

<%@ Import Namespace="CSGenio.framework" %>
<%@ Import Namespace="CSGenio.persistence" %>
<%@ Import Namespace="Quidgest.Persistence.GenericQuery" %>
<%@ Import Namespace="CSGenio.business" %>
<%@ Import Namespace="GenioMVC.Controllers" %>

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
        function embedPDF(nome) {

            window.open("js/PDFJS/web/viewer.html?file=" + nome);
        }

    </script>
</body>
</html>
<%}%>
<script runat="server">

    protected string open = "0";

    protected void Page_Load(object sender, EventArgs e)
    {


        // obter o conteudo do recurso
        string versao = Request.Params["versao"];
        string coddocums = Request.Params["coddocums"];
        string codtabela = Request.Params["codtabela"];
        string nometabela = Request.Params["nometabela"];
        string idsession = Request.Params["idsession"];
        string field = Request.Params["campo"];
        string name = Request.Params["name"];
        string year = Request.Params["year"];

        // obter o utilizador da sessão
        User utilizador = new User(name, idsession, year);


        var httpRequest = System.Web.HttpContext.Current.Request;
        HttpFileCollection uploadFiles = httpRequest.Files;
        var docfiles = new List<string>();

        if (utilizador == null)
            throw new Exception("Invalid session values");

        if (httpRequest.Files.Count > 0)
        {
            int i;
            if (uploadFiles.Count == 1 && uploadFiles[0].FileName == "loading.txt")
            {
                try
                {
                    if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/loading" + idsession + ".txt"))
                        System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/temp/loading" + idsession + ".txt", "");
                }
                catch { }
            }
            else if (uploadFiles.Count == 1 && uploadFiles[0].FileName == "logincert.txt")
            {
                try
                {
                    if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/logincert" + idsession + ".txt"))
                        System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/temp/logincert" + idsession + ".txt", "");
                }
                catch { }
            }
            else if (uploadFiles.Count == 1 && uploadFiles[0].FileName == "login.txt")
            {
                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/login" + idsession + ".txt"))
                {
                    HttpPostedFile postedFile = uploadFiles[0];
                    postedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/temp/login" + idsession + ".txt");
                }
            }
            else if (uploadFiles.Count == 1 && uploadFiles[0].FileName == "loginCancel.txt")
            {
                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/loginCancel" + idsession + ".txt"))
                {
                    HttpPostedFile postedFile = uploadFiles[0];
                    postedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/temp/loginCancel" + idsession + ".txt");
                }
            }
            else if (uploadFiles.Count == 1 && uploadFiles[0].FileName == "loadingCert.txt")
            {
                try
                {
                    if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/loadingCert" + idsession + ".txt"))
                        System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/temp/loadingCert" + idsession + ".txt", "");
                }
                catch { }
            }
            else if (uploadFiles.Count == 1 && uploadFiles[0].FileName == "Cert.txt")
            {
                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/Cert" + idsession + ".txt"))
                {
                    HttpPostedFile postedFile = uploadFiles[0];
                    postedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/temp/Cert" + idsession + ".txt");
                }
            }
            else
            {
                for (i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    Guid guidOutput;
                    bool isValid = Guid.TryParse(postedFile.FileName.Split('.')[0], out guidOutput);
                    if (!isValid)
                    {
                        try
                        {
                            postedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + postedFile.FileName);
                        }
                        catch { }
                        // obter o conteudo do recurso
                        string recSer = Request.Params["rec"];

                        // decifra o ticket, devolvendo um array com os objectos instanciados
                        object[] objs = QResources.DecryptTicketBase64(recSer);
                        // na primeira posição do array está o IP
                        string username = (string)objs[0];
                        string ip = (string)objs[1];

                        // valida o IP e o username
                        if (!username.Equals(utilizador.Name) && !ip.Equals(Request.UserHostAddress))
                            throw new Exception("Invalid ticket");

                        // na segunda posição do array está o objecto do recurso
                        Resource rec = (Resource)objs[2];

                        // cria-se um suporte persistente e invoca-se a função que devolve o conteúdo do recurso
                        PersistentSupport sp = PersistentSupport.getPersistentSupport(utilizador.Year, utilizador.Name);
                        field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();
                        byte[] file = System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + postedFile.FileName);
                        DbArea baseklass = (DbArea)Area.createArea(nometabela.Substring(3).ToLower(), utilizador, utilizador.CurrentModule);
                        CSGenioAdocums docums = CSGenioAdocums.search(sp, coddocums, utilizador);
                        sp.openTransaction();
                        docums.duplicate(sp, CriteriaSet.And().Equal(CSGenioAdocums.FldCoddocums, coddocums));
                        docums.ValZzstate = 0;
                        docums.ValDatacria = DateTime.Now;
                        docums.updateDirect(sp);
                        coddocums = docums.ValCoddocums;
                        RequestedField campo = new RequestedField(baseklass.Alias + "." + baseklass.PrimaryKeyName, baseklass.Alias);
                        campo.Value = codtabela;
                        campo.FieldType = FieldType.CHAVE_PRIMARIA;
                        baseklass.Fields.Add(baseklass.Alias + "." + baseklass.PrimaryKeyName, campo);
                        string nomedoc = postedFile.FileName.Replace("Sign", "");
                        string auxnome = nomedoc.Substring(0, (nomedoc.Length - nomedoc.Split('.').Last().Length - 1));
                        auxnome = auxnome.Substring(0, auxnome.Length - 36);
                        baseklass.submitDocum(sp, field, file, auxnome + "." + nomedoc.Split('.').Last() + "_" + coddocums, "SUBM", (int.Parse(versao) + 1).ToString());
                        baseklass.updateDirect(sp);
                        sp.closeTransaction();
                        try
                        {
                            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + nomedoc))
                                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + nomedoc);
                            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + postedFile.FileName))
                                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + postedFile.FileName);
                            string nomeaux = nomedoc.Replace(auxnome, "").Replace(".pdf", "");
                            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/nome" + nomeaux + ".txt"))
                                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/temp/nome" + nomeaux + ".txt");
                        }
                        catch { }
                    }
                }
                try
                {
                    if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + idsession + ".txt"))
                        System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/temp/" + idsession + ".txt", "");
                }
                catch { }
            }
        }
    }
</script>
