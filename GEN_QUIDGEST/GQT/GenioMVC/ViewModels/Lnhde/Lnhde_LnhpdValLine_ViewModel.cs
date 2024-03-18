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

namespace GenioMVC.ViewModels.Lnhde
{
    public class Lnhde_LnhpdValLine_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Lnhpd> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "lnhpd"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Lnhde_LnhpdValLine"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodlnhde { get; set; }

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

        public string ValCodpedid { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lnhde_LnhpdValLine_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Lnhde_LnhpdValLine_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAlnhpd.FldLine, FieldType.NUMERO, Resources.Resources.LINE27983, 3, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAlnhpd> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "lnhpd" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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

			// Limits Generation

			// Area limit
			tableReload &= AddCriteriaAreaLimit(crs, CSGenio.business.CSGenioApedid.FldCodpedid, "pedid", this.ValCodpedid, true);


			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Lnhpd>();
			Menu.SetFilters(bool.Parse(requestValues["Lnhde_LnhpdValLine_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Lnhde_LnhpdValLine_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Lnhpd.AddEPH<CSGenioAlnhpd>(ref u, crs, "IBL_LNHDE___LNHPDLINE____");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAlnhpd.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlnhpd.FldZzstate), CriteriaOperator.Equal, 0));

			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_lnhpd"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Lnhpd.AddEPH<CSGenioAlnhpd>(ref u, null, "IBL_LNHDE___LNHPDLINE____"));
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
            ListingMVC<CSGenioAlnhpd> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlnhpd> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Lnhde_LnhpdValLine", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Lnhde_LnhpdValLine"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Lnhde_LnhpdValLine");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Lnhpd>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["Lnhde_LnhpdValLine_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pLnhde_LnhpdValLine"])) ? int.Parse(requestValues["pLnhde_LnhpdValLine"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sLnhde_LnhpdValLine", "dLnhde_LnhpdValLine", requestValues, "lnhpd", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAlnhpd.FldCodlnhpd, CSGenioAlnhpd.FldZzstate, CSGenioAlnhpd.FldLine };


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
					firstVisibleColumn = new FieldRef("lnhpd", "line");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAlnhpd model_limit_area = new CSGenioAlnhpd(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_LNHDE___LNHPDLINE____");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 

			//Limit type: "A"			//Current Area = "LNHPD"			//1st Area Limit: "PEDID"			//1st Area Field: "CODPEDID"			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.A;
				limit.NaoAplicaSeNulo = false;
				CSGenioApedid model_limit_area = new CSGenioApedid(UserContext.Current.User);
				string limit_field = "codpedid", limit_field_value = "";
				object this_limit_field = Navigation.GetValue("pedid") == null ? this.ValCodpedid : Navigation.GetValue("pedid");
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet lnhde___lnhpdline____Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ LNHDE_LNHPDLINE]/

            // This will happen in case there is an error
            if(lnhde___lnhpdline____Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAlnhpd>(false, lnhde___lnhpdline____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LNHDE___LNHPDLINE____", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP LNHDE_LNHPDLINE]/

                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST LNHDE_LNHPDLINE]/


				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_lnhpd"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAlnhpd.GetInformation(), QMVC_POS_RECORD, sorts, lnhde___lnhpdline____Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAlnhpd> listing = Models.ModelBase.Where<CSGenioAlnhpd>(false, lnhde___lnhpdline____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LNHDE___LNHPDLINE____", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapLnhde_LnhpdValLine(listing);

				Menu.Identifier = "IBL_LNHDE___LNHPDLINE____";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_LNHDE___LNHPDLINE____";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Lnhpd> MapLnhde_LnhpdValLine(ListingMVC<CSGenioAlnhpd> Qlisting)
        {
            var Elements = new List<Models.Lnhpd>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapLnhde_LnhpdValLine(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAlnhpd row
        /// to a Models.Lnhpd object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Lnhpd MapLnhde_LnhpdValLine(CSGenioAlnhpd row)
        {
            var model = new Models.Lnhpd(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "lnhpd":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHDE_LNHPDVALLINE]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Lnhpd", "Lnhpd.ValCodlnhpd", "Lnhpd.ValZzstate", "Lnhpd.ValLine", "Lnhpd.ValCodpedid", "Lnhpd.ValCodtpequ"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValLine", CSGenioAlnhpd.FldLine, typeof(decimal?))
        };
    }
}
