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
using GenioMVC.ViewModels.Gitem;


// USE /[MANUAL GQT INCLUDE_CONTROLLER GITEM]/

namespace GenioMVC.Controllers
{
	public partial class GitemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARTGL_CANCEL = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Cancel", "Gitem") { vueRouteName = "form-ARTGL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTGL_SHOW = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Show", "Gitem") { vueRouteName = "form-ARTGL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTGL_NEW = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_New", "Gitem") { vueRouteName = "form-ARTGL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTGL_EDIT = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Edit", "Gitem") { vueRouteName = "form-ARTGL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTGL_DUPLICATE = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Duplicate", "Gitem") { vueRouteName = "form-ARTGL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTGL_DELETE = new NavigationLocation("GLOBAL_ARTICLE63861", "Artgl_Delete", "Gitem") { vueRouteName = "form-ARTGL", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Artgl(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("gitem");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_ARTGL_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_ARTGL_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_ARTGL_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_ARTGL_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_ARTGL_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Artgl private

		private void FormHistoryLimits_Artgl()
		{

		}

		#endregion


		[AuthorizeForUsers]
		public ActionResult Artgl_ModalDBEdit(string partialView)
		{
			Artgl_ViewModel model = new Artgl_ViewModel();
			model.setModes(Request.QueryString["m"]);
			model.Navigation = Navigation;
			model.Load(Request.Form, true, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

		#region Artgl_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTGL]/
		//
		// GET: /Gitem/Artgl_Show
		[AuthorizeForUsers]
		public ActionResult Artgl_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Artgl_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			string partialView = qs["partialView"] ?? "Artgl"; // MF send the patial view name

			var navigationLocationAction = ACTION_ARTGL_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("gitem"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("gitem", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTGL]/

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
				CSGenio.framework.Log.Error("Artgl_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTGL]/

			return PartialView("Artgl", model);
		}

		#endregion

		#region Artgl_New

		[ActionName("Artgl_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Artgl_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Artgl_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTGL]/
		//
		// GET: /Gitem/Artgl_New
		[ActionName("Artgl_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Artgl_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Artgl_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_ARTGL_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("ARTGL"))
				Navigation.OverrideSkipIfJustOne["ARTGL"] = true;

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

					Navigation.SetValue("gitem", model.ValCodgitem);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTGL]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTGL]/
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
				CSGenio.framework.Log.Error("Artgl_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return PartialView("_PermissionError", model: exceptionUserMessage);
			}

			return PartialView("Artgl", model);
		}


		//
		// POST: /Gitem/Artgl_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTGL]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Artgl_New(Artgl_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_New",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_NEW,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTGL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTGL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTGL]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Artgl_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Save", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Artgl_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTGL]/
		//
		// GET: /Gitem/Artgl_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Artgl_Edit")]
		public ActionResult Artgl_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Artgl"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_ARTGL_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_ARTGL_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("gitem", id);

			var model = new Artgl_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTGL]/
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
				CSGenio.framework.Log.Error("Artgl_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTGL]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Artgl", model);
		}


		//
		// POST: /Gitem/Artgl_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTGL]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Artgl_Edit(Artgl_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored

			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Edit",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_EDIT,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTGL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTGL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTGL]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Artgl_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}


		#endregion

		#region Artgl_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTGL]/
		//
		// GET: /Gitem/Artgl_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Artgl_Delete")]
		public ActionResult Artgl_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_ARTGL_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("gitem", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Artgl_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTGL]/

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
				CSGenio.framework.Log.Error("Artgl_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTGL]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Artgl",model);
		}


		//
		// POST: /Gitem/Artgl_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTGL]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Artgl_Delete(string id, FormCollection collection)
		{

			var model = new Artgl_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Delete",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_DELETE,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTGL]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Artgl_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTGL");
		}

		#endregion

		#region Artgl_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTGL]/
		//
		// GET: /Gitem/Artgl_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Artgl_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Artgl_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_ARTGL_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTGL]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTGL]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_ARTGL_DUPLICATE.SetRoutedValues(new { Id = model.ValCodgitem }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("gitem", model.ValCodgitem);
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

			return PartialView("Artgl", model);
		}


		//
		// POST: /Gitem/Artgl_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTGL]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Artgl_Duplicate(Artgl_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_Duplicate",
				ViewName = "Artgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_DUPLICATE,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTGL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTGL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTGL]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Artgl_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("gitem", Convert.ToString(Navigation.CurrentLevel.GetEntry("gitem"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Artgl_Cancel

		//
		// GET: /Gitem/Artgl_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTGL]/
		[AuthorizeForUsers]
		public ActionResult Artgl_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Gitem();
					model.klass.QPrimaryKey = Navigation.GetStrValue("gitem");

// USE /[MANUAL GQT BEFORE_CANCEL ARTGL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTGL]/

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

				Navigation.SetValue("ForcePrimaryRead_gitem", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "gitem";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("gitem");
			if (Navigation.CurrentLevel.Location.Controller.ToUpper() == RouteData.Values["controller"].ToString().ToUpper()) Navigation.RemoveHistoryLevel();
			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Cancel" }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Artgl Multiform actions

		//
		// GET /Gitem/MFArtgl_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFArtgl_New")]
		public ActionResult MFArtgl_New()
		{
			var model = new Artgl_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ARTGL_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("gitem", model.ValCodgitem);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFArtgl", model);
		}

		//
		// GET /Gitem/MFArtgl_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFArtgl_Edit")]
		public ActionResult MFArtgl_Edit(string id)
		{
			return this.RedirectToAction("Artgl_Edit", "Gitem", new { id = id, partialView = "MFArtgl", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Gitem/MFArtgl_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFArtgl_Cancel")]
		public ActionResult MFArtgl_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_ARTGL_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_ARTGL_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Gitem();
						model.klass.QPrimaryKey = Navigation.GetStrValue("gitem");

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

						Log.Error("MFArtgl_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Artgl_Show", "Gitem", new { id = id, partialView = "MFArtgl", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Gitem/MFArtgl_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFArtgl_Save")]
		public JsonResult MFArtgl_Save(Artgl_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFArtgl_Save",
				ViewName = "MFArtgl",
				AreaName = "gitem"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Gitem/MFArtgl_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFArtgl_Delete")]
		public JsonResult MFArtgl_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFArtgl_Delete",
				ViewName = "MFArtgl",
				AreaName = "gitem",
				Location = ACTION_ARTGL_EDIT
			};

			var model = new Artgl_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




   
		// POST: /Gitem/Artgl_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Artgl_SaveEdit(Artgl_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artgl_SaveEdit",
				ViewName = "Artgl",
				AreaName = "gitem",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTGL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTGL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
