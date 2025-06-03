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
using GenioMVC.ViewModels.Notif;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER NOTIF]/

namespace GenioMVC.Controllers
{
	public partial class NotifController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_NOTIF_CANCEL = new("NOTIFICATION15372", "Notif_Cancel", "Notif") { vueRouteName = "form-NOTIF", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_NOTIF_SHOW = new("NOTIFICATION15372", "Notif_Show", "Notif") { vueRouteName = "form-NOTIF", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_NOTIF_NEW = new("NOTIFICATION15372", "Notif_New", "Notif") { vueRouteName = "form-NOTIF", mode = "NEW" };
		private static readonly NavigationLocation ACTION_NOTIF_EDIT = new("NOTIFICATION15372", "Notif_Edit", "Notif") { vueRouteName = "form-NOTIF", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_NOTIF_DUPLICATE = new("NOTIFICATION15372", "Notif_Duplicate", "Notif") { vueRouteName = "form-NOTIF", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_NOTIF_DELETE = new("NOTIFICATION15372", "Notif_Delete", "Notif") { vueRouteName = "form-NOTIF", mode = "DELETE" };

		#endregion

		#region Notif private

		private void FormHistoryLimits_Notif()
		{

		}

		#endregion

		#region Notif_Show

// USE /[MANUAL GQT CONTROLLER_SHOW NOTIF]/

		[HttpPost]
		public ActionResult Notif_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Notif_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Notif_Show_GET",
				AreaName = "notif",
				Location = ACTION_NOTIF_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Notif();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW NOTIF]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Notif_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET NOTIF]/
		[HttpPost]
		public ActionResult Notif_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Notif_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Notif_New_GET",
				AreaName = "notif",
				FormName = "NOTIF",
				Location = ACTION_NOTIF_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Notif();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW NOTIF]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Notif/Notif_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST NOTIF]/
		[HttpPost]
		public ActionResult Notif_New([FromBody]Notif_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Notif_New",
				ViewName = "Notif",
				AreaName = "notif",
				Location = ACTION_NOTIF_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW NOTIF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX NOTIF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX NOTIF]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Notif_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET NOTIF]/
		[HttpPost]
		public ActionResult Notif_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Notif_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Notif_Edit_GET",
				AreaName = "notif",
				FormName = "NOTIF",
				Location = ACTION_NOTIF_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Notif();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT NOTIF]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Notif/Notif_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST NOTIF]/
		[HttpPost]
		public ActionResult Notif_Edit([FromBody]Notif_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Notif_Edit",
				ViewName = "Notif",
				AreaName = "notif",
				Location = ACTION_NOTIF_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT NOTIF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX NOTIF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX NOTIF]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Notif_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET NOTIF]/
		[HttpPost]
		public ActionResult Notif_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Notif_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Notif_Delete_GET",
				AreaName = "notif",
				FormName = "NOTIF",
				Location = ACTION_NOTIF_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Notif();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE NOTIF]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Notif/Notif_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST NOTIF]/
		[HttpPost]
		public ActionResult Notif_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Notif_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Notif_Delete",
				ViewName = "Notif",
				AreaName = "notif",
				Location = ACTION_NOTIF_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE NOTIF]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Notif_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("NOTIF");
		}

		#endregion

		#region Notif_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET NOTIF]/

		[HttpPost]
		public ActionResult Notif_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Notif_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Notif_Duplicate_GET",
				AreaName = "notif",
				FormName = "NOTIF",
				Location = ACTION_NOTIF_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE NOTIF]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Notif/Notif_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST NOTIF]/
		[HttpPost]
		public ActionResult Notif_Duplicate([FromBody]Notif_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Notif_Duplicate",
				ViewName = "Notif",
				AreaName = "notif",
				Location = ACTION_NOTIF_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE NOTIF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX NOTIF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX NOTIF]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Notif_Cancel

		//
		// GET: /Notif/Notif_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET NOTIF]/
		public ActionResult Notif_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Notif(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("notif");

// USE /[MANUAL GQT BEFORE_CANCEL NOTIF]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL NOTIF]/

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

				Navigation.SetValue("ForcePrimaryRead_notif", "true", true);
			}

			Navigation.ClearValue("notif");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Notif_Pess2ValNameModel : RequestLookupModel
		{
			public Notif_ViewModel Model { get; set; }
		}

		//
		// GET: /Notif/Notif_Pess2ValName
		// POST: /Notif/Notif_Pess2ValName
		[ActionName("Notif_Pess2ValName")]
		public ActionResult Notif_Pess2ValName([FromBody] Notif_Pess2ValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess2")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess2");
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

			Models.Notif parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Notif_Pess2ValName_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Notif/Notif_SaveEdit
		[HttpPost]
		public ActionResult Notif_SaveEdit([FromBody]Notif_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Notif_SaveEdit",
				ViewName = "Notif",
				AreaName = "notif",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT NOTIF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT NOTIF]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
