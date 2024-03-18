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
using GenioMVC.ViewModels.Rogl1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROGL1]/

namespace GenioMVC.Controllers
{
	public partial class Rogl1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ROGL1_CANCEL = new NavigationLocation("ROW_ORDER_GROUP_LEVE17934", "Rogl1_Cancel", "Rogl1") { vueRouteName = "form-ROGL1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ROGL1_SHOW = new NavigationLocation("ROW_ORDER_GROUP_LEVE17934", "Rogl1_Show", "Rogl1") { vueRouteName = "form-ROGL1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ROGL1_NEW = new NavigationLocation("ROW_ORDER_GROUP_LEVE17934", "Rogl1_New", "Rogl1") { vueRouteName = "form-ROGL1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ROGL1_EDIT = new NavigationLocation("ROW_ORDER_GROUP_LEVE17934", "Rogl1_Edit", "Rogl1") { vueRouteName = "form-ROGL1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ROGL1_DUPLICATE = new NavigationLocation("ROW_ORDER_GROUP_LEVE17934", "Rogl1_Duplicate", "Rogl1") { vueRouteName = "form-ROGL1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ROGL1_DELETE = new NavigationLocation("ROW_ORDER_GROUP_LEVE17934", "Rogl1_Delete", "Rogl1") { vueRouteName = "form-ROGL1", mode = "DELETE" };

		#endregion

		#region Rogl1 private

		private void FormHistoryLimits_Rogl1()
		{

		}

		#endregion

		public ActionResult Rogl1_ModalDBEdit()
		{
			Rogl1_ViewModel model = new Rogl1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Rogl1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ROGL1]/

		[HttpPost]
		public ActionResult Rogl1_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rogl1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Show_GET",
				AreaName = "rogl1",
				Location = ACTION_ROGL1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rogl1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ROGL1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Rogl1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Rogl1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_New_GET",
				AreaName = "rogl1",
				FormName = "ROGL1",
				Location = ACTION_ROGL1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Rogl1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ROGL1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Rogl1/Rogl1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_New([FromBody]Rogl1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_New",
				ViewName = "Rogl1",
				AreaName = "rogl1",
				Location = ACTION_ROGL1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ROGL1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ROGL1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ROGL1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Rogl1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rogl1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Edit_GET",
				AreaName = "rogl1",
				FormName = "ROGL1",
				Location = ACTION_ROGL1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rogl1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ROGL1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Rogl1/Rogl1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_Edit([FromBody]Rogl1_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Edit",
				ViewName = "Rogl1",
				AreaName = "rogl1",
				Location = ACTION_ROGL1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ROGL1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ROGL1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ROGL1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Rogl1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rogl1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Delete_GET",
				AreaName = "rogl1",
				FormName = "ROGL1",
				Location = ACTION_ROGL1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rogl1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ROGL1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Rogl1/Rogl1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rogl1_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Delete",
				ViewName = "Rogl1",
				AreaName = "rogl1",
				Location = ACTION_ROGL1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ROGL1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Rogl1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ROGL1");
		}

		#endregion

		#region Rogl1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ROGL1]/

		[HttpPost]
		public ActionResult Rogl1_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Rogl1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Duplicate_GET",
				AreaName = "rogl1",
				FormName = "ROGL1",
				Location = ACTION_ROGL1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ROGL1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Rogl1/Rogl1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ROGL1]/
		[HttpPost]
		public ActionResult Rogl1_Duplicate([FromBody]Rogl1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_Duplicate",
				ViewName = "Rogl1",
				AreaName = "rogl1",
				Location = ACTION_ROGL1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ROGL1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ROGL1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ROGL1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Rogl1_Cancel

		//
		// GET: /Rogl1/Rogl1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ROGL1]/
		public ActionResult Rogl1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Rogl1(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("rogl1");

// USE /[MANUAL GQT BEFORE_CANCEL ROGL1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ROGL1]/

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

				Navigation.SetValue("ForcePrimaryRead_rogl1", "true", true);
			}

			Navigation.ClearValue("rogl1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Rogl1 Multiform actions

		//
		// GET /Rogl1/MFRogl1_New
		[HttpGet]
		[ActionName("MFRogl1_New")]
		public ActionResult MFRogl1_New()
		{
			var model = new Rogl1_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ROGL1_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("rogl1", model.ValCodrogl1);

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
		public ActionResult MFRogl1_New_GET()
		{
			return MFRogl1_New();
		}

		//
		// GET /Rogl1/MFRogl1_Edit
		[HttpGet]
		[ActionName("MFRogl1_Edit")]
		public ActionResult MFRogl1_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ROGL1", "EDIT", new { id = id, partialView = "MFRogl1", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFRogl1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFRogl1_Edit(requestModel);
		}

		//
		// GET /Rogl1/MFRogl1_Cancel
		[ActionName("MFRogl1_Cancel")]
		public ActionResult MFRogl1_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Rogl1(UserContext.Current);
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
		// POST /Rogl1/MFRogl1_Save
		[HttpPost]
		[ActionName("MFRogl1_Save")]
		public JsonResult MFRogl1_Save(Rogl1_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRogl1_Save",
				ViewName = "MFRogl1",
				AreaName = "rogl1"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Rogl1/MFRogl1_Delete
		[HttpPost]
		[ActionName("MFRogl1_Delete")]
		public JsonResult MFRogl1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFRogl1_Delete",
				ViewName = "MFRogl1",
				AreaName = "rogl1",
				Location = ACTION_ROGL1_EDIT
			};

			var model = new Rogl1_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Rogl1/Rogl1_SaveEdit
		[HttpPost]
		public ActionResult Rogl1_SaveEdit([FromBody]Rogl1_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rogl1_SaveEdit",
				ViewName = "Rogl1",
				AreaName = "rogl1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ROGL1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ROGL1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
