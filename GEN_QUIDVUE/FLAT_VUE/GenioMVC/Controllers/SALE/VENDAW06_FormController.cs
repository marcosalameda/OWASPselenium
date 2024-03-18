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

		private static readonly NavigationLocation ACTION_VENDAW06_CANCEL = new NavigationLocation("SUPERAR_OBJECOES02243", "Vendaw06_Cancel", "Sale") { vueRouteName = "form-VENDAW06", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW06_SHOW = new NavigationLocation("SUPERAR_OBJECOES02243", "Vendaw06_Show", "Sale") { vueRouteName = "form-VENDAW06", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW06_NEW = new NavigationLocation("SUPERAR_OBJECOES02243", "Vendaw06_New", "Sale") { vueRouteName = "form-VENDAW06", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW06_EDIT = new NavigationLocation("SUPERAR_OBJECOES02243", "Vendaw06_Edit", "Sale") { vueRouteName = "form-VENDAW06", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW06_DUPLICATE = new NavigationLocation("SUPERAR_OBJECOES02243", "Vendaw06_Duplicate", "Sale") { vueRouteName = "form-VENDAW06", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW06_DELETE = new NavigationLocation("SUPERAR_OBJECOES02243", "Vendaw06_Delete", "Sale") { vueRouteName = "form-VENDAW06", mode = "DELETE" };

		#endregion

		#region Vendaw06 private

		private void FormHistoryLimits_Vendaw06()
		{

		}

		#endregion

		public ActionResult Vendaw06_ModalDBEdit()
		{
			Vendaw06_ViewModel model = new Vendaw06_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Vendaw06_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW06]/

		[HttpPost]
		public ActionResult Vendaw06_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW06_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW06]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw06_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_New_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW06]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw06_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_New([FromBody]Vendaw06_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_New",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW06]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw06_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW06]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw06_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Edit([FromBody]Vendaw06_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Edit",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW06]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw06_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW06]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw06_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Delete",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW06]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw06_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW06");
		}

		#endregion

		#region Vendaw06_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW06]/

		[HttpPost]
		public ActionResult Vendaw06_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW06]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw06_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Duplicate([FromBody]Vendaw06_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Duplicate",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW06]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw06_Cancel

		//
		// GET: /Sale/Vendaw06_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW06]/
		public ActionResult Vendaw06_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW06]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW06]/

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

		#region Vendaw06 Multiform actions

		//
		// GET /Sale/MFVendaw06_New
		[HttpGet]
		[ActionName("MFVendaw06_New")]
		public ActionResult MFVendaw06_New()
		{
			var model = new Vendaw06_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW06_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFVendaw06_New_GET()
		{
			return MFVendaw06_New();
		}

		//
		// GET /Sale/MFVendaw06_Edit
		[HttpGet]
		[ActionName("MFVendaw06_Edit")]
		public ActionResult MFVendaw06_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDAW06", "EDIT", new { id = id, partialView = "MFVendaw06", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVendaw06_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVendaw06_Edit(requestModel);
		}

		//
		// GET /Sale/MFVendaw06_Cancel
		[ActionName("MFVendaw06_Cancel")]
		public ActionResult MFVendaw06_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Sale/MFVendaw06_Save
		[HttpPost]
		[ActionName("MFVendaw06_Save")]
		public JsonResult MFVendaw06_Save(Vendaw06_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw06_Save",
				ViewName = "MFVendaw06",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw06_Delete
		[HttpPost]
		[ActionName("MFVendaw06_Delete")]
		public JsonResult MFVendaw06_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw06_Delete",
				ViewName = "MFVendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_EDIT
			};

			var model = new Vendaw06_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Sale/Vendaw06_SaveEdit
		[HttpPost]
		public ActionResult Vendaw06_SaveEdit([FromBody]Vendaw06_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_SaveEdit",
				ViewName = "Vendaw06",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW06]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
