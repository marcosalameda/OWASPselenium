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
using GenioMVC.ViewModels.Facil;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FACIL]/

namespace GenioMVC.Controllers
{
	public partial class FacilController : ControllerBase
	{
		public FacilController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION FACIL]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAfacil>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER FACIL]/


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
			Models.Facil row = null;

			try
			{
				row = Models.Facil.Find(Navigation.GetStrValue("facil"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model facil");
			}

			if (row == null)
			{
				row = new Models.Facil(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("facil");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "FACIL___ENTITNAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Facil_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Facil___entitname____(qs);
							result = model.TableEntitName;
						}
						break;
					case "FACIL___FACTYTYPE____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Facil_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Facil___factytype____(qs);
							result = model.TableFactyType;
						}
						break;
					case "FACILFEXENTITNAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Facilfex_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Facilfexentitname____(qs);
							result = model.TableEntitName;
						}
						break;
					case "FACILFEXFACTYTYPE____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Facilfex_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Facilfexfactytype____(qs);
							result = model.TableFactyType;
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
					case "FACIL___ENTITNAME____":	// Field (DB)
						values = new Facil_ViewModel(UserContext.Current).GetDependant_FacilTableEntitName(Selected);
						break;
					case "FACIL___FACTYTYPE____":	// Field (DB)
						values = new Facil_ViewModel(UserContext.Current).GetDependant_FacilTableFactyType(Selected);
						break;
					case "FACILFEXENTITNAME____":	// Field (DB)
						values = new Facilfex_ViewModel(UserContext.Current).GetDependant_FacilfexTableEntitName(Selected);
						break;
					case "FACILFEXFACTYTYPE____":	// Field (DB)
						values = new Facilfex_ViewModel(UserContext.Current).GetDependant_FacilfexTableFactyType(Selected);
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
		/// Recalculate formulas of the "Facil" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Facil([FromBody]Facil_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "facil",
				(primaryKey) => Models.Facil.Find(primaryKey, UserContext.Current, "FFACIL"),
				(model) => form_data.MapToModel(model as Models.Facil)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Facilfex" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Facilfex([FromBody]Facilfex_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "facil",
				(primaryKey) => Models.Facil.Find(primaryKey, UserContext.Current, "FFACILFEX"),
				(model) => form_data.MapToModel(model as Models.Facil)
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
