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

namespace GenioMVC.ViewModels.Grpb
{
	public class Grpb_ValTblb_ViewModel : MenuListViewModel<Models.Tblb>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public GridTableList<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "tblb";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Grpb_ValTblb";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string GrpbValCodgrpb { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS GRPB_PSEUDTBLB]/

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
		public Grpb_ValTblb_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Grpb_ValTblb_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Grpb_ValTblb_ViewModel(UserContext userContext) : base(userContext)
		{
			GrpbValCodgrpb = userContext.CurrentNavigation.CurrentLevel.GetEntry("grpb")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Grpb_ValTblb_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Grpb_ValTblb_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAtblb.FldText, FieldType.TEXT, Resources.Resources.TEXT04938, 30, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldTextml, FieldType.MEMO, Resources.Resources.MULTILINE_TEXT38013, 30, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldNumint, FieldType.NUMERIC, Resources.Resources.NUMERIC__INTEGER_50289, 10, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldNumdec, FieldType.NUMERIC, Resources.Resources.NUMERIC__DECIMAL_36157, 10, 3, true),
				new Exports.QColumn(CSGenioAtblb.FldCurint, FieldType.CURRENCY, Resources.Resources.CURRENCY__INTERGER_21437, 10, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldCurdec, FieldType.CURRENCY, Resources.Resources.CURRENCY__DECIMAL_11718, 10, 2, true),
				new Exports.QColumn(CSGenioAtblb.FldBool, FieldType.LOGIC, Resources.Resources.BOOLEAN45002, 1, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldDate, FieldType.DATE, Resources.Resources.DATE18475, 8, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldDatetm, FieldType.DATETIME, Resources.Resources.DATETIME__MINUTES_59352, 16, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldDatets, FieldType.DATETIMESECONDS, Resources.Resources.DATETIME__SECONDS_49861, 19, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldTimehm, FieldType.TIME_HOURS, Resources.Resources.TIME__HOURS_MINUTES_01660, 5, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldEnumt, FieldType.ARRAY_TEXT, Resources.Resources.ENUMERATION__TEXT_15855, 10, 0, true, "typet"),
				new Exports.QColumn(CSGenioAtblb.FldEnumn, FieldType.ARRAY_NUMERIC, Resources.Resources.ENUMERATION__NUMERIC44708, 10, 0, true, "typen"),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAtblb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAtblb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new GridTableList<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel>(m_userContext);
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

			if (this.GrpbValCodgrpb != null)
				crs.Equal(CSGenioAtblb.FldFkey1, this.GrpbValCodgrpb);
			else
				tableReload = false;
				

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Tblb.AddEPH<CSGenioAtblb>(ref u, crs, "IBL_GRPB____PSEUDTBLB____");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtblb.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("TBLB", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAtblb.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tblb");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tblb");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tblb.AddEPH<CSGenioAtblb>(ref u, null, "IBL_GRPB____PSEUDTBLB____"));
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
			ListingMVC<CSGenioAtblb> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtblb> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAtblb> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtblb> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new GridTableList<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel>(m_userContext);

			CriteriaSet grpb____pseudtblb____Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "tblb", allSortOrders);


			FieldRef[] fields = new FieldRef[] { CSGenioAtblb.FldCodtblb, CSGenioAtblb.FldZzstate, CSGenioAtblb.FldText, CSGenioAtblb.FldTextml, CSGenioAtblb.FldNumint, CSGenioAtblb.FldNumdec, CSGenioAtblb.FldCurint, CSGenioAtblb.FldCurdec, CSGenioAtblb.FldBool, CSGenioAtblb.FldDate, CSGenioAtblb.FldDatetm, CSGenioAtblb.FldDatets, CSGenioAtblb.FldTimehm, CSGenioAtblb.FldEnumt, CSGenioAtblb.FldEnumn, CSGenioAtblb.FldFkey1 };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("tblb", "text");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAtblb model_limit_area = new CSGenioAtblb(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_GRPB____PSEUDTBLB____");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(grpb____pseudtblb____Conds);
			grpb____pseudtblb____Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ GRPB_PSEUDTBLB]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAtblb>(m_userContext, false, ref grpb____pseudtblb____Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_GRPB____PSEUDTBLB____", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP GRPB_PSEUDTBLB]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST GRPB_PSEUDTBLB]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tblb");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tblb");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAtblb.GetInformation(), QMVC_POS_RECORD, sorts, grpb____pseudtblb____Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAtblb> listing = Models.ModelBase.Where<CSGenioAtblb>(m_userContext, distinct, grpb____pseudtblb____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_GRPB____PSEUDTBLB____", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapGrpb_ValTblb(listing);

				Menu.Identifier = "IBL_GRPB____PSEUDTBLB____";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_GRPB____PSEUDTBLB____";

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

		private List<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel> MapGrpb_ValTblb(ListingMVC<CSGenioAtblb> Qlisting)
		{
			List<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGrpb_ValTblb(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAtblb row
		/// to a GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel MapGrpb_ValTblb(CSGenioAtblb row)
		{
			if (row == null)
				return null;
			var model = new Models.Tblb(m_userContext, true, _fieldsToSerialize);

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tblb":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			Navigation.History.Push(new HistoryLevel(new NavigationLocation("GRPB____PSEUDTBLB____", String.Empty, String.Empty), FormMode.Edit));// TEMP - JUST FOR TESTs
			var viewModel = new GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel(m_userContext, model);
			viewModel.Load();
			// Remove the temporary level. If we don't remove it, all rows will have the same value in Lookups.
			Navigation.History.TryPop(out HistoryLevel _);
			return viewModel;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return false;
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAtblb> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Tblb m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tblb m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GRPB_VALTBLB]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Tblb", "Tblb.ValCodtblb", "Tblb.ValZzstate", "Tblb.ValText", "Tblb.ValTextml", "Tblb.ValNumint", "Tblb.ValNumdec", "Tblb.ValCurint", "Tblb.ValCurdec", "Tblb.ValBool", "Tblb.ValDate", "Tblb.ValDatetm", "Tblb.ValDatets", "Tblb.ValTimehm", "Tblb.ValEnumt", "Tblb.ValEnumn", "Tblb.ValFkey1"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValText", CSGenioAtblb.FldText, typeof(string)),
			new TableSearchColumn("ValTextml", CSGenioAtblb.FldTextml, typeof(string)),
			new TableSearchColumn("ValNumint", CSGenioAtblb.FldNumint, typeof(decimal?)),
			new TableSearchColumn("ValNumdec", CSGenioAtblb.FldNumdec, typeof(decimal?)),
			new TableSearchColumn("ValCurint", CSGenioAtblb.FldCurint, typeof(decimal?)),
			new TableSearchColumn("ValCurdec", CSGenioAtblb.FldCurdec, typeof(decimal?)),
			new TableSearchColumn("ValBool", CSGenioAtblb.FldBool, typeof(bool)),
			new TableSearchColumn("ValDate", CSGenioAtblb.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDatetm", CSGenioAtblb.FldDatetm, typeof(DateTime?)),
			new TableSearchColumn("ValDatets", CSGenioAtblb.FldDatets, typeof(DateTime?)),
			new TableSearchColumn("ValTimehm", CSGenioAtblb.FldTimehm, typeof(string)),
			new TableSearchColumn("ValEnumt", CSGenioAtblb.FldEnumt, typeof(string), array : "typet"),
			new TableSearchColumn("ValEnumn", CSGenioAtblb.FldEnumn, typeof(decimal), array : "typen"),
		];
	}
}
