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

namespace GenioMVC.ViewModels.Lendi
{
    public class PTN_Menu_LIST_DM_MB_R_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Lendi> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "lendi"; }

        /// <inheritdoc/>
        public override string Uuid { get => "5e4e7e69-c5b2-478b-bb88-e077baaaf55b"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodlendi { get; set; }

		/// <inheritdoc/>
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

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

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL PTN LIST_LIMITS LIST_DM_MB_R]/

			return crs;
		}


        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.LENDING18782;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("lendi", user, "PTN");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAlendi.FldZzstate, 0); //valid zzstate only

            // Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAlendi.FldCodlendi, CSGenioAlendi.FldZzstate, CSGenioAlendi.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAlendi.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAlendi.FldCodpess2, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioAlendi.FldLendinnr, CSGenioAlendi.FldStart, CSGenioAlendi.FldWarndt, CSGenioAlendi.FldEnd, CSGenioAlendi.FldObservat, CSGenioAlendi.FldReturndt, CSGenioAlendi.FldReturned, CSGenioAlendi.FldDayslimi, CSGenioAlendi.FldIfoutdt };

            ListingMVC<CSGenioAlendi> listing = new ListingMVC<CSGenioAlendi>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PTN_Menu_LIST_DM_MB_R_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public PTN_Menu_LIST_DM_MB_R_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
                new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
                new Exports.QColumn(CSGenioApess2.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldLendinnr, FieldType.NUMERO, Resources.Resources.NO__OF_THE_DADATO35934, 6, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldStart, FieldType.DATAHORA, Resources.Resources.BEGINNING18124, 16, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldWarndt, FieldType.DATAHORA, Resources.Resources.WARNING52043, 16, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldEnd, FieldType.DATAHORA, Resources.Resources.END47577, 16, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldObservat, FieldType.MEMO, Resources.Resources.OBSERVATIONS03729, 30, 3, true),
                new Exports.QColumn(CSGenioAlendi.FldReturndt, FieldType.DATA, Resources.Resources.RETURN32222, 8, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldReturned, FieldType.LOGICO, Resources.Resources.RETURNED01606, 1, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldDayslimi, FieldType.NUMERO, Resources.Resources.DAYS_FOR_RETURN_PERI04559, 10, 0, true),
                new Exports.QColumn(CSGenioAlendi.FldIfoutdt, FieldType.LOGICO, Resources.Resources.IF_OUT_OF_DATE49042, 1, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAlendi> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "lendi" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Lendi>();
			Menu.SetFilters(bool.Parse(requestValues["PTN_Menu_LIST_DM_MB_R_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "PTN_Menu_LIST_DM_MB_R_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Lendi.AddEPH<CSGenioAlendi>(ref u, crs, "MLLIST_DM_MB_R");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAlendi.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LENDI", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAlendi.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lendi");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Lendi.AddEPH<CSGenioAlendi>(ref u, null, "MLLIST_DM_MB_R"));
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
            ListingMVC<CSGenioAlendi> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlendi> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "PTN_Menu_LIST_DM_MB_R", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "PTN_Menu_LIST_DM_MB_R"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "PTN_Menu_LIST_DM_MB_R");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Lendi>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("LENDI.START", new OrderedDictionary());
			allSortOrders["LENDI.START"].Add("LENDI.START", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pPTN_Menu_LIST_DM_MB_R"])) ? int.Parse(requestValues["pPTN_Menu_LIST_DM_MB_R"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sPTN_Menu_LIST_DM_MB_R", "dPTN_Menu_LIST_DM_MB_R", requestValues, "lendi", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlendi.FldStart), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAlendi.FldCodlendi, CSGenioAlendi.FldZzstate, CSGenioAlendi.FldCodpess1, CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioAlendi.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAlendi.FldCodpess2, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioAlendi.FldLendinnr, CSGenioAlendi.FldStart, CSGenioAlendi.FldWarndt, CSGenioAlendi.FldEnd, CSGenioAlendi.FldObservat, CSGenioAlendi.FldReturndt, CSGenioAlendi.FldReturned, CSGenioAlendi.FldDayslimi, CSGenioAlendi.FldIfoutdt };


			//columns by users list (TemplateDBEditViewModel)
			userColumns = TableUiSettingsDbRec.Load(UserContext.Current.PersistentSupport, Uuid, UserContext.Current.User).UserColumns;
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
					firstVisibleColumn = new FieldRef("pess1", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAlendi model_limit_area = new CSGenioAlendi(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLLIST_DM_MB_R");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet ptn_menu_list_dm_mb_rConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ LIST_DM_MB_R]/

            // This will happen in case there is an error
            if(ptn_menu_list_dm_mb_rConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAlendi>(false, ptn_menu_list_dm_mb_rConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLLIST_DM_MB_R", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP LIST_DM_MB_R]/

                conditions = ptn_menu_list_dm_mb_rConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST LIST_DM_MB_R]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lendi");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lendi");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAlendi.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_list_dm_mb_rConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAlendi> listing = Models.ModelBase.Where<CSGenioAlendi>(false, ptn_menu_list_dm_mb_rConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLLIST_DM_MB_R", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapPTN_Menu_LIST_DM_MB_R(listing);

				Menu.Identifier = "MLLIST_DM_MB_R";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "MLLIST_DM_MB_R";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Lendi> MapPTN_Menu_LIST_DM_MB_R(ListingMVC<CSGenioAlendi> Qlisting)
        {
            var Elements = new List<Models.Lendi>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_LIST_DM_MB_R(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAlendi row
        /// to a Models.Lendi object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Lendi MapPTN_Menu_LIST_DM_MB_R(CSGenioAlendi row)
        {
            var model = new Models.Lendi(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "lendi":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pess1":
                        model.Pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "equip":
                        model.Equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pess2":
                        model.Pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_LIST_DM_MB_R]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Lendi", "Lendi.ValCodlendi", "Lendi.ValZzstate", "Pess1", "Pess1.ValName", "Equip", "Equip.ValRegistnr", "Pess2", "Pess2.ValName", "Lendi.ValLendinnr", "Lendi.ValStart", "Lendi.ValWarndt", "Lendi.ValEnd", "Lendi.ValObservat", "Lendi.ValReturndt", "Lendi.ValReturned", "Lendi.ValDayslimi", "Lendi.ValIfoutdt", "Lendi.ValCodequip", "Lendi.ValCodpess1", "Lendi.ValCodpess2"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("Pess1_ValName", CSGenioApess1.FldName, typeof(string)),
            new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
            new TableSearchColumn("Pess2_ValName", CSGenioApess2.FldName, typeof(string)),
            new TableSearchColumn("ValLendinnr", CSGenioAlendi.FldLendinnr, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("ValStart", CSGenioAlendi.FldStart, typeof(DateTime?)),
            new TableSearchColumn("ValWarndt", CSGenioAlendi.FldWarndt, typeof(DateTime?)),
            new TableSearchColumn("ValEnd", CSGenioAlendi.FldEnd, typeof(DateTime?)),
            new TableSearchColumn("ValObservat", CSGenioAlendi.FldObservat, typeof(string)),
            new TableSearchColumn("ValReturndt", CSGenioAlendi.FldReturndt, typeof(DateTime?)),
            new TableSearchColumn("ValReturned", CSGenioAlendi.FldReturned, typeof(bool)),
            new TableSearchColumn("ValDayslimi", CSGenioAlendi.FldDayslimi, typeof(decimal?)),
            new TableSearchColumn("ValIfoutdt", CSGenioAlendi.FldIfoutdt, typeof(bool))
        };

    }
}
