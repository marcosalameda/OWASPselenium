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

namespace GenioMVC.ViewModels.Lendi
{
	public class PTN_Menu_3111_ViewModel : MenuListViewModel<Models.Lendi>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<PTN_Menu_3111_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "lendi";

		/// <inheritdoc/>
		public override string Uuid => "ed257c9e-1f86-4731-9ffe-354e5fc8169d";

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
// USE /[MANUAL PTN LIST_LIMITS 3111]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("lendi", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML3111");
			conditions.Equal(CSGenioAlendi.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAlendi.FldCodlendi, CSGenioAlendi.FldZzstate, CSGenioAlendi.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAlendi.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAlendi.FldCodpess2, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioAlendi.FldLendinnr, CSGenioAlendi.FldStart, CSGenioAlendi.FldWarndt, CSGenioAlendi.FldEnd, CSGenioAlendi.FldObservat, CSGenioAlendi.FldReturndt, CSGenioAlendi.FldReturned, CSGenioAlendi.FldDayslimi, CSGenioAlendi.FldIfoutdt };

			ListingMVC<CSGenioAlendi> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public PTN_Menu_3111_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_3111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_3111_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXT, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioApess2.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldLendinnr, FieldType.NUMERIC, Resources.Resources.NO__OF_THE_DADATO35934, 6, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldStart, FieldType.DATETIME, Resources.Resources.BEGINNING18124, 16, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldWarndt, FieldType.DATETIME, Resources.Resources.WARNING52043, 16, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldEnd, FieldType.DATETIME, Resources.Resources.END47577, 16, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldObservat, FieldType.MEMO, Resources.Resources.OBSERVATIONS03729, 30, 3, true),
				new Exports.QColumn(CSGenioAlendi.FldReturndt, FieldType.DATE, Resources.Resources.RETURN32222, 8, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldReturned, FieldType.LOGIC, Resources.Resources.RETURNED01606, 1, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldDayslimi, FieldType.NUMERIC, Resources.Resources.DAYS_FOR_RETURN_PERI04559, 10, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldIfoutdt, FieldType.LOGIC, Resources.Resources.IF_OUT_OF_DATE49042, 1, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAlendi> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAlendi> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<PTN_Menu_3111_RowViewModel>();
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
				crs = Models.Lendi.AddEPH<CSGenioAlendi>(ref u, crs, "ML3111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAlendi.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LENDI", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAlendi.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lendi");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lendi");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Lendi.AddEPH<CSGenioAlendi>(ref u, null, "ML3111"));
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
			ListingMVC<CSGenioAlendi> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlendi> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAlendi> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlendi> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "3111"),
				new("Module", "PTN")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<PTN_Menu_3111_RowViewModel>();

				CriteriaSet ptn_menu_3111Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("LENDI.START", new OrderedDictionary());
				allSortOrders["LENDI.START"].Add("LENDI.START", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "lendi", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlendi.FldStart), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAlendi.FldCodlendi, CSGenioAlendi.FldZzstate, CSGenioAlendi.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAlendi.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAlendi.FldCodpess2, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioAlendi.FldLendinnr, CSGenioAlendi.FldStart, CSGenioAlendi.FldWarndt, CSGenioAlendi.FldEnd, CSGenioAlendi.FldObservat, CSGenioAlendi.FldReturndt, CSGenioAlendi.FldReturned, CSGenioAlendi.FldDayslimi, CSGenioAlendi.FldIfoutdt };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("pess1", "name");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAlendi model_limit_area = new CSGenioAlendi(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3111");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ptn_menu_3111Conds);
				ptn_menu_3111Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 3111]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAlendi>(m_userContext, false, ptn_menu_3111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 3111]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL PTN OVERRQLIST 3111]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lendi");
					Navigation.DestroyEntry("QMVC_POS_RECORD_lendi");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAlendi.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_3111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAlendi> listing = Models.ModelBase.Where<CSGenioAlendi>(m_userContext, distinct, ptn_menu_3111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapPTN_Menu_3111(listing);

					Menu.Identifier = "ML3111";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML3111";

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

		private List<PTN_Menu_3111_RowViewModel> MapPTN_Menu_3111(ListingMVC<CSGenioAlendi> Qlisting)
		{
			List<PTN_Menu_3111_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_3111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAlendi row
		/// to a PTN_Menu_3111_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_3111_RowViewModel MapPTN_Menu_3111(CSGenioAlendi row)
		{
			var model = new PTN_Menu_3111_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lendi":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pess1":
						model.Pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "equip":
						model.Equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "pess2":
						model.Pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAlendi> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Lendi m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lendi m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_3111]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Lendi", "Lendi.ValCodlendi", "Lendi.ValZzstate", "Pess1", "Pess1.ValName", "Equip", "Equip.ValRegistnr", "Pess2", "Pess2.ValName", "Lendi.ValLendinnr", "Lendi.ValStart", "Lendi.ValWarndt", "Lendi.ValEnd", "Lendi.ValObservat", "Lendi.ValReturndt", "Lendi.ValReturned", "Lendi.ValDayslimi", "Lendi.ValIfoutdt", "Lendi.ValCodequip", "Lendi.ValCodpess1", "Lendi.ValCodpess2"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Pess1_ValName", CSGenioApess1.FldName, typeof(string)),
			new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
			new TableSearchColumn("Pess2_ValName", CSGenioApess2.FldName, typeof(string)),
			new TableSearchColumn("ValLendinnr", CSGenioAlendi.FldLendinnr, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("ValStart", CSGenioAlendi.FldStart, typeof(DateTime?)),
			new TableSearchColumn("ValWarndt", CSGenioAlendi.FldWarndt, typeof(DateTime?)),
			new TableSearchColumn("ValEnd", CSGenioAlendi.FldEnd, typeof(DateTime?)),
			new TableSearchColumn("ValObservat", CSGenioAlendi.FldObservat, typeof(string)),
			new TableSearchColumn("ValReturndt", CSGenioAlendi.FldReturndt, typeof(DateTime?)),
			new TableSearchColumn("ValReturned", CSGenioAlendi.FldReturned, typeof(bool)),
			new TableSearchColumn("ValDayslimi", CSGenioAlendi.FldDayslimi, typeof(decimal?)),
			new TableSearchColumn("ValIfoutdt", CSGenioAlendi.FldIfoutdt, typeof(bool)),
		];
	}
}
