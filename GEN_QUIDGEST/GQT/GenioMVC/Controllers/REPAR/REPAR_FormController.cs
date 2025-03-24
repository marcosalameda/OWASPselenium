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
using GenioMVC.ViewModels.Repar;


// USE /[MANUAL GQT INCLUDE_CONTROLLER REPAR]/

namespace GenioMVC.Controllers
{
	public partial class ReparController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REPAR_CANCEL = new NavigationLocation("REPAIR34508", "Repar_Cancel", "Repar") { vueRouteName = "form-REPAR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REPAR_SHOW = new NavigationLocation("REPAIR34508", "Repar_Show", "Repar") { vueRouteName = "form-REPAR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REPAR_NEW = new NavigationLocation("REPAIR34508", "Repar_New", "Repar") { vueRouteName = "form-REPAR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REPAR_EDIT = new NavigationLocation("REPAIR34508", "Repar_Edit", "Repar") { vueRouteName = "form-REPAR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REPAR_DUPLICATE = new NavigationLocation("REPAIR34508", "Repar_Duplicate", "Repar") { vueRouteName = "form-REPAR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REPAR_DELETE = new NavigationLocation("REPAIR34508", "Repar_Delete", "Repar") { vueRouteName = "form-REPAR", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Repar(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("repar");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_REPAR_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_REPAR_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_REPAR_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_REPAR_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_REPAR_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Repar private

		private void FormHistoryLimits_Repar()
		{

		}

		#endregion

		#region Repar_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REPAR]/
		//
		// GET: /Repar/Repar_Show
		[AuthorizeForUsers]
		public ActionResult Repar_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Repar_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Repar"; // MF send the patial view name

			var navigationLocationAction = ACTION_REPAR_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("repar"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("repar", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW REPAR]/

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
				CSGenio.framework.Log.Error("Repar_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW REPAR]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Repar");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Repar", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Repar_New

		[ActionName("Repar_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Repar_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Repar_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET REPAR]/
		//
		// GET: /Repar/Repar_New
		[ActionName("Repar_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Repar_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Repar_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Repar";

			var navigationLocationAction = ACTION_REPAR_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("REPAR"))
				Navigation.OverrideSkipIfJustOne["REPAR"] = true;

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

					Navigation.SetValue("repar", model.ValCodrepar);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW REPAR]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW REPAR]/
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
				CSGenio.framework.Log.Error("Repar_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Repar", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Repar/Repar_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REPAR]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Repar_New(Repar_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Repar_New",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REPAR]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Repar_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("repar", Convert.ToString(Navigation.CurrentLevel.GetEntry("repar"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_REPAR_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REPAR");
		}

		#endregion

		#region Repar_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REPAR]/
		//
		// GET: /Repar/Repar_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Repar_Edit")]
		public ActionResult Repar_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Repar"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_REPAR_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_REPAR_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("repar", id);

			var model = new Repar_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT REPAR]/
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
				CSGenio.framework.Log.Error("Repar_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT REPAR]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Repar", model);
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
		// POST: /Repar/Repar_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REPAR]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Repar_Edit(Repar_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Repar_Edit",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REPAR]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Repar_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("repar", Convert.ToString(Navigation.CurrentLevel.GetEntry("repar"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REPAR");
		}


		#endregion

		#region Repar_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REPAR]/
		//
		// GET: /Repar/Repar_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Repar_Delete")]
		public ActionResult Repar_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_REPAR_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("repar", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Repar_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE REPAR]/

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
				CSGenio.framework.Log.Error("Repar_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE REPAR]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Repar", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Repar", model);
		}


		//
		// POST: /Repar/Repar_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REPAR]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Repar_Delete(string id, FormCollection collection)
		{

			var model = new Repar_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Repar_Delete",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REPAR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Repar_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REPAR");
		}

		#endregion

		#region Repar_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REPAR]/
		//
		// GET: /Repar/Repar_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Repar_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Repar_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_REPAR_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REPAR]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REPAR]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_REPAR_DUPLICATE.SetRoutedValues(new { Id = model.ValCodrepar }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("repar", model.ValCodrepar);
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
				Navigation.SetValue("repar", model.ValCodrepar);
				return View("Repar", model);
			}
			else
				return PartialView("Repar", model);
		}


		//
		// POST: /Repar/Repar_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REPAR]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Repar_Duplicate(Repar_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Repar_Duplicate",
				ViewName = "Repar",
				AreaName = "repar",
				Location = ACTION_REPAR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REPAR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REPAR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REPAR]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Repar_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("repar", Convert.ToString(Navigation.CurrentLevel.GetEntry("repar"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REPAR");
		}

		#endregion

		#region Repar_Cancel

		//
		// GET: /Repar/Repar_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REPAR]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Repar_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Repar();
					model.klass.QPrimaryKey = Navigation.GetStrValue("repar");

// USE /[MANUAL GQT BEFORE_CANCEL REPAR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REPAR]/

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

				Navigation.SetValue("ForcePrimaryRead_repar", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "repar";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("repar");
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

		#region Repar Multiform actions

		//
		// GET /Repar/MFRepar_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFRepar_New")]
		public ActionResult MFRepar_New()
		{
			var model = new Repar_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_REPAR_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("repar", model.ValCodrepar);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFRepar", model);
		}

		//
		// GET /Repar/MFRepar_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFRepar_Edit")]
		public ActionResult MFRepar_Edit(string id)
		{
			return this.RedirectToAction("Repar_Edit", "Repar", new { id = id, partialView = "MFRepar", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Repar/MFRepar_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFRepar_Cancel")]
		public ActionResult MFRepar_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_REPAR_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_REPAR_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Repar();
						model.klass.QPrimaryKey = Navigation.GetStrValue("repar");

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

						Log.Error("MFRepar_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Repar_Show", "Repar", new { id = id, partialView = "MFRepar", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Repar/MFRepar_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFRepar_Save")]
		public JsonResult MFRepar_Save(Repar_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRepar_Save",
				ViewName = "MFRepar",
				AreaName = "repar"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Repar/MFRepar_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFRepar_Delete")]
		public JsonResult MFRepar_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRepar_Delete",
				ViewName = "MFRepar",
				AreaName = "repar",
				Location = ACTION_REPAR_EDIT
			};

			var model = new Repar_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: /Repar/Repar_EquipValRegistnr
		// POST: /Repar/Repar_EquipValRegistnr
		[AuthorizeForUsers]
		[ActionName("Repar_EquipValRegistnr")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Repar_EquipValRegistnr(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Repar_EquipValRegistnr_ViewModel model = new Repar_EquipValRegistnr_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

      
		//
		// GET: /Repar/Repar_SpeciValEspecial
		// POST: /Repar/Repar_SpeciValEspecial
		[AuthorizeForUsers]
		[ActionName("Repar_SpeciValEspecial")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Repar_SpeciValEspecial(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_speci")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_speci");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Repar_SpeciValEspecial_ViewModel model = new Repar_SpeciValEspecial_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
			// TODO: Remove the old version of limits that pass every field in separate parameters
			if (Limits != null)
			{
				foreach (KeyValuePair<string, string> par in Limits)
				{
					if (navigation.CheckFilledByHistory(par.Key)) continue;
					if (string.IsNullOrEmpty(par.Value))
						navigation.SetValue(par.Key, null);
					else
						navigation.SetValue(par.Key, par.Value);
				}
			}

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		//
		// GET: /Repar/Repar_PessoValName
		// POST: /Repar/Repar_PessoValName
		[AuthorizeForUsers]
		[ActionName("Repar_PessoValName")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Repar_PessoValName(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Repar_PessoValName_ViewModel model = new Repar_PessoValName_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
			// TODO: Remove the old version of limits that pass every field in separate parameters
			if (Limits != null)
			{
				foreach (KeyValuePair<string, string> par in Limits)
				{
					if (navigation.CheckFilledByHistory(par.Key)) continue;
					if (string.IsNullOrEmpty(par.Value))
						navigation.SetValue(par.Key, null);
					else
						navigation.SetValue(par.Key, par.Value);
				}
			}

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

  
		/// <summary>
		/// Server-side component of action #1 (AGENT) of trigger REPAIR_AGENT
		/// Button CATEG_AI
		/// </summary>
		/// <param name="data">The client-side context of the trigger.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult Repar_BT_CATEG_AI_REPAIR_AGENT_1(string key, Repar_ViewModel vm)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
				var model = Models.Repar.Find(key, "FREPAR");
				vm.MapToModel(model);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model.klass,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger REPAIR_AGENT
				CSGenio.business.Triggers.ITrigger trigger_REPAIR_AGENT = new CSGenio.business.Triggers.TriggerRepairAgent(context);
				CSGenio.business.Triggers.IAction action = trigger_REPAIR_AGENT.GetAction(1);
				trigger_REPAIR_AGENT.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
				sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

		/// <summary>
		/// Gets the value in the database of the field repar.tipoarea.
		/// Invoked during the execution of action #2 (CREFRESH) of trigger REPAIR_AGENT.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[AuthorizeForUsers]
		[ActionName("Repar_ValTipoarea")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Repar_ValTipoarea(string id)
		{
			var model = new Repar_ViewModel(Navigation, id, false, new string[] { CSGenioArepar.FldTipoarea.Field });

			return Json(new { model.ValTipoarea }, JsonRequestBehavior.AllowGet);
		}

 
		// POST: /Repar/Repar_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Repar_SaveEdit(Repar_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Repar_SaveEdit",
				ViewName = "Repar",
				AreaName = "repar",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REPAR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REPAR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
