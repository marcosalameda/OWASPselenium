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

namespace GenioMVC.ViewModels.Conta
{
	public class Conta_TpconValTipocont_ViewModel : MenuListViewModel<Models.Tpcon>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<Conta_TpconValTipocont_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "tpcon";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "Conta_TpconValTipocont";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ValCodconta { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS CONTA_TPCONTIPOCONT]/

			return crs;
		}

		public string ValCodgenre { get; set; }

		public override int GetCount(User user)
		{
			throw new NotImplementedException("This operation is not supported");
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public Conta_TpconValTipocont_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Conta_TpconValTipocont_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Conta_TpconValTipocont_ViewModel(UserContext userContext) : base(userContext)
		{
			ValCodconta = userContext.CurrentNavigation.CurrentLevel.GetEntry("conta")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Conta_TpconValTipocont_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Conta_TpconValTipocont_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAtpcon.FldTipocont, FieldType.TEXT, Resources.Resources.DESIGNATION35876, 50, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpcon> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpcon> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

			// Area limit
			tableReload &= AddCriteriaAreaLimit(crs, CSGenio.business.CSGenioAgenre.FldCodgenre, "genre", this.ValCodgenre, true);

			Menu ??= new TablePartial<Conta_TpconValTipocont_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Tpcon.AddEPH<CSGenioAtpcon>(ref u, crs, "IBL_CONTA___TPCONTIPOCONT");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtpcon.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpcon.FldZzstate), CriteriaOperator.Equal, 0));


			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_tpcon"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tpcon.AddEPH<CSGenioAtpcon>(ref u, null, "IBL_CONTA___TPCONTIPOCONT"));
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
			ListingMVC<CSGenioAtpcon> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpcon> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAtpcon> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpcon> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<Conta_TpconValTipocont_RowViewModel>();

			CriteriaSet conta___tpcontipocontConds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("TPCON.TIPOCONT", new OrderedDictionary());
			allSortOrders["TPCON.TIPOCONT"].Add("TPCON.TIPOCONT", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "tpcon", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpcon.FldTipocont), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldZzstate, CSGenioAtpcon.FldTipocont };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("tpcon", "tipocont");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAtpcon model_limit_area = new CSGenioAtpcon(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_CONTA___TPCONTIPOCONT");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 
			//Limit type: "A"
			//Current Area = "TPCON"
			//1st Area Limit: "GENRE"
			//1st Area Field: "CODGENRE"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.A;
				limit.NaoAplicaSeNulo = false;
				CSGenioAgenre model_limit_area = new CSGenioAgenre(m_userContext.User);
				string limit_field = "codgenre", limit_field_value = "";
				object this_limit_field = Navigation.GetValue("genre") == null ? this.ValCodgenre : Navigation.GetValue("genre");
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(conta___tpcontipocontConds);
			conta___tpcontipocontConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ CONTA_TPCONTIPOCONT]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAtpcon>(m_userContext, false, ref conta___tpcontipocontConds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_CONTA___TPCONTIPOCONT", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP CONTA_TPCONTIPOCONT]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST CONTA_TPCONTIPOCONT]/

				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_tpcon"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAtpcon.GetInformation(), QMVC_POS_RECORD, sorts, conta___tpcontipocontConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAtpcon> listing = Models.ModelBase.Where<CSGenioAtpcon>(m_userContext, distinct, conta___tpcontipocontConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_CONTA___TPCONTIPOCONT", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapConta_TpconValTipocont(listing);

				Menu.Identifier = "IBL_CONTA___TPCONTIPOCONT";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_CONTA___TPCONTIPOCONT";

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

		private List<Conta_TpconValTipocont_RowViewModel> MapConta_TpconValTipocont(ListingMVC<CSGenioAtpcon> Qlisting)
		{
			List<Conta_TpconValTipocont_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapConta_TpconValTipocont(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAtpcon row
		/// to a Conta_TpconValTipocont_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Conta_TpconValTipocont_RowViewModel MapConta_TpconValTipocont(CSGenioAtpcon row)
		{
			var model = new Conta_TpconValTipocont_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpcon":
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
		private void SetDocumentFields(ListingMVC<CSGenioAtpcon> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Tpcon m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tpcon m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM CONTA_TPCONVALTIPOCONT]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Tpcon", "Tpcon.ValCodtpcon", "Tpcon.ValZzstate", "Tpcon.ValTipocont", "Tpcon.ValCodgenre"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValTipocont", CSGenioAtpcon.FldTipocont, typeof(string)),
		];
	}
}
