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

namespace GenioMVC.ViewModels.Pesso
{
    public class Pessos01_ValEvolucao_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Evcat> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "evcat"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Pessos01_ValEvolucao"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodpesso { get; set; }

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
        /// Initializes a new instance of the <see cref="Pessos01_ValEvolucao_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Pessos01_ValEvolucao_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodpesso = currentNavigation.CurrentLevel.GetEntry("pesso")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAevcat.FldSince, FieldType.DATA, Resources.Resources.SINCE47259, 8, 0, true),
                new Exports.QColumn(CSGenioAcate1.FldCategoria, FieldType.TEXTO, Resources.Resources.CATEGORY18978, 30, 0, true),
                new Exports.QColumn(CSGenioAevcat.FldFimperio, FieldType.DATA, Resources.Resources.END_OF_PERIOD44616, 8, 0, true),
                new Exports.QColumn(CSGenioAevcat.FldObservat, FieldType.MEMO, Resources.Resources.OBSERVATION37880, 30, 2, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAevcat> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "evcat" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Evcat>();
			Menu.SetFilters(bool.Parse(requestValues["ValEvolucao_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("EVCAT.SINCE", new OrderedDictionary());
			allSortOrders["EVCAT.SINCE"].Add("EVCAT.SINCE", "D");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValEvolucao_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodpesso != null)
				crs.Equal(CSGenioAevcat.FldCodpesso, this.ValCodpesso);





			if (isToExport)
			{
				// EPH
				crs = Models.Evcat.AddEPH<CSGenioAevcat>(ref u, crs, "IBL_PESSOS01PSEUDEVOLUCAO");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAevcat.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("EVCAT", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAevcat.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_evcat");
				Navigation.DestroyEntry("QMVC_POS_RECORD_evcat");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Evcat.AddEPH<CSGenioAevcat>(ref u, null, "IBL_PESSOS01PSEUDEVOLUCAO"));
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
            ListingMVC<CSGenioAevcat> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAevcat> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Pessos01_ValEvolucao", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Pessos01_ValEvolucao"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Pessos01_ValEvolucao");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Evcat>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValEvolucao_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("EVCAT.SINCE", new OrderedDictionary());
			allSortOrders["EVCAT.SINCE"].Add("EVCAT.SINCE", "D");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValEvolucao"])) ? int.Parse(requestValues["pValEvolucao"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValEvolucao", "dValEvolucao", requestValues, "evcat", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAevcat.FldSince), SortOrder.Descending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAevcat.FldCodprogr, CSGenioAevcat.FldZzstate, CSGenioAevcat.FldSince, CSGenioAevcat.FldCodcateg, CSGenioAcate1.FldCodcateg, CSGenioAcate1.FldCategoria, CSGenioAevcat.FldFimperio, CSGenioAevcat.FldObservat };


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
					firstVisibleColumn = new FieldRef("evcat", "since");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAevcat model_limit_area = new CSGenioAevcat(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PESSOS01PSEUDEVOLUCAO");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet pessos01pseudevolucaoConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PESSOS01_PSEUDEVOLUCAO]/

            // This will happen in case there is an error
            if(pessos01pseudevolucaoConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAevcat>(false, pessos01pseudevolucaoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PESSOS01PSEUDEVOLUCAO", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PESSOS01_PSEUDEVOLUCAO]/

                conditions = pessos01pseudevolucaoConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST PESSOS01_PSEUDEVOLUCAO]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_evcat");
				Navigation.DestroyEntry("QMVC_POS_RECORD_evcat");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAevcat.GetInformation(), QMVC_POS_RECORD, sorts, pessos01pseudevolucaoConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAevcat> listing = Models.ModelBase.Where<CSGenioAevcat>(false, pessos01pseudevolucaoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PESSOS01PSEUDEVOLUCAO", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapPessos01_ValEvolucao(listing);

				Menu.Identifier = "IBL_PESSOS01PSEUDEVOLUCAO";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_PESSOS01PSEUDEVOLUCAO";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Evcat> MapPessos01_ValEvolucao(ListingMVC<CSGenioAevcat> Qlisting)
        {
            var Elements = new List<Models.Evcat>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPessos01_ValEvolucao(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAevcat row
        /// to a Models.Evcat object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Evcat MapPessos01_ValEvolucao(CSGenioAevcat row)
        {
            var model = new Models.Evcat(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "evcat":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "cate1":
                        model.Cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSOS01_VALEVOLUCAO]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Evcat", "Evcat.ValCodprogr", "Evcat.ValZzstate", "Evcat.ValSince", "Cate1", "Cate1.ValCategoria", "Evcat.ValFimperio", "Evcat.ValObservat", "Evcat.ValCodcateg", "Evcat.ValCodpesso"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValSince", CSGenioAevcat.FldSince, typeof(DateTime?)),
            new TableSearchColumn("Cate1_ValCategoria", CSGenioAcate1.FldCategoria, typeof(string)),
            new TableSearchColumn("ValFimperio", CSGenioAevcat.FldFimperio, typeof(DateTime?)),
            new TableSearchColumn("ValObservat", CSGenioAevcat.FldObservat, typeof(string))
        };

    }
}
