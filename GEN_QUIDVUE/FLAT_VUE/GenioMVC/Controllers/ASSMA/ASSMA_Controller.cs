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
using GenioMVC.ViewModels.Assma;
using GenioServer.business;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSMA]/

namespace GenioMVC.Controllers
{
	public partial class AssmaController : ControllerBase
	{
		public AssmaController(UserContextService userContext): base(userContext) { }
// USE /[MANUAL GQT CONTROLLER_NAVIGATION ASSMA]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioAassma>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL GQT MANUAL_CONTROLLER ASSMA]/


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
			Models.Assma row = null;

			try
			{
				row = Models.Assma.Find(Navigation.GetStrValue("assma"), UserContext.Current);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("ReloadDBEdit - " + Identifier + " Not found Model assma");
			}

			if (row == null)
			{
				row = new Models.Assma(UserContext.Current);
				row.klass.QPrimaryKey = Navigation.GetStrValue("assma");
			}

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "ASSMA___ASSETNAME____":	// Field (DB)
						{
							row.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);
							var model = new Assma_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Assma___assetname____(qs);
							result = model.TableAssetName;
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
					case "ASSMA___ASSETNAME____":	// Field (DB)
						values = new Assma_ViewModel(UserContext.Current).GetDependant_AssmaTableAssetName(Selected);
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
		/// Recalculate formulas of the "Assma" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="form_data">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Assma([FromBody]Assma_ViewModel form_data)
		{
			return GenericRecalculateFormulas(form_data, "assma",
				(primaryKey) => Models.Assma.Find(primaryKey, UserContext.Current, "FASSMA"),
				(model) => form_data.MapToModel(model as Models.Assma)
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
