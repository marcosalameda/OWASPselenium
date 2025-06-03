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

		private static readonly NavigationLocation ACTION_FACIL_CANCEL = new("FACILITY55206", "Facil_Cancel", "Facil") { vueRouteName = "form-FACIL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FACIL_SHOW = new("FACILITY55206", "Facil_Show", "Facil") { vueRouteName = "form-FACIL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FACIL_NEW = new("FACILITY55206", "Facil_New", "Facil") { vueRouteName = "form-FACIL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FACIL_EDIT = new("FACILITY55206", "Facil_Edit", "Facil") { vueRouteName = "form-FACIL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FACIL_DUPLICATE = new("FACILITY55206", "Facil_Duplicate", "Facil") { vueRouteName = "form-FACIL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FACIL_DELETE = new("FACILITY55206", "Facil_Delete", "Facil") { vueRouteName = "form-FACIL", mode = "DELETE" };

		#endregion

		#region Facil private

		private void FormHistoryLimits_Facil()
		{

		}

		#endregion

		#region Facil_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FACIL]/

		[HttpPost]
		public ActionResult Facil_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Show_GET",
				AreaName = "facil",
				Location = ACTION_FACIL_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FACIL]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Facil_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FACIL]/
		[HttpPost]
		public ActionResult Facil_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_New_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FACIL]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Facil/Facil_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_New([FromBody]Facil_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_New",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FACIL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FACIL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FACIL]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Facil_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FACIL]/
		[HttpPost]
		public ActionResult Facil_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Edit_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FACIL]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Facil/Facil_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_Edit([FromBody]Facil_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Edit",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FACIL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FACIL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FACIL]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Facil_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FACIL]/
		[HttpPost]
		public ActionResult Facil_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Delete_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facil();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FACIL]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Facil/Facil_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facil_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Facil_Delete",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FACIL]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Facil_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FACIL");
		}

		#endregion

		#region Facil_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FACIL]/

		[HttpPost]
		public ActionResult Facil_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Facil_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Duplicate_GET",
				AreaName = "facil",
				FormName = "FACIL",
				Location = ACTION_FACIL_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FACIL]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Facil/Facil_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FACIL]/
		[HttpPost]
		public ActionResult Facil_Duplicate([FromBody]Facil_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_Duplicate",
				ViewName = "Facil",
				AreaName = "facil",
				Location = ACTION_FACIL_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FACIL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FACIL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FACIL]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Facil_Cancel

		//
		// GET: /Facil/Facil_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FACIL]/
		public ActionResult Facil_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Facil(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("facil");

// USE /[MANUAL GQT BEFORE_CANCEL FACIL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FACIL]/

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

				Navigation.SetValue("ForcePrimaryRead_facil", "true", true);
			}

			Navigation.ClearValue("facil");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Facil_EntitValNameModel : RequestLookupModel
		{
			public Facil_ViewModel Model { get; set; }
		}

		//
		// GET: /Facil/Facil_EntitValName
		// POST: /Facil/Facil_EntitValName
		[ActionName("Facil_EntitValName")]
		public ActionResult Facil_EntitValName([FromBody] Facil_EntitValNameModel requestModel)
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
			Facil_EntitValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Facil_FactyValTypeModel : RequestLookupModel
		{
			public Facil_ViewModel Model { get; set; }
		}

		//
		// GET: /Facil/Facil_FactyValType
		// POST: /Facil/Facil_FactyValType
		[ActionName("Facil_FactyValType")]
		public ActionResult Facil_FactyValType([FromBody] Facil_FactyValTypeModel requestModel)
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
			Facil_FactyValType_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Facil/Facil_SaveEdit
		[HttpPost]
		public ActionResult Facil_SaveEdit([FromBody]Facil_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facil_SaveEdit",
				ViewName = "Facil",
				AreaName = "facil",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FACIL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FACIL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
