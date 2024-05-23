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

namespace GenioMVC.ViewModels.Repar
{
    public class Repar_SpeciValEspecial_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Speci> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "speci"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Repar_SpeciValEspecial"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodrepar { get; set; }

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

        public string ValTipoarea { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repar_SpeciValEspecial_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Repar_SpeciValEspecial_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAspeci.FldEspecial, FieldType.TEXTO, Resources.Resources.SPECIALTY09304, 50, 0, true),
                new Exports.QColumn(CSGenioAspeci.FldAreatecn, FieldType.ARRAY_COD_TEXTO, Resources.Resources.TECHNICAL_AREA50773, 1, 0, true, "AreaTecn"),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAspeci> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "speci" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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

				// Limit by field
				crs.Equal(
				CSGenio.business.CSGenioAspeci.FldAreatecn,
				this.ValTipoarea);


			if(Menu == null)
				Menu = new TablePartial<GenioMVC.Models.Speci>();
			Menu.SetFilters(bool.Parse(requestValues["Repar_SpeciValEspecial_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("SPECI.ESPECIAL", new OrderedDictionary());
			allSortOrders["SPECI.ESPECIAL"].Add("SPECI.ESPECIAL", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Repar_SpeciValEspecial_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Speci.AddEPH<CSGenioAspeci>(ref u, crs, "IBL_REPAR___SPECIESPECIAL");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAspeci.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAspeci.FldZzstate), CriteriaOperator.Equal, 0));

			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_speci"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Speci.AddEPH<CSGenioAspeci>(ref u, null, "IBL_REPAR___SPECIESPECIAL"));
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
            ListingMVC<CSGenioAspeci> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAspeci> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Repar_SpeciValEspecial", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Repar_SpeciValEspecial"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Repar_SpeciValEspecial");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Speci>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["Repar_SpeciValEspecial_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("SPECI.ESPECIAL", new OrderedDictionary());
			allSortOrders["SPECI.ESPECIAL"].Add("SPECI.ESPECIAL", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pRepar_SpeciValEspecial"])) ? int.Parse(requestValues["pRepar_SpeciValEspecial"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sRepar_SpeciValEspecial", "dRepar_SpeciValEspecial", requestValues, "speci", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAspeci.FldEspecial), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAspeci.FldCodespec, CSGenioAspeci.FldZzstate, CSGenioAspeci.FldEspecial, CSGenioAspeci.FldAreatecn };


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
					firstVisibleColumn = new FieldRef("speci", "especial");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAspeci model_limit_area = new CSGenioAspeci(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_REPAR___SPECIESPECIAL");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: form 

			//Limit type: "C"			//Current Area = "SPECI"			//1st Area Limit: "SPECI"			//1st Area Field: "AREATECN"			//1st Area Value: ""
			//2nd Area Limit: "REPAR"			//2nd Area Field: "TIPOAREA"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.C;
				limit.NaoAplicaSeNulo = false;
				CSGenioAspeci model_limit_area = new CSGenioAspeci(UserContext.Current.User);
				string limit_field = "areatecn", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);

				CSGenioArepar model_limit_area2 = new CSGenioArepar(UserContext.Current.User);
				string limit_field2 = "tipoarea", limit_field_value2 = "";
				object this_limit_field2 = ValTipoarea;
				Limit_Filler(ref limit, model_limit_area2, limit_field2, limit_field_value2, this_limit_field2, LimitAreaType.AreaLimitaN);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet repar___speciespecialConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ REPAR_SPECIESPECIAL]/

            // This will happen in case there is an error
            if(repar___speciespecialConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAspeci>(false, repar___speciespecialConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_REPAR___SPECIESPECIAL", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP REPAR_SPECIESPECIAL]/

                conditions = repar___speciespecialConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST REPAR_SPECIESPECIAL]/


				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_speci"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAspeci.GetInformation(), QMVC_POS_RECORD, sorts, repar___speciespecialConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAspeci> listing = Models.ModelBase.Where<CSGenioAspeci>(false, repar___speciespecialConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_REPAR___SPECIESPECIAL", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapRepar_SpeciValEspecial(listing);

				Menu.Identifier = "IBL_REPAR___SPECIESPECIAL";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_REPAR___SPECIESPECIAL";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Speci> MapRepar_SpeciValEspecial(ListingMVC<CSGenioAspeci> Qlisting)
        {
            var Elements = new List<Models.Speci>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapRepar_SpeciValEspecial(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAspeci row
        /// to a Models.Speci object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Speci MapRepar_SpeciValEspecial(CSGenioAspeci row)
        {
            var model = new Models.Speci(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "speci":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM REPAR_SPECIVALESPECIAL]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Speci", "Speci.ValCodespec", "Speci.ValZzstate", "Speci.ValEspecial", "Speci.ValAreatecn"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValEspecial", CSGenioAspeci.FldEspecial, typeof(string)),
            new TableSearchColumn("ValAreatecn", CSGenioAspeci.FldAreatecn, typeof(string), array : "AreaTecn")
        };
    }
}
