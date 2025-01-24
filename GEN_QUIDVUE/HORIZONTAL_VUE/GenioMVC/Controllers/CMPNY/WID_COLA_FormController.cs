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
using GenioMVC.ViewModels.Cmpny;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPNY]/

namespace GenioMVC.Controllers
{
	public partial class CmpnyController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_WID_COLA_CANCEL = new("COMPANY52963", "Wid_cola_Cancel", "Cmpny") { vueRouteName = "form-WID_COLA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_WID_COLA_SHOW = new("COMPANY52963", "Wid_cola_Show", "Cmpny") { vueRouteName = "form-WID_COLA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_WID_COLA_NEW = new("COMPANY52963", "Wid_cola_New", "Cmpny") { vueRouteName = "form-WID_COLA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_WID_COLA_EDIT = new("COMPANY52963", "Wid_cola_Edit", "Cmpny") { vueRouteName = "form-WID_COLA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_WID_COLA_DUPLICATE = new("COMPANY52963", "Wid_cola_Duplicate", "Cmpny") { vueRouteName = "form-WID_COLA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_WID_COLA_DELETE = new("COMPANY52963", "Wid_cola_Delete", "Cmpny") { vueRouteName = "form-WID_COLA", mode = "DELETE" };

		#endregion

		#region Wid_cola private

		private void FormHistoryLimits_Wid_cola()
		{

		}

		#endregion

		#region Wid_cola_Show

// USE /[MANUAL GQT CONTROLLER_SHOW WID_COLA]/

		[HttpPost]
		public ActionResult Wid_cola_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_cola_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Show_GET",
				AreaName = "cmpny",
				Location = ACTION_WID_COLA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wid_cola();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW WID_COLA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Wid_cola_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Wid_cola_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_New_GET",
				AreaName = "cmpny",
				FormName = "WID_COLA",
				Location = ACTION_WID_COLA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Wid_cola();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW WID_COLA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cmpny/Wid_cola_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_New([FromBody]Wid_cola_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_New",
				ViewName = "Wid_cola",
				AreaName = "cmpny",
				Location = ACTION_WID_COLA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW WID_COLA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX WID_COLA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX WID_COLA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Wid_cola_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_cola_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Edit_GET",
				AreaName = "cmpny",
				FormName = "WID_COLA",
				Location = ACTION_WID_COLA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wid_cola();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT WID_COLA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cmpny/Wid_cola_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_Edit([FromBody]Wid_cola_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Edit",
				ViewName = "Wid_cola",
				AreaName = "cmpny",
				Location = ACTION_WID_COLA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT WID_COLA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX WID_COLA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX WID_COLA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Wid_cola_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_cola_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Delete_GET",
				AreaName = "cmpny",
				FormName = "WID_COLA",
				Location = ACTION_WID_COLA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wid_cola();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE WID_COLA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cmpny/Wid_cola_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_cola_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Delete",
				ViewName = "Wid_cola",
				AreaName = "cmpny",
				Location = ACTION_WID_COLA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE WID_COLA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Wid_cola_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("WID_COLA");
		}

		#endregion

		#region Wid_cola_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET WID_COLA]/

		[HttpPost]
		public ActionResult Wid_cola_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Wid_cola_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Duplicate_GET",
				AreaName = "cmpny",
				FormName = "WID_COLA",
				Location = ACTION_WID_COLA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE WID_COLA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cmpny/Wid_cola_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST WID_COLA]/
		[HttpPost]
		public ActionResult Wid_cola_Duplicate([FromBody]Wid_cola_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_Duplicate",
				ViewName = "Wid_cola",
				AreaName = "cmpny",
				Location = ACTION_WID_COLA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE WID_COLA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX WID_COLA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX WID_COLA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Wid_cola_Cancel

		//
		// GET: /Cmpny/Wid_cola_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET WID_COLA]/
		public ActionResult Wid_cola_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cmpny(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");

// USE /[MANUAL GQT BEFORE_CANCEL WID_COLA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL WID_COLA]/

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

				Navigation.SetValue("ForcePrimaryRead_cmpny", "true", true);
			}

			Navigation.ClearValue("cmpny");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Cmpny/Wid_cola_ValPesslist
		// POST: /Cmpny/Wid_cola_ValPesslist
		[ActionName("Wid_cola_ValPesslist")]
		public ActionResult Wid_cola_ValPesslist([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Wid_cola_ValPesslist_ViewModel model = new Wid_cola_ValPesslist_ViewModel(UserContext.Current);
			
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


		// POST: /Cmpny/Wid_cola_SaveEdit
		[HttpPost]
		public ActionResult Wid_cola_SaveEdit([FromBody]Wid_cola_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_cola_SaveEdit",
				ViewName = "Wid_cola",
				AreaName = "cmpny",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT WID_COLA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT WID_COLA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
