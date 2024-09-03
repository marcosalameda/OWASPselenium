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
using GenioMVC.ViewModels.Lnhag;


// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHAG]/

namespace GenioMVC.Controllers
{
	public partial class LnhagController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHAG_CANCEL = new NavigationLocation("EQUIPMENT_GROUPING44771", "Lnhag_Cancel", "Lnhag") { vueRouteName = "form-LNHAG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHAG_SHOW = new NavigationLocation("EQUIPMENT_GROUPING44771", "Lnhag_Show", "Lnhag") { vueRouteName = "form-LNHAG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHAG_NEW = new NavigationLocation("EQUIPMENT_GROUPING44771", "Lnhag_New", "Lnhag") { vueRouteName = "form-LNHAG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHAG_EDIT = new NavigationLocation("EQUIPMENT_GROUPING44771", "Lnhag_Edit", "Lnhag") { vueRouteName = "form-LNHAG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHAG_DUPLICATE = new NavigationLocation("EQUIPMENT_GROUPING44771", "Lnhag_Duplicate", "Lnhag") { vueRouteName = "form-LNHAG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHAG_DELETE = new NavigationLocation("EQUIPMENT_GROUPING44771", "Lnhag_Delete", "Lnhag") { vueRouteName = "form-LNHAG", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Lnhag(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("lnhag");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_LNHAG_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_LNHAG_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_LNHAG_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_LNHAG_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_LNHAG_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Lnhag private

		private void FormHistoryLimits_Lnhag()
		{

		}

		#endregion

		#region Lnhag_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHAG]/
		//
		// GET: /Lnhag/Lnhag_Show
		[AuthorizeForUsers]
		public ActionResult Lnhag_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Lnhag_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Lnhag"; // MF send the patial view name

			var navigationLocationAction = ACTION_LNHAG_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("lnhag"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("lnhag", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHAG]/

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
				CSGenio.framework.Log.Error("Lnhag_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHAG]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Lnhag");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Lnhag", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Lnhag_New

		[ActionName("Lnhag_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhag_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Lnhag_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHAG]/
		//
		// GET: /Lnhag/Lnhag_New
		[ActionName("Lnhag_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhag_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Lnhag_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Lnhag";

			var navigationLocationAction = ACTION_LNHAG_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("LNHAG"))
				Navigation.OverrideSkipIfJustOne["LNHAG"] = true;

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

					Navigation.SetValue("lnhag", model.ValCodlnhag);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHAG]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHAG]/
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
				CSGenio.framework.Log.Error("Lnhag_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Lnhag", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Lnhag/Lnhag_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHAG]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhag_New(Lnhag_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_New",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHAG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHAG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHAG]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhag_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("lnhag", Convert.ToString(Navigation.CurrentLevel.GetEntry("lnhag"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_LNHAG_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHAG");
		}

		#endregion

		#region Lnhag_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHAG]/
		//
		// GET: /Lnhag/Lnhag_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Lnhag_Edit")]
		public ActionResult Lnhag_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Lnhag"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_LNHAG_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_LNHAG_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("lnhag", id);

			var model = new Lnhag_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHAG]/
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
				CSGenio.framework.Log.Error("Lnhag_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHAG]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Lnhag", model);
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
		// POST: /Lnhag/Lnhag_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHAG]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhag_Edit(Lnhag_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Edit",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHAG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHAG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHAG]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhag_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("lnhag", Convert.ToString(Navigation.CurrentLevel.GetEntry("lnhag"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHAG");
		}


		#endregion

		#region Lnhag_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHAG]/
		//
		// GET: /Lnhag/Lnhag_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Lnhag_Delete")]
		public ActionResult Lnhag_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_LNHAG_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("lnhag", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Lnhag_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHAG]/

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
				CSGenio.framework.Log.Error("Lnhag_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHAG]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Lnhag", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Lnhag", model);
		}


		//
		// POST: /Lnhag/Lnhag_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHAG]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhag_Delete(string id, FormCollection collection)
		{

			var model = new Lnhag_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Delete",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHAG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhag_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHAG");
		}

		#endregion

		#region Lnhag_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHAG]/
		//
		// GET: /Lnhag/Lnhag_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhag_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Lnhag_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_LNHAG_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHAG]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHAG]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_LNHAG_DUPLICATE.SetRoutedValues(new { Id = model.ValCodlnhag }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("lnhag", model.ValCodlnhag);
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
				Navigation.SetValue("lnhag", model.ValCodlnhag);
				return View("Lnhag", model);
			}
			else
				return PartialView("Lnhag", model);
		}


		//
		// POST: /Lnhag/Lnhag_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHAG]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhag_Duplicate(Lnhag_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Duplicate",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHAG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHAG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHAG]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Lnhag_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("lnhag", Convert.ToString(Navigation.CurrentLevel.GetEntry("lnhag"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHAG");
		}

		#endregion

		#region Lnhag_Cancel

		//
		// GET: /Lnhag/Lnhag_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHAG]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Lnhag_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhag();
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhag");

// USE /[MANUAL GQT BEFORE_CANCEL LNHAG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHAG]/

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

				Navigation.SetValue("ForcePrimaryRead_lnhag", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "lnhag";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("lnhag");
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

		#region Lnhag Multiform actions

		//
		// GET /Lnhag/MFLnhag_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLnhag_New")]
		public ActionResult MFLnhag_New()
		{
			var model = new Lnhag_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LNHAG_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("lnhag", model.ValCodlnhag);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFLnhag", model);
		}

		//
		// GET /Lnhag/MFLnhag_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLnhag_Edit")]
		public ActionResult MFLnhag_Edit(string id)
		{
			return this.RedirectToAction("Lnhag_Edit", "Lnhag", new { id = id, partialView = "MFLnhag", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Lnhag/MFLnhag_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLnhag_Cancel")]
		public ActionResult MFLnhag_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_LNHAG_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_LNHAG_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Lnhag();
						model.klass.QPrimaryKey = Navigation.GetStrValue("lnhag");

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

						Log.Error("MFLnhag_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Lnhag_Show", "Lnhag", new { id = id, partialView = "MFLnhag", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Lnhag/MFLnhag_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFLnhag_Save")]
		public JsonResult MFLnhag_Save(Lnhag_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLnhag_Save",
				ViewName = "MFLnhag",
				AreaName = "lnhag"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Lnhag/MFLnhag_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFLnhag_Delete")]
		public JsonResult MFLnhag_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLnhag_Delete",
				ViewName = "MFLnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_EDIT
			};

			var model = new Lnhag_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: /Lnhag/Lnhag_PedidValNrpedido
		// POST: /Lnhag/Lnhag_PedidValNrpedido
		[AuthorizeForUsers]
		[ActionName("Lnhag_PedidValNrpedido")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Lnhag_PedidValNrpedido(string id, string partialView,  IDictionary<string, string> Limits)
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
			Lnhag_PedidValNrpedido_ViewModel model = new Lnhag_PedidValNrpedido_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		//
		// GET: /Lnhag/Lnhag_Tpeq1ValTipoequi
		// POST: /Lnhag/Lnhag_Tpeq1ValTipoequi
		[AuthorizeForUsers]
		[ActionName("Lnhag_Tpeq1ValTipoequi")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Lnhag_Tpeq1ValTipoequi(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpeq1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpeq1");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Lnhag_Tpeq1ValTipoequi_ViewModel model = new Lnhag_Tpeq1ValTipoequi_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		// POST: /Lnhag/Lnhag_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Lnhag_SaveEdit(Lnhag_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_SaveEdit",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHAG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
