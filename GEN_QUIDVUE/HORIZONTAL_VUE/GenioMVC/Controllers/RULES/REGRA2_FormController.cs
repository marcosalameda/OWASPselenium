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
using GenioMVC.ViewModels.Rules;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RULES]/

namespace GenioMVC.Controllers
{
	public partial class RulesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REGRA2_CANCEL = new("REGRA09608", "Regra2_Cancel", "Rules") { vueRouteName = "form-REGRA2", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGRA2_SHOW = new("REGRA09608", "Regra2_Show", "Rules") { vueRouteName = "form-REGRA2", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGRA2_NEW = new("REGRA09608", "Regra2_New", "Rules") { vueRouteName = "form-REGRA2", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGRA2_EDIT = new("REGRA09608", "Regra2_Edit", "Rules") { vueRouteName = "form-REGRA2", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGRA2_DUPLICATE = new("REGRA09608", "Regra2_Duplicate", "Rules") { vueRouteName = "form-REGRA2", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGRA2_DELETE = new("REGRA09608", "Regra2_Delete", "Rules") { vueRouteName = "form-REGRA2", mode = "DELETE" };

		#endregion

		#region Regra2 private

		private void FormHistoryLimits_Regra2()
		{

		}

		#endregion

		#region Regra2_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGRA2]/

		[HttpPost]
		public ActionResult Regra2_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Regra2_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Regra2_Show_GET",
				AreaName = "rules",
				Location = ACTION_REGRA2_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regra2();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGRA2]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regra2_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGRA2]/
		[HttpPost]
		public ActionResult Regra2_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Regra2_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Regra2_New_GET",
				AreaName = "rules",
				FormName = "REGRA2",
				Location = ACTION_REGRA2_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regra2();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGRA2]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Rules/Regra2_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGRA2]/
		[HttpPost]
		public ActionResult Regra2_New([FromBody]Regra2_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Regra2_New",
				ViewName = "Regra2",
				AreaName = "rules",
				Location = ACTION_REGRA2_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGRA2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGRA2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGRA2]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regra2_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGRA2]/
		[HttpPost]
		public ActionResult Regra2_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Regra2_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Regra2_Edit_GET",
				AreaName = "rules",
				FormName = "REGRA2",
				Location = ACTION_REGRA2_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regra2();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGRA2]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Rules/Regra2_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGRA2]/
		[HttpPost]
		public ActionResult Regra2_Edit([FromBody]Regra2_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Regra2_Edit",
				ViewName = "Regra2",
				AreaName = "rules",
				Location = ACTION_REGRA2_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGRA2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGRA2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGRA2]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regra2_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGRA2]/
		[HttpPost]
		public ActionResult Regra2_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Regra2_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Regra2_Delete_GET",
				AreaName = "rules",
				FormName = "REGRA2",
				Location = ACTION_REGRA2_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regra2();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGRA2]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Rules/Regra2_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGRA2]/
		[HttpPost]
		public ActionResult Regra2_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Regra2_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Regra2_Delete",
				ViewName = "Regra2",
				AreaName = "rules",
				Location = ACTION_REGRA2_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGRA2]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regra2_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGRA2");
		}

		#endregion

		#region Regra2_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGRA2]/

		[HttpPost]
		public ActionResult Regra2_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Regra2_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Regra2_Duplicate_GET",
				AreaName = "rules",
				FormName = "REGRA2",
				Location = ACTION_REGRA2_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGRA2]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Rules/Regra2_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGRA2]/
		[HttpPost]
		public ActionResult Regra2_Duplicate([FromBody]Regra2_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Regra2_Duplicate",
				ViewName = "Regra2",
				AreaName = "rules",
				Location = ACTION_REGRA2_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGRA2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGRA2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGRA2]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regra2_Cancel

		//
		// GET: /Rules/Regra2_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGRA2]/
		public ActionResult Regra2_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Rules model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("rules");

// USE /[MANUAL GQT BEFORE_CANCEL REGRA2]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGRA2]/

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


		public class Regra2_Up_rulesValDescriptModel : RequestLookupModel
		{
			public Regra2_ViewModel Model { get; set; }
		}

		//
		// GET: /Rules/Regra2_Up_rulesValDescript
		// POST: /Rules/Regra2_Up_rulesValDescript
		[ActionName("Regra2_Up_rulesValDescript")]
		public ActionResult Regra2_Up_rulesValDescript([FromBody] Regra2_Up_rulesValDescriptModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_up_rules")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_up_rules");
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

			Models.Rules parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Regra2_Up_rulesValDescript_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Rules/Regra2_SaveEdit
		[HttpPost]
		public ActionResult Regra2_SaveEdit([FromBody] Regra2_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Regra2_SaveEdit",
				ViewName = "Regra2",
				AreaName = "rules",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGRA2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGRA2]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Regra2DocumValidateTickets : RequestDocumValidateTickets
		{
			public Regra2_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRegra2([FromBody] Regra2DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
