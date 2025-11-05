<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
	//********** obter os parametros passados pelo qweb e torna-los disponíveis para depois do submit
    string Ifile = Request.QueryString[1].ToString();
    string modo = Request.QueryString[0].ToString();
    string Ipath = Request.PhysicalPath;
    
    int i=Ipath.LastIndexOf("\\");
    Ipath=Ipath.Substring(0,i);
    SetParm(modo, Ifile, Ipath, Ifile.Contains("sessionIDqaddin"));
%>
<script runat="server">

    //********** variáveis onde vão ficar disponíveis os parametros passados ao aspx mesmo depois do submit
    static string Path = "";
    static string File = "";
    static string majorv = "";
    static string minorv = "";
    static string modo = "";
    string errMsg = "";
    string errMsgcode = "";

    //********** guardar as variáveis dos parametros
    protected void SetParm(string mode, string wfile, string wpath, bool addin)
    {
        File = wfile;
        Path = wpath;
        modo = mode;
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
            errMsg = "Ficheiro vazio";
            errMsgcode = "88";
            return;
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
            }
            catch (System.IO.PathTooLongException)
            {
                errMsg = "Nome do ficheiro ou o caminho completo de gravação muito extenso";
                errMsgcode = "89";
                return;
            }
            UploadStatusLabel.Text = "Ficheiro enviado com sucesso";
            CtlLabel.Text = savePath.Replace(" ", "!");

            resposta = fileName + "_" + File + "/" + mode + "/" + version;

            String modoEnviar = modo.Equals("anex") ? "Anexar" : "Subm";

            // a tag script foi separada em duas com concatenação de strings para não dar erro de parsing no aspx (o parser pensa que se está a fechar o script da página)
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>parent.ExecCmd('','SetHistorial(modo," + modoEnviar + "{SetHistorial(path," + resposta + "{ClosePage(KeepHist{UpdateCtls')</scrip" + "t>");

        }
        else
        {
            // a tag script foi separada em duas com concatenação de strings para não dar erro de parsing no aspx (o parser pensa que se está a fechar o script da página)
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>parent.ExecCmd('','SetHistorial(modo,Subm{SetHistorial(path," + resposta + "{ClosePage(KeepHist{UpdateCtls')</scrip" + "t>");
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
    <link rel="stylesheet" type="text/css" href="css/qwebuploadFC.css">
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

            <!--input type="button" value="Cancelar" onclick="Cancelar()" class="BOTCAN"/-->

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
            <%if (errMsg.Length > 0)
                {%>
            <script language="JavaScript">window.alert(parent.GetMsg(<% =errMsgcode %>, '<% =errMsg %>'))</script>
            <% } %>
            <asp:Label ID="CtlLabel"
                runat="server">
            </asp:Label>
        </div>
    </form>
</body>
</html>
