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

namespace GenioMVC.ViewModels.Dispa
{
    public class Dispa_ValDispatch_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Dilin> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "dilin"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Dispa_ValDispatch"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCoddispa { get; set; }

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
        /// Initializes a new instance of the <see cref="Dispa_ValDispatch_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Dispa_ValDispatch_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCoddispa = currentNavigation.CurrentLevel.GetEntry("dispa")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAdilin.FldLinenumb, FieldType.NUMERO, Resources.Resources.LINE27983, 6, 0, true),
                new Exports.QColumn(CSGenioAprodu.FldSku, FieldType.TEXTO, Resources.Resources.SKU42303, 20, 0, true),
                new Exports.QColumn(CSGenioAprodu.FldGtin, FieldType.TEXTO, Resources.Resources.GTIN45487, 14, 0, false),
                new Exports.QColumn(CSGenioAprodu.FldProduct, FieldType.TEXTO, Resources.Resources.PRODUCT12880, 30, 0, true),
                new Exports.QColumn(CSGenioAdilin.FldOrdered, FieldType.NUMERO, Resources.Resources.ORDERED04034, 10, 0, true),
                new Exports.QColumn(CSGenioAdilin.FldDelivere, FieldType.NUMERO, Resources.Resources.DELIVERED26597, 10, 0, true),
                new Exports.QColumn(CSGenioAdilin.FldOutstand, FieldType.NUMERO, Resources.Resources.OUTSTANDING36400, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAdilin> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "dilin" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Dilin>();
			Menu.SetFilters(bool.Parse(requestValues["ValDispatch_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DILIN.LINENUMB", new OrderedDictionary());
			allSortOrders["DILIN.LINENUMB"].Add("DILIN.LINENUMB", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValDispatch_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCoddispa != null)
				crs.Equal(CSGenioAdilin.FldCoddispa, this.ValCoddispa);





			if (isToExport)
			{
				// EPH
				crs = Models.Dilin.AddEPH<CSGenioAdilin>(ref u, crs, "IBL_DISPA___PSEUDDISPATCH");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAdilin.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("DILIN", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAdilin.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dilin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dilin");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Dilin.AddEPH<CSGenioAdilin>(ref u, null, "IBL_DISPA___PSEUDDISPATCH"));
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
            ListingMVC<CSGenioAdilin> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdilin> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Dispa_ValDispatch", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Dispa_ValDispatch"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Dispa_ValDispatch");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Dilin>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValDispatch_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DILIN.LINENUMB", new OrderedDictionary());
			allSortOrders["DILIN.LINENUMB"].Add("DILIN.LINENUMB", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValDispatch"])) ? int.Parse(requestValues["pValDispatch"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValDispatch", "dValDispatch", requestValues, "dilin", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAdilin.FldLinenumb), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAdilin.FldCoddilin, CSGenioAdilin.FldZzstate, CSGenioAdilin.FldLinenumb, CSGenioAdilin.FldCodprodu, CSGenioAprodu.FldCodprodu, CSGenioAprodu.FldSku, CSGenioAprodu.FldGtin, CSGenioAprodu.FldProduct, CSGenioAdilin.FldOrdered, CSGenioAdilin.FldDelivere, CSGenioAdilin.FldOutstand };


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
					firstVisibleColumn = new FieldRef("dilin", "linenumb");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAdilin model_limit_area = new CSGenioAdilin(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_DISPA___PSEUDDISPATCH");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet dispa___pseuddispatchConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ DISPA_PSEUDDISPATCH]/

            // This will happen in case there is an error
            if(dispa___pseuddispatchConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAdilin>(false, dispa___pseuddispatchConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_DISPA___PSEUDDISPATCH", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP DISPA_PSEUDDISPATCH]/

                conditions = dispa___pseuddispatchConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST DISPA_PSEUDDISPATCH]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dilin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dilin");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAdilin.GetInformation(), QMVC_POS_RECORD, sorts, dispa___pseuddispatchConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAdilin> listing = Models.ModelBase.Where<CSGenioAdilin>(false, dispa___pseuddispatchConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_DISPA___PSEUDDISPATCH", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapDispa_ValDispatch(listing);

				Menu.Identifier = "IBL_DISPA___PSEUDDISPATCH";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_DISPA___PSEUDDISPATCH";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Dilin> MapDispa_ValDispatch(ListingMVC<CSGenioAdilin> Qlisting)
        {
            var Elements = new List<Models.Dilin>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapDispa_ValDispatch(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAdilin row
        /// to a Models.Dilin object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Dilin MapDispa_ValDispatch(CSGenioAdilin row)
        {
            var model = new Models.Dilin(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "dilin":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DISPA_VALDISPATCH]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Dilin", "Dilin.ValCoddilin", "Dilin.ValZzstate", "Dilin.ValLinenumb", "Produ", "Produ.ValSku", "Produ.ValGtin", "Produ.ValProduct", "Dilin.ValOrdered", "Dilin.ValDelivere", "Dilin.ValOutstand", "Dilin.ValCoddispa", "Dilin.ValCodprodu"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValLinenumb", CSGenioAdilin.FldLinenumb, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("Produ_ValSku", CSGenioAprodu.FldSku, typeof(string)),
            new TableSearchColumn("Produ_ValGtin", CSGenioAprodu.FldGtin, typeof(string), visible : false),
            new TableSearchColumn("Produ_ValProduct", CSGenioAprodu.FldProduct, typeof(string)),
            new TableSearchColumn("ValOrdered", CSGenioAdilin.FldOrdered, typeof(decimal?)),
            new TableSearchColumn("ValDelivere", CSGenioAdilin.FldDelivere, typeof(decimal?)),
            new TableSearchColumn("ValOutstand", CSGenioAdilin.FldOutstand, typeof(decimal?))
        };

    }
}
