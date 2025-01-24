using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Expen;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EXPEN]/

namespace GenioMVC.Controllers
{
	public partial class ExpenController : ControllerBase
	{
		public ExpenController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION EXPEN]/



		/// <summary>
		/// Server-side component of action #1 (FLDUPDT) of trigger EMPTYDESCRIPTIO2
		/// Button PTN_3B111
		/// </summary>
		/// <param name="key">The primary key of the record.</param>
		/// <returns>
		/// Success message
		/// </returns>
		public ActionResult PTN_MenuTR_3B111_EMPTYDESCRIPTIO2_1([FromBody]RequestKeyModel key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = CSGenioAexpen.search(sp, key.Key, user);
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
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
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
		public ActionResult PTN_MenuTR_3B121_FILLDESCRIPTION2_1([FromBody]RequestKeyModel key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = CSGenioAexpen.search(sp, key.Key, user);
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
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
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
		public ActionResult PTN_MenuTR_3C1111_EMPTYDESCRIPTION_1([FromBody]RequestKeyModel key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = CSGenioAexpen.search(sp, key.Key, user);
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
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
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
		public ActionResult PTN_MenuTR_3C1121_FILLDESCRIPTION_1([FromBody]RequestKeyModel key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = CSGenioAexpen.search(sp, key.Key, user);
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
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
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
		public ActionResult PTN_MenuTR_TRIGGER_MENU1_MENUTRIGER_1([FromBody]RequestKeyModel key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = CSGenioAexpen.search(sp, key.Key, user);
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
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
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
		public ActionResult PTN_MenuTR_TRIGGER_MENU2_TRIGMENU2_1([FromBody]RequestKeyModel key)
		{
			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			try
			{
				var model = CSGenioAexpen.search(sp, key.Key, user);
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
					}
				);
			}

			return Json(
				new {
					success = "OK",
					message = Resources.Resources.A_OPERACAO_FOI_CONCL36721
				}
			);
		}


		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAexpen>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER EXPEN]/


		[HttpPost]
		public JsonResult ReloadDBEdit([FromBody]RequestReloadDBEditModel requestModel)
		{
			var Identifier = requestModel.Identifier ?? "";
			var qs = new NameValueCollection();
			qs.AddRange(Request.Query);
			// The value of the lookup search field comes in 'Values'
			if (requestModel.Values != null)
				qs.AddRange(requestModel.Values);
			this.IsStateReadonly = true;

			dynamic result = null;
			Models.Expen row = null;

			if (row == null)
			{
				row = new Models.Expen(UserContext.Current, isEmpty: true);
				row.klass.QPrimaryKey = Navigation.GetStrValue("expen");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "DESPE___PROJEPROJECTO":	// Field (DB)
						{
							row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Despe_ViewModel(UserContext.Current) { editable = false };							
							model.MapFromModel(row);
							model.Load_Despe___projeprojecto(qs);
							result = model.TableProjeProjecto;
						}
						break;
					case "DESPE___YEAR_YEAR____":	// Field (DB)
						{
							row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Despe_ViewModel(UserContext.Current) { editable = false };							
							model.MapFromModel(row);
							model.Load_Despe___year_year____(qs);
							result = model.TableYearYear;
						}
						break;
					case "DESPE___AGREGVALUE___":	// Field (DB)
						{
							row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Despe_ViewModel(UserContext.Current) { editable = false };							
							model.MapFromModel(row);
							model.Load_Despe___agregvalue___(qs);
							result = model.TableAgregValue;
						}
						break;
					default:
						break;
				}
			}
			catch (Exception)
			{
				return JsonERROR("On Reload form field: " + Identifier);
			}

			if (result != null)
				return JsonOK(new { List = result.List, TotalRows = result.Pagination.TotalRows, Selected = result.Selected, Value = result.Value });
			return JsonERROR("Not found any valid result");
		}

		[HttpPost]
		public JsonResult GetDependants([FromBody]RequestDependantsModel requestModel)
		{
			var Identifier = requestModel.Identifier;
			var Selected = requestModel.Selected;

			ConcurrentDictionary<string, object> values = null;
			this.IsStateReadonly = true;

			try
			{
				// Only the last reload request is accepted.
				var requestNumber = Request.Headers["GetDependantsRequestNumber"];
				if (requestNumber != StringValues.Empty)
					Response.Headers["GetDependantsRequestNumber"] = requestNumber.First();

				UserContext.Current.PersistentSupport.openConnection();
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "DESPE___PROJEPROJECTO":	// Field (DB)
						values = new Despe_ViewModel(UserContext.Current).GetDependant_DespeTableProjeProjecto(Selected);
						break;
					case "DESPE___YEAR_YEAR____":	// Field (DB)
						values = new Despe_ViewModel(UserContext.Current).GetDependant_DespeTableYearYear(Selected);
						break;
					case "DESPE___AGREGVALUE___":	// Field (DB)
						values = new Despe_ViewModel(UserContext.Current).GetDependant_DespeTableAgregValue(Selected);
						break;
					default: break;
				}

				if (values == null || !values.Any())
					return JsonERROR("List is empty");

				// Remove DateTime.MinValue
				foreach (KeyValuePair<string, object> field in values)
					if (field.Value is DateTime && (DateTime)field.Value == DateTime.MinValue)
						values.TryUpdate(field.Key, "", DateTime.MinValue);

				// TODO: Sanitize HTML content
				return JsonOK(values);
			}
			catch (Exception)
			{
				return JsonERROR("On Get Dependants - " + Identifier);
			}
			finally
			{
				UserContext.Current.PersistentSupport.closeConnection();
			}
		}


		/// <summary>
		/// Recalculate formulas of the "Despe" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Despe([FromBody]Despe_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "expen",
				(primaryKey) => Models.Expen.Find(primaryKey, UserContext.Current, "FDESPE"),
				(model) => formData.MapToModel(model as Models.Expen)
			);
		}

		/// <summary>
		/// Get "See more..." tree structure
		/// </summary>
		/// <returns></returns>
		public JsonResult GetTreeSeeMore([FromBody]RequestLookupModel requestModel)
		{
			var Identifier = requestModel.Identifier;
			var queryParams = requestModel.QueryParams;

			try
			{
				// We need the request values to apply filters
				var requestValues = new NameValueCollection();
				if (queryParams != null)
					foreach (var kv in queryParams)
						requestValues.Add(kv.Key, kv.Value);

				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					default:
						break;
				}
			}
			catch (Exception)
			{
				return Json(new { Success = false, Message = "Error" });
			}

			return Json(new { Success = false, Message = "Error" });
		}
	}
}
