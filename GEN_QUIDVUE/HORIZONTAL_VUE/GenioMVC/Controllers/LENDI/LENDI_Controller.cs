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
using GenioMVC.ViewModels.Lendi;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
	public partial class LendiController : ControllerBase
	{
		private IChatbotService _aiService;
		public LendiController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL GQT CONTROLLER_NAVIGATION LENDI]/


		public ActionResult GQT_Report_1511([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = true;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "comodato";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
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

// USE /[MANUAL GQT OVERRIDE_REPORT 1511]/

				string fileName = "\"" + "comodato." + result.FileNameExtension + "\"";
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


		protected JsonResult PTN_MenuR_DELETEONEROW(string id, string area)
		{
			try
			{
				using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("manua_exec_time", new System.Diagnostics.TagList([
					new("Name", "CONTROLLER_ROUTINE_BODY"),
					new("Parameter", "DELETEONEROW"),
					new("ModuleOrSystem", "GQT")
				]), "ms", "Time to execute the manual code.")) {
//Platform: MVC | Type: CONTROLLER_ROUTINE_BODY | Module: GQT | Parameter: DELETEONEROW | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:d31ac115-e389-497a-814c-ae4776fc238a
			
			var sp = m_userContext.PersistentSupport;
			var user = m_userContext.User;
			var id_model = CSGenioAlendi.search(sp, id, user);

			sp.openConnection();
				id_model.delete(sp);
			sp.closeConnection();
			
			return Json(new { success = "OK", message = "Routine success" });
//END_MANUALCODE
				}

			}
			catch (BusinessException ex)
			{
				return Json(new { success = "E", message = ex.UserMessage });
			}
			catch (Exception ex)
			{
				Log.Error("Error in action PTN_MenuR_DELETEONEROW: " + ex.Message);
				return Json(new { success = "E", message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}
		}

		// POST: /Lendi/PTN_Menu_LIST_DM_MB_R_MenuR_DELETEONEROW
		public JsonResult PTN_Menu_LIST_DM_MB_R_MenuR_DELETEONEROW([FromBody] RequestRoutineSingleModel requestModel)
		{
			return PTN_MenuR_DELETEONEROW(requestModel.Id, requestModel.Area);
		}

		protected JsonResult PTN_MenuR_DELETEROWS(CriteriaSet crs, List<Relation> relations, CSGenio.business.Area routineArea)
		{
			try
			{
				using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("manua_exec_time", new System.Diagnostics.TagList([
					new("Name", "CONTROLLER_ROUTINE_BODY"),
					new("Parameter", "DELETEROWS"),
					new("ModuleOrSystem", "GQT")
				]), "ms", "Time to execute the manual code.")) {
//Platform: MVC | Type: CONTROLLER_ROUTINE_BODY | Module: GQT | Parameter: DELETEROWS | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:db1bb593-c309-49f0-9eee-3ee35c5c4383
			
			var sp = m_userContext.PersistentSupport;
			var user = m_userContext.User;
			var listComod = CSGenioAlendi.searchList(sp, user, crs);
			
			sp.openConnection();
			foreach (var comod in listComod) {
				comod.delete(sp);
			}
			sp.closeConnection();
			
			return Json(new { success = "OK", message = "Routine success" });
//END_MANUALCODE
				}

			}
			catch (BusinessException ex)
			{
				return Json(new { success = "E", message = ex.UserMessage });
			}
			catch (Exception ex)
			{
				Log.Error("Error in action PTN_MenuR_DELETEROWS: " + ex.Message);
				return Json(new { success = "E", message = Resources.Resources.PEDIMOS_DESCULPA__OC63848 });
			}
		}

		// POST: /Lendi/PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS
		public JsonResult PTN_Menu_LIST_DM_MB_R_MenuR_DELETEROWS([FromBody] RequestRoutineMultipleModel requestModel)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea("lendi", UserContext.Current.User, UserContext.Current.User.CurrentModule);
			ListViewModel model = new PTN_Menu_LIST_DM_MB_R_ViewModel(m_userContext);
			NameValueCollection parameters;

			// Fetch and format the parameters
			if (requestModel.QueryParams != null && requestModel.QueryParams.Count() > 0)
				parameters = FormatQueryString(requestModel.QueryParams);
			else
				parameters = this.Navigation.GetValue<NameValueCollection>("requestValuesPTN_Menu_LIST_DM_MB_R");

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				m_userContext.PersistentSupport,
				model.Uuid,
				m_userContext.User
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView
			);

			// Get CriteriaSet
			CriteriaSet crs = model.BuildCriteriaSet(tableConfig, parameters, out bool hasAllRequiredLimits);

			if (!requestModel.AllSelected || crs == null)
				crs.In("lendi", "CODLENDI", requestModel.Ids);

			// Fetch List of Related Areas
			List<string> relatedTables = [];
			QueryUtils.checkConditionsForForeignTables(crs, area, relatedTables);

			/*
			 * This is a list of Relationships that has to be included in the query that will be using the CriteriaSet.
			 * This can be done using QueryUtils.setFromTabDirect()
			 */
			List<CSGenio.framework.Relation> relations = QueryUtils.tablesRelationships(relatedTables, area);

			return PTN_MenuR_DELETEROWS(crs, relations, area);
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
			/*
				Instead of loading the entire record from the database, a record will be created in memory with the keys filled in,
					and additional fields from "Field" type limits will be mapped later.
				This allows us to reduce database queries, as we already have all the necessary information to apply the limits.
			*/
			Models.Lendi row = new Models.Lendi(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("lendi");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

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
							var model = new Comod_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Comod___pess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "COMOD___PESS2NAME____":	// Field (DB)
						{
							var model = new Comod_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Comod___pess2name____(qs);
							result = model.TablePess2Name;
						}
						break;
					case "COMOD___EQUIPREGISTNR":	// Field (DB)
						{
							var model = new Comod_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Comod___equipregistnr(qs);
							result = model.TableEquipRegistnr;
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


		// POST: /Lendi/PTN_3171_Equip_Registnr_ShowWhen
		[HttpPost]
		public JsonResult PTN_3171_Equip_Registnr_ShowWhen([FromBody] ViewModels.Lendi.PTN_Menu_3171_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Lendi(UserContext.Current);

				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: 1==1
				var result = 1==1;
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}

		// POST: /Lendi/PTN_3171_Lendi_Ifoutdt__ShowWhen
		[HttpPost]
		public JsonResult PTN_3171_Lendi_Ifoutdt__ShowWhen([FromBody] ViewModels.Lendi.PTN_Menu_3171_ViewModel formData)
		{
			try
			{
				// Create a model from form data to avoid extra database queries.
				var p = new Models.Lendi(UserContext.Current);

				// Map client-side form data into the model
				formData.MapToModel(p);

				// Formula: 1==0
				var result = 1==0;
				return JsonOK(result);
			}
			catch (Exception ex)
			{
				return JsonERROR(ex.Message);
			}
		}



		/// <summary>
		/// Recalculate formulas of the "Comod" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Comod([FromBody]Comod_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "lendi",
				(primaryKey) => Models.Lendi.Find(primaryKey, UserContext.Current, "FCOMOD"),
				(model) => formData.MapToModel(model as Models.Lendi)
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

		/// <summary>
		/// Gets the necessary tickets to interact with the given document
		/// </summary>
		/// <param name="requestModel">The request model with the table, field and the primary key of the record</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetDocumsTickets([FromBody] RequestDocumGetTicketsModel requestModel)
		{
			return base.GetDocumsTickets("LENDI", requestModel.FieldName, requestModel.KeyValue);
		}

		/// <summary>
		/// Gets the versions of the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetFileVersions([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFileVersions(requestModel.Ticket);
		}

		/// <summary>
		/// Gets the properties of the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetFileProperties([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFileProperties(requestModel.Ticket);
		}

		/// <summary>
		/// Gets the binary file associated to the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket and view type</param>
		/// <returns>A File object with the content of the document</returns>
		public ActionResult GetFile([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFile(requestModel.Ticket, requestModel.ViewType);
		}

		/// <summary>
		/// Changes the state/properties of a given document
		/// </summary>
		/// <param name="requestModel">The request model with a list of changes</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFilesState([FromBody] RequestDocumsChangeModel requestModel)
		{
			return base.SetFilesState(requestModel.Documents);
		}
	}
}
