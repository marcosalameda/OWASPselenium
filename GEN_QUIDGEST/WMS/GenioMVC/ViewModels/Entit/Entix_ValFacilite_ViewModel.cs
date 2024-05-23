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

namespace GenioMVC.ViewModels.Entit
{
    public class Entix_ValFacilite_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Facil> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "facil"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Entix_ValFacilite"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodentit { get; set; }

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
        /// Initializes a new instance of the <see cref="Entix_ValFacilite_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Entix_ValFacilite_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAfacil.FldIncorpor, FieldType.DATA, Resources.Resources.INCORPORATION10135, 8, 0, true),
                new Exports.QColumn(CSGenioAfacil.FldName, FieldType.TEXTO, Resources.Resources.FACILITY_NAME19514, 30, 0, true),
                new Exports.QColumn(CSGenioAfacty.FldType, FieldType.TEXTO, Resources.Resources.FACILITY_TYPE44577, 25, 0, true),
                new Exports.QColumn(CSGenioAfacil.FldLatitude, FieldType.NUMERO, Resources.Resources.LATITUDE11291, 10, 6, true),
                new Exports.QColumn(CSGenioAfacil.FldLongitud, FieldType.NUMERO, Resources.Resources.LONGITUDE01015, 10, 6, true),
                new Exports.QColumn(CSGenioAfacil.FldGeocoord, FieldType.GEOGRAPHY, Resources.Resources.GEOGRAPHICAL_COORDIN45869, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAfacil.FldImage, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE65174, 3, 1, true):null,
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAfacil> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "facil" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Facil>();
			Menu.SetFilters(bool.Parse(requestValues["ValFacilite_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FACIL.INCORPOR", new OrderedDictionary());
			allSortOrders["FACIL.INCORPOR"].Add("FACIL.INCORPOR", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValFacilite_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodentit != null)
				crs.Equal(CSGenioAfacil.FldCodentit, this.ValCodentit);





			if (isToExport)
			{
				// EPH
				crs = Models.Facil.AddEPH<CSGenioAfacil>(ref u, crs, "IBL_ENTIX___PSEUDFACILITE");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAfacil.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FACIL", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAfacil.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_facil");
				Navigation.DestroyEntry("QMVC_POS_RECORD_facil");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Facil.AddEPH<CSGenioAfacil>(ref u, null, "IBL_ENTIX___PSEUDFACILITE"));
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
            ListingMVC<CSGenioAfacil> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAfacil> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Entix_ValFacilite", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Entix_ValFacilite"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Entix_ValFacilite");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Facil>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValFacilite_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FACIL.INCORPOR", new OrderedDictionary());
			allSortOrders["FACIL.INCORPOR"].Add("FACIL.INCORPOR", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValFacilite"])) ? int.Parse(requestValues["pValFacilite"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValFacilite", "dValFacilite", requestValues, "facil", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacil.FldIncorpor), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAfacil.FldCodfacil, CSGenioAfacil.FldZzstate, CSGenioAfacil.FldIncorpor, CSGenioAfacil.FldName, CSGenioAfacil.FldCodfacty, CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType, CSGenioAfacil.FldLatitude, CSGenioAfacil.FldLongitud, CSGenioAfacil.FldGeocoord, CSGenioAfacil.FldImage };


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
					firstVisibleColumn = new FieldRef("facil", "incorpor");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAfacil model_limit_area = new CSGenioAfacil(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ENTIX___PSEUDFACILITE");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet entix___pseudfaciliteConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL GQT OVERRQ ENTIX_PSEUDFACILITE]/

            // This will happen in case there is an error
            if(entix___pseudfaciliteConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAfacil>(false, entix___pseudfaciliteConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ENTIX___PSEUDFACILITE", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ENTIX_PSEUDFACILITE]/

                conditions = entix___pseudfaciliteConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ENTIX_PSEUDFACILITE]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_facil");
				Navigation.DestroyEntry("QMVC_POS_RECORD_facil");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAfacil.GetInformation(), QMVC_POS_RECORD, sorts, entix___pseudfaciliteConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAfacil> listing = Models.ModelBase.Where<CSGenioAfacil>(false, entix___pseudfaciliteConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ENTIX___PSEUDFACILITE", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapEntix_ValFacilite(listing);

				Menu.Identifier = "IBL_ENTIX___PSEUDFACILITE";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ENTIX___PSEUDFACILITE";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Facil> MapEntix_ValFacilite(ListingMVC<CSGenioAfacil> Qlisting)
        {
            var Elements = new List<Models.Facil>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapEntix_ValFacilite(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAfacil row
        /// to a Models.Facil object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Facil MapEntix_ValFacilite(CSGenioAfacil row)
        {
            var model = new Models.Facil(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "facil":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "facty":
                        model.Facty.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ENTIX_VALFACILITE]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Facil", "Facil.ValCodfacil", "Facil.ValZzstate", "Facil.ValIncorpor", "Facil.ValName", "Facty", "Facty.ValType", "Facil.ValLatitude", "Facil.ValLongitud", "Facil.ValGeocoord", "Facil.ValImage", "Facil.ValCodentit", "Facil.ValCodfacty"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValIncorpor", CSGenioAfacil.FldIncorpor, typeof(DateTime?)),
            new TableSearchColumn("ValName", CSGenioAfacil.FldName, typeof(string), defaultSearch : true),
            new TableSearchColumn("Facty_ValType", CSGenioAfacty.FldType, typeof(string)),
            new TableSearchColumn("ValLatitude", CSGenioAfacil.FldLatitude, typeof(decimal?)),
            new TableSearchColumn("ValLongitud", CSGenioAfacil.FldLongitud, typeof(decimal?))
        };
    }
}
