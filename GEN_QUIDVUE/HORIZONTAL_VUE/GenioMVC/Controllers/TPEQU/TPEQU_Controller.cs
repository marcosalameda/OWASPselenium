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
using GenioMVC.ViewModels.Tpequ;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPEQU]/

namespace GenioMVC.Controllers
{
	public partial class TpequController : ControllerBase
	{
		private IChatbotService _aiService;
		public TpequController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL GQT CONTROLLER_NAVIGATION TPEQU]/


		public ActionResult GQT_Report_2D2141([FromBody]RequestReportModel requestModel)
		{
			var allSelected = requestModel.AllSelected;
			bool preview = false;
			try
			{
				var isServerReports = !Configuration.SSRSServer.isLocalReports;
				var reportName = "Teste equip";
				var reportFileName = reportName + (isServerReports ? "" : ".rdlc");
				var reportPath = isServerReports ? Configuration.SSRSServer.path : Configuration.PathReports;
				var reportFullPath = reportPath + (isServerReports ? "/" : "\\") + reportFileName;
				if (isServerReports)
					reportFullPath = (reportFullPath.StartsWith("/") ? "" : "/") + reportFullPath;

				string area = "tpequ";
				var limitation = new List<ReportLimitParameter>();


				CriteriaSet crs = this.Navigation.GetValue<CriteriaSet>("CriteriaSet_ML2D21");
				if (crs == null && allSelected)
					throw new FrameworkException(Resources.Resources.NAO_FOI_POSSIVEL_OBT36525, "GQT_Report_2D2141", "Could not obtain the selected records list.");

				limitation.Add(new ReportLimitParameter_DM()
				{
					FullFieldName = "tpequ.codtpequ",
					FieldValue = allSelected
						? GetActionIds(crs, null, CSGenio.business.Area.createArea("tpequ",
							UserContext.Current.User, UserContext.Current.User.CurrentModule)).ToArray()
						: Navigation.GetValue<string[]>("tpequ_Selections")
				});

				string[] historicFieldNames = new string[0]{};
				string[] historicFieldValues = new string[0]{};
				Dictionary<string, string> arrayFieldsList = new Dictionary<string, string>();

				string[] globFields = new string[0]{};

				string[] specialFormulasFields = new string[0]{};
				string[] areasReport = new string[1]{"tpequ"};


// USE /[MANUAL GQT BEFORE_EXECUTE_REPORT 2D2141]/
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

// USE /[MANUAL GQT OVERRIDE_REPORT 2D2141]/

				string fileName = "\"" + "Teste equip." + result.FileNameExtension + "\"";
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
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAtpequ>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER TPEQU]/

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
			Models.Tpequ row = new Models.Tpequ(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("tpequ");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "TPEQU___FAMILFAMILY__":	// Field (DB)
						{
							var model = new Tpequ_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Tpequ___familfamily__(qs);
							result = model.TableFamilFamily;
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
					case "TPEQU___FAMILFAMILY__":	// Field (DB)
						values = new Tpequ_ViewModel(UserContext.Current).GetDependant_TpequTableFamilFamily(Selected);
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
		/// Recalculate formulas of the "Tpequ" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Tpequ([FromBody]Tpequ_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "tpequ",
				(primaryKey) => Models.Tpequ.Find(primaryKey, UserContext.Current, "FTPEQU"),
				(model) => formData.MapToModel(model as Models.Tpequ)
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
			return base.GetDocumsTickets("TPEQU", requestModel.FieldName, requestModel.KeyValue);
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
		/// Stores a new document in the Docums table
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFile([FromForm] RequestDocumsCreateModel requestModel)
		{
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version);
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
