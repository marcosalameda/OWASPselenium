using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class ColumnRenderer<TModel> where TModel : class
    {
        public Table<TModel> Builder { get; protected set; }
        public TableRenderer<TModel> Renderer { get; protected set; }
        public SorterRenderer<TModel> SorterRenderer { get; protected set; }

        public ColumnRenderer(TableRenderer<TModel> renderer)
        {
            this.Renderer = renderer;
            this.Builder = this.Renderer.Builder;
            this.SorterRenderer = new SorterRenderer<TModel>(this.Renderer);
        }

        public virtual TagBuilder RenderBodyCell(TModel model, ITableColumnInternal<TModel> tableColumn, bool paint_cell = true )
        {
            TagBuilder tCell;

            // set tag type
            if ((this.Builder.TableType == Properties.TableType.SearchList) && !tableColumn.IsDocument)
                tCell = new TagBuilder("span");
            else
                tCell = new TagBuilder("td");

            // set html attributes
            foreach (var htmlAttr in tableColumn.ColumnHtmlAttributes)
	        {
		        tCell.Attributes.Add(htmlAttr);
	        }
			
			// set element identifier
			tCell.Attributes.Add("elem-identifier", "RowData");

            // set css class
            tCell.AddCssClass(string.Join(" ", tableColumn.ColumnCssClasses));

            // set style attribute
            tCell.Attributes.Add("style", ColumnUtils.GetCellStyle(tableColumn));

            // set field identifier
            tCell.Attributes.Add("data-col-field", tableColumn.ColumnField);

			// Last updated by [DSG] at [2018.07.02]
            // Add id to the header creating a link between td and th by adding td`s attribute headers equal to the corresponding header id
            // For accessibility purposes (see Principle1.Guideline1_3.1_3_1.H43.HeadersRequired of the WCAG2 rules)

            //set headers
            String fieldID = tableColumn.ColumnField;
            String header = typeof(TModel).Name + "_" + this.Builder.TableId + "_" + fieldID;
			
			if(this.Builder.hasFilters){header += " Filter_" + typeof(TModel).Name + "_" + this.Builder.TableId + "_" + fieldID.Replace(".", "_");}
			
            tCell.Attributes.Add("headers", header);

            // set value
            if (tableColumn.LambdaExpression == null && tableColumn.FormatExpression != null)
                tCell.InnerHtml = tableColumn.EvaluateFormat(this.Builder.HtmlHelper, model).ToHtmlString();
            else if (tableColumn.LambdaExpression != null)
                FillTCell(tCell, tableColumn, model);
            else
                tCell.SetInnerText(String.Empty);

            if (paint_cell)
            {
            PaintBackgroundColor(model, tableColumn, tCell);
            PaintForegroundColor(model, tableColumn, tCell);
            }

            return tCell;
        }


        /// <summary>
        /// Paints the background color of a cell.
        /// Adds and changes the necessary elements to tCell
        /// </summary>
        private void PaintBackgroundColor(TModel model, ITableColumnInternal<TModel> tableColumn, TagBuilder tCell)
        {
            //If column has a background, paint it with e-badge class
            var backgroundColorCondition = tableColumn.CompiledBackgroundColorExpression;
            if (backgroundColorCondition != null)
            {
                string colour = backgroundColorCondition.Invoke(model);
                if (!string.IsNullOrEmpty(colour))
                {
                    string backgroundcolour = "background-color: " + colour;
                    TagBuilder span = new TagBuilder("span");
                    span.AddCssClass("e-badge");
                    span.Attributes["style"] = backgroundcolour;
                    span.InnerHtml = tCell.InnerHtml;
                    tCell.InnerHtml = span.ToString();
                }
            }

            //If the row has a background paint all the cell
            if (this.Builder.BackgroundColourCondition != null)
            {
                backgroundColorCondition = this.Builder.BackgroundColourCondition.Compile();

                string colour = backgroundColorCondition.Invoke(model);
                if (!string.IsNullOrEmpty(colour))
                {
                    string backgroundColor = "background-color: " + colour;
                    if (tCell.Attributes.ContainsKey("style"))
                    {
                        backgroundColor += ";" + tCell.Attributes["style"];
                        tCell.Attributes.Remove("style");
                    }
                    tCell.Attributes.Add("style", backgroundColor);
                }
            }
        }

        
        private void PaintForegroundColor(TModel model, ITableColumnInternal<TModel> tableColumn, TagBuilder tCell)
        {
            Func<TModel, string> foregroundColorCondition = null;
            if (tableColumn.CompiledForegroundColorExpression != null)
            {
                foregroundColorCondition = tableColumn.CompiledForegroundColorExpression;
            }
            else if (this.Builder.ForegroundColourCondition != null)
            {
                foregroundColorCondition = this.Builder.ForegroundColourCondition.Compile();
            }

            if (foregroundColorCondition != null)
            {
                string colour = foregroundColorCondition.Invoke(model);
                if (!string.IsNullOrEmpty(colour))
                {
                    string foregroundcolour = "color: " + colour;
                    if (tCell.Attributes.ContainsKey("style"))
                    {
                        foregroundcolour += ";" + tCell.Attributes["style"];
                        tCell.Attributes.Remove("style");
                    }
                    tCell.Attributes.Add("style", foregroundcolour);
                }
            }
        }


        private void FillTCell(TagBuilder tCell, ITableColumnInternal<TModel> tableColumn, TModel model)
        {
            string value = tableColumn.Evaluate(model);

            var hasColumnForm = !String.IsNullOrEmpty(tableColumn.ColumnForm);
            TagBuilder aColumnForm = null;
            if (hasColumnForm)
            {
                // MH - As colunas Document e Boolean não vão suportar os formularios de apoio
                aColumnForm = new TagBuilder("a");
				aColumnForm.Attributes.Add("href","#");
                var routeValues = new { id = tableColumn.EvaluateKey(model), nav = Builder.Navigation.NavigationId, lvl = Builder.Navigation.CurrentLevel.Level };
                aColumnForm.Attributes.Add("data-href", (new UrlHelper(this.Builder.HtmlHelper.ViewContext.RequestContext)).Action(tableColumn.ColumnForm, tableColumn.ColumnArea, routeValues));
                aColumnForm.Attributes.Add("data-ispopup", tableColumn.ColumnFormIsPopUp.ToString().ToLower());

                if (tableColumn.ColumnNewTab)
                    aColumnForm.Attributes.Add("target", "_blank");

                // Help for the column alternative action (activated with CTRL or ALT)
                aColumnForm.Attributes.Add("q-help", "column-form");

                aColumnForm.InnerHtml = value;
            }

            switch (tableColumn.DataType)
            {
                    case ColumnDataType.Image:
                    {
                        if (((TableList<TModel>)this.Builder).HasHelpForm())
                        {
                            System.Web.Routing.RouteValueDictionary routeValueDictionary = new System.Web.Routing.RouteValueDictionary();

                            routeValueDictionary.Add("id", ((TableList<TModel>)Builder).TableKey.Evaluate(model));
                            string form = (((TableList<TModel>)this.Builder).Form.HelpForm.ToString()) + "_Show";
                            TagBuilder actionlink = TableUtils.MakeActionLinkImg<TModel>(Builder.HtmlHelper, form, routeValueDictionary, TableString.View.ToString(), null);
                            if (((TableList<TModel>)this.Builder).Form.OpenInPopup)
                            {
                                actionlink.MergeAttribute("data-modal-form", "true");
                                actionlink.MergeAttribute("data-table", this.Builder.TableId);
                            }
                            actionlink.InnerHtml += value;
                            value = actionlink.ToString();
                           
						}
                        tCell.InnerHtml += value;
                        break;
                    
                    }
                case ColumnDataType.Document:
                    {
                        TagBuilder a = new TagBuilder("a");
                        
                        a.Attributes.Add("href", tableColumn.DocumentUrl.Invoke(model));

                        if (tableColumn.ColumnHtmlAttributes.ContainsKey("target"))
                            a.Attributes.Add("target", tableColumn.ColumnHtmlAttributes["target"]);
						
                        a.Attributes.Add("rel", "tooltip");
                        a.Attributes.Add("title", TableString.Download.ToString());

                        if (this.Builder.TableType == Properties.TableType.SearchList)
                        {
                            if (!String.IsNullOrEmpty(value))
                            {
                                a.AddCssClass("download-button");
                                a.InnerHtml += TableString.Download.ToString();
                                tCell.InnerHtml += a;
                            }
                        }
                        else
                        {
                            a.InnerHtml += value;
                            TagBuilder i = new TagBuilder("i");

                            if (String.IsNullOrEmpty(value))
                            {
                                i.AddCssClass("glyphicons glyphicons-remove e-icon");
                                i.Attributes.Add("rel", "tooltip");
                                i.Attributes.Add("title", TableString.FileNotFound.ToString());
                                tCell.InnerHtml += i;
                            }
                            else
                            {
                                a.InnerHtml += i;
                                tCell.InnerHtml += a;
                            }
                        }
                    }
                    break;
                case ColumnDataType.Boolean:
                    {
                        var icon = Boolean.Parse(value) ? "glyphicons glyphicons-ok e-icon" : "glyphicons glyphicons-remove e-icon";
                        TagBuilder i = new TagBuilder("i");
                        i.AddCssClass(icon);
                        i.Attributes.Add("name", Guid.NewGuid().ToString());
                        i.Attributes.Add("value", Boolean.Parse(value).ToString());


                        tCell.InnerHtml += i;
                    }
                    break;
                case ColumnDataType.Currency:
                case ColumnDataType.Numeric:
                    {
                        tCell.AddCssClass("c-table__cell-numeric row-numeric");
                        if (hasColumnForm)
                            tCell.InnerHtml += aColumnForm;
                        else
                            tCell.InnerHtml += value;
                    }
                    break;
                case ColumnDataType.Text:
                    {
                        var _value = value;

                        if (this.Builder.TableType == Properties.TableType.SearchList && value.Length > 500)
                            _value = value.Substring(0, 500) + " (...)";
                        else if (value.Length > tableColumn.ColumnSize)
                        {
                            tCell.Attributes.Add("title", value);
                            _value = value.Substring(0, tableColumn.ColumnSize) + " (...)";
                        }

                        if (hasColumnForm && aColumnForm != null)
                        {
                            aColumnForm.InnerHtml = HttpUtility.HtmlEncode(_value);
                            tCell.InnerHtml += aColumnForm;
                        }
                        else
                            tCell.InnerHtml += HttpUtility.HtmlEncode(_value);
                    }
                    break;
                case ColumnDataType.HyperLink:
                    {
						if(!String.IsNullOrEmpty(value))
						{
							var _value = string.Format("<a href='{0}' target='_blank' class='column-data-link'>{1}</a>", value, HttpUtility.HtmlEncode(value));/*FIX FOR TABBING: Added class column-data-link*/
							tCell.InnerHtml += _value;
						}
                    }
                    break;
                default:
                    {
                        if (hasColumnForm)
                            tCell.InnerHtml += aColumnForm;
                        else
                            tCell.InnerHtml += value;
                    }
                    break;
            }
        }

        public virtual TagBuilder RenderHeaderCell(TModel model, ITableColumnInternal<TModel> tableColumn)
        {
            TagBuilder thCell = new TagBuilder("th");

            thCell.Attributes.Add("style", ColumnUtils.GetCellStyle(tableColumn));
			
			// Last updated by [DSG] at [2018.07.02]
            // Add id to the header creating a link between td and th by adding td's attribute headers equal to the corresponding header id
            // For accessibility purposes (see Principle1.Guideline1_3.1_3_1.H43.MissingHeaderIds of the WCAG2 rules)
            string fieldID;
            if(tableColumn.IsActionsColumn) { 
                fieldID = "actions";
            } else { 
                fieldID = tableColumn.ColumnField;
            }
            String id = typeof(TModel).Name + "_" + this.Builder.TableId + "_" + fieldID;
            thCell.Attributes.Add("id", id);
            //New attribute as to be added so the header can be used in the javascript.
            //And doing the replace in the id breaks a lot of things.
            thCell.Attributes.Add("data-filter", id.Replace(".", "_")); 
            
            // Last updated by [CJP] at [2016.07.11]
            // Add css class to right align when column is numeric or currency
            if (tableColumn.DataType == ColumnDataType.Numeric || tableColumn.DataType == ColumnDataType.Currency)
            {
                thCell.Attributes.Add("elem-identifier", "TheadNumeric");
                thCell.AddCssClass("c-table__head-numeric");

                if (tableColumn.AggregationType != Helpers.ColumnAggregationType.NONE)
                    thCell.Attributes.Add("data-aggregation-type", tableColumn.AggregationType.ToString());

                var customeAttribute = tableColumn.CustomAttribute;
                if (customeAttribute is NumericAttribute)
                    thCell.Attributes.Add("data-decimals", (customeAttribute as NumericAttribute).Decimals.ToString());
                else if (customeAttribute is CurrencyAttribute)
                {
                    var curencyCulture = (customeAttribute as CurrencyAttribute).GetCurrencyWithCurrentCulture(HtmlHelpers.GetNumericCulture());
                    thCell.Attributes.Add("data-decimals", curencyCulture.NumberFormat.CurrencyDecimalDigits.ToString());
                }
            }

            if (tableColumn.IsActionsColumn)
            {
                thCell.Attributes.Add("elem-identifier", "TheadActions");
                thCell.AddCssClass("thead-actions");
            }			
			
			//Accessibility fix
			thCell.Attributes.Add("role", "columnheader");
			
            if (this.Builder.hasSorting && tableColumn.ColumnField != null && !tableColumn.IsActionsColumn)
            {
                thCell.InnerHtml += this.SorterRenderer.GetSortLink(tableColumn);
				
				//Accessibility fix
				if (tableColumn.ColumnField == this.Builder.Sorter.Column)
				{
					if(this.Builder.Sorter.Direction == GenioMVC.Helpers.Table.Sorting.SortDirection.Ascending)
						thCell.Attributes.Add("aria-sort", "ascending");
					else
						thCell.Attributes.Add("aria-sort", "descending");
				}
            }
            else
            {
                if (tableColumn.IsActionsColumn)
                {
                    TagBuilder thIcon = new TagBuilder("i");
                    thIcon.AddCssClass("glyphicons");
                    thIcon.AddCssClass("glyphicons-option-vertical");
                    thIcon.AddCssClass("e-icon");
                    thIcon.MergeAttribute("title", tableColumn.ColumnTitle);
					thCell.InnerHtml = thIcon.ToString();
                }
                else
                    thCell.SetInnerText(tableColumn.ColumnTitle);
            }

            return thCell;
        }
    }
}
