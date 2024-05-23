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

namespace GenioMVC.ViewModels.Recei
{
    public class Recei_ValReceiptl_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Relin> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "relin"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Recei_ValReceiptl"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodrecei { get; set; }

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
        /// Initializes a new instance of the <see cref="Recei_ValReceiptl_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Recei_ValReceiptl_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioArelin.FldLinenumb, FieldType.NUMERO, Resources.Resources.LINE27983, 6, 0, true),
                new Exports.QColumn(CSGenioAprodu.FldSku, FieldType.TEXTO, Resources.Resources.SKU42303, 20, 0, true),
                new Exports.QColumn(CSGenioAprodu.FldGtin, FieldType.TEXTO, Resources.Resources.GTIN45487, 14, 0, false),
                new Exports.QColumn(CSGenioAprodu.FldProduct, FieldType.TEXTO, Resources.Resources.PRODUCT12880, 30, 0, true),
                new Exports.QColumn(CSGenioArelin.FldOrdered, FieldType.NUMERO, Resources.Resources.ORDERED04034, 10, 0, true),
                new Exports.QColumn(CSGenioArelin.FldReceived, FieldType.NUMERO, Resources.Resources.RECEIVED19242, 10, 0, true),
                new Exports.QColumn(CSGenioArelin.FldOutstand, FieldType.NUMERO, Resources.Resources.OUTSTANDING36400, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioArelin> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "relin" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Relin>();
			Menu.SetFilters(bool.Parse(requestValues["ValReceiptl_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("RELIN.LINENUMB", new OrderedDictionary());
			allSortOrders["RELIN.LINENUMB"].Add("RELIN.LINENUMB", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValReceiptl_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodrecei != null)
				crs.Equal(CSGenioArelin.FldCodrecei, this.ValCodrecei);





			if (isToExport)
			{
				// EPH
				crs = Models.Relin.AddEPH<CSGenioArelin>(ref u, crs, "IBL_RECEI___PSEUDRECEIPTL");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArelin.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("RELIN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArelin.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_relin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_relin");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Relin.AddEPH<CSGenioArelin>(ref u, null, "IBL_RECEI___PSEUDRECEIPTL"));
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
            ListingMVC<CSGenioArelin> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArelin> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Recei_ValReceiptl", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Recei_ValReceiptl"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Recei_ValReceiptl");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Relin>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValReceiptl_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("RELIN.LINENUMB", new OrderedDictionary());
			allSortOrders["RELIN.LINENUMB"].Add("RELIN.LINENUMB", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValReceiptl"])) ? int.Parse(requestValues["pValReceiptl"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValReceiptl", "dValReceiptl", requestValues, "relin", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArelin.FldLinenumb), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioArelin.FldCoddilin, CSGenioArelin.FldZzstate, CSGenioArelin.FldLinenumb, CSGenioArelin.FldCodprodu, CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldSku, CSGenioAprodu.FldGtin, CSGenioAprodu.FldProduct, CSGenioArelin.FldOrdered, CSGenioArelin.FldReceived, CSGenioArelin.FldOutstand };


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
					firstVisibleColumn = new FieldRef("relin", "linenumb");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArelin model_limit_area = new CSGenioArelin(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_RECEI___PSEUDRECEIPTL");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet recei___pseudreceiptlConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ RECEI_PSEUDRECEIPTL]/

            // This will happen in case there is an error
            if(recei___pseudreceiptlConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioArelin>(false, recei___pseudreceiptlConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_RECEI___PSEUDRECEIPTL", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP RECEI_PSEUDRECEIPTL]/

                conditions = recei___pseudreceiptlConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST RECEI_PSEUDRECEIPTL]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_relin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_relin");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioArelin.GetInformation(), QMVC_POS_RECORD, sorts, recei___pseudreceiptlConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioArelin> listing = Models.ModelBase.Where<CSGenioArelin>(false, recei___pseudreceiptlConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_RECEI___PSEUDRECEIPTL", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapRecei_ValReceiptl(listing);

				Menu.Identifier = "IBL_RECEI___PSEUDRECEIPTL";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_RECEI___PSEUDRECEIPTL";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Relin> MapRecei_ValReceiptl(ListingMVC<CSGenioArelin> Qlisting)
        {
            var Elements = new List<Models.Relin>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapRecei_ValReceiptl(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioArelin row
        /// to a Models.Relin object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Relin MapRecei_ValReceiptl(CSGenioArelin row)
        {
            var model = new Models.Relin(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "relin":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "produ":
                        model.Produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM RECEI_VALRECEIPTL]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Relin", "Relin.ValCoddilin", "Relin.ValZzstate", "Relin.ValLinenumb", "Produ", "Produ.ValSku", "Produ.ValGtin", "Produ.ValProduct", "Relin.ValOrdered", "Relin.ValReceived", "Relin.ValOutstand", "Relin.ValCodentit", "Relin.ValCodprodu", "Relin.ValCodrecei"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValLinenumb", CSGenioArelin.FldLinenumb, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("Produ_ValSku", CSGenioAprodu.FldSku, typeof(string)),
            new TableSearchColumn("Produ_ValGtin", CSGenioAprodu.FldGtin, typeof(string), visible : false),
            new TableSearchColumn("Produ_ValProduct", CSGenioAprodu.FldProduct, typeof(string)),
            new TableSearchColumn("ValOrdered", CSGenioArelin.FldOrdered, typeof(decimal?)),
            new TableSearchColumn("ValReceived", CSGenioArelin.FldReceived, typeof(decimal?)),
            new TableSearchColumn("ValOutstand", CSGenioArelin.FldOutstand, typeof(decimal?))
        };
    }
}
