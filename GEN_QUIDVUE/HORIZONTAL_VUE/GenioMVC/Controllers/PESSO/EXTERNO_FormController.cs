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
using GenioMVC.ViewModels.Pesso;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESSO]/

namespace GenioMVC.Controllers
{
	public partial class PessoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EXTERNO_CANCEL = new("PERSON10446", "Externo_Cancel", "Pesso") { vueRouteName = "form-EXTERNO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EXTERNO_SHOW = new("PERSON10446", "Externo_Show", "Pesso") { vueRouteName = "form-EXTERNO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EXTERNO_NEW = new("PERSON10446", "Externo_New", "Pesso") { vueRouteName = "form-EXTERNO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EXTERNO_EDIT = new("PERSON10446", "Externo_Edit", "Pesso") { vueRouteName = "form-EXTERNO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EXTERNO_DUPLICATE = new("PERSON10446", "Externo_Duplicate", "Pesso") { vueRouteName = "form-EXTERNO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EXTERNO_DELETE = new("PERSON10446", "Externo_Delete", "Pesso") { vueRouteName = "form-EXTERNO", mode = "DELETE" };

		#endregion

		#region Externo private

		private void FormHistoryLimits_Externo()
		{

		}

		#endregion

		#region Externo_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EXTERNO]/

		[HttpPost]
		public ActionResult Externo_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Externo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Externo_Show_GET",
				AreaName = "pesso",
				Location = ACTION_EXTERNO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Externo();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EXTERNO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Externo_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EXTERNO]/
		[HttpPost]
		public ActionResult Externo_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Externo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Externo_New_GET",
				AreaName = "pesso",
				FormName = "EXTERNO",
				Location = ACTION_EXTERNO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Externo();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EXTERNO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pesso/Externo_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EXTERNO]/
		[HttpPost]
		public ActionResult Externo_New([FromBody]Externo_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Externo_New",
				ViewName = "Externo",
				AreaName = "pesso",
				Location = ACTION_EXTERNO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EXTERNO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EXTERNO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EXTERNO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Externo_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EXTERNO]/
		[HttpPost]
		public ActionResult Externo_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Externo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Externo_Edit_GET",
				AreaName = "pesso",
				FormName = "EXTERNO",
				Location = ACTION_EXTERNO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Externo();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EXTERNO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pesso/Externo_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EXTERNO]/
		[HttpPost]
		public ActionResult Externo_Edit([FromBody]Externo_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Externo_Edit",
				ViewName = "Externo",
				AreaName = "pesso",
				Location = ACTION_EXTERNO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EXTERNO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EXTERNO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EXTERNO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Externo_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EXTERNO]/
		[HttpPost]
		public ActionResult Externo_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Externo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Externo_Delete_GET",
				AreaName = "pesso",
				FormName = "EXTERNO",
				Location = ACTION_EXTERNO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Externo();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EXTERNO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pesso/Externo_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EXTERNO]/
		[HttpPost]
		public ActionResult Externo_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Externo_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Externo_Delete",
				ViewName = "Externo",
				AreaName = "pesso",
				Location = ACTION_EXTERNO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EXTERNO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Externo_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EXTERNO");
		}

		#endregion

		#region Externo_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EXTERNO]/

		[HttpPost]
		public ActionResult Externo_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Externo_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Externo_Duplicate_GET",
				AreaName = "pesso",
				FormName = "EXTERNO",
				Location = ACTION_EXTERNO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EXTERNO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pesso/Externo_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EXTERNO]/
		[HttpPost]
		public ActionResult Externo_Duplicate([FromBody]Externo_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Externo_Duplicate",
				ViewName = "Externo",
				AreaName = "pesso",
				Location = ACTION_EXTERNO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EXTERNO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EXTERNO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EXTERNO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Externo_Cancel

		//
		// GET: /Pesso/Externo_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EXTERNO]/
		public ActionResult Externo_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pesso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");

// USE /[MANUAL GQT BEFORE_CANCEL EXTERNO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EXTERNO]/

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

				Navigation.SetValue("ForcePrimaryRead_pesso", "true", true);
			}

			Navigation.ClearValue("pesso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Externo_CmpnyValDesignatModel : RequestLookupModel
		{
			public Externo_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Externo_CmpnyValDesignat
		// POST: /Pesso/Externo_CmpnyValDesignat
		[ActionName("Externo_CmpnyValDesignat")]
		public ActionResult Externo_CmpnyValDesignat([FromBody] Externo_CmpnyValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Externo_CmpnyValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Pesso/Externo_SaveEdit
		[HttpPost]
		public ActionResult Externo_SaveEdit([FromBody] Externo_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Externo_SaveEdit",
				ViewName = "Externo",
				AreaName = "pesso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EXTERNO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EXTERNO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ExternoDocumValidateTickets : RequestDocumValidateTickets
		{
			public Externo_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsExterno([FromBody] ExternoDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
