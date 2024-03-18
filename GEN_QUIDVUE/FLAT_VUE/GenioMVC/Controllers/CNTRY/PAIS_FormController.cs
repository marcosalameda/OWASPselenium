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
using GenioMVC.ViewModels.Cntry;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CNTRY]/

namespace GenioMVC.Controllers
{
	public partial class CntryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PAIS_CANCEL = new NavigationLocation("COUNTRY64133", "Pais_Cancel", "Cntry") { vueRouteName = "form-PAIS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PAIS_SHOW = new NavigationLocation("COUNTRY64133", "Pais_Show", "Cntry") { vueRouteName = "form-PAIS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PAIS_NEW = new NavigationLocation("COUNTRY64133", "Pais_New", "Cntry") { vueRouteName = "form-PAIS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PAIS_EDIT = new NavigationLocation("COUNTRY64133", "Pais_Edit", "Cntry") { vueRouteName = "form-PAIS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PAIS_DUPLICATE = new NavigationLocation("COUNTRY64133", "Pais_Duplicate", "Cntry") { vueRouteName = "form-PAIS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PAIS_DELETE = new NavigationLocation("COUNTRY64133", "Pais_Delete", "Cntry") { vueRouteName = "form-PAIS", mode = "DELETE" };

		#endregion

		#region Pais private

		private void FormHistoryLimits_Pais()
		{

		}

		#endregion

		public ActionResult Pais_ModalDBEdit()
		{
			Pais_ViewModel model = new Pais_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Pais_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PAIS]/

		[HttpPost]
		public ActionResult Pais_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pais_Show_GET",
				AreaName = "cntry",
				Location = ACTION_PAIS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pais();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PAIS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pais_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PAIS]/
		[HttpPost]
		public ActionResult Pais_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pais_New_GET",
				AreaName = "cntry",
				FormName = "PAIS",
				Location = ACTION_PAIS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pais();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PAIS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cntry/Pais_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PAIS]/
		[HttpPost]
		public ActionResult Pais_New([FromBody]Pais_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pais_New",
				ViewName = "Pais",
				AreaName = "cntry",
				Location = ACTION_PAIS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PAIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PAIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PAIS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pais_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PAIS]/
		[HttpPost]
		public ActionResult Pais_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pais_Edit_GET",
				AreaName = "cntry",
				FormName = "PAIS",
				Location = ACTION_PAIS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pais();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PAIS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cntry/Pais_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PAIS]/
		[HttpPost]
		public ActionResult Pais_Edit([FromBody]Pais_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pais_Edit",
				ViewName = "Pais",
				AreaName = "cntry",
				Location = ACTION_PAIS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PAIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PAIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PAIS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pais_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PAIS]/
		[HttpPost]
		public ActionResult Pais_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pais_Delete_GET",
				AreaName = "cntry",
				FormName = "PAIS",
				Location = ACTION_PAIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pais();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PAIS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cntry/Pais_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PAIS]/
		[HttpPost]
		public ActionResult Pais_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pais_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pais_Delete",
				ViewName = "Pais",
				AreaName = "cntry",
				Location = ACTION_PAIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PAIS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pais_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PAIS");
		}

		#endregion

		#region Pais_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PAIS]/

		[HttpPost]
		public ActionResult Pais_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pais_Duplicate_GET",
				AreaName = "cntry",
				FormName = "PAIS",
				Location = ACTION_PAIS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PAIS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cntry/Pais_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PAIS]/
		[HttpPost]
		public ActionResult Pais_Duplicate([FromBody]Pais_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pais_Duplicate",
				ViewName = "Pais",
				AreaName = "cntry",
				Location = ACTION_PAIS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PAIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PAIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PAIS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pais_Cancel

		//
		// GET: /Cntry/Pais_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PAIS]/
		public ActionResult Pais_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cntry(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cntry");

// USE /[MANUAL GQT BEFORE_CANCEL PAIS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PAIS]/

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

				Navigation.SetValue("ForcePrimaryRead_cntry", "true", true);
			}

			Navigation.ClearValue("cntry");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Pais Multiform actions

		//
		// GET /Cntry/MFPais_New
		[HttpGet]
		[ActionName("MFPais_New")]
		public ActionResult MFPais_New()
		{
			var model = new Pais_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PAIS_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("cntry", model.ValCodcntry);

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
		public ActionResult MFPais_New_GET()
		{
			return MFPais_New();
		}

		//
		// GET /Cntry/MFPais_Edit
		[HttpGet]
		[ActionName("MFPais_Edit")]
		public ActionResult MFPais_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PAIS", "EDIT", new { id = id, partialView = "MFPais", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFPais_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFPais_Edit(requestModel);
		}

		//
		// GET /Cntry/MFPais_Cancel
		[ActionName("MFPais_Cancel")]
		public ActionResult MFPais_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Cntry(UserContext.Current);
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
		// POST /Cntry/MFPais_Save
		[HttpPost]
		[ActionName("MFPais_Save")]
		public JsonResult MFPais_Save(Pais_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPais_Save",
				ViewName = "MFPais",
				AreaName = "cntry"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Cntry/MFPais_Delete
		[HttpPost]
		[ActionName("MFPais_Delete")]
		public JsonResult MFPais_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFPais_Delete",
				ViewName = "MFPais",
				AreaName = "cntry",
				Location = ACTION_PAIS_EDIT
			};

			var model = new Pais_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Cntry/Pais_ValProprie1
		// POST: /Cntry/Pais_ValProprie1
		[ActionName("Pais_ValProprie1")]
		public ActionResult Pais_ValProprie1([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_propr");
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

			Pais_ValProprie1_ViewModel model = new Pais_ValProprie1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodcntry = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Cntry/Pais_ValPropried
		// POST: /Cntry/Pais_ValPropried
		[ActionName("Pais_ValPropried")]
		public ActionResult Pais_ValPropried([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_propr");
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

			Pais_ValPropried_ViewModel model = new Pais_ValPropried_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodcntry = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Cntry/Pais_SaveEdit
		[HttpPost]
		public ActionResult Pais_SaveEdit([FromBody]Pais_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pais_SaveEdit",
				ViewName = "Pais",
				AreaName = "cntry",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PAIS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
