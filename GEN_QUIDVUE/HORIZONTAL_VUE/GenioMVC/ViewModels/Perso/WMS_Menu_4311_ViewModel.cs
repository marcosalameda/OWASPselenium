using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Perso
{
	public class WMS_Menu_4311_ViewModel : MenuListViewModel<Models.Perso>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<WMS_Menu_4311_RowViewModel> Menu { get; set; }

		[JsonIgnore]
		public override TableManagementMode ViewsManagementMode => TableManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "perso";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "41620bc2-3820-44b2-9922-4b85648ff0b5";

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
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL WMS LIST_LIMITS 4311]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("perso", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML4311");
			conditions.Equal(CSGenioAperso.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldZzstate, CSGenioAperso.FldName, CSGenioAperso.FldGender, CSGenioAperso.FldIdentifi, CSGenioAperso.FldPhoto, CSGenioAperso.FldDob, CSGenioAperso.FldEmail, CSGenioAperso.FldYear, CSGenioAperso.FldMonth, CSGenioAperso.FldTob };

			ListingMVC<CSGenioAperso> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public WMS_Menu_4311_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_4311_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_4311_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_4311_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public WMS_Menu_4311_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAperso.FldName, FieldType.TEXT, Resources.Resources.PERSON_NAME40980, 30, 0, true),
				new Exports.QColumn(CSGenioAperso.FldGender, FieldType.ARRAY_TEXT, Resources.Resources.GENDER44172, 1, 0, true, "Gender"),
				new Exports.QColumn(CSGenioAperso.FldIdentifi, FieldType.TEXT, Resources.Resources.IDENTIFICATION_NUMBE11999, 10, 0, true),
				new Exports.QColumn(CSGenioAperso.FldDob, FieldType.DATE, Resources.Resources.DATE_OF_BIRTH63058, 8, 0, true),
				new Exports.QColumn(CSGenioAperso.FldEmail, FieldType.TEXT, Resources.Resources.E_MAIL42251, 30, 0, true),
				new Exports.QColumn(CSGenioAperso.FldYear, FieldType.NUMERIC, Resources.Resources.YEAR61794, 4, 0, false),
				new Exports.QColumn(CSGenioAperso.FldMonth, FieldType.ARRAY_NUMERIC, Resources.Resources.MONTH46035, 2, 0, false, "Months"),
				new Exports.QColumn(CSGenioAperso.FldTob, FieldType.TIME_HOURS, Resources.Resources.TIME_OF_BIRTH04797, 5, 0, false),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAperso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAperso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

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
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<WMS_Menu_4311_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Perso.AddEPH<CSGenioAperso>(ref u, crs, "ML4311");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAperso.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PERSO", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAperso.FldZzstate, CSGenioAperso.FldCreatusr);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_perso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_perso");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Perso.AddEPH<CSGenioAperso>(ref u, null, "ML4311"));
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
			ListingMVC<CSGenioAperso> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAperso> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAperso> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAperso> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<WMS_Menu_4311_RowViewModel>();

			CriteriaSet wms_menu_4311Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PERSO.NAME", new OrderedDictionary());
			allSortOrders["PERSO.NAME"].Add("PERSO.NAME", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "perso", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAperso.FldName), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldZzstate, CSGenioAperso.FldName, CSGenioAperso.FldGender, CSGenioAperso.FldIdentifi, CSGenioAperso.FldPhoto, CSGenioAperso.FldDob, CSGenioAperso.FldEmail, CSGenioAperso.FldYear, CSGenioAperso.FldMonth, CSGenioAperso.FldTob };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("perso", "name");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAperso model_limit_area = new CSGenioAperso(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML4311");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(wms_menu_4311Conds);
			wms_menu_4311Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 4311]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAperso>(m_userContext, false, ref wms_menu_4311Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML4311", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 4311]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 4311]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_perso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_perso");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAperso.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_4311Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(m_userContext, distinct, wms_menu_4311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML4311", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapWMS_Menu_4311(listing);

				Menu.Identifier = "ML4311";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML4311";

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

		private List<WMS_Menu_4311_RowViewModel> MapWMS_Menu_4311(ListingMVC<CSGenioAperso> Qlisting)
		{
			List<WMS_Menu_4311_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_4311(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAperso row
		/// to a WMS_Menu_4311_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private WMS_Menu_4311_RowViewModel MapWMS_Menu_4311(CSGenioAperso row)
		{
			var model = new WMS_Menu_4311_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "perso":
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
		private void SetDocumentFields(ListingMVC<CSGenioAperso> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Perso m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Perso m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_4311]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName", "Perso.ValGender", "Perso.ValIdentifi", "Perso.ValPhoto", "Perso.ValDob", "Perso.ValEmail", "Perso.ValYear", "Perso.ValMonth", "Perso.ValTob"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValName", CSGenioAperso.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValGender", CSGenioAperso.FldGender, typeof(string), array : "Gender"),
			new TableSearchColumn("ValIdentifi", CSGenioAperso.FldIdentifi, typeof(string)),
			new TableSearchColumn("ValDob", CSGenioAperso.FldDob, typeof(DateTime?)),
			new TableSearchColumn("ValEmail", CSGenioAperso.FldEmail, typeof(string)),
			new TableSearchColumn("ValYear", CSGenioAperso.FldYear, typeof(decimal?), visible : false),
			new TableSearchColumn("ValMonth", CSGenioAperso.FldMonth, typeof(decimal), visible : false, array : "Months"),
			new TableSearchColumn("ValTob", CSGenioAperso.FldTob, typeof(string), visible : false),
		];
		protected void SetTicketToImageFields(Models.Perso row)
		{
			if (row == null)
				return;

			row.ValPhotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPERSO, CSGenioAperso.FldPhoto.Field, null, row.ValCodperso);
		}
	}
}
