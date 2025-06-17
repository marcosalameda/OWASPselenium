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

		private static readonly NavigationLocation ACTION_PESSOHIS_CANCEL = new("PERSON10446", "Pessohis_Cancel", "Pesso") { vueRouteName = "form-PESSOHIS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESSOHIS_SHOW = new("PERSON10446", "Pessohis_Show", "Pesso") { vueRouteName = "form-PESSOHIS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESSOHIS_NEW = new("PERSON10446", "Pessohis_New", "Pesso") { vueRouteName = "form-PESSOHIS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESSOHIS_EDIT = new("PERSON10446", "Pessohis_Edit", "Pesso") { vueRouteName = "form-PESSOHIS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESSOHIS_DUPLICATE = new("PERSON10446", "Pessohis_Duplicate", "Pesso") { vueRouteName = "form-PESSOHIS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESSOHIS_DELETE = new("PERSON10446", "Pessohis_Delete", "Pesso") { vueRouteName = "form-PESSOHIS", mode = "DELETE" };

		#endregion

		#region Pessohis private

		private void FormHistoryLimits_Pessohis()
		{

		}

		#endregion

		#region Pessohis_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESSOHIS]/

		[HttpPost]
		public ActionResult Pessohis_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessohis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Show_GET",
				AreaName = "pesso",
				Location = ACTION_PESSOHIS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pessohis();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESSOHIS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pessohis_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pessohis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_New_GET",
				AreaName = "pesso",
				FormName = "PESSOHIS",
				Location = ACTION_PESSOHIS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pessohis();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESSOHIS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pesso/Pessohis_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_New([FromBody]Pessohis_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_New",
				ViewName = "Pessohis",
				AreaName = "pesso",
				Location = ACTION_PESSOHIS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESSOHIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESSOHIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESSOHIS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pessohis_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessohis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Edit_GET",
				AreaName = "pesso",
				FormName = "PESSOHIS",
				Location = ACTION_PESSOHIS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pessohis();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESSOHIS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pessohis_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_Edit([FromBody]Pessohis_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Edit",
				ViewName = "Pessohis",
				AreaName = "pesso",
				Location = ACTION_PESSOHIS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESSOHIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESSOHIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESSOHIS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pessohis_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessohis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Delete_GET",
				AreaName = "pesso",
				FormName = "PESSOHIS",
				Location = ACTION_PESSOHIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pessohis();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESSOHIS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pessohis_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pessohis_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Delete",
				ViewName = "Pessohis",
				AreaName = "pesso",
				Location = ACTION_PESSOHIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESSOHIS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pessohis_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESSOHIS");
		}

		#endregion

		#region Pessohis_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESSOHIS]/

		[HttpPost]
		public ActionResult Pessohis_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pessohis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Duplicate_GET",
				AreaName = "pesso",
				FormName = "PESSOHIS",
				Location = ACTION_PESSOHIS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESSOHIS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pesso/Pessohis_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESSOHIS]/
		[HttpPost]
		public ActionResult Pessohis_Duplicate([FromBody]Pessohis_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_Duplicate",
				ViewName = "Pessohis",
				AreaName = "pesso",
				Location = ACTION_PESSOHIS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESSOHIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESSOHIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESSOHIS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pessohis_Cancel

		//
		// GET: /Pesso/Pessohis_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESSOHIS]/
		public ActionResult Pessohis_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pesso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pesso");

// USE /[MANUAL GQT BEFORE_CANCEL PESSOHIS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESSOHIS]/

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


		public class Pessohis_ValField001Model : RequestLookupModel
		{
			public Pessohis_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pessohis_ValField001
		// POST: /Pesso/Pessohis_ValField001
		[ActionName("Pessohis_ValField001")]
		public ActionResult Pessohis_ValField001([FromBody] Pessohis_ValField001Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_hpess")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_hpess");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pessohis_ValField001_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Pesso/Pessohis_SaveEdit
		[HttpPost]
		public ActionResult Pessohis_SaveEdit([FromBody] Pessohis_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pessohis_SaveEdit",
				ViewName = "Pessohis",
				AreaName = "pesso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESSOHIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESSOHIS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PessohisDocumValidateTickets : RequestDocumValidateTickets
		{
			public Pessohis_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPessohis([FromBody] PessohisDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
