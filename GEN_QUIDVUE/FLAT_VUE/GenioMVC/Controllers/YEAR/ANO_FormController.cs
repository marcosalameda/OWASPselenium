using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Year;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER YEAR]/

namespace GenioMVC.Controllers
{
	public partial class YearController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ANO_CANCEL = new NavigationLocation("YEAR61794", "Ano_Cancel", "Year") { vueRouteName = "form-ANO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ANO_SHOW = new NavigationLocation("YEAR61794", "Ano_Show", "Year") { vueRouteName = "form-ANO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ANO_NEW = new NavigationLocation("YEAR61794", "Ano_New", "Year") { vueRouteName = "form-ANO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ANO_EDIT = new NavigationLocation("YEAR61794", "Ano_Edit", "Year") { vueRouteName = "form-ANO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ANO_DUPLICATE = new NavigationLocation("YEAR61794", "Ano_Duplicate", "Year") { vueRouteName = "form-ANO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ANO_DELETE = new NavigationLocation("YEAR61794", "Ano_Delete", "Year") { vueRouteName = "form-ANO", mode = "DELETE" };

		#endregion

		#region Ano private

		private void FormHistoryLimits_Ano()
		{

		}

		#endregion

		public ActionResult Ano_ModalDBEdit()
		{
			Ano_ViewModel model = new Ano_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Ano_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ANO]/

		[HttpPost]
		public ActionResult Ano_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ano_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ano_Show_GET",
				AreaName = "year",
				Location = ACTION_ANO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ano();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ANO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ano_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ANO]/
		[HttpPost]
		public ActionResult Ano_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Ano_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ano_New_GET",
				AreaName = "year",
				FormName = "ANO",
				Location = ACTION_ANO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ano();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ANO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Year/Ano_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ANO]/
		[HttpPost]
		public ActionResult Ano_New([FromBody]Ano_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ano_New",
				ViewName = "Ano",
				AreaName = "year",
				Location = ACTION_ANO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ANO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ANO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ANO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ano_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ANO]/
		[HttpPost]
		public ActionResult Ano_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ano_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ano_Edit_GET",
				AreaName = "year",
				FormName = "ANO",
				Location = ACTION_ANO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ano();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ANO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Year/Ano_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ANO]/
		[HttpPost]
		public ActionResult Ano_Edit([FromBody]Ano_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ano_Edit",
				ViewName = "Ano",
				AreaName = "year",
				Location = ACTION_ANO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ANO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ANO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ANO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ano_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ANO]/
		[HttpPost]
		public ActionResult Ano_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ano_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ano_Delete_GET",
				AreaName = "year",
				FormName = "ANO",
				Location = ACTION_ANO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ano();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ANO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Year/Ano_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ANO]/
		[HttpPost]
		public ActionResult Ano_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ano_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ano_Delete",
				ViewName = "Ano",
				AreaName = "year",
				Location = ACTION_ANO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ANO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ano_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ANO");
		}

		#endregion

		#region Ano_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ANO]/

		[HttpPost]
		public ActionResult Ano_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Ano_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ano_Duplicate_GET",
				AreaName = "year",
				FormName = "ANO",
				Location = ACTION_ANO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ANO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Year/Ano_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ANO]/
		[HttpPost]
		public ActionResult Ano_Duplicate([FromBody]Ano_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ano_Duplicate",
				ViewName = "Ano",
				AreaName = "year",
				Location = ACTION_ANO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ANO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ANO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ANO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ano_Cancel

		//
		// GET: /Year/Ano_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ANO]/
		public ActionResult Ano_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Year(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("year");

// USE /[MANUAL GQT BEFORE_CANCEL ANO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ANO]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_year", "true", true);
			}

			Navigation.ClearValue("year");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Ano Multiform actions

		//
		// GET /Year/MFAno_New
		[HttpGet]
		[ActionName("MFAno_New")]
		public ActionResult MFAno_New()
		{
			var model = new Ano_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ANO_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("year", model.ValCodyear);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return JsonOK(model);
		}

		[HttpPost]
		public ActionResult MFAno_New_GET()
		{
			return MFAno_New();
		}

		//
		// GET /Year/MFAno_Edit
		[HttpGet]
		[ActionName("MFAno_Edit")]
		public ActionResult MFAno_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ANO", "EDIT", new { id = id, partialView = "MFAno", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFAno_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFAno_Edit(requestModel);
		}

		//
		// GET /Year/MFAno_Cancel
		[ActionName("MFAno_Cancel")]
		public ActionResult MFAno_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Year(UserContext.Current);
				model.klass.QPrimaryKey = id;

				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				ClearMessages();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				return JsonERROR(exceptionUserMessage);
			}

			return JsonOK(new { Success = true });
		}

		//
		// POST /Year/MFAno_Save
		[HttpPost]
		[ActionName("MFAno_Save")]
		public JsonResult MFAno_Save(Ano_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFAno_Save",
				ViewName = "MFAno",
				AreaName = "year"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Year/MFAno_Delete
		[HttpPost]
		[ActionName("MFAno_Delete")]
		public JsonResult MFAno_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFAno_Delete",
				ViewName = "MFAno",
				AreaName = "year",
				Location = ACTION_ANO_EDIT
			};

			var model = new Ano_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Year/Ano_ValTodasdes
		// POST: /Year/Ano_ValTodasdes
		[ActionName("Ano_ValTodasdes")]
		public ActionResult Ano_ValTodasdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Ano_ValTodasdes_ViewModel model = new Ano_ValTodasdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodyear = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Year/Ano_ValAgregado
		// POST: /Year/Ano_ValAgregado
		[ActionName("Ano_ValAgregado")]
		public ActionResult Ano_ValAgregado([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_agreg")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_agreg");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Ano_ValAgregado_ViewModel model = new Ano_ValAgregado_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodyear = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Year/Ano_SaveEdit
		[HttpPost]
		public ActionResult Ano_SaveEdit([FromBody]Ano_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ano_SaveEdit",
				ViewName = "Ano",
				AreaName = "year",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ANO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ANO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
