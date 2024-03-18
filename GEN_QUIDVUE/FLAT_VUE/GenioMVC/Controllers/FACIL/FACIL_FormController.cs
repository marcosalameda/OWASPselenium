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
using GenioMVC.ViewModels.Facil;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FACIL]/

namespace GenioMVC.Controllers
{
	public partial class FacilController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FACIL_CANCEL = new NavigationLocation("FACILITY55206", "Facil_Cancel", "Facil") { vueRouteName = "form-FACIL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FACIL_SHOW = new NavigationLocation("FACILITY55206", "Facil_Show", "Facil") { vueRouteName = "form-FACIL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FACIL_NEW = new NavigationLocation("FACILITY55206", "Facil_New", "Facil") { vueRouteName = "form-FACIL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FACIL_EDIT = new NavigationLocation("FACILITY55206", "Facil_Edit", "Facil") { vueRouteName = "form-FACIL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FACIL_DUPLICATE = new NavigationLocation("FACILITY55206", "Facil_Duplicate", "Facil") { vueRouteName = "form-FACIL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FACIL_DELETE = new NavigationLocation("FACILITY55206", "Facil_Delete", "Facil") { vueRouteName = "form-FACIL", mode = "DELETE" };

		#endregion

		#region Facil private

		private void FormHistoryLimits_Facil()
		{

		}

		#endregion

		public ActionResult Facil_ModalDBEdit()
		{
			Facil_ViewModel model = new Facil_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Facil_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FACIL]/

		[HttpPost]
		public ActionResult Facil_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Show_GET",
				AreaName = "facil",
				Location = ACTION_FACIL_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FACIL]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Facil_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FACIL]/
		[HttpPost]
		public ActionResult Facil_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_New_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FACIL]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Facil/Facil_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_New([FromBody]Facil_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_New",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FACIL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FACIL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FACIL]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Facil_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FACIL]/
		[HttpPost]
		public ActionResult Facil_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Edit_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FACIL]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Facil/Facil_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_Edit([FromBody]Facil_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Edit",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FACIL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FACIL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FACIL]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Facil_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FACIL]/
		[HttpPost]
		public ActionResult Facil_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Delete_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FACIL]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Facil/Facil_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Facil_Delete",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FACIL]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Facil_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FACIL");
		}

		#endregion

		#region Facil_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FACIL]/

		[HttpPost]
		public ActionResult Facil_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Duplicate_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FACIL]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Facil/Facil_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_Duplicate([FromBody]Facil_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Duplicate",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FACIL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FACIL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FACIL]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Facil_Cancel

		//
		// GET: /Facil/Facil_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FACIL]/
		public ActionResult Facil_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Facil(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("facil");

// USE /[MANUAL GQT BEFORE_CANCEL FACIL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FACIL]/

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

				Navigation.SetValue("ForcePrimaryRead_facil", "true", true);
			}

			Navigation.ClearValue("facil");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Facil Multiform actions

		//
		// GET /Facil/MFFacil_New
		[HttpGet]
		[ActionName("MFFacil_New")]
		public ActionResult MFFacil_New()
		{
			var model = new Facil_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_FACIL_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("facil", model.ValCodfacil);

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
		public ActionResult MFFacil_New_GET()
		{
			return MFFacil_New();
		}

		//
		// GET /Facil/MFFacil_Edit
		[HttpGet]
		[ActionName("MFFacil_Edit")]
		public ActionResult MFFacil_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("FACIL", "EDIT", new { id = id, partialView = "MFFacil", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFFacil_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFFacil_Edit(requestModel);
		}

		//
		// GET /Facil/MFFacil_Cancel
		[ActionName("MFFacil_Cancel")]
		public ActionResult MFFacil_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Facil(UserContext.Current);
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
		// POST /Facil/MFFacil_Save
		[HttpPost]
		[ActionName("MFFacil_Save")]
		public JsonResult MFFacil_Save(Facil_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFFacil_Save",
				ViewName = "MFFacil",
				AreaName = "facil"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Facil/MFFacil_Delete
		[HttpPost]
		[ActionName("MFFacil_Delete")]
		public JsonResult MFFacil_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFFacil_Delete",
				ViewName = "MFFacil",
				AreaName = "facil",
				Location = ACTION_FACIL_EDIT
			};

			var model = new Facil_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Facil/Facil_EntitValName
		// POST: /Facil/Facil_EntitValName
		[ActionName("Facil_EntitValName")]
		public ActionResult Facil_EntitValName([FromBody]RequestLookupModel requestModel)
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
			Facil_EntitValName_ViewModel model = new Facil_EntitValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodfacil = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Facil/Facil_FactyValType
		// POST: /Facil/Facil_FactyValType
		[ActionName("Facil_FactyValType")]
		public ActionResult Facil_FactyValType([FromBody]RequestLookupModel requestModel)
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
			Facil_FactyValType_ViewModel model = new Facil_FactyValType_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodfacil = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Facil/Facil_SaveEdit
		[HttpPost]
		public ActionResult Facil_SaveEdit([FromBody]Facil_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_SaveEdit",
				ViewName = "Facil",
				AreaName = "facil",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FACIL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
