using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Security.Principal;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Menus;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioServer.security;
using CSGenio.core.persistence;
using CSGenio.core.di;

namespace GenioMVC.Controllers
{
	public class AccountController(IUserContextService userContextService) : ControllerBase(userContextService)
	{
		//
		// GET: /Account/LogOn
// USE /[MANUAL GQT CUSTOM_LOGON_GET]/

		[HttpGet]
		[AllowAnonymous]
		//
		// GET: /Account/LogOn
		public ActionResult LogOn()
		{
			LogOnModel model = new();

			foreach(var ip in SecurityFactory.IdentityProviderList)
			{
				if (ip.HasRedirectLogin())
					model.AuthRedirectMethods.Add(new()
					{
						Id = ip.Id,
						Description = ip.Description,
						Redirect = ip.GetRedirectLoginUrl(
                            AuthRedirectMethodModel.MapRedirectEndpoint(ip, Url, Request))
					});
            }

			return JsonOK(model);
		}
        /// <summary>
        /// Validates the provided model and adds any validation errors to the ModelState.
        /// </summary>
        /// <param name="model">The model to be validated.</param>
        /// <param name="userContext">The userContext.</param>
        public void ValidateModel(IValidatable model, UserContext userContext)
		{
			var validationResult = model.Validate(userContext);

			foreach (var (field, errorMessages) in validationResult.ModelErrors)
				foreach (var errorMessage in errorMessages)
					ModelState.AddModelError(field, errorMessage);
		}

		//
		// POST: /Account/LogOn
		[HttpPost]
		[AllowAnonymous]
// USE /[MANUAL GQT CUSTOM_LOGON_POST]/

		public ActionResult LogOn([FromBody]LogOnModel model, string returnUrl)
		{
			ValidateModel(model, UserContext.Current);
			if (!ModelState.IsValid)
				return JsonERROR();

			User? user = AuthenticateUser(model, Configuration.DefaultYear);
			if (user == null)
			{
				ModelState.AddModelError("Error", Resources.Resources.ENTRADA_INCORRETA__T45717);
				
				//Increment invalid login counter
				GenioDI.MetricsOtlp.IncrementCounter("login_counter", 1, new List<KeyValuePair<string, object>>() {
					new("User", model.UserName),
					new("Ip", HttpContext.GetIpAddress()),
					new("Failed", true)
				});

				return JsonERROR();
			}

            string loginError = ValidateLoginState(user);
			if(!string.IsNullOrEmpty(loginError))
			{
                ModelState.AddModelError("Error", loginError);

				//Increment invalid login counter
				GenioDI.MetricsOtlp.IncrementCounter("login_counter", 1, new List<KeyValuePair<string, object>>() {
					new("User", model.UserName),
					new("Ip", user.Location),
					new("Failed", true)
				});

                return JsonERROR();
            }

			//Increment success login counter
			GenioDI.MetricsOtlp.IncrementCounter("login_counter", 1, new List<KeyValuePair<string, object>>() {
				new("User", model.UserName),
				new("Ip", user.Location),
				new("Failed", false)
			});

			if (user.Auth2FA)
				return Json(new { Success = true, Auth2FA = true, User = user, Redirect = returnUrl });

			return finalizeAuthentication(user, returnUrl, false);
		}


		private string ValidateLoginState(User user)
		{
            if (user.Status == 2)
            {
                string errorMessage = Resources.Resources.ESTE_UTILIZADOR_ENCO01685;
                Log.Error($"{errorMessage}. User: {user.Name}");
				return errorMessage;
            }

            bool isConfigurationValid = DatabaseVersionReader.IsConfigurationUpToDate();
			if (!isConfigurationValid)
			{
                string errorMessage = Resources.Resources.E_NECESSARIO_PROCEDE36325;
                Log.Error($"{errorMessage}. Found: {Configuration.GetDbVersion(user.Year)}, Expected: {Configuration.VersionDbGen}");
				return errorMessage;
            }

            bool isValidDb = DatabaseVersionReader.IsDatabaseUpToDate(user);
            if (!isValidDb)
            {
                string errorMessage = Resources.Resources.E_NECESSARIO_ATUALIZ49371;
                Log.Error($"{errorMessage}. Found: {Configuration.GetDbVersion(user.Year)}, Expected: {Configuration.VersionDbGen}");
                return errorMessage;
            }

            return null;
        }

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Authentication2FA([FromBody] LogOnModel model, string returnUrl)
		{
			UserPassCredential cred = new();
			cred.Username = model.UserName;
			cred.Password = model.Password;
			TOTPIdentityProvider totp = new();
			var ident = totp.Authenticate(cred);
			if (ident == null)
				return JsonERROR(Resources.Resources.DADOS_DE_LOGIN_INCOR44791);

			var principal = SecurityFactory.GetUserRoles(ident);
			User user = new(model.UserName, HttpContext.Session.Id, Configuration.DefaultYear, HttpContext.GetHostName());
			UserFactory.FillUser(principal, user);

			return finalizeAuthentication(user, returnUrl, true);
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
				ValidateModel(model, UserContext.Current);

				if (!ModelState.IsValid)
					return JsonERROR();

                var CaptchaData = model.CaptchaData;
                bool isValidCaptcha = QCaptcha.Validate(CaptchaData.UserEnteredCaptchaCode, CaptchaData.CaptchaId, HttpContext.Session);
                QCaptcha.SetCaptcha(CaptchaData.CaptchaId, null, HttpContext.Session);
                if (!isValidCaptcha)
                {
                    ModelState.AddModelError("userEnteredCaptchaCode", Resources.Resources.INVALID_CAPTCHA29660);
                    return JsonERROR(Resources.Resources.INVALID_CAPTCHA29660);
                }

				User u = UserContext.Current.User;
				PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
				UserFactory userFactory = new(sp, u);
				IPrincipal principal = HttpContext.User;
				//Check if the user with this email exists
				var user = SecurityFactory.GetUserFromEmail(principal.Identity, model.Email, u, sp);

				string emailBody = "";
				string appName = Configuration.Application.Name;
				//TODO: this should be obtained directly from user that already has its language filled by Usercontext
				string lang = RouteData.Values["culture"]?.ToString() ?? "";

				if (user != null)
				{
					ResourceUser rec = new(user.ValNome, user.ValCodpsw);
					var ticket = QResources.CreateTicketEncryptedBase64(u.Name, u.Location, rec);

					string userName = user.ValNome;
					string? urlToken = Url.Action("RecoverPasswordChange", "Account", new { ticket }, Request.Scheme);

					emailBody = UserRegistration.GetEmailForLanguage("PasswordChangeEmail", lang);
					emailBody = string.Format(emailBody, appName, userName, urlToken);
				}
				else
				{
					emailBody = UserRegistration.GetEmailForLanguage("InvalidEmailTemplate", lang);
					string? baseUrl = Url.Action("LogOn", "Account", null, Request.Scheme);
					emailBody = string.Format(emailBody, appName, baseUrl);
				}

				userFactory.SendPasswordRecoveryMail(model.Email, emailBody);
				model.IsEmailSent = true;
			}
			catch (Exception exc)
			{
				Log.Error(exc.Message);
				ModelState.AddModelError("error", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
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
					//Store the id in session for later use
					HttpContext.Session.SetString("userId", resource.Name);
					return RedirectToVuePage("RecoverPasswordChange");
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
			ValidateModel(model, UserContext.Current);
			if(!ModelState.IsValid)
				return JsonERROR();

			try
			{
				User u = UserContext.Current.User;
				PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
				var userFactory = new UserFactory(sp, u);
				//Get the user id from the session
				string userId = HttpContext.Session.GetString("userId");

				var user = userFactory.GetUser(userId);
				Password password = new(model.NewPassword, model.ConfirmPassword);

				string encOldPass = user.ValPassword;
				// checks if the new password is equal to the old one, if yes, return an error
				var isSamePassword = PasswordFactory.IsOK(password.New, encOldPass, user.ValSalt, user.ValPswtype);
				if (isSamePassword)
				{
					ModelState.AddModelError("error", Resources.Resources.A_NOVA_PALAVRA_PASSE58485);
					return JsonERROR();
				}

				//Change password
				userFactory.ChangePassword(user, model.NewPassword, model.ConfirmPassword);
				user.UserRecord = false;

				try
				{
					sp.openTransaction();

					user.User.Name = "PasswordRecovery";
					user.fillStampChange();
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
				return JsonOK();
			}
			catch (InvalidPasswordException exc)
			{
				Log.Error(exc.Message);
				ModelState.AddModelError("error", exc.UserMessage);
				return JsonERROR();
			}
			catch (Exception exc)
			{
				Log.Error(exc.Message);
				ModelState.AddModelError("error", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				return JsonERROR();
			}
		}

		[AllowAnonymous]
		public ActionResult WebAuthn2FAAssertionOptions()
		{
			WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
			{
				MDSAccessKey = ModelState.GetValueOrDefault("fido2:MDSAccessKey")?.AttemptedValue,
				MDSCacheDirPath = ModelState.GetValueOrDefault("fido2:MDSCacheDirPath")?.AttemptedValue,
				TimestampDriftTolerance = ModelState.GetValueOrDefault("fido2:TimestampDriftTolerance")?.AttemptedValue,
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

			return Json(new { Success = false, returnWebAuth.ErrorMessage });
		}

		public async Task<ActionResult> WebAuthn2FAMakeAssertion(string data, string returnUrl)
		{
			WebAuthIdentityProvider credWebAuth = new(new WebAuthValues()
			{
				MDSAccessKey = ModelState.GetValueOrDefault("fido2:MDSAccessKey")?.AttemptedValue,
				MDSCacheDirPath = ModelState.GetValueOrDefault("fido2:MDSCacheDirPath")?.AttemptedValue,
				TimestampDriftTolerance = ModelState.GetValueOrDefault("fido2:TimestampDriftTolerance")?.AttemptedValue,
				Fido2Options = new WebAuthFido2Options() { Origin = $"{Request.Scheme}://{Request.Host}{Request.PathBase}" }
			});

			User user = UserContext.Current.User;

			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
			var returnWebAuth = await credWebAuth.MakeAssertion(data, HttpContext.Session.GetString("fido2.assertionOptions"), user.Codpsw, sp);

			if (returnWebAuth.Success)
				return finalizeAuthentication(user, returnUrl, true);
			return Json(new { returnWebAuth.Success, returnWebAuth.ErrorMessage });
		}


        private ActionResult IdentityProviderLoginGeneric(string providerId, Func<IIdentityProvider, Credential> createCredential)
        {
            try
            {
                var ip = SecurityFactory.IdentityProviderList.First(i => i.Id == providerId);
                var credential = createCredential(ip);
				var identity = ip.Authenticate(credential);
                
                if (identity != null) //When user authenticated successfull return to Home page
                {
                    User user = new(identity.Name, "id", Configuration.DefaultYear, HttpContext.GetHostName())
                    {
                        Auth2FA = false, // This authentication method doesn't allow 2FA because the provider have this responsibility
                        Status = 0 // At this point if "id" isn't null then this user has status = 0
                    };

					var principal = SecurityFactory.GetUserRoles(identity);
					user = UserFactory.FillUser(principal, user);

                    string loginError = ValidateLoginState(user);
					if (!string.IsNullOrEmpty(loginError))
						throw new BusinessException(loginError, "IdentityProviderLoginGeneric", loginError);

                    finalizeAuthentication(user, "", false);
                    return RedirectToVuePage("");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
            return RedirectToVuePage("Error", null, false); //TODO: When user authentication error then return again to Logon page
        }

        [HttpPost]
        [AllowAnonymous]
		public ActionResult OpenIdConnectLogin([FromRoute] string providerId, [FromForm] string code, [FromForm] string id_token)
        {
			return IdentityProviderLoginGeneric(providerId, (ip) => new TokenCredential() {
				Auth = code,
				Token = id_token,
				OriginUrl = AuthRedirectMethodModel.MapRedirectEndpoint(ip, Url, Request)
			});
        }


		private ActionResult IdentityProviderRegisterGeneric(string providerId, Func<IIdentityProvider, Credential> createCredential)
		{
            try
            {
                var ip = SecurityFactory.IdentityProviderList.First(i => i.Id == providerId);
				var credential = createCredential(ip);

                if (ip.RegisterExternalId(credential, UserContext.Current.User))
                {
                    SuccessMessage(Resources.Resources.CONTA_FOI_CRIADA_COM31537);
                    return RedirectToVuePage("Profile");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            ErrorMessage(Resources.Resources.ENTRADA_INCORRETA__T45717);
			return RedirectToVuePage(""); //TODO: When user authentication error then return again to Logon page
        }


		[HttpGet]
		[ActionName("OpenIdConnectRegister")]
		public ActionResult OpenIdConnectRegister_Get([FromRoute] string providerId, [FromQuery] string code, [FromQuery] string id_token, [FromQuery] string state)
		{
			return IdentityProviderRegisterGeneric(providerId, (ip) => new TokenCredential()
			{
				Auth = code,
				Token = id_token,
				OriginUrl = AuthRedirectMethodModel.MapRedirectEndpoint(ip, Url, Request, "Register")
			});
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult OpenIdConnectRegister([FromRoute] string providerId, [FromForm] string code, [FromForm] string id_token, [FromForm] string state)
        {
			//reflects the request back to the server through a browser initiated Get
			//this is necessary because an external request will not bring the authentication cookies of the person registering because its considered cross-site
			//However if we do the registration part in a subsequent request then the cookies are sent and we can use them to get the user state.
			//This has the advantage of not needing any internal state being sent and maintained by the external provider.
			string endpoint = Url.Action("OpenIdConnectRegister", "Account", new { providerId, code, id_token, state });
			return ClientSideRedirect(endpoint);
        }




        /// <summary>
        /// After user have authenticated on Governement CMD identity provider will callback to our application to that funcion.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CMDLogin([FromRoute] string providerId)
        {
            //Government CMD sends the results in the Url hash (instead of the standard that sends them in the url query)
            //The server will not receive them in this method call, so we need to render a html page that captures them in javascript and sends them back as url query
            string endpoint = Url.Action("CMDLoginParams", "Account", new { providerId });
			return ClientSideRedirect(endpoint, captureHash: true);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult CMDLoginParams([FromRoute] string providerId, string access_token, string token_type, string expires_in)
        {
            return IdentityProviderLoginGeneric(providerId, (ip) => new TokenCredential()
            {
                Token = access_token,
            });
        }

        [HttpGet]
        public ActionResult CMDRegisterParams([FromRoute] string providerId, string access_token, string token_type, string expires_in)
        {
            return IdentityProviderRegisterGeneric(providerId, (ip) => new TokenCredential()
            {
                Token = access_token
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult CMDRegister([FromRoute] string providerId)
        {
            //reflects the request back to the server through a browser initiated Get
            //this is necessary because an external request will not bring the authentication cookies of the person registering because its considered cross-site
            //However if we do the registration part in a subsequent request then the cookies are sent and we can use them to get the user state.
            //This has the advantage of not needing any internal state being sent and maintained by the external provider.
            string endpoint = Url.Action("CMDRegisterParams", "Account", new { providerId });
            return ClientSideRedirect(endpoint, captureHash: true);
        }


        [HttpGet]
		[AllowAnonymous]
		public ActionResult CASLogin([FromRoute] string providerId, string ticket)
		{
			return IdentityProviderLoginGeneric(providerId, (ip) => new TokenCredential()
			{
                Token = ticket,
                OriginUrl = AuthRedirectMethodModel.MapRedirectEndpoint(ip, Url, Request)
            });
		}

		private ActionResult finalizeAuthentication(User user, string returnUrl, bool Val2FA)
		{
			if (user != null)
			{
				UserContext.Current.User = user;

				//UserContext.Current.SetFormsAuthenticationCookie();
				var claimsIdentity = new ClaimsIdentity(new List<Claim>
				{
					new(ClaimTypes.Name, user.Name)
				}, LegacyFormsAuthenticationOptions.DefaultScheme);

				var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
				HttpContext.SignInAsync(claimsPrincipal).Wait();

				// log login (audit)
				CSGenio.framework.Audit.registLoginOut(user, Resources.Resources.ENTRADA31905, Resources.Resources.ENTRADA_ATRAVES_DA_P48446, HttpContext.GetHostName(), HttpContext.GetIpAddress());
				GlobalAppSessions.Instance.AddOrUpdate(HttpContext.Session.Id, user.Name, HttpContext.GetHostName());

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
			{
				"75f89df6-5f63-4719-b81a-43a2c304c7c2", new List<string> { "Defaultpsw", "Regis" }
			},
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
			switch (Form)
			{
				case "Regis": //Setup Form
					{
						if (!Navigation.CurrentLevel.CheckEntry("regis") || model.FormData == null)
							model.FormData = Regis_New(true);

						model.partialView = "Regis_Support";
						model.partialViewJS = "REGIS";
						model.redirect = "Regis_Register";
						model.DivID = "Regis_well";
						model.FormDataOrdem = GetRegistrationFormOrder(Form, registrationID);
						break;
					}
				case "Defaultpsw": //Psw form
					{
						if (model.FormPswData == null)
							model.FormPswData = new ViewModels.Psw.Defaultpsw_ViewModel(UserContext.Current);

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
			return JsonOK();
		}

		public ViewModels.Regis.Regis_ViewModel Regis_New(bool isNewInitialization = false)
		{
			ViewModels.Regis.Regis_ViewModel model = new ViewModels.Regis.Regis_ViewModel(UserContext.Current, true);
			var qs = Request.QueryNameValues();

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				if (isNewInitialization)
				{
					CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

					sp.openTransaction();

					var Model = new Models.Regis(UserContext.Current);
					Model.klass.UserRecord = false;
					Model.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level);
					//this line is commented because we don´t want to create a new records everytime a user enter on user registration page (this is a  public page)
					//Model.New("Regis");

					Navigation.SetValue("regis", Model.ValCodregis);
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

				model.LoadPartial(Request.QueryNameValues());
				model.MapFromModel();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				ModelState.AddModelError("Erro", exceptionUserMessage);

				CSGenio.framework.Log.Error("Regis_New - GET " + e.Message);

				ErrorMessage(exceptionUserMessage);
			}

			return model;
		}


		public class Regis_RegisterRequestModel
		{
			public ViewModels.Regis.Regis_ViewModel FormData { get; set; }
			public ViewModels.Psw.Defaultpsw_ViewModel FormPswData { get; set; }
			public VueCaptchaModel CaptchaData { get; set; }
		}

		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Regis_Register([FromBody]Regis_RegisterRequestModel requestModel)
		{
			const string registrationId = "75f89df6-5f63-4719-b81a-43a2c304c7c2";

			var FormData = requestModel.FormData;
			var FormPswData = requestModel.FormPswData;
			var CaptchaData = requestModel.CaptchaData;

			// execute the captcha validation
			bool isValidCaptcha = QCaptcha.Validate(CaptchaData.UserEnteredCaptchaCode, CaptchaData.CaptchaId, HttpContext.Session);
			QCaptcha.SetCaptcha(CaptchaData.CaptchaId, null, HttpContext.Session);
			if (!isValidCaptcha)
			{
				ModelState.AddModelError("registerCaptchaUserInput", Resources.Resources.INVALID_CAPTCHA29660);
				return JsonERROR(Resources.Resources.INVALID_CAPTCHA29660);
			}

			FormData.Init(UserContext.Current);
			FormPswData.Init(UserContext.Current);

			// TODO: if (!Config.RegisterUsers) return "ERROR UNAUTHORIZED";
			ViewModels.RegisterViewModel returnModel = new ViewModels.RegisterViewModel();

			if (!ModelState.IsValid)
			{
				returnModel.FormData = FormData;
				RegistrationConfig(returnModel,"Regis", registrationId);
				var formDataModel = returnModel.FormData as ViewModels.Regis.Regis_ViewModel;
				formDataModel.LoadPartial(Request.QueryNameValues());
				formDataModel.MapFromModel();

				returnModel.FormPswData = FormPswData;
				RegistrationConfig(returnModel, "Defaultpsw", registrationId);

				return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848, new { model = returnModel });
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

				Psw pswModel = new Psw(UserContext.Current);
				FormPswData.MapToModel(pswModel);
				var userRecord = pswModel.klass;
				user = userRecord;
				user.User.Public = true;

// USE /[MANUAL GQT USER_CREATION_CONTROLLER]/

				//Insert new user data into database
				user.UserRecord = false;
				user.User.Name = UserName;
				user.fillStampInsert();

				try
				{
					UserContext.Current.User.AddModuleRole("STY", CSGenio.framework.Role.ADMINISTRATION);
					factory.FillPsw(userPsw: user,
						userName: UserName,
						email: Email,
						phone: string.Empty,
						status: 2, //Account starts disabled
						password: password);

					user.insert(sp);
				}
				catch (BusinessException ex)
				{
					ModelState.AddModelError("Erro", ex.UserMessage);
					return JsonERROR(ex.UserMessage);
				}
				finally
				{
					//Ensure that whe remove the remove in case of sucess and error
					UserContext.Current.User.RemoveModuleRole("STY", CSGenio.framework.Role.ADMINISTRATION);
				}

				factory.CreateUser_REGIS(user);

				//Set foreign key to primary key of record in user table (USERLOGIN / PSW)
				//Change by [TMV] (16.03.2021) -> Returns the CSGenio to be able to create eph with formula fields
				CSGenioAregis area = Regis_New_Registration(FormData);

				if (area is null)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					returnModel.FormData = FormData;
					RegistrationConfig(returnModel,"Regis", registrationId);

					var formDataModel = returnModel.FormData as ViewModels.Regis.Regis_ViewModel;
					formDataModel.LoadPartial(Request.QueryNameValues());
					formDataModel.MapFromModel();

					returnModel.FormPswData = FormPswData;
					RegistrationConfig(returnModel,"Defaultpsw", registrationId);

					return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848, new { model = returnModel });
				}


				string lang = "";
				try
				{
					//TODO: this should be obtained directly from user that already has its language filled by Usercontext
					lang = RouteData.Values["culture"]?.ToString() ?? "";
				}
				catch {/*In case language is not defined*/ }

				UserFactory.MailSender(user, Url.Action("ConfirmEmail", "Account", new { ticket = "fldTicket" }, Request.Scheme), lang);

				sp.closeTransaction();

				return JsonOK(new { Success = true, Message = Resources.Resources.REGISTO_CRIADO_COM_S18746 });
			}
			catch (BusinessException e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				if(e.ErrorStack != null)
				{
					foreach(var error in e.ErrorStack)
					{
						ModelState.AddModelError("Erro", error);
						Log.Error(error);
					}
				}
			}
			catch (FrameworkException e)
			{
				sp.rollbackTransaction();
				ModelState.AddModelError("Erro", e.UserMessage);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				Log.Error(e.Message);
			}

			returnModel.FormData = FormData;
			RegistrationConfig(returnModel,"Regis", registrationId);
			var tempFormDataModel = returnModel.FormData as ViewModels.Regis.Regis_ViewModel;
			tempFormDataModel.LoadPartial(Request.QueryNameValues());
			tempFormDataModel.MapFromModel();

			returnModel.FormPswData = FormPswData;
			RegistrationConfig(returnModel,"Defaultpsw", registrationId);

			return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848, new { Form = "Form_Regis", model = returnModel });
		}

		private CSGenioAregis Regis_New_Registration(ViewModels.Regis.Regis_ViewModel model)
		{
			ValidateModel(model);
			if (!ModelState.IsValid)
				return null;

			User u = UserContext.Current.User;
			u.AddModuleRole("STY", CSGenio.framework.Role.ADMINISTRATION);
			try
			{
				//TMV adds the module to be able to check the permisions
				u.CurrentModule = "STY";
				var Model = new Models.Regis(UserContext.Current)
				{
					ValZzstate = 0,
				};
				model.MapToModel(Model);

				PersistentSupport sp = UserContext.Current.PersistentSupport;

				Model.klass.removeCalculatedFields();
				Model.klass.insert(sp);

				u.RemoveModuleRole("STY", CSGenio.framework.Role.ADMINISTRATION);
				u.CurrentModule = null;

				// MH - Visualizar os warnings obtidos durante gravação. (ex: Condição de escrita que não impede gravação)
				if (model.flashMessage != null && (model.flashMessage.Status == Status.W || model.flashMessage.Status == Status.OK_MAIS_W))
					GetFlashMessage(model.flashMessage, Navigation.CurrentLevel.FormMode);

				return Model.klass;
			}
			catch
			{
				u.RemoveModuleRole("STY", CSGenio.framework.Role.ADMINISTRATION);
				u.CurrentModule = null;
				throw;
			}
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

			try
			{
				var principal = SecurityFactory.Authenticate(new UserPassCredential() { Username = model.UserName, Password = model.Password, Year = year });
				if (principal == null)
				{
					CSGenio.framework.Audit.registLoginOut(UserContext.Current.User,
						model.UserName,
						Resources.Resources.TENTATIVA38682,
						Resources.Resources.LOGIN_OU_PASSWORD_IN32183,
						HttpContext.GetHostName(),
						HttpContext.GetIpAddress());

					throw new BusinessException(Resources.Resources.LOGIN_OU_PASSWORD_IN32183, "InterfaceXml.pedidoEXW()", Resources.Resources.LOGIN_OU_PASSWORD_IN32183);
				}

				user = UserFactory.FillUser(principal, user);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				user = null;
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
