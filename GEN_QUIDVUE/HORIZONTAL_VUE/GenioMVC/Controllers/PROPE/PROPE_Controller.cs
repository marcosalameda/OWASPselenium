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
using GenioMVC.ViewModels.Prope;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPE]/

namespace GenioMVC.Controllers
{
	public partial class PropeController : ControllerBase
	{
		private IChatbotService _aiService;
		public PropeController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL GQT CONTROLLER_NAVIGATION PROPE]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAprope>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER PROPE]/

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
			Models.Prope row = new Models.Prope(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("prope");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "PROPE01_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope01_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope01_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE03_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope03_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope03_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE03_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope03_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope03_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE05_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope05_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope05_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE05_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope05_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope05_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE06_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope06_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope06_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE06_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope06_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope06_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE07_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope07_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope07_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE07_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope07_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope07_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE08_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope08_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope08_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE08_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope08_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope08_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE09_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope09_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope09_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE09_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope09_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope09_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE10_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope10_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope10_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE10_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope10_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope10_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE11_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope11_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope11_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE11_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope11_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope11_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE17_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope17_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope17_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE17_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope17_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope17_agentname____(qs);
							result = model.TableAgentName;
						}
						break;
					case "PROPE19_CITY_CITY____":	// Field (DB)
						{
							var model = new Prope19_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope19_city_city____(qs);
							result = model.TableCityCity;
						}
						break;
					case "PROPE19_AGENTNAME____":	// Field (DB)
						{
							var model = new Prope19_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Prope19_agentname____(qs);
							result = model.TableAgentName;
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
					case "PROPE01_AGENTNAME____":	// Field (DB)
						values = new Prope01_ViewModel(UserContext.Current).GetDependant_Prope01TableAgentName(Selected);
						break;
					case "PROPE03_AGENTNAME____":	// Field (DB)
						values = new Prope03_ViewModel(UserContext.Current).GetDependant_Prope03TableAgentName(Selected);
						break;
					case "PROPE03_CITY_CITY____":	// Field (DB)
						values = new Prope03_ViewModel(UserContext.Current).GetDependant_Prope03TableCityCity(Selected);
						break;
					case "PROPE05_AGENTNAME____":	// Field (DB)
						values = new Prope05_ViewModel(UserContext.Current).GetDependant_Prope05TableAgentName(Selected);
						break;
					case "PROPE05_CITY_CITY____":	// Field (DB)
						values = new Prope05_ViewModel(UserContext.Current).GetDependant_Prope05TableCityCity(Selected);
						break;
					case "PROPE06_CITY_CITY____":	// Field (DB)
						values = new Prope06_ViewModel(UserContext.Current).GetDependant_Prope06TableCityCity(Selected);
						break;
					case "PROPE06_AGENTNAME____":	// Field (DB)
						values = new Prope06_ViewModel(UserContext.Current).GetDependant_Prope06TableAgentName(Selected);
						break;
					case "PROPE07_CITY_CITY____":	// Field (DB)
						values = new Prope07_ViewModel(UserContext.Current).GetDependant_Prope07TableCityCity(Selected);
						break;
					case "PROPE07_AGENTNAME____":	// Field (DB)
						values = new Prope07_ViewModel(UserContext.Current).GetDependant_Prope07TableAgentName(Selected);
						break;
					case "PROPE08_CITY_CITY____":	// Field (DB)
						values = new Prope08_ViewModel(UserContext.Current).GetDependant_Prope08TableCityCity(Selected);
						break;
					case "PROPE08_AGENTNAME____":	// Field (DB)
						values = new Prope08_ViewModel(UserContext.Current).GetDependant_Prope08TableAgentName(Selected);
						break;
					case "PROPE09_CITY_CITY____":	// Field (DB)
						values = new Prope09_ViewModel(UserContext.Current).GetDependant_Prope09TableCityCity(Selected);
						break;
					case "PROPE09_AGENTNAME____":	// Field (DB)
						values = new Prope09_ViewModel(UserContext.Current).GetDependant_Prope09TableAgentName(Selected);
						break;
					case "PROPE10_CITY_CITY____":	// Field (DB)
						values = new Prope10_ViewModel(UserContext.Current).GetDependant_Prope10TableCityCity(Selected);
						break;
					case "PROPE10_AGENTNAME____":	// Field (DB)
						values = new Prope10_ViewModel(UserContext.Current).GetDependant_Prope10TableAgentName(Selected);
						break;
					case "PROPE11_CITY_CITY____":	// Field (DB)
						values = new Prope11_ViewModel(UserContext.Current).GetDependant_Prope11TableCityCity(Selected);
						break;
					case "PROPE11_AGENTNAME____":	// Field (DB)
						values = new Prope11_ViewModel(UserContext.Current).GetDependant_Prope11TableAgentName(Selected);
						break;
					case "PROPE17_CITY_CITY____":	// Field (DB)
						values = new Prope17_ViewModel(UserContext.Current).GetDependant_Prope17TableCityCity(Selected);
						break;
					case "PROPE17_AGENTNAME____":	// Field (DB)
						values = new Prope17_ViewModel(UserContext.Current).GetDependant_Prope17TableAgentName(Selected);
						break;
					case "PROPE19_CITY_CITY____":	// Field (DB)
						values = new Prope19_ViewModel(UserContext.Current).GetDependant_Prope19TableCityCity(Selected);
						break;
					case "PROPE19_AGENTNAME____":	// Field (DB)
						values = new Prope19_ViewModel(UserContext.Current).GetDependant_Prope19TableAgentName(Selected);
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
		/// Recalculate formulas of the "Prope01" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope01([FromBody]Prope01_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE01"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope03" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope03([FromBody]Prope03_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE03"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope05" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope05([FromBody]Prope05_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE05"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope06" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope06([FromBody]Prope06_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE06"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope07" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope07([FromBody]Prope07_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE07"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope08" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope08([FromBody]Prope08_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE08"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope09" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope09([FromBody]Prope09_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE09"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope10" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope10([FromBody]Prope10_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE10"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope11" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope11([FromBody]Prope11_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE11"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope17" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope17([FromBody]Prope17_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE17"),
				(model) => formData.MapToModel(model as Models.Prope)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Prope19" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Prope19([FromBody]Prope19_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "prope",
				(primaryKey) => Models.Prope.Find(primaryKey, UserContext.Current, "FPROPE19"),
				(model) => formData.MapToModel(model as Models.Prope)
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
			return base.GetDocumsTickets("PROPE", requestModel.FieldName, requestModel.KeyValue);
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
