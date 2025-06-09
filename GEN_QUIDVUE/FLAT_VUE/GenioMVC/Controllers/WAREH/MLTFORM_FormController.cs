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
using GenioMVC.ViewModels.Wareh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MLTFORM_CANCEL = new("MULTIFORM41286", "Mltform_Cancel", "Wareh") { vueRouteName = "form-MLTFORM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MLTFORM_SHOW = new("MULTIFORM41286", "Mltform_Show", "Wareh") { vueRouteName = "form-MLTFORM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MLTFORM_NEW = new("MULTIFORM41286", "Mltform_New", "Wareh") { vueRouteName = "form-MLTFORM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MLTFORM_EDIT = new("MULTIFORM41286", "Mltform_Edit", "Wareh") { vueRouteName = "form-MLTFORM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MLTFORM_DUPLICATE = new("MULTIFORM41286", "Mltform_Duplicate", "Wareh") { vueRouteName = "form-MLTFORM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MLTFORM_DELETE = new("MULTIFORM41286", "Mltform_Delete", "Wareh") { vueRouteName = "form-MLTFORM", mode = "DELETE" };

		#endregion

		#region Mltform private

		private void FormHistoryLimits_Mltform()
		{

		}

		#endregion

		#region Mltform_Show

// USE /[MANUAL GQT CONTROLLER_SHOW MLTFORM]/

		[HttpPost]
		public ActionResult Mltform_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mltform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Show_GET",
				AreaName = "wareh",
				Location = ACTION_MLTFORM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mltform();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW MLTFORM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Mltform_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Mltform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_New_GET",
				AreaName = "wareh",
				FormName = "MLTFORM",
				Location = ACTION_MLTFORM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Mltform();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW MLTFORM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Mltform_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_New([FromBody]Mltform_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_New",
				ViewName = "Mltform",
				AreaName = "wareh",
				Location = ACTION_MLTFORM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW MLTFORM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX MLTFORM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX MLTFORM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Mltform_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mltform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Edit_GET",
				AreaName = "wareh",
				FormName = "MLTFORM",
				Location = ACTION_MLTFORM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mltform();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT MLTFORM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Mltform_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_Edit([FromBody]Mltform_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Edit",
				ViewName = "Mltform",
				AreaName = "wareh",
				Location = ACTION_MLTFORM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT MLTFORM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX MLTFORM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX MLTFORM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Mltform_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mltform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Delete_GET",
				AreaName = "wareh",
				FormName = "MLTFORM",
				Location = ACTION_MLTFORM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Mltform();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE MLTFORM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Mltform_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Mltform_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Delete",
				ViewName = "Mltform",
				AreaName = "wareh",
				Location = ACTION_MLTFORM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE MLTFORM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Mltform_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MLTFORM");
		}

		#endregion

		#region Mltform_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET MLTFORM]/

		[HttpPost]
		public ActionResult Mltform_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Mltform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Duplicate_GET",
				AreaName = "wareh",
				FormName = "MLTFORM",
				Location = ACTION_MLTFORM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE MLTFORM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Mltform_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST MLTFORM]/
		[HttpPost]
		public ActionResult Mltform_Duplicate([FromBody]Mltform_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Mltform_Duplicate",
				ViewName = "Mltform",
				AreaName = "wareh",
				Location = ACTION_MLTFORM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE MLTFORM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX MLTFORM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX MLTFORM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Mltform_Cancel

		//
		// GET: /Wareh/Mltform_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET MLTFORM]/
		public ActionResult Mltform_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wareh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL MLTFORM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL MLTFORM]/

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

				Navigation.SetValue("ForcePrimaryRead_wareh", "true", true);
			}

			Navigation.ClearValue("wareh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Mltform_ValMltform1Model : RequestLookupModel
		{
			public Mltform_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Mltform_ValMltform1
		// POST: /Wareh/Mltform_ValMltform1
		[ActionName("Mltform_ValMltform1")]
		public ActionResult Mltform_ValMltform1([FromBody] Mltform_ValMltform1Model requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wpess")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wpess");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Wareh parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Mltform_ValMltform1_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Wareh/Mltform_SaveEdit
		[HttpPost]
		public ActionResult Mltform_SaveEdit([FromBody] Mltform_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Mltform_SaveEdit",
				ViewName = "Mltform",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT MLTFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT MLTFORM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class MltformDocumValidateTickets : RequestDocumValidateTickets
		{
			public Mltform_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsMltform([FromBody] MltformDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
