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
using GenioMVC.ViewModels.Anexd;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ANEXD]/

namespace GenioMVC.Controllers
{
	public partial class AnexdController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ANEXD_CANCEL = new("ANEXO_DIGITAL09547", "Anexd_Cancel", "Anexd") { vueRouteName = "form-ANEXD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ANEXD_SHOW = new("ANEXO_DIGITAL09547", "Anexd_Show", "Anexd") { vueRouteName = "form-ANEXD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ANEXD_NEW = new("ANEXO_DIGITAL09547", "Anexd_New", "Anexd") { vueRouteName = "form-ANEXD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ANEXD_EDIT = new("ANEXO_DIGITAL09547", "Anexd_Edit", "Anexd") { vueRouteName = "form-ANEXD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ANEXD_DUPLICATE = new("ANEXO_DIGITAL09547", "Anexd_Duplicate", "Anexd") { vueRouteName = "form-ANEXD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ANEXD_DELETE = new("ANEXO_DIGITAL09547", "Anexd_Delete", "Anexd") { vueRouteName = "form-ANEXD", mode = "DELETE" };

		#endregion

		#region Anexd private

		private void FormHistoryLimits_Anexd()
		{

		}

		#endregion

		#region Anexd_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ANEXD]/

		[HttpPost]
		public ActionResult Anexd_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Anexd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Show_GET",
				AreaName = "anexd",
				Location = ACTION_ANEXD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Anexd();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ANEXD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Anexd_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ANEXD]/
		[HttpPost]
		public ActionResult Anexd_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Anexd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_New_GET",
				AreaName = "anexd",
				FormName = "ANEXD",
				Location = ACTION_ANEXD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Anexd();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ANEXD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Anexd/Anexd_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ANEXD]/
		[HttpPost]
		public ActionResult Anexd_New([FromBody]Anexd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_New",
				ViewName = "Anexd",
				AreaName = "anexd",
				Location = ACTION_ANEXD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ANEXD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ANEXD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ANEXD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Anexd_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ANEXD]/
		[HttpPost]
		public ActionResult Anexd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Anexd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Edit_GET",
				AreaName = "anexd",
				FormName = "ANEXD",
				Location = ACTION_ANEXD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Anexd();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ANEXD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Anexd/Anexd_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ANEXD]/
		[HttpPost]
		public ActionResult Anexd_Edit([FromBody]Anexd_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Edit",
				ViewName = "Anexd",
				AreaName = "anexd",
				Location = ACTION_ANEXD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ANEXD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ANEXD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ANEXD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Anexd_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ANEXD]/
		[HttpPost]
		public ActionResult Anexd_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Anexd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Delete_GET",
				AreaName = "anexd",
				FormName = "ANEXD",
				Location = ACTION_ANEXD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Anexd();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ANEXD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Anexd/Anexd_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ANEXD]/
		[HttpPost]
		public ActionResult Anexd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Anexd_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Delete",
				ViewName = "Anexd",
				AreaName = "anexd",
				Location = ACTION_ANEXD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ANEXD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Anexd_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ANEXD");
		}

		#endregion

		#region Anexd_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ANEXD]/

		[HttpPost]
		public ActionResult Anexd_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Anexd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Duplicate_GET",
				AreaName = "anexd",
				FormName = "ANEXD",
				Location = ACTION_ANEXD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ANEXD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Anexd/Anexd_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ANEXD]/
		[HttpPost]
		public ActionResult Anexd_Duplicate([FromBody]Anexd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_Duplicate",
				ViewName = "Anexd",
				AreaName = "anexd",
				Location = ACTION_ANEXD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ANEXD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ANEXD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ANEXD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Anexd_Cancel

		//
		// GET: /Anexd/Anexd_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ANEXD]/
		public ActionResult Anexd_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Anexd(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("anexd");

// USE /[MANUAL GQT BEFORE_CANCEL ANEXD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ANEXD]/

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

				Navigation.SetValue("ForcePrimaryRead_anexd", "true", true);
			}

			Navigation.ClearValue("anexd");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Anexd/Anexd_EquipValRegistnr
		// POST: /Anexd/Anexd_EquipValRegistnr
		[ActionName("Anexd_EquipValRegistnr")]
		public ActionResult Anexd_EquipValRegistnr([FromBody]RequestLookupModel requestModel)
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
			Anexd_EquipValRegistnr_ViewModel model = new Anexd_EquipValRegistnr_ViewModel(UserContext.Current);
			
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
		// GET: /Anexd/Anexd_LanguValLangua
		// POST: /Anexd/Anexd_LanguValLangua
		[ActionName("Anexd_LanguValLangua")]
		public ActionResult Anexd_LanguValLangua([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_langu")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_langu");
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
			Anexd_LanguValLangua_ViewModel model = new Anexd_LanguValLangua_ViewModel(UserContext.Current);
			
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


		// POST: /Anexd/Anexd_SaveEdit
		[HttpPost]
		public ActionResult Anexd_SaveEdit([FromBody]Anexd_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Anexd_SaveEdit",
				ViewName = "Anexd",
				AreaName = "anexd",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ANEXD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ANEXD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
