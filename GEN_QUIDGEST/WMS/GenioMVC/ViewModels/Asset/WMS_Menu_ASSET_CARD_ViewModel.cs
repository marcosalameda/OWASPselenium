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

namespace GenioMVC.ViewModels.Asset
{
    public class WMS_Menu_ASSET_CARD_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Asset> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "asset"; }

        /// <inheritdoc/>
        public override string Uuid { get => "cbba1257-006c-407c-bff6-cb87a80d6f4e"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodasset { get; set; }

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

        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.EQUIPMENTS06276;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("asset", user, "WMS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAasset.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

                        conditions.Equal(CSGenioAasset.FldAssettyp, "E");



            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldZzstate, CSGenioAasset.FldAssetnum, CSGenioAasset.FldName, CSGenioAasset.FldCodkinde, CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAasset.FldIdenttyp, CSGenioAasset.FldGrai, CSGenioAasset.FldGiai, CSGenioAasset.FldPhoto, CSGenioAasset.FldCodmanuf, CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAmanuf.FldWebsite };

            ListingMVC<CSGenioAasset> listing = new ListingMVC<CSGenioAasset>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WMS_Menu_ASSET_CARD_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public WMS_Menu_ASSET_CARD_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAasset.FldAssetnum, FieldType.NUMERO, Resources.Resources.ASSET_NUMBER52372, 10, 0, true),
                new Exports.QColumn(CSGenioAasset.FldName, FieldType.TEXTO, Resources.Resources.IDENTIFICATION_NAME16317, 30, 0, true),
                new Exports.QColumn(CSGenioAkinde.FldDesignat, FieldType.TEXTO, Resources.Resources.KIND_OF_EQUIPMENT22928, 30, 0, false),
                new Exports.QColumn(CSGenioAasset.FldIdenttyp, FieldType.ARRAY_COD_TEXTO, Resources.Resources.IDENTIFIER_TYPE60623, 1, 0, true, "IdentTyp"),
                new Exports.QColumn(CSGenioAasset.FldGrai, FieldType.TEXTO, Resources.Resources.GRAI10374, 30, 0, true),
                new Exports.QColumn(CSGenioAasset.FldGiai, FieldType.TEXTO, Resources.Resources.GIAI50592, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAasset.FldPhoto, FieldType.IMAGEM_JPEG, Resources.Resources.PHOTO51874, 3, 1, true):null,
                new Exports.QColumn(CSGenioAmanuf.FldName, FieldType.TEXTO, Resources.Resources.MANUFACTURER50759, 30, 0, true),
                new Exports.QColumn(CSGenioAmanuf.FldWebsite, FieldType.TEXTO, Resources.Resources.WEB_SITE06263, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAasset> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "asset" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Asset>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_ASSET_CARD_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ASSET.NAME", new OrderedDictionary());
			allSortOrders["ASSET.NAME"].Add("ASSET.NAME", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_ASSET_CARD_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			// Limitations
			// Limit "SC"
			crs.Equal(CSGenioAasset.FldAssettyp, "E");

			if (isToExport)
			{
				// EPH
				crs = Models.Asset.AddEPH<CSGenioAasset>(ref u, crs, "MLASSET_CARD");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAasset.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("ASSET", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAasset.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asset");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asset");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Asset.AddEPH<CSGenioAasset>(ref u, null, "MLASSET_CARD"));
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
            ListingMVC<CSGenioAasset> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAasset> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_ASSET_CARD", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_ASSET_CARD"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_ASSET_CARD");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Asset>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_ASSET_CARD_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("ASSET.NAME", new OrderedDictionary());
			allSortOrders["ASSET.NAME"].Add("ASSET.NAME", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_ASSET_CARD"])) ? int.Parse(requestValues["pWMS_Menu_ASSET_CARD"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_ASSET_CARD", "dWMS_Menu_ASSET_CARD", requestValues, "asset", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasset.FldName), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldZzstate, CSGenioAasset.FldAssetnum, CSGenioAasset.FldName, CSGenioAasset.FldCodkinde, CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAasset.FldIdenttyp, CSGenioAasset.FldGrai, CSGenioAasset.FldGiai, CSGenioAasset.FldPhoto, CSGenioAasset.FldCodmanuf, CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAmanuf.FldWebsite };


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
					firstVisibleColumn = new FieldRef("asset", "assetnum");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAasset model_limit_area = new CSGenioAasset(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "MLASSET_CARD");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 


			//Limit type: "SC"			//Current Area = "ASSET"			//1st Area Limit: "ASSET"			//1st Area Field: "ASSETTYP"			//1st Area Value: "E"
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.SC;
				limit.NaoAplicaSeNulo = false;
				CSGenioAasset model_limit_area = new CSGenioAasset(UserContext.Current.User);
				string limit_field = "assettyp", limit_field_value = "E";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.tableLimits.Add(limit);
			}

			CriteriaSet wms_menu_asset_cardConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ ASSET_CARD]/

            // This will happen in case there is an error
            if(wms_menu_asset_cardConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAasset>(false, wms_menu_asset_cardConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLASSET_CARD", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP ASSET_CARD]/

                conditions = wms_menu_asset_cardConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST ASSET_CARD]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_asset");
				Navigation.DestroyEntry("QMVC_POS_RECORD_asset");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAasset.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_asset_cardConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(false, wms_menu_asset_cardConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "MLASSET_CARD", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapWMS_Menu_ASSET_CARD(listing);

				Menu.Identifier = "MLASSET_CARD";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "MLASSET_CARD";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Asset> MapWMS_Menu_ASSET_CARD(ListingMVC<CSGenioAasset> Qlisting)
        {
            var Elements = new List<Models.Asset>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_ASSET_CARD(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAasset row
        /// to a Models.Asset object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Asset MapWMS_Menu_ASSET_CARD(CSGenioAasset row)
        {
            var model = new Models.Asset(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "asset":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "kinde":
                        model.Kinde.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "manuf":
                        model.Manuf.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_ASSET_CARD]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValAssetnum", "Asset.ValName", "Kinde", "Kinde.ValDesignat", "Asset.ValIdenttyp", "Asset.ValGrai", "Asset.ValGiai", "Asset.ValPhoto", "Manuf", "Manuf.ValName", "Manuf.ValWebsite", "Asset.ValCodkinde", "Asset.ValCodmanuf"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValAssetnum", CSGenioAasset.FldAssetnum, typeof(decimal?)),
            new TableSearchColumn("ValName", CSGenioAasset.FldName, typeof(string), defaultSearch : true),
            new TableSearchColumn("Kinde_ValDesignat", CSGenioAkinde.FldDesignat, typeof(string), visible : false),
            new TableSearchColumn("ValIdenttyp", CSGenioAasset.FldIdenttyp, typeof(string), array : "IdentTyp"),
            new TableSearchColumn("ValGrai", CSGenioAasset.FldGrai, typeof(string)),
            new TableSearchColumn("ValGiai", CSGenioAasset.FldGiai, typeof(string)),
            new TableSearchColumn("Manuf_ValName", CSGenioAmanuf.FldName, typeof(string)),
            new TableSearchColumn("Manuf_ValWebsite", CSGenioAmanuf.FldWebsite, typeof(string))
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
                        new SpecialRenderingVariable { Variable = "title", Value = "ASSET.NAME", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "subtitle", Value = "ASSET.ASSETNUM", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "text", Value = "ASSET.GIAI", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "text", Value = "ASSET.GRAI", AllowMultiple = true },
                        new SpecialRenderingVariable { Variable = "image", Value = "ASSET.PHOTO", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "btn-href", Value = "MANUF.WEBSITE", AllowMultiple = false },
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "show-column-titles", Value = "true" },
                        new SpecialRenderingVariable { Variable = "image-shape", Value = "rectangular" },
                        new SpecialRenderingVariable { Variable = "background-color", Value = "auto" },
                        new SpecialRenderingVariable { Variable = "actions-alignment", Value = "right" },
                        new SpecialRenderingVariable { Variable = "hover-scale-amount", Value = "1.05" },
                        new SpecialRenderingVariable { Variable = "content-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "actions-style", Value = "dropdown" },
                        new SpecialRenderingVariable { Variable = "custom-followup-default-target", Value = "blank" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card", Value = "false" },
                        new SpecialRenderingVariable { Variable = "custom-insert-card-style", Value = "secondary" },
                        new SpecialRenderingVariable { Variable = "display-mode", Value = "grid" },
                        new SpecialRenderingVariable { Variable = "container-alignment", Value = "left" },
                        new SpecialRenderingVariable { Variable = "show-empty-column-titles", Value = "true" },
                        new SpecialRenderingVariable { Variable = "size", Value = "regular" },
                    },
                },
                new SpecialRendering
                {
                    Id = "CAROUSEL",
                    Ordem = 3,
                    Subtipo = "",
                    MappingVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "slide-title", Value = "ASSET.NAME", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "slide-subtitle", Value = "ASSET.ASSETNUM", AllowMultiple = false },
                        new SpecialRenderingVariable { Variable = "slide-image", Value = "ASSET.PHOTO", AllowMultiple = false },
                    },
                    StyleVariables = new List<SpecialRenderingVariable>()
                    {
                        new SpecialRenderingVariable { Variable = "wrap", Value = "true" },
                        new SpecialRenderingVariable { Variable = "show-indicators", Value = "true" },
                        new SpecialRenderingVariable { Variable = "auto-cycle-pause", Value = "hover" },
                        new SpecialRenderingVariable { Variable = "keyboard-controllable", Value = "true" },
                        new SpecialRenderingVariable { Variable = "auto-cycle-interval", Value = "" },
                        new SpecialRenderingVariable { Variable = "show-controls", Value = "true" },
                        new SpecialRenderingVariable { Variable = "ride", Value = "carousel" },
                    },
                },
            }
        };

        override public SpecialRenderingsCfg ViewModesCfg { get => _viewModes; }
    }
}
