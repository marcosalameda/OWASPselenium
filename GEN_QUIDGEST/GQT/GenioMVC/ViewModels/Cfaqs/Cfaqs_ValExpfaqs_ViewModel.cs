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

namespace GenioMVC.ViewModels.Cfaqs
{
    public class Cfaqs_ValExpfaqs_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Faqs> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "faqs"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Cfaqs_ValExpfaqs"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodcfaqs { get; set; }

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
        /// Initializes a new instance of the <see cref="Cfaqs_ValExpfaqs_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Cfaqs_ValExpfaqs_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAfaqs.FldQuestion, FieldType.MEMO, Resources.Resources.QUESTION00194, 30, 0, true),
                new Exports.QColumn(CSGenioAfaqs.FldAnswer, FieldType.MEMO, Resources.Resources.ANSWER22961, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAfaqs> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "faqs" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Faqs>();
			Menu.SetFilters(bool.Parse(requestValues["ValExpfaqs_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValExpfaqs_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodcfaqs != null)
				crs.Equal(CSGenioAfaqs.FldCodcfaqs, this.ValCodcfaqs);





			if (isToExport)
			{
				// EPH
				crs = Models.Faqs.AddEPH<CSGenioAfaqs>(ref u, crs, "IBL_CFAQS___PSEUDEXPFAQS_");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfaqs.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FAQS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAfaqs.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_faqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_faqs");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Faqs.AddEPH<CSGenioAfaqs>(ref u, null, "IBL_CFAQS___PSEUDEXPFAQS_"));
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
            ListingMVC<CSGenioAfaqs> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfaqs> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Cfaqs_ValExpfaqs", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Cfaqs_ValExpfaqs"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Cfaqs_ValExpfaqs");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Faqs>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValExpfaqs_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValExpfaqs"])) ? int.Parse(requestValues["pValExpfaqs"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValExpfaqs", "dValExpfaqs", requestValues, "faqs", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAfaqs.FldCodfaqs, CSGenioAfaqs.FldZzstate, CSGenioAfaqs.FldQuestion, CSGenioAfaqs.FldAnswer };


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
					firstVisibleColumn = new FieldRef("faqs", "question");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAfaqs model_limit_area = new CSGenioAfaqs(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_CFAQS___PSEUDEXPFAQS_");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet cfaqs___pseudexpfaqs_Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ CFAQS_PSEUDEXPFAQS]/

            // This will happen in case there is an error
            if(cfaqs___pseudexpfaqs_Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfaqs>(false, cfaqs___pseudexpfaqs_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_CFAQS___PSEUDEXPFAQS_", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP CFAQS_PSEUDEXPFAQS]/

                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST CFAQS_PSEUDEXPFAQS]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_faqs");
				Navigation.DestroyEntry("QMVC_POS_RECORD_faqs");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAfaqs.GetInformation(), QMVC_POS_RECORD, sorts, cfaqs___pseudexpfaqs_Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAfaqs> listing = Models.ModelBase.Where<CSGenioAfaqs>(false, cfaqs___pseudexpfaqs_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_CFAQS___PSEUDEXPFAQS_", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapCfaqs_ValExpfaqs(listing);

				Menu.Identifier = "IBL_CFAQS___PSEUDEXPFAQS_";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_CFAQS___PSEUDEXPFAQS_";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Faqs> MapCfaqs_ValExpfaqs(ListingMVC<CSGenioAfaqs> Qlisting)
        {
            var Elements = new List<Models.Faqs>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapCfaqs_ValExpfaqs(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAfaqs row
        /// to a Models.Faqs object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Faqs MapCfaqs_ValExpfaqs(CSGenioAfaqs row)
        {
            var model = new Models.Faqs(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "faqs":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM CFAQS_VALEXPFAQS]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Faqs", "Faqs.ValCodfaqs", "Faqs.ValZzstate", "Faqs.ValQuestion", "Faqs.ValAnswer", "Faqs.ValCodcfaqs"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValQuestion", CSGenioAfaqs.FldQuestion, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValAnswer", CSGenioAfaqs.FldAnswer, typeof(string))
        };
    }
}
