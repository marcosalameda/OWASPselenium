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
using GenioMVC.ViewModels.Attac;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ATTAC]/

namespace GenioMVC.Controllers
{
	public partial class AttacController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ATTAC_CANCEL = new NavigationLocation("ATTACHMENT29376", "Attac_Cancel", "Attac") { vueRouteName = "form-ATTAC", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ATTAC_SHOW = new NavigationLocation("ATTACHMENT29376", "Attac_Show", "Attac") { vueRouteName = "form-ATTAC", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ATTAC_NEW = new NavigationLocation("ATTACHMENT29376", "Attac_New", "Attac") { vueRouteName = "form-ATTAC", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ATTAC_EDIT = new NavigationLocation("ATTACHMENT29376", "Attac_Edit", "Attac") { vueRouteName = "form-ATTAC", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ATTAC_DUPLICATE = new NavigationLocation("ATTACHMENT29376", "Attac_Duplicate", "Attac") { vueRouteName = "form-ATTAC", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ATTAC_DELETE = new NavigationLocation("ATTACHMENT29376", "Attac_Delete", "Attac") { vueRouteName = "form-ATTAC", mode = "DELETE" };

		#endregion

		#region Attac private

		private void FormHistoryLimits_Attac()
		{

		}

		#endregion

		public ActionResult Attac_ModalDBEdit()
		{
			Attac_ViewModel model = new Attac_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Attac_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ATTAC]/

		[HttpPost]
		public ActionResult Attac_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Show_GET",
				AreaName = "attac",
				Location = ACTION_ATTAC_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ATTAC]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Attac_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ATTAC]/
		[HttpPost]
		public ActionResult Attac_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_New_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ATTAC]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Attac/Attac_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_New([FromBody]Attac_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_New",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ATTAC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ATTAC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ATTAC]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Attac_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ATTAC]/
		[HttpPost]
		public ActionResult Attac_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Edit_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ATTAC]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Attac/Attac_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_Edit([FromBody]Attac_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Edit",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ATTAC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ATTAC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ATTAC]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Attac_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ATTAC]/
		[HttpPost]
		public ActionResult Attac_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Delete_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ATTAC]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Attac/Attac_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Attac_Delete",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ATTAC]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Attac_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ATTAC");
		}

		#endregion

		#region Attac_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ATTAC]/

		[HttpPost]
		public ActionResult Attac_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Duplicate_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ATTAC]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Attac/Attac_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_Duplicate([FromBody]Attac_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Duplicate",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ATTAC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ATTAC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ATTAC]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Attac_Cancel

		//
		// GET: /Attac/Attac_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ATTAC]/
		public ActionResult Attac_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Attac(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("attac");

// USE /[MANUAL GQT BEFORE_CANCEL ATTAC]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ATTAC]/

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

				Navigation.SetValue("ForcePrimaryRead_attac", "true", true);
			}

			Navigation.ClearValue("attac");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Attac Multiform actions

		//
		// GET /Attac/MFAttac_New
		[HttpGet]
		[ActionName("MFAttac_New")]
		public ActionResult MFAttac_New()
		{
			var model = new Attac_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ATTAC_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("attac", model.ValCodattac);

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
		public ActionResult MFAttac_New_GET()
		{
			return MFAttac_New();
		}

		//
		// GET /Attac/MFAttac_Edit
		[HttpGet]
		[ActionName("MFAttac_Edit")]
		public ActionResult MFAttac_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ATTAC", "EDIT", new { id = id, partialView = "MFAttac", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFAttac_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFAttac_Edit(requestModel);
		}

		//
		// GET /Attac/MFAttac_Cancel
		[ActionName("MFAttac_Cancel")]
		public ActionResult MFAttac_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Attac(UserContext.Current);
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
		// POST /Attac/MFAttac_Save
		[HttpPost]
		[ActionName("MFAttac_Save")]
		public JsonResult MFAttac_Save(Attac_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFAttac_Save",
				ViewName = "MFAttac",
				AreaName = "attac"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Attac/MFAttac_Delete
		[HttpPost]
		[ActionName("MFAttac_Delete")]
		public JsonResult MFAttac_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFAttac_Delete",
				ViewName = "MFAttac",
				AreaName = "attac",
				Location = ACTION_ATTAC_EDIT
			};

			var model = new Attac_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Attac/Attac_AssetValName
		// POST: /Attac/Attac_AssetValName
		[ActionName("Attac_AssetValName")]
		public ActionResult Attac_AssetValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asset")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asset");
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
			Attac_AssetValName_ViewModel model = new Attac_AssetValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodattac = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Attac/Attac_SaveEdit
		[HttpPost]
		public ActionResult Attac_SaveEdit([FromBody]Attac_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_SaveEdit",
				ViewName = "Attac",
				AreaName = "attac",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ATTAC]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
