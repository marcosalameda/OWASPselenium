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
using GenioMVC.ViewModels.Equip;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		private IChatbotService _aiService;
		public EquipController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

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
			/*
				Instead of loading the entire record from the database, a record will be created in memory with the keys filled in,
					and additional fields from "Field" type limits will be mapped later.
				This allows us to reduce database queries, as we already have all the necessary information to apply the limits.
			*/
			Models.Equip row = new Models.Equip(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("equip");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

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
							var model = new Accordi_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Accordi_cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "ACCORDI_PESS1NAME____":	// Field (DB)
						{
							var model = new Accordi_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Accordi_pess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "EQUIGROUPESS1NAME____":	// Field (DB)
						{
							var model = new Equigrou_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equigroupess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "EQUIGROUTPEQUTIPOEQUI":	// Field (DB)
						{
							var model = new Equigrou_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equigroutpequtipoequi(qs);
							result = model.TableTpequTipoequi;
						}
						break;
					case "EQUIP___CMPNYDESIGNAT":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___cmpnydesignat(qs);
							result = model.TableCmpnyDesignat;
						}
						break;
					case "EQUIP___PESS1NAME____":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___pess1name____(qs);
							result = model.TablePess1Name;
						}
						break;
					case "EQUIP___TPEQUTIPOEQUI":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___tpequtipoequi(qs);
							result = model.TableTpequTipoequi;
						}
						break;
					case "EQUIP___WAREHWAREHDES":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___warehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "EQUIP___ITEM_ITEMDES_":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___item_itemdes_(qs);
							result = model.TableItemItemdes;
						}
						break;
					case "EQUIP___ROOM1ROOMNR__":	// Field (F1)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___room1roomnr__(qs);
							result = model.TableRoom1Roomnr;
						}
						break;
					case "EQUIP___DECOMDECOMNR_":	// Field (DB)
						{
							var model = new Equip_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Equip___decomdecomnr_(qs);
							result = model.TableDecomDecomnr;
						}
						break;
					case "GROUPBX_TPEQUTIPOEQUI":	// Field (DB)
						{
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_tpequtipoequi(qs);
							result = model.TableTpequTipoequi;
						}
						break;
					case "GROUPBX_WAREHWAREHDES":	// Field (DB)
						{
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_warehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "GROUPBX_ITEM_ITEMDES_":	// Field (DB)
						{
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_item_itemdes_(qs);
							result = model.TableItemItemdes;
						}
						break;
					case "GROUPBX_ROOM1ROOMNR__":	// Field (F1)
						{
							var model = new Groupbx_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Groupbx_room1roomnr__(qs);
							result = model.TableRoom1Roomnr;
						}
						break;
					case "WID_IEQUTPEQUTIPOEQUI":	// Field (DB)
						{
							var model = new Wid_iequ_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Wid_iequtpequtipoequi(qs);
							result = model.TableTpequTipoequi;
						}
						break;
					case "WID_IEQUWAREHWAREHDES":	// Field (DB)
						{
							var model = new Wid_iequ_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Wid_iequwarehwarehdes(qs);
							result = model.TableWarehWarehdes;
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
					case "ACCORDI_CMPNYDESIGNAT":	// Field (DB)
						values = new Accordi_ViewModel(UserContext.Current).GetDependant_AccordiTableCmpnyDesignat(Selected);
						break;
					case "ACCORDI_PESS1NAME____":	// Field (DB)
						values = new Accordi_ViewModel(UserContext.Current).GetDependant_AccordiTablePess1Name(Selected);
						break;
					case "EQUIGROUPESS1NAME____":	// Field (DB)
						values = new Equigrou_ViewModel(UserContext.Current).GetDependant_EquigrouTablePess1Name(Selected);
						break;
					case "EQUIGROUTPEQUTIPOEQUI":	// Field (DB)
						values = new Equigrou_ViewModel(UserContext.Current).GetDependant_EquigrouTableTpequTipoequi(Selected);
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
					case "WID_IEQUTPEQUTIPOEQUI":	// Field (DB)
						values = new Wid_iequ_ViewModel(UserContext.Current).GetDependant_Wid_iequTableTpequTipoequi(Selected);
						break;
					case "WID_IEQUWAREHWAREHDES":	// Field (DB)
						values = new Wid_iequ_ViewModel(UserContext.Current).GetDependant_Wid_iequTableWarehWarehdes(Selected);
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
		/// Recalculate formulas of the "Accordi" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Accordi([FromBody]Accordi_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FACCORDI"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Equdocum" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Equdocum([FromBody]Equdocum_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FEQUDOCUM"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Equigrou" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Equigrou([FromBody]Equigrou_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FEQUIGROU"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Equip" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Equip([FromBody]Equip_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FEQUIP"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Fullcale" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Fullcale([FromBody]Fullcale_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FFULLCALE"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Gmaps" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Gmaps([FromBody]Gmaps_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FGMAPS"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Groupbx" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Groupbx([FromBody]Groupbx_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FGROUPBX"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Timequip" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Timequip([FromBody]Timequip_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FTIMEQUIP"),
				(model) => formData.MapToModel(model as Models.Equip)
			);
		}



		/// <summary>
		/// Recalculate formulas of the "Wid_iequ" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Wid_iequ([FromBody]Wid_iequ_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "equip",
				(primaryKey) => Models.Equip.Find(primaryKey, UserContext.Current, "FWID_IEQU"),
				(model) => formData.MapToModel(model as Models.Equip)
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

		/// <summary>
		/// Gets the necessary tickets to interact with the given document
		/// </summary>
		/// <param name="requestModel">The request model with the table, field and the primary key of the record</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetDocumsTickets([FromBody] RequestDocumGetTicketsModel requestModel)
		{
			return base.GetDocumsTickets("EQUIP", requestModel.FieldName, requestModel.KeyValue);
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
		/// Stores a new document in the Docums table
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFile([FromForm] RequestDocumsCreateModel requestModel)
		{
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version);
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
