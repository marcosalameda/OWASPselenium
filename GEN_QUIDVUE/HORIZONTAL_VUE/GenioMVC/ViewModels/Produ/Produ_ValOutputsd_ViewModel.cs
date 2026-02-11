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

namespace GenioMVC.ViewModels.Produ
{
	public class Produ_ValOutputsd_ViewModel : MenuListViewModel<Models.Dilin>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Produ_ValOutputsd_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "dilin";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Produ_ValOutputsd";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ProduValCodprodu { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS PRODU_PSEUDOUTPUTSD]/

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
		public Produ_ValOutputsd_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Produ_ValOutputsd_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Produ_ValOutputsd_ViewModel(UserContext userContext) : base(userContext)
		{
			ProduValCodprodu = userContext.CurrentNavigation.CurrentLevel.GetEntry("produ")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Produ_ValOutputsd_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Produ_ValOutputsd_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAdilin.FldInstant, FieldType.DATETIME, Resources.Resources.INSTANT35907, 16, 0, true),
				new Exports.QColumn(CSGenioAdispa.FldDispanr, FieldType.NUMERIC, Resources.Resources.DISPATCH_NUMBER23616, 10, 0, true),
				new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXT, Resources.Resources.ENTITY62049, 30, 0, true),
				new Exports.QColumn(CSGenioAdilin.FldLinenumb, FieldType.NUMERIC, Resources.Resources.LINE27983, 6, 0, true),
				new Exports.QColumn(CSGenioAdilin.FldOrdered, FieldType.NUMERIC, Resources.Resources.ORDERED04034, 10, 0, true),
				new Exports.QColumn(CSGenioAdilin.FldDelivere, FieldType.NUMERIC, Resources.Resources.DELIVERED26597, 10, 0, true),
				new Exports.QColumn(CSGenioAdilin.FldOutstand, FieldType.NUMERIC, Resources.Resources.OUTSTANDING36400, 10, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAdilin> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAdilin> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Produ_ValOutputsd_RowViewModel>();
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

			if (this.ProduValCodprodu != null)
				crs.Equal(CSGenioAdilin.FldCodprodu, this.ProduValCodprodu);
			else
				tableReload = false;
				

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Dilin.AddEPH<CSGenioAdilin>(ref u, crs, "IBL_PRODU___PSEUDOUTPUTSD");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAdilin.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("DILIN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAdilin.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dilin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dilin");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Dilin.AddEPH<CSGenioAdilin>(ref u, null, "IBL_PRODU___PSEUDOUTPUTSD"));
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
			ListingMVC<CSGenioAdilin> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdilin> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAdilin> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdilin> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Produ_ValOutputsd_RowViewModel>();

			CriteriaSet produ___pseudoutputsdConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DILIN.INSTANT", new OrderedDictionary());
			allSortOrders["DILIN.INSTANT"].Add("DILIN.INSTANT", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "dilin", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAdilin.FldInstant), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAdilin.FldCoddilin, CSGenioAdilin.FldZzstate, CSGenioAdilin.FldInstant, CSGenioAdilin.FldCoddispa, CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldDispanr, CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAdilin.FldLinenumb, CSGenioAdilin.FldOrdered, CSGenioAdilin.FldDelivere, CSGenioAdilin.FldOutstand };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("dilin", "instant");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAdilin model_limit_area = new CSGenioAdilin(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PRODU___PSEUDOUTPUTSD");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(produ___pseudoutputsdConds);
			produ___pseudoutputsdConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PRODU_PSEUDOUTPUTSD]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAdilin>(m_userContext, false, ref produ___pseudoutputsdConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PRODU___PSEUDOUTPUTSD", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PRODU_PSEUDOUTPUTSD]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST PRODU_PSEUDOUTPUTSD]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dilin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dilin");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAdilin.GetInformation(), QMVC_POS_RECORD, sorts, produ___pseudoutputsdConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAdilin> listing = Models.ModelBase.Where<CSGenioAdilin>(m_userContext, distinct, produ___pseudoutputsdConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PRODU___PSEUDOUTPUTSD", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapProdu_ValOutputsd(listing);

				Menu.Identifier = "IBL_PRODU___PSEUDOUTPUTSD";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_PRODU___PSEUDOUTPUTSD";

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

		private List<Produ_ValOutputsd_RowViewModel> MapProdu_ValOutputsd(ListingMVC<CSGenioAdilin> Qlisting)
		{
			List<Produ_ValOutputsd_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapProdu_ValOutputsd(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAdilin row
		/// to a Produ_ValOutputsd_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Produ_ValOutputsd_RowViewModel MapProdu_ValOutputsd(CSGenioAdilin row)
		{
			var model = new Produ_ValOutputsd_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "dilin":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "dispa":
						model.Dispa.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "entit":
						model.Dispa.Entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAdilin> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Dilin m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Dilin m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PRODU_VALOUTPUTSD]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Dilin", "Dilin.ValCoddilin", "Dilin.ValZzstate", "Dilin.ValInstant", "Dispa", "Dispa.ValDispanr", "Entit", "Entit.ValName", "Dilin.ValLinenumb", "Dilin.ValOrdered", "Dilin.ValDelivere", "Dilin.ValOutstand", "Dilin.ValCoddispa", "Dilin.ValCodprodu"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValInstant", CSGenioAdilin.FldInstant, typeof(DateTime?)),
			new TableSearchColumn("Dispa_ValDispanr", CSGenioAdispa.FldDispanr, typeof(decimal?)),
			new TableSearchColumn("Dispa_Entit_ValName", CSGenioAentit.FldName, typeof(string)),
			new TableSearchColumn("ValLinenumb", CSGenioAdilin.FldLinenumb, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("ValOrdered", CSGenioAdilin.FldOrdered, typeof(decimal?)),
			new TableSearchColumn("ValDelivere", CSGenioAdilin.FldDelivere, typeof(decimal?)),
			new TableSearchColumn("ValOutstand", CSGenioAdilin.FldOutstand, typeof(decimal?)),
		];
	}
}
