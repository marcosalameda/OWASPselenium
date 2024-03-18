using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Facil
{
	public class Facil_FactyValType_ViewModel : ListViewModel
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GenioMVC.Models.Facty> Menu { get; set; }

		/// <inheritdoc/>
		public override string TableAlias { get => "facty"; }

		/// <inheritdoc/>
		public override string Uuid { get => "Facil_FactyValType"; }

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		public string ValCodfacil { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				return conds;
			}
		}

		/// <inheritdoc/>
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}
		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Facil_FactyValType_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Facil_FactyValType_ViewModel(UserContext userContext) : base(userContext)
		{
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAfacty.FldType, FieldType.TEXTO, Resources.Resources.FACILITY_TYPE44577, 25, 0, true),
				new Exports.QColumn(CSGenioAfacty.FldLayrname, FieldType.TEXTO, Resources.Resources.LAYER_NAME49545, 30, 0, true),
				new Exports.QColumn(CSGenioAfacty.FldIconurl, FieldType.TEXTO, Resources.Resources.ICON41974, 30, 0, true),
				new Exports.QColumn(CSGenioAfacty.FldShadowur, FieldType.TEXTO, Resources.Resources.SHADOW_URL57805, 30, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldIconancx, FieldType.NUMERO, Resources.Resources.ICON_ANCHOR__X_AXIS_18664, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldIconancy, FieldType.NUMERO, Resources.Resources.ICON_ANCHOR__Y_AXIS_63725, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldIconheig, FieldType.NUMERO, Resources.Resources.ICON_HEIGHT61896, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldIconwid, FieldType.NUMERO, Resources.Resources.ICON_WIDTH02295, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldPopupanx, FieldType.NUMERO, Resources.Resources.POPUP_ANCHOR__X_AXIS15060, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldPopupany, FieldType.NUMERO, Resources.Resources.POPUP_ANCHOR__Y_AXIS64670, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldShadowax, FieldType.NUMERO, Resources.Resources.SHADOW_ANCHOR__X_AXI31230, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldShadoway, FieldType.NUMERO, Resources.Resources.SHADOW_ANCHOR__Y_AXI51495, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldShadowhe, FieldType.NUMERO, Resources.Resources.SHADOW_HEIGHT64343, 3, 0, false),
				new Exports.QColumn(CSGenioAfacty.FldShadowwi, FieldType.NUMERO, Resources.Resources.SHADOW_WIDTH01769, 3, 0, false),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAfacty> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetColumnsToExport(ajaxRequest);
			Load(-1, requestValues, ajaxRequest, true, ref listing, ref conditions);

			//user config listing:
			if (ajaxRequest && userColumns!=null)
			{
				List<Exports.QColumn> current_List = new List<Exports.QColumn>();
				foreach (CSGenioAlstcol column in userColumns)
				{
					//check if theres a match in existing list columns
					string areabase = column.ValTabela.ToLower() != "facty" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
					Exports.QColumn matching_column = columns.Where(x => x.BaseArea == column.ValTabela && areabase + "Val" + x.FieldName.First().ToString().ToUpper() + x.FieldName.Substring(1).ToLower() == column.ValCampo && column.ValVisivel==1).FirstOrDefault();
					if (matching_column != null)
						current_List.Add(matching_column);
				}
				columns = current_List;
			}
		}

		/// <summary>
		/// Builds the list CriteriaSet with all the limits, filters and conditions
		/// </summary>
		/// <param name="requestValues">Table filters</param>
		/// <param name="tableReload">[Quick fix] Indicates whether the data list should be loaded. If set to false within the method, it signals that the data list should not display rows due to unmet mandatory limits.</param>
		/// <param name="crs">Pass a CriteriaSet by reference to be modified</param>
		/// <param name="isToExport">If the  table is to be exported</param>
		public CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();



			if (Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Facty>();
			Menu.SetFilters(bool.Parse(requestValues["Facil_FactyValType_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("FACTY.TYPE", new OrderedDictionary());
					allSortOrders["FACTY.TYPE"].Add("FACTY.TYPE", "A");


			int numberListItems = 0; //The value of this doesnt really matter
			LoadUserTableConfig(requestValues, allSortOrders, "Facil_FactyValType", ref numberListItems);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Facil_FactyValType_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Facty.AddEPH<CSGenioAfacty>(ref u, crs, "IBL_FACIL___FACTYTYPE____");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfacty.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfacty.FldZzstate), CriteriaOperator.Equal, 0));


			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_facty"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Facty.AddEPH<CSGenioAfacty>(ref u, null, "IBL_FACIL___FACTYTYPE____"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAfacty> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfacty> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Facil_FactyValType", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Facil_FactyValType"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Facil_FactyValType");

			User u = m_userContext.User;
			Menu = new TablePartial<GenioMVC.Models.Facty>();

			CriteriaSet facil___factytype____Conds = CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["Facil_FactyValType_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("FACTY.TYPE", new OrderedDictionary());
					allSortOrders["FACTY.TYPE"].Add("FACTY.TYPE", "A");


			LoadUserTableConfig(requestValues, allSortOrders, "Facil_FactyValType", ref numberListItems);



			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pFacil_FactyValType"])) ? int.Parse(requestValues["pFacil_FactyValType"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sFacil_FactyValType", "dFacil_FactyValType", requestValues, "facty", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacty.FldType), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldZzstate, CSGenioAfacty.FldType, CSGenioAfacty.FldLayrname, CSGenioAfacty.FldIconurl, CSGenioAfacty.FldShadowur, CSGenioAfacty.FldIconancx, CSGenioAfacty.FldIconancy, CSGenioAfacty.FldIconheig, CSGenioAfacty.FldIconwid, CSGenioAfacty.FldPopupanx, CSGenioAfacty.FldPopupany, CSGenioAfacty.FldShadowax, CSGenioAfacty.FldShadoway, CSGenioAfacty.FldShadowhe, CSGenioAfacty.FldShadowwi };


			//columns by users list (TemplateDBEditViewModel)
			userColumns = UserUiSettings.Load(m_userContext.PersistentSupport, Uuid, m_userContext.User).userColumns;
			FieldRef firstVisibleColumn = null;

			if (sorts == null)
				if (userColumns != null)
				{
					CSGenioAlstcol col = userColumns.FirstOrDefault(x => x.ValVisivel == 1);

					if (col != null)
					{
						string table = col.ValTabela.ToLower();
						string field = col.ValCampo.ToLower(); //may contain Table.ValField
						if (field.Contains("."))
						{
							field = field.Substring(table.Length + 4); //remove table name and .Val from ValCampo data. i.e: "Pesso.ValNome", pesso lenght will remove "Pesso" and then +4 for the fixed ".Val"
						}
						else
						{
							field = field.Substring(3); //remove table Val from ValCampo data. i.e: "ValNome", Substring(3) will remove "Val"
						}

						firstVisibleColumn = new FieldRef(table, field);
					}
				}
				else
					firstVisibleColumn = new FieldRef("facty", "type");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(facil___factytype____Conds);
			facil___factytype____Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ FACIL_FACTYTYPE]/

			if (isToExport)
			{
				if (!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfacty>(m_userContext, false, facil___factytype____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_FACIL___FACTYTYPE____", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP FACIL_FACTYTYPE]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST FACIL_FACTYTYPE]/

				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_facty"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAfacty.GetInformation(), QMVC_POS_RECORD, sorts, facil___factytype____Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAfacty> listing = Models.ModelBase.Where<CSGenioAfacty>(m_userContext, false, facil___factytype____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_FACIL___FACTYTYPE____", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapFacil_FactyValType(listing);

				Menu.Identifier = "IBL_FACIL___FACTYTYPE____";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_FACIL___FACTYTYPE____";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

		private List<Models.Facty> MapFacil_FactyValType(ListingMVC<CSGenioAfacty> Qlisting)
		{
			var Elements = new List<Models.Facty>();
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapFacil_FactyValType(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAfacty row
		/// to a Models.Facty object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Models.Facty MapFacil_FactyValType(CSGenioAfacty row)
		{
			var model = new Models.Facty(m_userContext, true, _fieldsToSerialize);
			if (row == null) return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "facty":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}


		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows.</param>
		private void SetDocumentFields(ListingMVC<CSGenioAfacty> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioAfacty row in listing.Rows)
			{
			}
		}

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FACIL_FACTYVALTYPE]/
		#endregion

		private static readonly string[] _fieldsToSerialize =
		{
			"Facty", "Facty.ValCodfacty", "Facty.ValZzstate", "Facty.ValType", "Facty.ValLayrname", "Facty.ValIconurl", "Facty.ValShadowur", "Facty.ValIconancx", "Facty.ValIconancy", "Facty.ValIconheig", "Facty.ValIconwid", "Facty.ValPopupanx", "Facty.ValPopupany", "Facty.ValShadowax", "Facty.ValShadoway", "Facty.ValShadowhe", "Facty.ValShadowwi"
		};

		private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
		{
			new TableSearchColumn("ValType", CSGenioAfacty.FldType, typeof(string)),
			new TableSearchColumn("ValLayrname", CSGenioAfacty.FldLayrname, typeof(string)),
			new TableSearchColumn("ValIconurl", CSGenioAfacty.FldIconurl, typeof(string)),
			new TableSearchColumn("ValShadowur", CSGenioAfacty.FldShadowur, typeof(string), visible : false),
			new TableSearchColumn("ValIconancx", CSGenioAfacty.FldIconancx, typeof(decimal?), visible : false),
			new TableSearchColumn("ValIconancy", CSGenioAfacty.FldIconancy, typeof(decimal?), visible : false),
			new TableSearchColumn("ValIconheig", CSGenioAfacty.FldIconheig, typeof(decimal?), visible : false),
			new TableSearchColumn("ValIconwid", CSGenioAfacty.FldIconwid, typeof(decimal?), visible : false),
			new TableSearchColumn("ValPopupanx", CSGenioAfacty.FldPopupanx, typeof(decimal?), visible : false),
			new TableSearchColumn("ValPopupany", CSGenioAfacty.FldPopupany, typeof(decimal?), visible : false),
			new TableSearchColumn("ValShadowax", CSGenioAfacty.FldShadowax, typeof(decimal?), visible : false),
			new TableSearchColumn("ValShadoway", CSGenioAfacty.FldShadoway, typeof(decimal?), visible : false),
			new TableSearchColumn("ValShadowhe", CSGenioAfacty.FldShadowhe, typeof(decimal?), visible : false),
			new TableSearchColumn("ValShadowwi", CSGenioAfacty.FldShadowwi, typeof(decimal?), visible : false)
		};
	}
}
