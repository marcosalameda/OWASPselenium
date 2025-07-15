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

namespace GenioMVC.ViewModels.Lnhpd
{
	public class Lnhpd_ValDesagreg_ViewModel : MenuListViewModel<Models.Lnhde>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<Lnhpd_ValDesagreg_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "lnhde";

		/// <inheritdoc/>
		public override string Uuid => "Lnhpd_ValDesagreg";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string LnhpdValCodlnhpd { get; set; }

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
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS LNHPD_PSEUDDESAGREG]/

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
		public Lnhpd_ValDesagreg_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Lnhpd_ValDesagreg_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Lnhpd_ValDesagreg_ViewModel(UserContext userContext) : base(userContext)
		{
			LnhpdValCodlnhpd = userContext.CurrentNavigation.CurrentLevel.GetEntry("lnhpd")?.ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Lnhpd_ValDesagreg_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Lnhpd_ValDesagreg_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAlnhde.FldOrdem, FieldType.NUMERIC, Resources.Resources.ORDER39632, 3, 0, true),
				new Exports.QColumn(CSGenioAtpeq1.FldTipoequi, FieldType.TEXT, Resources.Resources.TYPE_OF_EQUIPMENT18080, 50, 0, true),
				new Exports.QColumn(CSGenioAlnhde.FldQuantida, FieldType.NUMERIC, Resources.Resources.AMOUNT46885, 3, 0, true),
				new Exports.QColumn(CSGenioAlnhde.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 2, true),
				new Exports.QColumn(CSGenioAlnhde.FldCode, FieldType.TEXT, Resources.Resources.CODE49225, 10, 0, true),
				new Exports.QColumn(CSGenioAlnhde.FldUrl, FieldType.TEXT, Resources.Resources.SITE06486, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAlnhde> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAlnhde> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<Lnhpd_ValDesagreg_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			if (this.LnhpdValCodlnhpd != null)
				crs.Equal(CSGenioAlnhde.FldCodlnhpd, this.LnhpdValCodlnhpd);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Lnhde.AddEPH<CSGenioAlnhde>(ref u, crs, "IBL_LNHPD___PSEUDDESAGREG");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAlnhde.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LNHDE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAlnhde.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lnhde");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lnhde");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Lnhde.AddEPH<CSGenioAlnhde>(ref u, null, "IBL_LNHPD___PSEUDDESAGREG"));
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
			ListingMVC<CSGenioAlnhde> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlnhde> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAlnhde> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlnhde> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<Lnhpd_ValDesagreg_RowViewModel>();

				CriteriaSet lnhpd___pseuddesagregConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("LNHDE.ORDEM", new OrderedDictionary());
				allSortOrders["LNHDE.ORDEM"].Add("LNHDE.ORDEM", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "lnhde", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlnhde.FldOrdem), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAlnhde.FldCodlnhde, CSGenioAlnhde.FldZzstate, CSGenioAlnhde.FldOrdem, CSGenioAlnhde.FldCodtpequ, CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAlnhde.FldQuantida, CSGenioAlnhde.FldDescript, CSGenioAlnhde.FldCode, CSGenioAlnhde.FldUrl };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("lnhde", "ordem");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAlnhde model_limit_area = new CSGenioAlnhde(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_LNHPD___PSEUDDESAGREG");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(lnhpd___pseuddesagregConds);
				lnhpd___pseuddesagregConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ LNHPD_PSEUDDESAGREG]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAlnhde>(m_userContext, false, lnhpd___pseuddesagregConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LNHPD___PSEUDDESAGREG", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP LNHPD_PSEUDDESAGREG]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST LNHPD_PSEUDDESAGREG]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lnhde");
					Navigation.DestroyEntry("QMVC_POS_RECORD_lnhde");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAlnhde.GetInformation(), QMVC_POS_RECORD, sorts, lnhpd___pseuddesagregConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAlnhde> listing = Models.ModelBase.Where<CSGenioAlnhde>(m_userContext, distinct, lnhpd___pseuddesagregConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LNHPD___PSEUDDESAGREG", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapLnhpd_ValDesagreg(listing);

					Menu.Identifier = "IBL_LNHPD___PSEUDDESAGREG";

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "IBL_LNHPD___PSEUDDESAGREG";

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

		private List<Lnhpd_ValDesagreg_RowViewModel> MapLnhpd_ValDesagreg(ListingMVC<CSGenioAlnhde> Qlisting)
		{
			List<Lnhpd_ValDesagreg_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapLnhpd_ValDesagreg(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAlnhde row
		/// to a Lnhpd_ValDesagreg_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private Lnhpd_ValDesagreg_RowViewModel MapLnhpd_ValDesagreg(CSGenioAlnhde row)
		{
			var model = new Lnhpd_ValDesagreg_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lnhde":
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
		private void SetDocumentFields(ListingMVC<CSGenioAlnhde> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Lnhde m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lnhde m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHPD_VALDESAGREG]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Lnhde", "Lnhde.ValCodlnhde", "Lnhde.ValZzstate", "Lnhde.ValOrdem", "Tpeq1", "Tpeq1.ValTipoequi", "Lnhde.ValQuantida", "Lnhde.ValDescript", "Lnhde.ValCode", "Lnhde.ValUrl", "Lnhde.ValCodlnhag", "Lnhde.ValCodlnhpd", "Lnhde.ValCodpedid", "Lnhde.ValCodtpequ"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValOrdem", CSGenioAlnhde.FldOrdem, typeof(decimal?)),
			new TableSearchColumn("Tpeq1_ValTipoequi", CSGenioAtpeq1.FldTipoequi, typeof(string)),
			new TableSearchColumn("ValQuantida", CSGenioAlnhde.FldQuantida, typeof(decimal?)),
			new TableSearchColumn("ValDescript", CSGenioAlnhde.FldDescript, typeof(string)),
			new TableSearchColumn("ValCode", CSGenioAlnhde.FldCode, typeof(string)),
			new TableSearchColumn("ValUrl", CSGenioAlnhde.FldUrl, typeof(string)),
		];
	}
}
