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
	public class GQT_Menu_1711_ViewModel : MenuListViewModel<Models.Lendi>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<GQT_Menu_1711_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "lendi";

		/// <inheritdoc/>
		public override string Uuid => "7477a56b-438b-4cd1-9927-38bc641973fc";

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
				conds.Equal(CSGenioAlendi.FldCodequip, Navigation.GetValue("equip"));

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
// USE /[MANUAL GQT LIST_LIMITS 1711]/

			return crs;
		}


		public string EquipValRegistnr { get; set; }

		public string EquipTpequValTipoequi { get; set; }

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
				case "equip.registnr":
					EquipValRegistnr = ViewModelConversion.ToString(value);
					break;
				case "tpequ.tipoequi":
					EquipTpequValTipoequi = ViewModelConversion.ToString(value);
					break;
			}
		}

		/// <summary>
		/// Loads from the database the values of fields used in the menu title or columns show when and populates them in the ViewModel.
		/// </summary>
		public void LoadAdditionalFields()
		{
			string[] titleFields = ["equip.registnr", "tpequ.tipoequi"];
			FieldRef[] refTitleFields = [CSGenioAequip.FldRegistnr, CSGenioAtpequ.FldTipoequi];

			var sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;
			var tempEmptyArea = new CSGenioAequip(u);

			// Fields to select
			SelectQuery querySelect = new SelectQuery();
			querySelect.PageSize(1);
			foreach (FieldRef field in refTitleFields)
				querySelect.Select(field);

			var args = CriteriaSet.And()
				.Equal(CSGenioAequip.FldZzstate, 0)
				.Equal(CSGenioAequip.FldCodequip, Navigation.GetValue("equip"));

			args = Models.Equip.AddEPH<CSGenioAequip>(ref u, args, "ML171");
			querySelect.From(tempEmptyArea.QSystem, tempEmptyArea.TableName, tempEmptyArea.Alias).Where(args);
			CSGenio.persistence.QueryUtils.SetInnerJoins(titleFields, args, tempEmptyArea, querySelect);

			var dbValues = sp.executeReaderOneRow(querySelect);
			for (int i = 0; i < dbValues.Count; i++)
				SetViewModelValue(querySelect.SelectFields[i].Alias, dbValues[i]);
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("lendi", user, "GQT");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML1711");
			conditions.Equal(CSGenioAlendi.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAlendi.FldCodlendi, CSGenioAlendi.FldZzstate, CSGenioAlendi.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAlendi.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAlendi.FldCodpess2, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioAlendi.FldLendinnr, CSGenioAlendi.FldStart, CSGenioAequip.FldFrequenc, CSGenioAlendi.FldWarndt, CSGenioAlendi.FldEnd, CSGenioAlendi.FldObservat };

			ListingMVC<CSGenioAlendi> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaEQUIP.Alias))
				qs.Join(CSGenio.business.Area.AreaEQUIP, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAequip.FldCodequip, CSGenioAlendi.FldCodequip));




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public GQT_Menu_1711_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_1711_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public GQT_Menu_1711_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GQT_Menu_1711_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public GQT_Menu_1711_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
				new Exports.QColumn(CSGenioApess2.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldLendinnr, FieldType.NUMERO, Resources.Resources.NO__OF_THE_DADATO35934, 6, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldStart, FieldType.DATAHORA, Resources.Resources.BEGINNING18124, 16, 0, true),
				new Exports.QColumn(CSGenioAequip.FldFrequenc, FieldType.ARRAY_COD_NUMERICO, Resources.Resources.LOAN_FREQUENCY00701, 2, 0, true, "FreqEmpr"),
				new Exports.QColumn(CSGenioAlendi.FldWarndt, FieldType.DATAHORA, Resources.Resources.WARNING52043, 16, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldEnd, FieldType.DATAHORA, Resources.Resources.END47577, 16, 0, true),
				new Exports.QColumn(CSGenioAlendi.FldObservat, FieldType.MEMO, Resources.Resources.OBSERVATIONS03729, 30, 3, true),
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
				Menu = new TablePartial<GQT_Menu_1711_RowViewModel>();
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
			crs.Equal(CSGenioAlendi.FldCodequip, Navigation.GetValue("equip"));
			if (isToExport)
			{
				// EPH
				crs = Models.Lendi.AddEPH<CSGenioAlendi>(ref u, crs, "ML1711");

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
					crs.Equals(Models.Lendi.AddEPH<CSGenioAlendi>(ref u, null, "ML1711"));
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
				new("Menu", "1711"),
				new("Module", "GQT")
			}, "ms", "Time to load the menu."))
			{
				// Load the values of the fields used in the title or columns show when formulas
				LoadAdditionalFields();

				User u = m_userContext.User;
				Menu = new TablePartial<GQT_Menu_1711_RowViewModel>();

				CriteriaSet gqt_menu_1711Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("LENDI.START", new OrderedDictionary());
				allSortOrders["LENDI.START"].Add("LENDI.START", "A");
				allSortOrders.Add("LENDI.WARNDT", new OrderedDictionary());
				allSortOrders["LENDI.WARNDT"].Add("LENDI.WARNDT", "A");
				allSortOrders.Add("LENDI.END", new OrderedDictionary());
				allSortOrders["LENDI.END"].Add("LENDI.END", "A");



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
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlendi.FldWarndt), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlendi.FldEnd), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAlendi.FldCodlendi, CSGenioAlendi.FldZzstate, CSGenioAlendi.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAlendi.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAlendi.FldCodpess2, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioAlendi.FldLendinnr, CSGenioAlendi.FldStart, CSGenioAequip.FldFrequenc, CSGenioAlendi.FldWarndt, CSGenioAlendi.FldEnd, CSGenioAlendi.FldObservat };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("pess1", "name");
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
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML1711");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}

				// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
				// Limit origin: menu 

				//Limit type: "DB"
				//Current Area = "LENDI"
				//1st Area Limit: "EQUIP"
				//1st Area Field: "CODEQUIP"
				//1st Area Value: ""
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.DB;
					limit.NaoAplicaSeNulo = false;
					CSGenioAequip model_limit_area = new CSGenioAequip(m_userContext.User);
					string limit_field = "codequip", limit_field_value = "";
					object this_limit_field = Navigation.GetStrValue(limit_field_value);
					Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
					if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
						this.tableLimits.Add(limit);
				}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(gqt_menu_1711Conds);
				gqt_menu_1711Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 1711]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAlendi>(m_userContext, false, gqt_menu_1711Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1711", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 1711]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL GQT OVERRQLIST 1711]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lendi");
					Navigation.DestroyEntry("QMVC_POS_RECORD_lendi");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAlendi.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_1711Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAlendi> listing = Models.ModelBase.Where<CSGenioAlendi>(m_userContext, false, gqt_menu_1711Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1711", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapGQT_Menu_1711(listing);

					Menu.Identifier = "ML1711";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML1711";

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

		private List<GQT_Menu_1711_RowViewModel> MapGQT_Menu_1711(ListingMVC<CSGenioAlendi> Qlisting)
		{
			List<GQT_Menu_1711_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_1711(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAlendi row
		/// to a GQT_Menu_1711_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private GQT_Menu_1711_RowViewModel MapGQT_Menu_1711(CSGenioAlendi row)
		{
			var model = new GQT_Menu_1711_RowViewModel(m_userContext, true, _fieldsToSerialize);
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
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lendi) to ViewModel (GQT_Menu_1711) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				EquipValRegistnr = ViewModelConversion.ToString(m.Equip.ValRegistnr);
				EquipTpequValTipoequi = ViewModelConversion.ToString(m.Equip.Tpequ.ValTipoequi);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map Model (Lendi) to ViewModel (GQT_Menu_1711) - Error during mapping.");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lendi m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (GQT_Menu_1711) to Model (Lendi) - Model is a null reference.");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.Equip.ValRegistnr = ViewModelConversion.ToString(EquipValRegistnr);
				m.Equip.Tpequ.ValTipoequi = ViewModelConversion.ToString(EquipTpequValTipoequi);
			}
			catch
			{
				CSGenio.framework.Log.Error("Map ViewModel (GQT_Menu_1711) to Model (Lendi) - Error during mapping.");
				throw;
			}
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_1711]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Lendi", "Lendi.ValCodlendi", "Lendi.ValZzstate", "Pess1", "Pess1.ValName", "Equip", "Equip.ValRegistnr", "Pess2", "Pess2.ValName", "Lendi.ValLendinnr", "Lendi.ValStart", "Equip.ValFrequenc", "Lendi.ValWarndt", "Lendi.ValEnd", "Lendi.ValObservat", "Lendi.ValCodequip", "Lendi.ValCodpess1", "Lendi.ValCodpess2"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("Pess1_ValName", CSGenioApess1.FldName, typeof(string)),
			new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
			new TableSearchColumn("Pess2_ValName", CSGenioApess2.FldName, typeof(string)),
			new TableSearchColumn("ValLendinnr", CSGenioAlendi.FldLendinnr, typeof(decimal?), defaultSearch : true),
			new TableSearchColumn("ValStart", CSGenioAlendi.FldStart, typeof(DateTime?)),
			new TableSearchColumn("Equip_ValFrequenc", CSGenioAequip.FldFrequenc, typeof(decimal), array : "FreqEmpr"),
			new TableSearchColumn("ValWarndt", CSGenioAlendi.FldWarndt, typeof(DateTime?)),
			new TableSearchColumn("ValEnd", CSGenioAlendi.FldEnd, typeof(DateTime?)),
			new TableSearchColumn("ValObservat", CSGenioAlendi.FldObservat, typeof(string))
		];
	}
}
