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
using GenioMVC.ViewModels.Relin;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RELIN]/

namespace GenioMVC.Controllers
{
	public partial class RelinController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_RELIN_CANCEL = new("RECEIPT_LINE60287", "Relin_Cancel", "Relin") { vueRouteName = "form-RELIN", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_RELIN_SHOW = new("RECEIPT_LINE60287", "Relin_Show", "Relin") { vueRouteName = "form-RELIN", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_RELIN_NEW = new("RECEIPT_LINE60287", "Relin_New", "Relin") { vueRouteName = "form-RELIN", mode = "NEW" };
		private static readonly NavigationLocation ACTION_RELIN_EDIT = new("RECEIPT_LINE60287", "Relin_Edit", "Relin") { vueRouteName = "form-RELIN", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_RELIN_DUPLICATE = new("RECEIPT_LINE60287", "Relin_Duplicate", "Relin") { vueRouteName = "form-RELIN", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_RELIN_DELETE = new("RECEIPT_LINE60287", "Relin_Delete", "Relin") { vueRouteName = "form-RELIN", mode = "DELETE" };

		#endregion

		#region Relin private

		private void FormHistoryLimits_Relin()
		{

		}

		#endregion

		#region Relin_Show

// USE /[MANUAL GQT CONTROLLER_SHOW RELIN]/

		[HttpPost]
		public ActionResult Relin_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Relin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Relin_Show_GET",
				AreaName = "relin",
				Location = ACTION_RELIN_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Relin();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW RELIN]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Relin_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET RELIN]/
		[HttpPost]
		public ActionResult Relin_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Relin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Relin_New_GET",
				AreaName = "relin",
				FormName = "RELIN",
				Location = ACTION_RELIN_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Relin();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW RELIN]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Relin/Relin_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST RELIN]/
		[HttpPost]
		public ActionResult Relin_New([FromBody]Relin_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Relin_New",
				ViewName = "Relin",
				AreaName = "relin",
				Location = ACTION_RELIN_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW RELIN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX RELIN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX RELIN]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Relin_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET RELIN]/
		[HttpPost]
		public ActionResult Relin_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Relin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Relin_Edit_GET",
				AreaName = "relin",
				FormName = "RELIN",
				Location = ACTION_RELIN_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Relin();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT RELIN]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Relin/Relin_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST RELIN]/
		[HttpPost]
		public ActionResult Relin_Edit([FromBody]Relin_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Relin_Edit",
				ViewName = "Relin",
				AreaName = "relin",
				Location = ACTION_RELIN_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT RELIN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX RELIN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX RELIN]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Relin_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET RELIN]/
		[HttpPost]
		public ActionResult Relin_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Relin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Relin_Delete_GET",
				AreaName = "relin",
				FormName = "RELIN",
				Location = ACTION_RELIN_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Relin();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE RELIN]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Relin/Relin_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST RELIN]/
		[HttpPost]
		public ActionResult Relin_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Relin_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Relin_Delete",
				ViewName = "Relin",
				AreaName = "relin",
				Location = ACTION_RELIN_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE RELIN]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Relin_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("RELIN");
		}

		#endregion

		#region Relin_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET RELIN]/

		[HttpPost]
		public ActionResult Relin_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Relin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Relin_Duplicate_GET",
				AreaName = "relin",
				FormName = "RELIN",
				Location = ACTION_RELIN_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE RELIN]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Relin/Relin_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST RELIN]/
		[HttpPost]
		public ActionResult Relin_Duplicate([FromBody]Relin_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Relin_Duplicate",
				ViewName = "Relin",
				AreaName = "relin",
				Location = ACTION_RELIN_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE RELIN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX RELIN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX RELIN]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Relin_Cancel

		//
		// GET: /Relin/Relin_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET RELIN]/
		public ActionResult Relin_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Relin(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("relin");

// USE /[MANUAL GQT BEFORE_CANCEL RELIN]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL RELIN]/

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

				Navigation.SetValue("ForcePrimaryRead_relin", "true", true);
			}

			Navigation.ClearValue("relin");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Relin_ReceiValNumberModel : RequestLookupModel
		{
			public Relin_ViewModel Model { get; set; }
		}

		//
		// GET: /Relin/Relin_ReceiValNumber
		// POST: /Relin/Relin_ReceiValNumber
		[ActionName("Relin_ReceiValNumber")]
		public ActionResult Relin_ReceiValNumber([FromBody] Relin_ReceiValNumberModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_recei")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_recei");
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

			Models.Relin parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Relin_ReceiValNumber_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Relin_ProduValProductModel : RequestLookupModel
		{
			public Relin_ViewModel Model { get; set; }
		}

		//
		// GET: /Relin/Relin_ProduValProduct
		// POST: /Relin/Relin_ProduValProduct
		[ActionName("Relin_ProduValProduct")]
		public ActionResult Relin_ProduValProduct([FromBody] Relin_ProduValProductModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_produ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_produ");
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

			Models.Relin parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Relin_ProduValProduct_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Relin/Relin_SaveEdit
		[HttpPost]
		public ActionResult Relin_SaveEdit([FromBody]Relin_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Relin_SaveEdit",
				ViewName = "Relin",
				AreaName = "relin",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT RELIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT RELIN]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
