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
    public class Equip_ValMovimels_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Movim> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "movim"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Equip_ValMovimels"; }

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
// USE /[MANUAL GQT LIST_LIMITS EQUIP_PSEUDMOVIMELS]/

			return crs;
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="Equip_ValMovimels_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Equip_ValMovimels_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodequip = currentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAmovim.FldDhmudanc, FieldType.DATAHORA, Resources.Resources.CHANGE36355, 16, 0, true),
                new Exports.QColumn(CSGenioArooms.FldRoomnr, FieldType.TEXTO, Resources.Resources.N_R__ROOM43805, 10, 0, true),
                new Exports.QColumn(CSGenioArooms.FldDesignat, FieldType.TEXTO, Resources.Resources.ROOM_DESIGNATION37895, 30, 0, true),
                new Exports.QColumn(CSGenioAmovim.FldObservat, FieldType.MEMO, Resources.Resources.OBSERVATION37880, 30, 2, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAmovim> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "movim" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Movim>();
			Menu.SetFilters(bool.Parse(requestValues["ValMovimels_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("MOVIM.DHMUDANC", new OrderedDictionary());
			allSortOrders["MOVIM.DHMUDANC"].Add("MOVIM.DHMUDANC", "D");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValMovimels_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodequip != null)
				crs.Equal(CSGenioAmovim.FldCodequip, this.ValCodequip);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Movim.AddEPH<CSGenioAmovim>(ref u, crs, "IBL_EQUIP___PSEUDMOVIMELS");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAmovim.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("MOVIM", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAmovim.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_movim");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Movim.AddEPH<CSGenioAmovim>(ref u, null, "IBL_EQUIP___PSEUDMOVIMELS"));
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
            ListingMVC<CSGenioAmovim> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAmovim> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Equip_ValMovimels", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Equip_ValMovimels"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Equip_ValMovimels");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Movim>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("MOVIM.DHMUDANC", new OrderedDictionary());
			allSortOrders["MOVIM.DHMUDANC"].Add("MOVIM.DHMUDANC", "D");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValMovimels"])) ? int.Parse(requestValues["pValMovimels"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValMovimels", "dValMovimels", requestValues, "movim", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAmovim.FldDhmudanc), SortOrder.Descending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAmovim.FldCodmovim, CSGenioAmovim.FldZzstate, CSGenioAmovim.FldDhmudanc, CSGenioAmovim.FldCodrooms, CSGenioArooms.FldCodrooms, CSGenioArooms.FldRoomnr, CSGenioArooms.FldDesignat, CSGenioAmovim.FldObservat };


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
					firstVisibleColumn = new FieldRef("movim", "dhmudanc");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAmovim model_limit_area = new CSGenioAmovim(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_EQUIP___PSEUDMOVIMELS");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet equip___pseudmovimelsConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ EQUIP_PSEUDMOVIMELS]/

            // This will happen in case there is an error
            if(equip___pseudmovimelsConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAmovim>(false, equip___pseudmovimelsConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___PSEUDMOVIMELS", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP EQUIP_PSEUDMOVIMELS]/

                conditions = equip___pseudmovimelsConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST EQUIP_PSEUDMOVIMELS]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_movim");
				Navigation.DestroyEntry("QMVC_POS_RECORD_movim");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAmovim.GetInformation(), QMVC_POS_RECORD, sorts, equip___pseudmovimelsConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAmovim> listing = Models.ModelBase.Where<CSGenioAmovim>(false, equip___pseudmovimelsConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_EQUIP___PSEUDMOVIMELS", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapEquip_ValMovimels(listing);

				Menu.Identifier = "IBL_EQUIP___PSEUDMOVIMELS";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_EQUIP___PSEUDMOVIMELS";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Movim> MapEquip_ValMovimels(ListingMVC<CSGenioAmovim> Qlisting)
        {
            var Elements = new List<Models.Movim>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapEquip_ValMovimels(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAmovim row
        /// to a Models.Movim object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Movim MapEquip_ValMovimels(CSGenioAmovim row)
        {
            var model = new Models.Movim(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "movim":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "rooms":
                        model.Rooms.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_VALMOVIMELS]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Movim", "Movim.ValCodmovim", "Movim.ValZzstate", "Movim.ValDhmudanc", "Rooms", "Rooms.ValRoomnr", "Rooms.ValDesignat", "Movim.ValObservat", "Movim.ValCodequip", "Movim.ValCodrooms"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValDhmudanc", CSGenioAmovim.FldDhmudanc, typeof(DateTime?)),
            new TableSearchColumn("Rooms_ValRoomnr", CSGenioArooms.FldRoomnr, typeof(string)),
            new TableSearchColumn("Rooms_ValDesignat", CSGenioArooms.FldDesignat, typeof(string)),
            new TableSearchColumn("ValObservat", CSGenioAmovim.FldObservat, typeof(string))
        };

    }
}
