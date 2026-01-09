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

namespace GenioMVC.ViewModels.Tpequ
{
	public class Tpequ_ValInstala1_ViewModel : MenuListViewModel<Models.Insta>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Tpequ_ValInstala1_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "insta";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Tpequ_ValInstala1";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string TpequValCodtpequ { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS TPEQU_PSEUDINSTALA1]/

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
		public Tpequ_ValInstala1_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Tpequ_ValInstala1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Tpequ_ValInstala1_ViewModel(UserContext userContext) : base(userContext)
		{
			TpequValCodtpequ = userContext.CurrentNavigation.CurrentLevel.GetEntry("tpequ")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Tpequ_ValInstala1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Tpequ_ValInstala1_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAinsta.FldDesignat, FieldType.TEXT, Resources.Resources.SCHEDULING24801, 30, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldDtiniage, FieldType.DATETIME, Resources.Resources.BEGINNING18124, 16, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldDtfimage, FieldType.DATETIME, Resources.Resources.END47577, 16, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 3, true),
				new Exports.QColumn(CSGenioAinsta.FldAllday, FieldType.LOGIC, Resources.Resources.ALL_DAY18496, 1, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldSince, FieldType.DATETIME, Resources.Resources.SINCE47259, 16, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldUntil, FieldType.DATETIME, Resources.Resources.UNTIL39173, 16, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldHours, FieldType.NUMERIC, Resources.Resources.QTD_HOURS28684, 10, 2, true),
				new Exports.QColumn(CSGenioAinsta.FldPrecohor, FieldType.CURRENCY, Resources.Resources.HOURLY_PRICE48005, 12, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldValue, FieldType.CURRENCY, Resources.Resources.VALUE10285, 12, 0, true),
				new Exports.QColumn(CSGenioAinsta.FldCoordgeo, FieldType.GEOGRAPHY_POINT, Resources.Resources.GEOGRAPHIC_COORDINAT21394, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAinsta> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAinsta> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Tpequ_ValInstala1_RowViewModel>();
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

			if (this.TpequValCodtpequ != null)
				crs.Equal(CSGenioAinsta.FldCodtpequ, this.TpequValCodtpequ);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Insta.AddEPH<CSGenioAinsta>(ref u, crs, "IBL_TPEQU___PSEUDINSTALA1");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAinsta.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("INSTA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAinsta.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_insta");
				Navigation.DestroyEntry("QMVC_POS_RECORD_insta");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Insta.AddEPH<CSGenioAinsta>(ref u, null, "IBL_TPEQU___PSEUDINSTALA1"));
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
			ListingMVC<CSGenioAinsta> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAinsta> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAinsta> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAinsta> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Tpequ_ValInstala1_RowViewModel>();

			CriteriaSet tpequ___pseudinstala1Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "insta", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAinsta.FldCodinsta, CSGenioAinsta.FldZzstate, CSGenioAinsta.FldDesignat, CSGenioAinsta.FldDtiniage, CSGenioAinsta.FldDtfimage, CSGenioAinsta.FldDescript, CSGenioAinsta.FldAllday, CSGenioAinsta.FldSince, CSGenioAinsta.FldUntil, CSGenioAinsta.FldHours, CSGenioAinsta.FldPrecohor, CSGenioAinsta.FldValue, CSGenioAinsta.FldCoordgeo };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("insta", "designat");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAinsta model_limit_area = new CSGenioAinsta(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_TPEQU___PSEUDINSTALA1");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(tpequ___pseudinstala1Conds);
			tpequ___pseudinstala1Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ TPEQU_PSEUDINSTALA1]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAinsta>(m_userContext, false, ref tpequ___pseudinstala1Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_TPEQU___PSEUDINSTALA1", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP TPEQU_PSEUDINSTALA1]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST TPEQU_PSEUDINSTALA1]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_insta");
				Navigation.DestroyEntry("QMVC_POS_RECORD_insta");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAinsta.GetInformation(), QMVC_POS_RECORD, sorts, tpequ___pseudinstala1Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAinsta> listing = Models.ModelBase.Where<CSGenioAinsta>(m_userContext, distinct, tpequ___pseudinstala1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_TPEQU___PSEUDINSTALA1", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTpequ_ValInstala1(listing);

				Menu.Identifier = "IBL_TPEQU___PSEUDINSTALA1";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_TPEQU___PSEUDINSTALA1";

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

		private List<Tpequ_ValInstala1_RowViewModel> MapTpequ_ValInstala1(ListingMVC<CSGenioAinsta> Qlisting)
		{
			List<Tpequ_ValInstala1_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTpequ_ValInstala1(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAinsta row
		/// to a Tpequ_ValInstala1_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Tpequ_ValInstala1_RowViewModel MapTpequ_ValInstala1(CSGenioAinsta row)
		{
			var model = new Tpequ_ValInstala1_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "insta":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAinsta> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Insta m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Insta m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPEQU_VALINSTALA1]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Insta", "Insta.ValCodinsta", "Insta.ValZzstate", "Insta.ValDesignat", "Insta.ValDtiniage", "Insta.ValDtfimage", "Insta.ValDescript", "Insta.ValAllday", "Insta.ValSince", "Insta.ValUntil", "Insta.ValHours", "Insta.ValPrecohor", "Insta.ValValue", "Insta.ValCoordgeo", "Insta.ValCodequip", "Insta.ValCodtpequ"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValDesignat", CSGenioAinsta.FldDesignat, typeof(string)),
			new TableSearchColumn("ValDtiniage", CSGenioAinsta.FldDtiniage, typeof(DateTime?)),
			new TableSearchColumn("ValDtfimage", CSGenioAinsta.FldDtfimage, typeof(DateTime?)),
			new TableSearchColumn("ValDescript", CSGenioAinsta.FldDescript, typeof(string)),
			new TableSearchColumn("ValAllday", CSGenioAinsta.FldAllday, typeof(bool)),
			new TableSearchColumn("ValSince", CSGenioAinsta.FldSince, typeof(DateTime?)),
			new TableSearchColumn("ValUntil", CSGenioAinsta.FldUntil, typeof(DateTime?)),
			new TableSearchColumn("ValHours", CSGenioAinsta.FldHours, typeof(decimal?)),
			new TableSearchColumn("ValPrecohor", CSGenioAinsta.FldPrecohor, typeof(decimal?)),
			new TableSearchColumn("ValValue", CSGenioAinsta.FldValue, typeof(decimal?)),
		];
	}
}
