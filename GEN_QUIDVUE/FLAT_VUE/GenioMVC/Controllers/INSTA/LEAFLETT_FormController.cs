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
using GenioMVC.ViewModels.Insta;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER INSTA]/

namespace GenioMVC.Controllers
{
	public partial class InstaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LEAFLETT_CANCEL = new NavigationLocation("INSTALLATION12952", "Leaflett_Cancel", "Insta") { vueRouteName = "form-LEAFLETT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LEAFLETT_SHOW = new NavigationLocation("INSTALLATION12952", "Leaflett_Show", "Insta") { vueRouteName = "form-LEAFLETT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LEAFLETT_NEW = new NavigationLocation("INSTALLATION12952", "Leaflett_New", "Insta") { vueRouteName = "form-LEAFLETT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LEAFLETT_EDIT = new NavigationLocation("INSTALLATION12952", "Leaflett_Edit", "Insta") { vueRouteName = "form-LEAFLETT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LEAFLETT_DUPLICATE = new NavigationLocation("INSTALLATION12952", "Leaflett_Duplicate", "Insta") { vueRouteName = "form-LEAFLETT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LEAFLETT_DELETE = new NavigationLocation("INSTALLATION12952", "Leaflett_Delete", "Insta") { vueRouteName = "form-LEAFLETT", mode = "DELETE" };

		#endregion

		#region Leaflett private

		private void FormHistoryLimits_Leaflett()
		{

		}

		#endregion

		public ActionResult Leaflett_ModalDBEdit()
		{
			Leaflett_ViewModel model = new Leaflett_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Leaflett_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LEAFLETT]/

		[HttpPost]
		public ActionResult Leaflett_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leaflett_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Show_GET",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LEAFLETT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Leaflett_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Leaflett_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_New_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LEAFLETT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Insta/Leaflett_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_New([FromBody]Leaflett_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_New",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LEAFLETT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LEAFLETT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LEAFLETT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Leaflett_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leaflett_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Edit_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LEAFLETT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Insta/Leaflett_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Edit([FromBody]Leaflett_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Edit",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LEAFLETT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LEAFLETT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LEAFLETT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Leaflett_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leaflett_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Delete_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leaflett();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LEAFLETT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Insta/Leaflett_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leaflett_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Delete",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LEAFLETT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Leaflett_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LEAFLETT");
		}

		#endregion

		#region Leaflett_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LEAFLETT]/

		[HttpPost]
		public ActionResult Leaflett_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Leaflett_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Duplicate_GET",
				AreaName = "insta",
				FormName = "LEAFLETT",
				Location = ACTION_LEAFLETT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LEAFLETT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Insta/Leaflett_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LEAFLETT]/
		[HttpPost]
		public ActionResult Leaflett_Duplicate([FromBody]Leaflett_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_Duplicate",
				ViewName = "Leaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LEAFLETT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LEAFLETT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LEAFLETT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Leaflett_Cancel

		//
		// GET: /Insta/Leaflett_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LEAFLETT]/
		public ActionResult Leaflett_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Insta(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("insta");

// USE /[MANUAL GQT BEFORE_CANCEL LEAFLETT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LEAFLETT]/

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

				Navigation.SetValue("ForcePrimaryRead_insta", "true", true);
			}

			Navigation.ClearValue("insta");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Leaflett Multiform actions

		//
		// GET /Insta/MFLeaflett_New
		[HttpGet]
		[ActionName("MFLeaflett_New")]
		public ActionResult MFLeaflett_New()
		{
			var model = new Leaflett_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LEAFLETT_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("insta", model.ValCodinsta);

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
		public ActionResult MFLeaflett_New_GET()
		{
			return MFLeaflett_New();
		}

		//
		// GET /Insta/MFLeaflett_Edit
		[HttpGet]
		[ActionName("MFLeaflett_Edit")]
		public ActionResult MFLeaflett_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("LEAFLETT", "EDIT", new { id = id, partialView = "MFLeaflett", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFLeaflett_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFLeaflett_Edit(requestModel);
		}

		//
		// GET /Insta/MFLeaflett_Cancel
		[ActionName("MFLeaflett_Cancel")]
		public ActionResult MFLeaflett_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Insta(UserContext.Current);
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
		// POST /Insta/MFLeaflett_Save
		[HttpPost]
		[ActionName("MFLeaflett_Save")]
		public JsonResult MFLeaflett_Save(Leaflett_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLeaflett_Save",
				ViewName = "MFLeaflett",
				AreaName = "insta"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Insta/MFLeaflett_Delete
		[HttpPost]
		[ActionName("MFLeaflett_Delete")]
		public JsonResult MFLeaflett_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFLeaflett_Delete",
				ViewName = "MFLeaflett",
				AreaName = "insta",
				Location = ACTION_LEAFLETT_EDIT
			};

			var model = new Leaflett_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Insta/Leaflett_EquipValRegistnr
		// POST: /Insta/Leaflett_EquipValRegistnr
		[ActionName("Leaflett_EquipValRegistnr")]
		public ActionResult Leaflett_EquipValRegistnr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
			Leaflett_EquipValRegistnr_ViewModel model = new Leaflett_EquipValRegistnr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodinsta = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Insta/Leaflett_SaveEdit
		[HttpPost]
		public ActionResult Leaflett_SaveEdit([FromBody]Leaflett_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leaflett_SaveEdit",
				ViewName = "Leaflett",
				AreaName = "insta",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LEAFLETT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LEAFLETT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
