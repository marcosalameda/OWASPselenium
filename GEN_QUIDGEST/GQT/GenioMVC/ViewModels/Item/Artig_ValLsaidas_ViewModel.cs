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

namespace GenioMVC.ViewModels.Item
{
    public class Artig_ValLsaidas_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Outpu> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "outpu"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Artig_ValLsaidas"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCoditem { get; set; }

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
        /// Initializes a new instance of the <see cref="Artig_ValLsaidas_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Artig_ValLsaidas_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAoutpu.FldExitdt, FieldType.DATAHORA, Resources.Resources.EXIT_INSTANT27038, 16, 0, true),
                new Exports.QColumn(CSGenioAoutpt.FldDocumenr, FieldType.NUMERO, Resources.Resources.DOCUMENT_NO_30174, 10, 0, true),
                new Exports.QColumn(CSGenioAoutpu.FldLine, FieldType.NUMERO, Resources.Resources.LINE27983, 5, 1, true),
                new Exports.QColumn(CSGenioAoutpu.FldExitqnty, FieldType.NUMERO, Resources.Resources.QTD_OUTPUT12876, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAoutpu> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "outpu" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Outpu>();
			Menu.SetFilters(bool.Parse(requestValues["ValLsaidas_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("OUTPU.EXITDT", new OrderedDictionary());
			allSortOrders["OUTPU.EXITDT"].Add("OUTPU.EXITDT", "D");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValLsaidas_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCoditem != null)
				crs.Equal(CSGenioAoutpu.FldCoditem, this.ValCoditem);





			if (isToExport)
			{
				// EPH
				crs = Models.Outpu.AddEPH<CSGenioAoutpu>(ref u, crs, "IBL_ARTIG___PSEUDLSAIDAS_");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAoutpu.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("OUTPU", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAoutpu.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_outpu");
				Navigation.DestroyEntry("QMVC_POS_RECORD_outpu");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Outpu.AddEPH<CSGenioAoutpu>(ref u, null, "IBL_ARTIG___PSEUDLSAIDAS_"));
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
            ListingMVC<CSGenioAoutpu> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAoutpu> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Artig_ValLsaidas", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Artig_ValLsaidas"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Artig_ValLsaidas");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Outpu>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValLsaidas_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("OUTPU.EXITDT", new OrderedDictionary());
			allSortOrders["OUTPU.EXITDT"].Add("OUTPU.EXITDT", "D");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValLsaidas"])) ? int.Parse(requestValues["pValLsaidas"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValLsaidas", "dValLsaidas", requestValues, "outpu", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoutpu.FldExitdt), SortOrder.Descending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAoutpu.FldCodoutpu, CSGenioAoutpu.FldZzstate, CSGenioAoutpu.FldExitdt, CSGenioAoutpu.FldCodoutpt, CSGenioAoutpt.FldCodoutpt, CSGenioAoutpt.FldDocumenr, CSGenioAoutpu.FldLine, CSGenioAoutpu.FldExitqnty };


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
					firstVisibleColumn = new FieldRef("outpu", "exitdt");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAoutpu model_limit_area = new CSGenioAoutpu(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ARTIG___PSEUDLSAIDAS_");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet artig___pseudlsaidas_Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ ARTIG_PSEUDLSAIDAS]/

            // This will happen in case there is an error
            if(artig___pseudlsaidas_Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAoutpu>(false, artig___pseudlsaidas_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ARTIG___PSEUDLSAIDAS_", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ARTIG_PSEUDLSAIDAS]/

                conditions = artig___pseudlsaidas_Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ARTIG_PSEUDLSAIDAS]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_outpu");
				Navigation.DestroyEntry("QMVC_POS_RECORD_outpu");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAoutpu.GetInformation(), QMVC_POS_RECORD, sorts, artig___pseudlsaidas_Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAoutpu> listing = Models.ModelBase.Where<CSGenioAoutpu>(false, artig___pseudlsaidas_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ARTIG___PSEUDLSAIDAS_", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapArtig_ValLsaidas(listing);

				Menu.Identifier = "IBL_ARTIG___PSEUDLSAIDAS_";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ARTIG___PSEUDLSAIDAS_";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Outpu> MapArtig_ValLsaidas(ListingMVC<CSGenioAoutpu> Qlisting)
        {
            var Elements = new List<Models.Outpu>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapArtig_ValLsaidas(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAoutpu row
        /// to a Models.Outpu object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Outpu MapArtig_ValLsaidas(CSGenioAoutpu row)
        {
            var model = new Models.Outpu(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "outpu":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "outpt":
                        model.Outpt.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARTIG_VALLSAIDAS]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Outpu", "Outpu.ValCodoutpu", "Outpu.ValZzstate", "Outpu.ValExitdt", "Outpt", "Outpt.ValDocumenr", "Outpu.ValLine", "Outpu.ValExitqnty", "Outpu.ValCodoutpt", "Outpt.ValCodoutpt", "Outpu.ValCoditem", "Outpu.ValCoddocsd", "Outpu.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValExitdt", CSGenioAoutpu.FldExitdt, typeof(DateTime?)),
            new TableSearchColumn("Outpt_ValDocumenr", CSGenioAoutpt.FldDocumenr, typeof(decimal?)),
            new TableSearchColumn("ValLine", CSGenioAoutpu.FldLine, typeof(decimal?)),
            new TableSearchColumn("ValExitqnty", CSGenioAoutpu.FldExitqnty, typeof(decimal?))
        };
    }
}
