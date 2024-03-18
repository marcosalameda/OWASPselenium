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
using GenioMVC.ViewModels.Equip;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GMAPS_CANCEL = new NavigationLocation("GOOGLEMAPS16051", "Gmaps_Cancel", "Equip") { vueRouteName = "form-GMAPS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GMAPS_SHOW = new NavigationLocation("GOOGLEMAPS16051", "Gmaps_Show", "Equip") { vueRouteName = "form-GMAPS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GMAPS_NEW = new NavigationLocation("GOOGLEMAPS16051", "Gmaps_New", "Equip") { vueRouteName = "form-GMAPS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GMAPS_EDIT = new NavigationLocation("GOOGLEMAPS16051", "Gmaps_Edit", "Equip") { vueRouteName = "form-GMAPS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GMAPS_DUPLICATE = new NavigationLocation("GOOGLEMAPS16051", "Gmaps_Duplicate", "Equip") { vueRouteName = "form-GMAPS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GMAPS_DELETE = new NavigationLocation("GOOGLEMAPS16051", "Gmaps_Delete", "Equip") { vueRouteName = "form-GMAPS", mode = "DELETE" };

		#endregion

		#region Gmaps private

		private void FormHistoryLimits_Gmaps()
		{

		}

		#endregion

		public ActionResult Gmaps_ModalDBEdit()
		{
			Gmaps_ViewModel model = new Gmaps_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Gmaps_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GMAPS]/

		[HttpPost]
		public ActionResult Gmaps_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Gmaps_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Show_GET",
				AreaName = "equip",
				Location = ACTION_GMAPS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Gmaps();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GMAPS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Gmaps_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Gmaps_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_New_GET",
				AreaName = "equip",
				FormName = "GMAPS",
				Location = ACTION_GMAPS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Gmaps();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GMAPS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Gmaps_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_New([FromBody]Gmaps_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_New",
				ViewName = "Gmaps",
				AreaName = "equip",
				Location = ACTION_GMAPS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GMAPS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GMAPS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GMAPS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Gmaps_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Gmaps_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Edit_GET",
				AreaName = "equip",
				FormName = "GMAPS",
				Location = ACTION_GMAPS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Gmaps();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GMAPS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Gmaps_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_Edit([FromBody]Gmaps_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Edit",
				ViewName = "Gmaps",
				AreaName = "equip",
				Location = ACTION_GMAPS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GMAPS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GMAPS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GMAPS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Gmaps_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Gmaps_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Delete_GET",
				AreaName = "equip",
				FormName = "GMAPS",
				Location = ACTION_GMAPS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Gmaps();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GMAPS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Gmaps_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Gmaps_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Delete",
				ViewName = "Gmaps",
				AreaName = "equip",
				Location = ACTION_GMAPS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GMAPS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Gmaps_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GMAPS");
		}

		#endregion

		#region Gmaps_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GMAPS]/

		[HttpPost]
		public ActionResult Gmaps_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Gmaps_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Duplicate_GET",
				AreaName = "equip",
				FormName = "GMAPS",
				Location = ACTION_GMAPS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GMAPS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Gmaps_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GMAPS]/
		[HttpPost]
		public ActionResult Gmaps_Duplicate([FromBody]Gmaps_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_Duplicate",
				ViewName = "Gmaps",
				AreaName = "equip",
				Location = ACTION_GMAPS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GMAPS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GMAPS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GMAPS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Gmaps_Cancel

		//
		// GET: /Equip/Gmaps_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GMAPS]/
		public ActionResult Gmaps_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL GMAPS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GMAPS]/

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

				Navigation.SetValue("ForcePrimaryRead_equip", "true", true);
			}

			Navigation.ClearValue("equip");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Gmaps Multiform actions

		//
		// GET /Equip/MFGmaps_New
		[HttpGet]
		[ActionName("MFGmaps_New")]
		public ActionResult MFGmaps_New()
		{
			var model = new Gmaps_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_GMAPS_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("equip", model.ValCodequip);

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
		public ActionResult MFGmaps_New_GET()
		{
			return MFGmaps_New();
		}

		//
		// GET /Equip/MFGmaps_Edit
		[HttpGet]
		[ActionName("MFGmaps_Edit")]
		public ActionResult MFGmaps_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("GMAPS", "EDIT", new { id = id, partialView = "MFGmaps", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFGmaps_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFGmaps_Edit(requestModel);
		}

		//
		// GET /Equip/MFGmaps_Cancel
		[ActionName("MFGmaps_Cancel")]
		public ActionResult MFGmaps_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Equip(UserContext.Current);
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
		// POST /Equip/MFGmaps_Save
		[HttpPost]
		[ActionName("MFGmaps_Save")]
		public JsonResult MFGmaps_Save(Gmaps_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGmaps_Save",
				ViewName = "MFGmaps",
				AreaName = "equip"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Equip/MFGmaps_Delete
		[HttpPost]
		[ActionName("MFGmaps_Delete")]
		public JsonResult MFGmaps_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFGmaps_Delete",
				ViewName = "MFGmaps",
				AreaName = "equip",
				Location = ACTION_GMAPS_EDIT
			};

			var model = new Gmaps_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Equip/Gmaps_ValInstalac
		// POST: /Equip/Gmaps_ValInstalac
		[ActionName("Gmaps_ValInstalac")]
		public ActionResult Gmaps_ValInstalac([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
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

			Gmaps_ValInstalac_ViewModel model = new Gmaps_ValInstalac_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodequip = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Equip/Gmaps_SaveEdit
		[HttpPost]
		public ActionResult Gmaps_SaveEdit([FromBody]Gmaps_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Gmaps_SaveEdit",
				ViewName = "Gmaps",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GMAPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GMAPS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
