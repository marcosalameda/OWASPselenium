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
using GenioMVC.ViewModels.Feeca;


// USE /[MANUAL GQT INCLUDE_CONTROLLER FEECA]/

namespace GenioMVC.Controllers
{
	public partial class FeecaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__CANCEL = new NavigationLocation("CANCELAR49513", "Fldscondpseudgridtbl__Cancel", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__SHOW = new NavigationLocation("CONSULTA40695", "Fldscondpseudgridtbl__Show", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__NEW = new NavigationLocation("INSERIR43365", "Fldscondpseudgridtbl__New", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__EDIT = new NavigationLocation("EDITAR11616", "Fldscondpseudgridtbl__Edit", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE = new NavigationLocation("DUPLICAR09748", "Fldscondpseudgridtbl__Duplicate", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FLDSCONDPSEUDGRIDTBL__DELETE = new NavigationLocation("APAGAR04097", "Fldscondpseudgridtbl__Delete", "Feeca") { vueRouteName = "form-FLDSCONDPSEUDGRIDTBL_", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Fldscondpseudgridtbl_(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("feeca");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_FLDSCONDPSEUDGRIDTBL__SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_FLDSCONDPSEUDGRIDTBL__DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_FLDSCONDPSEUDGRIDTBL__EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_FLDSCONDPSEUDGRIDTBL__NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Fldscondpseudgridtbl_ private

		private void FormHistoryLimits_Fldscondpseudgridtbl_()
		{

		}

		#endregion

		#region Fldscondpseudgridtbl__Show

// USE /[MANUAL GQT CONTROLLER_SHOW FLDSCONDPSEUDGRIDTBL_]/
		//
		// GET: /Feeca/Fldscondpseudgridtbl__Show
		[AuthorizeForUsers]
		public ActionResult Fldscondpseudgridtbl__Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Fldscondpseudgridtbl_"; // MF send the patial view name

			var navigationLocationAction = ACTION_FLDSCONDPSEUDGRIDTBL__SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("feeca", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW FLDSCONDPSEUDGRIDTBL_]/

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
				CSGenio.framework.Log.Error("Fldscondpseudgridtbl__Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW FLDSCONDPSEUDGRIDTBL_]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Fldscondpseudgridtbl_");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Fldscondpseudgridtbl_", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Fldscondpseudgridtbl__New

		[ActionName("Fldscondpseudgridtbl__New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Fldscondpseudgridtbl__New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Fldscondpseudgridtbl__New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET FLDSCONDPSEUDGRIDTBL_]/
		//
		// GET: /Feeca/Fldscondpseudgridtbl__New
		[ActionName("Fldscondpseudgridtbl__New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Fldscondpseudgridtbl__New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Fldscondpseudgridtbl_";

			var navigationLocationAction = ACTION_FLDSCONDPSEUDGRIDTBL__NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("FLDSCONDPSEUDGRIDTBL_"))
				Navigation.OverrideSkipIfJustOne["FLDSCONDPSEUDGRIDTBL_"] = true;

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

					Navigation.SetValue("feeca", model.ValCodfeeca);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW FLDSCONDPSEUDGRIDTBL_]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW FLDSCONDPSEUDGRIDTBL_]/
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
				CSGenio.framework.Log.Error("Fldscondpseudgridtbl__New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Fldscondpseudgridtbl_", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Feeca/Fldscondpseudgridtbl__New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FLDSCONDPSEUDGRIDTBL_]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Fldscondpseudgridtbl__New(Fldscondpseudgridtbl__ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__New",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FLDSCONDPSEUDGRIDTBL_]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FLDSCONDPSEUDGRIDTBL_]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Fldscondpseudgridtbl__New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("feeca", Convert.ToString(Navigation.CurrentLevel.GetEntry("feeca"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_FLDSCONDPSEUDGRIDTBL__NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSCONDPSEUDGRIDTBL_");
		}

		#endregion

		#region Fldscondpseudgridtbl__Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FLDSCONDPSEUDGRIDTBL_]/
		//
		// GET: /Feeca/Fldscondpseudgridtbl__Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Fldscondpseudgridtbl__Edit")]
		public ActionResult Fldscondpseudgridtbl__Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Fldscondpseudgridtbl_"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_FLDSCONDPSEUDGRIDTBL__NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_FLDSCONDPSEUDGRIDTBL__EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("feeca", id);

			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT FLDSCONDPSEUDGRIDTBL_]/
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
				CSGenio.framework.Log.Error("Fldscondpseudgridtbl__Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT FLDSCONDPSEUDGRIDTBL_]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Fldscondpseudgridtbl_", model);
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
		// POST: /Feeca/Fldscondpseudgridtbl__Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FLDSCONDPSEUDGRIDTBL_]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Fldscondpseudgridtbl__Edit(Fldscondpseudgridtbl__ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Edit",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FLDSCONDPSEUDGRIDTBL_]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Fldscondpseudgridtbl__Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("feeca", Convert.ToString(Navigation.CurrentLevel.GetEntry("feeca"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSCONDPSEUDGRIDTBL_");
		}


		#endregion

		#region Fldscondpseudgridtbl__Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FLDSCONDPSEUDGRIDTBL_]/
		//
		// GET: /Feeca/Fldscondpseudgridtbl__Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Fldscondpseudgridtbl__Delete")]
		public ActionResult Fldscondpseudgridtbl__Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_FLDSCONDPSEUDGRIDTBL__DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("feeca", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE FLDSCONDPSEUDGRIDTBL_]/

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
				CSGenio.framework.Log.Error("Fldscondpseudgridtbl__Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE FLDSCONDPSEUDGRIDTBL_]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Fldscondpseudgridtbl_", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Fldscondpseudgridtbl_", model);
		}


		//
		// POST: /Feeca/Fldscondpseudgridtbl__Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FLDSCONDPSEUDGRIDTBL_]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Fldscondpseudgridtbl__Delete(string id, FormCollection collection)
		{

			var model = new Fldscondpseudgridtbl__ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Delete",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Fldscondpseudgridtbl__Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSCONDPSEUDGRIDTBL_");
		}

		#endregion

		#region Fldscondpseudgridtbl__Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FLDSCONDPSEUDGRIDTBL_]/
		//
		// GET: /Feeca/Fldscondpseudgridtbl__Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Fldscondpseudgridtbl__Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE.SetRoutedValues(new { Id = model.ValCodfeeca }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("feeca", model.ValCodfeeca);
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
				Navigation.SetValue("feeca", model.ValCodfeeca);
				return View("Fldscondpseudgridtbl_", model);
			}
			else
				return PartialView("Fldscondpseudgridtbl_", model);
		}


		//
		// POST: /Feeca/Fldscondpseudgridtbl__Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FLDSCONDPSEUDGRIDTBL_]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Fldscondpseudgridtbl__Duplicate(Fldscondpseudgridtbl__ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__Duplicate",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FLDSCONDPSEUDGRIDTBL_]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Fldscondpseudgridtbl__Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("feeca", Convert.ToString(Navigation.CurrentLevel.GetEntry("feeca"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSCONDPSEUDGRIDTBL_");
		}

		#endregion

		#region Fldscondpseudgridtbl__Cancel

		//
		// GET: /Feeca/Fldscondpseudgridtbl__Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FLDSCONDPSEUDGRIDTBL_]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Fldscondpseudgridtbl__Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Feeca();
					model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");

// USE /[MANUAL GQT BEFORE_CANCEL FLDSCONDPSEUDGRIDTBL_]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FLDSCONDPSEUDGRIDTBL_]/

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

				Navigation.SetValue("ForcePrimaryRead_feeca", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "feeca";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("feeca");
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

		#region Fldscondpseudgridtbl_ Multiform actions

		//
		// GET /Feeca/MFFldscondpseudgridtbl__New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFFldscondpseudgridtbl__New")]
		public ActionResult MFFldscondpseudgridtbl__New()
		{
			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_FLDSCONDPSEUDGRIDTBL__NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("feeca", model.ValCodfeeca);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFFldscondpseudgridtbl_", model);
		}

		//
		// GET /Feeca/MFFldscondpseudgridtbl__Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFFldscondpseudgridtbl__Edit")]
		public ActionResult MFFldscondpseudgridtbl__Edit(string id)
		{
			return this.RedirectToAction("Fldscondpseudgridtbl__Edit", "Feeca", new { id = id, partialView = "MFFldscondpseudgridtbl_", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Feeca/MFFldscondpseudgridtbl__Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFFldscondpseudgridtbl__Cancel")]
		public ActionResult MFFldscondpseudgridtbl__Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_FLDSCONDPSEUDGRIDTBL__NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_FLDSCONDPSEUDGRIDTBL__EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Feeca();
						model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");

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

						Log.Error("MFFldscondpseudgridtbl__Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Fldscondpseudgridtbl__Show", "Feeca", new { id = id, partialView = "MFFldscondpseudgridtbl_", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Feeca/MFFldscondpseudgridtbl__Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFFldscondpseudgridtbl__Save")]
		public JsonResult MFFldscondpseudgridtbl__Save(Fldscondpseudgridtbl__ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFFldscondpseudgridtbl__Save",
				ViewName = "MFFldscondpseudgridtbl_",
				AreaName = "feeca"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Feeca/MFFldscondpseudgridtbl__Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFFldscondpseudgridtbl__Delete")]
		public JsonResult MFFldscondpseudgridtbl__Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFFldscondpseudgridtbl__Delete",
				ViewName = "MFFldscondpseudgridtbl_",
				AreaName = "feeca",
				Location = ACTION_FLDSCONDPSEUDGRIDTBL__EDIT
			};

			var model = new Fldscondpseudgridtbl__ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		// POST: /Feeca/Fldscondpseudgridtbl__SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Fldscondpseudgridtbl__SaveEdit(Fldscondpseudgridtbl__ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscondpseudgridtbl__SaveEdit",
				ViewName = "Fldscondpseudgridtbl_",
				AreaName = "feeca",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FLDSCONDPSEUDGRIDTBL_]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FLDSCONDPSEUDGRIDTBL_]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
