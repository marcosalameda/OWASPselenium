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
    public class Artig_ValLentrada_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Ldent> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "ldent"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Artig_ValLentrada"; }

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
        /// Initializes a new instance of the <see cref="Artig_ValLentrada_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Artig_ValLentrada_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCoditem = currentNavigation.CurrentLevel.GetEntry("item")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAldent.FldDhentra, FieldType.DATAHORA, Resources.Resources.INSTANT_ENTRANCE27379, 16, 0, true),
                new Exports.QColumn(CSGenioAindoc.FldDocumenr, FieldType.NUMERO, Resources.Resources.DOCUMENT_NO_30174, 10, 0, true),
                new Exports.QColumn(CSGenioAldent.FldLine, FieldType.NUMERO, Resources.Resources.LINE27983, 5, 1, true),
                new Exports.QColumn(CSGenioAldent.FldQtdentra, FieldType.NUMERO, Resources.Resources.QTD_ENTRY35144, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAldent> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "ldent" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Ldent>();
			Menu.SetFilters(bool.Parse(requestValues["ValLentrada_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("LDENT.DHENTRA", new OrderedDictionary());
			allSortOrders["LDENT.DHENTRA"].Add("LDENT.DHENTRA", "D");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValLentrada_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCoditem != null)
				crs.Equal(CSGenioAldent.FldCoditem, this.ValCoditem);





			if (isToExport)
			{
				// EPH
				crs = Models.Ldent.AddEPH<CSGenioAldent>(ref u, crs, "IBL_ARTIG___PSEUDLENTRADA");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAldent.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("LDENT", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAldent.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_ldent");
				Navigation.DestroyEntry("QMVC_POS_RECORD_ldent");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Ldent.AddEPH<CSGenioAldent>(ref u, null, "IBL_ARTIG___PSEUDLENTRADA"));
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
            ListingMVC<CSGenioAldent> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAldent> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Artig_ValLentrada", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Artig_ValLentrada"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Artig_ValLentrada");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Ldent>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValLentrada_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("LDENT.DHENTRA", new OrderedDictionary());
			allSortOrders["LDENT.DHENTRA"].Add("LDENT.DHENTRA", "D");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValLentrada"])) ? int.Parse(requestValues["pValLentrada"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValLentrada", "dValLentrada", requestValues, "ldent", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAldent.FldDhentra), SortOrder.Descending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAldent.FldCodldent, CSGenioAldent.FldZzstate, CSGenioAldent.FldDhentra, CSGenioAldent.FldCoddentr, CSGenioAindoc.FldCoddentr, CSGenioAindoc.FldDocumenr, CSGenioAldent.FldLine, CSGenioAldent.FldQtdentra };


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
					firstVisibleColumn = new FieldRef("ldent", "dhentra");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAldent model_limit_area = new CSGenioAldent(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ARTIG___PSEUDLENTRADA");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet artig___pseudlentradaConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ ARTIG_PSEUDLENTRADA]/

            // This will happen in case there is an error
            if(artig___pseudlentradaConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAldent>(false, artig___pseudlentradaConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ARTIG___PSEUDLENTRADA", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ARTIG_PSEUDLENTRADA]/

                conditions = artig___pseudlentradaConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ARTIG_PSEUDLENTRADA]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_ldent");
				Navigation.DestroyEntry("QMVC_POS_RECORD_ldent");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAldent.GetInformation(), QMVC_POS_RECORD, sorts, artig___pseudlentradaConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAldent> listing = Models.ModelBase.Where<CSGenioAldent>(false, artig___pseudlentradaConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ARTIG___PSEUDLENTRADA", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapArtig_ValLentrada(listing);

				Menu.Identifier = "IBL_ARTIG___PSEUDLENTRADA";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ARTIG___PSEUDLENTRADA";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Ldent> MapArtig_ValLentrada(ListingMVC<CSGenioAldent> Qlisting)
        {
            var Elements = new List<Models.Ldent>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapArtig_ValLentrada(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAldent row
        /// to a Models.Ldent object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Ldent MapArtig_ValLentrada(CSGenioAldent row)
        {
            var model = new Models.Ldent(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "ldent":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "indoc":
                        model.Indoc.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARTIG_VALLENTRADA]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Ldent", "Ldent.ValCodldent", "Ldent.ValZzstate", "Ldent.ValDhentra", "Indoc", "Indoc.ValDocumenr", "Ldent.ValLine", "Ldent.ValQtdentra", "Ldent.ValCoddentr", "Indoc.ValCoddentr", "Ldent.ValCoditem", "Ldent.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValDhentra", CSGenioAldent.FldDhentra, typeof(DateTime?)),
            new TableSearchColumn("Indoc_ValDocumenr", CSGenioAindoc.FldDocumenr, typeof(decimal?)),
            new TableSearchColumn("ValLine", CSGenioAldent.FldLine, typeof(decimal?)),
            new TableSearchColumn("ValQtdentra", CSGenioAldent.FldQtdentra, typeof(decimal?))
        };
    }
}
