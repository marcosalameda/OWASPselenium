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
using GenioMVC.ViewModels.Lendi;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
    public partial class LendiController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION LENDI]/

        #endregion


        #region Reports

		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult GQT_Report_1511(bool allSelected = false)
        {
            bool preview = true;
            try
            {
                var isServerReports = !Configuration.SSRSServer.isLocalReports;
                var reportName = "comodato";
                var reportFileName = reportName + (isServerReports ? "" : ".rdl");
                var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
                var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
                if(isServerReports) reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

                string area = "lendi";
                var limitation = new List<ReportLimitParameter>();

                // Created by [CJP] at [2017.05.31]
                // Updated by [MH] at [2017.07.11]
                // Add min and max values to navigation with the field name
                // Navigation.SetValue("lendi.startMIN", Navigation.GetStrValue("minLendiValStart"));
                // Navigation.SetValue("lendi.startMAX", Navigation.GetStrValue("maxLendiValStart"));
                limitation.Add(new ReportLimitParameter_SE() {
                    FullFieldName = "lendi.start",
                    MinFieldName = "f_data01",
                    MinFieldValue = Navigation.GetValue("minLendiValStart"),
                    MaxFieldName = "f_data11",
                    MaxFieldValue = Navigation.GetValue("maxLendiValStart"),
                    FieldType = "D"
                });

                string[] historicFieldNames = new string[0]{};
                string[] historicFieldValues = new string[0]{};
                Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

                string[] globFields = new string[0]{};

                string[] specialFormulasFields = new string[0]{};
                string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 1511]/
                ReportSSRS_Result result;
                using (var renderer = new ReportSSRS(reportFullPath, reportFileName, reportFullPath, isServerReports, UserContext.Current.PersistentSupport))
                {
                    // MH (11/10/2017) - Report Server credentials
                    if (Configuration.SSRSServer.ContainsCredentials())
                    {
                        renderer.ServerReportInstance.ReportServerCredentials = new ReportServerCredentials(Configuration.SSRSServer.Username, Configuration.SSRSServer.Password, Configuration.SSRSServer.Domain);
                    }
                    renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
                    result = renderer.Render("PDF");
                }

// USE /[MANUAL GQT OVERRIDE_REPORT 1511]/

                Response.Headers.Add("FileName", reportFileName + "." + result.FileNameExtension);
                if (result.FileNameExtension == "pdf") // If pass file extension, browser will download file instead of opening it in PDF Viewer.
                    return File(result.File, result.MimeType);
                else
                    return File(result.File, result.MimeType, "comodato." + result.FileNameExtension);
            }
            catch (Exception e)
            {
                CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
                if (!preview)
                {
                    return PartialView("_ErrorReport", model: Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message);
                }
                else
                {
                    return PartialView("_ErrorReport", model: Resources.Resources.OCORREU_UM_ERRO_INES30674);
                }
            }
        }

        #endregion

        #region Programmers code...


		// GET: /Lendi/PTN_MenuR_MESSAGEOK
		// <returns>Json(new { success = "OK", message = "" }, JsonRequestBehavior.AllowGet)</returns>
		public JsonResult PTN_MenuR_MESSAGEOK(string id)
		{
			try
			{
//Platform: MVC | Type: CONTROLLER_ROUTINE_BODY | Module: GQT | Parameter: MESSAGEOK | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:0c2d5cb3-18c7-413c-8452-58bb80443e50
//Return ok message
return Json(new { success = true, message = "OK" });
//END_MANUALCODE
			}
			catch (BusinessException ex)
			{
				return Json(new { success = "E", message = ex.UserMessage }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Log.Error("Error in action PTN_MenuR_MESSAGEOK: " + ex.Message);
				return Json(new { success = "E", message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 }, JsonRequestBehavior.AllowGet);
			}
		}


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAlendi>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER LENDI]/

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
            Models.Lendi row = null;
            try { row = Models.Lendi.Find(navigation.GetStrValue("lendi")); }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model lendi");
            }
            if(row == null)
            {
                row = new Models.Lendi();
                row.klass.QPrimaryKey = navigation.GetStrValue("lendi");
            }

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "COMOD___PESS1NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Comod_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Comod___pess1name____(qs);
						    result = model.TablePess1Name;
                        }
						break;
					case "COMOD___PESS2NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Comod_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Comod___pess2name____(qs);
						    result = model.TablePess2Name;
                        }
						break;
					case "COMOD___EQUIPREGISTNR":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Comod_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Comod___equipregistnr(qs);
						    result = model.TableEquipRegistnr;
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
					case "COMOD___PESS1NAME____":	// Field (DB)
						values = Comod_ViewModel.GetDependant_ComodTablePess1Name(Selected, navigation);
						break;
					case "COMOD___PESS2NAME____":	// Field (DB)
						values = Comod_ViewModel.GetDependant_ComodTablePess2Name(Selected, navigation);
						break;
					case "COMOD___EQUIPREGISTNR":	// Field (DB)
						values = Comod_ViewModel.GetDependant_ComodTableEquipRegistnr(Selected, navigation);
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
        /// Recalculate formulas of the "Comod" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Comod(Comod_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "lendi",
                (primaryKey) => Models.Lendi.Find(primaryKey, "FCOMOD"),
                (model) => form_data.MapToModel(model as Models.Lendi)
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


        #endregion
    }
}
