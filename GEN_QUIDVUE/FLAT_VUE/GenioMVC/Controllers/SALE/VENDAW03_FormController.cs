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

		private static readonly NavigationLocation ACTION_VENDAW03_CANCEL = new NavigationLocation("PRE_ABORDAGEM30870", "Vendaw03_Cancel", "Sale") { vueRouteName = "form-VENDAW03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW03_SHOW = new NavigationLocation("PRE_ABORDAGEM30870", "Vendaw03_Show", "Sale") { vueRouteName = "form-VENDAW03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW03_NEW = new NavigationLocation("PRE_ABORDAGEM30870", "Vendaw03_New", "Sale") { vueRouteName = "form-VENDAW03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW03_EDIT = new NavigationLocation("PRE_ABORDAGEM30870", "Vendaw03_Edit", "Sale") { vueRouteName = "form-VENDAW03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW03_DUPLICATE = new NavigationLocation("PRE_ABORDAGEM30870", "Vendaw03_Duplicate", "Sale") { vueRouteName = "form-VENDAW03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW03_DELETE = new NavigationLocation("PRE_ABORDAGEM30870", "Vendaw03_Delete", "Sale") { vueRouteName = "form-VENDAW03", mode = "DELETE" };

		#endregion

		#region Vendaw03 private

		private void FormHistoryLimits_Vendaw03()
		{

		}

		#endregion

		public ActionResult Vendaw03_ModalDBEdit()
		{
			Vendaw03_ViewModel model = new Vendaw03_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Vendaw03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW03]/

		[HttpPost]
		public ActionResult Vendaw03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_New_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_New([FromBody]Vendaw03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_New",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Edit([FromBody]Vendaw03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Edit",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Delete",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW03");
		}

		#endregion

		#region Vendaw03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW03]/

		[HttpPost]
		public ActionResult Vendaw03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Duplicate([FromBody]Vendaw03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Duplicate",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw03_Cancel

		//
		// GET: /Sale/Vendaw03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW03]/
		public ActionResult Vendaw03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW03]/

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

		#region Vendaw03 Multiform actions

		//
		// GET /Sale/MFVendaw03_New
		[HttpGet]
		[ActionName("MFVendaw03_New")]
		public ActionResult MFVendaw03_New()
		{
			var model = new Vendaw03_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW03_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFVendaw03_New_GET()
		{
			return MFVendaw03_New();
		}

		//
		// GET /Sale/MFVendaw03_Edit
		[HttpGet]
		[ActionName("MFVendaw03_Edit")]
		public ActionResult MFVendaw03_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDAW03", "EDIT", new { id = id, partialView = "MFVendaw03", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVendaw03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVendaw03_Edit(requestModel);
		}

		//
		// GET /Sale/MFVendaw03_Cancel
		[ActionName("MFVendaw03_Cancel")]
		public ActionResult MFVendaw03_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Sale/MFVendaw03_Save
		[HttpPost]
		[ActionName("MFVendaw03_Save")]
		public JsonResult MFVendaw03_Save(Vendaw03_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw03_Save",
				ViewName = "MFVendaw03",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw03_Delete
		[HttpPost]
		[ActionName("MFVendaw03_Delete")]
		public JsonResult MFVendaw03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw03_Delete",
				ViewName = "MFVendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_EDIT
			};

			var model = new Vendaw03_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Sale/Vendaw03_SaveEdit
		[HttpPost]
		public ActionResult Vendaw03_SaveEdit([FromBody]Vendaw03_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_SaveEdit",
				ViewName = "Vendaw03",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
