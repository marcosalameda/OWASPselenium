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
using GenioMVC.ViewModels.C_brn;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER C_BRN]/

namespace GenioMVC.Controllers
{
	public partial class C_brnController : ControllerBase
	{

		private IChatbotService _aiService;
		public C_brnController(UserContextService userContext, IChatbotService aiService): base(userContext) 
		{
			_aiService = aiService;
		}


// USE /[MANUAL GQT CONTROLLER_NAVIGATION C_BRN]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAc_brn>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER C_BRN]/





		/// <summary>
		/// Recalculate formulas of the "C_brn" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_C_brn([FromBody]C_brn_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "c_brn",
				(primaryKey) => Models.C_brn.Find(primaryKey, UserContext.Current, "FC_BRN"),
				(model) => formData.MapToModel(model as Models.C_brn)
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
