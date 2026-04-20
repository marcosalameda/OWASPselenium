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

namespace GenioMVC.ViewModels.Pedid
{
	public class Pedid_ValAgrupame_ViewModel : MenuListViewModel<Models.Lnhag>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Pedid_ValAgrupame_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "lnhag";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Pedid_ValAgrupame";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string PedidValCodpedid { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS PEDID_PSEUDAGRUPAME]/

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
		public Pedid_ValAgrupame_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Pedid_ValAgrupame_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Pedid_ValAgrupame_ViewModel(UserContext userContext) : base(userContext)
		{
			PedidValCodpedid = userContext.CurrentNavigation.CurrentLevel.GetEntry("pedid")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Pedid_ValAgrupame_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Pedid_ValAgrupame_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAtpeq1.FldTipoequi, FieldType.TEXT, Resources.Resources.TYPE_OF_EQUIPMENT18080, 50, 0, true),
				new Exports.QColumn(CSGenioAlnhag.FldQtdtpequ, FieldType.NUMERIC, Resources.Resources.AMOUNT46885, 6, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAlnhag> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAlnhag> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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


			Menu ??= new TablePartial<Pedid_ValAgrupame_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			if (this.PedidValCodpedid != null)
				crs.Equal(CSGenioAlnhag.FldCodpedid, this.PedidValCodpedid);
			else
				tableReload = false;


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Lnhag.AddEPH<CSGenioAlnhag>(ref u, crs, "IBL_PEDID___PSEUDAGRUPAME");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAlnhag.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LNHAG", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAlnhag.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lnhag");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lnhag");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Lnhag.AddEPH<CSGenioAlnhag>(ref u, null, "IBL_PEDID___PSEUDAGRUPAME"));
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
			ListingMVC<CSGenioAlnhag> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlnhag> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAlnhag> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlnhag> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Pedid_ValAgrupame_RowViewModel>();

			CriteriaSet pedid___pseudagrupameConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("TPEQ1.TIPOEQUI", new OrderedDictionary());
			allSortOrders["TPEQ1.TIPOEQUI"].Add("TPEQ1.TIPOEQUI", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "lnhag", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpeq1.FldTipoequi), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAlnhag.FldCodlnhag, CSGenioAlnhag.FldZzstate, CSGenioAlnhag.FldCodtpequ, CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAlnhag.FldQtdtpequ };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("tpeq1", "tipoequi");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAlnhag model_limit_area = new CSGenioAlnhag(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PEDID___PSEUDAGRUPAME");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(pedid___pseudagrupameConds);
			pedid___pseudagrupameConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PEDID_PSEUDAGRUPAME]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAlnhag>(m_userContext, false, ref pedid___pseudagrupameConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PEDID___PSEUDAGRUPAME", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PEDID_PSEUDAGRUPAME]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST PEDID_PSEUDAGRUPAME]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lnhag");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lnhag");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAlnhag.GetInformation(), QMVC_POS_RECORD, sorts, pedid___pseudagrupameConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAlnhag> listing = Models.ModelBase.Where<CSGenioAlnhag>(m_userContext, distinct, pedid___pseudagrupameConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PEDID___PSEUDAGRUPAME", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapPedid_ValAgrupame(listing);

				Menu.Identifier = "IBL_PEDID___PSEUDAGRUPAME";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_PEDID___PSEUDAGRUPAME";

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

		private List<Pedid_ValAgrupame_RowViewModel> MapPedid_ValAgrupame(ListingMVC<CSGenioAlnhag> Qlisting)
		{
			List<Pedid_ValAgrupame_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPedid_ValAgrupame(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAlnhag row
		/// to a Pedid_ValAgrupame_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Pedid_ValAgrupame_RowViewModel MapPedid_ValAgrupame(CSGenioAlnhag row)
		{
			var model = new Pedid_ValAgrupame_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lnhag":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "tpeq1":
						model.Tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAlnhag> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Lnhag m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lnhag m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PEDID_VALAGRUPAME]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Lnhag", "Lnhag.ValCodlnhag", "Lnhag.ValZzstate", "Tpeq1", "Tpeq1.ValTipoequi", "Lnhag.ValQtdtpequ", "Lnhag.ValCodpedid", "Lnhag.ValCodtpequ"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Tpeq1_ValTipoequi", CSGenioAtpeq1.FldTipoequi, typeof(string)),
			new TableSearchColumn("ValQtdtpequ", CSGenioAlnhag.FldQtdtpequ, typeof(decimal?)),
		];
	}
}
