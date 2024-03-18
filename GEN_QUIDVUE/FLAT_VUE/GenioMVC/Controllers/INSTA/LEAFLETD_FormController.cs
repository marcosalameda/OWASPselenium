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

		private static readonly NavigationLocation ACTION_LEAFLETD_CANCEL = new NavigationLocation("CANCELAR49513", "Leafletd_Cancel", "Insta") { vueRouteName = "form-LEAFLETD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LEAFLETD_SHOW = new NavigationLocation("CONSULTA40695", "Leafletd_Show", "Insta") { vueRouteName = "form-LEAFLETD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LEAFLETD_NEW = new NavigationLocation("INSERIR43365", "Leafletd_New", "Insta") { vueRouteName = "form-LEAFLETD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LEAFLETD_EDIT = new NavigationLocation("EDITAR11616", "Leafletd_Edit", "Insta") { vueRouteName = "form-LEAFLETD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LEAFLETD_DUPLICATE = new NavigationLocation("DUPLICAR09748", "Leafletd_Duplicate", "Insta") { vueRouteName = "form-LEAFLETD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LEAFLETD_DELETE = new NavigationLocation("APAGAR04097", "Leafletd_Delete", "Insta") { vueRouteName = "form-LEAFLETD", mode = "DELETE" };

		#endregion

		#region Leafletd private

		private void FormHistoryLimits_Leafletd()
		{

		}

		#endregion

		public ActionResult Leafletd_ModalDBEdit()
		{
			Leafletd_ViewModel model = new Leafletd_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Leafletd_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LEAFLETD]/

		[HttpPost]
		public ActionResult Leafletd_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leafletd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Show_GET",
				AreaName = "insta",
				Location = ACTION_LEAFLETD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leafletd();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LEAFLETD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Leafletd_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Leafletd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_New_GET",
				AreaName = "insta",
				FormName = "LEAFLETD",
				Location = ACTION_LEAFLETD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Leafletd();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LEAFLETD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Insta/Leafletd_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_New([FromBody]Leafletd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_New",
				ViewName = "Leafletd",
				AreaName = "insta",
				Location = ACTION_LEAFLETD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LEAFLETD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LEAFLETD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LEAFLETD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Leafletd_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leafletd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Edit_GET",
				AreaName = "insta",
				FormName = "LEAFLETD",
				Location = ACTION_LEAFLETD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leafletd();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LEAFLETD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Insta/Leafletd_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_Edit([FromBody]Leafletd_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Edit",
				ViewName = "Leafletd",
				AreaName = "insta",
				Location = ACTION_LEAFLETD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LEAFLETD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LEAFLETD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LEAFLETD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Leafletd_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leafletd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Delete_GET",
				AreaName = "insta",
				FormName = "LEAFLETD",
				Location = ACTION_LEAFLETD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Leafletd();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LEAFLETD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Insta/Leafletd_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Leafletd_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Delete",
				ViewName = "Leafletd",
				AreaName = "insta",
				Location = ACTION_LEAFLETD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LEAFLETD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Leafletd_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LEAFLETD");
		}

		#endregion

		#region Leafletd_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LEAFLETD]/

		[HttpPost]
		public ActionResult Leafletd_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Leafletd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Duplicate_GET",
				AreaName = "insta",
				FormName = "LEAFLETD",
				Location = ACTION_LEAFLETD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LEAFLETD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Insta/Leafletd_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LEAFLETD]/
		[HttpPost]
		public ActionResult Leafletd_Duplicate([FromBody]Leafletd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_Duplicate",
				ViewName = "Leafletd",
				AreaName = "insta",
				Location = ACTION_LEAFLETD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LEAFLETD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LEAFLETD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LEAFLETD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Leafletd_Cancel

		//
		// GET: /Insta/Leafletd_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LEAFLETD]/
		public ActionResult Leafletd_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Insta(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("insta");

// USE /[MANUAL GQT BEFORE_CANCEL LEAFLETD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LEAFLETD]/

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

		#region Leafletd Multiform actions

		//
		// GET /Insta/MFLeafletd_New
		[HttpGet]
		[ActionName("MFLeafletd_New")]
		public ActionResult MFLeafletd_New()
		{
			var model = new Leafletd_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LEAFLETD_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFLeafletd_New_GET()
		{
			return MFLeafletd_New();
		}

		//
		// GET /Insta/MFLeafletd_Edit
		[HttpGet]
		[ActionName("MFLeafletd_Edit")]
		public ActionResult MFLeafletd_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("LEAFLETD", "EDIT", new { id = id, partialView = "MFLeafletd", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFLeafletd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFLeafletd_Edit(requestModel);
		}

		//
		// GET /Insta/MFLeafletd_Cancel
		[ActionName("MFLeafletd_Cancel")]
		public ActionResult MFLeafletd_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Insta/MFLeafletd_Save
		[HttpPost]
		[ActionName("MFLeafletd_Save")]
		public JsonResult MFLeafletd_Save(Leafletd_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLeafletd_Save",
				ViewName = "MFLeafletd",
				AreaName = "insta"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Insta/MFLeafletd_Delete
		[HttpPost]
		[ActionName("MFLeafletd_Delete")]
		public JsonResult MFLeafletd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFLeafletd_Delete",
				ViewName = "MFLeafletd",
				AreaName = "insta",
				Location = ACTION_LEAFLETD_EDIT
			};

			var model = new Leafletd_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Insta/Leafletd_EquipValRegistnr
		// POST: /Insta/Leafletd_EquipValRegistnr
		[ActionName("Leafletd_EquipValRegistnr")]
		public ActionResult Leafletd_EquipValRegistnr([FromBody]RequestLookupModel requestModel)
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
			Leafletd_EquipValRegistnr_ViewModel model = new Leafletd_EquipValRegistnr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodinsta = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Insta/Leafletd_SaveEdit
		[HttpPost]
		public ActionResult Leafletd_SaveEdit([FromBody]Leafletd_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Leafletd_SaveEdit",
				ViewName = "Leafletd",
				AreaName = "insta",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LEAFLETD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LEAFLETD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
