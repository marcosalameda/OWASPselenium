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

namespace GenioMVC.ViewModels.Conta
{
    public class TBS_Menu_141_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Conta> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "conta"; }

        /// <inheritdoc/>
        public override string Uuid { get => "c97df91f-65ee-4b77-9b9a-cec4db5ebdb9"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodconta { get; set; }

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
            dbeditTitle = Resources.Resources.CONTACTS55742;
        }

        public int GetCount(User user)
        {
            CSGenio.persistence.PersistentSupport sp = UserContext.Current.PersistentSupport;
            var areaBase = CSGenio.business.Area.createArea("conta", user, "TBS");

            //gets eph conditions to be applied in listing
            CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, this.Identifier);
            conditions.Equal(CSGenioAconta.FldZzstate, 0); //valid zzstate only

            //Menu fixed limits and relations:

            


            // Checks for foreign tables in fields and conditions
FieldRef[] fields = new FieldRef[] { CSGenioAconta.FldCodconta, CSGenioAconta.FldZzstate, CSGenioAconta.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioAconta.FldCodtpcon, CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldTipocont, CSGenioAconta.FldContacto };

            ListingMVC<CSGenioAconta> listing = new ListingMVC<CSGenioAconta>(fields, null, 1, 1, false, user, true, string.Empty, false);
            SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

            //Menu relations:
            if (qs.FromTable == null)
                qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);


            //operation: Count menu records
            return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TBS_Menu_141_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public TBS_Menu_141_ViewModel(NavigationContext currentNavigation)
            : base(currentNavigation)
        {
            this.RoleToShow = CSGenio.framework.Role.ROLE_1;
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
                new Exports.QColumn(CSGenioAtpcon.FldTipocont, FieldType.TEXTO, Resources.Resources.TYPE00312, 30, 0, true),
                new Exports.QColumn(CSGenioAconta.FldContacto, FieldType.TEXTO, Resources.Resources.CONTACT59247, 30, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAconta> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "conta" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Conta>();
			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_141_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("CONTA.CONTACTO", new OrderedDictionary());
					allSortOrders["CONTA.CONTACTO"].Add("CONTA.CONTACTO", "A");


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "TBS_Menu_141_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			if (isToExport)
			{
				// EPH
				crs = Models.Conta.AddEPH<CSGenioAconta>(ref u, crs, "ML141");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAconta.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CONTA", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAconta.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_conta");
				Navigation.DestroyEntry("QMVC_POS_RECORD_conta");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Conta.AddEPH<CSGenioAconta>(ref u, null, "ML141"));
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
            ListingMVC<CSGenioAconta> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAconta> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "TBS_Menu_141", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "TBS_Menu_141"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "TBS_Menu_141");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Conta>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["TBS_Menu_141_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("CONTA.CONTACTO", new OrderedDictionary());
					allSortOrders["CONTA.CONTACTO"].Add("CONTA.CONTACTO", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pTBS_Menu_141"])) ? int.Parse(requestValues["pTBS_Menu_141"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sTBS_Menu_141", "dTBS_Menu_141", requestValues, "conta", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAconta.FldContacto), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAconta.FldCodconta, CSGenioAconta.FldZzstate, CSGenioAconta.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioAconta.FldCodtpcon, CSGenioAtpcon.FldCodtpcon, CSGenioAtpcon.FldTipocont, CSGenioAconta.FldContacto };


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
				CSGenioAconta model_limit_area = new CSGenioAconta(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML141");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet tbs_menu_141Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;
			
// USE /[MANUAL TBS OVERRQ 141]/

            // This will happen in case there is an error
            if(tbs_menu_141Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAconta>(false, tbs_menu_141Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML141", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TBS OVERRQLSTEXP 141]/

                return;
			}



			if (tableReload)
			{
// USE /[MANUAL TBS OVERRQLIST 141]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_conta");
				Navigation.DestroyEntry("QMVC_POS_RECORD_conta");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAconta.GetInformation(), QMVC_POS_RECORD, sorts, tbs_menu_141Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAconta> listing = Models.ModelBase.Where<CSGenioAconta>(false, tbs_menu_141Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML141", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;
	

				Menu.Elements = MapTBS_Menu_141(listing);

				Menu.Identifier = "ML141";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML141";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Conta> MapTBS_Menu_141(ListingMVC<CSGenioAconta> Qlisting)
        {
            var Elements = new List<Models.Conta>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTBS_Menu_141(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAconta row
        /// to a Models.Conta object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Conta MapTBS_Menu_141(CSGenioAconta row)
        {
            var model = new Models.Conta(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "conta":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pesso":
                        model.Pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "tpcon":
                        model.Tpcon.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TBS_MENU_141]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Conta", "Conta.ValCodconta", "Conta.ValZzstate", "Pesso", "Pesso.ValName", "Tpcon", "Tpcon.ValTipocont", "Conta.ValContacto", "Conta.ValCodgenre", "Conta.ValCodpesso", "Conta.ValCodtpcon"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("Pesso_ValName", CSGenioApesso.FldName, typeof(string)),
            new TableSearchColumn("Tpcon_ValTipocont", CSGenioAtpcon.FldTipocont, typeof(string)),
            new TableSearchColumn("ValContacto", CSGenioAconta.FldContacto, typeof(string), defaultSearch : true)
        };
    }
}
