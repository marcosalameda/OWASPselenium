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
using GenioMVC.ViewModels.Item;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		public ItemController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION ITEM]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAitem>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER ITEM]/


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
			Models.Item row = null;

			try
			{
				row = Models.Item.Find(Navigation.GetStrValue("item"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model item");
			}

			if (row == null)
			{
				row = new Models.Item(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("item");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "ARTIG___WAREHWAREHDES":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artig_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artig___warehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "ARTIG___GITEMITEMDES_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artig_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artig___gitemitemdes_(qs);
							result = model.TableGitemItemdes;
						}
						break;
					case "ARTIGEXTWAREHWAREHDES":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artigext_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artigextwarehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "ARTIGEXTGITEMITEMDES_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artigext_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artigextgitemitemdes_(qs);
							result = model.TableGitemItemdes;
						}
						break;
					case "ARTIGINVGITEMITEMDES_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artiginv_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artiginvgitemitemdes_(qs);
							result = model.TableGitemItemdes;
						}
						break;
					case "ARTIGINVWAREHWAREHDES":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artiginv_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artiginvwarehwarehdes(qs);
							result = model.TableWarehWarehdes;
						}
						break;
					case "ARTIGVALGITEMITEMDES_":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artigval_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artigvalgitemitemdes_(qs);
							result = model.TableGitemItemdes;
						}
						break;
					case "ARTIGVALWAREHWAREHDES":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Artigval_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Artigvalwarehwarehdes(qs);
							result = model.TableWarehWarehdes;
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
					case "ARTIG___WAREHWAREHDES":	// Field (DB)
						values = new Artig_ViewModel(UserContext.Current).GetDependant_ArtigTableWarehWarehdes(Selected);
						break;
					case "ARTIG___GITEMITEMDES_":	// Field (DB)
						values = new Artig_ViewModel(UserContext.Current).GetDependant_ArtigTableGitemItemdes(Selected);
						break;
					case "ARTIGEXTWAREHWAREHDES":	// Field (DB)
						values = new Artigext_ViewModel(UserContext.Current).GetDependant_ArtigextTableWarehWarehdes(Selected);
						break;
					case "ARTIGEXTGITEMITEMDES_":	// Field (DB)
						values = new Artigext_ViewModel(UserContext.Current).GetDependant_ArtigextTableGitemItemdes(Selected);
						break;
					case "ARTIGINVGITEMITEMDES_":	// Field (DB)
						values = new Artiginv_ViewModel(UserContext.Current).GetDependant_ArtiginvTableGitemItemdes(Selected);
						break;
					case "ARTIGINVWAREHWAREHDES":	// Field (DB)
						values = new Artiginv_ViewModel(UserContext.Current).GetDependant_ArtiginvTableWarehWarehdes(Selected);
						break;
					case "ARTIGVALGITEMITEMDES_":	// Field (DB)
						values = new Artigval_ViewModel(UserContext.Current).GetDependant_ArtigvalTableGitemItemdes(Selected);
						break;
					case "ARTIGVALWAREHWAREHDES":	// Field (DB)
						values = new Artigval_ViewModel(UserContext.Current).GetDependant_ArtigvalTableWarehWarehdes(Selected);
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
		/// Recalculate formulas of the "Artig" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Artig([FromBody]Artig_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "item",
				(primaryKey) => Models.Item.Find(primaryKey, UserContext.Current, "FARTIG"),
				(model) => form_data.MapToModel(model as Models.Item)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Artigext" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Artigext([FromBody]Artigext_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "item",
				(primaryKey) => Models.Item.Find(primaryKey, UserContext.Current, "FARTIGEXT"),
				(model) => form_data.MapToModel(model as Models.Item)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Artiginv" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Artiginv([FromBody]Artiginv_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "item",
				(primaryKey) => Models.Item.Find(primaryKey, UserContext.Current, "FARTIGINV"),
				(model) => form_data.MapToModel(model as Models.Item)
			);
		}

		/// <summary>
		/// Recalculate formulas of the "Artigval" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Artigval([FromBody]Artigval_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "item",
				(primaryKey) => Models.Item.Find(primaryKey, UserContext.Current, "FARTIGVAL"),
				(model) => form_data.MapToModel(model as Models.Item)
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

		public ActionResult GetDocumsTickets([FromBody]RequestDocumGetTicketsModel requestModel)
		{
			return base.GetDocumsTickets(requestModel.TableName, requestModel.FieldName, requestModel.KeyValue);
		}

		public ActionResult GetDocumsVersionsDBEdit([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetDocumsVersionsDBEdit(requestModel.Ticket);
		}

		public ActionResult GetFileProperties([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetFileProperties(requestModel.Ticket);
		}

		public ActionResult SubmitVersion([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.SubmitVersion(requestModel.Ticket);
		}

		public ActionResult CheckoutDocum([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.CheckoutDocum(requestModel.Ticket);
		}

		public ActionResult DeleteFile([FromBody]RequestDocumDeleteModel requestModel)
		{
			return base.DeleteFile(requestModel.Ticket, requestModel.Action);
		}

		public new ActionResult SetFile([FromForm] string ticket, [FromForm] ControllerBase.VersionSubmitAction mode = VersionSubmitAction.Insert, [FromForm] string version = "1")
		{
			return base.SetFile(ticket, mode, version);
		}

		public ActionResult GetFile([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetFile(requestModel.Ticket, requestModel.ViewType);
		}

		public ActionResult GetSpecificFile([FromBody]RequestDocumTicketsModel requestModel)
		{
			return base.GetSpecificFile(requestModel.Ticket);
		}
	}
}
