using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.UserAdmin;
using CSGenio.framework;
using GenioServer.security;
using CSGenio.business;
using CSGenio.persistence;
using CaptchaMvc.HtmlHelpers;
using System.Linq;
using System.Text;
using GenioMVC.Models.Exception;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using GenioMVC.Helpers.Menus;
using System.Collections.Generic;



namespace GenioMVC.Controllers
{
	public class AccountController : ControllerBase
	{
		//
		// GET: /Account/LogOn
// USE /[MANUAL GQT CUSTOM_LOGON_GET]/
        // GET: /Account/LogOnPartial
		public ActionResult LogOnPartial(string view)
		{
			LogOnModel model = new LogOnModel();
			model.Load();

			//check if configuracoes.xml have OpenID Connect configured
            OpenIdConnectIdentityProvider oIdIP = new OpenIdConnectIdentityProvider();
            if (oIdIP.Options != null)
                model.OpenIdConnAuthMethods.Add(oIdIP.Options.Description);
			//check if configuracoes.xml have CAS configured
            CASIdentityProvider casIP = new CASIdentityProvider();
            if (casIP.Options != null)
                model.CASAuthMethods.Add(casIP.Options.Description);

			//check if configuracoes.xml have CMD configured
            CMDIdentityProvider cmdIP = new CMDIdentityProvider();
            if (cmdIP.Options != null)
                model.CMDAuthMethods.Add(cmdIP.Options.Description);

            if (string.IsNullOrEmpty(view))
			    return PartialView("LogOn", model);
            else
                return PartialView(view, model);
        }

        //
        // GET: /Account/LogOn
        public ActionResult LogOn()
        {
            LogOnModel model = new LogOnModel();
            model.Load();

			//TSX (2020.06.01) - If authentication cookie timeout and the user are on one form the breadcrumbs aren't remove because level are > 0
            Navigation.ClearHistoryLevels();

			//check if configuracoes.xml have OpenID Connect configured
            OpenIdConnectIdentityProvider oIdIP = new OpenIdConnectIdentityProvider();
            if (oIdIP.Options != null)
                model.OpenIdConnAuthMethods.Add(oIdIP.Options.Description);
			//check if configuracoes.xml have CAS configured
            CASIdentityProvider casIP = new CASIdentityProvider();
            if (casIP.Options != null)
                model.CASAuthMethods.Add(casIP.Options.Description);

			//check if configuracoes.xml have CMD configured
            CMDIdentityProvider cmdIP = new CMDIdentityProvider();
            if (cmdIP.Options != null)
                model.CMDAuthMethods.Add(cmdIP.Options.Description);

			//if only have one identity provider redirect directly to the webpage for login
            if (Configuration.Security.IdentityProviders.Count == 1)
            {
                if (model.OpenIdConnAuthMethods.Any())
                    return RedirectToAction("OpenIdLoginRedirect", new { id = model.OpenIdConnAuthMethods.First() });
                else if (model.CASAuthMethods.Any())
                    return RedirectToAction("CASLoginRedirect", new { id = model.CASAuthMethods.First() });
				else if (model.CMDAuthMethods.Any())
                    return RedirectToAction("CMDLoginRedirect", new { id = model.CMDAuthMethods.First() });
            }

            return View(model);
        }

		//
		// POST: /Account/LogOn
		[HttpPost]
// USE /[MANUAL GQT CUSTOM_LOGON_POST]/
		public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
                User user = AuthenticateUser(model, Configuration.DefaultYear);

                //if (Membership.ValidateUser(model.UserName, model.Password))
                if (user != null)
                {
                    PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year);
                    //Check for DB Version
                    if (Configuration.GetDbVersion(user.Year) != Configuration.VersionDbGen ||
                        Configuration.GetDbUpgrIndx(user.Year) < Configuration.VersionUpgrIndxGen)
                    {
                        UserContext.Destroy();
                        return Json(new { Success = false, Message = Resources.Resources.E_NECESSARIO_ATUALIZ49371 });
                    }

					//Check for Configuration Version
                    if (Configuration.ConfigVersion != GenioServer.framework.ConfigXMLMigration.CurConfigurationVerion.ToString())
                    {
                        UserContext.Destroy();
                        return Json(new { Success = false, Message = Resources.Resources.E_NECESSARIO_PROCEDE36325 });
                    }

					try
                    {
                        GlobalAppSessions.Instance.AddOrUpdate(this.Session.SessionID, user.Name, Request.UserHostAddress);
                    }
                    catch (FrameworkException e)
                    {
                        var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
                        if (e is GenioException && (e as GenioException).UserMessage != null)
                            exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

                        UserContext.Destroy();
                        return Json(new { Success = false, Message = exceptionUserMessage });
                    }

					//TSX (12/04/2019) - All unsuccess have to stay here before create cookie with user because if user refresh the page the application think it is authenticated
					if (user.Status == 2)
                    {
                        UserContext.Destroy();
                        return Json(new { Success = false, Message = Resources.Resources.ESTE_UTILIZADOR_ENCO01685 });
                    }

					if (!user.Auth2FA)
                        return finalizeAuthentication(user, returnUrl, false);
                    else
                        return Json(new { Success = true, Auth2FA = true, User = user, Redirect = returnUrl });
				}
				else if (!String.IsNullOrEmpty(model.UserName))
                    CSGenio.framework.Audit.registLoginOut(UserContext.Current.User, model.UserName, Resources.Resources.TENTATIVA38682, Resources.Resources.LOGIN_OU_PASSWORD_IN32183, Request.UserHostName, Request.GetClientIpAddress());
			}

			string error = "";
            foreach (ModelState m in  ModelState.Values)
            {
                var errIt = m.Errors.GetEnumerator();
                errIt.MoveNext();
                while (errIt.Current != null)
                {
                   error = errIt.Current.ErrorMessage;
                   errIt.MoveNext();
                }
            }

			// If we got this far, something failed, redisplay form
            model.Load();
            return Json(new { Success = false, Message = Translations.Get(error, System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString().Replace("-", "").ToUpper()) });
		}

		[HttpPost]
        public ActionResult Authentication2FA(string returnUrl, string code)
        {
            User user = UserContext.Current.User;

            //Check if user is locked
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            var userPsw = CSGenioApsw.search(sp, user.Codpsw, user);
            if (userPsw.ValStatus == 2)
                return Json(new { Success = false, Message = Resources.Resources.ESTE_UTILIZADOR_ENCO01685 });

            IIdentity ident = null;
            if (userPsw.ValPsw2fatp == Auth2FAModes.TOTP.ToString())
            {
                UserPassCredential cred = new UserPassCredential();
                cred.Username = user.Name;
                cred.Password = code;
                cred.Year = user.Year;

                TOTPIdentityProvider totp = new TOTPIdentityProvider();
                ident = totp.Authenticate(cred);
            }

            if (ident != null)
                return finalizeAuthentication(user, returnUrl, true);
            else
            {
                return Json(new { Success = false, Message = Resources.Resources.DADOS_DE_LOGIN_INCOR44791 });
            }
        }

        /// <summary>
        /// Sends the email for password recovery
        /// </summary>
        [HttpPost, CaptchaMvc.Attributes.CaptchaVerify("Invalid captcha")]
        public ActionResult RecoverPassword(PasswordRecoverViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    User u = UserContext.Current.User;
                    PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
                    UserFactory userFactory = new UserFactory(sp, u);
                    IPrincipal principal = HttpContext.User;
                    //Check if the user with this email exists
                    //var user = userFactory.GetUserFromEmail(model.Email);
                    var user = SecurityFactory.GetUserFromEmail(principal.Identity, model.Email, u, sp);

                    string emailBody = "";
                    string appName = Configuration.Application.Name;
                    string lang = RouteData.GetRequiredString("culture");
                    if (user != null)
                    {
                        ResourceUser rec = new ResourceUser(user.ValNome, user.ValCodpsw);
                        var ticket = QResources.CreateTicketEncryptedBase64(u.Name, u.Location, rec);

                        string userName = user.ValNome;
                        string urlToken= Url.Action("RecoverPasswordChange", "Account", new { ticket }, Request.Url.Scheme);

                        emailBody = UserRegistration.GetEmailForLanguage("PasswordChangeEmail", lang);
                        emailBody = String.Format(emailBody, appName, userName, urlToken);
                    }
                    else
                    {
                        emailBody = UserRegistration.GetEmailForLanguage("InvalidEmailTemplate", lang);
                        string baseUrl = Url.Action("LogOn", "Account", null, Request.Url.Scheme);
                        emailBody = String.Format(emailBody, appName, baseUrl);
                    }

                    userFactory.SendPasswordRecoveryMail(model.Email, emailBody);
                    model.IsEmailSent = true;

                }
            }
            catch (Exception exc)
            {
                    Log.Error(exc.Message);
                    ModelState.AddModelError("error", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
            }
            return View(model);
        }

        /// <summary>
        /// Receives a ticket, validates it and shows the view to change password
        /// </summary>
        public ActionResult RecoverPasswordChange(string ticket)
        {
            try
            {
                var ticketContent = QResources.DecryptTicketBase64(ticket);
                ResourceUser resource = ticketContent[2] as ResourceUser;
                //Check if ticket expired
                if (GlobalFunctions.Diferenca_entre_Datas(resource.CreationDate, DateTime.UtcNow, "M") < 60)
                {
                    var model = new PasswordRecoverChangeModel();
                    model.UserId = resource.Name;
                    //Store the id in session for later use
                    Session["userId"] = resource.Name;
                    return View(model);
                }
                else
                {
                    return View("ErrorTicketConfirm");
                }
            }
            catch
            {
                return View("ErrorTicketConfirm");
            }
        }

        /// <summary>
        /// Persist the password change
        /// </summary>
        [HttpPost]
        public ActionResult RecoverPasswordChange(PasswordRecoverChangeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User u = UserContext.Current.User;
                    PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
                    var userFactory = new UserFactory(sp, u);
                    //Get the user id from the session
                    string userId = (string)Session["userId"];
                    model.UserId = userId;
                    //Find the user with this id
                    //IPrincipal principal = HttpContext.User;
                    //var user = SecurityFactory.GetUser(principal.Identity,u,sp);
                    var user = userFactory.GetUser(userId);
                    //Change password
                    userFactory.ChangePassword(user, model.NewPassword, model.ConfirmPassword);
					try
                    {
                        sp.openTransaction();
                        user.update(sp);
                        sp.closeTransaction();
                    }
                    catch
                    {
                        sp.rollbackTransaction();
                        throw;
                    }
                    //Cleanup
                    Session["userId"] = null;
                    return View("RecoverPasswordChangeSuccess");
                }
                catch (InvalidPasswordException exc)
                {
                    Log.Error(exc.Message);
                    ModelState.AddModelError("error", exc.UserMessage);
                }
                catch (Exception exc)
                {
                    Log.Error(exc.Message);
                    ModelState.AddModelError("error", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
                }
            }
            return View(model);
        }

        public ActionResult WebAuthn2FAAssertionOptions()
        {
            WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
            {
                MDSAccessKey = ValueProvider.GetValue("fido2:MDSAccessKey")?.AttemptedValue,
                MDSCacheDirPath = ValueProvider.GetValue("fido2:MDSCacheDirPath")?.AttemptedValue,
                TimestampDriftTolerance = ValueProvider.GetValue("fido2:TimestampDriftTolerance")?.AttemptedValue,
                Fido2Options = new WebAuthFido2Options() { Origin = Request.Url.GetLeftPart(UriPartial.Authority) }
            });

            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            var returnWebAuth = credWebAuth.AssertionOptionsPost(user.Codpsw, sp);

            if (returnWebAuth.Success)
            {
                //Temporarily store options, session/in-memory cache/redis/db
                HttpContext.Session["fido2.assertionOptions"] = returnWebAuth.Options;
                return Json(new { Success = true, options = returnWebAuth.Options });
            }
            else
            {
                return Json(new { Success = false, ErrorMessage = returnWebAuth.ErrorMessage });
            }
        }

        public async Task<ActionResult> WebAuthn2FAMakeAssertion(string data, string returnUrl)
        {
            WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
            {
                MDSAccessKey = ValueProvider.GetValue("fido2:MDSAccessKey")?.AttemptedValue,
                MDSCacheDirPath = ValueProvider.GetValue("fido2:MDSCacheDirPath")?.AttemptedValue,
                TimestampDriftTolerance = ValueProvider.GetValue("fido2:TimestampDriftTolerance")?.AttemptedValue,
                Fido2Options = new WebAuthFido2Options() { Origin = Request.Url.GetLeftPart(UriPartial.Authority) }
            });

            User user = UserContext.Current.User;

            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            var returnWebAuth = await credWebAuth.MakeAssertion(data, (string)HttpContext.Session["fido2.assertionOptions"], user.Codpsw, sp);

            if (returnWebAuth.Success)
            {
                return finalizeAuthentication(user, returnUrl, true);
            }
            else
            {
                return Json(new { Success = returnWebAuth.Success, ErrorMessage = returnWebAuth.ErrorMessage });
            }
        }

		/// <summary>
        /// After user request to authenticate with OpenId Connect we will redirect user to the authentication page from the provider
        /// </summary>
        /// <param name="id">the "id" argument isn't used at the moment but when have multiple identity providers configured that will be used</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OpenIdLoginRedirect(string id)
        {
            string urlRedirectAuth = (new OpenIdConnectIdentityProvider()).GetUrlToAuthenticate(
                Url.RouteUrl("OIdAuth", null, Request.Url.Scheme) //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
                );

            return Redirect(urlRedirectAuth);
        }

		/// <summary>
        /// After user request to authenticate with CMD provider we will redirect user to the authentication page from the provider
        /// </summary>
        /// <param name="id">the "id" argument isn't used at the moment but when have multiple identity providers configured that will be used</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CMDLoginRedirect(string id)
        {
            string urlRedirectAuth = (new CMDIdentityProvider()).GetUrlToAuthenticate(
                Url.RouteUrl("OIdAuth", null, Request.Url.Scheme) //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
                );

            return Redirect(urlRedirectAuth);
        }

        /// <summary>
        /// After user have authenticated on external identity provider will callback to our application to that funcion.
        /// </summary>
        /// <param name="id_token">Returned token by the external identity provider. The primary extension that OpenID Connect makes to OAuth 2.0 to enable End-Users to be Authenticated is the ID Token data structure. The ID Token is a security token that contains Claims about the Authentication of an End-User by an Authorization Server when using a Client, and potentially other requested Claims. The ID Token is represented as a JSON Web Token (JWT)</param>
        /// <param name="code">The Authorization Code Flow returns an Authorization Code to the Client. This provides the benefit of not exposing any tokens to the User Agent and possibly other malicious applications with access to the User Agent. The Authorization Server can also authenticate the Client before exchanging the Authorization Code for an Access Token. The Authorization Code flow is suitable for Clients that can securely maintain a Client Secret between themselves and the Authorization Server. More information at https://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OpenIdLogin (string id_token, string code)
        {
            try {
                //decode JWT received, more information at https://openid.net/specs/openid-connect-core-1_0.html#IDToken
                var token = new JwtSecurityToken(id_token);

                OpenIdConnectIdentityProvider ip = new OpenIdConnectIdentityProvider();
                ip.Options.CallbackPath = Url.RouteUrl("OIdAuth", null, Request.Url.Scheme); //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
                TokenCredential qToken = new TokenCredential();
                qToken.Token = token.ToString();

                var id = ip.Authenticate(qToken, code);

                if (id != null) //When user authenticated successfull return to Home page
                {
                    User user = new User(id.Name, "id", Configuration.DefaultYear, Request.UserHostName);
                    user.Auth2FA = false; //This authentication method doesn't allow 2FA because the provider have this responsibility
                    user.Status = 0; //At this moment if "id" isn't null than this user have status = 0

                    finalizeAuthentication(user, "", false);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch { }
			ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
            return RedirectToAction("LogOn", new { nav = Navigation.NavigationId }); //When user authentication error then return again to Logon page
        }

		/// <summary>
        /// After user have authenticated on Governement CMD identity provider will callback to our application to that funcion.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OpenIdLogin()
        {
            //just redirect to CMDLogin
            return View("CMDRedirect");
        }

		/// <summary>
        /// /// After user have authenticated on Governement CMD identity provider, it is invoked an API to get data associated with token, and the laocal login process is satarted
        /// </summary>
        /// <param name="access_token">authentication token</param>
        /// <param name="token_type"></param>
        /// <param name="expires_in"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CMDLogin(string access_token, string token_type, string expires_in)
        {
            try
            {
                CMDIdentityProvider ip = new CMDIdentityProvider();
                var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(ip.Options.DataAPI+"?token=" + access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    string jsonResult = streamReader.ReadToEnd();
                    DomainCredential credencial = ip.ValidateCredencial(jsonResult);

                    if(credencial != null)
                    {
                        var id = ip.Authenticate(credencial);

                        if (id != null) //When user authenticated successfull return to Home page
                        {
                            User user = new User(id.Name, "id", Configuration.DefaultYear, Request.UserHostName);
                            user.Auth2FA = false; //This authentication method doesn't allow 2FA because the provider have this responsibility
                            user.Status = 0; //At this moment if "id" isn't null than this user have status = 0

                            finalizeAuthentication(user, "", false);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error("GetData error:"+ ex.Message);
            }

            ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
            return RedirectToAction("LogOn", new { nav = Navigation.NavigationId }); //When user authentication error then return again to Logon page
        }

		[HttpGet]
        public ActionResult CASLoginRedirect(string id)
        {
            string ticket = "";

            string urlRedirectAuth = (new CASIdentityProvider()).GetUrlToAuthenticate(
                Url.RouteUrl("CASAuth", null, Request.Url.Scheme), //Get absolute path with scheme + domain + "/CASLogin" to provider known were to send the callback
                "login" //path to contact
                );

            if (Request.QueryString["SAMLArt"] != null)
                ticket = Request.QueryString["SAMLArt"].ToString();
            else
                return Redirect(urlRedirectAuth);

            return CASLogin(ticket);
        }

        public ActionResult CASLogin(string SAMLart)
        {
            if (!String.IsNullOrEmpty(SAMLart))
            {
                try
                {
                    CASIdentityProvider ip = new CASIdentityProvider();
                    ip.Options.CallbackPath = Url.RouteUrl("CASAuth", null, Request.Url.Scheme); //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
                    TokenCASCredential qToken = new TokenCASCredential();
                    qToken.Token = SAMLart;
					qToken.OriginUrl = Request.Url.AbsoluteUri;

                    var id = ip.Authenticate(qToken);

                    if (id != null) //When user authenticated successfull return to Home page
                    {
                        User user = new User(id.Name, "id", Configuration.DefaultYear, Request.UserHostName);
                        user.Auth2FA = false; //This authentication method doesn't allow 2FA because the provider have this responsibility
                        user.Status = 0; //At this moment if "id" isn't null than this user have status = 0

                        finalizeAuthentication(user, "", false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                }
            }
            ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
            return RedirectToAction("LogOn", new { nav = Navigation.NavigationId }); //When user authentication error then return again to Logon page
        }

        [HttpPost]
        private ActionResult finalizeAuthentication (User user, string returnUrl, bool Val2FA)
        {
			if (user != null)
            {
				SetCookie(user.Name, user.Year);

				// log login (audit)
                CSGenio.framework.Audit.registLoginOut(user, Resources.Resources.ENTRADA31905, Resources.Resources.ENTRADA_ATRAVES_DA_P48446, Request.UserHostName, Request.GetClientIpAddress());

				if (GlobalFunctions.emptyN(user.Status) == 0 && user.Status == 1 || (Configuration.Security.Mandatory2FA && !user.Auth2FA))
                {
                    if (Val2FA)
                        return Json(new { Success = true, Redirect = Url.Action("Profile", "Home"), Val2FA = true });
                    else
                        return Json(new { Success = true, Redirect = Url.Action("Profile", "Home") });
                }
                else if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    if (Val2FA)
                        return Json(new { Success = true, Redirect = returnUrl, Val2FA = true });
                    else
                        return Json(new { Success = true, Redirect = returnUrl });
                }
                else
                {
                    if (Val2FA)
                        return Json(new { Success = true, Redirect = Url.Action("Index", "Home"), Val2FA = true });
                    else
                        return Json(new { Success = true, Redirect = Url.Action("Index", "Home") });
                }
			}
			else
			{
				if (Val2FA)
					return Json(new { Success = false, Message = Resources.Resources.DADOS_DE_LOGIN_INCOR44791, Val2FA = false });
				else
					return Json(new { Success = false, Message = Resources.Resources.DADOS_DE_LOGIN_INCOR44791 });
			}
        }


		//
		// GET: /Account/LogOff
		[AuthorizeForUsers]
		public ActionResult LogOff()
		{
		    DestroySession();
			return RedirectToAction("HttpRedirectIndex", "Home", new { nav = Navigation.NavigationId });
		}

		//
		// GET: /Account/Register

		public ActionResult Register(string Form, string Pswform, string Id)
        {
            ViewModels.RegisterViewModel model = new ViewModels.RegisterViewModel();

            RegistrationConfig(model, Form, Id);
            RegistrationConfig(model, Pswform, Id);

            return View(model);
        }

		/// <summary>
		/// A dictionary with all user regitration defined (The form order ie defined by list object)
		/// </summary>
		private Dictionary<string, List<string>> registrationFormList = new Dictionary<string, List<string>>
		{
			{
				"b19bed66-a6e9-4494-92e5-78deac2ba837", new List<string> { "Defaultpsw", "Pess1" }
			},
        };

		/// <summary>
		/// Get the form order of each user registration
		/// </summary>
		/// <param name="form">form to get order</param>
		/// <param name="formRegistor">user registration ID</param>
		/// <returns>form order</returns>
		private int GetRegistrationFormOrder(string form,  string registrationID)
		{
			if (string.IsNullOrEmpty(registrationID) || string.IsNullOrEmpty(form))
				return -1;

			if (registrationFormList.ContainsKey(registrationID))
			{
				List<string> formlist = registrationFormList[registrationID];
				if (formlist.Count == 2) 
				{
					if (formlist[0].Equals(form))
						return 1;
					else
						return 2;
				}
			}

			return -1;
		}

        public void RegistrationConfig(ViewModels.RegisterViewModel model, string Form, string registrationID)
        {
            switch (Form)
            {
                case "Pess1"://Setup Form
                    {
                        if (!Navigation.CurrentLevel.CheckEntry("pess1") || model.FormData == null)
                            model.FormData = Pess1_New(true);

                        model.partialView = "Pess1_Support";
                        model.partialViewJS = "PESS1";
                        model.redirect = "Pess1_Register";
                        model.DivID = "Pess1_well";
						model.FormDataOrdem = GetRegistrationFormOrder(Form, registrationID);
                        break;
                    }
                case "Defaultpsw": //Psw form
                    {
                        if (model.FormPswData == null)
                            model.FormPswData =  new ViewModels.Psw.Defaultpsw_ViewModel(Navigation, true);

                        model.PswpartialView = "Defaultpsw_Support";
                        model.Pswredirect = "Defaultpsw_Register";
                        model.PswDivID = "Defaultpsw_well";
                        model.FormPswOrdem = GetRegistrationFormOrder(Form, registrationID);
                        break;
                    }
            }
		}

		public ActionResult CreationSuccess()
        {
            return View("CreationSuccess");
        }


		public ViewModels.Pess1.Pess1_ViewModel Pess1_New(bool isNewInitialization = false)
        {
            ViewModels.Pess1.Pess1_ViewModel model = new ViewModels.Pess1.Pess1_ViewModel(Navigation, true);
            var qs = Request.QueryString;


            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {

                if (isNewInitialization)
                {
                    CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

                    sp.openTransaction();

                    var Model = new Models.Pess1();
                    Model.klass.UserRecord = false;
                    Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
                    Model.New("Pess1");

					                    Navigation.SetValue("pess1", Model.ValCodpesso);
					Navigation.CurrentLevel.SetMode(FormMode.New);
                    model.MapFromModel(Model);
                    sp.closeTransaction();

                    sp.openConnection();

                    model.NewLoad();

                    sp.closeConnection();
                }
                else
                {
                    model.NestedForm = true;
                    model.Navigation = Navigation;
                    sp.openConnection();
                    model.Load(qs, true, Request.IsAjaxRequest());
                    sp.closeConnection();
                }

            }
            catch (ModelNotFoundException)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                return model;
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();

                var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

                ModelState.AddModelError("Erro", exceptionUserMessage);

                CSGenio.framework.Log.Error("Pess1_New - GET " + e.Message);

                ErrorMessage(exceptionUserMessage);
            }
            return model;
        }
 
        // POST: /Account/Register
        [HttpPost, CaptchaMvc.Attributes.CaptchaVerify("Invalid captcha")]
        public ActionResult Pess1_Register(
            [Bind(Prefix = "model2")] ViewModels.Pess1.Pess1_ViewModel FormData,
            [Bind(Prefix = "model1")] ViewModels.Psw.Defaultpsw_ViewModel FormPswData)
        {
            //TODO: If(!Config.RegisterUsers) return "ERROR UNAUTHORIZED";
            ViewModels.RegisterViewModel returnModel = new ViewModels.RegisterViewModel();
            const string registrationId = "b19bed66-a6e9-4494-92e5-78deac2ba837";

            if (!ModelState.IsValid)
            {

				returnModel.FormData = FormData;
				RegistrationConfig(returnModel,"Pess1", registrationId);
				(returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).Navigation = Navigation;
				(returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).LoadPartial(Request.QueryString);
				(returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).MapFromModel();

                returnModel.FormPswData = FormPswData;
                RegistrationConfig(returnModel,"Defaultpsw", registrationId);
                (returnModel.FormPswData as ViewModels.Psw.Defaultpsw_ViewModel).Navigation = Navigation;

                return Json(new { Success = false, Form = "Form_Pess1" ,Operation = "New", View = RenderPartialViewToString(this, "Register", returnModel), Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848});
            }

            string UserName = FormPswData.ValNome;
            string Email = FormPswData.ValEmail;
            string Password = FormPswData.ValPassword;
            string ConfirmPassword = FormPswData.ConfirmValPassword;

            CSGenioApsw user;

            PersistentSupport sp = UserContext.Current.PersistentSupport;

            try
            {
                Password password = new Password(Password,ConfirmPassword);
                UserFactory factory = new UserFactory(sp, UserContext.Current.User);
                sp.openTransaction();

                //Create new user psw record
                user = factory.CreateNewPsw(
                    userName : UserName, email: Email, phone: string.Empty,
                    status: 2, //Account starts disabled
                    password: password);
                user.User.Public = true;
 
// USE /[MANUAL GQT USER_CREATION_CONTROLLER]/

                //Insert new user data into database
				user.UserRecord = true; //Change by [TMV] (03-08-2022) -> Makes sense to be a user record, to stamp the audit fields. And the action is triggred by a user
                user.insert(sp);
                factory.CreateUser_PESS1(user);

				//Set foreign key to primary key of record in user table (USERLOGIN / PSW)
                //Change by [TMV] (16.03.2021) -> Returns the CSGenio to be able to create eph with formula fields
                CSGenioApess1 area = Pess1_New_Registration(FormData);

                if (area is null)
                {
                    sp.rollbackTransaction();
                    sp.closeConnection();

                    returnModel.FormData = FormData;
                    RegistrationConfig(returnModel,"Pess1", registrationId);
                    (returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).Navigation = Navigation;
                    (returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).LoadPartial(Request.QueryString);
                    (returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).MapFromModel();

                    returnModel.FormPswData = FormPswData;
                    RegistrationConfig(returnModel,"Defaultpsw", registrationId);
                    (returnModel.FormPswData as ViewModels.Psw.Defaultpsw_ViewModel).Navigation = Navigation;

                    return Json(new { Success = false, Form = "Form_Pess1", Operation = "New", View = RenderPartialViewToString(this, "Register", returnModel), Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
                }

                factory.CreateEph_COMODANTE(user, area.ValCodpesso);

                string lang = "";
                try
                {
                    lang = RouteData.GetRequiredString("culture");
                }
                catch (Exception) { }

                UserFactory.MailSender(user, Url.Action("ConfirmEmail", "Account", new { ticket = "fldTicket" }, Request.Url.Scheme), lang);

                sp.closeTransaction();

                return Json(new { Success = true, Operation = "New", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746, Url = Url.Action("CreationSuccess") });
            }
            catch (BusinessException e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                ModelState.AddModelError("Erro", e.UserMessage);
                Log.Error(e.Message);
            }
            catch (FrameworkException e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                ModelState.AddModelError("Erro", e.UserMessage);
                Log.Error(e.Message);
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
                Log.Error(e.Message);
            }

            returnModel.FormData = FormData;
            RegistrationConfig(returnModel,"Pess1", registrationId);
            (returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).Navigation = Navigation;
            (returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).LoadPartial(Request.QueryString);
            (returnModel.FormData as ViewModels.Pess1.Pess1_ViewModel).MapFromModel();

            returnModel.FormPswData = FormPswData;
            RegistrationConfig(returnModel,"Defaultpsw", registrationId);
            (returnModel.FormPswData as ViewModels.Psw.Defaultpsw_ViewModel).Navigation = Navigation;

            return Json(new { Success = false, Form = "Form_Pess1", Operation = "New", View = RenderPartialViewToString(this, "Register", returnModel), Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
        }

		public CSGenioApess1 Pess1_New_Registration(ViewModels.Pess1.Pess1_ViewModel model)
        {
			User u = UserContext.Current.User;
            u.AddModuleRole("GQT", CSGenio.framework.Role.ADMINISTRATION);
			try
			{
				//TMV adds the module to be able to check the permisions
				u.CurrentModule = "GQT";
				var Model = new Models.Pess1
				{
					ValZzstate = 0,
				};
				model.MapToModel(Model);

				PersistentSupport sp = UserContext.Current.PersistentSupport;

				Model.klass.removeCalculatedFields();
				Model.klass.change(sp, (Quidgest.Persistence.GenericQuery.CriteriaSet)null);

				u.RemoveModuleRole("GQT", CSGenio.framework.Role.ADMINISTRATION);
				u.CurrentModule = null;


				// MH - Visualizar os warnings obtidos durante gravação. (ex: Condição de escrita que não impede gravação)
				if (model.flashMessage != null && (model.flashMessage.Status == Status.W || model.flashMessage.Status == Status.OK_MAIS_W))
					GetFlashMessage(model.flashMessage, Navigation.CurrentLevel.FormMode);

				return Model.klass;
			}
			catch
            {
                u.RemoveModuleRole("GQT", CSGenio.framework.Role.ADMINISTRATION);
                u.CurrentModule = null;
                throw;
            }
        }

		// GET: /Account/ConfirmEmail
        [HttpGet]
        public ActionResult ConfirmEmail(string ticket)
        {
			try
			{
                object[] objs = QResources.DecryptTicketBase64(ticket);

                string username = objs[0] as string;
                Resource rec = objs[2] as Resource;

                if (rec is ResourceUser)
                {
                    try
                    {
                        ResourceUser recq = rec as ResourceUser;
                        PersistentSupport sp = UserContext.Current.PersistentSupport;
                        if (DateTime.UtcNow < recq.CreationDate.AddHours(24))
                        {
                            Psw psw = Psw.Find(recq.ID);
                            sp.openConnection();
                            psw.ValStatus = 0;
                            psw.Apply();
                            sp.closeConnection();
                        }
                    }
                    catch (Exception e)
                    {
                        CSGenio.framework.Log.Error(e.Message);
                        return View("~/Views/Account/ErrorTicketConfirm.cshtml");
                    }
                }
			}
			catch (Exception e)
            {
                CSGenio.framework.Log.Error(e.Message);
                return View("~/Views/Account/ErrorTicketConfirm.cshtml");
            }
            return View("~/Views/Account/SuccessTicketConfirm.cshtml");
        }

		//
		// GET: /Account/ChangePassword

		[AuthorizeForUsers]
		public ActionResult ChangePassword()
		{
			return View();
		}

		//
		// POST: /Account/ChangePassword
		[AuthorizeForUsers]
		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordModel model)
		{
			if (ModelState.IsValid)
			{
				// ChangePassword will throw an exception rather
				// than return false in certain failure scenarios.
				bool changePasswordSucceeded;
				try
				{
					MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
					changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
				}
				catch (Exception)
				{
					changePasswordSucceeded = false;
				}

				if (changePasswordSucceeded)
				{
					return RedirectToAction("ChangePasswordSuccess", new { nav = Navigation.NavigationId });
				}
				else
				{
					ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ChangePasswordSuccess
		[AuthorizeForUsers]
		public ActionResult ChangePasswordSuccess()
		{
			return View();
		}

        [AllowAnonymous]
        public ActionResult RecoverPassword()
        {
            return View(new PasswordRecoverViewModel());
        }

        private void SetCookie(string userName, string year)
        {
            FormsAuthenticationTicket ticket =
              new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                  false,
                  year);

            string hashedTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket) { Expires = DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes) };
            HttpContext.Response.Cookies.Add(cookie);
        }

        private User AuthenticateUser(BasicUserModel model, string year)
        {
            User user = new User(model.UserName, HttpContext.Session.SessionID, Configuration.DefaultYear, Request.UserHostName);

            IPrincipal principal = null;

            try
            {
                principal = SecurityFactory.Authenticate(
                       new UserPassCredential() { Username = model.UserName, Password = model.Password, Year = year });
                if (principal == null)
                {
					throw new BusinessException(Resources.Resources.LOGIN_OU_PASSWORD_IN32183, "InterfaceXml.pedidoEXW()", Resources.Resources.LOGIN_OU_PASSWORD_IN32183);
                }

                //o user entra no primeiro Qyear a que tem direito
                Exception lastException = null;
                bool sucess = false;
                // tentar fazer login no DefaultYear
                if (principal.IsInRole(user.Year))
                {
                    try
                    {
                        user = UserFactory.FillUser(principal, user);
                        sucess = true;
                    }
                    catch (Exception e)
                    {
                        lastException = e;
                    }
                }
                if (!sucess)
                {
                    foreach (string Qyear in Configuration.Years)
                    {
                        if (principal.IsInRole(Qyear))
                        {
                            user.Year = Qyear;

                            try
                            {
                                user = UserFactory.FillUser(principal, user);
                                sucess = true;
                            }
                            catch (Exception e)
                            {
                                lastException = e;
                                //guarda a excepção e tenta o proximo Qyear
                                continue;
                            }

                            //caso tenhamos entrado podemos esquecer a ultima excepção
                            lastException = null;
                            break;
                        }
                    }
                }

                //caso não tenhamos entrado em nenhum Qyear relançamos a excepção
                //entra aqui caso as autorizações nem tenham roles to nenhum Qyear
                if (!sucess)
                {
                    throw new BusinessException("O utilizador não pode aceder a nenhum módulo web.", "AuthenticateUser", "O utilizador não pode aceder a nenhum módulo web.");
                }
                //falhou em todos os anos e mostra aqui a ultima excepção
                if (lastException != null)
                {
                    throw lastException;
                }

                QCache.Instance.User.Put("principal." + principal.Identity.Name, principal);
                UserContext.Current.User = user;
            }
            catch (Exception)
            {
                user = null;
                ModelState.AddModelError("", Resources.Resources.ENTRADA_INCORRETA__T45717);
            }

            return user;
        }

        [AuthorizeForUsers]
        public ActionResult GetImage()
        {
            User usr = UserContext.Current.User;

            // html for user avatar image
            string dataImage = "";
            string ckey = "userInfo." + usr.Codpsw;

            UserInfo usrInfo = QCache.Instance.User.Get(ckey) as UserInfo;

            if (usrInfo == null)
            {
                usrInfo = UserProfileInfo.getUserImage(UserContext.Current.PersistentSupport, usr);

                if (!usrInfo.IsEmpty())
                    QCache.Instance.User.Put(ckey, usrInfo, TimeSpan.FromMinutes(1));
            }

            if (usrInfo.Image != null && usrInfo.Image.Length > 0 )
            {
                IHtmlString img = HtmlHelpers.Image(null, usrInfo.Image, new {@class = "avatar", title = usr.Name, data_toggle="tooltip", data_placement="left", alt="User Avatar"});
                dataImage = img.ToHtmlString();
            }
            else
            {
                var img = new TagBuilder("img");
                img.AddCssClass("avatar");
                img.Attributes.Add("src", UrlHelper.GenerateContentUrl("~/Content/img/user_avatar.png", HttpContext));
                img.Attributes.Add("data-toggle", "tooltip");
                img.Attributes.Add("data-placement", "left");
                img.Attributes.Add("title", usr.Name);
                img.Attributes.Add("alt", "User Avatar");
                img.Attributes.Add("aria-hidden", "true");
                dataImage = img.ToString();
            }

            return Json(new { Success = true, img = dataImage, fullname = usrInfo.Fullname, position = usrInfo.Position }, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeForUsers]
        // MH (03/08/2021) - The Session and HttpRuntime.Cache are different things.
        //     We can use Session in read only since it doesn't write there. (Optimization for Vue.js)
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult UserAvatar()
        {
            User usr = UserContext.Current.User;

            // base64 image for user avatar image
            string dataImage = "";
            string ckey = "userInfo." + usr.Codpsw;

            UserInfo usrInfo = QCache.Instance.User.Get(ckey) as UserInfo;

            if (usrInfo == null)
            {
                usrInfo = UserProfileInfo.getUserImage(UserContext.Current.PersistentSupport, usr);

                if (!usrInfo.IsEmpty())
                    QCache.Instance.User.Put(ckey, usrInfo, TimeSpan.FromMinutes(1));
            }

            if (usrInfo.Image != null && usrInfo.Image.Length > 0)
            {
                string img = HtmlHelpers.ImageBase64(null, usrInfo.Image);
                if (img != null)
                    dataImage = img;
            }

            var usrAvatarMenu =  UserAvatarMenu.GetMenus(UserContext.Current.PersistentSupport, UserContext.Current.User);
            var ePHUsrAvatarMenu = EPHUserAvatarMenu.GetMenus();
            var avatar = new { image = dataImage, fullname = usrInfo.Fullname, position = usrInfo.Position };

            return Json(new { Success = true, Avatar = avatar, UserAvatarMenus = usrAvatarMenu, EPHUserAvatarMenus = ePHUsrAvatarMenu }, JsonRequestBehavior.AllowGet);
        }

		// GET: /Account/GetIfUserLogged
        public ActionResult GetIfUserLogged()
        {
            var user = UserContext.Current.User;
            return Json(new { username = user.Name != "guest" ? user.Name : "" });
        }

		#region Status Codes

		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}

		#endregion
	}
}