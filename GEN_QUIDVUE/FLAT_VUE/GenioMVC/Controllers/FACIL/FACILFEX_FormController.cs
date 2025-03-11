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
using GenioMVC.ViewModels.Facil;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FACIL]/

namespace GenioMVC.Controllers
{
	public partial class FacilController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FACILFEX_CANCEL = new("FACILITY55206", "Facilfex_Cancel", "Facil") { vueRouteName = "form-FACILFEX", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FACILFEX_SHOW = new("FACILITY55206", "Facilfex_Show", "Facil") { vueRouteName = "form-FACILFEX", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FACILFEX_NEW = new("FACILITY55206", "Facilfex_New", "Facil") { vueRouteName = "form-FACILFEX", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FACILFEX_EDIT = new("FACILITY55206", "Facilfex_Edit", "Facil") { vueRouteName = "form-FACILFEX", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FACILFEX_DUPLICATE = new("FACILITY55206", "Facilfex_Duplicate", "Facil") { vueRouteName = "form-FACILFEX", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FACILFEX_DELETE = new("FACILITY55206", "Facilfex_Delete", "Facil") { vueRouteName = "form-FACILFEX", mode = "DELETE" };

		#endregion

		#region Facilfex private

		private void FormHistoryLimits_Facilfex()
		{

		}

		#endregion

		#region Facilfex_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FACILFEX]/

		[HttpPost]
		public ActionResult Facilfex_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facilfex_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Show_GET",
				AreaName = "facil",
				Location = ACTION_FACILFEX_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facilfex();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FACILFEX]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Facilfex_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Facilfex_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_New_GET",
				AreaName = "facil",
				FormName = "FACILFEX",
				Location = ACTION_FACILFEX_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Facilfex();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FACILFEX]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Facil/Facilfex_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_New([FromBody]Facilfex_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_New",
				ViewName = "Facilfex",
				AreaName = "facil",
				Location = ACTION_FACILFEX_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FACILFEX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FACILFEX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FACILFEX]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Facilfex_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facilfex_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Edit_GET",
				AreaName = "facil",
				FormName = "FACILFEX",
				Location = ACTION_FACILFEX_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facilfex();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FACILFEX]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Facil/Facilfex_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_Edit([FromBody]Facilfex_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Edit",
				ViewName = "Facilfex",
				AreaName = "facil",
				Location = ACTION_FACILFEX_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FACILFEX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FACILFEX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FACILFEX]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Facilfex_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facilfex_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Delete_GET",
				AreaName = "facil",
				FormName = "FACILFEX",
				Location = ACTION_FACILFEX_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facilfex();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FACILFEX]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Facil/Facilfex_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facilfex_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Delete",
				ViewName = "Facilfex",
				AreaName = "facil",
				Location = ACTION_FACILFEX_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FACILFEX]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Facilfex_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FACILFEX");
		}

		#endregion

		#region Facilfex_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FACILFEX]/

		[HttpPost]
		public ActionResult Facilfex_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Facilfex_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Duplicate_GET",
				AreaName = "facil",
				FormName = "FACILFEX",
				Location = ACTION_FACILFEX_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FACILFEX]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Facil/Facilfex_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FACILFEX]/
		[HttpPost]
		public ActionResult Facilfex_Duplicate([FromBody]Facilfex_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_Duplicate",
				ViewName = "Facilfex",
				AreaName = "facil",
				Location = ACTION_FACILFEX_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FACILFEX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FACILFEX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FACILFEX]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Facilfex_Cancel

		//
		// GET: /Facil/Facilfex_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FACILFEX]/
		public ActionResult Facilfex_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Facil(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("facil");

// USE /[MANUAL GQT BEFORE_CANCEL FACILFEX]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FACILFEX]/

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

				Navigation.SetValue("ForcePrimaryRead_facil", "true", true);
			}

			Navigation.ClearValue("facil");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Facilfex_EntitValNameModel : RequestLookupModel
		{
			public Facilfex_ViewModel Model { get; set; }
		}

		//
		// GET: /Facil/Facilfex_EntitValName
		// POST: /Facil/Facilfex_EntitValName
		[ActionName("Facilfex_EntitValName")]
		public ActionResult Facilfex_EntitValName([FromBody] Facilfex_EntitValNameModel requestModel)
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

			Models.Facil parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Facilfex_EntitValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Facilfex_FactyValTypeModel : RequestLookupModel
		{
			public Facilfex_ViewModel Model { get; set; }
		}

		//
		// GET: /Facil/Facilfex_FactyValType
		// POST: /Facil/Facilfex_FactyValType
		[ActionName("Facilfex_FactyValType")]
		public ActionResult Facilfex_FactyValType([FromBody] Facilfex_FactyValTypeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_facty")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_facty");
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

			Models.Facil parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Facilfex_FactyValType_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Facil/Facilfex_SaveEdit
		[HttpPost]
		public ActionResult Facilfex_SaveEdit([FromBody]Facilfex_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facilfex_SaveEdit",
				ViewName = "Facilfex",
				AreaName = "facil",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FACILFEX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FACILFEX]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
