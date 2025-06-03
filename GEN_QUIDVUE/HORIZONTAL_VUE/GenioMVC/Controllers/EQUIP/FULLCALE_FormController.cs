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
using GenioMVC.ViewModels.Equip;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FULLCALE_CANCEL = new("FULL_CALENDAR15524", "Fullcale_Cancel", "Equip") { vueRouteName = "form-FULLCALE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FULLCALE_SHOW = new("FULL_CALENDAR15524", "Fullcale_Show", "Equip") { vueRouteName = "form-FULLCALE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FULLCALE_NEW = new("FULL_CALENDAR15524", "Fullcale_New", "Equip") { vueRouteName = "form-FULLCALE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FULLCALE_EDIT = new("FULL_CALENDAR15524", "Fullcale_Edit", "Equip") { vueRouteName = "form-FULLCALE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FULLCALE_DUPLICATE = new("FULL_CALENDAR15524", "Fullcale_Duplicate", "Equip") { vueRouteName = "form-FULLCALE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FULLCALE_DELETE = new("FULL_CALENDAR15524", "Fullcale_Delete", "Equip") { vueRouteName = "form-FULLCALE", mode = "DELETE" };

		#endregion

		#region Fullcale private

		private void FormHistoryLimits_Fullcale()
		{

		}

		#endregion

		#region Fullcale_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FULLCALE]/

		[HttpPost]
		public ActionResult Fullcale_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fullcale_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Show_GET",
				AreaName = "equip",
				Location = ACTION_FULLCALE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fullcale();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FULLCALE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Fullcale_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Fullcale_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_New_GET",
				AreaName = "equip",
				FormName = "FULLCALE",
				Location = ACTION_FULLCALE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Fullcale();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FULLCALE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Fullcale_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_New([FromBody]Fullcale_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_New",
				ViewName = "Fullcale",
				AreaName = "equip",
				Location = ACTION_FULLCALE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FULLCALE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FULLCALE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FULLCALE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Fullcale_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fullcale_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Edit_GET",
				AreaName = "equip",
				FormName = "FULLCALE",
				Location = ACTION_FULLCALE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fullcale();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FULLCALE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Fullcale_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_Edit([FromBody]Fullcale_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Edit",
				ViewName = "Fullcale",
				AreaName = "equip",
				Location = ACTION_FULLCALE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FULLCALE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FULLCALE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FULLCALE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Fullcale_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fullcale_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Delete_GET",
				AreaName = "equip",
				FormName = "FULLCALE",
				Location = ACTION_FULLCALE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fullcale();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FULLCALE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Fullcale_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fullcale_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Delete",
				ViewName = "Fullcale",
				AreaName = "equip",
				Location = ACTION_FULLCALE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FULLCALE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Fullcale_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FULLCALE");
		}

		#endregion

		#region Fullcale_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FULLCALE]/

		[HttpPost]
		public ActionResult Fullcale_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Fullcale_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Duplicate_GET",
				AreaName = "equip",
				FormName = "FULLCALE",
				Location = ACTION_FULLCALE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FULLCALE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Fullcale_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FULLCALE]/
		[HttpPost]
		public ActionResult Fullcale_Duplicate([FromBody]Fullcale_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_Duplicate",
				ViewName = "Fullcale",
				AreaName = "equip",
				Location = ACTION_FULLCALE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FULLCALE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FULLCALE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FULLCALE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Fullcale_Cancel

		//
		// GET: /Equip/Fullcale_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FULLCALE]/
		public ActionResult Fullcale_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL FULLCALE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FULLCALE]/

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

				Navigation.SetValue("ForcePrimaryRead_equip", "true", true);
			}

			Navigation.ClearValue("equip");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Fullcale_ValFullcaleModel : RequestLookupModel
		{
			public Fullcale_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Fullcale_ValFullcale
		// POST: /Equip/Fullcale_ValFullcale
		[ActionName("Fullcale_ValFullcale")]
		public ActionResult Fullcale_ValFullcale([FromBody] Fullcale_ValFullcaleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_visit")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_visit");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Fullcale_ValFullcale_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Equip/Fullcale_SaveEdit
		[HttpPost]
		public ActionResult Fullcale_SaveEdit([FromBody]Fullcale_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fullcale_SaveEdit",
				ViewName = "Fullcale",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FULLCALE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FULLCALE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
