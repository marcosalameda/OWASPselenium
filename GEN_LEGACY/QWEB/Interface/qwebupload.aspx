<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
	//********** obter os parametros passados pelo qweb e torna-los disponíveis para depois do submit
    string Ilang = Request.QueryString[0].ToString();
    string Ifile = Request.QueryString[1].ToString();
    string Ipath = Request.PhysicalPath;
    int i=Ipath.LastIndexOf("\\");
    Ipath=Ipath.Substring(0,i);
    SetParm(Ifile, Ilang, Ipath, Ifile.Contains("sessionIDqaddin"));
%>

<script runat="server">

    //********** variáveis onde vão ficar disponíveis os parametros passados ao aspx mesmo depois do submit
    static string Path = "";
    static string File = "";

    //********** guardar as variáveis dos parametros
    protected void SetParm(string wfile, string wlang, string wpath, bool addin)
    {
        File = wfile;
        Path = wpath;

        if (addin)
            UploadAddin();
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            //Obter a extensão do ficheiro recebido
            String fileName = FileUpload1.FileName;
            int i = fileName.LastIndexOf(".");
            String fileExt = fileName.Substring(i + 1);
            //Obter path onde vai ser guardado com nome pre-definido e a extensão obtida
            String savePath = Path + "\\temp\\" + fileName.Substring(0, i) + "_" + File + "." + fileExt;
            FileUpload1.SaveAs(savePath);
            UploadStatusLabel.Text = "Ficheiro enviado com sucesso";
            CtlLabel.Text = savePath.Replace(" ", "!");
        }
        else
        {
            UploadStatusLabel.Text = "Ficheiro inválido ou não especificado";
            CtlLabel.Text = "";
        }
    }

    protected void UploadAddin()
    {
        try
        {
            //Obter a extensão do ficheiro recebido
            HttpPostedFile hfile = Request.Files[0];
            string fname = Request.QueryString[0].ToString();
            String[] separator = { "sessionIDqaddin:" };
            String[] split = fname.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
            String savePath = Path + "\\temp\\" + "ID_" + split[0];
            hfile.SaveAs(savePath);
            Response.Write("@DONE@");
        }
        catch (Exception ex)
        {
            Response.Write("@ERROR" + ex.Message + "ERROR@");
        }
    }
</script>

<html>
<head id="Head1" runat="server">
    <title>Qweb upload de ficheiros</title>
    <link rel="stylesheet" type="text/css" href="css/qwebupload.css">
</head>
<body scroll="no" bgcolor="transparent">
    <form id="form1" runat="server">
        <div>
            <p class="TXTINFO">Seleccione o ficheiro a enviar:</p>

            <asp:FileUpload ID="FileUpload1"
                runat="server" class="FILUPLOAD"></asp:FileUpload>

            <br />
            <br />

            <asp:Button ID="UploadButton"
                Text="Enviar"
                OnClick="UploadButton_Click"
                runat="server" class="BOTOK"></asp:Button>

            <input type="button" value="Limpar" onclick="Limpar()" class="BOTCAN" />
            <input type="button" value="Cancelar" onclick="Cancelar()" class="BOTCAN" />

            <br />

            <asp:Label ID="UploadStatusLabel"
                runat="server" class="TXTSTATUS">
            </asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="CtlLabel"
                runat="server">
            </asp:Label>
        </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    //************* script de cliente para poder comunicar com o qweb  -  detectar se a mensagem indica que o ficheiro foi enviado
    var lbl = document.getElementById("CtlLabel")
    var wmsg = lbl.innerHTML
    var wframe = window.frameElement
    if (wmsg != "") {
        var re = /!/g
        wframe.qwebp1 = wmsg.replace(re, " ")
        wframe.status = "OK"
        //*********** desencadear um evento para informar o qweb que foi enviado
        if (document.createEvent) {
            var evt = document.createEvent("HTMLEvents")
            evt.initEvent("submit", false, false)
            console.log(wframe);
            var r = wframe.dispatchEvent(evt)
        } else {
            wframe.fireEvent("onresizestart")
        }
    }

    function Cancelar() {
        var wframe = window.frameElement
        wframe.qwebp1 = ""
        wframe.status = "CANCEL"
        //*********** desencadear um evento para informar o qweb que foi enviado
        if (document.createEvent) {
            var evt = document.createEvent("HTMLEvents")
            evt.initEvent("submit", false, false)
            var r = wframe.dispatchEvent(evt)
        } else {
            wframe.fireEvent("onresizestart")
        }
    }

    function Limpar() {
        var wframe = window.frameElement
        wframe.qwebp1 = ""
        wframe.status = "OK"
        //*********** desencadear um evento para informar o qweb que foi enviado
        if (document.createEvent) {
            var evt = document.createEvent("HTMLEvents")
            evt.initEvent("submit", false, false)
            var r = wframe.dispatchEvent(evt)
        } else {
            wframe.fireEvent("onresizestart")
        }
    }
</script>
