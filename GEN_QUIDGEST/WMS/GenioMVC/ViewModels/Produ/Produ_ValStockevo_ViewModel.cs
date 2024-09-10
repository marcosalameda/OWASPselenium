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

namespace GenioMVC.ViewModels.Produ
{
    public class Produ_ValStockevo_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Stock> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "stock"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Produ_ValStockevo"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodprodu { get; set; }

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
        /// Initializes a new instance of the <see cref="Produ_ValStockevo_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Produ_ValStockevo_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodprodu = currentNavigation.CurrentLevel.GetEntry("produ")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAstock.FldSequence, FieldType.NUMERO, Resources.Resources.SEQUENCE42310, 6, 0, true),
                new Exports.QColumn(CSGenioAstock.FldDate, FieldType.DATAHORA, Resources.Resources.DATE18475, 16, 0, true),
                new Exports.QColumn(CSGenioAstock.FldType, FieldType.TEXTO, Resources.Resources.TYPE00312, 8, 0, true),
                new Exports.QColumn(CSGenioAstock.FldReferenc, FieldType.TEXTO, Resources.Resources.REFERENCE28402, 10, 0, true),
                new Exports.QColumn(CSGenioAstock.FldQuantity, FieldType.NUMERO, Resources.Resources.QUANTITY06415, 10, 0, true),
                new Exports.QColumn(CSGenioAstock.FldBalance, FieldType.NUMERO, Resources.Resources.BALANCE13297, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAstock> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "stock" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Stock>();
			Menu.SetFilters(bool.Parse(requestValues["ValStockevo_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValStockevo_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodprodu != null)
				crs.Equal(CSGenioAstock.FldCodprodu, this.ValCodprodu);





			if (isToExport)
			{
				// EPH
				crs = Models.Stock.AddEPH<CSGenioAstock>(ref u, crs, "IBL_PRODU___PSEUDSTOCKEVO");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAstock.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("STOCK", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAstock.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_stock");
				Navigation.DestroyEntry("QMVC_POS_RECORD_stock");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Stock.AddEPH<CSGenioAstock>(ref u, null, "IBL_PRODU___PSEUDSTOCKEVO"));
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
            ListingMVC<CSGenioAstock> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAstock> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Produ_ValStockevo", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Produ_ValStockevo"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Produ_ValStockevo");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Stock>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValStockevo_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValStockevo"])) ? int.Parse(requestValues["pValStockevo"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValStockevo", "dValStockevo", requestValues, "stock", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAstock.FldCodstock, CSGenioAstock.FldZzstate, CSGenioAstock.FldSequence, CSGenioAstock.FldDate, CSGenioAstock.FldType, CSGenioAstock.FldReferenc, CSGenioAstock.FldQuantity, CSGenioAstock.FldBalance };


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
					firstVisibleColumn = new FieldRef("stock", "sequence");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAstock model_limit_area = new CSGenioAstock(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PRODU___PSEUDSTOCKEVO");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet produ___pseudstockevoConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PRODU_PSEUDSTOCKEVO]/

            // This will happen in case there is an error
            if(produ___pseudstockevoConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAstock>(false, produ___pseudstockevoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PRODU___PSEUDSTOCKEVO", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PRODU_PSEUDSTOCKEVO]/

                conditions = produ___pseudstockevoConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST PRODU_PSEUDSTOCKEVO]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_stock");
				Navigation.DestroyEntry("QMVC_POS_RECORD_stock");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAstock.GetInformation(), QMVC_POS_RECORD, sorts, produ___pseudstockevoConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAstock> listing = Models.ModelBase.Where<CSGenioAstock>(false, produ___pseudstockevoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PRODU___PSEUDSTOCKEVO", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapProdu_ValStockevo(listing);

				Menu.Identifier = "IBL_PRODU___PSEUDSTOCKEVO";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_PRODU___PSEUDSTOCKEVO";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Stock> MapProdu_ValStockevo(ListingMVC<CSGenioAstock> Qlisting)
        {
            var Elements = new List<Models.Stock>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapProdu_ValStockevo(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAstock row
        /// to a Models.Stock object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Stock MapProdu_ValStockevo(CSGenioAstock row)
        {
            var model = new Models.Stock(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "stock":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PRODU_VALSTOCKEVO]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Stock", "Stock.ValCodstock", "Stock.ValZzstate", "Stock.ValSequence", "Stock.ValDate", "Stock.ValType", "Stock.ValReferenc", "Stock.ValQuantity", "Stock.ValBalance", "Stock.ValCoddispa", "Stock.ValCodprodu", "Stock.ValCodrecei"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValSequence", CSGenioAstock.FldSequence, typeof(decimal?)),
            new TableSearchColumn("ValDate", CSGenioAstock.FldDate, typeof(DateTime?)),
            new TableSearchColumn("ValType", CSGenioAstock.FldType, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValReferenc", CSGenioAstock.FldReferenc, typeof(string)),
            new TableSearchColumn("ValQuantity", CSGenioAstock.FldQuantity, typeof(decimal?)),
            new TableSearchColumn("ValBalance", CSGenioAstock.FldBalance, typeof(decimal?))
        };

    }
}
