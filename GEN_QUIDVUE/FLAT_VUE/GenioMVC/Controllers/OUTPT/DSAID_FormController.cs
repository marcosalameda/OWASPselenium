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
using GenioMVC.ViewModels.Outpt;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER OUTPT]/

namespace GenioMVC.Controllers
{
	public partial class OutptController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DSAID_CANCEL = new NavigationLocation("OUTPUT_DOCUMENT44972", "Dsaid_Cancel", "Outpt") { vueRouteName = "form-DSAID", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DSAID_SHOW = new NavigationLocation("OUTPUT_DOCUMENT44972", "Dsaid_Show", "Outpt") { vueRouteName = "form-DSAID", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DSAID_NEW = new NavigationLocation("OUTPUT_DOCUMENT44972", "Dsaid_New", "Outpt") { vueRouteName = "form-DSAID", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DSAID_EDIT = new NavigationLocation("OUTPUT_DOCUMENT44972", "Dsaid_Edit", "Outpt") { vueRouteName = "form-DSAID", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DSAID_DUPLICATE = new NavigationLocation("OUTPUT_DOCUMENT44972", "Dsaid_Duplicate", "Outpt") { vueRouteName = "form-DSAID", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DSAID_DELETE = new NavigationLocation("OUTPUT_DOCUMENT44972", "Dsaid_Delete", "Outpt") { vueRouteName = "form-DSAID", mode = "DELETE" };

		#endregion

		#region Dsaid private

		private void FormHistoryLimits_Dsaid()
		{

		}

		#endregion

		public ActionResult Dsaid_ModalDBEdit()
		{
			Dsaid_ViewModel model = new Dsaid_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Dsaid_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DSAID]/

		[HttpPost]
		public ActionResult Dsaid_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dsaid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Show_GET",
				AreaName = "outpt",
				Location = ACTION_DSAID_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dsaid();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DSAID]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dsaid_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DSAID]/
		[HttpPost]
		public ActionResult Dsaid_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Dsaid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_New_GET",
				AreaName = "outpt",
				FormName = "DSAID",
				Location = ACTION_DSAID_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dsaid();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DSAID]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Outpt/Dsaid_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DSAID]/
		[HttpPost]
		public ActionResult Dsaid_New([FromBody]Dsaid_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_New",
				ViewName = "Dsaid",
				AreaName = "outpt",
				Location = ACTION_DSAID_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DSAID]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DSAID]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DSAID]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dsaid_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DSAID]/
		[HttpPost]
		public ActionResult Dsaid_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dsaid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Edit_GET",
				AreaName = "outpt",
				FormName = "DSAID",
				Location = ACTION_DSAID_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dsaid();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DSAID]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Outpt/Dsaid_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DSAID]/
		[HttpPost]
		public ActionResult Dsaid_Edit([FromBody]Dsaid_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Edit",
				ViewName = "Dsaid",
				AreaName = "outpt",
				Location = ACTION_DSAID_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DSAID]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DSAID]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DSAID]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dsaid_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DSAID]/
		[HttpPost]
		public ActionResult Dsaid_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dsaid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Delete_GET",
				AreaName = "outpt",
				FormName = "DSAID",
				Location = ACTION_DSAID_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dsaid();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DSAID]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Outpt/Dsaid_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DSAID]/
		[HttpPost]
		public ActionResult Dsaid_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dsaid_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Delete",
				ViewName = "Dsaid",
				AreaName = "outpt",
				Location = ACTION_DSAID_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DSAID]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dsaid_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DSAID");
		}

		#endregion

		#region Dsaid_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DSAID]/

		[HttpPost]
		public ActionResult Dsaid_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Dsaid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Duplicate_GET",
				AreaName = "outpt",
				FormName = "DSAID",
				Location = ACTION_DSAID_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DSAID]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Outpt/Dsaid_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DSAID]/
		[HttpPost]
		public ActionResult Dsaid_Duplicate([FromBody]Dsaid_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_Duplicate",
				ViewName = "Dsaid",
				AreaName = "outpt",
				Location = ACTION_DSAID_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DSAID]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DSAID]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DSAID]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dsaid_Cancel

		//
		// GET: /Outpt/Dsaid_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DSAID]/
		public ActionResult Dsaid_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Outpt(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("outpt");

// USE /[MANUAL GQT BEFORE_CANCEL DSAID]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DSAID]/

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

				Navigation.SetValue("ForcePrimaryRead_outpt", "true", true);
			}

			Navigation.ClearValue("outpt");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Dsaid Multiform actions

		//
		// GET /Outpt/MFDsaid_New
		[HttpGet]
		[ActionName("MFDsaid_New")]
		public ActionResult MFDsaid_New()
		{
			var model = new Dsaid_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_DSAID_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("outpt", model.ValCodoutpt);

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
		public ActionResult MFDsaid_New_GET()
		{
			return MFDsaid_New();
		}

		//
		// GET /Outpt/MFDsaid_Edit
		[HttpGet]
		[ActionName("MFDsaid_Edit")]
		public ActionResult MFDsaid_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("DSAID", "EDIT", new { id = id, partialView = "MFDsaid", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFDsaid_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFDsaid_Edit(requestModel);
		}

		//
		// GET /Outpt/MFDsaid_Cancel
		[ActionName("MFDsaid_Cancel")]
		public ActionResult MFDsaid_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Outpt(UserContext.Current);
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
		// POST /Outpt/MFDsaid_Save
		[HttpPost]
		[ActionName("MFDsaid_Save")]
		public JsonResult MFDsaid_Save(Dsaid_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFDsaid_Save",
				ViewName = "MFDsaid",
				AreaName = "outpt"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Outpt/MFDsaid_Delete
		[HttpPost]
		[ActionName("MFDsaid_Delete")]
		public JsonResult MFDsaid_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFDsaid_Delete",
				ViewName = "MFDsaid",
				AreaName = "outpt",
				Location = ACTION_DSAID_EDIT
			};

			var model = new Dsaid_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Outpt/Dsaid_Ware1ValWarehdes
		// POST: /Outpt/Dsaid_Ware1ValWarehdes
		[ActionName("Dsaid_Ware1ValWarehdes")]
		public ActionResult Dsaid_Ware1ValWarehdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_ware1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_ware1");
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
			Dsaid_Ware1ValWarehdes_ViewModel model = new Dsaid_Ware1ValWarehdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodoutpt = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Outpt/Dsaid_ValSaidas
		// POST: /Outpt/Dsaid_ValSaidas
		[ActionName("Dsaid_ValSaidas")]
		public ActionResult Dsaid_ValSaidas([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = -1;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_outpu")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_outpu");
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

			Dsaid_ValSaidas_ViewModel model = new Dsaid_ValSaidas_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodoutpt = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		[ActionName("ReorderDsaid_ValSaidas")]
		public ActionResult ReorderDsaid_ValSaidas([FromBody]RequestReorderModel requestModel)
		{
			var id = requestModel.Id;
			var position = requestModel.Position.ToString();

			Dsaid_ValSaidas_ViewModel model = new Dsaid_ValSaidas_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodoutpt = Navigation.GetStrValue("outpt");
			model.Reorder(id, position);
			model.Load(-1);

			return JsonOK(model);
		}

		// POST: /Outpt/Dsaid_SaveEdit
		[HttpPost]
		public ActionResult Dsaid_SaveEdit([FromBody]Dsaid_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dsaid_SaveEdit",
				ViewName = "Dsaid",
				AreaName = "outpt",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DSAID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DSAID]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
