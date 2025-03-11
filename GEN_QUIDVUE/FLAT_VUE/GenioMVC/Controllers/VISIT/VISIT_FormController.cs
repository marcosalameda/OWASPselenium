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
using GenioMVC.ViewModels.Visit;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER VISIT]/

namespace GenioMVC.Controllers
{
	public partial class VisitController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VISIT_CANCEL = new("VISIT42885", "Visit_Cancel", "Visit") { vueRouteName = "form-VISIT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VISIT_SHOW = new("VISIT42885", "Visit_Show", "Visit") { vueRouteName = "form-VISIT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VISIT_NEW = new("VISIT42885", "Visit_New", "Visit") { vueRouteName = "form-VISIT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VISIT_EDIT = new("VISIT42885", "Visit_Edit", "Visit") { vueRouteName = "form-VISIT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VISIT_DUPLICATE = new("VISIT42885", "Visit_Duplicate", "Visit") { vueRouteName = "form-VISIT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VISIT_DELETE = new("VISIT42885", "Visit_Delete", "Visit") { vueRouteName = "form-VISIT", mode = "DELETE" };

		#endregion

		#region Visit private

		private void FormHistoryLimits_Visit()
		{

		}

		#endregion

		#region Visit_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VISIT]/

		[HttpPost]
		public ActionResult Visit_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit_Show_GET",
				AreaName = "visit",
				Location = ACTION_VISIT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Visit();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VISIT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Visit_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VISIT]/
		[HttpPost]
		public ActionResult Visit_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Visit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit_New_GET",
				AreaName = "visit",
				FormName = "VISIT",
				Location = ACTION_VISIT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Visit();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VISIT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Visit/Visit_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VISIT]/
		[HttpPost]
		public ActionResult Visit_New([FromBody]Visit_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit_New",
				ViewName = "Visit",
				AreaName = "visit",
				Location = ACTION_VISIT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VISIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VISIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VISIT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Visit_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VISIT]/
		[HttpPost]
		public ActionResult Visit_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit_Edit_GET",
				AreaName = "visit",
				FormName = "VISIT",
				Location = ACTION_VISIT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Visit();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VISIT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Visit/Visit_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VISIT]/
		[HttpPost]
		public ActionResult Visit_Edit([FromBody]Visit_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit_Edit",
				ViewName = "Visit",
				AreaName = "visit",
				Location = ACTION_VISIT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VISIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VISIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VISIT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Visit_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VISIT]/
		[HttpPost]
		public ActionResult Visit_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit_Delete_GET",
				AreaName = "visit",
				FormName = "VISIT",
				Location = ACTION_VISIT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Visit();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VISIT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Visit/Visit_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VISIT]/
		[HttpPost]
		public ActionResult Visit_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Visit_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Visit_Delete",
				ViewName = "Visit",
				AreaName = "visit",
				Location = ACTION_VISIT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VISIT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Visit_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VISIT");
		}

		#endregion

		#region Visit_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VISIT]/

		[HttpPost]
		public ActionResult Visit_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Visit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Visit_Duplicate_GET",
				AreaName = "visit",
				FormName = "VISIT",
				Location = ACTION_VISIT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VISIT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Visit/Visit_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VISIT]/
		[HttpPost]
		public ActionResult Visit_Duplicate([FromBody]Visit_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit_Duplicate",
				ViewName = "Visit",
				AreaName = "visit",
				Location = ACTION_VISIT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VISIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VISIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VISIT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Visit_Cancel

		//
		// GET: /Visit/Visit_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VISIT]/
		public ActionResult Visit_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Visit(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("visit");

// USE /[MANUAL GQT BEFORE_CANCEL VISIT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VISIT]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_visit", "true", true);
			}

			Navigation.ClearValue("visit");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Visit_EquipValRegistnrModel : RequestLookupModel
		{
			public Visit_ViewModel Model { get; set; }
		}

		//
		// GET: /Visit/Visit_EquipValRegistnr
		// POST: /Visit/Visit_EquipValRegistnr
		[ActionName("Visit_EquipValRegistnr")]
		public ActionResult Visit_EquipValRegistnr([FromBody] Visit_EquipValRegistnrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
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

			Models.Visit parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Visit_EquipValRegistnr_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Visit/Visit_SaveEdit
		[HttpPost]
		public ActionResult Visit_SaveEdit([FromBody]Visit_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit_SaveEdit",
				ViewName = "Visit",
				AreaName = "visit",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VISIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VISIT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
