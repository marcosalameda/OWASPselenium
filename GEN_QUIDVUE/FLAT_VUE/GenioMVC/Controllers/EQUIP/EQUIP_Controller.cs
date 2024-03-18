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
using GenioMVC.ViewModels.Equip;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		public EquipController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION EQUIP]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAequip>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER EQUIP]/


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
			Models.Equip row = null;

			try
			{
				row = Models.Equip.Find(Navigation.GetStrValue("equip"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model equip");
			}

			if (row == null)
			{
				row = new Models.Equip(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("equip");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "ACCORDI_CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Accordi_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Accordi_cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "ACCORDI_PESS1NAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Accordi_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Accordi_pess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "EQUIP___CMPNYDESIGNAT":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "EQUIP___PESS1NAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___pess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___tpequtipoequi(qs);
							result = model.TableTpequTipoequi;
						}
						break;
					case "EQUIP___WAREHWAREHDES":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___warehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "EQUIP___ITEM_ITEMDES_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___item_itemdes_(qs);
							result = model.TableItemItemdes;
						}
						break;
					case "EQUIP___ROOM1ROOMNR__":	// Field (F1)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___room1roomnr__(qs);
							result = model.TableRoom1Roomnr;
						}
						break;
					case "EQUIP___DECOMDECOMNR_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___decomdecomnr_(qs);
							result = model.TableDecomDecomnr;
						}
						break;
					case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_tpequtipoequi(qs);
							result = model.TableTpequTipoequi;
						}
						break;
					case "GROUPBX_WAREHWAREHDES":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_warehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "GROUPBX_ITEM_ITEMDES_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_item_itemdes_(qs);
							result = model.TableItemItemdes;
						}
						break;
					case "GROUPBX_ROOM1ROOMNR__":	// Field (F1)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_room1roomnr__(qs);
							result = model.TableRoom1Roomnr;
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
					case "ACCORDI_CMPNYDESIGNAT":	// Field (DB)
						values = new Accordi_ViewModel(UserContext.Current).GetDependant_AccordiTableCmpnyDesignat(Selected);
						break;
					case "ACCORDI_PESS1NAME____":	// Field (DB)
						values = new Accordi_ViewModel(UserContext.Current).GetDependant_AccordiTablePess1Name(Selected);
						break;
					case "EQUIP___CMPNYDESIGNAT":	// Field (DB)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTableCmpnyDesignat(Selected);
						break;
					case "EQUIP___PESS1NAME____":	// Field (DB)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTablePess1Name(Selected);
						break;
					case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTableTpequTipoequi(Selected);
						break;
					case "EQUIP___WAREHWAREHDES":	// Field (DB)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTableWarehWarehdes(Selected);
						break;
					case "EQUIP___ITEM_ITEMDES_":	// Field (DB)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTableItemItemdes(Selected);
						break;
					case "EQUIP___ROOM1ROOMNR__":	// Field (F1)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTableRoom1Roomnr(Selected);
						break;
					case "EQUIP___DECOMDECOMNR_":	// Field (DB)
						values = new Equip_ViewModel(UserContext.Current).GetDependant_EquipTableDecomDecomnr(Selected);
						break;
					case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
						values = new Groupbx_ViewModel(UserContext.Current).GetDependant_GroupbxTableTpequTipoequi(Selected);
						break;
					case "GROUPBX_WAREHWAREHDES":	// Field (DB)
						values = new Groupbx_ViewModel(UserContext.Current).GetDependant_GroupbxTableWarehWarehdes(Selected);
						break;
					case "GROUPBX_ITEM_ITEMDES_":	// Field (DB)
						values = new Groupbx_ViewModel(UserContext.Current).GetDependant_GroupbxTableItemItemdes(Selected);
						break;
					case "GROUPBX_ROOM1ROOMNR__":	// Field (F1)
						values = new Groupbx_ViewModel(UserContext.Current).GetDependant_GroupbxTableRoom1Roomnr(Selected);
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
		/// Recalculate formulas of the "Accordi" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Accordi([FromBody]Accordi_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FACCORDI"),
				(model) => form_data.MapToModel(model as Models.Equip)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Equdocum" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Equdocum([FromBody]Equdocum_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FEQUDOCUM"),
				(model) => form_data.MapToModel(model as Models.Equip)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Equip" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Equip([FromBody]Equip_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FEQUIP"),
				(model) => form_data.MapToModel(model as Models.Equip)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Fullcale" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Fullcale([FromBody]Fullcale_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FFULLCALE"),
				(model) => form_data.MapToModel(model as Models.Equip)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Gmaps" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Gmaps([FromBody]Gmaps_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FGMAPS"),
				(model) => form_data.MapToModel(model as Models.Equip)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Groupbx" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Groupbx([FromBody]Groupbx_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FGROUPBX"),
				(model) => form_data.MapToModel(model as Models.Equip)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Timequip" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Timequip([FromBody]Timequip_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FTIMEQUIP"),
				(model) => form_data.MapToModel(model as Models.Equip)
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
					case "ACCORDI_PESS1NAME____":	// Field (DB)
						{
							var model = new Accordi_ViewModel(UserContext.Current);
							var permission = model.CheckPermissions(FormMode.Show);
							if (permission.Status.Equals(CSGenio.framework.Status.E))
								return Json(new { Success = false, Message = permission.Message });

							model.LoadTree_TablePess1Name(requestValues);
							return JsonOK(new { Tree = model.Tree_TablePess1Name });
						}
					case "EQUIP___PESS1NAME____":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current);
							var permission = model.CheckPermissions(FormMode.Show);
							if (permission.Status.Equals(CSGenio.framework.Status.E))
								return Json(new { Success = false, Message = permission.Message });

							model.LoadTree_TablePess1Name(requestValues);
							return JsonOK(new { Tree = model.Tree_TablePess1Name });
						}
					case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current);
							var permission = model.CheckPermissions(FormMode.Show);
							if (permission.Status.Equals(CSGenio.framework.Status.E))
								return Json(new { Success = false, Message = permission.Message });

							model.LoadTree_TableTpequTipoequi(requestValues);
							return JsonOK(new { Tree = model.Tree_TableTpequTipoequi });
						}
					case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
						{
							var model = new Groupbx_ViewModel(UserContext.Current);
							var permission = model.CheckPermissions(FormMode.Show);
							if (permission.Status.Equals(CSGenio.framework.Status.E))
								return Json(new { Success = false, Message = permission.Message });

							model.LoadTree_TableTpequTipoequi(requestValues);
							return JsonOK(new { Tree = model.Tree_TableTpequTipoequi });
						}
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
