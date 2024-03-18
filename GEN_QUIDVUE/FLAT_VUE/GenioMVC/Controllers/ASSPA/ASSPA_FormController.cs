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
using GenioMVC.ViewModels.Asspa;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSPA]/

namespace GenioMVC.Controllers
{
	public partial class AsspaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ASSPA_CANCEL = new NavigationLocation("ASSET_PARAMETER22072", "Asspa_Cancel", "Asspa") { vueRouteName = "form-ASSPA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ASSPA_SHOW = new NavigationLocation("ASSET_PARAMETER22072", "Asspa_Show", "Asspa") { vueRouteName = "form-ASSPA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ASSPA_NEW = new NavigationLocation("ASSET_PARAMETER22072", "Asspa_New", "Asspa") { vueRouteName = "form-ASSPA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ASSPA_EDIT = new NavigationLocation("ASSET_PARAMETER22072", "Asspa_Edit", "Asspa") { vueRouteName = "form-ASSPA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ASSPA_DUPLICATE = new NavigationLocation("ASSET_PARAMETER22072", "Asspa_Duplicate", "Asspa") { vueRouteName = "form-ASSPA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ASSPA_DELETE = new NavigationLocation("ASSET_PARAMETER22072", "Asspa_Delete", "Asspa") { vueRouteName = "form-ASSPA", mode = "DELETE" };

		#endregion

		#region Asspa private

		private void FormHistoryLimits_Asspa()
		{

		}

		#endregion

		public ActionResult Asspa_ModalDBEdit()
		{
			Asspa_ViewModel model = new Asspa_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Asspa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ASSPA]/

		[HttpPost]
		public ActionResult Asspa_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Asspa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Show_GET",
				AreaName = "asspa",
				Location = ACTION_ASSPA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ASSPA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Asspa_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ASSPA]/
		[HttpPost]
		public ActionResult Asspa_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Asspa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_New_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ASSPA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Asspa/Asspa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_New([FromBody]Asspa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_New",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ASSPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ASSPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ASSPA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Asspa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Asspa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Edit_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ASSPA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Asspa/Asspa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Edit([FromBody]Asspa_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Edit",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ASSPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ASSPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ASSPA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Asspa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Asspa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Delete_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ASSPA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Asspa/Asspa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Asspa_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Delete",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ASSPA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Asspa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ASSPA");
		}

		#endregion

		#region Asspa_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ASSPA]/

		[HttpPost]
		public ActionResult Asspa_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Asspa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Duplicate_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ASSPA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Asspa/Asspa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Duplicate([FromBody]Asspa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_Duplicate",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ASSPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ASSPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ASSPA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Asspa_Cancel

		//
		// GET: /Asspa/Asspa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ASSPA]/
		public ActionResult Asspa_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Asspa(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("asspa");

// USE /[MANUAL GQT BEFORE_CANCEL ASSPA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ASSPA]/

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

				Navigation.SetValue("ForcePrimaryRead_asspa", "true", true);
			}

			Navigation.ClearValue("asspa");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Asspa Multiform actions

		//
		// GET /Asspa/MFAsspa_New
		[HttpGet]
		[ActionName("MFAsspa_New")]
		public ActionResult MFAsspa_New()
		{
			var model = new Asspa_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ASSPA_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("asspa", model.ValCodasspa);

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
		public ActionResult MFAsspa_New_GET()
		{
			return MFAsspa_New();
		}

		//
		// GET /Asspa/MFAsspa_Edit
		[HttpGet]
		[ActionName("MFAsspa_Edit")]
		public ActionResult MFAsspa_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ASSPA", "EDIT", new { id = id, partialView = "MFAsspa", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFAsspa_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFAsspa_Edit(requestModel);
		}

		//
		// GET /Asspa/MFAsspa_Cancel
		[ActionName("MFAsspa_Cancel")]
		public ActionResult MFAsspa_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Asspa(UserContext.Current);
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
		// POST /Asspa/MFAsspa_Save
		[HttpPost]
		[ActionName("MFAsspa_Save")]
		public JsonResult MFAsspa_Save(Asspa_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFAsspa_Save",
				ViewName = "MFAsspa",
				AreaName = "asspa"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Asspa/MFAsspa_Delete
		[HttpPost]
		[ActionName("MFAsspa_Delete")]
		public JsonResult MFAsspa_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFAsspa_Delete",
				ViewName = "MFAsspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_EDIT
			};

			var model = new Asspa_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Asspa/Asspa_AssetValName
		// POST: /Asspa/Asspa_AssetValName
		[ActionName("Asspa_AssetValName")]
		public ActionResult Asspa_AssetValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asset")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asset");
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
			Asspa_AssetValName_ViewModel model = new Asspa_AssetValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasspa = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Asspa/Asspa_ParamValParameter
		// POST: /Asspa/Asspa_ParamValParameter
		[ActionName("Asspa_ParamValParameter")]
		public ActionResult Asspa_ParamValParameter([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_param")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_param");
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
			Asspa_ParamValParameter_ViewModel model = new Asspa_ParamValParameter_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodasspa = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Asspa/Asspa_SaveEdit
		[HttpPost]
		public ActionResult Asspa_SaveEdit([FromBody]Asspa_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Asspa_SaveEdit",
				ViewName = "Asspa",
				AreaName = "asspa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ASSPA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
