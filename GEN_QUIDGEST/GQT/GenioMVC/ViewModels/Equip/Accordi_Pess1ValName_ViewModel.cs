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

namespace GenioMVC.ViewModels.Equip
{
    public class Accordi_Pess1ValName_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Pess1> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "pess1"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Accordi_Pess1ValName"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodequip { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS ACCORDI_PESS1NAME]/

			return crs;
		}


        public string ValCodempre { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Accordi_Pess1ValName_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Accordi_Pess1ValName_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodequip = currentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioApess1.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 85, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioApess1> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "pess1" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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

			// Limits Generation

			// Area limit
			tableReload &= AddCriteriaAreaLimit(crs, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);


			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Pess1>();
			Menu.SetFilters(bool.Parse(requestValues["Accordi_Pess1ValName_tableFilters"] ?? "false"), true);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Accordi_Pess1ValName_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();
			{
				var groupFilters = CriteriaSet.Or();
				bool filter_Accordi_Pess1ValName_FILTER1_1 = false;
				if (requestValues["filter_Accordi_Pess1ValName_FILTER1"] != null)
					filter_Accordi_Pess1ValName_FILTER1_1 = requestValues["filter_Accordi_Pess1ValName_FILTER1"].Contains("1");
				Navigation.SetValue("filter_Accordi_Pess1ValName_FILTER1_1", filter_Accordi_Pess1ValName_FILTER1_1);
				if (filter_Accordi_Pess1ValName_FILTER1_1)
				{
					groupFilters.Equal(CSGenioApess1.FldGender, "F");

				}

				subfilters.SubSets.Add(groupFilters);
			}
			{
				var groupFilters = CriteriaSet.Or();
				bool filter_Accordi_Pess1ValName_FILTER2_1 = false;
				if (requestValues["filter_Accordi_Pess1ValName_FILTER2"] != null)
					filter_Accordi_Pess1ValName_FILTER2_1 = requestValues["filter_Accordi_Pess1ValName_FILTER2"].Contains("1");
				Navigation.SetValue("filter_Accordi_Pess1ValName_FILTER2_1", filter_Accordi_Pess1ValName_FILTER2_1);
				if (filter_Accordi_Pess1ValName_FILTER2_1)
				{
					groupFilters.Equal(CSGenioApess1.FldGender, "M");

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);





			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Pess1.AddEPH<CSGenioApess1>(ref u, crs, "IBL_ACCORDI_PESS1NAME____");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApess1.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_pess1"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Pess1.AddEPH<CSGenioApess1>(ref u, null, "IBL_ACCORDI_PESS1NAME____"));
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
            ListingMVC<CSGenioApess1> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApess1> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Accordi_Pess1ValName", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Accordi_Pess1ValName"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Accordi_Pess1ValName");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Pess1>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PESS1.NAME", new OrderedDictionary());
			allSortOrders["PESS1.NAME"].Add("PESS1.NAME", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pAccordi_Pess1ValName"])) ? int.Parse(requestValues["pAccordi_Pess1ValName"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sAccordi_Pess1ValName", "dAccordi_Pess1ValName", requestValues, "pess1", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldName };


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
					firstVisibleColumn = new FieldRef("pess1", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioApess1 model_limit_area = new CSGenioApess1(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ACCORDI_PESS1NAME____");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 

			//Limit type: "A"			//Current Area = "PESS1"			//1st Area Limit: "CMPNY"			//1st Area Field: "CODEMPRE"			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.A;
				limit.NaoAplicaSeNulo = false;
				CSGenioAcmpny model_limit_area = new CSGenioAcmpny(UserContext.Current.User);
				string limit_field = "codempre", limit_field_value = "";
				object this_limit_field = Navigation.GetValue("cmpny") == null ? this.ValCodempre : Navigation.GetValue("cmpny");
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet accordi_pess1name____Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ ACCORDI_PESS1NAME]/

            // This will happen in case there is an error
            if(accordi_pess1name____Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioApess1>(false, accordi_pess1name____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ACCORDI_PESS1NAME____", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ACCORDI_PESS1NAME]/

                conditions = accordi_pess1name____Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ACCORDI_PESS1NAME]/


				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_pess1"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioApess1.GetInformation(), QMVC_POS_RECORD, sorts, accordi_pess1name____Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(false, accordi_pess1name____Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ACCORDI_PESS1NAME____", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapAccordi_Pess1ValName(listing);

				Menu.Identifier = "IBL_ACCORDI_PESS1NAME____";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ACCORDI_PESS1NAME____";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Pess1> MapAccordi_Pess1ValName(ListingMVC<CSGenioApess1> Qlisting)
        {
            var Elements = new List<Models.Pess1>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapAccordi_Pess1ValName(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioApess1 row
        /// to a Models.Pess1 object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Pess1 MapAccordi_Pess1ValName(CSGenioApess1 row)
        {
            var model = new Models.Pess1(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "pess1":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ACCORDI_PESS1VALNAME]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName", "Pess1.ValCodcateg", "Pess1.ValCodempre", "Pess1.ValCodparte"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValName", CSGenioApess1.FldName, typeof(string))
        };

    }
}
