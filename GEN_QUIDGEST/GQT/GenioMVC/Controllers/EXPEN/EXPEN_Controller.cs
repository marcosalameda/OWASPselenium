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
using GenioMVC.ViewModels.Expen;
using Microsoft.Reporting.WebForms;
using GenioServer.business;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EXPEN]/

namespace GenioMVC.Controllers
{
    public partial class ExpenController : ControllerBase
    {
        #region NavigationLocation Names controller.cs.vm

// USE /[MANUAL GQT CONTROLLER_NAVIGATION EXPEN]/

        #endregion


        #region Reports


        #endregion

        #region Triggers

		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger EMPTYDESCRIPTIO2
		/// Button PTN_3B111
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_1(string key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
                var model = CSGenioAexpen.search(sp, key, user);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger EMPTYDESCRIPTIO2
				CSGenio.business.Triggers.ITrigger trigger_EMPTYDESCRIPTIO2 = new CSGenio.business.Triggers.TriggerEmptydescriptio2(context);
				CSGenio.business.Triggers.IAction action = trigger_EMPTYDESCRIPTIO2.GetAction(1);
				trigger_EMPTYDESCRIPTIO2.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
                sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger FILLDESCRIPTION2
		/// Button PTN_3B121
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult PTN_MenuTR_3B121_FILLDESCRIPTION2_1(string key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
                var model = CSGenioAexpen.search(sp, key, user);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger FILLDESCRIPTION2
				CSGenio.business.Triggers.ITrigger trigger_FILLDESCRIPTION2 = new CSGenio.business.Triggers.TriggerFilldescription2(context);
				CSGenio.business.Triggers.IAction action = trigger_FILLDESCRIPTION2.GetAction(1);
				trigger_FILLDESCRIPTION2.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
                sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger EMPTYDESCRIPTION
		/// Button PTN_3C1111
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult PTN_MenuTR_3C1111_EMPTYDESCRIPTION_1(string key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
                var model = CSGenioAexpen.search(sp, key, user);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger EMPTYDESCRIPTION
				CSGenio.business.Triggers.ITrigger trigger_EMPTYDESCRIPTION = new CSGenio.business.Triggers.TriggerEmptydescription(context);
				CSGenio.business.Triggers.IAction action = trigger_EMPTYDESCRIPTION.GetAction(1);
				trigger_EMPTYDESCRIPTION.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
                sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger FILLDESCRIPTION
		/// Button PTN_3C1121
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult PTN_MenuTR_3C1121_FILLDESCRIPTION_1(string key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
                var model = CSGenioAexpen.search(sp, key, user);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger FILLDESCRIPTION
				CSGenio.business.Triggers.ITrigger trigger_FILLDESCRIPTION = new CSGenio.business.Triggers.TriggerFilldescription(context);
				CSGenio.business.Triggers.IAction action = trigger_FILLDESCRIPTION.GetAction(1);
				trigger_FILLDESCRIPTION.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
                sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger MENUTRIGER
		/// Button PTN_TRIGGER_MENU1
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult PTN_MenuTR_TRIGGER_MENU1_MENUTRIGER_1(string key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
                var model = CSGenioAexpen.search(sp, key, user);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger MENUTRIGER
				CSGenio.business.Triggers.ITrigger trigger_MENUTRIGER = new CSGenio.business.Triggers.TriggerMenutriger(context);
				CSGenio.business.Triggers.IAction action = trigger_MENUTRIGER.GetAction(1);
				trigger_MENUTRIGER.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
                sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger TRIGMENU2
		/// Button PTN_TRIGGER_MENU2
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		[AuthorizeForUsers]
		public ActionResult PTN_MenuTR_TRIGGER_MENU2_TRIGMENU2_1(string key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try 
			{
                var model = CSGenioAexpen.search(sp, key, user);
				// Context
				var context = new CSGenio.business.Triggers.TriggerContext()
				{
					Area = model,
					PersistentSupport = sp,
					User = user,
				};

				// Should open a local transaction
				// if the context did not provide an open transaction.
				bool openLocalTransaction = sp.TransactionIsClosed;

				// Should keep the connection alive
				// if the context provided an open connection but not an open transaction.
				bool keepConnectionAlive = !sp.ConnectionIsClosed && sp.TransactionIsClosed;

				if (openLocalTransaction)
					sp.openTransaction();

				// Trigger TRIGMENU2
				CSGenio.business.Triggers.ITrigger trigger_TRIGMENU2 = new CSGenio.business.Triggers.TriggerTrigmenu2(context);
				CSGenio.business.Triggers.IAction action = trigger_TRIGMENU2.GetAction(1);
				trigger_TRIGMENU2.ExecuteAction(action);

				// If a local transaction was opened, it should also be closed.
				if (openLocalTransaction)
				{
					sp.closeTransaction();

					// Reopen the connection if it needs to be kept alive.
					if (keepConnectionAlive)
						sp.openConnection();
				}

			}
			catch(Exception)
			{
                sp.rollbackTransaction();
				return Json(
					new {
						success = "E",
						message = Resources.Resources.PEDIMOS_DESCULPA__OC63848
					},
                    JsonRequestBehavior.AllowGet
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				},
				JsonRequestBehavior.AllowGet
			);
		}

        #endregion

        #region Programmers code...


        private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
        {
            CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAexpen>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
            return base.GetActionIds(crs, sp, area);
        }

// USE /[MANUAL GQT MANUAL_CONTROLLER EXPEN]/

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
            Models.Expen row = new Models.Expen(isEmpty: true);
            row.klass.QPrimaryKey = navigation.GetStrValue("expen");
            row.LoadKeysFormHistory(navigation, navigation.CurrentLevel.Level, false, true, true, true);

            // Only the last reload request is accepted.
            var requestNumber = Request.Headers.GetValues("ReloadDBEditRequestNumber");
            if (requestNumber != null && requestNumber.Any())
                Response.Headers.Add("ReloadDBEditRequestNumber", requestNumber.First());

			try
			{
				switch ((string.IsNullOrEmpty(Identifier) || Identifier.Length < 5) ? "" : Identifier.Substring(4)) // Substring(4) => to retirar o IFF_ e LED_
				{
					case "DESPE___PROJEPROJECTO":	// Field (DB)
                        {
						    var model = new Despe_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Despe___projeprojecto(qs);
						    result = model.TableProjeProjecto;
                        }
						break;
					case "DESPE___YEAR_YEAR____":	// Field (DB)
                        {
						    var model = new Despe_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Despe___year_year____(qs);
						    result = model.TableYearYear;
                        }
						break;
					case "DESPE___AGREGVALUE___":	// Field (DB)
                        {
						    var model = new Despe_ViewModel(navigation) { editable = false };
						    model.MapFromModel(row);
                            TryUpdateModel(model); // Map recived values to fields - The 'field' type limits
						    model.Load_Despe___agregvalue___(qs);
						    result = model.TableAgregValue;
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
					case "DESPE___PROJEPROJECTO":	// Field (DB)
						values = Despe_ViewModel.GetDependant_DespeTableProjeProjecto(Selected, navigation);
						break;
					case "DESPE___YEAR_YEAR____":	// Field (DB)
						values = Despe_ViewModel.GetDependant_DespeTableYearYear(Selected, navigation);
						break;
					case "DESPE___AGREGVALUE___":	// Field (DB)
						values = Despe_ViewModel.GetDependant_DespeTableAgregValue(Selected, navigation);
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
        /// Recalculate formulas of the "Despe" form. (++, CT, SR, CL and U1)
        /// </summary>
        /// <param name="form_data">Current form data</param>
        /// <returns></returns>
        [HttpPost]
		[AuthorizeForUsers]
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public JsonResult RecalculateFormulas_Despe(Despe_ViewModel form_data)
        {
            return GenericRecalculateFormulas(form_data, "expen",
                (primaryKey) => Models.Expen.Find(primaryKey, "FDESPE"),
                (model) => form_data.MapToModel(model as Models.Expen)
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
