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
using GenioMVC.ViewModels.Flds;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
    public partial class FldsController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION FLDS]/

        #endregion


        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAflds>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER FLDS]/

        #endregion

        #region Reload Form
        [HttpPost]
        // MH (03/08/2021) - Since the Navigation clone is being used this means that the Navigation change is not made (recorded in the session)
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult ReloadDBEdit(string Identifier, IDictionary<string, object> Values)
        {
            var qs = new NameValueCollection(Request.QueryString);
            var navigation = Navigation.Clone();
            foreach (KeyValuePair<string, object> par in Values)
            {// Override com o Qvalue do Qfield do form
                if(navigation.CheckFilledByHistory(par.Key)) continue;
                if (string.IsNullOrEmpty(Convert.ToString(par.Value)))
                    navigation.SetValue(par.Key, null);
                else
                {
                    navigation.SetValue(par.Key, par.Value);
                    //Load do DBEdit permite também filtrar os registos por Qvalue do Qfield search
                    qs.Add(par.Key, par.Value.ToString());
                }
            }

            dynamic result = null;
            Models.Flds row = null;
            try { row = Models.Flds.Find(navigation.GetStrValue("flds")); }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model flds");
            }
            if(row == null)
            {
                row = new Models.Flds();
                row.klass.QPrimaryKey = navigation.GetStrValue("flds");
            }

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "CAMPO___AERO_NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Campo_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Campo___aero_name____(qs);
						    result = model.TableAeroName;
                        }
						break;
					case "FIELDHLPAERO_NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Fieldhlp_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Fieldhlpaero_name____(qs);
						    result = model.TableAeroName;
                        }
						break;
					default: break;
				}
			}
            catch (Exception) { return JsonERROR("On Reload form field: " + Identifier); }
			if (result != null)
                return JsonOK(new { List = result.List, HasMore = result.HasMore(), Selected = result.Selected, Value = result.Value });
            else
                return JsonERROR("Not found any valid result");
        }

        [HttpPost]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult GetDependants(string Identifier, string Selected, IDictionary<string, object> Limits)
        {
            ConcurrentDictionary<string, object> values = null;
            var navigation = Navigation.Clone();
            try
            {
                foreach (KeyValuePair<string, object> par in Limits)
                {   // Override the values with current form fields values
                    if(navigation.CheckFilledByHistory(par.Key))
                        continue;

                    if (string.IsNullOrEmpty(Convert.ToString(par.Value)))
                        navigation.SetValue(par.Key, null);
                    else
                        navigation.SetValue(par.Key, par.Value);
                }

                // Only the last reload request is accepted.
                var requestNumber = Request.Headers.GetValues("GetDependantsRequestNumber");
                if (requestNumber != null && requestNumber.Any())
                    Response.Headers.Add("GetDependantsRequestNumber", requestNumber.First());

                UserContext.Current.PersistentSupport.openConnection();
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "CAMPO___AERO_NAME____":	// Field (DB)
						values = Campo_ViewModel.GetDependant_CampoTableAeroName(Selected, navigation);
						break;
					case "FIELDHLPAERO_NAME____":	// Field (DB)
						values = Fieldhlp_ViewModel.GetDependant_FieldhlpTableAeroName(Selected, navigation);
						break;
					default: break;
				}

                if (values == null || !values.Any())
                    return JsonERROR("List is empty");

                // Remove DateTime.MinValue
                foreach (KeyValuePair<string, object> field in values)
                {
                    if (field.Value is DateTime && (DateTime)field.Value == DateTime.MinValue)
                        values.TryUpdate(field.Key, "", DateTime.MinValue);
                }

                return JsonOK(values);
            }
			catch (Exception) { return JsonERROR("On Get Dependants - " + Identifier );}
            finally { UserContext.Current.PersistentSupport.closeConnection(); }
		}
		#endregion

        #region Recalculate Formulas (server side)

        /// <summary>
        /// Recalculate formulas of the "Campo" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Campo(Campo_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "flds",
                (primaryKey) => Models.Flds.Find(primaryKey, "FCAMPO"),
                (model) => form_data.MapToModel(model as Models.Flds)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Fieldhlp" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Fieldhlp(Fieldhlp_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "flds",
                (primaryKey) => Models.Flds.Find(primaryKey, "FFIELDHLP"),
                (model) => form_data.MapToModel(model as Models.Flds)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Infields" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Infields(Infields_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "flds",
                (primaryKey) => Models.Flds.Find(primaryKey, "FINFIELDS"),
                (model) => form_data.MapToModel(model as Models.Flds)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Listacam" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Listacam(Listacam_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "flds",
                (primaryKey) => Models.Flds.Find(primaryKey, "FLISTACAM"),
                (model) => form_data.MapToModel(model as Models.Flds)
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
