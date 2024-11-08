using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using System.Text;
using GenioMVC.Helpers.Table.Filtering;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Utils;
using GenioMVC.Helpers.Table.Renderer;
using GenioMVC.Models.Navigation;
using CSGenio.business;
using System.Text.RegularExpressions;


namespace GenioMVC.Helpers.Table
{
    public class MatrixBuilder<TModel> : DbEditRenderer<TModel> where TModel : class
    {
        new private TableList<TModel> Builder { get; set; }

        private string tablekey_AxysX {get; set;}

        private string tablekey_AxysY { get; set; }

        private GenioMVC.Helpers.Table.Columns.ITableColumnInternal<TModel> tcX = null; //QColumn X
        private GenioMVC.Helpers.Table.Columns.ITableColumnInternal<TModel> tcY = null; //QColumn Y
        private GenioMVC.Helpers.Table.Columns.ITableColumnInternal<TModel> tcData = null; //QColumn com os dados
        private GenioMVC.Helpers.Table.Columns.ITableColumnInternal<TModel> tcActions = null; //QColumn com as acções

        private Dictionary<string, string> listYHeaders = null;

        private RouteValueDictionary CellRouteValues = new RouteValueDictionary();

        private string action_Save_All { get; set; } //link to a gravação global
        private string action_Insert_All { get; set; } //link to a inserção global

        public MatrixBuilder<TModel> _builder
        {
            get { return (this.Builder as MatrixBuilder<TModel>); }
        }

        internal MatrixBuilder(Table<TModel> builder, bool hasFilters)
            : base(builder)
        {
            this.Builder = builder as TableList<TModel>;
        }

        public MatrixBuilder<TModel> Pager(GenioMVC.ViewModels.TablePagination pager)
        {
            int numberofitems = pager.NumberOfItems;
            if (pager.NumberOfItems == 0)
                numberofitems = 1000;

            this.Builder.SetPager(pager.PageNumber, numberofitems, pager.HasMore, pager.HasTotal, pager.TotalRows);
            return this;
        }

        /// Set SetMatrixActionSaveAll
        public MatrixBuilder<TModel> SetMatrixActionSaveAll(string url)
        {
            this.action_Save_All = url;
            return this;
        }

        /// Set SetMatrixActionInsertAll
        public MatrixBuilder<TModel> SetMatrixActionInsertAll(string url)
        {
            this.action_Insert_All = url;
            return this;
        }

        /// Set SetMatrixInputField
        public MatrixBuilder<TModel> TableKey_AxysX(string tablekey)
        {
            this.tablekey_AxysX = tablekey;
            return this;
        }

        public MatrixBuilder<TModel> TableKey_AxysY(string tablekey)
        {
            this.tablekey_AxysY = tablekey;
            return this;
        }

        public MvcHtmlString ToHtml()
        {

            this.Builder.DoInternalActions();

            //TagBuilder divTableFilters = new TagBuilder("div");
            //divTableFilters.MergeAttribute("id", this.Builder.TableId + "_tableFilters");

            //divTableFilters.AddCssClass("table-strip-responsive");

            //if (this.Builder.TableType == GenioMVC.Helpers.Table.Properties.TableType.SearchList)
            //    divTableFilters.AddCssClass("search-list");

            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("c-table table-resizable table-responsive table-strip");
            table.AddCssClass(String.Join(" ", this.Builder.TableCssClass));

            if (string.IsNullOrEmpty(this.Builder.TableId))
            {
                table.GenerateId("table");
                this.Builder.SetId(table.Attributes["id"]);
            }
            else
            {
                table.Attributes.Add("id", this.Builder.TableId);
            }
            
            TagBuilder rowFluid = new TagBuilder("div");
            rowFluid.AddCssClass("row-fluid");
            rowFluid.AddCssClass(String.Join(" ", this.Builder.TableCssClass));

            TagBuilder span12;
            span12 = Header();
            if (this.Builder.Data.Count() == 0)
            { 
                span12.InnerHtml += EmptyListNoHeader();
                span12.InnerHtml += GetMatrixDynamicControlsFunction(""); //sets an empty Function in this case... so it doesnt burst the JS
            }


            span12.InnerHtml += Body();
            rowFluid.InnerHtml = span12.ToString();
            table.InnerHtml += rowFluid;


            if (this.Builder.IsInEditMode && (this.action_Save_All != null || this.action_Insert_All != null)) //mode edição
            {
                table.InnerHtml += Footer();

                RouteValueDictionary route = new RouteValueDictionary();
                if (tcX != null && tcY != null)
                {
                    string areas = tcX.ColumnArea.ToLower() + "," + tcY.ColumnArea.ToLower();
                    route.Add("HistoryRemoveAreas", areas);
                }
                this.CellRouteValues = route;
            }

            //divTableFilters.InnerHtml += table;
            TagBuilder divHiddenFields = new TagBuilder("div");
            divHiddenFields.MergeAttribute("id", Builder.TableId + "_inputs");
            divHiddenFields.InnerHtml = GenerateHiddenFields().ToHtmlString();
            
            GetHtmlAttributes().ToList().ForEach(p => { if (!table.Attributes.ContainsKey(p.Key)) table.Attributes.Add(p.Key, p.Value); });
           
            string result = new MvcHtmlString(/*divTableFilters.ToString() + */divHiddenFields.ToString() + table.ToString() + "<script>" + GenerateScripts().ToHtmlString() + "</script>").ToHtmlString();


            return new MvcHtmlString(result);
        }

        protected new TagBuilder Header()
        {
            //Header
            TagBuilder div = new TagBuilder("div");
            TagBuilder first = new TagBuilder("div");
            TagBuilder last = new TagBuilder("div");
            TagBuilder thead = new TagBuilder("thead");
            thead.AddCssClass("c-table__head");
            thead.InnerHtml += "<tr>";
            bool first_X = false;
            bool last_Y = false;

            //TModel model = (TModel)Builder.TableColumns.ElementAt(0).GetType();
            TModel model = this.Builder.Data.FirstOrDefault(); //(TModel)(Builder);

            foreach (ITableColumnInternal<TModel> tc in Builder.TableColumns)
            {
                if (tc.ColumnVisible && !first_X && !tc.IsActionsColumn)
                {
                    first.InnerHtml += GenerateHeaderCell(model, tc).ToString();
                    first_X = true;
                }
                else if (tc.ColumnVisible && first_X && !last_Y && !tc.IsActionsColumn)
                {
                    var th = GenerateHeaderCell(model, tc);
                    listYHeaders = GetColumnList(tc);
                    th.MergeAttribute("colspan", listYHeaders.Count.ToString());
                    last.InnerHtml += th.ToString();
                    last_Y = true;
                }
            }
            thead.InnerHtml += first.ToString() + last.ToString();
            
            thead.InnerHtml += "</tr>";
            div.InnerHtml = thead.ToString();

            return div;
        }

        protected new TagBuilder Body()
        {
            if (Builder.Data.Count() == 0)
            {
                TagBuilder insert_div = new TagBuilder("div");
                insert_div.InnerHtml = GenerateInsertCellContent().ToHtmlString();
                return insert_div;
            }  

            // Add Carousels
            TagBuilder div = new TagBuilder("div");
            TagBuilder first = new TagBuilder("div");
            TagBuilder last = new TagBuilder("div");

            #region Column information and ocurrences
            TagBuilder first_data = new TagBuilder("div");
            TagBuilder last_data = new TagBuilder("div");

            Dictionary<string, string> ListX_Data = new Dictionary<string, string>();        

            for (int i = 0; i < Builder.TableColumns.Count; i++)
            {
                GenioMVC.Helpers.Table.Columns.ITableColumnInternal<TModel> tc = Builder.TableColumns[i];

                if (tc.ColumnVisible && tcX == null && !tc.IsActionsColumn)
                {
                    tcX = tc; //Eixo dos X (comanda as linhas)

                    foreach (TModel inner_model in Builder.Data) //Percorre todas as ocorrências distintas de Qvalues da table que corre no eixo dos X
                    {
                        string cell = GenerateBodyCell(inner_model, tc, false).ToString();
                        string tc_key = tc.EvaluateKey(inner_model);
                        string found = String.Empty;
                        if (!(ListX_Data.TryGetValue(tc_key, out found) && found == cell))
                        {
                            ListX_Data.Add(tc_key, cell);
                        }
                    }
                }
                else if (tc.ColumnVisible && tcY == null && !tc.IsActionsColumn)
                {
                    tcY = tc; //Eixo dos Y (comanda as colunas)

                    last_data.InnerHtml += "<th>";
                }
                else if (tc.ColumnVisible && tcData == null && !tc.IsActionsColumn)
                {
                    tcData = tc; //QColumn com os dados
                }
                else if (tc.ColumnVisible && tc.IsActionsColumn)
                {
                    tcActions = tc; //QColumn com as acções
                }
            }
            #endregion

            //Percorre a matriz to preencher as ocorrências cruzadas
            List<string> columns_on_table = new List<string>();
            int control_num = 0;
            string cells_script = "";
            foreach (KeyValuePair<string, string> Axys_X in ListX_Data)
            {
                first_data.InnerHtml += "<tr>";
                first_data.InnerHtml += Axys_X.Value;
                foreach (KeyValuePair<string, string> Axys_Y in listYHeaders)
                {
                    bool found_cell = false;
                    if (!columns_on_table.Contains(Axys_Y.Key))
                    {
                        last_data.InnerHtml += Axys_Y.Value;
                        columns_on_table.Add(Axys_Y.Key);
                    }
                    foreach (TModel inner_model in Builder.Data)
                    {
                        
                        {
                            string cell_DataX = GenerateBodyCell(inner_model, tcX, false).ToString();
                            string cell_DataY = GenerateBodyCell(inner_model, tcY, false).ToString();

                            if (Axys_X.Value == cell_DataX)
                            {
                                if (Axys_Y.Value == cell_DataY) //Célula com os dados correspondentes na matriz
                                {
                                    if (!found_cell)
                                    {
                                        
                                        System.Reflection.PropertyInfo key_property = inner_model.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(System.ComponentModel.DataAnnotations.KeyAttribute))).FirstOrDefault();
                                        RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
                                        routeValueDictionary.Add("id", Builder.TableKey.Evaluate(inner_model)); //ID do registo correspondente à célula

                                        TagBuilder tCell = GenerateBodyCell(inner_model, tcData);

                                        //get/replace data-identifier:
                                        int start = tCell.InnerHtml.IndexOf("data-identifier=\""); //begining of the attribute
                                        int first_comma = tCell.InnerHtml.IndexOf("\"", start); //position of 1st "
                                        int second_comma = tCell.InnerHtml.IndexOf("\"", first_comma + 1);//position of 2nd "
                                        //update for each control;
                                        string find_data_id = tCell.InnerHtml.Substring(first_comma + 1, second_comma - first_comma - 1); //identifier is being place inside "" of data-identifier. i.e: data-identifier="LED_SOMETHING"
                                        string replace_data_id = find_data_id + "_" + control_num;
                                        tCell.InnerHtml = tCell.InnerHtml.Replace(find_data_id, replace_data_id);

                                        //get/replace id:
                                        start = tCell.InnerHtml.IndexOf(" id=\""); //begining of the attribute
                                        first_comma = tCell.InnerHtml.IndexOf("\"", start); //position of 1st "
                                        second_comma = tCell.InnerHtml.IndexOf("\"", first_comma + 1);//position of 2nd "
                                        string find_id = tCell.InnerHtml.Substring(first_comma + 1, second_comma - first_comma - 1); //identifier is being place inside "" of id. i.e: id="LED_SOMETHING"
                                        //update id control
                                        string replace_id = find_id + "_" + control_num;
                                        tCell.InnerHtml = tCell.InnerHtml.Replace(find_id, replace_id);

                                        ////get working area via per-cs-area:
                                        //start = tCell.InnerHtml.IndexOf(" pers-cs-area=\""); //begining of the attribute
                                        //first_comma = tCell.InnerHtml.IndexOf("\"", start); //position of 1st "
                                        //second_comma = tCell.InnerHtml.IndexOf("\"", first_comma + 1);//position of 2nd "
                                        //string area_find = tCell.InnerHtml.Substring(first_comma + 1, second_comma - first_comma - 1); //identifier is being place inside "" of id. i.e: id="LED_SOMETHING"

                                        //Form control initializer for each element called on form DeclareControls, via MatrixDynamicControls function ;
                                        //find = tCell.InnerHtml.Substring(first_comma + 1, second_comma - first_comma - 1); //identifier is being place inside "" of data-identifier. i.e: data-identifier="LED_SOMETHING"
                                        string main_form = Builder.ajaxUpdateContainerId.Replace("_" + Builder.TableId, "");
                                        cells_script += "Form_" + main_form + ".Controls." + replace_data_id + " = N_N_DataControl('" + replace_data_id + "');\n ";

                                        //Get cell working area (fast way.. this matrix area):
                                        string matrix_area = inner_model.GetType().Name;

                                        //get rid of "viewModel." naming that comes within control, should be named with model:
                                        tCell.InnerHtml = Regex.Replace(tCell.InnerHtml, @"viewModel.", matrix_area);

                                        string BDKey = this.Builder.TableKey.Evaluate(inner_model);

                                        tCell.MergeAttribute("data-key", BDKey, true);
                                        tCell.MergeAttribute("id", BDKey);
                                        //tCell.Attributes.Keys.Remove("data-col-field");
                                        tCell.Attributes.Add("control-id", Regex.Replace(replace_id, @"viewModel.", matrix_area));

                                        if (this.Builder.IsInEditMode && this.action_Save_All != null && tcActions != null) //mode edição
                                            GenerateOtherCell(inner_model, tcActions, tCell, routeValueDictionary);

                                        if (this.Builder.IsInEditMode)
                                            tCell.AddCssClass("row-actions");
                                        else
                                        {

                                            //add readonly to automatically disable control
                                            tCell.InnerHtml = tCell.InnerHtml.Replace("pers-cs-area=\"" + matrix_area + "\"", "pers-cs-area=\"" + matrix_area + "\" readonly = \"readonly\"");
                                            //tCell.InnerHtml = tCell.InnerHtml.Replace("<select ", "<select readonly = \"readonly\" ");
                                        }

                                        first_data.InnerHtml += tCell.ToString();
                                        found_cell = true;
                                        control_num++;

                                    }//caso não tenha encontrado, só fará algo se chegar ao fim da lista e não encontrar nenhuma ocorrência
                                    else
                                        first_data.InnerHtml += "(Warning: multiple values detected on " + tcX.Evaluate(inner_model) + " : " + tcY.Evaluate(inner_model) + " )<br>";

                                }
                            }
                        }
                    }
                    if (this.Builder.IsInEditMode && !found_cell && this.action_Insert_All != null) //Não encontrou e está em mode de edição (vai introduce esta célula no modelo)
                    {
                        //Inserir
                        TagBuilder tCell = new TagBuilder("td");// GenerateBodyCell(inner_model_new, null);
						tCell.Attributes.Add("elem-identifier", "RowActions");
                        tCell.AddCssClass("row-actions");
                        tCell.AddCssClass("to-insert");

                        tCell.MergeAttribute("dataX-key", Axys_X.Key, true);
                        tCell.MergeAttribute("dataY-key", Axys_Y.Key, true);

                        first_data.InnerHtml += tCell.ToString();
                    }
                }
            }
            div.InnerHtml += last_data.ToString() + first_data.ToString();
            div.InnerHtml += "</div>"; //item
            div.InnerHtml += "</div>";
            div.InnerHtml += "</div>";


            div.InnerHtml += GetMatrixDynamicControlsFunction(cells_script);



            return div;
        }

        protected string GetMatrixDynamicControlsFunction(string cells_script)
        {
            string return_function = string.Empty;
            return_function += "\n<script>function MatrixDynamicControls() {\n";
            return_function += cells_script;
            return_function += "\n};</script>";
            return return_function;
        }

        protected override int GetColumnCount()
        {
            return listYHeaders.Count + 1;
        }

        private Dictionary<string, string> GetColumnList(ITableColumnInternal<TModel> tableColumn)
        {
            Dictionary<string, string> columnList = new Dictionary<string, string>();
            foreach (TModel inner_model in Builder.Data) //Percorre todas as ocorrências distintas de Qvalues da table que corre no eixo dos Y
            {                
                string tc_key = tableColumn.EvaluateKey(inner_model);             

                if (!columnList.ContainsKey(tc_key)) //Célula de dados correspondentes
                {
                    var cell= GenerateBodyCell(inner_model, tableColumn, false);
                    TagBuilder th = new TagBuilder("td");
                    th.MergeAttributes(cell.Attributes, true);
                    th.InnerHtml = cell.InnerHtml;
                    columnList.Add(tc_key, cell.ToString());
                }
            }
            return columnList;
        }


        internal MvcHtmlString GenerateInsertCellContent()
        {
            RouteValueDictionary routeValueDictionary = this.CellRouteValues;

            String extraContent = String.Empty;

            // Insert Action
            if (Builder.Permissions.CanInsert && Builder.HasHelpForm())
            {
                extraContent += CreateInsertAction();
            }

            return new MvcHtmlString(extraContent);
        }

        protected override MvcHtmlString CreateInsertAction() 
        {
            RouteValueDictionary routeValueDictionary = this.CellRouteValues;

            TagBuilder actionLink;
            TableAction<TModel> fAction = TableUtils.GetSepecificPathsFollowUpAction(this.Builder.TableActions);

            if (fAction != null)
            {
                routeValueDictionary.Add("formMode", "New_Insert"); //to poder mexer no historial no click do introduce.
                actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, fAction.Action, routeValueDictionary, TableString.Insert.ToString(), new { @class = "b-icon-text b-icon-text--primary" }, fAction.Controller);
            }
            else
            {
                actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_New_Insert", routeValueDictionary, TableString.Insert.ToString(), new { @class = "b-icon-text b-icon-text--primary" });
            }
            actionLink.Attributes.Add("onclick", "onNavigation(event, this, 'NEW')");
            actionLink.Attributes.Add("qbutton", "insert");

            if (this.Builder.Form.OpenInPopup)
            {
                actionLink.Attributes.Add("data-modal-form", "true");
                actionLink.Attributes.Add("data-table", this.Builder.TableId);
                actionLink.Attributes.Add("data-modal-form-mode", "NEW");
            }
 
            return new MvcHtmlString(actionLink.ToString());
        }

        internal new void GenerateOtherCell(TModel model, ITableColumnInternal<TModel> tc, TagBuilder tRow, RouteValueDictionary routeValueDictionary)
        {
                 if (tc.ColumnVisible && tc.IsActionsColumn && (this.Builder.HasActions() || !this.Builder.HasActions() && this.Builder.hasFilters))
                    GenerateBodyActionsCell(model, tc, routeValueDictionary, tRow).ToString();
        }

        protected virtual TagBuilder GenerateBodyActionsCell(TModel model, ITableColumnInternal<TModel> tc, RouteValueDictionary routeValueDictionary, TagBuilder tCell)
        {
			tCell.Attributes.Remove("elem-identifier");
			tCell.Attributes.Add("elem-identifier", "RowActions");
            tCell.AddCssClass("row-actions");

            if (this.Builder.HasFollowUpAction())
                tCell.AddCssClass("selectable");

            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("elem-identifier", "BtnGroup");
            div.AddCssClass("btn-group");
         //   div.AddCssClass("pull-right");

            tCell.InnerHtml += "" + this.CreateFollowUp(model, routeValueDictionary) ?? "";
            if (!this.Builder.HasOnlyOneAction() || (this.Builder.HasOnlyOneAction() && !this.Builder.HasFollowUpAction()))
                div.InnerHtml += this.CreateActions(model, routeValueDictionary, tc) ?? "";

            if (!String.IsNullOrEmpty(div.InnerHtml))
                tCell.InnerHtml += div;

            if (this.Builder.BackgroundColourCondition != null)
            {
                string colour = this.Builder.BackgroundColourCondition.Compile().Invoke(model);
                    string backgroundcolour = "background-color: " + colour;
                    if (tCell.Attributes.ContainsKey("style"))
                    {
                        backgroundcolour += ";" + tCell.Attributes["style"];
                        tCell.Attributes.Remove("style");
                    }
                    tCell.Attributes.Add("style", backgroundcolour);
                }

            return tCell;
        }

        internal override MvcHtmlString GenerateExtraFooterContent()
        {
            var extraContent = String.Empty;
            //Generate the save changes button
            if (this.Builder.IsInEditMode && this.Builder.Data.Count()>0)
            {
                TagBuilder actionLink = new TagBuilder("button");
                actionLink.MergeAttribute("type", "button");
                actionLink.AddCssClass("b-icon-text b-icon-text--primary");
                actionLink.InnerHtml = Resources.Resources.GRAVAR45301; 
				//Resources.Resources.{Genio.GetSymbolFromString("Gravar")}; 
                actionLink.MergeAttribute("onclick", "javascript:" + this.Builder.TableId + "_SaveAllChanges()");
                extraContent += actionLink.ToString();
            }
            //Generate the insert button
            if (this.Builder.IsInEditMode && this.Builder.Data.Count() == 0)
            {
                TagBuilder actionLink = new TagBuilder("button");
                actionLink.MergeAttribute("type", "button");
                actionLink.AddCssClass("b-icon-text b-icon-text--primary");
                actionLink.InnerHtml = Resources.Resources.CRIAR_A_MATRIZ24165; 
				//Resources.Resources.{Genio.GetSymbolFromString("Criar a Matriz")}; 
                actionLink.MergeAttribute("onclick", "javascript:" + this.Builder.TableId + "_InsertMissing()");
                extraContent += actionLink.ToString();
            }

            return new MvcHtmlString(extraContent);

        }

    }
}