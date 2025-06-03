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

namespace GenioMVC.ViewModels.Produ
{
	public class WMS_Menu_321_ViewModel : MenuListViewModel<Models.Produ>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<WMS_Menu_321_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "produ";

		/// <inheritdoc/>
		public override string Uuid => "2ea79590-c020-42b1-b8c3-c1e74fe946b6";

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
// USE /[MANUAL WMS LIST_LIMITS 321]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("produ", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML321");
			conditions.Equal(CSGenioAprodu.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldZzstate, CSGenioAprodu.FldProduct, CSGenioAprodu.FldSku, CSGenioAprodu.FldGtin, CSGenioAprodu.FldDescript, CSGenioAprodu.FldSize, CSGenioAprodu.FldWeight, CSGenioAprodu.FldCodlocat, CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln, CSGenioAprodu.FldCodlcext, CSGenioAlcext.FldCodlcext, CSGenioAlcext.FldGlnext };

			ListingMVC<CSGenioAprodu> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public WMS_Menu_321_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_321_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_321_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_321_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public WMS_Menu_321_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAprodu.FldProduct, FieldType.TEXT, Resources.Resources.PRODUCT12880, 30, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldSku, FieldType.TEXT, Resources.Resources.SKU42303, 20, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldGtin, FieldType.TEXT, Resources.Resources.GTIN45487, 14, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 3, true),
				new Exports.QColumn(CSGenioAprodu.FldSize, FieldType.TEXT, Resources.Resources.SIZE10299, 30, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldWeight, FieldType.NUMERIC, Resources.Resources.WEIGHT36329, 10, 2, true),
				new Exports.QColumn(CSGenioAlocat.FldGln, FieldType.TEXT, Resources.Resources.GLN35528, 30, 0, true),
				new Exports.QColumn(CSGenioAlcext.FldGlnext, FieldType.TEXT, Resources.Resources.GLN_EXT31913, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAprodu> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAprodu> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAprodu.FldProduct, FieldType.TEXT, Resources.Resources.PRODUCT12880, 85, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 85, 3, true),
				new Exports.QColumn(CSGenioAprodu.FldSku, FieldType.TEXT, Resources.Resources.SKU42303, 20, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldGtin, FieldType.TEXT, Resources.Resources.GTIN45487, 14, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldSize, FieldType.TEXT, Resources.Resources.SIZE10299, 50, 0, true),
				new Exports.QColumn(CSGenioAprodu.FldWeight, FieldType.NUMERIC, Resources.Resources.WEIGHT36329, 9, 2, true),
				new Exports.QColumn(CSGenioAprodu.FldPrice, FieldType.CURRENCY, Resources.Resources.PRICE06900, 11, 4, true),
				new Exports.QColumn(CSGenioAprodu.FldImage, FieldType.IMAGE, Resources.Resources.IMAGE65174, 3, 1, true),
				new Exports.QColumn(CSGenioAprodu.FldIn_use, FieldType.ARRAY_LOGIC, Resources.Resources.IN_USE42606, 1, 0, true),
				new Exports.QColumn(CSGenioAlocat.FldGln, FieldType.TEXT, Resources.Resources.GLN35528, 30, 0, true),
				new Exports.QColumn(CSGenioAlcext.FldGlnext, FieldType.TEXT, Resources.Resources.GLN_EXT31913, 30, 0, true),
			};
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
				Menu = new TablePartial<WMS_Menu_321_RowViewModel>();
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
				crs = Models.Produ.AddEPH<CSGenioAprodu>(ref u, crs, "ML321");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAprodu.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PRODU", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAprodu.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_produ");
				Navigation.DestroyEntry("QMVC_POS_RECORD_produ");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Produ.AddEPH<CSGenioAprodu>(ref u, null, "ML321"));
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
			ListingMVC<CSGenioAprodu> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAprodu> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAprodu> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAprodu> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "321"),
				new("Module", "WMS")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<WMS_Menu_321_RowViewModel>();

				CriteriaSet wms_menu_321Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PRODU.PRODUCT", new OrderedDictionary());
				allSortOrders["PRODU.PRODUCT"].Add("PRODU.PRODUCT", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "produ", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAprodu.FldProduct), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldZzstate, CSGenioAprodu.FldProduct, CSGenioAprodu.FldSku, CSGenioAprodu.FldGtin, CSGenioAprodu.FldDescript, CSGenioAprodu.FldSize, CSGenioAprodu.FldWeight, CSGenioAprodu.FldCodlocat, CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln, CSGenioAprodu.FldCodlcext, CSGenioAlcext.FldCodlcext, CSGenioAlcext.FldGlnext };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("produ", "product");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAprodu model_limit_area = new CSGenioAprodu(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML321");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(wms_menu_321Conds);
				wms_menu_321Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 321]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAprodu>(m_userContext, false, wms_menu_321Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML321", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 321]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL WMS OVERRQLIST 321]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_produ");
					Navigation.DestroyEntry("QMVC_POS_RECORD_produ");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAprodu.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_321Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAprodu> listing = Models.ModelBase.Where<CSGenioAprodu>(m_userContext, distinct, wms_menu_321Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML321", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapWMS_Menu_321(listing);

					Menu.Identifier = "ML321";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML321";

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

		private List<WMS_Menu_321_RowViewModel> MapWMS_Menu_321(ListingMVC<CSGenioAprodu> Qlisting)
		{
			List<WMS_Menu_321_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_321(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAprodu row
		/// to a WMS_Menu_321_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private WMS_Menu_321_RowViewModel MapWMS_Menu_321(CSGenioAprodu row)
		{
			var model = new WMS_Menu_321_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "produ":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "locat":
						model.Locat.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "lcext":
						model.Lcext.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAprodu> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Produ m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Produ m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_321]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Produ", "Produ.ValCodprodu", "Produ.ValZzstate", "Produ.ValProduct", "Produ.ValSku", "Produ.ValGtin", "Produ.ValDescript", "Produ.ValSize", "Produ.ValWeight", "Locat", "Locat.ValGln", "Lcext", "Lcext.ValGlnext", "Produ.ValCodlcext", "Produ.ValCodlocat"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValProduct", CSGenioAprodu.FldProduct, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValSku", CSGenioAprodu.FldSku, typeof(string)),
			new TableSearchColumn("ValGtin", CSGenioAprodu.FldGtin, typeof(string)),
			new TableSearchColumn("ValDescript", CSGenioAprodu.FldDescript, typeof(string)),
			new TableSearchColumn("ValSize", CSGenioAprodu.FldSize, typeof(string)),
			new TableSearchColumn("ValWeight", CSGenioAprodu.FldWeight, typeof(decimal?)),
			new TableSearchColumn("Locat_ValGln", CSGenioAlocat.FldGln, typeof(string)),
			new TableSearchColumn("Lcext_ValGlnext", CSGenioAlcext.FldGlnext, typeof(string)),
		];
	}
}
