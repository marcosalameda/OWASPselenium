using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using CSGenio.framework;
using CSGenio.persistence;
using GenioServer.security;
using CSGenio.business;
using Quidgest.Persistence.GenericQuery;
using System.Globalization;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;

namespace GenioMVC.Controllers
{
	public class HomeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LSTUSR_EDIT = new NavigationLocation("LISTA_DE_UTILIZADORE37232", "ChangeListProperties", "Home");
		private static readonly NavigationLocation ACTION_PEOPLE_SHOW = new NavigationLocation("CONSULTA40695", "People_Show", "Home")  { vueRouteName = "form-PEOPLE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PEOPLE_EDIT = new NavigationLocation("EDITAR11616", "People_Edit", "Home")  { vueRouteName = "form-PEOPLE", mode = "EDIT" };

		#endregion

		public readonly string EPH_Action_Available_Key = "EPH_Action_Available";
		public readonly string EPH_Action_Form_Key = "EPH_Action_Form";

// USE /[MANUAL GQT HOME_CONTROLLER_INDEX]/
		public ActionResult Index()
		{
			Navigation.ClearHistoryLevels();

			ViewBag.Message = "Welcome to the Quidgest's ASP.NET MVC platform!";
			var model = new Home_ViewModel();

			var isGuestUser = UserContext.Current.User.IsGuest();

			// Load the ViewModel of the Home Page
			model.HomePage_model = new ViewModels.Home.HomePage_ViewModel(Navigation, isGuestUser);
			model.HomePage_model.Load();

			if (!isGuestUser)
			{
				if (UserContext.Current.User.NeedsToChangePassword())
					return RedirectToAction("Profile", "Home");
				if (UserContext.Current.User.NeedsToSetup2FA())
					return RedirectToAction("Change2FA", "Home");
				if (!UserContext.Current.User.EphOk)
					return RedirectToAction("GetEphFormAction", "Home");
				return View("IndexAuthenticated", model);
			}
			return View(model);
		}

		[RequireHttp]
		public ActionResult HttpRedirectIndex()
		{
			return RedirectToAction("Index", "Home", new { nav = Navigation.NavigationId });
		}

		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Bookmarks()
		{
			if (UserContext.Current.User.IsGuest() || UserContext.Current.User.Public)
				return new EmptyResult();

			var cacheKey = string.Format("bookmarks.{0}.{1}", UserContext.Current.User.Name, UserContext.Current.User.Codpsw);
			var model = QCache.Instance.User.Get(cacheKey) as ViewModels.Bookmarks.Bookmarks_ViewModel;
			if (model == null)
			{
				model = new ViewModels.Bookmarks.Bookmarks_ViewModel();
				model.LoadMenus(UserContext.Current);
				QCache.Instance.User.Put(cacheKey, model, TimeSpan.FromMinutes(15));
			}

			return PartialView("_Bookmarks", model);
		}

		[HttpPost]
		[AuthorizeForUsers]
		public JsonResult AddBookmark(string module, string menuId)
		{
			var sp = UserContext.Current.PersistentSupport;
			var user = UserContext.Current.User;
			try
			{
				var sqlCheck = new SelectQuery() { noLock = true }
					.Select(SqlFunctions.Count("1"), "count")
					.From(CSGenio.business.Area.AreaUSRCFG)
					.Where(CriteriaSet.And()
						.Equal(CSGenioAusrcfg.FldTipo, "FV")
						.Equal(CSGenioAusrcfg.FldCodpsw, user.Codpsw)
						.Equal(CSGenioAusrcfg.FldModulo, module)
						.Equal(CSGenioAusrcfg.FldId, menuId));

				var values = sp.executeReaderOneColumn(sqlCheck);
				int count = (int)values[0];

				if (count != 0)
					return Json(new { Success = true });

				sp.openTransaction();

				var fav = new CSGenio.business.CSGenioAusrcfg(user, module) {
					ValTipo = "FV",
					ValModulo = module,
					ValId = menuId,
					ValCodpsw = user.Codpsw
				};

				fav.insert(sp);

				var cacheKey = string.Format("bookmarks.{0}.{1}", UserContext.Current.User.Name, UserContext.Current.User.Codpsw);
				QCache.Instance.User.Invalidate(cacheKey);

				sp.closeTransaction();
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				Log.Error("Error on AddBookmark. Message: " + e.Message ?? string.Empty);
				return Json(new { Success = false, Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}

			try
			{
				var model = new ViewModels.Bookmarks.Bookmarks_ViewModel();
				model.LoadMenus(UserContext.Current);

				var cacheKey = string.Format("bookmarks.{0}.{1}", UserContext.Current.User.Name, UserContext.Current.User.Codpsw);
				QCache.Instance.User.Put(cacheKey, model, TimeSpan.FromMinutes(15));

				var newView = RenderPartialViewToString(this, "_Bookmarks", model);
				return new JsonResult()
				{
					Data = new { Success = true, View = newView },
					MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
				};
			}
			catch
			{
				return Json(new { Success = false, Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}
		}

		[HttpPost]
		[AuthorizeForUsers]
		public JsonResult RemoveBookmark(string bookmarkId)
		{
			var sp = UserContext.Current.PersistentSupport;
			var user = UserContext.Current.User;
			try
			{
				sp.openTransaction();

				var fav = CSGenio.business.CSGenioAusrcfg.search(sp, bookmarkId, user);

				fav.delete(sp);

				var cacheKey = string.Format("bookmarks.{0}.{1}", UserContext.Current.User.Name, UserContext.Current.User.Codpsw);
				QCache.Instance.User.Invalidate(cacheKey);

				sp.closeTransaction();
				return Json(new { Success = true, fav_id = fav.ValCodusrcfg });
			}
			catch(Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				Log.Error("Error on RemoveBookmark. Message: " + e.Message ?? string.Empty);
				return Json(new { Success = false, Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}
		}


		#region Form Methods -> People ()

		// GET: /Home/People_Show
		[AuthorizeForUsers]
		public ActionResult People_Show()
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new People_ViewModel(Navigation, nestedForm);
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			ViewBag.isHomePage = isHomePage;
			if (isHomePage)
				Navigation.SetValue("HomePage", "People");
			if (permission.Status.Equals(CSGenio.framework.Status.E))
			{
				if (!Request.IsAjaxRequest() && !isHomePage)
					return View("_PermissionError", model: permission.Message);
				else
					return PartialView("_PermissionError", model: permission.Message);
			}

			if (!isHomePage && IsNewLocation(ACTION_PEOPLE_SHOW))
				Navigation.AddHistoryLevel(ACTION_PEOPLE_SHOW.SetRoutedValues(new { m = Request.QueryString["m"] }), FormMode.Show, nestedForm);
			// Audit
			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + ACTION_PEOPLE_SHOW.ShortDescription());

// USE /[MANUAL GQT BEFORE_LOAD_SHOW PEOPLE]/

			model.Load(qs);

// USE /[MANUAL GQT AFTER_LOAD_SHOW PEOPLE]/

			if (!Request.IsAjaxRequest() && !isHomePage)
				return View("People", model);
			else
				return PartialView("People", model);
		}

		// GET: /Home/People_Edit
		[AuthorizeForUsers]
		public ActionResult People_Edit()
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new People_ViewModel(Navigation, nestedForm);
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			ViewBag.isHomePage = isHomePage;
			if (isHomePage)
				Navigation.SetValue("HomePage", "People");

			if (!isHomePage && IsNewLocation(ACTION_PEOPLE_EDIT))
				Navigation.AddHistoryLevel(ACTION_PEOPLE_EDIT.SetRoutedValues(new { m = Request.QueryString["m"] }), FormMode.Show, nestedForm);
			// Audit
			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + ACTION_PEOPLE_EDIT.ShortDescription());

// USE /[MANUAL GQT BEFORE_LOAD_EDIT PEOPLE]/

			model.Load(qs);

// USE /[MANUAL GQT AFTER_LOAD_EDIT PEOPLE]/

			return JsonOK(model);
		}

		//
		// GET: /Home/People_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PEOPLE]/
		[AuthorizeForUsers]
		public ActionResult People_Cancel()
		{
			return JsonOK(new { Success = true });
		}

		//
		// GET: /Home/People_ValPeoplels
		// POST: /Home/People_ValPeoplels
		[AuthorizeForUsers]
		[ActionName("People_ValPeoplels")]
		public ActionResult People_ValPeoplels()
		{
			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored

			People_ValPeoplels_ViewModel model = new People_ValPeoplels_ViewModel(Navigation);


			model.Load(2, requestValues, Request.IsAjaxRequest());

			return PartialView("People_ValPeoplels", model);
		}

		#endregion

		private void recreateUser()
		{
			QCache.Instance.User.Invalidate("user." + UserContext.Current.User.Name);
			UserContext.Current.User = null;
		}

		// GET: /Home/Profile
		[AuthorizeForUsers]
		new public ActionResult Profile()
		{
			var sp = UserContext.Current.PersistentSupport;
			var user = UserContext.Current.User;

			var profile = new ProfileModel();
			profile.Load(user.Codpsw);
			profile.Enable2FAOptions = Configuration.Security.Activate2FA != Auth2FAModes.None;

			try
			{
				sp.openConnection();
				var userValues = CSGenioApsw.search(sp, user.Codpsw, user, new string[] { CSGenioApsw.FldCodpsw.Field, CSGenioApsw.FldNome.Field });

				profile.ValCodpsw = userValues.ValCodpsw;
				profile.ValNome = userValues.ValNome;
			}
			catch
			{
				ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
			}
			finally
			{
				sp.closeConnection();
			}

			var status = user.Status;
			if (status == 1)
				ModelState.AddModelError(Resources.Resources.PALAVRA_CHAVE_EXPIRA05120, Resources.Resources.PALAVRA_CHAVE_EXPIRA05120);

			// check if configuracoes.xml have OpenID Connect configured
			OpenIdConnectIdentityProvider oIdIP = new OpenIdConnectIdentityProvider();
			if (oIdIP.Options != null)
				profile.OpenIdConnAuthMethods.Add(oIdIP.Options.Description);

			return View(profile);
		}

		//
		// POST: /Home/Profile/5
		[AuthorizeForUsers]
		[HttpPost]
		new public ActionResult Profile(ProfileModel model)
		{
			bool success = false;
			string error = string.Empty;

			var user = UserContext.Current.User;
			var sp = UserContext.Current.PersistentSupport;

			if (user.Codpsw != model.ValCodpsw)
				error = Resources.Resources.NAO_PODE_ALTERAR_A_P42871;
			else
			{
				try
				{
					sp.openConnection();
					var userOldValues = CSGenioApsw.search(sp, user.Codpsw, user, new string[] { CSGenioApsw.FldPassword.Field, CSGenioApsw.FldSalt.Field, CSGenioApsw.FldPswtype.Field });
					var factory = new UserFactory(sp, user);
					factory.ChangePassword(userOldValues, model.NewPassword, model.ConfirmPassword, model.OldPassword);
				}
				catch(InvalidPasswordException ipe)
				{
					error = ipe.Message;
				}
				catch
				{
					error = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				}
				finally
				{
					sp.closeConnection();
				}
			}

			if (error != string.Empty)
				ModelState.AddModelError(error, error);
			else
			{
				try
				{
					sp.openTransaction();
					model.Save();
					sp.closeTransaction();

					SuccessMessage(Resources.Resources.A_SUA_PASSWORD_FOI_A50177);
					success = true;

					//recriar user logado, caso contrário
					if (GlobalFunctions.emptyN(UserContext.Current.User.Status) == 0 && UserContext.Current.User.Status == 1)
						recreateUser();
				}
				catch (Exception e)
				{
					sp.rollbackTransaction();

					if (e is GenioException && (e as GenioException).UserMessage != null)
						ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
					else
						ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
					return View(model);
				}
			}

			model.OldPassword = "";
			model.NewPassword = "";
			model.ConfirmPassword = "";

			if (success)
				// redirecting to GET method
				return RedirectToAction("Index", new { nav = Navigation.NavigationId });
			else
				return View(model);
		}

		[AuthorizeForUsers]
		public ActionResult Change2FA()
		{
			var model = new TwoFAViewModel();

			var userPsw = Models.Psw.Find(UserContext.Current.User.Codpsw);
			model.HasTotp = userPsw.ValPsw2fatp == Auth2FAModes.TOTP.ToString() ? 1 : 0;
			model.HasWebAuthN = userPsw.ValPsw2fatp == Auth2FAModes.WebAuth.ToString() ? 1 : 0;
			model.ShowTotp = false;

			//give to user a message if is mandatory to create 2FA
			if (Configuration.Security.Mandatory2FA && !UserContext.Current.User.Auth2FA)
				ModelState.AddModelError("Erro", Resources.Resources.A_2ND_AUTHENTICATION36972);

			return View("2FAChange", model);
		}

		[HttpPost]
		[AuthorizeForUsers]
		public ActionResult Change2FA(TwoFAViewModel model)
		{
			if (model.HasTotp == 1)
			{
				var secret = UserContext.Current.User.Code;
				//Only save if the user has correctly inserted the 6 code, otherwise they may be locked out of the system
				if (new TOTPIdentityProvider().IsOk(secret, model.Totp6Code))
				{
					var sp = UserContext.Current.PersistentSupport;
                    try
					{
                        sp.openConnection();
                        var userPsw = Models.Psw.Find(UserContext.Current.User.Codpsw);
                        userPsw.ValPsw2fatp = Auth2FAModes.TOTP.ToString();
                        userPsw.ValPsw2favl = secret;
                        userPsw.Save(sp);
                        sp.closeConnection();
                    }
					catch(Exception ex)
					{
                        sp.closeConnection();
                        Log.Error(ex.Message);

                        ModelState.AddModelError("user", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
                        CreateTOTPModel(ref model, secret);
						return View("2FAChange", model);
                    }
					recreateUser();
				}
				else
				{
					ModelState.AddModelError(Resources.Resources.THE_CODE_YOU_ENTERED21835, Resources.Resources.THE_CODE_YOU_ENTERED21835);
					CreateTOTPModel(ref model, secret);
					return View("2FAChange", model);
				}
			}
			return RedirectToAction("Index");
		}

		private string getUrlQrCodeTOTP (string secret)
		{
			return TOTPIdentityProvider.GetUrlQrCode(UserContext.Current.User.Name, secret);
		}

		private void CreateTOTPModel(ref TwoFAViewModel model, string secret)
		{
			model.HasTotp = 1;
			model.HasWebAuthN = 0;
			model.ShowTotp = true;

			var qrUrl = getUrlQrCodeTOTP(secret);
			var codeToReturn = qrUrl.Substring(qrUrl.IndexOf("secret=") + 7, qrUrl.IndexOf("&", qrUrl.IndexOf("secret=") + 7) - (qrUrl.IndexOf("secret=") + 7));
			model.TotpUrl = qrUrl;
			model.TotpDisplayCode = codeToReturn;
		}

		[AuthorizeForUsers]
		public ActionResult CreateTOTP ()
		{
			var model = new TwoFAViewModel();

			//Creation 2FA based on TOTP
			string secret = PasswordFactory.StringRandom(20, true);

			//save the 2FA secret
			UserContext.Current.User.Code = secret;

			CreateTOTPModel(ref model, secret);

			return View("2FAChange", model);
		}

		[AuthorizeForUsers]
		public ActionResult CreateWebAuthN()
		{
			var model = new TwoFAViewModel();

			model.HasTotp = 0;
			model.HasWebAuthN = 1;
			model.ShowWebAuthN = true;

			return View("2FAChange", model);
		}

		public ActionResult WebAuthn2FAMakeCredentialOptions()
		{
			WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
			{
				MDSAccessKey = ValueProvider.GetValue("fido2:MDSAccessKey")?.AttemptedValue,
				MDSCacheDirPath = ValueProvider.GetValue("fido2:MDSCacheDirPath")?.AttemptedValue,
				TimestampDriftTolerance = ValueProvider.GetValue("fido2:TimestampDriftTolerance")?.AttemptedValue,
				Fido2Options = new WebAuthFido2Options() { Origin = Request.Url.GetLeftPart(UriPartial.Authority) }
			});

			var returnWebAuth = credWebAuth.MakeCredentialOptions(UserContext.Current.User.Name);

			if (returnWebAuth.Success)
			{
				//Temporarily store options, session/in-memory cache/redis/db
				HttpContext.Session["fido2.attestationOptions"] = returnWebAuth.Options;
				return Json(new { Success = true, options = returnWebAuth.Options });
			}
			else
			{
				return Json(new { Success = false, ErrorMessage = returnWebAuth.ErrorMessage });
			}
		}

		public async Task<ActionResult> WebAuthn2FAMakeCredentialOptions2(string data)
		{
			WebAuthIdentityProvider credWebAuth = new WebAuthIdentityProvider(new WebAuthValues()
			{
				MDSAccessKey = ValueProvider.GetValue("fido2:MDSAccessKey")?.AttemptedValue,
				MDSCacheDirPath = ValueProvider.GetValue("fido2:MDSCacheDirPath")?.AttemptedValue,
				TimestampDriftTolerance = ValueProvider.GetValue("fido2:TimestampDriftTolerance")?.AttemptedValue,
				Fido2Options = new WebAuthFido2Options() { Origin = Request.Url.GetLeftPart(UriPartial.Authority) }
			});

			User u = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(u.Year, u.Name);
			var returnWebAuth = await credWebAuth.MakeCredential(data, (string)HttpContext.Session["fido2.attestationOptions"], UserContext.Current.User.Codpsw, sp);

			if (returnWebAuth.Success)
			{
				return Json(new { Success = returnWebAuth.Success, options = returnWebAuth.Options });
			}
			else
			{
				return Json(new { Success = returnWebAuth.Success, ErrorMessage = returnWebAuth.ErrorMessage });
			}
		}

		[HttpPost]
		public ActionResult CreateOpenIdLoginRedirect()
		{
			string urlRedirectAuth = (new OpenIdConnectIdentityProvider()).GetUrlToAuthenticate(
				Url.RouteUrl("OIdRegist", null, Request.Url.Scheme) //Get absolute path with scheme + domain + "/OpenIdRegister" to provider known were to send the callback
			);

			return Json(new
			{
				url = urlRedirectAuth
			}, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult OpenIdRegister(string id_token, string code)
		{
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				//decode JWT received, more information at https://openid.net/specs/openid-connect-core-1_0.html#IDToken
				var token = new JwtSecurityToken(id_token);

				OpenIdConnectIdentityProvider ip = new OpenIdConnectIdentityProvider();
				ip.Options.CallbackPath = Url.RouteUrl("OIdRegist", null, Request.Url.Scheme); //Get absolute path with scheme + domain + "/OIdRegist" to provider known were to send the callback
				TokenCredential qToken = new TokenCredential();
				qToken.Token = token.ToString();

				bool validToken = ip.ValidateToken(qToken, code);

				if (validToken) //When user authenticated successfull we will save user info
				{
					// the token it's composed by two JSON. The first one are header and the second one are payload. Here we will use the payload
					dynamic jsonPayload = JObject.Parse(qToken.Token.Substring(qToken.Token.IndexOf("}.{") + 2));

					string username = jsonPayload.sub.Value + //Subject
									"@" + jsonPayload.iss.Value; //Issuer

					//save data to PSW
					sp.openConnection();
					var userPsw = Models.Psw.Find(UserContext.Current.User.Codpsw);
					userPsw.ValUserid = username;
					userPsw.Save(sp);
					sp.closeConnection();

					SuccessMessage(Resources.Resources.CONTA_FOI_CRIADA_COM31537);
				}
			}
			catch (Exception ex)
			{
				sp.closeConnection();
				ErrorMessage(ex.Message);
			}

			return RedirectToAction("Profile", new { nav = Navigation.NavigationId });
		}

		public ActionResult About()
		{
			Navigation.ClearHistoryLevels();
			return View();
		}

		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult NavigationalBar()
		{
			return PartialView("_NavigationalBar", new Menu_ViewModel(UserContext.Current.User));
		}

		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult NavigationalBarTop()
		{
			return PartialView("_NavigationalBarTop", new Menu_ViewModel(UserContext.Current.User));
		}

		[HttpGet]
		public ActionResult QDebug()
		{
			// We only allow code debugging when event tracing is active.
			if(!Configuration.EventTracking)
				return RedirectToAction("Index", "Home");
			QDebug_ViewModel model = new QDebug_ViewModel(Navigation);
			return PartialView(model);
		}

		/// <summary>
		/// Created by [SF] at [2017.03.23]
		/// Fazer refresh à pagina
		/// </summary>
		/// <returns></returns>
		public ActionResult RefreshDbPDF()
		{
			if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "temp\\loading" + System.Web.HttpContext.Current.Session.SessionID + ".txt"))
			{
				System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "temp\\loading" + System.Web.HttpContext.Current.Session.SessionID + ".txt");
				return new JsonResult() { Data = new { success = true, loading = true } };
			}
			if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "temp\\" + System.Web.HttpContext.Current.Session.SessionID + ".txt"))
			{
				System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "temp\\" + System.Web.HttpContext.Current.Session.SessionID + ".txt");
				return new JsonResult() { Data = new { success = true, loading = false } };
			}
			else
				return new JsonResult() { Data = new { success = false } };
		}

		/// <summary>
		/// Created by [SF] at [2022.08.04]
		/// Remove files creates in method PrepareFileLink
		/// </summary>
		/// <returns></returns>
		public ActionResult RemoveFileTemp()
		{
			if (!string.IsNullOrEmpty(Navigation.GetStrValue("filename")))
			{
				if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "temp\\" + Navigation.GetStrValue("filename")))
				{
					System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "temp\\" + Navigation.GetStrValue("filename"));
					Navigation.ClearValue("filename");
				}
			}
			return new JsonResult() { Data = new { success = true } };
		}

		/// <summary>
		/// Created by [HTA] at [2019.10.01]
		/// Devolve um link para ser usado com a aplicação da consola do Office Add-In. Usa o stream do pedido (request)
		/// </summary>
		/// <returns>O redirecionamneto para o link a ser usado na aplicação ou para a página de origem em caso de erro</returns>
		public ActionResult PrepareFileLink()
		{
			PersistentSupport userSP = UserContext.Current.PersistentSupport;
			string url = ""; // TODO: Update to use the exclusive addin portal
			string area = Request.QueryString["area"].ToLower();
			string areaPrimarykey = Request.QueryString["areakey"];
			string userAgent = Request.UserAgent;
			bool isWindows = false;
			if (userAgent.Contains("Windows"))
				isWindows = true;

			try
			{
				CSGenio.business.Area info = CSGenio.business.Area.createArea(area, UserContext.Current.User, UserContext.Current.User.CurrentModule);
				string tablename = info.TableName;
				string field = "";
				foreach(KeyValuePair<string,Field> fields in info.DBFields)
				{
					if (fields.Key.EndsWith("fk"))
					{
						field = fields.Key;
						break;
					}
				}
				SelectQuery query = new SelectQuery()
					.Select("docums", "document")
					.Select("docums", "docpath")
					.Select("docums", "nome")
					.Select("docums", "coddocums")
					.Select("docums", "datamuda")
					.From(tablename).Join("docums", "docums", TableJoinType.Inner).On(CriteriaSet.And().Equal(tablename, field, "docums", "documid"))
					.Where(CriteriaSet.And()
							.Equal(tablename, info.PrimaryKeyName, areaPrimarykey)
							.Equal(tablename, "zzstate", 0)
							.NotEqual("docums", "versao", "CHECKOUT"))
					.OrderBy("docums", "datacria", SortOrder.Descending)
					.OrderBy("docums", "chave", SortOrder.Ascending).Page(1);
				DataMatrix values = userSP.Execute(query);

				if (values.NumRows > 0)
				{
					Byte[] bytes = new byte[0];
					if (Configuration.Files2Disk)
					{
						System.IO.FileInfo fileinfo = new System.IO.FileInfo(Configuration.PathDocuments + "\\" + values.GetString(0, 1));
						int size = (int)fileinfo.Length;
						bytes = new Byte[size];
						System.IO.FileStream fs = new System.IO.FileStream(Configuration.PathDocuments + "\\" + values.GetString(0, 1), System.IO.FileMode.Open);
						fs.Read(bytes, 0, size);
						fs.Flush();
						fs.Close();
					}
					else
						bytes = values.GetBinary(0, 0);

					string fileName = values.GetString(0, 2);
					string documsPrimaryKey = values.GetString(0, 3);
					string timestamp = values.GetDate(0, 4).ToUniversalTime().ToString("s", System.Globalization.CultureInfo.InvariantCulture);

					string tempFile = AppDomain.CurrentDomain.BaseDirectory + "\\temp\\" + documsPrimaryKey + "-" + fileName;
					using (System.IO.FileStream tempFileStream = System.IO.File.OpenWrite(tempFile))
					{
						tempFileStream.Write(bytes, 0, bytes.Length);
					}
					tempFile = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "\\temp\\" + documsPrimaryKey + "-" + fileName;

					string protocol = "addin:";
					Navigation.SetValue("filename", documsPrimaryKey + "-" + fileName);
					bool openTaskPane = false;
					if (!string.IsNullOrEmpty(Request.QueryString["openPane"]))
						openTaskPane = bool.Parse(Request.QueryString["openPane"]);

					// information format: url | File download url | File name | area name | area primary key | docums primary key | timestamp | open task pane (bool) | platform is Windows (bool)
					string link = protocol + url + "?linkfile=" + tempFile + "&filename=" + fileName + "&area=" + area + "&areakey=" + areaPrimarykey + "&documskey=" + documsPrimaryKey + "&timestamp=" + timestamp + "&taskpane=" + openTaskPane + "&win=" + isWindows;

					return Redirect(link);
				}
				else
				{
					return Redirect(Request.UrlReferrer.AbsoluteUri);
				}
			}
			catch (Exception)
			{
				if (userSP != null)
				{
					userSP.closeConnection();
				}
				return Redirect(Request.UrlReferrer.AbsoluteUri);
			}
		}

		//Create by [TMV] (2020.09.23)
		/// <summary>
		/// Redirects to the eph menu
		/// </summary>
		/// <returns></returns>
		public ActionResult GetEphFormAction()
		{
			User user = UserContext.Current.User;
			string actionName = "";

			string module = user.CurrentModule;

			List<string> possibleAction = (List<string>) Session[module + this.EPH_Action_Available_Key];

			if (possibleAction == null)
			{
				// Contains the name of the action
				possibleAction = new List<string>() { "GetEphFormAction", "DefineEphForm", "DefineEphFormValues" };

				string controllerName = "";

				// Get the action for the form id
				string id = user.EphTofill.GetForm(module);

				GenioMVC.Helpers.Menus.MenuEntry menu;

				// Search all branches possible to navigate
				while (!string.IsNullOrEmpty(id))
				{
					menu = GenioMVC.Helpers.Menus.Menus.FindMenu(module, id);

					if (string.IsNullOrEmpty(menu.Controller))
						break;

					string key = menu.Action_MVC;
					if (!possibleAction.Any(pActionName => string.Equals(pActionName, key, StringComparison.OrdinalIgnoreCase)))
						possibleAction.Add(key);

					controllerName = menu.Controller;
					actionName = menu.Action_MVC;
					id = menu.ParentId;
				}

				// Storage in a session variable
				Session[module + this.EPH_Action_Available_Key] = possibleAction;
				Session[module + this.EPH_Action_Form_Key] = Url.Action(actionName, controllerName);

				return RedirectToAction(actionName, controllerName);
			}

			return Redirect(Session[module + this.EPH_Action_Form_Key].ToString());
		}

		#region Programmers area...




// USE /[MANUAL GQT HOME_CONTROLLER_MANUAL]/

		#endregion
	}
}
