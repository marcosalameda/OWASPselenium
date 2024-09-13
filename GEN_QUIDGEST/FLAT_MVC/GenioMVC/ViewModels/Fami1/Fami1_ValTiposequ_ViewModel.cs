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

namespace GenioMVC.ViewModels.Fami1
{
    public class Fami1_ValTiposequ_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Tpeq1> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "tpeq1"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Fami1_ValTiposequ"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodfamil { get; set; }

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
        /// Initializes a new instance of the <see cref="Fami1_ValTiposequ_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Fami1_ValTiposequ_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodfamil = currentNavigation.CurrentLevel.GetEntry("fami1")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAtpeq1.FldTipoequi, FieldType.TEXTO, Resources.Resources.TYPE_OF_EQUIPMENT18080, 30, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldTpequcod, FieldType.TEXTO, Resources.Resources.CODE49225, 20, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldTpequpai, FieldType.TEXTO, Resources.Resources.DEPENDENT_ON28321, 20, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldNivel, FieldType.NUMERO, Resources.Resources.LEVEL06184, 3, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldBackcolo, FieldType.TEXTO, Resources.Resources.BACKGROUND_COLOR47883, 30, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldCorletra, FieldType.TEXTO, Resources.Resources.LETTER_COLOR15736, 30, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldPrecomax, FieldType.VALOR, Resources.Resources.MAXIMUM_PRICE55489, 12, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldPrecoult, FieldType.VALOR, Resources.Resources.LAST_PRICE25852, 12, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldSince, FieldType.DATAHORA, Resources.Resources.IN34902, 16, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldQtdequip, FieldType.NUMERO, Resources.Resources.AMOUNT46885, 6, 0, true),
                new Exports.QColumn(CSGenioAtpeq1.FldKit, FieldType.LOGICO, Resources.Resources.KIT27179, 1, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAtpeq1> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "tpeq1" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Tpeq1>();
			Menu.SetFilters(bool.Parse(requestValues["ValTiposequ_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValTiposequ_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodfamil != null)
				crs.Equal(CSGenioAtpeq1.FldCodfamil, this.ValCodfamil);





			if (isToExport)
			{
				// EPH
				crs = Models.Tpeq1.AddEPH<CSGenioAtpeq1>(ref u, crs, "IBL_FAMI1___PSEUDTIPOSEQU");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAtpeq1.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("TPEQ1", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAtpeq1.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpeq1");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tpeq1");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Tpeq1.AddEPH<CSGenioAtpeq1>(ref u, null, "IBL_FAMI1___PSEUDTIPOSEQU"));
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
            ListingMVC<CSGenioAtpeq1> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAtpeq1> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Fami1_ValTiposequ", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Fami1_ValTiposequ"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Fami1_ValTiposequ");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Tpeq1>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValTiposequ"])) ? int.Parse(requestValues["pValTiposequ"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValTiposequ", "dValTiposequ", requestValues, "tpeq1", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldZzstate, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldNivel, CSGenioAtpeq1.FldBackcolo, CSGenioAtpeq1.FldCorletra, CSGenioAtpeq1.FldPrecomax, CSGenioAtpeq1.FldPrecoult, CSGenioAtpeq1.FldSince, CSGenioAtpeq1.FldQtdequip, CSGenioAtpeq1.FldKit };


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
					firstVisibleColumn = new FieldRef("tpeq1", "tipoequi");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAtpeq1 model_limit_area = new CSGenioAtpeq1(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_FAMI1___PSEUDTIPOSEQU");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet fami1___pseudtiposequConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ FAMI1_PSEUDTIPOSEQU]/

            // This will happen in case there is an error
            if(fami1___pseudtiposequConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAtpeq1>(false, fami1___pseudtiposequConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_FAMI1___PSEUDTIPOSEQU", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP FAMI1_PSEUDTIPOSEQU]/

                conditions = fami1___pseudtiposequConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST FAMI1_PSEUDTIPOSEQU]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_tpeq1");
				Navigation.DestroyEntry("QMVC_POS_RECORD_tpeq1");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAtpeq1.GetInformation(), QMVC_POS_RECORD, sorts, fami1___pseudtiposequConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(false, fami1___pseudtiposequConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_FAMI1___PSEUDTIPOSEQU", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapFami1_ValTiposequ(listing);

				Menu.Identifier = "IBL_FAMI1___PSEUDTIPOSEQU";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_FAMI1___PSEUDTIPOSEQU";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Tpeq1> MapFami1_ValTiposequ(ListingMVC<CSGenioAtpeq1> Qlisting)
        {
            var Elements = new List<Models.Tpeq1>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapFami1_ValTiposequ(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAtpeq1 row
        /// to a Models.Tpeq1 object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Tpeq1 MapFami1_ValTiposequ(CSGenioAtpeq1 row)
        {
            var model = new Models.Tpeq1(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "tpeq1":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FAMI1_VALTIPOSEQU]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTipoequi", "Tpeq1.ValTpequcod", "Tpeq1.ValTpequpai", "Tpeq1.ValNivel", "Tpeq1.ValBackcolo", "Tpeq1.ValCorletra", "Tpeq1.ValPrecomax", "Tpeq1.ValPrecoult", "Tpeq1.ValSince", "Tpeq1.ValQtdequip", "Tpeq1.ValKit", "Tpeq1.ValCodfamil"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValTipoequi", CSGenioAtpeq1.FldTipoequi, typeof(string)),
            new TableSearchColumn("ValTpequcod", CSGenioAtpeq1.FldTpequcod, typeof(string)),
            new TableSearchColumn("ValTpequpai", CSGenioAtpeq1.FldTpequpai, typeof(string)),
            new TableSearchColumn("ValNivel", CSGenioAtpeq1.FldNivel, typeof(decimal)),
            new TableSearchColumn("ValBackcolo", CSGenioAtpeq1.FldBackcolo, typeof(string)),
            new TableSearchColumn("ValCorletra", CSGenioAtpeq1.FldCorletra, typeof(string)),
            new TableSearchColumn("ValPrecomax", CSGenioAtpeq1.FldPrecomax, typeof(decimal?)),
            new TableSearchColumn("ValPrecoult", CSGenioAtpeq1.FldPrecoult, typeof(decimal?)),
            new TableSearchColumn("ValSince", CSGenioAtpeq1.FldSince, typeof(DateTime?)),
            new TableSearchColumn("ValQtdequip", CSGenioAtpeq1.FldQtdequip, typeof(decimal?)),
            new TableSearchColumn("ValKit", CSGenioAtpeq1.FldKit, typeof(bool))
        };

    }
}
