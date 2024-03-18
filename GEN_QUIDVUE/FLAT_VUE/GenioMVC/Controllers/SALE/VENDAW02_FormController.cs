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

		private static readonly NavigationLocation ACTION_VENDAW02_CANCEL = new NavigationLocation("QUALIFICACAO07026", "Vendaw02_Cancel", "Sale") { vueRouteName = "form-VENDAW02", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW02_SHOW = new NavigationLocation("QUALIFICACAO07026", "Vendaw02_Show", "Sale") { vueRouteName = "form-VENDAW02", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW02_NEW = new NavigationLocation("QUALIFICACAO07026", "Vendaw02_New", "Sale") { vueRouteName = "form-VENDAW02", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW02_EDIT = new NavigationLocation("QUALIFICACAO07026", "Vendaw02_Edit", "Sale") { vueRouteName = "form-VENDAW02", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW02_DUPLICATE = new NavigationLocation("QUALIFICACAO07026", "Vendaw02_Duplicate", "Sale") { vueRouteName = "form-VENDAW02", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW02_DELETE = new NavigationLocation("QUALIFICACAO07026", "Vendaw02_Delete", "Sale") { vueRouteName = "form-VENDAW02", mode = "DELETE" };

		#endregion

		#region Vendaw02 private

		private void FormHistoryLimits_Vendaw02()
		{

		}

		#endregion

		public ActionResult Vendaw02_ModalDBEdit()
		{
			Vendaw02_ViewModel model = new Vendaw02_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Vendaw02_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW02]/

		[HttpPost]
		public ActionResult Vendaw02_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW02_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw02();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW02]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw02_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_New_GET",
				AreaName = "sale",
				FormName = "VENDAW02",
				Location = ACTION_VENDAW02_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw02();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW02]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw02_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_New([FromBody]Vendaw02_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_New",
				ViewName = "Vendaw02",
				AreaName = "sale",
				Location = ACTION_VENDAW02_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW02]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW02]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW02]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw02_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW02",
				Location = ACTION_VENDAW02_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw02();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW02]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw02_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_Edit([FromBody]Vendaw02_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Edit",
				ViewName = "Vendaw02",
				AreaName = "sale",
				Location = ACTION_VENDAW02_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW02]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW02]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW02]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw02_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW02",
				Location = ACTION_VENDAW02_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw02();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW02]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw02_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw02_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Delete",
				ViewName = "Vendaw02",
				AreaName = "sale",
				Location = ACTION_VENDAW02_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW02]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw02_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW02");
		}

		#endregion

		#region Vendaw02_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW02]/

		[HttpPost]
		public ActionResult Vendaw02_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW02",
				Location = ACTION_VENDAW02_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW02]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw02_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW02]/
		[HttpPost]
		public ActionResult Vendaw02_Duplicate([FromBody]Vendaw02_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_Duplicate",
				ViewName = "Vendaw02",
				AreaName = "sale",
				Location = ACTION_VENDAW02_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW02]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW02]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW02]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw02_Cancel

		//
		// GET: /Sale/Vendaw02_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW02]/
		public ActionResult Vendaw02_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW02]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW02]/

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

		#region Vendaw02 Multiform actions

		//
		// GET /Sale/MFVendaw02_New
		[HttpGet]
		[ActionName("MFVendaw02_New")]
		public ActionResult MFVendaw02_New()
		{
			var model = new Vendaw02_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW02_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFVendaw02_New_GET()
		{
			return MFVendaw02_New();
		}

		//
		// GET /Sale/MFVendaw02_Edit
		[HttpGet]
		[ActionName("MFVendaw02_Edit")]
		public ActionResult MFVendaw02_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDAW02", "EDIT", new { id = id, partialView = "MFVendaw02", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVendaw02_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVendaw02_Edit(requestModel);
		}

		//
		// GET /Sale/MFVendaw02_Cancel
		[ActionName("MFVendaw02_Cancel")]
		public ActionResult MFVendaw02_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Sale/MFVendaw02_Save
		[HttpPost]
		[ActionName("MFVendaw02_Save")]
		public JsonResult MFVendaw02_Save(Vendaw02_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw02_Save",
				ViewName = "MFVendaw02",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw02_Delete
		[HttpPost]
		[ActionName("MFVendaw02_Delete")]
		public JsonResult MFVendaw02_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw02_Delete",
				ViewName = "MFVendaw02",
				AreaName = "sale",
				Location = ACTION_VENDAW02_EDIT
			};

			var model = new Vendaw02_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Sale/Vendaw02_SaveEdit
		[HttpPost]
		public ActionResult Vendaw02_SaveEdit([FromBody]Vendaw02_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw02_SaveEdit",
				ViewName = "Vendaw02",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW02]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
