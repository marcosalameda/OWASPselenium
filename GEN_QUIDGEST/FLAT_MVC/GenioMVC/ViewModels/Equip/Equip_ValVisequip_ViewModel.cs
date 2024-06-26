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
    public class Equip_ValVisequip_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Visit> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "visit"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Equip_ValVisequip"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodequip { get; set; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Equip_ValVisequip_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Equip_ValVisequip_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodequip = currentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAvisit.FldTitle, FieldType.TEXTO, Resources.Resources.TITLE21885, 30, 0, true),
                new Exports.QColumn(CSGenioAvisit.FldStartdt, FieldType.DATAHORA, Resources.Resources.BEGINNING18124, 16, 0, true),
                new Exports.QColumn(CSGenioAvisit.FldDtfim, FieldType.DATAHORA, Resources.Resources.END47577, 16, 0, true),
                new Exports.QColumn(CSGenioAvisit.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 3, true),
                new Exports.QColumn(CSGenioAvisit.FldTodoodia, FieldType.LOGICO, Resources.Resources.DAY27593, 1, 0, true),
                new Exports.QColumn(CSGenioAvisit.FldColor, FieldType.TEXTO, Resources.Resources.COLOR55628, 30, 0, true),
                new Exports.QColumn(CSGenioAvisit.FldBack, FieldType.LOGICO, Resources.Resources.BACKGROUND45121, 1, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAvisit> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "visit" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Visit>();
			Menu.SetFilters(bool.Parse(requestValues["ValVisequip_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("VISIT.TITLE", new OrderedDictionary());
			allSortOrders["VISIT.TITLE"].Add("VISIT.TITLE", "A");
			allSortOrders.Add("VISIT.STARTDT", new OrderedDictionary());
			allSortOrders["VISIT.STARTDT"].Add("VISIT.STARTDT", "A");
			allSortOrders.Add("VISIT.DTFIM", new OrderedDictionary());
			allSortOrders["VISIT.DTFIM"].Add("VISIT.DTFIM", "A");
			allSortOrders.Add("VISIT.COLOR", new OrderedDictionary());
			allSortOrders["VISIT.COLOR"].Add("VISIT.COLOR", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValVisequip_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodequip != null)
				crs.Equal(CSGenioAvisit.FldCodequip, this.ValCodequip);





			if (isToExport)
			{
				// EPH
				crs = Models.Visit.AddEPH<CSGenioAvisit>(ref u, crs, "IBL_EQUIP___PSEUDVISEQUIP");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAvisit.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("VISIT", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAvisit.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_visit");
				Navigation.DestroyEntry("QMVC_POS_RECORD_visit");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Visit.AddEPH<CSGenioAvisit>(ref u, null, "IBL_EQUIP___PSEUDVISEQUIP"));
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
            ListingMVC<CSGenioAvisit> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAvisit> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Equip_ValVisequip", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Equip_ValVisequip"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Equip_ValVisequip");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Visit>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValVisequip_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("VISIT.TITLE", new OrderedDictionary());
			allSortOrders["VISIT.TITLE"].Add("VISIT.TITLE", "A");
			allSortOrders.Add("VISIT.STARTDT", new OrderedDictionary());
			allSortOrders["VISIT.STARTDT"].Add("VISIT.STARTDT", "A");
			allSortOrders.Add("VISIT.DTFIM", new OrderedDictionary());
			allSortOrders["VISIT.DTFIM"].Add("VISIT.DTFIM", "A");
			allSortOrders.Add("VISIT.COLOR", new OrderedDictionary());
			allSortOrders["VISIT.COLOR"].Add("VISIT.COLOR", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValVisequip"])) ? int.Parse(requestValues["pValVisequip"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValVisequip", "dValVisequip", requestValues, "visit", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAvisit.FldTitle), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAvisit.FldStartdt), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAvisit.FldDtfim), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAvisit.FldColor), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAvisit.FldCodvisit, CSGenioAvisit.FldZzstate, CSGenioAvisit.FldTitle, CSGenioAvisit.FldStartdt, CSGenioAvisit.FldDtfim, CSGenioAvisit.FldDescript, CSGenioAvisit.FldTodoodia, CSGenioAvisit.FldColor, CSGenioAvisit.FldBack };


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
					firstVisibleColumn = new FieldRef("visit", "title");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAvisit model_limit_area = new CSGenioAvisit(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_EQUIP___PSEUDVISEQUIP");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet equip___pseudvisequipConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ EQUIP_PSEUDVISEQUIP]/

            // This will happen in case there is an error
            if(equip___pseudvisequipConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAvisit>(false, equip___pseudvisequipConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___PSEUDVISEQUIP", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP EQUIP_PSEUDVISEQUIP]/

                conditions = equip___pseudvisequipConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST EQUIP_PSEUDVISEQUIP]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_visit");
				Navigation.DestroyEntry("QMVC_POS_RECORD_visit");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAvisit.GetInformation(), QMVC_POS_RECORD, sorts, equip___pseudvisequipConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAvisit> listing = Models.ModelBase.Where<CSGenioAvisit>(false, equip___pseudvisequipConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___PSEUDVISEQUIP", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapEquip_ValVisequip(listing);

				Menu.Identifier = "IBL_EQUIP___PSEUDVISEQUIP";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_EQUIP___PSEUDVISEQUIP";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Visit> MapEquip_ValVisequip(ListingMVC<CSGenioAvisit> Qlisting)
        {
            var Elements = new List<Models.Visit>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapEquip_ValVisequip(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAvisit row
        /// to a Models.Visit object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Visit MapEquip_ValVisequip(CSGenioAvisit row)
        {
            var model = new Models.Visit(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "visit":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_VALVISEQUIP]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Visit", "Visit.ValCodvisit", "Visit.ValZzstate", "Visit.ValTitle", "Visit.ValStartdt", "Visit.ValDtfim", "Visit.ValDescript", "Visit.ValTodoodia", "Visit.ValColor", "Visit.ValBack", "Visit.ValCodequip"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValTitle", CSGenioAvisit.FldTitle, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValStartdt", CSGenioAvisit.FldStartdt, typeof(DateTime?)),
            new TableSearchColumn("ValDtfim", CSGenioAvisit.FldDtfim, typeof(DateTime?)),
            new TableSearchColumn("ValDescript", CSGenioAvisit.FldDescript, typeof(string)),
            new TableSearchColumn("ValTodoodia", CSGenioAvisit.FldTodoodia, typeof(bool)),
            new TableSearchColumn("ValColor", CSGenioAvisit.FldColor, typeof(string)),
            new TableSearchColumn("ValBack", CSGenioAvisit.FldBack, typeof(bool))
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
                    Id = "CALENDAR",
                    Ordem = 2,
                    Subtipo = "",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "event-title", Value = "VISIT.TITLE", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "event-start", Value = "VISIT.STARTDT", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "event-end", Value = "VISIT.DTFIM", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "event-description", Value = "VISIT.DESCRIPT", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "event-all-day", Value = "VISIT.TODOODIA", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "event-color", Value = "VISIT.COLOR", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "event-is-background", Value = "VISIT.BACK", AllowMultiple = false },
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "view-day-grid-month", Value = "true" },
                        new SpecialRenderingVariable { Variable = "view-day-grid-day", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-day-grid-week", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-time-grid-day", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-time-grid-week", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-list-day", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-list-week", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-list-month", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-list-year", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-timeline-day", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-timeline-week", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-timeline-month", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-timeline-year", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-time-grid-day", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-time-grid-week", Value = "false" },
                        new SpecialRenderingVariable { Variable = "view-resource-day-grid-day", Value = "false" },
                        new SpecialRenderingVariable { Variable = "initial-view", Value = "" },
                        new SpecialRenderingVariable { Variable = "extra-weekends", Value = "true" },
                        new SpecialRenderingVariable { Variable = "extra-events-overlap", Value = "false" },
                        new SpecialRenderingVariable { Variable = "extra-auto-height", Value = "false" },
                        new SpecialRenderingVariable { Variable = "extra-max-height", Value = "750" },
                        new SpecialRenderingVariable { Variable = "extra-no-tooltips", Value = "false" },
                        new SpecialRenderingVariable { Variable = "extra-all-day-slot", Value = "true" },
                        new SpecialRenderingVariable { Variable = "extra-full-reload", Value = "false" },
                        new SpecialRenderingVariable { Variable = "extra-slot-min-time", Value = "" },
                        new SpecialRenderingVariable { Variable = "extra-slot-max-time", Value = "" },
                        new SpecialRenderingVariable { Variable = "extra-no-dates", Value = "false" },
                        new SpecialRenderingVariable { Variable = "extra-limit-range-start", Value = "" },
                        new SpecialRenderingVariable { Variable = "extra-limit-range-end", Value = "" },
                        new SpecialRenderingVariable { Variable = "extra-hour-12", Value = "false" },
                        new SpecialRenderingVariable { Variable = "extra-slot-duration", Value = "" },
                        new SpecialRenderingVariable { Variable = "extra-slot-label-interval", Value = "" },
                    },
                },
            }
        };

        override public SpecialRenderingsCfg ViewModesCfg { get => _viewModes; }
    }
}
