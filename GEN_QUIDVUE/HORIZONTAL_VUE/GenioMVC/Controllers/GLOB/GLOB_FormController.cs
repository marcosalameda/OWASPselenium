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
using GenioMVC.ViewModels.Glob;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GLOB]/

namespace GenioMVC.Controllers
{
	public partial class GlobController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GLOB_CANCEL = new("CONFIGURACAO_DE_HOME06050", "Glob_Cancel", "Glob") { vueRouteName = "form-GLOB", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GLOB_SHOW = new("CONFIGURACAO_DE_HOME06050", "Glob_Show", "Glob") { vueRouteName = "form-GLOB", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GLOB_NEW = new("CONFIGURACAO_DE_HOME06050", "Glob_New", "Glob") { vueRouteName = "form-GLOB", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GLOB_EDIT = new("CONFIGURACAO_DE_HOME06050", "Glob_Edit", "Glob") { vueRouteName = "form-GLOB", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GLOB_DUPLICATE = new("CONFIGURACAO_DE_HOME06050", "Glob_Duplicate", "Glob") { vueRouteName = "form-GLOB", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GLOB_DELETE = new("CONFIGURACAO_DE_HOME06050", "Glob_Delete", "Glob") { vueRouteName = "form-GLOB", mode = "DELETE" };

		#endregion

		#region Glob private

		private void FormHistoryLimits_Glob()
		{

		}

		#endregion

		#region Glob_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GLOB]/

		[HttpPost]
		public ActionResult Glob_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Glob_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Glob_Show_GET",
				AreaName = "glob",
				Location = ACTION_GLOB_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Glob();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GLOB]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Glob_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GLOB]/
		[HttpPost]
		public ActionResult Glob_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Glob_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Glob_New_GET",
				AreaName = "glob",
				FormName = "GLOB",
				Location = ACTION_GLOB_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Glob();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GLOB]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Glob/Glob_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GLOB]/
		[HttpPost]
		public ActionResult Glob_New([FromBody]Glob_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Glob_New",
				ViewName = "Glob",
				AreaName = "glob",
				Location = ACTION_GLOB_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GLOB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GLOB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GLOB]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Glob_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GLOB]/
		[HttpPost]
		public ActionResult Glob_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Glob_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Glob_Edit_GET",
				AreaName = "glob",
				FormName = "GLOB",
				Location = ACTION_GLOB_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Glob();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GLOB]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Glob/Glob_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GLOB]/
		[HttpPost]
		public ActionResult Glob_Edit([FromBody]Glob_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Glob_Edit",
				ViewName = "Glob",
				AreaName = "glob",
				Location = ACTION_GLOB_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GLOB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GLOB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GLOB]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Glob_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GLOB]/
		[HttpPost]
		public ActionResult Glob_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Glob_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Glob_Delete_GET",
				AreaName = "glob",
				FormName = "GLOB",
				Location = ACTION_GLOB_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Glob();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GLOB]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Glob/Glob_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GLOB]/
		[HttpPost]
		public ActionResult Glob_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Glob_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Glob_Delete",
				ViewName = "Glob",
				AreaName = "glob",
				Location = ACTION_GLOB_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GLOB]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Glob_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GLOB");
		}

		#endregion

		#region Glob_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GLOB]/

		[HttpPost]
		public ActionResult Glob_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Glob_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Glob_Duplicate_GET",
				AreaName = "glob",
				FormName = "GLOB",
				Location = ACTION_GLOB_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GLOB]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Glob/Glob_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GLOB]/
		[HttpPost]
		public ActionResult Glob_Duplicate([FromBody]Glob_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Glob_Duplicate",
				ViewName = "Glob",
				AreaName = "glob",
				Location = ACTION_GLOB_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GLOB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GLOB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GLOB]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Glob_Cancel

		//
		// GET: /Glob/Glob_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GLOB]/
		public ActionResult Glob_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Glob(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("glob");

// USE /[MANUAL GQT BEFORE_CANCEL GLOB]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GLOB]/

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

				Navigation.SetValue("ForcePrimaryRead_glob", "true", true);
			}

			Navigation.ClearValue("glob");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Glob/Glob_SaveEdit
		[HttpPost]
		public ActionResult Glob_SaveEdit([FromBody] Glob_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Glob_SaveEdit",
				ViewName = "Glob",
				AreaName = "glob",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GLOB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GLOB]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class GlobDocumValidateTickets : RequestDocumValidateTickets
		{
			public Glob_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGlob([FromBody] GlobDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
