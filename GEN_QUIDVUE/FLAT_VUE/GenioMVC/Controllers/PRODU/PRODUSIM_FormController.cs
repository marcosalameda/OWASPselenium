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
using GenioMVC.ViewModels.Produ;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PRODU]/

namespace GenioMVC.Controllers
{
	public partial class ProduController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PRODUSIM_CANCEL = new("PRODUCT12880", "Produsim_Cancel", "Produ") { vueRouteName = "form-PRODUSIM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PRODUSIM_SHOW = new("PRODUCT12880", "Produsim_Show", "Produ") { vueRouteName = "form-PRODUSIM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PRODUSIM_NEW = new("PRODUCT12880", "Produsim_New", "Produ") { vueRouteName = "form-PRODUSIM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PRODUSIM_EDIT = new("PRODUCT12880", "Produsim_Edit", "Produ") { vueRouteName = "form-PRODUSIM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PRODUSIM_DUPLICATE = new("PRODUCT12880", "Produsim_Duplicate", "Produ") { vueRouteName = "form-PRODUSIM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PRODUSIM_DELETE = new("PRODUCT12880", "Produsim_Delete", "Produ") { vueRouteName = "form-PRODUSIM", mode = "DELETE" };

		#endregion

		#region Produsim private

		private void FormHistoryLimits_Produsim()
		{

		}

		#endregion

		#region Produsim_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PRODUSIM]/

		[HttpPost]
		public ActionResult Produsim_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produsim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Show_GET",
				AreaName = "produ",
				Location = ACTION_PRODUSIM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produsim();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PRODUSIM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Produsim_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Produsim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_New_GET",
				AreaName = "produ",
				FormName = "PRODUSIM",
				Location = ACTION_PRODUSIM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Produsim();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PRODUSIM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Produ/Produsim_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_New([FromBody]Produsim_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_New",
				ViewName = "Produsim",
				AreaName = "produ",
				Location = ACTION_PRODUSIM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PRODUSIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PRODUSIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PRODUSIM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Produsim_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produsim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Edit_GET",
				AreaName = "produ",
				FormName = "PRODUSIM",
				Location = ACTION_PRODUSIM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produsim();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PRODUSIM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Produ/Produsim_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_Edit([FromBody]Produsim_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Edit",
				ViewName = "Produsim",
				AreaName = "produ",
				Location = ACTION_PRODUSIM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PRODUSIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PRODUSIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PRODUSIM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Produsim_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produsim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Delete_GET",
				AreaName = "produ",
				FormName = "PRODUSIM",
				Location = ACTION_PRODUSIM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produsim();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PRODUSIM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Produ/Produsim_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Produsim_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Delete",
				ViewName = "Produsim",
				AreaName = "produ",
				Location = ACTION_PRODUSIM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PRODUSIM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Produsim_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PRODUSIM");
		}

		#endregion

		#region Produsim_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PRODUSIM]/

		[HttpPost]
		public ActionResult Produsim_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Produsim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Duplicate_GET",
				AreaName = "produ",
				FormName = "PRODUSIM",
				Location = ACTION_PRODUSIM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PRODUSIM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Produ/Produsim_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PRODUSIM]/
		[HttpPost]
		public ActionResult Produsim_Duplicate([FromBody]Produsim_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_Duplicate",
				ViewName = "Produsim",
				AreaName = "produ",
				Location = ACTION_PRODUSIM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PRODUSIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PRODUSIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PRODUSIM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Produsim_Cancel

		//
		// GET: /Produ/Produsim_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PRODUSIM]/
		public ActionResult Produsim_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Produ(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("produ");

// USE /[MANUAL GQT BEFORE_CANCEL PRODUSIM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PRODUSIM]/

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

				Navigation.SetValue("ForcePrimaryRead_produ", "true", true);
			}

			Navigation.ClearValue("produ");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Produ/Produsim_LocatValGln
		// POST: /Produ/Produsim_LocatValGln
		[ActionName("Produsim_LocatValGln")]
		public ActionResult Produsim_LocatValGln([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_locat")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_locat");
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
			Produsim_LocatValGln_ViewModel model = new Produsim_LocatValGln_ViewModel(UserContext.Current);
			
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
		// GET: /Produ/Produsim_LcextValGlnext
		// POST: /Produ/Produsim_LcextValGlnext
		[ActionName("Produsim_LcextValGlnext")]
		public ActionResult Produsim_LcextValGlnext([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lcext")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lcext");
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
			Produsim_LcextValGlnext_ViewModel model = new Produsim_LcextValGlnext_ViewModel(UserContext.Current);
			
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


		// POST: /Produ/Produsim_SaveEdit
		[HttpPost]
		public ActionResult Produsim_SaveEdit([FromBody]Produsim_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Produsim_SaveEdit",
				ViewName = "Produsim",
				AreaName = "produ",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PRODUSIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PRODUSIM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
