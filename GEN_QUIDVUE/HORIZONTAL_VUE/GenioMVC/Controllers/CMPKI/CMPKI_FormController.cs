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
using GenioMVC.ViewModels.Cmpki;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPKI]/

namespace GenioMVC.Controllers
{
	public partial class CmpkiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CMPKI_CANCEL = new("KIT_COMPONENT05829", "Cmpki_Cancel", "Cmpki") { vueRouteName = "form-CMPKI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CMPKI_SHOW = new("KIT_COMPONENT05829", "Cmpki_Show", "Cmpki") { vueRouteName = "form-CMPKI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CMPKI_NEW = new("KIT_COMPONENT05829", "Cmpki_New", "Cmpki") { vueRouteName = "form-CMPKI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CMPKI_EDIT = new("KIT_COMPONENT05829", "Cmpki_Edit", "Cmpki") { vueRouteName = "form-CMPKI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CMPKI_DUPLICATE = new("KIT_COMPONENT05829", "Cmpki_Duplicate", "Cmpki") { vueRouteName = "form-CMPKI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CMPKI_DELETE = new("KIT_COMPONENT05829", "Cmpki_Delete", "Cmpki") { vueRouteName = "form-CMPKI", mode = "DELETE" };

		#endregion

		#region Cmpki private

		private void FormHistoryLimits_Cmpki()
		{

		}

		#endregion

		#region Cmpki_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CMPKI]/

		[HttpPost]
		public ActionResult Cmpki_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Show_GET",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CMPKI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Cmpki_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_New_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CMPKI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cmpki/Cmpki_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_New([FromBody]Cmpki_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_New",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CMPKI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CMPKI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CMPKI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Cmpki_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Edit_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CMPKI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cmpki/Cmpki_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Edit([FromBody]Cmpki_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Edit",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CMPKI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CMPKI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CMPKI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Cmpki_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Delete_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cmpki();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CMPKI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cmpki/Cmpki_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cmpki_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Delete",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CMPKI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Cmpki_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CMPKI");
		}

		#endregion

		#region Cmpki_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CMPKI]/

		[HttpPost]
		public ActionResult Cmpki_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cmpki_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Duplicate_GET",
				AreaName = "cmpki",
				FormName = "CMPKI",
				Location = ACTION_CMPKI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CMPKI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cmpki/Cmpki_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CMPKI]/
		[HttpPost]
		public ActionResult Cmpki_Duplicate([FromBody]Cmpki_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_Duplicate",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				Location = ACTION_CMPKI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CMPKI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CMPKI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CMPKI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Cmpki_Cancel

		//
		// GET: /Cmpki/Cmpki_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CMPKI]/
		public ActionResult Cmpki_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cmpki(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cmpki");

// USE /[MANUAL GQT BEFORE_CANCEL CMPKI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CMPKI]/

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

				Navigation.SetValue("ForcePrimaryRead_cmpki", "true", true);
			}

			Navigation.ClearValue("cmpki");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Cmpki_TpequValTipoequiModel : RequestLookupModel
		{
			public Cmpki_ViewModel Model { get; set; }
		}

		//
		// GET: /Cmpki/Cmpki_TpequValTipoequi
		// POST: /Cmpki/Cmpki_TpequValTipoequi
		[ActionName("Cmpki_TpequValTipoequi")]
		public ActionResult Cmpki_TpequValTipoequi([FromBody] Cmpki_TpequValTipoequiModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
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

			Models.Cmpki parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Cmpki_TpequValTipoequi_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Cmpki_Tpeq1ValTipoequiModel : RequestLookupModel
		{
			public Cmpki_ViewModel Model { get; set; }
		}

		//
		// GET: /Cmpki/Cmpki_Tpeq1ValTipoequi
		// POST: /Cmpki/Cmpki_Tpeq1ValTipoequi
		[ActionName("Cmpki_Tpeq1ValTipoequi")]
		public ActionResult Cmpki_Tpeq1ValTipoequi([FromBody] Cmpki_Tpeq1ValTipoequiModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpeq1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpeq1");
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

			Models.Cmpki parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Cmpki_Tpeq1ValTipoequi_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Cmpki/Cmpki_SaveEdit
		[HttpPost]
		public ActionResult Cmpki_SaveEdit([FromBody] Cmpki_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cmpki_SaveEdit",
				ViewName = "Cmpki",
				AreaName = "cmpki",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CMPKI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CMPKI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CmpkiDocumValidateTickets : RequestDocumValidateTickets
		{
			public Cmpki_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCmpki([FromBody] CmpkiDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
