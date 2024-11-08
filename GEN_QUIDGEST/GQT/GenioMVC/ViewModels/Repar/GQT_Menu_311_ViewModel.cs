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

namespace GenioMVC.ViewModels.Repar
{
    public class GQT_Menu_311_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Repar> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "repar"; }

        /// <inheritdoc/>
        public override string Uuid { get => "eb5c42d7-9401-4743-a232-b08f9c554f17"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodrepar { get; set; }

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
            dbeditTitle = Resources.Resources.REPAIRS18165;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("repar", user, "GQT");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioArepar.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldTipoarea, CSGenioArepar.FldCodespec, CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioArepar.FldDescript, CSGenioArepar.FldHours, CSGenioArepar.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };

            ListingMVC<CSGenioArepar> listing = new ListingMVC<CSGenioArepar>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GQT_Menu_311_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public GQT_Menu_311_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioArepar.FldNrrepara, FieldType.NUMERO, Resources.Resources.REPAIR_NO_45492, 10, 0, true),
                new Exports.QColumn(CSGenioArepar.FldDtrepara, FieldType.DATAHORA, Resources.Resources.FIXED_IN00179, 16, 0, true),
                new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
                new Exports.QColumn(CSGenioAequip.FldDesignat, FieldType.TEXTO, Resources.Resources.EQUIPMENT03632, 30, 0, true),
                new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXTO, Resources.Resources.TECHNICAL18245, 30, 0, true),
                new Exports.QColumn(CSGenioArepar.FldTipoarea, FieldType.ARRAY_COD_TEXTO, Resources.Resources.TECHNICAL_AREA50773, 1, 0, true, "AreaTecn"),
                new Exports.QColumn(CSGenioAspeci.FldEspecial, FieldType.TEXTO, Resources.Resources.SPECIALTY09304, 30, 0, true),
                new Exports.QColumn(CSGenioArepar.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION_OF_THE_R26085, 30, 3, true),
                new Exports.QColumn(CSGenioArepar.FldHours, FieldType.NUMERO, Resources.Resources.SPENT_ON_HOURS19285, 10, 0, true),
                new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.COMPANY52963, 30, 0, false),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioArepar> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "repar" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Repar>();
			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_311_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("REPAR.DTREPARA", new OrderedDictionary());
			allSortOrders["REPAR.DTREPARA"].Add("REPAR.DTREPARA", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "GQT_Menu_311_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Repar.AddEPH<CSGenioArepar>(ref u, crs, "ML311");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArepar.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("REPAR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArepar.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Repar.AddEPH<CSGenioArepar>(ref u, null, "ML311"));
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
            ListingMVC<CSGenioArepar> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArepar> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "GQT_Menu_311", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "GQT_Menu_311"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_311");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Repar>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("REPAR.DTREPARA", new OrderedDictionary());
			allSortOrders["REPAR.DTREPARA"].Add("REPAR.DTREPARA", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pGQT_Menu_311"])) ? int.Parse(requestValues["pGQT_Menu_311"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sGQT_Menu_311", "dGQT_Menu_311", requestValues, "repar", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArepar.FldDtrepara), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAequip.FldDesignat, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldTipoarea, CSGenioArepar.FldCodespec, CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial, CSGenioArepar.FldDescript, CSGenioArepar.FldHours, CSGenioArepar.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };


			//columns by users list (TemplateDBEditViewModel)
			userColumns = UserUiSettings.Load(UserContext.Current.PersistentSupport, Uuid, UserContext.Current.User).UserColumns;
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
					firstVisibleColumn = new FieldRef("repar", "nrrepara");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArepar model_limit_area = new CSGenioArepar(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML311");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet gqt_menu_311Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 311]/

            // This will happen in case there is an error
            if(gqt_menu_311Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioArepar>(false, gqt_menu_311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML311", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 311]/

                conditions = gqt_menu_311Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST 311]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioArepar.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_311Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioArepar> listing = Models.ModelBase.Where<CSGenioArepar>(false, gqt_menu_311Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML311", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapGQT_Menu_311(listing);

				Menu.Identifier = "ML311";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML311";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Repar> MapGQT_Menu_311(ListingMVC<CSGenioArepar> Qlisting)
        {
            var Elements = new List<Models.Repar>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_311(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioArepar row
        /// to a Models.Repar object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Repar MapGQT_Menu_311(CSGenioArepar row)
        {
            var model = new Models.Repar(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "repar":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "equip":
                        model.Equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pesso":
                        model.Pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "speci":
                        model.Speci.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "cmpny":
                        model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_311]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Repar", "Repar.ValCodrepar", "Repar.ValZzstate", "Repar.ValNrrepara", "Repar.ValDtrepara", "Equip", "Equip.ValRegistnr", "Equip.ValDesignat", "Pesso", "Pesso.ValName", "Repar.ValTipoarea", "Speci", "Speci.ValEspecial", "Repar.ValDescript", "Repar.ValHours", "Cmpny", "Cmpny.ValDesignat", "Repar.ValCodcateg", "Repar.ValCodempre", "Repar.ValCodequip", "Repar.ValCodpesso", "Repar.ValCodespec"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValNrrepara", CSGenioArepar.FldNrrepara, typeof(decimal?)),
            new TableSearchColumn("ValDtrepara", CSGenioArepar.FldDtrepara, typeof(DateTime?), defaultSearch : true),
            new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
            new TableSearchColumn("Equip_ValDesignat", CSGenioAequip.FldDesignat, typeof(string)),
            new TableSearchColumn("Pesso_ValName", CSGenioApesso.FldName, typeof(string)),
            new TableSearchColumn("ValTipoarea", CSGenioArepar.FldTipoarea, typeof(string), array : "AreaTecn"),
            new TableSearchColumn("Speci_ValEspecial", CSGenioAspeci.FldEspecial, typeof(string)),
            new TableSearchColumn("ValDescript", CSGenioArepar.FldDescript, typeof(string)),
            new TableSearchColumn("ValHours", CSGenioArepar.FldHours, typeof(decimal?)),
            new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string), visible : false)
        };

    }
}
