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
using GenioMVC.ViewModels.Messa;


// USE /[MANUAL GQT INCLUDE_CONTROLLER MESSA]/

namespace GenioMVC.Controllers
{
	public partial class MessaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MESSA_CANCEL = new NavigationLocation("MESSAGE30602", "Messa_Cancel", "Messa") { vueRouteName = "form-MESSA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MESSA_SHOW = new NavigationLocation("MESSAGE30602", "Messa_Show", "Messa") { vueRouteName = "form-MESSA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MESSA_NEW = new NavigationLocation("MESSAGE30602", "Messa_New", "Messa") { vueRouteName = "form-MESSA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MESSA_EDIT = new NavigationLocation("MESSAGE30602", "Messa_Edit", "Messa") { vueRouteName = "form-MESSA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MESSA_DUPLICATE = new NavigationLocation("MESSAGE30602", "Messa_Duplicate", "Messa") { vueRouteName = "form-MESSA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MESSA_DELETE = new NavigationLocation("MESSAGE30602", "Messa_Delete", "Messa") { vueRouteName = "form-MESSA", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Messa(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("messa");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_MESSA_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_MESSA_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_MESSA_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_MESSA_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_MESSA_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Messa private

		private void FormHistoryLimits_Messa()
		{

		}

		#endregion

		#region Messa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW MESSA]/
		//
		// GET: /Messa/Messa_Show
		[AuthorizeForUsers]
		public ActionResult Messa_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Messa_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Messa"; // MF send the patial view name

			var navigationLocationAction = ACTION_MESSA_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("messa"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("messa", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW MESSA]/

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
				CSGenio.framework.Log.Error("Messa_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW MESSA]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Messa");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Messa", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Messa_New

		[ActionName("Messa_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Messa_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Messa_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET MESSA]/
		//
		// GET: /Messa/Messa_New
		[ActionName("Messa_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Messa_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Messa_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Messa";

			var navigationLocationAction = ACTION_MESSA_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("MESSA"))
				Navigation.OverrideSkipIfJustOne["MESSA"] = true;

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

					Navigation.SetValue("messa", model.ValCodmessa);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW MESSA]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW MESSA]/
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
				CSGenio.framework.Log.Error("Messa_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Messa", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Messa/Messa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST MESSA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Messa_New(Messa_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_New",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW MESSA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX MESSA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX MESSA]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Messa_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("messa", Convert.ToString(Navigation.CurrentLevel.GetEntry("messa"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_MESSA_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MESSA");
		}

		#endregion

		#region Messa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET MESSA]/
		//
		// GET: /Messa/Messa_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Messa_Edit")]
		public ActionResult Messa_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Messa"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_MESSA_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_MESSA_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("messa", id);

			var model = new Messa_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT MESSA]/
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
				CSGenio.framework.Log.Error("Messa_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT MESSA]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Messa", model);
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
		// POST: /Messa/Messa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST MESSA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Messa_Edit(Messa_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Messa_Edit",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT MESSA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX MESSA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX MESSA]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Messa_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("messa", Convert.ToString(Navigation.CurrentLevel.GetEntry("messa"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MESSA");
		}


		#endregion

		#region Messa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET MESSA]/
		//
		// GET: /Messa/Messa_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Messa_Delete")]
		public ActionResult Messa_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_MESSA_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("messa", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Messa_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE MESSA]/

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
				CSGenio.framework.Log.Error("Messa_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE MESSA]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Messa", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Messa", model);
		}


		//
		// POST: /Messa/Messa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST MESSA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Messa_Delete(string id, FormCollection collection)
		{

			var model = new Messa_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Messa_Delete",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE MESSA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Messa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MESSA");
		}

		#endregion

		#region Messa_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET MESSA]/
		//
		// GET: /Messa/Messa_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Messa_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Messa_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_MESSA_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE MESSA]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE MESSA]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_MESSA_DUPLICATE.SetRoutedValues(new { Id = model.ValCodmessa }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("messa", model.ValCodmessa);
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
				Navigation.SetValue("messa", model.ValCodmessa);
				return View("Messa", model);
			}
			else
				return PartialView("Messa", model);
		}


		//
		// POST: /Messa/Messa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST MESSA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Messa_Duplicate(Messa_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_Duplicate",
				ViewName = "Messa",
				AreaName = "messa",
				Location = ACTION_MESSA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE MESSA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX MESSA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX MESSA]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Messa_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("messa", Convert.ToString(Navigation.CurrentLevel.GetEntry("messa"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MESSA");
		}

		#endregion

		#region Messa_Cancel

		//
		// GET: /Messa/Messa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET MESSA]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Messa_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Messa();
					model.klass.QPrimaryKey = Navigation.GetStrValue("messa");

// USE /[MANUAL GQT BEFORE_CANCEL MESSA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL MESSA]/

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

				Navigation.SetValue("ForcePrimaryRead_messa", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "messa";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("messa");
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

		#region Messa Multiform actions

		//
		// GET /Messa/MFMessa_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFMessa_New")]
		public ActionResult MFMessa_New()
		{
			var model = new Messa_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_MESSA_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("messa", model.ValCodmessa);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFMessa", model);
		}

		//
		// GET /Messa/MFMessa_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFMessa_Edit")]
		public ActionResult MFMessa_Edit(string id)
		{
			return this.RedirectToAction("Messa_Edit", "Messa", new { id = id, partialView = "MFMessa", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Messa/MFMessa_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFMessa_Cancel")]
		public ActionResult MFMessa_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_MESSA_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_MESSA_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Messa();
						model.klass.QPrimaryKey = Navigation.GetStrValue("messa");

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

						Log.Error("MFMessa_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Messa_Show", "Messa", new { id = id, partialView = "MFMessa", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Messa/MFMessa_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFMessa_Save")]
		public JsonResult MFMessa_Save(Messa_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFMessa_Save",
				ViewName = "MFMessa",
				AreaName = "messa"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Messa/MFMessa_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFMessa_Delete")]
		public JsonResult MFMessa_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFMessa_Delete",
				ViewName = "MFMessa",
				AreaName = "messa",
				Location = ACTION_MESSA_EDIT
			};

			var model = new Messa_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




     
		//
		// GET: /Messa/Messa_EntitValName
		// POST: /Messa/Messa_EntitValName
		[AuthorizeForUsers]
		[ActionName("Messa_EntitValName")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Messa_EntitValName(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entit")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entit");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Messa_EntitValName_ViewModel model = new Messa_EntitValName_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		//
		// GET: /Messa/Messa_PersoValName
		// POST: /Messa/Messa_PersoValName
		[AuthorizeForUsers]
		[ActionName("Messa_PersoValName")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Messa_PersoValName(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Messa_PersoValName_ViewModel model = new Messa_PersoValName_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

      
		// POST: /Messa/Messa_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Messa_SaveEdit(Messa_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Messa_SaveEdit",
				ViewName = "Messa",
				AreaName = "messa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT MESSA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT MESSA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
