using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Microsoft.Reporting.WebForms;

using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using CSGenio.reporting;
using Quidgest.Persistence.GenericQuery;

using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Resources;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Sale;


// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VENDAWV_CANCEL = new NavigationLocation("VERTICAL_WIZARD29412", "Vendawv_Cancel", "Sale") { vueRouteName = "form-VENDAWV", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAWV_SHOW = new NavigationLocation("VERTICAL_WIZARD29412", "Vendawv_Show", "Sale") { vueRouteName = "form-VENDAWV", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAWV_NEW = new NavigationLocation("VERTICAL_WIZARD29412", "Vendawv_New", "Sale") { vueRouteName = "form-VENDAWV", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAWV_EDIT = new NavigationLocation("VERTICAL_WIZARD29412", "Vendawv_Edit", "Sale") { vueRouteName = "form-VENDAWV", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAWV_DUPLICATE = new NavigationLocation("VERTICAL_WIZARD29412", "Vendawv_Duplicate", "Sale") { vueRouteName = "form-VENDAWV", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAWV_DELETE = new NavigationLocation("VERTICAL_WIZARD29412", "Vendawv_Delete", "Sale") { vueRouteName = "form-VENDAWV", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Vendawv(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("sale");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_VENDAWV_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_VENDAWV_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_VENDAWV_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_VENDAWV_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_VENDAWV_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Vendawv private

		private void FormHistoryLimits_Vendawv()
		{

		}

		#endregion

		#region Vendawv_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAWV]/
		//
		// GET: /Sale/Vendawv_Show
		[AuthorizeForUsers]
		public ActionResult Vendawv_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Vendawv_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				if (!Request.IsAjaxRequest())
					return View("_PermissionError", model: permission.Message);
				else
					return PartialView("_PermissionErrorExt", model: permission.Message);

			string partialView = qs["partialView"] ?? "Vendawv"; // MF send the patial view name

			var navigationLocationAction = ACTION_VENDAWV_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("sale"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("sale", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAWV]/

			try
			{
				model.Load(qs, true, Request.IsAjaxRequest(), true);
			}
			catch (ModelNotFoundException)
			{
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e) {
				//JFG 05-05-2017 This need to better handled, for now it's handled on webconfig's customErrors section.
				CSGenio.framework.Log.Error("Vendawv_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAWV]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Vendawv");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Vendawv", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Vendawv_New

		[ActionName("Vendawv_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendawv_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Vendawv_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAWV]/
		//
		// GET: /Sale/Vendawv_New
		[ActionName("Vendawv_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendawv_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Vendawv_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				if (!Request.IsAjaxRequest())
					return View("_PermissionError", model: permission.Message);
				else
					return PartialView("_PermissionErrorExt", model: permission.Message);

			string partialView = qs["partialView"] ?? "Vendawv";

			var navigationLocationAction = ACTION_VENDAWV_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("VENDAWV"))
				Navigation.OverrideSkipIfJustOne["VENDAWV"] = true;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				if (IsNewLocation(navigationLocationAction))
				{
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, nestedForm);
					CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

					if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
						Navigation.SetValue("repeatInsertion", true);

					sp.openTransaction();
					model.New();
					sp.closeTransaction();

					Navigation.SetValue("sale", model.ValCodvenda);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAWV]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAWV]/
					sp.closeConnection();
				}
				else
				{
					sp.openConnection();
					model.Load(qs, true, Request.IsAjaxRequest());
					sp.closeConnection();
				}
			}
			catch (ModelNotFoundException)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				ModelState.AddModelError("Erro", exceptionUserMessage);
				ErrorMessage(exceptionUserMessage);
				CSGenio.framework.Log.Error("Vendawv_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Vendawv", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Sale/Vendawv_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAWV]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendawv_New(Vendawv_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_New",
				ViewName = "Vendawv",
				AreaName = "sale",
				Location = ACTION_VENDAWV_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAWV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAWV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAWV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAWV]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendawv_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("sale", Convert.ToString(Navigation.CurrentLevel.GetEntry("sale"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_VENDAWV_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAWV");
		}

		#endregion

		#region Vendawv_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAWV]/
		//
		// GET: /Sale/Vendawv_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendawv_Edit")]
		public ActionResult Vendawv_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Vendawv"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_VENDAWV_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_VENDAWV_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("sale", id);

			var model = new Vendawv_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAWV]/
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openConnection();
				model.Load(qs, true, Request.IsAjaxRequest(), true);
				sp.closeConnection();
			}
			catch (ModelNotFoundException)
			{
				sp.closeConnection();
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e) {
				sp.closeConnection();
				//JFG 05-05-2017 This need to better handled, for now it's handled on webconfig's customErrors section.
				CSGenio.framework.Log.Error("Vendawv_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAWV]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Vendawv", model);
			}
			else
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView(partialView, model);
			}
		}


		//
		// POST: /Sale/Vendawv_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAWV]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendawv_Edit(Vendawv_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Edit",
				ViewName = "Vendawv",
				AreaName = "sale",
				Location = ACTION_VENDAWV_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAWV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAWV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAWV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAWV]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendawv_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("sale", Convert.ToString(Navigation.CurrentLevel.GetEntry("sale"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAWV");
		}


		#endregion

		#region Vendawv_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAWV]/
		//
		// GET: /Sale/Vendawv_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendawv_Delete")]
		public ActionResult Vendawv_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_VENDAWV_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("sale", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Vendawv_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAWV]/

			try
			{
				model.Load(qs, false, Request.IsAjaxRequest(), true);
			}
			catch (ModelNotFoundException)
			{
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e) {
				//JFG 05-05-2017 This need to better handled, for now it's handled on webconfig's customErrors section.
				CSGenio.framework.Log.Error("Vendawv_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAWV]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Vendawv", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Vendawv", model);
		}


		//
		// POST: /Sale/Vendawv_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAWV]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendawv_Delete(string id, FormCollection collection)
		{

			var model = new Vendawv_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Delete",
				ViewName = "Vendawv",
				AreaName = "sale",
				Location = ACTION_VENDAWV_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAWV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAWV]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendawv_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAWV");
		}

		#endregion

		#region Vendawv_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAWV]/
		//
		// GET: /Sale/Vendawv_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendawv_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Vendawv_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				if (!Request.IsAjaxRequest())
					return View("_PermissionError", model: permission.Message);
				else
					return PartialView("_PermissionErrorExt", model: permission.Message);

			var navigationLocationAction = ACTION_VENDAWV_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				if (IsNewLocation(navigationLocationAction))
				{
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Duplicate, nestedForm);
					CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

					sp.openTransaction();

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAWV]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAWV]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_VENDAWV_DUPLICATE.SetRoutedValues(new { Id = model.ValCodvenda }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("sale", model.ValCodvenda);
				}
				else
				{
					sp.openConnection();
					model.Load(qs, true, Request.IsAjaxRequest());
					sp.closeConnection();
				}
			}
			catch (ModelNotFoundException)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				ErrorMessage(exceptionUserMessage);
				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				Navigation.SetValue("sale", model.ValCodvenda);
				return View("Vendawv", model);
			}
			else
				return PartialView("Vendawv", model);
		}


		//
		// POST: /Sale/Vendawv_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAWV]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendawv_Duplicate(Vendawv_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Duplicate",
				ViewName = "Vendawv",
				AreaName = "sale",
				Location = ACTION_VENDAWV_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAWV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAWV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAWV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAWV]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendawv_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("sale", Convert.ToString(Navigation.CurrentLevel.GetEntry("sale"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAWV");
		}

		#endregion

		#region Vendawv_Cancel

		//
		// GET: /Sale/Vendawv_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAWV]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendawv_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale();
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAWV]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAWV]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

					ErrorMessage(exceptionUserMessage);

					//PG - Applies to the cancel button ("New" and "Duplicate" modes)
					return Json(new
					{
						Success = false,
						Operation = "Cancel",
						Location = Url.Action(
								Navigation.CurrentLevel.Location.Action,
								Navigation.CurrentLevel.Location.Controller,
								GetRouteValues(Navigation.CurrentLevel.Location)
							)
					}, JsonRequestBehavior.AllowGet);
				}

				Navigation.SetValue("ForcePrimaryRead_sale", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "sale";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("sale");
			if (Navigation.CurrentLevel.Location.Controller.ToUpper() == RouteData.Values["controller"].ToString().ToUpper()) Navigation.RemoveHistoryLevel();
			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//PG - Applies to the cancel button ("New", "Edit, "Duplicate", and "Delete" modes)
			if (Request.IsAjaxRequest())
				return Json(new
				{
					Success = true,
					Operation = "Cancel",
					Location = Url.Action(
						Navigation.CurrentLevel.Location.Action,
						Navigation.CurrentLevel.Location.Controller,
						GetRouteValues(Navigation.CurrentLevel.Location)
					)
				}, JsonRequestBehavior.AllowGet);

			//PG - Applies to the back button ("View" mode only)
			return RedirectToLocation(Navigation.CurrentLevel.Location);
		}

		#endregion

		#region Vendawv Multiform actions

		//
		// GET /Sale/MFVendawv_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVendawv_New")]
		public ActionResult MFVendawv_New()
		{
			var model = new Vendawv_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAWV_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
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

			return PartialView("MFVendawv", model);
		}

		//
		// GET /Sale/MFVendawv_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVendawv_Edit")]
		public ActionResult MFVendawv_Edit(string id)
		{
			return this.RedirectToAction("Vendawv_Edit", "Sale", new { id = id, partialView = "MFVendawv", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Sale/MFVendawv_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVendawv_Cancel")]
		public ActionResult MFVendawv_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_VENDAWV_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_VENDAWV_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Sale();
						model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

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

						Log.Error("MFVendawv_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Vendawv_Show", "Sale", new { id = id, partialView = "MFVendawv", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Sale/MFVendawv_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFVendawv_Save")]
		public JsonResult MFVendawv_Save(Vendawv_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendawv_Save",
				ViewName = "MFVendawv",
				AreaName = "sale"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendawv_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFVendawv_Delete")]
		public JsonResult MFVendawv_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendawv_Delete",
				ViewName = "MFVendawv",
				AreaName = "sale",
				Location = ACTION_VENDAWV_EDIT
			};

			var model = new Vendawv_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion



		#region Vendawv Wizard actions

		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendawv_Fases_WizardStep")]
		public ActionResult Vendawv_Fases_WizardStep(string wizardStepView)
		{
			try
			{
				string pkey = Navigation.GetStrValue("sale");
				if (pkey != null)
				{
					Models.Sale record = Models.Sale.Find(pkey);
					if (record != null)
						record.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, true, false, false, true);
				}
			}
			catch {}

			try
			{
				switch (wizardStepView)
				{
					case "Vendaw01":
						Vendaw01_ViewModel modelVendaw01 = new Vendaw01_ViewModel(Navigation, true);
						modelVendaw01.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw01);
					case "Vendaw02":
						Vendaw02_ViewModel modelVendaw02 = new Vendaw02_ViewModel(Navigation, true);
						modelVendaw02.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw02);
					case "Vendaw03":
						Vendaw03_ViewModel modelVendaw03 = new Vendaw03_ViewModel(Navigation, true);
						modelVendaw03.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw03);
					case "Vendaw04":
						Vendaw04_ViewModel modelVendaw04 = new Vendaw04_ViewModel(Navigation, true);
						modelVendaw04.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw04);
					case "Vendaw05":
						Vendaw05_ViewModel modelVendaw05 = new Vendaw05_ViewModel(Navigation, true);
						modelVendaw05.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw05);
					case "Vendaw06":
						Vendaw06_ViewModel modelVendaw06 = new Vendaw06_ViewModel(Navigation, true);
						modelVendaw06.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw06);
					case "Vendaw07":
						Vendaw07_ViewModel modelVendaw07 = new Vendaw07_ViewModel(Navigation, true);
						modelVendaw07.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw07);
					case "Vendaw08":
						Vendaw08_ViewModel modelVendaw08 = new Vendaw08_ViewModel(Navigation, true);
						modelVendaw08.Load(Request.Form, true, true, true);
						return PartialView(wizardStepView, modelVendaw08);
					default:
						throw new Exception("The specified step doesn't belong to wizard 'FASES'.");
				}
			}
			catch (Exception e)
			{
				return Json(new { Success = false, e.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		private Models.WizardStep Vendawv_Fases_GetNextStep(Models.Sale p, string currentStep)
		{
			Models.WizardStep nextStep = new Models.WizardStep();
			switch (currentStep)
			{
				case "":
					nextStep = new Models.WizardStep("VENDAW01", "FASES", 1);
					break;
				case "wizard-step-FASES-1":
					nextStep = new Models.WizardStep("VENDAW02", "FASES", 2);
					break;
				case "wizard-step-FASES-2":
					nextStep = new Models.WizardStep("VENDAW03", "FASES", 3);
					break;
				case "wizard-step-FASES-3":
					nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
					break;
				case "wizard-step-FASES-4":
					nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
					break;
				case "wizard-step-FASES-5":
					nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
					break;
				case "wizard-step-FASES-6":
					nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
					break;
				case "wizard-step-FASES-7":
					nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
					break;
				case "wizard-step-FASES-8":
					CSGenio.framework.Log.Error("Wizard FASES - Forward action is disabled for step 'wizard-step-FASES-8'.");
					// Throw exception as the last step doesn't have a forward action.
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				default:
					CSGenio.framework.Log.Error("Wizard FASES - The specified step doesn't belong to wizard 'FASES'.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
			}
			return nextStep;
		}

		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendawv_Fases_NextStep")]
		public JsonResult Vendawv_Fases_NextStep(string formId, string currentStep)
		{
			try
			{
				var p = Models.Sale.Find(formId);
				Models.WizardStep nextStep = Vendawv_Fases_GetNextStep(p, currentStep);

				return Json(new { Success = true, nextStep.StepId }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				return Json(new { Success = false, e.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		private void Vendawv_Fases_CalculatePath(Models.Sale p, string step, ref IList<string> path)
		{
			try
			{
				Models.WizardStep nextStep = Vendawv_Fases_GetNextStep(p, step);
				bool isActive = false;

				switch (nextStep.StepId)
				{
					case "wizard-step-FASES-1":
						break;
					case "wizard-step-FASES-2":
						break;
					case "wizard-step-FASES-3":
						break;
					case "wizard-step-FASES-4":
						break;
					case "wizard-step-FASES-5":
						break;
					case "wizard-step-FASES-6":
						break;
					case "wizard-step-FASES-7":
						break;
					case "wizard-step-FASES-8":
						break;
				}
				if (!string.IsNullOrWhiteSpace(nextStep.StepId))
					path.Add(nextStep.StepId);
				if (isActive)
					Vendawv_Fases_CalculatePath(p, nextStep.StepId, ref path);
			}
			catch {}
		}

		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendawv_Fases_GetPath")]
		public JsonResult Vendawv_Fases_GetPath(string formId)
		{
			try
			{
				var p = Models.Sale.Find(formId);
				IList<string> path = new List<string>(8);
				if (p != null)
					Vendawv_Fases_CalculatePath(p, "", ref path);

				string nextStep;
				if (path.Count > 0)
					nextStep = path.Last();
				else
					nextStep = "form-VENDAWV-" + Vendawv_Fases_GetNextStep(p, "").FormName;

				// If the wizard is now starting, clears any remnants of previous navigations.
				if (path.Count <= 1)
					HttpContext.Session["Vendawv_Fases_WizardNav"] = new Models.WizardNav();

				return Json(new { Success = true, Path = path, NextStep = nextStep }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				return Json(new { Success = false, e.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw01_Save")]
		public JsonResult Vendawv_Fases_Vendaw01_Save(Vendaw01_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw01_Save",
				ViewName = "Vendaw01",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW01]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw02_Save")]
		public JsonResult Vendawv_Fases_Vendaw02_Save(Vendaw02_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw02_Save",
				ViewName = "Vendaw02",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW02]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw03_Save")]
		public JsonResult Vendawv_Fases_Vendaw03_Save(Vendaw03_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw03_Save",
				ViewName = "Vendaw03",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW03]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw04_Save")]
		public JsonResult Vendawv_Fases_Vendaw04_Save(Vendaw04_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw04_Save",
				ViewName = "Vendaw04",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW04]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw05_Save")]
		public JsonResult Vendawv_Fases_Vendaw05_Save(Vendaw05_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw05_Save",
				ViewName = "Vendaw05",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW05]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw06_Save")]
		public JsonResult Vendawv_Fases_Vendaw06_Save(Vendaw06_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw06_Save",
				ViewName = "Vendaw06",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW06]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw07_Save")]
		public JsonResult Vendawv_Fases_Vendaw07_Save(Vendaw07_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw07_Save",
				ViewName = "Vendaw07",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW07]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendawv_Fases_Vendaw08_Save")]
		public JsonResult Vendawv_Fases_Vendaw08_Save(Vendaw08_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_Fases_Vendaw08_Save",
				ViewName = "Vendaw08",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV_FASES_VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV_FASES_VENDAW08]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		#endregion

  
                          
		// POST: /Sale/Vendawv_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendawv_SaveEdit(Vendawv_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendawv_SaveEdit",
				ViewName = "Vendawv",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAWV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAWV]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
