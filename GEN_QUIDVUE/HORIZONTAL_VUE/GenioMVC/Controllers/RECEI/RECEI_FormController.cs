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
using GenioMVC.ViewModels.Recei;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RECEI]/

namespace GenioMVC.Controllers
{
	public partial class ReceiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_RECEI_CANCEL = new("RECEIPT_OF_GOOD16561", "Recei_Cancel", "Recei") { vueRouteName = "form-RECEI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_RECEI_SHOW = new("RECEIPT_OF_GOOD16561", "Recei_Show", "Recei") { vueRouteName = "form-RECEI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_RECEI_NEW = new("RECEIPT_OF_GOOD16561", "Recei_New", "Recei") { vueRouteName = "form-RECEI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_RECEI_EDIT = new("RECEIPT_OF_GOOD16561", "Recei_Edit", "Recei") { vueRouteName = "form-RECEI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_RECEI_DUPLICATE = new("RECEIPT_OF_GOOD16561", "Recei_Duplicate", "Recei") { vueRouteName = "form-RECEI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_RECEI_DELETE = new("RECEIPT_OF_GOOD16561", "Recei_Delete", "Recei") { vueRouteName = "form-RECEI", mode = "DELETE" };

		#endregion

		#region Recei private

		private void FormHistoryLimits_Recei()
		{

		}

		#endregion

		#region Recei_Show

// USE /[MANUAL GQT CONTROLLER_SHOW RECEI]/

		[HttpPost]
		public ActionResult Recei_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recei_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recei_Show_GET",
				AreaName = "recei",
				Location = ACTION_RECEI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Recei();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW RECEI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Recei_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET RECEI]/
		[HttpPost]
		public ActionResult Recei_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Recei_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recei_New_GET",
				AreaName = "recei",
				FormName = "RECEI",
				Location = ACTION_RECEI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Recei();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW RECEI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Recei/Recei_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST RECEI]/
		[HttpPost]
		public ActionResult Recei_New([FromBody]Recei_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recei_New",
				ViewName = "Recei",
				AreaName = "recei",
				Location = ACTION_RECEI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW RECEI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX RECEI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX RECEI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Recei_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET RECEI]/
		[HttpPost]
		public ActionResult Recei_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recei_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recei_Edit_GET",
				AreaName = "recei",
				FormName = "RECEI",
				Location = ACTION_RECEI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Recei();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT RECEI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Recei/Recei_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST RECEI]/
		[HttpPost]
		public ActionResult Recei_Edit([FromBody]Recei_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recei_Edit",
				ViewName = "Recei",
				AreaName = "recei",
				Location = ACTION_RECEI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT RECEI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX RECEI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX RECEI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Recei_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET RECEI]/
		[HttpPost]
		public ActionResult Recei_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recei_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recei_Delete_GET",
				AreaName = "recei",
				FormName = "RECEI",
				Location = ACTION_RECEI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Recei();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE RECEI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Recei/Recei_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST RECEI]/
		[HttpPost]
		public ActionResult Recei_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recei_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Recei_Delete",
				ViewName = "Recei",
				AreaName = "recei",
				Location = ACTION_RECEI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE RECEI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Recei_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("RECEI");
		}

		#endregion

		#region Recei_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET RECEI]/

		[HttpPost]
		public ActionResult Recei_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Recei_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recei_Duplicate_GET",
				AreaName = "recei",
				FormName = "RECEI",
				Location = ACTION_RECEI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE RECEI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Recei/Recei_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST RECEI]/
		[HttpPost]
		public ActionResult Recei_Duplicate([FromBody]Recei_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recei_Duplicate",
				ViewName = "Recei",
				AreaName = "recei",
				Location = ACTION_RECEI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE RECEI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX RECEI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX RECEI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Recei_Cancel

		//
		// GET: /Recei/Recei_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET RECEI]/
		public ActionResult Recei_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Recei(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("recei");

// USE /[MANUAL GQT BEFORE_CANCEL RECEI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL RECEI]/

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

				Navigation.SetValue("ForcePrimaryRead_recei", "true", true);
			}

			Navigation.ClearValue("recei");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Recei/Recei_EntitValName
		// POST: /Recei/Recei_EntitValName
		[ActionName("Recei_EntitValName")]
		public ActionResult Recei_EntitValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entit")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entit");
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
			Recei_EntitValName_ViewModel model = new Recei_EntitValName_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Recei/Recei_ValReceiptl
		// POST: /Recei/Recei_ValReceiptl
		[ActionName("Recei_ValReceiptl")]
		public ActionResult Recei_ValReceiptl([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_relin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_relin");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Recei_ValReceiptl_ViewModel model = new Recei_ValReceiptl_ViewModel(UserContext.Current);
			
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


		// POST: /Recei/Recei_SaveEdit
		[HttpPost]
		public ActionResult Recei_SaveEdit([FromBody]Recei_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recei_SaveEdit",
				ViewName = "Recei",
				AreaName = "recei",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT RECEI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT RECEI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
