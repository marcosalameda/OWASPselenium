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
    public class TBS_Menu_1921_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Flds> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "flds"; }

        /// <inheritdoc/>
        public override string Uuid { get => "ece7a4a3-4c81-42b8-99a3-ee5e82c2cf5b"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodflds { get; set; }

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
// USE /[MANUAL TBS LIST_LIMITS 1921]/

			return crs;
		}


        private string dbeditTitle;
        public string DBEditTitle { get { if (string.IsNullOrEmpty(dbeditTitle)) GetTitle(); return dbeditTitle; } }

        public void GetTitle()
        {
            dbeditTitle = Resources.Resources.LISTA_DE_CAMPOS37609;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("flds", user, "TBS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAflds.FldZzstate, 0); //valid zzstate only

            // Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCodaero, CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAflds.FldDescrip, CSGenioAflds.FldNpassage, CSGenioAflds.FldDuration, CSGenioAflds.FldPrice, CSGenioAflds.FldPrecobil, CSGenioAflds.FldDate, CSGenioAflds.FldDatetime, CSGenioAflds.FldDateseco, CSGenioAflds.FldTime, CSGenioAflds.FldYear, CSGenioAflds.FldPrimviag, CSGenioAflds.FldConditio, CSGenioAflds.FldClass, CSGenioAflds.FldClassnum, CSGenioAflds.FldLogicenu, CSGenioAflds.FldLogo, CSGenioAflds.FldAttach, CSGenioAflds.FldLogoexte, CSGenioAflds.FldCreatuse, CSGenioAflds.FldCreatdat, CSGenioAflds.FldCreathou, CSGenioAflds.FldCreatins, CSGenioAflds.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr };

            ListingMVC<CSGenioAflds> listing = new ListingMVC<CSGenioAflds>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TBS_Menu_1921_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public TBS_Menu_1921_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAaero.FldName, FieldType.TEXT, Resources.Resources.NOME_DA_COMPANHIA48638, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDescrip, FieldType.MEMO, Resources.Resources.DESCRICAO51618, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldNpassage, FieldType.NUMERIC, Resources.Resources.CAPACIDADE_DE_PASSEI42438, 3, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDuration, FieldType.NUMERIC, Resources.Resources.DURACAO_VIAGEM00021, 5, 2, true),
                new Exports.QColumn(CSGenioAflds.FldPrice, FieldType.CURRENCY, Resources.Resources.PRECO_DO_BILHETE_ARR20993, 6, 0, true),
                new Exports.QColumn(CSGenioAflds.FldPrecobil, FieldType.CURRENCY, Resources.Resources.PRECO_DO_BILHETE_AS_59630, 6, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDate, FieldType.DATE, Resources.Resources.DATA_DE_PARTIDA__DD_26044, 8, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDatetime, FieldType.DATETIME, Resources.Resources.DATA_DE_PARTIDA__HOR47484, 16, 0, true),
                new Exports.QColumn(CSGenioAflds.FldDateseco, FieldType.DATETIMESECONDS, Resources.Resources.DATA_DE_PARTIDA__SEG38575, 19, 0, true),
                new Exports.QColumn(CSGenioAflds.FldTime, FieldType.TIME_HOURS, Resources.Resources.HORA_DE_PARTIDA00929, 5, 0, true),
                new Exports.QColumn(CSGenioAflds.FldYear, FieldType.NUMERIC, Resources.Resources.ANO_DE_CRIACAO_DO_AE38604, 4, 0, true),
                new Exports.QColumn(CSGenioAflds.FldPrimviag, FieldType.LOGIC, Resources.Resources._1AVIAGEM08604, 1, 0, true),
                new Exports.QColumn(CSGenioAflds.FldConditio, FieldType.NUMERIC, Resources.Resources.JA_VIAJOU_ANTES_22497, 1, 0, true),
                new Exports.QColumn(CSGenioAflds.FldClass, FieldType.ARRAY_TEXT, Resources.Resources.CLASS__ENUMERACAO_DE17340, 2, 0, true, "CLASS"),
                new Exports.QColumn(CSGenioAflds.FldClassnum, FieldType.ARRAY_NUMERIC, Resources.Resources.CLASSE__ENUMERACAO_N29443, 1, 0, true, "CLASSNUM"),
                new Exports.QColumn(CSGenioAflds.FldLogicenu, FieldType.ARRAY_LOGIC, Resources.Resources._1A_VIAGEM__ENUMERACA14864, 1, 0, true, "PRIMVIAG"),
                !ajaxRequest ? new Exports.QColumn(CSGenioAflds.FldLogo, FieldType.IMAGE, Resources.Resources.LOGO62483, 3, 1, true):null,
                new Exports.QColumn(CSGenioAflds.FldAttach, FieldType.DOCUMENT, Resources.Resources.ANEXOS65235, 30, 0, true),
                new Exports.QColumn(CSGenioAflds.FldLogoexte, FieldType.PATH, Resources.Resources.LOGO__EXTERNAL_FILE_58162, 3, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreatuse, FieldType.TEXT, Resources.Resources.CRIADO_POR17895, 20, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreatdat, FieldType.DATETIMESECONDS, Resources.Resources.DATA_DE_CRIACAO__DD_33541, 8, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreathou, FieldType.TIME_HOURS, Resources.Resources.HORA_DE_CRIACAO40754, 5, 0, true),
                new Exports.QColumn(CSGenioAflds.FldCreatins, FieldType.DATETIMESECONDS, Resources.Resources.DATA_DE_CRIACAO_COMP31582, 15, 0, true),
                new Exports.QColumn(CSGenioAequip.FldRegistnr, FieldType.TEXT, Resources.Resources.NO__REGISTER04207, 6, 0, true),
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
			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_1921_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "TBS_Menu_1921_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Flds.AddEPH<CSGenioAflds>(ref u, crs, "ML1921");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAflds.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("FLDS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAflds.FldZzstate, CSGenioAflds.FldCreatuse);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Flds.AddEPH<CSGenioAflds>(ref u, null, "ML1921"));
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
				this.Navigation.SetValue("requestValues" + "TBS_Menu_1921", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "TBS_Menu_1921"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "TBS_Menu_1921");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Flds>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("FLDS.DURATION", new OrderedDictionary());
			allSortOrders["FLDS.DURATION"].Add("FLDS.DURATION", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pTBS_Menu_1921"])) ? int.Parse(requestValues["pTBS_Menu_1921"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sTBS_Menu_1921", "dTBS_Menu_1921", requestValues, "flds", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAflds.FldDuration), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAflds.FldCodflds, CSGenioAflds.FldZzstate, CSGenioAflds.FldCodaero, CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAflds.FldDescrip, CSGenioAflds.FldNpassage, CSGenioAflds.FldDuration, CSGenioAflds.FldPrice, CSGenioAflds.FldPrecobil, CSGenioAflds.FldDate, CSGenioAflds.FldDatetime, CSGenioAflds.FldDateseco, CSGenioAflds.FldTime, CSGenioAflds.FldYear, CSGenioAflds.FldPrimviag, CSGenioAflds.FldConditio, CSGenioAflds.FldClass, CSGenioAflds.FldClassnum, CSGenioAflds.FldLogicenu, CSGenioAflds.FldLogo, CSGenioAflds.FldAttach, CSGenioAflds.FldAttachfk, CSGenioAflds.FldLogoexte, CSGenioAflds.FldCreatuse, CSGenioAflds.FldCreatdat, CSGenioAflds.FldCreathou, CSGenioAflds.FldCreatins, CSGenioAflds.FldCodequip, CSGenioAequip.FldCodequip, CSGenioAequip.FldRegistnr };


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
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML1921");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet tbs_menu_1921Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TBS OVERRQ 1921]/

            // This will happen in case there is an error
            if(tbs_menu_1921Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAflds>(false, tbs_menu_1921Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1921", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TBS OVERRQLSTEXP 1921]/

                conditions = tbs_menu_1921Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL TBS OVERRQLIST 1921]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_flds");
				Navigation.DestroyEntry("QMVC_POS_RECORD_flds");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAflds.GetInformation(), QMVC_POS_RECORD, sorts, tbs_menu_1921Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAflds> listing = Models.ModelBase.Where<CSGenioAflds>(false, tbs_menu_1921Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML1921", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapTBS_Menu_1921(listing);

				Menu.Identifier = "ML1921";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML1921";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Flds> MapTBS_Menu_1921(ListingMVC<CSGenioAflds> Qlisting)
        {
            var Elements = new List<Models.Flds>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTBS_Menu_1921(row));
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
        private Models.Flds MapTBS_Menu_1921(CSGenioAflds row)
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBS_MENU_1921]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Flds", "Flds.ValCodflds", "Flds.ValZzstate", "Aero", "Aero.ValName", "Flds.ValDescrip", "Flds.ValNpassage", "Flds.ValDuration", "Flds.ValPrice", "Flds.ValPrecobil", "Flds.ValDate", "Flds.ValDatetime", "Flds.ValDateseco", "Flds.ValTime", "Flds.ValYear", "Flds.ValPrimviag", "Flds.ValConditio", "Flds.ValClass", "Flds.ValClassnum", "Flds.ValLogicenu", "Flds.ValLogo", "Flds.ValAttach", "Flds.ValLogoexte", "Flds.ValCreatuse", "Flds.ValCreatdat", "Flds.ValCreathou", "Flds.ValCreatins", "Equip", "Equip.ValRegistnr", "Flds.ValCodaero", "Flds.ValCodequip"
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
            new TableSearchColumn("Equip_ValRegistnr", CSGenioAequip.FldRegistnr, typeof(string))
        };

    }
}
