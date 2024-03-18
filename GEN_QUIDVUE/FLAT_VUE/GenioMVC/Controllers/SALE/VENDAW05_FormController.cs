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
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VENDAW05_CANCEL = new NavigationLocation("APRESENTACAO15975", "Vendaw05_Cancel", "Sale") { vueRouteName = "form-VENDAW05", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW05_SHOW = new NavigationLocation("APRESENTACAO15975", "Vendaw05_Show", "Sale") { vueRouteName = "form-VENDAW05", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW05_NEW = new NavigationLocation("APRESENTACAO15975", "Vendaw05_New", "Sale") { vueRouteName = "form-VENDAW05", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW05_EDIT = new NavigationLocation("APRESENTACAO15975", "Vendaw05_Edit", "Sale") { vueRouteName = "form-VENDAW05", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW05_DUPLICATE = new NavigationLocation("APRESENTACAO15975", "Vendaw05_Duplicate", "Sale") { vueRouteName = "form-VENDAW05", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW05_DELETE = new NavigationLocation("APRESENTACAO15975", "Vendaw05_Delete", "Sale") { vueRouteName = "form-VENDAW05", mode = "DELETE" };

		#endregion

		#region Vendaw05 private

		private void FormHistoryLimits_Vendaw05()
		{

		}

		#endregion

		public ActionResult Vendaw05_ModalDBEdit()
		{
			Vendaw05_ViewModel model = new Vendaw05_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Vendaw05_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW05]/

		[HttpPost]
		public ActionResult Vendaw05_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw05_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW05_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW05]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw05_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw05_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_New_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW05]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw05_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_New([FromBody]Vendaw05_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_New",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW05]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw05_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw05_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW05]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw05_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Edit([FromBody]Vendaw05_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Edit",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW05]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw05_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw05_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW05]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw05_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw05_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Delete",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW05]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw05_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW05");
		}

		#endregion

		#region Vendaw05_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW05]/

		[HttpPost]
		public ActionResult Vendaw05_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw05_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW05]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw05_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Duplicate([FromBody]Vendaw05_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_Duplicate",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW05]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw05_Cancel

		//
		// GET: /Sale/Vendaw05_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW05]/
		public ActionResult Vendaw05_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW05]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW05]/

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

				Navigation.SetValue("ForcePrimaryRead_sale", "true", true);
			}

			Navigation.ClearValue("sale");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Vendaw05 Multiform actions

		//
		// GET /Sale/MFVendaw05_New
		[HttpGet]
		[ActionName("MFVendaw05_New")]
		public ActionResult MFVendaw05_New()
		{
			var model = new Vendaw05_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW05_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("sale", model.ValCodvenda);

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
		public ActionResult MFVendaw05_New_GET()
		{
			return MFVendaw05_New();
		}

		//
		// GET /Sale/MFVendaw05_Edit
		[HttpGet]
		[ActionName("MFVendaw05_Edit")]
		public ActionResult MFVendaw05_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDAW05", "EDIT", new { id = id, partialView = "MFVendaw05", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVendaw05_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVendaw05_Edit(requestModel);
		}

		//
		// GET /Sale/MFVendaw05_Cancel
		[ActionName("MFVendaw05_Cancel")]
		public ActionResult MFVendaw05_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Sale(UserContext.Current);
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
		// POST /Sale/MFVendaw05_Save
		[HttpPost]
		[ActionName("MFVendaw05_Save")]
		public JsonResult MFVendaw05_Save(Vendaw05_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw05_Save",
				ViewName = "MFVendaw05",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw05_Delete
		[HttpPost]
		[ActionName("MFVendaw05_Delete")]
		public JsonResult MFVendaw05_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw05_Delete",
				ViewName = "MFVendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_EDIT
			};

			var model = new Vendaw05_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Sale/Vendaw05_SaveEdit
		[HttpPost]
		public ActionResult Vendaw05_SaveEdit([FromBody]Vendaw05_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw05_SaveEdit",
				ViewName = "Vendaw05",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW05]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
