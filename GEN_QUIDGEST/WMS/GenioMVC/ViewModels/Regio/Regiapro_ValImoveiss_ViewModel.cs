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

namespace GenioMVC.ViewModels.Regio
{
    public class Regiapro_ValImoveiss_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Propr> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "propr"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Regiapro_ValImoveiss"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodregia { get; set; }

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

        public string ValCodpais1 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Regiapro_ValImoveiss_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Regiapro_ValImoveiss_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioApropr.FldName, FieldType.TEXTO, Resources.Resources.PROPERTY_NAME18934, 30, 0, true),
                new Exports.QColumn(CSGenioApropr.FldPrecoest, FieldType.VALOR, Resources.Resources.ESTIMATED_PRICE02986, 12, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioApropr.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
                new Exports.QColumn(CSGenioApropr.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 10, true),
                new Exports.QColumn(CSGenioApropr.FldCoordgeo, FieldType.GEOGRAPHY, Resources.Resources.GEOGRAPHIC_COORDINAT21394, 30, 0, true),
                new Exports.QColumn(CSGenioApais1.FldCountry, FieldType.TEXTO, Resources.Resources.PAIS_PESSOA61621, 30, 0, true),
                new Exports.QColumn(CSGenioAcntry.FldCountry, FieldType.TEXTO, Resources.Resources.COUNTRY64133, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioApropr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "propr" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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

			// Limits Generation

			// Area limit
			tableReload &= AddCriteriaAreaLimit(crs, CSGenio.business.CSGenioApais1.FldCodcntry, "pais1", this.ValCodpais1, true);


			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Propr>();
			Menu.SetFilters(bool.Parse(requestValues["ValImoveiss_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValImoveiss_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Propr.AddEPH<CSGenioApropr>(ref u, crs, "IBL_REGIAPROPSEUDIMOVEISS");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApropr.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROPR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApropr.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Propr.AddEPH<CSGenioApropr>(ref u, null, "IBL_REGIAPROPSEUDIMOVEISS"));
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
            ListingMVC<CSGenioApropr> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApropr> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Regiapro_ValImoveiss", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Regiapro_ValImoveiss"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Regiapro_ValImoveiss");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Propr>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValImoveiss_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValImoveiss"])) ? int.Parse(requestValues["pValImoveiss"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValImoveiss", "dValImoveiss", requestValues, "propr", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioApropr.FldCodpropr, CSGenioApropr.FldZzstate, CSGenioApropr.FldName, CSGenioApropr.FldPrecoest, CSGenioApropr.FldPhotogra, CSGenioApropr.FldDescript, CSGenioApropr.FldCoordgeo, CSGenioApropr.FldCodpais1, CSGenioApais1.FldCodcntry, CSGenioApais1.FldCountry, CSGenioApropr.FldCodcntry, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry };


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
					firstVisibleColumn = new FieldRef("propr", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioApropr model_limit_area = new CSGenioApropr(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_REGIAPROPSEUDIMOVEISS");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 

			//Limit type: "A"			//Current Area = "PROPR"			//1st Area Limit: "PAIS1"			//1st Area Field: "CODCNTRY"			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.A;
				limit.NaoAplicaSeNulo = false;
				CSGenioApais1 model_limit_area = new CSGenioApais1(UserContext.Current.User);
				string limit_field = "codcntry", limit_field_value = "";
				object this_limit_field = Navigation.GetValue("pais1") == null ? this.ValCodpais1 : Navigation.GetValue("pais1");
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet regiapropseudimoveissConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ REGIAPRO_PSEUDIMOVEISS]/

            // This will happen in case there is an error
            if(regiapropseudimoveissConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioApropr>(false, regiapropseudimoveissConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_REGIAPROPSEUDIMOVEISS", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP REGIAPRO_PSEUDIMOVEISS]/

                conditions = regiapropseudimoveissConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST REGIAPRO_PSEUDIMOVEISS]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_propr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_propr");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioApropr.GetInformation(), QMVC_POS_RECORD, sorts, regiapropseudimoveissConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioApropr> listing = Models.ModelBase.Where<CSGenioApropr>(false, regiapropseudimoveissConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_REGIAPROPSEUDIMOVEISS", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapRegiapro_ValImoveiss(listing);

				Menu.Identifier = "IBL_REGIAPROPSEUDIMOVEISS";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_REGIAPROPSEUDIMOVEISS";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Propr> MapRegiapro_ValImoveiss(ListingMVC<CSGenioApropr> Qlisting)
        {
            var Elements = new List<Models.Propr>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapRegiapro_ValImoveiss(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioApropr row
        /// to a Models.Propr object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Propr MapRegiapro_ValImoveiss(CSGenioApropr row)
        {
            var model = new Models.Propr(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "propr":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pais1":
                        model.Pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "cntry":
                        model.Cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGIAPRO_VALIMOVEISS]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Propr", "Propr.ValCodpropr", "Propr.ValZzstate", "Propr.ValName", "Propr.ValPrecoest", "Propr.ValPhotogra", "Propr.ValDescript", "Propr.ValCoordgeo", "Pais1", "Pais1.ValCountry", "Cntry", "Cntry.ValCountry", "Propr.ValCodcntry", "Propr.ValCodpais1", "Propr.ValCodpesso", "Propr.ValCodregia", "Propr.ValCodtppro"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValName", CSGenioApropr.FldName, typeof(string)),
            new TableSearchColumn("ValPrecoest", CSGenioApropr.FldPrecoest, typeof(decimal?)),
            new TableSearchColumn("ValDescript", CSGenioApropr.FldDescript, typeof(string)),
            new TableSearchColumn("Pais1_ValCountry", CSGenioApais1.FldCountry, typeof(string)),
            new TableSearchColumn("Cntry_ValCountry", CSGenioAcntry.FldCountry, typeof(string))
        };
    }
}
