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

namespace GenioMVC.ViewModels.Item
{
	public class GQT_Menu_4611_ViewModel : MenuListViewModel<Models.Item>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_4611_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "item";

		/// <inheritdoc/>
		public override string Uuid => "a95f0654-5e3a-4d36-b46f-5a17074e5019";

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
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAitem.FldCodwareh, Navigation.GetValue("wareh"));

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
// USE /[MANUAL GQT LIST_LIMITS 4611]/

			return crs;
		}


		public string WarehValWarehdes { get; set; }

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param
		private void SetViewModelValue(string fullFieldName, object value)
		{
			if (string.IsNullOrEmpty(fullFieldName))
				return;

			switch (fullFieldName)
			{
				case "wareh.warehdes":
					WarehValWarehdes = ViewModelConversion.ToString(value);
					break;
			}
		}

		/// <summary>
		/// Loads from the database the values of fields used in the menu title or columns show when and populates them in the ViewModel.
		/// </summary>
		public void LoadAdditionalFields()
		{
			string[] titleFields = ["wareh.warehdes"];
			FieldRef[] refTitleFields = [CSGenioAwareh.FldWarehdes];

			var sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;
			var tempEmptyArea = new CSGenioAwareh(u);

			// Fields to select
			SelectQuery querySelect = new SelectQuery();
			querySelect.PageSize(1);
			foreach (FieldRef field in refTitleFields)
				querySelect.Select(field);

			var args = CriteriaSet.And()
				.Equal(CSGenioAwareh.FldZzstate, 0)
				.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetValue("wareh"));

			args = Models.Wareh.AddEPH<CSGenioAwareh>(ref u, args, "ML461");
			querySelect.From(tempEmptyArea.QSystem, tempEmptyArea.TableName, tempEmptyArea.Alias).Where(args);
			CSGenio.persistence.QueryUtils.SetInnerJoins(titleFields, args, tempEmptyArea, querySelect);

			var dbValues = sp.executeReaderOneRow(querySelect);
			for (int i = 0; i < dbValues.Count; i++)
				SetViewModelValue(querySelect.SelectFields[i].Alias, dbValues[i]);
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("item", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML4611");
			conditions.Equal(CSGenioAitem.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldZzstate, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldEntries, CSGenioAitem.FldExits, CSGenioAitem.FldExistenc, CSGenioAitem.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAitem.FldCodgitem, CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes };

			ListingMVC<CSGenioAitem> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaWAREH.Alias))
				qs.Join(CSGenio.business.Area.AreaWAREH, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAwareh.FldCodwareh, CSGenioAitem.FldCodwareh));




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public GQT_Menu_4611_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_4611_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_4611_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_4611_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public GQT_Menu_4611_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXTO, Resources.Resources.ARTICLE60065, 30, 0, true),
				new Exports.QColumn(CSGenioAitem.FldItemcod, FieldType.TEXTO, Resources.Resources.CODE49225, 15, 0, true),
				new Exports.QColumn(CSGenioAitem.FldEntries, FieldType.NUMERO, Resources.Resources.ENTRIES32319, 10, 0, true),
				new Exports.QColumn(CSGenioAitem.FldExits, FieldType.NUMERO, Resources.Resources.OUTPUTS47833, 10, 0, true),
				new Exports.QColumn(CSGenioAitem.FldExistenc, FieldType.NUMERO, Resources.Resources.STOCKS47349, 10, 0, true),
				new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, false),
				new Exports.QColumn(CSGenioAgitem.FldItemdes, FieldType.TEXTO, Resources.Resources.GLOBAL_ARTICLE63861, 30, 0, false),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAitem> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAitem> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<GQT_Menu_4611_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAitem.FldCodwareh, Navigation.GetValue("wareh"));
			if (isToExport)
			{
				// EPH
				crs = Models.Item.AddEPH<CSGenioAitem>(ref u, crs, "ML4611");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAitem.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ITEM", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAitem.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_item");
				Navigation.DestroyEntry("QMVC_POS_RECORD_item");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Item.AddEPH<CSGenioAitem>(ref u, null, "ML4611"));
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
			ListingMVC<CSGenioAitem> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAitem> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAitem> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAitem> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "4611"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu."))
			{
				// Load the values of the fields used in the title or columns show when formulas
				LoadAdditionalFields();

				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_4611_RowViewModel>();

				CriteriaSet gqt_menu_4611Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("ITEM.ITEMDES", new OrderedDictionary());
				allSortOrders["ITEM.ITEMDES"].Add("ITEM.ITEMDES", "A");
				allSortOrders.Add("ITEM.ITEMCOD", new OrderedDictionary());
				allSortOrders["ITEM.ITEMCOD"].Add("ITEM.ITEMCOD", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "item", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemdes), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldZzstate, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldEntries, CSGenioAitem.FldExits, CSGenioAitem.FldExistenc, CSGenioAitem.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAitem.FldCodgitem, CSGenioAgitem.FldCodgitem, CSGenioAgitem.FldItemdes };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("item", "itemdes");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAitem model_limit_area = new CSGenioAitem(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML4611");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}

				// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
				// Limit origin: menu 

				//Limit type: "DB"
				//Current Area = "ITEM"
				//1st Area Limit: "WAREH"
				//1st Area Field: "CODWAREH"
				//1st Area Value: ""
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.DB;
					limit.NaoAplicaSeNulo = false;
					CSGenioAwareh model_limit_area = new CSGenioAwareh(m_userContext.User);
					string limit_field = "codwareh", limit_field_value = "";
					object this_limit_field = Navigation.GetStrValue(limit_field_value);
					Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
					if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
						this.tableLimits.Add(limit);
				}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_4611Conds);
				gqt_menu_4611Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 4611]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, gqt_menu_4611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML4611", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 4611]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 4611]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_item");
					Navigation.DestroyEntry("QMVC_POS_RECORD_item");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAitem.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_4611Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, gqt_menu_4611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML4611", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_4611(listing);

					Menu.Identifier = "ML4611";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML4611";

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

		private List<GQT_Menu_4611_RowViewModel> MapGQT_Menu_4611(ListingMVC<CSGenioAitem> Qlisting)
		{
			List<GQT_Menu_4611_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_4611(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAitem row
		/// to a GQT_Menu_4611_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_4611_RowViewModel MapGQT_Menu_4611(CSGenioAitem row)
		{
			var model = new GQT_Menu_4611_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "wareh":
						model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "gitem":
						model.Gitem.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

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
		private void SetDocumentFields(ListingMVC<CSGenioAitem> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (GQT_Menu_4611) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				WarehValWarehdes = ViewModelConversion.ToString(m.Wareh.ValWarehdes);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map Model (Item) to ViewModel (GQT_Menu_4611) - Error during mapping.");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Item m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (GQT_Menu_4611) to Model (Item) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.Wareh.ValWarehdes = ViewModelConversion.ToString(WarehValWarehdes);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map ViewModel (GQT_Menu_4611) to Model (Item) - Error during mapping.");
				throw;
			}
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_4611]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod", "Item.ValEntries", "Item.ValExits", "Item.ValExistenc", "Wareh", "Wareh.ValWarehdes", "Gitem", "Gitem.ValItemdes", "Item.ValCodgitem", "Item.ValCodwareh"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValItemdes", CSGenioAitem.FldItemdes, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValItemcod", CSGenioAitem.FldItemcod, typeof(string)),
			new TableSearchColumn("ValEntries", CSGenioAitem.FldEntries, typeof(decimal?)),
			new TableSearchColumn("ValExits", CSGenioAitem.FldExits, typeof(decimal?)),
			new TableSearchColumn("ValExistenc", CSGenioAitem.FldExistenc, typeof(decimal?)),
			new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string), visible : false),
			new TableSearchColumn("Gitem_ValItemdes", CSGenioAgitem.FldItemdes, typeof(string), visible : false)
		];
	}
}
