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
using GenioMVC.ViewModels.Propr;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPR]/

namespace GenioMVC.Controllers
{
    public partial class ProprController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION PROPR]/

        #endregion


        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioApropr>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER PROPR]/

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
            Models.Propr row = null;
            try { row = Models.Propr.Find(navigation.GetStrValue("propr")); }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model propr");
            }
            if(row == null)
            {
                row = new Models.Propr();
                row.klass.QPrimaryKey = navigation.GetStrValue("propr");
            }

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "PROPR00_TPPROTPPROPRI":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Propr00_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Propr00_tpprotppropri(qs);
						    result = model.TableTpproTppropri;
                        }
						break;
					case "PROPR00_PESSONAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Propr00_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Propr00_pessoname____(qs);
						    result = model.TablePessoName;
                        }
						break;
					case "PROPR01_CNTRYCOUNTRY_":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Propr00_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Propr01_cntrycountry_(qs);
						    result = model.TableCntryCountry;
                        }
						break;
					case "PROPR01_REGIOREGIAO__":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Propr00_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Propr01_regioregiao__(qs);
						    result = model.TableRegioRegiao;
                        }
						break;
					case "PROPRALLTPPROTPPROPRI":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Proprall_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Propralltpprotppropri(qs);
						    result = model.TableTpproTppropri;
                        }
						break;
					case "PROPRALLCNTRYCOUNTRY_":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Proprall_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Proprallcntrycountry_(qs);
						    result = model.TableCntryCountry;
                        }
						break;
					case "PROPRALLREGIOREGIAO__":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Proprall_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Proprallregioregiao__(qs);
						    result = model.TableRegioRegiao;
                        }
						break;
					case "PROPRALLPESSONAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Proprall_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Proprallpessoname____(qs);
						    result = model.TablePessoName;
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
					case "PROPR00_TPPROTPPROPRI":	// Field (DB)
						values = Propr00_ViewModel.GetDependant_Propr00TableTpproTppropri(Selected, navigation);
						break;
					case "PROPR00_PESSONAME____":	// Field (DB)
						values = Propr00_ViewModel.GetDependant_Propr00TablePessoName(Selected, navigation);
						break;
					case "PROPR01_CNTRYCOUNTRY_":	// Field (DB)
						values = Propr00_ViewModel.GetDependant_Propr01TableCntryCountry(Selected, navigation);
						break;
					case "PROPR01_REGIOREGIAO__":	// Field (DB)
						values = Propr00_ViewModel.GetDependant_Propr01TableRegioRegiao(Selected, navigation);
						break;
					case "PROPRALLTPPROTPPROPRI":	// Field (DB)
						values = Proprall_ViewModel.GetDependant_ProprallTableTpproTppropri(Selected, navigation);
						break;
					case "PROPRALLCNTRYCOUNTRY_":	// Field (DB)
						values = Proprall_ViewModel.GetDependant_ProprallTableCntryCountry(Selected, navigation);
						break;
					case "PROPRALLREGIOREGIAO__":	// Field (DB)
						values = Proprall_ViewModel.GetDependant_ProprallTableRegioRegiao(Selected, navigation);
						break;
					case "PROPRALLPESSONAME____":	// Field (DB)
						values = Proprall_ViewModel.GetDependant_ProprallTablePessoName(Selected, navigation);
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
        /// Recalculate formulas of the "Propr00" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Propr00(Propr00_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "propr",
                (primaryKey) => Models.Propr.Find(primaryKey, "FPROPR00"),
                (model) => form_data.MapToModel(model as Models.Propr)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Proprall" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Proprall(Proprall_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "propr",
                (primaryKey) => Models.Propr.Find(primaryKey, "FPROPRALL"),
                (model) => form_data.MapToModel(model as Models.Propr)
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
