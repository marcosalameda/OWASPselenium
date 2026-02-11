using GenioMVC.Models;
using GenioMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Concurrent;
using System.Collections.Specialized;

namespace GenioMVC.Controllers.Home;

[Authorize]
public class Equip_emptyEmptyController(UserContextService userContext) : HomeController(userContext)
{
	[HttpPost]
	public JsonResult ReloadDBEdit([FromBody]RequestReloadDBEditModel requestModel, [FromHeader]string ReloadDBEditRequestNumber)
	{
		var Identifier = requestModel.Identifier ?? "";
		var qs = new NameValueCollection();
		qs.AddRange(Request.Query);
		// The value of the lookup search field comes in 'Values'
		if (requestModel.Values != null)
			qs.AddRange(requestModel.Values);
		IsStateReadonly = true;

		dynamic result = null;
		// Only the last reload request is accepted.
		if (!string.IsNullOrEmpty(ReloadDBEditRequestNumber))
			Response.Headers["ReloadDBEditRequestNumber"] = ReloadDBEditRequestNumber;

		try
		{
			switch (Identifier)
			{
				case "EQUIP_EMPTY__CNTRY__COUNTRY_FG":
					{
						var model = new Equip_empty_ViewModel(UserContext.Current);
						model.Load_Equip_empty__cntry__country_fg(qs);
						result = model.TableCntryCountry;
					}
					break;
				case "EQUIP_EMPTY__CMPNY__DESIGNAT_FG":
					{
						var model = new Equip_empty_ViewModel(UserContext.Current);
						model.Load_Equip_empty__cmpny__designat_fg(qs);
						result = model.TableCmpnyDesignat;
					}
					break;
				case "EQUIP_EMPTY__PESS1__NAME_FG":
					{
						var model = new Equip_empty_ViewModel(UserContext.Current);
						model.Load_Equip_empty__pess1__name_fg(qs);
						result = model.TablePess1Name;
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
			return JsonOK(new { result.List, result.Pagination.TotalRows, result.Selected, result.Value });
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
				switch (Identifier)
				{
					case "EQUIP_EMPTY__CNTRY__COUNTRY_FG":
						values = new Equip_empty_ViewModel(UserContext.Current).GetDependant_Equip_emptyTableCntryCountry(Selected);
						break;
					case "EQUIP_EMPTY__CMPNY__DESIGNAT_FG":
						values = new Equip_empty_ViewModel(UserContext.Current).GetDependant_Equip_emptyTableCmpnyDesignat(Selected);
						break;
					case "EQUIP_EMPTY__PESS1__NAME_FG":
						values = new Equip_empty_ViewModel(UserContext.Current).GetDependant_Equip_emptyTablePess1Name(Selected);
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
}