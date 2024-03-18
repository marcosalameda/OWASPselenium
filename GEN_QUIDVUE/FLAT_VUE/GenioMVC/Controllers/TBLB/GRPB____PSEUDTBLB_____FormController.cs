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
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Tblb;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLB]/

namespace GenioMVC.Controllers
{
	public partial class TblbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____CANCEL = new NavigationLocation("CANCELAR49513", "Grpb____pseudtblb_____Cancel", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____SHOW = new NavigationLocation("CONSULTA40695", "Grpb____pseudtblb_____Show", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____NEW = new NavigationLocation("INSERIR43365", "Grpb____pseudtblb_____New", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____EDIT = new NavigationLocation("EDITAR11616", "Grpb____pseudtblb_____Edit", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____DUPLICATE = new NavigationLocation("DUPLICAR09748", "Grpb____pseudtblb_____Duplicate", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____DELETE = new NavigationLocation("APAGAR04097", "Grpb____pseudtblb_____Delete", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "DELETE" };

		#endregion

		#region Grpb____pseudtblb____ private

		private void FormHistoryLimits_Grpb____pseudtblb____()
		{

		}

		#endregion

		public ActionResult Grpb____pseudtblb_____ModalDBEdit()
		{
			Grpb____pseudtblb_____ViewModel model = new Grpb____pseudtblb_____ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Grpb____pseudtblb_____Show

// USE /[MANUAL GQT CONTROLLER_SHOW GRPB____PSEUDTBLB____]/

		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Show_GET",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Grpb____pseudtblb_____New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____New_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____New([FromBody]Grpb____pseudtblb_____ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____New",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Grpb____pseudtblb_____Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Edit_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Edit([FromBody]Grpb____pseudtblb_____ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Edit",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Grpb____pseudtblb_____Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Delete_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Grpb____pseudtblb_____ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Delete",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Grpb____pseudtblb_____Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB____PSEUDTBLB____");
		}

		#endregion

		#region Grpb____pseudtblb_____Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GRPB____PSEUDTBLB____]/

		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Duplicate_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Duplicate([FromBody]Grpb____pseudtblb_____ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Duplicate",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Grpb____pseudtblb_____Cancel

		//
		// GET: /Tblb/Grpb____pseudtblb_____Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GRPB____PSEUDTBLB____]/
		public ActionResult Grpb____pseudtblb_____Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tblb(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");

// USE /[MANUAL GQT BEFORE_CANCEL GRPB____PSEUDTBLB____]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GRPB____PSEUDTBLB____]/

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

				Navigation.SetValue("ForcePrimaryRead_tblb", "true", true);
			}

			Navigation.ClearValue("tblb");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Grpb____pseudtblb____ Multiform actions

		//
		// GET /Tblb/MFGrpb____pseudtblb_____New
		[HttpGet]
		[ActionName("MFGrpb____pseudtblb_____New")]
		public ActionResult MFGrpb____pseudtblb_____New()
		{
			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_GRPB____PSEUDTBLB_____NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("tblb", model.ValCodtblb);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return JsonOK(model);
		}

		[HttpPost]
		public ActionResult MFGrpb____pseudtblb_____New_GET()
		{
			return MFGrpb____pseudtblb_____New();
		}

		//
		// GET /Tblb/MFGrpb____pseudtblb_____Edit
		[HttpGet]
		[ActionName("MFGrpb____pseudtblb_____Edit")]
		public ActionResult MFGrpb____pseudtblb_____Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("GRPB____PSEUDTBLB____", "EDIT", new { id = id, partialView = "MFGrpb____pseudtblb____", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFGrpb____pseudtblb_____Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFGrpb____pseudtblb_____Edit(requestModel);
		}

		//
		// GET /Tblb/MFGrpb____pseudtblb_____Cancel
		[ActionName("MFGrpb____pseudtblb_____Cancel")]
		public ActionResult MFGrpb____pseudtblb_____Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Tblb(UserContext.Current);
				model.klass.QPrimaryKey = id;

				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
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

			return JsonOK(new { Success = true });
		}

		//
		// POST /Tblb/MFGrpb____pseudtblb_____Save
		[HttpPost]
		[ActionName("MFGrpb____pseudtblb_____Save")]
		public JsonResult MFGrpb____pseudtblb_____Save(Grpb____pseudtblb_____ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGrpb____pseudtblb_____Save",
				ViewName = "MFGrpb____pseudtblb____",
				AreaName = "tblb"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Tblb/MFGrpb____pseudtblb_____Delete
		[HttpPost]
		[ActionName("MFGrpb____pseudtblb_____Delete")]
		public JsonResult MFGrpb____pseudtblb_____Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFGrpb____pseudtblb_____Delete",
				ViewName = "MFGrpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT
			};

			var model = new Grpb____pseudtblb_____ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Tblb/Grpb____pseudtblb_____SaveEdit
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____SaveEdit([FromBody]Grpb____pseudtblb_____ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____SaveEdit",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
