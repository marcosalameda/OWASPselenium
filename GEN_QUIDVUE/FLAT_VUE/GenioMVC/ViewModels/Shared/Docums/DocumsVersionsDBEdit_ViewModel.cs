using System.Collections.Specialized;
using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels
{
	public class DocumsVersionsDBEdit_ViewModel : ViewModelBase
	{
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Docums> Menu { get; set; }

		public string DocumId { get; set; }

		public string Ticket { get; set; }

		public string TableName { get; set; }

		public string FieldName { get; set; }

		public bool Onlyshow { get; set; }

		public DocumsVersionsDBEdit_ViewModel(UserContext userContext, string ticket, string documid, string tableName, string fieldName, bool onlyshow) : base(userContext)
		{
			this.Ticket = ticket;
			this.DocumId = documid;
			this.TableName = tableName;
			this.FieldName = fieldName;
			this.Onlyshow = onlyshow;
		}

		public void Load(int numberListItems, NameValueCollection requestValues)
		{
			Menu = new TablePartial<GenioMVC.Models.Docums>();
			CriteriaSet filters = CriteriaSet.And();

			Menu.SetFilters(bool.Parse(requestValues["_DocumsVersionsDBEdit_tableFilters"] ?? "false"), false);

			CriteriaSet search_filters = ProcessSearchFilters(Menu, GetSearchColumns(), requestValues, "_DocumsVersionsDBEdit_");

			filters.SubSets.Add(search_filters);

			var currentModule = m_userContext.User.CurrentModule;
			if (!m_userContext.User.IsAdmin(currentModule))
				filters.Equal(CSGenioAdocums.FldZzstate, 0);

			filters.Equal(CSGenioAdocums.FldDocumid, this.DocumId);

			var pageNumber = !String.IsNullOrEmpty(requestValues["p_DocumsVersionsDBEdit"]) ? int.Parse(requestValues["p_DocumsVersionsDBEdit"]) : 1;
			var columnSort = GetRequestSort(this.Menu, "s_DocumsVersionsDBEdit", "d_DocumsVersionsDBEdit", requestValues, "docums");

			List<ColumnSort> sorts = new List<ColumnSort>();
			if (columnSort != null)
				sorts.Add(columnSort);
			else
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAdocums.FldDatacria), SortOrder.Descending));

			FieldRef[] fields = new FieldRef[] { CSGenioAdocums.FldCoddocums, CSGenioAdocums.FldVersao, CSGenioAdocums.FldNome, CSGenioAdocums.FldTamanho, CSGenioAdocums.FldOpercria, CSGenioAdocums.FldDatacria };

			ListingMVC<CSGenioAdocums> listing = Models.ModelBase.Where<CSGenioAdocums>(m_userContext, false, filters, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts);

			User u = m_userContext.User;
			Menu.Elements = listing.RowsForViewModel<GenioMVC.Models.Docums>(x => new GenioMVC.Models.Docums(m_userContext, x));
			List<GenioMVC.Models.Docums> docums = Menu.Elements.ToList();
			docums.ForEach(x => fillDocumTicket(x, u));
			Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
		}

		private GenioMVC.Models.Docums fillDocumTicket(GenioMVC.Models.Docums model, User u)
		{
			ResourceQuery rec = new ResourceQuery(model.ValNome, "docums", "ValDocument", "ValCoddocums", model.ValCoddocums);
			model.Ticket = QResources.CreateTicketEncryptedBase64(u.Name, u.Location, rec);
			return model;
		}

		public List<TableSearchColumn> GetSearchColumns()
		{
			List<TableSearchColumn> list = new List<TableSearchColumn>();

			list.Add(new TableSearchColumn("ValVersao", CSGenioAdocums.FldVersao, typeof(String), true));
			list.Add(new TableSearchColumn("ValNome", CSGenioAdocums.FldNome, typeof(String), true));
			list.Add(new TableSearchColumn("ValTamanho", CSGenioAdocums.FldTamanho, typeof(int), true));
			list.Add(new TableSearchColumn("ValOpercria", CSGenioAdocums.FldOpercria, typeof(String), true));
			list.Add(new TableSearchColumn("ValDatacria", CSGenioAdocums.FldDatacria, typeof(String),true));

			return list;
		}
	}
}
