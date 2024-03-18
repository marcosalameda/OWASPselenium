using Administration.AuxClass;
using CSGenio;
using CSGenio.business;
using CSGenio.framework;
using System.Globalization;
using System.Text;
using System.Net;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using DbAdmin;

namespace Administration.Controllers
{
    public class ConfigController : ControllerBase
    {
        private readonly string pathConfig = Path.Combine(CSGenio.framework.Configuration.GetConfigPath(), "Configuracoes.xml");

        [HttpGet]
        public IActionResult Index()
        {
            var appId = FromQuery("appId");
            return Index(null, appId);
        }

        private IActionResult Index(string resultMsg, string appId)
        {
            if (!AuxFunctions.CheckXMLIsValid())
                return Json(new { redirect = "config_migration" });

            var model = new Models.ConfigModel();
            model.Applications = ClientApplication.Applications;
            model.ResultMsg = resultMsg ?? "";

            try
            {
                var conf = ConfigurationXML.readXML(pathConfig);

                //----------------
                // Database
                //----------------
                if (!conf.DataSystems.Any(ds => ds.Name == CurrentYear))
                {
                    if (!conf.DataSystems.Any()) // Se não houver nenhum DataSystem, cria um default.
                        createDataSystem(CSGenio.framework.Configuration.DefaultYear, string.Format("{0}{1}", CSGenio.framework.Configuration.Acronym, CSGenio.framework.Configuration.DefaultYear), conf);
                    return Json(new { reload = true, system = CSGenio.framework.Configuration.DefaultYear });
                }

                var dataSystem = CSGenio.framework.Configuration.ResolveDataSystem(CurrentYear, CSGenio.framework.Configuration.DbTypes.NORMAL);
                if (dataSystem != null)
                {
                    model.Schema = dataSystem.Schemas[0].Schema; //<-- TODO: Suportar configurações datasystems com BDs partilhadas
					model.ConnEncrypt = dataSystem.Schemas[0].ConnEncrypt;
					model.ConnWithDomainUser = dataSystem.Schemas[0].ConnWithDomainUser;

                    model.HideYears = conf.omiteAnos.ToUpper() == "S";  //<-- So este é que vai ao conf? faz sentido?
                    model.DbUser = Encoding.Unicode.GetString(Convert.FromBase64String(dataSystem.Login ?? string.Empty));
                    model.DbPsw = Encoding.Unicode.GetString(Convert.FromBase64String(dataSystem.Password ?? string.Empty));
                    model.Server = dataSystem.Server;
                    model.Service = dataSystem.Service;
					model.ServiceName = dataSystem.ServiceName;
                    model.Port = dataSystem.Port;

                    Enum.TryParse(dataSystem.Type, out HardCodedLists.DBMS serverType);// Default: SQLSERVER2008
                    model.ServerType = serverType;

                    /*
                     *  Read Log Database config
                     */
                    if (dataSystem.DataSystemLog != null && dataSystem.DataSystemLog.Schemas.Count > 0)
                    {
                        model.Log_Schema = dataSystem.DataSystemLog.Schemas[0].Schema;
                        model.Log_ConnEncrypt = dataSystem.DataSystemLog.Schemas[0].ConnEncrypt;
                        model.Log_ConnWithDomainUser = dataSystem.DataSystemLog.Schemas[0].ConnWithDomainUser;
                        model.Log_DbUser = Encoding.Unicode.GetString(Convert.FromBase64String(dataSystem.DataSystemLog.Login ?? string.Empty));
                        model.Log_DbPsw = Encoding.Unicode.GetString(Convert.FromBase64String(dataSystem.DataSystemLog.Password ?? string.Empty));
                        model.Log_Server = dataSystem.DataSystemLog.Server ?? string.Empty;
                        model.Log_Port = dataSystem.DataSystemLog.Port ?? string.Empty;
                        model.Log_Service = dataSystem.DataSystemLog.Service ?? string.Empty;
                        model.Log_ServiceName = dataSystem.DataSystemLog.ServiceName ?? string.Empty;
                    }

                }

                model.DefaultYear = CSGenio.framework.Configuration.DefaultYear;

                //----------------
                // Security
                //----------------
                model.Security = new Dictionary<string, Models.SecurityCfg>();
                foreach (var app in model.Applications)
                {
                    if (conf.Security.Find(x => x.Application == app.Id) != null)
                        app.Security = true;
                    model.Security[app.Id] = ReadSecurityConfig(app.Id, conf);
                }

                //----------------
                // Queues list
                //----------------
                model.MQueues = new Models.MessageQueue();
                model.MQueues.Queues = new List<Models.QueueCfg>();

                int rownum = 0;
                if (conf.MessageQueueing != null)
                {
                    conf.MessageQueueing.Journaltimeout = GlobalFunctions.atoi(model.MQueues.Journaltimeout);
                    conf.MessageQueueing.Maxsendnumber = GlobalFunctions.atoi(model.MQueues.Maxsendnumber);

                    foreach (var q in conf.MessageQueueing.Queues)
                    {
                        model.MQueues.Queues.Add(new Models.QueueCfg(q) { Rownum = rownum ++ });
                    }
                }
                else
                {
                    conf.MessageQueueing = new messagequeueing();
                }

                //----------------
                // ACK list
                //----------------
                model.MQueues.Acks = new List<Models.QueueACK>();

                rownum = 0;
                if (conf.MessageQueueing != null)
                {
                    foreach (var q in conf.MessageQueueing.ACKS)
                    {
                        model.MQueues.Acks.Add(new Models.QueueACK(q) { Rownum = rownum ++ });
                    }
                }

                //----------------
                // Others [PATHS , FORMATS , Elasticsearch]
                //----------------

                model.Paths = new Dictionary<string, Models.PathCfg>();
                foreach (var app in model.Applications)
                {
                    if (conf.Paths.Find(x => x.Application == app.Id) != null)
                        app.Path = true;
                    model.Paths[app.Id] = ReadPathConfig(app.Id, conf);
                }
                model.pathReports = conf.pathReports;
                model.ssrsServer = conf.ssrsServer.url;
                model.ssrsServerPath = conf.ssrsServer.path;
                model.isLocalReports = conf.ssrsServer.isLocalReports;
                model.ssrsServerDomain = conf.ssrsServer.Domain;
                model.ssrsServerUsername = Encoding.Unicode.GetString(Convert.FromBase64String(conf.ssrsServer.Username ?? string.Empty));
                model.ssrsServerPassword = Encoding.Unicode.GetString(Convert.FromBase64String(conf.ssrsServer.Password ?? string.Empty));

                model.DateFormat = new Models.DateFormatCfg();
                if (conf.DateFormat != null)
                {
                    model.DateFormat.date = conf.DateFormat.Date;
                    model.DateFormat.dateTime = conf.DateFormat.DateTime;
                    model.DateFormat.dateTimeSeconds = conf.DateFormat.DateTimeSeconds;
                    model.DateFormat.time = conf.DateFormat.Time;
                }

                model.QAEnvironment = Convert.ToBoolean(conf.QAEnvironment);

                var decimalSeparator = HardCodedLists.DisplayNumberFormatDecimal.Dot;
                var groupSeparator = HardCodedLists.DisplayNumberFormatGroup.None;
                if (conf.NumberFormat != null)
                {
                    Enum.TryParse(conf.NumberFormat.DecimalSeparator, out decimalSeparator);
                    model.DecimalSeparator = decimalSeparator;
                    switch (conf.NumberFormat.DecimalSeparator)
                    {
                        case ".":
                            model.DecimalSeparator = HardCodedLists.DisplayNumberFormatDecimal.Dot;
                            break;
                        case ",":
                            model.DecimalSeparator = HardCodedLists.DisplayNumberFormatDecimal.Comma;
                            break;
                        default:
                            model.DecimalSeparator = HardCodedLists.DisplayNumberFormatDecimal.Dot;
                            break;
                    }

                    Enum.TryParse(conf.NumberFormat.GroupSeparator, out groupSeparator);
                    model.GroupSeparator = groupSeparator;
                    switch (conf.NumberFormat.GroupSeparator)
                    {
                        case "":
                            model.GroupSeparator = HardCodedLists.DisplayNumberFormatGroup.None;
                            break;
                        case " ":
                            model.GroupSeparator = HardCodedLists.DisplayNumberFormatGroup.Blank;
                            break;
                        case ".":
                            model.GroupSeparator = HardCodedLists.DisplayNumberFormatGroup.Dot;
                            break;
                        case ",":
                            model.GroupSeparator = HardCodedLists.DisplayNumberFormatGroup.Comma;
                            break;
                        default:
                            model.GroupSeparator = HardCodedLists.DisplayNumberFormatGroup.None;
                            break;
                    }
                }

				// Convert dictionary to list
                foreach (var mp in conf.maisPropriedades)
                {
                    model.MoreProperties.Add(new Models.MorePropertyCfg(mp.Key, mp.Value));
                }

                // Elasticsearch List/table
                model.Cores = new List<Models.CoreCfg>();
                rownum = 0;
                if (conf.Elasticsearch != null)
                {
                    foreach (var c in conf.Elasticsearch.Colours)
                        model.Cores.Add(new Models.CoreCfg(c) { Rownum = rownum++ });
                }
                else
                {
                    conf.Elasticsearch = new ElasticsearchXml
                    {
                        Colours = new List<CoreXml>()
                    };
                }

                //----------------
                // Audit
                //----------------
                if (conf.Audit != null)
                {
                    model.RegistActions = conf.Audit.RegistActions;
                    model.RegistLoginOut = conf.Audit.RegistLoginOut;
					model.AuditInterface = conf.Audit.AuditInterface;
                }
                else
                {
                    model.RegistActions = false;
                    model.RegistLoginOut = false;
					model.AuditInterface = false;
                }

                // Event tracing feature
                model.EventTracking = conf.EventTracking;

                model.UrlAPIBackend = conf.ChatBotConfig?.apiURL;
                model.UrlSocketBackend = conf.ChatBotConfig?.websocketURL;
            }
            catch (Exception e)
            {
                model.Security = new Dictionary<String, Models.SecurityCfg>();
                model.MQueues = new Models.MessageQueue();
                model.MQueues.Queues = new List<Models.QueueCfg>();

                model.ResultMsg = Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper());
            }

            return Ok(model);
        }

        private Models.SecurityCfg ReadSecurityConfig(String appId, ConfigurationXML conf)
        {
            var model = new Models.SecurityCfg();

            var security = conf.GetSecurity(appId);

            model.AuthenticationMode = security.AuthenticationMode;
            model.AllowMultiSessionPerUser = security.AllowMultiSessionPerUser;
            model.AllowAuthenticationRecovery = security.AllowAuthenticationRecovery;
			model.Activate2FA = security.Activate2FA != GenioServer.security.Auth2FAModes.None; //change this when have multiple 2FA
			model.Mandatory2FA = security.Mandatory2FA;
            model.ExpirationDateBool = security.ExpirationDateBool;
            model.ExpirationDate = security.ExpirationDate;
            model.MinCharacters = Convert.ToInt32(security.MinCharacters);
            model.PasswordStrength = security.PasswordStrength;
            model.PasswordAlgorithms = security.PasswordAlgorithms;
            model.SessionTimeOut = security.SessionTimeOut;

            model.IdentityProviders = new List<Models.IdentityProviderCfg>();
            int rownum = 0;
            foreach (var ip in security.IdentityProviders)
                model.IdentityProviders.Add(new Models.IdentityProviderCfg(ip) { Rownum = rownum++ });

            model.RoleProviders = new List<Models.RoleProviderCfg>();
            rownum = 0;
            foreach (var rp in security.RoleProviders)
                model.RoleProviders.Add(new Models.RoleProviderCfg(rp) { Rownum = rownum++ });

            model.Users = new List<Models.UserCfg>();

            foreach (var u in security.Users)
                model.Users.Add(new Models.UserCfg(u) { Rownum = rownum++ });

            return model;
        }

        private Models.PathCfg ReadPathConfig(String appId, ConfigurationXML conf)
        {
            var model = new Models.PathCfg();
            var paths = conf.Paths.Find(x => x.Application == appId);
            if (paths != null)
            {
                model.pathApp = paths.pathApp;
                model.pathDocuments = paths.pathDocuments;
            }
            return model;
        }

        [HttpPost]
        public IActionResult CreateDataSystem([FromBody] JsonObject data)
        {
            ConfigurationXML conf = ConfigurationXML.readXML(pathConfig);
            string year = (string)data["year"];
            string schema = (string)data["schema"];
            createDataSystem(year, schema, conf);
            return Json(new { system = year });
        }

        private void createDataSystem(string year, string schemaName, ConfigurationXML conf)
        {
            if (conf.DataSystems.Any(ds => ds.Name == year))
                return;// Não cria DataSystem com mesmo Id

            var dataSystem = new DataSystemXml() { Name = year };

            var schema = new DataXml();
            schema.Id = CSGenio.framework.Configuration.Program;
            schema.Schema = schemaName;
			schema.ConnEncrypt = conf.connEncrypt;
			schema.ConnWithDomainUser = conf.connWithDomainUser;
            dataSystem.Schemas = new List<DataXml>() { schema };

            conf.DataSystems.Add(dataSystem);
            conf.writeXML(pathConfig);

            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);
        }

        [HttpPost]
        public IActionResult SaveConfigDatabase([FromBody]Models.ConfigModel model)
        {
            var appId = FromQuery("appId");
            bool hasLogDB = false;
            string year = CurrentYear; 

            try
            {
                SysConfiguration sysConfiguration = new SysConfiguration();

                model.ResultMsg = string.Empty;
				if (!ModelState.IsValid)
                {
                    string err = Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860 + Environment.NewLine + string.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    throw new BusinessException(err, "ConfigController.reindex", err);
                }

                if (string.IsNullOrEmpty(model.DbPsw) || (model.DbPsw != model.DbCheckPsw))
                    model.ResultMsg += Resources.Resources.A_PASSWORD_NAO_COINC35287;

                //Check log database user input
                if(!string.IsNullOrEmpty(model.Log_Server) || !string.IsNullOrEmpty(model.Log_Schema) || 
                    !string.IsNullOrEmpty(model.Log_DbPsw) || !string.IsNullOrEmpty(model.Log_DbCheckPsw) || !string.IsNullOrEmpty(model.Log_DbUser))
                {                    
                    if (string.IsNullOrEmpty(model.Log_Server) || string.IsNullOrEmpty(model.Log_Schema) ||
                    string.IsNullOrEmpty(model.Log_DbPsw) || string.IsNullOrEmpty(model.Log_DbCheckPsw) || string.IsNullOrEmpty(model.Log_DbUser))
                        throw new BusinessException(Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860, "ConfigController.reindex", Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860);

                    if (model.Log_DbPsw != model.Log_DbCheckPsw)
                        model.ResultMsg += Resources.Resources.A_PASSWORD_NAO_COINC35287;
					
					hasLogDB = true;
                }   

                if(hasLogDB && model.Schema.ToLower() == model.Log_Schema.ToLower())
                    throw new BusinessException(Resources.Resources.THE_LOG_DATABASE_CAN31596, "ConfigController.reindex", Resources.Resources.THE_LOG_DATABASE_CAN31596);

                if (string.IsNullOrEmpty(model.ResultMsg))
                {
                    //Configure main database
                    sysConfiguration.SaveDatabaseConfig(model.DbUser, model.DbPsw, model.Server, model.ServerType.ToString(), model.Schema, 
                    model.Port, model.ConnEncrypt, model.ConnWithDomainUser, year);

                    // Configure log database
                    if(hasLogDB) {
                        sysConfiguration.SaveLogDatabaseConfig(model.Log_DbUser, model.Log_DbPsw, model.Log_Server, model.ServerType.ToString(), 
                            model.Log_Schema, model.Log_Port, model.ConnEncrypt, model.ConnWithDomainUser, year);                    
                    }
                    model.ResultMsg = Resources.Resources.FICHEIRO_DE_CONFIGUR18806;
                }
            }
            catch (Exception e)
            {
                return Index(Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper()), appId);
            }

			return Index(model.ResultMsg, appId);
        }


        [HttpPost]
        public IActionResult SaveIdentityProvider([FromBody]Models.IdentityProviderCfg model)
        {
            var appId = FromQuery("appId");
            var conf = ConfigurationXML.readXML(pathConfig);
            SecurityCfgEl security = conf.GetSecurity(appId);
            if (model.FormMode == "delete")
            {
                security.IdentityProviders.RemoveAt(model.Rownum);
            }
            if (model.FormMode == "edit")
            {
                security.IdentityProviders[model.Rownum] = model.obj;
            }
            if (model.FormMode == "new")
            {
                security.IdentityProviders.Add(model.obj);
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            security = conf.GetSecurity(appId);
            var rownum = security.IdentityProviders.FindIndex(u => u.Name == model.Name);
            Models.IdentityProviderCfg identityProvider = model.FormMode != "delete" ? new Models.IdentityProviderCfg(security.IdentityProviders[rownum]) { Rownum = rownum } : null;

            return Json(new { success = true, identityProvider });
        }

        [HttpPost]
        public IActionResult SaveRoleProvider([FromBody]Models.RoleProviderCfg model)
        {
            var appId = FromQuery("appId");
            var conf = ConfigurationXML.readXML(pathConfig);
            SecurityCfgEl security = conf.GetSecurity(appId);
            if (model.FormMode == "delete")
            {
                security.RoleProviders.RemoveAt(model.Rownum);
            }
            if (model.FormMode == "edit")
            {
                security.RoleProviders[model.Rownum] = model.obj;
            }
            if (model.FormMode == "new")
            {
                security.RoleProviders.Add(model.obj);
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            security = conf.GetSecurity(appId);
            var rownum = security.RoleProviders.FindIndex(rp => rp.Name == model.Name);
            Models.RoleProviderCfg roleProvider = model.FormMode != "delete" ? new Models.RoleProviderCfg(security.RoleProviders[rownum]) { Rownum = rownum } : null;

            return Json(new { success = true, roleProvider });
        }

        [HttpPost]
        public IActionResult SaveUserCfg([FromBody]Models.UserCfg model)
        {
            var appId = FromQuery("appId");
            var conf = ConfigurationXML.readXML(pathConfig);
            SecurityCfgEl security = conf.GetSecurity(appId);
            var index = security.Users.FindIndex(u => u.Name == model.Name);
            if (model.FormMode == "delete")
            {
                security.Users.RemoveAt(index);
            }
            if (model.FormMode == "edit")
            {
                security.Users[index] = model.obj;
            }
            if (model.FormMode == "new")
            {
                security.Users.Add(model.obj);
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);
            security = conf.GetSecurity(appId);
            // var rownum = security.Users.FindIndex(u => u.Name == model.Name);
            // Models.UserCfg user = model.FormMode != "delete" ? new Models.UserCfg(security.Users[rownum]) { Rownum = rownum } : null;

            if (security.Users == null) security.Users = new List<UserCfgEl>();
            var users = security.Users.Select(u => new Models.UserCfg(u));

            return Json(new { success = true, users });
        }

        [HttpPost]
        public IActionResult SaveQueue([FromBody] Models.QueueCfg model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            if (conf.MessageQueueing == null)
            {
                conf.MessageQueueing = new messagequeueing();
            }

            if (model.FormMode == "delete")
            {
                conf.MessageQueueing.Queues.RemoveAt(model.Rownum);
            }
            if (model.FormMode == "edit")
            {
                conf.MessageQueueing.Queues[model.Rownum] = model.obj;
            }
            if (model.FormMode == "new")
            {
                conf.MessageQueueing.Queues.Add(model.obj);
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            return Json(new { Success = true });
        }

        [HttpPost]
        public IActionResult SaveQueueACK([FromBody] Models.QueueACK model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            if (conf.MessageQueueing == null)
            {
                conf.MessageQueueing = new messagequeueing();
            }

            if (model.FormMode == "delete")
            {
                conf.MessageQueueing.ACKS.RemoveAt(model.Rownum);
            }
            if (model.FormMode == "edit")
            {
                conf.MessageQueueing.ACKS[model.Rownum] = model.obj;
            }
            if (model.FormMode == "new")
            {
                conf.MessageQueueing.ACKS.Add(model.obj);
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult ReloadMQueues()
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            //----------------
            // Queues list
            //----------------
            var MQueues = new Models.MessageQueue();
            MQueues.Queues = new List<Models.QueueCfg>();

            int rownum = 0;
            if (conf.MessageQueueing != null)
            {
                conf.MessageQueueing.Journaltimeout = GlobalFunctions.atoi(MQueues.Journaltimeout);
                conf.MessageQueueing.Maxsendnumber = GlobalFunctions.atoi(MQueues.Maxsendnumber);

                foreach (var q in conf.MessageQueueing.Queues)
                {
                    MQueues.Queues.Add(new Models.QueueCfg(q) { Rownum = rownum++ });
                }
            }
            else
            {
                conf.MessageQueueing = new messagequeueing();
            }

            //----------------
            // ACK list
            //----------------
            MQueues.Acks = new List<Models.QueueACK>();

            rownum = 0;
            if (conf.MessageQueueing != null)
            {
                foreach (var q in conf.MessageQueueing.ACKS)
                {
                    MQueues.Acks.Add(new Models.QueueACK(q) { Rownum = rownum++ });
                }
            }
            return Json(new { Success = true, MQueues });
        }

        [HttpPost]
        public IActionResult SaveCoreCfg([FromBody]Models.CoreCfg model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            if (conf.Elasticsearch == null)
            {
                conf.Elasticsearch = new ElasticsearchXml
                {
                    Colours = new List<CoreXml>()
                };
            }

            if (model.FormMode == "delete")
            {
                conf.Elasticsearch.Colours.RemoveAt(model.Rownum);
            }
            if (model.FormMode == "edit" || model.FormMode == "new")
            {
                if (!string.IsNullOrEmpty(model.Obj.Password))
                {
                    byte[] pass_bytes = System.Text.Encoding.UTF8.GetBytes(model.Obj.Password ?? "");
                    model.Obj.Password = Convert.ToBase64String(pass_bytes, Base64FormattingOptions.None);
                }
                if (model.FormMode == "edit")
                {
                    conf.Elasticsearch.Colours[model.Rownum] = model.Obj;
                }
                if (model.FormMode == "new")
                {
                    conf.Elasticsearch.Colours.Add(model.Obj);
                }
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            return Json(new { Success = true });
        }

		[HttpGet]
        public IActionResult GetNewMorePropertyCfg()
        {
            return Json(new Models.MorePropertyCfg() { Rownum = -1 });
        }

        #region Empty objects
        [HttpGet]
        public IActionResult GetNewUserCfg()
        {
            return Json(new Models.UserCfg() { Rownum = -1 });
        }

        [HttpGet]
        public IActionResult GetNewIdentityProviderCfg()
        {
            return Json(new Models.IdentityProviderCfg() { Rownum = -1 });
        }

        [HttpGet]
        public IActionResult GetNewRoleProviderCfg()
        {
            return Json(new Models.RoleProviderCfg() { Rownum = -1 });
        }

        [HttpGet]
        public IActionResult GetNewCoreCfg()
        {
            return Json(new Models.CoreCfg() { Rownum = -1 });
        }

        [HttpGet]
        public IActionResult GetNewQueue()
        {
            return Json(new Models.QueueCfg() { Rownum = -1 });
        }

        [HttpGet]
        public IActionResult GetNewAck()
        {
            return Json(new Models.QueueACK() { Rownum = -1 });
        }
        #endregion

        [HttpPost]
        public IActionResult SaveConfigSecurity([FromBody]Models.SecurityCfg model)
        {
            var appId = FromQuery("appId");
            var conf = ConfigurationXML.readXML(pathConfig);

            foreach (var security in ClientApplication.Applications.Select(x=> conf.GetSecurity(x.Id)))
            {
				try
				{
                    if (appId == security.Application)
                    {
                        security.AllowAuthenticationRecovery = model.AllowAuthenticationRecovery;
                        security.AllowMultiSessionPerUser = model.AllowMultiSessionPerUser;
                        security.AuthenticationMode = model.AuthenticationMode;
                        security.Activate2FA = model.Activate2FA ? GenioServer.security.Auth2FAModes.TOTP : GenioServer.security.Auth2FAModes.None;
                        security.Mandatory2FA = model.Activate2FA && model.Mandatory2FA;
                        security.SessionTimeOut = model.SessionTimeOut;
                    }
                    //this variables will be the same for all modules
					security.ExpirationDateBool = model.ExpirationDateBool;
					security.ExpirationDate = model.ExpirationDate;
					security.MinCharacters = model.MinCharacters.ToString();
					security.PasswordStrength = model.PasswordStrength;
					security.PasswordAlgorithms = model.PasswordAlgorithms;
					security.MaxAttempts = model.MaxAttempts;

					conf.writeXML(pathConfig);
				}
				catch (Exception e)
				{
					var resultMsg = Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper());
					return Json(new { Success = false, Message = resultMsg });
				}
			}

            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            return Json(new { Success = true });
        }

        [HttpPost]
        public IActionResult SaveConfigMessageQueue([FromBody] Models.ConfigModel model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            try
            {
                if ((!string.IsNullOrEmpty(model.MQueues.Journaltimeout) && string.IsNullOrEmpty(model.MQueues.Maxsendnumber)) || (string.IsNullOrEmpty(model.MQueues.Journaltimeout) && !string.IsNullOrEmpty(model.MQueues.Maxsendnumber)))
                    throw new BusinessException(Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860, "ConfigController.Queue", Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860);

				if (conf.MessageQueueing == null)
                    conf.MessageQueueing = new messagequeueing();

				model.MQueues.Journaltimeout = conf.MessageQueueing.Journaltimeout.ToString();
				model.MQueues.Maxsendnumber = conf.MessageQueueing.Maxsendnumber.ToString();

                conf.writeXML(pathConfig);
                model.ResultMsg = Resources.Resources.FICHEIRO_DE_CONFIGUR18806;

				// Reload Configuration static instance in server with the new Configuracoes.xml data
                CSGenio.framework.Configuration.ReadConfiguration(conf);
            }
            catch (Exception e)
            {
                var resultMsg = Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper());
                return Json(new { Status = "ERROR", Message = resultMsg });
            }

            return Json(new { Status = "OK", Message = model.ResultMsg });
        }

        [HttpPost]
        public IActionResult SaveConfigAudit([FromBody]Models.ConfigModel model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            conf.Audit = new AuditCfgEl();
            try
            {
                conf.Audit.RegistActions = model.RegistActions;
                conf.Audit.RegistLoginOut = model.RegistLoginOut;
				conf.Audit.AuditInterface = model.AuditInterface;

                // Event tracing feature
                conf.EventTracking = model.EventTracking;

                conf.writeXML(pathConfig);

				// Reload Configuration static instance in server with the new Configuracoes.xml data
                CSGenio.framework.Configuration.ReadConfiguration(conf);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper()) });
            }

            return Json(new { Success = true });
        }

        [HttpPost]
        public IActionResult SaveConfigOthers([FromBody]Models.ConfigModel model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            conf.DateFormat = new DateFormatXml();
            conf.NumberFormat = new NumberFormatXml();
            conf.ChatBotConfig = new ChatBotCfg();
            try
            {
                conf.pathReports = model.pathReports;
                conf.ssrsServer.url = model.ssrsServer;
                conf.ssrsServer.path = model.ssrsServerPath;
                conf.ssrsServer.isLocalReports = model.isLocalReports;
                conf.ssrsServer.Domain = model.ssrsServerDomain;
                conf.ssrsServer.Username = Convert.ToBase64String(Encoding.Unicode.GetBytes(model.ssrsServerUsername));
                conf.ssrsServer.Password = Convert.ToBase64String(Encoding.Unicode.GetBytes(model.ssrsServerPassword));

                conf.DateFormat.Date = model.DateFormat.date;
                conf.DateFormat.DateTime = model.DateFormat.dateTime;
                conf.DateFormat.DateTimeSeconds = model.DateFormat.dateTimeSeconds;
                conf.DateFormat.Time = model.DateFormat.time;

                conf.ChatBotConfig.apiURL = model.UrlAPIBackend;
                conf.ChatBotConfig.websocketURL = model.UrlSocketBackend;

                conf.QAEnvironment = Convert.ToInt32(model.QAEnvironment);

                switch (model.DecimalSeparator.ToString())
                {
                    case "Dot":
                        conf.NumberFormat.DecimalSeparator = ".";
                        break;
                    case "Comma":
                        conf.NumberFormat.DecimalSeparator = ",";
                        break;
                    default:
                        conf.NumberFormat.DecimalSeparator = ".";
                        break;
                }
                switch (model.GroupSeparator.ToString())
                {
                    case "": // none
                        conf.NumberFormat.GroupSeparator = "";
                        break;
                    case "Comma":
                        conf.NumberFormat.GroupSeparator = ",";
                        break;
                    case "Dot":
                        conf.NumberFormat.GroupSeparator = ".";
                        break;
                    case "Blank":
                        conf.NumberFormat.GroupSeparator = " ";
                        break;
                    default: // none
                        conf.NumberFormat.GroupSeparator = "";
                        break;
                }
                // check if they have the same value
                if (model.DecimalSeparator.ToString() == model.GroupSeparator.ToString())
                    throw new BusinessException(Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860, "ConfigController.reindex", Resources.Resources.ALGUNS_CAMPOS_ESTAO_27860);

                conf.writeXML(pathConfig);

				// Reload Configuration static instance in server with the new Configuracoes.xml data
                CSGenio.framework.Configuration.ReadConfiguration(conf);
            }
            catch (Exception e)
            {
                var resultMsg = Translations.Get(e.Message, CultureInfo.CurrentCulture.Name.Replace("-", "").ToUpper());
                return Json(new { Success = false, Message = resultMsg });
            }

            return Json(new { Success = true });
        }

        [HttpPost]
        public IActionResult SavePathCfg([FromBody] Models.PathCfg model)
        {
            var appId = FromQuery("appId");
            ConfigurationXML conf = ConfigurationXML.readXML(pathConfig);
            PathCfgEl path = conf.GetPath(appId);
            path.pathApp = model.pathApp;
            path.pathDocuments = model.pathDocuments;
            conf.writeXML(pathConfig);

            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);
            return Json(new { Success = true });
        }

		[HttpPost]
        public IActionResult SaveMoreProperty([FromBody]Models.MorePropertyCfg model)
        {
            var conf = ConfigurationXML.readXML(pathConfig);
            var initProp = false;

			if (String.IsNullOrEmpty(model.Key)) { return Json(new { emptyKey = true }); }

            if (String.IsNullOrEmpty(model.Val)) { return Json(new { emptyVal = true }); }

            if (model.FormMode == "delete")
            {
                initProp = CSGenio.framework.Configuration.isInitPropInitialized(model.Key);
                
                conf.maisPropriedades.Remove(model.Key);
            }
            if (model.FormMode == "edit")
            {
                conf.maisPropriedades[model.Key] = model.Val;
            }
            if (model.FormMode == "new")
            {
                if (conf.maisPropriedades.ContainsKey(model.Key)) { return Json(new { success = false }); }
                conf.maisPropriedades.Add(model.Key, model.Val);
            }

            conf.writeXML(pathConfig);
            // Reload Configuration static instance in server with the new Configuracoes.xml data
            CSGenio.framework.Configuration.ReadConfiguration(conf);

            List<MorePropertyCfgEl> morePropertyList = new List<MorePropertyCfgEl>();
            foreach (var mp in conf.maisPropriedades)
            {
                MorePropertyCfgEl mpe = new MorePropertyCfgEl();
                mpe.Key = mp.Key;
                mpe.Val = mp.Value;
                morePropertyList.Add(mpe);
            }

            var rownum = morePropertyList.FindIndex(u => u.Key == model.Key);
            Models.MorePropertyCfg moreProperty = model.FormMode != "delete" ? new Models.MorePropertyCfg(morePropertyList[rownum]) { Rownum = rownum } : null;

            return Json(new { success = true, moreProperty, initProp = initProp });
        }

        [HttpGet]
        public FileResult DownloadRedirect()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            RedirectXML redirect = new RedirectXML();
            redirect.files = new FileRedirect[1];
            var fileRedirect = new FileRedirect();
            fileRedirect.file = "Configuracoes.xml";
            fileRedirect.relative = false;
            fileRedirect.path = path;
            redirect.files[0] = fileRedirect;

            var dataStream = new MemoryStream();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(RedirectXML));
            serializer.Serialize(dataStream, redirect);
            dataStream.Position = 0;

            return File(dataStream, "application/octet-stream", "Configuracoes.redirect.xml");
        }

        [HttpPost]
        public IActionResult VerifyDocPathConfig([FromBody] Models.PathCfg model)
        {
            ConfigurationXML conf = ConfigurationXML.readXML(pathConfig);

            for(int i = 0; i < conf.Paths.Count; i++){
                if(conf.Paths[i].pathDocuments != model.pathDocuments){
                    return Json(new { Success = false });
                }
            }

            return Json(new { Success = true });            
        }
    }
}