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
using GenioMVC.ViewModels.Proph;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPH]/

namespace GenioMVC.Controllers
{
	public partial class ProphController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PHOTO03_CANCEL = new("PHOTO51874", "Photo03_Cancel", "Proph") { vueRouteName = "form-PHOTO03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PHOTO03_SHOW = new("PHOTO51874", "Photo03_Show", "Proph") { vueRouteName = "form-PHOTO03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PHOTO03_NEW = new("PHOTO51874", "Photo03_New", "Proph") { vueRouteName = "form-PHOTO03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PHOTO03_EDIT = new("PHOTO51874", "Photo03_Edit", "Proph") { vueRouteName = "form-PHOTO03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PHOTO03_DUPLICATE = new("PHOTO51874", "Photo03_Duplicate", "Proph") { vueRouteName = "form-PHOTO03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PHOTO03_DELETE = new("PHOTO51874", "Photo03_Delete", "Proph") { vueRouteName = "form-PHOTO03", mode = "DELETE" };

		#endregion

		#region Photo03 private

		private void FormHistoryLimits_Photo03()
		{

		}

		#endregion

		#region Photo03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PHOTO03]/

		[HttpPost]
		public ActionResult Photo03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Photo03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Show_GET",
				AreaName = "proph",
				Location = ACTION_PHOTO03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Photo03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PHOTO03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Photo03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Photo03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_New_GET",
				AreaName = "proph",
				FormName = "PHOTO03",
				Location = ACTION_PHOTO03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Photo03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PHOTO03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Proph/Photo03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_New([FromBody]Photo03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_New",
				ViewName = "Photo03",
				AreaName = "proph",
				Location = ACTION_PHOTO03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PHOTO03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PHOTO03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PHOTO03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Photo03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Photo03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Edit_GET",
				AreaName = "proph",
				FormName = "PHOTO03",
				Location = ACTION_PHOTO03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Photo03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PHOTO03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Proph/Photo03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_Edit([FromBody]Photo03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Edit",
				ViewName = "Photo03",
				AreaName = "proph",
				Location = ACTION_PHOTO03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PHOTO03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PHOTO03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PHOTO03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Photo03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Photo03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Delete_GET",
				AreaName = "proph",
				FormName = "PHOTO03",
				Location = ACTION_PHOTO03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Photo03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PHOTO03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Proph/Photo03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Photo03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Delete",
				ViewName = "Photo03",
				AreaName = "proph",
				Location = ACTION_PHOTO03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PHOTO03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Photo03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PHOTO03");
		}

		#endregion

		#region Photo03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PHOTO03]/

		[HttpPost]
		public ActionResult Photo03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Photo03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Duplicate_GET",
				AreaName = "proph",
				FormName = "PHOTO03",
				Location = ACTION_PHOTO03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PHOTO03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Proph/Photo03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PHOTO03]/
		[HttpPost]
		public ActionResult Photo03_Duplicate([FromBody]Photo03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_Duplicate",
				ViewName = "Photo03",
				AreaName = "proph",
				Location = ACTION_PHOTO03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PHOTO03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PHOTO03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PHOTO03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Photo03_Cancel

		//
		// GET: /Proph/Photo03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PHOTO03]/
		public ActionResult Photo03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Proph(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("proph");

// USE /[MANUAL GQT BEFORE_CANCEL PHOTO03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PHOTO03]/

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

				Navigation.SetValue("ForcePrimaryRead_proph", "true", true);
			}

			Navigation.ClearValue("proph");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Proph/Photo03_PropeValTitle
		// POST: /Proph/Photo03_PropeValTitle
		[ActionName("Photo03_PropeValTitle")]
		public ActionResult Photo03_PropeValTitle([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_prope")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_prope");
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
			Photo03_PropeValTitle_ViewModel model = new Photo03_PropeValTitle_ViewModel(UserContext.Current);
			
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


		// POST: /Proph/Photo03_SaveEdit
		[HttpPost]
		public ActionResult Photo03_SaveEdit([FromBody]Photo03_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Photo03_SaveEdit",
				ViewName = "Photo03",
				AreaName = "proph",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PHOTO03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PHOTO03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
