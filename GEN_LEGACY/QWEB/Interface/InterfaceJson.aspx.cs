using System;
using CSGenio.framework;
using System.Web;

namespace CSGenio
{
	/// <summary>
	///Classe que faz a ligação da classe de negócio com a Interface Cliente
	/// </summary>
	public partial class InterfaceJson : System.Web.UI.Page
	{
      
		private void Page_Load(object sender, System.EventArgs e)
		{
			processRequest();
		}

    /// <summary>
    /// Método to processar os pedidos vindo da interface
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
	protected void processRequest()
	{
        //for JSONP
        Response.ContentType = "application/javascript"; 
        //for JSON
        //Response.ContentType = "application/json"; 

		// RR - alterei o POST to o format standard no Qweb
		// agora podem-se aceder as variáveis do form da forma correcta
		string xml = Request.Form.Get("jsondata");

        if (Log.IsDebugEnabled)
        {
            Log.Debug("Pedido json");
            Log.Debug(xml);
        }

        DateTime ini = DateTime.Now;

        QcomBlk res = InterfaceXml.processRequest(new SessaoWeb(this), Json2Qcom.Deserialize(xml), Request.UserHostAddress);
        string resJson = Json2Qcom.Serialize(res);

        TimeSpan delta = DateTime.Now - ini;

        if (Log.IsDebugEnabled)
        {
            Log.Debug(string.Format("Terminou o processamento do pedido xml. [tempo] {0}ms", delta.Milliseconds.ToString()));
            Log.Debug(resJson);
        }

        Response.Write(resJson);
		HttpContext.Current.ApplicationInstance.CompleteRequest();
        return;
	}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
