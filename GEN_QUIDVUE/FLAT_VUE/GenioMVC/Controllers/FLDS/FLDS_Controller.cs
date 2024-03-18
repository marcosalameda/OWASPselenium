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
using GenioMVC.ViewModels.Flds;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		public FldsController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION FLDS]/



		// GET: /Flds/Fieldhlp_BR_APPLWIT
		// <returns>Json(new { success = "OK", message = "" })</returns>
		public JsonResult Fieldhlp_BR_APPLWIT([FromBody] RequestRoutineSingleModel requestModel)
		{
			var id = requestModel.Id;
			var area = requestModel.Area;
			try
			{
//Platform: MVC | Type: CONTROLLER_ROUTINE_BODY | Module: GQT | Parameter: APPLWIT | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:4c4dc3f0-13bc-4675-96ec-0368ba7048e7
//Return ok message
return Json(new { success = true, message = "OK" });
//END_MANUALCODE
			}
			catch (BusinessException ex)
			{
				return Json(new { success = "E", message = ex.UserMessage });
			}
			catch (Exception ex)
			{
				Log.Error("Error in action Fieldhlp_BR_APPLWIT: " + ex.Message);
				return Json(new { success = "E", message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}
		}


		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAflds>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER FLDS]/


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
			Models.Flds row = null;

			try
			{
				row = Models.Flds.Find(Navigation.GetStrValue("flds"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model flds");
			}

			if (row == null)
			{
				row = new Models.Flds(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("flds");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "CAMPO___AERO_NAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Campo_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Campo___aero_name____(qs);
							result = model.TableAeroName;
						}
						break;
					case "FIELDHLPAERO_NAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Fieldhlp_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Fieldhlpaero_name____(qs);
							result = model.TableAeroName;
						}
						break;
					case "FIELDHLPEQUIPREGISTNR":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Fieldhlp_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Fieldhlpequipregistnr(qs);
							result = model.TableEquipRegistnr;
						}
						break;
					default: break;
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
					case "CAMPO___AERO_NAME____":	// Field (DB)
						values = new Campo_ViewModel(UserContext.Current).GetDependant_CampoTableAeroName(Selected);
						break;
					case "FIELDHLPAERO_NAME____":	// Field (DB)
						values = new Fieldhlp_ViewModel(UserContext.Current).GetDependant_FieldhlpTableAeroName(Selected);
						break;
					case "FIELDHLPEQUIPREGISTNR":	// Field (DB)
						values = new Fieldhlp_ViewModel(UserContext.Current).GetDependant_FieldhlpTableEquipRegistnr(Selected);
						break;
					default: break;
				}

				if (values == null || !values.Any())
					return JsonERROR("List is empty");

				// Remove DateTime.MinValue
				foreach (KeyValuePair<string, object> field in values)
					if (field.Value is DateTime && (DateTime)field.Value == DateTime.MinValue)
						values.TryUpdate(field.Key, "", DateTime.MinValue);

				return JsonOK(values);
			}
			catch (Exception)
			{
				return JsonERROR("On Get Dependants - " + Identifier );
			}
			finally
			{
				UserContext.Current.PersistentSupport.closeConnection();
			}
		}



		/// <summary>
		/// Recalculate formulas of the "Campo" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Campo([FromBody]Campo_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FCAMPO"),
				(model) => form_data.MapToModel(model as Models.Flds)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Fieldhlp" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Fieldhlp([FromBody]Fieldhlp_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FFIELDHLP"),
				(model) => form_data.MapToModel(model as Models.Flds)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Infields" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Infields([FromBody]Infields_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FINFIELDS"),
				(model) => form_data.MapToModel(model as Models.Flds)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Listacam" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Listacam([FromBody]Listacam_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "flds",
				(primaryKey) => Models.Flds.Find(primaryKey, UserContext.Current, "FLISTACAM"),
				(model) => form_data.MapToModel(model as Models.Flds)
			);
		}



		/// <summary>
		/// Get "See more..." tree structure
		/// </summary>
		/// <returns></returns>
		public JsonResult GetTreeSeeMore([FromBody]RequestLookupModel requestModel)
		{
			var Identifier = requestModel.Id;
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

		public ActionResult GetDocumsTickets([FromBody]RequestDocumGetTicketsModel requestModel)
		{
			return base.GetDocumsTickets(requestModel.TableName, requestModel.FieldName, requestModel.KeyValue);
		}

		public ActionResult GetDocumsVersionsDBEdit([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetDocumsVersionsDBEdit(requestModel.Ticket);
		}

		public ActionResult GetFileProperties([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetFileProperties(requestModel.Ticket);
		}

		public ActionResult SubmitVersion([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.SubmitVersion(requestModel.Ticket);
		}

		public ActionResult CheckoutDocum([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.CheckoutDocum(requestModel.Ticket);
		}

		public ActionResult DeleteFile([FromBody]RequestDocumDeleteModel requestModel)
		{
			return base.DeleteFile(requestModel.Ticket, requestModel.Action);
		}

		public new ActionResult SetFile([FromForm] string ticket, [FromForm] ControllerBase.VersionSubmitAction mode = VersionSubmitAction.Insert, [FromForm] string version = "1")
		{
			return base.SetFile(ticket, mode, version);
		}

		public ActionResult GetFile([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetFile(requestModel.Ticket, requestModel.ViewType);
		}

		public ActionResult GetSpecificFile([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetSpecificFile(requestModel.Ticket);
		}
	}
}
