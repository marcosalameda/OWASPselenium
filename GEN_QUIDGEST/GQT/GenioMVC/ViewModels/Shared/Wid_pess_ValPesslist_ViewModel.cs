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

namespace GenioMVC.ViewModels
{
    public class Wid_pess_ValPesslist_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Pesso> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "pesso"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Wid_pess_ValPesslist"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

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
        /// Initializes a new instance of the <see cref="Wid_pess_ValPesslist_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Wid_pess_ValPesslist_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioApesso.FldPhotogra, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
                new Exports.QColumn(CSGenioApesso.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
                new Exports.QColumn(CSGenioAcateg.FldCategoria, FieldType.TEXTO, Resources.Resources.CATEGORY18978, 30, 0, true),
                new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.COMPANY52963, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioApesso> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "pesso" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Pesso>();
			Menu.SetFilters(bool.Parse(requestValues["ValPesslist_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValPesslist_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);






			if (isToExport)
			{
				// EPH
				crs = Models.Pesso.AddEPH<CSGenioApesso>(ref u, crs, "IBL_WID_PESSPSEUDPESSLIST");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioApesso.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PESSO", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioApesso.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Pesso.AddEPH<CSGenioApesso>(ref u, null, "IBL_WID_PESSPSEUDPESSLIST"));
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
            ListingMVC<CSGenioApesso> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioApesso> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Wid_pess_ValPesslist", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Wid_pess_ValPesslist"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Wid_pess_ValPesslist");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Pesso>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValPesslist"])) ? int.Parse(requestValues["pValPesslist"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValPesslist", "dValPesslist", requestValues, "pesso", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioApesso.FldCodpesso, CSGenioApesso.FldZzstate, CSGenioApesso.FldName, CSGenioApesso.FldPhotogra, CSGenioApesso.FldEmail, CSGenioApesso.FldCodcateg, CSGenioAcateg.FldCodcateg, CSGenioAcateg.FldCategoria, CSGenioApesso.FldCodempre, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat };


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
					firstVisibleColumn = new FieldRef("pesso", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioApesso model_limit_area = new CSGenioApesso(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_WID_PESSPSEUDPESSLIST");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet wid_pesspseudpesslistConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ WID_PESS_PSEUDPESSLIST]/

            // This will happen in case there is an error
            if(wid_pesspseudpesslistConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioApesso>(false, wid_pesspseudpesslistConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WID_PESSPSEUDPESSLIST", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP WID_PESS_PSEUDPESSLIST]/

                conditions = wid_pesspseudpesslistConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST WID_PESS_PSEUDPESSLIST]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_pesso");
				Navigation.DestroyEntry("QMVC_POS_RECORD_pesso");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioApesso.GetInformation(), QMVC_POS_RECORD, sorts, wid_pesspseudpesslistConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(false, wid_pesspseudpesslistConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_WID_PESSPSEUDPESSLIST", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapWid_pess_ValPesslist(listing);

				Menu.Identifier = "IBL_WID_PESSPSEUDPESSLIST";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_WID_PESSPSEUDPESSLIST";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Pesso> MapWid_pess_ValPesslist(ListingMVC<CSGenioApesso> Qlisting)
        {
            var Elements = new List<Models.Pesso>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWid_pess_ValPesslist(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioApesso row
        /// to a Models.Pesso object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Pesso MapWid_pess_ValPesslist(CSGenioApesso row)
        {
            var model = new Models.Pesso(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "pesso":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "categ":
                        model.Categ.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "cmpny":
                        model.Cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WID_PESS_VALPESSLIST]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName", "Pesso.ValPhotogra", "Pesso.ValEmail", "Categ", "Categ.ValCategoria", "Cmpny", "Cmpny.ValDesignat", "Pesso.ValCodempre", "Pesso.ValCodpaise", "Pesso.ValCodcntry", "Pesso.ValCodregia", "Pesso.ValCodcateg"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValName", CSGenioApesso.FldName, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValEmail", CSGenioApesso.FldEmail, typeof(string)),
            new TableSearchColumn("Categ_ValCategoria", CSGenioAcateg.FldCategoria, typeof(string), defaultSearch : true),
            new TableSearchColumn("Cmpny_ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string), defaultSearch : true)
        };

        // Note: cannot be marked static because some variables might depend on the current user language.
        private readonly SpecialRenderingsCfg _viewModes = new SpecialRenderingsCfg()
        {
            SpecialRenderings = new List<SpecialRendering>()
            {
                new SpecialRendering
                {
                    Id = "LIST",
                    Ordem = 1,
                    Subtipo = "",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                    },
                },
                new SpecialRendering
                {
                    Id = "CARDS",
                    Ordem = 2,
                    Subtipo = "card-img-top",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "title", Value = "PESSO.NAME", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "subtitle", Value = "PESSO.EMAIL", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "text", Value = "CATEG.CATEGORY", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "image", Value = "PESSO.PHOTOGRA", AllowMultiple = false },
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "custom-insert-card", Value = "true" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card-style", Value = "image" },
                        new SpecialRenderingVariable { Variable = "actions-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "actions-style", Value = "dropdown" },
                        new SpecialRenderingVariable { Variable = "background-color", Value = "auto" },
                        new SpecialRenderingVariable { Variable = "content-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "custom-followup-default-target", Value = "blank" },
                        new SpecialRenderingVariable { Variable = "display-mode", Value = "grid" },
                        new SpecialRenderingVariable { Variable = "container-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "hover-scale-amount", Value = "1.00" },
                        new SpecialRenderingVariable { Variable = "image-shape", Value = "rectangular" },
                        new SpecialRenderingVariable { Variable = "show-column-titles", Value = "false" },
                        new SpecialRenderingVariable { Variable = "show-empty-column-titles", Value = "true" },
                        new SpecialRenderingVariable { Variable = "size", Value = "regular" },
                    },
                },
            }
        };

        override public SpecialRenderingsCfg ViewModesCfg { get => _viewModes; }

    }
}
