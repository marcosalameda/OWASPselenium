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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CAMPO_CANCEL = new NavigationLocation("LISTA_DE_CAMPO62169", "Campo_Cancel", "Flds") { vueRouteName = "form-CAMPO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CAMPO_SHOW = new NavigationLocation("LISTA_DE_CAMPO62169", "Campo_Show", "Flds") { vueRouteName = "form-CAMPO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CAMPO_NEW = new NavigationLocation("LISTA_DE_CAMPO62169", "Campo_New", "Flds") { vueRouteName = "form-CAMPO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CAMPO_EDIT = new NavigationLocation("LISTA_DE_CAMPO62169", "Campo_Edit", "Flds") { vueRouteName = "form-CAMPO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CAMPO_DUPLICATE = new NavigationLocation("LISTA_DE_CAMPO62169", "Campo_Duplicate", "Flds") { vueRouteName = "form-CAMPO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CAMPO_DELETE = new NavigationLocation("LISTA_DE_CAMPO62169", "Campo_Delete", "Flds") { vueRouteName = "form-CAMPO", mode = "DELETE" };

		#endregion

		#region Campo private

		private void FormHistoryLimits_Campo()
		{

		}

		#endregion

		public ActionResult Campo_ModalDBEdit()
		{
			Campo_ViewModel model = new Campo_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Campo_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CAMPO]/

		[HttpPost]
		public ActionResult Campo_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Campo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Campo_Show_GET",
				AreaName = "flds",
				Location = ACTION_CAMPO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Campo();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CAMPO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Campo_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CAMPO]/
		[HttpPost]
		public ActionResult Campo_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Campo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Campo_New_GET",
				AreaName = "flds",
				FormName = "CAMPO",
				Location = ACTION_CAMPO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Campo();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CAMPO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Flds/Campo_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CAMPO]/
		[HttpPost]
		public ActionResult Campo_New([FromBody]Campo_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Campo_New",
				ViewName = "Campo",
				AreaName = "flds",
				Location = ACTION_CAMPO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CAMPO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CAMPO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CAMPO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Campo_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CAMPO]/
		[HttpPost]
		public ActionResult Campo_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Campo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Campo_Edit_GET",
				AreaName = "flds",
				FormName = "CAMPO",
				Location = ACTION_CAMPO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Campo();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CAMPO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Flds/Campo_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CAMPO]/
		[HttpPost]
		public ActionResult Campo_Edit([FromBody]Campo_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Campo_Edit",
				ViewName = "Campo",
				AreaName = "flds",
				Location = ACTION_CAMPO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CAMPO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CAMPO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CAMPO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Campo_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CAMPO]/
		[HttpPost]
		public ActionResult Campo_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Campo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Campo_Delete_GET",
				AreaName = "flds",
				FormName = "CAMPO",
				Location = ACTION_CAMPO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Campo();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CAMPO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Flds/Campo_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CAMPO]/
		[HttpPost]
		public ActionResult Campo_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Campo_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Campo_Delete",
				ViewName = "Campo",
				AreaName = "flds",
				Location = ACTION_CAMPO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CAMPO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Campo_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CAMPO");
		}

		#endregion

		#region Campo_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CAMPO]/

		[HttpPost]
		public ActionResult Campo_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Campo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Campo_Duplicate_GET",
				AreaName = "flds",
				FormName = "CAMPO",
				Location = ACTION_CAMPO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CAMPO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Flds/Campo_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CAMPO]/
		[HttpPost]
		public ActionResult Campo_Duplicate([FromBody]Campo_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Campo_Duplicate",
				ViewName = "Campo",
				AreaName = "flds",
				Location = ACTION_CAMPO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CAMPO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CAMPO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CAMPO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Campo_Cancel

		//
		// GET: /Flds/Campo_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CAMPO]/
		public ActionResult Campo_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Flds(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("flds");

// USE /[MANUAL GQT BEFORE_CANCEL CAMPO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CAMPO]/

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

				Navigation.SetValue("ForcePrimaryRead_flds", "true", true);
			}

			Navigation.ClearValue("flds");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Campo Multiform actions

		//
		// GET /Flds/MFCampo_New
		[HttpGet]
		[ActionName("MFCampo_New")]
		public ActionResult MFCampo_New()
		{
			var model = new Campo_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_CAMPO_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("flds", model.ValCodflds);

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
		public ActionResult MFCampo_New_GET()
		{
			return MFCampo_New();
		}

		//
		// GET /Flds/MFCampo_Edit
		[HttpGet]
		[ActionName("MFCampo_Edit")]
		public ActionResult MFCampo_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("CAMPO", "EDIT", new { id = id, partialView = "MFCampo", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFCampo_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFCampo_Edit(requestModel);
		}

		//
		// GET /Flds/MFCampo_Cancel
		[ActionName("MFCampo_Cancel")]
		public ActionResult MFCampo_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Flds(UserContext.Current);
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
		// POST /Flds/MFCampo_Save
		[HttpPost]
		[ActionName("MFCampo_Save")]
		public JsonResult MFCampo_Save(Campo_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFCampo_Save",
				ViewName = "MFCampo",
				AreaName = "flds"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Flds/MFCampo_Delete
		[HttpPost]
		[ActionName("MFCampo_Delete")]
		public JsonResult MFCampo_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFCampo_Delete",
				ViewName = "MFCampo",
				AreaName = "flds",
				Location = ACTION_CAMPO_EDIT
			};

			var model = new Campo_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Flds/Campo_AeroValName
		// POST: /Flds/Campo_AeroValName
		[ActionName("Campo_AeroValName")]
		public ActionResult Campo_AeroValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_aero")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_aero");
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
			Campo_AeroValName_ViewModel model = new Campo_AeroValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodflds = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Flds/Campo_SaveEdit
		[HttpPost]
		public ActionResult Campo_SaveEdit([FromBody]Campo_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Campo_SaveEdit",
				ViewName = "Campo",
				AreaName = "flds",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CAMPO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CAMPO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
