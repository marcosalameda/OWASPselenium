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
using GenioMVC.ViewModels.Wpess;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WPESS]/

namespace GenioMVC.Controllers
{
	public partial class WpessController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_IMGMAGN_CANCEL = new("IMAGE_MAGNIFIER35311", "Imgmagn_Cancel", "Wpess") { vueRouteName = "form-IMGMAGN", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_IMGMAGN_SHOW = new("IMAGE_MAGNIFIER35311", "Imgmagn_Show", "Wpess") { vueRouteName = "form-IMGMAGN", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_IMGMAGN_NEW = new("IMAGE_MAGNIFIER35311", "Imgmagn_New", "Wpess") { vueRouteName = "form-IMGMAGN", mode = "NEW" };
		private static readonly NavigationLocation ACTION_IMGMAGN_EDIT = new("IMAGE_MAGNIFIER35311", "Imgmagn_Edit", "Wpess") { vueRouteName = "form-IMGMAGN", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_IMGMAGN_DUPLICATE = new("IMAGE_MAGNIFIER35311", "Imgmagn_Duplicate", "Wpess") { vueRouteName = "form-IMGMAGN", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_IMGMAGN_DELETE = new("IMAGE_MAGNIFIER35311", "Imgmagn_Delete", "Wpess") { vueRouteName = "form-IMGMAGN", mode = "DELETE" };

		#endregion

		#region Imgmagn private

		private void FormHistoryLimits_Imgmagn()
		{

		}

		#endregion

		#region Imgmagn_Show

// USE /[MANUAL GQT CONTROLLER_SHOW IMGMAGN]/

		[HttpPost]
		public ActionResult Imgmagn_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Imgmagn_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Show_GET",
				AreaName = "wpess",
				Location = ACTION_IMGMAGN_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Imgmagn();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW IMGMAGN]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Imgmagn_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Imgmagn_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_New_GET",
				AreaName = "wpess",
				FormName = "IMGMAGN",
				Location = ACTION_IMGMAGN_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Imgmagn();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW IMGMAGN]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wpess/Imgmagn_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_New([FromBody]Imgmagn_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_New",
				ViewName = "Imgmagn",
				AreaName = "wpess",
				Location = ACTION_IMGMAGN_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW IMGMAGN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX IMGMAGN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX IMGMAGN]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Imgmagn_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Imgmagn_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Edit_GET",
				AreaName = "wpess",
				FormName = "IMGMAGN",
				Location = ACTION_IMGMAGN_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Imgmagn();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT IMGMAGN]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wpess/Imgmagn_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_Edit([FromBody]Imgmagn_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Edit",
				ViewName = "Imgmagn",
				AreaName = "wpess",
				Location = ACTION_IMGMAGN_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT IMGMAGN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX IMGMAGN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX IMGMAGN]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Imgmagn_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Imgmagn_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Delete_GET",
				AreaName = "wpess",
				FormName = "IMGMAGN",
				Location = ACTION_IMGMAGN_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Imgmagn();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE IMGMAGN]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wpess/Imgmagn_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Imgmagn_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Delete",
				ViewName = "Imgmagn",
				AreaName = "wpess",
				Location = ACTION_IMGMAGN_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE IMGMAGN]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Imgmagn_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("IMGMAGN");
		}

		#endregion

		#region Imgmagn_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET IMGMAGN]/

		[HttpPost]
		public ActionResult Imgmagn_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Imgmagn_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Duplicate_GET",
				AreaName = "wpess",
				FormName = "IMGMAGN",
				Location = ACTION_IMGMAGN_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE IMGMAGN]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wpess/Imgmagn_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST IMGMAGN]/
		[HttpPost]
		public ActionResult Imgmagn_Duplicate([FromBody]Imgmagn_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_Duplicate",
				ViewName = "Imgmagn",
				AreaName = "wpess",
				Location = ACTION_IMGMAGN_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE IMGMAGN]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX IMGMAGN]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX IMGMAGN]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Imgmagn_Cancel

		//
		// GET: /Wpess/Imgmagn_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET IMGMAGN]/
		public ActionResult Imgmagn_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wpess(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wpess");

// USE /[MANUAL GQT BEFORE_CANCEL IMGMAGN]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL IMGMAGN]/

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

				Navigation.SetValue("ForcePrimaryRead_wpess", "true", true);
			}

			Navigation.ClearValue("wpess");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Wpess/Imgmagn_SaveEdit
		[HttpPost]
		public ActionResult Imgmagn_SaveEdit([FromBody]Imgmagn_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Imgmagn_SaveEdit",
				ViewName = "Imgmagn",
				AreaName = "wpess",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT IMGMAGN]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT IMGMAGN]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
