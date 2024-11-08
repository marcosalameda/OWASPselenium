<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<%
	//********** obter os parametros passados pelo qweb e torna-los disponíveis para depois do submit
    string Ifile = Request.QueryString[0].ToString();
    string Ipath = Request.PhysicalPath;
    int i=Ipath.LastIndexOf("\\");
    Ipath=Ipath.Substring(0,i);
    SetParm(Ifile, Ipath, Ifile.Contains("sessionIDqaddin"));
 %>

<script runat="server">

    //********** variáveis onde vão ficar disponíveis os parametros passados ao aspx mesmo depois do submit
    static string Path = "";
    static string File = "";
    
    //********** guardar as variáveis dos parametros
    protected void SetParm(string wfile, string wpath, bool addin)
    {
    	File=wfile;
    	Path=wpath;
        
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
        	String fileExt = fileName.Substring(i+1);
        	//Obter path onde vai ser guardado com nome pre-definido e a extensão obtida
        	String savePath = Path + "\\temp\\" +fileName.Substring(0,i)+"_"+ File + "." + fileExt;
        	FileUpload1.SaveAs(savePath);
        	UploadStatusLabel.Text = "Ficheiro enviado com sucesso";
        	CtlLabel.Text = savePath.Replace(" ", "!");
    	}
    	else
    	{      
        	UploadStatusLabel.Text = "Não foi especificado ficheiro a enviar";
        	CtlLabel.Text = "";
    	}
	}
  protected void UploadAddin() {

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
      catch (Exception ex) {
          Response.Write("@ERROR" + ex.Message + "ERROR@");
    }
 
  }

  
</script>

<html lang="en">
<head id="Head1" runat="server">
    <title>Qweb upload de ficheiros</title>
    <link rel="stylesheet" type="text/css" href="qwebupload.css">
</head>
<body scroll="no" bgcolor="transparent">
    <form id="form1" runat="server">
    <div>
       <p class="TXTINFO">Seleccione o ficheiro a enviar:</p>
   
       <asp:FileUpload id="FileUpload1"                 
           runat="server" class="FILUPLOAD">
       </asp:FileUpload>
            
	<br/><br/>
              
       <asp:Button id="UploadButton" 
           Text="Enviar"
           OnClick="UploadButton_Click"
           runat="server" class="BOTOK">
       </asp:Button>

	<input type="button" value="Cancelar" onclick="Cancelar()" class="BOTCAN"/>
	
	<br/>
       
       <asp:Label id="UploadStatusLabel"
           runat="server" class="TXTSTATUS">
       </asp:Label>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
       <asp:Label id="CtlLabel"
           runat="server">
       </asp:Label>
    </div>
    </form>
</body>
</html>


<script type="text/javascript" language="javascript">
//************* script de cliente para poder comunicar com o qweb  -  detectar se a mensagem indica que o ficheiro foi enviado
var BrowserIE=false
var BrowserMOZ=false
var BrowserOP=false
var BrowserName = navigator.appName.toUpperCase()
if (BrowserName.indexOf("INTERNET EXPLORER") > -1) {
	BrowserIE=true
} else {
	if (BrowserName.indexOf("NETSCAPE") > -1) {
		BrowserMOZ=true
	} else {
		if (BrowserName.indexOf("OPERA") > -1) {
			BrowserOP=true
		} else {
			BrowserIE=true
		}
	}
}


var lbl=document.getElementById("CtlLabel")
var wmsg=lbl.innerHTML
if (wmsg != "") {
	var wframe=window.frameElement
	var re=/!/g
	wframe.qwebp=wmsg.replace(re, " ")
        //*********** é um evento idiota mas isto permite-me saber (no qweb) que foi enviado
	if (BrowserIE) {
		wframe.fireEvent("onresizestart")
	} else {
    var evt = document.createEvent("HTMLEvents")
    evt.initEvent("submit", false, false)
    var r=wframe.dispatchEvent(evt)
  }
} 

function Cancelar() {
	var wframe=window.frameElement
	wframe.qwebp=""
	//********** outro evento idiota mas permite-me saber (no qweb) que foi cancelado
	if (BrowserIE) {
		wframe.fireEvent("onmove")
	} else {
    var evt = document.createEvent("HTMLEvents")
		evt.initEvent("reset", false, false)
    var r=wframe.dispatchEvent(evt)
  }
}
</script>