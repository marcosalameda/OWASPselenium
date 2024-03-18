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
using GenioMVC.ViewModels.Conta;


// USE /[MANUAL GQT INCLUDE_CONTROLLER CONTA]/

namespace GenioMVC.Controllers
{
	public partial class ContaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CONTA_CANCEL = new NavigationLocation("CONTACT59247", "Conta_Cancel", "Conta") { vueRouteName = "form-CONTA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONTA_SHOW = new NavigationLocation("CONTACT59247", "Conta_Show", "Conta") { vueRouteName = "form-CONTA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONTA_NEW = new NavigationLocation("CONTACT59247", "Conta_New", "Conta") { vueRouteName = "form-CONTA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONTA_EDIT = new NavigationLocation("CONTACT59247", "Conta_Edit", "Conta") { vueRouteName = "form-CONTA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONTA_DUPLICATE = new NavigationLocation("CONTACT59247", "Conta_Duplicate", "Conta") { vueRouteName = "form-CONTA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONTA_DELETE = new NavigationLocation("CONTACT59247", "Conta_Delete", "Conta") { vueRouteName = "form-CONTA", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_Conta(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("conta");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_CONTA_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_CONTA_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_CONTA_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_CONTA_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_CONTA_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region Conta private

		private void FormHistoryLimits_Conta()
		{

		}

		#endregion


		[AuthorizeForUsers]
		public ActionResult Conta_ModalDBEdit(string partialView)
		{
			Conta_ViewModel model = new Conta_ViewModel();
			model.setModes(Request.QueryString["m"]);
			model.Navigation = Navigation;
			model.Load(Request.Form, true, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

		#region Conta_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CONTA]/
		//
		// GET: /Conta/Conta_Show
		[AuthorizeForUsers]
		public ActionResult Conta_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Conta_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);

			// Check form conditions
			permission.MergeStatusMessage(model.ViewConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			string partialView = qs["partialView"] ?? "Conta"; // MF send the patial view name

			var navigationLocationAction = ACTION_CONTA_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("conta"), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("conta", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW CONTA]/

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
				CSGenio.framework.Log.Error("Conta_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW CONTA]/

			return PartialView("Conta", model);
		}

		#endregion

		#region Conta_New

		[ActionName("Conta_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Conta_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("Conta_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET CONTA]/
		//
		// GET: /Conta/Conta_New
		[ActionName("Conta_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Conta_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Conta_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_CONTA_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("CONTA"))
				Navigation.OverrideSkipIfJustOne["CONTA"] = true;

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

					Navigation.SetValue("conta", model.ValCodconta);

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW CONTA]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW CONTA]/
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
				CSGenio.framework.Log.Error("Conta_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return PartialView("_PermissionError", model: exceptionUserMessage);
			}

			return PartialView("Conta", model);
		}


		//
		// POST: /Conta/Conta_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CONTA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Conta_New(Conta_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Conta_New",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_NEW,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CONTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CONTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CONTA]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Conta_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Save", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Conta_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CONTA]/
		//
		// GET: /Conta/Conta_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Conta_Edit")]
		public ActionResult Conta_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "Conta"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_CONTA_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_CONTA_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("conta", id);

			var model = new Conta_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT CONTA]/
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
				CSGenio.framework.Log.Error("Conta_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT CONTA]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Conta", model);
		}


		//
		// POST: /Conta/Conta_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CONTA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Conta_Edit(Conta_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored

			var eventSink = new EventSink()
			{
				MethodName = "Conta_Edit",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_EDIT,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CONTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CONTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CONTA]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Conta_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			Navigation.RemoveHistoryLevel();
			return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFECTUADA64514 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}


		#endregion

		#region Conta_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CONTA]/
		//
		// GET: /Conta/Conta_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("Conta_Delete")]
		public ActionResult Conta_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_CONTA_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("conta", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new Conta_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE CONTA]/

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
				CSGenio.framework.Log.Error("Conta_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE CONTA]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);
			else
				return PartialView("Conta",model);
		}


		//
		// POST: /Conta/Conta_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CONTA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Conta_Delete(string id, FormCollection collection)
		{

			var model = new Conta_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Conta_Delete",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_DELETE,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CONTA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Conta_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONTA");
		}

		#endregion

		#region Conta_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CONTA]/
		//
		// GET: /Conta/Conta_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult Conta_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new Conta_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Duplicate);

			// Check form permissions
			permission.MergeStatusMessage(model.InsertConditions());

			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PartialView("_PermissionError", model: permission.Message);

			var navigationLocationAction = ACTION_CONTA_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CONTA]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CONTA]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_CONTA_DUPLICATE.SetRoutedValues(new { Id = model.ValCodconta }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("conta", model.ValCodconta);
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

			return PartialView("Conta", model);
		}


		//
		// POST: /Conta/Conta_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CONTA]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Conta_Duplicate(Conta_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Duplicate",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_DUPLICATE,
				Redirect = redirect,
				FormType = QFormType.PopUp,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CONTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CONTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CONTA]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult Conta_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("conta", Convert.ToString(Navigation.CurrentLevel.GetEntry("conta"))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Conta_Cancel

		//
		// GET: /Conta/Conta_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CONTA]/
		[AuthorizeForUsers]
		public ActionResult Conta_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Conta();
					model.klass.QPrimaryKey = Navigation.GetStrValue("conta");

// USE /[MANUAL GQT BEFORE_CANCEL CONTA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CONTA]/

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

				Navigation.SetValue("ForcePrimaryRead_conta", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "conta";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("conta");
			if (Navigation.CurrentLevel.Location.Controller.ToUpper() == RouteData.Values["controller"].ToString().ToUpper()) Navigation.RemoveHistoryLevel();
			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			return Json(new { Success = true, Operation = "Cancel" }, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Conta Multiform actions

		//
		// GET /Conta/MFConta_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFConta_New")]
		public ActionResult MFConta_New()
		{
			var model = new Conta_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_CONTA_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("conta", model.ValCodconta);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFConta", model);
		}

		//
		// GET /Conta/MFConta_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFConta_Edit")]
		public ActionResult MFConta_Edit(string id)
		{
			return this.RedirectToAction("Conta_Edit", "Conta", new { id = id, partialView = "MFConta", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET /Conta/MFConta_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFConta_Cancel")]
		public ActionResult MFConta_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_CONTA_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_CONTA_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.Conta();
						model.klass.QPrimaryKey = Navigation.GetStrValue("conta");

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

						Log.Error("MFConta_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("Conta_Show", "Conta", new { id = id, partialView = "MFConta", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST /Conta/MFConta_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFConta_Save")]
		public JsonResult MFConta_Save(Conta_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFConta_Save",
				ViewName = "MFConta",
				AreaName = "conta"
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Conta/MFConta_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFConta_Delete")]
		public JsonResult MFConta_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFConta_Delete",
				ViewName = "MFConta",
				AreaName = "conta",
				Location = ACTION_CONTA_EDIT
			};

			var model = new Conta_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: /Conta/Conta_PessoValName
		// POST: /Conta/Conta_PessoValName
		[AuthorizeForUsers]
		[ActionName("Conta_PessoValName")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Conta_PessoValName(string id, string partialView,  IDictionary<string, string> Limits)
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
			Conta_PessoValName_ViewModel model = new Conta_PessoValName_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodconta = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		//
		// GET: /Conta/Conta_GenreValGender
		// POST: /Conta/Conta_GenreValGender
		[AuthorizeForUsers]
		[ActionName("Conta_GenreValGender")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Conta_GenreValGender(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_genre")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_genre");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Conta_GenreValGender_ViewModel model = new Conta_GenreValGender_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodconta = id;

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}

 
		//
		// GET: /Conta/Conta_TpconValTipocont
		// POST: /Conta/Conta_TpconValTipocont
		[AuthorizeForUsers]
		[ActionName("Conta_TpconValTipocont")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult Conta_TpconValTipocont(string id, string partialView,  IDictionary<string, string> Limits)
		{
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpcon")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpcon");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation.Clone();
			Conta_TpconValTipocont_ViewModel model = new Conta_TpconValTipocont_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);
			model.ValCodconta = id;
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

 
		// POST: /Conta/Conta_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult Conta_SaveEdit(Conta_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Conta_SaveEdit",
				ViewName = "Conta",
				AreaName = "conta",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CONTA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
