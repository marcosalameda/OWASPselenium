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

namespace GenioMVC.ViewModels.Expen
{
    public class PTN_Menu_LIST_DB_TR_F_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Expen> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "expen"; }

        /// <inheritdoc/>
        public override string Uuid { get => "a393a10a-95b6-4384-8269-4b89e5ab094a"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCoddespe { get; set; }

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
// USE /[MANUAL PTN LIST_LIMITS LIST_DB_TR_F]/

			return crs;
		}


        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.DESPESAS23133;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("expen", user, "PTN");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAexpen.FldZzstate, 0); //valid zzstate only

            // Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAexpen.FldCoddespe, CSGenioAexpen.FldZzstate, CSGenioAexpen.FldCodyear, CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAexpen.FldYearnumb, CSGenioAexpen.FldCodaggre, CSGenioAagreg.FldCodaggre, CSGenioAagreg.FldValue, CSGenioAexpen.FldDescript, CSGenioAexpen.FldValue, CSGenioAexpen.FldPrevval, CSGenioAexpen.FldCodproje, CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto };

            ListingMVC<CSGenioAexpen> listing = new ListingMVC<CSGenioAexpen>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PTN_Menu_LIST_DB_TR_F_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public PTN_Menu_LIST_DB_TR_F_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAyear.FldYear, FieldType.TEXTO, Resources.Resources.ANO33022, 4, 0, true),
                new Exports.QColumn(CSGenioAexpen.FldYearnumb, FieldType.NUMERO, Resources.Resources.ANO_NUMERICO_51058, 4, 0, true),
                new Exports.QColumn(CSGenioAagreg.FldValue, FieldType.VALOR, Resources.Resources.VALUE10285, 10, 0, true),
                new Exports.QColumn(CSGenioAexpen.FldDescript, FieldType.TEXTO, Resources.Resources.DESCRIPTION07383, 30, 0, true),
                new Exports.QColumn(CSGenioAexpen.FldValue, FieldType.VALOR, Resources.Resources.VALUE10285, 10, 0, true),
                new Exports.QColumn(CSGenioAexpen.FldPrevval, FieldType.VALOR, Resources.Resources.VALOR_ANTERIOR54849, 10, 0, true),
                new Exports.QColumn(CSGenioAproje.FldProjecto, FieldType.TEXTO, Resources.Resources.PROJECTO50142, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAexpen> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "expen" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Expen>();
			Menu.SetFilters(bool.Parse(requestValues["PTN_Menu_LIST_DB_TR_F_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "PTN_Menu_LIST_DB_TR_F_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Expen.AddEPH<CSGenioAexpen>(ref u, crs, "MLLIST_DB_TR_F");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAexpen.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("EXPEN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAexpen.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_expen");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Expen.AddEPH<CSGenioAexpen>(ref u, null, "MLLIST_DB_TR_F"));
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
            ListingMVC<CSGenioAexpen> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAexpen> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "PTN_Menu_LIST_DB_TR_F", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "PTN_Menu_LIST_DB_TR_F"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "PTN_Menu_LIST_DB_TR_F");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Expen>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("EXPEN.DESCRIPT", new OrderedDictionary());
			allSortOrders["EXPEN.DESCRIPT"].Add("EXPEN.DESCRIPT", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pPTN_Menu_LIST_DB_TR_F"])) ? int.Parse(requestValues["pPTN_Menu_LIST_DB_TR_F"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sPTN_Menu_LIST_DB_TR_F", "dPTN_Menu_LIST_DB_TR_F", requestValues, "expen", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAexpen.FldDescript), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAexpen.FldCoddespe, CSGenioAexpen.FldZzstate, CSGenioAexpen.FldCodyear, CSGenioAyear.FldCodyear, CSGenioAyear.FldYear, CSGenioAexpen.FldYearnumb, CSGenioAexpen.FldCodaggre, CSGenioAagreg.FldCodaggre, CSGenioAagreg.FldValue, CSGenioAexpen.FldDescript, CSGenioAexpen.FldValue, CSGenioAexpen.FldPrevval, CSGenioAexpen.FldCodproje, CSGenioAproje.FldCodproje, CSGenioAproje.FldProjecto };


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
					firstVisibleColumn = new FieldRef("year", "year");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAexpen model_limit_area = new CSGenioAexpen(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLLIST_DB_TR_F");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet ptn_menu_list_db_tr_fConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ LIST_DB_TR_F]/

            // This will happen in case there is an error
            if(ptn_menu_list_db_tr_fConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAexpen>(false, ptn_menu_list_db_tr_fConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLLIST_DB_TR_F", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP LIST_DB_TR_F]/

                conditions = ptn_menu_list_db_tr_fConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST LIST_DB_TR_F]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_expen");
				Navigation.DestroyEntry("QMVC_POS_RECORD_expen");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAexpen.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_list_db_tr_fConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAexpen> listing = Models.ModelBase.Where<CSGenioAexpen>(false, ptn_menu_list_db_tr_fConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLLIST_DB_TR_F", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapPTN_Menu_LIST_DB_TR_F(listing);

				Menu.Identifier = "MLLIST_DB_TR_F";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "MLLIST_DB_TR_F";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Expen> MapPTN_Menu_LIST_DB_TR_F(ListingMVC<CSGenioAexpen> Qlisting)
        {
            var Elements = new List<Models.Expen>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_LIST_DB_TR_F(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAexpen row
        /// to a Models.Expen object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Expen MapPTN_Menu_LIST_DB_TR_F(CSGenioAexpen row)
        {
            var model = new Models.Expen(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "expen":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "year":
                        model.Year.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "agreg":
                        model.Agreg.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "proje":
                        model.Proje.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_LIST_DB_TR_F]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Expen", "Expen.ValCoddespe", "Expen.ValZzstate", "Year", "Year.ValYear", "Expen.ValYearnumb", "Agreg", "Agreg.ValValue", "Expen.ValDescript", "Expen.ValValue", "Expen.ValPrevval", "Proje", "Proje.ValProjecto", "Expen.ValCodaggre", "Expen.ValCodproje", "Expen.ValCodyear"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("Year_ValYear", CSGenioAyear.FldYear, typeof(string)),
            new TableSearchColumn("ValYearnumb", CSGenioAexpen.FldYearnumb, typeof(decimal?)),
            new TableSearchColumn("Agreg_ValValue", CSGenioAagreg.FldValue, typeof(decimal?)),
            new TableSearchColumn("ValDescript", CSGenioAexpen.FldDescript, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValValue", CSGenioAexpen.FldValue, typeof(decimal?)),
            new TableSearchColumn("ValPrevval", CSGenioAexpen.FldPrevval, typeof(decimal?)),
            new TableSearchColumn("Proje_ValProjecto", CSGenioAproje.FldProjecto, typeof(string))
        };

    }
}
