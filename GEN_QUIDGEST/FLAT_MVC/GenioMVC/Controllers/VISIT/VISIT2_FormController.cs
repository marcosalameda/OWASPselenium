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
using GenioMVC.ViewModels.Visit;


// USE /[MANUAL GQT INCLUDE_CONTROLLER VISIT]/

namespace GenioMVC.Controllers
{
	public partial class VisitController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VISIT2_CANCEL = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Cancel", "Visit") { vueRouteName = "form-VISIT2", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VISIT2_SHOW = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Show", "Visit") { vueRouteName = "form-VISIT2", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VISIT2_NEW = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_New", "Visit") { vueRouteName = "form-VISIT2", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VISIT2_EDIT = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Edit", "Visit") { vueRouteName = "form-VISIT2", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VISIT2_DUPLICATE = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Duplicate", "Visit") { vueRouteName = "form-VISIT2", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VISIT2_DELETE = new NavigationLocation("FULL_CALENDAR_EVENTS04140", "Visit2_Delete", "Visit") { vueRouteName = "form-VISIT2", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Visit2(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("visit");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_VISIT2_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_VISIT2_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_VISIT2_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_VISIT2_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_VISIT2_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Visit2 private

		private void FormHistoryLimits_Visit2()
		{

		}

		#endregion

		#region Visit2_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VISIT2]/
		//
		// GET: /Visit/Visit2_Show
		[AuthorizeForUsers]
		public ActionResult Visit2_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Visit2_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			string partialView = qs["partialView"] ?? "Visit2"; // MF send the patial view name

			var navigationLocationAction = ACTION_VISIT2_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("visit"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("visit", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW VISIT2]/

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
				CSGenio.framework.Log.Error("Visit2_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW VISIT2]/

			return PartialView("Visit2", model);
		}

		#endregion

		#region Visit2_New

		[ActionName("Visit2_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Visit2_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Visit2_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET VISIT2]/
		//
		// GET: /Visit/Visit2_New
		[ActionName("Visit2_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Visit2_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Visit2_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_VISIT2_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("VISIT2"))
				Navigation.OverrideSkipIfJustOne["VISIT2"] = true;

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

					Navigation.SetValue("visit", model.ValCodvisit);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW VISIT2]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW VISIT2]/
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
				return PartialView("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);

				ErrorMessage(exceptionUserMessage);
				CSGenio.framework.Log.Error("Visit2_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return PartialView("_PermissionError", model: exceptionUserMessage);
			}

			return PartialView("Visit2", model);
		}


		//
		// POST: /Visit/Visit2_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VISIT2]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Visit2_New(Visit2_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_New",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_NEW,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VISIT2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VISIT2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VISIT2]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Visit2_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Save", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Visit2_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VISIT2]/
		//
		// GET: /Visit/Visit2_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Visit2_Edit")]
		public ActionResult Visit2_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Visit2"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_VISIT2_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_VISIT2_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("visit", id);

			var model = new Visit2_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT VISIT2]/
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
				CSGenio.framework.Log.Error("Visit2_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT VISIT2]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Visit2", model);
		}


		//
		// POST: /Visit/Visit2_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VISIT2]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Visit2_Edit(Visit2_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored

			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Edit",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_EDIT,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VISIT2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VISIT2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VISIT2]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Visit2_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}


		#endregion

		#region Visit2_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VISIT2]/
		//
		// GET: /Visit/Visit2_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Visit2_Delete")]
		public ActionResult Visit2_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_VISIT2_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("visit", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Visit2_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE VISIT2]/

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
				CSGenio.framework.Log.Error("Visit2_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE VISIT2]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Visit2",model);
		}


		//
		// POST: /Visit/Visit2_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VISIT2]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Visit2_Delete(string id, FormCollection collection)
		{

			var model = new Visit2_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Delete",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_DELETE,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VISIT2]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Visit2_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VISIT2");
		}

		#endregion

		#region Visit2_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VISIT2]/
		//
		// GET: /Visit/Visit2_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Visit2_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Visit2_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_VISIT2_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VISIT2]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VISIT2]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_VISIT2_DUPLICATE.SetRoutedValues(new { Id = model.ValCodvisit }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("visit", model.ValCodvisit);
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

			return PartialView("Visit2", model);
		}


		//
		// POST: /Visit/Visit2_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VISIT2]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Visit2_Duplicate(Visit2_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_Duplicate",
				ViewName = "Visit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_DUPLICATE,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VISIT2]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VISIT2]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VISIT2]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Visit2_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("visit", Convert.ToString(Navigation.CurrentLevel.GetEntry("visit"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Visit2_Cancel

		//
		// GET: /Visit/Visit2_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VISIT2]/
		[AuthorizeForUsers]
		public ActionResult Visit2_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Visit();
					model.klass.QPrimaryKey = Navigation.GetStrValue("visit");

// USE /[MANUAL GQT BEFORE_CANCEL VISIT2]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VISIT2]/

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

					return RedirectToLocation(Navigation.CurrentLevel.Location);
				}

				Navigation.SetValue("ForcePrimaryRead_visit", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "visit";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("visit");
			if (Navigation.CurrentLevel.Location.Controller.ToUpper() == RouteData.Values["controller"].ToString().ToUpper()) Navigation.RemoveHistoryLevel();
			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Cancel" }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Visit2 Multiform actions

		//
		// GET /Visit/MFVisit2_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVisit2_New")]
		public ActionResult MFVisit2_New()
		{
			var model = new Visit2_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_VISIT2_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("visit", model.ValCodvisit);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFVisit2", model);
		}

		//
		// GET /Visit/MFVisit2_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVisit2_Edit")]
		public ActionResult MFVisit2_Edit(string id)
		{
			return this.RedirectToAction("Visit2_Edit", "Visit", new { id = id, partialView = "MFVisit2", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Visit/MFVisit2_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFVisit2_Cancel")]
		public ActionResult MFVisit2_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_VISIT2_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_VISIT2_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Visit();
						model.klass.QPrimaryKey = Navigation.GetStrValue("visit");

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

						Log.Error("MFVisit2_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Visit2_Show", "Visit", new { id = id, partialView = "MFVisit2", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Visit/MFVisit2_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFVisit2_Save")]
		public JsonResult MFVisit2_Save(Visit2_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVisit2_Save",
				ViewName = "MFVisit2",
				AreaName = "visit"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Visit/MFVisit2_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFVisit2_Delete")]
		public JsonResult MFVisit2_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFVisit2_Delete",
				ViewName = "MFVisit2",
				AreaName = "visit",
				Location = ACTION_VISIT2_EDIT
			};

			var model = new Visit2_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: /Visit/Visit2_EquipValRegistnr
		// POST: /Visit/Visit2_EquipValRegistnr
		[AuthorizeForUsers]
		[ActionName("Visit2_EquipValRegistnr")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Visit2_EquipValRegistnr(string id, string partialView,  IDictionary<string, string> Limits)
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
			Visit2_EquipValRegistnr_ViewModel model = new Visit2_EquipValRegistnr_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodvisit = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

       
		// POST: /Visit/Visit2_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Visit2_SaveEdit(Visit2_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Visit2_SaveEdit",
				ViewName = "Visit2",
				AreaName = "visit",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VISIT2]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VISIT2]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
