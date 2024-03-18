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
using GenioMVC.ViewModels.Cmpny;


// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPNY]/

namespace GenioMVC.Controllers
{
	public partial class CmpnyController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EMPRE_CANCEL = new NavigationLocation("COMPANY52963", "Empre_Cancel", "Cmpny") { vueRouteName = "form-EMPRE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EMPRE_SHOW = new NavigationLocation("COMPANY52963", "Empre_Show", "Cmpny") { vueRouteName = "form-EMPRE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EMPRE_NEW = new NavigationLocation("COMPANY52963", "Empre_New", "Cmpny") { vueRouteName = "form-EMPRE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EMPRE_EDIT = new NavigationLocation("COMPANY52963", "Empre_Edit", "Cmpny") { vueRouteName = "form-EMPRE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EMPRE_DUPLICATE = new NavigationLocation("COMPANY52963", "Empre_Duplicate", "Cmpny") { vueRouteName = "form-EMPRE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EMPRE_DELETE = new NavigationLocation("COMPANY52963", "Empre_Delete", "Cmpny") { vueRouteName = "form-EMPRE", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Empre(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("cmpny");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_EMPRE_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_EMPRE_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_EMPRE_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_EMPRE_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_EMPRE_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Empre private

		private void FormHistoryLimits_Empre()
		{

		}

		#endregion


		[AuthorizeForUsers]
		public ActionResult Empre_ModalDBEdit(string partialView)
		{
			Empre_ViewModel model = new Empre_ViewModel();
			model.setModes(Request.QueryString["m"]);
			model.Navigation = Navigation;
			model.Load(Request.Form, true, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

		#region Empre_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EMPRE]/
		//
		// GET: /Cmpny/Empre_Show
		[AuthorizeForUsers]
		public ActionResult Empre_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Empre_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			string partialView = qs["partialView"] ?? "Empre"; // MF send the patial view name

			var navigationLocationAction = ACTION_EMPRE_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("cmpny"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("cmpny", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW EMPRE]/

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
				CSGenio.framework.Log.Error("Empre_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW EMPRE]/

			return PartialView("Empre", model);
		}

		#endregion

		#region Empre_New

		[ActionName("Empre_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Empre_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Empre_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET EMPRE]/
		//
		// GET: /Cmpny/Empre_New
		[ActionName("Empre_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Empre_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Empre_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_EMPRE_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("EMPRE"))
				Navigation.OverrideSkipIfJustOne["EMPRE"] = true;

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

					Navigation.SetValue("cmpny", model.ValCodempre);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW EMPRE]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW EMPRE]/
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
				CSGenio.framework.Log.Error("Empre_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return PartialView("_PermissionError", model: exceptionUserMessage);
			}

			return PartialView("Empre", model);
		}


		//
		// POST: /Cmpny/Empre_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EMPRE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Empre_New(Empre_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_New",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_NEW,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EMPRE]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Empre_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Save", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Empre_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EMPRE]/
		//
		// GET: /Cmpny/Empre_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Empre_Edit")]
		public ActionResult Empre_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Empre"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_EMPRE_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_EMPRE_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("cmpny", id);

			var model = new Empre_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT EMPRE]/
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
				CSGenio.framework.Log.Error("Empre_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT EMPRE]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Empre", model);
		}


		//
		// POST: /Cmpny/Empre_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EMPRE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Empre_Edit(Empre_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored

			var eventSink = new EventSink()
			{
				MethodName = "Empre_Edit",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_EDIT,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EMPRE]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Empre_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}


		#endregion

		#region Empre_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EMPRE]/
		//
		// GET: /Cmpny/Empre_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Empre_Delete")]
		public ActionResult Empre_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_EMPRE_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("cmpny", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Empre_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE EMPRE]/

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
				CSGenio.framework.Log.Error("Empre_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE EMPRE]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Empre",model);
		}


		//
		// POST: /Cmpny/Empre_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EMPRE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Empre_Delete(string id, FormCollection collection)
		{

			var model = new Empre_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Empre_Delete",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_DELETE,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EMPRE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Empre_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EMPRE");
		}

		#endregion

		#region Empre_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EMPRE]/
		//
		// GET: /Cmpny/Empre_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Empre_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Empre_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_EMPRE_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EMPRE]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EMPRE]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_EMPRE_DUPLICATE.SetRoutedValues(new { Id = model.ValCodempre }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("cmpny", model.ValCodempre);
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

			return PartialView("Empre", model);
		}


		//
		// POST: /Cmpny/Empre_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EMPRE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Empre_Duplicate(Empre_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Duplicate",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_DUPLICATE,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EMPRE]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Empre_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("cmpny", Convert.ToString(Navigation.CurrentLevel.GetEntry("cmpny"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Empre_Cancel

		//
		// GET: /Cmpny/Empre_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EMPRE]/
		[AuthorizeForUsers]
		public ActionResult Empre_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cmpny();
					model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");

// USE /[MANUAL GQT BEFORE_CANCEL EMPRE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EMPRE]/

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

				Navigation.SetValue("ForcePrimaryRead_cmpny", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "cmpny";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("cmpny");
			if (Navigation.CurrentLevel.Location.Controller.ToUpper() == RouteData.Values["controller"].ToString().ToUpper()) Navigation.RemoveHistoryLevel();
			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Cancel" }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Empre Multiform actions

		//
		// GET /Cmpny/MFEmpre_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFEmpre_New")]
		public ActionResult MFEmpre_New()
		{
			var model = new Empre_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_EMPRE_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("cmpny", model.ValCodempre);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFEmpre", model);
		}

		//
		// GET /Cmpny/MFEmpre_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFEmpre_Edit")]
		public ActionResult MFEmpre_Edit(string id)
		{
			return this.RedirectToAction("Empre_Edit", "Cmpny", new { id = id, partialView = "MFEmpre", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Cmpny/MFEmpre_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFEmpre_Cancel")]
		public ActionResult MFEmpre_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_EMPRE_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_EMPRE_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Cmpny();
						model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");

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

						Log.Error("MFEmpre_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Empre_Show", "Cmpny", new { id = id, partialView = "MFEmpre", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Cmpny/MFEmpre_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFEmpre_Save")]
		public JsonResult MFEmpre_Save(Empre_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEmpre_Save",
				ViewName = "MFEmpre",
				AreaName = "cmpny"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Cmpny/MFEmpre_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFEmpre_Delete")]
		public JsonResult MFEmpre_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEmpre_Delete",
				ViewName = "MFEmpre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_EDIT
			};

			var model = new Empre_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




       
		//
		// GET: /Cmpny/Empre_CntryValCountry
		// POST: /Cmpny/Empre_CntryValCountry
		[AuthorizeForUsers]
		[ActionName("Empre_CntryValCountry")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Empre_CntryValCountry(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Empre_CntryValCountry_ViewModel model = new Empre_CntryValCountry_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodempre = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

  
		// POST: /Cmpny/Empre_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Empre_SaveEdit(Empre_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_SaveEdit",
				ViewName = "Empre",
				AreaName = "cmpny",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EMPRE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
