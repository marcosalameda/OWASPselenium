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

namespace GenioMVC.ViewModels.Flds
{
    public class PTN_Menu_611_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Flds> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "flds"; }

        /// <inheritdoc/>
        public override string Uuid { get => "8c79866f-7459-4fd0-8b1b-b5434e42c174"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodflds { get; set; }

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
            dbeditTitle = Resources.Resources.FIELD_TYPES49172;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("flds", user, "PTN");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAflds.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCodaero, CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAflds.FldDescrip, CSGenioAflds.FldNpassage, CSGenioAflds.FldDuration, CSGenioAflds.FldPrice, CSGenioAflds.FldPrecobil, CSGenioAflds.FldDate, CSGenioAflds.FldDatetime, CSGenioAflds.FldDateseco, CSGenioAflds.FldTime, CSGenioAflds.FldYear, CSGenioAflds.FldPrimviag, CSGenioAflds.FldConditio, CSGenioAflds.FldClass, CSGenioAflds.FldClassnum, CSGenioAflds.FldLogicenu, CSGenioAflds.FldLogo, CSGenioAflds.FldAttach, CSGenioAflds.FldLogoexte, CSGenioAflds.FldCreatuse, CSGenioAflds.FldCreatdat, CSGenioAflds.FldCreathou, CSGenioAflds.FldCreatins, CSGenioAflds.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAflds.FldTxtfield, CSGenioAflds.FldEmailfld, CSGenioAflds.FldZipfield, CSGenioAflds.FldIbanfiel, CSGenioAflds.FldSsnumber, CSGenioAflds.FldLicplate, CSGenioAflds.FldVatnumbr, CSGenioAflds.FldBanknmbr, CSGenioAflds.FldUpprtext, CSGenioAflds.FldPassfld, CSGenioAflds.FldClrpicke, CSGenioAflds.FldShwrc, CSGenioAflds.FldRadiob };

            ListingMVC<CSGenioAflds> listing = new ListingMVC<CSGenioAflds>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PTN_Menu_611_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public PTN_Menu_611_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAaero.FldName, FieldType.TEXTO, Resources.Resources.AIRLINE_NAME55130, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDescrip, FieldType.MEMO, Resources.Resources.DESCRIPTION07383, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldNpassage, FieldType.NUMERO, Resources.Resources.NUMERIC19292, 3, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDuration, FieldType.NUMERO, Resources.Resources.NUMERIC_DECIMAL37352, 5, 2, true),
                new Exports.QColumn(CSGenioAflds.FldPrice, FieldType.VALOR, Resources.Resources.CURRENCY13881, 6, 0, true),
                new Exports.QColumn(CSGenioAflds.FldPrecobil, FieldType.VALOR, Resources.Resources.CURRENCY_DECIMAL48296, 6, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDate, FieldType.DATA, Resources.Resources.DATE__DD_MM_YY_57869, 8, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDatetime, FieldType.DATAHORA, Resources.Resources.DATETIME61308, 16, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDateseco, FieldType.DATASEGUNDO, Resources.Resources.DATESECOND44557, 19, 0, true),
                new Exports.QColumn(CSGenioAflds.FldTime, FieldType.TEMPO, Resources.Resources.TIME15328, 5, 0, true),
                new Exports.QColumn(CSGenioAflds.FldYear, FieldType.NUMERO, Resources.Resources.YEAR61794, 4, 0, true),
                new Exports.QColumn(CSGenioAflds.FldPrimviag, FieldType.LOGICO, Resources.Resources.LOGICAL47485, 1, 0, true),
                new Exports.QColumn(CSGenioAflds.FldConditio, FieldType.NUMERO, Resources.Resources.CONDITIONAL01431, 1, 0, true),
                new Exports.QColumn(CSGenioAflds.FldClass, FieldType.ARRAY_COD_TEXTO, Resources.Resources.TEXT_ENUMERATION45668, 2, 0, true, "CLASS"),
                new Exports.QColumn(CSGenioAflds.FldClassnum, FieldType.ARRAY_COD_NUMERICO, Resources.Resources.NUMERIC_ENUMERATION19068, 1, 0, true, "CLASSNUM"),
                new Exports.QColumn(CSGenioAflds.FldLogicenu, FieldType.ARRAY_COD_LOGICO, Resources.Resources.LOGICAL_ENUMERATION30276, 1, 0, true, "PRIMVIAG"),
                !ajaxRequest ? new Exports.QColumn(CSGenioAflds.FldLogo, FieldType.IMAGEM_JPEG, Resources.Resources.LOGO62483, 3, 1, true):null,
                new Exports.QColumn(CSGenioAflds.FldAttach, FieldType.FICHEIRO_BD, Resources.Resources.DOCUMENT00695, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldLogoexte, FieldType.PATH, Resources.Resources.LOGO__EXTERNAL_FILE_58162, 3, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreatuse, FieldType.OPERCRIA, Resources.Resources.CREATED_BY12292, 20, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreatdat, FieldType.DATACRIA, Resources.Resources.DATE_OF_CREATION__DD02208, 8, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreathou, FieldType.HORACRIA, Resources.Resources.HOUR_OF_CREATION33629, 5, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreatins, FieldType.INSTANTECRIA, Resources.Resources.COMPLETE_DATE_OF_CRE57046, 15, 0, true),
                new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXTO, Resources.Resources.NO__REGISTER04207, 6, 0, true),
                new Exports.QColumn(CSGenioAflds.FldTxtfield, FieldType.TEXTO, Resources.Resources.TEXT_FIELD41810, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldEmailfld, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldZipfield, FieldType.TEXTO, Resources.Resources.ZIPCODE21021, 8, 0, true),
                new Exports.QColumn(CSGenioAflds.FldIbanfiel, FieldType.TEXTO, Resources.Resources.IBAN28506, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldSsnumber, FieldType.TEXTO, Resources.Resources.SOCIAL_SECURITY_NO48150, 11, 0, true),
                new Exports.QColumn(CSGenioAflds.FldLicplate, FieldType.TEXTO, Resources.Resources.LICENCE_PLATE07627, 8, 0, true),
                new Exports.QColumn(CSGenioAflds.FldVatnumbr, FieldType.TEXTO, Resources.Resources.VAT_NUMBER24236, 9, 0, true),
                new Exports.QColumn(CSGenioAflds.FldBanknmbr, FieldType.TEXTO, Resources.Resources.BANKING_ACCOUNT_NUMB62548, 24, 0, true),
                new Exports.QColumn(CSGenioAflds.FldUpprtext, FieldType.TEXTO, Resources.Resources.UPPERCASE48238, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldPassfld, FieldType.TEXTO, Resources.Resources.PASSWORD09467, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldClrpicke, FieldType.TEXTO, Resources.Resources.COLORPICKER39653, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldShwrc, FieldType.LOGICO, Resources.Resources.SHOW_RECORD53851, 1, 0, true),
                new Exports.QColumn(CSGenioAflds.FldRadiob, FieldType.ARRAY_COD_TEXTO, Resources.Resources.RADIO_BTN20980, 5, 0, true, "RADIOBTN"),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAflds> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "flds" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Flds>();
			Menu.SetFilters(bool.Parse(requestValues["PTN_Menu_611_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FLDS.DURATION", new OrderedDictionary());
			allSortOrders["FLDS.DURATION"].Add("FLDS.DURATION", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "PTN_Menu_611_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Flds.AddEPH<CSGenioAflds>(ref u, crs, "ML611");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAflds.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FLDS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAflds.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				Navigation.DestroyEntry("QMVC_POS_RECORD_flds");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Flds.AddEPH<CSGenioAflds>(ref u, null, "ML611"));
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
            ListingMVC<CSGenioAflds> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAflds> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "PTN_Menu_611", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "PTN_Menu_611"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "PTN_Menu_611");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Flds>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FLDS.DURATION", new OrderedDictionary());
			allSortOrders["FLDS.DURATION"].Add("FLDS.DURATION", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pPTN_Menu_611"])) ? int.Parse(requestValues["pPTN_Menu_611"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sPTN_Menu_611", "dPTN_Menu_611", requestValues, "flds", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAflds.FldDuration), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCodaero, CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAflds.FldDescrip, CSGenioAflds.FldNpassage, CSGenioAflds.FldDuration, CSGenioAflds.FldPrice, CSGenioAflds.FldPrecobil, CSGenioAflds.FldDate, CSGenioAflds.FldDatetime, CSGenioAflds.FldDateseco, CSGenioAflds.FldTime, CSGenioAflds.FldYear, CSGenioAflds.FldPrimviag, CSGenioAflds.FldConditio, CSGenioAflds.FldClass, CSGenioAflds.FldClassnum, CSGenioAflds.FldLogicenu, CSGenioAflds.FldLogo, CSGenioAflds.FldAttach, CSGenioAflds.FldAttachfk, CSGenioAflds.FldLogoexte, CSGenioAflds.FldCreatuse, CSGenioAflds.FldCreatdat, CSGenioAflds.FldCreathou, CSGenioAflds.FldCreatins, CSGenioAflds.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr, CSGenioAflds.FldTxtfield, CSGenioAflds.FldEmailfld, CSGenioAflds.FldZipfield, CSGenioAflds.FldIbanfiel, CSGenioAflds.FldSsnumber, CSGenioAflds.FldLicplate, CSGenioAflds.FldVatnumbr, CSGenioAflds.FldBanknmbr, CSGenioAflds.FldUpprtext, CSGenioAflds.FldPassfld, CSGenioAflds.FldClrpicke, CSGenioAflds.FldShwrc, CSGenioAflds.FldRadiob };


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
					firstVisibleColumn = new FieldRef("aero", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAflds model_limit_area = new CSGenioAflds(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML611");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet ptn_menu_611Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL PTN OVERRQ 611]/

            // This will happen in case there is an error
            if(ptn_menu_611Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAflds>(false, ptn_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL PTN OVERRQLSTEXP 611]/

                conditions = ptn_menu_611Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL PTN OVERRQLIST 611]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				Navigation.DestroyEntry("QMVC_POS_RECORD_flds");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAflds.GetInformation(), QMVC_POS_RECORD, sorts, ptn_menu_611Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAflds> listing = Models.ModelBase.Where<CSGenioAflds>(false, ptn_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapPTN_Menu_611(listing);

				Menu.Identifier = "ML611";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML611";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Flds> MapPTN_Menu_611(ListingMVC<CSGenioAflds> Qlisting)
        {
            var Elements = new List<Models.Flds>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPTN_Menu_611(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAflds row
        /// to a Models.Flds object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Flds MapPTN_Menu_611(CSGenioAflds row)
        {
            var model = new Models.Flds(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "flds":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "aero":
                        model.Aero.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "equip":
                        model.Equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PTN_MENU_611]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Flds", "Flds.ValCodflds", "Flds.ValZzstate", "Aero", "Aero.ValName", "Flds.ValDescrip", "Flds.ValNpassage", "Flds.ValDuration", "Flds.ValPrice", "Flds.ValPrecobil", "Flds.ValDate", "Flds.ValDatetime", "Flds.ValDateseco", "Flds.ValTime", "Flds.ValYear", "Flds.ValPrimviag", "Flds.ValConditio", "Flds.ValClass", "Flds.ValClassnum", "Flds.ValLogicenu", "Flds.ValLogo", "Flds.ValAttach", "Flds.ValLogoexte", "Flds.ValCreatuse", "Flds.ValCreatdat", "Flds.ValCreathou", "Flds.ValCreatins", "Equip", "Equip.ValRegistnr", "Flds.ValTxtfield", "Flds.ValEmailfld", "Flds.ValZipfield", "Flds.ValIbanfiel", "Flds.ValSsnumber", "Flds.ValLicplate", "Flds.ValVatnumbr", "Flds.ValBanknmbr", "Flds.ValUpprtext", "Flds.ValPassfld", "Flds.ValClrpicke", "Flds.ValShwrc", "Flds.ValRadiob", "Flds.ValCodaero", "Flds.ValCodequip"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("Aero_ValName", CSGenioAaero.FldName, typeof(string)),
            new TableSearchColumn("ValDescrip", CSGenioAflds.FldDescrip, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValNpassage", CSGenioAflds.FldNpassage, typeof(decimal?)),
            new TableSearchColumn("ValDuration", CSGenioAflds.FldDuration, typeof(decimal?)),
            new TableSearchColumn("ValPrice", CSGenioAflds.FldPrice, typeof(decimal?)),
            new TableSearchColumn("ValPrecobil", CSGenioAflds.FldPrecobil, typeof(decimal?)),
            new TableSearchColumn("ValDate", CSGenioAflds.FldDate, typeof(DateTime?)),
            new TableSearchColumn("ValDatetime", CSGenioAflds.FldDatetime, typeof(DateTime?)),
            new TableSearchColumn("ValDateseco", CSGenioAflds.FldDateseco, typeof(DateTime?)),
            new TableSearchColumn("ValTime", CSGenioAflds.FldTime, typeof(string)),
            new TableSearchColumn("ValYear", CSGenioAflds.FldYear, typeof(decimal?)),
            new TableSearchColumn("ValPrimviag", CSGenioAflds.FldPrimviag, typeof(bool)),
            new TableSearchColumn("ValConditio", CSGenioAflds.FldConditio, typeof(decimal)),
            new TableSearchColumn("ValClass", CSGenioAflds.FldClass, typeof(string), array : "CLASS"),
            new TableSearchColumn("ValClassnum", CSGenioAflds.FldClassnum, typeof(decimal), array : "CLASSNUM"),
            new TableSearchColumn("ValLogicenu", CSGenioAflds.FldLogicenu, typeof(int), array : "PRIMVIAG"),
            new TableSearchColumn("ValAttach", CSGenioAflds.FldAttach, typeof(string)),
            new TableSearchColumn("ValCreatuse", CSGenioAflds.FldCreatuse, typeof(string)),
            new TableSearchColumn("ValCreatdat", CSGenioAflds.FldCreatdat, typeof(DateTime?)),
            new TableSearchColumn("ValCreathou", CSGenioAflds.FldCreathou, typeof(string)),
            new TableSearchColumn("ValCreatins", CSGenioAflds.FldCreatins, typeof(DateTime?)),
            new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string)),
            new TableSearchColumn("ValTxtfield", CSGenioAflds.FldTxtfield, typeof(string)),
            new TableSearchColumn("ValEmailfld", CSGenioAflds.FldEmailfld, typeof(string)),
            new TableSearchColumn("ValZipfield", CSGenioAflds.FldZipfield, typeof(string)),
            new TableSearchColumn("ValIbanfiel", CSGenioAflds.FldIbanfiel, typeof(string)),
            new TableSearchColumn("ValSsnumber", CSGenioAflds.FldSsnumber, typeof(string)),
            new TableSearchColumn("ValLicplate", CSGenioAflds.FldLicplate, typeof(string)),
            new TableSearchColumn("ValVatnumbr", CSGenioAflds.FldVatnumbr, typeof(string)),
            new TableSearchColumn("ValBanknmbr", CSGenioAflds.FldBanknmbr, typeof(string)),
            new TableSearchColumn("ValUpprtext", CSGenioAflds.FldUpprtext, typeof(string)),
            new TableSearchColumn("ValPassfld", CSGenioAflds.FldPassfld, typeof(string)),
            new TableSearchColumn("ValClrpicke", CSGenioAflds.FldClrpicke, typeof(string)),
            new TableSearchColumn("ValShwrc", CSGenioAflds.FldShwrc, typeof(bool)),
            new TableSearchColumn("ValRadiob", CSGenioAflds.FldRadiob, typeof(string), array : "RADIOBTN")
        };

    }
}
