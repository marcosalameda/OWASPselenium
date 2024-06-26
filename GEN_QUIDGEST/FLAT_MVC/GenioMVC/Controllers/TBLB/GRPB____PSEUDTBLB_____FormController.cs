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
using GenioMVC.ViewModels.Tblb;


// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLB]/

namespace GenioMVC.Controllers
{
	public partial class TblbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____CANCEL = new NavigationLocation("CANCELAR49513", "Grpb____pseudtblb_____Cancel", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____SHOW = new NavigationLocation("CONSULTA40695", "Grpb____pseudtblb_____Show", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____NEW = new NavigationLocation("INSERIR43365", "Grpb____pseudtblb_____New", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____EDIT = new NavigationLocation("EDITAR11616", "Grpb____pseudtblb_____Edit", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____DUPLICATE = new NavigationLocation("DUPLICAR09748", "Grpb____pseudtblb_____Duplicate", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____DELETE = new NavigationLocation("APAGAR04097", "Grpb____pseudtblb_____Delete", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Grpb____pseudtblb____(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("tblb");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_GRPB____PSEUDTBLB_____SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_GRPB____PSEUDTBLB_____DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_GRPB____PSEUDTBLB_____EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_GRPB____PSEUDTBLB_____DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_GRPB____PSEUDTBLB_____NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Grpb____pseudtblb____ private

		private void FormHistoryLimits_Grpb____pseudtblb____()
		{

		}

		#endregion

		#region Grpb____pseudtblb_____Show

// USE /[MANUAL GQT CONTROLLER_SHOW GRPB____PSEUDTBLB____]/
		//
		// GET: /Tblb/Grpb____pseudtblb_____Show
		[AuthorizeForUsers]
		public ActionResult Grpb____pseudtblb_____Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Grpb____pseudtblb_____ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Grpb____pseudtblb____"; // MF send the patial view name

			var navigationLocationAction = ACTION_GRPB____PSEUDTBLB_____SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

			Navigation.SetValue("tblb", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW GRPB____PSEUDTBLB____]/

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
				CSGenio.framework.Log.Error("Grpb____pseudtblb_____Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW GRPB____PSEUDTBLB____]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Grpb____pseudtblb____");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Grpb____pseudtblb____", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Grpb____pseudtblb_____New

		[ActionName("Grpb____pseudtblb_____New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Grpb____pseudtblb_____New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Grpb____pseudtblb_____New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET GRPB____PSEUDTBLB____]/
		//
		// GET: /Tblb/Grpb____pseudtblb_____New
		[ActionName("Grpb____pseudtblb_____New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Grpb____pseudtblb_____New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Grpb____pseudtblb_____ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Grpb____pseudtblb____";

			var navigationLocationAction = ACTION_GRPB____PSEUDTBLB_____NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GRPB____PSEUDTBLB____"))
				Navigation.OverrideSkipIfJustOne["GRPB____PSEUDTBLB____"] = true;

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

					Navigation.SetValue("tblb", model.ValCodtblb);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW GRPB____PSEUDTBLB____]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW GRPB____PSEUDTBLB____]/
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
				CSGenio.framework.Log.Error("Grpb____pseudtblb_____New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Grpb____pseudtblb____", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Tblb/Grpb____pseudtblb_____New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GRPB____PSEUDTBLB____]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Grpb____pseudtblb_____New(Grpb____pseudtblb_____ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____New",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GRPB____PSEUDTBLB____]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Grpb____pseudtblb_____New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("tblb", Convert.ToString(Navigation.CurrentLevel.GetEntry("tblb"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_GRPB____PSEUDTBLB_____NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB____PSEUDTBLB____");
		}

		#endregion

		#region Grpb____pseudtblb_____Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GRPB____PSEUDTBLB____]/
		//
		// GET: /Tblb/Grpb____pseudtblb_____Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Grpb____pseudtblb_____Edit")]
		public ActionResult Grpb____pseudtblb_____Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Grpb____pseudtblb____"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_GRPB____PSEUDTBLB_____NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_GRPB____PSEUDTBLB_____EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("tblb", id);

			var model = new Grpb____pseudtblb_____ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT GRPB____PSEUDTBLB____]/
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
				CSGenio.framework.Log.Error("Grpb____pseudtblb_____Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT GRPB____PSEUDTBLB____]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Grpb____pseudtblb____", model);
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
		// POST: /Tblb/Grpb____pseudtblb_____Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GRPB____PSEUDTBLB____]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Grpb____pseudtblb_____Edit(Grpb____pseudtblb_____ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Edit",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GRPB____PSEUDTBLB____]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Grpb____pseudtblb_____Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("tblb", Convert.ToString(Navigation.CurrentLevel.GetEntry("tblb"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB____PSEUDTBLB____");
		}


		#endregion

		#region Grpb____pseudtblb_____Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GRPB____PSEUDTBLB____]/
		//
		// GET: /Tblb/Grpb____pseudtblb_____Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Grpb____pseudtblb_____Delete")]
		public ActionResult Grpb____pseudtblb_____Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_GRPB____PSEUDTBLB_____DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("tblb", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Grpb____pseudtblb_____ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE GRPB____PSEUDTBLB____]/

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
				CSGenio.framework.Log.Error("Grpb____pseudtblb_____Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE GRPB____PSEUDTBLB____]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Grpb____pseudtblb____", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Grpb____pseudtblb____", model);
		}


		//
		// POST: /Tblb/Grpb____pseudtblb_____Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GRPB____PSEUDTBLB____]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Grpb____pseudtblb_____Delete(string id, FormCollection collection)
		{

			var model = new Grpb____pseudtblb_____ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Delete",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Grpb____pseudtblb_____Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB____PSEUDTBLB____");
		}

		#endregion

		#region Grpb____pseudtblb_____Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GRPB____PSEUDTBLB____]/
		//
		// GET: /Tblb/Grpb____pseudtblb_____Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Grpb____pseudtblb_____Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Grpb____pseudtblb_____ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_GRPB____PSEUDTBLB_____DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GRPB____PSEUDTBLB____]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GRPB____PSEUDTBLB____]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_GRPB____PSEUDTBLB_____DUPLICATE.SetRoutedValues(new { Id = model.ValCodtblb }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("tblb", model.ValCodtblb);
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
				Navigation.SetValue("tblb", model.ValCodtblb);
				return View("Grpb____pseudtblb____", model);
			}
			else
				return PartialView("Grpb____pseudtblb____", model);
		}


		//
		// POST: /Tblb/Grpb____pseudtblb_____Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GRPB____PSEUDTBLB____]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Grpb____pseudtblb_____Duplicate(Grpb____pseudtblb_____ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____Duplicate",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GRPB____PSEUDTBLB____]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Grpb____pseudtblb_____Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("tblb", Convert.ToString(Navigation.CurrentLevel.GetEntry("tblb"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB____PSEUDTBLB____");
		}

		#endregion

		#region Grpb____pseudtblb_____Cancel

		//
		// GET: /Tblb/Grpb____pseudtblb_____Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GRPB____PSEUDTBLB____]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Grpb____pseudtblb_____Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tblb();
					model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");

// USE /[MANUAL GQT BEFORE_CANCEL GRPB____PSEUDTBLB____]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GRPB____PSEUDTBLB____]/

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

				Navigation.SetValue("ForcePrimaryRead_tblb", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "tblb";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("tblb");
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

		#region Grpb____pseudtblb____ Multiform actions

		//
		// GET /Tblb/MFGrpb____pseudtblb_____New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFGrpb____pseudtblb_____New")]
		public ActionResult MFGrpb____pseudtblb_____New()
		{
			var model = new Grpb____pseudtblb_____ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_GRPB____PSEUDTBLB_____NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("tblb", model.ValCodtblb);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFGrpb____pseudtblb____", model);
		}

		//
		// GET /Tblb/MFGrpb____pseudtblb_____Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFGrpb____pseudtblb_____Edit")]
		public ActionResult MFGrpb____pseudtblb_____Edit(string id)
		{
			return this.RedirectToAction("Grpb____pseudtblb_____Edit", "Tblb", new { id = id, partialView = "MFGrpb____pseudtblb____", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Tblb/MFGrpb____pseudtblb_____Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFGrpb____pseudtblb_____Cancel")]
		public ActionResult MFGrpb____pseudtblb_____Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_GRPB____PSEUDTBLB_____NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_GRPB____PSEUDTBLB_____EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Tblb();
						model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");

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

						Log.Error("MFGrpb____pseudtblb_____Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Grpb____pseudtblb_____Show", "Tblb", new { id = id, partialView = "MFGrpb____pseudtblb____", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Tblb/MFGrpb____pseudtblb_____Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFGrpb____pseudtblb_____Save")]
		public JsonResult MFGrpb____pseudtblb_____Save(Grpb____pseudtblb_____ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGrpb____pseudtblb_____Save",
				ViewName = "MFGrpb____pseudtblb____",
				AreaName = "tblb"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Tblb/MFGrpb____pseudtblb_____Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFGrpb____pseudtblb_____Delete")]
		public JsonResult MFGrpb____pseudtblb_____Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGrpb____pseudtblb_____Delete",
				ViewName = "MFGrpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT
			};

			var model = new Grpb____pseudtblb_____ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




             
		// POST: /Tblb/Grpb____pseudtblb_____SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Grpb____pseudtblb_____SaveEdit(Grpb____pseudtblb_____ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Grpb____pseudtblb_____SaveEdit",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
