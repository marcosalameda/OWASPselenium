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

namespace GenioMVC.ViewModels.Tblb
{
	public class PTN_Menu_3141_ViewModel : MenuListViewModel<Models.Tblb>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<PTN_Menu_3141_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.NonPersistent;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "tblb";

		/// <inheritdoc/>
		public override string Uuid => "b91b9161-2846-47fc-b5b4-08511357ea57";

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
// USE /[MANUAL PTN LIST_LIMITS 3141]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("tblb", user, "PTN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML3141");
			conditions.Equal(CSGenioAtblb.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAtblb.FldCodtblb, CSGenioAtblb.FldZzstate, CSGenioAtblb.FldText, CSGenioAtblb.FldTextml, CSGenioAtblb.FldNumint, CSGenioAtblb.FldNumdec, CSGenioAtblb.FldCurint, CSGenioAtblb.FldCurdec, CSGenioAtblb.FldBool, CSGenioAtblb.FldDate, CSGenioAtblb.FldDatetm, CSGenioAtblb.FldDatets, CSGenioAtblb.FldTimehm, CSGenioAtblb.FldEnumt, CSGenioAtblb.FldEnumn };

			ListingMVC<CSGenioAtblb> listing = new(fields, null, 1, 1, false, user, true, string.Empty, true);
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
		public PTN_Menu_3141_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3141_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public PTN_Menu_3141_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PTN_Menu_3141_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public PTN_Menu_3141_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAtblb.FldText, FieldType.TEXT, Resources.Resources.TEXT04938, 30, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldTextml, FieldType.MEMO, Resources.Resources.MULTILINE_TEXT38013, 30, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldNumint, FieldType.NUMERIC, Resources.Resources.NUMERIC__INTEGER_50289, 10, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldNumdec, FieldType.NUMERIC, Resources.Resources.NUMERIC__DECIMAL_36157, 10, 3, true),
				new Exports.QColumn(CSGenioAtblb.FldCurint, FieldType.CURRENCY, Resources.Resources.CURRENCY__INTERGER_21437, 10, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldCurdec, FieldType.CURRENCY, Resources.Resources.CURRENCY__DECIMAL_11718, 10, 2, true),
				new Exports.QColumn(CSGenioAtblb.FldBool, FieldType.LOGIC, Resources.Resources.BOOLEAN45002, 1, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldDate, FieldType.DATE, Resources.Resources.DATE18475, 8, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldDatetm, FieldType.DATETIME, Resources.Resources.DATETIME__MINUTES_59352, 16, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldDatets, FieldType.DATETIMESECONDS, Resources.Resources.DATETIME__SECONDS_49861, 19, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldTimehm, FieldType.TIME_HOURS, Resources.Resources.TIME__HOURS_MINUTES_01660, 5, 0, true),
				new Exports.QColumn(CSGenioAtblb.FldEnumt, FieldType.ARRAY_TEXT, Resources.Resources.ENUMERATION__TEXT_15855, 1, 0, true, "typet"),
				new Exports.QColumn(CSGenioAtblb.FldEnumn, FieldType.ARRAY_NUMERIC, Resources.Resources.ENUMERATION__NUMERIC44708, 1, 0, true, "typen"),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAtblb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAtblb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				new Exports.QColumn(CSGenioAtblb.FldText, FieldType.TEXT, Resources.Resources.TEXT04938, 50, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldTextml, FieldType.MEMO, Resources.Resources.MULTILINE_TEXT38013, 50, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldNumint, FieldType.NUMERIC, Resources.Resources.NUMERIC__INTEGER_50289, 10, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldNumdec, FieldType.NUMERIC, Resources.Resources.NUMERIC__DECIMAL_36157, 9, 3, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldCurint, FieldType.CURRENCY, Resources.Resources.CURRENCY__INTERGER_21437, 9, 2, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldCurdec, FieldType.CURRENCY, Resources.Resources.CURRENCY__DECIMAL_11718, 9, 4, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldBool, FieldType.LOGIC, Resources.Resources.BOOLEAN45002, 1, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldDate, FieldType.DATE, Resources.Resources.DATE18475, 8, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldDatetm, FieldType.DATETIME, Resources.Resources.DATETIME__MINUTES_59352, 16, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldDatets, FieldType.DATETIMESECONDS, Resources.Resources.DATETIME__SECONDS_49861, 19, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldTimehm, FieldType.TIME_HOURS, Resources.Resources.TIME__HOURS_MINUTES_01660, 5, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldEnumt, FieldType.ARRAY_TEXT, Resources.Resources.ENUMERATION__TEXT_15855, 1, 0, true, "typen"),
				new Exports.QColumn(CSGenioAtblb.FldEnumn, FieldType.ARRAY_NUMERIC, Resources.Resources.ENUMERATION__NUMERIC44708, 1, 0, true, "typen"),
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
				Menu = new TablePartial<PTN_Menu_3141_RowViewModel>();
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
				crs = Models.Tblb.AddEPH<CSGenioAtblb>(ref u, crs, "ML3141");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtblb.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("TBLB", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAtblb.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tblb");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tblb");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tblb.AddEPH<CSGenioAtblb>(ref u, null, "ML3141"));
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
			ListingMVC<CSGenioAtblb> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtblb> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAtblb> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtblb> Qlisting, ref CriteriaSet conditions)
		{
				User u = m_userContext.User;
				Menu = new TablePartial<PTN_Menu_3141_RowViewModel>();

				CriteriaSet ptn_menu_3141Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("TBLB.TEXT", new OrderedDictionary());
				allSortOrders["TBLB.TEXT"].Add("TBLB.TEXT", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "tblb", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtblb.FldText), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAtblb.FldCodtblb, CSGenioAtblb.FldZzstate, CSGenioAtblb.FldText, CSGenioAtblb.FldTextml, CSGenioAtblb.FldNumint, CSGenioAtblb.FldNumdec, CSGenioAtblb.FldCurint, CSGenioAtblb.FldCurdec, CSGenioAtblb.FldBool, CSGenioAtblb.FldDate, CSGenioAtblb.FldDatetm, CSGenioAtblb.FldDatets, CSGenioAtblb.FldTimehm, CSGenioAtblb.FldEnumt, CSGenioAtblb.FldEnumn };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("tblb", "text");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAtblb model_limit_area = new CSGenioAtblb(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3141");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ptn_menu_3141Conds);
				ptn_menu_3141Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 3141]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAtblb>(m_userContext, false, ptn_menu_3141Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3141", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 3141]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL PTN OVERRQLIST 3141]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tblb");
					Navigation.DestroyEntry("QMVC_POS_RECORD_tblb");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAtblb.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_3141Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAtblb> listing = Models.ModelBase.Where<CSGenioAtblb>(m_userContext, distinct, ptn_menu_3141Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3141", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapPTN_Menu_3141(listing);

					Menu.Identifier = "ML3141";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML3141";

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

		private List<PTN_Menu_3141_RowViewModel> MapPTN_Menu_3141(ListingMVC<CSGenioAtblb> Qlisting)
		{
			List<PTN_Menu_3141_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_3141(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAtblb row
		/// to a PTN_Menu_3141_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private PTN_Menu_3141_RowViewModel MapPTN_Menu_3141(CSGenioAtblb row)
		{
			var model = new PTN_Menu_3141_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tblb":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAtblb> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Tblb m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tblb m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_3141]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Tblb", "Tblb.ValCodtblb", "Tblb.ValZzstate", "Tblb.ValText", "Tblb.ValTextml", "Tblb.ValNumint", "Tblb.ValNumdec", "Tblb.ValCurint", "Tblb.ValCurdec", "Tblb.ValBool", "Tblb.ValDate", "Tblb.ValDatetm", "Tblb.ValDatets", "Tblb.ValTimehm", "Tblb.ValEnumt", "Tblb.ValEnumn", "Tblb.ValFkey1"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValText", CSGenioAtblb.FldText, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValTextml", CSGenioAtblb.FldTextml, typeof(string)),
			new TableSearchColumn("ValNumint", CSGenioAtblb.FldNumint, typeof(decimal?)),
			new TableSearchColumn("ValNumdec", CSGenioAtblb.FldNumdec, typeof(decimal?)),
			new TableSearchColumn("ValCurint", CSGenioAtblb.FldCurint, typeof(decimal?)),
			new TableSearchColumn("ValCurdec", CSGenioAtblb.FldCurdec, typeof(decimal?)),
			new TableSearchColumn("ValBool", CSGenioAtblb.FldBool, typeof(bool)),
			new TableSearchColumn("ValDate", CSGenioAtblb.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValDatetm", CSGenioAtblb.FldDatetm, typeof(DateTime?)),
			new TableSearchColumn("ValDatets", CSGenioAtblb.FldDatets, typeof(DateTime?)),
			new TableSearchColumn("ValTimehm", CSGenioAtblb.FldTimehm, typeof(string)),
			new TableSearchColumn("ValEnumt", CSGenioAtblb.FldEnumt, typeof(string), array : "typet"),
			new TableSearchColumn("ValEnumn", CSGenioAtblb.FldEnumn, typeof(decimal), array : "typen"),
		];
	}
}
