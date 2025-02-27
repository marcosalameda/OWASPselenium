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

namespace GenioMVC.ViewModels.Flds
{
    public class PTN_Menu_271_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Flds> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "flds"; }

        /// <inheritdoc/>
        public override string Uuid { get => "32a1f511-9029-4390-aa28-2f7ddfc6c2c6"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodflds { get; set; }

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
// USE /[MANUAL PTN LIST_LIMITS 271]/

			return crs;
		}


        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.FIELD_TYPES49172;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("flds", user, "PTN");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAflds.FldZzstate, 0); //valid zzstate only

            // Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCond, CSGenioAflds.FldFclient1, CSGenioAflds.FldFserver1, CSGenioAflds.FldFclient2, CSGenioAflds.FldFserver2, CSGenioAflds.FldFclient3, CSGenioAflds.FldFserver3 };

            ListingMVC<CSGenioAflds> listing = new ListingMVC<CSGenioAflds>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PTN_Menu_271_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public PTN_Menu_271_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAflds.FldCond, FieldType.ARRAY_COD_TEXTO, Resources.Resources.FIELD_STATE03599, 8, 0, true, "aCondTst"),
                new Exports.QColumn(CSGenioAflds.FldFclient1, FieldType.TEXTO, Resources.Resources.FIELD_WITH_CLIENT_SI60452, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldFserver1, FieldType.DATAHORA, Resources.Resources.FIELD_WITH_SERVER_SI13554, 16, 0, true),
                new Exports.QColumn(CSGenioAflds.FldFclient2, FieldType.LOGICO, Resources.Resources.FIELD_WITH_CLIENT_SI60452, 1, 0, true),
                new Exports.QColumn(CSGenioAflds.FldFserver2, FieldType.NUMERO, Resources.Resources.FIELD_WITH_SERVER_SI13554, 8, 2, true),
                new Exports.QColumn(CSGenioAflds.FldFclient3, FieldType.FICHEIRO_BD, Resources.Resources.FIELD_WITH_CLIENT_SI60452, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAflds.FldFserver3, FieldType.IMAGEM_JPEG, Resources.Resources.FIELD_WITH_SERVER_SI13554, 3, 1, true):null,
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAflds> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "flds" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Flds>();
			Menu.SetFilters(bool.Parse(requestValues["PTN_Menu_271_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "PTN_Menu_271_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Flds.AddEPH<CSGenioAflds>(ref u, crs, "ML271");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAflds.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FLDS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAflds.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Flds.AddEPH<CSGenioAflds>(ref u, null, "ML271"));
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
            ListingMVC<CSGenioAflds> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAflds> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "PTN_Menu_271", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "PTN_Menu_271"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "PTN_Menu_271");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Flds>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pPTN_Menu_271"])) ? int.Parse(requestValues["pPTN_Menu_271"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sPTN_Menu_271", "dPTN_Menu_271", requestValues, "flds", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCond, CSGenioAflds.FldFclient1, CSGenioAflds.FldFserver1, CSGenioAflds.FldFclient2, CSGenioAflds.FldFserver2, CSGenioAflds.FldFclient3, CSGenioAflds.FldFclient3fk, CSGenioAflds.FldFserver3 };


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
					firstVisibleColumn = new FieldRef("flds", "cond");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAflds model_limit_area = new CSGenioAflds(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML271");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet ptn_menu_271Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 271]/

            // This will happen in case there is an error
            if(ptn_menu_271Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAflds>(false, ptn_menu_271Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML271", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 271]/

                conditions = ptn_menu_271Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST 271]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				Navigation.DestroyEntry("QMVC_POS_RECORD_flds");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAflds.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_271Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAflds> listing = Models.ModelBase.Where<CSGenioAflds>(false, ptn_menu_271Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML271", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapPTN_Menu_271(listing);

				Menu.Identifier = "ML271";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML271";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Flds> MapPTN_Menu_271(ListingMVC<CSGenioAflds> Qlisting)
        {
            var Elements = new List<Models.Flds>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_271(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAflds row
        /// to a Models.Flds object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Flds MapPTN_Menu_271(CSGenioAflds row)
        {
            var model = new Models.Flds(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "flds":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_271]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Flds", "Flds.ValCodflds", "Flds.ValZzstate", "Flds.ValCond", "Flds.ValFclient1", "Flds.ValFserver1", "Flds.ValFclient2", "Flds.ValFserver2", "Flds.ValFclient3", "Flds.ValFserver3", "Flds.ValCodaero", "Flds.ValCodequip"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValCond", CSGenioAflds.FldCond, typeof(string), array : "aCondTst"),
            new TableSearchColumn("ValFclient1", CSGenioAflds.FldFclient1, typeof(string)),
            new TableSearchColumn("ValFserver1", CSGenioAflds.FldFserver1, typeof(DateTime?)),
            new TableSearchColumn("ValFclient2", CSGenioAflds.FldFclient2, typeof(bool)),
            new TableSearchColumn("ValFserver2", CSGenioAflds.FldFserver2, typeof(decimal?)),
            new TableSearchColumn("ValFclient3", CSGenioAflds.FldFclient3, typeof(string))
        };

    }
}
