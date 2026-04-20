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

namespace GenioMVC.ViewModels.Cntry
{
	public class IMO_Menu_131_ViewModel : MenuListViewModel<Models.Cntry>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<IMO_Menu_131_RowViewModel> Menu { get; set; }

		[JsonIgnore]
		public override TableManagementMode ViewsManagementMode => TableManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "cntry";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "2e0383bf-f54f-41d7-b7e7-76c78c1dc049";

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
// USE /[MANUAL IMO LIST_LIMITS 131]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("cntry", user, "IMO");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML131");
			conditions.Equal(CSGenioAcntry.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldZzstate, CSGenioAcntry.FldCountry, CSGenioAcntry.FldActive, CSGenioAcntry.FldCodigonr, CSGenioAcntry.FldAlfa2, CSGenioAcntry.FldAlfa3, CSGenioAcntry.FldFlag };

			ListingMVC<CSGenioAcntry> listing = new(fields, null, 1, 1, false, user, true, string.Empty, true);
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
		public IMO_Menu_131_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="IMO_Menu_131_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public IMO_Menu_131_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IMO_Menu_131_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public IMO_Menu_131_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXT, Resources.Resources.COUNTRY64133, 30, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldActive, FieldType.LOGIC, Resources.Resources.ACTIVE03270, 1, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldCodigonr, FieldType.TEXT, Resources.Resources.NUMERIC19292, 3, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldAlfa2, FieldType.TEXT, Resources.Resources.ALPHABETIC_232435, 2, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldAlfa3, FieldType.TEXT, Resources.Resources.ALPHABETIC_316640, 3, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAcntry> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAcntry> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXT, Resources.Resources.COUNTRY64133, 90, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldActive, FieldType.LOGIC, Resources.Resources.ACTIVE03270, 1, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldCodigonr, FieldType.TEXT, Resources.Resources.NUMERIC19292, 3, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldAlfa2, FieldType.TEXT, Resources.Resources.ALPHABETIC_232435, 2, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldAlfa3, FieldType.TEXT, Resources.Resources.ALPHABETIC_316640, 3, 0, true),
				new Exports.QColumn(CSGenioAcntry.FldFlag, FieldType.IMAGE, Resources.Resources.FLAG51937, 3, 1, true),
			};
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

			Menu ??= new TablePartial<IMO_Menu_131_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_IMO_Menu_131_ACTIVO"))
			{
				string defaultValue = "";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_IMO_Menu_131_ACTIVO", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Filter by area PROPR
			CriteriaSet subAreaConds = CriteriaSet.And().Equal(CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry);
			// Apply EPH conditions from the area PROPR
			Models.Propr.AddEPH<CSGenioApropr>(ref u, subAreaConds, "ML131");

			SelectQuery subAreaQuery = new SelectQuery()
				.Select(CSGenioApropr.FldCodcntry)
				.From(CSGenio.business.Area.AreaPROPR)
				.Where(subAreaConds);
			CriteriaSet filterByArea = CriteriaSet.And().Exists(subAreaQuery);
			crs.SubSets.Add(filterByArea);

			if (isToExport)
			{
				// EPH
				crs = Models.Cntry.AddEPH<CSGenioAcntry>(ref u, crs, "ML131");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcntry.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CNTRY", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcntry.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cntry");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cntry");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Cntry.AddEPH<CSGenioAcntry>(ref u, null, "ML131"));
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
			ListingMVC<CSGenioAcntry> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcntry> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAcntry> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcntry> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<IMO_Menu_131_RowViewModel>();

			CriteriaSet imo_menu_131Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("CNTRY.COUNTRY", new OrderedDictionary());
			allSortOrders["CNTRY.COUNTRY"].Add("CNTRY.COUNTRY", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "cntry", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldZzstate, CSGenioAcntry.FldCountry, CSGenioAcntry.FldActive, CSGenioAcntry.FldCodigonr, CSGenioAcntry.FldAlfa2, CSGenioAcntry.FldAlfa3, CSGenioAcntry.FldFlag };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("cntry", "country");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAcntry model_limit_area = new CSGenioAcntry(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML131");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}
			//Tooltip for "Filter by area" affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.AFILTER;
				CSGenioApropr model_limit_area = new CSGenioApropr(m_userContext.User);
				string limit_field = "codcntry";
				Limit_Filler(ref limit, model_limit_area, limit_field, "", null, LimitAreaType.AreaLimita);
				this.TableLimits.Add(limit);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(imo_menu_131Conds);
			imo_menu_131Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL IMO OVERRQ 131]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAcntry>(m_userContext, false, ref imo_menu_131Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML131", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL IMO OVERRQLSTEXP 131]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL IMO OVERRQLIST 131]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cntry");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cntry");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAcntry.GetInformation(), QMVC_POS_RECORD, sorts, imo_menu_131Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, distinct, imo_menu_131Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML131", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapIMO_Menu_131(listing);

				Menu.Identifier = "ML131";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML131";

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

		private List<IMO_Menu_131_RowViewModel> MapIMO_Menu_131(ListingMVC<CSGenioAcntry> Qlisting)
		{
			List<IMO_Menu_131_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapIMO_Menu_131(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAcntry row
		/// to a IMO_Menu_131_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private IMO_Menu_131_RowViewModel MapIMO_Menu_131(CSGenioAcntry row)
		{
			var model = new IMO_Menu_131_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			SetTicketToImageFields(model);
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
		private void SetDocumentFields(ListingMVC<CSGenioAcntry> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Cntry m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Cntry m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM IMO_MENU_131]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry", "Cntry.ValActive", "Cntry.ValCodigonr", "Cntry.ValAlfa2", "Cntry.ValAlfa3", "Cntry.ValFlag"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValCountry", CSGenioAcntry.FldCountry, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValActive", CSGenioAcntry.FldActive, typeof(bool)),
			new TableSearchColumn("ValCodigonr", CSGenioAcntry.FldCodigonr, typeof(string)),
			new TableSearchColumn("ValAlfa2", CSGenioAcntry.FldAlfa2, typeof(string)),
			new TableSearchColumn("ValAlfa3", CSGenioAcntry.FldAlfa3, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Cntry row)
		{
			if (row == null)
				return;

			row.ValFlagQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaCNTRY, CSGenioAcntry.FldFlag.Field, null, row.ValCodcntry);
		}
	}
}
