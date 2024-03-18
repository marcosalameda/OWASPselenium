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
using GenioMVC.ViewModels.Sbcat;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SBCAT]/

namespace GenioMVC.Controllers
{
	public partial class SbcatController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_SBCAT_CANCEL = new NavigationLocation("SUB_CATEGORY06342", "Sbcat_Cancel", "Sbcat") { vueRouteName = "form-SBCAT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_SBCAT_SHOW = new NavigationLocation("SUB_CATEGORY06342", "Sbcat_Show", "Sbcat") { vueRouteName = "form-SBCAT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_SBCAT_NEW = new NavigationLocation("SUB_CATEGORY06342", "Sbcat_New", "Sbcat") { vueRouteName = "form-SBCAT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_SBCAT_EDIT = new NavigationLocation("SUB_CATEGORY06342", "Sbcat_Edit", "Sbcat") { vueRouteName = "form-SBCAT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_SBCAT_DUPLICATE = new NavigationLocation("SUB_CATEGORY06342", "Sbcat_Duplicate", "Sbcat") { vueRouteName = "form-SBCAT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_SBCAT_DELETE = new NavigationLocation("SUB_CATEGORY06342", "Sbcat_Delete", "Sbcat") { vueRouteName = "form-SBCAT", mode = "DELETE" };

		#endregion

		#region Sbcat private

		private void FormHistoryLimits_Sbcat()
		{

		}

		#endregion

		public ActionResult Sbcat_ModalDBEdit()
		{
			Sbcat_ViewModel model = new Sbcat_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Sbcat_Show

// USE /[MANUAL GQT CONTROLLER_SHOW SBCAT]/

		[HttpPost]
		public ActionResult Sbcat_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Sbcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Show_GET",
				AreaName = "sbcat",
				Location = ACTION_SBCAT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Sbcat();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW SBCAT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Sbcat_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Sbcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_New_GET",
				AreaName = "sbcat",
				FormName = "SBCAT",
				Location = ACTION_SBCAT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Sbcat();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW SBCAT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sbcat/Sbcat_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_New([FromBody]Sbcat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_New",
				ViewName = "Sbcat",
				AreaName = "sbcat",
				Location = ACTION_SBCAT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW SBCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX SBCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX SBCAT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Sbcat_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Sbcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Edit_GET",
				AreaName = "sbcat",
				FormName = "SBCAT",
				Location = ACTION_SBCAT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Sbcat();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT SBCAT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sbcat/Sbcat_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_Edit([FromBody]Sbcat_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Edit",
				ViewName = "Sbcat",
				AreaName = "sbcat",
				Location = ACTION_SBCAT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT SBCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX SBCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX SBCAT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Sbcat_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Sbcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Delete_GET",
				AreaName = "sbcat",
				FormName = "SBCAT",
				Location = ACTION_SBCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Sbcat();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE SBCAT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sbcat/Sbcat_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Sbcat_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Delete",
				ViewName = "Sbcat",
				AreaName = "sbcat",
				Location = ACTION_SBCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE SBCAT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Sbcat_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("SBCAT");
		}

		#endregion

		#region Sbcat_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET SBCAT]/

		[HttpPost]
		public ActionResult Sbcat_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Sbcat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Duplicate_GET",
				AreaName = "sbcat",
				FormName = "SBCAT",
				Location = ACTION_SBCAT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE SBCAT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sbcat/Sbcat_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST SBCAT]/
		[HttpPost]
		public ActionResult Sbcat_Duplicate([FromBody]Sbcat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_Duplicate",
				ViewName = "Sbcat",
				AreaName = "sbcat",
				Location = ACTION_SBCAT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE SBCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX SBCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX SBCAT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Sbcat_Cancel

		//
		// GET: /Sbcat/Sbcat_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET SBCAT]/
		public ActionResult Sbcat_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sbcat(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sbcat");

// USE /[MANUAL GQT BEFORE_CANCEL SBCAT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL SBCAT]/

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

				Navigation.SetValue("ForcePrimaryRead_sbcat", "true", true);
			}

			Navigation.ClearValue("sbcat");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Sbcat Multiform actions

		//
		// GET /Sbcat/MFSbcat_New
		[HttpGet]
		[ActionName("MFSbcat_New")]
		public ActionResult MFSbcat_New()
		{
			var model = new Sbcat_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_SBCAT_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("sbcat", model.ValCodsbcat);

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
		public ActionResult MFSbcat_New_GET()
		{
			return MFSbcat_New();
		}

		//
		// GET /Sbcat/MFSbcat_Edit
		[HttpGet]
		[ActionName("MFSbcat_Edit")]
		public ActionResult MFSbcat_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("SBCAT", "EDIT", new { id = id, partialView = "MFSbcat", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFSbcat_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFSbcat_Edit(requestModel);
		}

		//
		// GET /Sbcat/MFSbcat_Cancel
		[ActionName("MFSbcat_Cancel")]
		public ActionResult MFSbcat_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Sbcat(UserContext.Current);
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
		// POST /Sbcat/MFSbcat_Save
		[HttpPost]
		[ActionName("MFSbcat_Save")]
		public JsonResult MFSbcat_Save(Sbcat_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFSbcat_Save",
				ViewName = "MFSbcat",
				AreaName = "sbcat"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sbcat/MFSbcat_Delete
		[HttpPost]
		[ActionName("MFSbcat_Delete")]
		public JsonResult MFSbcat_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFSbcat_Delete",
				ViewName = "MFSbcat",
				AreaName = "sbcat",
				Location = ACTION_SBCAT_EDIT
			};

			var model = new Sbcat_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Sbcat/Sbcat_SaveEdit
		[HttpPost]
		public ActionResult Sbcat_SaveEdit([FromBody]Sbcat_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Sbcat_SaveEdit",
				ViewName = "Sbcat",
				AreaName = "sbcat",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT SBCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT SBCAT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
