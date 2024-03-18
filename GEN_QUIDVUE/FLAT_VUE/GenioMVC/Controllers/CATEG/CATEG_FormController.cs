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
using GenioMVC.ViewModels.Categ;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CATEG]/

namespace GenioMVC.Controllers
{
	public partial class CategController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CATEG_CANCEL = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Categ_Cancel", "Categ") { vueRouteName = "form-CATEG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CATEG_SHOW = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Categ_Show", "Categ") { vueRouteName = "form-CATEG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CATEG_NEW = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Categ_New", "Categ") { vueRouteName = "form-CATEG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CATEG_EDIT = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Categ_Edit", "Categ") { vueRouteName = "form-CATEG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CATEG_DUPLICATE = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Categ_Duplicate", "Categ") { vueRouteName = "form-CATEG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CATEG_DELETE = new NavigationLocation("PROFESSIONAL_CATEGOR16809", "Categ_Delete", "Categ") { vueRouteName = "form-CATEG", mode = "DELETE" };

		#endregion

		#region Categ private

		private void FormHistoryLimits_Categ()
		{

		}

		#endregion

		public ActionResult Categ_ModalDBEdit()
		{
			Categ_ViewModel model = new Categ_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Categ_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CATEG]/

		[HttpPost]
		public ActionResult Categ_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Categ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Categ_Show_GET",
				AreaName = "categ",
				Location = ACTION_CATEG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Categ();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CATEG]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Categ_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CATEG]/
		[HttpPost]
		public ActionResult Categ_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Categ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Categ_New_GET",
				AreaName = "categ",
				FormName = "CATEG",
				Location = ACTION_CATEG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Categ();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CATEG]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Categ/Categ_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CATEG]/
		[HttpPost]
		public ActionResult Categ_New([FromBody]Categ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Categ_New",
				ViewName = "Categ",
				AreaName = "categ",
				Location = ACTION_CATEG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CATEG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CATEG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CATEG]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Categ_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CATEG]/
		[HttpPost]
		public ActionResult Categ_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Categ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Categ_Edit_GET",
				AreaName = "categ",
				FormName = "CATEG",
				Location = ACTION_CATEG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Categ();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CATEG]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Categ/Categ_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CATEG]/
		[HttpPost]
		public ActionResult Categ_Edit([FromBody]Categ_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Categ_Edit",
				ViewName = "Categ",
				AreaName = "categ",
				Location = ACTION_CATEG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CATEG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CATEG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CATEG]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Categ_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CATEG]/
		[HttpPost]
		public ActionResult Categ_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Categ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Categ_Delete_GET",
				AreaName = "categ",
				FormName = "CATEG",
				Location = ACTION_CATEG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Categ();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CATEG]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Categ/Categ_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CATEG]/
		[HttpPost]
		public ActionResult Categ_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Categ_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Categ_Delete",
				ViewName = "Categ",
				AreaName = "categ",
				Location = ACTION_CATEG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CATEG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Categ_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CATEG");
		}

		#endregion

		#region Categ_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CATEG]/

		[HttpPost]
		public ActionResult Categ_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Categ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Categ_Duplicate_GET",
				AreaName = "categ",
				FormName = "CATEG",
				Location = ACTION_CATEG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CATEG]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Categ/Categ_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CATEG]/
		[HttpPost]
		public ActionResult Categ_Duplicate([FromBody]Categ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Categ_Duplicate",
				ViewName = "Categ",
				AreaName = "categ",
				Location = ACTION_CATEG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CATEG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CATEG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CATEG]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Categ_Cancel

		//
		// GET: /Categ/Categ_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CATEG]/
		public ActionResult Categ_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Categ(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("categ");

// USE /[MANUAL GQT BEFORE_CANCEL CATEG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CATEG]/

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

				Navigation.SetValue("ForcePrimaryRead_categ", "true", true);
			}

			Navigation.ClearValue("categ");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Categ Multiform actions

		//
		// GET /Categ/MFCateg_New
		[HttpGet]
		[ActionName("MFCateg_New")]
		public ActionResult MFCateg_New()
		{
			var model = new Categ_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_CATEG_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("categ", model.ValCodcateg);

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
		public ActionResult MFCateg_New_GET()
		{
			return MFCateg_New();
		}

		//
		// GET /Categ/MFCateg_Edit
		[HttpGet]
		[ActionName("MFCateg_Edit")]
		public ActionResult MFCateg_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("CATEG", "EDIT", new { id = id, partialView = "MFCateg", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFCateg_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFCateg_Edit(requestModel);
		}

		//
		// GET /Categ/MFCateg_Cancel
		[ActionName("MFCateg_Cancel")]
		public ActionResult MFCateg_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Categ(UserContext.Current);
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
		// POST /Categ/MFCateg_Save
		[HttpPost]
		[ActionName("MFCateg_Save")]
		public JsonResult MFCateg_Save(Categ_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFCateg_Save",
				ViewName = "MFCateg",
				AreaName = "categ"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Categ/MFCateg_Delete
		[HttpPost]
		[ActionName("MFCateg_Delete")]
		public JsonResult MFCateg_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFCateg_Delete",
				ViewName = "MFCateg",
				AreaName = "categ",
				Location = ACTION_CATEG_EDIT
			};

			var model = new Categ_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Categ/Categ_SaveEdit
		[HttpPost]
		public ActionResult Categ_SaveEdit([FromBody]Categ_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Categ_SaveEdit",
				ViewName = "Categ",
				AreaName = "categ",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CATEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CATEG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
