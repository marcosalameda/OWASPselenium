using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using JsonNetResult = Microsoft.AspNetCore.Mvc.JsonResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Controllers
{
	public class ControllerExtension : Controller
	{
		protected readonly IUserContextService UserContext;
		protected readonly UserContext m_userContext;

		public ControllerExtension(IUserContextService userContextService)
		{
			UserContext = userContextService;
			m_userContext = userContextService.Current;
		}

		/// <summary>
		/// Retrieves server errors to be sent to the client-side.
		/// </summary>
		/// <remarks>
		/// This method collates errors stored in TempData as well as those in the current thread.
		/// Useful for debugging and tracking what errors occurred during a specific request cycle.
		/// </remarks>
		/// <returns>List of error messages.</returns>
		private List<string> getServerErrorsToClientSide()
		{
			List<string> errors = [];

			// Check if EventTracking is enabled
			if (Configuration.EventTracking)
			{
				// Fetch errors stored in TempData
				if (TempData["ErrorList"] is List<string> cachedErrors)
					errors.AddRange(cachedErrors);

				// Fetch errors from the current thread
				var currentErrors = Log.GetThreadErrors();
				if (currentErrors != null)
					errors.AddRange(currentErrors);
			}

			// Clear the error cache for the current thread
			Log.ClearThreadErrorsCache();

			return errors;
		}

		/// <summary>
		/// Retorno do objeto em Json com uso da serialização do Newtonsoft.
		/// Para um retorno correto dos dados, não podemos utilizar a serialização do MVC 4 (por exemplo, as datas não estarão no formato correto)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private JsonNetResult _jsonResult(object data)
		{
			return new JsonNetResult(data);
		}

		/// <summary>
		/// Retorno do objeto em Json com uso da serialização do Newtonsoft.
		/// Para um retorno correto dos dados, não podemos utilizar a serialização do MVC 4 (por exemplo, as datas não estarão no formato correto)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected JsonNetResult JsonOK(object data = null)
		{
			return _jsonResult(
				new
				{
					Success = true,
					Data = data,
					Errors = GetModelErrors(),
					NavigationData = GetHistoryToUpdateClientSide(),
					eTracker = getServerErrorsToClientSide()
				}
			);
		}

		protected JsonNetResult JsonERROR(string errorMsg = null, object data = null)
		{
			var defaultMsg = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
			
			return _jsonResult(
				new
				{
					Success = false,
					Data = data,
					Message = (errorMsg ?? defaultMsg),
					Errors = GetModelErrors(),
					NavigationData = GetHistoryToUpdateClientSide(),
					eTracker = getServerErrorsToClientSide()
				}
			);
		}

		// O MVC 5+ utiliza a serialização Newtonsoft por default
		// O override dos metodos Json permite controlar e unificar formato do Json devolvido
		// que no caso das datas, nem pode usar serialização normal do MVC 4

		protected new JsonNetResult Json(object data)
		{
			return JsonOK(data);
		}

		protected JsonNetResult Json(object data, string contentType)
		{
			return JsonOK(data);
		}

		/// <summary>
		/// Get list of history entries to be update on the client-side (Vue.js)
		/// </summary>
		/// <returns></returns>
		private NavigationContext.ClientSideHistoryResult GetHistoryToUpdateClientSide()
		{
			if (IsStateReadonly)
				return GetHistoryNoChanges();
			return UserContext.Current.CurrentNavigation.GetHistoryToUpdateClientSide();
		}

		/// <summary>
		/// Get an empty diff of history changes.
		/// This should be used when the original Navigation is considered read-only but we make temporary changes to it
		/// </summary>
		/// <returns></returns>
		private NavigationContext.ClientSideHistoryResult GetHistoryNoChanges()
		{
			return new NavigationContext.ClientSideHistoryResult()
			{
				HistoryDiff = [],
				NavigationId = UserContext.Current.CurrentNavigation.NavigationId
			};
		}

		/// <summary>
		/// Marks this controller context behaving as if its state is readonly
		/// This makes methods discard any changes caused by processing before sending them to the client side
		/// </summary>
		protected bool IsStateReadonly { get; set; } = false;

		protected JsonNetResult PermissionError(string errorMsg = null, object data = null)
		{
			var message = errorMsg ?? Resources.Resources.PEDIMOS_DESCULPA__OC63848;
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Forbidden, message, data, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult NotFoundError(string errorMsg = null, object data = null)
		{
			var message = errorMsg ?? Resources.Resources.PEDIMOS_DESCULPA__OC63848;
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.NotFound, message, data, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult InternalServerError(string errorMsg = null, object data = null)
		{
			var message = errorMsg ?? Resources.Resources.PEDIMOS_DESCULPA__OC63848;
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.InternalServerError, message, data, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		private Dictionary<string, IList<string>> GetModelErrors()
		{
			var errors = new Dictionary<string, IList<string>>();

			if (!ModelState.IsValid)
			{
				var keys = ModelState.Keys.ToList();
				var values = ModelState.Values.ToList();
				for (int i = 0; i < values.Count; i++)
				{
					IList<string> fieldErrors = new List<string>();
					foreach (var err in values[i].Errors)
						fieldErrors.Add(err.ErrorMessage);

					if (fieldErrors.Count > 0)
						errors[keys[i]] = fieldErrors;
				}
			}

			return errors;
		}

		protected JsonNetResult RedirectToFormAction(string formName, string formMode, object routeValues = null, object model = null)
		{
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Redirect, type = "form", formName, formMode, routeValues, Data = model, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult RedirectToMenuAction(string menuId, object routeValues = null)
		{
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Redirect, type = "menu", menuId, routeValues, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult RedirectToVueRoute(string routeName, object routeValues = null)
		{
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Redirect, type = "route", routeName, routeValues, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult RedirectToErrorPage(string message)
		{
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Redirect, type = "erro", message, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult RedirectToMenuCondition(string menuId, object routeValues = null, object model = null)
		{
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Redirect, type = "menu-mc", menuId, routeValues, Data = model, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		protected JsonNetResult RedirectToMenuRoutine(string menuId, string routineName, object routeValues = null, object model = null)
		{
			return _jsonResult(new { statusCode = System.Net.HttpStatusCode.Redirect, type = "menu-routine", menuId, routineName, routeValues, Data = model, NavigationData = GetHistoryToUpdateClientSide(), eTracker = getServerErrorsToClientSide() });
		}

		private string _getRedirectUrlToVue(string page, object queryParameters = null, bool includeCulture = true, bool includeSystemAndModule = false, string module = null)
		{
			var culture = includeCulture ? string.Format("{0}/", CultureInfo.CurrentCulture.Name) : string.Empty;
			module = module ?? UserContext.Current.User.CurrentModule ?? "Public";
			var systemAndModule = includeSystemAndModule ? string.Format("{0}/{1}/", UserContext.Current.User.Year, module) : string.Empty;
			var queryString = string.Empty;

			if (queryParameters != null)
			{
				var properties = from p in queryParameters.GetType().GetProperties()
								 where p.GetValue(queryParameters, null) != null
								 select p.Name + "=" + System.Web.HttpUtility.UrlEncode(p.GetValue(queryParameters, null).ToString());
				queryString = String.Join("&", properties.ToArray());
			}

			return $"{Request.Scheme}://{Request.Host}{Request.PathBase}/#/{culture}{systemAndModule}{page}?{queryString}";
		}

		protected ActionResult RedirectToVuePage(string page, object queryParameters = null, bool includeCulture = true, bool includeSystemAndModule = false)
		{
			var url = _getRedirectUrlToVue(page, queryParameters, includeCulture, includeSystemAndModule);
			return Redirect(url);
		}

		protected ActionResult RedirectToVueFormPage(string form, string mode = "SHOW", string id = "", object queryParameters = null)
		{
			string formUrl = string.Format("form/{0}/{1}/{2}", form, mode, id),
				url = _getRedirectUrlToVue(formUrl, queryParameters, true, true);
			return Redirect(url);
		}

		public JsonNetResult VueErrorRedirect(string message)
		{
			return RedirectToErrorPage(message);
		}

		public JsonNetResult VueRouteRedirect(string routeName, object routeValues = null)
		{
			return RedirectToVueRoute(routeName, routeValues);
		}
	}

	/// <summary>
	/// Base class for the controllers
	/// Also used the NoCache attribute to prevent any attempt of caching the results
	/// </summary>
	[Authorize]
	public class ControllerBase : ControllerExtension
	{
		/// <summary>
		/// Accessor for the current navigation context
		/// </summary>
		protected NavigationContext Navigation
		{
			get
			{
				return UserContext.Current.CurrentNavigation;
			}
		}

		// TODO: Criar um ficheiro próprio !?
		protected class EventSink
		{
			public Dictionary<string, object> m_context = new();

			public Dictionary<string, object> Context { get { return m_context; } }

			public string MethodName { get; set; }

			public string ViewName { get; set; }

			public string FormName { get; set; }

			public string AreaName { get; set; }

			public NavigationLocation Location { get; set; }

			public bool Redirect { get; set; }

			public Action<EventSink, PersistentSupport> BeforeAll { get; set; }

			public Action<EventSink, PersistentSupport> BeforeOp { get; set; }

			public Action<EventSink, PersistentSupport> AfterOp { get; set; }

			public Action<EventSink, PersistentSupport> BeforeException { get; set; }

			public Action<EventSink, PersistentSupport> AfterException { get; set; }
		}

		/// <summary>
		/// Validates the provided ICrudViewModel and adds any validation errors to the ModelState.
		/// </summary>
		/// <param name="model">The ICrudViewModel to be validated.</param>
		protected void ValidateModel(ICrudViewModel model)
		{
			var validationResult = model.Validate();

			foreach (var (field, errorMessages) in validationResult.ModelErrors)
				foreach (var errorMessage in errorMessages)
					ModelState.AddModelError(field, errorMessage);
		}

		private string HandleException(Exception e)
		{
			Log.Error(e.Message);
			//JGF 2020.12.10 Added multi exception check for multiple write condition errors
			if (e is FieldValidationException fvExc)
			{
				foreach (var message in fvExc.StatusMessage.GetErrorList())
					ModelState.AddModelError(message.Origin, message.Message);

				return fvExc.UserMessage;
			}

			string exceptionUserMessage;
			if (e is GenioException gExc && gExc.UserMessage != null)
				exceptionUserMessage = Translations.Get(gExc.UserMessage, UserContext.Current.User.Language);
			else
				exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;

			ModelState.AddModelError("Erro", exceptionUserMessage);
			return exceptionUserMessage;
		}

		protected List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp, CSGenio.business.Area area)
		{
			if (crs == null)
				return [];

			sp ??= UserContext.Current.PersistentSupport;

			// Fetch List of Related Areas
			List<string> ids = [];

			List<string> relatedTables = [];
			QueryUtils.checkConditionsForForeignTables(crs, area, relatedTables);
			List<CSGenio.framework.Relation> relations = QueryUtils.tablesRelationships(relatedTables, area);
			SelectQuery select = new SelectQuery()
				.Select(area.Alias, area.PrimaryKeyName)
				.From(area.Alias)
				.Where(crs);

			// Insert related area joins in query
			QueryUtils.setFromTabDirect(select, relations, area);

			// Fetch all the IDs
			DataMatrix dm = sp.Execute(select);
			for (int i = 0; i < dm.NumRows; i++)
				ids.Add(dm.GetString(i, 0));

			return ids;
		}

		/// <summary>
		/// Ensures the keys in the navigation belong to the current record
		/// </summary>
		/// <param name="id">The id of the record</param>
		/// <param name="area">The name of the area</param>
		protected void SanitizeHistoryEntries(string id, string area)
		{
			if (id != null && id != Navigation.GetStrValue(area))
				Navigation.CurrentLevel.ClearEntries();
		}

		protected JsonNetResult GenericHandleGetFormShow(EventSink sink, ICrudViewModel model, string id)
		{
			SanitizeHistoryEntries(id, sink.AreaName);

			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			model.setModes(Request.Query["m"]);

			// Check table permissions
			var permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Navigation.SetValue(sink.AreaName, id);

			//---------------------------------------------
			// USE /[MANUAL BEFORE_LOAD_SHOW]/
			sink.BeforeOp?.Invoke(sink, sp);
			//---------------------------------------------

			try
			{
				if (sink.AreaName == "glob")
				{
					model.LoadGlob(Request.QueryNameValues(), true, Request.IsAjaxRequest());
					Navigation.SetValue(sink.AreaName, model.QPrimaryKey);
				}
				else
					model.Load(Request.QueryNameValues(), true, Request.IsAjaxRequest(), true);
			}
			catch (ModelNotFoundException)
			{
				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error(sink.MethodName + " - " + id + " " + e.Message);
				return InternalServerError();
			}

			//---------------------------------------------
			// USE /[MANUAL AFTER_LOAD_SHOW]/
			sink.AfterOp?.Invoke(sink, sp);
			//---------------------------------------------

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			return JsonOK(model);
		}

		protected JsonNetResult GenericHandleGetFormNew(EventSink sink, ICrudViewModel model, string id, bool isNewLocation, Dictionary<string, string> prefillValues = null)
		{
			SanitizeHistoryEntries(id, sink.AreaName);

			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			model.setModes(Request.Query["m"]);

			// Check table permissions
			var permission = model.CheckPermissions(FormMode.New);

			// Check form conditions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey(sink.FormName))
				Navigation.OverrideSkipIfJustOne[sink.FormName] = true;

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			try
			{
				if (isNewLocation)
				{
					sp.openTransaction();
					model.New();
					sp.closeTransaction();

					Navigation.SetValue(sink.AreaName, model.QPrimaryKey);

					sp.openConnection();

					//---------------------------------------------
					// USE /[MANUAL BEFORE_LOAD_NEW]/
					sink.BeforeOp?.Invoke(sink, sp);
					//---------------------------------------------

					model.NewLoad();

					// FOR: PREFILL_FORM_VALUES
					// Set property values passed in
					if (prefillValues != null)
					{
						foreach (KeyValuePair<string, string> kvp in prefillValues)
						{
							PropertyInfo prop = model.GetType().GetProperty(kvp.Key);
							if (prop == null)
								continue;

							Type type = prop.PropertyType;
							if (type == null)
								continue;

							var converter = TypeDescriptor.GetConverter(type);
							if (converter == null)
								continue;

							var value = converter.ConvertFromString(kvp.Value);
							prop.SetValue(model, value);
						}
					}

					//---------------------------------------------
					// USE /[MANUAL AFTER_LOAD_SHOW]/
					sink.AfterOp?.Invoke(sink, sp);
					//---------------------------------------------

					sp.closeConnection();
				}
				else
				{
					if (id != null)
						Navigation.SetValue(sink.AreaName, id);
					sp.openConnection();
					model.Load(Request.QueryNameValues(), true, Request.IsAjaxRequest());
					sp.closeConnection();
				}
			}
			catch (ModelNotFoundException)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				ErrorMessage(exceptionUserMessage);
				CSGenio.framework.Log.Error( sink.MethodName + " - " + e.Message);

				return JsonERROR(exceptionUserMessage);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			return JsonOK(model);
		}

		protected JsonNetResult GenericHandleGetFormEdit(EventSink sink, ICrudViewModel model, string id)
		{
			SanitizeHistoryEntries(id, sink.AreaName);

			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			model.setModes(Request.Query["m"]);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Navigation.SetValue(sink.AreaName, id);

			//---------------------------------------------
			// USE /[MANUAL BEFORE_LOAD_EDIT]/
			sink.BeforeOp?.Invoke(sink, sp);
			//---------------------------------------------

			try
			{
				sp.openConnection();
				if (sink.AreaName == "glob")
				{
					model.LoadGlob(Request.QueryNameValues(), true, Request.IsAjaxRequest());
					Navigation.SetValue(sink.AreaName, model.QPrimaryKey);
				}
				else
					model.Load(Request.QueryNameValues(), true, Request.IsAjaxRequest(), true);

				sp.closeConnection();
			}
			catch (ModelNotFoundException)
			{
				sp.closeConnection();
				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				sp.closeConnection();
				CSGenio.framework.Log.Error(sink.MethodName + " - " + id + " " + e.Message);
				return InternalServerError();
			}

			//---------------------------------------------
			// USE /[MANUAL AFTER_LOAD_EDIT]/
			sink.AfterOp?.Invoke(sink, sp);
			//---------------------------------------------

			// Check table permissions
			var permission = model.CheckPermissions(FormMode.Edit);

			// Check form conditions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			return JsonOK(model);
		}

		protected JsonNetResult GenericHandleGetFormDelete(EventSink sink, ICrudViewModel model, string id)
		{
			SanitizeHistoryEntries(id, sink.AreaName);

			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			model.setModes(Request.Query["m"]);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Navigation.SetValue(sink.AreaName, id);

			//---------------------------------------------
			// USE /[MANUAL BEFORE_LOAD_DELETE]/
			sink.BeforeOp?.Invoke(sink, sp);
			//---------------------------------------------

			try
			{
				model.Load(Request.QueryNameValues(), false, Request.IsAjaxRequest(), true);
			}
			catch (ModelNotFoundException)
			{
				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error(sink.MethodName + " - " + id + " " + e.Message);
				return InternalServerError();
			}

			//---------------------------------------------
			// USE /[MANUAL AFTER_LOAD_DELETE]/
			sink.AfterOp?.Invoke(sink, sp);
			//---------------------------------------------

			// Check table permissions
			var permission = model.CheckPermissions(FormMode.Delete);

			// Check form conditions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			return JsonOK(model);
		}

		protected JsonNetResult GenericHandleGetFormDuplicate(EventSink sink, ICrudViewModel model, string id, bool isNewLocation)
		{
			SanitizeHistoryEntries(id, sink.AreaName);

			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			model.setModes(Request.Query["m"]);

			// Check table permissions
			var permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form conditions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			try
			{
				if (isNewLocation)
				{
					sp.openTransaction();

					//---------------------------------------------
					// USE /[MANUAL BEFORE_LOAD_DUPLICATE]/
					sink.BeforeOp?.Invoke(sink, sp);
					//---------------------------------------------

					model.Duplicate(id);

					//---------------------------------------------
					// USE /[MANUAL AFTER_LOAD_DUPLICATE]/
					sink.AfterOp?.Invoke(sink, sp);
					//---------------------------------------------

					sp.closeTransaction();

					Navigation.SetValue(sink.AreaName, model.QPrimaryKey);
				}
				else
				{
					if (id != null)
						Navigation.SetValue(sink.AreaName, id);
					sp.openConnection();
					model.Load(Request.QueryNameValues(), true, Request.IsAjaxRequest());
					sp.closeConnection();
				}
			}
			catch (ModelNotFoundException)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				ErrorMessage(exceptionUserMessage);

				return JsonOK(model);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			return JsonOK(model);
		}

		protected ActionResult GenericHandlePostFormEdit(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			try
			{
				// Check table permissions
				var permission = model.CheckPermissions(FormMode.Edit);

				// Check form conditions
				permission.MergeStatusMessage(model.UpdateConditions());

				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PermissionError(permission.Message);

				ValidateModel(model);

				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, sink.MethodName, "Erro");

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_SAVE_EDIT]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Save();

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

				Navigation.SetValue("ForcePrimaryRead_" + sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_LOAD_EDIT_EX]/
				sink.BeforeException?.Invoke(sink, sp);
				//---------------------------------------------

				model.LoadPartial(Request.QueryNameValues(), true);
				model.MapFromModel();

				//---------------------------------------------
				// USE /[MANUAL AFTER_LOAD_EDIT_EX]/
				sink.AfterException?.Invoke(sink, sp);
				//---------------------------------------------

				HandleException(e);
				model.NestedForm = Request.IsAjaxRequest() && sink.Redirect;

				return JsonERROR(Resources.Resources.ERRO_AO_GUARDAR_O_RE65182, model);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			IList<string> warningMsgs = new List<string>();
			// MH - Visualizar os warnings obtidos durante gravação. (ex: Condição de escrita que não impede gravação)
			if (model.flashMessage != null)
			{
				warningMsgs = model.flashMessage.WarningMessages;
				TempData.SetObject("NEW_WARNINGS_LIST", warningMsgs); // Save the warnings list, so it can be retrieved during the redirect.
				if (model.flashMessage.Status == Status.W || model.flashMessage.Status == Status.OK_MAIS_W)
					GetFlashMessage(model.flashMessage, FormMode.Edit);
			}

			return Json(new { Success = true, Operation = "Edit", Message = Resources.Resources.ALTERACOES_EFECTUADA64514, Warnings = warningMsgs, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		protected ActionResult GenericHandlePostFormApply(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				sink.BeforeAll?.Invoke(sink, sp);

				// Check table permissions
				var permission = model.CheckPermissions(FormMode.Edit);

				// Check form conditions
				permission.MergeStatusMessage(model.UpdateConditions());

				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PermissionError(permission.Message);

				ValidateModel(model);

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

				model.LoadPartial(Request.QueryNameValues());
				model.MapFromModel();

				var exceptionUserMessage = HandleException(ex);

				return JsonERROR(exceptionUserMessage);
			}

			if (model.flashMessage != null && !string.IsNullOrEmpty(model.flashMessage.Message) && model.flashMessage.Status == Status.OK)
				TempData.SetObject("NEW_SAVE_LIST", model.flashMessage.Message); // Add the save messages so they can be retrived later
			else
				TempData.SetObject("NEW_SAVE_LIST", ""); //Make sure that no custom message is displayed when the flashMessage is empty

			return Json(new { Success = true, Operation = "Apply", Message = Resources.Resources.ALTERACOES_EFECTUADA64514 });
		}

		protected ActionResult GenericHandlePostFormDelete(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				sink.BeforeAll?.Invoke(sink, sp);
				// Check table permissions
				var permission = model.CheckPermissions(FormMode.Delete);

				// Check form conditions
				permission.MergeStatusMessage(model.DeleteConditions());

				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PermissionError(permission.Message);

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

				if (!Navigation.CurrentLevel.IsNestedContext)
					GetFlashMessage(model.flashMessage, FormMode.Delete);

				Navigation.SetValue("PreviouslyRemovedRowKey_" + sink.AreaName, model.QPrimaryKey, true);
				Navigation.SetValue("ForcePrimaryRead_" + sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = HandleException(e);

				ClearMessages();
				ErrorMessage(exceptionUserMessage);

				return JsonERROR(exceptionUserMessage);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			return Json(new { Success = true, Operation = "Delete", Message = Resources.Resources.REGISTO_APAGADO_COM_64671, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		protected ActionResult GenericHandlePostFormDuplicate(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				sink.BeforeAll?.Invoke(sink, sp);
				// Check table permissions
				var permission = model.CheckPermissions(FormMode.Duplicate);

				// Check form conditions
				permission.MergeStatusMessage(model.InsertConditions());

				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PermissionError(permission.Message);

				ValidateModel(model);

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

				if (!Request.IsAjaxRequest())
					GetFlashMessage(model.flashMessage, FormMode.Duplicate);

				if (Navigation.PreviousLevel != null)
				{
					// Position the list in the current registry
					Navigation.SetValue("QMVC_POS_RECORD_" + sink.AreaName, Navigation.GetValue(sink.AreaName), true);
				}
				Navigation.SetValue("ForcePrimaryRead_" + sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_LOAD_DUPLICATE_EX]/
				sink.BeforeException?.Invoke(sink, sp);
				//---------------------------------------------

				model.LoadPartial(Request.QueryNameValues());
				model.MapFromModel();

				//---------------------------------------------
				// USE /[MANUAL AFTER_LOAD_DUPLICATE_EX]/
				sink.AfterException?.Invoke(sink, sp);
				//---------------------------------------------

				HandleException(e);

				return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848, model);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			IList<string> warningMsgs = new List<string>();
			// MH - Visualizar os warnings obtidos durante gravação. (ex: Condição de escrita que não impede gravação)
			if (model.flashMessage != null)
			{
				warningMsgs = model.flashMessage.WarningMessages;
				TempData.SetObject("DUP_WARNINGS_LIST", warningMsgs); // Save the warnings list, so it can be retrieved during the redirect.
				if (model.flashMessage.Status == Status.W || model.flashMessage.Status == Status.OK_MAIS_W)
					GetFlashMessage(model.flashMessage, FormMode.Duplicate);
			}

			return Json(new { Success = true, Operation = "Dup", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746, Warnings = warningMsgs, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		protected ActionResult GenericHandlePostFormNew(EventSink sink, ICrudViewModel model)
		{
			long st = DateTime.Now.Ticks;
			var sp = UserContext.Current.PersistentSupport;

			sink.BeforeAll?.Invoke(sink, sp);

			try
			{
				// Check table permissions
				var permission = model.CheckPermissions(FormMode.New);

				// Check form conditions
				permission.MergeStatusMessage(model.InsertConditions());

				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PermissionError(permission.Message);

				ValidateModel(model);

				if (!ModelState.IsValid)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, sink.MethodName, "Erro");

				sp.openTransaction();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_SAVE_NEW]/
				sink.BeforeOp?.Invoke(sink, sp);
				//---------------------------------------------

				model.Save();

				//---------------------------------------------
				// USE /[MANUAL AFTER_SAVE_NEW]/
				sink.AfterOp?.Invoke(sink, sp);
				//---------------------------------------------

				sp.closeTransaction();

				if (!Request.IsAjaxRequest())
					GetFlashMessage(model.flashMessage, FormMode.New);

				if (Navigation.PreviousLevel != null)
				{
					// New insertion in upper table
					if (Navigation.PreviousLevel.FormMode != FormMode.List)
						Navigation.SetValue("RETURN_" + sink.AreaName, Navigation.GetValue(sink.AreaName), true);

					// Position the list in the current registry
					Navigation.SetValue("QMVC_POS_RECORD_" + sink.AreaName, Navigation.GetValue(sink.AreaName), true);
				}
				Navigation.SetValue("ForcePrimaryRead_" + sink.AreaName, "true", true);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				//---------------------------------------------
				// USE /[MANUAL BEFORE_LOAD_NEW_EX]/
				sink.BeforeException?.Invoke(sink, sp);
				//---------------------------------------------

				model.LoadPartial(Request.QueryNameValues());
				model.MapFromModel();

				//---------------------------------------------
				// USE /[MANUAL AFTER_LOAD_NEW_EX]/
				sink.AfterException?.Invoke(sink, sp);
				//---------------------------------------------

				HandleException(e);
				model.NestedForm = Request.IsAjaxRequest() && sink.Redirect; //TODO: MUDAR!

				return JsonERROR(Resources.Resources.ERRO_AO_GUARDAR_O_RE65182, model);
			}

			if (CSGenio.framework.Log.IsDebugEnabled)
				CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

			if (model.flashMessage != null && !string.IsNullOrEmpty(model.flashMessage.Message) && model.flashMessage.Status == Status.OK)
				TempData.SetObject("NEW_SAVE_LIST", model.flashMessage.Message); // Add the save messages so they can be retrived later
			else
				TempData.SetObject("NEW_SAVE_LIST", ""); //Make sure that no custom message is displayed when the flashMessage is empty

			IList<string> warningMsgs = new List<string>();
			// MH - Visualizar os warnings obtidos durante gravação. (ex: Condição de escrita que não impede gravação)
			if (model.flashMessage != null)
			{
				warningMsgs = model.flashMessage.WarningMessages;
				TempData.SetObject("NEW_WARNINGS_LIST", warningMsgs); // Save the warnings list, so it can be retrieved during the redirect.
				if (model.flashMessage.Status == Status.W || model.flashMessage.Status == Status.OK_MAIS_W)
					GetFlashMessage(model.flashMessage, FormMode.New);
			}

			return Json(new { Success = true, Operation = "New", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746, Warnings = warningMsgs, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		protected JsonNetResult GenericHandleMultiFormSave(EventSink sink, ICrudViewModel model, string mode)
		{
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				ValidateModel(model);

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

				model.LoadPartial(Request.QueryNameValues());
				model.MapFromModel();

				var exceptionUserMessage = Resources.Resources.ERRO_AO_GUARDAR_O_RE65182;
				if (ex is GenioException && (ex as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((ex as GenioException).UserMessage, UserContext.Current.User.Language);

				return JsonERROR(exceptionUserMessage, model);
			}

			if (model.flashMessage != null && !string.IsNullOrEmpty(model.flashMessage.Message) && model.flashMessage.Status == Status.OK)
				TempData.SetObject("NEW_SAVE_LIST", model.flashMessage.Message); // Add the save messages so they can be retrived later
			else
				TempData.SetObject("NEW_SAVE_LIST", ""); //Make sure that no custom message is displayed when the flashMessage is empty

			if (mode == "INSERT")
				return Json(new { Success = true, Operation = "MFSave", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746 });
			return Json(new { Success = true, Operation = "MFSave", Message = Resources.Resources.ALTERACOES_EFECTUADA64514 });
		}

		protected JsonNetResult GenericHandlePostMultiFormDelete(EventSink sink, ICrudViewModel model)
		{
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				model.LoadPartial(Request.QueryNameValues());
				model.MapFromModel();

				return JsonOK(model);
			}

			return Json(new { Success = true, Operation = "MFDelete", Message = Resources.Resources.REGISTO_APAGADO_COM_64671 });
		}

		protected ControllerBase(IUserContextService userContextService) : base(userContextService) { }

		/// <summary>
		/// Creates Erros message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void ErrorMessage(string content, bool containsHTML = false)
		{
			Message message = new Message(content, CSGenio.framework.Status.E,containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates Success message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void SuccessMessage(string content, bool containsHTML = false)
		{
			Message message = new Message(content, CSGenio.framework.Status.OK,containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates  Warning message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void WarningMessage(string content, bool containsHTML = false)
		{
			Message message = new Message(content, CSGenio.framework.Status.W, containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates Info message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="containsHTML>"Indicates whether the message to show contains HTML</param>
		protected void InfoMessage(string content, bool containsHTML = false)
		{
			Message message = new Message(content, CSGenio.framework.Status.OK_MAIS_W, containsHTML);
			AddMessage(message);
		}

		/// <summary>
		/// Creates Generic message
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		/// <param name="content">Status of the message</param>
		protected void Message(string content, Status status)
		{
			Message message = new Message(content, status);
			AddMessage(message);
		}

		/// <summary>
		/// Clears any message in TemData
		/// </summary>
		protected void ClearMessages()
		{
			string id = Messages.getID(Navigation.NavigationId);
			//JFG 11/05/2017 This assumes that the Navigation ID is unique per thread, if not, this needs to be protected by lock
			TempData.Remove(id);
		}

		/// <summary>
		/// Adds Message to TempDate to be shown on next http response
		/// </summary>
		/// <param name="content">Mesage to Show</param>
		private void AddMessage(Message message)
		{
			string Id = Messages.getID(Navigation.NavigationId);

			var messageList = TempData.GetObject<List<Message>>(Id) ?? new List<Message> { message };

			//JFG 11/05/2017 This assumes that the Navigation ID is unique per thread, if not, this needs to be protected by lock
			TempData.SetObject(Id, messageList);
		}

		internal void GetFlashMessage(StatusMessage flashMessage, FormMode formMode)
		{
			if (flashMessage != null)
			{
				if (flashMessage.Status.Equals(Status.E) || flashMessage.Status.Equals(Status.EW))
					ErrorMessage(flashMessage.Message);
				else if (flashMessage.Status.Equals(Status.W))
					WarningMessage(flashMessage.Message);
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
							msg = Resources.Resources.ALTERACOES_EFECTUADA64514;
							break;
						case FormMode.Delete:
							msg = Resources.Resources.REGISTO_APAGADO_COM_64671;
							break;
					}

					if (!string.IsNullOrEmpty(msg))
						SuccessMessage(msg);
				}
				else if (flashMessage.Status.Equals(Status.OK_MAIS_W))
					InfoMessage(flashMessage.Message);
			}
		}

		/// <summary>
		/// Builds a RouteValueDictionary with the current route values and additional params
		/// </summary>
		/// <param name="location">The action to redirect to</param>
		/// <param name="additionalRouteValues">Additional Route data</param>
		/// <returns>The redirect result object</returns>
		protected RouteValueDictionary GetRouteValues(NavigationLocation location, object additionalRouteValues = null)
		{
			var values = new RouteValueDictionary(location.RoutedValues);

			if (additionalRouteValues != null)
			{
				var arv = new RouteValueDictionary(additionalRouteValues);

				foreach (var kv in arv)
					if (!values.ContainsKey(kv.Key))
						values.Add(kv.Key, kv.Value);
			}

			return values;
		}

		/// <summary>
		/// Redirects to the action specified in the location
		/// </summary>
		/// <param name="location">The action to redirect to</param>
		/// <param name="additionalRouteValues">Additional Route data</param>
		/// <returns>The redirect result object</returns>
		protected JsonNetResult RedirectToLocation(NavigationLocation location, object additionalRouteValues = null)
		{
			var values = GetRouteValues(location, additionalRouteValues);

			if (!string.IsNullOrEmpty(location.mode) && !values.ContainsKey("mode"))
				values.Add("mode", location.mode);
			return RedirectToVueRoute(location.vueRouteName, values);
		}

		/// <summary>
		/// Redirects to the location based on the form menu's GoBack value.
		/// </summary>
		/// <param name="FormName">The name of the form to get the redirect action of</param>
		/// <returns>The redirect result object</returns>
		/// <remarks>FOR: FORM MENU GO BACK</remarks>
		protected JsonNetResult RedirectToFormMenuGoBack(string FormName)
		{
			return RedirectToLocation(Navigation.CurrentLevel.Location);
		}

		protected bool IsNewLocation(NavigationLocation location)
		{
			return !location.IsSameAction(Navigation.CurrentLevel.Location);
		}

		#region Images

		/// <summary>
		/// Obtains the byte[] image from the corresponding model
		/// </summary>
		/// <param name="id">The id of the row</param>
		/// <param name="modelname">The model we are on</param>
		/// <param name="fldname">The name of the property where the image is at</param>
		/// <param name="formIdentifier">Form Identifier</param>
		/// <param name="height">The image height</param>
		/// <param name="width">The image width</param>
		/// <returns>The image data</returns>
		public JsonNetResult GetImage(string id, string modelname, string fldname, string formIdentifier, int height = -1, int width = -1)
		{
			// If a height and width aren't specified, the original dimensions of the image will be used.
			try
			{
				var row = ModelBase.FindGeneric(modelname, id, UserContext.Current, formIdentifier);
				byte[]? image = row.GetValueGeneric(fldname) as byte[];

				if (image?.Length > 0)
				{
					string imageFormat = ImageResizer.GetImageFormat(image);
					if (height > 0 && width > 0)
						image = ImageResizer.ResizeImage(image, width, height, true);

					ImageModel imageModel = new()
					{
						Data = System.Convert.ToBase64String(image),
						DataFormat = imageFormat,
						FileName = "" // TODO: Save the file name and format.
					};

					return JsonOK(imageModel);
				}

				return JsonOK();
			}
			catch
			{
				return JsonERROR();
			}
		}

		#endregion

		/// <summary>
		/// Calls the server-side method to convert a given string to a QR code representation
		/// </summary>
		/// <param name="text">The string to convert</param>
		/// <returns>A byte array representing the result of the convertion</returns>
		[ActionName("StringToQRcode")]
		[HttpGet]
		public JsonNetResult StringToQRcode(string text)
		{
			byte[] bytes = GlobalFunctions.StringToQRcode(text);

			if (bytes != null)
				return JsonOK(new { value = Convert.ToBase64String(bytes) });
			return JsonOK(new { value = String.Empty });
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
			selectedIds ??= [];

			// Creating the CriteriaSet
			AreaInfo info = CSGenio.business.Area.GetInfoArea(tableNN?.ToLower());
			CriteriaSet criteriaSetAnd = CriteriaSet.And().Equal(info.Alias, primaryField?.ToLower(), key);

			//Call the AllModel for reflection.
			//This code could avoid reflection if its changed to be a generic method and call the generic ModelBase.Where<T> instead.
			Type type = Type.GetType("GenioMVC.Models." + tableNN)!;
			MethodInfo allModelMI = type.GetMethod("AllModel", new Type[] {typeof(UserContext), typeof(CriteriaSet), typeof(String) })!;
			IEnumerable previous = (IEnumerable)allModelMI.Invoke(null, new object?[] { UserContext.Current, criteriaSetAnd, null })!;

			// Updates the table NN by removing the rows that were not selected this time
			HashSet<string> previousSelected = new HashSet<string>();
			foreach (ModelBase row in previous)
			{
				var otherKey = row.GetValueGeneric("Val" + otherField) as string;
				previousSelected.Add((string)otherKey);

				if (!selectedIds.Contains(otherKey))
					row.Destroy();
			}

			// Updates the table NN by adding the new rows that were selected this time
			foreach (var id in selectedIds)
			{
				if (!previousSelected.Contains(id))
				{
					// create
					ModelBase row = (ModelBase)Activator.CreateInstance(type, new object?[] { UserContext.Current, false, null})!;
					row.SetValueGeneric("Val" + primaryField, key);
					row.SetValueGeneric("Val" + otherField, id);
					row.New();
					row.Save();
				}
			}
		}

		#region Documents

		/// <summary>
		/// Creates tickets that can be used by the client-side to handle the specified documents
		/// </summary>
		/// <param name="tableName">The name of the table</param>
		/// <param name="fieldName">The name of the field in the view model</param>
		/// <param name="keyValue">The primary key value</param>
		/// <returns>A json with the list of ticket keys</returns>
		protected ActionResult GetDocumsTickets(string tableName, string fieldName, string keyValue)
		{
			try
			{
				User user = m_userContext.User;
				ModelBase model = ModelBase.FindGeneric(tableName, keyValue, m_userContext, "");
				DocumsProperties_ViewModel properties = model?.GetInfoDoc(fieldName);
				List<object> tickets = [];

				if (model != null)
				{
					SortedList<string, string> versions = properties.Versions;
					string docName = properties.Name;

					// All the versions of the file.
					if (versions?.Count > 0)
					{
						string areaName = "docums";
						string keyName = "ValCoddocums";

						foreach (KeyValuePair<string, string> version in versions)
						{
							ResourceQuery versionResource = new(version.Key, areaName, fieldName, keyName, version.Value);
							string versionTicket = QResources.CreateTicketEncryptedBase64(user.Name, user.Location, versionResource);
							tickets.Add(new { id = version.Key, ticket = versionTicket });
						}
					}

					// The current version of the file.
					ResourceQuery resource = new(docName ?? "", tableName, fieldName, "", keyValue);
					string ticket = QResources.CreateTicketEncryptedBase64(user.Name, user.Location, resource);
					tickets.Add(new { id = "main", ticket });
				}

				return JsonOK(new { tickets, properties });
			}
			catch
			{
				return JsonERROR();
			}
		}

		/// <summary>
		/// Returns a partial view with the docums information as a DBEdit
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <returns>Docums versions DBEdit for a specific field</returns>
		[NonAction]
		protected ActionResult GetDocumsVersionsDBEdit(string ticket)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress())
					return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;
					var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");

					string? docfk = model.GetValueGeneric(recq.KeyData + "fk") as string;

					bool onlyshow = false;
					if (Navigation.CurrentLevel.FormMode == FormMode.Show || Navigation.CurrentLevel.FormMode == FormMode.Delete)
						onlyshow = true;

					GenioMVC.ViewModels.DocumsVersionsDBEdit_ViewModel documsDBedit = new ViewModels.DocumsVersionsDBEdit_ViewModel(UserContext.Current, ticket, docfk, recq.Table, recq.KeyData, onlyshow);
					var values = new System.Collections.Specialized.NameValueCollection();
					documsDBedit.Load(Configuration.NrRegDBedit == 0 ? 10 : Configuration.NrRegDBedit, values);

					return JsonOK(documsDBedit);
				}

				return JsonERROR();
			}
			catch (Exception)
			{
				return JsonERROR();
			}
		}

		/// <summary>
		/// Returns a partial view with document properties
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <returns>Document properties partial view</returns>
		[NonAction]
		protected ActionResult GetFileProperties(string ticket)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress())
					return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;
					var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");
					var doc = model.GetInfoDoc(recq.KeyData);
					return JsonOK(doc);
				}

				return JsonERROR();
			}
			catch (Exception)
			{
				return JsonERROR();
			}
		}

		/// <summary>
		/// Returns a partial view for submitting a document version
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <returns>Document version submit menu partial view</returns>
		[NonAction]
		protected ActionResult SubmitVersion(string ticket)
		{
			object[] objs = QResources.DecryptTicketBase64(ticket);

			string username = objs[0] as string;
			string ip = objs[1] as string;

			if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress())
				return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

			Resource rec = objs[2] as Resource;

			if (rec is ResourceQuery)
			{
				ResourceQuery recq = rec as ResourceQuery;
				var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");
				string? docfk = model.GetValueGeneric(recq.KeyData + "fk") as string;
				var doc = model.GetInfoDoc(recq.KeyData);
				GenioMVC.ViewModels.DocumsControl_ViewModel controlDoc = GenioMVC.ViewModels.DocumsControl_ViewModel.FromPropertiesToDocums(UserContext.Current, recq.Table, recq.KeyData, recq.KeyValue, docfk, doc, true);

				return JsonOK(controlDoc);
			}

			return JsonERROR();
		}

		/// <summary>
		/// Returns a JSON response with whether the document was successfully checked out or not
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <returns>JSON response</returns>
		[NonAction]
		protected ActionResult CheckoutDocum(string ticket)
		{
			object[] objs = QResources.DecryptTicketBase64(ticket);

			string username = objs[0] as string;
			string ip = objs[1] as string;

			if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress())
				return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

			Resource rec = objs[2] as Resource;

			if (rec is ResourceQuery)
			{
				ResourceQuery recq = rec as ResourceQuery;

				var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");
				bool checkout = model.CheckoutVersion(recq.KeyData);

				if (!checkout)
					return Json(new { success = false, message = Resources.Resources.O_FICHEIRO_JA_ESTA_E06050 });

				return Json(new { success = true, message = "Checkout efectuado." });
			}

			// Should not happen
			return Json(new { success = false, message = Resources.Resources.O_REGISTO_PEDIDO_NAO63869 });
		}

		public enum VersionDeleteAction
		{
			LastVersion, Historic, All
		}

		/// <summary>
		/// Returns a JSON response with whether the document (IB or ID) was successfully deleted, accordingly to the version delete action
		/// </summary>
		/// <param name="ticket">Encryted ticket</param>
		/// <param name="action">The type of delete action</param>
		/// <returns>JSON response</returns>
		[NonAction]
		protected ActionResult DeleteFile(string ticket, VersionDeleteAction action = VersionDeleteAction.All)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress())
					return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;
					var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");
					Type type = model.GetType();

					bool external = false;
					object[] customAttrs = type.GetProperty(recq.KeyData).GetCustomAttributes(typeof(DocumentAttribute), false);

					if (customAttrs.FirstOrDefault() != null)
					{
						DocumentAttribute attr = ((DocumentAttribute)customAttrs.FirstOrDefault());
						external = attr.IsExternal();
					}

					if (external)
					{
						string? fileName = model.GetValueGeneric(recq.KeyData) as string;
						FileUpload file = new FileUpload(recq.Table, recq.KeyData, fileName);
						if (file.Delete())
						{
							// Server problem, it is not possible to insert null for type field PATH.
							model.SetValueGeneric(recq.KeyData, " ");
							model.Save();
							return Json(new { success = true, external });
						}

						throw new Exception();
					}
					else
					{
						bool result = action switch
						{
							VersionDeleteAction.LastVersion => model.DeleteLastVersion(recq.KeyData),
							VersionDeleteAction.Historic => model.DeleteHistoricVersions(recq.KeyData),
							VersionDeleteAction.All => model.DeleteDocument(recq.KeyData),
							_ => throw new Exception("Mode '" + action + "' not supported!"),
						};

						if (!result)
							throw new Exception();

						var properties = model.GetInfoDoc(recq.KeyData);
						return Json(new { success = result, external, properties });
					}
				}

				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 });
			}
			catch (Exception)
			{
				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 });
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
		/// <param name="mode">Submit file action mode</param>
		/// <param name="version">The document version</param>
		/// <returns>JSON response</returns>
		[NonAction]
		protected ActionResult SetFile(string ticket, VersionSubmitAction mode = VersionSubmitAction.Insert, string version = "1")
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress())
					return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				Resource rec = objs[2] as Resource;

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;

					var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");
					string? filefk = model.GetValueGeneric(recq.KeyData + "fk") as string;
					Type type = model.GetType();

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
						file = GetFileFromRequest(recq.KeyData + "_file", version);

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

						var f = Request.Form.Files[recq.KeyData + "_file"];

						byte[] chunk = StreamToByteArray(f.OpenReadStream(), (int)f.Length);

						// Get the content of any previous chunks from in-memory cache.
						List<byte[]> parts = (List<byte[]>)QCache.Instance.FileUpload.Get(ticket);
						parts ??= new List<byte[]>();
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
						oldFile = GenioMVC.Models.ModelBase.GetDocumentsLatestVersion(filefk, UserContext.Current);

					DocumsProperties_ViewModel infoDoc = null;
					if (version != "1")
					{
						// Confirm checkout editor
						infoDoc = model.GetInfoDoc(recq.KeyData);
						if (infoDoc.CheckoutEditor != username)
							throw new Exception($"User that checked out this file {infoDoc.CheckoutEditor} is not the same as the current user");
					}

					if (external)
					{
						string? oldfile = model.GetValueGeneric(recq.KeyData) as string;
						FileUpload fileupload = new FileUpload(recq.Table, recq.KeyData, file.Name);

						// Delete old file if it exists.
						if (fileupload.Delete(oldfile))
						{
							if (fileupload.Save(file.File))
							{
								model.SetValueGeneric(recq.KeyData, fileupload.SavedFileName);
								model.Save();
								return Json(new { success = true, filename = fileupload.SavedFileName, external = external });
							}
						}

						throw new Exception();
					}
					else
					{
						//IB type
						string successMessage = "Sucesso";
						string failMessage = Resources.Resources.OCORREU_UM_ERRO_AO_P53091;
						bool result = false;
						switch (mode)
						{
							case VersionSubmitAction.Insert:
								result = model.SaveDocument(recq.Table, recq.KeyData, file);
								break;
							case VersionSubmitAction.Submit:
							case VersionSubmitAction.UnlockFile:
								string saveMode = mode == VersionSubmitAction.Submit ? "SUBM" : "DESBL";
								byte[] bytes = file?.File;
								string fName = file?.Name;

								result = model.SubmitVersion(recq.Table, recq.KeyData, bytes, fName, infoDoc.Coddocums, saveMode, version);
								break;
							default:
								throw new Exception("Mode '" + mode + "' not supported!");
						}

						if (!result)
							return Json(new { success = false, message = failMessage });

						var properties = model.GetInfoDoc(recq.KeyData);
						return Json(new { success = true, message = successMessage, properties });
					}
				}

				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 });
			}
			catch (Exception)
			{
				return Json(new { success = false, message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091 });
			}
		}

		/// <summary>
		/// Download a document (IB or ID)
		/// </summary>
		/// <param name="ticket">The resource ticket</param>
		/// <param name="viewType">DocumentViewTypeMode type that defines if it is a download os a preview</param>
		/// <returns>A document</returns>
		[NonAction]
		protected ActionResult GetFile(string ticket, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print)
		{
			try
			{
				object[] objs = QResources.DecryptTicketBase64(ticket);

				string username = objs[0] as string;
				string ip = objs[1] as string;

				Resource rec = objs[2] as Resource;

				if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress() || string.IsNullOrEmpty(rec.Name))
					// Invalid user or null record
					return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				if (!(rec is ResourceQuery))
					return JsonERROR();

				ResourceQuery recq = rec as ResourceQuery;
				var model = ModelBase.FindGeneric(recq.Table, recq.KeyValue, UserContext.Current, "");
				string? filefk = model.GetValueGeneric(recq.KeyData + "fk") as string;
				Type type = model.GetType();

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
					var file = model.FindDocument(recq.KeyData);
					fileName = file.Name;
					document = file.File;
				}

				string contentType = "application/octet-stream";
				Response.Headers["FileName"] = fileName;
				if (viewType == DocumentViewTypeMode.Preview)
				{
					Response.Headers["Content-Disposition"] = "inline";
					new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);

					// It must be like this to be possible to open the file in a new TAB and preview, if we add fileName parameter it will crash with the following error ERR_RESPONSE_HEADERS_MULTIPLE_CONTENT_DISPOSITION
					return File(document, contentType);
				}

				return File(document, contentType, fileName);
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error("GetFile Error: " + ex.Message);
				return JsonERROR();
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

				if (username != UserContext.Current.User.Name || ip != HttpContext.GetIpAddress() || string.IsNullOrEmpty(rec.Name))
					return PermissionError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);

				if (rec is ResourceQuery)
				{
					ResourceQuery recq = rec as ResourceQuery;

					CSGenio.business.DBFile file = GenioMVC.Models.ModelBase.GetSpecificDocument(recq.KeyValue, UserContext.Current);
					Response.Headers["FileName"] = file.Name;
					return File(file.File, "application/octet-stream", file.Name);
				}

				return JsonERROR();
			}
			catch (Exception)
			{
				return JsonERROR();
			}
		}

		/// <summary>
		/// Aux method to get file from httpRequest
		/// </summary>
		/// <param name="request">request</param>
		/// <param name="fldname">document field</param>
		/// <returns>DBFile</returns>
		[NonAction]
		protected CSGenio.business.DBFile GetFileFromRequest(string fldname, string version)
		{
			CSGenio.business.DBFile dbfile = null;

			try
			{
				var file = Request.Form.Files[fldname];

				dbfile = new CSGenio.business.DBFile(
					Path.GetFileName(file.FileName),
					Path.GetExtension(file.FileName).Replace(".", ""),
					version,
					StreamToByteArray(file.OpenReadStream(), (int)file.Length),
					(int)file.Length);
			}
			catch { }

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
            using MemoryStream ms = new(capacity);
            input.CopyTo(ms);
            return ms.ToArray();
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

				// Create a new byte array with the calculated total length using GC.AllocateUninitializedArray
				//  for potential performance benefits in scenarios where the array is immediately filled.
				// This method reduces overhead by eliminating the initialization step for each element in the array.
                part = GC.AllocateUninitializedArray<byte>(totalLength);

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

		public class RequestExportFile
		{
			public string Id { get; set; }
			public string Type { get; set; }
		}

		/// <summary>
		/// Returns the exported file to download
		/// </summary>
		/// <param name="id">File ID</param>
		/// <param name="type">File type</param>
		/// <returns>Exported file</returns>
		public FileResult downloadExportFile([FromBody]RequestExportFile requestModel)
		{
			var id = requestModel.Id;
			var type = requestModel.Type;

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

		public class RequestServerFunctionModel
		{
			public string func { get; set; }
			public List<object> args { get; set; }
		}

		[HttpPost]
		public JsonNetResult ExecuteServerFunction([FromBody]RequestServerFunctionModel json)
		{
			var user = UserContext.Current.User;
			var sp = UserContext.Current.PersistentSupport;
			try
			{
				if (string.IsNullOrEmpty(json.func) || json.args == null)
					throw new BusinessException("Invalid arguments", "ExecuteServerFunction", "Empty argument value");
				if (!user.IsAuthorized(user.CurrentModule))
					throw new BusinessException("Permission denied", "ExecuteServerFunction", "Permission denied");

				var func = json.func;
				var args = new List<object>();
				foreach (var arg in json.args)
				{
					if (arg is JsonElement je)
					{
						if (je.ValueKind == JsonValueKind.String)
							args.Add(je.GetString() ?? "");
						else if (je.ValueKind == JsonValueKind.Number)
							args.Add(je.GetDouble());
						else if (je.ValueKind == JsonValueKind.True)
							args.Add(true);
						else if (je.ValueKind == JsonValueKind.False)
							args.Add(false);
					}
					else
						args.Add(arg);
				}

				// Check if function can be executed from the client-side
				if (!GlobalFunctions.CheckAllowedFunctions(func))
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
				if (methodParamCount != args.Count)
					throw new BusinessException("Invalid arguments", "ExecuteServerFunction", "Incoherence of parameters." + inputForLog);

				// Cast dos dados JSON to tipo de dados Csharp
				var parametersInput = new object[methodParamCount];
				for (int p = 0; p < methodParamCount; p++)
				{
					try
					{
						var type = Nullable.GetUnderlyingType(parameters[p].ParameterType) ?? parameters[p].ParameterType;
						if (args[p] == null)
							parametersInput[p] = null;
						else if (type == typeof(bool))
							parametersInput[p] = args[p];
						else if (type == typeof(DateTime) || type == typeof(DateTime?))
							parametersInput[p] = DateTime.Parse(args[p].ToString(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
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

				return JsonOK(new { Success = true, Data = data, Message = "" });
			}
			catch (BusinessException e)
			{
				sp.closeConnection();
				return JsonERROR(e.Message, new { func = json.func, args = json.args });
			}
			catch (Exception e)
			{
				sp.closeConnection();
				Log.Error(string.Format("Business Exception. [message] Unexpected error [site] ExecuteServerFunction [cause] {0}; Values|{1}", e.Message, Newtonsoft.Json.JsonConvert.SerializeObject(json)));
				return JsonERROR(Resources.Resources.PEDIMOS_DESCULPA__OC63848, new { func = json.func, args = json.args });
			}
		}

		#endregion

		[HttpGet]
		public JsonNetResult GetEph(string ephID)
		{
			var value = GlobalFunctions.GetEph(UserContext.Current.User, ephID);
			return Json(new { Success = true, Operation = "GetEph", Value = value });
		}

		[HttpGet]
		public JsonNetResult HasRole(string roleId)
		{
			var value = GlobalFunctions.HasRole(UserContext.Current.User, roleId);
			return Json(new { Success = true, Operation = "HasRole", Value = value });
		}

		[HttpGet]
		public JsonNetResult GetLevelFromRole(double level, string roleId)
		{
			var value = GlobalFunctions.GetLevelFromRole(level, roleId);
			return Json(new { Success = true, Operation = "GetLevelFromRole", Value = value });
		}

		[HttpGet]
		public JsonNetResult IsFeatureActive(string feature)
		{
			var value = GlobalFunctions.IsFeatureActive(feature);
			return Json(new { Success = true, Operation = "IsFeatureActive", Value = value });
		}

		// GET /GetMsqInfo/
		// Action for returning the MessageQueues info for a given model
		[HttpGet]
		[ActionName("GetMsqInfo")]
		public JsonNetResult GetMsqInfo(string id, string queueIdList)
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
						.In(CSGenioAmqqueues.FldQueueID,queueList))
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

					if (statusMQ == MQueueACK.ReplyFAIL && sendNumber >= maxsendnumber)
						statusMQ = MQueueACK.ReplyREJECT;

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
				return Json(new { Success = false, Operation = "GetMsqInfo", Message = ex.Message });
			}

			return Json(new { Success = true, Operation = "GetMsqInfo", infos = infos });
		}

		// GET /GetMsqInfo/
		// Action for returning the MessageQueues info for a given model
		[HttpGet]
		[ActionName("SendMsqUpdate")]
		public JsonNetResult SendMsqUpdate(string id, string baseArea)
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
				return Json(new { Success = false, Operation = "SendMsqUpdate", Message = ex.Message });
			}
			return Json(new { Success = true, Operation = "SendMsqUpdate", Message = Resources.Resources.FICHA_REENVIADA_PARA21165 });
		}

		/// <summary>
		/// Gets URL to be used in the client-side
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public JsonNetResult GetUrlToAction(string controllerName, string actionName, IDictionary<string, string> additionalValues = null)
		{
			var routeValues = new RouteValueDictionary();

			if (additionalValues != null)
				foreach (var kv in additionalValues)
					routeValues.Add(kv.Key, kv.Value);

			var url = Url.Action(actionName, controllerName, routeValues);
			return Json(new { url });
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
		/// Add a eph to the current user module and level and form id
		/// </summary>
		/// <param name="id">eph value</param>
		/// <param name="formId">origin form</param>
		/// <returns>Redirect to Home</returns>
		public ActionResult DefineEphForm(string id, string formId)
		{
			return DefineEphFormValues([id], formId);
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
				List<string> modules = [user.CurrentModule];

// USE /[MANUAL GQT BEFORE_FILL_EPH]/

				// Fill in the initial EPH value in the User object and get the values to be cached
				Dictionary<string, InitialEPHCache> initialEPHCache = GenioServer.security.UserFactory.FillEphRuntime(ref user, modules, ids, formId);

				// If the values of the other initial PHE are in the cache, we merge them.
				var cachedInitialPHE = UserContext.Current.GetInitialEph();
				if (cachedInitialPHE != null)
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
				UserContext.Current.SetInitialEph(initialEPHCache);

				UserContext.Current.User = user;

				return JsonOK();
			}
			catch (Exception e)
			{
				Log.Error(e.Message);
				return JsonERROR(Resources.Resources.ERRO_NA_EXECUCAO_DE_49457);
			}
		}

		protected void DestroySession()
		{
			HttpContext.SignOutAsync().Wait();

			UserContext.Current.Destroy();
			GenioServer.security.GlobalAppSessions.Instance.Remove(HttpContext.Session.Id);
			HttpContext.Session.Clear();

			// log logoff (audit)
			CSGenio.framework.Audit.registLoginOut(UserContext.Current.User, Resources.Resources.SAIDA45792, Resources.Resources.SAIDA_ATRAVES_DA_OPC43152, HttpContext.GetHostName(), HttpContext.GetIpAddress());

			UserContext.Current.Destroy();
		}

		[NonAction]
		protected JsonNetResult GenericRecalculateFormulas(ViewModelBase form_data, string area, Func<string, GenioMVC.Models.ModelBase> find, Action<GenioMVC.Models.ModelBase> map)
		{
			try
			{
				RequestReflectHeader("RecalculateFormulasRequestNumber");

				var primaryKey = Navigation.GetStrValue(area);
				if (form_data == null || GlobalFunctions.emptyG(primaryKey) == 1)
					return JsonERROR();

				var model = find(primaryKey);
				var backupFields = model.BackupAgregationFields();
				map(model);
				model.MergeFields(backupFields);

				var recalculatedFormulas = model.RecalculateFormulas();
				var viewModelValues = form_data.ConvertModelToViewModelValues(recalculatedFormulas);

				return JsonOK(viewModelValues);
			}
			catch (Exception e)
			{
				return JsonERROR(e.Message);
			}
		}

		[NonAction]
		protected void RequestReflectHeader(string header)
		{
			if (Request.Headers.TryGetValue(header, out var values))
				Response.Headers[header] = values;
		}

		public FileContentResult GetCaptcha(string captchaId)
		{
			using (var stream = new MemoryStream())
			{
				var captchaCode = new QCaptcha(40, 250, 6).Generate(stream);
				QCaptcha.SetCaptcha(captchaId, captchaCode, HttpContext.Session);

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
