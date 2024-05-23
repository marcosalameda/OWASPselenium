using System;
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Collections.Specialized;
using System.Web.Mvc;
using Quidgest.Persistence;
using GenioMVC.Helpers.Table.Properties;

namespace GenioMVC.ViewModels.Entit
{
    public class WMS_Menu_5211_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Entit> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "entit"; }

        /// <inheritdoc/>
        public override string Uuid { get => "8300d5e0-5f67-4834-8d14-7430e3b4800f"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodentit { get; set; }

        /// <inheritdoc/>
        public override CriteriaSet baseConditions
        {
            get
            {
                CriteriaSet conds = CriteriaSet.And();
                return conds;
            }
        }

        /// <inheritdoc/>
        public override List<Relation> relations
        {
            get
            {
                List<Relation> relations = null;
                return relations;
            }
        }

        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.ENTITIES22578;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("entit", user, "WMS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAentit.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

                        conditions.Equal(CSGenioAentit.FldOwner, 1);



            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldZzstate, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldRegistra, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldIban, CSGenioAentit.FldBuilding, CSGenioAentit.FldStreet, CSGenioAentit.FldTown, CSGenioAentit.FldCounty, CSGenioAentit.FldState, CSGenioAentit.FldPobox, CSGenioAentit.FldPostalco, CSGenioAentit.FldTelephon, CSGenioAentit.FldFax, CSGenioAentit.FldWebsite, CSGenioAentit.FldPerson, CSGenioAentit.FldContact, CSGenioAentit.FldManufact, CSGenioAentit.FldFounded, CSGenioAentit.FldFirstfacilitie, CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAentit.FldLastfacilitie, CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAentit.FldLanguage, CSGenioAentit.FldCurrency, CSGenioAentit.FldOwner, CSGenioAentit.FldCarrier, CSGenioAentit.FldSupplier };

            ListingMVC<CSGenioAentit> listing = new ListingMVC<CSGenioAentit>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WMS_Menu_5211_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public WMS_Menu_5211_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
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
                new Exports.QColumn(CSGenioAentit.FldOwner, FieldType.LOGICO, Resources.Resources.OWNER09558, 1, 0, true),
                new Exports.QColumn(CSGenioAentit.FldCarrier, FieldType.LOGICO, Resources.Resources.CARRIER64855, 1, 0, true),
                new Exports.QColumn(CSGenioAentit.FldSupplier, FieldType.LOGICO, Resources.Resources.SUPPLIER17230, 1, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAentit> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
        {
            listing = null;
            conditions = null;
            columns = this.GetColumnsToExport(ajaxRequest);
            Load(-1, requestValues, ajaxRequest, true, ref listing, ref conditions);

            //user config listing:
            if (ajaxRequest && userColumns!=null)
            {
                List<Exports.QColumn> current_List = new List<Exports.QColumn>();
                foreach (CSGenioAlstcol column in userColumns)
                {
                    //check if theres a match in existing list columns
                    string areabase = column.ValTabela.ToLower() != "entit" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
                    Exports.QColumn matching_column = columns.Where(x => x.BaseArea == column.ValTabela && areabase + "Val" + x.FieldName.First().ToString().ToUpper() + x.FieldName.Substring(1).ToLower() == column.ValCampo && column.ValVisivel==1).FirstOrDefault();
                    if (matching_column != null)
                        current_List.Add(matching_column);
                }
                columns = current_List;
            }
        }

        /// <summary>
		/// Builds the list CriteriaSet with all the limits, filters and conditions
		/// </summary>
		/// <param name="requestValues">Table filters</param>
        /// <param name="tableReload">[Quick fix] Indicates whether the data list should be loaded. If set to false within the method, it signals that the data list should not display rows due to unmet mandatory limits.</param>
        /// <param name="crs">Pass a CriteriaSet by reference to be modified</param>
		/// <param name="isToExport">If the  table is to be exported</param>
		public CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = UserContext.Current.User;
            tableReload = true;

			if(crs == null)
				crs = CriteriaSet.And();


			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Entit>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_5211_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ENTIT.NAME", new OrderedDictionary());
			allSortOrders["ENTIT.NAME"].Add("ENTIT.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_5211_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "SC"
			crs.Equal(CSGenioAentit.FldOwner, "1");

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
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_5211", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_5211"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_5211");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Entit>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_5211_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ENTIT.NAME", new OrderedDictionary());
			allSortOrders["ENTIT.NAME"].Add("ENTIT.NAME", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_5211"])) ? int.Parse(requestValues["pWMS_Menu_5211"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_5211", "dWMS_Menu_5211", requestValues, "entit", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldZzstate, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldRegistra, CSGenioAentit.FldTaxnumbe, CSGenioAentit.FldEmail, CSGenioAentit.FldPhonenum, CSGenioAentit.FldIban, CSGenioAentit.FldBuilding, CSGenioAentit.FldStreet, CSGenioAentit.FldTown, CSGenioAentit.FldCounty, CSGenioAentit.FldState, CSGenioAentit.FldPobox, CSGenioAentit.FldPostalco, CSGenioAentit.FldTelephon, CSGenioAentit.FldFax, CSGenioAentit.FldWebsite, CSGenioAentit.FldPerson, CSGenioAentit.FldContact, CSGenioAentit.FldManufact, CSGenioAentit.FldFounded, CSGenioAentit.FldFirstfacilitie, CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAentit.FldLastfacilitie, CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAentit.FldLanguage, CSGenioAentit.FldCurrency, CSGenioAentit.FldOwner, CSGenioAentit.FldCarrier, CSGenioAentit.FldSupplier };


			//columns by users list (TemplateDBEditViewModel)
			userColumns = UserUiSettings.Load(UserContext.Current.PersistentSupport, Uuid, UserContext.Current.User).userColumns;
			FieldRef firstVisibleColumn = null;

			if (sorts == null)
				if (userColumns != null)
				{
					CSGenioAlstcol col = userColumns.FirstOrDefault(x => x.ValVisivel == 1);

					if (col != null)
					{
						string table = col.ValTabela.ToLower();
						string field = col.ValCampo.ToLower(); //may contain Table.ValField
						if (field.Contains("."))
						{
							field = field.Substring(table.Length + 4); //remove table name and .Val from ValCampo data. i.e: "Pesso.ValNome", pesso lenght will remove "Pesso" and then +4 for the fixed ".Val"
						}
						else
						{
							field = field.Substring(3); //remove table Val from ValCampo data. i.e: "ValNome", Substring(3) will remove "Val"
						}

						firstVisibleColumn = new FieldRef(table, field);
					}
				}
				else
					firstVisibleColumn = new FieldRef("entit", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAentit model_limit_area = new CSGenioAentit(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML5211");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 


			//Limit type: "SC"			//Current Area = "ENTIT"			//1st Area Limit: "ENTIT"			//1st Area Field: "OWNER"			//1st Area Value: "1"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.SC;
				limit.NaoAplicaSeNulo = false;
				CSGenioAentit model_limit_area = new CSGenioAentit(UserContext.Current.User);
				string limit_field = "owner", limit_field_value = "1";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet wms_menu_5211Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL WMS OVERRQ 5211]/

            // This will happen in case there is an error
            if(wms_menu_5211Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAentit>(false, wms_menu_5211Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML5211", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 5211]/

                conditions = wms_menu_5211Conds;
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
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAentit.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_5211Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(false, wms_menu_5211Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML5211", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapWMS_Menu_5211(listing);

				Menu.Identifier = "ML5211";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML5211";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Entit> MapWMS_Menu_5211(ListingMVC<CSGenioAentit> Qlisting)
        {
            var Elements = new List<Models.Entit>();
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
        /// to a Models.Entit object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Entit MapWMS_Menu_5211(CSGenioAentit row)
        {
            var model = new Models.Entit(true, _fieldsToSerialize);
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


        #region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_5211]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials", "Entit.ValRegistra", "Entit.ValTaxnumbe", "Entit.ValEmail", "Entit.ValPhonenum", "Entit.ValIban", "Entit.ValBuilding", "Entit.ValStreet", "Entit.ValTown", "Entit.ValCounty", "Entit.ValState", "Entit.ValPobox", "Entit.ValPostalco", "Entit.ValTelephon", "Entit.ValFax", "Entit.ValWebsite", "Entit.ValPerson", "Entit.ValContact", "Entit.ValManufact", "Entit.ValFounded", "Faci1", "Faci1.ValName", "Faci2", "Faci2.ValName", "Entit.ValLanguage", "Entit.ValCurrency", "Entit.ValOwner", "Entit.ValCarrier", "Entit.ValSupplier", "Entit.ValFirstfacilitie", "Entit.ValLastfacilitie"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
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
            new TableSearchColumn("ValSupplier", CSGenioAentit.FldSupplier, typeof(bool))
        };
    }
}
