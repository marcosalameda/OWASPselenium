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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FLDSTBL_CANCEL = new("FIELD_TYPE57098", "Fldstbl_Cancel", "Flds") { vueRouteName = "form-FLDSTBL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FLDSTBL_SHOW = new("FIELD_TYPE57098", "Fldstbl_Show", "Flds") { vueRouteName = "form-FLDSTBL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FLDSTBL_NEW = new("FIELD_TYPE57098", "Fldstbl_New", "Flds") { vueRouteName = "form-FLDSTBL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FLDSTBL_EDIT = new("FIELD_TYPE57098", "Fldstbl_Edit", "Flds") { vueRouteName = "form-FLDSTBL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FLDSTBL_DUPLICATE = new("FIELD_TYPE57098", "Fldstbl_Duplicate", "Flds") { vueRouteName = "form-FLDSTBL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FLDSTBL_DELETE = new("FIELD_TYPE57098", "Fldstbl_Delete", "Flds") { vueRouteName = "form-FLDSTBL", mode = "DELETE" };

		#endregion

		#region Fldstbl private

		private void FormHistoryLimits_Fldstbl()
		{

		}

		#endregion

		#region Fldstbl_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FLDSTBL]/

		[HttpPost]
		public ActionResult Fldstbl_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldstbl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Show_GET",
				AreaName = "flds",
				Location = ACTION_FLDSTBL_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldstbl();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FLDSTBL]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Fldstbl_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Fldstbl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_New_GET",
				AreaName = "flds",
				FormName = "FLDSTBL",
				Location = ACTION_FLDSTBL_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Fldstbl();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FLDSTBL]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Flds/Fldstbl_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_New([FromBody]Fldstbl_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_New",
				ViewName = "Fldstbl",
				AreaName = "flds",
				Location = ACTION_FLDSTBL_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FLDSTBL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FLDSTBL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FLDSTBL]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Fldstbl_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldstbl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Edit_GET",
				AreaName = "flds",
				FormName = "FLDSTBL",
				Location = ACTION_FLDSTBL_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldstbl();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FLDSTBL]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Flds/Fldstbl_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_Edit([FromBody]Fldstbl_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Edit",
				ViewName = "Fldstbl",
				AreaName = "flds",
				Location = ACTION_FLDSTBL_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FLDSTBL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FLDSTBL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FLDSTBL]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Fldstbl_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldstbl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Delete_GET",
				AreaName = "flds",
				FormName = "FLDSTBL",
				Location = ACTION_FLDSTBL_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldstbl();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FLDSTBL]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Flds/Fldstbl_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldstbl_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Delete",
				ViewName = "Fldstbl",
				AreaName = "flds",
				Location = ACTION_FLDSTBL_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FLDSTBL]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Fldstbl_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSTBL");
		}

		#endregion

		#region Fldstbl_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FLDSTBL]/

		[HttpPost]
		public ActionResult Fldstbl_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Fldstbl_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Duplicate_GET",
				AreaName = "flds",
				FormName = "FLDSTBL",
				Location = ACTION_FLDSTBL_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FLDSTBL]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Flds/Fldstbl_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FLDSTBL]/
		[HttpPost]
		public ActionResult Fldstbl_Duplicate([FromBody]Fldstbl_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldstbl_Duplicate",
				ViewName = "Fldstbl",
				AreaName = "flds",
				Location = ACTION_FLDSTBL_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FLDSTBL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FLDSTBL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FLDSTBL]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Fldstbl_Cancel

		//
		// GET: /Flds/Fldstbl_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FLDSTBL]/
		public ActionResult Fldstbl_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Flds(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("flds");

// USE /[MANUAL GQT BEFORE_CANCEL FLDSTBL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FLDSTBL]/

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


		public class Fldstbl_AeroValNameModel : RequestLookupModel
		{
			public Fldstbl_ViewModel Model { get; set; }
		}

		//
		// GET: /Flds/Fldstbl_AeroValName
		// POST: /Flds/Fldstbl_AeroValName
		[ActionName("Fldstbl_AeroValName")]
		public ActionResult Fldstbl_AeroValName([FromBody] Fldstbl_AeroValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_aero")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_aero");
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

			Models.Flds parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Fldstbl_AeroValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Fldstbl_ValFeecaModel : RequestLookupModel
		{
			public Fldstbl_ViewModel Model { get; set; }
		}

		//
		// GET: /Flds/Fldstbl_ValFeeca
		// POST: /Flds/Fldstbl_ValFeeca
		[ActionName("Fldstbl_ValFeeca")]
		public ActionResult Fldstbl_ValFeeca([FromBody] Fldstbl_ValFeecaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_feeca")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_feeca");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Flds parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Fldstbl_ValFeeca_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Flds/Fldstbl_SaveEdit
		[HttpPost]
		public ActionResult Fldstbl_SaveEdit([FromBody] Fldstbl_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fldstbl_SaveEdit",
				ViewName = "Fldstbl",
				AreaName = "flds",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FLDSTBL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FLDSTBL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class FldstblDocumValidateTickets : RequestDocumValidateTickets
		{
			public Fldstbl_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsFldstbl([FromBody] FldstblDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}

		/// <summary>
		/// Stores a new document, in the Docums table, associated to field ATTACH
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFileFldstblAttach([FromForm] RequestDocumsCreateModel requestModel)
		{
			List<string> extensions = [];
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version, extensions);
		}
	}
}
