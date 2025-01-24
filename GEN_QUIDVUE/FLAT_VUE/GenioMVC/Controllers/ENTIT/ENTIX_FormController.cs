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
using GenioMVC.ViewModels.Entit;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ENTIT]/

namespace GenioMVC.Controllers
{
	public partial class EntitController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ENTIX_CANCEL = new("ENTITY62049", "Entix_Cancel", "Entit") { vueRouteName = "form-ENTIX", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ENTIX_SHOW = new("ENTITY62049", "Entix_Show", "Entit") { vueRouteName = "form-ENTIX", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ENTIX_NEW = new("ENTITY62049", "Entix_New", "Entit") { vueRouteName = "form-ENTIX", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ENTIX_EDIT = new("ENTITY62049", "Entix_Edit", "Entit") { vueRouteName = "form-ENTIX", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ENTIX_DUPLICATE = new("ENTITY62049", "Entix_Duplicate", "Entit") { vueRouteName = "form-ENTIX", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ENTIX_DELETE = new("ENTITY62049", "Entix_Delete", "Entit") { vueRouteName = "form-ENTIX", mode = "DELETE" };

		#endregion

		#region Entix private

		private void FormHistoryLimits_Entix()
		{

		}

		#endregion

		#region Entix_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ENTIX]/

		[HttpPost]
		public ActionResult Entix_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entix_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entix_Show_GET",
				AreaName = "entit",
				Location = ACTION_ENTIX_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entix();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ENTIX]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Entix_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ENTIX]/
		[HttpPost]
		public ActionResult Entix_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Entix_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entix_New_GET",
				AreaName = "entit",
				FormName = "ENTIX",
				Location = ACTION_ENTIX_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Entix();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ENTIX]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Entit/Entix_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ENTIX]/
		[HttpPost]
		public ActionResult Entix_New([FromBody]Entix_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entix_New",
				ViewName = "Entix",
				AreaName = "entit",
				Location = ACTION_ENTIX_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ENTIX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ENTIX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ENTIX]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Entix_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ENTIX]/
		[HttpPost]
		public ActionResult Entix_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entix_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entix_Edit_GET",
				AreaName = "entit",
				FormName = "ENTIX",
				Location = ACTION_ENTIX_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entix();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ENTIX]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Entit/Entix_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ENTIX]/
		[HttpPost]
		public ActionResult Entix_Edit([FromBody]Entix_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entix_Edit",
				ViewName = "Entix",
				AreaName = "entit",
				Location = ACTION_ENTIX_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ENTIX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ENTIX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ENTIX]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Entix_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ENTIX]/
		[HttpPost]
		public ActionResult Entix_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entix_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entix_Delete_GET",
				AreaName = "entit",
				FormName = "ENTIX",
				Location = ACTION_ENTIX_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entix();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ENTIX]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Entit/Entix_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ENTIX]/
		[HttpPost]
		public ActionResult Entix_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Entix_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Entix_Delete",
				ViewName = "Entix",
				AreaName = "entit",
				Location = ACTION_ENTIX_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ENTIX]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Entix_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ENTIX");
		}

		#endregion

		#region Entix_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ENTIX]/

		[HttpPost]
		public ActionResult Entix_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Entix_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Entix_Duplicate_GET",
				AreaName = "entit",
				FormName = "ENTIX",
				Location = ACTION_ENTIX_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ENTIX]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Entit/Entix_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ENTIX]/
		[HttpPost]
		public ActionResult Entix_Duplicate([FromBody]Entix_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entix_Duplicate",
				ViewName = "Entix",
				AreaName = "entit",
				Location = ACTION_ENTIX_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ENTIX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ENTIX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ENTIX]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Entix_Cancel

		//
		// GET: /Entit/Entix_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ENTIX]/
		public ActionResult Entix_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Entit(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("entit");

// USE /[MANUAL GQT BEFORE_CANCEL ENTIX]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ENTIX]/

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

				Navigation.SetValue("ForcePrimaryRead_entit", "true", true);
			}

			Navigation.ClearValue("entit");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Entit/Entix_ValFacilite
		// POST: /Entit/Entix_ValFacilite
		[ActionName("Entix_ValFacilite")]
		public ActionResult Entix_ValFacilite([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_facil")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_facil");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Entix_ValFacilite_ViewModel model = new Entix_ValFacilite_ViewModel(UserContext.Current);
			
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


		// POST: /Entit/Entix_SaveEdit
		[HttpPost]
		public ActionResult Entix_SaveEdit([FromBody]Entix_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Entix_SaveEdit",
				ViewName = "Entix",
				AreaName = "entit",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ENTIX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ENTIX]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
