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

namespace GenioMVC.ViewModels.Dispa
{
    public class WMS_Menu_2211_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Dispa> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "dispa"; }

        /// <inheritdoc/>
        public override string Uuid { get => "26adf4c3-c69b-49c3-9b58-2dd6e756779a"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCoddispa { get; set; }

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
            dbeditTitle = Resources.Resources.DISPATCHES13773;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("dispa", user, "WMS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAdispa.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

                        conditions.Equal(CSGenioAdispa.FldIsprepar, 1);



            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldZzstate, CSGenioAdispa.FldDispadt, CSGenioAdispa.FldDispanr, CSGenioAdispa.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName };

            ListingMVC<CSGenioAdispa> listing = new ListingMVC<CSGenioAdispa>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WMS_Menu_2211_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public WMS_Menu_2211_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAdispa.FldDispadt, FieldType.DATAHORA, Resources.Resources.DISPATCH_DATE54413, 16, 0, true),
                new Exports.QColumn(CSGenioAdispa.FldDispanr, FieldType.NUMERO, Resources.Resources.DISPATCH_NUMBER23616, 10, 0, true),
                new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXTO, Resources.Resources.CUSTOMER51658, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAdispa> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "dispa" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Dispa>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_2211_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DISPA.DISPADT", new OrderedDictionary());
			allSortOrders["DISPA.DISPADT"].Add("DISPA.DISPADT", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_2211_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "SC"
			crs.Equal(CSGenioAdispa.FldIsprepar, "1");

			if (isToExport)
			{
				// EPH
				crs = Models.Dispa.AddEPH<CSGenioAdispa>(ref u, crs, "ML2211");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAdispa.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("DISPA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAdispa.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dispa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dispa");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Dispa.AddEPH<CSGenioAdispa>(ref u, null, "ML2211"));
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
            ListingMVC<CSGenioAdispa> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdispa> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_2211", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_2211"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_2211");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Dispa>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_2211_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DISPA.DISPADT", new OrderedDictionary());
			allSortOrders["DISPA.DISPADT"].Add("DISPA.DISPADT", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_2211"])) ? int.Parse(requestValues["pWMS_Menu_2211"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_2211", "dWMS_Menu_2211", requestValues, "dispa", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAdispa.FldDispadt), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldZzstate, CSGenioAdispa.FldDispadt, CSGenioAdispa.FldDispanr, CSGenioAdispa.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName };


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
					firstVisibleColumn = new FieldRef("dispa", "dispadt");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAdispa model_limit_area = new CSGenioAdispa(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML2211");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 


			//Limit type: "SC"			//Current Area = "DISPA"			//1st Area Limit: "DISPA"			//1st Area Field: "ISPREPAR"			//1st Area Value: "1"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.SC;
				limit.NaoAplicaSeNulo = false;
				CSGenioAdispa model_limit_area = new CSGenioAdispa(UserContext.Current.User);
				string limit_field = "isprepar", limit_field_value = "1";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet wms_menu_2211Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 2211]/

            // This will happen in case there is an error
            if(wms_menu_2211Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAdispa>(false, wms_menu_2211Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2211", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 2211]/

                conditions = wms_menu_2211Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 2211]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dispa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dispa");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAdispa.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_2211Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAdispa> listing = Models.ModelBase.Where<CSGenioAdispa>(false, wms_menu_2211Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2211", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapWMS_Menu_2211(listing);

				Menu.Identifier = "ML2211";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML2211";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Dispa> MapWMS_Menu_2211(ListingMVC<CSGenioAdispa> Qlisting)
        {
            var Elements = new List<Models.Dispa>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_2211(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAdispa row
        /// to a Models.Dispa object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Dispa MapWMS_Menu_2211(CSGenioAdispa row)
        {
            var model = new Models.Dispa(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "dispa":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "entit":
                        model.Entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_2211]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Dispa", "Dispa.ValCoddispa", "Dispa.ValZzstate", "Dispa.ValDispadt", "Dispa.ValDispanr", "Entit", "Entit.ValName", "Dispa.ValCodentit", "Dispa.ValCodperso"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValDispadt", CSGenioAdispa.FldDispadt, typeof(DateTime?)),
            new TableSearchColumn("ValDispanr", CSGenioAdispa.FldDispanr, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("Entit_ValName", CSGenioAentit.FldName, typeof(string))
        };
    }
}
