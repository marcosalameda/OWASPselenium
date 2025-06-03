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
using GenioMVC.ViewModels.Pess1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESS1]/

namespace GenioMVC.Controllers
{
	public partial class Pess1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PESS1_CANCEL = new("COMODANTE63029", "Pess1_Cancel", "Pess1") { vueRouteName = "form-PESS1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESS1_SHOW = new("COMODANTE63029", "Pess1_Show", "Pess1") { vueRouteName = "form-PESS1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESS1_NEW = new("COMODANTE63029", "Pess1_New", "Pess1") { vueRouteName = "form-PESS1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESS1_EDIT = new("COMODANTE63029", "Pess1_Edit", "Pess1") { vueRouteName = "form-PESS1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESS1_DUPLICATE = new("COMODANTE63029", "Pess1_Duplicate", "Pess1") { vueRouteName = "form-PESS1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESS1_DELETE = new("COMODANTE63029", "Pess1_Delete", "Pess1") { vueRouteName = "form-PESS1", mode = "DELETE" };

		#endregion

		#region Pess1 private

		private void FormHistoryLimits_Pess1()
		{

		}

		#endregion

		#region Pess1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESS1]/

		[HttpPost]
		public ActionResult Pess1_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Show_GET",
				AreaName = "pess1",
				Location = ACTION_PESS1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESS1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pess1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESS1]/
		[HttpPost]
		public ActionResult Pess1_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_New_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESS1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pess1/Pess1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_New([FromBody]Pess1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_New",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESS1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESS1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESS1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pess1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESS1]/
		[HttpPost]
		public ActionResult Pess1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Edit_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESS1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pess1/Pess1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_Edit([FromBody]Pess1_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Edit",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESS1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESS1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESS1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pess1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESS1]/
		[HttpPost]
		public ActionResult Pess1_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Delete_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pess1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESS1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pess1/Pess1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pess1_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Delete",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESS1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pess1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESS1");
		}

		#endregion

		#region Pess1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESS1]/

		[HttpPost]
		public ActionResult Pess1_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pess1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Duplicate_GET",
				AreaName = "pess1",
				FormName = "PESS1",
				Location = ACTION_PESS1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESS1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pess1/Pess1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESS1]/
		[HttpPost]
		public ActionResult Pess1_Duplicate([FromBody]Pess1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_Duplicate",
				ViewName = "Pess1",
				AreaName = "pess1",
				Location = ACTION_PESS1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESS1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESS1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESS1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pess1_Cancel

		//
		// GET: /Pess1/Pess1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESS1]/
		public ActionResult Pess1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pess1(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pess1");

// USE /[MANUAL GQT BEFORE_CANCEL PESS1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESS1]/

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

				Navigation.SetValue("ForcePrimaryRead_pess1", "true", true);
			}

			Navigation.ClearValue("pess1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pess1_CmpnyValDesignatModel : RequestLookupModel
		{
			public Pess1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pess1/Pess1_CmpnyValDesignat
		// POST: /Pess1/Pess1_CmpnyValDesignat
		[ActionName("Pess1_CmpnyValDesignat")]
		public ActionResult Pess1_CmpnyValDesignat([FromBody] Pess1_CmpnyValDesignatModel requestModel)
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

			Models.Pess1 parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pess1_CmpnyValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pess1_StakeValDesignatModel : RequestLookupModel
		{
			public Pess1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pess1/Pess1_StakeValDesignat
		// POST: /Pess1/Pess1_StakeValDesignat
		[ActionName("Pess1_StakeValDesignat")]
		public ActionResult Pess1_StakeValDesignat([FromBody] Pess1_StakeValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_stake")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_stake");
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

			Models.Pess1 parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pess1_StakeValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Pess1/Pess1_SaveEdit
		[HttpPost]
		public ActionResult Pess1_SaveEdit([FromBody]Pess1_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pess1_SaveEdit",
				ViewName = "Pess1",
				AreaName = "pess1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESS1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESS1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
