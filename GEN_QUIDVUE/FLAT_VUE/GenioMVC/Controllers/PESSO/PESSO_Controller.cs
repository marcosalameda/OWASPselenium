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
using GenioMVC.ViewModels.Pesso;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESSO]/

namespace GenioMVC.Controllers
{
	public partial class PessoController : ControllerBase
	{
		public PessoController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION PESSO]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioApesso>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER PESSO]/


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
			Models.Pesso row = null;

			try
			{
				row = Models.Pesso.Find(Navigation.GetStrValue("pesso"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model pesso");
			}

			if (row == null)
			{
				row = new Models.Pesso(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("pesso");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "EXTERNO_CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Externo_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Externo_cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "PESSO___CATEGCATEGORY":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso___categcategory(qs);
							result = model.TableCategCategory;
						}
						break;
					case "PESSO___PAIS1COUNTRY_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso___pais1country_(qs);
							result = model.TablePais1Country;
						}
						break;
					case "PESSO___CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso___cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "PESSO___REGI1REGIAO__":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso___regi1regiao__(qs);
							result = model.TableRegi1Regiao;
						}
						break;
					case "PESSO1__CATEGCATEGORY":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso1__categcategory(qs);
							result = model.TableCategCategory;
						}
						break;
					case "PESSO1__CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso1__cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "PESSO1__REGI1REGIAO__":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pesso1_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pesso1__regi1regiao__(qs);
							result = model.TableRegi1Regiao;
						}
						break;
					case "PESSOSEPCATEGCATEGORY":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pessosep_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pessosepcategcategory(qs);
							result = model.TableCategCategory;
						}
						break;
					case "PESSOS00CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Pessosep_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Pessos00cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
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
					case "EXTERNO_CMPNYDESIGNAT":	// Field (DB)
						values = new Externo_ViewModel(UserContext.Current).GetDependant_ExternoTableCmpnyDesignat(Selected);
						break;
					case "PESSO___CATEGCATEGORY":	// Field (DB)
						values = new Pesso_ViewModel(UserContext.Current).GetDependant_PessoTableCategCategory(Selected);
						break;
					case "PESSO___PAIS1COUNTRY_":	// Field (DB)
						values = new Pesso_ViewModel(UserContext.Current).GetDependant_PessoTablePais1Country(Selected);
						break;
					case "PESSO___CMPNYDESIGNAT":	// Field (DB)
						values = new Pesso_ViewModel(UserContext.Current).GetDependant_PessoTableCmpnyDesignat(Selected);
						break;
					case "PESSO___REGI1REGIAO__":	// Field (DB)
						values = new Pesso_ViewModel(UserContext.Current).GetDependant_PessoTableRegi1Regiao(Selected);
						break;
					case "PESSO1__CATEGCATEGORY":	// Field (DB)
						values = new Pesso1_ViewModel(UserContext.Current).GetDependant_Pesso1TableCategCategory(Selected);
						break;
					case "PESSO1__CMPNYDESIGNAT":	// Field (DB)
						values = new Pesso1_ViewModel(UserContext.Current).GetDependant_Pesso1TableCmpnyDesignat(Selected);
						break;
					case "PESSO1__REGI1REGIAO__":	// Field (DB)
						values = new Pesso1_ViewModel(UserContext.Current).GetDependant_Pesso1TableRegi1Regiao(Selected);
						break;
					case "PESSOSEPCATEGCATEGORY":	// Field (DB)
						values = new Pessosep_ViewModel(UserContext.Current).GetDependant_PessosepTableCategCategory(Selected);
						break;
					case "PESSOS00CMPNYDESIGNAT":	// Field (DB)
						values = new Pessosep_ViewModel(UserContext.Current).GetDependant_Pessos00TableCmpnyDesignat(Selected);
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
		/// Recalculate formulas of the "Externo" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Externo([FromBody]Externo_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "pesso",
				(primaryKey) => Models.Pesso.Find(primaryKey, UserContext.Current, "FEXTERNO"),
				(model) => form_data.MapToModel(model as Models.Pesso)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Pesso" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Pesso([FromBody]Pesso_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "pesso",
				(primaryKey) => Models.Pesso.Find(primaryKey, UserContext.Current, "FPESSO"),
				(model) => form_data.MapToModel(model as Models.Pesso)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Pesso1" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Pesso1([FromBody]Pesso1_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "pesso",
				(primaryKey) => Models.Pesso.Find(primaryKey, UserContext.Current, "FPESSO1"),
				(model) => form_data.MapToModel(model as Models.Pesso)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Pessosep" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Pessosep([FromBody]Pessosep_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "pesso",
				(primaryKey) => Models.Pesso.Find(primaryKey, UserContext.Current, "FPESSOSEP"),
				(model) => form_data.MapToModel(model as Models.Pesso)
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
