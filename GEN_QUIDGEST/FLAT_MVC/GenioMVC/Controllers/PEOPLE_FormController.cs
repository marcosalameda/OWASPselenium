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
using GenioMVC.ViewModels.;


// USE /[MANUAL GQT INCLUDE_CONTROLLER]/

namespace GenioMVC.Controllers
{
	public partial class Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PEOPLE_CANCEL = new NavigationLocation("CANCELAR49513", "People_Cancel", "") { vueRouteName = "form-PEOPLE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PEOPLE_SHOW = new NavigationLocation("CONSULTA40695", "People_Show", "") { vueRouteName = "form-PEOPLE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PEOPLE_NEW = new NavigationLocation("INSERIR43365", "People_New", "") { vueRouteName = "form-PEOPLE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PEOPLE_EDIT = new NavigationLocation("EDITAR11616", "People_Edit", "") { vueRouteName = "form-PEOPLE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PEOPLE_DUPLICATE = new NavigationLocation("DUPLICAR09748", "People_Duplicate", "") { vueRouteName = "form-PEOPLE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PEOPLE_DELETE = new NavigationLocation("APAGAR04097", "People_Delete", "") { vueRouteName = "form-PEOPLE", mode = "DELETE" };

		#endregion

		#region Change form mode method(s)

		[AuthorizeForUsers]
		public ActionResult ChangeFormMode_People(string mode)
		{
			var _mode = Navigation.CurrentLevel.Location;
			var id = Navigation.GetStrValue("");
			var m = Request.QueryString["m"];

			Navigation.RemoveHistoryLevel();
			switch (mode)
			{
				case "show":
					if (m.Contains("v"))
						_mode = ACTION_PEOPLE_SHOW;
					break;
				case "delete":
					if (m.Contains("a"))
						_mode = ACTION_PEOPLE_DELETE;
					break;
				case "edit":
					if (m.Contains("e"))
						_mode = ACTION_PEOPLE_EDIT;
					break;
				case "duplicate":
					if (m.Contains("d"))
						_mode = ACTION_PEOPLE_DUPLICATE;
					break;
				case "new":
					if (m.Contains("i"))
						_mode = ACTION_PEOPLE_NEW;
					break;
			}

			return RedirectToLocation(_mode, new { id, m });
		}

		#endregion



		#region People private

		private void FormHistoryLimits_People()
		{

		}

		#endregion

		#region People_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PEOPLE]/
		//
		// GET: //People_Show
		[AuthorizeForUsers]
		public ActionResult People_Show(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new People_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "People"; // MF send the patial view name

			var navigationLocationAction = ACTION_PEOPLE_SHOW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//Check if it being called as a homepage
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") && (bool)RouteData.Values["isHomePage"];
			ViewBag.isHomePage = isHomePage;

			if (!isHomePage && (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue(""), id)))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			Navigation.SetValue("", id);

// USE /[MANUAL GQT BEFORE_LOAD_SHOW PEOPLE]/

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
				CSGenio.framework.Log.Error("People_Show - GET " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_SHOW PEOPLE]/


			if (isHomePage)
			{
				Navigation.SetValue("HomePage", "People");
				return PartialView(partialView, model);
			}
			else if (!Request.IsAjaxRequest())
				return View("People", model);
			else
				return PartialView(partialView, model);
		}

		#endregion

		#region People_New

		[ActionName("People_New_Insert")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult People_New_Insert()
		{
			string keys = Request.QueryString["HistoryRemoveAreas"];

			if (!string.IsNullOrEmpty(keys))
			{
				foreach (string key in keys.Split(','))
				{
					Navigation.ClearValue(key);
				}
			}

			return RedirectToAction("People_New");
		}

// USE /[MANUAL GQT CONTROLLER_NEW_GET PEOPLE]/
		//
		// GET: //People_New
		[ActionName("People_New")]
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult People_New()
		{

			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new People_ViewModel(Navigation, nestedForm);
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

			string partialView = qs["partialView"] ?? "People";

			var navigationLocationAction = ACTION_PEOPLE_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			//FOR: OVERRIDE SKIP IF JUST ONE
			//Allow child form to use "Go Back" to menu list without "skip if only one"
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("PEOPLE"))
				Navigation.OverrideSkipIfJustOne["PEOPLE"] = true;

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

					Navigation.SetValue("", model.${mvc.GetModelFieldName($table.FindChave())});

					sp.openConnection();
// USE /[MANUAL GQT BEFORE_LOAD_NEW PEOPLE]/
					model.NewLoad();
// USE /[MANUAL GQT AFTER_LOAD_NEW PEOPLE]/
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
				CSGenio.framework.Log.Error("People_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

			if (!Request.IsAjaxRequest())
			{
				return View("People", model);
			} else {
				return PartialView(partialView, model);
			}
		}


		//
		// POST: //People_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PEOPLE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult People_New(People_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "People_New",
				ViewName = "People",
				AreaName = "",
				Location = ACTION_PEOPLE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PEOPLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PEOPLE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PEOPLE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PEOPLE]/
				}
			};
			return GenericHandlePostFormNew(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult People_New_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["NEW_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("", Convert.ToString(Navigation.CurrentLevel.GetEntry(""))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "New", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			if (Convert.ToBoolean(Request.QueryString.Get("repeatInsertion")))
				return RedirectToLocation(ACTION_PEOPLE_NEW, new { repeatInsertion = true });

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PEOPLE");
		}

		#endregion

		#region People_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PEOPLE]/
		//
		// GET: //People_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("People_Edit")]
		public ActionResult People_Edit(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			string partialView = qs["partialView"] ?? "People"; // MF send the partial view name

			//Useful to initialize a record that had to be created by the framework prior to edition (and method New doesnt support this). This way, if the form then is canceled by the user, the record will be automatically deleted
			var isNewEdit = Navigation.GetStrValue("NewEdit") == "true";

			var navigationLocationAction =  isNewEdit ? ACTION_PEOPLE_NEW.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] }) : ACTION_PEOPLE_EDIT.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, isNewEdit? FormMode.New : FormMode.Edit, nestedForm);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			}
			Navigation.SetValue("", id);

			var model = new People_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_EDIT PEOPLE]/
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
				CSGenio.framework.Log.Error("People_Edit - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_EDIT PEOPLE]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

			// Check form permissions
			permission.MergeStatusMessage(model.UpdateConditions());

			if (!Request.IsAjaxRequest())
			{
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("People", model);
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
		// POST: //People_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PEOPLE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult People_Edit(People_ViewModel model, bool redirect = true)
		{
			var collection = Request.Unvalidated.Form; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			if (Request.IsAjaxRequest() && collection["partialView"] != null) // <-- ??????????
				return PartialView(collection["partialView"], model);

			var eventSink = new EventSink()
			{
				MethodName = "People_Edit",
				ViewName = "People",
				AreaName = "",
				Location = ACTION_PEOPLE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PEOPLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PEOPLE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PEOPLE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PEOPLE]/
				}
			};
			return GenericHandlePostFormEdit(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult People_Edit_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["EDIT_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect || !Request.IsAjaxRequest())
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 + GetHumanKeyToQMessage("", Convert.ToString(Navigation.CurrentLevel.GetEntry(""))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // Ajax result for nested form
				return Json(new { Success = true, Operation = "Edit", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.ALTERACOES_EFETUADAS10166 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//verify if the current level has a skipifjustone option, and remove it from history
			if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
				Navigation.RemoveHistoryLevel();

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PEOPLE");
		}


		#endregion

		#region People_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PEOPLE]/
		//
		// GET: //People_Delete
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("People_Delete")]
		public ActionResult People_Delete(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";

			var navigationLocationAction = ACTION_PEOPLE_DELETE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
			//MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
			CheckLevels(navigationLocationAction);

			if (IsNewLocation(navigationLocationAction))
			{
				Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
				Navigation.SetValue("", id);
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.FORM54242 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			var model = new People_ViewModel(Navigation, nestedForm);
			model.setModes(Request.QueryString["m"]);

// USE /[MANUAL GQT BEFORE_LOAD_DELETE PEOPLE]/

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
				CSGenio.framework.Log.Error("People_Delete - " + id + " " + e.Message);
				throw;
			}

// USE /[MANUAL GQT AFTER_LOAD_DELETE PEOPLE]/

			// Check table permissions
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

			// Check form permissions
			permission.MergeStatusMessage(model.DeleteConditions());

			if (!Request.IsAjaxRequest())
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return View("_PermissionError", model: permission.Message);
				else
					return View("People", model);
			else
				if (permission.Status.Equals(CSGenio.framework.Status.E))
					return PartialView("_PermissionErrorExt", model: permission.Message);
				else
					return PartialView("People", model);
		}


		//
		// POST: //People_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PEOPLE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult People_Delete(string id, FormCollection collection)
		{

			var model = new People_ViewModel (Navigation, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "People_Delete",
				ViewName = "People",
				AreaName = "",
				Location = ACTION_PEOPLE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PEOPLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PEOPLE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult People_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PEOPLE");
		}

		#endregion

		#region People_Duplicate


// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PEOPLE]/
		//
		// GET: //People_Duplicate
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult People_Duplicate(string id)
		{
			var qs = Request.QueryString;
			var nestedForm = qs["nestedForm"] == "true";
			var model = new People_ViewModel(Navigation, nestedForm);
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

			var navigationLocationAction = ACTION_PEOPLE_DUPLICATE.SetRoutedValues(new { Id = id, m = Request.QueryString["m"] });
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

// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PEOPLE]/

					model.Duplicate(id);

// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PEOPLE]/

					sp.closeTransaction();
					Navigation.CurrentLevel.SetLocation(ACTION_PEOPLE_DUPLICATE.SetRoutedValues(new { Id = model.${mvc.GetModelFieldName($table.FindChave())} }));
					Navigation.CurrentLevel.SetMode(FormMode.Duplicate);
					Navigation.SetValue("", model.${mvc.GetModelFieldName($table.FindChave())});
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
				Navigation.SetValue("", model.${mvc.GetModelFieldName($table.FindChave())});
				return View("People", model);
			}
			else
				return PartialView("People", model);
		}


		//
		// POST: //People_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PEOPLE]/
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult People_Duplicate(People_ViewModel model, bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "People_Duplicate",
				ViewName = "People",
				AreaName = "",
				Location = ACTION_PEOPLE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PEOPLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PEOPLE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PEOPLE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PEOPLE]/
				}
			};
			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		[AuthorizeForUsers]
		public ActionResult People_Duplicate_Redirect(bool internalRedirect = false)
		{
			IList<string> warningMsgs = TempData["DUP_WARNINGS_LIST"] as List<string>;
			string saveMsg = TempData["NEW_SAVE_LIST"] as string;

			if (!internalRedirect)
				SuccessMessage(String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 + GetHumanKeyToQMessage("", Convert.ToString(Navigation.CurrentLevel.GetEntry(""))) : saveMsg);

			Navigation.RemoveHistoryLevel();

			if (Request.IsAjaxRequest()) // The Vue app needs a JSON response.
				return Json(new { Success = true, Operation = "Dup", Message = String.IsNullOrEmpty(saveMsg) ? Resources.Resources.REGISTO_CRIADO_COM_S18746 : saveMsg, Warnings = warningMsgs }, JsonRequestBehavior.AllowGet);

			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PEOPLE");
		}

		#endregion

		#region People_Cancel

		//
		// GET: //People_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PEOPLE]/
		[AuthorizeForUsers]
		[HttpGet]
		public ActionResult People_Cancel()
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.();
					model.klass.QPrimaryKey = Navigation.GetStrValue("");

// USE /[MANUAL GQT BEFORE_CANCEL PEOPLE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PEOPLE]/

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

				Navigation.SetValue("ForcePrimaryRead_", "true", true);
			}
			else if (Navigation.PreviousLevel != null)
			{
				// Position the list in the current registry
				string previousLevelArea = Navigation.PreviousLevel.Location.Controller?.ToLower() ?? "";
				Navigation.SetValue("QMVC_POS_RECORD_" + previousLevelArea, Navigation.GetValue(previousLevelArea), true);
			}

			Navigation.ClearValue("");
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

		#region People Multiform actions

		//
		// GET //MFPeople_New
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFPeople_New")]
		public ActionResult MFPeople_New()
		{
			var model = new People_ViewModel(Navigation, true);
			model.setModes(Request.QueryString["m"]);
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PEOPLE_NEW.SetRoutedValues(new { m = Request.QueryString["m"] });
			CheckLevels(navigationLocationAction);
			try
			{
				if (IsNewLocation(navigationLocationAction))
					Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, true);
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("", model.${mvc.GetModelFieldName($table.FindChave())});

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return PartialView("MFPeople", model);
		}

		//
		// GET //MFPeople_Edit
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFPeople_Edit")]
		public ActionResult MFPeople_Edit(string id)
		{
			return this.RedirectToAction("People_Edit", "", new { id = id, partialView = "MFPeople", nestedForm = "true", multiForm = "true" });
		}

		//
		// GET //MFPeople_Cancel
		[AuthorizeForUsers]
		[HttpGet]
		[ActionName("MFPeople_Cancel")]
		public ActionResult MFPeople_Cancel(string id)
		{
			//MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
			CheckLevels(NavigationLocation.Any);

			if (Navigation.CurrentLevel.IsNestedContext &&
				(Navigation.CurrentLevel.Location.Action == ACTION_PEOPLE_NEW.Action || Navigation.CurrentLevel.Location.Action == ACTION_PEOPLE_EDIT.Action))
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New)
				{
					var sp = UserContext.Current.PersistentSupport;
					try
					{
						var model = new Models.();
						model.klass.QPrimaryKey = Navigation.GetStrValue("");

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

						Log.Error("MFPeople_Cancel - " + exceptionUserMessage);
						ErrorMessage(exceptionUserMessage);
					}
				}

				Navigation.RemoveHistoryLevel();
			}

			var nav = CurrentNavigation.cloneNavigation(Navigation.NavigationId);

			return this.RedirectToAction("People_Show", "", new { id = id, partialView = "MFPeople", nestedForm = "true", multiForm = "true", nav });
		}

		//
		// POST //MFPeople_Save
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFPeople_Save")]
		public JsonResult MFPeople_Save(People_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPeople_Save",
				ViewName = "MFPeople",
				AreaName = ""
			};
			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST //MFPeople_Delete
		[AuthorizeForUsers]
		[HttpPost]
		[ActionName("MFPeople_Delete")]
		public JsonResult MFPeople_Delete(string id)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPeople_Delete",
				ViewName = "MFPeople",
				AreaName = "",
				Location = ACTION_PEOPLE_EDIT
			};

			var model = new People_ViewModel(Navigation, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion




 
		//
		// GET: //People_ValPeoplels
		// POST: //People_ValPeoplels
		[AuthorizeForUsers]
		[ActionName("People_ValPeoplels")]
		[ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
		public ActionResult People_ValPeoplels(string id, string partialView)
		{
			int perPage = 2;

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString; //TSX (01.07.2020) Can not access directly to the FormCollection or made Request.Form otherwise the tags on viewmodel will be ignored
			var navigation = Navigation;
			People_ValPeoplels_ViewModel model = new People_ValPeoplels_ViewModel(navigation);
			model.setModes(Request.QueryString["m"]);

			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return PartialView(partialView, model);
		}


		// POST: //People_SaveEdit
		[AuthorizeForUsers]
		[HttpPost]
		[HttpParamAction]
		public ActionResult People_SaveEdit(People_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "People_SaveEdit",
				ViewName = "People",
				AreaName = "",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PEOPLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PEOPLE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
