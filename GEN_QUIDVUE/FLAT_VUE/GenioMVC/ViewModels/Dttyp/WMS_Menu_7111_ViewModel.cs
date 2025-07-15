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

namespace GenioMVC.ViewModels.Dttyp
{
	public class WMS_Menu_7111_ViewModel : MenuListViewModel<Models.Dttyp>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<WMS_Menu_7111_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "dttyp";

		/// <inheritdoc/>
		public override string Uuid => "c2b15f2a-27e8-459e-91be-79fcbdf502e1";

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
// USE /[MANUAL WMS LIST_LIMITS 7111]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("dttyp", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML7111");
			conditions.Equal(CSGenioAdttyp.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAdttyp.FldCoddttyp, CSGenioAdttyp.FldZzstate, CSGenioAdttyp.FldString, CSGenioAdttyp.FldUppercas, CSGenioAdttyp.FldQrcode, CSGenioAdttyp.FldMultilin, CSGenioAdttyp.FldMultili3, CSGenioAdttyp.FldBoolean, CSGenioAdttyp.FldBoolean2, CSGenioAdttyp.FldSmallint, CSGenioAdttyp.FldInteger, CSGenioAdttyp.FldBigint, CSGenioAdttyp.FldReal, CSGenioAdttyp.FldFloat, CSGenioAdttyp.FldDecimal, CSGenioAdttyp.FldDecimal9, CSGenioAdttyp.FldMoney, CSGenioAdttyp.FldMoney9, CSGenioAdttyp.FldDate, CSGenioAdttyp.FldDatetime, CSGenioAdttyp.FldDtsesond, CSGenioAdttyp.FldTime, CSGenioAdttyp.FldUuid, CSGenioAdttyp.FldImage, CSGenioAdttyp.FldStart, CSGenioAdttyp.FldEnd };

			ListingMVC<CSGenioAdttyp> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public WMS_Menu_7111_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_7111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_7111_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_7111_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public WMS_Menu_7111_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAdttyp.FldString, FieldType.TEXT, Resources.Resources.STRING29433, 30, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldUppercas, FieldType.TEXT, Resources.Resources.UPPER_CASE31324, 30, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldQrcode, FieldType.TEXT, Resources.Resources.QR_CODE12259, 30, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldMultilin, FieldType.MEMO, Resources.Resources.SIMPLE_MULTILINE_TEX04460, 30, 3, true),
				new Exports.QColumn(CSGenioAdttyp.FldMultili3, FieldType.MEMO, Resources.Resources.EDITOR_MULTILINE_TEX05556, 30, 3, true),
				new Exports.QColumn(CSGenioAdttyp.FldBoolean, FieldType.LOGIC, Resources.Resources.BOOLEAN__TINYINT___S57956, 1, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldBoolean2, FieldType.NUMERIC, Resources.Resources.CONDITIONAL__BOOLEAN08919, 1, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldSmallint, FieldType.NUMERIC, Resources.Resources.SMALL_INTEGER__STORA54196, 4, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldInteger, FieldType.NUMERIC, Resources.Resources.INTEGER__STORAGE__4_49578, 9, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldBigint, FieldType.NUMERIC, Resources.Resources.BIG_INTEGER__STORAGE28249, 15, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldReal, FieldType.NUMERIC, Resources.Resources.REAL_FLOAT_24___PREC46659, 8, 2, true),
				new Exports.QColumn(CSGenioAdttyp.FldFloat, FieldType.NUMERIC, Resources.Resources.DOUBLE___FLOAT_53___07951, 15, 2, true),
				new Exports.QColumn(CSGenioAdttyp.FldDecimal, FieldType.NUMERIC, Resources.Resources.DECIMAL__1_10___STOR26677, 10, 4, true),
				new Exports.QColumn(CSGenioAdttyp.FldDecimal9, FieldType.NUMERIC, Resources.Resources.DECIMAL__11_15___STO49382, 15, 4, true),
				new Exports.QColumn(CSGenioAdttyp.FldMoney, FieldType.CURRENCY, Resources.Resources.MONEY___DECIMAL__1_124403, 10, 2, true),
				new Exports.QColumn(CSGenioAdttyp.FldMoney9, FieldType.CURRENCY, Resources.Resources.MONEY___DECIMAL__11_02101, 15, 2, true),
				new Exports.QColumn(CSGenioAdttyp.FldDate, FieldType.DATE, Resources.Resources.DATE02091, 8, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldDatetime, FieldType.DATETIME, Resources.Resources.DATETIME62630, 16, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldDtsesond, FieldType.DATETIMESECONDS, Resources.Resources.DATE_TIME_SECOND__IN55990, 19, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldTime, FieldType.TIME_HOURS, Resources.Resources.TIME50904, 5, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldUuid, FieldType.TEXT, Resources.Resources.UUID__AKA_GUID_13998, 30, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldStart, FieldType.DATETIME, Resources.Resources.STARTING_TIME_WITH_I44217, 16, 0, true),
				new Exports.QColumn(CSGenioAdttyp.FldEnd, FieldType.DATETIME, Resources.Resources.END_TIME_WITH_INCLUS19241, 16, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAdttyp> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAdttyp> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<WMS_Menu_7111_RowViewModel>();
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
				crs = Models.Dttyp.AddEPH<CSGenioAdttyp>(ref u, crs, "ML7111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAdttyp.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("DTTYP", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAdttyp.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dttyp");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dttyp");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Dttyp.AddEPH<CSGenioAdttyp>(ref u, null, "ML7111"));
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
			ListingMVC<CSGenioAdttyp> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdttyp> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAdttyp> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdttyp> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<WMS_Menu_7111_RowViewModel>();

				CriteriaSet wms_menu_7111Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("DTTYP.STRING", new OrderedDictionary());
				allSortOrders["DTTYP.STRING"].Add("DTTYP.STRING", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "dttyp", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAdttyp.FldString), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAdttyp.FldCoddttyp, CSGenioAdttyp.FldZzstate, CSGenioAdttyp.FldString, CSGenioAdttyp.FldUppercas, CSGenioAdttyp.FldQrcode, CSGenioAdttyp.FldMultilin, CSGenioAdttyp.FldMultili3, CSGenioAdttyp.FldBoolean, CSGenioAdttyp.FldBoolean2, CSGenioAdttyp.FldSmallint, CSGenioAdttyp.FldInteger, CSGenioAdttyp.FldBigint, CSGenioAdttyp.FldReal, CSGenioAdttyp.FldFloat, CSGenioAdttyp.FldDecimal, CSGenioAdttyp.FldDecimal9, CSGenioAdttyp.FldMoney, CSGenioAdttyp.FldMoney9, CSGenioAdttyp.FldDate, CSGenioAdttyp.FldDatetime, CSGenioAdttyp.FldDtsesond, CSGenioAdttyp.FldTime, CSGenioAdttyp.FldUuid, CSGenioAdttyp.FldImage, CSGenioAdttyp.FldStart, CSGenioAdttyp.FldEnd };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("dttyp", "string");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAdttyp model_limit_area = new CSGenioAdttyp(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML7111");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(wms_menu_7111Conds);
				wms_menu_7111Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 7111]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAdttyp>(m_userContext, false, wms_menu_7111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML7111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 7111]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL WMS OVERRQLIST 7111]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dttyp");
					Navigation.DestroyEntry("QMVC_POS_RECORD_dttyp");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAdttyp.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_7111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAdttyp> listing = Models.ModelBase.Where<CSGenioAdttyp>(m_userContext, distinct, wms_menu_7111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML7111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapWMS_Menu_7111(listing);

					Menu.Identifier = "ML7111";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML7111";

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

		private List<WMS_Menu_7111_RowViewModel> MapWMS_Menu_7111(ListingMVC<CSGenioAdttyp> Qlisting)
		{
			List<WMS_Menu_7111_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_7111(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAdttyp row
		/// to a WMS_Menu_7111_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private WMS_Menu_7111_RowViewModel MapWMS_Menu_7111(CSGenioAdttyp row)
		{
			var model = new WMS_Menu_7111_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "dttyp":
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
		private void SetDocumentFields(ListingMVC<CSGenioAdttyp> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Dttyp m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Dttyp m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_7111]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Dttyp", "Dttyp.ValCoddttyp", "Dttyp.ValZzstate", "Dttyp.ValString", "Dttyp.ValUppercas", "Dttyp.ValQrcode", "Dttyp.ValMultilin", "Dttyp.ValMultili3", "Dttyp.ValBoolean", "Dttyp.ValBoolean2", "Dttyp.ValSmallint", "Dttyp.ValInteger", "Dttyp.ValBigint", "Dttyp.ValReal", "Dttyp.ValFloat", "Dttyp.ValDecimal", "Dttyp.ValDecimal9", "Dttyp.ValMoney", "Dttyp.ValMoney9", "Dttyp.ValDate", "Dttyp.ValDatetime", "Dttyp.ValDtsesond", "Dttyp.ValTime", "Dttyp.ValUuid", "Dttyp.ValImage", "Dttyp.ValStart", "Dttyp.ValEnd"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValString", CSGenioAdttyp.FldString, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValUppercas", CSGenioAdttyp.FldUppercas, typeof(string)),
			new TableSearchColumn("ValQrcode", CSGenioAdttyp.FldQrcode, typeof(string)),
			new TableSearchColumn("ValMultilin", CSGenioAdttyp.FldMultilin, typeof(string)),
			new TableSearchColumn("ValMultili3", CSGenioAdttyp.FldMultili3, typeof(string)),
			new TableSearchColumn("ValBoolean", CSGenioAdttyp.FldBoolean, typeof(bool)),
			new TableSearchColumn("ValBoolean2", CSGenioAdttyp.FldBoolean2, typeof(decimal)),
			new TableSearchColumn("ValSmallint", CSGenioAdttyp.FldSmallint, typeof(decimal?)),
			new TableSearchColumn("ValInteger", CSGenioAdttyp.FldInteger, typeof(decimal?)),
			new TableSearchColumn("ValBigint", CSGenioAdttyp.FldBigint, typeof(decimal?)),
			new TableSearchColumn("ValReal", CSGenioAdttyp.FldReal, typeof(decimal?)),
			new TableSearchColumn("ValFloat", CSGenioAdttyp.FldFloat, typeof(decimal?)),
			new TableSearchColumn("ValDecimal", CSGenioAdttyp.FldDecimal, typeof(decimal?)),
			new TableSearchColumn("ValDecimal9", CSGenioAdttyp.FldDecimal9, typeof(decimal?)),
			new TableSearchColumn("ValMoney", CSGenioAdttyp.FldMoney, typeof(decimal?)),
			new TableSearchColumn("ValMoney9", CSGenioAdttyp.FldMoney9, typeof(decimal?)),
			new TableSearchColumn("ValDate", CSGenioAdttyp.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDatetime", CSGenioAdttyp.FldDatetime, typeof(DateTime?)),
			new TableSearchColumn("ValDtsesond", CSGenioAdttyp.FldDtsesond, typeof(DateTime?)),
			new TableSearchColumn("ValTime", CSGenioAdttyp.FldTime, typeof(string)),
			new TableSearchColumn("ValUuid", CSGenioAdttyp.FldUuid, typeof(string)),
			new TableSearchColumn("ValStart", CSGenioAdttyp.FldStart, typeof(DateTime?)),
			new TableSearchColumn("ValEnd", CSGenioAdttyp.FldEnd, typeof(DateTime?)),
		];
		protected void SetTicketToImageFields(Models.Dttyp row)
		{
			if (row == null)
				return;

			row.ValImageQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaDTTYP, CSGenioAdttyp.FldImage.Field, null, row.ValCoddttyp);
		}
	}
}
