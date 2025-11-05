<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
	//********** obter os parametros passados pelo qweb e torna-los disponíveis para depois do submit
    string lang = Request.QueryString[0].ToString();
    string modo = Request.QueryString[1].ToString();
    string Ifile = Request.QueryString[2].ToString();
    string Ipath = Request.PhysicalPath;
    int i=Ipath.LastIndexOf("\\");
    Ipath=Ipath.Substring(0,i);
    SetParm(lang, modo, Ifile, Ipath, Ifile.Contains("sessionIDqaddin"));
%>

<script runat="server">

    //********** variáveis onde vão ficar disponíveis os parametros passados ao aspx mesmo depois do submit
    static string Path = "";
    static string File = "";
    static string majorv = "";
    static string minorv = "";
    static string modo = "";
    static string Lang = "";
    //string errMsg = "";
    //string errMsgcode = "";

    //********** guardar as variáveis dos parametros
    protected void SetParm(string lang, string mode, string wfile, string wpath, bool addin)
    {
        File = wfile;
        Path = wpath;
        modo = mode;
        Lang = lang;
        string[] value = File.Split('|');

        if (modo.Equals("anex"))
        {
            minorversion.Visible = false;
            majorversion.Visible = false;
            desbl.Visible = false;
            gravar.Visible = false;
            subm.Visible = false;
            TXTSUBM.Visible = false;
        }
        else
        {
            minorv = (Double.Parse(value[0].Replace(".", ",")) + 0.1).ToString().Replace(",", ".");
            majorv = Convert.ToInt32((Double.Parse(value[0].Replace(".", ",")) + 1.0)).ToString();
            minorversion.Text = minorv;
            majorversion.Text = majorv;
        }

        if (addin)
            UploadAddin();
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string resposta = "";
        string[] value = File.Split('|');
        String fileName = "";

        string mode = "";
        string version = "0";

        if (!modo.Equals("anex"))
        {
            if (desbl.Checked)
                mode = "DESBL";
            else if (subm.Checked)
            {
                mode = "SUBM";
                if (minorV.Checked)
                    version = minorv;
                else
                    version = majorv;
            }
            else
                mode = "GRAVAR";

            resposta = fileName + "_" + value[1] + "/" + mode + "/" + version;
        }

        if (FileUpload1.FileName.Length > 0 && FileUpload1.FileContent.Length == 0)
        {
            UploadStatusLabel.Text = "Ficheiro vazio";
            CtlStatus.Text = "ERROR";
            CtlRes1.Text = "88";
        }

        if (FileUpload1.HasFile)
        {
            //Obter a extensão do ficheiro recebido
            fileName = FileUpload1.FileName;
            int i = fileName.LastIndexOf(".");
            String fileExt = fileName.Substring(i + 1);

            if (!modo.Equals("anex"))
                File = value[1];

            String savePath = Path + "\\temp\\" + fileName + "_" + File;
            try
            {
                FileUpload1.SaveAs(savePath);
                UploadStatusLabel.Text = "Ficheiro enviado com sucesso";
                String modoEnviar = modo.Equals("anex") ? "Anexar" : "Subm";
                resposta = fileName + "_" + File + "/" + mode + "/" + version;
                CtlStatus.Text = "OK";
                CtlRes1.Text = modoEnviar;
                CtlRes2.Text = resposta;
                CtlRes3.Text = "";
            }
            catch (System.IO.PathTooLongException)
            {
                UploadStatusLabel.Text = "Nome do ficheiro ou o caminho completo de gravação muito extenso";
                CtlStatus.Text = "ERROR";
                CtlRes1.Text = "89";
            }
        }
        else
        {
            resposta = fileName + "_" + File + "/" + mode + "/" + version;
            CtlStatus.Text = "OK";
            CtlRes1.Text = "Subm";
            CtlRes2.Text = resposta;
            CtlRes3.Text = "";
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

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Qweb upload de ficheiros</title>
    <link rel="stylesheet" type="text/css" href="css/qwebuploadFC.css" />
</head>
<body style="overflow: hidden; background-color: transparent;">
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

            <input type="button" value="Cancelar" onclick="Cancelar()" class="BOTCAN" />

            <br />
            <p runat="server" id="TXTSUBM">
                <p class="TXTSUBM">
                    <asp:RadioButton ID="desbl" GroupName="option" runat="server" />
                    Desbloquear: ignora as alterações actuais e o documento vai ficar livre para alterações.</p>
                <!--p class="TXTSUBM"><asp:RadioButton id="gravar" GroupName="option" runat="server"/>Gravar: o docuemnto vai manter-se bloqueado e apenas vai salvaguardar o que alterou até agora.</p-->
                <p class="TXTSUBM">
                    <asp:RadioButton ID="subm" GroupName="option" Checked="True" runat="server" />
                    Submeter: o documento vai ficar livre para alterações adicionais e vai ser criada uma nova versão.</p>

                <p class="TXTSUBM">
                    <asp:RadioButton ID="minorV" GroupName="versions" runat="server" />Minor Version:
            <asp:TextBox ID="minorversion" Columns="1" runat="server" ReadOnly="True" />
                </p>
                <p class="TXTSUBM">
                    <asp:RadioButton ID="majorV" Checked="True" GroupName="versions" runat="server" />Major Version:
            <asp:TextBox ID="majorversion" Columns="1" runat="server" ReadOnly="True" />
                </p>
                <br />
            </p>
            <asp:Label ID="UploadStatusLabel"
                runat="server" class="TXTSTATUS">
            </asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="CtlStatus"
                runat="server">
            </asp:Label>
            <asp:Label ID="CtlRes1"
                runat="server">
            </asp:Label>
            <asp:Label ID="CtlRes2"
                runat="server">
            </asp:Label>
            <asp:Label ID="CtlRes3"
                runat="server">
            </asp:Label>
        </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    //************* script de cliente para poder comunicar com o qweb. Posiciona as variaveis e desencadeia um evento para o qweb saber que acabou
    var wframe = window.frameElement
    var lbl = document.getElementById("CtlStatus")
    wframe.status = lbl.innerHTML
    var lbl = document.getElementById("CtlRes1")
    wframe.qwebp1 = lbl.innerHTML
    var lbl = document.getElementById("CtlRes2")
    wframe.qwebp2 = lbl.innerHTML
    var lbl = document.getElementById("CtlRes3")
    wframe.qwebp3 = lbl.innerHTML

    //*********** desencadear um evento para informar o qweb que foi enviado
    if (document.createEvent) {  //se o browser aceitar o createEvent faz o evento submit senão (IE8) faz o evento onsizerestart
        var evt = document.createEvent("HTMLEvents")
        evt.initEvent("submit", false, false)
        var r = wframe.dispatchEvent(evt)
    } else {
        wframe.fireEvent("onresizestart")
    }

    function Cancelar() {   //vem por aqui quando o utilizador clica no botão Cancelar
        var wframe = window.frameElement
        wframe.qwebp1 = ""
        wframe.qwebp2 = ""
        wframe.qwebp3 = ""
        wframe.status = "CANCEL"
        //*********** desencadear um evento para informar o qweb que foi enviado
        if (document.createEvent) {  //se o browser aceitar o createEvent faz o evento submit senão (IE8) faz o evento onsizerestart
            var evt = document.createEvent("HTMLEvents")
            evt.initEvent("submit", false, false)
            var r = wframe.dispatchEvent(evt)
        } else {
            wframe.fireEvent("onresizestart")
        }
    }
</script>
