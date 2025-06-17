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

		private static readonly NavigationLocation ACTION_ARMAZPOP_CANCEL = new("WAREHOUSE51864", "Armazpop_Cancel", "Wareh") { vueRouteName = "form-ARMAZPOP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARMAZPOP_SHOW = new("WAREHOUSE51864", "Armazpop_Show", "Wareh") { vueRouteName = "form-ARMAZPOP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARMAZPOP_NEW = new("WAREHOUSE51864", "Armazpop_New", "Wareh") { vueRouteName = "form-ARMAZPOP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARMAZPOP_EDIT = new("WAREHOUSE51864", "Armazpop_Edit", "Wareh") { vueRouteName = "form-ARMAZPOP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARMAZPOP_DUPLICATE = new("WAREHOUSE51864", "Armazpop_Duplicate", "Wareh") { vueRouteName = "form-ARMAZPOP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARMAZPOP_DELETE = new("WAREHOUSE51864", "Armazpop_Delete", "Wareh") { vueRouteName = "form-ARMAZPOP", mode = "DELETE" };

		#endregion

		#region Armazpop private

		private void FormHistoryLimits_Armazpop()
		{

		}

		#endregion

		#region Armazpop_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARMAZPOP]/

		[HttpPost]
		public ActionResult Armazpop_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Armazpop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Show_GET",
				AreaName = "wareh",
				Location = ACTION_ARMAZPOP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armazpop();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARMAZPOP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Armazpop_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Armazpop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_New_GET",
				AreaName = "wareh",
				FormName = "ARMAZPOP",
				Location = ACTION_ARMAZPOP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Armazpop();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARMAZPOP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Armazpop_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_New([FromBody]Armazpop_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_New",
				ViewName = "Armazpop",
				AreaName = "wareh",
				Location = ACTION_ARMAZPOP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARMAZPOP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARMAZPOP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARMAZPOP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Armazpop_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Armazpop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Edit_GET",
				AreaName = "wareh",
				FormName = "ARMAZPOP",
				Location = ACTION_ARMAZPOP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armazpop();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARMAZPOP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Armazpop_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_Edit([FromBody]Armazpop_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Edit",
				ViewName = "Armazpop",
				AreaName = "wareh",
				Location = ACTION_ARMAZPOP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARMAZPOP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARMAZPOP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARMAZPOP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Armazpop_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Armazpop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Delete_GET",
				AreaName = "wareh",
				FormName = "ARMAZPOP",
				Location = ACTION_ARMAZPOP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armazpop();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARMAZPOP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Armazpop_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Armazpop_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Delete",
				ViewName = "Armazpop",
				AreaName = "wareh",
				Location = ACTION_ARMAZPOP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARMAZPOP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Armazpop_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARMAZPOP");
		}

		#endregion

		#region Armazpop_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARMAZPOP]/

		[HttpPost]
		public ActionResult Armazpop_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Armazpop_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Duplicate_GET",
				AreaName = "wareh",
				FormName = "ARMAZPOP",
				Location = ACTION_ARMAZPOP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARMAZPOP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Armazpop_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARMAZPOP]/
		[HttpPost]
		public ActionResult Armazpop_Duplicate([FromBody]Armazpop_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_Duplicate",
				ViewName = "Armazpop",
				AreaName = "wareh",
				Location = ACTION_ARMAZPOP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARMAZPOP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARMAZPOP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARMAZPOP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Armazpop_Cancel

		//
		// GET: /Wareh/Armazpop_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARMAZPOP]/
		public ActionResult Armazpop_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wareh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL ARMAZPOP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARMAZPOP]/

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


		public class Armaz02_ValArtigosModel : RequestLookupModel
		{
			public Armazpop_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Armaz02_ValArtigos
		// POST: /Wareh/Armaz02_ValArtigos
		[ActionName("Armaz02_ValArtigos")]
		public ActionResult Armaz02_ValArtigos([FromBody] Armaz02_ValArtigosModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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
			Armaz02_ValArtigos_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Wareh/Armazpop_SaveEdit
		[HttpPost]
		public ActionResult Armazpop_SaveEdit([FromBody] Armazpop_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Armazpop_SaveEdit",
				ViewName = "Armazpop",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARMAZPOP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARMAZPOP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ArmazpopDocumValidateTickets : RequestDocumValidateTickets
		{
			public Armazpop_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArmazpop([FromBody] ArmazpopDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
