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

		private static readonly NavigationLocation ACTION_ARMAZ03_CANCEL = new("WAREHOUSE51864", "Armaz03_Cancel", "Wareh") { vueRouteName = "form-ARMAZ03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARMAZ03_SHOW = new("WAREHOUSE51864", "Armaz03_Show", "Wareh") { vueRouteName = "form-ARMAZ03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARMAZ03_NEW = new("WAREHOUSE51864", "Armaz03_New", "Wareh") { vueRouteName = "form-ARMAZ03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARMAZ03_EDIT = new("WAREHOUSE51864", "Armaz03_Edit", "Wareh") { vueRouteName = "form-ARMAZ03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARMAZ03_DUPLICATE = new("WAREHOUSE51864", "Armaz03_Duplicate", "Wareh") { vueRouteName = "form-ARMAZ03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARMAZ03_DELETE = new("WAREHOUSE51864", "Armaz03_Delete", "Wareh") { vueRouteName = "form-ARMAZ03", mode = "DELETE" };

		#endregion

		#region Armaz03 private

		private void FormHistoryLimits_Armaz03()
		{

		}

		#endregion

		#region Armaz03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARMAZ03]/

		[HttpPost]
		public ActionResult Armaz03_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz03_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Show_GET",
				AreaName = "wareh",
				Location = ACTION_ARMAZ03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armaz03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARMAZ03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Armaz03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Armaz03_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_New_GET",
				AreaName = "wareh",
				FormName = "ARMAZ03",
				Location = ACTION_ARMAZ03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Armaz03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARMAZ03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Armaz03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_New([FromBody]Armaz03_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_New",
				ViewName = "Armaz03",
				AreaName = "wareh",
				Location = ACTION_ARMAZ03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARMAZ03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARMAZ03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARMAZ03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Armaz03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz03_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Edit_GET",
				AreaName = "wareh",
				FormName = "ARMAZ03",
				Location = ACTION_ARMAZ03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armaz03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARMAZ03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Armaz03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_Edit([FromBody]Armaz03_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Edit",
				ViewName = "Armaz03",
				AreaName = "wareh",
				Location = ACTION_ARMAZ03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARMAZ03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARMAZ03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARMAZ03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Armaz03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz03_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Delete_GET",
				AreaName = "wareh",
				FormName = "ARMAZ03",
				Location = ACTION_ARMAZ03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armaz03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARMAZ03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Armaz03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz03_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Delete",
				ViewName = "Armaz03",
				AreaName = "wareh",
				Location = ACTION_ARMAZ03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARMAZ03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Armaz03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARMAZ03");
		}

		#endregion

		#region Armaz03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARMAZ03]/

		[HttpPost]
		public ActionResult Armaz03_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Armaz03_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Duplicate_GET",
				AreaName = "wareh",
				FormName = "ARMAZ03",
				Location = ACTION_ARMAZ03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARMAZ03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Armaz03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARMAZ03]/
		[HttpPost]
		public ActionResult Armaz03_Duplicate([FromBody]Armaz03_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_Duplicate",
				ViewName = "Armaz03",
				AreaName = "wareh",
				Location = ACTION_ARMAZ03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARMAZ03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARMAZ03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARMAZ03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Armaz03_Cancel

		//
		// GET: /Wareh/Armaz03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARMAZ03]/
		public ActionResult Armaz03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("wareh");
					var model = GenioMVC.Models.Wareh.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("wareh");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL ARMAZ03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARMAZ03]/

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


		public class Armaz03_ValArtigosModel : RequestLookupModel
		{
			public Armaz03_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Armaz03_ValArtigos
		// POST: /Wareh/Armaz03_ValArtigos
		[ActionName("Armaz03_ValArtigos")]
		public ActionResult Armaz03_ValArtigos([FromBody] Armaz03_ValArtigosModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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
			Armaz03_ValArtigos_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Wareh/Armaz03_SaveEdit
		[HttpPost]
		public ActionResult Armaz03_SaveEdit([FromBody] Armaz03_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz03_SaveEdit",
				ViewName = "Armaz03",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARMAZ03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARMAZ03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Armaz03DocumValidateTickets : RequestDocumValidateTickets
		{
			public Armaz03_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArmaz03([FromBody] Armaz03DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
