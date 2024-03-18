using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Menus;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.UserAdmin;
using GenioServer.security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Security.Principal;

namespace GenioMVC.Controllers
{
	public class AccountController : ControllerBase
	{
		public AccountController(IUserContextService userContextService) : base(userContextService)
		{
		}

		//
		// GET: /Account/LogOn
// USE /[MANUAL GQT CUSTOM_LOGON_GET]/
		// GET: /Account/LogOnPartial
        [HttpGet]
        [AllowAnonymous]
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

			return JsonOK(model);
		}

        [HttpGet]
        [AllowAnonymous]
		//
		// GET: /Account/LogOn
		public ActionResult LogOn()
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

			return JsonOK(model);
		}

		//
		// POST: /Account/LogOn
		[HttpPost]
		[AllowAnonymous]
// USE /[MANUAL GQT CUSTOM_LOGON_POST]/
		public ActionResult LogOn([FromBody]LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				User? user = AuthenticateUser(model, Configuration.DefaultYear);

				if (user != null)
				{
					PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year);
					//Check for DB Version
					if (Configuration.GetDbVersion(user.Year) != Configuration.VersionDbGen ||
						Configuration.GetDbUpgrIndx(user.Year) < Configuration.VersionUpgrIndxGen)
					{
						UserContext.Current.Destroy();
						return Json(new { Success = false, Message = Resources.Resources.E_NECESSARIO_ATUALIZ49371 });
					}

					//Check for Configuration Version
					if (Configuration.ConfigVersion != GenioServer.framework.ConfigXMLMigration.CurConfigurationVerion.ToString())
					{
						UserContext.Current.Destroy();
						return Json(new { Success = false, Message = Resources.Resources.E_NECESSARIO_PROCEDE36325 });
					}

					try
					{
                    GlobalAppSessions.Instance.AddOrUpdate(HttpContext.Session.Id, user.Name, HttpContext.GetHostName());
					}
					catch (FrameworkException e)
					{
						var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
						if (e.UserMessage != null)
							exceptionUserMessage = Translations.Get(e.UserMessage, UserContext.Current.User.Language);

                    UserContext.Current.Destroy();
						return Json(new { Success = false, Message = exceptionUserMessage });
					}

					//TSX (12/04/2019) - All unsuccess have to stay here before create cookie with user because if user refresh the page the application think it is authenticated
					if (user.Status == 2)
					{
						UserContext.Current.Destroy();
						return Json(new { Success = false, Message = Resources.Resources.ESTE_UTILIZADOR_ENCO01685 });
					}

					if (!user.Auth2FA)
						return finalizeAuthentication(user, returnUrl, false);
					return Json(new { Success = true, Auth2FA = true, User = user, Redirect = returnUrl });
				}
				else if (!String.IsNullOrEmpty(model.UserName))
					CSGenio.framework.Audit.registLoginOut(UserContext.Current.User, model.UserName, Resources.Resources.TENTATIVA38682, Resources.Resources.LOGIN_OU_PASSWORD_IN32183, HttpContext.GetHostName(), HttpContext.GetIpAddress());
			}

			Dictionary<string, string> errors = new Dictionary<string, string>();

            foreach (var key in ModelState.Keys)
            {
                if (ModelState[key].Errors.Any())
                {
                    errors.Add(key, ModelState[key].Errors.First().ErrorMessage);
                }
            }

            // If we got this far, something failed, redisplay form
            model.Load();
            return Json(new { Success = false, Errors = errors });
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Authentication2FA([FromBody] LogOnModel model, string returnUrl)
		{
			UserPassCredential cred = new UserPassCredential();
			cred.Username = model.UserName;
			cred.Password = model.Password;
            TOTPIdentityProvider totp = new TOTPIdentityProvider();
            var ident = totp.Authenticate(cred);
			if (ident != null)
			{
				var principal = SecurityFactory.GetUserRoles(ident);
                User user = new User(model.UserName, HttpContext.Session.Id, Configuration.DefaultYear, HttpContext.GetHostName());
				UserFactory.FillUser(principal, user);
				return finalizeAuthentication(user, returnUrl, true);
			}
            return Json(new { Success = false, Message = Resources.Resources.DADOS_DE_LOGIN_INCOR44791 });
		}

		/// <summary>
		/// Sends the email for password recovery
		/// </summary>
		/// <remarks>TODO: Add Captcha to the RecoverPassword interface (Vue.js)</remarks>
		[HttpPost]
		[AllowAnonymous]
		public ActionResult RecoverPassword([FromBody]PasswordRecoverViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					User u = UserContext.Current.User;
					PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
					UserFactory userFactory = new UserFactory(sp, u);
					IPrincipal principal = HttpContext.User;
					//Check if the user with this email exists
					var user = SecurityFactory.GetUserFromEmail(principal.Identity, model.Email, u, sp);

					string emailBody = "";
					string appName = Configuration.Application.Name;
					//TODO: this should be obtained directly from user that already has its language filled by Usercontext
					string lang = RouteData.Values["culture"]?.ToString() ?? "";

					if (user != null)
					{
						ResourceUser rec = new ResourceUser(user.ValNome, user.ValCodpsw);
						var ticket = QResources.CreateTicketEncryptedBase64(u.Name, u.Location, rec);

						string userName = user.ValNome;
						string? urlToken = Url.Action("RecoverPasswordChange", "Account", new { ticket }, Request.Scheme);

						emailBody = UserRegistration.GetEmailForLanguage("PasswordChangeEmail", lang);
						emailBody = String.Format(emailBody, appName, userName, urlToken);
					}
					else
					{
						emailBody = UserRegistration.GetEmailForLanguage("InvalidEmailTemplate", lang);
						string? baseUrl = Url.Action("LogOn", "Account", null, Request.Scheme);
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

			return JsonOK(model);
		}

		/// <summary>
		/// Receives a ticket, validates it and shows the view to change password
		/// </summary>
		[AllowAnonymous]
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
					HttpContext.Session.SetString("userId", resource.Name);
					return RedirectToVuePage("RecoverPasswordChange", new { UserId = model.UserId });
				}

				return RedirectToVuePage("ErrorTicketConfirm");
			}
			catch
			{
				return RedirectToVuePage("ErrorTicketConfirm");
			}
		}

		/// <summary>
		/// Persist the password change
		/// </summary>
		[HttpPost]
		[AllowAnonymous]
		public ActionResult RecoverPasswordChange([FromBody]PasswordRecoverChangeModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					User u = UserContext.Current.User;
					PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
					var userFactory = new UserFactory(sp, u);
					//Get the user id from the session
					string userId = HttpContext.Session.GetString("userId");
					model.UserId = userId;

					var user = userFactory.GetUser(userId);
					//Change password
					Password password = new Password(model.NewPassword, model.ConfirmPassword);
					userFactory.ChangePassword(user, password);

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
					HttpContext.Session.Remove("userId");
					return JsonOK(/* TODO: data ?? */);
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

			return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848, model);
		}

		[AllowAnonymous]
		public ActionResult WebAuthn2FAAssertionOptions()
		{
			WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
			{
				MDSAccessKey = ModelState.GetValueOrDefault("fido2:MDSAccessKey")?.AttemptedValue,
				MDSCacheDirPath = ModelState.GetValueOrDefault("fido2:MDSCacheDirPath")?.AttemptedValue,
				TimestampDriftTolerance = ModelState.GetValueOrDefault("fido2:TimestampDriftTolerance")?.AttemptedValue,
                //Fido2Options = new WebAuthFido2Options() { Origin = Request.Url.GetLeftPart(UriPartial.Authority) }
                Fido2Options = new WebAuthFido2Options() { Origin = $"{Request.Scheme}://{Request.Host}{Request.PathBase}" }
			});

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
			var returnWebAuth = credWebAuth.AssertionOptionsPost(user.Codpsw, sp);

			if (returnWebAuth.Success)
			{
				//Temporarily store options, session/in-memory cache/redis/db
				HttpContext.Session.SetString("fido2.attestationOptions", returnWebAuth.Options);
				return Json(new { Success = true, options = returnWebAuth.Options });
			}

			return Json(new { Success = false, ErrorMessage = returnWebAuth.ErrorMessage });
		}

		public async Task<ActionResult> WebAuthn2FAMakeAssertion(string data, string returnUrl)
		{
			WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
			{
				MDSAccessKey = ModelState.GetValueOrDefault("fido2:MDSAccessKey")?.AttemptedValue,
				MDSCacheDirPath = ModelState.GetValueOrDefault("fido2:MDSCacheDirPath")?.AttemptedValue,
				TimestampDriftTolerance = ModelState.GetValueOrDefault("fido2:TimestampDriftTolerance")?.AttemptedValue,
                //Fido2Options = new WebAuthFido2Options() { Origin = Request.Url.GetLeftPart(UriPartial.Authority) }
                Fido2Options = new WebAuthFido2Options() { Origin = $"{Request.Scheme}://{Request.Host}{Request.PathBase}" }
			});

			User user = UserContext.Current.User;

			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
			var returnWebAuth = await credWebAuth.MakeAssertion(data, HttpContext.Session.GetString("fido2.assertionOptions"), user.Codpsw, sp);

			if (returnWebAuth.Success)
				return finalizeAuthentication(user, returnUrl, true);
			return Json(new { Success = returnWebAuth.Success, ErrorMessage = returnWebAuth.ErrorMessage });
		}

		/// <summary>
		/// After user request to authenticate with OpenId Connect we will redirect user to the authentication page from the provider
		/// </summary>
		/// <param name="id">the "id" argument isn't used at the moment but when have multiple identity providers configured that will be used</param>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public ActionResult OpenIdLoginRedirect(string id)
		{
			string urlRedirectAuth = (new OpenIdConnectIdentityProvider()).GetUrlToAuthenticate(
				Url.RouteUrl("OIdAuth", null, Request.Scheme) //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
			);

			return Json(new { redirectUrl = urlRedirectAuth });
		}

		/// <summary>
		/// After user request to authenticate with CMD provider we will redirect user to the authentication page from the provider
		/// </summary>
		/// <param name="id">the "id" argument isn't used at the moment but when have multiple identity providers configured that will be used</param>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public ActionResult CMDLoginRedirect(string id)
		{
			string urlRedirectAuth = (new CMDIdentityProvider()).GetUrlToAuthenticate(
				Url.RouteUrl("OIdAuth", null, Request.Scheme) //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
			);

			return Json(new { redirectUrl = urlRedirectAuth });
		}

		/// <summary>
		/// After user have authenticated on external identity provider will callback to our application to that funcion.
		/// </summary>
		/// <param name="id_token">Returned token by the external identity provider. The primary extension that OpenID Connect makes to OAuth 2.0 to enable End-Users to be Authenticated is the ID Token data structure. The ID Token is a security token that contains Claims about the Authentication of an End-User by an Authorization Server when using a Client, and potentially other requested Claims. The ID Token is represented as a JSON Web Token (JWT)</param>
		/// <param name="code">The Authorization Code Flow returns an Authorization Code to the Client. This provides the benefit of not exposing any tokens to the User Agent and possibly other malicious applications with access to the User Agent. The Authorization Server can also authenticate the Client before exchanging the Authorization Code for an Access Token. The Authorization Code flow is suitable for Clients that can securely maintain a Client Secret between themselves and the Authorization Server. More information at https://openid.net/specs/openid-connect-core-1_0.html#CodeFlowAuth</param>
		/// <returns></returns>
		[HttpPost]
		[AllowAnonymous]
		public ActionResult OpenIdLogin([FromForm]string id_token, [FromForm] string code)
		{
			try
			{
				//decode JWT received, more information at https://openid.net/specs/openid-connect-core-1_0.html#IDToken
				var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(id_token);

				OpenIdConnectIdentityProvider ip = new OpenIdConnectIdentityProvider();
				ip.Options.CallbackPath = Url.RouteUrl("OIdAuth", null, Request.Scheme); //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
				TokenCredential qToken = new TokenCredential();
				qToken.Token = token.ToString();

				var id = ip.Authenticate(qToken, code);

				if (id != null) //When user authenticated successfull return to Home page
				{
					User user = new User(id.Name, "id", Configuration.DefaultYear, HttpContext.GetHostName());
					user.Auth2FA = false; //This authentication method doesn't allow 2FA because the provider have this responsibility
					user.Status = 0; //At this moment if "id" isn't null than this user have status = 0

					finalizeAuthentication(user, "", false);
					return RedirectToVuePage("");
				}
			}
			catch { }

			ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
			return RedirectToVuePage(""); //TODO: When user authentication error then return again to Logon page
		}

		/// <summary>
		/// After user have authenticated on Governement CMD identity provider will callback to our application to that funcion.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public ActionResult OpenIdLogin()
		{
			return Content(string.Format("<script>window.location = '{0}?' + window.location.hash.substring(1);</script>", Url.Action("CMDLogin", "Account")), "text/html");
		}

		/// <summary>
		/// /// After user have authenticated on Governement CMD identity provider, it is invoked an API to get data associated with token, and the laocal login process is satarted
		/// </summary>
		/// <param name="access_token">authentication token</param>
		/// <param name="token_type"></param>
		/// <param name="expires_in"></param>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> CMDLogin(string access_token, string token_type, string expires_in)
		{
			try
			{
				CMDIdentityProvider ip = new CMDIdentityProvider();

                var http = new HttpClient();
				http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				var resp = await http.GetAsync(ip.Options.DataAPI + "?token=" + access_token);
				resp.EnsureSuccessStatusCode();
				string jsonResult = await resp.Content.ReadAsStringAsync();

                DomainCredential credencial = ip.ValidateCredencial(jsonResult);

                if (credencial != null)
                {
                    var id = ip.Authenticate(credencial);

                    if (id != null) //When user authenticated successfull return to Home page
                    {
                        var user = new User(id.Name, "id", Configuration.DefaultYear, HttpContext.GetHostName());
                        user.Auth2FA = false; //This authentication method doesn't allow 2FA because the provider have this responsibility
                        user.Status = 0; //At this moment if "id" isn't null than this user have status = 0

                        finalizeAuthentication(user, "", false);
                        return RedirectToVuePage("Home");
                    }
                }
			}
			catch (Exception ex)
			{
				Log.Error("GetData error:"+ ex.Message);
			}

			ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
			return RedirectToVuePage("Home"); // TODO: When user authentication error then return again to Logon page
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult CASLoginRedirect(string id)
		{
			string ticket = "";

			string urlRedirectAuth = (new CASIdentityProvider()).GetUrlToAuthenticate(
				Url.RouteUrl("CASAuth", null, Request.Scheme), //Get absolute path with scheme + domain + "/CASLogin" to provider known were to send the callback
				"login" //path to contact
			);

			if (Request.Query.ContainsKey("SAMLArt"))
				ticket = Request.Query["SAMLArt"].ToString();
			else
				return Json(new { redirectUrl = urlRedirectAuth });

			return CASLogin(ticket);
		}

		[AllowAnonymous]
		public ActionResult CASLogin(string SAMLart)
		{
			if (!String.IsNullOrEmpty(SAMLart))
			{
				try
				{
					CASIdentityProvider ip = new CASIdentityProvider();
					ip.Options.CallbackPath = Url.RouteUrl("CASAuth", null, Request.Scheme); //Get absolute path with scheme + domain + "/OpenIdLogin" to provider known were to send the callback
					TokenCASCredential qToken = new TokenCASCredential();
					qToken.Token = SAMLart;
					qToken.OriginUrl = Request.GetDisplayUrl();

					var id = ip.Authenticate(qToken);

					if (id != null) //When user authenticated successfull return to Home page
					{
						User user = new User(id.Name, "id", Configuration.DefaultYear, HttpContext.GetHostName());
						user.Auth2FA = false; //This authentication method doesn't allow 2FA because the provider have this responsibility
						user.Status = 0; //At this moment if "id" isn't null than this user have status = 0

						finalizeAuthentication(user, "", false);
						return RedirectToVueRoute("home");
					}
				}
				catch (Exception e)
				{
					Log.Error(e.Message);
				}
			}

			ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
			return RedirectToVueRoute("LogOn", new { nav = Navigation.NavigationId }); //TODO: When user authentication error then return again to Logon page
		}

        private ActionResult finalizeAuthentication(User user, string returnUrl, bool Val2FA)
        {
            if (user != null)
            {
                //UserContext.Current.SetFormsAuthenticationCookie();
                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }, LegacyFormsAuthenticationOptions.DefaultScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal).Wait();

                // log login (audit)
                CSGenio.framework.Audit.registLoginOut(user, Resources.Resources.ENTRADA31905, Resources.Resources.ENTRADA_ATRAVES_DA_P48446, HttpContext.GetHostName(), HttpContext.GetIpAddress());

                if (GlobalFunctions.emptyN(user.Status) == 0 && user.Status == 1 || (Configuration.Security.Mandatory2FA && !user.Auth2FA))
                {
                    if (Val2FA)
                        return Json(new { Success = true, Redirect = Url.Action("Profile", "Home"), Val2FA = true });
                    return Json(new { Success = true, Redirect = Url.Action("Profile", "Home") });
                }
                else if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    if (Val2FA)
                        return Json(new { Success = true, Redirect = returnUrl, Val2FA = true });
                    return Json(new { Success = true, Redirect = returnUrl });
                }
                else
                {
                    if (Val2FA)
                        return Json(new { Success = true, Redirect = Url.Action("Index", "Home"), Val2FA = true });
                    return Json(new { Success = true, Redirect = Url.Action("Index", "Home") });
                }
            }
            else
            {
                if (Val2FA)
                    return Json(new { Success = false, Message = Resources.Resources.DADOS_DE_LOGIN_INCOR44791, Val2FA = false });
                return Json(new { Success = false, Message = Resources.Resources.DADOS_DE_LOGIN_INCOR44791 });
            }
        }

		//
		// GET: /Account/LogOff
		[HttpPost]
		public ActionResult LogOff()
		{
			DestroySession();
			return JsonOK();
		}

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register(string Form, string Pswform, string id)
		{
			ViewModels.RegisterViewModel model = new ViewModels.RegisterViewModel();

			RegistrationConfig(model, Form, id);
			RegistrationConfig(model, Pswform, id);

			return JsonOK(model);
		}

		/// <summary>
		/// A dictionary with all user registrations defined (The form order is defined by list object)
		/// </summary>
		private Dictionary<string, List<string>> registrationFormList = new Dictionary<string, List<string>>
		{
		};

		/// <summary>
		/// Get the form order of each user registration
		/// </summary>
		/// <param name="form">form to get order</param>
		/// <param name="formRegistor">user registration ID</param>
		/// <returns>form order</returns>
		private int GetRegistrationFormOrder(string form, string registrationID)
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
		}

		public ActionResult CreationSuccess()
		{
			return JsonOK();
		}

		public class VueCaptchaModel
		{
			public string CaptchaId { get; set; }

			public string UserEnteredCaptchaCode { get; set; }
		}

		// GET: /Account/ConfirmEmail
		[HttpGet]
		[AllowAnonymous]
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
							Psw psw = Psw.Find(recq.ID, UserContext.Current);
							sp.openConnection();
							psw.ValStatus = 0;
							psw.Apply();
							sp.closeConnection();
						}
					}
					catch (Exception e)
					{
						CSGenio.framework.Log.Error(e.Message);
						return RedirectToVuePage("ErrorTicketConfirm");
					}
				}
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error(e.Message);
				return RedirectToVuePage("ErrorTicketConfirm");
			}

			return RedirectToVuePage("SuccessTicketConfirm");
		}


		[AllowAnonymous]
		public ActionResult RecoverPassword()
		{
			return JsonOK(new PasswordRecoverViewModel());
		}

		private User AuthenticateUser(BasicUserModel model, string year)
		{
			User user = new User(model.UserName, HttpContext.Session.Id, Configuration.DefaultYear, HttpContext.GetHostName());
			IPrincipal principal = null;

			try
			{
				principal = SecurityFactory.Authenticate(new UserPassCredential() { Username = model.UserName, Password = model.Password, Year = year });
				if (principal == null)
					throw new BusinessException(Resources.Resources.LOGIN_OU_PASSWORD_IN32183, "InterfaceXml.pedidoEXW()", Resources.Resources.LOGIN_OU_PASSWORD_IN32183);

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
					throw new BusinessException("O utilizador não pode aceder a nenhum módulo web.", "AuthenticateUser", "O utilizador não pode aceder a nenhum módulo web.");
				//falhou em todos os anos e mostra aqui a ultima excepção
				if (lastException != null)
					throw lastException;

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

		[HttpGet]
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
				dataImage = HtmlHelpers.ImageBase64(usrInfo.Image);
			}
			else
			{
				var avatar = System.IO.File.ReadAllBytes("./Content/img/user_avatar.png");
				dataImage = HtmlHelpers.ImageBase64(avatar);
			}

			return Json(new { Success = true, img = dataImage, fullname = usrInfo.Fullname, position = usrInfo.Position });
		}

		[HttpGet]
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
				string img = HtmlHelpers.ImageBase64(usrInfo.Image);
				if (img != null)
					dataImage = img;
			}

			var usrAvatarMenu = UserAvatarMenu.GetMenus(UserContext.Current.PersistentSupport, UserContext.Current.User);
			var ePHUsrAvatarMenu = EPHUserAvatarMenu.GetMenus(UserContext.Current);
			var avatar = new { image = dataImage, fullname = usrInfo.Fullname, position = usrInfo.Position };

			var has2FAOptions = Configuration.Security.Activate2FA != Auth2FAModes.None;
			var hasOpenIdAuth = new OpenIdConnectIdentityProvider().Options != null;

			return Json(new { Success = true, Avatar = avatar, UserAvatarMenus = usrAvatarMenu, EPHUserAvatarMenus = ePHUsrAvatarMenu, Has2FAOptions = has2FAOptions, HasOpenIdAuth = hasOpenIdAuth });
		}

		// GET: /Account/GetIfUserLogged
		[AllowAnonymous]
		public ActionResult GetIfUserLogged()
		{
			var user = UserContext.Current.User;
			return Json(new { username = user.Name != "guest" ? user.Name : "" });
		}

	}
}
