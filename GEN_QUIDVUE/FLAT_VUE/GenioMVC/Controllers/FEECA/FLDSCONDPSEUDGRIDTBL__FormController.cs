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
using GenioMVC.ViewModels.Feeca;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FEECA]/

namespace GenioMVC.Controllers
{
	public partial class FeecaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__CANCEL = new("CANCELAR49513", "Fldscondpseudgridtbl__Cancel", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__SHOW = new("CONSULTA40695", "Fldscondpseudgridtbl__Show", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__NEW = new("INSERIR43365", "Fldscondpseudgridtbl__New", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__EDIT = new("EDITAR11616", "Fldscondpseudgridtbl__Edit", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE = new("DUPLICAR09748", "Fldscondpseudgridtbl__Duplicate", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__DELETE = new("APAGAR04097", "Fldscondpseudgridtbl__Delete", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "DELETE" };

		#endregion

		#region Fldscondpseudgridtbl_ private

		private void FormHistoryLimits_Fldscondpseudgridtbl_()
		{

		}

		#endregion

		#region Fldscondpseudgridtbl__Show

// USE /[MANUAL GQT CONTROLLER_SHOW FLDSCONDPSEUDGRIDTBL_]/

		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscondpseudgridtbl__ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Show_GET",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldscondpseudgridtbl_();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Fldscondpseudgridtbl__New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Fldscondpseudgridtbl__ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__New_GET",
				AreaName = "feeca",
				FormName = "FLDSCONDPSEUDGRIDTBL_",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Fldscondpseudgridtbl_();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Feeca/Fldscondpseudgridtbl__New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__New([FromBody]Fldscondpseudgridtbl__ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__New",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FLDSCONDPSEUDGRIDTBL_]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Fldscondpseudgridtbl__Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscondpseudgridtbl__ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Edit_GET",
				AreaName = "feeca",
				FormName = "FLDSCONDPSEUDGRIDTBL_",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldscondpseudgridtbl_();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Feeca/Fldscondpseudgridtbl__Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Edit([FromBody]Fldscondpseudgridtbl__ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Edit",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Fldscondpseudgridtbl__Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscondpseudgridtbl__ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Delete_GET",
				AreaName = "feeca",
				FormName = "FLDSCONDPSEUDGRIDTBL_",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldscondpseudgridtbl_();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Feeca/Fldscondpseudgridtbl__Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscondpseudgridtbl__ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Delete",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Fldscondpseudgridtbl__Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSCONDPSEUDGRIDTBL_");
		}

		#endregion

		#region Fldscondpseudgridtbl__Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FLDSCONDPSEUDGRIDTBL_]/

		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Fldscondpseudgridtbl__ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Duplicate_GET",
				AreaName = "feeca",
				FormName = "FLDSCONDPSEUDGRIDTBL_",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Feeca/Fldscondpseudgridtbl__Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FLDSCONDPSEUDGRIDTBL_]/
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__Duplicate([FromBody]Fldscondpseudgridtbl__ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Duplicate",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Fldscondpseudgridtbl__Cancel

		//
		// GET: /Feeca/Fldscondpseudgridtbl__Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FLDSCONDPSEUDGRIDTBL_]/
		public ActionResult Fldscondpseudgridtbl__Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Feeca(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");

// USE /[MANUAL GQT BEFORE_CANCEL FLDSCONDPSEUDGRIDTBL_]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FLDSCONDPSEUDGRIDTBL_]/

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

				Navigation.SetValue("ForcePrimaryRead_feeca", "true", true);
			}

			Navigation.ClearValue("feeca");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Feeca/Fldscondpseudgridtbl__SaveEdit
		[HttpPost]
		public ActionResult Fldscondpseudgridtbl__SaveEdit([FromBody]Fldscondpseudgridtbl__ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__SaveEdit",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
