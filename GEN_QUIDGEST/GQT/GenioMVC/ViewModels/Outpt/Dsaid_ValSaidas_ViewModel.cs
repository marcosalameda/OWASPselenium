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

namespace GenioMVC.ViewModels.Outpt
{
    public class Dsaid_ValSaidas_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Outpu> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "outpu"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Dsaid_ValSaidas"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodoutpt { get; set; }

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
                conds.Equal(CSGenioAoutpu.FldCodoutpt, this.ValCodoutpt ?? Navigation.GetStrValue("outpt"));

                return conds;
            }
        }

        /// <inheritdoc/>
        public override List<Relation> relations
        {
            get
            {
                List<Relation> relations = null;
                List<string> aboveTables = new List<string>();
                User u = UserContext.Current.User;
                var area = new CSGenioAoutpu(u);
                relations = CSGenio.persistence.QueryUtils.tablesRelationships(aboveTables.Distinct().ToList(), area);
                return relations;
            }
        }

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL GQT LIST_LIMITS DSAID_PSEUDSAIDAS]/

			return crs;
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="Dsaid_ValSaidas_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Dsaid_ValSaidas_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodoutpt = currentNavigation.CurrentLevel.GetEntry("outpt")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAoutpu.FldLine, FieldType.NUMERIC, Resources.Resources.LINE27983, 5, 1, true),
                new Exports.QColumn(CSGenioAitem.FldItemdes, FieldType.TEXT, Resources.Resources.ARTICLE60065, 50, 0, true),
                new Exports.QColumn(CSGenioAitem.FldItemcod, FieldType.TEXT, Resources.Resources.CODE49225, 15, 0, true),
                new Exports.QColumn(CSGenioAoutpu.FldExitqnty, FieldType.NUMERIC, Resources.Resources.QTD_OUTPUT12876, 10, 0, true),
                new Exports.QColumn(CSGenioAwareh.FldWarehdes, FieldType.TEXT, Resources.Resources.WAREHOUSE51864, 30, 0, true),
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

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = UserContext.Current.User;
            tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();



			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Outpu>();
			Menu.SetFilters(bool.Parse(requestValues["ValSaidas_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValSaidas_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodoutpt != null)
				crs.Equal(CSGenioAoutpu.FldCodoutpt, this.ValCodoutpt);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Outpu.AddEPH<CSGenioAoutpu>(ref u, crs, "IBL_DSAID___PSEUDSAIDAS__");

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
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Outpu.AddEPH<CSGenioAoutpu>(ref u, null, "IBL_DSAID___PSEUDSAIDAS__"));
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
				this.Navigation.SetValue("requestValues" + "Dsaid_ValSaidas", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Dsaid_ValSaidas"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Dsaid_ValSaidas");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Outpu>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("OUTPU.LINE", new OrderedDictionary());
			allSortOrders["OUTPU.LINE"].Add("OUTPU.LINE", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValSaidas"])) ? int.Parse(requestValues["pValSaidas"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValSaidas", "dValSaidas", requestValues, "outpu", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAoutpu.FldLine), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAoutpu.FldCodoutpu, CSGenioAoutpu.FldZzstate, CSGenioAoutpu.FldLine, CSGenioAoutpu.FldCoditem, CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAoutpu.FldExitqnty, CSGenioAoutpu.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };


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
					firstVisibleColumn = new FieldRef("outpu", "line");


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
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_DSAID___PSEUDSAIDAS__");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet dsaid___pseudsaidas__Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ DSAID_PSEUDSAIDAS]/

            // This will happen in case there is an error
            if(dsaid___pseudsaidas__Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAoutpu>(false, dsaid___pseudsaidas__Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_DSAID___PSEUDSAIDAS__", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP DSAID_PSEUDSAIDAS]/

                conditions = dsaid___pseudsaidas__Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST DSAID_PSEUDSAIDAS]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_outpu");
				Navigation.DestroyEntry("QMVC_POS_RECORD_outpu");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAoutpu.GetInformation(), QMVC_POS_RECORD, sorts, dsaid___pseudsaidas__Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAoutpu> listing = Models.ModelBase.Where<CSGenioAoutpu>(false, dsaid___pseudsaidas__Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_DSAID___PSEUDSAIDAS__", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapDsaid_ValSaidas(listing);

				Menu.Identifier = "IBL_DSAID___PSEUDSAIDAS__";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_DSAID___PSEUDSAIDAS__";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Outpu> MapDsaid_ValSaidas(ListingMVC<CSGenioAoutpu> Qlisting)
        {
            var Elements = new List<Models.Outpu>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapDsaid_ValSaidas(row));
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
        private Models.Outpu MapDsaid_ValSaidas(CSGenioAoutpu row)
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
                    case "item":
                        model.Item.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "wareh":
                        model.Wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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


        public void Reorder(string id, string position)
        {
            User u = UserContext.Current.User;
            var sp = UserContext.Current.PersistentSupport;
            sp.openConnection();
            var row = CSGenioAoutpu.search(sp, id, u);
            row.Reorder_Line(sp, int.Parse(position), baseConditions, relations);
            sp.closeConnection();
        }

        #region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DSAID_VALSAIDAS]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Outpu", "Outpu.ValCodoutpu", "Outpu.ValZzstate", "Outpu.ValLine", "Item", "Item.ValItemdes", "Item.ValItemcod", "Outpu.ValExitqnty", "Wareh", "Wareh.ValWarehdes", "Outpu.ValCodwareh", "Wareh.ValCodwareh", "Outpu.ValCoditem", "Outpu.ValCoddocsd", "Outpu.ValCodoutpt"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValLine", CSGenioAoutpu.FldLine, typeof(decimal?)),
            new TableSearchColumn("Item_ValItemdes", CSGenioAitem.FldItemdes, typeof(string)),
            new TableSearchColumn("Item_ValItemcod", CSGenioAitem.FldItemcod, typeof(string)),
            new TableSearchColumn("ValExitqnty", CSGenioAoutpu.FldExitqnty, typeof(decimal?)),
            new TableSearchColumn("Wareh_ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string))
        };

    }
}
