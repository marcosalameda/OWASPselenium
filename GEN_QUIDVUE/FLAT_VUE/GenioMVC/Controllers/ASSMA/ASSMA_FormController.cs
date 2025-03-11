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
using GenioMVC.ViewModels.Assma;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSMA]/

namespace GenioMVC.Controllers
{
	public partial class AssmaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ASSMA_CANCEL = new("ASSET_MANUAL50119", "Assma_Cancel", "Assma") { vueRouteName = "form-ASSMA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ASSMA_SHOW = new("ASSET_MANUAL50119", "Assma_Show", "Assma") { vueRouteName = "form-ASSMA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ASSMA_NEW = new("ASSET_MANUAL50119", "Assma_New", "Assma") { vueRouteName = "form-ASSMA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ASSMA_EDIT = new("ASSET_MANUAL50119", "Assma_Edit", "Assma") { vueRouteName = "form-ASSMA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ASSMA_DUPLICATE = new("ASSET_MANUAL50119", "Assma_Duplicate", "Assma") { vueRouteName = "form-ASSMA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ASSMA_DELETE = new("ASSET_MANUAL50119", "Assma_Delete", "Assma") { vueRouteName = "form-ASSMA", mode = "DELETE" };

		#endregion

		#region Assma private

		private void FormHistoryLimits_Assma()
		{

		}

		#endregion

		#region Assma_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ASSMA]/

		[HttpPost]
		public ActionResult Assma_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Assma_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Assma_Show_GET",
				AreaName = "assma",
				Location = ACTION_ASSMA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Assma();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ASSMA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Assma_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ASSMA]/
		[HttpPost]
		public ActionResult Assma_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Assma_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Assma_New_GET",
				AreaName = "assma",
				FormName = "ASSMA",
				Location = ACTION_ASSMA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Assma();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ASSMA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Assma/Assma_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ASSMA]/
		[HttpPost]
		public ActionResult Assma_New([FromBody]Assma_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Assma_New",
				ViewName = "Assma",
				AreaName = "assma",
				Location = ACTION_ASSMA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ASSMA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ASSMA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ASSMA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Assma_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ASSMA]/
		[HttpPost]
		public ActionResult Assma_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Assma_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Assma_Edit_GET",
				AreaName = "assma",
				FormName = "ASSMA",
				Location = ACTION_ASSMA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Assma();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ASSMA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Assma/Assma_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ASSMA]/
		[HttpPost]
		public ActionResult Assma_Edit([FromBody]Assma_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Assma_Edit",
				ViewName = "Assma",
				AreaName = "assma",
				Location = ACTION_ASSMA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ASSMA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ASSMA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ASSMA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Assma_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ASSMA]/
		[HttpPost]
		public ActionResult Assma_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Assma_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Assma_Delete_GET",
				AreaName = "assma",
				FormName = "ASSMA",
				Location = ACTION_ASSMA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Assma();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ASSMA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Assma/Assma_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ASSMA]/
		[HttpPost]
		public ActionResult Assma_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Assma_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Assma_Delete",
				ViewName = "Assma",
				AreaName = "assma",
				Location = ACTION_ASSMA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ASSMA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Assma_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ASSMA");
		}

		#endregion

		#region Assma_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ASSMA]/

		[HttpPost]
		public ActionResult Assma_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Assma_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Assma_Duplicate_GET",
				AreaName = "assma",
				FormName = "ASSMA",
				Location = ACTION_ASSMA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ASSMA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Assma/Assma_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ASSMA]/
		[HttpPost]
		public ActionResult Assma_Duplicate([FromBody]Assma_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Assma_Duplicate",
				ViewName = "Assma",
				AreaName = "assma",
				Location = ACTION_ASSMA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ASSMA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ASSMA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ASSMA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Assma_Cancel

		//
		// GET: /Assma/Assma_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ASSMA]/
		public ActionResult Assma_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Assma(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("assma");

// USE /[MANUAL GQT BEFORE_CANCEL ASSMA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ASSMA]/

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

				Navigation.SetValue("ForcePrimaryRead_assma", "true", true);
			}

			Navigation.ClearValue("assma");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Assma_AssetValNameModel : RequestLookupModel
		{
			public Assma_ViewModel Model { get; set; }
		}

		//
		// GET: /Assma/Assma_AssetValName
		// POST: /Assma/Assma_AssetValName
		[ActionName("Assma_AssetValName")]
		public ActionResult Assma_AssetValName([FromBody] Assma_AssetValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asset")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asset");
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

			Models.Assma parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Assma_AssetValName_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Assma/Assma_SaveEdit
		[HttpPost]
		public ActionResult Assma_SaveEdit([FromBody]Assma_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Assma_SaveEdit",
				ViewName = "Assma",
				AreaName = "assma",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ASSMA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ASSMA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
