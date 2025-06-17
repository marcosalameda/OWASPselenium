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
using GenioMVC.ViewModels.Rules;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RULES]/

namespace GenioMVC.Controllers
{
	public partial class RulesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REGRA_CANCEL = new("REGRA09608", "Regra_Cancel", "Rules") { vueRouteName = "form-REGRA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGRA_SHOW = new("REGRA09608", "Regra_Show", "Rules") { vueRouteName = "form-REGRA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGRA_NEW = new("REGRA09608", "Regra_New", "Rules") { vueRouteName = "form-REGRA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGRA_EDIT = new("REGRA09608", "Regra_Edit", "Rules") { vueRouteName = "form-REGRA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGRA_DUPLICATE = new("REGRA09608", "Regra_Duplicate", "Rules") { vueRouteName = "form-REGRA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGRA_DELETE = new("REGRA09608", "Regra_Delete", "Rules") { vueRouteName = "form-REGRA", mode = "DELETE" };

		#endregion

		#region Regra private

		private void FormHistoryLimits_Regra()
		{

		}

		#endregion

		#region Regra_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGRA]/

		[HttpPost]
		public ActionResult Regra_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regra_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Show_GET",
				AreaName = "rules",
				Location = ACTION_REGRA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regra();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGRA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regra_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGRA]/
		[HttpPost]
		public ActionResult Regra_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Regra_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regra_New_GET",
				AreaName = "rules",
				FormName = "REGRA",
				Location = ACTION_REGRA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regra();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGRA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Rules/Regra_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGRA]/
		[HttpPost]
		public ActionResult Regra_New([FromBody]Regra_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_New",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGRA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGRA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGRA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regra_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGRA]/
		[HttpPost]
		public ActionResult Regra_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regra_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Edit_GET",
				AreaName = "rules",
				FormName = "REGRA",
				Location = ACTION_REGRA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regra();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGRA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Rules/Regra_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGRA]/
		[HttpPost]
		public ActionResult Regra_Edit([FromBody]Regra_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Edit",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGRA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGRA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGRA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regra_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGRA]/
		[HttpPost]
		public ActionResult Regra_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regra_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Delete_GET",
				AreaName = "rules",
				FormName = "REGRA",
				Location = ACTION_REGRA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regra();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGRA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Rules/Regra_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGRA]/
		[HttpPost]
		public ActionResult Regra_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regra_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regra_Delete",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGRA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regra_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGRA");
		}

		#endregion

		#region Regra_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGRA]/

		[HttpPost]
		public ActionResult Regra_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Regra_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Duplicate_GET",
				AreaName = "rules",
				FormName = "REGRA",
				Location = ACTION_REGRA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGRA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Rules/Regra_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGRA]/
		[HttpPost]
		public ActionResult Regra_Duplicate([FromBody]Regra_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Duplicate",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGRA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGRA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGRA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regra_Cancel

		//
		// GET: /Rules/Regra_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGRA]/
		public ActionResult Regra_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Rules(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("rules");

// USE /[MANUAL GQT BEFORE_CANCEL REGRA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGRA]/

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

				Navigation.SetValue("ForcePrimaryRead_rules", "true", true);
			}

			Navigation.ClearValue("rules");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Rules/Regra_SaveEdit
		[HttpPost]
		public ActionResult Regra_SaveEdit([FromBody] Regra_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_SaveEdit",
				ViewName = "Regra",
				AreaName = "rules",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGRA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class RegraDocumValidateTickets : RequestDocumValidateTickets
		{
			public Regra_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRegra([FromBody] RegraDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
