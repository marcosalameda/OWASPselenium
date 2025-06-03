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

namespace GenioMVC.ViewModels.Expen
{
	public class PTN_Menu_LIST_DB_MC_T_ViewModel : MenuListViewModel<Models.Expen>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<PTN_Menu_LIST_DB_MC_T_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "expen";

		/// <inheritdoc/>
		public override string Uuid => "d271f8e2-a487-40b9-b6aa-1c69abb862d1";

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
// USE /[MANUAL PTN LIST_LIMITS LIST_DB_MC_T]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("expen", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "MLLIST_DB_MC_T");
			conditions.Equal(CSGenioAexpen.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAexpen.FldCoddespe, CSGenioAexpen.FldZzstate, CSGenioAexpen.FldCodyear, CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAexpen.FldYearnumb, CSGenioAexpen.FldCodaggre, CSGenioAagreg.FldCodaggre, CSGenioAagreg.FldValue, CSGenioAexpen.FldDescript, CSGenioAexpen.FldValue, CSGenioAexpen.FldPrevval, CSGenioAexpen.FldCodproje, CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto };

			ListingMVC<CSGenioAexpen> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public PTN_Menu_LIST_DB_MC_T_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_LIST_DB_MC_T_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_LIST_DB_MC_T_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_LIST_DB_MC_T_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_LIST_DB_MC_T_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAyear.FldYear, FieldType.TEXT, Resources.Resources.ANO33022, 4, 0, true),
				new Exports.QColumn(CSGenioAexpen.FldYearnumb, FieldType.NUMERIC, Resources.Resources.ANO_NUMERICO_51058, 4, 0, true),
				new Exports.QColumn(CSGenioAagreg.FldValue, FieldType.CURRENCY, Resources.Resources.VALUE10285, 10, 0, true),
				new Exports.QColumn(CSGenioAexpen.FldDescript, FieldType.TEXT, Resources.Resources.DESCRIPTION07383, 30, 0, true),
				new Exports.QColumn(CSGenioAexpen.FldValue, FieldType.CURRENCY, Resources.Resources.VALUE10285, 10, 0, true),
				new Exports.QColumn(CSGenioAexpen.FldPrevval, FieldType.CURRENCY, Resources.Resources.VALOR_ANTERIOR54849, 10, 0, true),
				new Exports.QColumn(CSGenioAproje.FldProjecto, FieldType.TEXT, Resources.Resources.PROJECTO50142, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAexpen> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAexpen> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<PTN_Menu_LIST_DB_MC_T_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Expen.AddEPH<CSGenioAexpen>(ref u, crs, "MLLIST_DB_MC_T");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAexpen.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("EXPEN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAexpen.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_expen");
				Navigation.DestroyEntry("QMVC_POS_RECORD_expen");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Expen.AddEPH<CSGenioAexpen>(ref u, null, "MLLIST_DB_MC_T"));
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
			ListingMVC<CSGenioAexpen> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAexpen> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAexpen> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAexpen> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "LIST_DB_MC_T"),
				new("Module", "PTN")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<PTN_Menu_LIST_DB_MC_T_RowViewModel>();

				CriteriaSet ptn_menu_list_db_mc_tConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("EXPEN.DESCRIPT", new OrderedDictionary());
				allSortOrders["EXPEN.DESCRIPT"].Add("EXPEN.DESCRIPT", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "expen", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAexpen.FldDescript), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAexpen.FldCoddespe, CSGenioAexpen.FldZzstate, CSGenioAexpen.FldCodyear, CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAexpen.FldYearnumb, CSGenioAexpen.FldCodaggre, CSGenioAagreg.FldCodaggre, CSGenioAagreg.FldValue, CSGenioAexpen.FldDescript, CSGenioAexpen.FldValue, CSGenioAexpen.FldPrevval, CSGenioAexpen.FldCodproje, CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("year", "year");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAexpen model_limit_area = new CSGenioAexpen(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLLIST_DB_MC_T");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ptn_menu_list_db_mc_tConds);
				ptn_menu_list_db_mc_tConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ LIST_DB_MC_T]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAexpen>(m_userContext, false, ptn_menu_list_db_mc_tConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLLIST_DB_MC_T", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP LIST_DB_MC_T]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL PTN OVERRQLIST LIST_DB_MC_T]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_expen");
					Navigation.DestroyEntry("QMVC_POS_RECORD_expen");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAexpen.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_list_db_mc_tConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAexpen> listing = Models.ModelBase.Where<CSGenioAexpen>(m_userContext, distinct, ptn_menu_list_db_mc_tConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLLIST_DB_MC_T", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapPTN_Menu_LIST_DB_MC_T(listing);

					Menu.Identifier = "MLLIST_DB_MC_T";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "MLLIST_DB_MC_T";

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
		}

		private List<PTN_Menu_LIST_DB_MC_T_RowViewModel> MapPTN_Menu_LIST_DB_MC_T(ListingMVC<CSGenioAexpen> Qlisting)
		{
			List<PTN_Menu_LIST_DB_MC_T_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_LIST_DB_MC_T(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAexpen row
		/// to a PTN_Menu_LIST_DB_MC_T_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_LIST_DB_MC_T_RowViewModel MapPTN_Menu_LIST_DB_MC_T(CSGenioAexpen row)
		{
			var model = new PTN_Menu_LIST_DB_MC_T_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "expen":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "year":
						model.Year.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "agreg":
						model.Agreg.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "proje":
						model.Proje.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAexpen> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Expen m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Expen m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_LIST_DB_MC_T]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Expen", "Expen.ValCoddespe", "Expen.ValZzstate", "Year", "Year.ValYear", "Expen.ValYearnumb", "Agreg", "Agreg.ValValue", "Expen.ValDescript", "Expen.ValValue", "Expen.ValPrevval", "Proje", "Proje.ValProjecto", "Expen.ValCodaggre", "Expen.ValCodproje", "Expen.ValCodyear"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Year_ValYear", CSGenioAyear.FldYear, typeof(string)),
			new TableSearchColumn("ValYearnumb", CSGenioAexpen.FldYearnumb, typeof(decimal?)),
			new TableSearchColumn("Agreg_ValValue", CSGenioAagreg.FldValue, typeof(decimal?)),
			new TableSearchColumn("ValDescript", CSGenioAexpen.FldDescript, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValValue", CSGenioAexpen.FldValue, typeof(decimal?)),
			new TableSearchColumn("ValPrevval", CSGenioAexpen.FldPrevval, typeof(decimal?)),
			new TableSearchColumn("Proje_ValProjecto", CSGenioAproje.FldProjecto, typeof(string)),
		];
	}
}
