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
using GenioMVC.ViewModels.Perso;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PERSO]/

namespace GenioMVC.Controllers
{
	public partial class PersoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PERSO_CANCEL = new("PERSON10446", "Perso_Cancel", "Perso") { vueRouteName = "form-PERSO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PERSO_SHOW = new("PERSON10446", "Perso_Show", "Perso") { vueRouteName = "form-PERSO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PERSO_NEW = new("PERSON10446", "Perso_New", "Perso") { vueRouteName = "form-PERSO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PERSO_EDIT = new("PERSON10446", "Perso_Edit", "Perso") { vueRouteName = "form-PERSO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PERSO_DUPLICATE = new("PERSON10446", "Perso_Duplicate", "Perso") { vueRouteName = "form-PERSO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PERSO_DELETE = new("PERSON10446", "Perso_Delete", "Perso") { vueRouteName = "form-PERSO", mode = "DELETE" };

		#endregion

		#region Perso private

		private void FormHistoryLimits_Perso()
		{

		}

		#endregion

		#region Perso_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PERSO]/

		[HttpPost]
		public ActionResult Perso_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Perso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Perso_Show_GET",
				AreaName = "perso",
				Location = ACTION_PERSO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Perso();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PERSO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Perso_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PERSO]/
		[HttpPost]
		public ActionResult Perso_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Perso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Perso_New_GET",
				AreaName = "perso",
				FormName = "PERSO",
				Location = ACTION_PERSO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Perso();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PERSO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Perso/Perso_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PERSO]/
		[HttpPost]
		public ActionResult Perso_New([FromBody]Perso_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Perso_New",
				ViewName = "Perso",
				AreaName = "perso",
				Location = ACTION_PERSO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PERSO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PERSO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PERSO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Perso_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PERSO]/
		[HttpPost]
		public ActionResult Perso_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Perso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Perso_Edit_GET",
				AreaName = "perso",
				FormName = "PERSO",
				Location = ACTION_PERSO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Perso();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PERSO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Perso/Perso_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PERSO]/
		[HttpPost]
		public ActionResult Perso_Edit([FromBody]Perso_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Perso_Edit",
				ViewName = "Perso",
				AreaName = "perso",
				Location = ACTION_PERSO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PERSO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PERSO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PERSO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Perso_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PERSO]/
		[HttpPost]
		public ActionResult Perso_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Perso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Perso_Delete_GET",
				AreaName = "perso",
				FormName = "PERSO",
				Location = ACTION_PERSO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Perso();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PERSO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Perso/Perso_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PERSO]/
		[HttpPost]
		public ActionResult Perso_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Perso_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Perso_Delete",
				ViewName = "Perso",
				AreaName = "perso",
				Location = ACTION_PERSO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PERSO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Perso_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PERSO");
		}

		#endregion

		#region Perso_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PERSO]/

		[HttpPost]
		public ActionResult Perso_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Perso_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Perso_Duplicate_GET",
				AreaName = "perso",
				FormName = "PERSO",
				Location = ACTION_PERSO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PERSO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Perso/Perso_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PERSO]/
		[HttpPost]
		public ActionResult Perso_Duplicate([FromBody]Perso_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Perso_Duplicate",
				ViewName = "Perso",
				AreaName = "perso",
				Location = ACTION_PERSO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PERSO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PERSO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PERSO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Perso_Cancel

		//
		// GET: /Perso/Perso_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PERSO]/
		public ActionResult Perso_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Perso(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("perso");

// USE /[MANUAL GQT BEFORE_CANCEL PERSO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PERSO]/

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

				Navigation.SetValue("ForcePrimaryRead_perso", "true", true);
			}

			Navigation.ClearValue("perso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Perso/Perso_SaveEdit
		[HttpPost]
		public ActionResult Perso_SaveEdit([FromBody]Perso_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Perso_SaveEdit",
				ViewName = "Perso",
				AreaName = "perso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PERSO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PERSO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
