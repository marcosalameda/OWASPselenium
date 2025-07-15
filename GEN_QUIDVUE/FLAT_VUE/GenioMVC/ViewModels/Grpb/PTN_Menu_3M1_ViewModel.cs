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

namespace GenioMVC.ViewModels.Grpb
{
	public class PTN_Menu_3M1_ViewModel : MenuListViewModel<Models.Grpb>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<PTN_Menu_3M1_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "grpb";

		/// <inheritdoc/>
		public override string Uuid => "fa354599-4a30-4174-adb2-39d65e17489c";

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
// USE /[MANUAL PTN LIST_LIMITS 3M1]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("grpb", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML3M1");
			conditions.Equal(CSGenioAgrpb.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldZzstate, CSGenioAgrpb.FldName };

			ListingMVC<CSGenioAgrpb> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public PTN_Menu_3M1_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3M1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_3M1_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3M1_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_3M1_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAgrpb.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAgrpb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAgrpb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<PTN_Menu_3M1_RowViewModel>();
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
				crs = Models.Grpb.AddEPH<CSGenioAgrpb>(ref u, crs, "ML3M1");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAgrpb.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("GRPB", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAgrpb.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_grpb");
				Navigation.DestroyEntry("QMVC_POS_RECORD_grpb");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Grpb.AddEPH<CSGenioAgrpb>(ref u, null, "ML3M1"));
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
			ListingMVC<CSGenioAgrpb> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAgrpb> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAgrpb> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAgrpb> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<PTN_Menu_3M1_RowViewModel>();

				CriteriaSet ptn_menu_3m1Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "grpb", allSortOrders);


				FieldRef[] fields = new FieldRef[] { CSGenioAgrpb.FldCodgrpb, CSGenioAgrpb.FldZzstate, CSGenioAgrpb.FldName };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("grpb", "name");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAgrpb model_limit_area = new CSGenioAgrpb(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3M1");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ptn_menu_3m1Conds);
				ptn_menu_3m1Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 3M1]/

				List<string> listOfTablesBelow = ["tblb"];

				bool distinct = false;
				int nDistinctSearchTables = tableConfig.SearchFilters.SelectMany(sf =>
					sf.Conditions.Where(cond =>
						_searchableColumnsRefs.ContainsKey(cond.Field)
							? listOfTablesBelow.Contains(_searchableColumnsRefs[cond.Field].Area)
							: false
					)
				).Distinct().Count();

				if (nDistinctSearchTables == 1)
					distinct = true;
				else if (nDistinctSearchTables > 1)
					tableReload = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAgrpb>(m_userContext, false, ptn_menu_3m1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3M1", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 3M1]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL PTN OVERRQLIST 3M1]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_grpb");
					Navigation.DestroyEntry("QMVC_POS_RECORD_grpb");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAgrpb.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_3m1Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAgrpb> listing = Models.ModelBase.Where<CSGenioAgrpb>(m_userContext, distinct, ptn_menu_3m1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3M1", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					var rowKeys = listing.Rows.Select(r => r.QPrimaryKey);
					var belowRows = GetRecordsFromTablesBelow(rowKeys);
					Menu.Elements = MapPTN_Menu_3M1(listing, belowRows);

					Menu.Identifier = "ML3M1";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML3M1";

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

				if (nDistinctSearchTables > 1)
					throw new BusinessException(Resources.Resources.NAO_E_POSSIVEL_EFETU17380, "PTN_Menu_3M1_ViewModel.Load", "Error: MultipleFiltersTablesBelow", null);
		}

		private List<PTN_Menu_3M1_RowViewModel> MapPTN_Menu_3M1(ListingMVC<CSGenioAgrpb> Qlisting, System.Collections.Hashtable tableBelowRows = null)
		{
			List<PTN_Menu_3M1_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_3M1(row, tableBelowRows));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAgrpb row
		/// to a PTN_Menu_3M1_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_3M1_RowViewModel MapPTN_Menu_3M1(CSGenioAgrpb row, System.Collections.Hashtable tableBelowRows = null)
		{
			var model = new PTN_Menu_3M1_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "grpb":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			// TBLB columns
			if ((bool)tableBelowRows?.ContainsKey("tblb"))
			{
				var rowsByKey = tableBelowRows["tblb"] as Dictionary<string, List<CSGenioAtblb>>;
				if (rowsByKey?.TryGetValue(row.QPrimaryKey, out List<CSGenioAtblb> rows) == true)
				{
					model.TblbValBool = [.. rows.Where(r => !Field.isEmptyValue(r.ValBool, FieldType.LOGIC.GetFormatting())).Select(r => ViewModelConversion.ToLogic(r.ValBool))];
					model.TblbValCurdec = [.. rows.Where(r => !Field.isEmptyValue(r.ValCurdec, FieldType.CURRENCY.GetFormatting())).Select(r => ViewModelConversion.ToNumeric(r.ValCurdec))];
					model.TblbValCurint = [.. rows.Where(r => !Field.isEmptyValue(r.ValCurint, FieldType.CURRENCY.GetFormatting())).Select(r => ViewModelConversion.ToNumeric(r.ValCurint))];
					model.TblbValDate = [.. rows.Where(r => !Field.isEmptyValue(r.ValDate, FieldType.DATE.GetFormatting())).Select(r => ViewModelConversion.ToDateTime(r.ValDate))];
					model.TblbValDatetm = [.. rows.Where(r => !Field.isEmptyValue(r.ValDatetm, FieldType.DATETIME.GetFormatting())).Select(r => ViewModelConversion.ToDateTime(r.ValDatetm))];
					model.TblbValDatets = [.. rows.Where(r => !Field.isEmptyValue(r.ValDatets, FieldType.DATETIMESECONDS.GetFormatting())).Select(r => ViewModelConversion.ToDateTime(r.ValDatets))];
					model.TblbValEnumn = [.. rows.Where(r => !Field.isEmptyValue(r.ValEnumn, FieldType.ARRAY_NUMERIC.GetFormatting())).Select(r => ViewModelConversion.ToNumeric(r.ValEnumn))];
					model.TblbValEnumt = [.. rows.Where(r => !Field.isEmptyValue(r.ValEnumt, FieldType.ARRAY_TEXT.GetFormatting())).Select(r => ViewModelConversion.ToString(r.ValEnumt))];
					model.TblbValNumdec = [.. rows.Where(r => !Field.isEmptyValue(r.ValNumdec, FieldType.NUMERIC.GetFormatting())).Select(r => ViewModelConversion.ToNumeric(r.ValNumdec))];
					model.TblbValNumint = [.. rows.Where(r => !Field.isEmptyValue(r.ValNumint, FieldType.NUMERIC.GetFormatting())).Select(r => ViewModelConversion.ToNumeric(r.ValNumint))];
					model.TblbValText = [.. rows.Where(r => !Field.isEmptyValue(r.ValText, FieldType.TEXT.GetFormatting())).Select(r => ViewModelConversion.ToString(r.ValText))];
					model.TblbValTextml = [.. rows.Where(r => !Field.isEmptyValue(r.ValTextml, FieldType.MEMO.GetFormatting())).Select(r => ViewModelConversion.ToString(r.ValTextml))];
					model.TblbValTimehm = [.. rows.Where(r => !Field.isEmptyValue(r.ValTimehm, FieldType.TIME_HOURS.GetFormatting())).Select(r => ViewModelConversion.ToString(r.ValTimehm))];
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
		private void SetDocumentFields(ListingMVC<CSGenioAgrpb> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Grpb m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Grpb m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_3M1]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Grpb", "Grpb.ValCodgrpb", "Grpb.ValZzstate", "Grpb.ValName", "Tblb.ValBool", "Tblb.ValCurdec", "Tblb.ValCurint", "Tblb.ValDate", "Tblb.ValDatetm", "Tblb.ValDatets", "Tblb.ValEnumn", "Tblb.ValEnumt", "Tblb.ValNumdec", "Tblb.ValNumint", "Tblb.ValText", "Tblb.ValTextml", "Tblb.ValTimehm"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValName", CSGenioAgrpb.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValBool", CSGenioAtblb.FldBool, typeof(bool)),
			new TableSearchColumn("ValCurdec", CSGenioAtblb.FldCurdec, typeof(decimal?)),
			new TableSearchColumn("ValCurint", CSGenioAtblb.FldCurint, typeof(decimal?)),
			new TableSearchColumn("ValDate", CSGenioAtblb.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDatetm", CSGenioAtblb.FldDatetm, typeof(DateTime?)),
			new TableSearchColumn("ValDatets", CSGenioAtblb.FldDatets, typeof(DateTime?)),
			new TableSearchColumn("ValEnumn", CSGenioAtblb.FldEnumn, typeof(decimal), array : "typen"),
			new TableSearchColumn("ValEnumt", CSGenioAtblb.FldEnumt, typeof(string), array : "typet"),
			new TableSearchColumn("ValNumdec", CSGenioAtblb.FldNumdec, typeof(decimal?)),
			new TableSearchColumn("ValNumint", CSGenioAtblb.FldNumint, typeof(decimal?)),
			new TableSearchColumn("ValText", CSGenioAtblb.FldText, typeof(string)),
			new TableSearchColumn("ValTextml", CSGenioAtblb.FldTextml, typeof(string)),
			new TableSearchColumn("ValTimehm", CSGenioAtblb.FldTimehm, typeof(string)),
		];
		private static readonly Dictionary<string, FieldRef> _searchableColumnsRefs = new()
        {
            { "GRPB.NAME", CSGenioAgrpb.FldName },
            { "TBLB.BOOL", CSGenioAtblb.FldBool },
            { "TBLB.CURDEC", CSGenioAtblb.FldCurdec },
            { "TBLB.CURINT", CSGenioAtblb.FldCurint },
            { "TBLB.DATE", CSGenioAtblb.FldDate },
            { "TBLB.DATETM", CSGenioAtblb.FldDatetm },
            { "TBLB.DATETS", CSGenioAtblb.FldDatets },
            { "TBLB.ENUMN", CSGenioAtblb.FldEnumn },
            { "TBLB.ENUMT", CSGenioAtblb.FldEnumt },
            { "TBLB.NUMDEC", CSGenioAtblb.FldNumdec },
            { "TBLB.NUMINT", CSGenioAtblb.FldNumint },
            { "TBLB.TEXT", CSGenioAtblb.FldText },
            { "TBLB.TEXTML", CSGenioAtblb.FldTextml },
            { "TBLB.TIMEHM", CSGenioAtblb.FldTimehm },
        };

		/// <summary>
		/// Retrieves values from the database for the related tables. Each table fetches all necessary fields required for visualization in the table
		/// </summary>
		/// <param name="keys">Current row keys</param>
		/// <returns></returns>
		private System.Collections.Hashtable GetRecordsFromTablesBelow(IEnumerable<string> keys)
		{
			System.Collections.Hashtable result = [];
			if (keys?.Any() == false)
				return result;

			// TBLB columns
			{
				var criteriaSetTBelow = CriteriaSet.And().In(CSGenioAtblb.FldFkey1, keys).Equal(CSGenioAtblb.FldZzstate, 0);
				FieldRef[] fields = [CSGenioAtblb.FldCodtblb, CSGenioAtblb.FldFkey1, CSGenioAtblb.FldBool, CSGenioAtblb.FldCurdec, CSGenioAtblb.FldCurint, CSGenioAtblb.FldDate, CSGenioAtblb.FldDatetm, CSGenioAtblb.FldDatets, CSGenioAtblb.FldEnumn, CSGenioAtblb.FldEnumt, CSGenioAtblb.FldNumdec, CSGenioAtblb.FldNumint, CSGenioAtblb.FldText, CSGenioAtblb.FldTextml, CSGenioAtblb.FldTimehm];
				var listing = Models.ModelBase.Where<CSGenioAtblb>(m_userContext, false, criteriaSetTBelow, numRegs: -1, fields: fields, identifier: "ML3M1_TBLB");
				result.Add("tblb", listing.Rows.GroupBy(row => row.ValFkey1).ToDictionary(group => group.Key, group => group.ToList()));
			}
			return result;
		}
	}
}
