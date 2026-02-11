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

namespace GenioMVC.ViewModels.Asset
{
	public class Asset_global_filter_ValAsspa_filtred_by_param_ViewModel : MenuListViewModel<Models.Asspa>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel> Menu { get; set; }

		[JsonIgnore]
		public override TableManagementMode ViewsManagementMode => TableManagementMode.PersistMany;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "asspa";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Asset_global_filter_ValAsspa_filtred_by_param";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string AssetValCodasset { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS ASSET_GLOBAL_FILTER_PSEUDASSPA_FILTRED_BY_PARAM]/

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
		public Asset_global_filter_ValAsspa_filtred_by_param_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Asset_global_filter_ValAsspa_filtred_by_param_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Asset_global_filter_ValAsspa_filtred_by_param_ViewModel(UserContext userContext) : base(userContext)
		{
			AssetValCodasset = userContext.CurrentNavigation.CurrentLevel.GetEntry("asset")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Asset_global_filter_ValAsspa_filtred_by_param_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Asset_global_filter_ValAsspa_filtred_by_param_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAasspa.FldToshow, FieldType.TEXT, Resources.Resources.TO_SHOW13268, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldName, FieldType.TEXT, Resources.Resources.IDENTIFICATION_NAME16317, 30, 0, true),
				new Exports.QColumn(CSGenioAparam.FldParameter, FieldType.TEXT, Resources.Resources.PARAMETER41976, 30, 0, true),
				new Exports.QColumn(CSGenioAasspa.FldDatatype, FieldType.ARRAY_TEXT, Resources.Resources.DATA_TYPE47159, 1, 0, true, "DataType"),
				new Exports.QColumn(CSGenioAasspa.FldText, FieldType.TEXT, Resources.Resources.TEXT04938, 30, 0, true),
				new Exports.QColumn(CSGenioAasspa.FldQuantity, FieldType.NUMERIC, Resources.Resources.QUANTITY06415, 12, 4, true),
				new Exports.QColumn(CSGenioAasspa.FldDate, FieldType.DATE, Resources.Resources.DATE18475, 8, 0, true),
				new Exports.QColumn(CSGenioAasspa.FldDecimalplaces, FieldType.NUMERIC, Resources.Resources.DECIMAL_PLACES62575, 1, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAasspa> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAasspa> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_ValAsspa_filtred_by_param_PARAM_TYPE"))
			{
				string defaultValue = "1";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_ValAsspa_filtred_by_param_PARAM_TYPE", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_ValAsspa_filtred_by_param_PARAM_TYPE_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValAsspa_filtred_by_param_PARAM_TYPE"))
					filter_ValAsspa_filtred_by_param_PARAM_TYPE_1 = tableConfig.GroupFilters["filter_ValAsspa_filtred_by_param_PARAM_TYPE"].Contains("1");
				else if (!tableConfig.GroupFilters.ContainsKey("filter_ValAsspa_filtred_by_param_PARAM_TYPE"))
					filter_ValAsspa_filtred_by_param_PARAM_TYPE_1 = true;
				if (filter_ValAsspa_filtred_by_param_PARAM_TYPE_1)
				{

				}

				bool filter_ValAsspa_filtred_by_param_PARAM_TYPE_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValAsspa_filtred_by_param_PARAM_TYPE"))
					filter_ValAsspa_filtred_by_param_PARAM_TYPE_2 = tableConfig.GroupFilters["filter_ValAsspa_filtred_by_param_PARAM_TYPE"].Contains("2");
				if (filter_ValAsspa_filtred_by_param_PARAM_TYPE_2)
				{
					groupFilters.Equal(CSGenioAasspa.FldDatatype, "T");

				}

				bool filter_ValAsspa_filtred_by_param_PARAM_TYPE_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValAsspa_filtred_by_param_PARAM_TYPE"))
					filter_ValAsspa_filtred_by_param_PARAM_TYPE_3 = tableConfig.GroupFilters["filter_ValAsspa_filtred_by_param_PARAM_TYPE"].Contains("3");
				if (filter_ValAsspa_filtred_by_param_PARAM_TYPE_3)
				{
					groupFilters.Equal(CSGenioAasspa.FldDatatype, "N");

				}

				bool filter_ValAsspa_filtred_by_param_PARAM_TYPE_4 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_ValAsspa_filtred_by_param_PARAM_TYPE"))
					filter_ValAsspa_filtred_by_param_PARAM_TYPE_4 = tableConfig.GroupFilters["filter_ValAsspa_filtred_by_param_PARAM_TYPE"].Contains("4");
				if (filter_ValAsspa_filtred_by_param_PARAM_TYPE_4)
				{
					groupFilters.Equal(CSGenioAasspa.FldDatatype, "D");

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);

			// Form field filters
			if (tableConfig.FieldFilters != null)
				crs.SubSets.Add(ProcessFieldFilters(tableConfig.FieldFilters));

			if (this.AssetValCodasset != null)
				crs.Equal(CSGenioAasspa.FldCodasset, this.AssetValCodasset);
			else
				tableReload = false;
				

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Asspa.AddEPH<CSGenioAasspa>(ref u, crs, "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAasspa.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ASSPA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAasspa.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asspa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asspa");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Asspa.AddEPH<CSGenioAasspa>(ref u, null, "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM"));
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
			ListingMVC<CSGenioAasspa> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAasspa> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAasspa> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAasspa> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel>();

			CriteriaSet asset_global_filter__pseud__asspa_filtred_by_paramConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "asspa", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAasspa.FldCodasspa, CSGenioAasspa.FldZzstate, CSGenioAasspa.FldToshow, CSGenioAasspa.FldCodasset, CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasspa.FldCodparam, CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter, CSGenioAasspa.FldDatatype, CSGenioAasspa.FldText, CSGenioAasspa.FldQuantity, CSGenioAasspa.FldDate, CSGenioAasspa.FldDecimalplaces };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("asspa", "toshow");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAasspa model_limit_area = new CSGenioAasspa(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(asset_global_filter__pseud__asspa_filtred_by_paramConds);
			asset_global_filter__pseud__asspa_filtred_by_paramConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ ASSET_GLOBAL_FILTER_PSEUDASSPA_FILTRED_BY_PARAM]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAasspa>(m_userContext, false, ref asset_global_filter__pseud__asspa_filtred_by_paramConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ASSET_GLOBAL_FILTER_PSEUDASSPA_FILTRED_BY_PARAM]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ASSET_GLOBAL_FILTER_PSEUDASSPA_FILTRED_BY_PARAM]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asspa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asspa");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAasspa.GetInformation(), QMVC_POS_RECORD, sorts, asset_global_filter__pseud__asspa_filtred_by_paramConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAasspa> listing = Models.ModelBase.Where<CSGenioAasspa>(m_userContext, distinct, asset_global_filter__pseud__asspa_filtred_by_paramConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapAsset_global_filter_ValAsspa_filtred_by_param(listing);

				Menu.Identifier = "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ASSET_GLOBAL_FILTER__PSEUD__ASSPA_FILTRED_BY_PARAM";

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

		private List<Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel> MapAsset_global_filter_ValAsspa_filtred_by_param(ListingMVC<CSGenioAasspa> Qlisting)
		{
			List<Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapAsset_global_filter_ValAsspa_filtred_by_param(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAasspa row
		/// to a Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel MapAsset_global_filter_ValAsspa_filtred_by_param(CSGenioAasspa row)
		{
			var model = new Asset_global_filter_ValAsspa_filtred_by_param_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asspa":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "asset":
						model.Asset.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "param":
						model.Param.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			// Use the parent context, so the formulas are calculated with the current values.
			model.Asset = ParentCtx as Models.Asset;

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
		private void SetDocumentFields(ListingMVC<CSGenioAasspa> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Asspa m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Asspa m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ASSET_GLOBAL_FILTER_VALASSPA_FILTRED_BY_PARAM]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Asspa", "Asspa.ValCodasspa", "Asspa.ValZzstate", "Asspa.ValToshow", "Asset", "Asset.ValName", "Param", "Param.ValParameter", "Asspa.ValDatatype", "Asspa.ValText", "Asspa.ValQuantity", "Asspa.ValDate", "Asspa.ValDecimalplaces", "Asspa.ValCodasset", "Asspa.ValCodparam"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValToshow", CSGenioAasspa.FldToshow, typeof(string)),
			new TableSearchColumn("Asset_ValName", CSGenioAasset.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("Param_ValParameter", CSGenioAparam.FldParameter, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValDatatype", CSGenioAasspa.FldDatatype, typeof(string), array : "DataType"),
			new TableSearchColumn("ValText", CSGenioAasspa.FldText, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValQuantity", CSGenioAasspa.FldQuantity, typeof(decimal?)),
			new TableSearchColumn("ValDate", CSGenioAasspa.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDecimalplaces", CSGenioAasspa.FldDecimalplaces, typeof(decimal?)),
		];

		private static readonly List<Field> _globalFilters =
		[
			CSGenioAparam.GetInformation().DBFields[CSGenioAparam.FldCodparam.Field],
		];
		protected override List<Field> GlobalFilters => _globalFilters;
	}
}
