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

namespace GenioMVC.ViewModels.Outpt
{
    public class GQT_Menu_411_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Outpt> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "outpt"; }

        /// <inheritdoc/>
        public override string Uuid { get => "40d782e2-021c-459e-ae69-1e1ff69a0c72"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodoutpt { get; set; }

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
            dbeditTitle = Resources.Resources.OUTPUT_DOCUMENTS44871;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("outpt", user, "GQT");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAoutpt.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldZzstate, CSGenioAoutpt.FldDocumenr, CSGenioAoutpt.FldDhdocume, CSGenioAoutpt.FldCodwareh, CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes };

            ListingMVC<CSGenioAoutpt> listing = new ListingMVC<CSGenioAoutpt>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GQT_Menu_411_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public GQT_Menu_411_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAoutpt.FldDocumenr, FieldType.NUMERO, Resources.Resources.NO_14817, 10, 0, true),
                new Exports.QColumn(CSGenioAoutpt.FldDhdocume, FieldType.DATAHORA, Resources.Resources.DATE18475, 16, 0, true),
                new Exports.QColumn(CSGenioAware1.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAoutpt> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "outpt" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Outpt>();
			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_411_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("OUTPT.DOCUMENR", new OrderedDictionary());
			allSortOrders["OUTPT.DOCUMENR"].Add("OUTPT.DOCUMENR", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "GQT_Menu_411_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Outpt.AddEPH<CSGenioAoutpt>(ref u, crs, "ML411");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAoutpt.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("OUTPT", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAoutpt.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_outpt");
				Navigation.DestroyEntry("QMVC_POS_RECORD_outpt");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Outpt.AddEPH<CSGenioAoutpt>(ref u, null, "ML411"));
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
            ListingMVC<CSGenioAoutpt> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAoutpt> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "GQT_Menu_411", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "GQT_Menu_411"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_411");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Outpt>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("OUTPT.DOCUMENR", new OrderedDictionary());
			allSortOrders["OUTPT.DOCUMENR"].Add("OUTPT.DOCUMENR", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pGQT_Menu_411"])) ? int.Parse(requestValues["pGQT_Menu_411"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sGQT_Menu_411", "dGQT_Menu_411", requestValues, "outpt", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoutpt.FldDocumenr), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldZzstate, CSGenioAoutpt.FldDocumenr, CSGenioAoutpt.FldDhdocume, CSGenioAoutpt.FldCodwareh, CSGenioAware1.FldCodwareh, CSGenioAware1.FldWarehdes };


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
					firstVisibleColumn = new FieldRef("outpt", "documenr");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAoutpt model_limit_area = new CSGenioAoutpt(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML411");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet gqt_menu_411Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 411]/

            // This will happen in case there is an error
            if(gqt_menu_411Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAoutpt>(false, gqt_menu_411Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML411", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 411]/

                conditions = gqt_menu_411Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST 411]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_outpt");
				Navigation.DestroyEntry("QMVC_POS_RECORD_outpt");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAoutpt.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_411Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAoutpt> listing = Models.ModelBase.Where<CSGenioAoutpt>(false, gqt_menu_411Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML411", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapGQT_Menu_411(listing);

				Menu.Identifier = "ML411";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML411";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Outpt> MapGQT_Menu_411(ListingMVC<CSGenioAoutpt> Qlisting)
        {
            var Elements = new List<Models.Outpt>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_411(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAoutpt row
        /// to a Models.Outpt object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Outpt MapGQT_Menu_411(CSGenioAoutpt row)
        {
            var model = new Models.Outpt(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "outpt":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "ware1":
                        model.Ware1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_411]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Outpt", "Outpt.ValCodoutpt", "Outpt.ValZzstate", "Outpt.ValDocumenr", "Outpt.ValDhdocume", "Ware1", "Ware1.ValWarehdes", "Outpt.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValDocumenr", CSGenioAoutpt.FldDocumenr, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("ValDhdocume", CSGenioAoutpt.FldDhdocume, typeof(DateTime?)),
            new TableSearchColumn("Ware1_ValWarehdes", CSGenioAware1.FldWarehdes, typeof(string))
        };

    }
}
