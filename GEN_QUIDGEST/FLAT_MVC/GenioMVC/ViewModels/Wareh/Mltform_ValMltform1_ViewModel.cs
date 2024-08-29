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

namespace GenioMVC.ViewModels.Wareh
{
    public class Mltform_ValMltform1_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.ViewModels.Wpess.Armapess_ViewModel> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "wpess"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Mltform_ValMltform1"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodwareh { get; set; }

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
        /// Initializes a new instance of the <see cref="Mltform_ValMltform1_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Mltform_ValMltform1_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodwareh = currentNavigation.CurrentLevel.GetEntry("wareh")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAwpess.FldName, FieldType.TEXTO, Resources.Resources.NAME31974, 30, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldNfunc, FieldType.NUMERO, Resources.Resources.EMPLOYEE_NUMBER50873, 1, 0, true),
                new Exports.QColumn(CSGenioAwpess.FldDate, FieldType.DATA, Resources.Resources.BIRTH_DATE00284, 8, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAwpess> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "wpess" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.ViewModels.Wpess.Armapess_ViewModel>();
			Menu.SetFilters(bool.Parse(requestValues["ValMltform1_tableFilters"] ?? "false"), false);


			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValMltform1_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodwareh != null)
				crs.Equal(CSGenioAwpess.FldCodwareh, this.ValCodwareh);





			if (isToExport)
			{
				// EPH
				crs = Models.Wpess.AddEPH<CSGenioAwpess>(ref u, crs, "IBL_MLTFORM_PSEUDMLTFORM1");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAwpess.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("WPESS", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAwpess.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
				Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Wpess.AddEPH<CSGenioAwpess>(ref u, null, "IBL_MLTFORM_PSEUDMLTFORM1"));
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
            ListingMVC<CSGenioAwpess> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAwpess> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Mltform_ValMltform1", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Mltform_ValMltform1"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Mltform_ValMltform1");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.ViewModels.Wpess.Armapess_ViewModel>();


			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["ValMltform1_tableFilters"] ?? "false"), false);

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValMltform1"])) ? int.Parse(requestValues["pValMltform1"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValMltform1", "dValMltform1", requestValues, "wpess", allSortOrders);


FieldRef[] fields = new FieldRef[] { CSGenioAwpess.FldCodpess, CSGenioAwpess.FldZzstate, CSGenioAwpess.FldNfunc, CSGenioAwpess.FldPfoto, CSGenioAwpess.FldName, CSGenioAwpess.FldDate, CSGenioAwpess.FldSex, CSGenioAwpess.FldNaturali, CSGenioAwpess.FldNacional, CSGenioAwpess.FldAdress, CSGenioAwpess.FldZipcode, CSGenioAwpess.FldCountry, CSGenioAwpess.FldEmail, CSGenioAwpess.FldCellphon, CSGenioAwpess.FldCodwareh, CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes };


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
					firstVisibleColumn = new FieldRef("wpess", "name");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAwpess model_limit_area = new CSGenioAwpess(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_MLTFORM_PSEUDMLTFORM1");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet mltform_pseudmltform1Conds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ MLTFORM_PSEUDMLTFORM1]/

            // This will happen in case there is an error
            if(mltform_pseudmltform1Conds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAwpess>(false, mltform_pseudmltform1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_MLTFORM_PSEUDMLTFORM1", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP MLTFORM_PSEUDMLTFORM1]/

                conditions = mltform_pseudmltform1Conds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST MLTFORM_PSEUDMLTFORM1]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_wpess");
				Navigation.DestroyEntry("QMVC_POS_RECORD_wpess");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAwpess.GetInformation(), QMVC_POS_RECORD, sorts, mltform_pseudmltform1Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAwpess> listing = Models.ModelBase.Where<CSGenioAwpess>(false, mltform_pseudmltform1Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_MLTFORM_PSEUDMLTFORM1", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				List<GenioMVC.ViewModels.Wpess.Armapess_ViewModel> tempList = new List<GenioMVC.ViewModels.Wpess.Armapess_ViewModel>();

				foreach (GenioMVC.Models.Wpess Wpess in listing.RowsForViewModel<GenioMVC.Models.Wpess>((r) => new GenioMVC.Models.Wpess(r, true))) {
                    //Clone by line to prevent history values propagating through lines on list
                    NavigationContext clonedNavigation = Navigation.Clone();
                    clonedNavigation.AddHistoryLevel(new NavigationLocation("", "Armapess_Show", "Wpess") { vueRouteName = "form-ARMAPESS", mode = "CANCEL" }, FormMode.Show);
                    tempList.Add(new GenioMVC.ViewModels.Wpess.Armapess_ViewModel(Wpess, Navigation));
                }

				this.Menu.Elements = tempList;

				Menu.Identifier = "IBL_MLTFORM_PSEUDMLTFORM1";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_MLTFORM_PSEUDMLTFORM1";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();
		}

        private List<Models.Wpess> MapMltform_ValMltform1(ListingMVC<CSGenioAwpess> Qlisting)
        {
            var Elements = new List<Models.Wpess>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapMltform_ValMltform1(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAwpess row
        /// to a Models.Wpess object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Wpess MapMltform_ValMltform1(CSGenioAwpess row)
        {
            var model = new Models.Wpess(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "wpess":
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

            return false;
        }


        #region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM MLTFORM_VALMLTFORM1]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Wpess", "Wpess.ValCodpess", "Wpess.ValZzstate", "Wpess.ValName", "Wpess.ValNfunc", "Wpess.ValDate", "Wpess.ValCodwareh"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValNfunc", CSGenioAwpess.FldNfunc, typeof(decimal?)),
            new TableSearchColumn("ValName", CSGenioAwpess.FldName, typeof(string)),
            new TableSearchColumn("ValDate", CSGenioAwpess.FldDate, typeof(DateTime?)),
            new TableSearchColumn("ValSex", CSGenioAwpess.FldSex, typeof(string)),
            new TableSearchColumn("ValNaturali", CSGenioAwpess.FldNaturali, typeof(string)),
            new TableSearchColumn("ValNacional", CSGenioAwpess.FldNacional, typeof(string)),
            new TableSearchColumn("ValAdress", CSGenioAwpess.FldAdress, typeof(string)),
            new TableSearchColumn("ValZipcode", CSGenioAwpess.FldZipcode, typeof(string)),
            new TableSearchColumn("ValCountry", CSGenioAwpess.FldCountry, typeof(string)),
            new TableSearchColumn("ValEmail", CSGenioAwpess.FldEmail, typeof(string)),
            new TableSearchColumn("ValCellphon", CSGenioAwpess.FldCellphon, typeof(decimal?)),
            new TableSearchColumn("ValWarehdes", CSGenioAwareh.FldWarehdes, typeof(string))
        };
    }
}
