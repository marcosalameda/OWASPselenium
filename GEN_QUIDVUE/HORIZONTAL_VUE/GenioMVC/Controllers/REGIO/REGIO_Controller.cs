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
using GenioMVC.ViewModels.Regio;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REGIO]/

namespace GenioMVC.Controllers
{
	public partial class RegioController : ControllerBase
	{
		private IChatbotService _aiService;
		public RegioController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL GQT CONTROLLER_NAVIGATION REGIO]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAregio>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER REGIO]/

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
			Models.Regio row = new Models.Regio(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("regio");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "REGIA___CNTRYCOUNTRY_":	// Field (DB)
						{
							var model = new Regia_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regia___cntrycountry_(qs);
							result = model.TableCntryCountry;
						}
						break;
					case "REGIA_MLCNTRYCOUNTRY_":	// Field (DB)
						{
							var model = new Regia_ml_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regia_mlcntrycountry_(qs);
							result = model.TableCntryCountry;
						}
						break;
					case "REGIA_MLPAIS1COUNTRY_":	// Field (DB)
						{
							var model = new Regia_ml_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regia_mlpais1country_(qs);
							result = model.TablePais1Country;
						}
						break;
					case "REGIA_ONCNTRYCOUNTRY_":	// Field (DB)
						{
							var model = new Regia_on_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regia_oncntrycountry_(qs);
							result = model.TableCntryCountry;
						}
						break;
					case "REGIA_ONPAIS1COUNTRY_":	// Field (DB)
						{
							var model = new Regia_on_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regia_onpais1country_(qs);
							result = model.TablePais1Country;
						}
						break;
					case "REGIAPROCNTRYCOUNTRY_":	// Field (DB)
						{
							var model = new Regiapro_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regiaprocntrycountry_(qs);
							result = model.TableCntryCountry;
						}
						break;
					case "REGIAPROPAIS1COUNTRY_":	// Field (DB)
						{
							var model = new Regiapro_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Regiapropais1country_(qs);
							result = model.TablePais1Country;
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
				return JsonOK(result);
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
					case "REGIA___CNTRYCOUNTRY_":	// Field (DB)
						values = new Regia_ViewModel(UserContext.Current).GetDependant_RegiaTableCntryCountry(Selected);
						break;
					case "REGIA_MLCNTRYCOUNTRY_":	// Field (DB)
						values = new Regia_ml_ViewModel(UserContext.Current).GetDependant_Regia_mlTableCntryCountry(Selected);
						break;
					case "REGIA_MLPAIS1COUNTRY_":	// Field (DB)
						values = new Regia_ml_ViewModel(UserContext.Current).GetDependant_Regia_mlTablePais1Country(Selected);
						break;
					case "REGIA_ONCNTRYCOUNTRY_":	// Field (DB)
						values = new Regia_on_ViewModel(UserContext.Current).GetDependant_Regia_onTableCntryCountry(Selected);
						break;
					case "REGIA_ONPAIS1COUNTRY_":	// Field (DB)
						values = new Regia_on_ViewModel(UserContext.Current).GetDependant_Regia_onTablePais1Country(Selected);
						break;
					case "REGIAPROCNTRYCOUNTRY_":	// Field (DB)
						values = new Regiapro_ViewModel(UserContext.Current).GetDependant_RegiaproTableCntryCountry(Selected);
						break;
					case "REGIAPROPAIS1COUNTRY_":	// Field (DB)
						values = new Regiapro_ViewModel(UserContext.Current).GetDependant_RegiaproTablePais1Country(Selected);
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
		/// Recalculate formulas of the "Regia" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Regia([FromBody]Regia_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "regio",
				(primaryKey) => Models.Regio.Find(primaryKey, UserContext.Current, "FREGIA"),
				(model) => formData.MapToModel(model as Models.Regio)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Regia_ml" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Regia_ml([FromBody]Regia_ml_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "regio",
				(primaryKey) => Models.Regio.Find(primaryKey, UserContext.Current, "FREGIA_ML"),
				(model) => formData.MapToModel(model as Models.Regio)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Regia_on" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Regia_on([FromBody]Regia_on_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "regio",
				(primaryKey) => Models.Regio.Find(primaryKey, UserContext.Current, "FREGIA_ON"),
				(model) => formData.MapToModel(model as Models.Regio)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Regiapro" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Regiapro([FromBody]Regiapro_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "regio",
				(primaryKey) => Models.Regio.Find(primaryKey, UserContext.Current, "FREGIAPRO"),
				(model) => formData.MapToModel(model as Models.Regio)
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
			return base.GetDocumsTickets("REGIO", requestModel.FieldName, requestModel.KeyValue);
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
