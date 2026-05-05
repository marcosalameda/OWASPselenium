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
using GenioMVC.ViewModels.Herodescrip;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER HERODESCRIP]/

namespace GenioMVC.Controllers
{
	public partial class HerodescripController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_HEROCSEC_CANCEL = new("CALLOUT_HERO_SECTION42962", "Herocsec_Cancel", "Herodescrip") { vueRouteName = "form-HEROCSEC", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_HEROCSEC_SHOW = new("CALLOUT_HERO_SECTION42962", "Herocsec_Show", "Herodescrip") { vueRouteName = "form-HEROCSEC", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_HEROCSEC_NEW = new("CALLOUT_HERO_SECTION42962", "Herocsec_New", "Herodescrip") { vueRouteName = "form-HEROCSEC", mode = "NEW" };
		private static readonly NavigationLocation ACTION_HEROCSEC_EDIT = new("CALLOUT_HERO_SECTION42962", "Herocsec_Edit", "Herodescrip") { vueRouteName = "form-HEROCSEC", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_HEROCSEC_DUPLICATE = new("CALLOUT_HERO_SECTION42962", "Herocsec_Duplicate", "Herodescrip") { vueRouteName = "form-HEROCSEC", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_HEROCSEC_DELETE = new("CALLOUT_HERO_SECTION42962", "Herocsec_Delete", "Herodescrip") { vueRouteName = "form-HEROCSEC", mode = "DELETE" };

		#endregion

		#region Herocsec private

		private void FormHistoryLimits_Herocsec()
		{

		}

		#endregion

		#region Herocsec_Show

// USE /[MANUAL GQT CONTROLLER_SHOW HEROCSEC]/

		[HttpPost]
		public ActionResult Herocsec_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Herocsec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Show_GET",
				AreaName = "herodescrip",
				Location = ACTION_HEROCSEC_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Herocsec();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Herocsec_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Herocsec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_New_GET",
				AreaName = "herodescrip",
				FormName = "HEROCSEC",
				Location = ACTION_HEROCSEC_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Herocsec();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Herodescrip/Herocsec_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_New([FromBody]Herocsec_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_New",
				ViewName = "Herocsec",
				AreaName = "herodescrip",
				Location = ACTION_HEROCSEC_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW HEROCSEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX HEROCSEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Herocsec_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Herocsec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Edit_GET",
				AreaName = "herodescrip",
				FormName = "HEROCSEC",
				Location = ACTION_HEROCSEC_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Herocsec();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Herodescrip/Herocsec_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_Edit([FromBody]Herocsec_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Edit",
				ViewName = "Herocsec",
				AreaName = "herodescrip",
				Location = ACTION_HEROCSEC_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT HEROCSEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX HEROCSEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Herocsec_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Herocsec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Delete_GET",
				AreaName = "herodescrip",
				FormName = "HEROCSEC",
				Location = ACTION_HEROCSEC_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Herocsec();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Herodescrip/Herocsec_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Herocsec_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Delete",
				ViewName = "Herocsec",
				AreaName = "herodescrip",
				Location = ACTION_HEROCSEC_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Herocsec_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("HEROCSEC");
		}

		#endregion

		#region Herocsec_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET HEROCSEC]/

		[HttpPost]
		public ActionResult Herocsec_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Herocsec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Duplicate_GET",
				AreaName = "herodescrip",
				FormName = "HEROCSEC",
				Location = ACTION_HEROCSEC_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Herodescrip/Herocsec_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST HEROCSEC]/
		[HttpPost]
		public ActionResult Herocsec_Duplicate([FromBody]Herocsec_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Herocsec_Duplicate",
				ViewName = "Herocsec",
				AreaName = "herodescrip",
				Location = ACTION_HEROCSEC_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE HEROCSEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX HEROCSEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX HEROCSEC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "HEROCSEC.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Herocsec_Cancel

		//
		// GET: /Herodescrip/Herocsec_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET HEROCSEC]/
		public ActionResult Herocsec_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Herodescrip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("herodescrip");

// USE /[MANUAL GQT BEFORE_CANCEL HEROCSEC]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL HEROCSEC]/

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

				Navigation.SetValue("ForcePrimaryRead_herodescrip", "true", true);
			}

			Navigation.ClearValue("herodescrip");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Herodescrip/Herocsec_SaveEdit
		[HttpPost]
		public ActionResult Herocsec_SaveEdit([FromBody] Herocsec_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Herocsec_SaveEdit",
				ViewName = "Herocsec",
				AreaName = "herodescrip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT HEROCSEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT HEROCSEC]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class HerocsecDocumValidateTickets : RequestDocumValidateTickets
		{
			public Herocsec_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsHerocsec([FromBody] HerocsecDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
