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
using GenioMVC.ViewModels.Tpcon;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPCON]/

namespace GenioMVC.Controllers
{
	public partial class TpconController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TPCON_CANCEL = new NavigationLocation("CONTACT_TYPE65233", "Tpcon_Cancel", "Tpcon") { vueRouteName = "form-TPCON", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TPCON_SHOW = new NavigationLocation("CONTACT_TYPE65233", "Tpcon_Show", "Tpcon") { vueRouteName = "form-TPCON", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TPCON_NEW = new NavigationLocation("CONTACT_TYPE65233", "Tpcon_New", "Tpcon") { vueRouteName = "form-TPCON", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TPCON_EDIT = new NavigationLocation("CONTACT_TYPE65233", "Tpcon_Edit", "Tpcon") { vueRouteName = "form-TPCON", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TPCON_DUPLICATE = new NavigationLocation("CONTACT_TYPE65233", "Tpcon_Duplicate", "Tpcon") { vueRouteName = "form-TPCON", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TPCON_DELETE = new NavigationLocation("CONTACT_TYPE65233", "Tpcon_Delete", "Tpcon") { vueRouteName = "form-TPCON", mode = "DELETE" };

		#endregion

		#region Tpcon private

		private void FormHistoryLimits_Tpcon()
		{

		}

		#endregion

		public ActionResult Tpcon_ModalDBEdit()
		{
			Tpcon_ViewModel model = new Tpcon_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Tpcon_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TPCON]/

		[HttpPost]
		public ActionResult Tpcon_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcon_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Show_GET",
				AreaName = "tpcon",
				Location = ACTION_TPCON_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpcon();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TPCON]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tpcon_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TPCON]/
		[HttpPost]
		public ActionResult Tpcon_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tpcon_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_New_GET",
				AreaName = "tpcon",
				FormName = "TPCON",
				Location = ACTION_TPCON_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tpcon();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TPCON]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tpcon/Tpcon_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TPCON]/
		[HttpPost]
		public ActionResult Tpcon_New([FromBody]Tpcon_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_New",
				ViewName = "Tpcon",
				AreaName = "tpcon",
				Location = ACTION_TPCON_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TPCON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TPCON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TPCON]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tpcon_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TPCON]/
		[HttpPost]
		public ActionResult Tpcon_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcon_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Edit_GET",
				AreaName = "tpcon",
				FormName = "TPCON",
				Location = ACTION_TPCON_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpcon();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TPCON]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tpcon/Tpcon_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TPCON]/
		[HttpPost]
		public ActionResult Tpcon_Edit([FromBody]Tpcon_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Edit",
				ViewName = "Tpcon",
				AreaName = "tpcon",
				Location = ACTION_TPCON_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TPCON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TPCON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TPCON]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tpcon_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TPCON]/
		[HttpPost]
		public ActionResult Tpcon_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcon_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Delete_GET",
				AreaName = "tpcon",
				FormName = "TPCON",
				Location = ACTION_TPCON_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpcon();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TPCON]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tpcon/Tpcon_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TPCON]/
		[HttpPost]
		public ActionResult Tpcon_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tpcon_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Delete",
				ViewName = "Tpcon",
				AreaName = "tpcon",
				Location = ACTION_TPCON_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TPCON]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tpcon_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TPCON");
		}

		#endregion

		#region Tpcon_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TPCON]/

		[HttpPost]
		public ActionResult Tpcon_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tpcon_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Duplicate_GET",
				AreaName = "tpcon",
				FormName = "TPCON",
				Location = ACTION_TPCON_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TPCON]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tpcon/Tpcon_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TPCON]/
		[HttpPost]
		public ActionResult Tpcon_Duplicate([FromBody]Tpcon_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_Duplicate",
				ViewName = "Tpcon",
				AreaName = "tpcon",
				Location = ACTION_TPCON_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TPCON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TPCON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TPCON]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tpcon_Cancel

		//
		// GET: /Tpcon/Tpcon_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TPCON]/
		public ActionResult Tpcon_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tpcon(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tpcon");

// USE /[MANUAL GQT BEFORE_CANCEL TPCON]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TPCON]/

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

				Navigation.SetValue("ForcePrimaryRead_tpcon", "true", true);
			}

			Navigation.ClearValue("tpcon");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Tpcon Multiform actions

		//
		// GET /Tpcon/MFTpcon_New
		[HttpGet]
		[ActionName("MFTpcon_New")]
		public ActionResult MFTpcon_New()
		{
			var model = new Tpcon_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_TPCON_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("tpcon", model.ValCodtpcon);

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
		public ActionResult MFTpcon_New_GET()
		{
			return MFTpcon_New();
		}

		//
		// GET /Tpcon/MFTpcon_Edit
		[HttpGet]
		[ActionName("MFTpcon_Edit")]
		public ActionResult MFTpcon_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("TPCON", "EDIT", new { id = id, partialView = "MFTpcon", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFTpcon_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFTpcon_Edit(requestModel);
		}

		//
		// GET /Tpcon/MFTpcon_Cancel
		[ActionName("MFTpcon_Cancel")]
		public ActionResult MFTpcon_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Tpcon(UserContext.Current);
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
		// POST /Tpcon/MFTpcon_Save
		[HttpPost]
		[ActionName("MFTpcon_Save")]
		public JsonResult MFTpcon_Save(Tpcon_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFTpcon_Save",
				ViewName = "MFTpcon",
				AreaName = "tpcon"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Tpcon/MFTpcon_Delete
		[HttpPost]
		[ActionName("MFTpcon_Delete")]
		public JsonResult MFTpcon_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFTpcon_Delete",
				ViewName = "MFTpcon",
				AreaName = "tpcon",
				Location = ACTION_TPCON_EDIT
			};

			var model = new Tpcon_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Tpcon/Tpcon_GenreValGender
		// POST: /Tpcon/Tpcon_GenreValGender
		[ActionName("Tpcon_GenreValGender")]
		public ActionResult Tpcon_GenreValGender([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_genre")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_genre");
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
			Tpcon_GenreValGender_ViewModel model = new Tpcon_GenreValGender_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodtpcon = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Tpcon/Tpcon_SaveEdit
		[HttpPost]
		public ActionResult Tpcon_SaveEdit([FromBody]Tpcon_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tpcon_SaveEdit",
				ViewName = "Tpcon",
				AreaName = "tpcon",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TPCON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TPCON]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
