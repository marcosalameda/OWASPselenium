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
using GenioMVC.ViewModels.Dispa;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DISPA]/

namespace GenioMVC.Controllers
{
	public partial class DispaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DISPA_CANCEL = new NavigationLocation("DISPATCH46310", "Dispa_Cancel", "Dispa") { vueRouteName = "form-DISPA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DISPA_SHOW = new NavigationLocation("DISPATCH46310", "Dispa_Show", "Dispa") { vueRouteName = "form-DISPA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DISPA_NEW = new NavigationLocation("DISPATCH46310", "Dispa_New", "Dispa") { vueRouteName = "form-DISPA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DISPA_EDIT = new NavigationLocation("DISPATCH46310", "Dispa_Edit", "Dispa") { vueRouteName = "form-DISPA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DISPA_DUPLICATE = new NavigationLocation("DISPATCH46310", "Dispa_Duplicate", "Dispa") { vueRouteName = "form-DISPA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DISPA_DELETE = new NavigationLocation("DISPATCH46310", "Dispa_Delete", "Dispa") { vueRouteName = "form-DISPA", mode = "DELETE" };

		#endregion

		#region Dispa private

		private void FormHistoryLimits_Dispa()
		{

		}

		#endregion

		public ActionResult Dispa_ModalDBEdit()
		{
			Dispa_ViewModel model = new Dispa_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Dispa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DISPA]/

		[HttpPost]
		public ActionResult Dispa_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Show_GET",
				AreaName = "dispa",
				Location = ACTION_DISPA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DISPA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dispa_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_New_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DISPA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Dispa/Dispa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_New([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_New",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DISPA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dispa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Edit_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DISPA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Dispa/Dispa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Edit([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Edit",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DISPA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dispa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Delete_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DISPA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Dispa/Dispa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Delete",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DISPA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dispa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DISPA");
		}

		#endregion

		#region Dispa_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DISPA]/

		[HttpPost]
		public ActionResult Dispa_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Duplicate_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DISPA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Dispa/Dispa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Duplicate([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Duplicate",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DISPA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dispa_Cancel

		//
		// GET: /Dispa/Dispa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DISPA]/
		public ActionResult Dispa_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Dispa(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("dispa");

// USE /[MANUAL GQT BEFORE_CANCEL DISPA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DISPA]/

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

				Navigation.SetValue("ForcePrimaryRead_dispa", "true", true);
			}

			Navigation.ClearValue("dispa");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Dispa Multiform actions

		//
		// GET /Dispa/MFDispa_New
		[HttpGet]
		[ActionName("MFDispa_New")]
		public ActionResult MFDispa_New()
		{
			var model = new Dispa_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_DISPA_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("dispa", model.ValCoddispa);

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
		public ActionResult MFDispa_New_GET()
		{
			return MFDispa_New();
		}

		//
		// GET /Dispa/MFDispa_Edit
		[HttpGet]
		[ActionName("MFDispa_Edit")]
		public ActionResult MFDispa_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("DISPA", "EDIT", new { id = id, partialView = "MFDispa", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFDispa_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFDispa_Edit(requestModel);
		}

		//
		// GET /Dispa/MFDispa_Cancel
		[ActionName("MFDispa_Cancel")]
		public ActionResult MFDispa_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Dispa(UserContext.Current);
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
		// POST /Dispa/MFDispa_Save
		[HttpPost]
		[ActionName("MFDispa_Save")]
		public JsonResult MFDispa_Save(Dispa_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFDispa_Save",
				ViewName = "MFDispa",
				AreaName = "dispa"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Dispa/MFDispa_Delete
		[HttpPost]
		[ActionName("MFDispa_Delete")]
		public JsonResult MFDispa_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFDispa_Delete",
				ViewName = "MFDispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_EDIT
			};

			var model = new Dispa_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Dispa/Dispa_EntitValName
		// POST: /Dispa/Dispa_EntitValName
		[ActionName("Dispa_EntitValName")]
		public ActionResult Dispa_EntitValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entit")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entit");
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
			Dispa_EntitValName_ViewModel model = new Dispa_EntitValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoddispa = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Dispa/Dispa_PersoValName
		// POST: /Dispa/Dispa_PersoValName
		[ActionName("Dispa_PersoValName")]
		public ActionResult Dispa_PersoValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
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
			Dispa_PersoValName_ViewModel model = new Dispa_PersoValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoddispa = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Dispa/Dispa_ValDispatch
		// POST: /Dispa/Dispa_ValDispatch
		[ActionName("Dispa_ValDispatch")]
		public ActionResult Dispa_ValDispatch([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dilin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dilin");
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

			Dispa_ValDispatch_ViewModel model = new Dispa_ValDispatch_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoddispa = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Dispa/Dispa_SaveEdit
		[HttpPost]
		public ActionResult Dispa_SaveEdit([FromBody]Dispa_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_SaveEdit",
				ViewName = "Dispa",
				AreaName = "dispa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DISPA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
