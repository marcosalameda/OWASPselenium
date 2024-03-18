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
using GenioMVC.ViewModels.Genre;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GENRE]/

namespace GenioMVC.Controllers
{
	public partial class GenreController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GENCO_CANCEL = new NavigationLocation("CONTACT_TYPE65233", "Genco_Cancel", "Genre") { vueRouteName = "form-GENCO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GENCO_SHOW = new NavigationLocation("CONTACT_TYPE65233", "Genco_Show", "Genre") { vueRouteName = "form-GENCO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GENCO_NEW = new NavigationLocation("CONTACT_TYPE65233", "Genco_New", "Genre") { vueRouteName = "form-GENCO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GENCO_EDIT = new NavigationLocation("CONTACT_TYPE65233", "Genco_Edit", "Genre") { vueRouteName = "form-GENCO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GENCO_DUPLICATE = new NavigationLocation("CONTACT_TYPE65233", "Genco_Duplicate", "Genre") { vueRouteName = "form-GENCO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GENCO_DELETE = new NavigationLocation("CONTACT_TYPE65233", "Genco_Delete", "Genre") { vueRouteName = "form-GENCO", mode = "DELETE" };

		#endregion

		#region Genco private

		private void FormHistoryLimits_Genco()
		{

		}

		#endregion

		public ActionResult Genco_ModalDBEdit()
		{
			Genco_ViewModel model = new Genco_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Genco_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GENCO]/

		[HttpPost]
		public ActionResult Genco_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Genco_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Genco_Show_GET",
				AreaName = "genre",
				Location = ACTION_GENCO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Genco();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GENCO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Genco_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GENCO]/
		[HttpPost]
		public ActionResult Genco_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Genco_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Genco_New_GET",
				AreaName = "genre",
				FormName = "GENCO",
				Location = ACTION_GENCO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Genco();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GENCO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Genre/Genco_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GENCO]/
		[HttpPost]
		public ActionResult Genco_New([FromBody]Genco_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Genco_New",
				ViewName = "Genco",
				AreaName = "genre",
				Location = ACTION_GENCO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GENCO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GENCO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GENCO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Genco_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GENCO]/
		[HttpPost]
		public ActionResult Genco_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Genco_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Genco_Edit_GET",
				AreaName = "genre",
				FormName = "GENCO",
				Location = ACTION_GENCO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Genco();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GENCO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Genre/Genco_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GENCO]/
		[HttpPost]
		public ActionResult Genco_Edit([FromBody]Genco_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Genco_Edit",
				ViewName = "Genco",
				AreaName = "genre",
				Location = ACTION_GENCO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GENCO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GENCO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GENCO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Genco_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GENCO]/
		[HttpPost]
		public ActionResult Genco_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Genco_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Genco_Delete_GET",
				AreaName = "genre",
				FormName = "GENCO",
				Location = ACTION_GENCO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Genco();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GENCO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Genre/Genco_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GENCO]/
		[HttpPost]
		public ActionResult Genco_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Genco_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Genco_Delete",
				ViewName = "Genco",
				AreaName = "genre",
				Location = ACTION_GENCO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GENCO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Genco_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GENCO");
		}

		#endregion

		#region Genco_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GENCO]/

		[HttpPost]
		public ActionResult Genco_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Genco_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Genco_Duplicate_GET",
				AreaName = "genre",
				FormName = "GENCO",
				Location = ACTION_GENCO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GENCO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Genre/Genco_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GENCO]/
		[HttpPost]
		public ActionResult Genco_Duplicate([FromBody]Genco_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Genco_Duplicate",
				ViewName = "Genco",
				AreaName = "genre",
				Location = ACTION_GENCO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GENCO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GENCO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GENCO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Genco_Cancel

		//
		// GET: /Genre/Genco_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GENCO]/
		public ActionResult Genco_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Genre(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("genre");

// USE /[MANUAL GQT BEFORE_CANCEL GENCO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GENCO]/

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

				Navigation.SetValue("ForcePrimaryRead_genre", "true", true);
			}

			Navigation.ClearValue("genre");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Genco Multiform actions

		//
		// GET /Genre/MFGenco_New
		[HttpGet]
		[ActionName("MFGenco_New")]
		public ActionResult MFGenco_New()
		{
			var model = new Genco_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_GENCO_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("genre", model.ValCodgenre);

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
		public ActionResult MFGenco_New_GET()
		{
			return MFGenco_New();
		}

		//
		// GET /Genre/MFGenco_Edit
		[HttpGet]
		[ActionName("MFGenco_Edit")]
		public ActionResult MFGenco_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("GENCO", "EDIT", new { id = id, partialView = "MFGenco", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFGenco_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFGenco_Edit(requestModel);
		}

		//
		// GET /Genre/MFGenco_Cancel
		[ActionName("MFGenco_Cancel")]
		public ActionResult MFGenco_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Genre(UserContext.Current);
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
		// POST /Genre/MFGenco_Save
		[HttpPost]
		[ActionName("MFGenco_Save")]
		public JsonResult MFGenco_Save(Genco_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGenco_Save",
				ViewName = "MFGenco",
				AreaName = "genre"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Genre/MFGenco_Delete
		[HttpPost]
		[ActionName("MFGenco_Delete")]
		public JsonResult MFGenco_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFGenco_Delete",
				ViewName = "MFGenco",
				AreaName = "genre",
				Location = ACTION_GENCO_EDIT
			};

			var model = new Genco_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Genre/Genco_SaveEdit
		[HttpPost]
		public ActionResult Genco_SaveEdit([FromBody]Genco_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Genco_SaveEdit",
				ViewName = "Genco",
				AreaName = "genre",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GENCO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GENCO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
