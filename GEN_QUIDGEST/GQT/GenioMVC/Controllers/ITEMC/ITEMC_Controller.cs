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
using GenioMVC.ViewModels.Itemc;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEMC]/

namespace GenioMVC.Controllers
{
    public partial class ItemcController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION ITEMC]/

        #endregion


        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAitemc>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER ITEMC]/

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
            /*
                Instead of loading the entire record from the database, a record will be created in memory with the keys filled in, 
                    and additional fields from "Field" type limits will be mapped later. 
                This allows us to reduce database queries, as we already have all the necessary information to apply the limits.
            */
            Models.Itemc row = new Models.Itemc(isEmpty: true);
            row.klass.QPrimaryKey = navigation.GetStrValue("itemc");
            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "CATAR___ITEM_ITEMDES_":	// Field (DB)
                        {
						    var model = new Catar_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Catar___item_itemdes_(qs);
						    result = model.TableItemItemdes;
                        }
						break;
					case "CATAR___CATTPTPCATEGO":	// Field (DB)
                        {
						    var model = new Catar_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Catar___cattptpcatego(qs);
						    result = model.TableCattpTpcatego;
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
					case "CATAR___ITEM_ITEMDES_":	// Field (DB)
						values = Catar_ViewModel.GetDependant_CatarTableItemItemdes(Selected, navigation);
						break;
					case "CATAR___CATTPTPCATEGO":	// Field (DB)
						values = Catar_ViewModel.GetDependant_CatarTableCattpTpcatego(Selected, navigation);
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

                // TODO: Sanitize HTML content
                return JsonOK(values);
            }
			catch (Exception) { return JsonERROR("On Get Dependants - " + Identifier );}
            finally { UserContext.Current.PersistentSupport.closeConnection(); }
		}
		#endregion

        #region Recalculate Formulas (server side)

        /// <summary>
        /// Recalculate formulas of the "Catar" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Catar(Catar_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "itemc",
                (primaryKey) => Models.Itemc.Find(primaryKey, "FCATAR"),
                (model) => form_data.MapToModel(model as Models.Itemc)
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
