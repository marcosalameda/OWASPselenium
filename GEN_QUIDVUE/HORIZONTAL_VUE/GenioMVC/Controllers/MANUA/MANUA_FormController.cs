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
using GenioMVC.ViewModels.Manua;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MANUA]/

namespace GenioMVC.Controllers
{
	public partial class ManuaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MANUA_CANCEL = new("MANUAL_TO_COLLECT13417", "Manua_Cancel", "Manua") { vueRouteName = "form-MANUA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MANUA_SHOW = new("MANUAL_TO_COLLECT13417", "Manua_Show", "Manua") { vueRouteName = "form-MANUA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MANUA_NEW = new("MANUAL_TO_COLLECT13417", "Manua_New", "Manua") { vueRouteName = "form-MANUA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MANUA_EDIT = new("MANUAL_TO_COLLECT13417", "Manua_Edit", "Manua") { vueRouteName = "form-MANUA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MANUA_DUPLICATE = new("MANUAL_TO_COLLECT13417", "Manua_Duplicate", "Manua") { vueRouteName = "form-MANUA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MANUA_DELETE = new("MANUAL_TO_COLLECT13417", "Manua_Delete", "Manua") { vueRouteName = "form-MANUA", mode = "DELETE" };

		#endregion

		#region Manua private

		private void FormHistoryLimits_Manua()
		{

		}

		#endregion

		#region Manua_Show

// USE /[MANUAL GQT CONTROLLER_SHOW MANUA]/

		[HttpPost]
		public ActionResult Manua_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Manua_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Manua_Show_GET",
				AreaName = "manua",
				Location = ACTION_MANUA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Manua();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW MANUA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Manua_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET MANUA]/
		[HttpPost]
		public ActionResult Manua_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Manua_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Manua_New_GET",
				AreaName = "manua",
				FormName = "MANUA",
				Location = ACTION_MANUA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Manua();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW MANUA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Manua/Manua_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST MANUA]/
		[HttpPost]
		public ActionResult Manua_New([FromBody]Manua_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Manua_New",
				ViewName = "Manua",
				AreaName = "manua",
				Location = ACTION_MANUA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW MANUA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX MANUA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX MANUA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Manua_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET MANUA]/
		[HttpPost]
		public ActionResult Manua_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Manua_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Manua_Edit_GET",
				AreaName = "manua",
				FormName = "MANUA",
				Location = ACTION_MANUA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Manua();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT MANUA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Manua/Manua_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST MANUA]/
		[HttpPost]
		public ActionResult Manua_Edit([FromBody]Manua_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Manua_Edit",
				ViewName = "Manua",
				AreaName = "manua",
				Location = ACTION_MANUA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT MANUA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX MANUA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX MANUA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Manua_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET MANUA]/
		[HttpPost]
		public ActionResult Manua_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Manua_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Manua_Delete_GET",
				AreaName = "manua",
				FormName = "MANUA",
				Location = ACTION_MANUA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Manua();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE MANUA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Manua/Manua_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST MANUA]/
		[HttpPost]
		public ActionResult Manua_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Manua_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Manua_Delete",
				ViewName = "Manua",
				AreaName = "manua",
				Location = ACTION_MANUA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE MANUA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Manua_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MANUA");
		}

		#endregion

		#region Manua_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET MANUA]/

		[HttpPost]
		public ActionResult Manua_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Manua_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Manua_Duplicate_GET",
				AreaName = "manua",
				FormName = "MANUA",
				Location = ACTION_MANUA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE MANUA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Manua/Manua_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST MANUA]/
		[HttpPost]
		public ActionResult Manua_Duplicate([FromBody]Manua_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Manua_Duplicate",
				ViewName = "Manua",
				AreaName = "manua",
				Location = ACTION_MANUA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE MANUA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX MANUA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX MANUA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Manua_Cancel

		//
		// GET: /Manua/Manua_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET MANUA]/
		public ActionResult Manua_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Manua(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("manua");

// USE /[MANUAL GQT BEFORE_CANCEL MANUA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL MANUA]/

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

				Navigation.SetValue("ForcePrimaryRead_manua", "true", true);
			}

			Navigation.ClearValue("manua");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Manua_KindeValDesignatModel : RequestLookupModel
		{
			public Manua_ViewModel Model { get; set; }
		}

		//
		// GET: /Manua/Manua_KindeValDesignat
		// POST: /Manua/Manua_KindeValDesignat
		[ActionName("Manua_KindeValDesignat")]
		public ActionResult Manua_KindeValDesignat([FromBody] Manua_KindeValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
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

			Models.Manua parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Manua_KindeValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Manua/Manua_SaveEdit
		[HttpPost]
		public ActionResult Manua_SaveEdit([FromBody] Manua_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Manua_SaveEdit",
				ViewName = "Manua",
				AreaName = "manua",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT MANUA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT MANUA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ManuaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Manua_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsManua([FromBody] ManuaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
