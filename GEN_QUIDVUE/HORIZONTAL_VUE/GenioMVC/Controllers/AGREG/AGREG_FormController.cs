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
using GenioMVC.ViewModels.Agreg;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER AGREG]/

namespace GenioMVC.Controllers
{
	public partial class AgregController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AGREG_CANCEL = new("AGREGA_POR_ANO62275", "Agreg_Cancel", "Agreg") { vueRouteName = "form-AGREG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AGREG_SHOW = new("AGREGA_POR_ANO62275", "Agreg_Show", "Agreg") { vueRouteName = "form-AGREG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AGREG_NEW = new("AGREGA_POR_ANO62275", "Agreg_New", "Agreg") { vueRouteName = "form-AGREG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AGREG_EDIT = new("AGREGA_POR_ANO62275", "Agreg_Edit", "Agreg") { vueRouteName = "form-AGREG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AGREG_DUPLICATE = new("AGREGA_POR_ANO62275", "Agreg_Duplicate", "Agreg") { vueRouteName = "form-AGREG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AGREG_DELETE = new("AGREGA_POR_ANO62275", "Agreg_Delete", "Agreg") { vueRouteName = "form-AGREG", mode = "DELETE" };

		#endregion

		#region Agreg private

		private void FormHistoryLimits_Agreg()
		{

		}

		#endregion

		#region Agreg_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AGREG]/

		[HttpPost]
		public ActionResult Agreg_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Show_GET",
				AreaName = "agreg",
				Location = ACTION_AGREG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agreg();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AGREG]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Agreg_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AGREG]/
		[HttpPost]
		public ActionResult Agreg_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Agreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_New_GET",
				AreaName = "agreg",
				FormName = "AGREG",
				Location = ACTION_AGREG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Agreg();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AGREG]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Agreg/Agreg_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AGREG]/
		[HttpPost]
		public ActionResult Agreg_New([FromBody]Agreg_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_New",
				ViewName = "Agreg",
				AreaName = "agreg",
				Location = ACTION_AGREG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AGREG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AGREG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AGREG]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Agreg_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AGREG]/
		[HttpPost]
		public ActionResult Agreg_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Edit_GET",
				AreaName = "agreg",
				FormName = "AGREG",
				Location = ACTION_AGREG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agreg();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AGREG]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Agreg/Agreg_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AGREG]/
		[HttpPost]
		public ActionResult Agreg_Edit([FromBody]Agreg_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Edit",
				ViewName = "Agreg",
				AreaName = "agreg",
				Location = ACTION_AGREG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AGREG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AGREG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AGREG]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Agreg_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AGREG]/
		[HttpPost]
		public ActionResult Agreg_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Delete_GET",
				AreaName = "agreg",
				FormName = "AGREG",
				Location = ACTION_AGREG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agreg();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AGREG]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Agreg/Agreg_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AGREG]/
		[HttpPost]
		public ActionResult Agreg_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agreg_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Delete",
				ViewName = "Agreg",
				AreaName = "agreg",
				Location = ACTION_AGREG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AGREG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Agreg_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AGREG");
		}

		#endregion

		#region Agreg_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AGREG]/

		[HttpPost]
		public ActionResult Agreg_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Agreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Duplicate_GET",
				AreaName = "agreg",
				FormName = "AGREG",
				Location = ACTION_AGREG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AGREG]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Agreg/Agreg_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AGREG]/
		[HttpPost]
		public ActionResult Agreg_Duplicate([FromBody]Agreg_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_Duplicate",
				ViewName = "Agreg",
				AreaName = "agreg",
				Location = ACTION_AGREG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AGREG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AGREG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AGREG]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Agreg_Cancel

		//
		// GET: /Agreg/Agreg_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AGREG]/
		public ActionResult Agreg_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Agreg(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("agreg");

// USE /[MANUAL GQT BEFORE_CANCEL AGREG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AGREG]/

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

				Navigation.SetValue("ForcePrimaryRead_agreg", "true", true);
			}

			Navigation.ClearValue("agreg");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Agreg_ProjeValProjectoModel : RequestLookupModel
		{
			public Agreg_ViewModel Model { get; set; }
		}

		//
		// GET: /Agreg/Agreg_ProjeValProjecto
		// POST: /Agreg/Agreg_ProjeValProjecto
		[ActionName("Agreg_ProjeValProjecto")]
		public ActionResult Agreg_ProjeValProjecto([FromBody] Agreg_ProjeValProjectoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_proje")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_proje");
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

			Models.Agreg parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Agreg_ProjeValProjecto_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Agreg_YearValYearModel : RequestLookupModel
		{
			public Agreg_ViewModel Model { get; set; }
		}

		//
		// GET: /Agreg/Agreg_YearValYear
		// POST: /Agreg/Agreg_YearValYear
		[ActionName("Agreg_YearValYear")]
		public ActionResult Agreg_YearValYear([FromBody] Agreg_YearValYearModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_year")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_year");
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

			Models.Agreg parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Agreg_YearValYear_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Agreg/Agreg_SaveEdit
		[HttpPost]
		public ActionResult Agreg_SaveEdit([FromBody] Agreg_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agreg_SaveEdit",
				ViewName = "Agreg",
				AreaName = "agreg",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AGREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AGREG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AgregDocumValidateTickets : RequestDocumValidateTickets
		{
			public Agreg_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAgreg([FromBody] AgregDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
