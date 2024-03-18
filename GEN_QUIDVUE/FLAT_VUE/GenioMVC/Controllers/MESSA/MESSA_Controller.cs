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
using GenioMVC.ViewModels.Messa;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MESSA]/

namespace GenioMVC.Controllers
{
	public partial class MessaController : ControllerBase
	{
		public MessaController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION MESSA]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAmessa>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER MESSA]/


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
			Models.Messa row = null;

			try
			{
				row = Models.Messa.Find(Navigation.GetStrValue("messa"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model messa");
			}

			if (row == null)
			{
				row = new Models.Messa(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("messa");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "MESSA___ENTITNAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Messa_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Messa___entitname____(qs);
							result = model.TableEntitName;
						}
						break;
					case "MESSA___PERSONAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Messa_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Messa___personame____(qs);
							result = model.TablePersoName;
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
					case "MESSA___ENTITNAME____":	// Field (DB)
						values = new Messa_ViewModel(UserContext.Current).GetDependant_MessaTableEntitName(Selected);
						break;
					case "MESSA___PERSONAME____":	// Field (DB)
						values = new Messa_ViewModel(UserContext.Current).GetDependant_MessaTablePersoName(Selected);
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
		/// Recalculate formulas of the "Messa" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Messa([FromBody]Messa_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "messa",
				(primaryKey) => Models.Messa.Find(primaryKey, UserContext.Current, "FMESSA"),
				(model) => form_data.MapToModel(model as Models.Messa)
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
