using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Collections.Specialized;

using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;

using CSGenio;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using GenioServer.business;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Controllers
{
	/// <summary>
	/// This is a temporary class to help easy the transition after the removal of AutoMapper
	/// </summary>
	public static class Mapper
	{
		/// <summary>
		/// Maps a ViewModel to a Model or a Model to a ViewModel.
		/// </summary>
		[ObsoleteAttribute("This method is obsolete. Use ViewModel.MapToModel or ViewModel.MapFromModel instead.", false)]
		public static TDestination Map<TSource, TDestination>(TSource source) where TSource : new() where TDestination : new()
		{
			if (source is Models.ModelBase)
			{
				TDestination destination = new TDestination();
				var mi = destination.GetType().GetMethod("MapFromModel", new Type[] { source.GetType() });
				mi.Invoke(destination, new object[] { source });
				return destination;
			}
			else
			{
				var mi = source.GetType().GetMethod("MapToModel");
				TDestination destination = new TDestination();
				mi.Invoke(source, new object[] { destination });
				return destination;
			}
		}
	}

	public class JsonNetResult : JsonResult
	{
        /// <summary>
		/// Reuse Contract Resolver with custom JsonConverters
        /// https://www.newtonsoft.com/json/help/html/Performance.htm
        /// </summary>
        public class ConverterContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            public static readonly ConverterContractResolver Instance = new ConverterContractResolver();

            protected override Newtonsoft.Json.Serialization.JsonContract CreateContract(Type objectType)
            {
                Newtonsoft.Json.Serialization.JsonContract contract = base.CreateContract(objectType);

                // this will only be called once and then cached
                if (objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset))
                {
					contract.Converter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
					{
						DateTimeFormat = "yyyy-MM-ddTHH:mm:ss"
					};
                }
				else if(objectType == typeof(System.Collections.Specialized.NameValueCollection))
				{
                    contract.Converter = new NameValueCollectionSerializer();
                }
				else if(objectType == typeof(System.Web.Mvc.SelectList))
				{
                    contract.Converter = new SelectListSerializer();
                }

                return contract;
            }
        }

		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			var response = context.HttpContext.Response;

			response.ContentType = !String.IsNullOrEmpty(ContentType)
				? ContentType
				: "application/json";

			response.AppendHeader("Content-Encoding", "gzip");

			if (ContentEncoding != null)
				response.ContentEncoding = ContentEncoding;

			var serializeSettings = new Newtonsoft.Json.JsonSerializerSettings()
			{
				ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
				ContractResolver = ConverterContractResolver.Instance
			};

			using (var gzipStream = new GZipStream(response.OutputStream, CompressionMode.Compress))
			using (var writer = new StreamWriter(gzipStream))
			using (var jsonWriter = new Newtonsoft.Json.JsonTextWriter(writer))
			{
				var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(serializeSettings);
				serializer.Serialize(jsonWriter, Data);
				jsonWriter.Flush();
			}
		}
	}

	public class ControllerExtention : Controller
	{
		/// <summary>
		/// Retorno do objeto em Json com uso da serialização do Newtonsoft.
		/// Para um retorno correto dos dados, não podemos utilizar a serialização do MVC 4 (por exemplo, as datas não estarão no formato correto)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private JsonNetResult _jsonResult(object data)
		{
			return new JsonNetResult()
			{
				Data = data,
				MaxJsonLength = int.MaxValue,
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};
		}

		/// <summary>
		/// Retorno do objeto em Json com uso da serialização do Newtonsoft.
		/// Para um retorno correto dos dados, não podemos utilizar a serialização do MVC 4 (por exemplo, as datas não estarão no formato correto)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected JsonResult JsonOK(object data = null)
		{
			return _jsonResult(new { Success = true, Data = data });
		}

		protected JsonResult JsonERROR(string errorMsg = null, object data = null)
		{
			var defaultMsg = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
			return _jsonResult(new { Success = false, Data = data, Message = (errorMsg ?? defaultMsg) });
		}
	}

	/// <summary>
	/// Base class for the controllers
	/// Also used the NoCache attribute to prevent any attempt of caching the results
	/// </summary>
	[NoCache]
	[SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
	public class ControllerBase : ControllerExtention
	{
		/// <summary>
		/// Local access to usercontext to improve compatibility with core version
		/// </summary>
		protected UserContext m_userContext => UserContext.Current;

		/// <summary>
		/// Accessor for the current navigation context
		/// </summary>
		protected NavigationContext Navigation
		{
			get
			{
				return CurrentNavigation.getNavigation(HttpContext.Request, RouteData, Session);
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cwname">Current window name</param>
		/// <returns></returns>
		[ActionName("newWindow")]
		[HttpGet]
		public ActionResult newWindow(string cwname)
		{
			return Json(CurrentNavigation.newWindow(cwname, Request, RouteData, Session), JsonRequestBehavior.AllowGet);
		}

		protected enum QFormType
		{
			Normal,
			PopUp
		}

		// TODO: Criar um ficheiro próprio !?
		protected class EventSink
		{
			public Dictionary<string, object> m_context = new Dictionary<string, object>();

			public Dictionary<string, object> Context { get { return m_context; } }
			public string MethodName { get; set; }
			public string ViewName { get; set; }
			public string FormName { get; set; }
			public string AreaName { get; set; }
			public NavigationLocation Location { get; set; }
			public bool Redirect { get; set; }
			public QFormType FormType { get; set; }
			public Action<EventSink, PersistentSupport> BeforeAll { get; set; }
			public Action<EventSink, PersistentSupport> BeforeOp { get; set; }
			public Action<EventSink, PersistentSupport> AfterOp { get; set; }
			public Action<EventSink, PersistentSupport> BeforeException { get; set; }
			public Action<EventSink, PersistentSupport> AfterException { get; set; }
		}

		private string HandleException(Exception e)
		{
			Log.Error(e.Message);
			//JGF 2020.12.10 Added multi exception check for multiple write condition errors
			if (e is FieldValidationException fvExc)
			{
				foreach (var message in fvExc.StatusMessage.GetErrorList())
				{
					ModelState.AddModelError(message.Origin, message.Message);
				}
				return fvExc.UserMessage;
			}

			string exceptionUserMessage;
			if (e is GenioException gExc && gExc.UserMessage != null)
			{
				exceptionUserMessage = Translations.Get(gExc.UserMessage, UserContext.Current.User.Language);
			}
			else
			{
				exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
			}
			ModelState.AddModelError("Erro", exceptionUserMessage);
			return exceptionUserMessage;
		}

		protected List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp, CSGenio.business.Area area) {
			if (crs == null)
				return new List<string>();

			if (sp == null)
				sp = UserContext.Current.PersistentSupport;

			//Fetch List of Related Areas
			List<string> ids = new List<string>();

			List<string> relatedTables = new List<string>();
			QueryUtils.checkConditionsForForeignTables(crs, area, relatedTables);
			List<CSGenio.framework.Relation> relations = QueryUtils.tablesRelationships(relatedTables, area);
			SelectQuery select = new SelectQuery()
				.Select(area.Alias, area.PrimaryKeyName)
				.From(area.Alias)
				.Where(crs);

			//Insert related area joins in query
			QueryUtils.setFromTabDirect(select, relations, area);

			//Fetch all the IDs
			DataMatrix dm = sp.Execute(select);
			for(int i = 0; i < dm.NumRows; i++)
			{
				ids.Add(dm.GetString(i, 0));
			}

			return ids;
		}

		protected ActionResult GenericHandlePostFormEdit(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;
			var qs = Request.Form;

			/*
			 * If the warnings get ignored once, they stay ignored forever!
			 */
			if (qs["IgnoreWarnings"] == "true")
			{
				Navigation.CurrentLevel.SetEntry("IgnoreWarnings", "true");
			}

			sink.BeforeAll?.Invoke(sink, sp);

			try
			{
				// Remove other levels that not corresponding for this form.
				// For exemple: in case of nestedForms will be created additional history level
				//      and can has more levels after that (support form opened from extended form)
				CheckLevels(sink.Location);
				model.Navigation = Navigation;

				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, sink.MethodName, "Erro");

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_SAVE_EDIT]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Save();

				//Check for Warnings
				bool ignoreWarnings = Convert.ToBoolean(model.Navigation.CurrentLevel.GetEntry("IgnoreWarnings"));
				if (model.flashMessage != null &&
					model.flashMessage.WarningMessages.Count() > 0 &&
					!ignoreWarnings)
				{
					throw new CSGenio.business.FieldValidationException(new StatusMessage(Status.W, "One or more warnings in the form have been triggered"),
						"GenericHandlePostFormEdit");
				}

				//---------------------------------------------
				// USE /[MANUAL AFTER_SAVE_EDIT]/
				sink.AfterOp?.Invoke(sink, sp);
				//---------------------------------------------

				if (Navigation.PreviousLevel != null)
				{
					// New insertion in upper table
					if (Navigation.PreviousLevel.FormMode != FormMode.List)
						Navigation.SetValue("RETURN_" + sink.AreaName, Navigation.GetValue(sink.AreaName), true);
					// Position the list in the current registry
					Navigation.SetValue("QMVC_POS_RECORD_" + sink.AreaName, Navigation.GetValue(sink.AreaName), true);
				}

				sp.closeTransaction();

				Navigation.SetValue("ForcePrimaryRead_"+sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_LOAD_EDIT_EX]/
				sink.BeforeException?.Invoke(sink, sp);
				//---------------------------------------------

				model.LoadPartial(Request.QueryString, true);
				model.MapFromModel();

				//---------------------------------------------
				// USE /[MANUAL AFTER_LOAD_EDIT_EX]/
				sink.AfterException?.Invoke(sink, sp);
				//---------------------------------------------


				HandleException(e);
				model.NestedForm = Request.IsAjaxRequest() && sink.Redirect;

				if(sink.FormType == QFormType.PopUp)
					return PartialView(sink.ViewName, model);
				else
				{
					if (Request.IsAjaxRequest())
					{
						return new JsonResult()
						{
							Data = new { Success = false, Operation = "Edit", View = RenderPartialViewToString(this, sink.ViewName, model), Message = Resources.Resources.ERRO_AO_GUARDAR_O_RE65182 },
							JsonRequestBehavior = JsonRequestBehavior.AllowGet,
							MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
						};
					}

					return View(sink.ViewName, model);
				}
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			if (sink.Redirect || (qs["IgnoreWarnings"] == "true" && sink.FormType == QFormType.PopUp))
				return RedirectToAction(sink.MethodName + "_Redirect", new { internalRedirect = true });
			else
				return Json(new { Success = true, Operation = "Edit", Message = Resources.Resources.ALTERACOES_EFETUADAS10166, currentNavigationLevel = Navigation.CurrentLevel.Level }, JsonRequestBehavior.AllowGet);
		}

		protected ActionResult GenericHandlePostFormApply(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				sink.BeforeAll?.Invoke(sink, sp);

				model.Navigation = Navigation;
				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.ERRO_AO_GUARDAR_O_RE65182, sink.MethodName, "The ModelState is not valid.");

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_APPLY_EDIT]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Apply();

				//---------------------------------------------
				// USE /[MANUAL AFTER_APPLY_EDIT]/
				sink.AfterOp?.Invoke(sink, sp);
				//---------------------------------------------

				sp.closeTransaction();

				if (CSGenio.framework.Log.IsDebugEnabled)
					CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

				if (!Request.IsAjaxRequest())
					GetFlashMessage(model.flashMessage, Navigation.CurrentLevel.FormMode);
			}
			catch (Exception ex)
			{
				sp.rollbackTransaction();

				model.LoadPartial(Request.QueryString);
				model.MapFromModel();

				var exceptionUserMessage = HandleException(ex);

				// Protected this code to avoid throwing another exception while running the RenderPartialViewToString method.
				string partialView;
				try { partialView = RenderPartialViewToString(this, sink.ViewName, model); }
				catch { partialView = ""; }

				return new JsonResult()
				{
					Data = new { Success = false, Operation = "Apply", View = partialView, Message = exceptionUserMessage },
					MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
				};
			}

			if (model.flashMessage != null && !String.IsNullOrEmpty(model.flashMessage.Message) && model.flashMessage.Status == Status.OK)
			{
				TempData["NEW_SAVE_LIST"] = model.flashMessage.Message; // Add the save messages so they can be retrived later
			}
			else
			{
				TempData["NEW_SAVE_LIST"] = ""; //Make sure that no custom message is displayed when the flashMessage is empty
			}

			return Json(new { Success = true, Operation = "Apply", Message = Resources.Resources.ALTERACOES_EFETUADAS10166 }, JsonRequestBehavior.AllowGet);
		}

		protected ActionResult GenericHandlePostFormDelete(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				sink.BeforeAll?.Invoke(sink, sp);
				// Remove other levels that not corresponding for this form.
				// For exemple: in case of nestedForms will be created additional history level
				//      and can has more levels after that (support form opened from extended form)
				CheckLevels(sink.Location);

				model.Navigation = Navigation;

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_DESTROY_DELETE]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Destroy();

				//---------------------------------------------
				// USE /[MANUAL AFTER_DESTROY_DELETE]/
				sink.AfterOp?.Invoke(sink, sp);
				//---------------------------------------------

				sp.closeTransaction();

				if (sink.FormType == QFormType.Normal && !Navigation.CurrentLevel.IsNestedContext)
					GetFlashMessage(model.flashMessage, FormMode.Delete);
				
				//< FOR: tree table select row on return
				Navigation.SetValue("PreviouslyRemovedRowKey_" + sink.AreaName, model.QPrimaryKey, true);
				//>
				Navigation.SetValue("ForcePrimaryRead_"+sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = HandleException(e);

				if (sink.FormType == QFormType.Normal) {
					ClearMessages();
					ErrorMessage(exceptionUserMessage);
				}

				return Json(new { Success = false, Operation = "Delete", Message = exceptionUserMessage }, JsonRequestBehavior.AllowGet);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Delete", Message = Resources.Resources.REGISTO_APAGADO_COM_64671, currentNavigationLevel = Navigation.CurrentLevel.Level }, JsonRequestBehavior.AllowGet);
		}

		protected ActionResult GenericHandlePostFormDuplicate(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				sink.BeforeAll?.Invoke(sink, sp);

				// Remove other levels that not corresponding for this form.
				// For exemple: in case of nestedForms will be created additional history level
				//      and can has more levels after that (support form opened from extended form)
				CheckLevels(sink.Location);
				model.Navigation = Navigation;

				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, sink.MethodName, "Erro");

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_SAVE_DUPLICATE]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Save();

				//---------------------------------------------
				// USE /[MANUAL AFTER_SAVE_DUPLICATE]/
				sink.AfterOp?.Invoke(sink, sp);
				//---------------------------------------------

				sp.closeTransaction();

				if(!Request.IsAjaxRequest())
					GetFlashMessage(model.flashMessage, FormMode.Duplicate);

				if (Navigation.PreviousLevel != null)
				{
					// Position the list in the current registry
					Navigation.SetValue("QMVC_POS_RECORD_"  + sink.AreaName, Navigation.GetValue(sink.AreaName), true);
				}
				Navigation.SetValue("ForcePrimaryRead_"+sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_LOAD_DUPLICATE_EX]/
				sink.BeforeException?.Invoke(sink, sp);
				//---------------------------------------------

				model.LoadPartial(Request.QueryString);
				model.MapFromModel();

				//---------------------------------------------
				// USE /[MANUAL AFTER_LOAD_DUPLICATE_EX]/
				sink.AfterException?.Invoke(sink, sp);
				//---------------------------------------------

				HandleException(e);

				if (sink.FormType == QFormType.PopUp)
					return PartialView(sink.ViewName, model);
				else if (Request.IsAjaxRequest())
				{
					return new JsonResult()
					{
						Data = new { Success = false, Operation = "Duplicate", View = RenderPartialViewToString(this, sink.ViewName, model), Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 },
						MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
					};
				}
				else
					return View(sink.ViewName, model);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			IList<string> warningMsgs = new List<string>();
			// MH - Visualizar os warnings obtidos durante gravação. (ex: Condição de escrita que não impede gravação)
			if (model.flashMessage != null)
			{
				warningMsgs = model.flashMessage.WarningMessages;
				TempData["DUP_WARNINGS_LIST"] = warningMsgs; // Save the warnings list, so it can be retrieved during the redirect.
				if (model.flashMessage.Status == Status.W || model.flashMessage.Status == Status.OK_MAIS_W)
					GetFlashMessage(model.flashMessage, FormMode.Duplicate);
			}

			if (sink.Redirect)
				return RedirectToAction(sink.MethodName + "_Redirect", new { internalRedirect = true });
			else
				return Json(new { Success = true, Operation = "Dup", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746, Warnings = warningMsgs, currentNavigationLevel = Navigation.CurrentLevel.Level }, JsonRequestBehavior.AllowGet);
		}

		protected ActionResult GenericHandlePostFormNew(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;
			var qs = Request.Form;

			/*
			 * If the warnings get ignored once, they stay ignored forever!
			 */
			if (qs["IgnoreWarnings"] == "true")
			{
				Navigation.CurrentLevel.SetEntry("IgnoreWarnings", "true");
			}

			sink.BeforeAll?.Invoke(sink, sp);

			try
			{
				// Remove other levels that not corresponding for this form.
				// For exemple: in case of nestedForms will be created additional history level
				//      and can has more levels after that (support form opened from extended form)
				CheckLevels(sink.Location);
				model.Navigation = Navigation;

				if (sink.FormType == QFormType.PopUp)
				{
					// TODO: Check Navigations <-- ??
					if (Request.IsAjaxRequest() && qs["partialView"] != null) // <- ????????????
						return PartialView(qs["partialView"], model);
				}

				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, sink.MethodName, "Erro");

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_SAVE_NEW]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Save();

				//Check for Warnings
				bool ignoreWarnings = Convert.ToBoolean(model.Navigation.CurrentLevel.GetEntry("IgnoreWarnings"));
				if (model.flashMessage != null &&
					model.flashMessage.WarningMessages.Count() > 0 &&
					!ignoreWarnings)
				{
					throw new CSGenio.business.FieldValidationException(new StatusMessage(Status.W, "One or more warnings in the form have been triggered"),
						"GenericHandlePostFormNew");
				}

				//---------------------------------------------
				// USE /[MANUAL AFTER_SAVE_NEW]/
				sink.AfterOp?.Invoke(sink, sp);
				//---------------------------------------------

				sp.closeTransaction();

				if(!Request.IsAjaxRequest())
					GetFlashMessage(model.flashMessage, FormMode.New);

				if (Navigation.PreviousLevel != null)
				{
					// New insertion in upper table
					if (Navigation.PreviousLevel.FormMode != FormMode.List)
						Navigation.SetValue("RETURN_" + sink.AreaName, Navigation.GetValue(sink.AreaName), true);

					// Position the list in the current registry
					Navigation.SetValue("QMVC_POS_RECORD_"  + sink.AreaName, Navigation.GetValue(sink.AreaName), true);
				}
				Navigation.SetValue("ForcePrimaryRead_"+sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_LOAD_NEW_EX]/
				sink.BeforeException?.Invoke(sink, sp);
				//---------------------------------------------

				model.LoadPartial(Request.QueryString);
				model.MapFromModel();

				//---------------------------------------------
				// USE /[MANUAL AFTER_LOAD_NEW_EX]/
				sink.AfterException?.Invoke(sink, sp);
				//---------------------------------------------

				HandleException(e);
				model.NestedForm = Request.IsAjaxRequest() && sink.Redirect; // TODO: MUDAR!

				if (sink.FormType == QFormType.PopUp)
					return PartialView(sink.ViewName, model);
				else
				{
					if (Request.IsAjaxRequest())
					{
						return new JsonResult()
						{
							Data = new { Success = false, Operation = "New", View = RenderPartialViewToString(this, sink.ViewName, model), Message = Resources.Resources.ERRO_AO_GUARDAR_O_RE65182 },
							MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
						};
					}

					return View(sink.ViewName, model);
				}
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			if (model.flashMessage != null && !String.IsNullOrEmpty(model.flashMessage.Message) && model.flashMessage.Status == Status.OK)
			{
				TempData["NEW_SAVE_LIST"] = model.flashMessage.Message; // Add the save messages so they can be retrived later
			}
			else
			{
				TempData["NEW_SAVE_LIST"] = ""; //Make sure that no custom message is displayed when the flashMessage is empty
			}

			if (sink.Redirect || (qs["IgnoreWarnings"] == "true" && sink.FormType == QFormType.PopUp))
				return RedirectToAction(sink.MethodName + "_Redirect", new { internalRedirect = true });
			else
				return Json(new { Success = true, Operation = "New", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746, currentNavigationLevel = Navigation.CurrentLevel.Level }, JsonRequestBehavior.AllowGet);
		}

		protected JsonResult GenericHandleMultiFormSave(EventSink sink, ICrudViewModel model, string mode)
		{
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				model.Navigation = Navigation;

				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, sink.MethodName, "Erro");

				sp.openTransaction();
				model.Save();
				sp.closeTransaction();
			}
			catch (Exception ex)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				model.LoadPartial(Request.QueryString);
				model.MapFromModel();

				var exceptionUserMessage = Resources.Resources.ERRO_AO_GUARDAR_O_RE65182;
				if (ex is GenioException && (ex as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((ex as GenioException).UserMessage, UserContext.Current.User.Language);

				return new JsonResult()
				{
					Data = new { Success = false, Operation = "MFSave", View = RenderPartialViewToString(this, sink.ViewName, model), Message = exceptionUserMessage },
					MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
				};
			}

			Navigation.RemoveHistoryLevel();

			if (model.flashMessage != null && !String.IsNullOrEmpty(model.flashMessage.Message) && model.flashMessage.Status == Status.OK)
			{
				TempData["NEW_SAVE_LIST"] = model.flashMessage.Message; // Add the save messages so they can be retrived later
			}
			else
			{
				TempData["NEW_SAVE_LIST"] = ""; //Make sure that no custom message is displayed when the flashMessage is empty
			}

			if(mode == "INSERT")
				return Json(new { Success = true, Operation = "MFSave", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746 });
			else
				return Json(new { Success = true, Operation = "MFSave", Message = Resources.Resources.ALTERACOES_EFETUADAS10166 });
		}

		protected JsonResult GenericHandlePostMultiFormDelete(EventSink sink, ICrudViewModel model)
		{
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				// Remove other levels that not corresponding for this form.
				// For exemple: in case of nestedForms will be created additional history level
				//      and can has more levels after that (support form opened from extended form)
				CheckLevels(sink.Location);

				model.Navigation = Navigation;
				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				model.LoadPartial(Request.QueryString);
				model.MapFromModel();

				return new JsonResult()
				{
					Data = new { Success = false, Operation = "MFDelete", View = RenderPartialViewToString(this, sink.ViewName, model), Message = Resources.Resources.ERRO_AO_APAGAR_O_REG38939 },
					MaxJsonLength = int.MaxValue // MH - The data object includes the HTML of the form which can exceed the default length of the JSON string.
				};
			}

			return Json(new { Success = true, Operation = "MFDelete", Message = Resources.Resources.REGISTO_APAGADO_COM_64671 });
		}

		/// <summary>
		/// MH (01/03/2017) - Allow return error view
		/// </summary>
		/// <param name="error">Erro description</param>
		/// <param name="isAjax">Return as JSON ?</param>
		/// <param name="isPartialView">Return as PartialView ?</param>
		/// <returns></returns>
		[ActionName("ReturnErrorView")]
		[HttpGet]
		public ActionResult ReturnErrorView(string error, bool isAjax = false, bool isPartialView = false)
		{
			if (isAjax)
				return Json(new { Success = false, View = RenderPartialViewToString(this, "_PermissionErrorExt", model: error) }, JsonRequestBehavior.AllowGet);
			else if (isPartialView)
				return PartialView("_PermissionErrorExt", model: error);
			else
				return View("_PermissionError", model: error);
		}

		/// <summary>
		/// Check if History List contains any "invalid" levels.
		/// New browser Tabs can insert any levels that not corresponde to current window
		/// </summary>
		/// <param name="location">The current location</param>
		/// <remarks>Location serve to proteger dos casos quando user muda level no url e apaga mais niveis</remarks>
		protected void CheckLevels(NavigationLocation location)
		{
			if (Request == null)
				return;
			if (Request.QueryString == null)
				return;
			if (Request.QueryString.AllKeys == null)
				return;

			if (Request.QueryString.AllKeys.Contains("niv"))
			{
				int currentLevel;
				if (int.TryParse(Request.QueryString["niv"], out currentLevel))
				{
					if (currentLevel < 0)
						return;
					while (Navigation.CurrentLevel.Level > currentLevel)
					{
						if (Navigation.CurrentLevel.Location == NavigationLocation.Any) break;
						if (location.IsSameAction(Navigation.CurrentLevel.Location)) break;
						else Navigation.RemoveHistoryLevel();

					}
				}
			}
		}

		protected ControllerBase() { }

		/// <summary>
		/// Creates Erros message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void ErrorMessage(String content,bool containsHTML=false)
		{
			Message message = new Message(content, CSGenio.framework.Status.E,containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates Success message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void SuccessMessage(String content,bool containsHTML=false)
		{
			Message message = new Message(content, CSGenio.framework.Status.OK,containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates  Warning message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void WarningMessage(String content,bool containsHTML=false)
		{
			Message message = new Message(content, CSGenio.framework.Status.W,containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates Info message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void InfoMessage(String content,bool containsHTML=false)
		{
			Message message = new Message(content, CSGenio.framework.Status.OK_MAIS_W,containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates Generic message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="content">Status of the message</param>
		protected void Message(String content, Status status)
		{
			Message message = new Message(content, status);
			AddMessage(message);
		}

		/// <summary>
		/// Clears any message in TemData
		/// </summary>
		protected void ClearMessages()
		{
			String Id = Messages.getID(Navigation.NavigationId);
			//JFG 11/05/2017 This assumes that the Navigation ID is unique per thread, if not, this needs to be protected by lock
			TempData[Id] = null;
		}

		/// <summary>
		/// Adds Message to TempDate to be shown on next http response
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		private void AddMessage(Message message)
		{
			List<Message> messageList = new List<Message> { message };
			String Id = Messages.getID(Navigation.NavigationId);

			if (TempData[Id] != null)
			{
				messageList = TempData[Id] as List<Message>;
				messageList.Add(message);
			}

			//JFG 11/05/2017 This assumes that the Navigation ID is unique per thread, if not, this needs to be protected by lock
			TempData[Id] = messageList;
		}

		internal void GetFlashMessage(StatusMessage flashMessage, FormMode formMode)
		{
			if (flashMessage != null)
			{
				if (flashMessage.Status.Equals(Status.E) || flashMessage.Status.Equals(Status.EW))
				{
					ErrorMessage(flashMessage.Message);
				}
				else if (flashMessage.Status.Equals(Status.W))
				{
					WarningMessage(flashMessage.Message);
				}
				else if (flashMessage.Status.Equals(Status.OK))
				{
					string msg = string.Empty;
					switch (formMode)
					{
						case FormMode.New:
						case FormMode.Duplicate:
							msg = Resources.Resources.REGISTO_CRIADO_COM_S18746;
							break;
						case FormMode.Edit:
							msg = Resources.Resources.ALTERACOES_EFETUADAS10166;
							break;
						case FormMode.Delete:
							msg = Resources.Resources.REGISTO_APAGADO_COM_64671;
							break;
					}
					if (!String.IsNullOrEmpty(msg))
						SuccessMessage(msg);
				}
				else if (flashMessage.Status.Equals(Status.OK_MAIS_W))
				{
					InfoMessage(flashMessage.Message);
				}
			}
		}

		/// <summary>
		/// Builds a RouteValueDictionary with the current route values and additional params
		/// </summary>
		/// <param name="location">The action to redirect to</param>
		/// <param name="additionalRouteValues">Additional Route data</param>
		/// <returns>The redirect result object</returns>
		protected System.Web.Routing.RouteValueDictionary GetRouteValues(NavigationLocation location, object additionalRouteValues = null)
		{
			var values = new System.Web.Routing.RouteValueDictionary(location.RoutedValues);
			if (!values.ContainsKey("nav"))
				values.Add("nav", Navigation.NavigationId);
			if (additionalRouteValues != null)
			{
				var arv = new System.Web.Routing.RouteValueDictionary(additionalRouteValues);
				foreach (var kv in arv)
				{
					if (!values.ContainsKey(kv.Key))
						values.Add(kv.Key, kv.Value);
				}
			}

			return values;
		}

		/// <summary>
		/// Redirects to the action specified in the location
		/// </summary>
		/// <param name="location">The action to redirect to</param>
		/// <param name="additionalRouteValues">Additional Route data</param>
		/// <returns>The redirect result object</returns>
		protected RedirectToRouteResult RedirectToLocation(NavigationLocation location, object additionalRouteValues = null)
		{
			var values = GetRouteValues(location, additionalRouteValues);
			return RedirectToAction(location.Action, location.Controller, values);
		}

		/// <summary>
		/// Redirects to the location based on the form menu's GoBack value.
		/// </summary>
		/// <param name="FormName">The name of the form to get the redirect action of</param>
		/// <returns>The redirect result object</returns>
		/// <remarks>FOR: FORM MENU GO BACK</remarks>
		protected RedirectToRouteResult RedirectToFormMenuGoBack(string FormName)
		{
			if (Navigation.GoBack.ContainsKey(FormName))
			{
				//Go back the number of history levels specified
				var level = Navigation.History.Count - Navigation.GoBack[FormName];
				Navigation.RemoveHistoryLevel(level);
			}

			return RedirectToLocation(Navigation.CurrentLevel.Location);
		}

		protected bool IsNewLocation(NavigationLocation location)
		{
			VerifyPreviousLocations(location);
			return !location.IsSameAction(Navigation.CurrentLevel.Location);
		}

		/// <summary>
		/// Check if the given location already exists in history,
		/// if so deletes all entries until after the found location.
		/// </summary>
		/// <param name="location">The current location</param>
		protected void VerifyPreviousLocations(NavigationLocation location)
		{
			bool hasSameLocation = false;
			int levelRemove = 0;
			foreach (var hLevel in Navigation.History)
			{
				if(hLevel.Location == NavigationLocation.Any) break;
				if (location.IsSameAction(hLevel.Location))
				{
					hasSameLocation = true;
					levelRemove = hLevel.IsNestedContext ? hLevel.Level : (hLevel.Level + 1); //+1 :> Level alterior
					break;
				}
			}

			if (hasSameLocation)
				Navigation.RemoveHistoryLevel(levelRemove);
		}

		/// <summary>
		/// Created by [ BPM ] at [ 2020.07.30 ]
		/// Last updated by [ BPM ] at [2020.11.05]
		/// </summary>
		/// <param name="baseArea">base area of ​​the form</param>
		/// <param name="primaryKey">primary key of form</param>
		/// <returns>Returns the value of table's human keys</returns>
		public string GetHumanKeyToQMessage(string baseArea, string primaryKey, string delimite = ";")
		{
			var sp = UserContext.Current.PersistentSupport;
			string QMessage = "";

			if (!string.IsNullOrEmpty(primaryKey))
			{
				var area = CSGenio.business.Area.createArea(baseArea.ToLowerInvariant(), UserContext.Current.User, UserContext.Current.User.CurrentModule) as DbArea;

				if (area != null)
				{
					//if for some reason can't get the record it doesn't fail in the application's redirect
					try
					{

						sp.openConnection();
						sp.getRecord(area, primaryKey);
						sp.closeConnection();

						string humanKeyInfo = area.Information.HumanKeyName;

						string[] humanKeyFields = humanKeyInfo.Split(',');

						if(humanKeyInfo != "")
							foreach (var humanKeyField in humanKeyFields)
							{
								QMessage += " ";
								string QDescription = Translations.Get(area.DBFields[humanKeyField].FieldDescription, UserContext.Current.User.Language);
								QMessage += QDescription + ": " + area.returnValueField(baseArea + "." + humanKeyField) + delimite;
							}

						if (QMessage.Contains(delimite))
							QMessage = QMessage.Substring(0, QMessage.Length - 1);
					}
					catch
					{
						//on exception so nothing
					}

				}
			}
			return QMessage;
		}

		private bool CheckMagicSig(byte[] file, byte[] sig)
		{
			for (int bix = 0; bix < sig.Length; bix++)
			{
				if (bix >= file.Length)
					return false;
				if (file[bix] != sig[bix])
					return false;
			}
			return true;
		}

		/// <summary>
		/// Fill the values to the model to open the view
		/// </summary>
		/// <param name="key">Form primary key</param>
		/// <param name="modelname">Base area</param>
		/// <param name="fldname">Image field to be edited</param>
		/// <param name="identifier">Form identifier</param>
		/// <param name="FormName">Form name</param>
		/// <param name="FieldId">Field identifier</param>
		/// <returns>ActionResult</returns>
		public ActionResult ImageCropper(string key, string modelname, string fldname, string identifier, string FormName, string FieldId)
		{
			ImageCropper_ViewModel model = new ImageCropper_ViewModel(key, modelname, fldname, identifier, FormName, FieldId);
			return PartialView(model);
		}

		/// <summary>
		/// Update the image with the cropped canvas
		/// </summary>
		/// <param name="fileData">Image in base 64</param>
		/// <param name="id">Form primary key</param>
		/// <param name="modelname">Base area</param>
		/// <param name="fldname">Image field to be edited</param>
		/// <param name="formIdentifier">Form identifier</param>
		/// <returns>Returns a JSON with the result of the operation (either success or failure)</returns>
		[HttpPost]
		public ActionResult UploadImageCropper(string fileData, string id, string modelname, string fldname, string formIdentifier)
		{
			try
			{
				// Get only the base64 part by removing the first part (image type information)
				string base64File = fileData.Substring(fileData.IndexOf(";base64,") + 8);
				byte[] fileByte = Convert.FromBase64String(base64File);

				// Grabbing the type that has the static generic method
				Type type = Type.GetType("GenioMVC.Models." + modelname);

				object row = null;
				// Grabbing the specific static method
				MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
				row = methodInfo.Invoke(null, new object[] { id, formIdentifier, null, null });

				// Sets the property with the new value
				PropertyInfo prop = type.GetProperty(fldname);
				prop.SetValue(row, fileByte, null);

				// Saves the updated model (ideally only save the specific property)
				MethodInfo saveMethod = type.GetMethod("Apply");

				UserContext.Current.PersistentSupport.openTransaction();
				saveMethod.Invoke(row, null);
				UserContext.Current.PersistentSupport.closeTransaction();

				return Json(new { Success = true, Message = Resources.Resources.ALTERACOES_EFETUADAS10166 }, "application/json");
			}
			catch (Exception ex)
			{
				UserContext.Current.PersistentSupport.rollbackTransaction();
				CSGenio.framework.Log.Error("UploadImageCropper Error: " + ex.Message);
				return Json(new { Success = false, Message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 }, "application/json");
			}
		}

		/// <summary>
		/// Sets the byte[] image from the corresponding model
		/// </summary>
		/// <param name="id">The id of the model being used</param>
		/// <param name="modelname">The name of the model</param>
		/// <param name="fldname">Name of the property being saved</param>
		/// <param name="formIdentifier">Form Identifier</param>
		/// <returns>Returns a JSON with the result of the operation (either success or failure)</returns>
		public ActionResult ImageHandlerPut(string id, string modelname, string fldname, string formIdentifier)
		{
			// Grabbing the type that has the static generic method
			Type type = Type.GetType("GenioMVC.Models." + modelname);

			object row = null;

			CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				// Grabbing the specific static method
				MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
				row = methodInfo.Invoke(null, new object[] { id, formIdentifier, null, null });

				var stream = Request.InputStream;
				if (string.IsNullOrEmpty(Request["qqfile"]))
				{
					// IE
					System.Web.HttpPostedFileBase postedFile = Request.Files[0];
					stream = postedFile.InputStream;
				}

				var buffer = new byte[stream.Length];
				stream.Read(buffer, 0, buffer.Length);

				// Sets the property with the new value
				PropertyInfo prop = type.GetProperty(fldname);
				prop.SetValue(row, buffer, null);

				// Saves the updated model (ideally only save the specific property)
				MethodInfo saveMethod = type.GetMethod("Apply");

				sp.openTransaction();
				saveMethod.Invoke(row, null);
			}
			catch (Exception ex)
			{
				sp.rollbackTransaction();
				CSGenio.framework.Log.Error("ImageHandlerPut Error: " + ex.Message);
				return Json(new { success = false, message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 }, "application/json");
			}
			finally
			{
				sp.closeTransaction();
			}

			// Obtains the Key from the Model
			PropertyInfo[] props = type.GetProperties();
			PropertyInfo keyProp = null;
			foreach (PropertyInfo p in props)
			{
				object[] attribute = p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true);
				if (attribute.Length > 0)
				{
					keyProp = p;
					break;
				}
			}

			if (keyProp != null)
			{
				// Sets the key to be sent back to the View
				var key = keyProp.GetValue(row, null);
				return Json(new { success = true, id = key }, "application/json");
			}
			else
				return Json(new { success = false, message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 }, "application/json");
		}

		/// <summary>
		/// Deletes the image from the given field
		/// </summary>
		/// <param name="id">The id of the model being used</param>
		/// <param name="modelname">The name of the model</param>
		/// <param name="fldname">Name of the property being saved</param>
		/// <returns>Returns a JSON with the result of the operation (either success or failure)</returns>
		public ActionResult ImageDelete(string id, string modelname, string fldname)
		{
			try
			{
				// Grabbing the type that has the static generic method
				Type type = Type.GetType("GenioMVC.Models." + modelname);

				object row = null;

				// Grabbing the specific static method
				MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
				row = methodInfo.Invoke(null, new object[] { id, null, null, null });

				// Sets the property with the null value
				PropertyInfo prop = type.GetProperty(fldname);
				prop.SetValue(row, null, null);

				// Saves the updated model (ideally only save the specific property)
				MethodInfo saveMethod = type.GetMethod("Apply");
				UserContext.Current.PersistentSupport.openConnection();
				saveMethod.Invoke(row, null);
				UserContext.Current.PersistentSupport.closeConnection();

				return Json(new { success = true, message = Resources.Resources.ALTERACOES_EFETUADAS10166 }, "application/json");
			}
			catch (Exception ex)
			{
				UserContext.Current.PersistentSupport.rollbackTransaction();
				CSGenio.framework.Log.Error("ImageDelete Error: " + ex.Message);
				return Json(new { success = false, message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 }, "application/json");
			}
		}

		private ActionResult EmptyImageHandlerGet(ResizeImageSerializer resizer = null)
		{
			try
			{
				string path = Server.MapPath("~/Content/img/unknown.png");
				if (!System.IO.File.Exists(path))
					return new EmptyResult();

				byte[] file = getFile(path);

				if (resizer != null)
				{
					string serializedImage = Newtonsoft.Json.JsonConvert.SerializeObject(file, resizer);
					return JsonOK(Newtonsoft.Json.JsonConvert.DeserializeObject(serializedImage));
				}
				else
					return new FileContentResult(file, "image/png");
			}
			catch (Exception ex)
			{
				Log.Error(string.Format("Error getting empty image file. {0}; {1}", ex.Message, ex.InnerException?.Message ?? ""));
			}

			return new EmptyResult();
		}

		[AuthorizeForUsers]
		[HttpGet]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult GetStaticImage(string ticket)
		{
			try
			{
				if (!string.IsNullOrEmpty(Configuration.PathDocuments) && !string.IsNullOrEmpty(ticket))
				{
					object[] objs = QResources.DecryptTicketBase64(ticket);

					string username = objs[0] as string;
					string ip = objs[1] as string;
					Resource rec = objs[2] as Resource;

					if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress || string.IsNullOrEmpty(rec.Name) || !(rec is ResourceFile))
						return EmptyImageHandlerGet();

					string filePath = Path.Combine(Configuration.PathDocuments, (rec as ResourceFile).FilePath);
					// Absolute Path Check (Path Traversal)
					if (!System.IO.File.Exists(filePath) || !Path.GetFullPath(filePath).StartsWith(Configuration.PathDocuments, StringComparison.OrdinalIgnoreCase))
						return EmptyImageHandlerGet();
					else
						return File(filePath, "image/jpeg");
				}
			}
			catch (Exception ex)
			{
				Log.Error(string.Format("Error getting static image file. {0}; {1}", ex.Message, ex.InnerException?.Message ?? ""));
			}
			return EmptyImageHandlerGet();
		}

		/// <summary>
		/// Obtains the byte[] image from the corresponding model
		/// </summary>
		/// <param name="id">The id of the row</param>
		/// <param name="modelname">The model we are on</param>
		/// <param name="fldname">The name of the property where the image is at</param>
		/// <param name="formIdentifier">Form Identifier</param>
		/// <returns>The image data</returns>
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult ImageHandlerGet(string id, string modelname, string fldname, string formIdentifier)
		{
			try
			{
				// Grabbing the type that has the static generic method
				Type type = Type.GetType("GenioMVC.Models." + modelname);

				// Grabbing the specific static method
				MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });

				object row = methodInfo.Invoke(null, new object[] { id, formIdentifier, null, null });

				PropertyInfo prop = type.GetProperty(fldname);

				// Skipping any validation etc - to read no-photo image [if data is not present] - for simplicity
				byte[] image = row == null ? null : prop.GetValue(row, null) as byte[];

				if (image != null && image.Length != 0)
				{
					byte[] pngSig = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
					byte[] jpgSig = { 0xFF, 0xD8 };
					byte[] gifSig = { 0x47, 0x49, 0x46 };
					if (CheckMagicSig(image, pngSig))
						return new FileContentResult(image, "image/png");
					else if (CheckMagicSig(image, jpgSig))
						return new FileContentResult(image, "image/jpeg");
					else if (CheckMagicSig(image, gifSig))
						return new FileContentResult(image, "image/gif");
					else
					{
						var text = Encoding.UTF8.GetString(image);
						if (text.StartsWith("<?xml ") || text.StartsWith("<svg "))
							return new FileContentResult(image, "image/svg+xml");
						else
							return new FileContentResult(image, "image/jpeg");
					}
				}
				else
					return EmptyImageHandlerGet();
			}
			catch
			{
				return EmptyImageHandlerGet();
			}
		}

		/// <summary>
		/// Calls the server-side method to convert a given string to a QR code representation
		/// </summary>
		/// <param name="text">The string to convert</param>
		/// <returns>A byte array representing the result of the convertion</returns>
		[ActionName("StringToQRcode")]
		[HttpGet]
		public JsonResult StringToQRcode(string text)
		{
			byte[] bytes = GlobalFunctions.StringToQRcode(text);

			if (bytes != null)
				return Json(new { Success = true, Operation = "StringToQRcode", Value = Convert.ToBase64String(bytes) }, JsonRequestBehavior.AllowGet);
			return Json(new { Success = true, Operation = "StringToQRcode", Value = String.Empty }, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Obtains an image from disk
		/// </summary>
		/// <param name="s">The Path</param>
		/// <returns>The image</returns>
		protected byte[] getFile(string s)
		{
			System.IO.FileStream fs = System.IO.File.OpenRead(s);
			byte[] data = new byte[fs.Length];
			int br = fs.Read(data, 0, data.Length);
			if (br != fs.Length)
				throw new System.IO.IOException(s);

			fs.Close();
			fs.Dispose();

			return data;
		}

		protected string ToSentenceCase(string str)
		{
			return System.Text.RegularExpressions.Regex.Replace(str, "[a-z0-9][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
		}

		[Obsolete("Use version with selectedIds as array of strings instead.")]
		protected void MergeNN(NavigationContext current_navigation, string table, string key, string tableNN, string primaryField, string otherField, string selected)
		{
			if (String.IsNullOrEmpty(selected))
				selected = "";
			MergeNN(current_navigation, table, key, tableNN, primaryField, otherField, selected.Split(','));
		}

		/// <summary>
		/// Updates the given tableNN below with the selected values of table B for the given key of table A
		/// </summary>
		/// <param name="current_navigation">History</param>
		/// <param name="table">Table A</param>
		/// <param name="key">The key of a row in table A</param>
		/// <param name="tableNN">The table that makes a N-N relation between A and B</param>
		/// <param name="primaryField">The field name for primaryKey in table A</param>
		/// <param name="otherField">The field name for primaryKey in table B</param>
		/// <param name="selectedIds">The selected keys in table B</param>
		protected void MergeNN(NavigationContext current_navigation, string table, string key, string tableNN, string primaryField, string otherField, string[] selectedIds)
		{
			//if (String.IsNullOrEmpty(selected))
				//selected = "";
			if (selectedIds == null)
				selectedIds = new string[0];

			Type type = Type.GetType("GenioMVC.Models." + tableNN);
			Type csType = Type.GetType("Quidgest.Persistence.GenericQuery.CriteriaSet, Quidgest.Persistence");
			Type fRefType = Type.GetType("Quidgest.Persistence.FieldRef, Quidgest.Persistence");

			// Grabbing the specific static method
			MethodInfo methodInfo = type.GetMethod("AllModel", new Type[] { csType, typeof(String) });

			// Creating the CriteriaSet
			MethodInfo miAnd = csType.GetMethod("And");
			object criteriaSetAnd = miAnd.Invoke(null, new object[] { });

			MethodInfo miEqual = csType.GetMethod("Equal", new Type[] { fRefType, typeof(object) });

			// Preparing to filter the query
			Type areaType = CSGenio.business.Area.GetTypeArea(tableNN.ToLower());
			object fieldRef = ((PropertyInfo)areaType.GetMember("Fld" + StringUtils.CapFirst(primaryField)).GetValue(0)).GetValue(areaType);
			criteriaSetAnd = miEqual.Invoke(criteriaSetAnd, new object[] { fieldRef, key });

			var previous = (IEnumerable)methodInfo.Invoke(null, new object[] { criteriaSetAnd, null });

			// Splits the selected values
			//IEnumerable<string> selectedIds = selected.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			// Updates the table NN by removing the rows that were not selected this time
			HashSet<string> previousSelected = new HashSet<string>();
			foreach (var p in previous)
			{
				object otherKey = p.GetType().GetProperty("Val" + otherField).GetValue(p, null);
				previousSelected.Add((string)otherKey);
				if (!selectedIds.Contains(otherKey))
				{
					// destroy
					p.GetType().GetMethod("Destroy").Invoke(p, new object[] { });
				}
				//else
				//{
					// is the same, do nothing
				//}
			}

			// Updates the table NN by adding the new rows that were selected this time
			MethodInfo newMI = type.GetMethod("New", new Type[] {typeof(string)});
			MethodInfo saveMI = type.GetMethod("Save", new Type[] { });
			foreach (var id in selectedIds)
			{
				if (!previousSelected.Contains(id))
				{
					//object.new
					// create
					Object row = Activator.CreateInstance(type);
					
					//set fields
					row.GetType().GetProperty("Val" + primaryField).SetValue(row, key, null);
					row.GetType().GetProperty("Val" + otherField).SetValue(row, id, null);					

					newMI.Invoke(row, new object[] { null });
					//object.save
					saveMI.Invoke(row, new object[] { });
				}
				//else
				//{
					// is the same, do nothing
				//}
			}
		}

		private string GetIPAddress()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;

			string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (!string.IsNullOrEmpty(ipAddress))
			{
				string[] addresses = ipAddress.Split(',');
				if (addresses.Length != 0)
				{
					return addresses[0];
				}
			}

			return context.Request.ServerVariables["REMOTE_ADDR"];
		}

		public ActionResult LoadFlash(GenioMVC.Models.FlashModel model)
		{
			string control = model.Id;
			User user = UserContext.Current.User;

			int count = model.HistoryKeys == null ? 0 : model.HistoryKeys.Count();
			string[] args = new string[count + 3];
			args[0] = model.Command;
			args[1] = model.Parameter;
			args[2] = model.Type;
			int index = 3;
			if(count > 0)
				foreach (string key in model.HistoryKeys)
				{
					args[index++] = key;
				}

			string[] flashRequestResult = null;
			Dictionary<string, string> result = new Dictionary<string, string>();

			try
			{
				switch (model.ExternalInterface)
				{
					case "ICTRLEXT"://interface for external controls request such as Flash
					{
						ExtControl extControlObj = ExtControl.getExtControlObj(control, args, user);
						flashRequestResult = extControlObj.processRequest() as string[];
						break;
					}
					default:
						flashRequestResult = new string[] { model.Type, "Flash not recognized" };
						result.Add("Status", "EW");
						break;
				}
			}
			catch (Exception e)
			{
				flashRequestResult = new string[] {  model.Type, e.Message };
				result.Add("Status", "EW");
			}

			if(!result.ContainsKey("Status"))
				//no error found
				result.Add("Status", "OK");
			result.Add("Function", flashRequestResult[0]);
			if(flashRequestResult.Count() > 1)
				result.Add("Message", flashRequestResult[1]);
			else
				result.Add("Message", "OK");

			return new JsonResult { ContentEncoding = System.Text.Encoding.UTF8, Data = result };
		}


		#region Docums

		#region Docum Versions Menu

		/// <summary>
		/// Returns a partial view with the docums information as a DBEdit
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <param name="isRequired">Whether or not the field is required</param>
		/// <returns>Docums versions DBEdit for a specific field</returns>
		[NonAction]
		protected ActionResult GetDocumsVersionsDBEdit(string ticket, bool isRequired = false)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress)
					//invalid user
					return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				ViewData["isRequired"] = isRequired;

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;
					Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));
					object model = null;

					MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
					model = methodInfo.Invoke(null, new object[] { recq.KeyValue, null, null, null });

					string docfk = type.GetProperty(recq.KeyData + "fk").GetValue(model, null) as string;

					bool onlyshow = false;
					if(Navigation.CurrentLevel.FormMode == FormMode.Show || Navigation.CurrentLevel.FormMode == FormMode.Delete)
						onlyshow = true;

					GenioMVC.ViewModels.DocumsVersionsDBEdit_ViewModel documsDBedit = new ViewModels.DocumsVersionsDBEdit_ViewModel(ticket, docfk, recq.Table, recq.KeyData, onlyshow);
					documsDBedit.Load(Configuration.NrRegDBedit == 0 ? 10 : Configuration.NrRegDBedit, Request.Form);

					return PartialView("../Shared/Docums/_DocumsVersionsDBEdit", documsDBedit);
				}
				return PartialView("Error");
			}
			catch (Exception)
			{
				return PartialView("Error");
			}
		}

		#endregion

		#region Docum Properties

		/// <summary>
		/// Returns a partial view with document properties
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <returns>Document properties partial view</returns>
		[NonAction]
		protected ActionResult GetFileProperties(string ticket, string identifier = null)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress)
					//invalid user
					return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;
					Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));
					object model = null;

					MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
					model = methodInfo.Invoke(null, new object[] { recq.KeyValue, identifier, null, null });

					MethodInfo getInfoDoc = type.GetMethod("GetInfoDoc");
					GenioMVC.ViewModels.DocumsProperties_ViewModel doc = getInfoDoc.Invoke(model, new object[] { recq.KeyData }) as GenioMVC.ViewModels.DocumsProperties_ViewModel;

					return PartialView("../Shared/Docums/_DocumsProperties", doc);
				}
				return PartialView("Error");
			}
			catch (Exception)
			{
				return PartialView("Error");
			}
		}

		#endregion

		#region Docum Edition

		/// <summary>
		/// Returns a partial view for submitting a document version
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <param name="fieldSize">The size of the field</param>
		/// <param name="dataIdentifier">The control identifier of the field</param>
		/// <param name="isRequired">Whether or not the field is required</param>
		/// <returns>Document version submit menu partial view</returns>
		[NonAction]
		protected ActionResult SubmitVersion(string ticket, string fieldSize = "", string dataIdentifier = "", bool isRequired = false, int? maxFileSize = null, string allowedTypes = null)
		{
			object[] objs = QResources.DecryptTicketBase64(ticket);

			string username = objs[0] as string;
			string ip = objs[1] as string;

			if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress)
				//invalid user
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

			if (!string.IsNullOrEmpty(fieldSize))
				ViewData["fieldSize"] = fieldSize;
			if (!string.IsNullOrEmpty(dataIdentifier))
				ViewData["data_identifier"] = dataIdentifier;
			ViewData["isRequired"] = isRequired;
			if (maxFileSize != null)
				ViewData["maxSize"] = maxFileSize;
			if (!string.IsNullOrEmpty(allowedTypes))
				ViewData["allowedTypes"] = allowedTypes;

			Resource rec = objs[2] as Resource;

			if (rec is ResourceQuery)
			{
				ResourceQuery recq = rec as ResourceQuery;

				Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));
				object model = null;

				MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
				model = methodInfo.Invoke(null, new object[] { recq.KeyValue, null, null, null });

				string docfk = type.GetProperty(recq.KeyData + "fk").GetValue(model, null) as string;

				MethodInfo getInfoDoc = type.GetMethod("GetInfoDoc");
				GenioMVC.ViewModels.DocumsProperties_ViewModel doc = getInfoDoc.Invoke(model, new object[] { recq.KeyData }) as GenioMVC.ViewModels.DocumsProperties_ViewModel;
				GenioMVC.ViewModels.DocumsControl_ViewModel controlDoc = GenioMVC.ViewModels.DocumsControl_ViewModel.FromPropertiesToDocums(recq.Table, recq.KeyData, recq.KeyValue, docfk, doc, true);

				return PartialView("../Shared/Docums/_SubmitDocumVersion", controlDoc);
			}
			return PartialView("Error");
		}

		/// <summary>
		/// Returns a JSON response if whether the document was successfully checkedout or not
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <param name="usesTemplates">Whether or not it uses templates</param>
		/// <param name="fieldSize">The size of the field</param>
		/// <param name="dataIdentifier">The control identifier of the field</param>
		/// <param name="isRequired">Whether or not the field is required</param>
		/// <param name="viewType">DocumentViewTypeMode type that defines if it is a download os a preview</param>
		/// <returns>JSON response</returns>
		[NonAction]
		protected ActionResult CheckoutDocum(string ticket, bool usesTemplates, string fieldSize = "", string dataIdentifier = "", bool isRequired = false, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print, int? maxFileSize = null, string allowedTypes = null)
		{
			object[] objs = QResources.DecryptTicketBase64(ticket);

			string username = objs[0] as string;
			string ip = objs[1] as string;

			if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress)
				//invalid user
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

			if (!string.IsNullOrEmpty(fieldSize))
				ViewData["fieldSize"] = fieldSize;
			if (!string.IsNullOrEmpty(dataIdentifier))
				ViewData["data_identifier"] = dataIdentifier;
			ViewData["isRequired"] = isRequired;
			ViewData["viewType"] = viewType;
			if (maxFileSize != null)
				ViewData["maxSize"] = maxFileSize;
			if (!string.IsNullOrEmpty(allowedTypes))
				ViewData["allowedTypes"] = allowedTypes;

			Resource rec = objs[2] as Resource;

			if (rec is ResourceQuery)
			{
				ResourceQuery recq = rec as ResourceQuery;

				Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));
				object model = null;

				MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
				model = methodInfo.Invoke(null, new object[] { recq.KeyValue, null, null, null });

				MethodInfo checkoutVersion = type.GetMethod("CheckoutVersion");
				bool checkout = (bool)checkoutVersion.Invoke(model, new object[] { recq.KeyData });

				if (!checkout)
					return Json(new { success = false, message = Resources.Resources.O_FICHEIRO_JA_ESTA_E06050 }, "text/html");

				string ctrlUpdate = ReloadDocumsVersions(type, model, recq.KeyValue, recq.Table, recq.KeyData, usesTemplates);

				return Json(new { success = true, message = "Checkout efectuado.", controlUpdate = ctrlUpdate }, "text/html");
			}

			// Should not happen
			return Json(new { success = false, message = Resources.Resources.O_REGISTO_PEDIDO_NAO63869 }, "text/html");
		}

		public enum VersionDeleteAction
		{
			LastVersion, Historic, All
		}

		/// <summary>
		/// Returns a JSON response if whether the document (IB or ID) was successfully deleted, accordingly to the version delete action
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <param name="usesTemplates">Whether or not it uses templates</param>
		/// <param name="action">The type of delete action</param>
		/// <param name="fieldSize">The size of the field</param>
		/// <param name="dataIdentifier">The control identifier of the field</param>
		/// <param name="isRequired">Whether or not the field is required</param>
		/// <returns>JSON response</returns>
		[NonAction]
		protected ActionResult DeleteFile(string ticket, bool usesTemplates, VersionDeleteAction action = VersionDeleteAction.All, string fieldSize = "", string dataIdentifier = "", bool isRequired = false, int? maxFileSize = null, string allowedTypes = null)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress)
					//invalid user
					return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				if (!string.IsNullOrEmpty(fieldSize))
					ViewData["fieldSize"] = fieldSize;
				if (!string.IsNullOrEmpty(dataIdentifier))
					ViewData["data_identifier"] = dataIdentifier;
				ViewData["isRequired"] = isRequired;
				if (maxFileSize != null)
					ViewData["maxSize"] = maxFileSize;
				if (!string.IsNullOrEmpty(allowedTypes))
					ViewData["allowedTypes"] = allowedTypes;

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;
					Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));

					object model = null;

					MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
					model = methodInfo.Invoke(null, new object[] { recq.KeyValue, null, null, null });

					bool external = false;
					object[] customAttrs = type.GetProperty(recq.KeyData).GetCustomAttributes(typeof(DocumentAttribute), false);
					if (customAttrs.FirstOrDefault() != null)
					{
						DocumentAttribute attr = ((DocumentAttribute)customAttrs.FirstOrDefault());
						external = attr.IsExternal();
					}

					if (external)
					{
						string fileName = type.GetProperty(recq.KeyData).GetValue(model, null) as string;
						FileUpload file = new FileUpload(recq.Table, recq.KeyData, fileName);
						if (file.Delete())
						{
							//Server problem, it is not possible to insert null for type field PATH
							type.GetProperty(recq.KeyData).SetValue(model, " ", null);
							MethodInfo saveMethod = type.GetMethod("Save");
							saveMethod.Invoke(model, new object[] {});
							return Json(new { success = true, external }, "text/html");
						}
						else
							throw new Exception();
					}
					else
					{
						MethodInfo deleteMethod;
						switch (action)
						{
							case VersionDeleteAction.LastVersion:
								deleteMethod = type.GetMethod("DeleteLastVersion");
								break;
							case VersionDeleteAction.Historic:
								deleteMethod = type.GetMethod("DeleteHistoricVersions");
								break;
							case VersionDeleteAction.All:
								deleteMethod = type.GetMethod("DeleteDocument");
								break;
							default:
								throw new Exception("Modo " + action + " não suportado");
						}

						bool result = (bool)deleteMethod.Invoke(model, new object[] { recq.KeyData });
						if (!result)
							throw new Exception();

						string ctrlUpdate = ReloadDocumsVersions(type, model, recq.KeyValue, recq.Table, recq.KeyData, usesTemplates);

						return Json(new { success = result, controlUpdate = ctrlUpdate, external }, "text/html");
					}
				}
				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 }, "text/html");
			}
			catch (Exception)
			{
				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 }, "text/html");
			}
		}

		public enum VersionSubmitAction
		{
			Insert, Submit, UnlockFile
		}

		/// <summary>
		/// Adds a new document (IB or ID)
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <param name="usesTemplates">Whether or not it uses templates</param>
		/// <param name="mode">Submit file action mode</param>
		/// <param name="version">The document version</param>
		/// <param name="fieldSize">The size of the field</param>
		/// <param name="dataIdentifier">The control identifier of the field</param>
		/// <param name="isRequired">Whether or not the field is required</param>
		/// <param name="viewType">DocumentViewTypeMode type that defines if it is a download os a preview</param>
		/// <returns>JSON response</returns>
		[NonAction]
		protected ActionResult SetFile(string ticket, bool usesTemplates, VersionSubmitAction mode = VersionSubmitAction.Insert, string version = "1", string fieldSize = "", string dataIdentifier = "", bool isRequired = false, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print, int? maxFileSize = null, string allowedTypes = null)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress)
					//invalid user
					return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				if (!string.IsNullOrEmpty(fieldSize))
					ViewData["fieldSize"] = fieldSize;
				if (!string.IsNullOrEmpty(dataIdentifier))
					ViewData["data_identifier"] = dataIdentifier;
				ViewData["isRequired"] = isRequired;
				ViewData["viewType"] = viewType;
                if (maxFileSize != null)
                    ViewData["maxSize"] = maxFileSize;
                if (!string.IsNullOrEmpty(allowedTypes))
                    ViewData["allowedTypes"] = allowedTypes;

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;

					Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));
					object model = null;

					MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
					model = methodInfo.Invoke(null, new object[] { recq.KeyValue, null, null, null });

					string filefk = type.GetProperty(recq.KeyData + "fk").GetValue(model, null) as string;

					bool external = false;
					bool versioning = false;
					object[] customAttrs = type.GetProperty(recq.KeyData).GetCustomAttributes(typeof(DocumentAttribute), false);
					if (customAttrs.FirstOrDefault() != null)
					{
						external = ((DocumentAttribute)customAttrs.FirstOrDefault()).IsExternal();
						versioning = ((DocumentAttribute)customAttrs.FirstOrDefault()).UsesVersioning();
					}

					CSGenio.business.DBFile file = null;
					string contentRangeHeader = Request.Headers["Content-Range"];

					// Check if this is a chunked upload.
					if (string.IsNullOrEmpty(contentRangeHeader) && mode != VersionSubmitAction.UnlockFile)
					{
						// Not a chunked upload.
						file = GetFileFromRequest(this.Request, recq.KeyData + "_file", version);

						if (file == null)
							throw new Exception();
					}
					else if (mode != VersionSubmitAction.UnlockFile)
					{
						// Parse the content range header to determine
						// the range of bytes in the current chunk.
						string[] contentRangeParts = contentRangeHeader.Split('/');
						string[] byteRangeParts = contentRangeParts[0].Split('-');
						int startByte = int.Parse(byteRangeParts[0].Replace("bytes ", ""));
						int endByte = int.Parse(byteRangeParts[1]);

						System.Web.HttpPostedFileBase f = Request.Files[recq.KeyData + "_file"];

						byte[] chunk = StreamToByteArray(f.InputStream, f.ContentLength);

						// Get the content of any previous chunks from in-memory cache.
						List<byte[]> parts = (List<byte[]>)QCache.Instance.FileUpload.Get(ticket) ?? new List<byte[]>();
						// Combine them with the current chunk.
						parts.Add(chunk);

						// Check if this is the last chunk.
						int totalBytes = int.Parse(contentRangeParts[1]);
						bool isLastChunk = endByte == totalBytes - 1;

						if (isLastChunk)
						{
							byte[] part = JoinByteArrays(parts);

							file = new CSGenio.business.DBFile
								(
									Path.GetFileName(f.FileName),
									Path.GetExtension(f.FileName).Replace(".", ""),
									version,
									part,
									totalBytes
								);

							// Remove the temporary partial file.
							QCache.Instance.FileUpload.Invalidate(ticket);
						}
						else
						{
							// Put the partial file into the in-memory cache.
							QCache.Instance.FileUpload.Put(ticket, parts);

							return Json(new { success = true, message = "Chunk processed successfully.", startByte, endByte });
						}
					}

					// Retrieve the latest version provided for this document.
					CSGenio.business.DBFile oldFile = null;
					if (versioning && GlobalFunctions.emptyG(filefk) == 0)
						oldFile = GenioMVC.Models.ModelBase.GetDocumentsLatestVersion(filefk);

					DocumsProperties_ViewModel infoDoc = null;
					if (version != "1")
					{
						// Confirm checkout editor
						MethodInfo getInfoDoc = type.GetMethod("GetInfoDoc", new Type[] { typeof(string) });
						infoDoc = (getInfoDoc.Invoke(model, new object[] { recq.KeyData })) as DocumsProperties_ViewModel;

						if (infoDoc.CheckoutEditor != username)
							throw new Exception();
					}

					if (external)
					{
						//ID type
						string oldfile = type.GetProperty(recq.KeyData).GetValue(model, null) as string;
						FileUpload fileupload = new FileUpload(recq.Table, recq.KeyData, file.Name);
						//Delete old file if exist
						if (fileupload.Delete(oldfile))
						{
							if (fileupload.Save(file.File))
							{
								type.GetProperty(recq.KeyData).SetValue(model, fileupload.SavedFileName, null);
								MethodInfo saveMethod = type.GetMethod("Save");
								saveMethod.Invoke(model, new object[] { });
								return Json(new { success = true, filename = fileupload.SavedFileName, external = external }, "text/html");
							}
						}
						throw new Exception();
					}
					else
					{
						//IB type
						MethodInfo method;
                        bool success = false;
                        string message = "Sucesso";
						
						switch (mode)
						{
							case VersionSubmitAction.Insert:
								method = type.GetMethod("SaveDocument");
                                success = (bool)method.Invoke(model, new object[] { recq.Table, recq.KeyData, file });
								break;
							case VersionSubmitAction.Submit:
							case VersionSubmitAction.UnlockFile:
								string saveMode = mode == VersionSubmitAction.Submit ? "SUBM" : "DESBL";
								method = type.GetMethod("SubmitVersion");
								byte[] bytes = file == null ? null : file.File;
								string fName = file == null ? null : file.Name;
                                // TODO
                                success = (bool)method.Invoke(model, new object[] { recq.Table, recq.KeyData, bytes, fName, infoDoc.Coddocums, saveMode, version });
								break;
							default:
								throw new Exception("Modo " + mode + " não suportado");
						}

						if (!success)
							message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091;

                        string filename = type.GetProperty(recq.KeyData).GetValue(model, null) as string;
						string ctrlUpdate = ReloadDocumsVersions(type, model, recq.KeyValue, recq.Table, recq.KeyData, usesTemplates);

						return Json(new { success = success, controlUpdate = ctrlUpdate, versioning, message = message, filename, filefk }, "text/html");
					}
				}
				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 }, "text/html");
			}
			catch (Exception)
			{
				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 }, "text/html");
			}
		}

		#endregion

		#region Docum Download

        /// <summary>
        /// Download a document (IB or ID)
        /// </summary>
        /// <param name="ticket">The resource ticket</param>
        /// <param name="identifier"></param>
        /// <param name="viewType">DocumentViewTypeMode type that defines if it is a download os a preview</param>
        /// <returns>A document</returns>
        [NonAction]
        protected ActionResult GetFile(string ticket, string identifier = null, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print)
        {
            try
            {
                object[] objs = QResources.DecryptTicketBase64(ticket);

                string username = objs[0] as string;
                string ip = objs[1] as string;

                Resource rec = objs[2] as Resource;

                if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress || String.IsNullOrEmpty(rec.Name))
                    //invalid user or null record
                    return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

                if (!(rec is ResourceQuery))
                    return View("Error");

                ResourceQuery recq = rec as ResourceQuery;
                Type type = Type.GetType("GenioMVC.Models." + StringUtils.CapFirst(recq.Table));
                object model = null;

                MethodInfo methodInfo = type.GetMethod("Find", new Type[] { typeof(string), typeof(string), typeof(string[]), typeof(string[]) });
                model = methodInfo.Invoke(null, new object[] { recq.KeyValue, identifier, null, null });

                bool external = false;
                object[] customAttrs = type.GetProperty(recq.KeyData).GetCustomAttributes(typeof(DocumentAttribute), false);
                if (customAttrs.FirstOrDefault() != null)
                    external = ((DocumentAttribute)customAttrs.FirstOrDefault()).IsExternal();

                byte[] document;
                string fileName;


                if (external)
                {
                    fileName = type.GetProperty(recq.KeyData).GetValue(model, null) as string;
                    document = System.IO.File.ReadAllBytes(Path.Combine(Configuration.PathDocuments, fileName));
                }
                else
                {
                    MethodInfo FindDocumentMethod = type.GetMethod("FindDocument");
                    DBFile file = FindDocumentMethod.Invoke(model, new object[] { recq.KeyData }) as DBFile;
                    fileName = file.Name;
                    document = file.File;
                }

                string contentType = "application/octet-stream";
				if (viewType == DocumentViewTypeMode.Preview)
				{
					contentType = System.Web.MimeMapping.GetMimeMapping(fileName);

                    var contentDisposition = new System.Net.Mime.ContentDisposition
                    {
                        FileName = System.Web.HttpUtility.UrlEncode(fileName),
                        Inline = true // For inline display,						
                    };

                    Response.AppendHeader("Content-Disposition", contentDisposition.ToString());

                    //It must be like this to be possible to open the file in a new TAB and preview, if whe add fileName parameter it will crash with the folwiing error ERR_RESPONSE_HEADERS_MULTIPLE_CONTENT_DISPOSITION					
                    return File(document, contentType);
                }

                return File(document, contentType, fileName);
                
            }
            catch (Exception ex)
            {
                Log.Error("GetFile Error: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.TargetSite.Name == "getFileDB")
                    return View("FileNotFoundError");
                else
                    return View("Error");
            }
        }

		/// <summary>
		/// Returns a specific version of a file
		/// </summary>
		/// <param name="ticket">The resource ticket</param>
		/// <returns>A document</returns>
		[NonAction]
		protected ActionResult GetSpecificFile(string ticket)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				Resource rec = objs[2] as Resource;

				if (username != UserContext.Current.User.Name || ip != HttpContext.Request.UserHostAddress || String.IsNullOrEmpty(rec.Name))
					//invalid user or null record
					return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;

					CSGenio.business.DBFile file = GenioMVC.Models.ModelBase.GetSpecificDocument(recq.KeyValue);
					Response.Headers.Add("FileName", file.Name);
					return File(file.File, "application/octet-stream", file.Name);
				}

				return View("Error");
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		#endregion

		#region Helper Methods

		/// <summary>
		/// Aux method to get file from httpRequest
		/// </summary>
		/// <param name="request">request</param>
		/// <param name="fldname">document field</param>
		/// <returns>DBFile</returns>
		[NonAction]
		protected static CSGenio.business.DBFile GetFileFromRequest(System.Web.HttpRequestBase request, string fldname, string version)
		{
			CSGenio.business.DBFile dbfile = null;

			try
			{
				System.Web.HttpPostedFileBase file = request.Files[fldname];

				dbfile = new CSGenio.business.DBFile(
					Path.GetFileName(file.FileName),
					Path.GetExtension(file.FileName).Replace(".", ""),
					version,
					StreamToByteArray(file.InputStream, file.ContentLength),
					file.ContentLength);
			}
			catch {}

			return dbfile;
		}

        /// <summary>
        /// Stream to byte[]
        /// </summary>
        /// <param name="input">Stream object</param>
        /// <param name="capacity">The initial size of the internal array in bytes</param>
        /// <returns>byte[]</returns>
        private static byte[] StreamToByteArray(Stream input, int capacity)
		{
			using (MemoryStream ms = new MemoryStream(capacity))
			{
				input.CopyTo(ms);
				return ms.ToArray();
			}
		}

        /// <summary>
        /// Joins multiple byte arrays into a single byte array.
        /// </summary>
        /// <param name="parts">A list of byte arrays to be joined.</param>
        /// <returns>A single byte array containing the concatenated elements of the input byte arrays.</returns>
        private static byte[] JoinByteArrays(List<byte[]> parts)
		{
            // Check if the list contains only one element and return it directly to avoid unnecessary processing.
            if (parts.Count == 1)
            {
                return parts[0];
            }
            else
            {
                byte[] part;
                int totalLength = 0;

                // Calculate the total length of the arrays to allocate enough space for all of them.
                foreach (var c in parts)
                    totalLength += c.Length;

                // Create a new byte array with the calculated total length.
                part = new byte[totalLength];

                int currentIndex = 0;

                // Copy each byte array to the final array 'part', maintaining the original order.
                foreach (var c in parts)
                {
                    // Copy the current byte array to 'part', starting at the current index.
                    Buffer.BlockCopy(c, 0, part, currentIndex, c.Length);

                    // Update the current index to the next position after the last copied byte.
                    currentIndex += c.Length;
                }

                return part;
            }
        }

		/// <summary>
		/// Renders a PartialView as a string
		/// </summary>
		/// <param name="thisController">The controller</param>
		/// <param name="viewName">The view name</param>
		/// <param name="model">The model object</param>
		/// <returns>A string with the rendered partial view</returns>
		protected static string RenderPartialViewToString(Controller thisController, string viewName, object model)
		{
			// assign the model of the controller from which this method was called to the instance of the passed controller (a new instance, by the way)
			thisController.ViewData.Model = model;

			// initialize a string builder
			using (StringWriter sw = new StringWriter())
			{
				// find and load the view or partial view, pass it through the controller factory
				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(thisController.ControllerContext, viewName);
				ViewContext viewContext = new ViewContext(thisController.ControllerContext, viewResult.View, thisController.ViewData, thisController.TempData, sw);

				// render it
				viewResult.View.Render(viewContext, sw);

				//return the razorized view/partial-view as a string
				return sw.ToString();
			}
		}

		/// <summary>
		/// Returns the partial view for docums version control
		/// </summary>
		/// <param name="type">The model type</param>
		/// <param name="row">The model row</param>
		/// <param name="rowId">The row id</param>
		/// <param name="model">The model name</param>
		/// <param name="fldname">The document field</param>
		/// <param name="usesTemplates">If the control uses templates</param>
		/// <returns>A string with the docums control partial view</returns>
		private string ReloadDocumsVersions(Type type, object row, string rowId, string model, string fldname, bool usesTemplates)
		{
			MethodInfo getInfoDoc = type.GetMethod("GetInfoDoc");
			GenioMVC.ViewModels.DocumsProperties_ViewModel doc = getInfoDoc.Invoke(row, new object[] { fldname }) as GenioMVC.ViewModels.DocumsProperties_ViewModel;

			string docfk = type.GetProperty(fldname + "fk").GetValue(row, null) as string;
			GenioMVC.ViewModels.DocumsControl_ViewModel controlDoc = GenioMVC.ViewModels.DocumsControl_ViewModel.FromPropertiesToDocums(model, fldname, rowId, docfk, doc, usesTemplates);

			return RenderPartialViewToString(this, "../Shared/Docums/_VersionedFile", controlDoc);
		}

		#endregion

		/// <summary>
		/// Returns the information required for download exported file
		/// </summary>
		/// <param name="fileId">File ID</param>
		/// <param name="fileType">File type</param>
		/// <returns>JSON</returns>
		protected object getJsonForDownloadExportFile(string fileId, string fileType)
		{
			return new
			{
				id = fileId,
				type = fileType,
				controller = RouteData.Values["controller"] ?? "Home",
				action = "downloadExportFile",
				Url = Url.Action("downloadExportFile", new { id = fileId, type = fileType })
			};
		}

		/// <summary>
		/// Returns the exported file to download
		/// </summary>
		/// <param name="id">File ID</param>
		/// <param name="type">File type</param>
		/// <returns>Exported file</returns>
		public FileResult downloadExportFile(string id, string type)
		{
			byte[] file = QCache.Instance.ExportFiles.Get(id) as byte[];
			QCache.Instance.ExportFiles.Invalidate(id);

			switch (type)
			{
				case "pdf":
					return File(file, "application/pdf", id);
				case "xlsx":
					return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", id);
				case "ods":
					return File(file, "application/vnd.oasis.opendocument.spreadsheet", id);
				case "csv":
					return File(file, "text/csv", id);
				case "xml":
					return File(file, "text/xml", id);
				default:
					return File(file, "application/octet-stream", id);
			}
		}

		#endregion

		#region Server-side Function

		[HttpPost]
		[AuthorizeForUsers]
		public JsonResult ExecuteServerFunction([DynamicJson] dynamic json)
		{
			var user = UserContext.Current.User;
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				var func = (string)json["func"];
				var args = json["args"];

				if (string.IsNullOrEmpty(func) || args == null)
					throw new BusinessException("Invalid arguments", "ExecuteServerFunction", "Empty argument value");
				if (!user.IsAuthorized(user.CurrentModule))
					throw new BusinessException("Permission denied", "ExecuteServerFunction", "Permission denied");

				// Check if function can be executed from the client-side
				if(!GlobalFunctions.CheckAllowedFunctions(func))
					throw new BusinessException("Execution of this function is not allowed!", "ExecuteServerFunction", string.Format("Execution of '{0}' function is not allowed!", func));

				var inputForLog = " Values| " + Newtonsoft.Json.JsonConvert.SerializeObject(json);
				var funcoesGlobais = new GlobalFunctions(user, user.CurrentModule, sp);
				var typeFuncoesGlobais = funcoesGlobais.GetType();

				// Encontrar metodo
				MethodInfo method;
				try
				{
					method = typeFuncoesGlobais.GetMethod(func); // TODO: Cache ...
				}
				catch
				{
					throw new BusinessException("Invalid arguments", "ExecuteServerFunction", string.Format("Can't find the method '{0}' ", func));
				}

				// Obter parametros do metodo invocado
				var parameters = method.GetParameters();
				// Validate se quantidade de parametros recebidos coresponde a quantidade dos parametros do metodo
				var methodParamCount = parameters.Count();
				if(methodParamCount != ((object[])args).Count())
					throw new BusinessException("Invalid arguments", "ExecuteServerFunction", "Incoherence of parameters." + inputForLog);

				// Cast dos dados JSON to tipo de dados C#
				var parametersInput = new object[methodParamCount];
				for(int p = 0; p < methodParamCount; p++)
				{
					try
					{
						var type = Nullable.GetUnderlyingType(parameters[p].ParameterType) ?? parameters[p].ParameterType;
						if (args[p] == null)
							parametersInput[p] = null;
						else if (type == typeof(bool) && (Convert.ToString(args[p]) == "0" || Convert.ToString(args[p]) == "1"))
							parametersInput[p] = Convert.ToString(args[p]) == "1";
						else if(type == typeof(DateTime) || type == typeof(DateTime?))
							parametersInput[p] = DateTime.Parse(args[p], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
						else
							parametersInput[p] = Convert.ChangeType(args[p], type);
					}
					catch (Exception e)
					{
						throw new BusinessException("Invalid arguments", "ExecuteServerFunction", "Error converting received value. " +  e.Message + inputForLog);
					}
				}

				// Invocar função
				sp.openConnection();
				var data = method.Invoke(funcoesGlobais, parametersInput);
				sp.closeConnection();
				return Json(Newtonsoft.Json.JsonConvert.SerializeObject(new { success = true, result = data, message = "" }), JsonRequestBehavior.AllowGet);
			}
			catch (BusinessException e)
			{
				sp.closeConnection();
				return Json(Newtonsoft.Json.JsonConvert.SerializeObject(new { success = false, result = new { func = json["func"], args = json["args"] }, message = e.Message }), JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				sp.closeConnection();
				Log.Error(string.Format("Business Exception. [message] Unexpected error [site] ExecuteServerFunction [cause] {0}; Values|{1}", e.Message, Newtonsoft.Json.JsonConvert.SerializeObject(json)));
				return Json(Newtonsoft.Json.JsonConvert.SerializeObject(new { success = false, result = new { func = json["func"], args = json["args"] }, message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 }), JsonRequestBehavior.AllowGet);
			}
		}

		#endregion

		#region Syncronize Form keys with Server (Navigation)

		/// <summary>
		/// Auxiliary class to receive more complete information about key values coming from the client side.
		/// </summary>
		[System.Runtime.Serialization.DataContract]
		public class SyncHistoryFormKeyValue {

			[Newtonsoft.Json.JsonProperty("level"), System.Runtime.Serialization.DataMember(Name = "level")]
			public int Level { get; set; }
			[Newtonsoft.Json.JsonProperty("navId"), System.Runtime.Serialization.DataMember(Name = "navId")]
			public string NavId { get; set; }
			[Newtonsoft.Json.JsonProperty("formAction"), System.Runtime.Serialization.DataMember(Name = "formAction")]
			public string FormAction { get; set; }
			[Newtonsoft.Json.JsonProperty("values"), System.Runtime.Serialization.DataMember(Name = "values")]
			public IDictionary<string, string> Values { get; set; }
		}

		[HttpPost]
		public JsonResult syncFormKeys(List<SyncHistoryFormKeyValue> formKeys)
		{
			_syncronizeFormKeys(formKeys);
			return Json(new { Success = "OK" });
		}

		// <summary>
		/// Updated history information based on keys coming from the client side.
		///
		/// </summary>
		/// <param name="formKeys">List of client-side form keys information</param>
		protected void _syncronizeFormKeys(List<SyncHistoryFormKeyValue> formKeys)
		{
			if (formKeys != null)
			{
				try
				{
					/*
					 To maintain compatibility with what was previously there and not to create bugs at
						the extreme cases where the Location, Id and Level of the navigation do not correspond to what we have,
						this code ignore some undefined cases.
					 */
					foreach (var form in formKeys) {
						// Validate if the form's navigation id matches the current one (multiforms and wizard use navigation clones). TODO: check!
						if (/*(string.IsNullOrEmpty(form.NavId) || form.NavId == Navigation.NavigationId) &&*/
							/*
							 * Validate that the navigation level of the form is not higher than the current one.
							 * Prevent insertion of keys from upper level to lower level (-1 is the undefined).
							 * There is a problem in complex systems (and still not identified the source)
							 *	in certain cases the insertion of the keys of one of the higher forms would inserted at the level of the menu that came before.
							 *	For some reason, at the time of synchronization, the form level no longer existed.
							*/
							(form.Level <= Navigation.CurrentLevel.Level) &&
							// Check if it's a some form. Prevent insertion from unexisted form. (empty is the undefined)
							// For now, let's not even check if the form exists in the history. In the case of wizards, the action is from the wizard phase.
							/*(string.IsNullOrEmpty(form.FormAction) || Navigation.CheckAction(form.FormAction, form.Level)) &&*/
							(form.Values?.Any()).Value)
						{
							foreach (var areaKey in form.Values)
							{   // Synchronize the keys of the areas in the form with History
								if (Navigation.CheckFilledByHistory(areaKey.Key))
									continue;
								if (string.IsNullOrEmpty(areaKey.Value))
									Navigation.SetValue(areaKey.Key, null);
								else Navigation.SetValue(areaKey.Key, areaKey.Value);
							}
						}
					}
				}
				catch (Exception e) {
					Log.Error("_syncronizeFormKeys: " + e.Message);
				}
			}
		}

		#endregion

		#region Client-side GetEph

		[HttpGet]
		[AuthorizeForUsers]
		public JsonResult GetEph(string ephID)
		{
			var value = GlobalFunctions.GetEph(UserContext.Current.User, ephID);
			return Json(new { Success = true, Operation = "GetEph", Value = value }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		[HttpGet]
		public JsonResult HasRole(string roleId)
		{
			var value = GlobalFunctions.HasRole(UserContext.Current.User, roleId);
			return Json(new { Success = true, Operation = "HasRole", Value = value }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		[AuthorizeForUsers]
		public JsonResult IsFeatureActive(string feature)
		{
			var value = GlobalFunctions.IsFeatureActive(feature);
			return Json(new { Success = true, Operation = "IsFeatureActive", Value = value }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		[AuthorizeForUsers]
		public JsonResult GetLevelFromRole(decimal level, string roleId)
		{
			var value = GlobalFunctions.GetLevelFromRole(level, roleId);
			return Json(new { Success = true, Operation = "GetLevelFromRole", Value = value }, JsonRequestBehavior.AllowGet);
		}

		// GET /GetMsqInfo/
		// Action for returning the MessageQueues info for a given model
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("GetMsqInfo")]
		public JsonResult GetMsqInfo(string id, string queueIdList)
		{
			List<System.Collections.Hashtable> infos = new List<System.Collections.Hashtable>();
			string[] queueList = queueIdList.Split(';');

			try
			{
				SelectQuery selQuery = new SelectQuery()
						.Select(CSGenioAmqqueues.FldQueueID)
						.Select(CSGenioAmqqueues.FldMQStatus)
						.Select(CSGenioAmqqueues.FldResposta)
						.Select(CSGenioAmqqueues.FldDataStatus)
						.Select(CSGenioAmqqueues.FldSendnumber)
						.From(CSGenio.business.Area.AreaMQQUEUES)
						.Where(CriteriaSet.And()
							.Equal(CSGenioAmqqueues.FldTabelaCod, id)
							.In(CSGenioAmqqueues.FldQueueID,queueList)
						)
						.OrderBy(CSGenioAmqqueues.FldDataStatus, SortOrder.Ascending);
				selQuery.noLock = true;

				UserContext.Current.PersistentSupport.openConnection();
				DataMatrix ds = UserContext.Current.PersistentSupport.Execute(selQuery);
				UserContext.Current.PersistentSupport.closeConnection();

				for (int k = 0; k < ds.NumRows; k++)
				{
					//Check for Fail status over max retry configuration
					string status = ds.GetString(k, CSGenioAmqqueues.FldMQStatus);
					int sendNumber = ds.GetInteger(k, CSGenioAmqqueues.FldSendnumber);
					int maxsendnumber = Configuration.MessageQueueing.Maxsendnumber;
					MQueueACK statusMQ = (MQueueACK)Enum.Parse(typeof(MQueueACK), status);

					if (statusMQ == MQueueACK.ReplyFAIL && sendNumber >= maxsendnumber) {
						statusMQ = MQueueACK.ReplyREJECT;
					}

					System.Collections.Hashtable res = new System.Collections.Hashtable();
					res.Add("QueueID", ds.GetString(k, CSGenioAmqqueues.FldQueueID));
					res.Add("MQStatus", (int)statusMQ);
					res.Add("Resposta", ds.GetString(k, CSGenioAmqqueues.FldResposta));
					res.Add("DataStatus", ds.GetDate(k, CSGenioAmqqueues.FldDataStatus).ToString(Configuration.DateFormat.DateTimeSeconds, System.Globalization.CultureInfo.InvariantCulture));
					infos.Add(res);
				}
			}
			catch (Exception ex)
			{
				UserContext.Current.PersistentSupport.closeConnection();
				return Json(new { Success = false, Operation = "GetMsqInfo", Message = ex.Message }, JsonRequestBehavior.AllowGet);
			}
			return Json(new { Success = true, Operation = "GetMsqInfo", infos = infos }, JsonRequestBehavior.AllowGet);
		}

		// GET /GetMsqInfo/
		// Action for returning the MessageQueues info for a given model
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("SendMsqUpdate")]
		public JsonResult SendMsqUpdate(string id, string baseArea)
		{
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				var area = CSGenio.business.Area.createArea(baseArea.ToLowerInvariant(), UserContext.Current.User, UserContext.Current.User.CurrentModule) as DbArea;
				if (area != null)
				{
					sp.openTransaction();
					sp.getRecord(area, id);
					//passamos o oldvalues a null to forçar o reenvio
					area.insertQueue(sp, "U", null, null);
					sp.closeTransaction();
				}
			}
			catch (Exception ex)
			{
				sp.rollbackTransaction();
				return Json(new { Success = false, Operation = "SendMsqUpdate", Message = ex.Message }, JsonRequestBehavior.AllowGet);
			}
			return Json(new { Success = true, Operation = "SendMsqUpdate", Message = Resources.Resources.FICHA_REENVIADA_PARA21165 }, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Keep alive the Session State
		/// </summary>
		/// <returns>OK</returns>
		[HttpGet]
		[ActionName("KeepAlive")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult KeepAlive()
		{
			return Json(new { }, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Gets URL to be used in the client-side
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public JsonResult GetUrlToAction(string controllerName, string actionName, IDictionary<string, string> additionalValues = null)
		{
			var routeValues = new System.Web.Routing.RouteValueDictionary();

			if (additionalValues != null)
				foreach (var kv in additionalValues)
					routeValues.Add(kv.Key, kv.Value);

			var url = Url.Action(actionName, controllerName, routeValues);
			return Json(new { url }, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Compatibilização com BO
		/// </summary>
		/// <param name="mode">Mode do form em MVC</param>
		/// <returns>inteiro correspondente a mode do form em BO</returns>
		[NonAction]
		public static int ConvertFormModeMVC2BO(FormMode mode)
		{
			switch (mode)
			{
				case FormMode.New: return 0;
				case FormMode.Show: return 1;
				case FormMode.Edit: return 2;
				case FormMode.Delete: return 3;
				case FormMode.Duplicate: return 4;
				default: return 1;
			}
		}

		/// <summary>
		/// Called when an unhandled exception occurs in the action.
		/// </summary>
		/// <param name="filterContext">Information about the current request and action.</param>
		protected override void OnException(ExceptionContext filterContext)
		{
			Exception ex = filterContext.Exception;
			if(ex != null) // pode ser null ??
				Log.Error(string.Format("Controller_Error: {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "") + ex.ToString());

			base.OnException(filterContext);
		}

		/// <summary>
		/// Created by [CHN] at [2018.12.13]
		/// </summary>
		/// <param name="all_files">string with filename (test.pdf) and byte[] of file</param>
		/// <param name="zipfilename">string for the final zip file</param>
		/// <returns>FileContentResult (that can be sent directly as an ActionResult) with a zip of files</returns>
		public FileContentResult ZipFiles(Dictionary<string, byte[]> all_files, string zipfilename)
		{
			using (var compressedFileStream = new System.IO.MemoryStream())
			{
				using (var zipArchive = new System.IO.Compression.ZipArchive(compressedFileStream, System.IO.Compression.ZipArchiveMode.Create, false))
				{
					foreach (var file in all_files)
					{
						//fix filename (replaces everything to "_" except letters, numbers and "-")
						string filename = System.Text.RegularExpressions.Regex.Replace(file.Key, "[^\\w\\.-]", "_");
						//Create a zip entry for each attachment
						var zipEntry = zipArchive.CreateEntry(filename);

						//Get the stream of the attachment
						using (var originalFileStream = new System.IO.MemoryStream(file.Value))
						using (var zipEntryStream = zipEntry.Open())
						{
							//Copy the attachment stream to the zip entry stream
							originalFileStream.WriteTo(zipEntryStream);
						}
					}
				}
				return new FileContentResult(compressedFileStream.ToArray(), "application/zip") { FileDownloadName = zipfilename };
			}
		}

		/// <summary>
		/// Save the sidebar toggle mode into the user session
		/// </summary>
		/// <param name="mode">sidebar mode </param>
		[AuthorizeForUsers]
		public void setSideMenuMoode(string mode)
		{
			Session.Add("sidebarMode", mode);
		}

		/// <summary>
		/// Add a eph to the current user module and level and form id
		/// </summary>
		/// <param name="id">eph value</param>
		/// <param name="formId">origin form</param>
		/// <returns>Redirect to Home</returns>
		public ActionResult DefineEphForm(string id, string formId)
		{
			DefineEphFormValues(new string[] { id }, formId);
			
			if (Session["CurrentAction"] != null)
			{
				string action = Session["CurrentAction"].ToString();
				string controller = Session["CurrentController"].ToString();
                Session["CurrentAction"] = null;
                Session["CurrentController"] = null;
				return RedirectToAction(action, controller);
			}
			
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// Add a eph to the current user module and level and form id
		/// </summary>
		/// <param name="id">eph values</param>
		/// <param name="formId">origin form</param>
		/// <returns>A json with the error/success response</returns>
		public ActionResult DefineEphFormValues(string[] ids, string formId)
		{
			try
			{
				User user = UserContext.Current.User;

				List<string> modules = new List<string>() { user.CurrentModule };

// USE /[MANUAL GQT BEFORE_FILL_EPH]/

                // Fill in the initial EPH value in the User object and get the values to be cached
                Dictionary<string, InitialEPHCache> initialEPHCache = GenioServer.security.UserFactory.FillEphRuntime(ref user, modules, ids, formId);

                // If the values of the other initial PHE are in the cache, we merge them.
                var cachedInitialPHE = Session["user.eph.initial"] as Dictionary<string, InitialEPHCache>;
				if(cachedInitialPHE != null)
				{
                    foreach (var cachePHE in cachedInitialPHE)
                    {
                        if (!initialEPHCache.ContainsKey(cachePHE.Key))
                            initialEPHCache.Add(cachePHE.Key, cachePHE.Value);
                        else
                            initialEPHCache[cachePHE.Key].MergeCache(cachePHE.Value);
                    }
                }

                // Writes the updated cache to session
                Session["user.eph.initial"] = initialEPHCache;

				UserContext.Current.User = user;

				return Json(new
				{
					success = "OK",
				});
			}
			catch (Exception e)
			{
				Log.Error(e.Message);

				return Json(new
				{
					success = "E",
					message = Resources.Resources.ERRO_NA_EXECUCAO_DE_49457,
				});
			}
		}

		protected void DestroySession()
		{
			System.Web.Security.FormsAuthentication.SignOut();
			UserContext.Destroy();
			GenioServer.security.GlobalAppSessions.Instance.Remove(Session.SessionID);
			Session.Abandon();

			Response.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName].Expires = DateTime.Today.AddDays(-1);
			//get sessionid cookie name from web.config
			System.Web.Configuration.SessionStateSection sessionStateSection = (System.Web.Configuration.SessionStateSection)System.Configuration.ConfigurationManager.GetSection("system.web/sessionState");
			Response.Cookies.Add(new System.Web.HttpCookie(sessionStateSection.CookieName, "") {
				Secure = true,
				Expires = DateTime.Now.AddDays(-1)
			});

			// log logoff (audit)
			CSGenio.framework.Audit.registLoginOut(UserContext.Current.User, Resources.Resources.SAIDA45792, Resources.Resources.SAIDA_ATRAVES_DA_OPC43152, Request.UserHostName, Request.GetClientIpAddress());

			UserContext.Destroy();
		}

		/// <summary>
		/// Function to check event dates validation: checks for invalid dates and interval, events can also be automatically restrained to a min and max time, useful to check if event start and end times fall outside calendar limits
		/// </summary>
		/// <param name="model">ViewModel of the form that stores the information to be validated</param>
		/// <returns></returns>
		public void CalendarDatesValidation(dynamic model)
		{
			DateTime dateSTART = model.GetMethodInvoke(model.CalendarOptions.startDateField);
			//if (!DateTime.TryParse(Request.Form.Get(startDateField), out dateSTART)) //Event desired start date
				//throw new BusinessException(Resources.Resources.A_DATA_DE_INICIO_NAO22799, "FormDatesValidation", "invalid start date");

			DateTime dateEND = model.GetMethodInvoke(model.CalendarOptions.endDateField);
			//if (!DateTime.TryParse(Request.Form.Get(endDateField), out dateEND)) //Event desired end date
				//throw new BusinessException(Resources.Resources.A_DATA_DE_FIM_NAO_E_13208, "FormDatesValidation", "invalid end date");

			if (dateEND <= dateSTART)
				throw new BusinessException(Resources.Resources.A_DATA_DE_FIM_TEM_DE19919, "FormDatesValidation", "invalid dates selection: end<=start");

			//event range check: if event start or end times falls out of range defined. Only checks this if a time range is present.
			bool colides = false;
			if (model.CalendarOptions.minTime != "" && model.CalendarOptions.maxTime != "")
			{
				var virtualSTART = GlobalFunctions.DateSetTime(GlobalFunctions.DateFloorDay(dateSTART), model.CalendarOptions.minTime); //created from the time defined in the calendar options
				var virtualEND = GlobalFunctions.DateSetTime(GlobalFunctions.DateFloorDay(dateEND), model.CalendarOptions.maxTime);

				//colides if start date is before or after range
				if ((dateSTART < virtualSTART || dateSTART > virtualEND))
				{
					colides = true;
				}
				//colides if end date is before or after range
				if ((dateEND < virtualSTART || dateEND > virtualEND))
				{
					colides = true;
				}
			}

			//event ranges check (by time): if event start or end times falls out of range defined. Only checks this if a date range is present.
			if (!string.IsNullOrEmpty(model.CalendarOptions.validDateStart) || !string.IsNullOrEmpty(model.CalendarOptions.validDateEnd))
			{
				//colides if start date is before or after range
				if ((dateSTART < DateTime.Parse(model.CalendarOptions.validDateStart)))
				{
					colides = true;
				}

				//colides if end date is before or after range
				if (dateEND > DateTime.Parse(model.CalendarOptions.validDateEnd))
				{
					colides = true;
				}
			}

			if (colides)
				throw new BusinessException(Resources.Resources.O_EVENTO_NAO_ESTA_DE47554, "FormDatesValidation", "calendar range colision");
		}

		/// <summary>
		/// Function to adjust event dates: if allDay variable is set then it will adjust the start and end dates to minTime and maxTime defined, also adjusts start and end times if they are present in model.
		/// </summary>
		/// <param name="model">ViewModel of the form that stores the information to be adjusted</param>
		/// <returns></returns>
		public void AdjustCalendarDates(dynamic model)
		{
			if (model.GetMethodInvoke(model.CalendarOptions.allDayField))
			{
				//Variables needed to be adjusted on event start and end dates when allDay flag is on
				//when allDay flag is set, times on event dates need to be adjusted to minTime and maxTime

				//Adjust DateTime fields on model
				DateTime dateSTART = model.GetMethodInvoke(model.CalendarOptions.startDateField);
				DateTime dateEND = model.GetMethodInvoke(model.CalendarOptions.endDateField);
				var virtualSTART = GlobalFunctions.DateSetTime(GlobalFunctions.DateFloorDay(dateSTART), model.CalendarOptions.minTime); //created from the time defined in the calendar options
				var virtualEND = GlobalFunctions.DateSetTime(GlobalFunctions.DateFloorDay(dateEND), model.CalendarOptions.maxTime);
				model.SetMethodInvoke(model.CalendarOptions.startDateField, virtualSTART);
				model.SetMethodInvoke(model.CalendarOptions.endDateField, virtualEND);

				//Adjust Time fields on model
				if (model.CalendarOptions.startTimeField != "")
					model.SetMethodInvoke(model.CalendarOptions.startTimeField, model.CalendarOptions.minTime);
				if (model.CalendarOptions.endTimeField != "")
					model.SetMethodInvoke(model.CalendarOptions.endTimeField, model.CalendarOptions.maxTime);
			}
		}

		[NonAction]
		protected JsonResult GenericRecalculateFormulas(ViewModelBase form_data, string area, Func<string, GenioMVC.Models.ModelBase> find, Action<GenioMVC.Models.ModelBase> map)
		{
			try
			{
				RequestReflectHeader("RecalculateFormulasRequestNumber");

				var primaryKey = Navigation.GetStrValue(area);
				if (form_data == null || GlobalFunctions.emptyG(primaryKey) == 1)
					return Json(new { Success = "NONE", Data = "" }, "application/json", JsonRequestBehavior.AllowGet);

				var model = find(primaryKey);
				var backupFields = model.BackupAgregationFields();
				map(model);
				model.MergeFields(backupFields);
				// TODO: Sanitize HTML content
				return JsonOK(model.RecalculateFormulas());
			}
			catch (Exception)
			{
				return Json(new { Success = "ERROR", Data = "" }, "application/json", JsonRequestBehavior.AllowGet);
			}
		}

		[NonAction]
		protected void RequestReflectHeader(string header)
		{
			var requestNumber = Request.Headers.GetValues(header);
			if (requestNumber != null && requestNumber.Any())
				Response.Headers.Add(header, requestNumber.First());
		}

		public FileContentResult GetCaptcha(string captchaId)
		{
			using (var stream = new MemoryStream())
			{
				var captchaCode = new QCaptcha(40, 250, 6).Generate(stream);
				Session["qCaptcha"] = QCaptcha.SetCaptcha(captchaId, captchaCode, (Dictionary<string, string>)Session["qCaptcha"]);

				return new FileContentResult(stream.ToArray(), "image/jpeg");
			}
		}

		/*
		* This method is a temporary measure to stop duplicated code in the controller
		* implementations. NameValueCollection should be removed!
		*/
		public NameValueCollection FormatQueryString(Dictionary<string, string> queryParams)
		{
			NameValueCollection qs = new NameValueCollection();

			foreach (var elem in queryParams)
				qs.Add(elem.Key.ToString(), (elem.Value != null) ? elem.Value.ToString() : null);

			return qs;
		}
	}
}
