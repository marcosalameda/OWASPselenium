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
using GenioMVC.ViewModels.Sale;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		public SaleController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION SALE]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAsale>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER SALE]/


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
			Models.Sale row = null;

			if (row == null)
			{
				row = new Models.Sale(UserContext.Current, isEmpty: true);
				row.klass.QPrimaryKey = Navigation.GetStrValue("sale");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "VENDA___ORGANORGANIZA":	// Field (DB)
						{
							row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Venda_ViewModel(UserContext.Current) { editable = false };							
							model.MapFromModel(row);
							model.Load_Venda___organorganiza(qs);
							result = model.TableOrganOrganiza;
						}
						break;
					case "VENDAW01ORGANORGANIZA":	// Field (DB)
						{
							row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Vendaw01_ViewModel(UserContext.Current) { editable = false };							
							model.MapFromModel(row);
							model.Load_Vendaw01organorganiza(qs);
							result = model.TableOrganOrganiza;
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
					case "VENDA___ORGANORGANIZA":	// Field (DB)
						values = new Venda_ViewModel(UserContext.Current).GetDependant_VendaTableOrganOrganiza(Selected);
						break;
					case "VENDAW01ORGANORGANIZA":	// Field (DB)
						values = new Vendaw01_ViewModel(UserContext.Current).GetDependant_Vendaw01TableOrganOrganiza(Selected);
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
		/// Recalculate formulas of the "Venda" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Venda([FromBody]Venda_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDA"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw01" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw01([FromBody]Vendaw01_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW01"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw02" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw02([FromBody]Vendaw02_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW02"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw03" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw03([FromBody]Vendaw03_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW03"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw04" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw04([FromBody]Vendaw04_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW04"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw05" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw05([FromBody]Vendaw05_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW05"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw06" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw06([FromBody]Vendaw06_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW06"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw07" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw07([FromBody]Vendaw07_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW07"),
				(model) => formData.MapToModel(model as Models.Sale)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Vendaw08" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Vendaw08([FromBody]Vendaw08_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "sale",
				(primaryKey) => Models.Sale.Find(primaryKey, UserContext.Current, "FVENDAW08"),
				(model) => formData.MapToModel(model as Models.Sale)
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
