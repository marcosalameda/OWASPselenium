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

		private static readonly NavigationLocation ACTION_VENDAW_CANCEL = new NavigationLocation("HORIZONTAL_WIZARD25471", "Vendaw_Cancel", "Sale") { vueRouteName = "form-VENDAW", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW_SHOW = new NavigationLocation("HORIZONTAL_WIZARD25471", "Vendaw_Show", "Sale") { vueRouteName = "form-VENDAW", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW_NEW = new NavigationLocation("HORIZONTAL_WIZARD25471", "Vendaw_New", "Sale") { vueRouteName = "form-VENDAW", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW_EDIT = new NavigationLocation("HORIZONTAL_WIZARD25471", "Vendaw_Edit", "Sale") { vueRouteName = "form-VENDAW", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW_DUPLICATE = new NavigationLocation("HORIZONTAL_WIZARD25471", "Vendaw_Duplicate", "Sale") { vueRouteName = "form-VENDAW", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW_DELETE = new NavigationLocation("HORIZONTAL_WIZARD25471", "Vendaw_Delete", "Sale") { vueRouteName = "form-VENDAW", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Vendaw(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("sale");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_VENDAW_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_VENDAW_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_VENDAW_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_VENDAW_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_VENDAW_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Vendaw private

		private void FormHistoryLimits_Vendaw()
		{

		}

		#endregion


		[AuthorizeForUsers]
		public ActionResult Vendaw_ModalDBEdit(string partialView)
		{
			Vendaw_ViewModel model = new Vendaw_ViewModel();
			model.setModes(Request.QueryString["m"]);
			model.Navigation = Navigation;
			model.Load(Request.Form, true, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

		#region Vendaw_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW]/
		//
		// GET: /Sale/Vendaw_Show
		[AuthorizeForUsers]
		public ActionResult Vendaw_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Vendaw_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Vendaw"; // MF send the patial view name

			var navigationLocationAction = ACTION_VENDAW_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW]/

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
				CSGenio.framework.Log.Error("Vendaw_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Vendaw");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Vendaw", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Vendaw_New

		[ActionName("Vendaw_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendaw_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Vendaw_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW]/
		//
		// GET: /Sale/Vendaw_New
		[ActionName("Vendaw_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendaw_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Vendaw_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Vendaw";

			var navigationLocationAction = ACTION_VENDAW_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("VENDAW"))
				Navigation.OverrideSkipIfJustOne["VENDAW"] = true;

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
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW]/
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
				CSGenio.framework.Log.Error("Vendaw_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Vendaw", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Sale/Vendaw_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendaw_New(Vendaw_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_New",
				ViewName = "Vendaw",
				AreaName = "sale",
				Location = ACTION_VENDAW_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendaw_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("sale", Convert.ToString(Navigation.CurrentLevel.GetEntry("sale"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_VENDAW_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW");
		}

		#endregion

		#region Vendaw_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW]/
		//
		// GET: /Sale/Vendaw_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendaw_Edit")]
		public ActionResult Vendaw_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Vendaw"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_VENDAW_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_VENDAW_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("sale", id);

			var model = new Vendaw_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW]/
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
				CSGenio.framework.Log.Error("Vendaw_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Vendaw", model);
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
		// POST: /Sale/Vendaw_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendaw_Edit(Vendaw_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Edit",
				ViewName = "Vendaw",
				AreaName = "sale",
				Location = ACTION_VENDAW_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendaw_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 + GetHumanKeyToQMessage("sale", Convert.ToString(Navigation.CurrentLevel.GetEntry("sale"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW");
		}


		#endregion

		#region Vendaw_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW]/
		//
		// GET: /Sale/Vendaw_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendaw_Delete")]
		public ActionResult Vendaw_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_VENDAW_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("sale", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Vendaw_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW]/

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
				CSGenio.framework.Log.Error("Vendaw_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Vendaw", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Vendaw", model);
		}


		//
		// POST: /Sale/Vendaw_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendaw_Delete(string id, FormCollection collection)
		{

			var model = new Vendaw_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Delete",
				ViewName = "Vendaw",
				AreaName = "sale",
				Location = ACTION_VENDAW_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendaw_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW");
		}

		#endregion

		#region Vendaw_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW]/
		//
		// GET: /Sale/Vendaw_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendaw_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Vendaw_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_VENDAW_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_VENDAW_DUPLICATE.SetRoutedValues(new { Id = model.ValCodvenda }));
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
				return RedirectToLocation(Navigation.PreviousLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				Navigation.SetValue("sale", model.ValCodvenda);
				return View("Vendaw", model);
			}
			else
				return PartialView("Vendaw", model);
		}


		//
		// POST: /Sale/Vendaw_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendaw_Duplicate(Vendaw_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Duplicate",
				ViewName = "Vendaw",
				AreaName = "sale",
				Location = ACTION_VENDAW_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Vendaw_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("sale", Convert.ToString(Navigation.CurrentLevel.GetEntry("sale"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW");
		}

		#endregion

		#region Vendaw_Cancel

		//
		// GET: /Sale/Vendaw_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Vendaw_Cancel()
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

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW]/

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

		#region Vendaw Multiform actions

		//
		// GET /Sale/MFVendaw_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVendaw_New")]
		public ActionResult MFVendaw_New()
		{
			var model = new Vendaw_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VENDAW_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
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

			return PartialView("MFVendaw", model);
		}

		//
		// GET /Sale/MFVendaw_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVendaw_Edit")]
		public ActionResult MFVendaw_Edit(string id)
		{
			return this.RedirectToAction("Vendaw_Edit", "Sale", new { id = id, partialView = "MFVendaw", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Sale/MFVendaw_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVendaw_Cancel")]
		public ActionResult MFVendaw_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_VENDAW_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_VENDAW_EDIT.Action))
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

						Log.Error("MFVendaw_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Vendaw_Show", "Sale", new { id = id, partialView = "MFVendaw", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Sale/MFVendaw_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFVendaw_Save")]
		public JsonResult MFVendaw_Save(Vendaw_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw_Save",
				ViewName = "MFVendaw",
				AreaName = "sale"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Sale/MFVendaw_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFVendaw_Delete")]
		public JsonResult MFVendaw_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVendaw_Delete",
				ViewName = "MFVendaw",
				AreaName = "sale",
				Location = ACTION_VENDAW_EDIT
			};

			var model = new Vendaw_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion



		#region Vendaw Wizard actions

		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendaw_Fases_WizardStep")]
		public ActionResult Vendaw_Fases_WizardStep(string wizardStepView)
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

		private Models.WizardStep Vendaw_Fases_GetNextStep(Models.Sale p, string currentStep)
		{
			Models.WizardStep nextStep = new Models.WizardStep();
			switch (currentStep)
			{
				case "":
					nextStep = new Models.WizardStep("VENDAW01", "FASES", 1);
					break;
				case "wizard-step-FASES-1":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValProspecc))==0)
					{
						nextStep = new Models.WizardStep("VENDAW02", "FASES", 2);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValQualific))==0)
					{
						nextStep = new Models.WizardStep("VENDAW03", "FASES", 3);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0)
					{
						nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-2":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValQualific))==0)
					{
						nextStep = new Models.WizardStep("VENDAW03", "FASES", 3);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0)
					{
						nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-3":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0)
					{
						nextStep = new Models.WizardStep("VENDAW04", "FASES", 4);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-4":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0)
					{
						nextStep = new Models.WizardStep("VENDAW05", "FASES", 5);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-5":
					if (CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0)
					{
						nextStep = new Models.WizardStep("VENDAW06", "FASES", 6);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-6":
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0)
					{
						nextStep = new Models.WizardStep("VENDAW07", "FASES", 7);
						break;
					}
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
				case "wizard-step-FASES-7":
					if (CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0)
					{
						nextStep = new Models.WizardStep("VENDAW08", "FASES", 8);
						break;
					}
					CSGenio.framework.Log.Error("Wizard FASES - On GetNextStep, all conditions were false, couldn't find the next step.");
					throw new Exception(Resources.Resources.PEDIMOS_DESCULPA__OC63848);
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
		[ActionName("Vendaw_Fases_NextStep")]
		public JsonResult Vendaw_Fases_NextStep(string formId, string currentStep)
		{
			try
			{
				var p = Models.Sale.Find(formId);
				Models.WizardStep nextStep = Vendaw_Fases_GetNextStep(p, currentStep);

				return Json(new { Success = true, nextStep.StepId }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				return Json(new { Success = false, e.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		private void Vendaw_Fases_CalculatePath(Models.Sale p, string step, ref IList<string> path)
		{
			try
			{
				Models.WizardStep nextStep = Vendaw_Fases_GetNextStep(p, step);
				bool isActive = false;

				switch (nextStep.StepId)
				{
					case "wizard-step-FASES-1":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValProspecc))==0&&CSGenio.business.GlobalFunctions.emptyG(((string)p.ValCodorgan))==0;
						break;
					case "wizard-step-FASES-2":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValQualific))==0;
						break;
					case "wizard-step-FASES-3":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValHomework))==0;
						break;
					case "wizard-step-FASES-4":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApproach))==0;
						break;
					case "wizard-step-FASES-5":
						isActive = CSGenio.business.GlobalFunctions.emptyL(((Logical)p.ValApresent))==0;
						break;
					case "wizard-step-FASES-6":
						isActive = CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtsupera))==0;
						break;
					case "wizard-step-FASES-7":
						isActive = CSGenio.business.GlobalFunctions.emptyD(((DateTime)p.ValDtvenda))==0;
						break;
					case "wizard-step-FASES-8":
						break;
				}
				if (!string.IsNullOrWhiteSpace(nextStep.StepId))
					path.Add(nextStep.StepId);
				if (isActive)
					Vendaw_Fases_CalculatePath(p, nextStep.StepId, ref path);
			}
			catch {}
		}

		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Vendaw_Fases_GetPath")]
		public JsonResult Vendaw_Fases_GetPath(string formId)
		{
			try
			{
				var p = Models.Sale.Find(formId);
				IList<string> path = new List<string>(8);
				if (p != null)
					Vendaw_Fases_CalculatePath(p, "", ref path);

				string nextStep;
				if (path.Count > 0)
					nextStep = path.Last();
				else
					nextStep = "form-VENDAW-" + Vendaw_Fases_GetNextStep(p, "").FormName;

				// If the wizard is now starting, clears any remnants of previous navigations.
				if (path.Count <= 1)
					HttpContext.Session["Vendaw_Fases_WizardNav"] = new Models.WizardNav();

				return Json(new { Success = true, Path = path, NextStep = nextStep }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception e)
			{
				return Json(new { Success = false, e.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw01_Save")]
		public JsonResult Vendaw_Fases_Vendaw01_Save(Vendaw01_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw01_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw01_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw01_Save",
				ViewName = "Vendaw01",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW01]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw02_Save")]
		public JsonResult Vendaw_Fases_Vendaw02_Save(Vendaw02_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw02_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw02_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw02_Save",
				ViewName = "Vendaw02",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW02]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw03_Save")]
		public JsonResult Vendaw_Fases_Vendaw03_Save(Vendaw03_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw03_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw03_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw03_Save",
				ViewName = "Vendaw03",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW03]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw04_Save")]
		public JsonResult Vendaw_Fases_Vendaw04_Save(Vendaw04_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw04_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw04_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw04_Save",
				ViewName = "Vendaw04",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW04]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw05_Save")]
		public JsonResult Vendaw_Fases_Vendaw05_Save(Vendaw05_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw05_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw05_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw05_Save",
				ViewName = "Vendaw05",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW05]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw06_Save")]
		public JsonResult Vendaw_Fases_Vendaw06_Save(Vendaw06_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw06_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw06_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw06_Save",
				ViewName = "Vendaw06",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW06]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw07_Save")]
		public JsonResult Vendaw_Fases_Vendaw07_Save(Vendaw07_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw07_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw07_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw07_Save",
				ViewName = "Vendaw07",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW07]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("Vendaw_Fases_Vendaw08_Save")]
		public JsonResult Vendaw_Fases_Vendaw08_Save(Vendaw08_ViewModel model)
		{
			// True if the user is moving to the previous step (backward), false otherwise.
			bool isGoingBack = false;
			if (Request.QueryString.Get("isGoingBack") != null)
				isGoingBack = Convert.ToBoolean(Request.QueryString["isGoingBack"]);

			// True if the step data should be cleared when moving to the previous step, false otherwise.
			bool clearData = false;
			if (Request.QueryString.Get("clearData") != null)
				clearData = Convert.ToBoolean(Request.QueryString["clearData"]);

			if (isGoingBack)
			{

				if (clearData)
				{
					try
					{
						ModelState.Clear();

						model = new Vendaw08_ViewModel(new Models.Sale(), Navigation);
						model.ValCodvenda = Navigation.GetStrValue("sale");
						model.NewLoad();
					}
					catch (Exception e)
					{
						// When removing dependencies from tables, if the records are related to other tables, an exception will be thrown.
						// Error message: "The record with code X of the table Y has related records and can't be deleted. The related table: Z".
						// TODO: A more profound analysis needs to be conducted, to decide if the records in those tables should also be removed, or if the removal shouldn't be possible at all.
						CSGenio.framework.Log.Error("Vendaw_Fases_Vendaw08_Save - Error while removing record: " + e.Message);
					}
				}
			}

			model._Navigation.SetValue("isGoingBack", isGoingBack);
			model._Navigation.SetValue("clearData", clearData);

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_Fases_Vendaw08_Save",
				ViewName = "Vendaw08",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW_FASES_VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW_FASES_VENDAW08]/
				}
			};

			return (JsonResult) GenericHandlePostFormApply(eventSink, model);
		}

		#endregion

  
		//
		// GET: /Sale/Vendaw01_OrganValOrganiza
		// POST: /Sale/Vendaw01_OrganValOrganiza
		[AuthorizeForUsers]
		[ActionName("Vendaw01_OrganValOrganiza")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Vendaw01_OrganValOrganiza(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_organ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_organ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Vendaw01_OrganValOrganiza_ViewModel model = new Vendaw01_OrganValOrganiza_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodvenda = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

                          
		// POST: /Sale/Vendaw_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Vendaw_SaveEdit(Vendaw_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw_SaveEdit",
				ViewName = "Vendaw",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
