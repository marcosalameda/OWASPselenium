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
using GenioMVC.ViewModels.City;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CITY]/

namespace GenioMVC.Controllers
{
	public partial class CityController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CITY03_CANCEL = new("CIDADE42080", "City03_Cancel", "City") { vueRouteName = "form-CITY03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CITY03_SHOW = new("CIDADE42080", "City03_Show", "City") { vueRouteName = "form-CITY03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CITY03_NEW = new("CIDADE42080", "City03_New", "City") { vueRouteName = "form-CITY03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CITY03_EDIT = new("CIDADE42080", "City03_Edit", "City") { vueRouteName = "form-CITY03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CITY03_DUPLICATE = new("CIDADE42080", "City03_Duplicate", "City") { vueRouteName = "form-CITY03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CITY03_DELETE = new("CIDADE42080", "City03_Delete", "City") { vueRouteName = "form-CITY03", mode = "DELETE" };

		#endregion

		#region City03 private

		private void FormHistoryLimits_City03()
		{

		}

		#endregion

		#region City03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CITY03]/

		[HttpPost]
		public ActionResult City03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City03_Show_GET",
				AreaName = "city",
				Location = ACTION_CITY03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_City03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region City03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CITY03]/
		[HttpPost]
		public ActionResult City03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new City03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City03_New_GET",
				AreaName = "city",
				FormName = "CITY03",
				Location = ACTION_CITY03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_City03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /City/City03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CITY03]/
		[HttpPost]
		public ActionResult City03_New([FromBody]City03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City03_New",
				ViewName = "City03",
				AreaName = "city",
				Location = ACTION_CITY03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CITY03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CITY03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region City03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CITY03]/
		[HttpPost]
		public ActionResult City03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City03_Edit_GET",
				AreaName = "city",
				FormName = "CITY03",
				Location = ACTION_CITY03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_City03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /City/City03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CITY03]/
		[HttpPost]
		public ActionResult City03_Edit([FromBody]City03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City03_Edit",
				ViewName = "City03",
				AreaName = "city",
				Location = ACTION_CITY03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CITY03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CITY03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region City03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CITY03]/
		[HttpPost]
		public ActionResult City03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City03_Delete_GET",
				AreaName = "city",
				FormName = "CITY03",
				Location = ACTION_CITY03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_City03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /City/City03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CITY03]/
		[HttpPost]
		public ActionResult City03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new City03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "City03_Delete",
				ViewName = "City03",
				AreaName = "city",
				Location = ACTION_CITY03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult City03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CITY03");
		}

		#endregion

		#region City03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CITY03]/

		[HttpPost]
		public ActionResult City03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new City03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "City03_Duplicate_GET",
				AreaName = "city",
				FormName = "CITY03",
				Location = ACTION_CITY03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /City/City03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CITY03]/
		[HttpPost]
		public ActionResult City03_Duplicate([FromBody]City03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "City03_Duplicate",
				ViewName = "City03",
				AreaName = "city",
				Location = ACTION_CITY03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CITY03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CITY03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CITY03]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CITY03.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region City03_Cancel

		//
		// GET: /City/City03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CITY03]/
		public ActionResult City03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.City(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("city");

// USE /[MANUAL GQT BEFORE_CANCEL CITY03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CITY03]/

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

				Navigation.SetValue("ForcePrimaryRead_city", "true", true);
			}

			Navigation.ClearValue("city");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class City03_CtryValCountryModel : RequestLookupModel
		{
			public City03_ViewModel Model { get; set; }
		}

		//
		// GET: /City/City03_CtryValCountry
		// POST: /City/City03_CtryValCountry
		[ActionName("City03_CtryValCountry")]
		public ActionResult City03_CtryValCountry([FromBody] City03_CtryValCountryModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_ctry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_ctry");
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

			Models.City parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			City03_CtryValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /City/City03_SaveEdit
		[HttpPost]
		public ActionResult City03_SaveEdit([FromBody] City03_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "City03_SaveEdit",
				ViewName = "City03",
				AreaName = "city",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CITY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CITY03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class City03DocumValidateTickets : RequestDocumValidateTickets
		{
			public City03_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCity03([FromBody] City03DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
