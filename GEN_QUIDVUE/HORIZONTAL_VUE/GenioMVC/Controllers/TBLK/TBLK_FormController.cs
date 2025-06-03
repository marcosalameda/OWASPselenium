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
using GenioMVC.ViewModels.Tblk;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLK]/

namespace GenioMVC.Controllers
{
	public partial class TblkController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TBLK_CANCEL = new("TABLE__FOREIGN_KEYS_21641", "Tblk_Cancel", "Tblk") { vueRouteName = "form-TBLK", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TBLK_SHOW = new("TABLE__FOREIGN_KEYS_21641", "Tblk_Show", "Tblk") { vueRouteName = "form-TBLK", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TBLK_NEW = new("TABLE__FOREIGN_KEYS_21641", "Tblk_New", "Tblk") { vueRouteName = "form-TBLK", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TBLK_EDIT = new("TABLE__FOREIGN_KEYS_21641", "Tblk_Edit", "Tblk") { vueRouteName = "form-TBLK", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TBLK_DUPLICATE = new("TABLE__FOREIGN_KEYS_21641", "Tblk_Duplicate", "Tblk") { vueRouteName = "form-TBLK", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TBLK_DELETE = new("TABLE__FOREIGN_KEYS_21641", "Tblk_Delete", "Tblk") { vueRouteName = "form-TBLK", mode = "DELETE" };

		#endregion

		#region Tblk private

		private void FormHistoryLimits_Tblk()
		{

		}

		#endregion

		#region Tblk_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TBLK]/

		[HttpPost]
		public ActionResult Tblk_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblk_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Show_GET",
				AreaName = "tblk",
				Location = ACTION_TBLK_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tblk();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TBLK]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tblk_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TBLK]/
		[HttpPost]
		public ActionResult Tblk_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tblk_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_New_GET",
				AreaName = "tblk",
				FormName = "TBLK",
				Location = ACTION_TBLK_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tblk();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TBLK]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tblk/Tblk_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TBLK]/
		[HttpPost]
		public ActionResult Tblk_New([FromBody]Tblk_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_New",
				ViewName = "Tblk",
				AreaName = "tblk",
				Location = ACTION_TBLK_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TBLK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TBLK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TBLK]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tblk_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TBLK]/
		[HttpPost]
		public ActionResult Tblk_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblk_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Edit_GET",
				AreaName = "tblk",
				FormName = "TBLK",
				Location = ACTION_TBLK_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tblk();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TBLK]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tblk/Tblk_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TBLK]/
		[HttpPost]
		public ActionResult Tblk_Edit([FromBody]Tblk_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Edit",
				ViewName = "Tblk",
				AreaName = "tblk",
				Location = ACTION_TBLK_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TBLK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TBLK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TBLK]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tblk_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TBLK]/
		[HttpPost]
		public ActionResult Tblk_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblk_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Delete_GET",
				AreaName = "tblk",
				FormName = "TBLK",
				Location = ACTION_TBLK_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tblk();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TBLK]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tblk/Tblk_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TBLK]/
		[HttpPost]
		public ActionResult Tblk_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblk_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Delete",
				ViewName = "Tblk",
				AreaName = "tblk",
				Location = ACTION_TBLK_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TBLK]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tblk_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TBLK");
		}

		#endregion

		#region Tblk_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TBLK]/

		[HttpPost]
		public ActionResult Tblk_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tblk_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Duplicate_GET",
				AreaName = "tblk",
				FormName = "TBLK",
				Location = ACTION_TBLK_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TBLK]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tblk/Tblk_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TBLK]/
		[HttpPost]
		public ActionResult Tblk_Duplicate([FromBody]Tblk_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_Duplicate",
				ViewName = "Tblk",
				AreaName = "tblk",
				Location = ACTION_TBLK_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TBLK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TBLK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TBLK]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tblk_Cancel

		//
		// GET: /Tblk/Tblk_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TBLK]/
		public ActionResult Tblk_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tblk(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tblk");

// USE /[MANUAL GQT BEFORE_CANCEL TBLK]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TBLK]/

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

				Navigation.SetValue("ForcePrimaryRead_tblk", "true", true);
			}

			Navigation.ClearValue("tblk");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tblk_GrpbValNameModel : RequestLookupModel
		{
			public Tblk_ViewModel Model { get; set; }
		}

		//
		// GET: /Tblk/Tblk_GrpbValName
		// POST: /Tblk/Tblk_GrpbValName
		[ActionName("Tblk_GrpbValName")]
		public ActionResult Tblk_GrpbValName([FromBody] Tblk_GrpbValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_grpb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_grpb");
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

			Models.Tblk parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Tblk_GrpbValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Tblk_TrsbValNameModel : RequestLookupModel
		{
			public Tblk_ViewModel Model { get; set; }
		}

		//
		// GET: /Tblk/Tblk_TrsbValName
		// POST: /Tblk/Tblk_TrsbValName
		[ActionName("Tblk_TrsbValName")]
		public ActionResult Tblk_TrsbValName([FromBody] Tblk_TrsbValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_trsb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_trsb");
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

			Models.Tblk parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Tblk_TrsbValName_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Tblk/Tblk_SaveEdit
		[HttpPost]
		public ActionResult Tblk_SaveEdit([FromBody]Tblk_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblk_SaveEdit",
				ViewName = "Tblk",
				AreaName = "tblk",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TBLK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TBLK]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
