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
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARTIGINV_CANCEL = new NavigationLocation("ITEM40802", "Artiginv_Cancel", "Item") { vueRouteName = "form-ARTIGINV", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTIGINV_SHOW = new NavigationLocation("ITEM40802", "Artiginv_Show", "Item") { vueRouteName = "form-ARTIGINV", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTIGINV_NEW = new NavigationLocation("ITEM40802", "Artiginv_New", "Item") { vueRouteName = "form-ARTIGINV", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTIGINV_EDIT = new NavigationLocation("ITEM40802", "Artiginv_Edit", "Item") { vueRouteName = "form-ARTIGINV", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTIGINV_DUPLICATE = new NavigationLocation("ITEM40802", "Artiginv_Duplicate", "Item") { vueRouteName = "form-ARTIGINV", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTIGINV_DELETE = new NavigationLocation("ITEM40802", "Artiginv_Delete", "Item") { vueRouteName = "form-ARTIGINV", mode = "DELETE" };

		#endregion

		#region Artiginv private

		private void FormHistoryLimits_Artiginv()
		{

		}

		#endregion

		public ActionResult Artiginv_ModalDBEdit()
		{
			Artiginv_ViewModel model = new Artiginv_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Artiginv_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTIGINV]/

		[HttpPost]
		public ActionResult Artiginv_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Show_GET",
				AreaName = "item",
				Location = ACTION_ARTIGINV_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTIGINV]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Artiginv_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_New_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTIGINV]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Artiginv_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_New([FromBody]Artiginv_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_New",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTIGINV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTIGINV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTIGINV]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Artiginv_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Edit_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTIGINV]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Artiginv_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Edit([FromBody]Artiginv_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Edit",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTIGINV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTIGINV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTIGINV]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Artiginv_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Delete_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTIGINV]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Artiginv_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Delete",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTIGINV]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Artiginv_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTIGINV");
		}

		#endregion

		#region Artiginv_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTIGINV]/

		[HttpPost]
		public ActionResult Artiginv_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Duplicate_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTIGINV]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Artiginv_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Duplicate([FromBody]Artiginv_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Duplicate",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTIGINV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTIGINV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTIGINV]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Artiginv_Cancel

		//
		// GET: /Item/Artiginv_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTIGINV]/
		public ActionResult Artiginv_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL ARTIGINV]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTIGINV]/

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

				Navigation.SetValue("ForcePrimaryRead_item", "true", true);
			}

			Navigation.ClearValue("item");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Artiginv Multiform actions

		//
		// GET /Item/MFArtiginv_New
		[HttpGet]
		[ActionName("MFArtiginv_New")]
		public ActionResult MFArtiginv_New()
		{
			var model = new Artiginv_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ARTIGINV_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("item", model.ValCoditem);

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
		public ActionResult MFArtiginv_New_GET()
		{
			return MFArtiginv_New();
		}

		//
		// GET /Item/MFArtiginv_Edit
		[HttpGet]
		[ActionName("MFArtiginv_Edit")]
		public ActionResult MFArtiginv_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ARTIGINV", "EDIT", new { id = id, partialView = "MFArtiginv", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFArtiginv_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFArtiginv_Edit(requestModel);
		}

		//
		// GET /Item/MFArtiginv_Cancel
		[ActionName("MFArtiginv_Cancel")]
		public ActionResult MFArtiginv_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Item(UserContext.Current);
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
		// POST /Item/MFArtiginv_Save
		[HttpPost]
		[ActionName("MFArtiginv_Save")]
		public JsonResult MFArtiginv_Save(Artiginv_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFArtiginv_Save",
				ViewName = "MFArtiginv",
				AreaName = "item"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Item/MFArtiginv_Delete
		[HttpPost]
		[ActionName("MFArtiginv_Delete")]
		public JsonResult MFArtiginv_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFArtiginv_Delete",
				ViewName = "MFArtiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_EDIT
			};

			var model = new Artiginv_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Item/Artiginv_GitemValItemdes
		// POST: /Item/Artiginv_GitemValItemdes
		[ActionName("Artiginv_GitemValItemdes")]
		public ActionResult Artiginv_GitemValItemdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_gitem")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_gitem");
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
			Artiginv_GitemValItemdes_ViewModel model = new Artiginv_GitemValItemdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Item/Artiginv_WarehValWarehdes
		// POST: /Item/Artiginv_WarehValWarehdes
		[ActionName("Artiginv_WarehValWarehdes")]
		public ActionResult Artiginv_WarehValWarehdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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
			Artiginv_WarehValWarehdes_ViewModel model = new Artiginv_WarehValWarehdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCoditem = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Item/Artiginv_SaveEdit
		[HttpPost]
		public ActionResult Artiginv_SaveEdit([FromBody]Artiginv_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_SaveEdit",
				ViewName = "Artiginv",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTIGINV]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
