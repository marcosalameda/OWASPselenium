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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FIELDHLP_CANCEL = new("FIELD_TYPE57098", "Fieldhlp_Cancel", "Flds") { vueRouteName = "form-FIELDHLP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FIELDHLP_SHOW = new("FIELD_TYPE57098", "Fieldhlp_Show", "Flds") { vueRouteName = "form-FIELDHLP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FIELDHLP_NEW = new("FIELD_TYPE57098", "Fieldhlp_New", "Flds") { vueRouteName = "form-FIELDHLP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FIELDHLP_EDIT = new("FIELD_TYPE57098", "Fieldhlp_Edit", "Flds") { vueRouteName = "form-FIELDHLP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FIELDHLP_DUPLICATE = new("FIELD_TYPE57098", "Fieldhlp_Duplicate", "Flds") { vueRouteName = "form-FIELDHLP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FIELDHLP_DELETE = new("FIELD_TYPE57098", "Fieldhlp_Delete", "Flds") { vueRouteName = "form-FIELDHLP", mode = "DELETE" };

		#endregion

		#region Fieldhlp private

		private void FormHistoryLimits_Fieldhlp()
		{

		}

		#endregion

		#region Fieldhlp_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FIELDHLP]/

		[HttpPost]
		public ActionResult Fieldhlp_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fieldhlp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Show_GET",
				AreaName = "flds",
				Location = ACTION_FIELDHLP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fieldhlp();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FIELDHLP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Fieldhlp_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Fieldhlp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_New_GET",
				AreaName = "flds",
				FormName = "FIELDHLP",
				Location = ACTION_FIELDHLP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Fieldhlp();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FIELDHLP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Flds/Fieldhlp_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_New([FromBody]Fieldhlp_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_New",
				ViewName = "Fieldhlp",
				AreaName = "flds",
				Location = ACTION_FIELDHLP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FIELDHLP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FIELDHLP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FIELDHLP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Fieldhlp_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fieldhlp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Edit_GET",
				AreaName = "flds",
				FormName = "FIELDHLP",
				Location = ACTION_FIELDHLP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fieldhlp();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FIELDHLP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Flds/Fieldhlp_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_Edit([FromBody]Fieldhlp_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Edit",
				ViewName = "Fieldhlp",
				AreaName = "flds",
				Location = ACTION_FIELDHLP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FIELDHLP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FIELDHLP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FIELDHLP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Fieldhlp_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fieldhlp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Delete_GET",
				AreaName = "flds",
				FormName = "FIELDHLP",
				Location = ACTION_FIELDHLP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fieldhlp();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FIELDHLP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Flds/Fieldhlp_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fieldhlp_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Delete",
				ViewName = "Fieldhlp",
				AreaName = "flds",
				Location = ACTION_FIELDHLP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FIELDHLP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Fieldhlp_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FIELDHLP");
		}

		#endregion

		#region Fieldhlp_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FIELDHLP]/

		[HttpPost]
		public ActionResult Fieldhlp_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Fieldhlp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Duplicate_GET",
				AreaName = "flds",
				FormName = "FIELDHLP",
				Location = ACTION_FIELDHLP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FIELDHLP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Flds/Fieldhlp_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FIELDHLP]/
		[HttpPost]
		public ActionResult Fieldhlp_Duplicate([FromBody]Fieldhlp_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_Duplicate",
				ViewName = "Fieldhlp",
				AreaName = "flds",
				Location = ACTION_FIELDHLP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FIELDHLP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FIELDHLP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FIELDHLP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Fieldhlp_Cancel

		//
		// GET: /Flds/Fieldhlp_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FIELDHLP]/
		public ActionResult Fieldhlp_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("flds");
					var model = GenioMVC.Models.Flds.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("flds");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL FIELDHLP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FIELDHLP]/

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

				Navigation.SetValue("ForcePrimaryRead_flds", "true", true);
			}

			Navigation.ClearValue("flds");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Fieldhlp_AeroValNameModel : RequestLookupModel
		{
			public Fieldhlp_ViewModel Model { get; set; }
		}

		//
		// GET: /Flds/Fieldhlp_AeroValName
		// POST: /Flds/Fieldhlp_AeroValName
		[ActionName("Fieldhlp_AeroValName")]
		public ActionResult Fieldhlp_AeroValName([FromBody] Fieldhlp_AeroValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_aero")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_aero");
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

			Models.Flds parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Fieldhlp_AeroValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Flds/Fieldhlp_SaveEdit
		[HttpPost]
		public ActionResult Fieldhlp_SaveEdit([FromBody] Fieldhlp_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fieldhlp_SaveEdit",
				ViewName = "Fieldhlp",
				AreaName = "flds",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FIELDHLP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FIELDHLP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class FieldhlpDocumValidateTickets : RequestDocumValidateTickets
		{
			public Fieldhlp_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsFieldhlp([FromBody] FieldhlpDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}

		/// <summary>
		/// Stores a new document, in the Docums table, associated to field ATTACH
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFileFieldhlpAttach([FromForm] RequestDocumsCreateModel requestModel)
		{
			List<string> extensions = [];
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version, extensions);
		}
	}
}
