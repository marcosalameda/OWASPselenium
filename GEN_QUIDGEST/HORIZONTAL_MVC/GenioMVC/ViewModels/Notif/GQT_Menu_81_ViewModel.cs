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

namespace GenioMVC.ViewModels.Notif
{
    public class GQT_Menu_81_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Notif> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "notif"; }

        /// <inheritdoc/>
        public override string Uuid { get => "8a24817a-f3db-4158-821e-86bf9df25ea0"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodnotif { get; set; }

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
            dbeditTitle = Resources.Resources.NOTIFICATIONS08466;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("notif", user, "GQT");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAnotif.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAnotif.FldCodnotif, CSGenioAnotif.FldZzstate, CSGenioAnotif.FldNrcomoda, CSGenioAnotif.FldBegin, CSGenioAnotif.FldEnd, CSGenioAnotif.FldEmail, CSGenioAnotif.FldIdnotif, CSGenioAnotif.FldIdmsg, CSGenioAnotif.FldMessage, CSGenioAnotif.FldMailerr, CSGenioAnotif.FldDesignat, CSGenioAnotif.FldCreatdat, CSGenioAnotif.FldCreatope, CSGenioAnotif.FldReturned, CSGenioAnotif.FldDtdevolu, CSGenioAnotif.FldCodpesso, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName };

            ListingMVC<CSGenioAnotif> listing = new ListingMVC<CSGenioAnotif>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GQT_Menu_81_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public GQT_Menu_81_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAnotif.FldNrcomoda, FieldType.NUMERO, Resources.Resources.NO__OF_THE_DADATO35934, 6, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldBegin, FieldType.DATAHORA, Resources.Resources.BEGINNING18124, 16, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldEnd, FieldType.DATAHORA, Resources.Resources.END47577, 16, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldEmail, FieldType.TEXTO, Resources.Resources.RECIPIENT_S_EMAIL43894, 30, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldIdnotif, FieldType.TEXTO, Resources.Resources.NOTIFICATION_ID_THAT61751, 30, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldIdmsg, FieldType.TEXTO, Resources.Resources.MESSAGE_ID37133, 30, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldMessage, FieldType.MEMO, Resources.Resources.TEXT_OF_THE_SENT_MES52307, 30, 15, true),
                new Exports.QColumn(CSGenioAnotif.FldMailerr, FieldType.TEXTO, Resources.Resources.ERROR_SENDING_EMAIL53846, 30, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldDesignat, FieldType.TEXTO, Resources.Resources.RECIPIENT65165, 30, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldCreatdat, FieldType.DATACRIA, Resources.Resources.CREATION__DATE13180, 8, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldCreatope, FieldType.OPERCRIA, Resources.Resources.CREATION__OPERATOR50535, 20, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldReturned, FieldType.LOGICO, Resources.Resources.RETURNED01606, 1, 0, true),
                new Exports.QColumn(CSGenioAnotif.FldDtdevolu, FieldType.DATA, Resources.Resources.RETURN32222, 8, 0, true),
                new Exports.QColumn(CSGenioApess2.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAnotif> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "notif" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Notif>();
			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_81_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("NOTIF.BEGIN", new OrderedDictionary());
			allSortOrders["NOTIF.BEGIN"].Add("NOTIF.BEGIN", "A");
			allSortOrders.Add("NOTIF.END", new OrderedDictionary());
			allSortOrders["NOTIF.END"].Add("NOTIF.END", "A");
			allSortOrders.Add("NOTIF.EMAIL", new OrderedDictionary());
			allSortOrders["NOTIF.EMAIL"].Add("NOTIF.EMAIL", "A");
			allSortOrders.Add("NOTIF.IDNOTIF", new OrderedDictionary());
			allSortOrders["NOTIF.IDNOTIF"].Add("NOTIF.IDNOTIF", "A");
			allSortOrders.Add("NOTIF.IDMSG", new OrderedDictionary());
			allSortOrders["NOTIF.IDMSG"].Add("NOTIF.IDMSG", "A");
			allSortOrders.Add("NOTIF.MAILERR", new OrderedDictionary());
			allSortOrders["NOTIF.MAILERR"].Add("NOTIF.MAILERR", "A");
			allSortOrders.Add("NOTIF.DESIGNAT", new OrderedDictionary());
			allSortOrders["NOTIF.DESIGNAT"].Add("NOTIF.DESIGNAT", "A");
			allSortOrders.Add("NOTIF.CREATDAT", new OrderedDictionary());
			allSortOrders["NOTIF.CREATDAT"].Add("NOTIF.CREATDAT", "A");
			allSortOrders.Add("NOTIF.CREATOPE", new OrderedDictionary());
			allSortOrders["NOTIF.CREATOPE"].Add("NOTIF.CREATOPE", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "GQT_Menu_81_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Notif.AddEPH<CSGenioAnotif>(ref u, crs, "ML81");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAnotif.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("NOTIF", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAnotif.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_notif");
				Navigation.DestroyEntry("QMVC_POS_RECORD_notif");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Notif.AddEPH<CSGenioAnotif>(ref u, null, "ML81"));
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
            ListingMVC<CSGenioAnotif> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAnotif> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "GQT_Menu_81", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "GQT_Menu_81"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_81");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Notif>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["GQT_Menu_81_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("NOTIF.BEGIN", new OrderedDictionary());
			allSortOrders["NOTIF.BEGIN"].Add("NOTIF.BEGIN", "A");
			allSortOrders.Add("NOTIF.END", new OrderedDictionary());
			allSortOrders["NOTIF.END"].Add("NOTIF.END", "A");
			allSortOrders.Add("NOTIF.EMAIL", new OrderedDictionary());
			allSortOrders["NOTIF.EMAIL"].Add("NOTIF.EMAIL", "A");
			allSortOrders.Add("NOTIF.IDNOTIF", new OrderedDictionary());
			allSortOrders["NOTIF.IDNOTIF"].Add("NOTIF.IDNOTIF", "A");
			allSortOrders.Add("NOTIF.IDMSG", new OrderedDictionary());
			allSortOrders["NOTIF.IDMSG"].Add("NOTIF.IDMSG", "A");
			allSortOrders.Add("NOTIF.MAILERR", new OrderedDictionary());
			allSortOrders["NOTIF.MAILERR"].Add("NOTIF.MAILERR", "A");
			allSortOrders.Add("NOTIF.DESIGNAT", new OrderedDictionary());
			allSortOrders["NOTIF.DESIGNAT"].Add("NOTIF.DESIGNAT", "A");
			allSortOrders.Add("NOTIF.CREATDAT", new OrderedDictionary());
			allSortOrders["NOTIF.CREATDAT"].Add("NOTIF.CREATDAT", "A");
			allSortOrders.Add("NOTIF.CREATOPE", new OrderedDictionary());
			allSortOrders["NOTIF.CREATOPE"].Add("NOTIF.CREATOPE", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pGQT_Menu_81"])) ? int.Parse(requestValues["pGQT_Menu_81"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sGQT_Menu_81", "dGQT_Menu_81", requestValues, "notif", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldBegin), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldEnd), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldEmail), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldIdnotif), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldIdmsg), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldMailerr), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldDesignat), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldCreatdat), SortOrder.Ascending));
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAnotif.FldCreatope), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAnotif.FldCodnotif, CSGenioAnotif.FldZzstate, CSGenioAnotif.FldNrcomoda, CSGenioAnotif.FldBegin, CSGenioAnotif.FldEnd, CSGenioAnotif.FldEmail, CSGenioAnotif.FldIdnotif, CSGenioAnotif.FldIdmsg, CSGenioAnotif.FldMessage, CSGenioAnotif.FldMailerr, CSGenioAnotif.FldDesignat, CSGenioAnotif.FldCreatdat, CSGenioAnotif.FldCreatope, CSGenioAnotif.FldReturned, CSGenioAnotif.FldDtdevolu, CSGenioAnotif.FldCodpesso, CSGenioApess2.FldCodpesso, CSGenioApess2.FldName };


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
					firstVisibleColumn = new FieldRef("notif", "nrcomoda");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAnotif model_limit_area = new CSGenioAnotif(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML81");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet gqt_menu_81Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ 81]/

            // This will happen in case there is an error
            if(gqt_menu_81Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAnotif>(false, gqt_menu_81Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML81", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP 81]/

                conditions = gqt_menu_81Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST 81]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_notif");
				Navigation.DestroyEntry("QMVC_POS_RECORD_notif");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAnotif.GetInformation(), QMVC_POS_RECORD, sorts, gqt_menu_81Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAnotif> listing = Models.ModelBase.Where<CSGenioAnotif>(false, gqt_menu_81Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML81", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapGQT_Menu_81(listing);

				Menu.Identifier = "ML81";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML81";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Notif> MapGQT_Menu_81(ListingMVC<CSGenioAnotif> Qlisting)
        {
            var Elements = new List<Models.Notif>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapGQT_Menu_81(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAnotif row
        /// to a Models.Notif object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Notif MapGQT_Menu_81(CSGenioAnotif row)
        {
            var model = new Models.Notif(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "notif":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pess2":
                        model.Pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GQT_MENU_81]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Notif", "Notif.ValCodnotif", "Notif.ValZzstate", "Notif.ValNrcomoda", "Notif.ValBegin", "Notif.ValEnd", "Notif.ValEmail", "Notif.ValIdnotif", "Notif.ValIdmsg", "Notif.ValMessage", "Notif.ValMailerr", "Notif.ValDesignat", "Notif.ValCreatdat", "Notif.ValCreatope", "Notif.ValReturned", "Notif.ValDtdevolu", "Pess2", "Pess2.ValName", "Notif.ValCodpesso"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValNrcomoda", CSGenioAnotif.FldNrcomoda, typeof(decimal?), defaultSearch : true),
            new TableSearchColumn("ValBegin", CSGenioAnotif.FldBegin, typeof(DateTime?)),
            new TableSearchColumn("ValEnd", CSGenioAnotif.FldEnd, typeof(DateTime?)),
            new TableSearchColumn("ValEmail", CSGenioAnotif.FldEmail, typeof(string)),
            new TableSearchColumn("ValIdnotif", CSGenioAnotif.FldIdnotif, typeof(string)),
            new TableSearchColumn("ValIdmsg", CSGenioAnotif.FldIdmsg, typeof(string)),
            new TableSearchColumn("ValMessage", CSGenioAnotif.FldMessage, typeof(string)),
            new TableSearchColumn("ValMailerr", CSGenioAnotif.FldMailerr, typeof(string)),
            new TableSearchColumn("ValDesignat", CSGenioAnotif.FldDesignat, typeof(string)),
            new TableSearchColumn("ValCreatdat", CSGenioAnotif.FldCreatdat, typeof(DateTime?)),
            new TableSearchColumn("ValCreatope", CSGenioAnotif.FldCreatope, typeof(string)),
            new TableSearchColumn("ValReturned", CSGenioAnotif.FldReturned, typeof(bool)),
            new TableSearchColumn("ValDtdevolu", CSGenioAnotif.FldDtdevolu, typeof(DateTime?)),
            new TableSearchColumn("Pess2_ValName", CSGenioApess2.FldName, typeof(string))
        };

    }
}
