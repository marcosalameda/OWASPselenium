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
using GenioMVC.ViewModels.Lendi;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
	public partial class LendiController : ControllerBase
	{
		public LendiController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION LENDI]/


		public ActionResult GQT_Report_1511([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = true;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodato";
				var reportFileName = reportName + (isServerReports ? "" : ".rdl");
				var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
				var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
				if (isServerReports)
					reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

				string area = "lendi";
				var limitation = new List<ReportLimitParameter>();

				// Created by [CJP] at [2017.05.31]
				// Updated by [MH] at [2017.07.11]
				// Add min and max values to navigation with the field name
				// Navigation.SetValue("lendi.startMIN", Navigation.GetStrValue("minLendiValStart"));
				// Navigation.SetValue("lendi.startMAX", Navigation.GetStrValue("maxLendiValStart"));
				limitation.Add(new ReportLimitParameter_SE()
				{
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
						renderer.SetServerCredentials(Configuration.SSRSServer.Username, Configuration.SSRSServer.Password, Configuration.SSRSServer.Domain);

					renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
					result = renderer.Render("PDF");
				}

// USE /[MANUAL GQT OVERRIDE_REPORT 1511]/

				Response.Headers["FileName"] = reportFileName + "." + result.FileNameExtension;
				if (result.FileNameExtension == "pdf") // If pass file extension, browser will download file instead of opening it in PDF Viewer.
					return File(result.File, result.MimeType);
				else
					return File(result.File, result.MimeType, "comodato." + result.FileNameExtension);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}


		// GET: /Lendi/PTN_MenuR_MESSAGEOK
		// <returns>Json(new { success = "OK", message = "" })</returns>
		public JsonResult PTN_MenuR_MESSAGEOK([FromBody] RequestRoutineSingleModel requestModel)
		{
			var id = requestModel.Id;
			var area = requestModel.Area;
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
				return Json(new { success = "E", message = ex.UserMessage });
			}
			catch (Exception ex)
			{
				Log.Error("Error in action PTN_MenuR_MESSAGEOK: " + ex.Message);
				return Json(new { success = "E", message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}
		}


		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAlendi>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER LENDI]/


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
			Models.Lendi row = null;

			try
			{
				row = Models.Lendi.Find(Navigation.GetStrValue("lendi"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model lendi");
			}

			if (row == null)
			{
				row = new Models.Lendi(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("lendi");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "COMOD___PESS1NAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Comod_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Comod___pess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "COMOD___PESS2NAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Comod_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Comod___pess2name____(qs);
							result = model.TablePess2Name;
						}
						break;
					case "COMOD___EQUIPREGISTNR":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Comod_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Comod___equipregistnr(qs);
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
					case "COMOD___PESS1NAME____":	// Field (DB)
						values = new Comod_ViewModel(UserContext.Current).GetDependant_ComodTablePess1Name(Selected);
						break;
					case "COMOD___PESS2NAME____":	// Field (DB)
						values = new Comod_ViewModel(UserContext.Current).GetDependant_ComodTablePess2Name(Selected);
						break;
					case "COMOD___EQUIPREGISTNR":	// Field (DB)
						values = new Comod_ViewModel(UserContext.Current).GetDependant_ComodTableEquipRegistnr(Selected);
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
		/// Recalculate formulas of the "Comod" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Comod([FromBody]Comod_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "lendi",
				(primaryKey) => Models.Lendi.Find(primaryKey, UserContext.Current, "FCOMOD"),
				(model) => form_data.MapToModel(model as Models.Lendi)
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
	}
}
