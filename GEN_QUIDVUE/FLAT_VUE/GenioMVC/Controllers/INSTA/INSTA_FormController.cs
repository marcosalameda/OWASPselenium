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
using GenioMVC.ViewModels.Insta;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER INSTA]/

namespace GenioMVC.Controllers
{
	public partial class InstaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_INSTA_CANCEL = new("INSTALLATION12952", "Insta_Cancel", "Insta") { vueRouteName = "form-INSTA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_INSTA_SHOW = new("INSTALLATION12952", "Insta_Show", "Insta") { vueRouteName = "form-INSTA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_INSTA_NEW = new("INSTALLATION12952", "Insta_New", "Insta") { vueRouteName = "form-INSTA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_INSTA_EDIT = new("INSTALLATION12952", "Insta_Edit", "Insta") { vueRouteName = "form-INSTA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_INSTA_DUPLICATE = new("INSTALLATION12952", "Insta_Duplicate", "Insta") { vueRouteName = "form-INSTA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_INSTA_DELETE = new("INSTALLATION12952", "Insta_Delete", "Insta") { vueRouteName = "form-INSTA", mode = "DELETE" };

		#endregion

		#region Insta private

		private void FormHistoryLimits_Insta()
		{

		}

		#endregion

		#region Insta_Show

// USE /[MANUAL GQT CONTROLLER_SHOW INSTA]/

		[HttpPost]
		public ActionResult Insta_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Insta_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Insta_Show_GET",
				AreaName = "insta",
				Location = ACTION_INSTA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Insta();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW INSTA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Insta_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET INSTA]/
		[HttpPost]
		public ActionResult Insta_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Insta_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Insta_New_GET",
				AreaName = "insta",
				FormName = "INSTA",
				Location = ACTION_INSTA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Insta();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW INSTA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Insta/Insta_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST INSTA]/
		[HttpPost]
		public ActionResult Insta_New([FromBody]Insta_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Insta_New",
				ViewName = "Insta",
				AreaName = "insta",
				Location = ACTION_INSTA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW INSTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX INSTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX INSTA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Insta_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET INSTA]/
		[HttpPost]
		public ActionResult Insta_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Insta_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Insta_Edit_GET",
				AreaName = "insta",
				FormName = "INSTA",
				Location = ACTION_INSTA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Insta();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT INSTA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Insta/Insta_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST INSTA]/
		[HttpPost]
		public ActionResult Insta_Edit([FromBody]Insta_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Insta_Edit",
				ViewName = "Insta",
				AreaName = "insta",
				Location = ACTION_INSTA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT INSTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX INSTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX INSTA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Insta_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET INSTA]/
		[HttpPost]
		public ActionResult Insta_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Insta_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Insta_Delete_GET",
				AreaName = "insta",
				FormName = "INSTA",
				Location = ACTION_INSTA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Insta();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE INSTA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Insta/Insta_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST INSTA]/
		[HttpPost]
		public ActionResult Insta_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Insta_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Insta_Delete",
				ViewName = "Insta",
				AreaName = "insta",
				Location = ACTION_INSTA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE INSTA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Insta_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("INSTA");
		}

		#endregion

		#region Insta_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET INSTA]/

		[HttpPost]
		public ActionResult Insta_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Insta_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Insta_Duplicate_GET",
				AreaName = "insta",
				FormName = "INSTA",
				Location = ACTION_INSTA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE INSTA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Insta/Insta_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST INSTA]/
		[HttpPost]
		public ActionResult Insta_Duplicate([FromBody]Insta_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Insta_Duplicate",
				ViewName = "Insta",
				AreaName = "insta",
				Location = ACTION_INSTA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE INSTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX INSTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX INSTA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Insta_Cancel

		//
		// GET: /Insta/Insta_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET INSTA]/
		public ActionResult Insta_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("insta");
					var model = GenioMVC.Models.Insta.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("insta");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL INSTA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL INSTA]/

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

				Navigation.SetValue("ForcePrimaryRead_insta", "true", true);
			}

			Navigation.ClearValue("insta");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Insta_TpequValTipoequiModel : RequestLookupModel
		{
			public Insta_ViewModel Model { get; set; }
		}

		//
		// GET: /Insta/Insta_TpequValTipoequi
		// POST: /Insta/Insta_TpequValTipoequi
		[ActionName("Insta_TpequValTipoequi")]
		public ActionResult Insta_TpequValTipoequi([FromBody] Insta_TpequValTipoequiModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
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

			Models.Insta parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Insta_TpequValTipoequi_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Insta_EquipValRegistnrModel : RequestLookupModel
		{
			public Insta_ViewModel Model { get; set; }
		}

		//
		// GET: /Insta/Insta_EquipValRegistnr
		// POST: /Insta/Insta_EquipValRegistnr
		[ActionName("Insta_EquipValRegistnr")]
		public ActionResult Insta_EquipValRegistnr([FromBody] Insta_EquipValRegistnrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
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

			Models.Insta parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Insta_EquipValRegistnr_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Insta/Insta_SaveEdit
		[HttpPost]
		public ActionResult Insta_SaveEdit([FromBody] Insta_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Insta_SaveEdit",
				ViewName = "Insta",
				AreaName = "insta",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT INSTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT INSTA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class InstaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Insta_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsInsta([FromBody] InstaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
