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
using GenioMVC.ViewModels.Wpess;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WPESS]/

namespace GenioMVC.Controllers
{
	public partial class WpessController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PESSPOP_CANCEL = new("FUNCIONARIO_DO_ARMAZ49520", "Pesspop_Cancel", "Wpess") { vueRouteName = "form-PESSPOP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESSPOP_SHOW = new("FUNCIONARIO_DO_ARMAZ49520", "Pesspop_Show", "Wpess") { vueRouteName = "form-PESSPOP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESSPOP_NEW = new("FUNCIONARIO_DO_ARMAZ49520", "Pesspop_New", "Wpess") { vueRouteName = "form-PESSPOP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESSPOP_EDIT = new("FUNCIONARIO_DO_ARMAZ49520", "Pesspop_Edit", "Wpess") { vueRouteName = "form-PESSPOP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESSPOP_DUPLICATE = new("FUNCIONARIO_DO_ARMAZ49520", "Pesspop_Duplicate", "Wpess") { vueRouteName = "form-PESSPOP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESSPOP_DELETE = new("FUNCIONARIO_DO_ARMAZ49520", "Pesspop_Delete", "Wpess") { vueRouteName = "form-PESSPOP", mode = "DELETE" };

		#endregion

		#region Pesspop private

		private void FormHistoryLimits_Pesspop()
		{

		}

		#endregion

		#region Pesspop_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESSPOP]/

		[HttpPost]
		public ActionResult Pesspop_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesspop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Show_GET",
				AreaName = "wpess",
				Location = ACTION_PESSPOP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesspop();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESSPOP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pesspop_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pesspop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_New_GET",
				AreaName = "wpess",
				FormName = "PESSPOP",
				Location = ACTION_PESSPOP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pesspop();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESSPOP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wpess/Pesspop_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_New([FromBody]Pesspop_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_New",
				ViewName = "Pesspop",
				AreaName = "wpess",
				Location = ACTION_PESSPOP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESSPOP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESSPOP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESSPOP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pesspop_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesspop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Edit_GET",
				AreaName = "wpess",
				FormName = "PESSPOP",
				Location = ACTION_PESSPOP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesspop();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESSPOP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wpess/Pesspop_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_Edit([FromBody]Pesspop_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Edit",
				ViewName = "Pesspop",
				AreaName = "wpess",
				Location = ACTION_PESSPOP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESSPOP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESSPOP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESSPOP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pesspop_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesspop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Delete_GET",
				AreaName = "wpess",
				FormName = "PESSPOP",
				Location = ACTION_PESSPOP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesspop();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESSPOP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wpess/Pesspop_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pesspop_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Delete",
				ViewName = "Pesspop",
				AreaName = "wpess",
				Location = ACTION_PESSPOP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESSPOP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pesspop_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESSPOP");
		}

		#endregion

		#region Pesspop_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESSPOP]/

		[HttpPost]
		public ActionResult Pesspop_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pesspop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Duplicate_GET",
				AreaName = "wpess",
				FormName = "PESSPOP",
				Location = ACTION_PESSPOP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESSPOP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wpess/Pesspop_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESSPOP]/
		[HttpPost]
		public ActionResult Pesspop_Duplicate([FromBody]Pesspop_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pesspop_Duplicate",
				ViewName = "Pesspop",
				AreaName = "wpess",
				Location = ACTION_PESSPOP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESSPOP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESSPOP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESSPOP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pesspop_Cancel

		//
		// GET: /Wpess/Pesspop_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESSPOP]/
		public ActionResult Pesspop_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wpess(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wpess");

// USE /[MANUAL GQT BEFORE_CANCEL PESSPOP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESSPOP]/

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

				Navigation.SetValue("ForcePrimaryRead_wpess", "true", true);
			}

			Navigation.ClearValue("wpess");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pesspop_WarehValWarehdesModel : RequestLookupModel
		{
			public Pesspop_ViewModel Model { get; set; }
		}

		//
		// GET: /Wpess/Pesspop_WarehValWarehdes
		// POST: /Wpess/Pesspop_WarehValWarehdes
		[ActionName("Pesspop_WarehValWarehdes")]
		public ActionResult Pesspop_WarehValWarehdes([FromBody] Pesspop_WarehValWarehdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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

			Models.Wpess parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pesspop_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Wpess/Pesspop_SaveEdit
		[HttpPost]
		public ActionResult Pesspop_SaveEdit([FromBody] Pesspop_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pesspop_SaveEdit",
				ViewName = "Pesspop",
				AreaName = "wpess",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESSPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESSPOP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PesspopDocumValidateTickets : RequestDocumValidateTickets
		{
			public Pesspop_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPesspop([FromBody] PesspopDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
