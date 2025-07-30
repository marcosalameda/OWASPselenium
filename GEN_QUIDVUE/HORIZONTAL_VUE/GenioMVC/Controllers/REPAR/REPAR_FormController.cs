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
using GenioMVC.ViewModels.Repar;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REPAR]/

namespace GenioMVC.Controllers
{
	public partial class ReparController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REPAR_CANCEL = new("REPAIR34508", "Repar_Cancel", "Repar") { vueRouteName = "form-REPAR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REPAR_SHOW = new("REPAIR34508", "Repar_Show", "Repar") { vueRouteName = "form-REPAR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REPAR_NEW = new("REPAIR34508", "Repar_New", "Repar") { vueRouteName = "form-REPAR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REPAR_EDIT = new("REPAIR34508", "Repar_Edit", "Repar") { vueRouteName = "form-REPAR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REPAR_DUPLICATE = new("REPAIR34508", "Repar_Duplicate", "Repar") { vueRouteName = "form-REPAR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REPAR_DELETE = new("REPAIR34508", "Repar_Delete", "Repar") { vueRouteName = "form-REPAR", mode = "DELETE" };

		#endregion

		#region Repar private

		private void FormHistoryLimits_Repar()
		{

		}

		#endregion

		#region Repar_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REPAR]/

		[HttpPost]
		public ActionResult Repar_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Repar_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Show_GET",
				AreaName = "repar",
				Location = ACTION_REPAR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REPAR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Repar_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REPAR]/
		[HttpPost]
		public ActionResult Repar_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Repar_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Repar_New_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REPAR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Repar/Repar_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_New([FromBody]Repar_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Repar_New",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REPAR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Repar_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REPAR]/
		[HttpPost]
		public ActionResult Repar_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Repar_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Edit_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REPAR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Repar/Repar_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_Edit([FromBody]Repar_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Edit",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REPAR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Repar_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REPAR]/
		[HttpPost]
		public ActionResult Repar_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Repar_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Delete_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Repar();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REPAR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Repar/Repar_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Repar_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Repar_Delete",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REPAR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Repar_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REPAR");
		}

		#endregion

		#region Repar_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REPAR]/

		[HttpPost]
		public ActionResult Repar_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Repar_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Duplicate_GET",
				AreaName = "repar",
				FormName = "REPAR",
				Location = ACTION_REPAR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REPAR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Repar/Repar_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REPAR]/
		[HttpPost]
		public ActionResult Repar_Duplicate([FromBody]Repar_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Duplicate",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REPAR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Repar_Cancel

		//
		// GET: /Repar/Repar_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REPAR]/
		public ActionResult Repar_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Repar(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("repar");

// USE /[MANUAL GQT BEFORE_CANCEL REPAR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REPAR]/

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

				Navigation.SetValue("ForcePrimaryRead_repar", "true", true);
			}

			Navigation.ClearValue("repar");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Repar_EquipValRegistnrModel : RequestLookupModel
		{
			public Repar_ViewModel Model { get; set; }
		}

		//
		// GET: /Repar/Repar_EquipValRegistnr
		// POST: /Repar/Repar_EquipValRegistnr
		[ActionName("Repar_EquipValRegistnr")]
		public ActionResult Repar_EquipValRegistnr([FromBody] Repar_EquipValRegistnrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Repar parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Repar_EquipValRegistnr_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Repar_SpeciValEspecialModel : RequestLookupModel
		{
			public Repar_ViewModel Model { get; set; }
		}

		//
		// GET: /Repar/Repar_SpeciValEspecial
		// POST: /Repar/Repar_SpeciValEspecial
		[ActionName("Repar_SpeciValEspecial")]
		public ActionResult Repar_SpeciValEspecial([FromBody] Repar_SpeciValEspecialModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_speci")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_speci");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Repar parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Repar_SpeciValEspecial_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			// Map received value to field - The 'field' type limit
			model.ValTipoarea = Navigation.GetValue<string>("repar.tipoarea");
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Repar_PessoValNameModel : RequestLookupModel
		{
			public Repar_ViewModel Model { get; set; }
		}

		//
		// GET: /Repar/Repar_PessoValName
		// POST: /Repar/Repar_PessoValName
		[ActionName("Repar_PessoValName")]
		public ActionResult Repar_PessoValName([FromBody] Repar_PessoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Repar parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Repar_PessoValName_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		/// <summary>
		/// Server-side component of action #1 (AGENT) of trigger REPAIR_AGENT
		/// Button CATEG_AI
		/// </summary>
		/// <param name="data">The client-side context of the trigger.</param>
		/// <returns>
		/// Success message
		/// </returns>
		public ActionResult Repar_BT_CATEG_AI_REPAIR_AGENT_1([FromBody] Repar_ViewModel vm)
		{
			var key = vm.ValCodrepar;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = Models.Repar.Find(key, UserContext.Current, "FREPAR");
				vm.MapToModel(model);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model.klass,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger REPAIR_AGENT
				CSGenio.business.Triggers.ITrigger trigger_REPAIR_AGENT = new CSGenio.business.Triggers.TriggerRepairAgent(context);
				CSGenio.business.Triggers.IAction action = trigger_REPAIR_AGENT.GetAction(1);
				trigger_REPAIR_AGENT.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
			);
		}

		/// <summary>
		/// Gets the value in the database of the field repar.tipoarea.
		/// Invoked during the execution of action #2 (CREFRESH) of trigger REPAIR_AGENT.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[ActionName("Repar_ValTipoarea")]
		public ActionResult Repar_ValTipoarea([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Repar_ViewModel model = new(m_userContext, id, false, [CSGenioArepar.FldTipoarea.Field]);

			return JsonOK(new { model.ValTipoarea });
		}

		// POST: /Repar/Repar_SaveEdit
		[HttpPost]
		public ActionResult Repar_SaveEdit([FromBody] Repar_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Repar_SaveEdit",
				ViewName = "Repar",
				AreaName = "repar",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REPAR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ReparDocumValidateTickets : RequestDocumValidateTickets
		{
			public Repar_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRepar([FromBody] ReparDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
