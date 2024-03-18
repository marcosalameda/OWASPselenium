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
using GenioMVC.ViewModels.Glob;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GLOB]/

namespace GenioMVC.Controllers
{
	public partial class GlobController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GLOBFACT_CANCEL = new NavigationLocation("GLOBAL_PARAMETER43021", "Globfact_Cancel", "Glob") { vueRouteName = "form-GLOBFACT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GLOBFACT_SHOW = new NavigationLocation("GLOBAL_PARAMETER43021", "Globfact_Show", "Glob") { vueRouteName = "form-GLOBFACT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GLOBFACT_NEW = new NavigationLocation("GLOBAL_PARAMETER43021", "Globfact_New", "Glob") { vueRouteName = "form-GLOBFACT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GLOBFACT_EDIT = new NavigationLocation("GLOBAL_PARAMETER43021", "Globfact_Edit", "Glob") { vueRouteName = "form-GLOBFACT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GLOBFACT_DUPLICATE = new NavigationLocation("GLOBAL_PARAMETER43021", "Globfact_Duplicate", "Glob") { vueRouteName = "form-GLOBFACT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GLOBFACT_DELETE = new NavigationLocation("GLOBAL_PARAMETER43021", "Globfact_Delete", "Glob") { vueRouteName = "form-GLOBFACT", mode = "DELETE" };

		#endregion

		#region Globfact private

		private void FormHistoryLimits_Globfact()
		{

		}

		#endregion

		public ActionResult Globfact_ModalDBEdit()
		{
			Globfact_ViewModel model = new Globfact_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Globfact_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GLOBFACT]/

		[HttpPost]
		public ActionResult Globfact_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Globfact_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Show_GET",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GLOBFACT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Globfact_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Globfact_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_New_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GLOBFACT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Glob/Globfact_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_New([FromBody]Globfact_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_New",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GLOBFACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GLOBFACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GLOBFACT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Globfact_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Globfact_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Edit_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GLOBFACT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Glob/Globfact_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Edit([FromBody]Globfact_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Edit",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GLOBFACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GLOBFACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GLOBFACT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Globfact_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Globfact_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Delete_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GLOBFACT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Glob/Globfact_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Globfact_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Delete",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GLOBFACT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Globfact_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GLOBFACT");
		}

		#endregion

		#region Globfact_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GLOBFACT]/

		[HttpPost]
		public ActionResult Globfact_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Globfact_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Duplicate_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GLOBFACT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Glob/Globfact_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Duplicate([FromBody]Globfact_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_Duplicate",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GLOBFACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GLOBFACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GLOBFACT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Globfact_Cancel

		//
		// GET: /Glob/Globfact_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GLOBFACT]/
		public ActionResult Globfact_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Glob(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("glob");

// USE /[MANUAL GQT BEFORE_CANCEL GLOBFACT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GLOBFACT]/

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

				Navigation.SetValue("ForcePrimaryRead_glob", "true", true);
			}

			Navigation.ClearValue("glob");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Globfact Multiform actions

		//
		// GET /Glob/MFGlobfact_New
		[HttpGet]
		[ActionName("MFGlobfact_New")]
		public ActionResult MFGlobfact_New()
		{
			var model = new Globfact_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_GLOBFACT_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("glob", model.ValCodglob);

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
		public ActionResult MFGlobfact_New_GET()
		{
			return MFGlobfact_New();
		}

		//
		// GET /Glob/MFGlobfact_Edit
		[HttpGet]
		[ActionName("MFGlobfact_Edit")]
		public ActionResult MFGlobfact_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("GLOBFACT", "EDIT", new { id = id, partialView = "MFGlobfact", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFGlobfact_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFGlobfact_Edit(requestModel);
		}

		//
		// GET /Glob/MFGlobfact_Cancel
		[ActionName("MFGlobfact_Cancel")]
		public ActionResult MFGlobfact_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Glob(UserContext.Current);
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
		// POST /Glob/MFGlobfact_Save
		[HttpPost]
		[ActionName("MFGlobfact_Save")]
		public JsonResult MFGlobfact_Save(Globfact_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGlobfact_Save",
				ViewName = "MFGlobfact",
				AreaName = "glob"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Glob/MFGlobfact_Delete
		[HttpPost]
		[ActionName("MFGlobfact_Delete")]
		public JsonResult MFGlobfact_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFGlobfact_Delete",
				ViewName = "MFGlobfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_EDIT
			};

			var model = new Globfact_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Glob/Globfact_FactyValType
		// POST: /Glob/Globfact_FactyValType
		[ActionName("Globfact_FactyValType")]
		public ActionResult Globfact_FactyValType([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_facty")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_facty");
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
			Globfact_FactyValType_ViewModel model = new Globfact_FactyValType_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodglob = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Glob/Globfact_SaveEdit
		[HttpPost]
		public ActionResult Globfact_SaveEdit([FromBody]Globfact_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Globfact_SaveEdit",
				ViewName = "Globfact",
				AreaName = "glob",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GLOBFACT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
