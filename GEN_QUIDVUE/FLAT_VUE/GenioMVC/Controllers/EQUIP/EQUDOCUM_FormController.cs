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

		private static readonly NavigationLocation ACTION_EQUDOCUM_CANCEL = new NavigationLocation("DOCUMENTS_FROM_EQUIP36805", "Equdocum_Cancel", "Equip") { vueRouteName = "form-EQUDOCUM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EQUDOCUM_SHOW = new NavigationLocation("DOCUMENTS_FROM_EQUIP36805", "Equdocum_Show", "Equip") { vueRouteName = "form-EQUDOCUM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EQUDOCUM_NEW = new NavigationLocation("DOCUMENTS_FROM_EQUIP36805", "Equdocum_New", "Equip") { vueRouteName = "form-EQUDOCUM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EQUDOCUM_EDIT = new NavigationLocation("DOCUMENTS_FROM_EQUIP36805", "Equdocum_Edit", "Equip") { vueRouteName = "form-EQUDOCUM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EQUDOCUM_DUPLICATE = new NavigationLocation("DOCUMENTS_FROM_EQUIP36805", "Equdocum_Duplicate", "Equip") { vueRouteName = "form-EQUDOCUM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EQUDOCUM_DELETE = new NavigationLocation("DOCUMENTS_FROM_EQUIP36805", "Equdocum_Delete", "Equip") { vueRouteName = "form-EQUDOCUM", mode = "DELETE" };

		#endregion

		#region Equdocum private

		private void FormHistoryLimits_Equdocum()
		{

		}

		#endregion

		public ActionResult Equdocum_ModalDBEdit()
		{
			Equdocum_ViewModel model = new Equdocum_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Equdocum_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EQUDOCUM]/

		[HttpPost]
		public ActionResult Equdocum_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equdocum_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Show_GET",
				AreaName = "equip",
				Location = ACTION_EQUDOCUM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equdocum();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EQUDOCUM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Equdocum_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Equdocum_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_New_GET",
				AreaName = "equip",
				FormName = "EQUDOCUM",
				Location = ACTION_EQUDOCUM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Equdocum();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EQUDOCUM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Equdocum_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_New([FromBody]Equdocum_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_New",
				ViewName = "Equdocum",
				AreaName = "equip",
				Location = ACTION_EQUDOCUM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EQUDOCUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EQUDOCUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EQUDOCUM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Equdocum_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equdocum_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Edit_GET",
				AreaName = "equip",
				FormName = "EQUDOCUM",
				Location = ACTION_EQUDOCUM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equdocum();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EQUDOCUM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Equdocum_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_Edit([FromBody]Equdocum_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Edit",
				ViewName = "Equdocum",
				AreaName = "equip",
				Location = ACTION_EQUDOCUM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EQUDOCUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EQUDOCUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EQUDOCUM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Equdocum_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equdocum_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Delete_GET",
				AreaName = "equip",
				FormName = "EQUDOCUM",
				Location = ACTION_EQUDOCUM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equdocum();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EQUDOCUM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Equdocum_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equdocum_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Delete",
				ViewName = "Equdocum",
				AreaName = "equip",
				Location = ACTION_EQUDOCUM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EQUDOCUM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Equdocum_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EQUDOCUM");
		}

		#endregion

		#region Equdocum_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EQUDOCUM]/

		[HttpPost]
		public ActionResult Equdocum_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Equdocum_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Duplicate_GET",
				AreaName = "equip",
				FormName = "EQUDOCUM",
				Location = ACTION_EQUDOCUM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EQUDOCUM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Equdocum_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EQUDOCUM]/
		[HttpPost]
		public ActionResult Equdocum_Duplicate([FromBody]Equdocum_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_Duplicate",
				ViewName = "Equdocum",
				AreaName = "equip",
				Location = ACTION_EQUDOCUM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EQUDOCUM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EQUDOCUM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EQUDOCUM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Equdocum_Cancel

		//
		// GET: /Equip/Equdocum_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EQUDOCUM]/
		public ActionResult Equdocum_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL EQUDOCUM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EQUDOCUM]/

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

		#region Equdocum Multiform actions

		//
		// GET /Equip/MFEqudocum_New
		[HttpGet]
		[ActionName("MFEqudocum_New")]
		public ActionResult MFEqudocum_New()
		{
			var model = new Equdocum_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_EQUDOCUM_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFEqudocum_New_GET()
		{
			return MFEqudocum_New();
		}

		//
		// GET /Equip/MFEqudocum_Edit
		[HttpGet]
		[ActionName("MFEqudocum_Edit")]
		public ActionResult MFEqudocum_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("EQUDOCUM", "EDIT", new { id = id, partialView = "MFEqudocum", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFEqudocum_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFEqudocum_Edit(requestModel);
		}

		//
		// GET /Equip/MFEqudocum_Cancel
		[ActionName("MFEqudocum_Cancel")]
		public ActionResult MFEqudocum_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Equip/MFEqudocum_Save
		[HttpPost]
		[ActionName("MFEqudocum_Save")]
		public JsonResult MFEqudocum_Save(Equdocum_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEqudocum_Save",
				ViewName = "MFEqudocum",
				AreaName = "equip"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Equip/MFEqudocum_Delete
		[HttpPost]
		[ActionName("MFEqudocum_Delete")]
		public JsonResult MFEqudocum_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFEqudocum_Delete",
				ViewName = "MFEqudocum",
				AreaName = "equip",
				Location = ACTION_EQUDOCUM_EDIT
			};

			var model = new Equdocum_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Equip/Equdocum_ValLisanex
		// POST: /Equip/Equdocum_ValLisanex
		[ActionName("Equdocum_ValLisanex")]
		public ActionResult Equdocum_ValLisanex([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_anexd")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_anexd");
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

			Equdocum_ValLisanex_ViewModel model = new Equdocum_ValLisanex_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodequip = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Equip/Equdocum_SaveEdit
		[HttpPost]
		public ActionResult Equdocum_SaveEdit([FromBody]Equdocum_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equdocum_SaveEdit",
				ViewName = "Equdocum",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EQUDOCUM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EQUDOCUM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
