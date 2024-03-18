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
using GenioMVC.ViewModels.Cate1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CATE1]/

namespace GenioMVC.Controllers
{
	public partial class Cate1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CATE1_CANCEL = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Cate1_Cancel", "Cate1") { vueRouteName = "form-CATE1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CATE1_SHOW = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Cate1_Show", "Cate1") { vueRouteName = "form-CATE1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CATE1_NEW = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Cate1_New", "Cate1") { vueRouteName = "form-CATE1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CATE1_EDIT = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Cate1_Edit", "Cate1") { vueRouteName = "form-CATE1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CATE1_DUPLICATE = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Cate1_Duplicate", "Cate1") { vueRouteName = "form-CATE1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CATE1_DELETE = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Cate1_Delete", "Cate1") { vueRouteName = "form-CATE1", mode = "DELETE" };

		#endregion

		#region Cate1 private

		private void FormHistoryLimits_Cate1()
		{

		}

		#endregion

		public ActionResult Cate1_ModalDBEdit()
		{
			Cate1_ViewModel model = new Cate1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cate1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CATE1]/

		[HttpPost]
		public ActionResult Cate1_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Show_GET",
				AreaName = "cate1",
				Location = ACTION_CATE1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CATE1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Cate1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CATE1]/
		[HttpPost]
		public ActionResult Cate1_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_New_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CATE1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cate1/Cate1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_New([FromBody]Cate1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_New",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CATE1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CATE1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CATE1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Cate1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CATE1]/
		[HttpPost]
		public ActionResult Cate1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Edit_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CATE1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cate1/Cate1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_Edit([FromBody]Cate1_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Edit",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CATE1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CATE1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CATE1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Cate1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CATE1]/
		[HttpPost]
		public ActionResult Cate1_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Delete_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CATE1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cate1/Cate1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Delete",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CATE1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Cate1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CATE1");
		}

		#endregion

		#region Cate1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CATE1]/

		[HttpPost]
		public ActionResult Cate1_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Duplicate_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CATE1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cate1/Cate1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_Duplicate([FromBody]Cate1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Duplicate",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CATE1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CATE1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CATE1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Cate1_Cancel

		//
		// GET: /Cate1/Cate1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CATE1]/
		public ActionResult Cate1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cate1(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cate1");

// USE /[MANUAL GQT BEFORE_CANCEL CATE1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CATE1]/

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

				Navigation.SetValue("ForcePrimaryRead_cate1", "true", true);
			}

			Navigation.ClearValue("cate1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Cate1 Multiform actions

		//
		// GET /Cate1/MFCate1_New
		[HttpGet]
		[ActionName("MFCate1_New")]
		public ActionResult MFCate1_New()
		{
			var model = new Cate1_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_CATE1_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("cate1", model.ValCodcateg);

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
		public ActionResult MFCate1_New_GET()
		{
			return MFCate1_New();
		}

		//
		// GET /Cate1/MFCate1_Edit
		[HttpGet]
		[ActionName("MFCate1_Edit")]
		public ActionResult MFCate1_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("CATE1", "EDIT", new { id = id, partialView = "MFCate1", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFCate1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFCate1_Edit(requestModel);
		}

		//
		// GET /Cate1/MFCate1_Cancel
		[ActionName("MFCate1_Cancel")]
		public ActionResult MFCate1_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Cate1(UserContext.Current);
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
		// POST /Cate1/MFCate1_Save
		[HttpPost]
		[ActionName("MFCate1_Save")]
		public JsonResult MFCate1_Save(Cate1_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFCate1_Save",
				ViewName = "MFCate1",
				AreaName = "cate1"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Cate1/MFCate1_Delete
		[HttpPost]
		[ActionName("MFCate1_Delete")]
		public JsonResult MFCate1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFCate1_Delete",
				ViewName = "MFCate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_EDIT
			};

			var model = new Cate1_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Cate1/Cate1_SaveEdit
		[HttpPost]
		public ActionResult Cate1_SaveEdit([FromBody]Cate1_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_SaveEdit",
				ViewName = "Cate1",
				AreaName = "cate1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CATE1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
