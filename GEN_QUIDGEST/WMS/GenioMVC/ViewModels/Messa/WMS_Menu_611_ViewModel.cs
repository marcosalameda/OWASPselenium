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

namespace GenioMVC.ViewModels.Messa
{
    public class WMS_Menu_611_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Messa> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "messa"; }

        /// <inheritdoc/>
        public override string Uuid { get => "c907abb5-c7f3-4623-8cf5-4701f233e6cb"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodmessa { get; set; }

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
            dbeditTitle = Resources.Resources.MESSAGES59316;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("messa", user, "WMS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAmessa.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAmessa.FldCodmessa, CSGenioAmessa.FldZzstate, CSGenioAmessa.FldIdnotif, CSGenioAmessa.FldIdmsg, CSGenioAmessa.FldDesignat, CSGenioAmessa.FldEmail, CSGenioAmessa.FldMessage, CSGenioAmessa.FldMailsent, CSGenioAmessa.FldMailerr, CSGenioAmessa.FldCreatope, CSGenioAmessa.FldCreatdat, CSGenioAmessa.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAmessa.FldCodperso, CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAmessa.FldDocum_nr };

            ListingMVC<CSGenioAmessa> listing = new ListingMVC<CSGenioAmessa>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WMS_Menu_611_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public WMS_Menu_611_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAmessa.FldIdnotif, FieldType.TEXTO, Resources.Resources.NOTIFICATION_ID25507, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldIdmsg, FieldType.TEXTO, Resources.Resources.MESSAGE_ID37133, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldDesignat, FieldType.TEXTO, Resources.Resources.TO_WHOM_THE_MESSAGE_02337, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldEmail, FieldType.TEXTO, Resources.Resources.E_MAIL_TO_WHOM_THE_M37668, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldMessage, FieldType.MEMO, Resources.Resources.MESSAGE30602, 30, 10, true),
                new Exports.QColumn(CSGenioAmessa.FldMailsent, FieldType.LOGICO, Resources.Resources.E_MAIL_SENT_60490, 1, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldMailerr, FieldType.TEXTO, Resources.Resources.ERROR_SENDING_MAIL44674, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldCreatope, FieldType.OPERCRIA, Resources.Resources.CREATED_BY12292, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldCreatdat, FieldType.DATACRIA, Resources.Resources.CREATED_ON00051, 8, 0, true),
                new Exports.QColumn(CSGenioAentit.FldName, FieldType.TEXTO, Resources.Resources.LEGAL_NAME42902, 30, 0, true),
                new Exports.QColumn(CSGenioAperso.FldName, FieldType.TEXTO, Resources.Resources.PERSON_NAME40980, 30, 0, true),
                new Exports.QColumn(CSGenioAmessa.FldDocum_nr, FieldType.NUMERO, Resources.Resources.DOCUMENT_NUMBER28451, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAmessa> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "messa" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Messa>();
			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_611_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("MESSA.IDNOTIF", new OrderedDictionary());
			allSortOrders["MESSA.IDNOTIF"].Add("MESSA.IDNOTIF", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "WMS_Menu_611_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Messa.AddEPH<CSGenioAmessa>(ref u, crs, "ML611");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAmessa.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("MESSA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAmessa.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_messa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_messa");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Messa.AddEPH<CSGenioAmessa>(ref u, null, "ML611"));
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
            ListingMVC<CSGenioAmessa> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAmessa> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "WMS_Menu_611", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "WMS_Menu_611"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "WMS_Menu_611");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Messa>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["WMS_Menu_611_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("MESSA.IDNOTIF", new OrderedDictionary());
			allSortOrders["MESSA.IDNOTIF"].Add("MESSA.IDNOTIF", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pWMS_Menu_611"])) ? int.Parse(requestValues["pWMS_Menu_611"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sWMS_Menu_611", "dWMS_Menu_611", requestValues, "messa", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAmessa.FldIdnotif), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAmessa.FldCodmessa, CSGenioAmessa.FldZzstate, CSGenioAmessa.FldIdnotif, CSGenioAmessa.FldIdmsg, CSGenioAmessa.FldDesignat, CSGenioAmessa.FldEmail, CSGenioAmessa.FldMessage, CSGenioAmessa.FldMailsent, CSGenioAmessa.FldMailerr, CSGenioAmessa.FldCreatope, CSGenioAmessa.FldCreatdat, CSGenioAmessa.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAmessa.FldCodperso, CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAmessa.FldDocum_nr };


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
					firstVisibleColumn = new FieldRef("messa", "idnotif");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAmessa model_limit_area = new CSGenioAmessa(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML611");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet wms_menu_611Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL WMS OVERRQ 611]/

            // This will happen in case there is an error
            if(wms_menu_611Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAmessa>(false, wms_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL WMS OVERRQLSTEXP 611]/

                conditions = wms_menu_611Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL WMS OVERRQLIST 611]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_messa");
				Navigation.DestroyEntry("QMVC_POS_RECORD_messa");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAmessa.GetInformation(), QMVC_POS_RECORD, sorts, wms_menu_611Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAmessa> listing = Models.ModelBase.Where<CSGenioAmessa>(false, wms_menu_611Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML611", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapWMS_Menu_611(listing);

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
		}

        private List<Models.Messa> MapWMS_Menu_611(ListingMVC<CSGenioAmessa> Qlisting)
        {
            var Elements = new List<Models.Messa>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapWMS_Menu_611(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAmessa row
        /// to a Models.Messa object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Messa MapWMS_Menu_611(CSGenioAmessa row)
        {
            var model = new Models.Messa(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "messa":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "entit":
                        model.Entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "perso":
                        model.Perso.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM WMS_MENU_611]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Messa", "Messa.ValCodmessa", "Messa.ValZzstate", "Messa.ValIdnotif", "Messa.ValIdmsg", "Messa.ValDesignat", "Messa.ValEmail", "Messa.ValMessage", "Messa.ValMailsent", "Messa.ValMailerr", "Messa.ValCreatope", "Messa.ValCreatdat", "Entit", "Entit.ValName", "Perso", "Perso.ValName", "Messa.ValDocum_nr", "Messa.ValCodentit", "Messa.ValCodperso"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValIdnotif", CSGenioAmessa.FldIdnotif, typeof(string), defaultSearch : true),
            new TableSearchColumn("ValIdmsg", CSGenioAmessa.FldIdmsg, typeof(string)),
            new TableSearchColumn("ValDesignat", CSGenioAmessa.FldDesignat, typeof(string)),
            new TableSearchColumn("ValEmail", CSGenioAmessa.FldEmail, typeof(string)),
            new TableSearchColumn("ValMessage", CSGenioAmessa.FldMessage, typeof(string)),
            new TableSearchColumn("ValMailsent", CSGenioAmessa.FldMailsent, typeof(bool)),
            new TableSearchColumn("ValMailerr", CSGenioAmessa.FldMailerr, typeof(string)),
            new TableSearchColumn("ValCreatope", CSGenioAmessa.FldCreatope, typeof(string)),
            new TableSearchColumn("ValCreatdat", CSGenioAmessa.FldCreatdat, typeof(DateTime?)),
            new TableSearchColumn("Entit_ValName", CSGenioAentit.FldName, typeof(string)),
            new TableSearchColumn("Perso_ValName", CSGenioAperso.FldName, typeof(string)),
            new TableSearchColumn("ValDocum_nr", CSGenioAmessa.FldDocum_nr, typeof(decimal?))
        };
    }
}
