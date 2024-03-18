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

		private static readonly NavigationLocation ACTION_VENDA_CANCEL = new NavigationLocation("SALE02786", "Venda_Cancel", "Sale") { vueRouteName = "form-VENDA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDA_SHOW = new NavigationLocation("SALE02786", "Venda_Show", "Sale") { vueRouteName = "form-VENDA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDA_NEW = new NavigationLocation("SALE02786", "Venda_New", "Sale") { vueRouteName = "form-VENDA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDA_EDIT = new NavigationLocation("SALE02786", "Venda_Edit", "Sale") { vueRouteName = "form-VENDA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDA_DUPLICATE = new NavigationLocation("SALE02786", "Venda_Duplicate", "Sale") { vueRouteName = "form-VENDA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDA_DELETE = new NavigationLocation("SALE02786", "Venda_Delete", "Sale") { vueRouteName = "form-VENDA", mode = "DELETE" };

		#endregion

		#region Venda private

		private void FormHistoryLimits_Venda()
		{

		}

		#endregion

		public ActionResult Venda_ModalDBEdit()
		{
			Venda_ViewModel model = new Venda_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Venda_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDA]/

		[HttpPost]
		public ActionResult Venda_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Venda_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDA]/
		[HttpPost]
		public ActionResult Venda_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_New_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Venda_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_New([FromBody]Venda_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_New",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Venda_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDA]/
		[HttpPost]
		public ActionResult Venda_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Edit_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Venda_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_Edit([FromBody]Venda_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Edit",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Venda_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDA]/
		[HttpPost]
		public ActionResult Venda_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Delete_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Venda_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Venda_Delete",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Venda_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDA");
		}

		#endregion

		#region Venda_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDA]/

		[HttpPost]
		public ActionResult Venda_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Venda_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_Duplicate([FromBody]Venda_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Duplicate",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Venda_Cancel

		//
		// GET: /Sale/Venda_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDA]/
		public ActionResult Venda_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDA]/

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

		#region Venda Multiform actions

		//
		// GET /Sale/MFVenda_New
		[HttpGet]
		[ActionName("MFVenda_New")]
		public ActionResult MFVenda_New()
		{
			var model = new Venda_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDA_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFVenda_New_GET()
		{
			return MFVenda_New();
		}

		//
		// GET /Sale/MFVenda_Edit
		[HttpGet]
		[ActionName("MFVenda_Edit")]
		public ActionResult MFVenda_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDA", "EDIT", new { id = id, partialView = "MFVenda", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVenda_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVenda_Edit(requestModel);
		}

		//
		// GET /Sale/MFVenda_Cancel
		[ActionName("MFVenda_Cancel")]
		public ActionResult MFVenda_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Sale/MFVenda_Save
		[HttpPost]
		[ActionName("MFVenda_Save")]
		public JsonResult MFVenda_Save(Venda_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVenda_Save",
				ViewName = "MFVenda",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVenda_Delete
		[HttpPost]
		[ActionName("MFVenda_Delete")]
		public JsonResult MFVenda_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVenda_Delete",
				ViewName = "MFVenda",
				AreaName = "sale",
				Location = ACTION_VENDA_EDIT
			};

			var model = new Venda_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Sale/Venda_OrganValOrganiza
		// POST: /Sale/Venda_OrganValOrganiza
		[ActionName("Venda_OrganValOrganiza")]
		public ActionResult Venda_OrganValOrganiza([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_organ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_organ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Venda_OrganValOrganiza_ViewModel model = new Venda_OrganValOrganiza_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodvenda = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Sale/Venda_SaveEdit
		[HttpPost]
		public ActionResult Venda_SaveEdit([FromBody]Venda_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_SaveEdit",
				ViewName = "Venda",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
