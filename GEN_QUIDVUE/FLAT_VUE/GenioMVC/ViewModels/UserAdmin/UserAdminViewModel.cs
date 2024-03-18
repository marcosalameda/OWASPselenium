using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels.Psw;
using GenioServer.security;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.UserAdmin
{
	public class UserAdminViewModel : ViewModelBase
	{
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Psw> Menu { get; set; }

		public UserAdminViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ADMINISTRATION;
		}

		public void LoadToExport(out ListingMVC<CSGenioApsw> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApsw.FldNome, FieldType.TEXTO, Resources.Resources.UTILIZADORES39761, 20, 0, true),
			};

			Load(-1, requestValues, ajaxRequest, true, ref listing, ref conditions);
		}

		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			ListingMVC<CSGenioApsw> listing = null;
			CriteriaSet conditions = null;
			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApsw> Qlisting, ref CriteriaSet conditions)
		{
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Index", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Index"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Index");

			Menu = new TablePartial<GenioMVC.Models.Psw>();
			CriteriaSet filters = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["Index_tableFilters"] ?? "false"), false);

			CriteriaSet search_filters = ProcessSearchFilters(Menu, GetSearchColumns(), requestValues, "Index_");
			filters.SubSets.Add(search_filters);

			CriteriaSet subfilters = CriteriaSet.Or();

			filters.SubSets.Add(subfilters);

			if (!m_userContext.User.IsAdmin(m_userContext.User.CurrentModule))
				filters.Equal(CSGenioApsw.FldZzstate, 0);

			var pageNumber = !String.IsNullOrEmpty(requestValues["pIndex"]) ? int.Parse(requestValues["pIndex"]) : 1;
			var columnSort = GetRequestSort(this.Menu, "sIndex", "dIndex", requestValues, "psw");

			List<ColumnSort> sorts = new List<ColumnSort>();
			if (columnSort != null)
				sorts.Add(columnSort);
			else
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApsw.FldNome), SortOrder.Ascending));

			FieldRef[] fields = new FieldRef[] { CSGenioApsw.FldCodpsw, CSGenioApsw.FldZzstate, CSGenioApsw.FldNome };

			if (isToExport)
			{
				User u = m_userContext.User;

				//EPH
				filters = Models.Psw.AddEPH<CSGenioApsw>(ref u, filters, "Index");
				ColumnSort sortPk = new ColumnSort(new ColumnReference(CSGenioApsw.FldCodpsw), SortOrder.Ascending);
				if (sorts != null && !sorts.Exists(x => x == sortPk))
					sorts.Add(sortPk);

				Qlisting = new ListingMVC<CSGenioApsw>(fields, sorts, (pageNumber - 1) * numberListItems, numberListItems, false, u, false);
				conditions = filters;
				this.Navigation.SetValue("CriteriaSet_" + Qlisting.identifier, filters);
				return;
			}

			if (tableReload)
			{
				ListingMVC<CSGenioApsw> listing = Models.ModelBase.Where<CSGenioApsw>(m_userContext, false, filters, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "Index");
				this.Navigation.SetValue("CriteriaSet_" + listing.identifier, filters);
				Menu.Elements = listing.RowsForViewModel(x => new Models.Psw(m_userContext));

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}
		}

		public List<TableSearchColumn> GetSearchColumns()
		{
			List<TableSearchColumn> list = new List<TableSearchColumn>();

			list.Add(new TableSearchColumn("ValNome", CSGenioApsw.FldNome, typeof(String), true));
			return list;
		}
	}
}
