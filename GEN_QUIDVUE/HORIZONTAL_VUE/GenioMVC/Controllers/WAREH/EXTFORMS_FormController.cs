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

		private static readonly NavigationLocation ACTION_EXTFORMS_CANCEL = new("EXTENDED_FORM_SUPPOR30674", "Extforms_Cancel", "Wareh") { vueRouteName = "form-EXTFORMS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EXTFORMS_SHOW = new("EXTENDED_FORM_SUPPOR30674", "Extforms_Show", "Wareh") { vueRouteName = "form-EXTFORMS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EXTFORMS_NEW = new("EXTENDED_FORM_SUPPOR30674", "Extforms_New", "Wareh") { vueRouteName = "form-EXTFORMS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EXTFORMS_EDIT = new("EXTENDED_FORM_SUPPOR30674", "Extforms_Edit", "Wareh") { vueRouteName = "form-EXTFORMS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EXTFORMS_DUPLICATE = new("EXTENDED_FORM_SUPPOR30674", "Extforms_Duplicate", "Wareh") { vueRouteName = "form-EXTFORMS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EXTFORMS_DELETE = new("EXTENDED_FORM_SUPPOR30674", "Extforms_Delete", "Wareh") { vueRouteName = "form-EXTFORMS", mode = "DELETE" };

		#endregion

		#region Extforms private

		private void FormHistoryLimits_Extforms()
		{

		}

		#endregion

		#region Extforms_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EXTFORMS]/

		[HttpPost]
		public ActionResult Extforms_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Extforms_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Extforms_Show_GET",
				AreaName = "wareh",
				Location = ACTION_EXTFORMS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Extforms();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EXTFORMS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Extforms_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Extforms_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Extforms_New_GET",
				AreaName = "wareh",
				FormName = "EXTFORMS",
				Location = ACTION_EXTFORMS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Extforms();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EXTFORMS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Extforms_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_New([FromBody]Extforms_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Extforms_New",
				ViewName = "Extforms",
				AreaName = "wareh",
				Location = ACTION_EXTFORMS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EXTFORMS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EXTFORMS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EXTFORMS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Extforms_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Extforms_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Extforms_Edit_GET",
				AreaName = "wareh",
				FormName = "EXTFORMS",
				Location = ACTION_EXTFORMS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Extforms();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EXTFORMS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Extforms_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_Edit([FromBody]Extforms_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Extforms_Edit",
				ViewName = "Extforms",
				AreaName = "wareh",
				Location = ACTION_EXTFORMS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EXTFORMS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EXTFORMS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EXTFORMS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Extforms_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Extforms_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Extforms_Delete_GET",
				AreaName = "wareh",
				FormName = "EXTFORMS",
				Location = ACTION_EXTFORMS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Extforms();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EXTFORMS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Extforms_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Extforms_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Extforms_Delete",
				ViewName = "Extforms",
				AreaName = "wareh",
				Location = ACTION_EXTFORMS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EXTFORMS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Extforms_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EXTFORMS");
		}

		#endregion

		#region Extforms_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EXTFORMS]/

		[HttpPost]
		public ActionResult Extforms_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Extforms_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Extforms_Duplicate_GET",
				AreaName = "wareh",
				FormName = "EXTFORMS",
				Location = ACTION_EXTFORMS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EXTFORMS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Extforms_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EXTFORMS]/
		[HttpPost]
		public ActionResult Extforms_Duplicate([FromBody]Extforms_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Extforms_Duplicate",
				ViewName = "Extforms",
				AreaName = "wareh",
				Location = ACTION_EXTFORMS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EXTFORMS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EXTFORMS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EXTFORMS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Extforms_Cancel

		//
		// GET: /Wareh/Extforms_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EXTFORMS]/
		public ActionResult Extforms_Cancel()
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

// USE /[MANUAL GQT BEFORE_CANCEL EXTFORMS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EXTFORMS]/

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


		public class Extforms_ValArtigosModel : RequestLookupModel
		{
			public Extforms_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Extforms_ValArtigos
		// POST: /Wareh/Extforms_ValArtigos
		[ActionName("Extforms_ValArtigos")]
		public ActionResult Extforms_ValArtigos([FromBody] Extforms_ValArtigosModel requestModel)
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
			Extforms_ValArtigos_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Wareh/Extforms_SaveEdit
		[HttpPost]
		public ActionResult Extforms_SaveEdit([FromBody] Extforms_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Extforms_SaveEdit",
				ViewName = "Extforms",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EXTFORMS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EXTFORMS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ExtformsDocumValidateTickets : RequestDocumValidateTickets
		{
			public Extforms_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsExtforms([FromBody] ExtformsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
