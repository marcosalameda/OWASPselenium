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
using GenioMVC.ViewModels.Kinde;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER KINDE]/

namespace GenioMVC.Controllers
{
	public partial class KindeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_KINDE_CANCEL = new NavigationLocation("KIND_OF_EQUIPMENT22928", "Kinde_Cancel", "Kinde") { vueRouteName = "form-KINDE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_KINDE_SHOW = new NavigationLocation("KIND_OF_EQUIPMENT22928", "Kinde_Show", "Kinde") { vueRouteName = "form-KINDE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_KINDE_NEW = new NavigationLocation("KIND_OF_EQUIPMENT22928", "Kinde_New", "Kinde") { vueRouteName = "form-KINDE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_KINDE_EDIT = new NavigationLocation("KIND_OF_EQUIPMENT22928", "Kinde_Edit", "Kinde") { vueRouteName = "form-KINDE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_KINDE_DUPLICATE = new NavigationLocation("KIND_OF_EQUIPMENT22928", "Kinde_Duplicate", "Kinde") { vueRouteName = "form-KINDE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_KINDE_DELETE = new NavigationLocation("KIND_OF_EQUIPMENT22928", "Kinde_Delete", "Kinde") { vueRouteName = "form-KINDE", mode = "DELETE" };

		#endregion

		#region Kinde private

		private void FormHistoryLimits_Kinde()
		{

		}

		#endregion

		public ActionResult Kinde_ModalDBEdit()
		{
			Kinde_ViewModel model = new Kinde_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Kinde_Show

// USE /[MANUAL GQT CONTROLLER_SHOW KINDE]/

		[HttpPost]
		public ActionResult Kinde_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Kinde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Show_GET",
				AreaName = "kinde",
				Location = ACTION_KINDE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Kinde();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW KINDE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Kinde_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET KINDE]/
		[HttpPost]
		public ActionResult Kinde_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Kinde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_New_GET",
				AreaName = "kinde",
				FormName = "KINDE",
				Location = ACTION_KINDE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Kinde();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW KINDE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Kinde/Kinde_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST KINDE]/
		[HttpPost]
		public ActionResult Kinde_New([FromBody]Kinde_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_New",
				ViewName = "Kinde",
				AreaName = "kinde",
				Location = ACTION_KINDE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW KINDE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX KINDE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX KINDE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Kinde_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET KINDE]/
		[HttpPost]
		public ActionResult Kinde_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Kinde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Edit_GET",
				AreaName = "kinde",
				FormName = "KINDE",
				Location = ACTION_KINDE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Kinde();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT KINDE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Kinde/Kinde_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST KINDE]/
		[HttpPost]
		public ActionResult Kinde_Edit([FromBody]Kinde_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Edit",
				ViewName = "Kinde",
				AreaName = "kinde",
				Location = ACTION_KINDE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT KINDE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX KINDE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX KINDE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Kinde_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET KINDE]/
		[HttpPost]
		public ActionResult Kinde_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Kinde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Delete_GET",
				AreaName = "kinde",
				FormName = "KINDE",
				Location = ACTION_KINDE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Kinde();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE KINDE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Kinde/Kinde_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST KINDE]/
		[HttpPost]
		public ActionResult Kinde_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Kinde_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Delete",
				ViewName = "Kinde",
				AreaName = "kinde",
				Location = ACTION_KINDE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE KINDE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Kinde_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("KINDE");
		}

		#endregion

		#region Kinde_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET KINDE]/

		[HttpPost]
		public ActionResult Kinde_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Kinde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Duplicate_GET",
				AreaName = "kinde",
				FormName = "KINDE",
				Location = ACTION_KINDE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE KINDE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Kinde/Kinde_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST KINDE]/
		[HttpPost]
		public ActionResult Kinde_Duplicate([FromBody]Kinde_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_Duplicate",
				ViewName = "Kinde",
				AreaName = "kinde",
				Location = ACTION_KINDE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE KINDE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX KINDE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX KINDE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Kinde_Cancel

		//
		// GET: /Kinde/Kinde_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET KINDE]/
		public ActionResult Kinde_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Kinde(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("kinde");

// USE /[MANUAL GQT BEFORE_CANCEL KINDE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL KINDE]/

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

				Navigation.SetValue("ForcePrimaryRead_kinde", "true", true);
			}

			Navigation.ClearValue("kinde");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Kinde Multiform actions

		//
		// GET /Kinde/MFKinde_New
		[HttpGet]
		[ActionName("MFKinde_New")]
		public ActionResult MFKinde_New()
		{
			var model = new Kinde_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_KINDE_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("kinde", model.ValCodkinde);

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
		public ActionResult MFKinde_New_GET()
		{
			return MFKinde_New();
		}

		//
		// GET /Kinde/MFKinde_Edit
		[HttpGet]
		[ActionName("MFKinde_Edit")]
		public ActionResult MFKinde_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("KINDE", "EDIT", new { id = id, partialView = "MFKinde", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFKinde_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFKinde_Edit(requestModel);
		}

		//
		// GET /Kinde/MFKinde_Cancel
		[ActionName("MFKinde_Cancel")]
		public ActionResult MFKinde_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Kinde(UserContext.Current);
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
		// POST /Kinde/MFKinde_Save
		[HttpPost]
		[ActionName("MFKinde_Save")]
		public JsonResult MFKinde_Save(Kinde_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFKinde_Save",
				ViewName = "MFKinde",
				AreaName = "kinde"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Kinde/MFKinde_Delete
		[HttpPost]
		[ActionName("MFKinde_Delete")]
		public JsonResult MFKinde_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFKinde_Delete",
				ViewName = "MFKinde",
				AreaName = "kinde",
				Location = ACTION_KINDE_EDIT
			};

			var model = new Kinde_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Kinde/Kinde_ValParamete
		// POST: /Kinde/Kinde_ValParamete
		[ActionName("Kinde_ValParamete")]
		public ActionResult Kinde_ValParamete([FromBody]RequestLookupModel requestModel)
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

			Kinde_ValParamete_ViewModel model = new Kinde_ValParamete_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodkinde = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Kinde/Kinde_ValManuals
		// POST: /Kinde/Kinde_ValManuals
		[ActionName("Kinde_ValManuals")]
		public ActionResult Kinde_ValManuals([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_manua")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_manua");
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

			Kinde_ValManuals_ViewModel model = new Kinde_ValManuals_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodkinde = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Kinde/Kinde_SaveEdit
		[HttpPost]
		public ActionResult Kinde_SaveEdit([FromBody]Kinde_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Kinde_SaveEdit",
				ViewName = "Kinde",
				AreaName = "kinde",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT KINDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT KINDE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
