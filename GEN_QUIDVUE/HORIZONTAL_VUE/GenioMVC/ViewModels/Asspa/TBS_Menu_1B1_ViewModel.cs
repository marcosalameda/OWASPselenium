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

namespace GenioMVC.ViewModels.Asspa
{
	public class TBS_Menu_1B1_ViewModel : MenuListViewModel<Models.Asspa>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<TBS_Menu_1B1_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "asspa";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "35e0dee6-b3d0-48e5-8bac-7ff2c10db4da";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

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
// USE /[MANUAL TBS LIST_LIMITS 1B1]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("asspa", user, "TBS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML1B1");
			conditions.Equal(CSGenioAasspa.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAasspa.FldCodasspa, CSGenioAasspa.FldZzstate, CSGenioAasspa.FldToshow, CSGenioAasspa.FldCodasset, CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasspa.FldCodparam, CSGenioAparam.FldCodparam, CSGenioAparam.FldParameter, CSGenioAasspa.FldDatatype, CSGenioAasspa.FldText, CSGenioAasspa.FldQuantity, CSGenioAasspa.FldDate, CSGenioAasspa.FldDecimalplaces };

			ListingMVC<CSGenioAasspa> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public TBS_Menu_1B1_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="TBS_Menu_1B1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TBS_Menu_1B1_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TBS_Menu_1B1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public TBS_Menu_1B1_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
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

			Menu ??= new TablePartial<TBS_Menu_1B1_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Asspa.AddEPH<CSGenioAasspa>(ref u, crs, "ML1B1");

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
					crs.Equals(Models.Asspa.AddEPH<CSGenioAasspa>(ref u, null, "ML1B1"));
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
			Menu = new TablePartial<TBS_Menu_1B1_RowViewModel>();

			CriteriaSet tbs_menu_1b1Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ASSPA.TOSHOW", new OrderedDictionary());
			allSortOrders["ASSPA.TOSHOW"].Add("ASSPA.TOSHOW", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "asspa", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasspa.FldToshow), SortOrder.Ascending));

			}

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
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML1B1");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(tbs_menu_1b1Conds);
			tbs_menu_1b1Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TBS OVERRQ 1B1]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAasspa>(m_userContext, false, ref tbs_menu_1b1Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1B1", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TBS OVERRQLSTEXP 1B1]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL TBS OVERRQLIST 1B1]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asspa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asspa");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAasspa.GetInformation(), QMVC_POS_RECORD, sorts, tbs_menu_1b1Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAasspa> listing = Models.ModelBase.Where<CSGenioAasspa>(m_userContext, distinct, tbs_menu_1b1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1B1", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTBS_Menu_1B1(listing);

				Menu.Identifier = "ML1B1";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML1B1";

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

		private List<TBS_Menu_1B1_RowViewModel> MapTBS_Menu_1B1(ListingMVC<CSGenioAasspa> Qlisting)
		{
			List<TBS_Menu_1B1_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTBS_Menu_1B1(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAasspa row
		/// to a TBS_Menu_1B1_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private TBS_Menu_1B1_RowViewModel MapTBS_Menu_1B1(CSGenioAasspa row)
		{
			var model = new TBS_Menu_1B1_RowViewModel(m_userContext, true, _fieldsToSerialize);
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

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBS_MENU_1B1]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Asspa", "Asspa.ValCodasspa", "Asspa.ValZzstate", "Asspa.ValToshow", "Asset", "Asset.ValName", "Param", "Param.ValParameter", "Asspa.ValDatatype", "Asspa.ValText", "Asspa.ValQuantity", "Asspa.ValDate", "Asspa.ValDecimalplaces", "Asspa.ValCodasset", "Asspa.ValCodparam"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValToshow", CSGenioAasspa.FldToshow, typeof(string)),
			new TableSearchColumn("Asset_ValName", CSGenioAasset.FldName, typeof(string)),
			new TableSearchColumn("Param_ValParameter", CSGenioAparam.FldParameter, typeof(string)),
			new TableSearchColumn("ValDatatype", CSGenioAasspa.FldDatatype, typeof(string), array : "DataType"),
			new TableSearchColumn("ValText", CSGenioAasspa.FldText, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValQuantity", CSGenioAasspa.FldQuantity, typeof(decimal?)),
			new TableSearchColumn("ValDate", CSGenioAasspa.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDecimalplaces", CSGenioAasspa.FldDecimalplaces, typeof(decimal?)),
		];
	}
}
