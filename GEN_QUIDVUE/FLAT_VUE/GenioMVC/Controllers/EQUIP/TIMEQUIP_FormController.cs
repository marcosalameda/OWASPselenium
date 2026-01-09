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

		private static readonly NavigationLocation ACTION_TIMEQUIP_CANCEL = new("TIMELINE45857", "Timequip_Cancel", "Equip") { vueRouteName = "form-TIMEQUIP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TIMEQUIP_SHOW = new("TIMELINE45857", "Timequip_Show", "Equip") { vueRouteName = "form-TIMEQUIP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TIMEQUIP_NEW = new("TIMELINE45857", "Timequip_New", "Equip") { vueRouteName = "form-TIMEQUIP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TIMEQUIP_EDIT = new("TIMELINE45857", "Timequip_Edit", "Equip") { vueRouteName = "form-TIMEQUIP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TIMEQUIP_DUPLICATE = new("TIMELINE45857", "Timequip_Duplicate", "Equip") { vueRouteName = "form-TIMEQUIP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TIMEQUIP_DELETE = new("TIMELINE45857", "Timequip_Delete", "Equip") { vueRouteName = "form-TIMEQUIP", mode = "DELETE" };

		#endregion

		#region Timequip private

		private void FormHistoryLimits_Timequip()
		{

		}

		#endregion

		#region Timequip_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TIMEQUIP]/

		[HttpPost]
		public ActionResult Timequip_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Timequip_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Timequip_Show_GET",
				AreaName = "equip",
				Location = ACTION_TIMEQUIP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Timequip();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TIMEQUIP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Timequip_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Timequip_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Timequip_New_GET",
				AreaName = "equip",
				FormName = "TIMEQUIP",
				Location = ACTION_TIMEQUIP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Timequip();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TIMEQUIP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Timequip_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_New([FromBody]Timequip_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Timequip_New",
				ViewName = "Timequip",
				AreaName = "equip",
				Location = ACTION_TIMEQUIP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TIMEQUIP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TIMEQUIP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TIMEQUIP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Timequip_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Timequip_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Timequip_Edit_GET",
				AreaName = "equip",
				FormName = "TIMEQUIP",
				Location = ACTION_TIMEQUIP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Timequip();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TIMEQUIP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Timequip_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_Edit([FromBody]Timequip_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Timequip_Edit",
				ViewName = "Timequip",
				AreaName = "equip",
				Location = ACTION_TIMEQUIP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TIMEQUIP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TIMEQUIP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TIMEQUIP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Timequip_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Timequip_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Timequip_Delete_GET",
				AreaName = "equip",
				FormName = "TIMEQUIP",
				Location = ACTION_TIMEQUIP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Timequip();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TIMEQUIP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Timequip_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Timequip_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Timequip_Delete",
				ViewName = "Timequip",
				AreaName = "equip",
				Location = ACTION_TIMEQUIP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TIMEQUIP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Timequip_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TIMEQUIP");
		}

		#endregion

		#region Timequip_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TIMEQUIP]/

		[HttpPost]
		public ActionResult Timequip_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Timequip_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Timequip_Duplicate_GET",
				AreaName = "equip",
				FormName = "TIMEQUIP",
				Location = ACTION_TIMEQUIP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TIMEQUIP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Timequip_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TIMEQUIP]/
		[HttpPost]
		public ActionResult Timequip_Duplicate([FromBody]Timequip_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Timequip_Duplicate",
				ViewName = "Timequip",
				AreaName = "equip",
				Location = ACTION_TIMEQUIP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TIMEQUIP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TIMEQUIP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TIMEQUIP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Timequip_Cancel

		//
		// GET: /Equip/Timequip_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TIMEQUIP]/
		public ActionResult Timequip_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Equip model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL TIMEQUIP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TIMEQUIP]/

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


		public class Timequip_ValReparacoModel : RequestLookupModel
		{
			public Timequip_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Timequip_ValReparaco
		// POST: /Equip/Timequip_ValReparaco
		[ActionName("Timequip_ValReparaco")]
		public ActionResult Timequip_ValReparaco([FromBody] Timequip_ValReparacoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_repar")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_repar");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Equip parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Timequip_ValReparaco_ViewModel model = new(m_userContext, parentCtx);

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

		public class Timequip_ValPrimaryModel : RequestLookupModel
		{
			public Timequip_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Timequip_ValPrimary
		// POST: /Equip/Timequip_ValPrimary
		[ActionName("Timequip_ValPrimary")]
		public ActionResult Timequip_ValPrimary([FromBody] Timequip_ValPrimaryModel requestModel)
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Timequip_ValPrimary_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel.TableConfiguration ?? new();

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Timequip_ValSecundarModel : RequestLookupModel
		{
			public Timequip_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Timequip_ValSecundar
		// POST: /Equip/Timequip_ValSecundar
		[ActionName("Timequip_ValSecundar")]
		public ActionResult Timequip_ValSecundar([FromBody] Timequip_ValSecundarModel requestModel)
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Timequip_ValSecundar_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel.TableConfiguration ?? new();

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Equip/Timequip_SaveEdit
		[HttpPost]
		public ActionResult Timequip_SaveEdit([FromBody] Timequip_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Timequip_SaveEdit",
				ViewName = "Timequip",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TIMEQUIP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TIMEQUIP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TimequipDocumValidateTickets : RequestDocumValidateTickets
		{
			public Timequip_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTimequip([FromBody] TimequipDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
