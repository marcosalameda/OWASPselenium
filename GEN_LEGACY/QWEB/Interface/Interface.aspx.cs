using System;
using CSGenio.framework;
using System.Web;

namespace CSGenio
{
	/// <summary>
	///Classe que faz a ligação da classe de negócio com a Interface Cliente
	/// </summary>
	public partial class Interface : System.Web.UI.Page
	{
      
		private void Page_Load(object sender, System.EventArgs e)
		{
			processRequest();
		}

        //------------------------------------------------
        ////variaveis de controlo to a thread de online-offline        
        ///// <summary>
        ///// Indica se nos consideramos actualmente online ou não
        ///// </summary>
        //protected volatile static bool online = true;
        ///// <summary>
        ///// Indica se a thread daemon já esta a correr
        ///// </summary>
        //protected volatile static bool daemonRunning = false;
        ///// <summary>
        ///// Por esta variável a true caso se queira parar correctamente a thread Daemon.
        ///// To uma paragem abortiva usar daemonThread.Abort() que causa o lançamento de uma excepção.
        ///// </summary>
        //protected volatile static bool daemonStop = false;
        ///// <summary>
        ///// Second entre cada tentativa de reconexão quando se está offline
        ///// </summary>
        //protected const double SecondsBetweenConnectionRetry = 5.0;
        ////------------------------------------------------        
        ///// <summary>
        ///// Identificador deste Iis (caso seja necessário)
        ///// </summary>
        //protected static Guid IisId = Guid.NewGuid();
        ///// <summary>
        ///// A thread daemon (deve ser um singleton)
        ///// </summary>
        //protected volatile static Thread daemonThread;
        //protected volatile static object mutex = new object();
        ////------------------------------------------------

        ///// <summary>
        ///// Url onde tentar descobrir se o servidor está online (Isto deve vir da configuração)
        ///// </summary>
        //const string onlineUrl = "http://localhost:1522/Interface/";

        ///// <summary>
        ///// Envia um pedido de http sincrono to um determinado url
        ///// </summary>
        ///// <param name="url">O url de target</param>
        ///// <param name="data">Os dados do pedido (assume xml)</param>
        ///// <param name="timeoutMiliseconds">Os milisegundos de espera até o envio falhar</param>
        ///// <returns>A resposta ao pedido</returns>
        //public static string MakeHttpRequest(string url, string data, int timeoutMiliseconds)
        //{
        //    // Prepare web request...
        //    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
        //    // We use POST ( we can also use GET )
        //    myRequest.Method = "POST";
        //    // Set the content type to a FORM
        //    myRequest.ContentType = "text/xml";

        //    if (data.Length > 0)
        //    {
        //        ASCIIEncoding encoding = new ASCIIEncoding();
        //        byte[] buffer = encoding.GetBytes(data);
        //        // Get length of content
        //        myRequest.ContentLength = buffer.Length;
        //        // Get request stream
        //        Stream newStream = myRequest.GetRequestStream();
        //        // Send the data
        //        newStream.Write(buffer, 0, buffer.Length);
        //        // Close stream
        //        newStream.Close();
        //    }

        //    // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
        //    // myRequest.KeepAlive = true; //Pode ser interessante explorar o true e o false desta propriedade
        //    myRequest.Timeout = timeoutMiliseconds;
        //    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();
        //    // Display the contents of the page to the console.
        //    Stream streamResponse = myHttpWebResponse.GetResponseStream();
        //    // Get stream object
        //    StreamReader streamRead = new StreamReader(streamResponse);
        //    // Prefiro ler tudo de uma vez, as mensagem não devem ser grandes
        //    string replyText = streamRead.ReadToEnd();
        //    // Release the response object resources.
        //    streamRead.Close();
        //    streamResponse.Close();

        //    // Close response
        //    myHttpWebResponse.Close();

        //    return replyText;

        //}

        ///// <summary>
        ///// Envia um 'ping' por http request ao servidor
        ///// </summary>
        //public static bool PingOnline(int timeoutMilliseconds)
        //{
        //    string replyText = "";
        //    try
        //    {
        //        replyText = MakeHttpRequest(onlineUrl + "Online.aspx", "", timeoutMilliseconds);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    return replyText.Contains("Ok");
        //}

        ///// <summary>
        ///// Thread de coordenação com o servidor central
        ///// </summary>
        //public static void daemonProc()
        //{
        //    //se por acaso tivemos muito azar e iniciámos 2 threads matamos uma delas
        //    lock(daemonRunning)
        //    {
        //      if(daemonRunning)
        //        return;
        //    }
        //    daemonRunning = true;
            
        //    try
        //    {
        //        //here we could launch a timer service or a singleton long running task
        //        while (!daemonStop)
        //        {
        //            Thread.Sleep((int)SecondsBetweenConnectionRetry);

        //            //welcome to haell
        //            if (!online)
        //            {
        //                //fazemos um 'ping' por http ao servidor to ver se já está online de novo
        //                //o timeout pode ser demorado pois não estamos a gastar processamento
        //                if (PingOnline(2000)) //TODO: Configurar este timeout
        //                    online = true; //passamos a online
        //            }
        //            else
        //            {
        //                //percorrer todas as tables verificar que tables têm a sincronização desactualizada e agendar
        //                DateTime now = DateTime.Now;
        //                List<AreaInfo> tables = new List<AreaInfo>();
        //                foreach (AreaInfo area in Area.ListaAreas.Values)
        //                    if (area.IsDomain && area.NextSync < now)
        //                        tables.Add(area);

        //                if (tables.Count > 0)
        //                {
        //                    //----------------------------------------------------------
        //                    // SINCRONIZAR
        //                    // Enquanto poe cada table a sincronizar faz set ao areaXXX.EmSicronizacao = true e poe a false no fim
        //                    // isto pode permitir que se bloqueie apenas certos pedidos com "Esta funcionalidade esta em manutenção... aguarde alguns segundos"
        //                    //
        //                    // sempre que se sincroniza adiciona-se a areaXXX.NextSync o timespan de areaXXX.SyncInterval
        //                    //----------------------------------------------------------
        //                    foreach (AreaInfo dom in tables)
        //                    {
        //                        //TODO: Sincronizacao incremental
        //                        //tables.SincronizacaoIncremental();
        //                        dom.NextSync = now + dom.SyncIncrementalPeriod;
        //                        //simular um rebentanço durante a sincronização
        //                        //throw new Exception("I wonder what this red button does...");
        //                    }
        //                }

        //                //TODO: Fazer as sincronizações completas
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        //TODO: log the error
        //    }
        //    daemonStop = false;
        //    daemonRunning = false;
        //}

	
    /// <summary>
    /// Método to processar os pedidos vindo da interface
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
	protected void processRequest()
	{
		Response.ContentType="text/xml";

		// RR - alterei o POST to o format standard no Qweb
		// agora podem-se aceder as variáveis do form da forma correcta
		string xml = Request.Form.Get("xmldata");

        //----------------------------------------------------------------------------------------------
        ////como temos uma thread a correr no backgroud que nos pode mudar esta variavel
        //// é melhor sacar logo o Qvalue actual dela to termos um comportamento coerente durante todo o
        //// processamento da resposta.
        //bool areOnline = online; 

        ////TODO: Aqui temos de decidir se contactamos o servidor ou apenas lidamos com o serviço localmente

        ////Decidimos que vamos contactar o servidor:
        //bool servidor = true;
        //if (areOnline && servidor)
        //{
        //    try
        //    {
        //        //vou fazer um fake só mesmo to poder testar o online-offline
        //        //Aqui vai surgir a questão da Session no servidor e como vamos partilhar esta
        //        //temos de ter em conta os EPH do user logo necessitamos de o partilhar de alguma forma
        //        //(talvez caso o login-logoff façam tambem relay to o servidor se resolva...)
        //        //throw new Exception("server went bye bye");
        //        string replyServer = MakeHttpRequest(onlineUrl + "servidor.aspx", xml, 2000);
        //    }
        //    catch(Exception ex)
        //    {
        //        //vamos ficar offline
        //        online = false;
        //    }
        //}

        ////lançar a thread de offline/online caso ainda não esteja lançada. Ironicamente este lançamento da thread tem problemas
        ////de multithreading. Tentei por a escrita da variável antes do test mas mesmo assim acho que pode haver problemas.
        ////Não queria por aqui uma secção crítica.
        //if (!daemonRunning)
        //{
        //    lock(mutex)
        //    {
        //      if(!daemonRunning)
        //      {
        //        daemonRunning = true;
        //        daemonThread = new Thread(new ThreadStart(daemonProc));
        //        daemonThread.Start();
        //        //As threads são melhores to tarefas de longa duração que os QueueUserWorkItem que usam o pool limitado de threads do Iis
        //        //Além disso têm melhor suporte to fazer Abort pause e resume caso seja necessário
        //        //ThreadPool.QueueUserWorkItem(new WaitCallback(daemonProc));
        //      }
        //    }
        //}
        //----------------------------------------------------------------------------------------------

        if (Log.IsDebugEnabled)
        {
            Log.Debug("Pedido xml");
            Log.Debug(xml);
        }

        DateTime ini = DateTime.Now;

        QcomBlk res = InterfaceXml.processRequest(new SessaoWeb(this), Qweb2Qcom.Deserialize(xml), Request.UserHostAddress);
        string resXml = Qweb2Qcom.Serialize(res);

        TimeSpan delta = DateTime.Now - ini;

        if (Log.IsDebugEnabled)
        {
            Log.Debug(string.Format("Terminou o processamento do pedido xml. [tempo] {0}ms", delta.Milliseconds.ToString()));
            Log.Debug(resXml);
        }
        
        Response.Write(resXml);
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
