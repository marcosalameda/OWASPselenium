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

		private static readonly NavigationLocation ACTION_VENDAW01_CANCEL = new NavigationLocation("PROSPECCAO46919", "Vendaw01_Cancel", "Sale") { vueRouteName = "form-VENDAW01", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW01_SHOW = new NavigationLocation("PROSPECCAO46919", "Vendaw01_Show", "Sale") { vueRouteName = "form-VENDAW01", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW01_NEW = new NavigationLocation("PROSPECCAO46919", "Vendaw01_New", "Sale") { vueRouteName = "form-VENDAW01", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW01_EDIT = new NavigationLocation("PROSPECCAO46919", "Vendaw01_Edit", "Sale") { vueRouteName = "form-VENDAW01", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW01_DUPLICATE = new NavigationLocation("PROSPECCAO46919", "Vendaw01_Duplicate", "Sale") { vueRouteName = "form-VENDAW01", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW01_DELETE = new NavigationLocation("PROSPECCAO46919", "Vendaw01_Delete", "Sale") { vueRouteName = "form-VENDAW01", mode = "DELETE" };

		#endregion

		#region Vendaw01 private

		private void FormHistoryLimits_Vendaw01()
		{

		}

		#endregion

		public ActionResult Vendaw01_ModalDBEdit()
		{
			Vendaw01_ViewModel model = new Vendaw01_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Vendaw01_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW01]/

		[HttpPost]
		public ActionResult Vendaw01_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW01_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw01();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW01]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw01_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_New_GET",
				AreaName = "sale",
				FormName = "VENDAW01",
				Location = ACTION_VENDAW01_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw01();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW01]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw01_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_New([FromBody]Vendaw01_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_New",
				ViewName = "Vendaw01",
				AreaName = "sale",
				Location = ACTION_VENDAW01_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW01]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW01]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW01]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw01_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW01",
				Location = ACTION_VENDAW01_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw01();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW01]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw01_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_Edit([FromBody]Vendaw01_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Edit",
				ViewName = "Vendaw01",
				AreaName = "sale",
				Location = ACTION_VENDAW01_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW01]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW01]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW01]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw01_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW01",
				Location = ACTION_VENDAW01_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw01();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW01]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw01_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw01_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Delete",
				ViewName = "Vendaw01",
				AreaName = "sale",
				Location = ACTION_VENDAW01_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW01]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw01_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW01");
		}

		#endregion

		#region Vendaw01_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW01]/

		[HttpPost]
		public ActionResult Vendaw01_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW01",
				Location = ACTION_VENDAW01_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW01]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw01_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW01]/
		[HttpPost]
		public ActionResult Vendaw01_Duplicate([FromBody]Vendaw01_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_Duplicate",
				ViewName = "Vendaw01",
				AreaName = "sale",
				Location = ACTION_VENDAW01_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW01]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW01]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW01]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw01_Cancel

		//
		// GET: /Sale/Vendaw01_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW01]/
		public ActionResult Vendaw01_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW01]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW01]/

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

		#region Vendaw01 Multiform actions

		//
		// GET /Sale/MFVendaw01_New
		[HttpGet]
		[ActionName("MFVendaw01_New")]
		public ActionResult MFVendaw01_New()
		{
			var model = new Vendaw01_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW01_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFVendaw01_New_GET()
		{
			return MFVendaw01_New();
		}

		//
		// GET /Sale/MFVendaw01_Edit
		[HttpGet]
		[ActionName("MFVendaw01_Edit")]
		public ActionResult MFVendaw01_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("VENDAW01", "EDIT", new { id = id, partialView = "MFVendaw01", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFVendaw01_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFVendaw01_Edit(requestModel);
		}

		//
		// GET /Sale/MFVendaw01_Cancel
		[ActionName("MFVendaw01_Cancel")]
		public ActionResult MFVendaw01_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Sale/MFVendaw01_Save
		[HttpPost]
		[ActionName("MFVendaw01_Save")]
		public JsonResult MFVendaw01_Save(Vendaw01_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw01_Save",
				ViewName = "MFVendaw01",
				AreaName = "sale"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw01_Delete
		[HttpPost]
		[ActionName("MFVendaw01_Delete")]
		public JsonResult MFVendaw01_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw01_Delete",
				ViewName = "MFVendaw01",
				AreaName = "sale",
				Location = ACTION_VENDAW01_EDIT
			};

			var model = new Vendaw01_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Sale/Vendaw01_OrganValOrganiza
		// POST: /Sale/Vendaw01_OrganValOrganiza
		[ActionName("Vendaw01_OrganValOrganiza")]
		public ActionResult Vendaw01_OrganValOrganiza([FromBody]RequestLookupModel requestModel)
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
			Vendaw01_OrganValOrganiza_ViewModel model = new Vendaw01_OrganValOrganiza_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodvenda = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Sale/Vendaw01_SaveEdit
		[HttpPost]
		public ActionResult Vendaw01_SaveEdit([FromBody]Vendaw01_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw01_SaveEdit",
				ViewName = "Vendaw01",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW01]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
