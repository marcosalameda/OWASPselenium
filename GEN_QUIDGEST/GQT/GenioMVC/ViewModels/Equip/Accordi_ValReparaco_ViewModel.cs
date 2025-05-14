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

namespace GenioMVC.ViewModels.Equip
{
    public class Accordi_ValReparaco_ViewModel : ListViewModel
    {
        /// <summary>
        /// Gets or sets the object that represents the table and its elements.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Repar> Menu { get; set; }

        /// <inheritdoc/>
        public override string TableAlias { get => "repar"; }

        /// <inheritdoc/>
        public override string Uuid { get => "Accordi_ValReparaco"; }

        /// <inheritdoc/>
        protected override string[] FieldsToSerialize { get => _fieldsToSerialize; }

        /// <inheritdoc/>
        protected override List<TableSearchColumn> SearchableColumns { get => _searchableColumns; }

        /// <summary>
        /// The primary key field.
        /// </summary>
        public string ValCodequip { get; set; }

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
// USE /[MANUAL GQT LIST_LIMITS ACCORDI_PSEUDREPARACO]/

			return crs;
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="Accordi_ValReparaco_ViewModel" /> class.
        /// </summary>
        /// <param name="currentNavigation">The current navigation</param>
        public Accordi_ValReparaco_ViewModel(NavigationContext currentNavigation) : base(currentNavigation)
        {
            ValCodequip = currentNavigation.CurrentLevel.GetEntry("equip")?.ToString();
        }

        /// <inheritdoc/>
        public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
        {
            var columns = new List<Exports.QColumn>()
            {
                new Exports.QColumn(CSGenioArepar.FldNrrepara, FieldType.NUMERIC, Resources.Resources.NO_RUMOUR_IN_THE_COM15248, 10, 0, true),
                new Exports.QColumn(CSGenioArepar.FldDtrepara, FieldType.DATETIME, Resources.Resources.FIXED_IN00179, 16, 0, true),
                new Exports.QColumn(CSGenioAcate1.FldCategoria, FieldType.TEXT, Resources.Resources.SPECIALTY09304, 30, 0, true),
                new Exports.QColumn(CSGenioApesso.FldName, FieldType.TEXT, Resources.Resources.EXPERT27393, 30, 0, true),
                new Exports.QColumn(CSGenioArepar.FldDescript, FieldType.MEMO, Resources.Resources.DESCRIPTION_OF_THE_R26085, 30, 3, true),
                new Exports.QColumn(CSGenioArepar.FldHours, FieldType.NUMERIC, Resources.Resources.SPENT_ON_HOURS19285, 10, 0, true),
            };

            columns.RemoveAll(item => item == null);
            return columns;
        }

        public void LoadToExport(out ListingMVC<CSGenioArepar> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
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
                    string areabase = column.ValTabela.ToLower() != "repar" ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(column.ValTabela) + "." : "";
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
				Menu = new TablePartial<GenioMVC.Models.Repar>();
			Menu.SetFilters(bool.Parse(requestValues["ValReparaco_tableFilters"] ?? "false"), false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(true), requestValues, "ValReparaco_"));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			crs.SubSets.Add(subfilters);

			if(this.ValCodequip != null)
				crs.Equal(CSGenioArepar.FldCodequip, this.ValCodequip);




			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));


			if (isToExport)
			{
				// EPH
				crs = Models.Repar.AddEPH<CSGenioArepar>(ref u, crs, "IBL_ACCORDI_PSEUDREPARACO");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioArepar.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("REPAR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioArepar.FldZzstate, null);

			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Repar.AddEPH<CSGenioArepar>(ref u, null, "IBL_ACCORDI_PSEUDREPARACO"));
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
            ListingMVC<CSGenioArepar> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioArepar> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saímos de um form e voltamos ao dbedit e mudamos de página.
			//como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Accordi_ValReparaco", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Accordi_ValReparaco"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Accordi_ValReparaco");

			User u = UserContext.Current.User;
			Menu = new TablePartial<GenioMVC.Models.Repar>();


			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("REPAR.NRREPARA", new OrderedDictionary());
			allSortOrders["REPAR.NRREPARA"].Add("REPAR.NRREPARA", "A");




			var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pValReparaco"])) ? int.Parse(requestValues["pValReparaco"]) : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, "sValReparaco", "dValReparaco", requestValues, "repar", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArepar.FldNrrepara), SortOrder.Ascending));

			}

FieldRef[] fields = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldCodcateg, CSGenioAcate1.FldCodcateg, CSGenioAcate1.FldCategoria, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldDescript, CSGenioArepar.FldHours };


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
					firstVisibleColumn = new FieldRef("repar", "nrrepara");


			// Limitations
			if (this.tableLimits == null)
				this.tableLimits = new List<Limit>();
			//Comparer to check if limit is already present in tableLimits
			LimitComparer limitComparer = new LimitComparer();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioArepar model_limit_area = new CSGenioArepar(UserContext.Current.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "IBL_ACCORDI_PSEUDREPARACO");
				if (area_EPH_limits.Count > 0)
					this.tableLimits.AddRange(area_EPH_limits);
			}


			CriteriaSet accordi_pseudreparacoConds = BuildCriteriaSet(requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
            tableReload &= hasAllRequiredLimits;

// USE /[MANUAL GQT OVERRQ ACCORDI_PSEUDREPARACO]/

            // This will happen in case there is an error
            if(accordi_pseudreparacoConds == null)
                return;

			if (isToExport)
			{
                if(!tableReload)
					return;

				Qlisting = Models.ModelBase.Where<CSGenioArepar>(false, accordi_pseudreparacoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ACCORDI_PSEUDREPARACO", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL GQT OVERRQLSTEXP ACCORDI_PSEUDREPARACO]/

                conditions = accordi_pseudreparacoConds;
                return;
			}



			if (tableReload)
			{
// USE /[MANUAL GQT OVERRQLIST ACCORDI_PSEUDREPARACO]/


				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_repar");
				Navigation.DestroyEntry("QMVC_POS_RECORD_repar");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioArepar.GetInformation(), QMVC_POS_RECORD, sorts, accordi_pseudreparacoConds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
					{
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
						Menu.FocusOnRecord = QMVC_POS_RECORD;
					}
				}

				ListingMVC<CSGenioArepar> listing = Models.ModelBase.Where<CSGenioArepar>(false, accordi_pseudreparacoConds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_ACCORDI_PSEUDREPARACO", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;


				Menu.Elements = MapAccordi_ValReparaco(listing);

				Menu.Identifier = "IBL_ACCORDI_PSEUDREPARACO";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "IBL_ACCORDI_PSEUDREPARACO";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}

			//Set table limits display property
			FillTableLimitsDisplayData();

            SanitizeContent();
		}

        private List<Models.Repar> MapAccordi_ValReparaco(ListingMVC<CSGenioArepar> Qlisting)
        {
            var Elements = new List<Models.Repar>();
            int i = 0;

            if (Qlisting.Rows != null)
            {
                foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapAccordi_ValReparaco(row));
					i++;
				}
            }

            return Elements;
        }

        /// <summary>
        /// Maps a single CSGenioArepar row
        /// to a Models.Repar object.
        /// </summary>
        /// <param name="row">The row.</param>
        private Models.Repar MapAccordi_ValReparaco(CSGenioArepar row)
        {
            var model = new Models.Repar(true, _fieldsToSerialize);
            if (row == null)
                return model;

            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "repar":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "cate1":
                        model.Cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    case "pesso":
                        model.Pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ACCORDI_VALREPARACO]/
        #endregion

        private static readonly string[] _fieldsToSerialize =
        {
            "Repar", "Repar.ValCodrepar", "Repar.ValZzstate", "Repar.ValNrrepara", "Repar.ValDtrepara", "Cate1", "Cate1.ValCategoria", "Pesso", "Pesso.ValName", "Repar.ValDescript", "Repar.ValHours", "Repar.ValCodcateg", "Repar.ValCodempre", "Repar.ValCodequip", "Repar.ValCodpesso", "Repar.ValCodespec"
        };

        private static readonly List<TableSearchColumn> _searchableColumns = new List<TableSearchColumn>
        {
            new TableSearchColumn("ValNrrepara", CSGenioArepar.FldNrrepara, typeof(decimal?)),
            new TableSearchColumn("ValDtrepara", CSGenioArepar.FldDtrepara, typeof(DateTime?)),
            new TableSearchColumn("Cate1_ValCategoria", CSGenioAcate1.FldCategoria, typeof(string)),
            new TableSearchColumn("Pesso_ValName", CSGenioApesso.FldName, typeof(string)),
            new TableSearchColumn("ValDescript", CSGenioArepar.FldDescript, typeof(string)),
            new TableSearchColumn("ValHours", CSGenioArepar.FldHours, typeof(decimal?))
        };

    }
}
