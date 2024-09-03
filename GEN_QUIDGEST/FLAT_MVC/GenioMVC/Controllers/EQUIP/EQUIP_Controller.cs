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
using GenioMVC.ViewModels.Equip;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
    public partial class EquipController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION EQUIP]/

        #endregion


        #region Reports


        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAequip>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER EQUIP]/

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
            Models.Equip row = null;
            try { row = Models.Equip.Find(navigation.GetStrValue("equip")); }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model equip");
            }
            if(row == null)
            {
                row = new Models.Equip();
                row.klass.QPrimaryKey = navigation.GetStrValue("equip");
            }

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "ACCORDI_CMPNYDESIGNAT":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Accordi_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Accordi_cmpnydesignat(qs);
						    result = model.TableCmpnyDesignat;
                        }
						break;
					case "ACCORDI_PESS1NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Accordi_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Accordi_pess1name____(qs);
						    result = model.TablePess1Name;
                        }
						break;
					case "EQUIGROUPESS1NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equigrou_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equigroupess1name____(qs);
						    result = model.TablePess1Name;
                        }
						break;
					case "EQUIGROUTPEQUTIPOEQUI":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equigrou_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equigroutpequtipoequi(qs);
						    result = model.TableTpequTipoequi;
                        }
						break;
					case "EQUIP___CMPNYDESIGNAT":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___cmpnydesignat(qs);
						    result = model.TableCmpnyDesignat;
                        }
						break;
					case "EQUIP___PESS1NAME____":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___pess1name____(qs);
						    result = model.TablePess1Name;
                        }
						break;
					case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___tpequtipoequi(qs);
						    result = model.TableTpequTipoequi;
                        }
						break;
					case "EQUIP___WAREHWAREHDES":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___warehwarehdes(qs);
						    result = model.TableWarehWarehdes;
                        }
						break;
					case "EQUIP___ITEM_ITEMDES_":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___item_itemdes_(qs);
						    result = model.TableItemItemdes;
                        }
						break;
					case "EQUIP___ROOM1ROOMNR__":	// Field (F1)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___room1roomnr__(qs);
						    result = model.TableRoom1Roomnr;
                        }
						break;
					case "EQUIP___DECOMDECOMNR_":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Equip_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Equip___decomdecomnr_(qs);
						    result = model.TableDecomDecomnr;
                        }
						break;
					case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Groupbx_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Groupbx_tpequtipoequi(qs);
						    result = model.TableTpequTipoequi;
                        }
						break;
					case "GROUPBX_WAREHWAREHDES":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Groupbx_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Groupbx_warehwarehdes(qs);
						    result = model.TableWarehWarehdes;
                        }
						break;
					case "GROUPBX_ITEM_ITEMDES_":	// Field (DB)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Groupbx_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Groupbx_item_itemdes_(qs);
						    result = model.TableItemItemdes;
                        }
						break;
					case "GROUPBX_ROOM1ROOMNR__":	// Field (F1)
                        {
                            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);
						    var model = new Groupbx_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Groupbx_room1roomnr__(qs);
						    result = model.TableRoom1Roomnr;
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
					case "ACCORDI_CMPNYDESIGNAT":	// Field (DB)
						values = Accordi_ViewModel.GetDependant_AccordiTableCmpnyDesignat(Selected, navigation);
						break;
					case "ACCORDI_PESS1NAME____":	// Field (DB)
						values = Accordi_ViewModel.GetDependant_AccordiTablePess1Name(Selected, navigation);
						break;
					case "EQUIGROUPESS1NAME____":	// Field (DB)
						values = Equigrou_ViewModel.GetDependant_EquigrouTablePess1Name(Selected, navigation);
						break;
					case "EQUIGROUTPEQUTIPOEQUI":	// Field (DB)
						values = Equigrou_ViewModel.GetDependant_EquigrouTableTpequTipoequi(Selected, navigation);
						break;
					case "EQUIP___CMPNYDESIGNAT":	// Field (DB)
						values = Equip_ViewModel.GetDependant_EquipTableCmpnyDesignat(Selected, navigation);
						break;
					case "EQUIP___PESS1NAME____":	// Field (DB)
						values = Equip_ViewModel.GetDependant_EquipTablePess1Name(Selected, navigation);
						break;
					case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
						values = Equip_ViewModel.GetDependant_EquipTableTpequTipoequi(Selected, navigation);
						break;
					case "EQUIP___WAREHWAREHDES":	// Field (DB)
						values = Equip_ViewModel.GetDependant_EquipTableWarehWarehdes(Selected, navigation);
						break;
					case "EQUIP___ITEM_ITEMDES_":	// Field (DB)
						values = Equip_ViewModel.GetDependant_EquipTableItemItemdes(Selected, navigation);
						break;
					case "EQUIP___ROOM1ROOMNR__":	// Field (F1)
						values = Equip_ViewModel.GetDependant_EquipTableRoom1Roomnr(Selected, navigation);
						break;
					case "EQUIP___DECOMDECOMNR_":	// Field (DB)
						values = Equip_ViewModel.GetDependant_EquipTableDecomDecomnr(Selected, navigation);
						break;
					case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
						values = Groupbx_ViewModel.GetDependant_GroupbxTableTpequTipoequi(Selected, navigation);
						break;
					case "GROUPBX_WAREHWAREHDES":	// Field (DB)
						values = Groupbx_ViewModel.GetDependant_GroupbxTableWarehWarehdes(Selected, navigation);
						break;
					case "GROUPBX_ITEM_ITEMDES_":	// Field (DB)
						values = Groupbx_ViewModel.GetDependant_GroupbxTableItemItemdes(Selected, navigation);
						break;
					case "GROUPBX_ROOM1ROOMNR__":	// Field (F1)
						values = Groupbx_ViewModel.GetDependant_GroupbxTableRoom1Roomnr(Selected, navigation);
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
        /// Recalculate formulas of the "Accordi" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Accordi(Accordi_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FACCORDI"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Equdocum" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Equdocum(Equdocum_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FEQUDOCUM"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Equigrou" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Equigrou(Equigrou_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FEQUIGROU"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Equip" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Equip(Equip_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FEQUIP"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Fullcale" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Fullcale(Fullcale_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FFULLCALE"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Gmaps" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Gmaps(Gmaps_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FGMAPS"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Groupbx" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Groupbx(Groupbx_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FGROUPBX"),
                (model) => form_data.MapToModel(model as Models.Equip)
            );
        }

        /// <summary>
        /// Recalculate formulas of the "Timequip" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Timequip(Timequip_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "equip",
                (primaryKey) => Models.Equip.Find(primaryKey, "FTIMEQUIP"),
                (model) => form_data.MapToModel(model as Models.Equip)
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

                    case "ACCORDI_PESS1NAME____":	// Field (DB)
                        {
                            var model = new Accordi_ViewModel(Navigation);
                            var permission = model.CheckPermissions(FormMode.Show);
                            if (permission.Status.Equals(CSGenio.framework.Status.E))
                                return Json(new { Success = false, Message = permission.Message }, JsonRequestBehavior.AllowGet);

                            model.LoadTree_TablePess1Name(requestValues);
                            return Json(new { Success = true, Data = model.Tree_TablePess1Name }, JsonRequestBehavior.AllowGet);
                        }

                    case "EQUIP___PESS1NAME____":	// Field (DB)
                        {
                            var model = new Equip_ViewModel(Navigation);
                            var permission = model.CheckPermissions(FormMode.Show);
                            if (permission.Status.Equals(CSGenio.framework.Status.E))
                                return Json(new { Success = false, Message = permission.Message }, JsonRequestBehavior.AllowGet);

                            model.LoadTree_TablePess1Name(requestValues);
                            return Json(new { Success = true, Data = model.Tree_TablePess1Name }, JsonRequestBehavior.AllowGet);
                        }

                    case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
                        {
                            var model = new Equip_ViewModel(Navigation);
                            var permission = model.CheckPermissions(FormMode.Show);
                            if (permission.Status.Equals(CSGenio.framework.Status.E))
                                return Json(new { Success = false, Message = permission.Message }, JsonRequestBehavior.AllowGet);

                            model.LoadTree_TableTpequTipoequi(requestValues);
                            return Json(new { Success = true, Data = model.Tree_TableTpequTipoequi }, JsonRequestBehavior.AllowGet);
                        }

                    case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
                        {
                            var model = new Groupbx_ViewModel(Navigation);
                            var permission = model.CheckPermissions(FormMode.Show);
                            if (permission.Status.Equals(CSGenio.framework.Status.E))
                                return Json(new { Success = false, Message = permission.Message }, JsonRequestBehavior.AllowGet);

                            model.LoadTree_TableTpequTipoequi(requestValues);
                            return Json(new { Success = true, Data = model.Tree_TableTpequTipoequi }, JsonRequestBehavior.AllowGet);
                        }
                    default: break;
                }
            }
            catch (Exception) { return Json(new { Success = false, Message = "Error" }, JsonRequestBehavior.AllowGet); }
            return Json(new { Success = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // POST: /Equip/Equip_MultiDelete
		[AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult Equip_MultiDelete(string[] ids)
        {
            if(ids == null || !ids.Any())
                return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });
            CSGenio.framework.Audit.registAction(UserContext.Current.User, "Equip_MultiDelete: " + string.Join("; ", ids));

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            try
            {
                sp.openTransaction();

// USE /[MANUAL GQT BEFORE_MULTI_DELETE Equip]/

                foreach (string id in ids)
                {
                    var model = Models.Equip.Find(id);
                    model.Destroy();
                }

// USE /[MANUAL GQT AFTER_MULTI_DELETE Equip]/

                sp.closeTransaction();

            }
            catch (Exception e)
            {
                sp.rollbackTransaction();

                var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
                if(e is GenioException && (e as GenioException).UserMessage != null)
                    exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
                CSGenio.framework.Log.Error(e.Message);

                return Json(new { Success = false, Message = exceptionUserMessage });
            }

            return Json(new { Success = true, Message = "Mensagem de sucesso" }); // Resources.Resources.REGISTO_APAGADO_COM_64671
        }

        #region  Documents


        #endregion
    }
}
