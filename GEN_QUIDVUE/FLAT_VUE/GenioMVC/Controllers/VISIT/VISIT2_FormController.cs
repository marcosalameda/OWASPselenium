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
using GenioMVC.ViewModels.Visit;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER VISIT]/

namespace GenioMVC.Controllers
{
	public partial class VisitController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VISIT2_CANCEL = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Cancel", "Visit") { vueRouteName = "form-VISIT2", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VISIT2_SHOW = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Show", "Visit") { vueRouteName = "form-VISIT2", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VISIT2_NEW = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_New", "Visit") { vueRouteName = "form-VISIT2", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VISIT2_EDIT = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Edit", "Visit") { vueRouteName = "form-VISIT2", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VISIT2_DUPLICATE = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Duplicate", "Visit") { vueRouteName = "form-VISIT2", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VISIT2_DELETE = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Delete", "Visit") { vueRouteName = "form-VISIT2", mode = "DELETE" };

		#endregion

		#region Visit2 private

		private void FormHistoryLimits_Visit2()
		{

		}

		#endregion

		public ActionResult Visit2_ModalDBEdit()
		{
			Visit2_ViewModel model = new Visit2_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Visit2_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VISIT2]/

		[HttpPost]
		public ActionResult Visit2_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit2_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Show_GET",
				AreaName = "visit",
				Location = ACTION_VISIT2_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Visit2();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VISIT2]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Visit2_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VISIT2]/
		[HttpPost]
		public ActionResult Visit2_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Visit2_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_New_GET",
				AreaName = "visit",
				FormName = "VISIT2",
				Location = ACTION_VISIT2_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Visit2();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VISIT2]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Visit/Visit2_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VISIT2]/
		[HttpPost]
		public ActionResult Visit2_New([FromBody]Visit2_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_New",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VISIT2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VISIT2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VISIT2]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Visit2_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VISIT2]/
		[HttpPost]
		public ActionResult Visit2_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit2_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Edit_GET",
				AreaName = "visit",
				FormName = "VISIT2",
				Location = ACTION_VISIT2_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Visit2();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VISIT2]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Visit/Visit2_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VISIT2]/
		[HttpPost]
		public ActionResult Visit2_Edit([FromBody]Visit2_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Edit",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VISIT2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VISIT2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VISIT2]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Visit2_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VISIT2]/
		[HttpPost]
		public ActionResult Visit2_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit2_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Delete_GET",
				AreaName = "visit",
				FormName = "VISIT2",
				Location = ACTION_VISIT2_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Visit2();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VISIT2]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Visit/Visit2_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VISIT2]/
		[HttpPost]
		public ActionResult Visit2_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit2_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Delete",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VISIT2]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Visit2_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VISIT2");
		}

		#endregion

		#region Visit2_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VISIT2]/

		[HttpPost]
		public ActionResult Visit2_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Visit2_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Duplicate_GET",
				AreaName = "visit",
				FormName = "VISIT2",
				Location = ACTION_VISIT2_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VISIT2]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Visit/Visit2_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VISIT2]/
		[HttpPost]
		public ActionResult Visit2_Duplicate([FromBody]Visit2_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Duplicate",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VISIT2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VISIT2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VISIT2]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Visit2_Cancel

		//
		// GET: /Visit/Visit2_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VISIT2]/
		public ActionResult Visit2_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Visit(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("visit");

// USE /[MANUAL GQT BEFORE_CANCEL VISIT2]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VISIT2]/

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

				Navigation.SetValue("ForcePrimaryRead_visit", "true", true);
			}

			Navigation.ClearValue("visit");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Visit2 Multiform actions

		//
		// GET /Visit/MFVisit2_New
		[HttpGet]
		[ActionName("MFVisit2_New")]
		public ActionResult MFVisit2_New()
		{
			var model = new Visit2_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VISIT2_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("visit", model.ValCodvisit);

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
		public ActionResult MFVisit2_New_GET()
		{
			return MFVisit2_New();
		}

		//
		// GET /Visit/MFVisit2_Edit
		[HttpGet]
		[ActionName("MFVisit2_Edit")]
		public ActionResult MFVisit2_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VISIT2", "EDIT", new { id = id, partialView = "MFVisit2", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVisit2_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVisit2_Edit(requestModel);
		}

		//
		// GET /Visit/MFVisit2_Cancel
		[ActionName("MFVisit2_Cancel")]
		public ActionResult MFVisit2_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Visit(UserContext.Current);
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
		// POST /Visit/MFVisit2_Save
		[HttpPost]
		[ActionName("MFVisit2_Save")]
		public JsonResult MFVisit2_Save(Visit2_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVisit2_Save",
				ViewName = "MFVisit2",
				AreaName = "visit"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Visit/MFVisit2_Delete
		[HttpPost]
		[ActionName("MFVisit2_Delete")]
		public JsonResult MFVisit2_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVisit2_Delete",
				ViewName = "MFVisit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_EDIT
			};

			var model = new Visit2_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Visit/Visit2_EquipValRegistnr
		// POST: /Visit/Visit2_EquipValRegistnr
		[ActionName("Visit2_EquipValRegistnr")]
		public ActionResult Visit2_EquipValRegistnr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
			Visit2_EquipValRegistnr_ViewModel model = new Visit2_EquipValRegistnr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodvisit = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Visit/Visit2_SaveEdit
		[HttpPost]
		public ActionResult Visit2_SaveEdit([FromBody]Visit2_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_SaveEdit",
				ViewName = "Visit2",
				AreaName = "visit",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VISIT2]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
