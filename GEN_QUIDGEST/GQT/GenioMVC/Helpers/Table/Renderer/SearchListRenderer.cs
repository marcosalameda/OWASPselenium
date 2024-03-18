using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Helpers.Table.Scripts;
using GenioMVC.Helpers.Table.Utils;
using System.ComponentModel.DataAnnotations;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class SearchListRenderer<TModel> : TableRenderer<TModel> where TModel : class
    {
        new private SearchList<TModel> Builder { get; set; }

        public FilterRenderer<TModel> FilterRenderer { get; protected set; }

        public String tableFiltersInput { get; protected set; }

        public SearchListRenderer(Table<TModel> builder)
            : base(builder)
        {
            this.Builder = builder as SearchList<TModel>;
            this.FilterRenderer = new FilterRenderer<TModel>(this.Builder, this);
        }

        protected override TagBuilder Header()
        {
            TagBuilder tHead = new TagBuilder("thead");
            return tHead;
        }

        protected override TagBuilder Body()
        {
            TagBuilder tBody = new TagBuilder("tbody");

            foreach (TModel model in Builder.Data)
            {
                PropertyInfo key_property = model.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).FirstOrDefault();
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary();

                routeValueDictionary.Add("id", Builder.TableKey.Evaluate(model));

                TagBuilder tRow = new TagBuilder("tr");
                tRow.MergeAttribute("data-key", this.Builder.TableKey.Evaluate(model));

                tRow.AddCssClass("search-list-row");

                TagBuilder tMainCell = new TagBuilder("td");
                TagBuilder tDownload = new TagBuilder("td");
                //tDownload.Attributes.Add("style", "width:64px");
                tDownload.AddCssClass("searchListDownload");


                for (int i = 0; i < Builder.TableColumns.Count; i++)
                {
                    ITableColumnInternal<TModel> tc = Builder.TableColumns[i];

                    TagBuilder paragraph = new TagBuilder("p");

                    int tableSize = TableUtils.CalculateTableSize<TModel>(Builder.TableColumns);
                    string cellWidth = ColumnUtils.CalculateColumnWidth(tc.ColumnSize, tableSize);

                    if (tc.ColumnField == "ValZzstate")
                    {
                        var value = tc.Evaluate(model);
                        if (value != "0")
						{
                            tRow.Attributes.Add("class", "dirty-row");
                            tRow.Attributes.Add("rel", "tooltip");
                            tRow.Attributes.Add("title", Resources.Resources.ATENCAO__ESTA_FICHA_24725);
                        }
                    }
                    if (tc.ColumnVisible && !tc.IsDocument)
                    {
                        if (i == 1 && this.Builder.HasHelpForm())
                        {
                            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
                            if (this.Builder.Form.OpenInPopup)
                            {
                                htmlAttributes.Add("data-modal-form", true);
                                htmlAttributes.Add("data-table", this.Builder.TableId);
                                htmlAttributes.Add("data-modal-form-mode", "SHOW");
                            }
                            TagBuilder actionLink = TableUtils.MakeActionLink<TModel>(Builder.HtmlHelper, Builder.Form.HelpForm + "_Show", routeValueDictionary, GenerateBodyCell(model, tc).ToString(), htmlAttributes, Builder.FormController);
                            paragraph.InnerHtml += actionLink;

                        }
                        else
                            paragraph.InnerHtml += GenerateBodyCell(model, tc).ToString();

                        tMainCell.InnerHtml += paragraph;
                    }
                    else if (tc.ColumnVisible && tc.IsDocument)
                    {
                        tDownload.InnerHtml += GenerateBodyCell(model, tc).InnerHtml;
                    }

                }

                tRow.InnerHtml += tMainCell;
                if (Builder.HasFiles() || !String.IsNullOrEmpty(tDownload.InnerHtml))
                    tRow.InnerHtml += tDownload;

                tBody.InnerHtml += tRow;
            }

            return tBody;
        }





    }
}
