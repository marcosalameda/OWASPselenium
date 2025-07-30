using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Indoc
{
	public class Dentr_ValEntradas_ViewModel : MenuListViewModel<Models.Ldent>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Dentr_ValEntradas_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "ldent";

		/// <inheritdoc/>
		public override string Uuid => "Dentr_ValEntradas";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string IndocValCoddentr { get; set; }

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAldent.FldCoddentr, this.IndocValCoddentr ?? Navigation.GetStrValue("indoc"));

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				List<string> aboveTables = new List<string>();
				User u = m_userContext.User;
				var area = new CSGenioAldent(u);
				relations = CSGenio.persistence.QueryUtils.tablesRelationships(aboveTables.Distinct().ToList(), area);
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS DENTR_PSEUDENTRADAS]/

			return crs;
		}

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Dentr_ValEntradas_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Dentr_ValEntradas_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Dentr_ValEntradas_ViewModel(UserContext userContext) : base(userContext)
		{
			IndocValCoddentr = userContext.CurrentNavigation.CurrentLevel.GetEntry("indoc")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Dentr_ValEntradas_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Dentr_ValEntradas_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAldent.FldLine, FieldType.NUMERIC, Resources.Resources.LINE27983, 5, 1, true),
				new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXT, Resources.Resources.WAREHOUSE51864, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXT, Resources.Resources.ARTICLE60065, 30, 0, true),
				new Exports.QColumn(CSGenioAldent.FldQtdentra, FieldType.NUMERIC, Resources.Resources.QTD_ENTRY35144, 10, 0, true),
				new Exports.QColumn(CSGenioAldent.FldDhentra, FieldType.DATETIME, Resources.Resources.INSTANT_ENTRANCE27379, 16, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAldent> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAldent> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfiguration);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();



			if (Menu == null)
				Menu = new TablePartial<Dentr_ValEntradas_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			if (this.IndocValCoddentr != null)
				crs.Equal(CSGenioAldent.FldCoddentr, this.IndocValCoddentr);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Ldent.AddEPH<CSGenioAldent>(ref u, crs, "IBL_DENTR___PSEUDENTRADAS");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAldent.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LDENT", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAldent.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_ldent");
				Navigation.DestroyEntry("QMVC_POS_RECORD_ldent");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Ldent.AddEPH<CSGenioAldent>(ref u, null, "IBL_DENTR___PSEUDENTRADAS"));
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
			ListingMVC<CSGenioAldent> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAldent> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAldent> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAldent> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<Dentr_ValEntradas_RowViewModel>();

				CriteriaSet dentr___pseudentradasConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("LDENT.LINE", new OrderedDictionary());
				allSortOrders["LDENT.LINE"].Add("LDENT.LINE", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "ldent", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAldent.FldLine), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAldent.FldCodldent, CSGenioAldent.FldZzstate, CSGenioAldent.FldLine, CSGenioAldent.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAldent.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAldent.FldQtdentra, CSGenioAldent.FldDhentra };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("ldent", "line");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAldent model_limit_area = new CSGenioAldent(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_DENTR___PSEUDENTRADAS");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(dentr___pseudentradasConds);
				dentr___pseudentradasConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ DENTR_PSEUDENTRADAS]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAldent>(m_userContext, false, dentr___pseudentradasConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_DENTR___PSEUDENTRADAS", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP DENTR_PSEUDENTRADAS]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST DENTR_PSEUDENTRADAS]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_ldent");
					Navigation.DestroyEntry("QMVC_POS_RECORD_ldent");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAldent.GetInformation(), QMVC_POS_RECORD, sorts, dentr___pseudentradasConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAldent> listing = Models.ModelBase.Where<CSGenioAldent>(m_userContext, distinct, dentr___pseudentradasConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_DENTR___PSEUDENTRADAS", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapDentr_ValEntradas(listing);

					Menu.Identifier = "IBL_DENTR___PSEUDENTRADAS";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_DENTR___PSEUDENTRADAS";

					Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

					// Set table totalizers
					if (listing.Totalizers != null && listing.Totalizers.Count > 0)
						Menu.SetTotalizers(listing.Totalizers);
				}

				// Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;

				// Load the user table configuration names and default name
				LoadUserTableConfigNameProperties();
		}

		private List<Dentr_ValEntradas_RowViewModel> MapDentr_ValEntradas(ListingMVC<CSGenioAldent> Qlisting)
		{
			List<Dentr_ValEntradas_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapDentr_ValEntradas(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAldent row
		/// to a Dentr_ValEntradas_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Dentr_ValEntradas_RowViewModel MapDentr_ValEntradas(CSGenioAldent row)
		{
			var model = new Dentr_ValEntradas_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "ldent":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "wareh":
						model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "item":
						model.Item.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

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
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAldent> listing)
		{
		}

		public void Reorder(string id, string position)
		{
			User u = m_userContext.User;
			var sp = m_userContext.PersistentSupport;
			sp.openConnection();
			var row = CSGenioAldent.search(sp, id, u);
			row.Reorder_Line(sp, int.Parse(position), baseConditions, relations);
			sp.closeConnection();
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Ldent m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Ldent m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM DENTR_VALENTRADAS]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Ldent", "Ldent.ValCodldent", "Ldent.ValZzstate", "Ldent.ValLine", "Wareh", "Wareh.ValWarehdes", "Item", "Item.ValItemdes", "Ldent.ValQtdentra", "Ldent.ValDhentra", "Ldent.ValCoddentr", "Ldent.ValCoditem", "Ldent.ValCodwareh"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValLine", CSGenioAldent.FldLine, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string)),
			new TableSearchColumn("Item_ValItemdes", CSGenioAitem.FldItemdes, typeof(string)),
			new TableSearchColumn("ValQtdentra", CSGenioAldent.FldQtdentra, typeof(decimal?)),
			new TableSearchColumn("ValDhentra", CSGenioAldent.FldDhentra, typeof(DateTime?)),
		];
	}
}
