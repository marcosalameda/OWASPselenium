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
using GenioMVC.ViewModels.Rules;


// USE /[MANUAL GQT INCLUDE_CONTROLLER RULES]/

namespace GenioMVC.Controllers
{
	public partial class RulesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REGRA_CANCEL = new NavigationLocation("REGRA09608", "Regra_Cancel", "Rules") { vueRouteName = "form-REGRA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGRA_SHOW = new NavigationLocation("REGRA09608", "Regra_Show", "Rules") { vueRouteName = "form-REGRA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGRA_NEW = new NavigationLocation("REGRA09608", "Regra_New", "Rules") { vueRouteName = "form-REGRA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGRA_EDIT = new NavigationLocation("REGRA09608", "Regra_Edit", "Rules") { vueRouteName = "form-REGRA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGRA_DUPLICATE = new NavigationLocation("REGRA09608", "Regra_Duplicate", "Rules") { vueRouteName = "form-REGRA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGRA_DELETE = new NavigationLocation("REGRA09608", "Regra_Delete", "Rules") { vueRouteName = "form-REGRA", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Regra(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("rules");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_REGRA_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_REGRA_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_REGRA_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_REGRA_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_REGRA_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Regra private

		private void FormHistoryLimits_Regra()
		{

		}

		#endregion

		#region Regra_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGRA]/
		//
		// GET: /Rules/Regra_Show
		[AuthorizeForUsers]
		public ActionResult Regra_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Regra_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Regra"; // MF send the patial view name

			var navigationLocationAction = ACTION_REGRA_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("rules"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("rules", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGRA]/

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
				CSGenio.framework.Log.Error("Regra_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW REGRA]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "Regra");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("Regra", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region Regra_New

		[ActionName("Regra_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Regra_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Regra_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGRA]/
		//
		// GET: /Rules/Regra_New
		[ActionName("Regra_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Regra_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Regra_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "Regra";

			var navigationLocationAction = ACTION_REGRA_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("REGRA"))
				Navigation.OverrideSkipIfJustOne["REGRA"] = true;

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

					Navigation.SetValue("rules", model.ValCodregra);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGRA]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW REGRA]/
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
				CSGenio.framework.Log.Error("Regra_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("Regra", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: /Rules/Regra_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGRA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Regra_New(Regra_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_New",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGRA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGRA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGRA]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Regra_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("rules", Convert.ToString(Navigation.CurrentLevel.GetEntry("rules"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_REGRA_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGRA");
		}

		#endregion

		#region Regra_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGRA]/
		//
		// GET: /Rules/Regra_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Regra_Edit")]
		public ActionResult Regra_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Regra"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_REGRA_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_REGRA_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("rules", id);

			var model = new Regra_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGRA]/
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
				CSGenio.framework.Log.Error("Regra_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT REGRA]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Regra", model);
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
		// POST: /Rules/Regra_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGRA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Regra_Edit(Regra_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "Regra_Edit",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGRA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGRA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGRA]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Regra_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("rules", Convert.ToString(Navigation.CurrentLevel.GetEntry("rules"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGRA");
		}


		#endregion

		#region Regra_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGRA]/
		//
		// GET: /Rules/Regra_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Regra_Delete")]
		public ActionResult Regra_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_REGRA_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("rules", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Regra_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGRA]/

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
				CSGenio.framework.Log.Error("Regra_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE REGRA]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("Regra", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("Regra", model);
		}


		//
		// POST: /Rules/Regra_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGRA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Regra_Delete(string id, FormCollection collection)
		{

			var model = new Regra_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regra_Delete",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGRA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Regra_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGRA");
		}

		#endregion

		#region Regra_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGRA]/
		//
		// GET: /Rules/Regra_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Regra_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Regra_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_REGRA_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGRA]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGRA]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_REGRA_DUPLICATE.SetRoutedValues(new { Id = model.ValCodregra }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("rules", model.ValCodregra);
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
				Navigation.SetValue("rules", model.ValCodregra);
				return View("Regra", model);
			}
			else
				return PartialView("Regra", model);
		}


		//
		// POST: /Rules/Regra_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGRA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Regra_Duplicate(Regra_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_Duplicate",
				ViewName = "Regra",
				AreaName = "rules",
				Location = ACTION_REGRA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGRA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGRA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGRA]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Regra_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("rules", Convert.ToString(Navigation.CurrentLevel.GetEntry("rules"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGRA");
		}

		#endregion

		#region Regra_Cancel

		//
		// GET: /Rules/Regra_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGRA]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Regra_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Rules();
					model.klass.QPrimaryKey = Navigation.GetStrValue("rules");

// USE /[MANUAL GQT BEFORE_CANCEL REGRA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGRA]/

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

				Navigation.SetValue("ForcePrimaryRead_rules", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "rules";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("rules");
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

		#region Regra Multiform actions

		//
		// GET /Rules/MFRegra_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFRegra_New")]
		public ActionResult MFRegra_New()
		{
			var model = new Regra_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_REGRA_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("rules", model.ValCodregra);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFRegra", model);
		}

		//
		// GET /Rules/MFRegra_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFRegra_Edit")]
		public ActionResult MFRegra_Edit(string id)
		{
			return this.RedirectToAction("Regra_Edit", "Rules", new { id = id, partialView = "MFRegra", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Rules/MFRegra_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFRegra_Cancel")]
		public ActionResult MFRegra_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_REGRA_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_REGRA_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Rules();
						model.klass.QPrimaryKey = Navigation.GetStrValue("rules");

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

						Log.Error("MFRegra_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Regra_Show", "Rules", new { id = id, partialView = "MFRegra", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Rules/MFRegra_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFRegra_Save")]
		public JsonResult MFRegra_Save(Regra_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRegra_Save",
				ViewName = "MFRegra",
				AreaName = "rules"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Rules/MFRegra_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFRegra_Delete")]
		public JsonResult MFRegra_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRegra_Delete",
				ViewName = "MFRegra",
				AreaName = "rules",
				Location = ACTION_REGRA_EDIT
			};

			var model = new Regra_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




   
		// POST: /Rules/Regra_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Regra_SaveEdit(Regra_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regra_SaveEdit",
				ViewName = "Regra",
				AreaName = "rules",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGRA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGRA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
