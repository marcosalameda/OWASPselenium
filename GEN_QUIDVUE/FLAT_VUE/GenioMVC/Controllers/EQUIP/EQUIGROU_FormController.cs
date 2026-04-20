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
using GenioMVC.ViewModels.Equip;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EQUIGROU_CANCEL = new("EQUIPMENT03632", "Equigrou_Cancel", "Equip") { vueRouteName = "form-EQUIGROU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EQUIGROU_SHOW = new("EQUIPMENT03632", "Equigrou_Show", "Equip") { vueRouteName = "form-EQUIGROU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EQUIGROU_NEW = new("EQUIPMENT03632", "Equigrou_New", "Equip") { vueRouteName = "form-EQUIGROU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EQUIGROU_EDIT = new("EQUIPMENT03632", "Equigrou_Edit", "Equip") { vueRouteName = "form-EQUIGROU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EQUIGROU_DUPLICATE = new("EQUIPMENT03632", "Equigrou_Duplicate", "Equip") { vueRouteName = "form-EQUIGROU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EQUIGROU_DELETE = new("EQUIPMENT03632", "Equigrou_Delete", "Equip") { vueRouteName = "form-EQUIGROU", mode = "DELETE" };

		#endregion

		#region Equigrou private

		private void FormHistoryLimits_Equigrou()
		{

		}

		#endregion

		#region Equigrou_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EQUIGROU]/

		[HttpPost]
		public ActionResult Equigrou_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equigrou_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Show_GET",
				AreaName = "equip",
				Location = ACTION_EQUIGROU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equigrou();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EQUIGROU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Equigrou_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Equigrou_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_New_GET",
				AreaName = "equip",
				FormName = "EQUIGROU",
				Location = ACTION_EQUIGROU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Equigrou();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EQUIGROU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Equigrou_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_New([FromBody]Equigrou_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_New",
				ViewName = "Equigrou",
				AreaName = "equip",
				Location = ACTION_EQUIGROU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EQUIGROU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EQUIGROU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EQUIGROU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Equigrou_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equigrou_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Edit_GET",
				AreaName = "equip",
				FormName = "EQUIGROU",
				Location = ACTION_EQUIGROU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equigrou();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EQUIGROU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Equigrou_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_Edit([FromBody]Equigrou_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Edit",
				ViewName = "Equigrou",
				AreaName = "equip",
				Location = ACTION_EQUIGROU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EQUIGROU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EQUIGROU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EQUIGROU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Equigrou_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equigrou_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Delete_GET",
				AreaName = "equip",
				FormName = "EQUIGROU",
				Location = ACTION_EQUIGROU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equigrou();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EQUIGROU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Equigrou_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equigrou_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Delete",
				ViewName = "Equigrou",
				AreaName = "equip",
				Location = ACTION_EQUIGROU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EQUIGROU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Equigrou_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EQUIGROU");
		}

		#endregion

		#region Equigrou_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EQUIGROU]/

		[HttpPost]
		public ActionResult Equigrou_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Equigrou_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Duplicate_GET",
				AreaName = "equip",
				FormName = "EQUIGROU",
				Location = ACTION_EQUIGROU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EQUIGROU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Equigrou_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EQUIGROU]/
		[HttpPost]
		public ActionResult Equigrou_Duplicate([FromBody]Equigrou_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_Duplicate",
				ViewName = "Equigrou",
				AreaName = "equip",
				Location = ACTION_EQUIGROU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EQUIGROU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EQUIGROU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EQUIGROU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Equigrou_Cancel

		//
		// GET: /Equip/Equigrou_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EQUIGROU]/
		public ActionResult Equigrou_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("equip");
					var model = GenioMVC.Models.Equip.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("equip");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL EQUIGROU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EQUIGROU]/

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

				Navigation.SetValue("ForcePrimaryRead_equip", "true", true);
			}

			Navigation.ClearValue("equip");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Equigrou_Pess1ValNameModel : RequestLookupModel
		{
			public Equigrou_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Equigrou_Pess1ValName
		// POST: /Equip/Equigrou_Pess1ValName
		[ActionName("Equigrou_Pess1ValName")]
		public ActionResult Equigrou_Pess1ValName([FromBody] Equigrou_Pess1ValNameModel requestModel)
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equigrou_Pess1ValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Equigrou_TpequValTipoequiModel : RequestLookupModel
		{
			public Equigrou_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Equigrou_TpequValTipoequi
		// POST: /Equip/Equigrou_TpequValTipoequi
		[ActionName("Equigrou_TpequValTipoequi")]
		public ActionResult Equigrou_TpequValTipoequi([FromBody] Equigrou_TpequValTipoequiModel requestModel)
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equigrou_TpequValTipoequi_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Equip/Equigrou_SaveEdit
		[HttpPost]
		public ActionResult Equigrou_SaveEdit([FromBody] Equigrou_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equigrou_SaveEdit",
				ViewName = "Equigrou",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EQUIGROU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EQUIGROU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class EquigrouDocumValidateTickets : RequestDocumValidateTickets
		{
			public Equigrou_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsEquigrou([FromBody] EquigrouDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
