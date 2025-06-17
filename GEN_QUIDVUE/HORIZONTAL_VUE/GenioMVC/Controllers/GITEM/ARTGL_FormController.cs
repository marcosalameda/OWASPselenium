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
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Gitem;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GITEM]/

namespace GenioMVC.Controllers
{
	public partial class GitemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARTGL_CANCEL = new("GLOBAL_ARTICLE63861", "Artgl_Cancel", "Gitem") { vueRouteName = "form-ARTGL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTGL_SHOW = new("GLOBAL_ARTICLE63861", "Artgl_Show", "Gitem") { vueRouteName = "form-ARTGL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTGL_NEW = new("GLOBAL_ARTICLE63861", "Artgl_New", "Gitem") { vueRouteName = "form-ARTGL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTGL_EDIT = new("GLOBAL_ARTICLE63861", "Artgl_Edit", "Gitem") { vueRouteName = "form-ARTGL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTGL_DUPLICATE = new("GLOBAL_ARTICLE63861", "Artgl_Duplicate", "Gitem") { vueRouteName = "form-ARTGL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTGL_DELETE = new("GLOBAL_ARTICLE63861", "Artgl_Delete", "Gitem") { vueRouteName = "form-ARTGL", mode = "DELETE" };

		#endregion

		#region Artgl private

		private void FormHistoryLimits_Artgl()
		{

		}

		#endregion

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



		// POST: /Gitem/Artgl_SaveEdit
		[HttpPost]
		public ActionResult Artgl_SaveEdit([FromBody] Artgl_ViewModel model)
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

		public class ArtglDocumValidateTickets : RequestDocumValidateTickets
		{
			public Artgl_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArtgl([FromBody] ArtglDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
