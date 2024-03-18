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
using GenioMVC.ViewModels.Param;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PARAM]/

namespace GenioMVC.Controllers
{
	public partial class ParamController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PARAM_CANCEL = new NavigationLocation("PARAMETER41976", "Param_Cancel", "Param") { vueRouteName = "form-PARAM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PARAM_SHOW = new NavigationLocation("PARAMETER41976", "Param_Show", "Param") { vueRouteName = "form-PARAM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PARAM_NEW = new NavigationLocation("PARAMETER41976", "Param_New", "Param") { vueRouteName = "form-PARAM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PARAM_EDIT = new NavigationLocation("PARAMETER41976", "Param_Edit", "Param") { vueRouteName = "form-PARAM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PARAM_DUPLICATE = new NavigationLocation("PARAMETER41976", "Param_Duplicate", "Param") { vueRouteName = "form-PARAM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PARAM_DELETE = new NavigationLocation("PARAMETER41976", "Param_Delete", "Param") { vueRouteName = "form-PARAM", mode = "DELETE" };

		#endregion

		#region Param private

		private void FormHistoryLimits_Param()
		{

		}

		#endregion

		public ActionResult Param_ModalDBEdit()
		{
			Param_ViewModel model = new Param_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Param_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PARAM]/

		[HttpPost]
		public ActionResult Param_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Show_GET",
				AreaName = "param",
				Location = ACTION_PARAM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Param();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PARAM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Param_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PARAM]/
		[HttpPost]
		public ActionResult Param_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_New_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Param();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PARAM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Param/Param_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PARAM]/
		[HttpPost]
		public ActionResult Param_New([FromBody]Param_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_New",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PARAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PARAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PARAM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Param_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PARAM]/
		[HttpPost]
		public ActionResult Param_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Edit_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Param();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PARAM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Param/Param_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PARAM]/
		[HttpPost]
		public ActionResult Param_Edit([FromBody]Param_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_Edit",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PARAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PARAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PARAM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Param_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PARAM]/
		[HttpPost]
		public ActionResult Param_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Delete_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Param();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PARAM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Param/Param_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PARAM]/
		[HttpPost]
		public ActionResult Param_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Param_Delete",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PARAM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Param_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PARAM");
		}

		#endregion

		#region Param_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PARAM]/

		[HttpPost]
		public ActionResult Param_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Duplicate_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PARAM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Param/Param_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PARAM]/
		[HttpPost]
		public ActionResult Param_Duplicate([FromBody]Param_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_Duplicate",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PARAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PARAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PARAM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Param_Cancel

		//
		// GET: /Param/Param_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PARAM]/
		public ActionResult Param_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Param(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("param");

// USE /[MANUAL GQT BEFORE_CANCEL PARAM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PARAM]/

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

				Navigation.SetValue("ForcePrimaryRead_param", "true", true);
			}

			Navigation.ClearValue("param");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Param Multiform actions

		//
		// GET /Param/MFParam_New
		[HttpGet]
		[ActionName("MFParam_New")]
		public ActionResult MFParam_New()
		{
			var model = new Param_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PARAM_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("param", model.ValCodparam);

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
		public ActionResult MFParam_New_GET()
		{
			return MFParam_New();
		}

		//
		// GET /Param/MFParam_Edit
		[HttpGet]
		[ActionName("MFParam_Edit")]
		public ActionResult MFParam_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PARAM", "EDIT", new { id = id, partialView = "MFParam", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFParam_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFParam_Edit(requestModel);
		}

		//
		// GET /Param/MFParam_Cancel
		[ActionName("MFParam_Cancel")]
		public ActionResult MFParam_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Param(UserContext.Current);
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
		// POST /Param/MFParam_Save
		[HttpPost]
		[ActionName("MFParam_Save")]
		public JsonResult MFParam_Save(Param_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFParam_Save",
				ViewName = "MFParam",
				AreaName = "param"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Param/MFParam_Delete
		[HttpPost]
		[ActionName("MFParam_Delete")]
		public JsonResult MFParam_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFParam_Delete",
				ViewName = "MFParam",
				AreaName = "param",
				Location = ACTION_PARAM_EDIT
			};

			var model = new Param_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Param/Param_KindeValDesignat
		// POST: /Param/Param_KindeValDesignat
		[ActionName("Param_KindeValDesignat")]
		public ActionResult Param_KindeValDesignat([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
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
			Param_KindeValDesignat_ViewModel model = new Param_KindeValDesignat_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodparam = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Param/Param_SaveEdit
		[HttpPost]
		public ActionResult Param_SaveEdit([FromBody]Param_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_SaveEdit",
				ViewName = "Param",
				AreaName = "param",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PARAM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
