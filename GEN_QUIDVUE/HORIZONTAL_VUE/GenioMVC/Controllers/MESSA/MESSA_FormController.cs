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
using GenioMVC.ViewModels.Messa;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MESSA]/

namespace GenioMVC.Controllers
{
	public partial class MessaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MESSA_CANCEL = new("MESSAGE30602", "Messa_Cancel", "Messa") { vueRouteName = "form-MESSA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MESSA_SHOW = new("MESSAGE30602", "Messa_Show", "Messa") { vueRouteName = "form-MESSA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MESSA_NEW = new("MESSAGE30602", "Messa_New", "Messa") { vueRouteName = "form-MESSA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MESSA_EDIT = new("MESSAGE30602", "Messa_Edit", "Messa") { vueRouteName = "form-MESSA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MESSA_DUPLICATE = new("MESSAGE30602", "Messa_Duplicate", "Messa") { vueRouteName = "form-MESSA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MESSA_DELETE = new("MESSAGE30602", "Messa_Delete", "Messa") { vueRouteName = "form-MESSA", mode = "DELETE" };

		#endregion

		#region Messa private

		private void FormHistoryLimits_Messa()
		{

		}

		#endregion

		#region Messa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW MESSA]/

		[HttpPost]
		public ActionResult Messa_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Messa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Show_GET",
				AreaName = "messa",
				Location = ACTION_MESSA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Messa();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW MESSA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Messa_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET MESSA]/
		[HttpPost]
		public ActionResult Messa_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Messa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Messa_New_GET",
				AreaName = "messa",
				FormName = "MESSA",
				Location = ACTION_MESSA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Messa();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW MESSA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Messa/Messa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST MESSA]/
		[HttpPost]
		public ActionResult Messa_New([FromBody]Messa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_New",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW MESSA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX MESSA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX MESSA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Messa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET MESSA]/
		[HttpPost]
		public ActionResult Messa_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Messa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Edit_GET",
				AreaName = "messa",
				FormName = "MESSA",
				Location = ACTION_MESSA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Messa();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT MESSA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Messa/Messa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST MESSA]/
		[HttpPost]
		public ActionResult Messa_Edit([FromBody]Messa_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Edit",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT MESSA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX MESSA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX MESSA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Messa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET MESSA]/
		[HttpPost]
		public ActionResult Messa_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Messa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Delete_GET",
				AreaName = "messa",
				FormName = "MESSA",
				Location = ACTION_MESSA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Messa();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE MESSA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Messa/Messa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST MESSA]/
		[HttpPost]
		public ActionResult Messa_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Messa_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Messa_Delete",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE MESSA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Messa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MESSA");
		}

		#endregion

		#region Messa_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET MESSA]/

		[HttpPost]
		public ActionResult Messa_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Messa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Duplicate_GET",
				AreaName = "messa",
				FormName = "MESSA",
				Location = ACTION_MESSA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE MESSA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Messa/Messa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST MESSA]/
		[HttpPost]
		public ActionResult Messa_Duplicate([FromBody]Messa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Duplicate",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE MESSA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX MESSA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX MESSA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Messa_Cancel

		//
		// GET: /Messa/Messa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET MESSA]/
		public ActionResult Messa_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Messa(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("messa");

// USE /[MANUAL GQT BEFORE_CANCEL MESSA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL MESSA]/

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

				Navigation.SetValue("ForcePrimaryRead_messa", "true", true);
			}

			Navigation.ClearValue("messa");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Messa_EntitValNameModel : RequestLookupModel
		{
			public Messa_ViewModel Model { get; set; }
		}

		//
		// GET: /Messa/Messa_EntitValName
		// POST: /Messa/Messa_EntitValName
		[ActionName("Messa_EntitValName")]
		public ActionResult Messa_EntitValName([FromBody] Messa_EntitValNameModel requestModel)
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

			Models.Messa parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Messa_EntitValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Messa_PersoValNameModel : RequestLookupModel
		{
			public Messa_ViewModel Model { get; set; }
		}

		//
		// GET: /Messa/Messa_PersoValName
		// POST: /Messa/Messa_PersoValName
		[ActionName("Messa_PersoValName")]
		public ActionResult Messa_PersoValName([FromBody] Messa_PersoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
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

			Models.Messa parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Messa_PersoValName_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Messa/Messa_SaveEdit
		[HttpPost]
		public ActionResult Messa_SaveEdit([FromBody]Messa_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_SaveEdit",
				ViewName = "Messa",
				AreaName = "messa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT MESSA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
