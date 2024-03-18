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
using GenioMVC.ViewModels.Pess1;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESS1]/

namespace GenioMVC.Controllers
{
	public partial class Pess1Controller : ControllerBase
	{
		public Pess1Controller(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION PESS1]/


		//[AddHeader("X-Frame-Options", "SAMEORIGIN")]
		public ActionResult PTN_Report_3111([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdl");
				var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
				var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
				if (isServerReports)
					reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

				string area = "pess1";
				var limitation = new List<ReportLimitParameter>();
				// This find is necessary to check: if the value exists, if the record is invalid, and if the user can view it (EPH).
				string id = Navigation.GetStrValue(area);
				var record = Models.Pess1.Find(id, UserContext.Current, fieldsToSerialize: new string[] { "zzstate" });
				if (record == null || record.ValZzstate != 0)
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_3111", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 3111]/
				throw new NotImplementedException("ReportViewer is not available in DotNet Core");
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}

		//[AddHeader("X-Frame-Options", "SAMEORIGIN")]
		public ActionResult PTN_Report_32111([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdl");
				var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
				var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
				if (isServerReports)
					reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

				string area = "pess1";
				var limitation = new List<ReportLimitParameter>();
				// This find is necessary to check: if the value exists, if the record is invalid, and if the user can view it (EPH).
				string id = Navigation.GetStrValue(area);
				var record = Models.Pess1.Find(id, UserContext.Current, fieldsToSerialize: new string[] { "zzstate" });
				if (record == null || record.ValZzstate != 0)
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_32111", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 32111]/
				throw new NotImplementedException("ReportViewer is not available in DotNet Core");
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}

		public ActionResult PTN_Report_32211([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdl");
				var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
				var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
				if (isServerReports)
					reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

				string area = "pess1";
				var limitation = new List<ReportLimitParameter>();
				// This find is necessary to check: if the value exists, if the record is invalid, and if the user can view it (EPH).
				string id = Navigation.GetStrValue(area);
				var record = Models.Pess1.Find(id, UserContext.Current, fieldsToSerialize: new string[] { "zzstate" });
				if (record == null || record.ValZzstate != 0)
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_32211", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 32211]/
				ReportSSRS_Result result;
				using (var renderer = new ReportSSRS(reportFullPath, reportFileName, reportFullPath, isServerReports, UserContext.Current.PersistentSupport))
				{
					// MH (11/10/2017) - Report Server credentials
					if (Configuration.SSRSServer.ContainsCredentials())
						renderer.SetServerCredentials(Configuration.SSRSServer.Username, Configuration.SSRSServer.Password, Configuration.SSRSServer.Domain);

					renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
					result = renderer.Render("PDF");
				}

// USE /[MANUAL GQT OVERRIDE_REPORT 32211]/

				Response.Headers["FileName"] = reportFileName + "." + result.FileNameExtension;
				if (result.FileNameExtension == "pdf") // If pass file extension, browser will download file instead of opening it in PDF Viewer.
					return File(result.File, result.MimeType);
				else
					return File(result.File, result.MimeType, "comodatos." + result.FileNameExtension);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}

		public ActionResult PTN_Report_32311([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdl");
				var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
				var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
				if (isServerReports)
					reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

				string area = "pess1";
				var limitation = new List<ReportLimitParameter>();
				// This find is necessary to check: if the value exists, if the record is invalid, and if the user can view it (EPH).
				string id = Navigation.GetStrValue(area);
				var record = Models.Pess1.Find(id, UserContext.Current, fieldsToSerialize: new string[] { "zzstate" });
				if (record == null || record.ValZzstate != 0)
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_32311", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 32311]/
				ReportSSRS_Result result;
				using (var renderer = new ReportSSRS(reportFullPath, reportFileName, reportFullPath, isServerReports, UserContext.Current.PersistentSupport))
				{
					// MH (11/10/2017) - Report Server credentials
					if (Configuration.SSRSServer.ContainsCredentials())
						renderer.SetServerCredentials(Configuration.SSRSServer.Username, Configuration.SSRSServer.Password, Configuration.SSRSServer.Domain);

					renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
					result = renderer.Render("WORD");
				}

// USE /[MANUAL GQT OVERRIDE_REPORT 32311]/

				Response.Headers["FileName"] = reportFileName + "." + result.FileNameExtension;
				if (result.FileNameExtension == "pdf") // If pass file extension, browser will download file instead of opening it in PDF Viewer.
					return File(result.File, result.MimeType);
				else
					return File(result.File, result.MimeType, "comodatos." + result.FileNameExtension);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}


		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioApess1>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER PESS1]/


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
			Models.Pess1 row = null;

			try
			{
				row = Models.Pess1.Find(Navigation.GetStrValue("pess1"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model pess1");
			}

			if (row == null)
			{
				row = new Models.Pess1(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("pess1");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "PESS1___CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pess1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pess1___cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "PESS1___STAKEDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pess1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pess1___stakedesignat(qs);
							result = model.TableStakeDesignat;
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
					case "PESS1___CMPNYDESIGNAT":	// Field (DB)
						values = new Pess1_ViewModel(UserContext.Current).GetDependant_Pess1TableCmpnyDesignat(Selected);
						break;
					case "PESS1___STAKEDESIGNAT":	// Field (DB)
						values = new Pess1_ViewModel(UserContext.Current).GetDependant_Pess1TableStakeDesignat(Selected);
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
		/// Recalculate formulas of the "Pess1" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Pess1([FromBody]Pess1_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "pess1",
				(primaryKey) => Models.Pess1.Find(primaryKey, UserContext.Current, "FPESS1"),
				(model) => form_data.MapToModel(model as Models.Pess1)
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
