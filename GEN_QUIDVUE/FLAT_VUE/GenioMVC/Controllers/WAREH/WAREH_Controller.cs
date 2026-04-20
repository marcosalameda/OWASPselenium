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
using GenioMVC.ViewModels.Wareh;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		private IChatbotService _aiService;
		public WarehController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL GQT CONTROLLER_NAVIGATION WAREH]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAwareh>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER WAREH]/





		/// <summary>
		/// Recalculate formulas of the "Armaz" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Armaz([FromBody]Armaz_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FARMAZ"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Armaz03" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Armaz03([FromBody]Armaz03_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FARMAZ03"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Armazpop" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Armazpop([FromBody]Armazpop_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FARMAZPOP"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Authent" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Authent([FromBody]Authent_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FAUTHENT"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Btnsform" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Btnsform([FromBody]Btnsform_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FBTNSFORM"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Extforms" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Extforms([FromBody]Extforms_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FEXTFORMS"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Mltform" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Mltform([FromBody]Mltform_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FMLTFORM"),
				(model) => formData.MapToModel(model as Models.Wareh)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Tmline" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Tmline([FromBody]Tmline_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FTMLINE"),
				(model) => formData.MapToModel(model as Models.Wareh)
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
			return base.GetDocumsTickets("WAREH", requestModel.FieldName, requestModel.KeyValue);
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
