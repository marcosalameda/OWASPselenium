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

namespace GenioMVC.ViewModels.Dttyp
{
    public class WMS_Menu_7111_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Dttyp> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "dttyp"; }

        /// <inheritdoc/>
        public override string Uuid { get => "c2b15f2a-27e8-459e-91be-79fcbdf502e1"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCoddttyp { get; set; }

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
            dbeditTitle = Resources.Resources.DATA_TYPES15706;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("dttyp", user, "WMS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAdttyp.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAdttyp.FldCoddttyp, CSGenioAdttyp.FldZzstate, CSGenioAdttyp.FldString, CSGenioAdttyp.FldUppercas, CSGenioAdttyp.FldQrcode, CSGenioAdttyp.FldMultilin, CSGenioAdttyp.FldMultili3, CSGenioAdttyp.FldBoolean, CSGenioAdttyp.FldBoolean2, CSGenioAdttyp.FldSmallint, CSGenioAdttyp.FldInteger, CSGenioAdttyp.FldBigint, CSGenioAdttyp.FldReal, CSGenioAdttyp.FldFloat, CSGenioAdttyp.FldDecimal, CSGenioAdttyp.FldDecimal9, CSGenioAdttyp.FldMoney, CSGenioAdttyp.FldMoney9, CSGenioAdttyp.FldDate, CSGenioAdttyp.FldDatetime, CSGenioAdttyp.FldDtsesond, CSGenioAdttyp.FldTime, CSGenioAdttyp.FldUuid, CSGenioAdttyp.FldImage, CSGenioAdttyp.FldStart, CSGenioAdttyp.FldEnd };

            ListingMVC<CSGenioAdttyp> listing = new ListingMVC<CSGenioAdttyp>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WMS_Menu_7111_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public WMS_Menu_7111_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAdttyp.FldString, FieldType.TEXTO, Resources.Resources.STRING29433, 30, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldUppercas, FieldType.TEXTO, Resources.Resources.UPPER_CASE31324, 30, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldQrcode, FieldType.TEXTO, Resources.Resources.QR_CODE12259, 30, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldMultilin, FieldType.MEMO, Resources.Resources.SIMPLE_MULTILINE_TEX04460, 30, 3, true),
                new Exports.QColumn(CSGenioAdttyp.FldMultili3, FieldType.MEMO, Resources.Resources.EDITOR_MULTILINE_TEX05556, 30, 3, true),
                new Exports.QColumn(CSGenioAdttyp.FldBoolean, FieldType.LOGICO, Resources.Resources.BOOLEAN__TINYINT___S57956, 1, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldBoolean2, FieldType.NUMERO, Resources.Resources.CONDITIONAL__BOOLEAN08919, 1, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldSmallint, FieldType.NUMERO, Resources.Resources.SMALL_INTEGER__STORA54196, 4, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldInteger, FieldType.NUMERO, Resources.Resources.INTEGER__STORAGE__4_49578, 9, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldBigint, FieldType.NUMERO, Resources.Resources.BIG_INTEGER__STORAGE28249, 15, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldReal, FieldType.NUMERO, Resources.Resources.REAL_FLOAT_24___PREC46659, 8, 2, true),
                new Exports.QColumn(CSGenioAdttyp.FldFloat, FieldType.NUMERO, Resources.Resources.DOUBLE___FLOAT_53___07951, 15, 2, true),
                new Exports.QColumn(CSGenioAdttyp.FldDecimal, FieldType.NUMERO, Resources.Resources.DECIMAL__1_10___STOR26677, 10, 4, true),
                new Exports.QColumn(CSGenioAdttyp.FldDecimal9, FieldType.NUMERO, Resources.Resources.DECIMAL__11_15___STO49382, 15, 4, true),
                new Exports.QColumn(CSGenioAdttyp.FldMoney, FieldType.VALOR, Resources.Resources.MONEY___DECIMAL__1_124403, 10, 2, true),
                new Exports.QColumn(CSGenioAdttyp.FldMoney9, FieldType.VALOR, Resources.Resources.MONEY___DECIMAL__11_02101, 15, 2, true),
                new Exports.QColumn(CSGenioAdttyp.FldDate, FieldType.DATA, Resources.Resources.DATE02091, 8, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldDatetime, FieldType.DATAHORA, Resources.Resources.DATETIME62630, 16, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldDtsesond, FieldType.DATASEGUNDO, Resources.Resources.DATE_TIME_SECOND__IN55990, 19, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldTime, FieldType.TEMPO, Resources.Resources.TIME50904, 5, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldUuid, FieldType.TEXTO, Resources.Resources.UUID__AKA_GUID_13998, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAdttyp.FldImage, FieldType.IMAGEM_JPEG, Resources.Resources.IMAGE__BINARY_46903, 3, 1, true):null,
                new Exports.QColumn(CSGenioAdttyp.FldStart, FieldType.DATAHORA, Resources.Resources.STARTING_TIME_WITH_I44217, 16, 0, true),
                new Exports.QColumn(CSGenioAdttyp.FldEnd, FieldType.DATAHORA, Resources.Resources.END_TIME_WITH_INCLUS19241, 16, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAdttyp> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "dttyp" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Dttyp>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_7111_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DTTYP.STRING", new OrderedDictionary());
			allSortOrders["DTTYP.STRING"].Add("DTTYP.STRING", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_7111_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Dttyp.AddEPH<CSGenioAdttyp>(ref u, crs, "ML7111");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAdttyp.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("DTTYP", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAdttyp.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dttyp");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dttyp");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Dttyp.AddEPH<CSGenioAdttyp>(ref u, null, "ML7111"));
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
            ListingMVC<CSGenioAdttyp> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAdttyp> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_7111", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_7111"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_7111");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Dttyp>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_7111_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("DTTYP.STRING", new OrderedDictionary());
			allSortOrders["DTTYP.STRING"].Add("DTTYP.STRING", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_7111"])) ? int.Parse(requestValues["pWMS_Menu_7111"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_7111", "dWMS_Menu_7111", requestValues, "dttyp", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAdttyp.FldString), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAdttyp.FldCoddttyp, CSGenioAdttyp.FldZzstate, CSGenioAdttyp.FldString, CSGenioAdttyp.FldUppercas, CSGenioAdttyp.FldQrcode, CSGenioAdttyp.FldMultilin, CSGenioAdttyp.FldMultili3, CSGenioAdttyp.FldBoolean, CSGenioAdttyp.FldBoolean2, CSGenioAdttyp.FldSmallint, CSGenioAdttyp.FldInteger, CSGenioAdttyp.FldBigint, CSGenioAdttyp.FldReal, CSGenioAdttyp.FldFloat, CSGenioAdttyp.FldDecimal, CSGenioAdttyp.FldDecimal9, CSGenioAdttyp.FldMoney, CSGenioAdttyp.FldMoney9, CSGenioAdttyp.FldDate, CSGenioAdttyp.FldDatetime, CSGenioAdttyp.FldDtsesond, CSGenioAdttyp.FldTime, CSGenioAdttyp.FldUuid, CSGenioAdttyp.FldImage, CSGenioAdttyp.FldStart, CSGenioAdttyp.FldEnd };


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
					firstVisibleColumn = new FieldRef("dttyp", "string");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAdttyp model_limit_area = new CSGenioAdttyp(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML7111");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet wms_menu_7111Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 7111]/

            // This will happen in case there is an error
            if(wms_menu_7111Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAdttyp>(false, wms_menu_7111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML7111", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 7111]/

                conditions = wms_menu_7111Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 7111]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_dttyp");
				Navigation.DestroyEntry("QMVC_POS_RECORD_dttyp");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAdttyp.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_7111Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAdttyp> listing = Models.ModelBase.Where<CSGenioAdttyp>(false, wms_menu_7111Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML7111", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapWMS_Menu_7111(listing);

				Menu.Identifier = "ML7111";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML7111";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Dttyp> MapWMS_Menu_7111(ListingMVC<CSGenioAdttyp> Qlisting)
        {
            var Elements = new List<Models.Dttyp>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_7111(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAdttyp row
        /// to a Models.Dttyp object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Dttyp MapWMS_Menu_7111(CSGenioAdttyp row)
        {
            var model = new Models.Dttyp(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "dttyp":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_7111]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Dttyp", "Dttyp.ValCoddttyp", "Dttyp.ValZzstate", "Dttyp.ValString", "Dttyp.ValUppercas", "Dttyp.ValQrcode", "Dttyp.ValMultilin", "Dttyp.ValMultili3", "Dttyp.ValBoolean", "Dttyp.ValBoolean2", "Dttyp.ValSmallint", "Dttyp.ValInteger", "Dttyp.ValBigint", "Dttyp.ValReal", "Dttyp.ValFloat", "Dttyp.ValDecimal", "Dttyp.ValDecimal9", "Dttyp.ValMoney", "Dttyp.ValMoney9", "Dttyp.ValDate", "Dttyp.ValDatetime", "Dttyp.ValDtsesond", "Dttyp.ValTime", "Dttyp.ValUuid", "Dttyp.ValImage", "Dttyp.ValStart", "Dttyp.ValEnd"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValString", CSGenioAdttyp.FldString, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValUppercas", CSGenioAdttyp.FldUppercas, typeof(string)),
            new TableSearchColumn("ValQrcode", CSGenioAdttyp.FldQrcode, typeof(string)),
            new TableSearchColumn("ValMultilin", CSGenioAdttyp.FldMultilin, typeof(string)),
            new TableSearchColumn("ValMultili3", CSGenioAdttyp.FldMultili3, typeof(string)),
            new TableSearchColumn("ValBoolean", CSGenioAdttyp.FldBoolean, typeof(bool)),
            new TableSearchColumn("ValBoolean2", CSGenioAdttyp.FldBoolean2, typeof(decimal)),
            new TableSearchColumn("ValSmallint", CSGenioAdttyp.FldSmallint, typeof(decimal?)),
            new TableSearchColumn("ValInteger", CSGenioAdttyp.FldInteger, typeof(decimal?)),
            new TableSearchColumn("ValBigint", CSGenioAdttyp.FldBigint, typeof(decimal?)),
            new TableSearchColumn("ValReal", CSGenioAdttyp.FldReal, typeof(decimal?)),
            new TableSearchColumn("ValFloat", CSGenioAdttyp.FldFloat, typeof(decimal?)),
            new TableSearchColumn("ValDecimal", CSGenioAdttyp.FldDecimal, typeof(decimal?)),
            new TableSearchColumn("ValDecimal9", CSGenioAdttyp.FldDecimal9, typeof(decimal?)),
            new TableSearchColumn("ValMoney", CSGenioAdttyp.FldMoney, typeof(decimal?)),
            new TableSearchColumn("ValMoney9", CSGenioAdttyp.FldMoney9, typeof(decimal?)),
            new TableSearchColumn("ValDate", CSGenioAdttyp.FldDate, typeof(DateTime?)),
            new TableSearchColumn("ValDatetime", CSGenioAdttyp.FldDatetime, typeof(DateTime?)),
            new TableSearchColumn("ValDtsesond", CSGenioAdttyp.FldDtsesond, typeof(DateTime?)),
            new TableSearchColumn("ValTime", CSGenioAdttyp.FldTime, typeof(string)),
            new TableSearchColumn("ValUuid", CSGenioAdttyp.FldUuid, typeof(string)),
            new TableSearchColumn("ValStart", CSGenioAdttyp.FldStart, typeof(DateTime?)),
            new TableSearchColumn("ValEnd", CSGenioAdttyp.FldEnd, typeof(DateTime?))
        };

    }
}
