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
using GenioMVC.ViewModels.Addre;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ADDRE]/

namespace GenioMVC.Controllers
{
	public partial class AddreController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ADDRE_CANCEL = new NavigationLocation("ADDRESS04342", "Addre_Cancel", "Addre") { vueRouteName = "form-ADDRE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ADDRE_SHOW = new NavigationLocation("ADDRESS04342", "Addre_Show", "Addre") { vueRouteName = "form-ADDRE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ADDRE_NEW = new NavigationLocation("ADDRESS04342", "Addre_New", "Addre") { vueRouteName = "form-ADDRE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ADDRE_EDIT = new NavigationLocation("ADDRESS04342", "Addre_Edit", "Addre") { vueRouteName = "form-ADDRE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ADDRE_DUPLICATE = new NavigationLocation("ADDRESS04342", "Addre_Duplicate", "Addre") { vueRouteName = "form-ADDRE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ADDRE_DELETE = new NavigationLocation("ADDRESS04342", "Addre_Delete", "Addre") { vueRouteName = "form-ADDRE", mode = "DELETE" };

		#endregion

		#region Addre private

		private void FormHistoryLimits_Addre()
		{

		}

		#endregion

		public ActionResult Addre_ModalDBEdit()
		{
			Addre_ViewModel model = new Addre_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Addre_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ADDRE]/

		[HttpPost]
		public ActionResult Addre_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Addre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Addre_Show_GET",
				AreaName = "addre",
				Location = ACTION_ADDRE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ADDRE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Addre_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ADDRE]/
		[HttpPost]
		public ActionResult Addre_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Addre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Addre_New_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ADDRE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Addre/Addre_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_New([FromBody]Addre_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Addre_New",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ADDRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ADDRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ADDRE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Addre_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ADDRE]/
		[HttpPost]
		public ActionResult Addre_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Addre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Addre_Edit_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ADDRE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Addre/Addre_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_Edit([FromBody]Addre_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Addre_Edit",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ADDRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ADDRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ADDRE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Addre_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ADDRE]/
		[HttpPost]
		public ActionResult Addre_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Addre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Addre_Delete_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ADDRE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Addre/Addre_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Addre_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Addre_Delete",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ADDRE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Addre_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ADDRE");
		}

		#endregion

		#region Addre_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ADDRE]/

		[HttpPost]
		public ActionResult Addre_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Addre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Addre_Duplicate_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ADDRE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Addre/Addre_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_Duplicate([FromBody]Addre_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Addre_Duplicate",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ADDRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ADDRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ADDRE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Addre_Cancel

		//
		// GET: /Addre/Addre_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ADDRE]/
		public ActionResult Addre_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Addre(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("addre");

// USE /[MANUAL GQT BEFORE_CANCEL ADDRE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ADDRE]/

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

				Navigation.SetValue("ForcePrimaryRead_addre", "true", true);
			}

			Navigation.ClearValue("addre");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Addre Multiform actions

		//
		// GET /Addre/MFAddre_New
		[HttpGet]
		[ActionName("MFAddre_New")]
		public ActionResult MFAddre_New()
		{
			var model = new Addre_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ADDRE_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("addre", model.ValCodaddre);

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
		public ActionResult MFAddre_New_GET()
		{
			return MFAddre_New();
		}

		//
		// GET /Addre/MFAddre_Edit
		[HttpGet]
		[ActionName("MFAddre_Edit")]
		public ActionResult MFAddre_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ADDRE", "EDIT", new { id = id, partialView = "MFAddre", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFAddre_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFAddre_Edit(requestModel);
		}

		//
		// GET /Addre/MFAddre_Cancel
		[ActionName("MFAddre_Cancel")]
		public ActionResult MFAddre_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Addre(UserContext.Current);
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
		// POST /Addre/MFAddre_Save
		[HttpPost]
		[ActionName("MFAddre_Save")]
		public JsonResult MFAddre_Save(Addre_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFAddre_Save",
				ViewName = "MFAddre",
				AreaName = "addre"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Addre/MFAddre_Delete
		[HttpPost]
		[ActionName("MFAddre_Delete")]
		public JsonResult MFAddre_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFAddre_Delete",
				ViewName = "MFAddre",
				AreaName = "addre",
				Location = ACTION_ADDRE_EDIT
			};

			var model = new Addre_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Addre/Addre_SaveEdit
		[HttpPost]
		public ActionResult Addre_SaveEdit([FromBody]Addre_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Addre_SaveEdit",
				ViewName = "Addre",
				AreaName = "addre",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ADDRE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
