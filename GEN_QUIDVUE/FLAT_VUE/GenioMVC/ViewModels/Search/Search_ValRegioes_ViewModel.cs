using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Search
{
	public class Search_ValRegioes_ViewModel : MenuListViewModel<Models.Regio>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Search_ValRegioes_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "regio";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Search_ValRegioes";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ValCodsearch { get; set; }

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
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS SEARCH_PSEUDREGIOES]/

			return crs;
		}

		public string ValCodpais { get; set; }
		public string ValCodregia { get; set; }

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Search_ValRegioes_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Search_ValRegioes_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Search_ValRegioes_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodsearch = userContext.CurrentNavigation.CurrentLevel.GetEntry("search")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Search_ValRegioes_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Search_ValRegioes_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXT, Resources.Resources.COUNTRY64133, 30, 0, true),
				new Exports.QColumn(CSGenioAregio.FldRegiao, FieldType.TEXT, Resources.Resources.REGION12723, 30, 0, true),
				new Exports.QColumn(CSGenioApais1.FldCountry, FieldType.TEXT, Resources.Resources.COUNTRY64133, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAregio> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAregio> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

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
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			// Limits Generation

				// Limit by field
			if(!CSGenio.business.CSGenioAsearch.GetInformation().DBFields["codpais"].isEmptyValue(this.ValCodpais))
				crs.Equal(
				CSGenio.business.CSGenioAcntry.FldCodcntry,
				CSGenio.persistence.QueryUtils.ToValidDbValue(this.ValCodpais, CSGenio.business.CSGenioAcntry.GetInformation().DBFields[CSGenio.business.CSGenioAcntry.FldCodcntry.Field]));

				// Limit by field
			if(!CSGenio.business.CSGenioAsearch.GetInformation().DBFields["codregia"].isEmptyValue(this.ValCodregia))
				crs.Equal(
				CSGenio.business.CSGenioAregio.FldCodregia,
				CSGenio.persistence.QueryUtils.ToValidDbValue(this.ValCodregia, CSGenio.business.CSGenioAregio.GetInformation().DBFields[CSGenio.business.CSGenioAregio.FldCodregia.Field]));

			Menu ??= new TablePartial<Search_ValRegioes_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			if (tableConfig.FieldFilters != null)
				crs.SubSets.Add(ProcessFieldFilters(tableConfig.FieldFilters));


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Regio.AddEPH<CSGenioAregio>(ref u, crs, "IBL_SEARCH__PSEUDREGIOES_");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAregio.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("REGIO", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAregio.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_regio");
				Navigation.DestroyEntry("QMVC_POS_RECORD_regio");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Regio.AddEPH<CSGenioAregio>(ref u, null, "IBL_SEARCH__PSEUDREGIOES_"));
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
			ListingMVC<CSGenioAregio> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAregio> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAregio> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAregio> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Search_ValRegioes_RowViewModel>();

			CriteriaSet search__pseudregioes_Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "regio", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAregio.FldCodregia, CSGenioAregio.FldZzstate, CSGenioAregio.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAregio.FldRegiao, CSGenioAregio.FldCodpais1, CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("cntry", "country");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAregio model_limit_area = new CSGenioAregio(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_SEARCH__PSEUDREGIOES_");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 2 Limit(s) detected.
			// Limit origin: form 
			//Limit type: "C"
			//Current Area = "REGIO"
			//1st Area Limit: "CNTRY"
			//1st Area Field: "CODCNTRY"
			//1st Area Value: ""
			//2nd Area Limit: "SEARCH"
			//2nd Area Field: "CODPAIS"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.C;
				limit.NaoAplicaSeNulo = true;
				CSGenioAcntry model_limit_area = new CSGenioAcntry(m_userContext.User);
				string limit_field = "codcntry", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);

				CSGenioAsearch model_limit_area2 = new CSGenioAsearch(m_userContext.User);
				string limit_field2 = "codpais", limit_field_value2 = "";
				object this_limit_field2 = ValCodpais;
				Limit_Filler(ref limit, model_limit_area2, limit_field2, limit_field_value2, this_limit_field2, LimitAreaType.AreaLimitaN);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}
			// Limit origin: form 
			//Limit type: "C"
			//Current Area = "REGIO"
			//1st Area Limit: "REGIO"
			//1st Area Field: "CODREGIA"
			//1st Area Value: ""
			//2nd Area Limit: "SEARCH"
			//2nd Area Field: "CODREGIA"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.C;
				limit.NaoAplicaSeNulo = true;
				CSGenioAregio model_limit_area = new CSGenioAregio(m_userContext.User);
				string limit_field = "codregia", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);

				CSGenioAsearch model_limit_area2 = new CSGenioAsearch(m_userContext.User);
				string limit_field2 = "codregia", limit_field_value2 = "";
				object this_limit_field2 = ValCodregia;
				Limit_Filler(ref limit, model_limit_area2, limit_field2, limit_field_value2, this_limit_field2, LimitAreaType.AreaLimitaN);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(search__pseudregioes_Conds);
			search__pseudregioes_Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ SEARCH_PSEUDREGIOES]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAregio>(m_userContext, false, ref search__pseudregioes_Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_SEARCH__PSEUDREGIOES_", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP SEARCH_PSEUDREGIOES]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST SEARCH_PSEUDREGIOES]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_regio");
				Navigation.DestroyEntry("QMVC_POS_RECORD_regio");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAregio.GetInformation(), QMVC_POS_RECORD, sorts, search__pseudregioes_Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAregio> listing = Models.ModelBase.Where<CSGenioAregio>(m_userContext, distinct, search__pseudregioes_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_SEARCH__PSEUDREGIOES_", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapSearch_ValRegioes(listing);

				Menu.Identifier = "IBL_SEARCH__PSEUDREGIOES_";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_SEARCH__PSEUDREGIOES_";

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

		private List<Search_ValRegioes_RowViewModel> MapSearch_ValRegioes(ListingMVC<CSGenioAregio> Qlisting)
		{
			List<Search_ValRegioes_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSearch_ValRegioes(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAregio row
		/// to a Search_ValRegioes_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Search_ValRegioes_RowViewModel MapSearch_ValRegioes(CSGenioAregio row)
		{
			var model = new Search_ValRegioes_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "regio":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cntry":
						model.Cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pais1":
						model.Pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAregio> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Regio m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Regio m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM SEARCH_VALREGIOES]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Regio", "Regio.ValCodregia", "Regio.ValZzstate", "Cntry", "Cntry.ValCountry", "Regio.ValRegiao", "Pais1", "Pais1.ValCountry", "Regio.ValCodcntry", "Regio.ValCodpais1"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Cntry_ValCountry", CSGenioAcntry.FldCountry, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValRegiao", CSGenioAregio.FldRegiao, typeof(string), defaultSearch : true),
			new TableSearchColumn("Pais1_ValCountry", CSGenioApais1.FldCountry, typeof(string), defaultSearch : true),
		];
	}
}
