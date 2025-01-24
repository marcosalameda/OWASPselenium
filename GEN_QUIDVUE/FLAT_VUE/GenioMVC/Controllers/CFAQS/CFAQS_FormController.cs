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
using GenioMVC.ViewModels.Cfaqs;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CFAQS]/

namespace GenioMVC.Controllers
{
	public partial class CfaqsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CFAQS_CANCEL = new("CATEGORY_FAQS42471", "Cfaqs_Cancel", "Cfaqs") { vueRouteName = "form-CFAQS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CFAQS_SHOW = new("CATEGORY_FAQS42471", "Cfaqs_Show", "Cfaqs") { vueRouteName = "form-CFAQS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CFAQS_NEW = new("CATEGORY_FAQS42471", "Cfaqs_New", "Cfaqs") { vueRouteName = "form-CFAQS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CFAQS_EDIT = new("CATEGORY_FAQS42471", "Cfaqs_Edit", "Cfaqs") { vueRouteName = "form-CFAQS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CFAQS_DUPLICATE = new("CATEGORY_FAQS42471", "Cfaqs_Duplicate", "Cfaqs") { vueRouteName = "form-CFAQS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CFAQS_DELETE = new("CATEGORY_FAQS42471", "Cfaqs_Delete", "Cfaqs") { vueRouteName = "form-CFAQS", mode = "DELETE" };

		#endregion

		#region Cfaqs private

		private void FormHistoryLimits_Cfaqs()
		{

		}

		#endregion

		#region Cfaqs_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CFAQS]/

		[HttpPost]
		public ActionResult Cfaqs_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cfaqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Show_GET",
				AreaName = "cfaqs",
				Location = ACTION_CFAQS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cfaqs();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CFAQS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Cfaqs_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cfaqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_New_GET",
				AreaName = "cfaqs",
				FormName = "CFAQS",
				Location = ACTION_CFAQS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cfaqs();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CFAQS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cfaqs/Cfaqs_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_New([FromBody]Cfaqs_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_New",
				ViewName = "Cfaqs",
				AreaName = "cfaqs",
				Location = ACTION_CFAQS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CFAQS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CFAQS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CFAQS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Cfaqs_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cfaqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Edit_GET",
				AreaName = "cfaqs",
				FormName = "CFAQS",
				Location = ACTION_CFAQS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cfaqs();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CFAQS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cfaqs/Cfaqs_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_Edit([FromBody]Cfaqs_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Edit",
				ViewName = "Cfaqs",
				AreaName = "cfaqs",
				Location = ACTION_CFAQS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CFAQS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CFAQS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CFAQS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Cfaqs_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cfaqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Delete_GET",
				AreaName = "cfaqs",
				FormName = "CFAQS",
				Location = ACTION_CFAQS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cfaqs();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CFAQS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cfaqs/Cfaqs_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cfaqs_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Delete",
				ViewName = "Cfaqs",
				AreaName = "cfaqs",
				Location = ACTION_CFAQS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CFAQS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Cfaqs_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CFAQS");
		}

		#endregion

		#region Cfaqs_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CFAQS]/

		[HttpPost]
		public ActionResult Cfaqs_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cfaqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Duplicate_GET",
				AreaName = "cfaqs",
				FormName = "CFAQS",
				Location = ACTION_CFAQS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CFAQS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cfaqs/Cfaqs_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CFAQS]/
		[HttpPost]
		public ActionResult Cfaqs_Duplicate([FromBody]Cfaqs_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_Duplicate",
				ViewName = "Cfaqs",
				AreaName = "cfaqs",
				Location = ACTION_CFAQS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CFAQS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CFAQS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CFAQS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Cfaqs_Cancel

		//
		// GET: /Cfaqs/Cfaqs_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CFAQS]/
		public ActionResult Cfaqs_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cfaqs(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cfaqs");

// USE /[MANUAL GQT BEFORE_CANCEL CFAQS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CFAQS]/

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

				Navigation.SetValue("ForcePrimaryRead_cfaqs", "true", true);
			}

			Navigation.ClearValue("cfaqs");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Cfaqs/Cfaqs_ValExpfaqs
		// POST: /Cfaqs/Cfaqs_ValExpfaqs
		[ActionName("Cfaqs_ValExpfaqs")]
		public ActionResult Cfaqs_ValExpfaqs([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_faqs")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_faqs");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Cfaqs_ValExpfaqs_ViewModel model = new Cfaqs_ValExpfaqs_ViewModel(UserContext.Current);
			
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


		// POST: /Cfaqs/Cfaqs_SaveEdit
		[HttpPost]
		public ActionResult Cfaqs_SaveEdit([FromBody]Cfaqs_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cfaqs_SaveEdit",
				ViewName = "Cfaqs",
				AreaName = "cfaqs",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CFAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CFAQS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
