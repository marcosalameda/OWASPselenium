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
using GenioMVC.ViewModels.Lnhpd;


// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHPD]/

namespace GenioMVC.Controllers
{
	public partial class LnhpdController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHPD_CANCEL = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Cancel", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHPD_SHOW = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Show", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHPD_NEW = new NavigationLocation("ORDER_LINE50035", "Lnhpd_New", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHPD_EDIT = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Edit", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHPD_DUPLICATE = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Duplicate", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHPD_DELETE = new NavigationLocation("ORDER_LINE50035", "Lnhpd_Delete", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Lnhpd(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("lnhpd");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_LNHPD_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_LNHPD_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_LNHPD_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_LNHPD_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_LNHPD_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Lnhpd private

		private void FormHistoryLimits_Lnhpd()
		{

		}

		#endregion

		#region Lnhpd_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHPD]/
		//
		// GET: /Lnhpd/Lnhpd_Show
		[AuthorizeForUsers]
		public ActionResult Lnhpd_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Lnhpd_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Lnhpd"; // MF send the patial view name

			var navigationLocationAction = ACTION_LNHPD_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("lnhpd"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("lnhpd", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHPD]/

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
				CSGenio.framework.Log.Error("Lnhpd_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHPD]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Lnhpd");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Lnhpd", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Lnhpd_New

		[ActionName("Lnhpd_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhpd_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Lnhpd_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHPD]/
		//
		// GET: /Lnhpd/Lnhpd_New
		[ActionName("Lnhpd_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhpd_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Lnhpd_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Lnhpd";

			var navigationLocationAction = ACTION_LNHPD_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("LNHPD"))
				Navigation.OverrideSkipIfJustOne["LNHPD"] = true;

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

					Navigation.SetValue("lnhpd", model.ValCodlnhpd);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHPD]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHPD]/
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
				CSGenio.framework.Log.Error("Lnhpd_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Lnhpd", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Lnhpd/Lnhpd_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHPD]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhpd_New(Lnhpd_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_New",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHPD]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhpd_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("lnhpd", Convert.ToString(Navigation.CurrentLevel.GetEntry("lnhpd"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_LNHPD_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHPD");
		}

		#endregion

		#region Lnhpd_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHPD]/
		//
		// GET: /Lnhpd/Lnhpd_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Lnhpd_Edit")]
		public ActionResult Lnhpd_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Lnhpd"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_LNHPD_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_LNHPD_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("lnhpd", id);

			var model = new Lnhpd_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHPD]/
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
				CSGenio.framework.Log.Error("Lnhpd_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHPD]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Lnhpd", model);
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
		// POST: /Lnhpd/Lnhpd_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHPD]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhpd_Edit(Lnhpd_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Edit",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHPD]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhpd_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("lnhpd", Convert.ToString(Navigation.CurrentLevel.GetEntry("lnhpd"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHPD");
		}


		#endregion

		#region Lnhpd_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHPD]/
		//
		// GET: /Lnhpd/Lnhpd_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Lnhpd_Delete")]
		public ActionResult Lnhpd_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_LNHPD_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("lnhpd", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Lnhpd_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHPD]/

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
				CSGenio.framework.Log.Error("Lnhpd_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHPD]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Lnhpd", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Lnhpd", model);
		}


		//
		// POST: /Lnhpd/Lnhpd_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHPD]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhpd_Delete(string id, FormCollection collection)
		{

			var model = new Lnhpd_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Delete",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHPD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhpd_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHPD");
		}

		#endregion

		#region Lnhpd_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHPD]/
		//
		// GET: /Lnhpd/Lnhpd_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhpd_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Lnhpd_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_LNHPD_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHPD]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHPD]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_LNHPD_DUPLICATE.SetRoutedValues(new { Id = model.ValCodlnhpd }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("lnhpd", model.ValCodlnhpd);
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
				Navigation.SetValue("lnhpd", model.ValCodlnhpd);
				return View("Lnhpd", model);
			}
			else
				return PartialView("Lnhpd", model);
		}


		//
		// POST: /Lnhpd/Lnhpd_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHPD]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhpd_Duplicate(Lnhpd_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Duplicate",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHPD]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhpd_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("lnhpd", Convert.ToString(Navigation.CurrentLevel.GetEntry("lnhpd"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHPD");
		}

		#endregion

		#region Lnhpd_Cancel

		//
		// GET: /Lnhpd/Lnhpd_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHPD]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhpd_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhpd();
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");

// USE /[MANUAL GQT BEFORE_CANCEL LNHPD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHPD]/

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

				Navigation.SetValue("ForcePrimaryRead_lnhpd", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "lnhpd";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("lnhpd");
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

		#region Lnhpd Multiform actions

		//
		// GET /Lnhpd/MFLnhpd_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLnhpd_New")]
		public ActionResult MFLnhpd_New()
		{
			var model = new Lnhpd_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LNHPD_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("lnhpd", model.ValCodlnhpd);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFLnhpd", model);
		}

		//
		// GET /Lnhpd/MFLnhpd_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLnhpd_Edit")]
		public ActionResult MFLnhpd_Edit(string id)
		{
			return this.RedirectToAction("Lnhpd_Edit", "Lnhpd", new { id = id, partialView = "MFLnhpd", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Lnhpd/MFLnhpd_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLnhpd_Cancel")]
		public ActionResult MFLnhpd_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_LNHPD_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_LNHPD_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Lnhpd();
						model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");

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

						Log.Error("MFLnhpd_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Lnhpd_Show", "Lnhpd", new { id = id, partialView = "MFLnhpd", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Lnhpd/MFLnhpd_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFLnhpd_Save")]
		public JsonResult MFLnhpd_Save(Lnhpd_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLnhpd_Save",
				ViewName = "MFLnhpd",
				AreaName = "lnhpd"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Lnhpd/MFLnhpd_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFLnhpd_Delete")]
		public JsonResult MFLnhpd_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLnhpd_Delete",
				ViewName = "MFLnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_EDIT
			};

			var model = new Lnhpd_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: /Lnhpd/Lnhpd_PedidValNrpedido
		// POST: /Lnhpd/Lnhpd_PedidValNrpedido
		[AuthorizeForUsers]
		[ActionName("Lnhpd_PedidValNrpedido")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Lnhpd_PedidValNrpedido(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pedid")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pedid");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Lnhpd_PedidValNrpedido_ViewModel model = new Lnhpd_PedidValNrpedido_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

  
		//
		// GET: /Lnhpd/Lnhpd_TpequValTipoequi
		// POST: /Lnhpd/Lnhpd_TpequValTipoequi
		[AuthorizeForUsers]
		[ActionName("Lnhpd_TpequValTipoequi")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Lnhpd_TpequValTipoequi(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Lnhpd_TpequValTipoequi_ViewModel model = new Lnhpd_TpequValTipoequi_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

		#region Cargas
  
		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		[HttpGet]
		[AuthorizeForUsers]
		public ActionResult GetCarga_CONJUNTO(string idsrc, string iddst)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Lnhpd.Find(iddst).carga_CONJUNTO(idsrc);
				sp.closeTransaction();
				return Json(new { Success = true, data = Resources.Resources.A_OPERACAO_FOI_CONCL36721 }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return View("Error");
			}
		}
   
		#endregion
 
		//
		// GET: /Lnhpd/Lnhpd_ValDesconju
		// POST: /Lnhpd/Lnhpd_ValDesconju
		[AuthorizeForUsers]
		[ActionName("Lnhpd_ValDesconju")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Lnhpd_ValDesconju(string id, string partialView)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation;
			Lnhpd_ValDesconju_ViewModel model = new Lnhpd_ValDesconju_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

  
		//
		// GET: /Lnhpd/Lnhpd_ValDesagreg
		// POST: /Lnhpd/Lnhpd_ValDesagreg
		[AuthorizeForUsers]
		[ActionName("Lnhpd_ValDesagreg")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Lnhpd_ValDesagreg(string id, string partialView)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lnhde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lnhde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation;
			Lnhpd_ValDesagreg_ViewModel model = new Lnhpd_ValDesagreg_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}


		// POST: /Lnhpd/Lnhpd_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhpd_SaveEdit(Lnhpd_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_SaveEdit",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHPD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
