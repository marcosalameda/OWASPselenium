using System;
using System.Web.Mvc;
using GenioMVC.Helpers;
using GenioMVC.ViewModels.UserAdmin;
using System.Web.Security;
using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using GenioMVC.ViewModels.Psw;

namespace GenioMVC.Controllers
{
    public class UserAdminController : ControllerBase
    {
        private static readonly NavigationLocation ACTION_ADMIN = new NavigationLocation("UTILIZADORES39761", "Index", "UserAdmin");

		//
        // UserAdmin/
        [AuthorizeForUsers]
        public ActionResult Index()
        {
			UserAdminViewModel model = new UserAdminViewModel(Navigation);
            CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
            if (result.Status.Equals(CSGenio.framework.Status.E) && !Request.IsAjaxRequest())
                return View("_PermissionError", model: result.Message);

            NameValueCollection querystring = Request.Form.Count > 0 ? Request.Form : Request.QueryString;
            if (!Request.IsAjaxRequest())
                if (Navigation.CurrentLevel == null || !ACTION_ADMIN.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_ADMIN);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_ADMIN.Action)
                        Navigation.AddHistoryLevel(ACTION_ADMIN, FormMode.List);
                }

            //verificar se o user clicou to exportar os dados da Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
                string file = "Utilizadores_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + querystring["ExportType"];
                ListingMVC<CSGenioApsw> listing = null;
                CriteriaSet conditions = null;
                List<CSGenio.framework.Exports.QColumn> columns = null;
                model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());
                byte[] fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, querystring["ExportType"], file);
                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }
            model.Load(CSGenio.framework.Configuration.NrRegDBedit, querystring, Request.IsAjaxRequest());

            if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("Index_Partial", model);
        }
	}
}
