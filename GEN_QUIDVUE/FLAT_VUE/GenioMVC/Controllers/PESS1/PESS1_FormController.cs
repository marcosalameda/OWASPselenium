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
using GenioMVC.ViewModels.Pess1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESS1]/

namespace GenioMVC.Controllers
{
	public partial class Pess1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PESS1_CANCEL = new NavigationLocation("COMODANTE63029", "Pess1_Cancel", "Pess1") { vueRouteName = "form-PESS1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESS1_SHOW = new NavigationLocation("COMODANTE63029", "Pess1_Show", "Pess1") { vueRouteName = "form-PESS1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESS1_NEW = new NavigationLocation("COMODANTE63029", "Pess1_New", "Pess1") { vueRouteName = "form-PESS1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESS1_EDIT = new NavigationLocation("COMODANTE63029", "Pess1_Edit", "Pess1") { vueRouteName = "form-PESS1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESS1_DUPLICATE = new NavigationLocation("COMODANTE63029", "Pess1_Duplicate", "Pess1") { vueRouteName = "form-PESS1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESS1_DELETE = new NavigationLocation("COMODANTE63029", "Pess1_Delete", "Pess1") { vueRouteName = "form-PESS1", mode = "DELETE" };

		#endregion

		#region Pess1 private

		private void FormHistoryLimits_Pess1()
		{

		}

		#endregion

		public ActionResult Pess1_ModalDBEdit()
		{
			Pess1_ViewModel model = new Pess1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Pess1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESS1]/

		[HttpPost]
		public ActionResult Pess1_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Show_GET",
				AreaName = "pess1",
				Location = ACTION_PESS1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESS1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pess1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESS1]/
		[HttpPost]
		public ActionResult Pess1_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_New_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESS1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pess1/Pess1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_New([FromBody]Pess1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_New",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESS1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESS1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESS1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pess1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESS1]/
		[HttpPost]
		public ActionResult Pess1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Edit_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESS1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pess1/Pess1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_Edit([FromBody]Pess1_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Edit",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESS1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESS1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESS1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pess1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESS1]/
		[HttpPost]
		public ActionResult Pess1_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Delete_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESS1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pess1/Pess1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Delete",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESS1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pess1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESS1");
		}

		#endregion

		#region Pess1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESS1]/

		[HttpPost]
		public ActionResult Pess1_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Duplicate_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESS1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pess1/Pess1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_Duplicate([FromBody]Pess1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Duplicate",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESS1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESS1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESS1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pess1_Cancel

		//
		// GET: /Pess1/Pess1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESS1]/
		public ActionResult Pess1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pess1(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pess1");

// USE /[MANUAL GQT BEFORE_CANCEL PESS1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESS1]/

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

				Navigation.SetValue("ForcePrimaryRead_pess1", "true", true);
			}

			Navigation.ClearValue("pess1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Pess1 Multiform actions

		//
		// GET /Pess1/MFPess1_New
		[HttpGet]
		[ActionName("MFPess1_New")]
		public ActionResult MFPess1_New()
		{
			var model = new Pess1_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PESS1_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("pess1", model.ValCodpesso);

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
		public ActionResult MFPess1_New_GET()
		{
			return MFPess1_New();
		}

		//
		// GET /Pess1/MFPess1_Edit
		[HttpGet]
		[ActionName("MFPess1_Edit")]
		public ActionResult MFPess1_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PESS1", "EDIT", new { id = id, partialView = "MFPess1", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFPess1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFPess1_Edit(requestModel);
		}

		//
		// GET /Pess1/MFPess1_Cancel
		[ActionName("MFPess1_Cancel")]
		public ActionResult MFPess1_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Pess1(UserContext.Current);
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
		// POST /Pess1/MFPess1_Save
		[HttpPost]
		[ActionName("MFPess1_Save")]
		public JsonResult MFPess1_Save(Pess1_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPess1_Save",
				ViewName = "MFPess1",
				AreaName = "pess1"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Pess1/MFPess1_Delete
		[HttpPost]
		[ActionName("MFPess1_Delete")]
		public JsonResult MFPess1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFPess1_Delete",
				ViewName = "MFPess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_EDIT
			};

			var model = new Pess1_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Pess1/Pess1_CmpnyValDesignat
		// POST: /Pess1/Pess1_CmpnyValDesignat
		[ActionName("Pess1_CmpnyValDesignat")]
		public ActionResult Pess1_CmpnyValDesignat([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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
			Pess1_CmpnyValDesignat_ViewModel model = new Pess1_CmpnyValDesignat_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pess1/Pess1_StakeValDesignat
		// POST: /Pess1/Pess1_StakeValDesignat
		[ActionName("Pess1_StakeValDesignat")]
		public ActionResult Pess1_StakeValDesignat([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_stake")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_stake");
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
			Pess1_StakeValDesignat_ViewModel model = new Pess1_StakeValDesignat_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpesso = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Pess1/Pess1_SaveEdit
		[HttpPost]
		public ActionResult Pess1_SaveEdit([FromBody]Pess1_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_SaveEdit",
				ViewName = "Pess1",
				AreaName = "pess1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESS1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
