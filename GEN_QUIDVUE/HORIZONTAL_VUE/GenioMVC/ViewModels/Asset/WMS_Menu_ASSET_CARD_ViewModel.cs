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

namespace GenioMVC.ViewModels.Asset
{
	public class WMS_Menu_ASSET_CARD_ViewModel : MenuListViewModel<Models.Asset>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<WMS_Menu_ASSET_CARD_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "asset";

		/// <inheritdoc/>
		public override string Uuid => "cbba1257-006c-407c-bff6-cb87a80d6f4e";

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
				// Limit "SC"
				conditions.Equal(CSGenioAasset.FldAssettyp, "E");

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
				if (Navigation.CheckKey("asset.assettyp"))
					conds.Equal(CSGenioAasset.FldAssettyp, Navigation.GetValue("asset.assettyp"));

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
// USE /[MANUAL WMS LIST_LIMITS ASSET_CARD]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("asset", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "MLASSET_CARD");
			conditions.Equal(CSGenioAasset.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldZzstate, CSGenioAasset.FldAssetnum, CSGenioAasset.FldName, CSGenioAasset.FldCodkinde, CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAasset.FldIdenttyp, CSGenioAasset.FldGrai, CSGenioAasset.FldGiai, CSGenioAasset.FldPhoto, CSGenioAasset.FldCodmanuf, CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAmanuf.FldWebsite };

			ListingMVC<CSGenioAasset> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public WMS_Menu_ASSET_CARD_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_ASSET_CARD_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_ASSET_CARD_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_ASSET_CARD_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public WMS_Menu_ASSET_CARD_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAasset.FldAssetnum, FieldType.NUMERIC, Resources.Resources.ASSET_NUMBER52372, 10, 0, true),
				new Exports.QColumn(CSGenioAasset.FldName, FieldType.TEXT, Resources.Resources.IDENTIFICATION_NAME16317, 30, 0, true),
				new Exports.QColumn(CSGenioAkinde.FldDesignat, FieldType.TEXT, Resources.Resources.KIND_OF_EQUIPMENT22928, 30, 0, false),
				new Exports.QColumn(CSGenioAasset.FldIdenttyp, FieldType.ARRAY_TEXT, Resources.Resources.IDENTIFIER_TYPE60623, 1, 0, true, "IdentTyp"),
				new Exports.QColumn(CSGenioAasset.FldGrai, FieldType.TEXT, Resources.Resources.GRAI10374, 30, 0, true),
				new Exports.QColumn(CSGenioAasset.FldGiai, FieldType.TEXT, Resources.Resources.GIAI50592, 30, 0, true),
				new Exports.QColumn(CSGenioAmanuf.FldName, FieldType.TEXT, Resources.Resources.MANUFACTURER50759, 30, 0, true),
				new Exports.QColumn(CSGenioAmanuf.FldWebsite, FieldType.TEXT, Resources.Resources.WEB_SITE06263, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAasset> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAasset> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<WMS_Menu_ASSET_CARD_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			if (isToExport)
			{
				// EPH
				crs = Models.Asset.AddEPH<CSGenioAasset>(ref u, crs, "MLASSET_CARD");

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
					crs.Equals(Models.Asset.AddEPH<CSGenioAasset>(ref u, null, "MLASSET_CARD"));
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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAasset> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<WMS_Menu_ASSET_CARD_RowViewModel>();

				CriteriaSet wms_menu_asset_cardConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("ASSET.NAME", new OrderedDictionary());
				allSortOrders["ASSET.NAME"].Add("ASSET.NAME", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "asset", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasset.FldName), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldZzstate, CSGenioAasset.FldAssetnum, CSGenioAasset.FldName, CSGenioAasset.FldCodkinde, CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAasset.FldIdenttyp, CSGenioAasset.FldGrai, CSGenioAasset.FldGiai, CSGenioAasset.FldPhoto, CSGenioAasset.FldCodmanuf, CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAmanuf.FldWebsite };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("asset", "assetnum");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAasset model_limit_area = new CSGenioAasset(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLASSET_CARD");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}

				// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
				// Limit origin: menu 

				//Limit type: "SC"
				//Current Area = "ASSET"
				//1st Area Limit: "ASSET"
				//1st Area Field: "ASSETTYP"
				//1st Area Value: "E"
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.SC;
					limit.NaoAplicaSeNulo = false;
					CSGenioAasset model_limit_area = new CSGenioAasset(m_userContext.User);
					string limit_field = "assettyp", limit_field_value = "E";
					object this_limit_field = Navigation.GetStrValue(limit_field_value);
					Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
					if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
						this.tableLimits.Add(limit);
				}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(wms_menu_asset_cardConds);
				wms_menu_asset_cardConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ ASSET_CARD]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAasset>(m_userContext, false, wms_menu_asset_cardConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLASSET_CARD", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP ASSET_CARD]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL WMS OVERRQLIST ASSET_CARD]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asset");
					Navigation.DestroyEntry("QMVC_POS_RECORD_asset");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAasset.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_asset_cardConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(m_userContext, distinct, wms_menu_asset_cardConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLASSET_CARD", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapWMS_Menu_ASSET_CARD(listing);

					Menu.Identifier = "MLASSET_CARD";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "MLASSET_CARD";

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

		private List<WMS_Menu_ASSET_CARD_RowViewModel> MapWMS_Menu_ASSET_CARD(ListingMVC<CSGenioAasset> Qlisting)
		{
			List<WMS_Menu_ASSET_CARD_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_ASSET_CARD(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAasset row
		/// to a WMS_Menu_ASSET_CARD_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private WMS_Menu_ASSET_CARD_RowViewModel MapWMS_Menu_ASSET_CARD(CSGenioAasset row)
		{
			var model = new WMS_Menu_ASSET_CARD_RowViewModel(m_userContext, true, _fieldsToSerialize);
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

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_ASSET_CARD]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValAssetnum", "Asset.ValName", "Kinde", "Kinde.ValDesignat", "Asset.ValIdenttyp", "Asset.ValGrai", "Asset.ValGiai", "Asset.ValPhoto", "Manuf", "Manuf.ValName", "Manuf.ValWebsite", "Asset.ValCodkinde", "Asset.ValCodmanuf"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValAssetnum", CSGenioAasset.FldAssetnum, typeof(decimal?)),
			new TableSearchColumn("ValName", CSGenioAasset.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("Kinde_ValDesignat", CSGenioAkinde.FldDesignat, typeof(string), visible : false),
			new TableSearchColumn("ValIdenttyp", CSGenioAasset.FldIdenttyp, typeof(string), array : "IdentTyp"),
			new TableSearchColumn("ValGrai", CSGenioAasset.FldGrai, typeof(string)),
			new TableSearchColumn("ValGiai", CSGenioAasset.FldGiai, typeof(string)),
			new TableSearchColumn("Manuf_ValName", CSGenioAmanuf.FldName, typeof(string)),
			new TableSearchColumn("Manuf_ValWebsite", CSGenioAmanuf.FldWebsite, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Asset row)
		{
			if (row == null)
				return;

			row.ValPhotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaASSET, CSGenioAasset.FldPhoto.Field, null, row.ValCodasset);
		}
	}
}
