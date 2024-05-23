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

namespace GenioMVC.ViewModels.Lnhpd
{
    public class Lnhpd_ValDesagreg_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Lnhde> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "lnhde"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Lnhpd_ValDesagreg"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodlnhpd { get; set; }

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
        /// Initializes a new instance of the <see cref="Lnhpd_ValDesagreg_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Lnhpd_ValDesagreg_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAlnhde.FldOrdem, FieldType.NUMERO, Resources.Resources.ORDER39632, 3, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 50, 0, true),
                new Exports.QColumn(CSGenioAlnhde.FldQuantida, FieldType.NUMERO, Resources.Resources.AMOUNT46885, 3, 0, true),
                new Exports.QColumn(CSGenioAlnhde.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 2, true),
                new Exports.QColumn(CSGenioAlnhde.FldCode, FieldType.TEXTO, Resources.Resources.CODE49225, 10, 0, true),
                new Exports.QColumn(CSGenioAlnhde.FldUrl, FieldType.TEXTO, Resources.Resources.SITE06486, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAlnhde> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "lnhde" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Lnhde>();
			Menu.SetFilters(bool.Parse(requestValues["ValDesagreg_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("LNHDE.ORDEM", new OrderedDictionary());
			allSortOrders["LNHDE.ORDEM"].Add("LNHDE.ORDEM", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValDesagreg_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodlnhpd != null)
				crs.Equal(CSGenioAlnhde.FldCodlnhpd, this.ValCodlnhpd);





			if (isToExport)
			{
				// EPH
				crs = Models.Lnhde.AddEPH<CSGenioAlnhde>(ref u, crs, "IBL_LNHPD___PSEUDDESAGREG");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAlnhde.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LNHDE", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAlnhde.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lnhde");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lnhde");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Lnhde.AddEPH<CSGenioAlnhde>(ref u, null, "IBL_LNHPD___PSEUDDESAGREG"));
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
            ListingMVC<CSGenioAlnhde> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlnhde> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Lnhpd_ValDesagreg", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Lnhpd_ValDesagreg"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Lnhpd_ValDesagreg");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Lnhde>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValDesagreg_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("LNHDE.ORDEM", new OrderedDictionary());
			allSortOrders["LNHDE.ORDEM"].Add("LNHDE.ORDEM", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValDesagreg"])) ? int.Parse(requestValues["pValDesagreg"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValDesagreg", "dValDesagreg", requestValues, "lnhde", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlnhde.FldOrdem), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAlnhde.FldCodlnhde, CSGenioAlnhde.FldZzstate, CSGenioAlnhde.FldOrdem, CSGenioAlnhde.FldCodtpequ, CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldTipoequi, CSGenioAlnhde.FldQuantida, CSGenioAlnhde.FldDescript, CSGenioAlnhde.FldCode, CSGenioAlnhde.FldUrl };


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
					firstVisibleColumn = new FieldRef("lnhde", "ordem");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAlnhde model_limit_area = new CSGenioAlnhde(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_LNHPD___PSEUDDESAGREG");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet lnhpd___pseuddesagregConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ LNHPD_PSEUDDESAGREG]/

            // This will happen in case there is an error
            if(lnhpd___pseuddesagregConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAlnhde>(false, lnhpd___pseuddesagregConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LNHPD___PSEUDDESAGREG", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP LNHPD_PSEUDDESAGREG]/

                conditions = lnhpd___pseuddesagregConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST LNHPD_PSEUDDESAGREG]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lnhde");
				Navigation.DestroyEntry("QMVC_POS_RECORD_lnhde");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAlnhde.GetInformation(), QMVC_POS_RECORD, sorts, lnhpd___pseuddesagregConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAlnhde> listing = Models.ModelBase.Where<CSGenioAlnhde>(false, lnhpd___pseuddesagregConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LNHPD___PSEUDDESAGREG", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapLnhpd_ValDesagreg(listing);

				Menu.Identifier = "IBL_LNHPD___PSEUDDESAGREG";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_LNHPD___PSEUDDESAGREG";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Lnhde> MapLnhpd_ValDesagreg(ListingMVC<CSGenioAlnhde> Qlisting)
        {
            var Elements = new List<Models.Lnhde>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapLnhpd_ValDesagreg(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAlnhde row
        /// to a Models.Lnhde object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Lnhde MapLnhpd_ValDesagreg(CSGenioAlnhde row)
        {
            var model = new Models.Lnhde(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "lnhde":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "tpeq1":
                        model.Tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHPD_VALDESAGREG]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Lnhde", "Lnhde.ValCodlnhde", "Lnhde.ValZzstate", "Lnhde.ValOrdem", "Tpeq1", "Tpeq1.ValTipoequi", "Lnhde.ValQuantida", "Lnhde.ValDescript", "Lnhde.ValCode", "Lnhde.ValUrl", "Lnhde.ValCodlnhag", "Lnhde.ValCodlnhpd", "Lnhde.ValCodpedid", "Lnhde.ValCodtpequ"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValOrdem", CSGenioAlnhde.FldOrdem, typeof(decimal?)),
            new TableSearchColumn("Tpeq1_ValTipoequi", CSGenioAtpeq1.FldTipoequi, typeof(string)),
            new TableSearchColumn("ValQuantida", CSGenioAlnhde.FldQuantida, typeof(decimal?)),
            new TableSearchColumn("ValDescript", CSGenioAlnhde.FldDescript, typeof(string)),
            new TableSearchColumn("ValCode", CSGenioAlnhde.FldCode, typeof(string)),
            new TableSearchColumn("ValUrl", CSGenioAlnhde.FldUrl, typeof(string))
        };
    }
}
