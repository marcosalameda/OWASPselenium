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
using GenioMVC.ViewModels.Dilin;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DILIN]/

namespace GenioMVC.Controllers
{
	public partial class DilinController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DILIN_CANCEL = new("DISPATCH_LINE65326", "Dilin_Cancel", "Dilin") { vueRouteName = "form-DILIN", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DILIN_SHOW = new("DISPATCH_LINE65326", "Dilin_Show", "Dilin") { vueRouteName = "form-DILIN", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DILIN_NEW = new("DISPATCH_LINE65326", "Dilin_New", "Dilin") { vueRouteName = "form-DILIN", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DILIN_EDIT = new("DISPATCH_LINE65326", "Dilin_Edit", "Dilin") { vueRouteName = "form-DILIN", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DILIN_DUPLICATE = new("DISPATCH_LINE65326", "Dilin_Duplicate", "Dilin") { vueRouteName = "form-DILIN", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DILIN_DELETE = new("DISPATCH_LINE65326", "Dilin_Delete", "Dilin") { vueRouteName = "form-DILIN", mode = "DELETE" };

		#endregion

		#region Dilin private

		private void FormHistoryLimits_Dilin()
		{

		}

		#endregion

		#region Dilin_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DILIN]/

		[HttpPost]
		public ActionResult Dilin_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dilin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Show_GET",
				AreaName = "dilin",
				Location = ACTION_DILIN_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dilin();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DILIN]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dilin_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DILIN]/
		[HttpPost]
		public ActionResult Dilin_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Dilin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_New_GET",
				AreaName = "dilin",
				FormName = "DILIN",
				Location = ACTION_DILIN_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dilin();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DILIN]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Dilin/Dilin_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DILIN]/
		[HttpPost]
		public ActionResult Dilin_New([FromBody]Dilin_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_New",
				ViewName = "Dilin",
				AreaName = "dilin",
				Location = ACTION_DILIN_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DILIN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DILIN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DILIN]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dilin_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DILIN]/
		[HttpPost]
		public ActionResult Dilin_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dilin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Edit_GET",
				AreaName = "dilin",
				FormName = "DILIN",
				Location = ACTION_DILIN_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dilin();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DILIN]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Dilin/Dilin_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DILIN]/
		[HttpPost]
		public ActionResult Dilin_Edit([FromBody]Dilin_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Edit",
				ViewName = "Dilin",
				AreaName = "dilin",
				Location = ACTION_DILIN_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DILIN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DILIN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DILIN]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dilin_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DILIN]/
		[HttpPost]
		public ActionResult Dilin_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dilin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Delete_GET",
				AreaName = "dilin",
				FormName = "DILIN",
				Location = ACTION_DILIN_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dilin();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DILIN]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Dilin/Dilin_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DILIN]/
		[HttpPost]
		public ActionResult Dilin_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dilin_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Delete",
				ViewName = "Dilin",
				AreaName = "dilin",
				Location = ACTION_DILIN_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DILIN]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dilin_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DILIN");
		}

		#endregion

		#region Dilin_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DILIN]/

		[HttpPost]
		public ActionResult Dilin_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Dilin_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Duplicate_GET",
				AreaName = "dilin",
				FormName = "DILIN",
				Location = ACTION_DILIN_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DILIN]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Dilin/Dilin_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DILIN]/
		[HttpPost]
		public ActionResult Dilin_Duplicate([FromBody]Dilin_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_Duplicate",
				ViewName = "Dilin",
				AreaName = "dilin",
				Location = ACTION_DILIN_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DILIN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DILIN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DILIN]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dilin_Cancel

		//
		// GET: /Dilin/Dilin_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DILIN]/
		public ActionResult Dilin_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Dilin(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("dilin");

// USE /[MANUAL GQT BEFORE_CANCEL DILIN]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DILIN]/

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

				Navigation.SetValue("ForcePrimaryRead_dilin", "true", true);
			}

			Navigation.ClearValue("dilin");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Dilin/Dilin_DispaValDispanr
		// POST: /Dilin/Dilin_DispaValDispanr
		[ActionName("Dilin_DispaValDispanr")]
		public ActionResult Dilin_DispaValDispanr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dispa");
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
			Dilin_DispaValDispanr_ViewModel model = new Dilin_DispaValDispanr_ViewModel(UserContext.Current);
			
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
		// GET: /Dilin/Dilin_ProduValProduct
		// POST: /Dilin/Dilin_ProduValProduct
		[ActionName("Dilin_ProduValProduct")]
		public ActionResult Dilin_ProduValProduct([FromBody]RequestLookupModel requestModel)
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
			Dilin_ProduValProduct_ViewModel model = new Dilin_ProduValProduct_ViewModel(UserContext.Current);
			
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


		// POST: /Dilin/Dilin_SaveEdit
		[HttpPost]
		public ActionResult Dilin_SaveEdit([FromBody]Dilin_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dilin_SaveEdit",
				ViewName = "Dilin",
				AreaName = "dilin",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DILIN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DILIN]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
