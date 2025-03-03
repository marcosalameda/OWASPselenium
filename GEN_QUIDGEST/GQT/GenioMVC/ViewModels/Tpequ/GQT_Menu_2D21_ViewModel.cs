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

namespace GenioMVC.ViewModels.Tpequ
{
    public class GQT_Menu_2D21_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Tpequ> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "tpequ"; }

        /// <inheritdoc/>
        public override string Uuid { get => "17bc4906-db78-4a9c-845c-30c7e64fb3d6"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodtpequ { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS 2D21]/

			return crs;
		}


        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.TYPES_OF_EQUIPMENT61264;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("tpequ", user, "GQT");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAtpequ.FldZzstate, 0); //valid zzstate only

            // Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldCodfamil, CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldPrecomax, CSGenioAtpequ.FldPrecoult, CSGenioAtpequ.FldSince, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldKit };

            ListingMVC<CSGenioAtpequ> listing = new ListingMVC<CSGenioAtpequ>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GQT_Menu_2D21_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public GQT_Menu_2D21_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAfamil.FldFamily, FieldType.TEXTO, Resources.Resources.FAMILIA_DE_EQUIPAMEN12158, 30, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldTpequcod, FieldType.TEXTO, Resources.Resources.CODE49225, 20, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldTpequpai, FieldType.TEXTO, Resources.Resources.DEPENDENT_ON28321, 20, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldNivel, FieldType.NUMERO, Resources.Resources.LEVEL06184, 3, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldBackcolo, FieldType.TEXTO, Resources.Resources.BACKGROUND_COLOR47883, 30, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldCorletra, FieldType.TEXTO, Resources.Resources.LETTER_COLOR15736, 30, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldPrecomax, FieldType.VALOR, Resources.Resources.MAXIMUM_PRICE55489, 12, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldPrecoult, FieldType.VALOR, Resources.Resources.LAST_PRICE25852, 12, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldSince, FieldType.DATAHORA, Resources.Resources.SINCE47259, 16, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldQtdequip, FieldType.NUMERO, Resources.Resources.AMOUNT46885, 6, 0, true),
                new Exports.QColumn(CSGenioAtpequ.FldKit, FieldType.LOGICO, Resources.Resources.KIT27179, 1, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAtpequ> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "tpequ" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Tpequ>();
			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_2D21_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "GQT_Menu_2D21_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Tpequ.AddEPH<CSGenioAtpequ>(ref u, crs, "ML2D21");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtpequ.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("TPEQU", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAtpequ.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpequ");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tpequ.AddEPH<CSGenioAtpequ>(ref u, null, "ML2D21"));
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
            ListingMVC<CSGenioAtpequ> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpequ> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "GQT_Menu_2D21", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "GQT_Menu_2D21"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_2D21");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Tpequ>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("TPEQU.TIPOEQUI", new OrderedDictionary());
			allSortOrders["TPEQU.TIPOEQUI"].Add("TPEQU.TIPOEQUI", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pGQT_Menu_2D21"])) ? int.Parse(requestValues["pGQT_Menu_2D21"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sGQT_Menu_2D21", "dGQT_Menu_2D21", requestValues, "tpequ", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTipoequi), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldCodfamil, CSGenioAfamil.FldCodfamil, CSGenioAfamil.FldFamily, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldPrecomax, CSGenioAtpequ.FldPrecoult, CSGenioAtpequ.FldSince, CSGenioAtpequ.FldQtdequip, CSGenioAtpequ.FldKit };


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
					firstVisibleColumn = new FieldRef("famil", "family");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAtpequ model_limit_area = new CSGenioAtpequ(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML2D21");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet gqt_menu_2d21Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 2D21]/

            // This will happen in case there is an error
            if(gqt_menu_2d21Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAtpequ>(false, gqt_menu_2d21Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2D21", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 2D21]/

                conditions = gqt_menu_2d21Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST 2D21]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpequ");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tpequ");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAtpequ.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_2d21Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(false, gqt_menu_2d21Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML2D21", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapGQT_Menu_2D21(listing);

				Menu.Identifier = "ML2D21";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML2D21";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Tpequ> MapGQT_Menu_2D21(ListingMVC<CSGenioAtpequ> Qlisting)
        {
            var Elements = new List<Models.Tpequ>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_2D21(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAtpequ row
        /// to a Models.Tpequ object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Tpequ MapGQT_Menu_2D21(CSGenioAtpequ row)
        {
            var model = new Models.Tpequ(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "tpequ":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "famil":
                        model.Famil.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_2D21]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Famil", "Famil.ValFamily", "Tpequ.ValTipoequi", "Tpequ.ValTpequcod", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra", "Tpequ.ValPrecomax", "Tpequ.ValPrecoult", "Tpequ.ValSince", "Tpequ.ValQtdequip", "Tpequ.ValKit", "Tpequ.ValCodfamil"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("Famil_ValFamily", CSGenioAfamil.FldFamily, typeof(string)),
            new TableSearchColumn("ValTipoequi", CSGenioAtpequ.FldTipoequi, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValTpequcod", CSGenioAtpequ.FldTpequcod, typeof(string)),
            new TableSearchColumn("ValTpequpai", CSGenioAtpequ.FldTpequpai, typeof(string)),
            new TableSearchColumn("ValNivel", CSGenioAtpequ.FldNivel, typeof(decimal)),
            new TableSearchColumn("ValBackcolo", CSGenioAtpequ.FldBackcolo, typeof(string)),
            new TableSearchColumn("ValCorletra", CSGenioAtpequ.FldCorletra, typeof(string)),
            new TableSearchColumn("ValPrecomax", CSGenioAtpequ.FldPrecomax, typeof(decimal?)),
            new TableSearchColumn("ValPrecoult", CSGenioAtpequ.FldPrecoult, typeof(decimal?)),
            new TableSearchColumn("ValSince", CSGenioAtpequ.FldSince, typeof(DateTime?)),
            new TableSearchColumn("ValQtdequip", CSGenioAtpequ.FldQtdequip, typeof(decimal?)),
            new TableSearchColumn("ValKit", CSGenioAtpequ.FldKit, typeof(bool))
        };

    }
}
