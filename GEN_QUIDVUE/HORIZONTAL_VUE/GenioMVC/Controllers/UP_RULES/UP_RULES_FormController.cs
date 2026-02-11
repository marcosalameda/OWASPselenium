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
using GenioMVC.ViewModels.Up_rules;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER UP_RULES]/

namespace GenioMVC.Controllers
{
	public partial class Up_rulesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_UP_RULES_CANCEL = new("RULE61609", "Up_rules_Cancel", "Up_rules") { vueRouteName = "form-UP_RULES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_UP_RULES_SHOW = new("RULE61609", "Up_rules_Show", "Up_rules") { vueRouteName = "form-UP_RULES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_UP_RULES_NEW = new("RULE61609", "Up_rules_New", "Up_rules") { vueRouteName = "form-UP_RULES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_UP_RULES_EDIT = new("RULE61609", "Up_rules_Edit", "Up_rules") { vueRouteName = "form-UP_RULES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_UP_RULES_DUPLICATE = new("RULE61609", "Up_rules_Duplicate", "Up_rules") { vueRouteName = "form-UP_RULES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_UP_RULES_DELETE = new("RULE61609", "Up_rules_Delete", "Up_rules") { vueRouteName = "form-UP_RULES", mode = "DELETE" };

		#endregion

		#region Up_rules private

		private void FormHistoryLimits_Up_rules()
		{

		}

		#endregion

		#region Up_rules_Show

// USE /[MANUAL GQT CONTROLLER_SHOW UP_RULES]/

		[HttpPost]
		public ActionResult Up_rules_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Up_rules_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Show_GET",
				AreaName = "up_rules",
				Location = ACTION_UP_RULES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Up_rules();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW UP_RULES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Up_rules_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Up_rules_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_New_GET",
				AreaName = "up_rules",
				FormName = "UP_RULES",
				Location = ACTION_UP_RULES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Up_rules();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW UP_RULES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Up_rules/Up_rules_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_New([FromBody]Up_rules_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_New",
				ViewName = "Up_rules",
				AreaName = "up_rules",
				Location = ACTION_UP_RULES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW UP_RULES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX UP_RULES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX UP_RULES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Up_rules_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Up_rules_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Edit_GET",
				AreaName = "up_rules",
				FormName = "UP_RULES",
				Location = ACTION_UP_RULES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Up_rules();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT UP_RULES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Up_rules/Up_rules_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_Edit([FromBody]Up_rules_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Edit",
				ViewName = "Up_rules",
				AreaName = "up_rules",
				Location = ACTION_UP_RULES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT UP_RULES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX UP_RULES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX UP_RULES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Up_rules_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Up_rules_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Delete_GET",
				AreaName = "up_rules",
				FormName = "UP_RULES",
				Location = ACTION_UP_RULES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Up_rules();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE UP_RULES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Up_rules/Up_rules_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Up_rules_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Delete",
				ViewName = "Up_rules",
				AreaName = "up_rules",
				Location = ACTION_UP_RULES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE UP_RULES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Up_rules_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("UP_RULES");
		}

		#endregion

		#region Up_rules_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET UP_RULES]/

		[HttpPost]
		public ActionResult Up_rules_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Up_rules_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Duplicate_GET",
				AreaName = "up_rules",
				FormName = "UP_RULES",
				Location = ACTION_UP_RULES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE UP_RULES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Up_rules/Up_rules_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST UP_RULES]/
		[HttpPost]
		public ActionResult Up_rules_Duplicate([FromBody]Up_rules_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_Duplicate",
				ViewName = "Up_rules",
				AreaName = "up_rules",
				Location = ACTION_UP_RULES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE UP_RULES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX UP_RULES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX UP_RULES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Up_rules_Cancel

		//
		// GET: /Up_rules/Up_rules_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET UP_RULES]/
		public ActionResult Up_rules_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Up_rules model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("up_rules");

// USE /[MANUAL GQT BEFORE_CANCEL UP_RULES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL UP_RULES]/

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

				Navigation.SetValue("ForcePrimaryRead_up_rules", "true", true);
			}

			Navigation.ClearValue("up_rules");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Up_rules_ValRegrasModel : RequestLookupModel
		{
			public Up_rules_ViewModel Model { get; set; }
		}

		//
		// GET: /Up_rules/Up_rules_ValRegras
		// POST: /Up_rules/Up_rules_ValRegras
		[ActionName("Up_rules_ValRegras")]
		public ActionResult Up_rules_ValRegras([FromBody] Up_rules_ValRegrasModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rules")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rules");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Up_rules parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Up_rules_ValRegras_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Up_rules/Up_rules_SaveEdit
		[HttpPost]
		public ActionResult Up_rules_SaveEdit([FromBody] Up_rules_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Up_rules_SaveEdit",
				ViewName = "Up_rules",
				AreaName = "up_rules",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT UP_RULES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT UP_RULES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Up_rulesDocumValidateTickets : RequestDocumValidateTickets
		{
			public Up_rules_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsUp_rules([FromBody] Up_rulesDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
