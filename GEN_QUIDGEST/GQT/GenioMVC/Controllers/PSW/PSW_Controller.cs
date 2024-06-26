using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Models;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Resources;
using Quidgest.Persistence.GenericQuery;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using CSGenio.reporting;
using System.Collections.Specialized;
using GenioMVC.ViewModels.Psw;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PSW]/

namespace GenioMVC.Controllers
{
    public partial class PswController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION PSW]/

        #endregion


        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioApsw>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER PSW]/

        #endregion


        #region Recalculate Formulas (server side)

        #endregion

        #region DBEdit em arvore
        /// <summary>
        /// Get "See more..." tree structure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult GetTreeSeeMore(string Identifier)
        {
            try
            {
                // We need the request values to apply filters
                NameValueCollection requestValues = Request.Unvalidated.Form.Count > 0 ? Request.Unvalidated.Form : Request.QueryString;

				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
                {
                    default: break;
                }
            }
            catch (Exception) { return Json(new { Success = false, Message = "Error" }, JsonRequestBehavior.AllowGet); }
            return Json(new { Success = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PSW Controller

        private static readonly NavigationLocation ACTION_USER_SHOW = new NavigationLocation("CONSULTA40695", "User_Show", "Psw") { vueRouteName = "form-USER", mode = "SHOW" };
        private static readonly NavigationLocation ACTION_USER_NEW = new NavigationLocation("INSERIR43365", "User_New", "Psw") { vueRouteName = "form-USER", mode = "NEW" };
        private static readonly NavigationLocation ACTION_USER_EDIT = new NavigationLocation("EDITAR11616", "User_Edit", "Psw") { vueRouteName = "form-USER", mode = "EDIT" };
        private static readonly NavigationLocation ACTION_USER_DELETE = new NavigationLocation("APAGAR04097", "User_Delete", "Psw") { vueRouteName = "form-USER", mode = "DELETE" };

        public bool NestedForm { get; set; }

        #region User_Show
        //
        // /Psw/User_new
        [AuthorizeForUsers]
        public ActionResult User_Show(string id)
        {
            var qs = Request.QueryString;
            var nestedForm = qs["nestedForm"] == "true";
            var model = new PswViewModel(Navigation, nestedForm);

            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Show);
            if (permission.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest())
                    return View("_PermissionError", model: permission.Message);
                else
                    return PartialView("_PermissionErrorExt", model: permission.Message);
            }

            string partialView = qs["partialView"] ?? "User";
            var navigationLocationAction = ACTION_USER_SHOW.SetRoutedValues(new { Id = id });
            //MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
            CheckLevels(navigationLocationAction);

            if (IsNewLocation(navigationLocationAction) || !string.Equals(Navigation.GetStrValue("psw"), id))
                Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Show, nestedForm);

            Navigation.SetValue("psw", id);

            try
            {
                model.Load(qs, false, Request.IsAjaxRequest());
            }
            catch (ModelNotFoundException)
            {
                return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
            }

            if (!Request.IsAjaxRequest())
                return View("User", model);
            else
                return PartialView(partialView, model);
        }

        #endregion

        #region User_New

        //
        // GET: /Psw/User_new
        [ActionName("User_New")]
        [AuthorizeForUsers]
        [HttpGet]
        public ActionResult User_New()
        {
            var qs = Request.QueryString;
            var nestedForm = qs["nestedForm"] == "true";
            var model = new PswViewModel(Navigation, nestedForm);
            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);
            if (permission.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest())
                    return View("_PermissionError", model: permission.Message);
                else
                    return PartialView("_PermissionErrorExt", model: permission.Message);
            }

            string partialView = qs["partialView"] ?? "User";
            var navigationLocationAction = ACTION_USER_NEW;
            //MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
            CheckLevels(navigationLocationAction);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {
                if (IsNewLocation(navigationLocationAction))
                {
                    Navigation.AddHistoryLevel(navigationLocationAction, FormMode.New, nestedForm);

                    sp.openTransaction();
                    model.New();
                    sp.closeTransaction();

                    Navigation.SetValue("psw", model.ValCodpsw);

                    sp.openConnection();
					model.NewLoad();
					sp.closeConnection();
                }
                else
                {
                    try
                    {
                        model.Load(qs, true, Request.IsAjaxRequest());
                    }
                    catch (ModelNotFoundException)
                    {
                        return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
                    }
                }
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
				CSGenio.framework.Log.Error("User_New - GET " + e.Message);

				Navigation.RemoveHistoryLevel();
				return RedirectToLocation(Navigation.CurrentLevel.Location);
			}

            if (!Request.IsAjaxRequest())
                return View("User", model);
            else
                return PartialView(partialView, model);
        }

        // POST: /Psw/User_New
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult User_New(PswViewModel model)
        {
            long st = DateTime.Now.Ticks;
            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);
            if (permission.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest())
                    return View("_PermissionError", model: permission.Message);
                else
                    return PartialView("_PermissionErrorExt", model: permission.Message);
            }

            var qs = Request.Form;
            if (Request.IsAjaxRequest() && qs["partialView"]!= null)
                return PartialView(qs["partialView"], model);

            var sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;

                // Removes password validation if it had not changed
                if (String.IsNullOrEmpty(model.ValPassword))
                    ModelState.Remove("ValPassword");
                if (!ModelState.IsValid)
                    throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, "User_New", "Erro");
                // Validate se user já exists
                CheckUserExist(model.ValNome);

                // Create a new user
                var userFactory = new GenioServer.security.UserFactory(sp, UserContext.Current.User);
                var password = new GenioServer.security.Password(model.ValPassword, model.ValConfirmPassword);
                Psw userPsw = Psw.Find(model.ValCodpsw);
                userFactory.FillPsw(userPsw.klass, model.ValNome, model.ValEmail,   phone:"", status: 0,password: password);

                sp.openTransaction();
                userPsw.Save(sp);
                model.SaveAuthorization();
                sp.closeTransaction();

                if (!Request.IsAjaxRequest())
                    GetFlashMessage(model.flashMessage, Navigation.CurrentLevel.FormMode);

                // New insertion in upper table
                // MH (13/10/2017) - Deixou de ser preciso Request.IsAjaxRequest() pq os formularios passam a fazer pedidos ajax nos submits dos formulários
                if (Navigation.PreviousLevel != null && Navigation.PreviousLevel.FormMode != FormMode.List)
                    Navigation.SetValue("RETURN_psw", Navigation.GetValue("psw"), true);
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                model.LoadPartial(Request.QueryString);

                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
                CSGenio.framework.Log.Error(e.Message);
                model.NestedForm = Request.IsAjaxRequest();

                if (Request.IsAjaxRequest())
                    return Json(new { Success = false, Operation = "New", View = RenderPartialViewToString(this, "User", model), Message = Resources.Resources.ERRO_AO_GUARDAR_O_RE65182 });

                return View("User", model);
            }

            if (CSGenio.framework.Log.IsDebugEnabled)
                CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

            if (Request.IsAjaxRequest())
                // Ajax result for extended views
                return new JsonResult(){ Data = new { Success = true, Operation = "New", Message = Resources.Resources.REGISTO_CRIADO_COM_S18746 } };

            Navigation.RemoveHistoryLevel();
            return RedirectToLocation(Navigation.CurrentLevel.Location);
        }

        #endregion

        #region User_Edit

        //
        // GET: /Psw/User_Edit
        [AuthorizeForUsers]
        [HttpGet]
        [ActionName("User_Edit")]
        public ActionResult User_Edit(string id)
        {
            var qs = Request.QueryString;
            var nestedForm = qs["nestedForm"] == "true";
            string partialView = qs["partialView"] ?? "User";

            var navigationLocationAction = ACTION_USER_EDIT.SetRoutedValues(new { Id = id });
            //MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
            CheckLevels(navigationLocationAction);

            if (IsNewLocation(navigationLocationAction))
                Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Edit, nestedForm);

            Navigation.SetValue("psw", id);

            var model = new PswViewModel(Navigation, nestedForm);

            try
            {
                model.Load(qs, true, Request.IsAjaxRequest());
            }
            catch (ModelNotFoundException)
            {
                return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
            }

            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Edit);

            if (!Request.IsAjaxRequest())
            {
                if (permission.Status.Equals(CSGenio.framework.Status.E))
                    return View("_PermissionError", model: permission.Message);
                else
                    return View("User", model);
            }
            else
            {
                if (permission.Status.Equals(CSGenio.framework.Status.E))
                    return PartialView("_PermissionErrorExt", model: permission.Message);
                else
                    return PartialView(partialView, model);
            }
        }

        // POST: /Psw/User_Edit
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult User_Edit(PswViewModel model, FormCollection collection)
        {
            long st = DateTime.Now.Ticks;
            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);
            if (permission.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest())
                    return View("_PermissionError", model: permission.Message);
                else
                    return PartialView("_PermissionErrorExt", model: permission.Message);
            }

            if (Request.IsAjaxRequest() && collection["partialView"] != null)
                return PartialView(collection["partialView"], model);

            var sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;

                if (!ModelState.IsValid)
                    throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, "User_Edit", "Erro");
                // Validate se user já exists
                CheckUserExist(model.ValNome, model.ValCodpsw);

                Psw psw = Psw.Find(model.ValCodpsw);
                var userFactory = new GenioServer.security.UserFactory(UserContext.Current.PersistentSupport, UserContext.Current.User);
                if (!String.IsNullOrEmpty(model.ValPassword))
                    userFactory.ChangePassword(psw.klass, model.ValPassword, model.ValConfirmPassword);

                psw.ValNome = model.ValNome;

                sp.openTransaction();
				model.flashMessage = psw.Save(sp);
                model.SaveAuthorization();
                sp.closeTransaction();

                if(!Request.IsAjaxRequest())
                    GetFlashMessage(model.flashMessage, Navigation.CurrentLevel.FormMode);

                // New insertion in upper table
                if (Navigation.PreviousLevel != null && Navigation.PreviousLevel.FormMode != FormMode.List)
                    Navigation.SetValue("RETURN_psw", Navigation.GetValue("psw"), true);
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                model.LoadPartial(Request.QueryString);

                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);
                CSGenio.framework.Log.Error(e.Message);
                model.NestedForm = Request.IsAjaxRequest();

                if (Request.IsAjaxRequest())
                    return Json(new { Success = false, Operation = "Edit", View = RenderPartialViewToString(this, "User", model), Message = Resources.Resources.ERRO_AO_GUARDAR_O_RE65182 });

                return View("User", model);
            }

            if (CSGenio.framework.Log.IsDebugEnabled)
                CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");
            if (Request.IsAjaxRequest())
                return Json(new { Success = true, Operation = "Edit", Message = Resources.Resources.ALTERACOES_EFETUADAS10166 });

            Navigation.RemoveHistoryLevel();

            return RedirectToLocation(Navigation.CurrentLevel.Location);
        }

        #endregion

        #region User_Delete

        //
        // GET: /Psw/User_Delete
        [AuthorizeForUsers]
        [HttpGet]
        [ActionName("User_Delete")]
        public ActionResult User_Delete(string id)
        {
            var qs = Request.QueryString;
            var nestedForm = qs["nestedForm"] == "true";
            string partialView = qs["partialView"] ?? "User";

            var navigationLocationAction = ACTION_USER_DELETE.SetRoutedValues(new { Id = id });
            //MH - Validate if current level is it correct. Remove all levels that is higher than the previous level.
            CheckLevels(navigationLocationAction);

            if (IsNewLocation(navigationLocationAction))
            {
                Navigation.AddHistoryLevel(navigationLocationAction, FormMode.Delete, nestedForm);
                Navigation.SetValue("psw", id);
            }

            var model = new PswViewModel(Navigation);

            try
            {
                model.Load(qs, false, Request.IsAjaxRequest());
            }
            catch (ModelNotFoundException)
            {
                return View("_PermissionError", model: Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
            }

            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.Delete);

            if (!Request.IsAjaxRequest())
            {
                if (permission.Status.Equals(CSGenio.framework.Status.E))
                    return View("_PermissionError", model: permission.Message);
                else
                    return View("User", model);
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
        // POST: /Psw/User_Delete
        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult User_Delete(PswViewModel model, FormCollection collection)
        {
            string id = model.ValCodpsw;
            model = new PswViewModel(Navigation, id);
            model.MapFromModel();

            long st = DateTime.Now.Ticks;
            CSGenio.framework.StatusMessage permission = model.CheckPermissions(FormMode.New);
            if (permission.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest())
                    return View("_PermissionError", model: permission.Message);
                else
                    return PartialView("_PermissionErrorExt", model: permission.Message);
            }

            var sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;

                sp.openTransaction();
                model.Destroy();
                sp.closeTransaction();

                if(!Request.IsAjaxRequest())
                    GetFlashMessage(model.flashMessage, Navigation.CurrentLevel.FormMode);
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
				sp.closeConnection();

                model.LoadPartial(Request.QueryString);

                ModelState.AddModelError(string.Empty, CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language));
                CSGenio.framework.Log.Error(e.Message);
                if (Request.IsAjaxRequest())
                    return Json(new { Success = false, Operation = "Delete", Message = Resources.Resources.ERRO_AO_APAGAR_O_REG38939 });

                return View("User", model);
            }

            if (CSGenio.framework.Log.IsDebugEnabled) CSGenio.framework.Log.Debug("Controller success " + (DateTime.Now.Ticks - st) / TimeSpan.TicksPerMillisecond + "ms");

            if (Request.IsAjaxRequest())
                return Json(new { Success = true, Operation = "Delete", Message = Resources.Resources.REGISTO_APAGADO_COM_64671 });

            Navigation.RemoveHistoryLevel();

            return RedirectToLocation(Navigation.CurrentLevel.Location);
        }

        #endregion

        #region User_Cancel

        //
        // GET: /Psw/User_Cancel
        [AuthorizeForUsers]
        [HttpGet]
        public ActionResult User_Cancel()
        {
            //MH - Validate if current level is it correct. Remove all levels that is higher than the currently level.
            CheckLevels(NavigationLocation.Any);

            if ((Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate) && !Request.IsAjaxRequest())
            {
                PersistentSupport sp = UserContext.Current.PersistentSupport;

                try
                {
                    var model = new GenioMVC.Models.Psw();
                    model.klass.QPrimaryKey = Navigation.GetStrValue("psw");

                    sp.openTransaction();
                    model.Destroy();
                    sp.closeTransaction();
                }
                catch (Exception e)
                {
                    sp.rollbackTransaction();
                    sp.closeConnection();
                    ClearMessages();

                    ErrorMessage(CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language));
                    return RedirectToLocation(Navigation.CurrentLevel.Location);
                }
            }

            Navigation.ClearValue("psw");
            Navigation.RemoveHistoryLevel();
            //verify if the current level has a skipifjustone option, and remove it from history
            if (Navigation.CurrentLevel.CheckEntry("SkipIfJustOne"))
                Navigation.RemoveHistoryLevel();

            return RedirectToLocation(Navigation.CurrentLevel.Location);
        }

        #endregion

        private void CheckUserExist(string Username, string CodUser = null)
        {
            //verificar se já exists um user com o mesmo name
            SelectQuery userQuery = new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From("USERLOGIN", "psw")
                .PageSize(1);

            CriteriaSet where = new CriteriaSet(CriteriaSetOperator.And);
            where.Equal(CSGenioApsw.FldNome, Username);
            where.Equal(CSGenioApsw.FldZzstate, 0);

            if (!string.IsNullOrEmpty(CodUser)) //!= de introduce
                where.NotEqual(CSGenioApsw.FldCodpsw, CodUser);

            userQuery.Where(where);
            var userExist = UserContext.Current.PersistentSupport.ExecuteScalar(userQuery);

            if (userExist != null)
            {
                //replace de %s to o format do c#
                var regex = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape("%s"));
                var msg = regex.Replace(Resources.Resources.A_FICHA_COM_O_VALOR_35649, "{0}", 1);
                msg = regex.Replace(msg, "{1}", 1);

                throw new BusinessException(String.Format(msg, Username, Resources.Resources.UTILIZADOR52387), "CheckUserExist", "Erro");
            }
        }

        #endregion


        #region  Documents


        #endregion
    }
}
