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
using GenioMVC.ViewModels.Sale;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
    public partial class SaleController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION SALE]/

        #endregion


        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAsale>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER SALE]/

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
            Models.Sale row = null;
            try { row = Models.Sale.Find(navigation.GetStrValue("sale")); }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model sale");
            }
            if(row == null)
            {
                row = new Models.Sale();
                row.klass.QPrimaryKey = navigation.GetStrValue("sale");
            }

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "VENDA___ORGANORGANIZA":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Venda_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Venda___organorganiza(qs);
						    result = model.TableOrganOrganiza;
                        }
						break;
					case "VENDAW01ORGANORGANIZA":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Vendaw01_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Vendaw01organorganiza(qs);
						    result = model.TableOrganOrganiza;
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
					case "VENDA___ORGANORGANIZA":	// Field (DB)
						values = Venda_ViewModel.GetDependant_VendaTableOrganOrganiza(Selected, navigation);
						break;
					case "VENDAW01ORGANORGANIZA":	// Field (DB)
						values = Vendaw01_ViewModel.GetDependant_Vendaw01TableOrganOrganiza(Selected, navigation);
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
        /// Recalculate formulas of the "Venda" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Venda(Venda_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDA"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw(Vendaw_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw01" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw01(Vendaw01_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW01"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw02" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw02(Vendaw02_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW02"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw03" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw03(Vendaw03_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW03"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw04" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw04(Vendaw04_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW04"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw05" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw05(Vendaw05_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW05"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw06" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw06(Vendaw06_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW06"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw07" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw07(Vendaw07_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW07"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendaw08" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendaw08(Vendaw08_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAW08"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendawp" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendawp(Vendawp_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAWP"),
                (model) => form_data.MapToModel(model as Models.Sale)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Vendawv" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Vendawv(Vendawv_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "sale",
                (primaryKey) => Models.Sale.Find(primaryKey, "FVENDAWV"),
                (model) => form_data.MapToModel(model as Models.Sale)
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
