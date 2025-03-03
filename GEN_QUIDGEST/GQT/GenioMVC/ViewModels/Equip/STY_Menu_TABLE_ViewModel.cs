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

namespace GenioMVC.ViewModels.Equip
{
    public class STY_Menu_TABLE_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Equip> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "equip"; }

        /// <inheritdoc/>
        public override string Uuid { get => "6215afe4-2b62-44b3-92eb-54468e9325fe"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodequip { get; set; }

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
// USE /[MANUAL STY LIST_LIMITS TABLE]/

			return crs;
		}


        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.TABLE15475;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("equip", user, "STY");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAequip.FldZzstate, 0); //valid zzstate only

            // Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAequip.FldSequennr, CSGenioAequip.FldRegistnr, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldIfabatif, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldFrequenc, CSGenioAequip.FldBought, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldSitefabr };

            ListingMVC<CSGenioAequip> listing = new ListingMVC<CSGenioAequip>(fields, null, 1, 1, false, user, true, string.Empty, true);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="STY_Menu_TABLE_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public STY_Menu_TABLE_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.DESIGNATION35876, 30, 0, true),
                new Exports.QColumn(CSGenioAequip.FldSequennr, FieldType.NUMERO, Resources.Resources.SEQUENTIAL_NO_38590, 6, 0, true),
                new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
                new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, true),
                new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXTO, Resources.Resources.ITEM40802, 30, 0, true),
                new Exports.QColumn(CSGenioAequip.FldDtaquisi, FieldType.DATA, Resources.Resources.ACQUISITION44180, 8, 0, true),
                new Exports.QColumn(CSGenioAequip.FldIfabatif, FieldType.LOGICO, Resources.Resources.DOWNED_EQUIPMENT43331, 1, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAequip.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
                new Exports.QColumn(CSGenioAequip.FldValortot, FieldType.VALOR, Resources.Resources.TOTAL_VALUE30570, 12, 0, true),
                new Exports.QColumn(CSGenioAequip.FldFrequenc, FieldType.ARRAY_COD_NUMERICO, Resources.Resources.LOAN_FREQUENCY00701, 1, 0, true, "FreqEmpr"),
                new Exports.QColumn(CSGenioAequip.FldBought, FieldType.LOGICO, Resources.Resources.BOUGHT32044, 1, 0, true),
                new Exports.QColumn(CSGenioAroom1.FldRoomnr, FieldType.TEXTO, Resources.Resources.N_R__ROOM43805, 10, 0, true),
                new Exports.QColumn(CSGenioAequip.FldSitefabr, FieldType.TEXTO, Resources.Resources.MANUFACTURER_S_WEBSI11084, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAequip> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "equip" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Equip>();
			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_TABLE_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "STY_Menu_TABLE_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Equip.AddEPH<CSGenioAequip>(ref u, crs, "MLTABLE");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAequip.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("EQUIP", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAequip.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Equip.AddEPH<CSGenioAequip>(ref u, null, "MLTABLE"));
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
            ListingMVC<CSGenioAequip> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAequip> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "STY_Menu_TABLE", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "STY_Menu_TABLE"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "STY_Menu_TABLE");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Equip>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("EQUIP.REGISTNR", new OrderedDictionary());
			allSortOrders["EQUIP.REGISTNR"].Add("EQUIP.REGISTNR", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pSTY_Menu_TABLE"])) ? int.Parse(requestValues["pSTY_Menu_TABLE"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sSTY_Menu_TABLE", "dSTY_Menu_TABLE", requestValues, "equip", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAequip.FldRegistnr), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAequip.FldCodequip, CSGenioAequip.FldZzstate, CSGenioAequip.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAequip.FldSequennr, CSGenioAequip.FldRegistnr, CSGenioAequip.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAequip.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAequip.FldDtaquisi, CSGenioAequip.FldIfabatif, CSGenioAequip.FldPhotogra, CSGenioAequip.FldValortot, CSGenioAequip.FldFrequenc, CSGenioAequip.FldBought, CSGenioAequip.FldCodrooms, CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAequip.FldSitefabr };


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
					firstVisibleColumn = new FieldRef("cmpny", "designat");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAequip model_limit_area = new CSGenioAequip(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLTABLE");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet sty_menu_tableConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ TABLE]/

            // This will happen in case there is an error
            if(sty_menu_tableConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAequip>(false, sty_menu_tableConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLTABLE", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP TABLE]/

                conditions = sty_menu_tableConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL STY OVERRQLIST TABLE]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_equip");
				Navigation.DestroyEntry("QMVC_POS_RECORD_equip");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAequip.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_tableConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAequip> listing = Models.ModelBase.Where<CSGenioAequip>(false, sty_menu_tableConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLTABLE", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapSTY_Menu_TABLE(listing);

				Menu.Identifier = "MLTABLE";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "MLTABLE";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Equip> MapSTY_Menu_TABLE(ListingMVC<CSGenioAequip> Qlisting)
        {
            var Elements = new List<Models.Equip>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_TABLE(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAequip row
        /// to a Models.Equip object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Equip MapSTY_Menu_TABLE(CSGenioAequip row)
        {
            var model = new Models.Equip(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "equip":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "cmpny":
                        model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "wareh":
                        model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "item":
                        model.Item.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "room1":
                        model.Room1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_TABLE]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Equip", "Equip.ValCodequip", "Equip.ValZzstate", "Cmpny", "Cmpny.ValDesignat", "Equip.ValSequennr", "Equip.ValRegistnr", "Wareh", "Wareh.ValWarehdes", "Item", "Item.ValItemdes", "Equip.ValDtaquisi", "Equip.ValIfabatif", "Equip.ValPhotogra", "Equip.ValValortot", "Equip.ValFrequenc", "Equip.ValBought", "Room1", "Room1.ValRoomnr", "Equip.ValSitefabr", "Equip.ValCodempre", "Equip.ValCoddeco", "Equip.ValCoditem", "Equip.ValCodpess1", "Equip.ValCodrooms", "Equip.ValCodtpequ", "Equip.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string)),
            new TableSearchColumn("ValSequennr", CSGenioAequip.FldSequennr, typeof(decimal?)),
            new TableSearchColumn("ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string), defaultSearch : true),
            new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string)),
            new TableSearchColumn("Item_ValItemdes", CSGenioAitem.FldItemdes, typeof(string)),
            new TableSearchColumn("ValDtaquisi", CSGenioAequip.FldDtaquisi, typeof(DateTime?)),
            new TableSearchColumn("ValIfabatif", CSGenioAequip.FldIfabatif, typeof(bool)),
            new TableSearchColumn("ValValortot", CSGenioAequip.FldValortot, typeof(decimal?)),
            new TableSearchColumn("ValFrequenc", CSGenioAequip.FldFrequenc, typeof(decimal), array : "FreqEmpr"),
            new TableSearchColumn("ValBought", CSGenioAequip.FldBought, typeof(bool)),
            new TableSearchColumn("Room1_ValRoomnr", CSGenioAroom1.FldRoomnr, typeof(string)),
            new TableSearchColumn("ValSitefabr", CSGenioAequip.FldSitefabr, typeof(string))
        };

    }
}
