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
using GenioMVC.ViewModels.Wareh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TMLINE_CANCEL = new NavigationLocation("TIMELINE45857", "Tmline_Cancel", "Wareh") { vueRouteName = "form-TMLINE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TMLINE_SHOW = new NavigationLocation("TIMELINE45857", "Tmline_Show", "Wareh") { vueRouteName = "form-TMLINE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TMLINE_NEW = new NavigationLocation("TIMELINE45857", "Tmline_New", "Wareh") { vueRouteName = "form-TMLINE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TMLINE_EDIT = new NavigationLocation("TIMELINE45857", "Tmline_Edit", "Wareh") { vueRouteName = "form-TMLINE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TMLINE_DUPLICATE = new NavigationLocation("TIMELINE45857", "Tmline_Duplicate", "Wareh") { vueRouteName = "form-TMLINE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TMLINE_DELETE = new NavigationLocation("TIMELINE45857", "Tmline_Delete", "Wareh") { vueRouteName = "form-TMLINE", mode = "DELETE" };

		#endregion

		#region Tmline private

		private void FormHistoryLimits_Tmline()
		{

		}

		#endregion

		public ActionResult Tmline_ModalDBEdit()
		{
			Tmline_ViewModel model = new Tmline_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Tmline_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TMLINE]/

		[HttpPost]
		public ActionResult Tmline_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tmline_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Show_GET",
				AreaName = "wareh",
				Location = ACTION_TMLINE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TMLINE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tmline_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TMLINE]/
		[HttpPost]
		public ActionResult Tmline_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tmline_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_New_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TMLINE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Tmline_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_New([FromBody]Tmline_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_New",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TMLINE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TMLINE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TMLINE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tmline_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tmline_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Edit_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TMLINE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Tmline_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Edit([FromBody]Tmline_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Edit",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TMLINE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TMLINE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TMLINE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tmline_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tmline_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Delete_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TMLINE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Tmline_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tmline_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Delete",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TMLINE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tmline_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TMLINE");
		}

		#endregion

		#region Tmline_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TMLINE]/

		[HttpPost]
		public ActionResult Tmline_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tmline_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Duplicate_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TMLINE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Tmline_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Duplicate([FromBody]Tmline_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_Duplicate",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TMLINE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TMLINE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TMLINE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tmline_Cancel

		//
		// GET: /Wareh/Tmline_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TMLINE]/
		public ActionResult Tmline_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wareh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL TMLINE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TMLINE]/

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

				Navigation.SetValue("ForcePrimaryRead_wareh", "true", true);
			}

			Navigation.ClearValue("wareh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Tmline Multiform actions

		//
		// GET /Wareh/MFTmline_New
		[HttpGet]
		[ActionName("MFTmline_New")]
		public ActionResult MFTmline_New()
		{
			var model = new Tmline_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_TMLINE_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("wareh", model.ValCodwareh);

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
		public ActionResult MFTmline_New_GET()
		{
			return MFTmline_New();
		}

		//
		// GET /Wareh/MFTmline_Edit
		[HttpGet]
		[ActionName("MFTmline_Edit")]
		public ActionResult MFTmline_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("TMLINE", "EDIT", new { id = id, partialView = "MFTmline", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFTmline_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFTmline_Edit(requestModel);
		}

		//
		// GET /Wareh/MFTmline_Cancel
		[ActionName("MFTmline_Cancel")]
		public ActionResult MFTmline_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Wareh(UserContext.Current);
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
		// POST /Wareh/MFTmline_Save
		[HttpPost]
		[ActionName("MFTmline_Save")]
		public JsonResult MFTmline_Save(Tmline_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFTmline_Save",
				ViewName = "MFTmline",
				AreaName = "wareh"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Wareh/MFTmline_Delete
		[HttpPost]
		[ActionName("MFTmline_Delete")]
		public JsonResult MFTmline_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFTmline_Delete",
				ViewName = "MFTmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_EDIT
			};

			var model = new Tmline_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Wareh/Tmline_ValTmdsaid
		// POST: /Wareh/Tmline_ValTmdsaid
		[ActionName("Tmline_ValTmdsaid")]
		public ActionResult Tmline_ValTmdsaid([FromBody]RequestLookupModel requestModel)
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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Tmline_ValTmdsaid_ViewModel model = new Tmline_ValTmdsaid_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodwareh = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Wareh/Tmline_SaveEdit
		[HttpPost]
		public ActionResult Tmline_SaveEdit([FromBody]Tmline_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tmline_SaveEdit",
				ViewName = "Tmline",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TMLINE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
