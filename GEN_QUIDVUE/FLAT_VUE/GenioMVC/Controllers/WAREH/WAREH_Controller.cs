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
using GenioMVC.ViewModels.Wareh;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		public WarehController(UserContextService userContext): base(userContext) { }
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
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Armaz([FromBody]Armaz_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FARMAZ"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Armaz03" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Armaz03([FromBody]Armaz03_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FARMAZ03"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Armazpop" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Armazpop([FromBody]Armazpop_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FARMAZPOP"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Authent" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Authent([FromBody]Authent_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FAUTHENT"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Btnsform" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Btnsform([FromBody]Btnsform_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FBTNSFORM"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Extforms" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Extforms([FromBody]Extforms_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FEXTFORMS"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Mltform" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Mltform([FromBody]Mltform_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FMLTFORM"),
				(model) => form_data.MapToModel(model as Models.Wareh)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Tmline" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Tmline([FromBody]Tmline_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "wareh",
				(primaryKey) => Models.Wareh.Find(primaryKey, UserContext.Current, "FTMLINE"),
				(model) => form_data.MapToModel(model as Models.Wareh)
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
