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

namespace GenioMVC.ViewModels.Kinde
{
    public class Kinde_ValParamete_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Param> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "param"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Kinde_ValParamete"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodkinde { get; set; }

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
        /// Initializes a new instance of the <see cref="Kinde_ValParamete_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Kinde_ValParamete_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodkinde = currentNavigation.CurrentLevel.GetEntry("kinde")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAparam.FldParameter, FieldType.TEXTO, Resources.Resources.PARAMETER41976, 30, 0, true),
                new Exports.QColumn(CSGenioAparam.FldDatatype, FieldType.ARRAY_COD_TEXTO, Resources.Resources.DATA_TYPE47159, 1, 0, true, "DataType"),
                new Exports.QColumn(CSGenioAparam.FldDecimalplaces, FieldType.ARRAY_COD_NUMERICO, Resources.Resources.DECIMAL_PLACES62575, 2, 0, true, "DecPlace"),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAparam> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "param" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Param>();
			Menu.SetFilters(bool.Parse(requestValues["ValParamete_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PARAM.PARAMETER", new OrderedDictionary());
			allSortOrders["PARAM.PARAMETER"].Add("PARAM.PARAMETER", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValParamete_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodkinde != null)
				crs.Equal(CSGenioAparam.FldCodkinde, this.ValCodkinde);





			if (isToExport)
			{
				// EPH
				crs = Models.Param.AddEPH<CSGenioAparam>(ref u, crs, "IBL_KINDE___PSEUDPARAMETE");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAparam.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PARAM", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAparam.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_param");
				Navigation.DestroyEntry("QMVC_POS_RECORD_param");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Param.AddEPH<CSGenioAparam>(ref u, null, "IBL_KINDE___PSEUDPARAMETE"));
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
            ListingMVC<CSGenioAparam> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAparam> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Kinde_ValParamete", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Kinde_ValParamete"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Kinde_ValParamete");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Param>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValParamete_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PARAM.PARAMETER", new OrderedDictionary());
			allSortOrders["PARAM.PARAMETER"].Add("PARAM.PARAMETER", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValParamete"])) ? int.Parse(requestValues["pValParamete"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValParamete", "dValParamete", requestValues, "param", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAparam.FldParameter), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAparam.FldCodparam, CSGenioAparam.FldZzstate, CSGenioAparam.FldParameter, CSGenioAparam.FldDatatype, CSGenioAparam.FldDecimalplaces };


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
					firstVisibleColumn = new FieldRef("param", "parameter");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAparam model_limit_area = new CSGenioAparam(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_KINDE___PSEUDPARAMETE");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet kinde___pseudparameteConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ KINDE_PSEUDPARAMETE]/

            // This will happen in case there is an error
            if(kinde___pseudparameteConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAparam>(false, kinde___pseudparameteConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_KINDE___PSEUDPARAMETE", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP KINDE_PSEUDPARAMETE]/

                conditions = kinde___pseudparameteConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST KINDE_PSEUDPARAMETE]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_param");
				Navigation.DestroyEntry("QMVC_POS_RECORD_param");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAparam.GetInformation(), QMVC_POS_RECORD, sorts, kinde___pseudparameteConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAparam> listing = Models.ModelBase.Where<CSGenioAparam>(false, kinde___pseudparameteConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_KINDE___PSEUDPARAMETE", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapKinde_ValParamete(listing);

				Menu.Identifier = "IBL_KINDE___PSEUDPARAMETE";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_KINDE___PSEUDPARAMETE";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Param> MapKinde_ValParamete(ListingMVC<CSGenioAparam> Qlisting)
        {
            var Elements = new List<Models.Param>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapKinde_ValParamete(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAparam row
        /// to a Models.Param object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Param MapKinde_ValParamete(CSGenioAparam row)
        {
            var model = new Models.Param(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "param":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM KINDE_VALPARAMETE]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Param", "Param.ValCodparam", "Param.ValZzstate", "Param.ValParameter", "Param.ValDatatype", "Param.ValDecimalplaces", "Param.ValCodkinde"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValParameter", CSGenioAparam.FldParameter, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValDatatype", CSGenioAparam.FldDatatype, typeof(string), array : "DataType"),
            new TableSearchColumn("ValDecimalplaces", CSGenioAparam.FldDecimalplaces, typeof(decimal), array : "DecPlace")
        };

    }
}
