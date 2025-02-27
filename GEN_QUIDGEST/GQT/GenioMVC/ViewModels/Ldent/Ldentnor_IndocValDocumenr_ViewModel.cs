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

namespace GenioMVC.ViewModels.Ldent
{
    public class Ldentnor_IndocValDocumenr_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Indoc> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "indoc"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Ldentnor_IndocValDocumenr"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodldent { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS LDENTNOR_INDOCDOCUMENR]/

			return crs;
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="Ldentnor_IndocValDocumenr_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Ldentnor_IndocValDocumenr_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodldent = currentNavigation.CurrentLevel.GetEntry("ldent")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAindoc.FldDocumenr, FieldType.NUMERO, Resources.Resources.NO_14817, 10, 0, true),
                new Exports.QColumn(CSGenioAindoc.FldDhdocume, FieldType.DATAHORA, Resources.Resources.DATE18475, 16, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAindoc> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "indoc" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Indoc>();
			Menu.SetFilters(bool.Parse(requestValues["Ldentnor_IndocValDocumenr_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("INDOC.DHDOCUME", new OrderedDictionary());
			allSortOrders["INDOC.DHDOCUME"].Add("INDOC.DHDOCUME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Ldentnor_IndocValDocumenr_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Indoc.AddEPH<CSGenioAindoc>(ref u, crs, "IBL_LDENTNORINDOCDOCUMENR");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAindoc.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAindoc.FldZzstate), CriteriaOperator.Equal, 0));

			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_indoc"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Indoc.AddEPH<CSGenioAindoc>(ref u, null, "IBL_LDENTNORINDOCDOCUMENR"));
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
            ListingMVC<CSGenioAindoc> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAindoc> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Ldentnor_IndocValDocumenr", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Ldentnor_IndocValDocumenr"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Ldentnor_IndocValDocumenr");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Indoc>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("INDOC.DHDOCUME", new OrderedDictionary());
			allSortOrders["INDOC.DHDOCUME"].Add("INDOC.DHDOCUME", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pLdentnor_IndocValDocumenr"])) ? int.Parse(requestValues["pLdentnor_IndocValDocumenr"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sLdentnor_IndocValDocumenr", "dLdentnor_IndocValDocumenr", requestValues, "indoc", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAindoc.FldDhdocume), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAindoc.FldCoddentr, CSGenioAindoc.FldZzstate, CSGenioAindoc.FldDocumenr, CSGenioAindoc.FldDhdocume };


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
					firstVisibleColumn = new FieldRef("indoc", "documenr");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAindoc model_limit_area = new CSGenioAindoc(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_LDENTNORINDOCDOCUMENR");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet ldentnorindocdocumenrConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ LDENTNOR_INDOCDOCUMENR]/

            // This will happen in case there is an error
            if(ldentnorindocdocumenrConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAindoc>(false, ldentnorindocdocumenrConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LDENTNORINDOCDOCUMENR", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP LDENTNOR_INDOCDOCUMENR]/

                conditions = ldentnorindocdocumenrConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST LDENTNOR_INDOCDOCUMENR]/


				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_indoc"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAindoc.GetInformation(), QMVC_POS_RECORD, sorts, ldentnorindocdocumenrConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAindoc> listing = Models.ModelBase.Where<CSGenioAindoc>(false, ldentnorindocdocumenrConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_LDENTNORINDOCDOCUMENR", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapLdentnor_IndocValDocumenr(listing);

				Menu.Identifier = "IBL_LDENTNORINDOCDOCUMENR";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_LDENTNORINDOCDOCUMENR";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Indoc> MapLdentnor_IndocValDocumenr(ListingMVC<CSGenioAindoc> Qlisting)
        {
            var Elements = new List<Models.Indoc>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapLdentnor_IndocValDocumenr(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAindoc row
        /// to a Models.Indoc object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Indoc MapLdentnor_IndocValDocumenr(CSGenioAindoc row)
        {
            var model = new Models.Indoc(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "indoc":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM LDENTNOR_INDOCVALDOCUMENR]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Indoc", "Indoc.ValCoddentr", "Indoc.ValZzstate", "Indoc.ValDocumenr", "Indoc.ValDhdocume", "Indoc.ValCodempre", "Indoc.ValCodcntry", "Indoc.ValCodpesso", "Indoc.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValDocumenr", CSGenioAindoc.FldDocumenr, typeof(decimal?)),
            new TableSearchColumn("ValDhdocume", CSGenioAindoc.FldDhdocume, typeof(DateTime?))
        };

    }
}
