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

namespace GenioMVC.ViewModels.Facty
{
    public class WMS_Menu_4231_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Facty> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "facty"; }

        /// <inheritdoc/>
        public override string Uuid { get => "7e4470ed-09c8-442d-91d2-b76a9ecd0d88"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodfacty { get; set; }

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
            dbeditTitle = Resources.Resources.FACILITY_TYPES57319;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("facty", user, "WMS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAfacty.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldZzstate, CSGenioAfacty.FldType, CSGenioAfacty.FldLayrname, CSGenioAfacty.FldIconurl, CSGenioAfacty.FldShadowur, CSGenioAfacty.FldIconancx, CSGenioAfacty.FldIconancy, CSGenioAfacty.FldIconheig, CSGenioAfacty.FldIconwid, CSGenioAfacty.FldPopupanx, CSGenioAfacty.FldPopupany, CSGenioAfacty.FldShadowax, CSGenioAfacty.FldShadoway, CSGenioAfacty.FldShadowhe, CSGenioAfacty.FldShadowwi };

            ListingMVC<CSGenioAfacty> listing = new ListingMVC<CSGenioAfacty>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WMS_Menu_4231_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public WMS_Menu_4231_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAfacty.FldType, FieldType.TEXTO, Resources.Resources.FACILITY_TYPE44577, 25, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldLayrname, FieldType.TEXTO, Resources.Resources.LAYER_NAME49545, 30, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldIconurl, FieldType.TEXTO, Resources.Resources.ICON_URL07016, 30, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldShadowur, FieldType.TEXTO, Resources.Resources.SHADOW_URL57805, 30, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldIconancx, FieldType.NUMERO, Resources.Resources.ICON_ANCHOR__X_AXIS_18664, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldIconancy, FieldType.NUMERO, Resources.Resources.ICON_ANCHOR__Y_AXIS_63725, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldIconheig, FieldType.NUMERO, Resources.Resources.ICON_HEIGHT61896, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldIconwid, FieldType.NUMERO, Resources.Resources.ICON_WIDTH02295, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldPopupanx, FieldType.NUMERO, Resources.Resources.POPUP_ANCHOR__X_AXIS15060, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldPopupany, FieldType.NUMERO, Resources.Resources.POPUP_ANCHOR__Y_AXIS64670, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldShadowax, FieldType.NUMERO, Resources.Resources.SHADOW_ANCHOR__X_AXI31230, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldShadoway, FieldType.NUMERO, Resources.Resources.SHADOW_ANCHOR__Y_AXI51495, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldShadowhe, FieldType.NUMERO, Resources.Resources.SHADOW_HEIGHT64343, 3, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldShadowwi, FieldType.NUMERO, Resources.Resources.SHADOW_WIDTH01769, 3, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAfacty> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "facty" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
                    Exports.QColumn matching_column = columns.Where(x => x.BaseArea == column.ValTabela && areabase + "Val" + x.FieldName.First().ToString().ToUpper() + x.FieldName.Substring(1).ToLower() == column.ValCampo && column.ValVisivel==1).FirstOrDefault();
                    if (matching_column != null)
                        current_List.Add(matching_column);
                }
                columns = current_List;
            }
        }

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = UserContext.Current.User;
            tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();


			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Facty>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_4231_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FACTY.TYPE", new OrderedDictionary());
			allSortOrders["FACTY.TYPE"].Add("FACTY.TYPE", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_4231_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Facty.AddEPH<CSGenioAfacty>(ref u, crs, "ML4231");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfacty.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FACTY", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAfacty.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_facty");
				Navigation.DestroyEntry("QMVC_POS_RECORD_facty");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Facty.AddEPH<CSGenioAfacty>(ref u, null, "ML4231"));
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
            ListingMVC<CSGenioAfacty> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfacty> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_4231", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_4231"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_4231");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Facty>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_4231_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FACTY.TYPE", new OrderedDictionary());
			allSortOrders["FACTY.TYPE"].Add("FACTY.TYPE", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_4231"])) ? int.Parse(requestValues["pWMS_Menu_4231"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_4231", "dWMS_Menu_4231", requestValues, "facty", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacty.FldType), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldZzstate, CSGenioAfacty.FldType, CSGenioAfacty.FldLayrname, CSGenioAfacty.FldIconurl, CSGenioAfacty.FldShadowur, CSGenioAfacty.FldIconancx, CSGenioAfacty.FldIconancy, CSGenioAfacty.FldIconheig, CSGenioAfacty.FldIconwid, CSGenioAfacty.FldPopupanx, CSGenioAfacty.FldPopupany, CSGenioAfacty.FldShadowax, CSGenioAfacty.FldShadoway, CSGenioAfacty.FldShadowhe, CSGenioAfacty.FldShadowwi };


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
					firstVisibleColumn = new FieldRef("facty", "type");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAfacty model_limit_area = new CSGenioAfacty(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML4231");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet wms_menu_4231Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 4231]/

            // This will happen in case there is an error
            if(wms_menu_4231Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfacty>(false, wms_menu_4231Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML4231", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 4231]/

                conditions = wms_menu_4231Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 4231]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_facty");
				Navigation.DestroyEntry("QMVC_POS_RECORD_facty");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAfacty.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_4231Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAfacty> listing = Models.ModelBase.Where<CSGenioAfacty>(false, wms_menu_4231Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML4231", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapWMS_Menu_4231(listing);

				Menu.Identifier = "ML4231";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML4231";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Facty> MapWMS_Menu_4231(ListingMVC<CSGenioAfacty> Qlisting)
        {
            var Elements = new List<Models.Facty>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_4231(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAfacty row
        /// to a Models.Facty object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Facty MapWMS_Menu_4231(CSGenioAfacty row)
        {
            var model = new Models.Facty(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "facty":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_4231]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Facty", "Facty.ValCodfacty", "Facty.ValZzstate", "Facty.ValType", "Facty.ValLayrname", "Facty.ValIconurl", "Facty.ValShadowur", "Facty.ValIconancx", "Facty.ValIconancy", "Facty.ValIconheig", "Facty.ValIconwid", "Facty.ValPopupanx", "Facty.ValPopupany", "Facty.ValShadowax", "Facty.ValShadoway", "Facty.ValShadowhe", "Facty.ValShadowwi"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValType", CSGenioAfacty.FldType, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValLayrname", CSGenioAfacty.FldLayrname, typeof(string)),
            new TableSearchColumn("ValIconurl", CSGenioAfacty.FldIconurl, typeof(string)),
            new TableSearchColumn("ValShadowur", CSGenioAfacty.FldShadowur, typeof(string)),
            new TableSearchColumn("ValIconancx", CSGenioAfacty.FldIconancx, typeof(decimal?)),
            new TableSearchColumn("ValIconancy", CSGenioAfacty.FldIconancy, typeof(decimal?)),
            new TableSearchColumn("ValIconheig", CSGenioAfacty.FldIconheig, typeof(decimal?)),
            new TableSearchColumn("ValIconwid", CSGenioAfacty.FldIconwid, typeof(decimal?)),
            new TableSearchColumn("ValPopupanx", CSGenioAfacty.FldPopupanx, typeof(decimal?)),
            new TableSearchColumn("ValPopupany", CSGenioAfacty.FldPopupany, typeof(decimal?)),
            new TableSearchColumn("ValShadowax", CSGenioAfacty.FldShadowax, typeof(decimal?)),
            new TableSearchColumn("ValShadoway", CSGenioAfacty.FldShadoway, typeof(decimal?)),
            new TableSearchColumn("ValShadowhe", CSGenioAfacty.FldShadowhe, typeof(decimal?)),
            new TableSearchColumn("ValShadowwi", CSGenioAfacty.FldShadowwi, typeof(decimal?))
        };

    }
}
