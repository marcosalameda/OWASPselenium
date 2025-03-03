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

namespace GenioMVC.ViewModels.Pesso
{
    public class Pesso1_CmpnyValDesignat_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Cmpny> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "cmpny"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Pesso1_CmpnyValDesignat"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodpesso { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS PESSO1_CMPNYDESIGNAT]/

			return crs;
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="Pesso1_CmpnyValDesignat_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Pesso1_CmpnyValDesignat_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodpesso = currentNavigation.CurrentLevel.GetEntry("pesso")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioAcmpny.FldDesignat, FieldType.TEXTO, Resources.Resources.DESIGNATION35876, 85, 0, true),
                new Exports.QColumn(CSGenioAcmpny.FldAcronym, FieldType.TEXTO, Resources.Resources.ACRONYM00872, 15, 0, true),
                new Exports.QColumn(CSGenioAcmpny.FldNif, FieldType.TEXTO, Resources.Resources.TAX_IDENTIFICATION51190, 15, 0, true),
                new Exports.QColumn(CSGenioAcmpny.FldTelephon, FieldType.TEXTO, Resources.Resources.PHONE56703, 20, 0, true),
                new Exports.QColumn(CSGenioAcmpny.FldEmail, FieldType.TEXTO, Resources.Resources.EMAIL25170, 30, 0, true),
                !ajaxRequest ? new Exports.QColumn(CSGenioAcmpny.FldLogo, FieldType.IMAGEM_JPEG, Resources.Resources.LOGO62483, 3, 1, true):null,
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioAcmpny> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "cmpny" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Cmpny>();
			Menu.SetFilters(bool.Parse(requestValues["Pesso1_CmpnyValDesignat_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "Pesso1_CmpnyValDesignat_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);





			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Cmpny.AddEPH<CSGenioAcmpny>(ref u, crs, "IBL_PESSO1__CMPNYDESIGNAT");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcmpny.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			crs.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

			if (tableReload)
			{
				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_cmpny"];
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Cmpny.AddEPH<CSGenioAcmpny>(ref u, null, "IBL_PESSO1__CMPNYDESIGNAT"));
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
            ListingMVC<CSGenioAcmpny> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcmpny> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Pesso1_CmpnyValDesignat", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Pesso1_CmpnyValDesignat"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Pesso1_CmpnyValDesignat");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Cmpny>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("CMPNY.DESIGNAT", new OrderedDictionary());
			allSortOrders["CMPNY.DESIGNAT"].Add("CMPNY.DESIGNAT", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pPesso1_CmpnyValDesignat"])) ? int.Parse(requestValues["pPesso1_CmpnyValDesignat"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sPesso1_CmpnyValDesignat", "dPesso1_CmpnyValDesignat", requestValues, "cmpny", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldDesignat), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldZzstate, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldAcronym, CSGenioAcmpny.FldNif, CSGenioAcmpny.FldTelephon, CSGenioAcmpny.FldEmail, CSGenioAcmpny.FldLogo };


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
					firstVisibleColumn = new FieldRef("cmpny", "designat");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAcmpny model_limit_area = new CSGenioAcmpny(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_PESSO1__CMPNYDESIGNAT");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet pesso1__cmpnydesignatConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ PESSO1_CMPNYDESIGNAT]/

            // This will happen in case there is an error
            if(pesso1__cmpnydesignatConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioAcmpny>(false, pesso1__cmpnydesignatConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PESSO1__CMPNYDESIGNAT", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP PESSO1_CMPNYDESIGNAT]/

                conditions = pesso1__cmpnydesignatConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST PESSO1_CMPNYDESIGNAT]/


				string QMVC_POS_RECORD = requestValues["Q_POS_RECORD_cmpny"];
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAcmpny.GetInformation(), QMVC_POS_RECORD, sorts, pesso1__cmpnydesignatConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(false, pesso1__cmpnydesignatConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_PESSO1__CMPNYDESIGNAT", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapPesso1_CmpnyValDesignat(listing);

				Menu.Identifier = "IBL_PESSO1__CMPNYDESIGNAT";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_PESSO1__CMPNYDESIGNAT";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Cmpny> MapPesso1_CmpnyValDesignat(ListingMVC<CSGenioAcmpny> Qlisting)
        {
            var Elements = new List<Models.Cmpny>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapPesso1_CmpnyValDesignat(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioAcmpny row
        /// to a Models.Cmpny object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Cmpny MapPesso1_CmpnyValDesignat(CSGenioAcmpny row)
        {
            var model = new Models.Cmpny(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "cmpny":
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PESSO1_CMPNYVALDESIGNAT]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat", "Cmpny.ValAcronym", "Cmpny.ValNif", "Cmpny.ValTelephon", "Cmpny.ValEmail", "Cmpny.ValLogo", "Cmpny.ValCodcntry"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValDesignat", CSGenioAcmpny.FldDesignat, typeof(string)),
            new TableSearchColumn("ValAcronym", CSGenioAcmpny.FldAcronym, typeof(string)),
            new TableSearchColumn("ValNif", CSGenioAcmpny.FldNif, typeof(string)),
            new TableSearchColumn("ValTelephon", CSGenioAcmpny.FldTelephon, typeof(string)),
            new TableSearchColumn("ValEmail", CSGenioAcmpny.FldEmail, typeof(string))
        };

    }
}
