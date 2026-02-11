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
using System.Dynamic;

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
using GenioMVC.ViewModels.Wareh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TMLINE_CANCEL = new("TIMELINE45857", "Tmline_Cancel", "Wareh") { vueRouteName = "form-TMLINE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TMLINE_SHOW = new("TIMELINE45857", "Tmline_Show", "Wareh") { vueRouteName = "form-TMLINE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TMLINE_NEW = new("TIMELINE45857", "Tmline_New", "Wareh") { vueRouteName = "form-TMLINE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TMLINE_EDIT = new("TIMELINE45857", "Tmline_Edit", "Wareh") { vueRouteName = "form-TMLINE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TMLINE_DUPLICATE = new("TIMELINE45857", "Tmline_Duplicate", "Wareh") { vueRouteName = "form-TMLINE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TMLINE_DELETE = new("TIMELINE45857", "Tmline_Delete", "Wareh") { vueRouteName = "form-TMLINE", mode = "DELETE" };

		#endregion

		#region Tmline private

		private void FormHistoryLimits_Tmline()
		{

		}

		#endregion

		#region Tmline_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TMLINE]/

		[HttpPost]
		public ActionResult Tmline_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tmline_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tmline_Show_GET",
				AreaName = "wareh",
				Location = ACTION_TMLINE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TMLINE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tmline_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TMLINE]/
		[HttpPost]
		public ActionResult Tmline_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Tmline_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tmline_New_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TMLINE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Tmline_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_New([FromBody]Tmline_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tmline_New",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TMLINE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TMLINE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TMLINE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tmline_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tmline_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tmline_Edit_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TMLINE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Tmline_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Edit([FromBody]Tmline_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tmline_Edit",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TMLINE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TMLINE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TMLINE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tmline_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tmline_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tmline_Delete_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tmline();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TMLINE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Tmline_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tmline_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Tmline_Delete",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TMLINE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tmline_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TMLINE");
		}

		#endregion

		#region Tmline_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TMLINE]/

		[HttpPost]
		public ActionResult Tmline_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Tmline_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tmline_Duplicate_GET",
				AreaName = "wareh",
				FormName = "TMLINE",
				Location = ACTION_TMLINE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TMLINE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Tmline_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TMLINE]/
		[HttpPost]
		public ActionResult Tmline_Duplicate([FromBody]Tmline_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tmline_Duplicate",
				ViewName = "Tmline",
				AreaName = "wareh",
				Location = ACTION_TMLINE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TMLINE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TMLINE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TMLINE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tmline_Cancel

		//
		// GET: /Wareh/Tmline_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TMLINE]/
		public ActionResult Tmline_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Wareh model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL TMLINE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TMLINE]/

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

				Navigation.SetValue("ForcePrimaryRead_wareh", "true", true);
			}

			Navigation.ClearValue("wareh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tmline_ValTmdsaidModel : RequestLookupModel
		{
			public Tmline_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Tmline_ValTmdsaid
		// POST: /Wareh/Tmline_ValTmdsaid
		[ActionName("Tmline_ValTmdsaid")]
		public ActionResult Tmline_ValTmdsaid([FromBody] Tmline_ValTmdsaidModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Wareh parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tmline_ValTmdsaid_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel.TableConfiguration ?? new();

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Wareh/Tmline_SaveEdit
		[HttpPost]
		public ActionResult Tmline_SaveEdit([FromBody] Tmline_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tmline_SaveEdit",
				ViewName = "Tmline",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TMLINE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TMLINE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TmlineDocumValidateTickets : RequestDocumValidateTickets
		{
			public Tmline_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTmline([FromBody] TmlineDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
