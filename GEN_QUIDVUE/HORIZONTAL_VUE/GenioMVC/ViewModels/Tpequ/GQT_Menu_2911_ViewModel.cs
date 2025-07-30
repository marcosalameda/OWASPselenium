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

namespace GenioMVC.ViewModels.Tpequ
{
	public class GQT_Menu_2911_ViewModel : MenuListViewModel<Models.Tpequ>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_2911_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "tpequ";

		/// <inheritdoc/>
		public override string Uuid => "ccb896ea-08b1-4f02-afd9-fc6db34c63ef";

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
// USE /[MANUAL GQT LIST_LIMITS 2911]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("tpequ", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML2911");
			conditions.Equal(CSGenioAtpequ.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldCodfamil, CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldPrecomax, CSGenioAtpequ.FldPrecoult, CSGenioAtpequ.FldSince, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldKit };

			ListingMVC<CSGenioAtpequ> listing = new(fields, null, 1, 1, false, user, true, string.Empty, true);
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
		public GQT_Menu_2911_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_2911_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_2911_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_2911_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public GQT_Menu_2911_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAtpequ.FldTpequcod, FieldType.TEXT, Resources.Resources.CODE49225, 20, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXT, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, true),
				new Exports.QColumn(CSGenioAfamil.FldFamily, FieldType.TEXT, Resources.Resources.FAMILIA_DE_EQUIPAMEN12158, 30, 0, true),
				new Exports.QColumn(CSGenioAtpequ.FldTpequpai, FieldType.TEXT, Resources.Resources.DEPENDENT_ON28321, 20, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldNivel, FieldType.NUMERIC, Resources.Resources.LEVEL06184, 3, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldBackcolo, FieldType.TEXT, Resources.Resources.BACKGROUND_COLOR47883, 30, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldCorletra, FieldType.TEXT, Resources.Resources.LETTER_COLOR15736, 30, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldPrecomax, FieldType.CURRENCY, Resources.Resources.MAXIMUM_PRICE55489, 12, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldPrecoult, FieldType.CURRENCY, Resources.Resources.LAST_PRICE25852, 12, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldSince, FieldType.DATETIME, Resources.Resources.SINCE47259, 16, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldQtdequip, FieldType.NUMERIC, Resources.Resources.AMOUNT46885, 6, 0, false),
				new Exports.QColumn(CSGenioAtpequ.FldKit, FieldType.LOGIC, Resources.Resources.KIT27179, 1, 0, false),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpequ> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAtpequ> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GQT_Menu_2911_RowViewModel>();
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
				crs = Models.Tpequ.AddEPH<CSGenioAtpequ>(ref u, crs, "ML2911");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtpequ.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("TPEQU", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAtpequ.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpequ");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tpequ");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tpequ.AddEPH<CSGenioAtpequ>(ref u, null, "ML2911"));
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
			ListingMVC<CSGenioAtpequ> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpequ> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAtpequ> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpequ> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_2911_RowViewModel>();

				CriteriaSet gqt_menu_2911Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("TPEQU.TPEQUCOD", new OrderedDictionary());
				allSortOrders["TPEQU.TPEQUCOD"].Add("TPEQU.TPEQUCOD", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "tpequ", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldCodfamil, CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldPrecomax, CSGenioAtpequ.FldPrecoult, CSGenioAtpequ.FldSince, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldKit };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("tpequ", "tpequcod");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAtpequ model_limit_area = new CSGenioAtpequ(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML2911");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_2911Conds);
				gqt_menu_2911Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 2911]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, gqt_menu_2911Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2911", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 2911]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 2911]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpequ");
					Navigation.DestroyEntry("QMVC_POS_RECORD_tpequ");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAtpequ.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_2911Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, distinct, gqt_menu_2911Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2911", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_2911(listing);

					Menu.Identifier = "ML2911";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML2911";

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

		private List<GQT_Menu_2911_RowViewModel> MapGQT_Menu_2911(ListingMVC<CSGenioAtpequ> Qlisting)
		{
			List<GQT_Menu_2911_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_2911(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAtpequ row
		/// to a GQT_Menu_2911_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_2911_RowViewModel MapGQT_Menu_2911(CSGenioAtpequ row)
		{
			var model = new GQT_Menu_2911_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "famil":
						model.Famil.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAtpequ> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Tpequ m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tpequ m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_2911]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Famil", "Famil.ValFamily", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra", "Tpequ.ValPrecomax", "Tpequ.ValPrecoult", "Tpequ.ValSince", "Tpequ.ValQtdequip", "Tpequ.ValKit", "Tpequ.ValCodfamil"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValTpequcod", CSGenioAtpequ.FldTpequcod, typeof(string)),
			new TableSearchColumn("ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string), defaultSearch : true),
			new TableSearchColumn("Famil_ValFamily", CSGenioAfamil.FldFamily, typeof(string)),
			new TableSearchColumn("ValTpequpai", CSGenioAtpequ.FldTpequpai, typeof(string), visible : false),
			new TableSearchColumn("ValNivel", CSGenioAtpequ.FldNivel, typeof(decimal), visible : false),
			new TableSearchColumn("ValBackcolo", CSGenioAtpequ.FldBackcolo, typeof(string), visible : false),
			new TableSearchColumn("ValCorletra", CSGenioAtpequ.FldCorletra, typeof(string), visible : false),
			new TableSearchColumn("ValPrecomax", CSGenioAtpequ.FldPrecomax, typeof(decimal?), visible : false),
			new TableSearchColumn("ValPrecoult", CSGenioAtpequ.FldPrecoult, typeof(decimal?), visible : false),
			new TableSearchColumn("ValSince", CSGenioAtpequ.FldSince, typeof(DateTime?), visible : false),
			new TableSearchColumn("ValQtdequip", CSGenioAtpequ.FldQtdequip, typeof(decimal?), visible : false),
			new TableSearchColumn("ValKit", CSGenioAtpequ.FldKit, typeof(bool), visible : false),
		];
	}
}
