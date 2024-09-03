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
    public class Produ_ValInputsre_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Relin> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "relin"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Produ_ValInputsre"; }

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
        /// Initializes a new instance of the <see cref="Produ_ValInputsre_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Produ_ValInputsre_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodprodu = currentNavigation.CurrentLevel.GetEntry("produ")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioArelin.FldInstant, FieldType.DATAHORA, Resources.Resources.INSTANT35907, 16, 0, true),
                new Exports.QColumn(CSGenioArecei.FldNumber, FieldType.NUMERO, Resources.Resources.RECEIPT_NUMBER31380, 10, 0, true),
                new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXTO, Resources.Resources.ENTITY62049, 30, 0, true),
                new Exports.QColumn(CSGenioArelin.FldLinenumb, FieldType.NUMERO, Resources.Resources.LINE27983, 6, 0, true),
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

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = UserContext.Current.User;
            tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();



			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Relin>();
			Menu.SetFilters(bool.Parse(requestValues["ValInputsre_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("RELIN.INSTANT", new OrderedDictionary());
			allSortOrders["RELIN.INSTANT"].Add("RELIN.INSTANT", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValInputsre_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodprodu != null)
				crs.Equal(CSGenioArelin.FldCodprodu, this.ValCodprodu);





			if (isToExport)
			{
				// EPH
				crs = Models.Relin.AddEPH<CSGenioArelin>(ref u, crs, "IBL_PRODU___PSEUDINPUTSRE");

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
					crs.Equals(Models.Relin.AddEPH<CSGenioArelin>(ref u, null, "IBL_PRODU___PSEUDINPUTSRE"));
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
				this.Navigation.SetValue("requestValues" + "Produ_ValInputsre", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Produ_ValInputsre"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Produ_ValInputsre");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Relin>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValInputsre_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("RELIN.INSTANT", new OrderedDictionary());
			allSortOrders["RELIN.INSTANT"].Add("RELIN.INSTANT", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValInputsre"])) ? int.Parse(requestValues["pValInputsre"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValInputsre", "dValInputsre", requestValues, "relin", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArelin.FldInstant), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioArelin.FldCoddilin, CSGenioArelin.FldZzstate, CSGenioArelin.FldInstant, CSGenioArelin.FldCodrecei, CSGenioArecei.FldCodrecei, CSGenioArecei.FldNumber, CSGenioArelin.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioArelin.FldLinenumb, CSGenioArelin.FldOrdered, CSGenioArelin.FldReceived, CSGenioArelin.FldOutstand };


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
					firstVisibleColumn = new FieldRef("relin", "instant");


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
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PRODU___PSEUDINPUTSRE");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet produ___pseudinputsreConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PRODU_PSEUDINPUTSRE]/

            // This will happen in case there is an error
            if(produ___pseudinputsreConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioArelin>(false, produ___pseudinputsreConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PRODU___PSEUDINPUTSRE", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PRODU_PSEUDINPUTSRE]/

                conditions = produ___pseudinputsreConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST PRODU_PSEUDINPUTSRE]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_relin");
				Navigation.DestroyEntry("QMVC_POS_RECORD_relin");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioArelin.GetInformation(), QMVC_POS_RECORD, sorts, produ___pseudinputsreConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioArelin> listing = Models.ModelBase.Where<CSGenioArelin>(false, produ___pseudinputsreConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PRODU___PSEUDINPUTSRE", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapProdu_ValInputsre(listing);

				Menu.Identifier = "IBL_PRODU___PSEUDINPUTSRE";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_PRODU___PSEUDINPUTSRE";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Relin> MapProdu_ValInputsre(ListingMVC<CSGenioArelin> Qlisting)
        {
            var Elements = new List<Models.Relin>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapProdu_ValInputsre(row));
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
        private Models.Relin MapProdu_ValInputsre(CSGenioArelin row)
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
                    case "recei":
                        model.Recei.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "entit":
                        model.Entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PRODU_VALINPUTSRE]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Relin", "Relin.ValCoddilin", "Relin.ValZzstate", "Relin.ValInstant", "Recei", "Recei.ValNumber", "Entit", "Entit.ValName", "Relin.ValLinenumb", "Relin.ValOrdered", "Relin.ValReceived", "Relin.ValOutstand", "Relin.ValCodentit", "Relin.ValCodprodu", "Relin.ValCodrecei"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValInstant", CSGenioArelin.FldInstant, typeof(DateTime?)),
            new TableSearchColumn("Recei_ValNumber", CSGenioArecei.FldNumber, typeof(decimal?)),
            new TableSearchColumn("Entit_ValName", CSGenioAentit.FldName, typeof(string)),
            new TableSearchColumn("ValLinenumb", CSGenioArelin.FldLinenumb, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("ValOrdered", CSGenioArelin.FldOrdered, typeof(decimal?)),
            new TableSearchColumn("ValReceived", CSGenioArelin.FldReceived, typeof(decimal?)),
            new TableSearchColumn("ValOutstand", CSGenioArelin.FldOutstand, typeof(decimal?))
        };
    }
}
