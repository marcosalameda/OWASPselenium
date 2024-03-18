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
using GenioMVC.ViewModels.Cmpny;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPNY]/

namespace GenioMVC.Controllers
{
	public partial class CmpnyController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EMPRE_CANCEL = new NavigationLocation("COMPANY52963", "Empre_Cancel", "Cmpny") { vueRouteName = "form-EMPRE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EMPRE_SHOW = new NavigationLocation("COMPANY52963", "Empre_Show", "Cmpny") { vueRouteName = "form-EMPRE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EMPRE_NEW = new NavigationLocation("COMPANY52963", "Empre_New", "Cmpny") { vueRouteName = "form-EMPRE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EMPRE_EDIT = new NavigationLocation("COMPANY52963", "Empre_Edit", "Cmpny") { vueRouteName = "form-EMPRE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EMPRE_DUPLICATE = new NavigationLocation("COMPANY52963", "Empre_Duplicate", "Cmpny") { vueRouteName = "form-EMPRE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EMPRE_DELETE = new NavigationLocation("COMPANY52963", "Empre_Delete", "Cmpny") { vueRouteName = "form-EMPRE", mode = "DELETE" };

		#endregion

		#region Empre private

		private void FormHistoryLimits_Empre()
		{

		}

		#endregion

		public ActionResult Empre_ModalDBEdit()
		{
			Empre_ViewModel model = new Empre_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Empre_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EMPRE]/

		[HttpPost]
		public ActionResult Empre_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Show_GET",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EMPRE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Empre_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EMPRE]/
		[HttpPost]
		public ActionResult Empre_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_New_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EMPRE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cmpny/Empre_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_New([FromBody]Empre_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_New",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EMPRE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Empre_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EMPRE]/
		[HttpPost]
		public ActionResult Empre_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Edit_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EMPRE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cmpny/Empre_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_Edit([FromBody]Empre_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Edit",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EMPRE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Empre_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EMPRE]/
		[HttpPost]
		public ActionResult Empre_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Delete_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EMPRE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cmpny/Empre_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Empre_Delete",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EMPRE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Empre_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EMPRE");
		}

		#endregion

		#region Empre_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EMPRE]/

		[HttpPost]
		public ActionResult Empre_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Duplicate_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EMPRE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cmpny/Empre_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_Duplicate([FromBody]Empre_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Duplicate",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EMPRE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Empre_Cancel

		//
		// GET: /Cmpny/Empre_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EMPRE]/
		public ActionResult Empre_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cmpny(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");

// USE /[MANUAL GQT BEFORE_CANCEL EMPRE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EMPRE]/

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

				Navigation.SetValue("ForcePrimaryRead_cmpny", "true", true);
			}

			Navigation.ClearValue("cmpny");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Empre Multiform actions

		//
		// GET /Cmpny/MFEmpre_New
		[HttpGet]
		[ActionName("MFEmpre_New")]
		public ActionResult MFEmpre_New()
		{
			var model = new Empre_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_EMPRE_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("cmpny", model.ValCodempre);

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
		public ActionResult MFEmpre_New_GET()
		{
			return MFEmpre_New();
		}

		//
		// GET /Cmpny/MFEmpre_Edit
		[HttpGet]
		[ActionName("MFEmpre_Edit")]
		public ActionResult MFEmpre_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("EMPRE", "EDIT", new { id = id, partialView = "MFEmpre", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFEmpre_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFEmpre_Edit(requestModel);
		}

		//
		// GET /Cmpny/MFEmpre_Cancel
		[ActionName("MFEmpre_Cancel")]
		public ActionResult MFEmpre_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Cmpny(UserContext.Current);
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
		// POST /Cmpny/MFEmpre_Save
		[HttpPost]
		[ActionName("MFEmpre_Save")]
		public JsonResult MFEmpre_Save(Empre_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEmpre_Save",
				ViewName = "MFEmpre",
				AreaName = "cmpny"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Cmpny/MFEmpre_Delete
		[HttpPost]
		[ActionName("MFEmpre_Delete")]
		public JsonResult MFEmpre_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFEmpre_Delete",
				ViewName = "MFEmpre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_EDIT
			};

			var model = new Empre_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Cmpny/Empre_CntryValCountry
		// POST: /Cmpny/Empre_CntryValCountry
		[ActionName("Empre_CntryValCountry")]
		public ActionResult Empre_CntryValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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
			Empre_CntryValCountry_ViewModel model = new Empre_CntryValCountry_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodempre = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Cmpny/Empre_SaveEdit
		[HttpPost]
		public ActionResult Empre_SaveEdit([FromBody]Empre_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_SaveEdit",
				ViewName = "Empre",
				AreaName = "cmpny",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EMPRE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
