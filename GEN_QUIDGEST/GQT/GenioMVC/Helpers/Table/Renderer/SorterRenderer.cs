using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Columns;
using GenioMVC.Helpers.Table.Sorting;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class SorterRenderer<TModel> where TModel : class
    {
        public const string ASC_VISUALIZER_HELPER = " ▲";
        public const string DESC_VISUALIZER_HELPER = " ▼";

        private Table<TModel> Builder { get; set; }
        private TableRenderer<TModel> Renderer { get; set; }

        public SorterRenderer(TableRenderer<TModel> renderer)
        {
            this.Renderer = renderer;
            this.Builder = this.Renderer.Builder;
        }

        private string GetSortUrl(ITableColumnInternal<TModel> tableColumn)
        {
            NameValueCollection queryString = new NameValueCollection(2);

            string sortCol = this.Renderer.sortInput;
            queryString[sortCol] = tableColumn.ColumnField;

            string sortDir = this.Renderer.sortDirInput;
            
            if (tableColumn.ColumnField == this.Builder.Sorter.Column)
                queryString[sortDir] = (this.Builder.Sorter.Direction == SortDirection.Ascending ? SortDirection.Descending.ToString() : SortDirection.Ascending.ToString());
            else
                queryString[sortDir] = SortDirection.Ascending.ToString();

            return TableUtils.GetPath<TModel>(this.Builder, queryString);
        }

        public TagBuilder GetSortLink(ITableColumnInternal<TModel> tableColumn)
        {
            TagBuilder linkTag = new TagBuilder("a");
			
			// Last updated by [DSG] at [2018.07.02]
            // Add id to the header creating a link between td and th by adding td's attribute headers equal to the corresponding header id
            // For accessibility purposes (see Principle1.Guideline1_3.1_3_1.H43.HeadersRequired of the WCAG2 rules);
            string fieldID;
            if(tableColumn.IsActionsColumn) { 
                fieldID = "actions";
            } else { 
                fieldID = tableColumn.ColumnField; 
            }
            String header = typeof(TModel).Name + "_" + this.Builder.TableId + "_" + fieldID;

            linkTag.Attributes.Add("headers", header);
			
			if(tableColumn.ColumnType == typeof(byte[]))
            {
                // No sort available for byte[] fields
                linkTag.MergeAttribute("href", "javascript:void(0);");
                string click = "window." + this.Builder.TableId + ".NoSort();";
                linkTag.Attributes.Add("onclick", click);
            }
            else if (this.Builder.useAjax)
            {
                string sort = tableColumn.ColumnField;
                string sortDir = SortDirection.Ascending.ToString();
                
                if (tableColumn.ColumnField == this.Builder.Sorter.Column)
                    sortDir = (this.Builder.Sorter.Direction == SortDirection.Ascending ? SortDirection.Descending.ToString() : SortDirection.Ascending.ToString());

                string click = "window." + this.Builder.TableId + ".Sort('" + sort + "','" + sortDir + "');";
                linkTag.MergeAttribute("href", "javascript:void(0);");
                linkTag.Attributes.Add("onclick", click);
            }
            else
            {
                linkTag.MergeAttribute("href", GetSortUrl(tableColumn));
            }

            string columnTitle = tableColumn.ColumnTitle;

            if (tableColumn.ColumnField == this.Builder.Sorter.Column)
			{
				//Accessibility fix
				TagBuilder sortDirTag = new TagBuilder("span");
				sortDirTag.Attributes.Add("aria-hidden", "true");
                string sortTitle = (this.Builder.Sorter.Direction == SortDirection.Ascending ? ASC_VISUALIZER_HELPER : DESC_VISUALIZER_HELPER);
				sortDirTag.SetInnerText(sortTitle);
				
				columnTitle += sortDirTag.ToString();
			}

            //linkTag.SetInnerText(columnTitle);
            linkTag.InnerHtml = columnTitle;

            return linkTag;
        }
    }
}