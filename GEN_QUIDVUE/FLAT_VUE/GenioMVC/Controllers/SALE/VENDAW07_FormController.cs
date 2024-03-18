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

		private static readonly NavigationLocation ACTION_VENDAW07_CANCEL = new NavigationLocation("FECHO_DA_VENDA48081", "Vendaw07_Cancel", "Sale") { vueRouteName = "form-VENDAW07", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW07_SHOW = new NavigationLocation("FECHO_DA_VENDA48081", "Vendaw07_Show", "Sale") { vueRouteName = "form-VENDAW07", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW07_NEW = new NavigationLocation("FECHO_DA_VENDA48081", "Vendaw07_New", "Sale") { vueRouteName = "form-VENDAW07", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW07_EDIT = new NavigationLocation("FECHO_DA_VENDA48081", "Vendaw07_Edit", "Sale") { vueRouteName = "form-VENDAW07", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW07_DUPLICATE = new NavigationLocation("FECHO_DA_VENDA48081", "Vendaw07_Duplicate", "Sale") { vueRouteName = "form-VENDAW07", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW07_DELETE = new NavigationLocation("FECHO_DA_VENDA48081", "Vendaw07_Delete", "Sale") { vueRouteName = "form-VENDAW07", mode = "DELETE" };

		#endregion

		#region Vendaw07 private

		private void FormHistoryLimits_Vendaw07()
		{

		}

		#endregion

		public ActionResult Vendaw07_ModalDBEdit()
		{
			Vendaw07_ViewModel model = new Vendaw07_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Vendaw07_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW07]/

		[HttpPost]
		public ActionResult Vendaw07_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW07_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW07]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw07_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_New_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW07]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw07_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_New([FromBody]Vendaw07_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_New",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW07]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw07_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW07]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw07_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Edit([FromBody]Vendaw07_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Edit",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW07]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw07_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW07]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw07_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Delete",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW07]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw07_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW07");
		}

		#endregion

		#region Vendaw07_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW07]/

		[HttpPost]
		public ActionResult Vendaw07_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW07]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw07_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Duplicate([FromBody]Vendaw07_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Duplicate",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW07]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw07_Cancel

		//
		// GET: /Sale/Vendaw07_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW07]/
		public ActionResult Vendaw07_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW07]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW07]/

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

		#region Vendaw07 Multiform actions

		//
		// GET /Sale/MFVendaw07_New
		[HttpGet]
		[ActionName("MFVendaw07_New")]
		public ActionResult MFVendaw07_New()
		{
			var model = new Vendaw07_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW07_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFVendaw07_New_GET()
		{
			return MFVendaw07_New();
		}

		//
		// GET /Sale/MFVendaw07_Edit
		[HttpGet]
		[ActionName("MFVendaw07_Edit")]
		public ActionResult MFVendaw07_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDAW07", "EDIT", new { id = id, partialView = "MFVendaw07", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVendaw07_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVendaw07_Edit(requestModel);
		}

		//
		// GET /Sale/MFVendaw07_Cancel
		[ActionName("MFVendaw07_Cancel")]
		public ActionResult MFVendaw07_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Sale/MFVendaw07_Save
		[HttpPost]
		[ActionName("MFVendaw07_Save")]
		public JsonResult MFVendaw07_Save(Vendaw07_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw07_Save",
				ViewName = "MFVendaw07",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw07_Delete
		[HttpPost]
		[ActionName("MFVendaw07_Delete")]
		public JsonResult MFVendaw07_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw07_Delete",
				ViewName = "MFVendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_EDIT
			};

			var model = new Vendaw07_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Sale/Vendaw07_SaveEdit
		[HttpPost]
		public ActionResult Vendaw07_SaveEdit([FromBody]Vendaw07_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_SaveEdit",
				ViewName = "Vendaw07",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW07]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
