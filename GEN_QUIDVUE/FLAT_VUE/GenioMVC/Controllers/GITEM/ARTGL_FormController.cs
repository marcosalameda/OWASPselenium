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
using GenioMVC.ViewModels.Gitem;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GITEM]/

namespace GenioMVC.Controllers
{
	public partial class GitemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARTGL_CANCEL = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Cancel", "Gitem") { vueRouteName = "form-ARTGL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTGL_SHOW = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Show", "Gitem") { vueRouteName = "form-ARTGL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTGL_NEW = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_New", "Gitem") { vueRouteName = "form-ARTGL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTGL_EDIT = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Edit", "Gitem") { vueRouteName = "form-ARTGL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTGL_DUPLICATE = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Duplicate", "Gitem") { vueRouteName = "form-ARTGL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTGL_DELETE = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Delete", "Gitem") { vueRouteName = "form-ARTGL", mode = "DELETE" };

		#endregion

		#region Artgl private

		private void FormHistoryLimits_Artgl()
		{

		}

		#endregion

		public ActionResult Artgl_ModalDBEdit()
		{
			Artgl_ViewModel model = new Artgl_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Artgl_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTGL]/

		[HttpPost]
		public ActionResult Artgl_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artgl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Show_GET",
				AreaName = "gitem",
				Location = ACTION_ARTGL_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artgl();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTGL]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Artgl_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTGL]/
		[HttpPost]
		public ActionResult Artgl_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Artgl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_New_GET",
				AreaName = "gitem",
				FormName = "ARTGL",
				Location = ACTION_ARTGL_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Artgl();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTGL]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Gitem/Artgl_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTGL]/
		[HttpPost]
		public ActionResult Artgl_New([FromBody]Artgl_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_New",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTGL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTGL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTGL]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Artgl_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTGL]/
		[HttpPost]
		public ActionResult Artgl_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artgl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Edit_GET",
				AreaName = "gitem",
				FormName = "ARTGL",
				Location = ACTION_ARTGL_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artgl();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTGL]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Gitem/Artgl_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTGL]/
		[HttpPost]
		public ActionResult Artgl_Edit([FromBody]Artgl_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Edit",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTGL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTGL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTGL]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Artgl_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTGL]/
		[HttpPost]
		public ActionResult Artgl_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artgl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Delete_GET",
				AreaName = "gitem",
				FormName = "ARTGL",
				Location = ACTION_ARTGL_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artgl();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTGL]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Gitem/Artgl_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTGL]/
		[HttpPost]
		public ActionResult Artgl_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artgl_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Delete",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTGL]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Artgl_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTGL");
		}

		#endregion

		#region Artgl_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTGL]/

		[HttpPost]
		public ActionResult Artgl_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Artgl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Duplicate_GET",
				AreaName = "gitem",
				FormName = "ARTGL",
				Location = ACTION_ARTGL_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTGL]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Gitem/Artgl_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTGL]/
		[HttpPost]
		public ActionResult Artgl_Duplicate([FromBody]Artgl_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Duplicate",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTGL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTGL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTGL]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Artgl_Cancel

		//
		// GET: /Gitem/Artgl_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTGL]/
		public ActionResult Artgl_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Gitem(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("gitem");

// USE /[MANUAL GQT BEFORE_CANCEL ARTGL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTGL]/

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

				Navigation.SetValue("ForcePrimaryRead_gitem", "true", true);
			}

			Navigation.ClearValue("gitem");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Artgl Multiform actions

		//
		// GET /Gitem/MFArtgl_New
		[HttpGet]
		[ActionName("MFArtgl_New")]
		public ActionResult MFArtgl_New()
		{
			var model = new Artgl_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ARTGL_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("gitem", model.ValCodgitem);

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
		public ActionResult MFArtgl_New_GET()
		{
			return MFArtgl_New();
		}

		//
		// GET /Gitem/MFArtgl_Edit
		[HttpGet]
		[ActionName("MFArtgl_Edit")]
		public ActionResult MFArtgl_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ARTGL", "EDIT", new { id = id, partialView = "MFArtgl", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFArtgl_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFArtgl_Edit(requestModel);
		}

		//
		// GET /Gitem/MFArtgl_Cancel
		[ActionName("MFArtgl_Cancel")]
		public ActionResult MFArtgl_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Gitem(UserContext.Current);
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
		// POST /Gitem/MFArtgl_Save
		[HttpPost]
		[ActionName("MFArtgl_Save")]
		public JsonResult MFArtgl_Save(Artgl_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFArtgl_Save",
				ViewName = "MFArtgl",
				AreaName = "gitem"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Gitem/MFArtgl_Delete
		[HttpPost]
		[ActionName("MFArtgl_Delete")]
		public JsonResult MFArtgl_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFArtgl_Delete",
				ViewName = "MFArtgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_EDIT
			};

			var model = new Artgl_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Gitem/Artgl_SaveEdit
		[HttpPost]
		public ActionResult Artgl_SaveEdit([FromBody]Artgl_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_SaveEdit",
				ViewName = "Artgl",
				AreaName = "gitem",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTGL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
