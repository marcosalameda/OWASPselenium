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

namespace GenioMVC.ViewModels.Pess1
{
	public class PTN_Menu_711_ViewModel : MenuListViewModel<Models.Pess1>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<PTN_Menu_711_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "pess1";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "ceade97e-c180-4cae-a25f-a2f0b7c050f2";

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
// USE /[MANUAL PTN LIST_LIMITS 711]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("pess1", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML711");
			conditions.Equal(CSGenioApess1.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldMapheigh, CSGenioApess1.FldGender, CSGenioApess1.FldCurricul, CSGenioApess1.FldTelephon, CSGenioApess1.FldLineclr, CSGenioApess1.FldCanrot, CSGenioApess1.FldDrawmrk, CSGenioApess1.FldCanexpor, CSGenioApess1.FldName, CSGenioApess1.FldCanremov, CSGenioApess1.FldDtultcat, CSGenioApess1.FldOutweigh, CSGenioApess1.FldDtnascim, CSGenioApess1.FldPhotogra, CSGenioApess1.FldTerrain, CSGenioApess1.FldAllowlin, CSGenioApess1.FldEmail2, CSGenioApess1.FldExtquery, CSGenioApess1.FldCandrag, CSGenioApess1.FldCodcateg, CSGenioAcate2.FldCodcateg, CSGenioAcate2.FldCategoria, CSGenioApess1.FldCodparte, CSGenioAstake.FldCodparte, CSGenioAstake.FldDesignat, CSGenioApess1.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioApess1.FldIdade, CSGenioApess1.FldCanedit, CSGenioApess1.FldEmail, CSGenioApess1.FldGroupmrk, CSGenioApess1.FldAllowpol, CSGenioApess1.FldZoomlvl, CSGenioApess1.FldExterna, CSGenioApess1.FldExtminzm, CSGenioApess1.FldInterna, CSGenioApess1.FldCancut, CSGenioApess1.FldIdfuncio, CSGenioApess1.FldPolyclr, CSGenioApess1.FldNotifind };

			ListingMVC<CSGenioApess1> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public PTN_Menu_711_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_711_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_711_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_711_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_711_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioApess1.FldMapheigh, FieldType.TEXT, Resources.Resources.MAP_HEIGHT06476, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldGender, FieldType.ARRAY_TEXT, Resources.Resources.GENRE63303, 1, 0, true, "Genero"),
				new Exports.QColumn(CSGenioApess1.FldCurricul, FieldType.DOCUMENT, Resources.Resources.CURRICULUM51182, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldTelephon, FieldType.TEXT, Resources.Resources.PHONE56703, 20, 0, true),
				new Exports.QColumn(CSGenioApess1.FldLineclr, FieldType.TEXT, Resources.Resources.POLYLINE_COLOR11664, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldCanrot, FieldType.LOGIC, Resources.Resources.ALLOW_FEATURE_ROTATI56653, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldDrawmrk, FieldType.LOGIC, Resources.Resources.ALLOW_DRAWING_MARKER56732, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldCanexpor, FieldType.LOGIC, Resources.Resources.ALLOW_EXPORTING_MAP27916, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldCanremov, FieldType.LOGIC, Resources.Resources.ALLOW_FEATURE_REMOVA13844, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldDtultcat, FieldType.DATE, Resources.Resources.SINCE47259, 8, 0, true),
				new Exports.QColumn(CSGenioApess1.FldOutweigh, FieldType.NUMERIC, Resources.Resources.OUTLINE_WEIGHT25236, 2, 0, true),
				new Exports.QColumn(CSGenioApess1.FldDtnascim, FieldType.DATE, Resources.Resources.BIRTH21799, 8, 0, true),
				new Exports.QColumn(CSGenioApess1.FldTerrain, FieldType.GEOGRAPHY_SHAPE, Resources.Resources.TERRAIN43857, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldAllowlin, FieldType.LOGIC, Resources.Resources.ALLOW_DRAWING_POLYLI25703, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldEmail2, FieldType.TEXT, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldExtquery, FieldType.TEXT, Resources.Resources.QUERY_FOR_EXTERNAL_A51761, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldCandrag, FieldType.LOGIC, Resources.Resources.ALLOW_FEATURE_DRAGGI09054, 1, 0, true),
				new Exports.QColumn(CSGenioAcate2.FldCategoria, FieldType.TEXT, Resources.Resources.CATEGORY18978, 30, 0, true),
				new Exports.QColumn(CSGenioAstake.FldDesignat, FieldType.TEXT, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXT, Resources.Resources.DESIGNATION35876, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldIdade, FieldType.NUMERIC, Resources.Resources.AGE28663, 5, 0, true),
				new Exports.QColumn(CSGenioApess1.FldCanedit, FieldType.LOGIC, Resources.Resources.ALLOW_FEATURE_EDITIN16439, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldEmail, FieldType.TEXT, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldGroupmrk, FieldType.LOGIC, Resources.Resources.GROUP_MARKERS_IN_CLU31341, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldAllowpol, FieldType.LOGIC, Resources.Resources.ALLOW_DRAWING_POLYGO46480, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldZoomlvl, FieldType.NUMERIC, Resources.Resources.ZOOM_LEVEL17268, 2, 0, true),
				new Exports.QColumn(CSGenioApess1.FldExterna, FieldType.LOGIC, Resources.Resources.EXTERNAL13375, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldExtminzm, FieldType.NUMERIC, Resources.Resources.MINIMUM_ZOOM_TO_LOAD08509, 2, 0, true),
				new Exports.QColumn(CSGenioApess1.FldInterna, FieldType.LOGIC, Resources.Resources.INTERNAL04894, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldCancut, FieldType.LOGIC, Resources.Resources.ALLOW_FEATURE_CUTTIN10746, 1, 0, true),
				new Exports.QColumn(CSGenioApess1.FldIdfuncio, FieldType.NUMERIC, Resources.Resources.OFFICIAL_NO_34819, 6, 0, true),
				new Exports.QColumn(CSGenioApess1.FldPolyclr, FieldType.TEXT, Resources.Resources.POLYGON_COLOR32161, 30, 0, true),
				new Exports.QColumn(CSGenioApess1.FldNotifind, FieldType.LOGIC, Resources.Resources.INDIVIDUAL_NOTIFICAT21987, 1, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioApess1> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioApess1> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

			Menu ??= new TablePartial<PTN_Menu_711_RowViewModel>();
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
				crs = Models.Pess1.AddEPH<CSGenioApess1>(ref u, crs, "ML711");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApess1.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PESS1", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApess1.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pess1");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pess1");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Pess1.AddEPH<CSGenioApess1>(ref u, null, "ML711"));
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
			ListingMVC<CSGenioApess1> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApess1> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioApess1> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApess1> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<PTN_Menu_711_RowViewModel>();

			CriteriaSet ptn_menu_711Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PESS1.MAPHEIGH", new OrderedDictionary());
			allSortOrders["PESS1.MAPHEIGH"].Add("PESS1.MAPHEIGH", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "pess1", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldMapheigh), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldMapheigh, CSGenioApess1.FldGender, CSGenioApess1.FldCurricul, CSGenioApess1.FldCurriculfk, CSGenioApess1.FldTelephon, CSGenioApess1.FldLineclr, CSGenioApess1.FldCanrot, CSGenioApess1.FldDrawmrk, CSGenioApess1.FldCanexpor, CSGenioApess1.FldName, CSGenioApess1.FldCanremov, CSGenioApess1.FldDtultcat, CSGenioApess1.FldOutweigh, CSGenioApess1.FldDtnascim, CSGenioApess1.FldPhotogra, CSGenioApess1.FldTerrain, CSGenioApess1.FldAllowlin, CSGenioApess1.FldEmail2, CSGenioApess1.FldExtquery, CSGenioApess1.FldCandrag, CSGenioApess1.FldCodcateg, CSGenioAcate2.FldCodcateg, CSGenioAcate2.FldCategoria, CSGenioApess1.FldCodparte, CSGenioAstake.FldCodparte, CSGenioAstake.FldDesignat, CSGenioApess1.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioApess1.FldIdade, CSGenioApess1.FldCanedit, CSGenioApess1.FldEmail, CSGenioApess1.FldGroupmrk, CSGenioApess1.FldAllowpol, CSGenioApess1.FldZoomlvl, CSGenioApess1.FldExterna, CSGenioApess1.FldExtminzm, CSGenioApess1.FldInterna, CSGenioApess1.FldCancut, CSGenioApess1.FldIdfuncio, CSGenioApess1.FldPolyclr, CSGenioApess1.FldNotifind };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("pess1", "mapheigh");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioApess1 model_limit_area = new CSGenioApess1(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML711");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(ptn_menu_711Conds);
			ptn_menu_711Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 711]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioApess1>(m_userContext, false, ref ptn_menu_711Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML711", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 711]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST 711]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pess1");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pess1");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioApess1.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_711Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(m_userContext, distinct, ptn_menu_711Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML711", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapPTN_Menu_711(listing);

				Menu.Identifier = "ML711";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML711";

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

		private List<PTN_Menu_711_RowViewModel> MapPTN_Menu_711(ListingMVC<CSGenioApess1> Qlisting)
		{
			List<PTN_Menu_711_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_711(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioApess1 row
		/// to a PTN_Menu_711_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_711_RowViewModel MapPTN_Menu_711(CSGenioApess1 row)
		{
			var model = new PTN_Menu_711_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pess1":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cate2":
						model.Cate2.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "stake":
						model.Stake.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "cmpny":
						model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioApess1> listing)
		{
			if (listing.Rows == null)
				return;

			foreach (CSGenioApess1 row in listing.Rows)
			{
				{
					if (!string.IsNullOrEmpty((string)row.returnValueField("pess1.curriculfk")))
					{
						ResourceQuery resource = new("Pess1", "ValCurricul", "ValCurriculfk", row.ValCodpesso);
						string ticket = QResources.CreateTicketEncryptedBase64(m_userContext.User.Name, m_userContext.User.Location, resource);

						row.insertNameValueField("pess1.curricul", Newtonsoft.Json.JsonConvert.SerializeObject(new
						{
							fileName = row.returnValueField("pess1.curricul"),
							ticket
						}));
					}
					else
						row.removeFieldValue("pess1.curricul");
				}
			}
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Pess1 m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Pess1 m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_711]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValMapheigh", "Pess1.ValGender", "Pess1.ValCurricul", "Pess1.ValTelephon", "Pess1.ValLineclr", "Pess1.ValCanrot", "Pess1.ValDrawmrk", "Pess1.ValCanexpor", "Pess1.ValName", "Pess1.ValCanremov", "Pess1.ValDtultcat", "Pess1.ValOutweigh", "Pess1.ValDtnascim", "Pess1.ValPhotogra", "Pess1.ValTerrain", "Pess1.ValAllowlin", "Pess1.ValEmail2", "Pess1.ValExtquery", "Pess1.ValCandrag", "Cate2", "Cate2.ValCategoria", "Stake", "Stake.ValDesignat", "Cmpny", "Cmpny.ValDesignat", "Pess1.ValIdade", "Pess1.ValCanedit", "Pess1.ValEmail", "Pess1.ValGroupmrk", "Pess1.ValAllowpol", "Pess1.ValZoomlvl", "Pess1.ValExterna", "Pess1.ValExtminzm", "Pess1.ValInterna", "Pess1.ValCancut", "Pess1.ValIdfuncio", "Pess1.ValPolyclr", "Pess1.ValNotifind", "Pess1.ValCodcateg", "Pess1.ValCodempre", "Pess1.ValCodparte"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValMapheigh", CSGenioApess1.FldMapheigh, typeof(string)),
			new TableSearchColumn("ValGender", CSGenioApess1.FldGender, typeof(string), array : "Genero"),
			new TableSearchColumn("ValCurricul", CSGenioApess1.FldCurricul, typeof(string)),
			new TableSearchColumn("ValTelephon", CSGenioApess1.FldTelephon, typeof(string)),
			new TableSearchColumn("ValLineclr", CSGenioApess1.FldLineclr, typeof(string)),
			new TableSearchColumn("ValCanrot", CSGenioApess1.FldCanrot, typeof(bool)),
			new TableSearchColumn("ValDrawmrk", CSGenioApess1.FldDrawmrk, typeof(bool)),
			new TableSearchColumn("ValCanexpor", CSGenioApess1.FldCanexpor, typeof(bool)),
			new TableSearchColumn("ValName", CSGenioApess1.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValCanremov", CSGenioApess1.FldCanremov, typeof(bool)),
			new TableSearchColumn("ValDtultcat", CSGenioApess1.FldDtultcat, typeof(DateTime?)),
			new TableSearchColumn("ValOutweigh", CSGenioApess1.FldOutweigh, typeof(decimal?)),
			new TableSearchColumn("ValDtnascim", CSGenioApess1.FldDtnascim, typeof(DateTime?)),
			new TableSearchColumn("ValAllowlin", CSGenioApess1.FldAllowlin, typeof(bool)),
			new TableSearchColumn("ValEmail2", CSGenioApess1.FldEmail2, typeof(string)),
			new TableSearchColumn("ValExtquery", CSGenioApess1.FldExtquery, typeof(string)),
			new TableSearchColumn("ValCandrag", CSGenioApess1.FldCandrag, typeof(bool)),
			new TableSearchColumn("Cate2_ValCategoria", CSGenioAcate2.FldCategoria, typeof(string)),
			new TableSearchColumn("Stake_ValDesignat", CSGenioAstake.FldDesignat, typeof(string)),
			new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string)),
			new TableSearchColumn("ValIdade", CSGenioApess1.FldIdade, typeof(decimal?)),
			new TableSearchColumn("ValCanedit", CSGenioApess1.FldCanedit, typeof(bool)),
			new TableSearchColumn("ValEmail", CSGenioApess1.FldEmail, typeof(string)),
			new TableSearchColumn("ValGroupmrk", CSGenioApess1.FldGroupmrk, typeof(bool)),
			new TableSearchColumn("ValAllowpol", CSGenioApess1.FldAllowpol, typeof(bool)),
			new TableSearchColumn("ValZoomlvl", CSGenioApess1.FldZoomlvl, typeof(decimal?)),
			new TableSearchColumn("ValExterna", CSGenioApess1.FldExterna, typeof(bool)),
			new TableSearchColumn("ValExtminzm", CSGenioApess1.FldExtminzm, typeof(decimal?)),
			new TableSearchColumn("ValInterna", CSGenioApess1.FldInterna, typeof(bool)),
			new TableSearchColumn("ValCancut", CSGenioApess1.FldCancut, typeof(bool)),
			new TableSearchColumn("ValIdfuncio", CSGenioApess1.FldIdfuncio, typeof(decimal?)),
			new TableSearchColumn("ValPolyclr", CSGenioApess1.FldPolyclr, typeof(string)),
			new TableSearchColumn("ValNotifind", CSGenioApess1.FldNotifind, typeof(bool)),
		];
		protected void SetTicketToImageFields(Models.Pess1 row)
		{
			if (row == null)
				return;

			row.ValPhotograQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPESS1, CSGenioApess1.FldPhotogra.Field, null, row.ValCodpesso);
		}
	}
}
