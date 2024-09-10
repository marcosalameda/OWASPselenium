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
    public class Gmaps_ValInstalac_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Insta> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "insta"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Gmaps_ValInstalac"; }

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
        /// Initializes a new instance of the <see cref="Gmaps_ValInstalac_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Gmaps_ValInstalac_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodequip = currentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAinsta.FldSince, FieldType.DATAHORA, Resources.Resources.SINCE47259, 16, 0, true),
                new Exports.QColumn(CSGenioAinsta.FldUntil, FieldType.DATAHORA, Resources.Resources.UNTIL39173, 16, 0, true),
                new Exports.QColumn(CSGenioAinsta.FldHours, FieldType.NUMERO, Resources.Resources.QTD_HOURS28684, 10, 2, true),
                new Exports.QColumn(CSGenioAinsta.FldPrecohor, FieldType.VALOR, Resources.Resources.HOURLY_PRICE48005, 12, 0, true),
                new Exports.QColumn(CSGenioAinsta.FldValue, FieldType.VALOR, Resources.Resources.VALUE10285, 12, 0, true),
                new Exports.QColumn(CSGenioAinsta.FldCoordgeo, FieldType.GEOGRAPHY, Resources.Resources.GEOGRAPHIC_COORDINAT21394, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAinsta> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "insta" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Insta>();
			Menu.SetFilters(bool.Parse(requestValues["ValInstalac_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValInstalac_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodequip != null)
				crs.Equal(CSGenioAinsta.FldCodequip, this.ValCodequip);





			if (isToExport)
			{
				// EPH
				crs = Models.Insta.AddEPH<CSGenioAinsta>(ref u, crs, "IBL_GMAPS___PSEUDINSTALAC");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAinsta.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("INSTA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAinsta.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_insta");
				Navigation.DestroyEntry("QMVC_POS_RECORD_insta");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Insta.AddEPH<CSGenioAinsta>(ref u, null, "IBL_GMAPS___PSEUDINSTALAC"));
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
            ListingMVC<CSGenioAinsta> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAinsta> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Gmaps_ValInstalac", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Gmaps_ValInstalac"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Gmaps_ValInstalac");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Insta>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValInstalac_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValInstalac"])) ? int.Parse(requestValues["pValInstalac"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValInstalac", "dValInstalac", requestValues, "insta", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAinsta.FldCodinsta, CSGenioAinsta.FldZzstate, CSGenioAinsta.FldSince, CSGenioAinsta.FldUntil, CSGenioAinsta.FldHours, CSGenioAinsta.FldPrecohor, CSGenioAinsta.FldValue, CSGenioAinsta.FldCoordgeo };


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
					firstVisibleColumn = new FieldRef("insta", "since");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAinsta model_limit_area = new CSGenioAinsta(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_GMAPS___PSEUDINSTALAC");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet gmaps___pseudinstalacConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ GMAPS_PSEUDINSTALAC]/

            // This will happen in case there is an error
            if(gmaps___pseudinstalacConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAinsta>(false, gmaps___pseudinstalacConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_GMAPS___PSEUDINSTALAC", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP GMAPS_PSEUDINSTALAC]/

                conditions = gmaps___pseudinstalacConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST GMAPS_PSEUDINSTALAC]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_insta");
				Navigation.DestroyEntry("QMVC_POS_RECORD_insta");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAinsta.GetInformation(), QMVC_POS_RECORD, sorts, gmaps___pseudinstalacConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAinsta> listing = Models.ModelBase.Where<CSGenioAinsta>(false, gmaps___pseudinstalacConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_GMAPS___PSEUDINSTALAC", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapGmaps_ValInstalac(listing);

				Menu.Identifier = "IBL_GMAPS___PSEUDINSTALAC";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_GMAPS___PSEUDINSTALAC";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Insta> MapGmaps_ValInstalac(ListingMVC<CSGenioAinsta> Qlisting)
        {
            var Elements = new List<Models.Insta>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGmaps_ValInstalac(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAinsta row
        /// to a Models.Insta object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Insta MapGmaps_ValInstalac(CSGenioAinsta row)
        {
            var model = new Models.Insta(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "insta":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GMAPS_VALINSTALAC]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Insta", "Insta.ValCodinsta", "Insta.ValZzstate", "Insta.ValSince", "Insta.ValUntil", "Insta.ValHours", "Insta.ValPrecohor", "Insta.ValValue", "Insta.ValCoordgeo", "Insta.ValCodequip", "Insta.ValCodtpequ"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValSince", CSGenioAinsta.FldSince, typeof(DateTime?)),
            new TableSearchColumn("ValUntil", CSGenioAinsta.FldUntil, typeof(DateTime?)),
            new TableSearchColumn("ValHours", CSGenioAinsta.FldHours, typeof(decimal?)),
            new TableSearchColumn("ValPrecohor", CSGenioAinsta.FldPrecohor, typeof(decimal?)),
            new TableSearchColumn("ValValue", CSGenioAinsta.FldValue, typeof(decimal?))
        };

    }
}
