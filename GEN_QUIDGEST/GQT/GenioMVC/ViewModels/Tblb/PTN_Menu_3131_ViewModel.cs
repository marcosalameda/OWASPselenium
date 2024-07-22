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

namespace GenioMVC.ViewModels.Tblb
{
    public class PTN_Menu_3131_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Tblb> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "tblb"; }

        /// <inheritdoc/>
        public override string Uuid { get => "3fd77cd2-766d-43a4-b089-f0a2b4bfc9d9"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodtblb { get; set; }

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
            dbeditTitle = Resources.Resources.TABLES__BASIC_TYPES_29665;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("tblb", user, "PTN");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAtblb.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAtblb.FldCodtblb, CSGenioAtblb.FldZzstate, CSGenioAtblb.FldText, CSGenioAtblb.FldTextml, CSGenioAtblb.FldNumint, CSGenioAtblb.FldNumdec, CSGenioAtblb.FldCurint, CSGenioAtblb.FldCurdec, CSGenioAtblb.FldBool, CSGenioAtblb.FldDate, CSGenioAtblb.FldDatetm, CSGenioAtblb.FldDatets, CSGenioAtblb.FldTimehm, CSGenioAtblb.FldEnumt, CSGenioAtblb.FldEnumn };

            ListingMVC<CSGenioAtblb> listing = new ListingMVC<CSGenioAtblb>(fields, null, 1, 1, false, user, true, string.Empty, true);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PTN_Menu_3131_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public PTN_Menu_3131_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAtblb.FldText, FieldType.TEXTO, Resources.Resources.TEXT04938, 30, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldTextml, FieldType.MEMO, Resources.Resources.MULTILINE_TEXT38013, 30, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldNumint, FieldType.NUMERO, Resources.Resources.NUMERIC__INTEGER_50289, 10, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldNumdec, FieldType.NUMERO, Resources.Resources.NUMERIC__DECIMAL_36157, 10, 3, true),
                new Exports.QColumn(CSGenioAtblb.FldCurint, FieldType.VALOR, Resources.Resources.CURRENCY__INTERGER_21437, 10, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldCurdec, FieldType.VALOR, Resources.Resources.CURRENCY__DECIMAL_11718, 10, 2, true),
                new Exports.QColumn(CSGenioAtblb.FldBool, FieldType.LOGICO, Resources.Resources.BOOLEAN45002, 1, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldDate, FieldType.DATA, Resources.Resources.DATE18475, 8, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldDatetm, FieldType.DATAHORA, Resources.Resources.DATETIME__MINUTES_59352, 16, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldDatets, FieldType.DATASEGUNDO, Resources.Resources.DATETIME__SECONDS_49861, 19, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldTimehm, FieldType.TEMPO, Resources.Resources.TIME__HOURS_MINUTES_01660, 5, 0, true),
                new Exports.QColumn(CSGenioAtblb.FldEnumt, FieldType.ARRAY_COD_TEXTO, Resources.Resources.ENUMERATION__TEXT_15855, 1, 0, true, "typet"),
                new Exports.QColumn(CSGenioAtblb.FldEnumn, FieldType.ARRAY_COD_NUMERICO, Resources.Resources.ENUMERATION__NUMERIC44708, 1, 0, true, "typen"),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAtblb> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "tblb" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Tblb>();
			Menu.SetFilters(bool.Parse(requestValues["PTN_Menu_3131_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("TBLB.TEXT", new OrderedDictionary());
			allSortOrders["TBLB.TEXT"].Add("TBLB.TEXT", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "PTN_Menu_3131_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Tblb.AddEPH<CSGenioAtblb>(ref u, crs, "ML3131");

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
					crs.Equals(Models.Tblb.AddEPH<CSGenioAtblb>(ref u, null, "ML3131"));
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
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "PTN_Menu_3131", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "PTN_Menu_3131"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "PTN_Menu_3131");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Tblb>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["PTN_Menu_3131_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("TBLB.TEXT", new OrderedDictionary());
			allSortOrders["TBLB.TEXT"].Add("TBLB.TEXT", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pPTN_Menu_3131"])) ? int.Parse(requestValues["pPTN_Menu_3131"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sPTN_Menu_3131", "dPTN_Menu_3131", requestValues, "tblb", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtblb.FldText), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAtblb.FldCodtblb, CSGenioAtblb.FldZzstate, CSGenioAtblb.FldText, CSGenioAtblb.FldTextml, CSGenioAtblb.FldNumint, CSGenioAtblb.FldNumdec, CSGenioAtblb.FldCurint, CSGenioAtblb.FldCurdec, CSGenioAtblb.FldBool, CSGenioAtblb.FldDate, CSGenioAtblb.FldDatetm, CSGenioAtblb.FldDatets, CSGenioAtblb.FldTimehm, CSGenioAtblb.FldEnumt, CSGenioAtblb.FldEnumn };


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
					firstVisibleColumn = new FieldRef("tblb", "text");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAtblb model_limit_area = new CSGenioAtblb(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3131");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet ptn_menu_3131Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL PTN OVERRQ 3131]/

            // This will happen in case there is an error
            if(ptn_menu_3131Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAtblb>(false, ptn_menu_3131Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3131", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 3131]/

                conditions = ptn_menu_3131Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST 3131]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tblb");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tblb");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAtblb.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_3131Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAtblb> listing = Models.ModelBase.Where<CSGenioAtblb>(false, ptn_menu_3131Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3131", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapPTN_Menu_3131(listing);

				Menu.Identifier = "ML3131";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML3131";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Tblb> MapPTN_Menu_3131(ListingMVC<CSGenioAtblb> Qlisting)
        {
            var Elements = new List<Models.Tblb>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_3131(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAtblb row
        /// to a Models.Tblb object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Tblb MapPTN_Menu_3131(CSGenioAtblb row)
        {
            var model = new Models.Tblb(true, _fieldsToSerialize);
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_3131]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Tblb", "Tblb.ValCodtblb", "Tblb.ValZzstate", "Tblb.ValText", "Tblb.ValTextml", "Tblb.ValNumint", "Tblb.ValNumdec", "Tblb.ValCurint", "Tblb.ValCurdec", "Tblb.ValBool", "Tblb.ValDate", "Tblb.ValDatetm", "Tblb.ValDatets", "Tblb.ValTimehm", "Tblb.ValEnumt", "Tblb.ValEnumn", "Tblb.ValFkey1"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
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
            new TableSearchColumn("ValEnumn", CSGenioAtblb.FldEnumn, typeof(decimal), array : "typen")
        };
    }
}
