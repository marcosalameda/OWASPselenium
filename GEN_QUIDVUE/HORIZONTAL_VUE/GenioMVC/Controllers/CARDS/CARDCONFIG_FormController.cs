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

		private static readonly NavigationLocation ACTION_CARDCONFIG_CANCEL = new("CARD_CONFIGURATION55633", "Cardconfig_Cancel", "Cards") { vueRouteName = "form-CARDCONFIG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CARDCONFIG_SHOW = new("CARD_CONFIGURATION55633", "Cardconfig_Show", "Cards") { vueRouteName = "form-CARDCONFIG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CARDCONFIG_NEW = new("CARD_CONFIGURATION55633", "Cardconfig_New", "Cards") { vueRouteName = "form-CARDCONFIG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CARDCONFIG_EDIT = new("CARD_CONFIGURATION55633", "Cardconfig_Edit", "Cards") { vueRouteName = "form-CARDCONFIG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CARDCONFIG_DUPLICATE = new("CARD_CONFIGURATION55633", "Cardconfig_Duplicate", "Cards") { vueRouteName = "form-CARDCONFIG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CARDCONFIG_DELETE = new("CARD_CONFIGURATION55633", "Cardconfig_Delete", "Cards") { vueRouteName = "form-CARDCONFIG", mode = "DELETE" };

		#endregion

		#region Cardconfig private

		private void FormHistoryLimits_Cardconfig()
		{

		}

		#endregion

		#region Cardconfig_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CARDCONFIG]/

		[HttpPost]
		public ActionResult Cardconfig_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cardconfig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Show_GET",
				AreaName = "cards",
				Location = ACTION_CARDCONFIG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cardconfig();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Cardconfig_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cardconfig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_New_GET",
				AreaName = "cards",
				FormName = "CARDCONFIG",
				Location = ACTION_CARDCONFIG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cardconfig();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Cards/Cardconfig_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_New([FromBody]Cardconfig_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_New",
				ViewName = "Cardconfig",
				AreaName = "cards",
				Location = ACTION_CARDCONFIG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CARDCONFIG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CARDCONFIG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Cardconfig_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cardconfig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Edit_GET",
				AreaName = "cards",
				FormName = "CARDCONFIG",
				Location = ACTION_CARDCONFIG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cardconfig();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Cards/Cardconfig_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_Edit([FromBody]Cardconfig_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Edit",
				ViewName = "Cardconfig",
				AreaName = "cards",
				Location = ACTION_CARDCONFIG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CARDCONFIG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CARDCONFIG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Cardconfig_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cardconfig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Delete_GET",
				AreaName = "cards",
				FormName = "CARDCONFIG",
				Location = ACTION_CARDCONFIG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cardconfig();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Cards/Cardconfig_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cardconfig_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Delete",
				ViewName = "Cardconfig",
				AreaName = "cards",
				Location = ACTION_CARDCONFIG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Cardconfig_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CARDCONFIG");
		}

		#endregion

		#region Cardconfig_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CARDCONFIG]/

		[HttpPost]
		public ActionResult Cardconfig_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cardconfig_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Duplicate_GET",
				AreaName = "cards",
				FormName = "CARDCONFIG",
				Location = ACTION_CARDCONFIG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Cards/Cardconfig_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CARDCONFIG]/
		[HttpPost]
		public ActionResult Cardconfig_Duplicate([FromBody]Cardconfig_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cardconfig_Duplicate",
				ViewName = "Cardconfig",
				AreaName = "cards",
				Location = ACTION_CARDCONFIG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CARDCONFIG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CARDCONFIG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CARDCONFIG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CARDCONFIG.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Cardconfig_Cancel

		//
		// GET: /Cards/Cardconfig_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CARDCONFIG]/
		public ActionResult Cardconfig_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cards(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cards");

// USE /[MANUAL GQT BEFORE_CANCEL CARDCONFIG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CARDCONFIG]/

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


		// POST: /Cards/Cardconfig_SaveEdit
		[HttpPost]
		public ActionResult Cardconfig_SaveEdit([FromBody] Cardconfig_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Cardconfig_SaveEdit",
				ViewName = "Cardconfig",
				AreaName = "cards",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CARDCONFIG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CARDCONFIG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CardconfigDocumValidateTickets : RequestDocumValidateTickets
		{
			public Cardconfig_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCardconfig([FromBody] CardconfigDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
