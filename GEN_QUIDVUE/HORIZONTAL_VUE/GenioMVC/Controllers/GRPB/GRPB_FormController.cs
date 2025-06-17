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
using GenioMVC.ViewModels.Grpb;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GRPB]/

namespace GenioMVC.Controllers
{
	public partial class GrpbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GRPB_CANCEL = new("GROUP__BASIC_TYPES_31302", "Grpb_Cancel", "Grpb") { vueRouteName = "form-GRPB", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GRPB_SHOW = new("GROUP__BASIC_TYPES_31302", "Grpb_Show", "Grpb") { vueRouteName = "form-GRPB", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GRPB_NEW = new("GROUP__BASIC_TYPES_31302", "Grpb_New", "Grpb") { vueRouteName = "form-GRPB", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GRPB_EDIT = new("GROUP__BASIC_TYPES_31302", "Grpb_Edit", "Grpb") { vueRouteName = "form-GRPB", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GRPB_DUPLICATE = new("GROUP__BASIC_TYPES_31302", "Grpb_Duplicate", "Grpb") { vueRouteName = "form-GRPB", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GRPB_DELETE = new("GROUP__BASIC_TYPES_31302", "Grpb_Delete", "Grpb") { vueRouteName = "form-GRPB", mode = "DELETE" };

		#endregion

		#region Grpb private

		private void FormHistoryLimits_Grpb()
		{

		}

		#endregion

		#region Grpb_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GRPB]/

		[HttpPost]
		public ActionResult Grpb_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Show_GET",
				AreaName = "grpb",
				Location = ACTION_GRPB_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GRPB]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Grpb_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GRPB]/
		[HttpPost]
		public ActionResult Grpb_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Grpb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_New_GET",
				AreaName = "grpb",
				FormName = "GRPB",
				Location = ACTION_GRPB_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Grpb();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GRPB]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Grpb/Grpb_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GRPB]/
		[HttpPost]
		public ActionResult Grpb_New([FromBody]Grpb_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_New",
				ViewName = "Grpb",
				AreaName = "grpb",
				Location = ACTION_GRPB_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GRPB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GRPB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GRPB]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Grpb_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GRPB]/
		[HttpPost]
		public ActionResult Grpb_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Edit_GET",
				AreaName = "grpb",
				FormName = "GRPB",
				Location = ACTION_GRPB_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GRPB]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Grpb/Grpb_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GRPB]/
		[HttpPost]
		public ActionResult Grpb_Edit([FromBody]Grpb_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Edit",
				ViewName = "Grpb",
				AreaName = "grpb",
				Location = ACTION_GRPB_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GRPB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GRPB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GRPB]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Grpb_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GRPB]/
		[HttpPost]
		public ActionResult Grpb_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Delete_GET",
				AreaName = "grpb",
				FormName = "GRPB",
				Location = ACTION_GRPB_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GRPB]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Grpb/Grpb_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GRPB]/
		[HttpPost]
		public ActionResult Grpb_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Delete",
				ViewName = "Grpb",
				AreaName = "grpb",
				Location = ACTION_GRPB_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GRPB]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Grpb_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB");
		}

		#endregion

		#region Grpb_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GRPB]/

		[HttpPost]
		public ActionResult Grpb_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Grpb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Duplicate_GET",
				AreaName = "grpb",
				FormName = "GRPB",
				Location = ACTION_GRPB_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GRPB]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Grpb/Grpb_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GRPB]/
		[HttpPost]
		public ActionResult Grpb_Duplicate([FromBody]Grpb_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_Duplicate",
				ViewName = "Grpb",
				AreaName = "grpb",
				Location = ACTION_GRPB_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GRPB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GRPB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GRPB]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Grpb_Cancel

		//
		// GET: /Grpb/Grpb_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GRPB]/
		public ActionResult Grpb_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Grpb(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("grpb");

// USE /[MANUAL GQT BEFORE_CANCEL GRPB]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GRPB]/

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

				Navigation.SetValue("ForcePrimaryRead_grpb", "true", true);
			}

			Navigation.ClearValue("grpb");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Grpb_ValTblbModel : RequestLookupModel
		{
			public Grpb_ViewModel Model { get; set; }
		}

		//
		// GET: /Grpb/Grpb_ValTblb
		// POST: /Grpb/Grpb_ValTblb
		[ActionName("Grpb_ValTblb")]
		public ActionResult Grpb_ValTblb([FromBody] Grpb_ValTblbModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = -1;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tblb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tblb");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Grpb parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Grpb_ValTblb_ViewModel model = new(UserContext.Current, parentCtx);

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

			return JsonOK(model.Menu);
		}


		// POST: /Grpb/Grpb_SaveEdit
		[HttpPost]
		public ActionResult Grpb_SaveEdit([FromBody] Grpb_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb_SaveEdit",
				ViewName = "Grpb",
				AreaName = "grpb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GRPB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GRPB]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class GrpbDocumValidateTickets : RequestDocumValidateTickets
		{
			public Grpb_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGrpb([FromBody] GrpbDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
