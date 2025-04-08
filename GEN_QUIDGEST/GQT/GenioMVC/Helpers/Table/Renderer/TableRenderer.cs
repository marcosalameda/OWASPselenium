using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Scripts;
using GenioMVC.Helpers.Table.Utils;
using GenioMVC.Helpers.Table.Properties;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class TableRenderer<TModel> where TModel : class
    {
        internal Table<TModel> Builder { get; set; }
        public ColumnRenderer<TModel> ColumnRenderer { get; protected set; }
        public PagerRenderer<TModel> PagerRenderer { get; protected set; }
        public TableScripts Scripts { get; protected set; }
        public String buttonSize { get; protected set; }

        public String pageInput { get; protected set; }
        public String sortInput { get; protected set; }
        public String sortDirInput { get; protected set; }

        public TableRenderer (Table<TModel> builder)
        {
            this.Builder = builder;

            this.ColumnRenderer = new ColumnRenderer<TModel>(this);
            this.PagerRenderer = new PagerRenderer<TModel>(this);
            this.Scripts = new TableScripts();

            this.buttonSize = "";

            this.pageInput = this.Builder.Pager.qsPageNumber + this.Builder.TableId;
            this.sortInput = this.Builder.Sorter.qsSortColumn + this.Builder.TableId;
            this.sortDirInput = this.Builder.Sorter.qsSortDirection + this.Builder.TableId;
        }

        /// <summary>
        /// Convert the TableBuilder to HTML.
        /// </summary>
        public virtual MvcHtmlString ToHtml(bool hidden = false)
        {
            TagBuilder tableContainer = new TagBuilder("div");
            tableContainer.AddCssClass("table-responsive");
            tableContainer.Attributes.Add("elem-identifier", "table-responsive-container");
			//Added to avoid vertical scrolling when 0 or 1 results are found in advanced search.

            if (hidden)
                tableContainer.Attributes.Add("style", "overflow-y: hidden; display: none;");
            else
                tableContainer.Attributes.Add("style", "overflow-y: hidden;");

            TagBuilder table = new TagBuilder("table");

			//Accessibility fix
			table.Attributes.Add("role", "grid");

            table.AddCssClass("c-table table-resizable");
            table.AddCssClass(String.Join(" ", this.Builder.TableCssClass));

            if (string.IsNullOrEmpty(Builder.TableId))
            {
                table.GenerateId("table");
                Builder.SetId(table.Attributes["id"]);
            }
            else
            {
                table.Attributes.Add("id", Builder.TableId);
            }

			if ((this.Builder.TableType == Properties.TableType.GridTableList && (this.Builder as GridTableList<TModel>).IsInEditMode))
                table.Attributes.Add("style", "width: auto;");

            if (Builder.Data.Any())
            {
                //table.AddCssClass("c-table--bordered");
                //table.AddCssClass("c-table--sm");
                //table.AddCssClass("c-table--striped");

                if (this.Builder.TableType == Properties.TableType.SearchList)
                    table.AddCssClass("search-list");

                if (!string.IsNullOrEmpty(this.Builder.FocusOnRecord))
                    table.Attributes.Add("data-focus-record", this.Builder.FocusOnRecord);

                table.InnerHtml += Header();
                table.InnerHtml += Body();
                //table.InnerHtml += Footer();//Footer moved outside of table
            }
            else
            {
				if (!(this.Builder.TableType == Properties.TableType.GridTableList && (this.Builder as GridTableList<TModel>).IsInEditMode))
					table.Attributes.Add("style", "width:100%");
                table.InnerHtml += EmptyList();
            }

            GetHtmlAttributes().ToList().ForEach(p=> {if(!table.Attributes.ContainsKey(p.Key)) table.Attributes.Add(p.Key, p.Value);});

            TagBuilder divHiddenFields = new TagBuilder("div");
            divHiddenFields.MergeAttribute("id", Builder.TableId + "_inputs");
            divHiddenFields.InnerHtml = GenerateHiddenFields().ToHtmlString();

            if (this.Builder.multipleSelection)
                table.Attributes.Add("data-multiple-selection", "true");
            if(this.Builder.HasFollowUpAction())
                table.Attributes.Add("data-has-follow-up-action", "true");

            tableContainer.InnerHtml += table;

            string html = tableContainer.ToString() + divHiddenFields.ToString();
            if (!hidden)
            {
                //Footer put after end of table
                html += Footer().ToString();
            }
            return new MvcHtmlString(html + "<script>" + GenerateScripts().ToHtmlString() + "</script>");
        }

        private void ProcessColumnProperties(ITableColumnInternal<TModel> tc)
        {
            int tableSize = TableUtils.CalculateTableSize<TModel>(Builder.TableColumns);
            string cellWidth = ColumnUtils.CalculateColumnWidth(tc.ColumnSize, tableSize);

            if ((this.Builder.TableType == Properties.TableType.GridTableList && !(this.Builder as GridTableList<TModel>).IsInEditMode) &&
                this.Builder.TableType != Properties.TableType.CheckList)
            {
                tc.AddInlineStyle("width", cellWidth + "%", true);
            }
        }

        protected virtual TagBuilder Header()
        {
            TagBuilder tHead = new TagBuilder("thead");
            tHead.AddCssClass("c-table__head");
            TagBuilder trHead = new TagBuilder("tr");


			//Accessibility fix
			trHead.Attributes.Add("role", "row");
			trHead.Attributes.Add("id", "TableHeader");

            TModel model = Builder.Data.FirstOrDefault();

            if (this.Builder.multipleSelection || this.Builder._DEF_MultipleSelection)
            {
                var thCheck = new TagBuilder("th");
                thCheck.Attributes.Add("elem-identifier", "CheckableColumn");
                thCheck.AddCssClass("checkable-column");
                thCheck.Attributes.Add("style", "width: 3.25rem;");
                thCheck.InnerHtml += TableUtils.GetTableHeaderRowCheckBox(this.Builder.TableId, Resources.Resources.TODOS59977, Resources.Resources.PAGINA_ATUAL46671, Resources.Resources.NENHUM21531);
                trHead.InnerHtml += thCheck;
            }

            foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
            {
                ProcessColumnProperties(tc);

                if (tc.ColumnVisible)
                {
                    trHead.InnerHtml += GenerateHeaderCell(model, tc).ToString();
                }
            }

            tHead.InnerHtml += trHead.ToString();
            
            return tHead;
        }

        protected virtual TagBuilder Body()
        {
            TagBuilder tBody = new TagBuilder("tbody");
            tBody.AddCssClass("c-table__body");

            foreach (TModel model in Builder.Data)
            {
                PropertyInfo key_property = model.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).FirstOrDefault();
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary();

                routeValueDictionary.Add("id", Builder.TableKey.Evaluate(model));

                TagBuilder tRow = new TagBuilder("tr");
                tRow.MergeAttribute("data-key", this.Builder.TableKey.Evaluate(model));

                if(this.Builder.multipleSelection || this.Builder._DEF_MultipleSelection)
                {
                    var tdCheck = new TagBuilder("td");
                    tdCheck.Attributes.Add("elem-identifier", "CheckableColumn");
                    tdCheck.AddCssClass("checkable-column");
                    tdCheck.Attributes.Add("q-help", "multi-select-column");
                    tdCheck.InnerHtml += TableUtils.GetTableRowCheckBox();
                    tRow.InnerHtml += tdCheck;
                }

                if(this.Builder.HasFollowUpAction())
                    tRow.Attributes.Add("q-help", "row-follow-up");

                foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
                {
                    ProcessColumnProperties(tc);

                    if (tc.ColumnField == "ValZzstate")
                    {
                        var value = tc.Evaluate(model);
                        if (value != "0")
						{
                            tRow.Attributes.Add("class", "c-table__row--pending");
                            tRow.Attributes.Add("rel", "tooltip");
                            tRow.Attributes.Add("title", Resources.Resources.ATENCAO__ESTA_FICHA_24725);
                        }
                    }
                    if (tc.ColumnVisible && !tc.IsActionsColumn && !tc.IsCheckListColumn)
                    {
                        tRow.InnerHtml += GenerateBodyCell(model, tc).ToString();
                    }

                    GenerateOtherCell(model, tc, tRow, routeValueDictionary);
                }

                tBody.InnerHtml += tRow;
            }

            return tBody;
        }

        protected virtual TagBuilder Footer()
        {
            TagBuilder tFooter = new TagBuilder("tfoot");
            tFooter.AddCssClass("c-table__footer");

            TagBuilder trFooter = new TagBuilder("tr");
            TagBuilder tdFooter = new TagBuilder("td");

            var columnCount = Builder.TableColumns.Count(x => x.ColumnVisible);
            if (this.Builder.multipleSelection)
                columnCount++;
            tdFooter.Attributes.Add("colspan", columnCount.ToString());

            if(this.Builder.hasPagination)
                tdFooter.InnerHtml += PagerRenderer.ToHtml();
            tdFooter.InnerHtml += GenerateExtraFooterContent();

            if (this.Builder.HasLimits())
                tdFooter.InnerHtml += GenerateLimitsContent();

            trFooter.InnerHtml += tdFooter;
            tFooter.InnerHtml += trFooter;

            return tFooter;
        }

        protected virtual MvcHtmlString EmptyList(bool hasActionsCol = false)
        {
            TagBuilder tBody = new TagBuilder("tbody");
            tBody.AddCssClass("c-table__body");

            TagBuilder tRow = new TagBuilder("tr");
            tRow.AddCssClass("c-table__row--empty");

            TagBuilder tCell = new TagBuilder("td");
            tCell.MergeAttribute("colspan", this.Builder.TableColumns.Where(x => x.ColumnVisible).Count().ToString());

			//<Get <th> IDs and add to footer <td> headers attribute
			string header = "";
			string header_fields = "";
			string header_filters = "";
			string header_actions = "";
			string header_actions_filter = "";
			//Add column IDs
			foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
			{
				if (tc.ColumnVisible && !tc.IsActionsColumn && !tc.IsCheckListColumn)
				{
					String fieldID = tc.ColumnField;
					String col_header = typeof(TModel).Name + "_" + this.Builder.TableId + "_" + fieldID;

					if(String.IsNullOrEmpty(col_header))
						continue;

					header_fields += col_header + " ";

					if(this.Builder.hasFilters)
						header_filters += "Filter_" + typeof(TModel).Name + "_" + this.Builder.TableId + "_" + fieldID.Replace(".", "_") + " ";
				}
			}

			//Add action ID if it exists
			if(hasActionsCol)
			{
				header_actions = typeof(TModel).Name + "_" + this.Builder.TableId + "_actions ";
				header_actions_filter = "Filter_" + header_actions;
			}

			//Join field headers and filter headers (filter headers must all come after field headers)
			header = header_fields + header_actions;

			if(this.Builder.hasFilters)
				header += header_filters + header_actions_filter;

			tCell.Attributes.Add("headers", header.Trim());
			//>

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("c-table__row");

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("c-alert__row-text");
            span.InnerHtml += " &lt;" + TableString.EmptyList.ToString() + "&gt;";

            div.InnerHtml += span;

            tCell.InnerHtml += div;
            tRow.InnerHtml += tCell;
            tBody.InnerHtml += tRow;

            return new MvcHtmlString(tBody.ToString());
        }

        protected virtual Dictionary<string, string> GetHtmlAttributes()
        {
            if (this.Builder.additionalHtmlAttributes != null)
                return this.Builder.additionalHtmlAttributes;
            return new Dictionary<string, string>();
        }

        internal virtual TagBuilder GenerateHeaderCell(TModel model, ITableColumnInternal<TModel> tc)
        {
            TagBuilder tCell = this.ColumnRenderer.RenderHeaderCell(model, tc);

            return tCell;
        }

        internal virtual TagBuilder GenerateBodyCell(TModel model, ITableColumnInternal<TModel> tc, bool paint_cell = true)
        {
            TagBuilder tCell = this.ColumnRenderer.RenderBodyCell(model, tc, paint_cell);

            return tCell;
        }

        internal virtual void GenerateOtherCell(TModel model, ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
        }

		internal virtual MvcHtmlString GenerateLimitsContent()
        {//remember to replace translation code below when copying from generated code, and add the dollar sign before {Genio
            MvcHtmlString ret = new MvcHtmlString(String.Empty);
            if (this.Builder.HasLimits())
            {
                TagBuilder button = new TagBuilder("button");
                button.AddCssClass("b-icon b-icon--secondary dropdown" + this.buttonSize);
                button.Attributes.Add("title", Resources.Resources.LIMITE12596);
                button.Attributes.Add("data-toggle", "dropdown");
                button.Attributes.Add("data-offset", "0, 9");
                
                TagBuilder iconBtnnInfo = new TagBuilder("i");
                iconBtnnInfo.AddCssClass("glyphicons glyphicons-info-sign e-icon");
                button.InnerHtml += iconBtnnInfo;

                TagBuilder ul = new TagBuilder("div");
                ul.AddCssClass("dropdown-menu");
                ul.AddCssClass("c-table");
                if (LayoutConfig.config.DbEditActionPlacement == "left")
                    ul.AddCssClass("pull-left");
                else
                    ul.AddCssClass("pull-right");


                ul.Attributes.Add("style", "width: fit-content; border: 1px solid rgba(0, 0, 0, 0.2);");

                TagBuilder div = new TagBuilder("div");
                TagBuilder li_header = new TagBuilder("li");
                li_header.AddCssClass("c-alert__row-text");
                TagBuilder hr = new TagBuilder("hr");
                hr.Attributes.Add("style", "margin-top: .6rem; margin-bottom: .9rem;");
              

                TModel tc = Builder.Data.FirstOrDefault();

                CSGenio.business.AreaInfo table = CSGenio.business.Area.GetInfoArea(typeof(TModel).Name.ToLower());

                string User_Language = Models.Navigation.UserContext.Current.User.Language;
                string table_AreaPluralDesignation = CSGenio.framework.Translations.Get(table.AreaPluralDesignation, User_Language); //translation
                string table_title_info = string.Format(Resources.Resources.A_INFORMACAO_NA_LIST00615, table_AreaPluralDesignation);
              //string table_title_info = string.Format(Resources.Resources.{Genio.GetSymbolFromString("A informação na lista de <b>{0}</b> está limitada por:")}, table.AreaPluralDesignation); //replace when copying from generated code, and add the dollar sign before {Genio

                li_header.InnerHtml += table_title_info;
                div.InnerHtml += li_header;
                div.InnerHtml += hr;

                int i = 1;
                CSGenio.persistence.PersistentSupport sp = GenioMVC.Models.Navigation.UserContext.Current.PersistentSupport;
                foreach (Limit limit in Builder.tableLimits)
                {

                    TagBuilder li = new TagBuilder("li");
                    li.Attributes.Add("style", "white-space: normal; padding-left: .6rem;");

                    string AreaLimita, AreaLimita_HTML, AreaLimitaPlural_HTML; AreaLimita = AreaLimita_HTML = AreaLimitaPlural_HTML = string.Empty;
                    string AreaLimitaN, AreaLimitaN_HTML, AreaLimitaNPlural_HTML; AreaLimitaN = AreaLimitaN_HTML = AreaLimitaNPlural_HTML = string.Empty;
                    string AreaComparar, AreaComparar_HTML, AreaCompararPlural_HTML; AreaComparar = AreaComparar_HTML = AreaCompararPlural_HTML = string.Empty;

                    string CampoLimita, CampoLimita_HTML; CampoLimita = CampoLimita_HTML = string.Empty;
                    string CampoLimitaN, CampoLimitaN_HTML; CampoLimitaN = CampoLimitaN_HTML = string.Empty;
                    string CampoComparar, CampoComparar_HTML; CampoComparar = CampoComparar_HTML = string.Empty;

                    string CampoLimita_Value, CampoLimita_MinLim_Value, CampoLimita_MaxLim_Value, CampoLimitaN_Value, CampoComparar_Value;
                    CampoLimita_Value = CampoLimita_MinLim_Value = CampoLimita_MaxLim_Value = CampoLimitaN_Value = CampoComparar_Value = string.Empty;

                    string CampoLimita_Value_HTML, CampoLimita_MinLim_Value_HTML, CampoLimita_MaxLim_Value_HTML, CampoLimitaN_Value_HTML, CampoComparar_Value_HTML;
                    CampoLimita_Value_HTML = CampoLimita_MinLim_Value_HTML = CampoLimita_MaxLim_Value_HTML = CampoLimitaN_Value_HTML = CampoComparar_Value_HTML = string.Empty;

                    string Area_CampoLimita_separator = string.Empty;
                    string Area_CampoLimitaN_separator = string.Empty;
                    string Area_CampoComparar_separator = string.Empty;

                    //Gets the variable names and values to display
                    if (limit.AreaLimita != null)
                    {
                        if (limit.AreaLimita.Alias != table.Alias)
                        {
                            //Naming with Translations
                            //AreaLimita
                            string AreaLimita_AreaDesignation = CSGenio.framework.Translations.Get(limit.AreaLimita.AreaDesignation, User_Language);
                            string AreaLimita_AreaPluralDesignation = CSGenio.framework.Translations.Get(limit.AreaLimita.AreaPluralDesignation, User_Language);
                            string AreaLimita_Alias = CSGenio.framework.Translations.Get(limit.AreaLimita.Alias, User_Language);

                            AreaLimita_HTML = (!string.IsNullOrEmpty(AreaLimita_AreaDesignation) ? AreaLimita_AreaDesignation : AreaLimita_Alias);
                            AreaLimitaPlural_HTML = (!string.IsNullOrEmpty(AreaLimita_AreaPluralDesignation) ? AreaLimita_AreaPluralDesignation : AreaLimita_Alias);
                        }
                        if (limit.CampoLimita != null)
                        {
                            CampoLimita = limit.CampoLimita.Name;
                            //List of human fields:
                            string[] AreaLimita_human_fields_array = limit.AreaLimita.Information.HumanKeyName.Split(',');

                            if (CampoLimita != limit.AreaLimita.Information.PrimaryKeyName && (!AreaLimita_human_fields_array.Contains(CampoLimita) || limit.AreaLimita.Alias == table.Alias))
                            {
                                //Naming with Translations
                                //CampoLimita
                                string CampoLimita_FieldDescription = CSGenio.framework.Translations.Get(limit.AreaLimita.DBFields[CampoLimita].FieldDescription, User_Language);
                                string CampoLimita_Name = limit.AreaLimita.DBFields[CampoLimita].Name;
                                CampoLimita_HTML = (!string.IsNullOrEmpty(CampoLimita_FieldDescription) ? CampoLimita_FieldDescription : CampoLimita_Name) ;
                            }
                            else if (limit.AreaLimita.Alias == table.Alias && CampoLimita == limit.AreaLimita.Information.PrimaryKeyName && CSGenio.framework.GenFunctions.emptyC(limit.AreaLimita.Information.HumanKeyName) == 0) //special case
                            {
                                //Naming with Translations
                                //CampoLimita (as humankey)
                                string HumanKeyName_FieldDescription = CSGenio.framework.Translations.Get(limit.AreaLimita.DBFields[limit.AreaLimita.Information.HumanKeyName.Split(',')[0]].FieldDescription, User_Language);
                                string HumanKeyName_Name = limit.AreaLimita.DBFields[limit.AreaLimita.Information.HumanKeyName.Split(',')[0]].Name;
                                CampoLimita_HTML = (!string.IsNullOrEmpty(HumanKeyName_FieldDescription) ? HumanKeyName_FieldDescription : HumanKeyName_Name);
                            }

                            if (limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + CampoLimita))
                            {
                                CampoLimita_Value = ((CSGenio.framework.RequestedField)limit.AreaLimita.Fields[limit.AreaLimita.Alias + "." + CampoLimita]).Value.ToString();
                                CampoLimita_Value_HTML = GenioMVC.Models.AuditModel.GetHumanValue(sp, limit.AreaLimita.Information, limit.CampoLimita, CampoLimita_Value);
                            }
                        }

                        //between dates (min)
                        if (limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + "minLim"))
                        {
                            CampoLimita_MinLim_Value = limit.AreaLimita.Fields[limit.AreaLimita.Alias + "." + "minLim"].Value.ToString();
                            CampoLimita_MinLim_Value_HTML = GenioMVC.Models.AuditModel.GetHumanValue(sp, limit.AreaLimita.Information, limit.CampoLimita, CampoLimita_MinLim_Value);
                        }

                        //between dates (max)
                        if (limit.AreaLimita.Fields.ContainsKey(limit.AreaLimita.Alias + "." + "maxLim"))
                        {
                            CampoLimita_MaxLim_Value = limit.AreaLimita.Fields[limit.AreaLimita.Alias + "." + "maxLim"].Value.ToString();
                            CampoLimita_MaxLim_Value_HTML = GenioMVC.Models.AuditModel.GetHumanValue(sp, limit.AreaLimita.Information, limit.CampoLimita, CampoLimita_MaxLim_Value);
                        }

                        //defaults if needed:
                        Area_CampoLimita_separator = (AreaLimita_HTML != "" && CampoLimita_HTML != "" ? " -> " : "");
                        if (string.IsNullOrEmpty(CampoLimita_Value_HTML))
                            CampoLimita_Value_HTML = " &lt;" + TableString.EmptyList.ToString() + "&gt;";
                        if (string.IsNullOrEmpty(CampoLimita_MinLim_Value_HTML))
                            CampoLimita_MinLim_Value_HTML = " &lt;" + TableString.EmptyList.ToString() + "&gt;";
                        if (string.IsNullOrEmpty(CampoLimita_MaxLim_Value_HTML))
                            CampoLimita_MaxLim_Value_HTML = " &lt;" + TableString.EmptyList.ToString() + "&gt;";
                    }

                    if (limit.AreaLimitaN != null)
                    {
                        if (limit.AreaLimitaN.Alias != table.Alias)
                        {
                            //Naming with Translations
                            //AreaLimitaN
                            string AreaLimitaN_AreaDesignation = CSGenio.framework.Translations.Get(limit.AreaLimitaN.AreaDesignation, User_Language);
                            string AreaLimitaN_AreaPluralDesignation = CSGenio.framework.Translations.Get(limit.AreaLimitaN.AreaPluralDesignation, User_Language);
                            string AreaLimitaN_Alias = CSGenio.framework.Translations.Get(limit.AreaLimitaN.Alias, User_Language);

                            AreaLimitaN_HTML = (!string.IsNullOrEmpty(AreaLimitaN_AreaDesignation) ? AreaLimitaN_AreaDesignation : AreaLimitaN_Alias);
                            AreaLimitaNPlural_HTML = (!string.IsNullOrEmpty(AreaLimitaN_AreaPluralDesignation) ? AreaLimitaN_AreaPluralDesignation : AreaLimitaN_Alias);
                        }
                        if (limit.CampoLimitaN != null)
                        {

                            CampoLimitaN = limit.CampoLimitaN.Name;
                            //List of human fields:
                            string[] AreaLimitaN_human_fields_array = limit.AreaLimitaN.Information.HumanKeyName.Split(',');

                            if (CampoLimitaN != limit.AreaLimitaN.Information.PrimaryKeyName && (!AreaLimitaN_human_fields_array.Contains(CampoLimitaN) || limit.AreaLimitaN.Alias == table.Alias))
                            {
                                //Naming with Translations
                                //CampoLimitaN
                                string CampoLimitaN_FieldDescription = CSGenio.framework.Translations.Get(limit.AreaLimitaN.DBFields[CampoLimitaN].FieldDescription, User_Language);
                                string CampoLimitaN_Name = limit.AreaLimitaN.DBFields[CampoLimitaN].Name;
                                CampoLimitaN_HTML = (!string.IsNullOrEmpty(CampoLimitaN_FieldDescription) ? CampoLimitaN_FieldDescription : CampoLimitaN_Name);
                            }
                            else if (limit.AreaLimitaN.Alias == table.Alias && CampoLimitaN == limit.AreaLimitaN.Information.PrimaryKeyName) //special case
                            {
                                //Naming with Translations
                                //CampoLimitaN (as humankey)
                                string HumanKeyName_FieldDescription = CSGenio.framework.Translations.Get(limit.AreaLimitaN.DBFields[limit.AreaLimitaN.Information.HumanKeyName.Split(',')[0]].FieldDescription, User_Language);
                                string HumanKeyName_Name = limit.AreaLimitaN.DBFields[limit.AreaLimitaN.Information.HumanKeyName.Split(',')[0]].Name;
                                CampoLimitaN_HTML = (!string.IsNullOrEmpty(HumanKeyName_FieldDescription) ? HumanKeyName_FieldDescription : HumanKeyName_Name);
                            }

                            if (limit.AreaLimitaN.Fields.ContainsKey(limit.AreaLimitaN.Alias + "." + CampoLimitaN))
                            {
                                CampoLimitaN_Value = ((CSGenio.framework.RequestedField)limit.AreaLimitaN.Fields[limit.AreaLimitaN.Alias + "." + CampoLimitaN]).Value.ToString();
                                CampoLimitaN_Value_HTML = GenioMVC.Models.AuditModel.GetHumanValue(sp, limit.AreaLimitaN.Information, limit.CampoLimitaN, CampoLimitaN_Value);
                            }
                        }

                        if (string.IsNullOrEmpty(CampoLimitaN_Value_HTML))
                            CampoLimitaN_Value_HTML = " &lt;" + TableString.EmptyList.ToString() + "&gt;";

                        Area_CampoLimitaN_separator = (AreaLimitaN_HTML != "" && CampoLimitaN_HTML != "" ? " -> " : "");
                    }

                    if (limit.AreaComparar != null)
                    {
                        if (limit.AreaComparar.Alias != table.Alias)
                        {
                            //Naming with Translations
                            //AreaComparar
                            string AreaComparar_AreaDesignation = CSGenio.framework.Translations.Get(limit.AreaComparar.AreaDesignation, User_Language);
                            string AreaComparar_AreaPluralDesignation = CSGenio.framework.Translations.Get(limit.AreaComparar.AreaPluralDesignation, User_Language);
                            string AreaComparar_Alias = CSGenio.framework.Translations.Get(limit.AreaComparar.Alias, User_Language);

                            AreaComparar_HTML =  (!string.IsNullOrEmpty(AreaComparar_AreaDesignation) ? AreaComparar_AreaDesignation : AreaComparar_Alias);
                            AreaCompararPlural_HTML = (!string.IsNullOrEmpty(AreaComparar_AreaPluralDesignation) ? AreaComparar_AreaPluralDesignation : AreaComparar_Alias);
                        }
                        if (limit.CampoComparar != null)
                        {
                            CampoComparar = limit.CampoComparar.Name;
                            //List of human fields:
                            string[] AreaComparar_human_fields_array = limit.AreaComparar.Information.HumanKeyName.Split(',');

                            if (CampoComparar != limit.AreaComparar.Information.PrimaryKeyName && (!AreaComparar_human_fields_array.Contains(CampoComparar) || limit.AreaComparar.Alias == table.Alias))
                            {
                                //Naming with Translations
                                //CampoComparar
                                string CampoComparar_FieldDescription = CSGenio.framework.Translations.Get(limit.AreaComparar.DBFields[CampoComparar].FieldDescription, User_Language);
                                string CampoComparar_Name = limit.AreaComparar.DBFields[CampoComparar].Name;
                                CampoComparar_HTML = (!string.IsNullOrEmpty(CampoComparar_FieldDescription) ? CampoComparar_FieldDescription : CampoComparar_Name);

                            }
                            else if (limit.AreaComparar.Alias == table.Alias && CampoComparar == limit.AreaComparar.Information.PrimaryKeyName) //special case
                            {
                                //Naming with Translations
                                //CampoComparar (as humankey)
                                string HumanKeyName_FieldDescription = CSGenio.framework.Translations.Get(limit.AreaComparar.DBFields[limit.AreaComparar.Information.HumanKeyName.Split(',')[0]].FieldDescription, User_Language);
                                string HumanKeyName_Name = limit.AreaComparar.DBFields[limit.AreaComparar.Information.HumanKeyName.Split(',')[0]].Name;
                                CampoComparar_HTML = (!string.IsNullOrEmpty(HumanKeyName_FieldDescription) ? HumanKeyName_FieldDescription : HumanKeyName_Name);
                            }

                            if (limit.AreaComparar.Fields.ContainsKey(limit.AreaComparar.Alias + "." + CampoComparar))
                            {
                                CampoComparar_Value = ((CSGenio.framework.RequestedField)limit.AreaComparar.Fields[limit.AreaComparar.Alias + "." + CampoComparar]).Value.ToString();
                                CampoComparar_Value_HTML = GenioMVC.Models.AuditModel.GetHumanValue(sp, limit.AreaComparar.Information, limit.CampoComparar, CampoComparar_Value);
                            }
                        }
                        if (string.IsNullOrEmpty(CampoComparar_Value_HTML))
                            CampoComparar_Value_HTML = " &lt;" + TableString.EmptyList.ToString() + "&gt;";

                        Area_CampoComparar_separator = (AreaComparar_HTML != "" && CampoComparar_HTML != "" ? " -> " : "");
                    }

                    string Table_Field_Limita = AreaLimita_HTML + Area_CampoLimita_separator + CampoLimita_HTML;
                    string Table_Field_LimitaN = AreaLimitaN_HTML + Area_CampoLimitaN_separator + CampoLimitaN_HTML;
                    string Table_Field_Comparar = AreaComparar_HTML + Area_CampoComparar_separator + CampoComparar_HTML;

                    bool valid_limit = false; //if the limit is not being applied, it wont be a valid limit, it exists on Genio definitions, but isnt limiting the list (not present, only apply if exists, or other future development)

                    switch (limit.TipoLimite)
                    {
                        case (LimitType.A):     //Area
                        case (LimitType.DB):    //Area (from menus)
                        case (LimitType.H):     //History
                        case (LimitType.F):     //Fixed
                        case (LimitType.N):     //Fixed (new)
                        case (LimitType.SH):    //history manipulation (from menus)
                        case (LimitType.HM):    //history selection  (from menus)
                        case (LimitType.SC):    //Condition selection (from menus)
                        case (LimitType.SA):    //Sub-area Array (Enumeration) (from menus)
                        case (LimitType.SL):    //Sub-area Logic (Boolean-int) (from menus)
                        case (LimitType.AC):    //Array Choice (Enumeration) (from menus)
                        case (LimitType.EPH):    //User EPH
                            {
                                //limit on AreaLimit (if <>) and CampoLimita

                                //if limit will only apply if exists, then when field_value is null, it will assume that the limit isnt being applied through the framework.
                                if (!(limit.NaoAplicaSeNulo && CampoLimita_Value == ""))
                                {
                                    li.InnerHtml += Table_Field_Limita + (!string.IsNullOrEmpty(limit.TipoLimiteOperator) ? limit.TipoLimiteOperator : ": ") + "<b>" + CampoLimita_Value_HTML + "</b>";
                                    valid_limit = true; //limit is being applied, otherwise it wont count.
                                }
                                break;
                            }
                        case (LimitType.V):     //Form control N:N
						case (LimitType.DC): 	//Menu N:N List
						    {
                                //li.InnerHtml += "(N:N) ";

                                //limit on AreaLimitaN and AreaLimita
                                if (!(limit.NaoAplicaSeNulo && CampoLimita_Value == ""))
                                {
                                    li.InnerHtml += Table_Field_LimitaN + " -> " + Table_Field_Limita + ": " + "<b>" + CampoLimita_Value_HTML + "</b>";
                                    valid_limit = true;
                                }
                                break;
                            }
                        case (LimitType.E):     //Between dates
                            {
                                //limit on all areas (CampoComparar holds the value between limits)
                                if (!(limit.NaoAplicaSeNulo && CampoComparar_Value == ""))
                                {
                                    li.InnerHtml += Table_Field_Limita + " <= " + Table_Field_Comparar +": "+ CampoComparar_Value_HTML + " <= " + Table_Field_LimitaN;
                                    valid_limit = true;
                                }
                                break;
                            }
                        case (LimitType.C):     //Field
                            {
                                //limit on AreaLimitaN
                                if (!(limit.NaoAplicaSeNulo && CampoLimitaN_Value == ""))
                                {
                                    li.InnerHtml += Table_Field_LimitaN + ": " + "<b>" + CampoLimitaN_Value_HTML + "</b>" ;
                                    valid_limit = true;
                                }
                                break;
                            }
                        case (LimitType.SE):    //Cross-boundary selection
                            {
                                //limit on AreaLimita and CampoLimita
								li.InnerHtml += CampoLimita_MinLim_Value_HTML + "<= " + Table_Field_Limita + " <= " + CampoLimita_MaxLim_Value_HTML;
								valid_limit = true;

                                break;
                            }
                        case (LimitType.SU):     //Threshold selection
                            {
                                //limit on AreaLimita and CampoLimita
                                string operation = string.Empty;
                                switch (limit.TipoLimiteSU)
                                {
                                    case OperationType.LESS:
                                        operation = " < ";
                                        break;
                                    case OperationType.LESSEQUAL:
                                        operation = " <= ";
                                        break;
                                    case OperationType.GREAT:
                                        operation = " > ";
                                        break;
                                    case OperationType.GREATEQUAL:
                                        operation = " >= ";
                                        break;
                                    case OperationType.DIFF:
                                        operation = " <> ";
                                        break;
                                    case OperationType.EQUAL:
                                    default:
                                        operation = " = ";
                                        break;
                                }
								li.InnerHtml += Table_Field_Limita + operation + CampoLimita_Value_HTML;
								valid_limit = true;
                                break;
                            }
                        case (LimitType.DM):    //Menu "Multiple selection"
                            {
                                li.InnerHtml += "{"+AreaLimitaPlural_HTML+"}"; //selected from list before
                                valid_limit = true;
                                break;
                            }
                        case (LimitType.AFILTER):    //Menu "Filter by Area"
							{
                                //limit on AreaLimit -> Current Area

                                    li.InnerHtml += "#" + AreaLimitaPlural_HTML +" (>= 1)";
                                    valid_limit = true; //limit is being applied, otherwise it wont count.

                                break;
                            }
							case (LimitType.OVERRQ):    //Manual routine
                            {
                                //limit on AreaLimit -> Current Area
                                if ((limit.ManualHTMLText != ""))
                                {
                                    li.InnerHtml += limit.ManualHTMLText;
                                    valid_limit = true; //limit is being applied, otherwise it wont count.
                                }
                                break;
                            }
                        default:
                            break;
                    }
                    if (valid_limit)
                    {
                        i++;
                        div.InnerHtml += li;
                    }
                }

                if (i > 1) //meaning that at least one limit was considered valid
                {
                    ul.InnerHtml += div;

                    TagBuilder divContainer = new TagBuilder("div");
                    divContainer.AddCssClass("btn-group dropup");
                    divContainer.Attributes.Add("elem-identifier", "BtnGroup");
                    divContainer.Attributes.Add("style", "position: inherit");

                    divContainer.InnerHtml += button;
                    divContainer.InnerHtml += ul;

                    ret = new MvcHtmlString(divContainer.ToString());
                }
            }
            return ret;
        }

        internal virtual MvcHtmlString GenerateExtraFooterContent()
        {
            return new MvcHtmlString(String.Empty);
        }

        internal virtual MvcHtmlString GenerateExtraEmptyListContent()
        {
            return new MvcHtmlString(String.Empty);
        }

        internal virtual MvcHtmlString GenerateHiddenFields()
        {
            string result = "";

            if (Builder.hasPagination)
            {
                result += System.Web.Mvc.Html.InputExtensions.Hidden(Builder.HtmlHelper, this.pageInput, Builder.Pager.PageNumber).ToHtmlString();
            }

            if (Builder.hasSorting)
            {
                result += System.Web.Mvc.Html.InputExtensions.Hidden(Builder.HtmlHelper, this.sortInput, Builder.Sorter.Column).ToHtmlString();
                result += System.Web.Mvc.Html.InputExtensions.Hidden(Builder.HtmlHelper, this.sortDirInput, Builder.Sorter.Direction.ToString()).ToHtmlString();
            }

            return new MvcHtmlString(result);
        }

        protected virtual MvcHtmlString GenerateScripts()
        {
            string script = @"
            $(document).ready(function(){
                window." + this.Builder.TableId + @" = $('#" + this.Builder.TableId + @"').tableFor({
                    requestsUrl: '" + HttpUtility.JavaScriptStringEncode(this.Builder.requestsLink) + @"',
                    container: '" + this.Builder.ajaxUpdateContainerId + @"',
                    tableType: '" + this.Builder.TableType.ToString() + @"',
                    pageField: '" + HttpUtility.JavaScriptStringEncode(this.pageInput) + @"',
                    sortField: '" + HttpUtility.JavaScriptStringEncode(this.sortInput) + @"',
                    sortDirField: '" + HttpUtility.JavaScriptStringEncode(this.sortDirInput) + @"'
                });
            });";
            return new MvcHtmlString(script);
        }
    }
}
