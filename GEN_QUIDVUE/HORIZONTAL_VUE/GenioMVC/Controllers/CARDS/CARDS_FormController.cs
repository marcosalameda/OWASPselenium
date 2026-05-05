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
using GenioMVC.ViewModels.Cards;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CARDS]/

namespace GenioMVC.Controllers
{
	public partial class CardsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CARDS_CANCEL = new("CARD53624", "Cards_Cancel", "Cards") { vueRouteName = "form-CARDS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CARDS_SHOW = new("CARD53624", "Cards_Show", "Cards") { vueRouteName = "form-CARDS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CARDS_NEW = new("CARD53624", "Cards_New", "Cards") { vueRouteName = "form-CARDS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CARDS_EDIT = new("CARD53624", "Cards_Edit", "Cards") { vueRouteName = "form-CARDS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CARDS_DUPLICATE = new("CARD53624", "Cards_Duplicate", "Cards") { vueRouteName = "form-CARDS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CARDS_DELETE = new("CARD53624", "Cards_Delete", "Cards") { vueRouteName = "form-CARDS", mode = "DELETE" };

		#endregion

		#region Cards private

		private void FormHistoryLimits_Cards()
		{

		}

		#endregion

		#region Cards_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CARDS]/

		[HttpPost]
		public ActionResult Cards_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cards_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cards_Show_GET",
				AreaName = "cards",
				Location = ACTION_CARDS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cards();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Cards_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CARDS]/
		[HttpPost]
		public ActionResult Cards_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cards_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cards_New_GET",
				AreaName = "cards",
				FormName = "CARDS",
				Location = ACTION_CARDS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cards();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Cards/Cards_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CARDS]/
		[HttpPost]
		public ActionResult Cards_New([FromBody]Cards_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cards_New",
				ViewName = "Cards",
				AreaName = "cards",
				Location = ACTION_CARDS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CARDS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CARDS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Cards_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CARDS]/
		[HttpPost]
		public ActionResult Cards_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cards_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cards_Edit_GET",
				AreaName = "cards",
				FormName = "CARDS",
				Location = ACTION_CARDS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cards();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Cards/Cards_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CARDS]/
		[HttpPost]
		public ActionResult Cards_Edit([FromBody]Cards_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cards_Edit",
				ViewName = "Cards",
				AreaName = "cards",
				Location = ACTION_CARDS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CARDS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CARDS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Cards_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CARDS]/
		[HttpPost]
		public ActionResult Cards_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cards_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cards_Delete_GET",
				AreaName = "cards",
				FormName = "CARDS",
				Location = ACTION_CARDS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cards();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Cards/Cards_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CARDS]/
		[HttpPost]
		public ActionResult Cards_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cards_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cards_Delete",
				ViewName = "Cards",
				AreaName = "cards",
				Location = ACTION_CARDS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Cards_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CARDS");
		}

		#endregion

		#region Cards_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CARDS]/

		[HttpPost]
		public ActionResult Cards_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cards_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cards_Duplicate_GET",
				AreaName = "cards",
				FormName = "CARDS",
				Location = ACTION_CARDS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Cards/Cards_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CARDS]/
		[HttpPost]
		public ActionResult Cards_Duplicate([FromBody]Cards_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cards_Duplicate",
				ViewName = "Cards",
				AreaName = "cards",
				Location = ACTION_CARDS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CARDS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CARDS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CARDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDS.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Cards_Cancel

		//
		// GET: /Cards/Cards_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CARDS]/
		public ActionResult Cards_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cards(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cards");

// USE /[MANUAL GQT BEFORE_CANCEL CARDS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CARDS]/

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

				Navigation.SetValue("ForcePrimaryRead_cards", "true", true);
			}

			Navigation.ClearValue("cards");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Card1_ValCardnormalModel : RequestLookupModel
		{
			public Cards_ViewModel Model { get; set; }
		}

		//
		// GET: /Cards/Card1_ValCardnormal
		// POST: /Cards/Card1_ValCardnormal
		[ActionName("Card1_ValCardnormal")]
		public ActionResult Card1_ValCardnormal([FromBody] Card1_ValCardnormalModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cards")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cards");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Cards parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Card1_ValCardnormal_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Cards/Cards_SaveEdit
		[HttpPost]
		public ActionResult Cards_SaveEdit([FromBody] Cards_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Cards_SaveEdit",
				ViewName = "Cards",
				AreaName = "cards",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CARDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CARDS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CardsDocumValidateTickets : RequestDocumValidateTickets
		{
			public Cards_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCards([FromBody] CardsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
