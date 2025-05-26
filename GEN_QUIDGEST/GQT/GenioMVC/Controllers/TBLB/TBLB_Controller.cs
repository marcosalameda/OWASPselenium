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
using GenioMVC.ViewModels;
using Quidgest.Persistence.GenericQuery;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using CSGenio.reporting;
using System.Collections.Specialized;
using GenioMVC.ViewModels.Tblb;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLB]/

namespace GenioMVC.Controllers
{
    public partial class TblbController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION TBLB]/

        #endregion

        #region GridTableList Virtual Form Methods -> Grpb____pseudtblb____


        //
        // POST: /Tblb/Grpb____pseudtblb____Form_Edit
		[AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Grpb____pseudtblb____Form_Edit(GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel model, FormCollection collection)
        {
            var sp = UserContext.Current.PersistentSupport;
            try
            {
				model.Navigation = Navigation;
                var qs = Request.QueryString;

                if (!ModelState.IsValid)
                    throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, "Grpb____pseudtblb____Form_Edit", "Erro");

				sp.openTransaction();

// USE /[MANUAL GQT BEFORE_SAVE_EDIT GRPB____PSEUDTBLB____FORM]/

                model.Save();

// USE /[MANUAL GQT AFTER_SAVE_EDIT GRPB____PSEUDTBLB____FORM]/

				sp.closeTransaction();

				return Json(new
                {
                    Success = true,
                    Key = model.QPrimaryKey,
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
            catch (Exception e)
            {
				sp.rollbackTransaction();
				sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);

				return Json(new
                {
                    Success = false,
                    Key = model.QPrimaryKey,
                    Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
        }


		//
        // POST: /Tblb/Grpb____pseudtblb____Form_New
		[AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Grpb____pseudtblb____Form_New(GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel model, FormCollection collection)
        {
            var sp = UserContext.Current.PersistentSupport;
            try
            {
				model.Navigation = Navigation;
                var qs = Request.QueryString;

                if (!ModelState.IsValid)
                    throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_GRAVA23775, "Grpb____pseudtblb____Form_New", "Erro");

				sp.openTransaction();

                model.New();
				model.NewLoad(); //TODO: Check if this is really necessary, if we are saving why are we loading all the lists again?
                TryUpdateModel(model);

// USE /[MANUAL GQT BEFORE_SAVE_NEW GRPB____PSEUDTBLB____FORM]/

                model.Save();

// USE /[MANUAL GQT AFTER_SAVE_NEW GRPB____PSEUDTBLB____FORM]/

				sp.closeTransaction();

                return Json(new
                {
                    Success = true,
                    Key = model.QPrimaryKey,
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"]
                });
            }
            catch (Exception e)
            {
				sp.rollbackTransaction();
				sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);

                return Json(new
                {
                    Success = false,
                    Key = model.QPrimaryKey,
                    Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"]
                });
            }
        }


        //
        // POST: /Tblb/Grpb____pseudtblb____Form_Delete
		[AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Grpb____pseudtblb____Form_Delete(GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel model, FormCollection collection)
        {
            var sp = UserContext.Current.PersistentSupport;
            try
            {
                model.Navigation = Navigation;
                var qs = Request.QueryString;

                if(!String.IsNullOrEmpty(model.QPrimaryKey))
                {
					sp.openTransaction();

// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GRPB____PSEUDTBLB____FORM]/

                    model.Destroy();

// USE /[MANUAL GQT AFTER_DESTROY_DELETE GRPB____PSEUDTBLB____FORM]/

					sp.closeTransaction();
                }

                return Json(new
                {
                    Success = true,
                    Key = model.QPrimaryKey,
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
            catch (Exception e)
            {
				sp.rollbackTransaction();
				sp.closeConnection();

                model.LoadPartial(Request.QueryString);
                model.MapFromModel();
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    ModelState.AddModelError("Erro", (e as GenioException).UserMessage);
                else
                    ModelState.AddModelError("Erro", Resources.Resources.PEDIMOS_DESCULPA__OC63848);

                return Json(new
                {
                    Success = false,
                    Key = model.QPrimaryKey,
                    Messages = (ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage)),
                    Expose = collection["expose"].ToString(),
                    InsertMode = Convert.ToBoolean(collection["InsertMode"]),
                    InsertedRow = collection["rowId"] ?? ""
                });
            }
        }

        #endregion

        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAtblb>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER TBLB]/

        #endregion


        #region Recalculate Formulas (server side)

        /// <summary>
        /// Recalculate formulas of the "Tblb" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Tblb(Tblb_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "tblb",
                (primaryKey) => Models.Tblb.Find(primaryKey, "FTBLB"),
                (model) => form_data.MapToModel(model as Models.Tblb)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Grpb____pseudtblb____" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Grpb____pseudtblb____(Grpb____pseudtblb_____ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "tblb",
                (primaryKey) => Models.Tblb.Find(primaryKey, "FGRPB____PSEUDTBLB____"),
                (model) => form_data.MapToModel(model as Models.Tblb)
            );
        }

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


        #region  Documents

		[AuthorizeForUsers]
        public new ActionResult GetDocumsVersionsDBEdit(string ticket, bool isRequired = false)
        {
            return base.GetDocumsVersionsDBEdit(ticket, isRequired);
        }

		[AuthorizeForUsers]
        public new ActionResult GetFileProperties(string ticket, string identifier = null)
        {
            return base.GetFileProperties(ticket, identifier);
        }

		[AuthorizeForUsers]
        public new ActionResult SubmitVersion(string ticket, string fieldSize = "", string dataIdentifier = "", bool isRequired = false, int? maxFileSize = null, string allowedTypes = null)
        {
            return base.SubmitVersion(ticket, fieldSize, dataIdentifier, isRequired, maxFileSize, allowedTypes);
        }

		[AuthorizeForUsers]
        public new ActionResult CheckoutDocum(string ticket, bool usesTemplates, string fieldSize = "", string dataIdentifier = "", bool isRequired = false, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print, int? maxFileSize = null, string allowedTypes = null)
        {
            return base.CheckoutDocum(ticket, usesTemplates, fieldSize, dataIdentifier, isRequired, viewType, maxFileSize, allowedTypes);
        }

		[AuthorizeForUsers]
        public new ActionResult DeleteFile(string ticket, bool usesTemplates, ControllerBase.VersionDeleteAction action = VersionDeleteAction.All, string fieldSize = "", string dataIdentifier = "", bool isRequired = false, int? maxFileSize = null, string allowedTypes = null)
        {
            return base.DeleteFile(ticket, usesTemplates, action, fieldSize, dataIdentifier, isRequired, maxFileSize, allowedTypes);
        }

		[AuthorizeForUsers]
        public new ActionResult SetFile(string ticket, bool usesTemplates, ControllerBase.VersionSubmitAction mode = VersionSubmitAction.Insert, string version = "1", string fieldSize = "", string dataIdentifier = "", bool isRequired = false, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print, int? maxFileSize = null, string allowedTypes = null)
        {
            return base.SetFile(ticket, usesTemplates, mode, version, fieldSize, dataIdentifier, isRequired, viewType, maxFileSize, allowedTypes);
        }

		[AuthorizeForUsers]
        public new ActionResult GetFile(string ticket, string identifier = null, DocumentViewTypeMode viewType = DocumentViewTypeMode.Print)
        {
            return base.GetFile(ticket, identifier, viewType);
        }

		[AuthorizeForUsers]
        public new ActionResult GetSpecificFile(string ticket)
        {
            return base.GetSpecificFile(ticket);
        }

        #endregion
    }
}
