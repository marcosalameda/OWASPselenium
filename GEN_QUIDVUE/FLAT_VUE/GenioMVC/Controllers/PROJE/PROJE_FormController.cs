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
using GenioMVC.ViewModels.Proje;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROJE]/

namespace GenioMVC.Controllers
{
	public partial class ProjeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PROJE_CANCEL = new NavigationLocation("PROJECTO50142", "Proje_Cancel", "Proje") { vueRouteName = "form-PROJE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROJE_SHOW = new NavigationLocation("PROJECTO50142", "Proje_Show", "Proje") { vueRouteName = "form-PROJE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROJE_NEW = new NavigationLocation("PROJECTO50142", "Proje_New", "Proje") { vueRouteName = "form-PROJE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROJE_EDIT = new NavigationLocation("PROJECTO50142", "Proje_Edit", "Proje") { vueRouteName = "form-PROJE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROJE_DUPLICATE = new NavigationLocation("PROJECTO50142", "Proje_Duplicate", "Proje") { vueRouteName = "form-PROJE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROJE_DELETE = new NavigationLocation("PROJECTO50142", "Proje_Delete", "Proje") { vueRouteName = "form-PROJE", mode = "DELETE" };

		#endregion

		#region Proje private

		private void FormHistoryLimits_Proje()
		{

		}

		#endregion

		public ActionResult Proje_ModalDBEdit()
		{
			Proje_ViewModel model = new Proje_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Proje_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROJE]/

		[HttpPost]
		public ActionResult Proje_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proje_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proje_Show_GET",
				AreaName = "proje",
				Location = ACTION_PROJE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proje();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROJE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Proje_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROJE]/
		[HttpPost]
		public ActionResult Proje_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Proje_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proje_New_GET",
				AreaName = "proje",
				FormName = "PROJE",
				Location = ACTION_PROJE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Proje();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROJE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Proje/Proje_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROJE]/
		[HttpPost]
		public ActionResult Proje_New([FromBody]Proje_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proje_New",
				ViewName = "Proje",
				AreaName = "proje",
				Location = ACTION_PROJE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROJE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROJE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROJE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Proje_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROJE]/
		[HttpPost]
		public ActionResult Proje_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proje_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proje_Edit_GET",
				AreaName = "proje",
				FormName = "PROJE",
				Location = ACTION_PROJE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proje();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROJE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Proje/Proje_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROJE]/
		[HttpPost]
		public ActionResult Proje_Edit([FromBody]Proje_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proje_Edit",
				ViewName = "Proje",
				AreaName = "proje",
				Location = ACTION_PROJE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROJE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROJE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROJE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Proje_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROJE]/
		[HttpPost]
		public ActionResult Proje_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proje_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proje_Delete_GET",
				AreaName = "proje",
				FormName = "PROJE",
				Location = ACTION_PROJE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proje();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROJE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Proje/Proje_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROJE]/
		[HttpPost]
		public ActionResult Proje_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proje_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Proje_Delete",
				ViewName = "Proje",
				AreaName = "proje",
				Location = ACTION_PROJE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROJE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Proje_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROJE");
		}

		#endregion

		#region Proje_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROJE]/

		[HttpPost]
		public ActionResult Proje_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Proje_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proje_Duplicate_GET",
				AreaName = "proje",
				FormName = "PROJE",
				Location = ACTION_PROJE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROJE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Proje/Proje_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROJE]/
		[HttpPost]
		public ActionResult Proje_Duplicate([FromBody]Proje_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proje_Duplicate",
				ViewName = "Proje",
				AreaName = "proje",
				Location = ACTION_PROJE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROJE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROJE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROJE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Proje_Cancel

		//
		// GET: /Proje/Proje_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROJE]/
		public ActionResult Proje_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Proje(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("proje");

// USE /[MANUAL GQT BEFORE_CANCEL PROJE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROJE]/

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

				Navigation.SetValue("ForcePrimaryRead_proje", "true", true);
			}

			Navigation.ClearValue("proje");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Proje Multiform actions

		//
		// GET /Proje/MFProje_New
		[HttpGet]
		[ActionName("MFProje_New")]
		public ActionResult MFProje_New()
		{
			var model = new Proje_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PROJE_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("proje", model.ValCodproje);

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
		public ActionResult MFProje_New_GET()
		{
			return MFProje_New();
		}

		//
		// GET /Proje/MFProje_Edit
		[HttpGet]
		[ActionName("MFProje_Edit")]
		public ActionResult MFProje_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PROJE", "EDIT", new { id = id, partialView = "MFProje", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFProje_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFProje_Edit(requestModel);
		}

		//
		// GET /Proje/MFProje_Cancel
		[ActionName("MFProje_Cancel")]
		public ActionResult MFProje_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Proje(UserContext.Current);
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
		// POST /Proje/MFProje_Save
		[HttpPost]
		[ActionName("MFProje_Save")]
		public JsonResult MFProje_Save(Proje_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFProje_Save",
				ViewName = "MFProje",
				AreaName = "proje"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Proje/MFProje_Delete
		[HttpPost]
		[ActionName("MFProje_Delete")]
		public JsonResult MFProje_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFProje_Delete",
				ViewName = "MFProje",
				AreaName = "proje",
				Location = ACTION_PROJE_EDIT
			};

			var model = new Proje_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Proje/Proje_Year1ValYear
		// POST: /Proje/Proje_Year1ValYear
		[ActionName("Proje_Year1ValYear")]
		public ActionResult Proje_Year1ValYear([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_year1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_year1");
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

			IsStateReadonly = true;
			Proje_Year1ValYear_ViewModel model = new Proje_Year1ValYear_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodproje = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Proje/Proje_ValDespesas
		// POST: /Proje/Proje_ValDespesas
		[ActionName("Proje_ValDespesas")]
		public ActionResult Proje_ValDespesas([FromBody]RequestLookupModel requestModel)
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

			Proje_ValDespesas_ViewModel model = new Proje_ValDespesas_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodproje = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Proje/Proje_ValAgregado
		// POST: /Proje/Proje_ValAgregado
		[ActionName("Proje_ValAgregado")]
		public ActionResult Proje_ValAgregado([FromBody]RequestLookupModel requestModel)
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

			Proje_ValAgregado_ViewModel model = new Proje_ValAgregado_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodproje = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Proje/Proje_SaveEdit
		[HttpPost]
		public ActionResult Proje_SaveEdit([FromBody]Proje_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proje_SaveEdit",
				ViewName = "Proje",
				AreaName = "proje",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROJE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROJE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
