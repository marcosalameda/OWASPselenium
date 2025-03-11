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
using GenioMVC.ViewModels.Pess1;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESS1]/

namespace GenioMVC.Controllers
{
	public partial class Pess1Controller : ControllerBase
	{
		public Pess1Controller(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION PESS1]/


		//[AddHeader("X-Frame-Options", "SAMEORIGIN")]
		public ActionResult PTN_Report_3H11([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_3H11", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 3H11]/
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
		public ActionResult PTN_Report_5111([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_5111", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 5111]/
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
		public ActionResult PTN_Report_52111([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_52111", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 52111]/
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

		public ActionResult PTN_Report_52211([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_52211", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 52211]/
				List<string> allowedReportFormats = new List<string> { "PDF" };
				if (requestModel.Format != null && !allowedReportFormats.Contains(requestModel.Format))
					throw new Exception(Resources.Resources.O_FORMATO_DE_RELATOR01134);

				string reportFormat = requestModel.Format != null ? ReportSSRS.GetExportType(requestModel.Format) : "PDF";
				ReportSSRS_Result result;
				using (var renderer = new ReportSSRS(reportFullPath, reportFileName, reportFullPath, isServerReports, UserContext.Current.PersistentSupport))
				{
					// MH (11/10/2017) - Report Server credentials
					if (Configuration.SSRSServer.ContainsCredentials())
						renderer.SetServerCredentials(Configuration.SSRSServer.UsernameDecode, Configuration.SSRSServer.PasswordDecode, Configuration.SSRSServer.Domain);

					renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
					result = renderer.Render(reportFormat);
				}

// USE /[MANUAL GQT OVERRIDE_REPORT 52211]/

				string fileName = "\"" + "comodatos." + result.FileNameExtension + "\"";
				return File(result.File, result.MimeType, fileName);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}

		public ActionResult PTN_Report_52311([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_52311", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 52311]/
				List<string> allowedReportFormats = new List<string> { "DOC" };
				if (requestModel.Format != null && !allowedReportFormats.Contains(requestModel.Format))
					throw new Exception(Resources.Resources.O_FORMATO_DE_RELATOR01134);

				string reportFormat = requestModel.Format != null ? ReportSSRS.GetExportType(requestModel.Format) : "WORDOPENXML";
				ReportSSRS_Result result;
				using (var renderer = new ReportSSRS(reportFullPath, reportFileName, reportFullPath, isServerReports, UserContext.Current.PersistentSupport))
				{
					// MH (11/10/2017) - Report Server credentials
					if (Configuration.SSRSServer.ContainsCredentials())
						renderer.SetServerCredentials(Configuration.SSRSServer.UsernameDecode, Configuration.SSRSServer.PasswordDecode, Configuration.SSRSServer.Domain);

					renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
					result = renderer.Render(reportFormat);
				}

// USE /[MANUAL GQT OVERRIDE_REPORT 52311]/

				string fileName = "\"" + "comodatos." + result.FileNameExtension + "\"";
				return File(result.File, result.MimeType, fileName);
			}
			catch (Exception e)
			{
				CSGenio.framework.Log.Error("Erro_Report: " + e.Message + "; " + (e.InnerException != null ? e.InnerException.Message : ""));
				if (!preview)
					return Json(new { Success = false, Message = Resources.Resources.FALHA_AO_GERAR_O_REL63109 + " -- " + e.Message }, "application/json");
				return JsonERROR(Resources.Resources.OCORREU_UM_ERRO_INES30674);
			}
		}

		public ActionResult PTN_Report_5311([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodatos";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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
					throw new FrameworkException(Resources.Resources.NAO_E_POSSIVEL_ACEDE59423, "PTN_Report_5311", "Cannot access the specified record");


				string[] historicFieldNames = new string[1]{"pess1"};
				string[] historicFieldValues = new string[1]{Navigation.GetStrValue("pess1")};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[1]{"glob.pricolor"};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[0]{};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 5311]/
				List<string> allowedReportFormats = new List<string> { "XLSX", "PDF" };
				if (requestModel.Format != null && !allowedReportFormats.Contains(requestModel.Format))
					throw new Exception(Resources.Resources.O_FORMATO_DE_RELATOR01134);

				string reportFormat = requestModel.Format != null ? ReportSSRS.GetExportType(requestModel.Format) : "EXCELOPENXML";
				ReportSSRS_Result result;
				using (var renderer = new ReportSSRS(reportFullPath, reportFileName, reportFullPath, isServerReports, UserContext.Current.PersistentSupport))
				{
					// MH (11/10/2017) - Report Server credentials
					if (Configuration.SSRSServer.ContainsCredentials())
						renderer.SetServerCredentials(Configuration.SSRSServer.UsernameDecode, Configuration.SSRSServer.PasswordDecode, Configuration.SSRSServer.Domain);

					renderer.ConstructReport(UserContext.Current.User, area, historicFieldNames, historicFieldValues, globFields, areasReport, limitation.ToArray(), specialFormulasFields);
					result = renderer.Render(reportFormat);
				}

// USE /[MANUAL GQT OVERRIDE_REPORT 5311]/

				string fileName = "\"" + "comodatos." + result.FileNameExtension + "\"";
				return File(result.File, result.MimeType, fileName);
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
			/*
				Instead of loading the entire record from the database, a record will be created in memory with the keys filled in,
					and additional fields from "Field" type limits will be mapped later.
				This allows us to reduce database queries, as we already have all the necessary information to apply the limits.
			*/
			Models.Pess1 row = new Models.Pess1(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("pess1");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

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
							var model = new Pess1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pess1___cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "PESS1___STAKEDESIGNAT":	// Field (DB)
						{
							var model = new Pess1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pess1___stakedesignat(qs);
							result = model.TableStakeDesignat;
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
		/// Recalculate formulas of the "Pess1" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Pess1([FromBody]Pess1_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "pess1",
				(primaryKey) => Models.Pess1.Find(primaryKey, UserContext.Current, "FPESS1"),
				(model) => formData.MapToModel(model as Models.Pess1)
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
