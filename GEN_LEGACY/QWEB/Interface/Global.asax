<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        log4net.Config.XmlConfigurator.Configure();

        //GenioServer services
        CSGenio.GenioDIDefault.Use();

        Quidgest.AssemblyResolver.AssemblyResolver.Initialize("Bin/Libs");

        //JGF 2019.03.27 No matter where the configuration file is, when it's changed the app pool must be restarted
        CSGenio.framework.Configuration.ConfigWatcher.Changed += new System.IO.FileSystemEventHandler(RestartAppPool);
	}
        
    private static void RestartAppPool(object sender, System.IO.FileSystemEventArgs e)
    {
        HttpRuntime.UnloadAppDomain();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started        
        GenioServer.security.GlobalAppSessions.Instance.AddOrUpdate(this.Session.SessionID);
    }

    void Session_End(object sender, EventArgs e) 
    {
        GenioServer.security.GlobalAppSessions.Instance.Remove(this.Session.SessionID);
        
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
