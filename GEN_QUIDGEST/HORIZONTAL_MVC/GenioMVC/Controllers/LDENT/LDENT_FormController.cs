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
using GenioMVC.ViewModels.Ldent;


// USE /[MANUAL GQT INCLUDE_CONTROLLER LDENT]/

namespace GenioMVC.Controllers
{
	public partial class LdentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LDENT_CANCEL = new NavigationLocation("ENTRY29068", "Ldent_Cancel", "Ldent") { vueRouteName = "form-LDENT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LDENT_SHOW = new NavigationLocation("ENTRY29068", "Ldent_Show", "Ldent") { vueRouteName = "form-LDENT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LDENT_NEW = new NavigationLocation("ENTRY29068", "Ldent_New", "Ldent") { vueRouteName = "form-LDENT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LDENT_EDIT = new NavigationLocation("ENTRY29068", "Ldent_Edit", "Ldent") { vueRouteName = "form-LDENT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LDENT_DUPLICATE = new NavigationLocation("ENTRY29068", "Ldent_Duplicate", "Ldent") { vueRouteName = "form-LDENT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LDENT_DELETE = new NavigationLocation("ENTRY29068", "Ldent_Delete", "Ldent") { vueRouteName = "form-LDENT", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Ldent(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("ldent");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_LDENT_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_LDENT_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_LDENT_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_LDENT_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_LDENT_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Ldent private

		private void FormHistoryLimits_Ldent()
		{

		}

		#endregion


		[AuthorizeForUsers]
		public ActionResult Ldent_ModalDBEdit(string partialView)
		{
			Ldent_ViewModel model = new Ldent_ViewModel();
			model.setModes(Request.QueryString["m"]);
			model.Navigation = Navigation;
			model.Load(Request.Form, true, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

		#region Ldent_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LDENT]/
		//
		// GET: /Ldent/Ldent_Show
		[AuthorizeForUsers]
		public ActionResult Ldent_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Ldent_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			string partialView = qs["partialView"] ?? "Ldent"; // MF send the patial view name

			var navigationLocationAction = ACTION_LDENT_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("ldent"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("ldent", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW LDENT]/

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
				CSGenio.framework.Log.Error("Ldent_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW LDENT]/

			return PartialView("Ldent", model);
		}

		#endregion

		#region Ldent_New

		[ActionName("Ldent_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Ldent_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Ldent_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET LDENT]/
		//
		// GET: /Ldent/Ldent_New
		[ActionName("Ldent_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Ldent_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Ldent_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_LDENT_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("LDENT"))
				Navigation.OverrideSkipIfJustOne["LDENT"] = true;

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

					Navigation.SetValue("ldent", model.ValCodldent);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW LDENT]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW LDENT]/
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
				CSGenio.framework.Log.Error("Ldent_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return PartialView("_PermissionError", model: exceptionUserMessage);
			}

			return PartialView("Ldent", model);
		}


		//
		// POST: /Ldent/Ldent_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LDENT]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Ldent_New(Ldent_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_New",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_NEW,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LDENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LDENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LDENT]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Ldent_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Save", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Ldent_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LDENT]/
		//
		// GET: /Ldent/Ldent_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Ldent_Edit")]
		public ActionResult Ldent_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Ldent"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_LDENT_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_LDENT_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("ldent", id);

			var model = new Ldent_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT LDENT]/
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
				CSGenio.framework.Log.Error("Ldent_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT LDENT]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Ldent", model);
		}


		//
		// POST: /Ldent/Ldent_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LDENT]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Ldent_Edit(Ldent_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored

			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Edit",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_EDIT,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LDENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LDENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LDENT]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Ldent_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}


		#endregion

		#region Ldent_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LDENT]/
		//
		// GET: /Ldent/Ldent_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Ldent_Delete")]
		public ActionResult Ldent_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_LDENT_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("ldent", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Ldent_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE LDENT]/

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
				CSGenio.framework.Log.Error("Ldent_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE LDENT]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Ldent",model);
		}


		//
		// POST: /Ldent/Ldent_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LDENT]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Ldent_Delete(string id, FormCollection collection)
		{

			var model = new Ldent_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Delete",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_DELETE,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LDENT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Ldent_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LDENT");
		}

		#endregion

		#region Ldent_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LDENT]/
		//
		// GET: /Ldent/Ldent_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Ldent_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Ldent_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_LDENT_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LDENT]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LDENT]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_LDENT_DUPLICATE.SetRoutedValues(new { Id = model.ValCodldent }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("ldent", model.ValCodldent);
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

			return PartialView("Ldent", model);
		}


		//
		// POST: /Ldent/Ldent_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LDENT]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Ldent_Duplicate(Ldent_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Duplicate",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_DUPLICATE,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LDENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LDENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LDENT]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Ldent_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("ldent", Convert.ToString(Navigation.CurrentLevel.GetEntry("ldent"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Ldent_Cancel

		//
		// GET: /Ldent/Ldent_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LDENT]/
		[AuthorizeForUsers]
		public ActionResult Ldent_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ldent();
					model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");

// USE /[MANUAL GQT BEFORE_CANCEL LDENT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LDENT]/

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

				Navigation.SetValue("ForcePrimaryRead_ldent", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "ldent";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("ldent");
			if (Navigation.CurrentLevel.Location.Controller.ToUpper() == RouteData.Values["controller"].ToString().ToUpper()) Navigation.RemoveHistoryLevel();
			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Cancel" }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Ldent Multiform actions

		//
		// GET /Ldent/MFLdent_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLdent_New")]
		public ActionResult MFLdent_New()
		{
			var model = new Ldent_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_LDENT_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("ldent", model.ValCodldent);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFLdent", model);
		}

		//
		// GET /Ldent/MFLdent_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLdent_Edit")]
		public ActionResult MFLdent_Edit(string id)
		{
			return this.RedirectToAction("Ldent_Edit", "Ldent", new { id = id, partialView = "MFLdent", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Ldent/MFLdent_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFLdent_Cancel")]
		public ActionResult MFLdent_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_LDENT_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_LDENT_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Ldent();
						model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");

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

						Log.Error("MFLdent_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Ldent_Show", "Ldent", new { id = id, partialView = "MFLdent", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Ldent/MFLdent_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFLdent_Save")]
		public JsonResult MFLdent_Save(Ldent_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLdent_Save",
				ViewName = "MFLdent",
				AreaName = "ldent"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Ldent/MFLdent_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFLdent_Delete")]
		public JsonResult MFLdent_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFLdent_Delete",
				ViewName = "MFLdent",
				AreaName = "ldent",
				Location = ACTION_LDENT_EDIT
			};

			var model = new Ldent_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: /Ldent/Ldent_IndocValDocumenr
		// POST: /Ldent/Ldent_IndocValDocumenr
		[AuthorizeForUsers]
		[ActionName("Ldent_IndocValDocumenr")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Ldent_IndocValDocumenr(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_indoc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_indoc");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Ldent_IndocValDocumenr_ViewModel model = new Ldent_IndocValDocumenr_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodldent = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		//
		// GET: /Ldent/Ldent_WarehValWarehdes
		// POST: /Ldent/Ldent_WarehValWarehdes
		[AuthorizeForUsers]
		[ActionName("Ldent_WarehValWarehdes")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Ldent_WarehValWarehdes(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Ldent_WarehValWarehdes_ViewModel model = new Ldent_WarehValWarehdes_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodldent = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

   
		//
		// GET: /Ldent/Ldent_ItemValItemdes
		// POST: /Ldent/Ldent_ItemValItemdes
		[AuthorizeForUsers]
		[ActionName("Ldent_ItemValItemdes")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Ldent_ItemValItemdes(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Ldent_ItemValItemdes_ViewModel model = new Ldent_ItemValItemdes_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodldent = id;
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

  
		// POST: /Ldent/Ldent_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Ldent_SaveEdit(Ldent_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_SaveEdit",
				ViewName = "Ldent",
				AreaName = "ldent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LDENT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
