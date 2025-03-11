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

namespace GenioMVC.ViewModels.Entit
{
	public class WMS_Menu_5211_ViewModel : MenuListViewModel<Models.Entit>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<WMS_Menu_5211_RowViewModel> Menu { get; set; }

		protected override TableViewsManagementMode ViewsManagementMode => TableViewsManagementMode.PersistOne;

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "entit";

		/// <inheritdoc/>
		public override string Uuid => "c507fd2e-3399-4cc1-ab05-02fd06f4746a";

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
				conditions.Equal(CSGenioAentit.FldSupplier, "1");

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
				if (Navigation.CheckKey("entit.supplier"))
					conds.Equal(CSGenioAentit.FldSupplier, Navigation.GetValue("entit.supplier"));

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
// USE /[MANUAL WMS LIST_LIMITS 5211]/

			return crs;
		}



		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("entit", user, "WMS");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML5211");
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
		public WMS_Menu_5211_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_5211_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public WMS_Menu_5211_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WMS_Menu_5211_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public WMS_Menu_5211_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXTO, Resources.Resources.LEGAL_NAME42902, 30, 0, true),
				new Exports.QColumn(CSGenioAentit.FldInitials, FieldType.TEXTO, Resources.Resources.COMPANY_INITIALS56204, 10, 0, true),
				new Exports.QColumn(CSGenioAentit.FldRegistra, FieldType.TEXTO, Resources.Resources.LEGAL_REGISTRATION04413, 20, 0, true),
				new Exports.QColumn(CSGenioAentit.FldTaxnumbe, FieldType.TEXTO, Resources.Resources.VAT_NUMBER24236, 20, 0, true),
				new Exports.QColumn(CSGenioAentit.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
				new Exports.QColumn(CSGenioAentit.FldPhonenum, FieldType.TEXTO, Resources.Resources.PHONE_NUMBER20774, 20, 0, true),
				new Exports.QColumn(CSGenioAentit.FldIban, FieldType.TEXTO, Resources.Resources.IBAN__INTERNATIONAL_45066, 25, 0, false),
				new Exports.QColumn(CSGenioAentit.FldBuilding, FieldType.TEXTO, Resources.Resources.BUILDING_HOUSE_NUMBE20738, 10, 0, false),
				new Exports.QColumn(CSGenioAentit.FldStreet, FieldType.TEXTO, Resources.Resources.STREET44324, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldTown, FieldType.TEXTO, Resources.Resources.TOWN_CITY16259, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldCounty, FieldType.TEXTO, Resources.Resources.COUNTY_PROVINCE34285, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldState, FieldType.TEXTO, Resources.Resources.STATE_PROVINCE28516, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldPobox, FieldType.TEXTO, Resources.Resources.POST_OFFICE_BOX06223, 5, 0, false),
				new Exports.QColumn(CSGenioAentit.FldPostalco, FieldType.TEXTO, Resources.Resources.ZIP_POSTAL_CODE55613, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldTelephon, FieldType.TEXTO, Resources.Resources.TELEPHONE28697, 20, 0, false),
				new Exports.QColumn(CSGenioAentit.FldFax, FieldType.TEXTO, Resources.Resources.FAX08532, 20, 0, false),
				new Exports.QColumn(CSGenioAentit.FldWebsite, FieldType.TEXTO, Resources.Resources.WEB_SITE06263, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldPerson, FieldType.TEXTO, Resources.Resources.PERSON_DEPARTMENT_TO28777, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldContact, FieldType.TEXTO, Resources.Resources.CONTACT_TELEPHONE_NU12694, 20, 0, false),
				new Exports.QColumn(CSGenioAentit.FldManufact, FieldType.LOGICO, Resources.Resources.MANUFACTURER50759, 1, 0, false),
				new Exports.QColumn(CSGenioAentit.FldFounded, FieldType.DATA, Resources.Resources.FOUNDED_IN54120, 8, 0, false),
				new Exports.QColumn(CSGenioAfaci1.FldName, FieldType.TEXTO, Resources.Resources.FACILITY_NAME19514, 30, 0, false),
				new Exports.QColumn(CSGenioAfaci2.FldName, FieldType.TEXTO, Resources.Resources.FACILITY_NAME19514, 30, 0, false),
				new Exports.QColumn(CSGenioAentit.FldLanguage, FieldType.TEXTO, Resources.Resources.LANGUAGE16872, 2, 0, false),
				new Exports.QColumn(CSGenioAentit.FldCurrency, FieldType.TEXTO, Resources.Resources.CURRENCY13881, 3, 0, false),
				new Exports.QColumn(CSGenioAentit.FldOwner, FieldType.TEXTO, Resources.Resources.OWNER09558, 1, 0, true),
				new Exports.QColumn(CSGenioAentit.FldCarrier, FieldType.LOGICO, Resources.Resources.CARRIER64855, 1, 0, true),
				new Exports.QColumn(CSGenioAentit.FldSupplier, FieldType.LOGICO, Resources.Resources.SUPPLIER17230, 1, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAentit> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAentit> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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
				Menu = new TablePartial<WMS_Menu_5211_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			if (isToExport)
			{
				// EPH
				crs = Models.Entit.AddEPH<CSGenioAentit>(ref u, crs, "ML5211");

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
					crs.Equals(Models.Entit.AddEPH<CSGenioAentit>(ref u, null, "ML5211"));
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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAentit> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "5211"),
				new("Module", "WMS")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<WMS_Menu_5211_RowViewModel>();

				CriteriaSet wms_menu_5211Conds = CriteriaSet.And();
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

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "entit", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldZzstate, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldRegistra, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldIban, CSGenioAentit.FldBuilding, CSGenioAentit.FldStreet, CSGenioAentit.FldTown, CSGenioAentit.FldCounty, CSGenioAentit.FldState, CSGenioAentit.FldPobox, CSGenioAentit.FldPostalco, CSGenioAentit.FldTelephon, CSGenioAentit.FldFax, CSGenioAentit.FldWebsite, CSGenioAentit.FldPerson, CSGenioAentit.FldContact, CSGenioAentit.FldManufact, CSGenioAentit.FldFounded, CSGenioAentit.FldFirstfacilitie, CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAentit.FldLastfacilitie, CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAentit.FldLanguage, CSGenioAentit.FldCurrency, CSGenioAentit.FldOwner, CSGenioAentit.FldCarrier, CSGenioAentit.FldSupplier };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					if (firstVisibleColumn == null)
						firstVisibleColumn = new FieldRef("entit", "name");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAentit model_limit_area = new CSGenioAentit(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML5211");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}

				// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
				// Limit origin: menu 

				//Limit type: "SC"
				//Current Area = "ENTIT"
				//1st Area Limit: "ENTIT"
				//1st Area Field: "SUPPLIER"
				//1st Area Value: "1"
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.SC;
					limit.NaoAplicaSeNulo = false;
					CSGenioAentit model_limit_area = new CSGenioAentit(m_userContext.User);
					string limit_field = "supplier", limit_field_value = "1";
					object this_limit_field = Navigation.GetStrValue(limit_field_value);
					Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
					if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
						this.tableLimits.Add(limit);
				}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(wms_menu_5211Conds);
				wms_menu_5211Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 5211]/

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAentit>(m_userContext, false, wms_menu_5211Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML5211", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 5211]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL WMS OVERRQLIST 5211]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_entit");
					Navigation.DestroyEntry("QMVC_POS_RECORD_entit");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAentit.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_5211Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(m_userContext, false, wms_menu_5211Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML5211", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapWMS_Menu_5211(listing);

					Menu.Identifier = "ML5211";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML5211";

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

		private List<WMS_Menu_5211_RowViewModel> MapWMS_Menu_5211(ListingMVC<CSGenioAentit> Qlisting)
		{
			List<WMS_Menu_5211_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_5211(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAentit row
		/// to a WMS_Menu_5211_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private WMS_Menu_5211_RowViewModel MapWMS_Menu_5211(CSGenioAentit row)
		{
			var model = new WMS_Menu_5211_RowViewModel(m_userContext, true, _fieldsToSerialize);
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

// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_5211]/

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
			new TableSearchColumn("ValOwner", CSGenioAentit.FldOwner, typeof(string)),
			new TableSearchColumn("ValCarrier", CSGenioAentit.FldCarrier, typeof(bool)),
			new TableSearchColumn("ValSupplier", CSGenioAentit.FldSupplier, typeof(bool))
		];
	}
}
