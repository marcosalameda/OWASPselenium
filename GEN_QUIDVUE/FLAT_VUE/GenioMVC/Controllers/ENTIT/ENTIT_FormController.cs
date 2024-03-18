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
using GenioMVC.ViewModels.Entit;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ENTIT]/

namespace GenioMVC.Controllers
{
	public partial class EntitController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ENTIT_CANCEL = new NavigationLocation("ENTITY62049", "Entit_Cancel", "Entit") { vueRouteName = "form-ENTIT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ENTIT_SHOW = new NavigationLocation("ENTITY62049", "Entit_Show", "Entit") { vueRouteName = "form-ENTIT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ENTIT_NEW = new NavigationLocation("ENTITY62049", "Entit_New", "Entit") { vueRouteName = "form-ENTIT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ENTIT_EDIT = new NavigationLocation("ENTITY62049", "Entit_Edit", "Entit") { vueRouteName = "form-ENTIT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ENTIT_DUPLICATE = new NavigationLocation("ENTITY62049", "Entit_Duplicate", "Entit") { vueRouteName = "form-ENTIT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ENTIT_DELETE = new NavigationLocation("ENTITY62049", "Entit_Delete", "Entit") { vueRouteName = "form-ENTIT", mode = "DELETE" };

		#endregion

		#region Entit private

		private void FormHistoryLimits_Entit()
		{

		}

		#endregion

		public ActionResult Entit_ModalDBEdit()
		{
			Entit_ViewModel model = new Entit_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Entit_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ENTIT]/

		[HttpPost]
		public ActionResult Entit_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entit_Show_GET",
				AreaName = "entit",
				Location = ACTION_ENTIT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entit();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ENTIT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Entit_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ENTIT]/
		[HttpPost]
		public ActionResult Entit_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Entit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entit_New_GET",
				AreaName = "entit",
				FormName = "ENTIT",
				Location = ACTION_ENTIT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Entit();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ENTIT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Entit/Entit_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ENTIT]/
		[HttpPost]
		public ActionResult Entit_New([FromBody]Entit_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entit_New",
				ViewName = "Entit",
				AreaName = "entit",
				Location = ACTION_ENTIT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ENTIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ENTIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ENTIT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Entit_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ENTIT]/
		[HttpPost]
		public ActionResult Entit_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entit_Edit_GET",
				AreaName = "entit",
				FormName = "ENTIT",
				Location = ACTION_ENTIT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entit();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ENTIT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Entit/Entit_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ENTIT]/
		[HttpPost]
		public ActionResult Entit_Edit([FromBody]Entit_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entit_Edit",
				ViewName = "Entit",
				AreaName = "entit",
				Location = ACTION_ENTIT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ENTIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ENTIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ENTIT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Entit_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ENTIT]/
		[HttpPost]
		public ActionResult Entit_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entit_Delete_GET",
				AreaName = "entit",
				FormName = "ENTIT",
				Location = ACTION_ENTIT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entit();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ENTIT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Entit/Entit_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ENTIT]/
		[HttpPost]
		public ActionResult Entit_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entit_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Entit_Delete",
				ViewName = "Entit",
				AreaName = "entit",
				Location = ACTION_ENTIT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ENTIT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Entit_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ENTIT");
		}

		#endregion

		#region Entit_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ENTIT]/

		[HttpPost]
		public ActionResult Entit_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Entit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entit_Duplicate_GET",
				AreaName = "entit",
				FormName = "ENTIT",
				Location = ACTION_ENTIT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ENTIT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Entit/Entit_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ENTIT]/
		[HttpPost]
		public ActionResult Entit_Duplicate([FromBody]Entit_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entit_Duplicate",
				ViewName = "Entit",
				AreaName = "entit",
				Location = ACTION_ENTIT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ENTIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ENTIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ENTIT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Entit_Cancel

		//
		// GET: /Entit/Entit_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ENTIT]/
		public ActionResult Entit_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Entit(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("entit");

// USE /[MANUAL GQT BEFORE_CANCEL ENTIT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ENTIT]/

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

				Navigation.SetValue("ForcePrimaryRead_entit", "true", true);
			}

			Navigation.ClearValue("entit");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Entit Multiform actions

		//
		// GET /Entit/MFEntit_New
		[HttpGet]
		[ActionName("MFEntit_New")]
		public ActionResult MFEntit_New()
		{
			var model = new Entit_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ENTIT_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("entit", model.ValCodentit);

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
		public ActionResult MFEntit_New_GET()
		{
			return MFEntit_New();
		}

		//
		// GET /Entit/MFEntit_Edit
		[HttpGet]
		[ActionName("MFEntit_Edit")]
		public ActionResult MFEntit_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ENTIT", "EDIT", new { id = id, partialView = "MFEntit", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFEntit_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFEntit_Edit(requestModel);
		}

		//
		// GET /Entit/MFEntit_Cancel
		[ActionName("MFEntit_Cancel")]
		public ActionResult MFEntit_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Entit(UserContext.Current);
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
		// POST /Entit/MFEntit_Save
		[HttpPost]
		[ActionName("MFEntit_Save")]
		public JsonResult MFEntit_Save(Entit_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEntit_Save",
				ViewName = "MFEntit",
				AreaName = "entit"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Entit/MFEntit_Delete
		[HttpPost]
		[ActionName("MFEntit_Delete")]
		public JsonResult MFEntit_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFEntit_Delete",
				ViewName = "MFEntit",
				AreaName = "entit",
				Location = ACTION_ENTIT_EDIT
			};

			var model = new Entit_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Entit/Entit_Faci1ValName
		// POST: /Entit/Entit_Faci1ValName
		[ActionName("Entit_Faci1ValName")]
		public ActionResult Entit_Faci1ValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_faci1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_faci1");
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
			Entit_Faci1ValName_ViewModel model = new Entit_Faci1ValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodentit = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Entit/Entit_Faci2ValName
		// POST: /Entit/Entit_Faci2ValName
		[ActionName("Entit_Faci2ValName")]
		public ActionResult Entit_Faci2ValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_faci2")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_faci2");
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
			Entit_Faci2ValName_ViewModel model = new Entit_Faci2ValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodentit = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Entit/Entit_SaveEdit
		[HttpPost]
		public ActionResult Entit_SaveEdit([FromBody]Entit_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entit_SaveEdit",
				ViewName = "Entit",
				AreaName = "entit",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ENTIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ENTIT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
