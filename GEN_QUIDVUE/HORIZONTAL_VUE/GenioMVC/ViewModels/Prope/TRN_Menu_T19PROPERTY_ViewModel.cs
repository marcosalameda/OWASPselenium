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

namespace GenioMVC.ViewModels.Prope
{
	public class TRN_Menu_T19PROPERTY_ViewModel : MenuListViewModel<Models.Prope>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<TRN_Menu_T19PROPERTY_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "prope";

		/// <inheritdoc/>
		public override string Uuid => "c95ccfe6-3b62-4e44-91b5-55b24c2e14cd";

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
// USE /[MANUAL TRN LIST_LIMITS T19PROPERTY]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("prope", user, "TRN");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "MLT19PROPERTY");
			conditions.Equal(CSGenioAprope.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAprope.FldCodprope, CSGenioAprope.FldZzstate, CSGenioAprope.FldTitle, CSGenioAprope.FldPrice, CSGenioAprope.FldPhoto, CSGenioAprope.FldCodagent, CSGenioAagent.FldCodagent, CSGenioAagent.FldName, CSGenioAprope.FldSize, CSGenioAprope.FldBathrms, CSGenioAprope.FldYear, CSGenioAprope.FldDescript, CSGenioAprope.FldCodcity, CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAprope.FldBuildtyp, CSGenioAprope.FldTypology, CSGenioAprope.FldOrder, CSGenioAprope.FldBuildage };

			ListingMVC<CSGenioAprope> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public TRN_Menu_T19PROPERTY_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="TRN_Menu_T19PROPERTY_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TRN_Menu_T19PROPERTY_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TRN_Menu_T19PROPERTY_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public TRN_Menu_T19PROPERTY_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAprope.FldTitle, FieldType.TEXT, Resources.Resources.TITLE21885, 30, 0, true),
				new Exports.QColumn(CSGenioAprope.FldPrice, FieldType.CURRENCY, Resources.Resources.PRICE06900, 12, 0, true),
				!ajaxRequest ? new Exports.QColumn(CSGenioAprope.FldPhoto, FieldType.IMAGE, Resources.Resources.MAIN_PHOTO18723, 3, 1, true):null,
				new Exports.QColumn(CSGenioAagent.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAprope.FldSize, FieldType.NUMERIC, Resources.Resources.SIZE__M2_57059, 15, 0, true),
				new Exports.QColumn(CSGenioAprope.FldBathrms, FieldType.NUMERIC, Resources.Resources.NUMBER_OF_BATHROOMS64857, 2, 0, true),
				new Exports.QColumn(CSGenioAprope.FldYear, FieldType.TEXT, Resources.Resources.YEAR_BUILT55277, 30, 0, true),
				new Exports.QColumn(CSGenioAprope.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 0, true),
				new Exports.QColumn(CSGenioAcity.FldCity, FieldType.TEXT, Resources.Resources.CITY42505, 30, 0, true),
				new Exports.QColumn(CSGenioAprope.FldBuildtyp, FieldType.ARRAY_TEXT, Resources.Resources.BUILDING_TYPE57152, 1, 0, true, "buildtyp"),
				new Exports.QColumn(CSGenioAprope.FldTypology, FieldType.ARRAY_NUMERIC, Resources.Resources.TYPOLOGY11991, 1, 0, true, "aparttyp"),
				new Exports.QColumn(CSGenioAprope.FldOrder, FieldType.NUMERIC, Resources.Resources.ORDER39632, 15, 0, true),
				new Exports.QColumn(CSGenioAprope.FldBuildage, FieldType.NUMERIC, Resources.Resources.BUILDING_AGE27311, 8, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAprope> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAprope> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<TRN_Menu_T19PROPERTY_RowViewModel>();
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
				crs = Models.Prope.AddEPH<CSGenioAprope>(ref u, crs, "MLT19PROPERTY");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAprope.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROPE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAprope.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_prope");
				Navigation.DestroyEntry("QMVC_POS_RECORD_prope");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Prope.AddEPH<CSGenioAprope>(ref u, null, "MLT19PROPERTY"));
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
			ListingMVC<CSGenioAprope> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAprope> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAprope> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAprope> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
                new("PageId", "TRN.T19PROPERTY"),
                new("PageType", "menu")
            ]), "ms", "Time to load the page."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<TRN_Menu_T19PROPERTY_RowViewModel>();

				CriteriaSet trn_menu_t19propertyConds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PROPE.TITLE", new OrderedDictionary());
				allSortOrders["PROPE.TITLE"].Add("PROPE.TITLE", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "prope", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAprope.FldTitle), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAprope.FldCodprope, CSGenioAprope.FldZzstate, CSGenioAprope.FldTitle, CSGenioAprope.FldPrice, CSGenioAprope.FldPhoto, CSGenioAprope.FldCodagent, CSGenioAagent.FldCodagent, CSGenioAagent.FldName, CSGenioAprope.FldSize, CSGenioAprope.FldBathrms, CSGenioAprope.FldYear, CSGenioAprope.FldDescript, CSGenioAprope.FldCodcity, CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAprope.FldBuildtyp, CSGenioAprope.FldTypology, CSGenioAprope.FldOrder, CSGenioAprope.FldBuildage };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("prope", "title");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAprope model_limit_area = new CSGenioAprope(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLT19PROPERTY");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(trn_menu_t19propertyConds);
				trn_menu_t19propertyConds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TRN OVERRQ T19PROPERTY]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAprope>(m_userContext, false, trn_menu_t19propertyConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLT19PROPERTY", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TRN OVERRQLSTEXP T19PROPERTY]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL TRN OVERRQLIST T19PROPERTY]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_prope");
					Navigation.DestroyEntry("QMVC_POS_RECORD_prope");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAprope.GetInformation(), QMVC_POS_RECORD, sorts, trn_menu_t19propertyConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAprope> listing = Models.ModelBase.Where<CSGenioAprope>(m_userContext, distinct, trn_menu_t19propertyConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLT19PROPERTY", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapTRN_Menu_T19PROPERTY(listing);

					Menu.Identifier = "MLT19PROPERTY";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "MLT19PROPERTY";

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

		private List<TRN_Menu_T19PROPERTY_RowViewModel> MapTRN_Menu_T19PROPERTY(ListingMVC<CSGenioAprope> Qlisting)
		{
			List<TRN_Menu_T19PROPERTY_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTRN_Menu_T19PROPERTY(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAprope row
		/// to a TRN_Menu_T19PROPERTY_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private TRN_Menu_T19PROPERTY_RowViewModel MapTRN_Menu_T19PROPERTY(CSGenioAprope row)
		{
			var model = new TRN_Menu_T19PROPERTY_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "prope":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "agent":
						model.Agent.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "city":
						model.City.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAprope> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Prope m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Prope m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TRN_MENU_T19PROPERTY]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Prope", "Prope.ValCodprope", "Prope.ValZzstate", "Prope.ValTitle", "Prope.ValPrice", "Prope.ValPhoto", "Agent", "Agent.ValName", "Prope.ValSize", "Prope.ValBathrms", "Prope.ValYear", "Prope.ValDescript", "City", "City.ValCity", "Prope.ValBuildtyp", "Prope.ValTypology", "Prope.ValOrder", "Prope.ValBuildage", "Prope.ValCodagent", "Prope.ValCodcity"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValTitle", CSGenioAprope.FldTitle, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValPrice", CSGenioAprope.FldPrice, typeof(decimal?)),
			new TableSearchColumn("Agent_ValName", CSGenioAagent.FldName, typeof(string)),
			new TableSearchColumn("ValSize", CSGenioAprope.FldSize, typeof(decimal?)),
			new TableSearchColumn("ValBathrms", CSGenioAprope.FldBathrms, typeof(decimal?)),
			new TableSearchColumn("ValYear", CSGenioAprope.FldYear, typeof(string)),
			new TableSearchColumn("ValDescript", CSGenioAprope.FldDescript, typeof(string)),
			new TableSearchColumn("City_ValCity", CSGenioAcity.FldCity, typeof(string)),
			new TableSearchColumn("ValBuildtyp", CSGenioAprope.FldBuildtyp, typeof(string), array : "buildtyp"),
			new TableSearchColumn("ValTypology", CSGenioAprope.FldTypology, typeof(decimal), array : "aparttyp"),
			new TableSearchColumn("ValOrder", CSGenioAprope.FldOrder, typeof(decimal?)),
			new TableSearchColumn("ValBuildage", CSGenioAprope.FldBuildage, typeof(decimal?)),
		];
		protected void SetTicketToImageFields(Models.Prope row)
		{
			if (row == null)
				return;

			row.ValPhotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPE, CSGenioAprope.FldPhoto.Field, null, row.ValCodprope);
		}
	}
}
