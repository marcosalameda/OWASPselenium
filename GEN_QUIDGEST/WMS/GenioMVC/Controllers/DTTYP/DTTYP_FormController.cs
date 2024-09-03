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
using GenioMVC.ViewModels.Dttyp;


// USE /[MANUAL GQT INCLUDE_CONTROLLER DTTYP]/

namespace GenioMVC.Controllers
{
	public partial class DttypController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DTTYP_CANCEL = new NavigationLocation("DATA_TYPE47159", "Dttyp_Cancel", "Dttyp") { vueRouteName = "form-DTTYP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DTTYP_SHOW = new NavigationLocation("DATA_TYPE47159", "Dttyp_Show", "Dttyp") { vueRouteName = "form-DTTYP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DTTYP_NEW = new NavigationLocation("DATA_TYPE47159", "Dttyp_New", "Dttyp") { vueRouteName = "form-DTTYP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DTTYP_EDIT = new NavigationLocation("DATA_TYPE47159", "Dttyp_Edit", "Dttyp") { vueRouteName = "form-DTTYP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DTTYP_DUPLICATE = new NavigationLocation("DATA_TYPE47159", "Dttyp_Duplicate", "Dttyp") { vueRouteName = "form-DTTYP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DTTYP_DELETE = new NavigationLocation("DATA_TYPE47159", "Dttyp_Delete", "Dttyp") { vueRouteName = "form-DTTYP", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Dttyp(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("dttyp");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_DTTYP_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_DTTYP_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_DTTYP_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_DTTYP_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_DTTYP_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Dttyp private

		private void FormHistoryLimits_Dttyp()
		{

		}

		#endregion

		#region Dttyp_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DTTYP]/
		//
		// GET: /Dttyp/Dttyp_Show
		[AuthorizeForUsers]
		public ActionResult Dttyp_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Dttyp_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Dttyp"; // MF send the patial view name

			var navigationLocationAction = ACTION_DTTYP_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("dttyp"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("dttyp", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW DTTYP]/

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
				CSGenio.framework.Log.Error("Dttyp_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW DTTYP]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Dttyp");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Dttyp", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Dttyp_New

		[ActionName("Dttyp_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Dttyp_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Dttyp_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET DTTYP]/
		//
		// GET: /Dttyp/Dttyp_New
		[ActionName("Dttyp_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Dttyp_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Dttyp_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Dttyp";

			var navigationLocationAction = ACTION_DTTYP_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("DTTYP"))
				Navigation.OverrideSkipIfJustOne["DTTYP"] = true;

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

					Navigation.SetValue("dttyp", model.ValCoddttyp);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW DTTYP]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW DTTYP]/
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
				CSGenio.framework.Log.Error("Dttyp_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Dttyp", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Dttyp/Dttyp_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DTTYP]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Dttyp_New(Dttyp_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dttyp_New",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DTTYP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DTTYP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DTTYP]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Dttyp_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("dttyp", Convert.ToString(Navigation.CurrentLevel.GetEntry("dttyp"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_DTTYP_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DTTYP");
		}

		#endregion

		#region Dttyp_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DTTYP]/
		//
		// GET: /Dttyp/Dttyp_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Dttyp_Edit")]
		public ActionResult Dttyp_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Dttyp"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_DTTYP_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_DTTYP_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("dttyp", id);

			var model = new Dttyp_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT DTTYP]/
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
				CSGenio.framework.Log.Error("Dttyp_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT DTTYP]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Dttyp", model);
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
		// POST: /Dttyp/Dttyp_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DTTYP]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Dttyp_Edit(Dttyp_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Dttyp_Edit",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DTTYP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DTTYP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DTTYP]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Dttyp_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("dttyp", Convert.ToString(Navigation.CurrentLevel.GetEntry("dttyp"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DTTYP");
		}


		#endregion

		#region Dttyp_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DTTYP]/
		//
		// GET: /Dttyp/Dttyp_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Dttyp_Delete")]
		public ActionResult Dttyp_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_DTTYP_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("dttyp", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Dttyp_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE DTTYP]/

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
				CSGenio.framework.Log.Error("Dttyp_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE DTTYP]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Dttyp", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Dttyp", model);
		}


		//
		// POST: /Dttyp/Dttyp_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DTTYP]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Dttyp_Delete(string id, FormCollection collection)
		{

			var model = new Dttyp_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Dttyp_Delete",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DTTYP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Dttyp_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DTTYP");
		}

		#endregion

		#region Dttyp_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DTTYP]/
		//
		// GET: /Dttyp/Dttyp_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Dttyp_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Dttyp_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_DTTYP_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DTTYP]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DTTYP]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_DTTYP_DUPLICATE.SetRoutedValues(new { Id = model.ValCoddttyp }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("dttyp", model.ValCoddttyp);
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
				Navigation.SetValue("dttyp", model.ValCoddttyp);
				return View("Dttyp", model);
			}
			else
				return PartialView("Dttyp", model);
		}


		//
		// POST: /Dttyp/Dttyp_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DTTYP]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Dttyp_Duplicate(Dttyp_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dttyp_Duplicate",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DTTYP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DTTYP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DTTYP]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Dttyp_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("dttyp", Convert.ToString(Navigation.CurrentLevel.GetEntry("dttyp"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DTTYP");
		}

		#endregion

		#region Dttyp_Cancel

		//
		// GET: /Dttyp/Dttyp_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DTTYP]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Dttyp_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Dttyp();
					model.klass.QPrimaryKey = Navigation.GetStrValue("dttyp");

// USE /[MANUAL GQT BEFORE_CANCEL DTTYP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DTTYP]/

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

				Navigation.SetValue("ForcePrimaryRead_dttyp", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "dttyp";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("dttyp");
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

		#region Dttyp Multiform actions

		//
		// GET /Dttyp/MFDttyp_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFDttyp_New")]
		public ActionResult MFDttyp_New()
		{
			var model = new Dttyp_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_DTTYP_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("dttyp", model.ValCoddttyp);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFDttyp", model);
		}

		//
		// GET /Dttyp/MFDttyp_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFDttyp_Edit")]
		public ActionResult MFDttyp_Edit(string id)
		{
			return this.RedirectToAction("Dttyp_Edit", "Dttyp", new { id = id, partialView = "MFDttyp", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Dttyp/MFDttyp_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFDttyp_Cancel")]
		public ActionResult MFDttyp_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_DTTYP_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_DTTYP_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Dttyp();
						model.klass.QPrimaryKey = Navigation.GetStrValue("dttyp");

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

						Log.Error("MFDttyp_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Dttyp_Show", "Dttyp", new { id = id, partialView = "MFDttyp", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Dttyp/MFDttyp_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFDttyp_Save")]
		public JsonResult MFDttyp_Save(Dttyp_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFDttyp_Save",
				ViewName = "MFDttyp",
				AreaName = "dttyp"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Dttyp/MFDttyp_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFDttyp_Delete")]
		public JsonResult MFDttyp_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFDttyp_Delete",
				ViewName = "MFDttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_EDIT
			};

			var model = new Dttyp_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




                      
		// POST: /Dttyp/Dttyp_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Dttyp_SaveEdit(Dttyp_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dttyp_SaveEdit",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DTTYP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
