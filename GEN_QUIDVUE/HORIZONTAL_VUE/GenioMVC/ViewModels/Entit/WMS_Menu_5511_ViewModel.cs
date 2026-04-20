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

namespace GenioMVC.ViewModels.Entit
{
	public class WMS_Menu_5511_ViewModel : MenuListViewModel<Models.Entit>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<WMS_Menu_5511_RowViewModel> Menu { get; set; }

		[JsonIgnore]
		public override TableManagementMode ViewsManagementMode => TableManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "entit";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "7c66b6d5-d903-4719-bd1e-67b5650e047d";

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
				// Limit "SC"
				conditions.Equal(CSGenioAentit.FldManufact, "1");

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
				if (Navigation.CheckKey("entit.manufact"))
					conds.Equal(CSGenioAentit.FldManufact, Navigation.GetValue("entit.manufact"));

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
// USE /[MANUAL WMS LIST_LIMITS 5511]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("entit", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML5511");
			conditions.Equal(CSGenioAentit.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldZzstate, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldRegistra, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldIban, CSGenioAentit.FldBuilding, CSGenioAentit.FldStreet, CSGenioAentit.FldTown, CSGenioAentit.FldCounty, CSGenioAentit.FldState, CSGenioAentit.FldPobox, CSGenioAentit.FldPostalco, CSGenioAentit.FldTelephon, CSGenioAentit.FldFax, CSGenioAentit.FldWebsite, CSGenioAentit.FldPerson, CSGenioAentit.FldContact, CSGenioAentit.FldManufact, CSGenioAentit.FldFounded, CSGenioAentit.FldFirstfacilitie, CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAentit.FldLastfacilitie, CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAentit.FldLanguage, CSGenioAentit.FldCurrency, CSGenioAentit.FldOwner, CSGenioAentit.FldCarrier, CSGenioAentit.FldSupplier };

			ListingMVC<CSGenioAentit> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
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
		public WMS_Menu_5511_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_5511_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_5511_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_5511_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public WMS_Menu_5511_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXT, Resources.Resources.LEGAL_NAME42902, 30, 0, true),
				new Exports.QColumn(CSGenioAentit.FldInitials, FieldType.TEXT, Resources.Resources.COMPANY_INITIALS56204, 10, 0, true),
				new Exports.QColumn(CSGenioAentit.FldRegistra, FieldType.TEXT, Resources.Resources.LEGAL_REGISTRATION04413, 20, 0, true),
				new Exports.QColumn(CSGenioAentit.FldTaxnumbe, FieldType.TEXT, Resources.Resources.VAT_NUMBER24236, 20, 0, true),
				new Exports.QColumn(CSGenioAentit.FldEmail, FieldType.TEXT, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioAentit.FldPhonenum, FieldType.TEXT, Resources.Resources.PHONE_NUMBER20774, 20, 0, true),
				new Exports.QColumn(CSGenioAentit.FldIban, FieldType.TEXT, Resources.Resources.IBAN__INTERNATIONAL_45066, 25, 0, false),
				new Exports.QColumn(CSGenioAentit.FldBuilding, FieldType.TEXT, Resources.Resources.BUILDING_HOUSE_NUMBE20738, 10, 0, false),
				new Exports.QColumn(CSGenioAentit.FldStreet, FieldType.TEXT, Resources.Resources.STREET44324, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldTown, FieldType.TEXT, Resources.Resources.TOWN_CITY16259, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldCounty, FieldType.TEXT, Resources.Resources.COUNTY_PROVINCE34285, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldState, FieldType.TEXT, Resources.Resources.STATE_PROVINCE28516, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldPobox, FieldType.TEXT, Resources.Resources.POST_OFFICE_BOX06223, 5, 0, false),
				new Exports.QColumn(CSGenioAentit.FldPostalco, FieldType.TEXT, Resources.Resources.ZIP_POSTAL_CODE55613, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldTelephon, FieldType.TEXT, Resources.Resources.TELEPHONE28697, 20, 0, false),
				new Exports.QColumn(CSGenioAentit.FldFax, FieldType.TEXT, Resources.Resources.FAX08532, 20, 0, false),
				new Exports.QColumn(CSGenioAentit.FldWebsite, FieldType.TEXT, Resources.Resources.WEB_SITE06263, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldPerson, FieldType.TEXT, Resources.Resources.PERSON_DEPARTMENT_TO28777, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldContact, FieldType.TEXT, Resources.Resources.CONTACT_TELEPHONE_NU12694, 20, 0, false),
				new Exports.QColumn(CSGenioAentit.FldManufact, FieldType.LOGIC, Resources.Resources.MANUFACTURER50759, 1, 0, false),
				new Exports.QColumn(CSGenioAentit.FldFounded, FieldType.DATE, Resources.Resources.FOUNDED_IN54120, 8, 0, false),
				new Exports.QColumn(CSGenioAfaci1.FldName, FieldType.TEXT, Resources.Resources.FACILITY_NAME19514, 30, 0, false),
				new Exports.QColumn(CSGenioAfaci2.FldName, FieldType.TEXT, Resources.Resources.FACILITY_NAME19514, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldLanguage, FieldType.TEXT, Resources.Resources.LANGUAGE16872, 2, 0, false),
				new Exports.QColumn(CSGenioAentit.FldCurrency, FieldType.TEXT, Resources.Resources.CURRENCY13881, 3, 0, false),
				new Exports.QColumn(CSGenioAentit.FldOwner, FieldType.LOGIC, Resources.Resources.OWNER09558, 1, 0, true),
				new Exports.QColumn(CSGenioAentit.FldCarrier, FieldType.LOGIC, Resources.Resources.CARRIER64855, 1, 0, true),
				new Exports.QColumn(CSGenioAentit.FldSupplier, FieldType.LOGIC, Resources.Resources.SUPPLIER17230, 1, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAentit> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAentit> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

			Menu ??= new TablePartial<WMS_Menu_5511_RowViewModel>();
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

			// Limitations
			if (isToExport)
			{
				// EPH
				crs = Models.Entit.AddEPH<CSGenioAentit>(ref u, crs, "ML5511");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAentit.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ENTIT", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAentit.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_entit");
				Navigation.DestroyEntry("QMVC_POS_RECORD_entit");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Entit.AddEPH<CSGenioAentit>(ref u, null, "ML5511"));
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
			ListingMVC<CSGenioAentit> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAentit> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAentit> listing = null;

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
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAentit> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<WMS_Menu_5511_RowViewModel>();

			CriteriaSet wms_menu_5511Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ENTIT.NAME", new OrderedDictionary());
			allSortOrders["ENTIT.NAME"].Add("ENTIT.NAME", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "entit", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldZzstate, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldRegistra, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldIban, CSGenioAentit.FldBuilding, CSGenioAentit.FldStreet, CSGenioAentit.FldTown, CSGenioAentit.FldCounty, CSGenioAentit.FldState, CSGenioAentit.FldPobox, CSGenioAentit.FldPostalco, CSGenioAentit.FldTelephon, CSGenioAentit.FldFax, CSGenioAentit.FldWebsite, CSGenioAentit.FldPerson, CSGenioAentit.FldContact, CSGenioAentit.FldManufact, CSGenioAentit.FldFounded, CSGenioAentit.FldFirstfacilitie, CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAentit.FldLastfacilitie, CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAentit.FldLanguage, CSGenioAentit.FldCurrency, CSGenioAentit.FldOwner, CSGenioAentit.FldCarrier, CSGenioAentit.FldSupplier };

			// List of column names that should display totalized (aggregated) values.
			List<string> totalizerColumns = [];
			List<FieldRef> fieldsWithTotalizers = [.. fields.Where(field => totalizerColumns.Contains(field.FullName))];

			FieldRef firstVisibleColumn = null;
			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("entit", "name");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAentit model_limit_area = new CSGenioAentit(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML5511");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "SC"
			//Current Area = "ENTIT"
			//1st Area Limit: "ENTIT"
			//1st Area Field: "MANUFACT"
			//1st Area Value: "1"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.SC;
				limit.NaoAplicaSeNulo = false;
				CSGenioAentit model_limit_area = new CSGenioAentit(m_userContext.User);
				string limit_field = "manufact", limit_field_value = "1";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(wms_menu_5511Conds);
			wms_menu_5511Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 5511]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAentit>(m_userContext, false, ref wms_menu_5511Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML5511", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 5511]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 5511]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_entit");
				Navigation.DestroyEntry("QMVC_POS_RECORD_entit");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAentit.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_5511Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(m_userContext, distinct, wms_menu_5511Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML5511", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapWMS_Menu_5511(listing);

				Menu.Identifier = "ML5511";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML5511";

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

		private List<WMS_Menu_5511_RowViewModel> MapWMS_Menu_5511(ListingMVC<CSGenioAentit> Qlisting)
		{
			List<WMS_Menu_5511_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_5511(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAentit row
		/// to a WMS_Menu_5511_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private WMS_Menu_5511_RowViewModel MapWMS_Menu_5511(CSGenioAentit row)
		{
			var model = new WMS_Menu_5511_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entit":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "faci1":
						model.Faci1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "faci2":
						model.Faci2.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAentit> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Entit m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Entit m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_5511]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials", "Entit.ValRegistra", "Entit.ValTaxnumbe", "Entit.ValEmail", "Entit.ValPhonenum", "Entit.ValIban", "Entit.ValBuilding", "Entit.ValStreet", "Entit.ValTown", "Entit.ValCounty", "Entit.ValState", "Entit.ValPobox", "Entit.ValPostalco", "Entit.ValTelephon", "Entit.ValFax", "Entit.ValWebsite", "Entit.ValPerson", "Entit.ValContact", "Entit.ValManufact", "Entit.ValFounded", "Faci1", "Faci1.ValName", "Faci2", "Faci2.ValName", "Entit.ValLanguage", "Entit.ValCurrency", "Entit.ValOwner", "Entit.ValCarrier", "Entit.ValSupplier", "Entit.ValFirstfacilitie", "Entit.ValLastfacilitie"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValName", CSGenioAentit.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValInitials", CSGenioAentit.FldInitials, typeof(string)),
			new TableSearchColumn("ValRegistra", CSGenioAentit.FldRegistra, typeof(string)),
			new TableSearchColumn("ValTaxnumbe", CSGenioAentit.FldTaxnumbe, typeof(string)),
			new TableSearchColumn("ValEmail", CSGenioAentit.FldEmail, typeof(string)),
			new TableSearchColumn("ValPhonenum", CSGenioAentit.FldPhonenum, typeof(string)),
			new TableSearchColumn("ValIban", CSGenioAentit.FldIban, typeof(string), visible : false),
			new TableSearchColumn("ValBuilding", CSGenioAentit.FldBuilding, typeof(string), visible : false),
			new TableSearchColumn("ValStreet", CSGenioAentit.FldStreet, typeof(string), visible : false),
			new TableSearchColumn("ValTown", CSGenioAentit.FldTown, typeof(string), visible : false),
			new TableSearchColumn("ValCounty", CSGenioAentit.FldCounty, typeof(string), visible : false),
			new TableSearchColumn("ValState", CSGenioAentit.FldState, typeof(string), visible : false),
			new TableSearchColumn("ValPobox", CSGenioAentit.FldPobox, typeof(string), visible : false),
			new TableSearchColumn("ValPostalco", CSGenioAentit.FldPostalco, typeof(string), visible : false),
			new TableSearchColumn("ValTelephon", CSGenioAentit.FldTelephon, typeof(string), visible : false),
			new TableSearchColumn("ValFax", CSGenioAentit.FldFax, typeof(string), visible : false),
			new TableSearchColumn("ValWebsite", CSGenioAentit.FldWebsite, typeof(string), visible : false),
			new TableSearchColumn("ValPerson", CSGenioAentit.FldPerson, typeof(string), visible : false),
			new TableSearchColumn("ValContact", CSGenioAentit.FldContact, typeof(string), visible : false),
			new TableSearchColumn("ValManufact", CSGenioAentit.FldManufact, typeof(bool), visible : false),
			new TableSearchColumn("ValFounded", CSGenioAentit.FldFounded, typeof(DateTime?), visible : false),
			new TableSearchColumn("Faci1_ValName", CSGenioAfaci1.FldName, typeof(string), visible : false),
			new TableSearchColumn("Faci2_ValName", CSGenioAfaci2.FldName, typeof(string), visible : false),
			new TableSearchColumn("ValLanguage", CSGenioAentit.FldLanguage, typeof(string), visible : false),
			new TableSearchColumn("ValCurrency", CSGenioAentit.FldCurrency, typeof(string), visible : false),
			new TableSearchColumn("ValOwner", CSGenioAentit.FldOwner, typeof(bool)),
			new TableSearchColumn("ValCarrier", CSGenioAentit.FldCarrier, typeof(bool)),
			new TableSearchColumn("ValSupplier", CSGenioAentit.FldSupplier, typeof(bool)),
		];
	}
}
