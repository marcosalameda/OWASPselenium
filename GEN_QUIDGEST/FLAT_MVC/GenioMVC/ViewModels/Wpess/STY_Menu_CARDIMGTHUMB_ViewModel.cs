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

namespace GenioMVC.ViewModels.Wpess
{
    public class STY_Menu_CARDIMGTHUMB_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Wpess> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "wpess"; }

        /// <inheritdoc/>
        public override string Uuid { get => "5b3c192d-de40-4fc4-bf07-308da67f2edd"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodpess { get; set; }

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
            dbeditTitle = Resources.Resources.CARD_IMAGE_THUMBNAIL58531;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("wpess", user, "STY");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAwpess.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAwpess.FldCodpess, CSGenioAwpess.FldZzstate, CSGenioAwpess.FldName, CSGenioAwpess.FldDate, CSGenioAwpess.FldSex, CSGenioAwpess.FldNfunc, CSGenioAwpess.FldAdress, CSGenioAwpess.FldZipcode, CSGenioAwpess.FldCountry, CSGenioAwpess.FldEmail, CSGenioAwpess.FldCellphon, CSGenioAwpess.FldNaturali, CSGenioAwpess.FldNacional, CSGenioAwpess.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwpess.FldFtthumb };

            ListingMVC<CSGenioAwpess> listing = new ListingMVC<CSGenioAwpess>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="STY_Menu_CARDIMGTHUMB_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public STY_Menu_CARDIMGTHUMB_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAwpess.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldDate, FieldType.DATA, Resources.Resources.DATA_DE_NASCIMENTO48110, 8, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldSex, FieldType.ARRAY_COD_TEXTO, Resources.Resources.SEXO52099, 9, 0, true, "SEXO"),
                new Exports.QColumn(CSGenioAwpess.FldNfunc, FieldType.NUMERO, Resources.Resources.NOFUNCIONARIO21429, 1, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldAdress, FieldType.TEXTO, Resources.Resources.ADDRESS04342, 30, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldZipcode, FieldType.TEXTO, Resources.Resources.ZIP_CODE56964, 8, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldCountry, FieldType.TEXTO, Resources.Resources.PAIS04637, 30, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldCellphon, FieldType.NUMERO, Resources.Resources.NOTELEFONE56747, 9, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldNaturali, FieldType.TEXTO, Resources.Resources.NATURALNESS33189, 30, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldNacional, FieldType.TEXTO, Resources.Resources.NACIONALIDADE23735, 30, 0, true),
                new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXTO, Resources.Resources.WAREHOUSE51864, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAwpess.FldFtthumb, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE_THUMBNAIL01682, 3, 1, true):null,
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAwpess> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "wpess" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Wpess>();
			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_CARDIMGTHUMB_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("WPESS.NAME", new OrderedDictionary());
			allSortOrders["WPESS.NAME"].Add("WPESS.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "STY_Menu_CARDIMGTHUMB_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Wpess.AddEPH<CSGenioAwpess>(ref u, crs, "MLCARDIMGTHUMB");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAwpess.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("WPESS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAwpess.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
				Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Wpess.AddEPH<CSGenioAwpess>(ref u, null, "MLCARDIMGTHUMB"));
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
            ListingMVC<CSGenioAwpess> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAwpess> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "STY_Menu_CARDIMGTHUMB", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "STY_Menu_CARDIMGTHUMB"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "STY_Menu_CARDIMGTHUMB");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Wpess>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("WPESS.NAME", new OrderedDictionary());
			allSortOrders["WPESS.NAME"].Add("WPESS.NAME", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pSTY_Menu_CARDIMGTHUMB"])) ? int.Parse(requestValues["pSTY_Menu_CARDIMGTHUMB"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sSTY_Menu_CARDIMGTHUMB", "dSTY_Menu_CARDIMGTHUMB", requestValues, "wpess", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwpess.FldName), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAwpess.FldCodpess, CSGenioAwpess.FldZzstate, CSGenioAwpess.FldName, CSGenioAwpess.FldDate, CSGenioAwpess.FldSex, CSGenioAwpess.FldNfunc, CSGenioAwpess.FldAdress, CSGenioAwpess.FldZipcode, CSGenioAwpess.FldCountry, CSGenioAwpess.FldEmail, CSGenioAwpess.FldCellphon, CSGenioAwpess.FldNaturali, CSGenioAwpess.FldNacional, CSGenioAwpess.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwpess.FldFtthumb };


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
					firstVisibleColumn = new FieldRef("wpess", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAwpess model_limit_area = new CSGenioAwpess(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLCARDIMGTHUMB");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet sty_menu_cardimgthumbConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL STY OVERRQ CARDIMGTHUMB]/

            // This will happen in case there is an error
            if(sty_menu_cardimgthumbConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAwpess>(false, sty_menu_cardimgthumbConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLCARDIMGTHUMB", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP CARDIMGTHUMB]/

                conditions = sty_menu_cardimgthumbConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL STY OVERRQLIST CARDIMGTHUMB]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
				Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAwpess.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_cardimgthumbConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAwpess> listing = Models.ModelBase.Where<CSGenioAwpess>(false, sty_menu_cardimgthumbConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLCARDIMGTHUMB", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapSTY_Menu_CARDIMGTHUMB(listing);

				Menu.Identifier = "MLCARDIMGTHUMB";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "MLCARDIMGTHUMB";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Wpess> MapSTY_Menu_CARDIMGTHUMB(ListingMVC<CSGenioAwpess> Qlisting)
        {
            var Elements = new List<Models.Wpess>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_CARDIMGTHUMB(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAwpess row
        /// to a Models.Wpess object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Wpess MapSTY_Menu_CARDIMGTHUMB(CSGenioAwpess row)
        {
            var model = new Models.Wpess(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "wpess":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "wareh":
                        model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_CARDIMGTHUMB]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Wpess", "Wpess.ValCodpess", "Wpess.ValZzstate", "Wpess.ValName", "Wpess.ValDate", "Wpess.ValSex", "Wpess.ValNfunc", "Wpess.ValAdress", "Wpess.ValZipcode", "Wpess.ValCountry", "Wpess.ValEmail", "Wpess.ValCellphon", "Wpess.ValNaturali", "Wpess.ValNacional", "Wareh", "Wareh.ValWarehdes", "Wpess.ValFtthumb", "Wpess.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValName", CSGenioAwpess.FldName, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValDate", CSGenioAwpess.FldDate, typeof(DateTime?)),
            new TableSearchColumn("ValSex", CSGenioAwpess.FldSex, typeof(string), array : "SEXO"),
            new TableSearchColumn("ValNfunc", CSGenioAwpess.FldNfunc, typeof(decimal?)),
            new TableSearchColumn("ValAdress", CSGenioAwpess.FldAdress, typeof(string)),
            new TableSearchColumn("ValZipcode", CSGenioAwpess.FldZipcode, typeof(string)),
            new TableSearchColumn("ValCountry", CSGenioAwpess.FldCountry, typeof(string)),
            new TableSearchColumn("ValEmail", CSGenioAwpess.FldEmail, typeof(string)),
            new TableSearchColumn("ValCellphon", CSGenioAwpess.FldCellphon, typeof(decimal?)),
            new TableSearchColumn("ValNaturali", CSGenioAwpess.FldNaturali, typeof(string)),
            new TableSearchColumn("ValNacional", CSGenioAwpess.FldNacional, typeof(string)),
            new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string))
        };

        // Note: cannot be marked static because some variables might depend on the current user language.
        private readonly SpecialRenderingsCfg _viewModes = new SpecialRenderingsCfg()
        {
            SpecialRenderings = new List<SpecialRendering>()
            {
                new SpecialRendering
                {
                    Id = "LIST",
                    Ordem = 1,
                    Subtipo = "",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                    },
                },
                new SpecialRendering
                {
                    Id = "CARDS",
                    Ordem = 2,
                    Subtipo = "card-img-thumbnail",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "title", Value = "WPESS.NAME", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "text", Value = "WPESS.NACIONAL", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "text", Value = "WPESS.NFUNC", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "text", Value = "WPESS.DATE", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "image", Value = "WPESS.FTTHUMB", AllowMultiple = false },
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "hover-scale-amount", Value = "1.05" },
                        new SpecialRenderingVariable { Variable = "content-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "actions-alignment", Value = "right" },
                        new SpecialRenderingVariable { Variable = "background-color", Value = "auto" },
                        new SpecialRenderingVariable { Variable = "actions-placement", Value = "footer" },
                        new SpecialRenderingVariable { Variable = "show-column-titles", Value = "true" },
                        new SpecialRenderingVariable { Variable = "actions-style", Value = "dropdown" },
                        new SpecialRenderingVariable { Variable = "custom-followup-default-target", Value = "blank" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card", Value = "false" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card-style", Value = "secondary" },
                        new SpecialRenderingVariable { Variable = "display-mode", Value = "grid" },
                        new SpecialRenderingVariable { Variable = "container-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "show-empty-column-titles", Value = "true" },
                        new SpecialRenderingVariable { Variable = "size", Value = "regular" },
                    },
                },
            }
        };

        override public SpecialRenderingsCfg ViewModesCfg { get => _viewModes; }

    }
}
