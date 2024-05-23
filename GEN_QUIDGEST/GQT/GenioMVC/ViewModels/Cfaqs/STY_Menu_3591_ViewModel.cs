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

namespace GenioMVC.ViewModels.Cfaqs
{
    public class STY_Menu_3591_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Cfaqs> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "cfaqs"; }

        /// <inheritdoc/>
        public override string Uuid { get => "c620143f-29ba-4b06-855d-55c48acfe0c6"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodcfaqs { get; set; }

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
            dbeditTitle = Resources.Resources.CATEGORY_FAQS42471;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("cfaqs", user, "STY");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAcfaqs.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAcfaqs.FldCodcfaqs, CSGenioAcfaqs.FldZzstate, CSGenioAcfaqs.FldIcon, CSGenioAcfaqs.FldCategory, CSGenioAcfaqs.FldDescript };

            ListingMVC<CSGenioAcfaqs> listing = new ListingMVC<CSGenioAcfaqs>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="STY_Menu_3591_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public STY_Menu_3591_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                !ajaxRequest ? new Exports.QColumn(CSGenioAcfaqs.FldIcon, FieldType.IMAGEM_JPEG, String.Empty, 3, 1, true):null,
                new Exports.QColumn(CSGenioAcfaqs.FldCategory, FieldType.MEMO, Resources.Resources.CATEGORY18978, 30, 3, true),
                new Exports.QColumn(CSGenioAcfaqs.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 3, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAcfaqs> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "cfaqs" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Cfaqs>();
			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_3591_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "STY_Menu_3591_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Cfaqs.AddEPH<CSGenioAcfaqs>(ref u, crs, "ML3591");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcfaqs.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CFAQS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcfaqs.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cfaqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cfaqs");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Cfaqs.AddEPH<CSGenioAcfaqs>(ref u, null, "ML3591"));
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
            ListingMVC<CSGenioAcfaqs> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcfaqs> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "STY_Menu_3591", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "STY_Menu_3591"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "STY_Menu_3591");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Cfaqs>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["STY_Menu_3591_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pSTY_Menu_3591"])) ? int.Parse(requestValues["pSTY_Menu_3591"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sSTY_Menu_3591", "dSTY_Menu_3591", requestValues, "cfaqs", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAcfaqs.FldCodcfaqs, CSGenioAcfaqs.FldZzstate, CSGenioAcfaqs.FldIcon, CSGenioAcfaqs.FldCategory, CSGenioAcfaqs.FldDescript };


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
					firstVisibleColumn = new FieldRef("cfaqs", "icon");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAcfaqs model_limit_area = new CSGenioAcfaqs(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML3591");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet sty_menu_3591Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL STY OVERRQ 3591]/

            // This will happen in case there is an error
            if(sty_menu_3591Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAcfaqs>(false, sty_menu_3591Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3591", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL STY OVERRQLSTEXP 3591]/

                conditions = sty_menu_3591Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL STY OVERRQLIST 3591]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_cfaqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_cfaqs");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAcfaqs.GetInformation(), QMVC_POS_RECORD, sorts, sty_menu_3591Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAcfaqs> listing = Models.ModelBase.Where<CSGenioAcfaqs>(false, sty_menu_3591Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML3591", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapSTY_Menu_3591(listing);

				Menu.Identifier = "ML3591";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML3591";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Cfaqs> MapSTY_Menu_3591(ListingMVC<CSGenioAcfaqs> Qlisting)
        {
            var Elements = new List<Models.Cfaqs>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSTY_Menu_3591(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAcfaqs row
        /// to a Models.Cfaqs object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Cfaqs MapSTY_Menu_3591(CSGenioAcfaqs row)
        {
            var model = new Models.Cfaqs(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "cfaqs":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM STY_MENU_3591]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Cfaqs", "Cfaqs.ValCodcfaqs", "Cfaqs.ValZzstate", "Cfaqs.ValIcon", "Cfaqs.ValCategory", "Cfaqs.ValDescript"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValCategory", CSGenioAcfaqs.FldCategory, typeof(string)),
            new TableSearchColumn("ValDescript", CSGenioAcfaqs.FldDescript, typeof(string))
        };

        // Note: cannot be marked static because some variables might depend on the current user language.
        private readonly SpecialRenderingsCfg _viewModes = new SpecialRenderingsCfg()
        {
            SpecialRenderings = new List<SpecialRendering>()
            {
                new SpecialRendering
                {
                    Id = "CARDS",
                    Ordem = 1,
                    Subtipo = "card-img-thumbnail",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "title", Value = "CFAQS.CATEGORY", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "text", Value = "CFAQS.DESCRIPT", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "image", Value = "CFAQS.ICON", AllowMultiple = false },
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "show-empty-column-titles", Value = "true" },
                        new SpecialRenderingVariable { Variable = "actions-alignment", Value = "right" },
                        new SpecialRenderingVariable { Variable = "content-alignment", Value = "center" },
                        new SpecialRenderingVariable { Variable = "actions-placement", Value = "footer" },
                        new SpecialRenderingVariable { Variable = "hover-scale-amount", Value = "1.00" },
                        new SpecialRenderingVariable { Variable = "show-column-titles", Value = "false" },
                        new SpecialRenderingVariable { Variable = "background-color", Value = "auto" },
                        new SpecialRenderingVariable { Variable = "actions-style", Value = "dropdown" },
                        new SpecialRenderingVariable { Variable = "custom-followup-default-target", Value = "blank" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card", Value = "false" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card-style", Value = "secondary" },
                        new SpecialRenderingVariable { Variable = "display-mode", Value = "grid" },
                        new SpecialRenderingVariable { Variable = "container-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "size", Value = "regular" },
                    },
                },
            }
        };

        override public SpecialRenderingsCfg ViewModesCfg { get => _viewModes; }
    }
}
