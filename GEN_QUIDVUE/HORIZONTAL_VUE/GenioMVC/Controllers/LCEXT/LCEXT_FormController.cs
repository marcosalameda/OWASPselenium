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
using GenioMVC.ViewModels.Lcext;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LCEXT]/

namespace GenioMVC.Controllers
{
	public partial class LcextController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LCEXT_CANCEL = new("LOCATION_EXTENSION_C10932", "Lcext_Cancel", "Lcext") { vueRouteName = "form-LCEXT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LCEXT_SHOW = new("LOCATION_EXTENSION_C10932", "Lcext_Show", "Lcext") { vueRouteName = "form-LCEXT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LCEXT_NEW = new("LOCATION_EXTENSION_C10932", "Lcext_New", "Lcext") { vueRouteName = "form-LCEXT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LCEXT_EDIT = new("LOCATION_EXTENSION_C10932", "Lcext_Edit", "Lcext") { vueRouteName = "form-LCEXT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LCEXT_DUPLICATE = new("LOCATION_EXTENSION_C10932", "Lcext_Duplicate", "Lcext") { vueRouteName = "form-LCEXT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LCEXT_DELETE = new("LOCATION_EXTENSION_C10932", "Lcext_Delete", "Lcext") { vueRouteName = "form-LCEXT", mode = "DELETE" };

		#endregion

		#region Lcext private

		private void FormHistoryLimits_Lcext()
		{

		}

		#endregion

		#region Lcext_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LCEXT]/

		[HttpPost]
		public ActionResult Lcext_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lcext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Show_GET",
				AreaName = "lcext",
				Location = ACTION_LCEXT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lcext();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LCEXT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Lcext_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LCEXT]/
		[HttpPost]
		public ActionResult Lcext_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Lcext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_New_GET",
				AreaName = "lcext",
				FormName = "LCEXT",
				Location = ACTION_LCEXT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Lcext();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LCEXT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lcext/Lcext_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LCEXT]/
		[HttpPost]
		public ActionResult Lcext_New([FromBody]Lcext_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_New",
				ViewName = "Lcext",
				AreaName = "lcext",
				Location = ACTION_LCEXT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LCEXT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LCEXT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LCEXT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Lcext_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LCEXT]/
		[HttpPost]
		public ActionResult Lcext_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lcext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Edit_GET",
				AreaName = "lcext",
				FormName = "LCEXT",
				Location = ACTION_LCEXT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lcext();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LCEXT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lcext/Lcext_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LCEXT]/
		[HttpPost]
		public ActionResult Lcext_Edit([FromBody]Lcext_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Edit",
				ViewName = "Lcext",
				AreaName = "lcext",
				Location = ACTION_LCEXT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LCEXT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LCEXT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LCEXT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Lcext_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LCEXT]/
		[HttpPost]
		public ActionResult Lcext_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lcext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Delete_GET",
				AreaName = "lcext",
				FormName = "LCEXT",
				Location = ACTION_LCEXT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lcext();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LCEXT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lcext/Lcext_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LCEXT]/
		[HttpPost]
		public ActionResult Lcext_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lcext_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Delete",
				ViewName = "Lcext",
				AreaName = "lcext",
				Location = ACTION_LCEXT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LCEXT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Lcext_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LCEXT");
		}

		#endregion

		#region Lcext_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LCEXT]/

		[HttpPost]
		public ActionResult Lcext_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Lcext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Duplicate_GET",
				AreaName = "lcext",
				FormName = "LCEXT",
				Location = ACTION_LCEXT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LCEXT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lcext/Lcext_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LCEXT]/
		[HttpPost]
		public ActionResult Lcext_Duplicate([FromBody]Lcext_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_Duplicate",
				ViewName = "Lcext",
				AreaName = "lcext",
				Location = ACTION_LCEXT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LCEXT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LCEXT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LCEXT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Lcext_Cancel

		//
		// GET: /Lcext/Lcext_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LCEXT]/
		public ActionResult Lcext_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lcext(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lcext");

// USE /[MANUAL GQT BEFORE_CANCEL LCEXT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LCEXT]/

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

				Navigation.SetValue("ForcePrimaryRead_lcext", "true", true);
			}

			Navigation.ClearValue("lcext");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Lcext_LocatValGlnModel : RequestLookupModel
		{
			public Lcext_ViewModel Model { get; set; }
		}

		//
		// GET: /Lcext/Lcext_LocatValGln
		// POST: /Lcext/Lcext_LocatValGln
		[ActionName("Lcext_LocatValGln")]
		public ActionResult Lcext_LocatValGln([FromBody] Lcext_LocatValGlnModel requestModel)
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

			Models.Lcext parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lcext_LocatValGln_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Lcext/Lcext_SaveEdit
		[HttpPost]
		public ActionResult Lcext_SaveEdit([FromBody]Lcext_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lcext_SaveEdit",
				ViewName = "Lcext",
				AreaName = "lcext",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LCEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LCEXT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
