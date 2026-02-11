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

namespace GenioMVC.ViewModels.Asset
{
	public class PTN_Menu_2C11_ViewModel : MenuListViewModel<Models.Asset>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<PTN_Menu_2C11_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "asset";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "bce6af89-4f7e-413c-9610-909b7033e2d7";

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
				// Limitations

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
				conds.Equal(CSGenioAasset.FldCodkinde, Navigation.GetValue("kinde"));

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
// USE /[MANUAL PTN LIST_LIMITS 2C11]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("asset", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML2C11");
			conditions.Equal(CSGenioAasset.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldZzstate, CSGenioAasset.FldBg_color, CSGenioAasset.FldAssetnum, CSGenioAasset.FldGrai, CSGenioAasset.FldIdenttyp, CSGenioAasset.FldCategory, CSGenioAasset.FldCodkinde, CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAasset.FldName, CSGenioAasset.FldCodmanuf, CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAasset.FldGiai, CSGenioAasset.FldPhoto, CSGenioAasset.FldLongdesc, CSGenioAasset.FldAssettyp, CSGenioAasset.FldDescription };

			ListingMVC<CSGenioAasset> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaKINDE.Alias))
				qs.Join(CSGenio.business.Area.AreaKINDE, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAkinde.FldCodkinde, CSGenioAasset.FldCodkinde));




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public PTN_Menu_2C11_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_2C11_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_2C11_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_2C11_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_2C11_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAasset.FldBg_color, FieldType.TEXT, Resources.Resources.BACKGROUND_COLOR_FOR59228, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldAssetnum, FieldType.NUMERIC, Resources.Resources.ASSET_NUMBER52372, 10, 0, true),
				new Exports.QColumn(CSGenioAasset.FldGrai, FieldType.TEXT, Resources.Resources.GRAI___GLOBAL_RETURN06821, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldIdenttyp, FieldType.ARRAY_TEXT, Resources.Resources.IDENTIFIER_TYPE60623, 1, 0, true, "IdentTyp"),
				new Exports.QColumn(CSGenioAasset.FldCategory, FieldType.ARRAY_TEXT, Resources.Resources.CATEGORY18978, 5, 0, true, "assetCategory"),
				new Exports.QColumn(CSGenioAkinde.FldDesignat, FieldType.TEXT, Resources.Resources.KIND_OF_EQUIPMENT22928, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldName, FieldType.TEXT, Resources.Resources.IDENTIFICATION_NAME16317, 30, 0, true),
				new Exports.QColumn(CSGenioAmanuf.FldName, FieldType.TEXT, Resources.Resources.LEGAL_NAME42902, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldGiai, FieldType.TEXT, Resources.Resources.GIAI___GLOBAL_INDIVI63214, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldLongdesc, FieldType.MEMO, Resources.Resources.DETAILED_DESCRIPTION36560, 30, 10, true),
				new Exports.QColumn(CSGenioAasset.FldAssettyp, FieldType.ARRAY_TEXT, Resources.Resources.ASSET_TYPE02033, 1, 0, true, "AssetTyp"),
				new Exports.QColumn(CSGenioAasset.FldDescription, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 5, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAasset> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAasset> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

			Menu ??= new TablePartial<PTN_Menu_2C11_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAasset.FldCodkinde, Navigation.GetValue("kinde"));
			if (isToExport)
			{
				// EPH
				crs = Models.Asset.AddEPH<CSGenioAasset>(ref u, crs, "ML2C11");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAasset.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ASSET", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAasset.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asset");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asset");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Asset.AddEPH<CSGenioAasset>(ref u, null, "ML2C11"));
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
			ListingMVC<CSGenioAasset> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAasset> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAasset> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAasset> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<PTN_Menu_2C11_RowViewModel>();

			CriteriaSet ptn_menu_2c11Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ASSET.BG_COLOR", new OrderedDictionary());
			allSortOrders["ASSET.BG_COLOR"].Add("ASSET.BG_COLOR", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "asset", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasset.FldBg_color), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldZzstate, CSGenioAasset.FldBg_color, CSGenioAasset.FldAssetnum, CSGenioAasset.FldGrai, CSGenioAasset.FldIdenttyp, CSGenioAasset.FldCategory, CSGenioAasset.FldCodkinde, CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAasset.FldName, CSGenioAasset.FldCodmanuf, CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAasset.FldGiai, CSGenioAasset.FldPhoto, CSGenioAasset.FldLongdesc, CSGenioAasset.FldAssettyp, CSGenioAasset.FldDescription };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("asset", "bg_color");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAasset model_limit_area = new CSGenioAasset(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML2C11");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "ASSET"
			//1st Area Limit: "KINDE"
			//1st Area Field: "CODKINDE"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAkinde model_limit_area = new CSGenioAkinde(m_userContext.User);
				string limit_field = "codkinde", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(ptn_menu_2c11Conds);
			ptn_menu_2c11Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 2C11]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAasset>(m_userContext, false, ref ptn_menu_2c11Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2C11", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 2C11]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST 2C11]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asset");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asset");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAasset.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_2c11Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(m_userContext, distinct, ptn_menu_2c11Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2C11", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapPTN_Menu_2C11(listing);

				Menu.Identifier = "ML2C11";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML2C11";

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

		private List<PTN_Menu_2C11_RowViewModel> MapPTN_Menu_2C11(ListingMVC<CSGenioAasset> Qlisting)
		{
			List<PTN_Menu_2C11_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_2C11(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAasset row
		/// to a PTN_Menu_2C11_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_2C11_RowViewModel MapPTN_Menu_2C11(CSGenioAasset row)
		{
			var model = new PTN_Menu_2C11_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asset":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "kinde":
						model.Kinde.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "manuf":
						model.Manuf.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAasset> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Asset m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Asset m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_2C11]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValBg_color", "Asset.ValAssetnum", "Asset.ValGrai", "Asset.ValIdenttyp", "Asset.ValCategory", "Kinde", "Kinde.ValDesignat", "Asset.ValName", "Manuf", "Manuf.ValName", "Asset.ValGiai", "Asset.ValPhoto", "Asset.ValLongdesc", "Asset.ValAssettyp", "Asset.ValDescription", "Asset.ValCodkinde", "Asset.ValCodmanuf"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValBg_color", CSGenioAasset.FldBg_color, typeof(string)),
			new TableSearchColumn("ValAssetnum", CSGenioAasset.FldAssetnum, typeof(decimal?)),
			new TableSearchColumn("ValGrai", CSGenioAasset.FldGrai, typeof(string)),
			new TableSearchColumn("ValIdenttyp", CSGenioAasset.FldIdenttyp, typeof(string), array : "IdentTyp"),
			new TableSearchColumn("ValCategory", CSGenioAasset.FldCategory, typeof(string), array : "assetCategory"),
			new TableSearchColumn("Kinde_ValDesignat", CSGenioAkinde.FldDesignat, typeof(string)),
			new TableSearchColumn("ValName", CSGenioAasset.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("Manuf_ValName", CSGenioAmanuf.FldName, typeof(string)),
			new TableSearchColumn("ValGiai", CSGenioAasset.FldGiai, typeof(string)),
			new TableSearchColumn("ValLongdesc", CSGenioAasset.FldLongdesc, typeof(string)),
			new TableSearchColumn("ValAssettyp", CSGenioAasset.FldAssettyp, typeof(string), array : "AssetTyp"),
			new TableSearchColumn("ValDescription", CSGenioAasset.FldDescription, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Asset row)
		{
			if (row == null)
				return;

			row.ValPhotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaASSET, CSGenioAasset.FldPhoto.Field, null, row.ValCodasset);
		}
	}
}
