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
using GenioMVC.ViewModels.Pwcom;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PWCOM]/

namespace GenioMVC.Controllers
{
	public partial class PwcomController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PWCOM_CANCEL = new("MOVING_ACCESS62712", "Pwcom_Cancel", "Pwcom") { vueRouteName = "form-PWCOM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PWCOM_SHOW = new("MOVING_ACCESS62712", "Pwcom_Show", "Pwcom") { vueRouteName = "form-PWCOM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PWCOM_NEW = new("MOVING_ACCESS62712", "Pwcom_New", "Pwcom") { vueRouteName = "form-PWCOM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PWCOM_EDIT = new("MOVING_ACCESS62712", "Pwcom_Edit", "Pwcom") { vueRouteName = "form-PWCOM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PWCOM_DUPLICATE = new("MOVING_ACCESS62712", "Pwcom_Duplicate", "Pwcom") { vueRouteName = "form-PWCOM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PWCOM_DELETE = new("MOVING_ACCESS62712", "Pwcom_Delete", "Pwcom") { vueRouteName = "form-PWCOM", mode = "DELETE" };

		#endregion

		#region Pwcom private

		private void FormHistoryLimits_Pwcom()
		{

		}

		#endregion

		#region Pwcom_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PWCOM]/

		[HttpPost]
		public ActionResult Pwcom_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pwcom_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Show_GET",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PWCOM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pwcom_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Pwcom_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_New_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PWCOM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pwcom/Pwcom_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_New([FromBody]Pwcom_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_New",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PWCOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PWCOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PWCOM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pwcom_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pwcom_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Edit_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PWCOM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pwcom/Pwcom_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Edit([FromBody]Pwcom_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Edit",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PWCOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PWCOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PWCOM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pwcom_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pwcom_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Delete_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PWCOM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pwcom/Pwcom_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pwcom_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Delete",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PWCOM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pwcom_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PWCOM");
		}

		#endregion

		#region Pwcom_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PWCOM]/

		[HttpPost]
		public ActionResult Pwcom_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Pwcom_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Duplicate_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PWCOM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pwcom/Pwcom_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Duplicate([FromBody]Pwcom_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_Duplicate",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PWCOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PWCOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PWCOM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pwcom_Cancel

		//
		// GET: /Pwcom/Pwcom_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PWCOM]/
		public ActionResult Pwcom_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Pwcom model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pwcom");

// USE /[MANUAL GQT BEFORE_CANCEL PWCOM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PWCOM]/

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

				Navigation.SetValue("ForcePrimaryRead_pwcom", "true", true);
			}

			Navigation.ClearValue("pwcom");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pwcom_PswValNomeModel : RequestLookupModel
		{
			public Pwcom_ViewModel Model { get; set; }
		}

		//
		// GET: /Pwcom/Pwcom_PswValNome
		// POST: /Pwcom/Pwcom_PswValNome
		[ActionName("Pwcom_PswValNome")]
		public ActionResult Pwcom_PswValNome([FromBody] Pwcom_PswValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_psw");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Pwcom parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pwcom_PswValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Pwcom_Pess1ValNameModel : RequestLookupModel
		{
			public Pwcom_ViewModel Model { get; set; }
		}

		//
		// GET: /Pwcom/Pwcom_Pess1ValName
		// POST: /Pwcom/Pwcom_Pess1ValName
		[ActionName("Pwcom_Pess1ValName")]
		public ActionResult Pwcom_Pess1ValName([FromBody] Pwcom_Pess1ValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess1");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Pwcom parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pwcom_Pess1ValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Pwcom/Pwcom_SaveEdit
		[HttpPost]
		public ActionResult Pwcom_SaveEdit([FromBody] Pwcom_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pwcom_SaveEdit",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PWCOM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PwcomDocumValidateTickets : RequestDocumValidateTickets
		{
			public Pwcom_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPwcom([FromBody] PwcomDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
