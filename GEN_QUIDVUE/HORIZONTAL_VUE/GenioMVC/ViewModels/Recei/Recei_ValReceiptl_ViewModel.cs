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

namespace GenioMVC.ViewModels.Recei
{
	public class Recei_ValReceiptl_ViewModel : MenuListViewModel<Models.Relin>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Recei_ValReceiptl_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "relin";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Recei_ValReceiptl";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ReceiValCodrecei { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS RECEI_PSEUDRECEIPTL]/

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
		public Recei_ValReceiptl_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Recei_ValReceiptl_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Recei_ValReceiptl_ViewModel(UserContext userContext) : base(userContext)
		{
			ReceiValCodrecei = userContext.CurrentNavigation.CurrentLevel.GetEntry("recei")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Recei_ValReceiptl_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Recei_ValReceiptl_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioArelin.FldLinenumb, FieldType.NUMERIC, Resources.Resources.LINE27983, 6, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldSku, FieldType.TEXT, Resources.Resources.SKU42303, 20, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldGtin, FieldType.TEXT, Resources.Resources.GTIN45487, 14, 0, false),
				new Exports.QColumn(CSGenioAprodu.FldProduct, FieldType.TEXT, Resources.Resources.PRODUCT12880, 30, 0, true),
				new Exports.QColumn(CSGenioArelin.FldOrdered, FieldType.NUMERIC, Resources.Resources.ORDERED04034, 10, 0, true),
				new Exports.QColumn(CSGenioArelin.FldReceived, FieldType.NUMERIC, Resources.Resources.RECEIVED19242, 10, 0, true),
				new Exports.QColumn(CSGenioArelin.FldOutstand, FieldType.NUMERIC, Resources.Resources.OUTSTANDING36400, 10, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioArelin> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioArelin> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Recei_ValReceiptl_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			if (this.ReceiValCodrecei != null)
				crs.Equal(CSGenioArelin.FldCodrecei, this.ReceiValCodrecei);
			else
				tableReload = false;


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Relin.AddEPH<CSGenioArelin>(ref u, crs, "IBL_RECEI___PSEUDRECEIPTL");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArelin.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("RELIN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArelin.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_relin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_relin");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Relin.AddEPH<CSGenioArelin>(ref u, null, "IBL_RECEI___PSEUDRECEIPTL"));
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
			ListingMVC<CSGenioArelin> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArelin> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioArelin> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArelin> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Recei_ValReceiptl_RowViewModel>();

			CriteriaSet recei___pseudreceiptlConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("RELIN.LINENUMB", new OrderedDictionary());
			allSortOrders["RELIN.LINENUMB"].Add("RELIN.LINENUMB", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "relin", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArelin.FldLinenumb), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioArelin.FldCoddilin, CSGenioArelin.FldZzstate, CSGenioArelin.FldLinenumb, CSGenioArelin.FldCodprodu, CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldSku, CSGenioAprodu.FldGtin, CSGenioAprodu.FldProduct, CSGenioArelin.FldOrdered, CSGenioArelin.FldReceived, CSGenioArelin.FldOutstand };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("relin", "linenumb");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArelin model_limit_area = new CSGenioArelin(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_RECEI___PSEUDRECEIPTL");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(recei___pseudreceiptlConds);
			recei___pseudreceiptlConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ RECEI_PSEUDRECEIPTL]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioArelin>(m_userContext, false, ref recei___pseudreceiptlConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_RECEI___PSEUDRECEIPTL", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP RECEI_PSEUDRECEIPTL]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST RECEI_PSEUDRECEIPTL]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_relin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_relin");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioArelin.GetInformation(), QMVC_POS_RECORD, sorts, recei___pseudreceiptlConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioArelin> listing = Models.ModelBase.Where<CSGenioArelin>(m_userContext, distinct, recei___pseudreceiptlConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_RECEI___PSEUDRECEIPTL", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapRecei_ValReceiptl(listing);

				Menu.Identifier = "IBL_RECEI___PSEUDRECEIPTL";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_RECEI___PSEUDRECEIPTL";

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

		private List<Recei_ValReceiptl_RowViewModel> MapRecei_ValReceiptl(ListingMVC<CSGenioArelin> Qlisting)
		{
			List<Recei_ValReceiptl_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapRecei_ValReceiptl(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioArelin row
		/// to a Recei_ValReceiptl_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Recei_ValReceiptl_RowViewModel MapRecei_ValReceiptl(CSGenioArelin row)
		{
			var model = new Recei_ValReceiptl_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "relin":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "produ":
						model.Produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioArelin> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Relin m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Relin m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM RECEI_VALRECEIPTL]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Relin", "Relin.ValCoddilin", "Relin.ValZzstate", "Relin.ValLinenumb", "Produ", "Produ.ValSku", "Produ.ValGtin", "Produ.ValProduct", "Relin.ValOrdered", "Relin.ValReceived", "Relin.ValOutstand", "Relin.ValCodentit", "Relin.ValCodprodu", "Relin.ValCodrecei"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValLinenumb", CSGenioArelin.FldLinenumb, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("Produ_ValSku", CSGenioAprodu.FldSku, typeof(string)),
			new TableSearchColumn("Produ_ValGtin", CSGenioAprodu.FldGtin, typeof(string), visible : false),
			new TableSearchColumn("Produ_ValProduct", CSGenioAprodu.FldProduct, typeof(string)),
			new TableSearchColumn("ValOrdered", CSGenioArelin.FldOrdered, typeof(decimal?)),
			new TableSearchColumn("ValReceived", CSGenioArelin.FldReceived, typeof(decimal?)),
			new TableSearchColumn("ValOutstand", CSGenioArelin.FldOutstand, typeof(decimal?)),
		];
	}
}
