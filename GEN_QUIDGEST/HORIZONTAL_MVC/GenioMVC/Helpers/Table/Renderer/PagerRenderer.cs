using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Builder;
using GenioMVC.Helpers.Table.Pagination;
using GenioMVC.Helpers.Table.Utils;

namespace GenioMVC.Helpers.Table.Renderer
{
    public class PagerRenderer<TModel> where TModel : class
    {
        private Table<TModel> Builder { get; set; }
        private TableRenderer<TModel> Renderer { get; set; }

        public PagerRenderer(TableRenderer<TModel> renderer)
        {
            this.Renderer = renderer;
            this.Builder = this.Renderer.Builder;
        }

        private bool CheckModeEnabled(WebGridPagerModes mode, WebGridPagerModes modeCheck)
        {
            return (mode & modeCheck) == modeCheck;
        }

        private string GetPageUrl(int pageNumber)
        {
            NameValueCollection queryString = new NameValueCollection(1);
            string page = this.Renderer.pageInput;
            queryString[page] = pageNumber.ToString();
            return TableUtils.GetPath<TModel>(Builder, queryString);
        }

        private string GetPagerButton(int pageNumber, string text = null, string title = null)
        {
            if (String.IsNullOrEmpty(text))
            {
                text = pageNumber.ToString();
            }
            TagBuilder linkTag = new TagBuilder("a");
            linkTag.AddCssClass("e-pagination__link");


            if (this.Builder.TableType == Properties.TableType.SearchList)
            {
                string pageInput = "p" + this.Builder.TableId;
                string click = "setFacet('" + pageInput + "', " + pageNumber.ToString() + ", " + 0 + ")";
                linkTag.Attributes.Add("style", "cursor: pointer");
                linkTag.MergeAttribute("href", "javascript:void(0);");
                linkTag.Attributes.Add("onclick", click);
            }
            else if (Builder.useAjax)
            {
                string click = "window." + this.Builder.TableId + ".Page('" + pageNumber.ToString() + "');";
                linkTag.MergeAttribute("href", "javascript:void(0);");
                linkTag.Attributes.Add("onclick", click);
            }
            else
            {
                linkTag.MergeAttribute("href", GetPageUrl(pageNumber));
            }

            if (!String.IsNullOrEmpty(title))
                linkTag.MergeAttribute("title", title);

            linkTag.SetInnerText(text);

            TagBuilder li = new TagBuilder("li");
            li.AddCssClass("e-pagination__item");
            li.InnerHtml = linkTag.ToString();
            return li.ToString();
        }

        private TagBuilder renderPaginationV1 (WebGridPagerModes mode, string firstText, string previousText, string nextText, string lastText)
        {
            int currentPage = Builder.Pager.PageNumber;
            double totalRows = Builder.Pager.TotalItems;
            int totalPages = (int)Math.Ceiling(totalRows / Builder.Pager.ItemsPerPage);
            int lastPage = totalPages;
            while (Builder.Pager.TotalItems == (lastPage * Builder.Pager.ItemsPerPage) + 1)
                lastPage--;

            int numericLinksCount = Builder.Pager.MaxDisplayedPages;

            TagBuilder divPager = new TagBuilder("div");
            divPager.Attributes.Add("elem-identifier", "Pagination");
            divPager.Attributes.Add("style", "display:flex");
            if (LayoutConfig.config.DbEditPagerPlacement == "left")
                divPager.AddCssClass("float-left");
            else
                divPager.AddCssClass("push-pagination-right");

            TagBuilder counter = new TagBuilder("div");
            if (Builder.hasCounter)
            {
                counter.AddCssClass("e-counter");
                TagBuilder counterImage = new TagBuilder("i");
                counterImage.AddCssClass("glyphicons glyphicons-sort e-counter__icon");
                counter.InnerHtml += counterImage.ToString();
                counter.Attributes.Add("elem-identifier", "DbeditCounter");
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("e-counter__text");
                span.InnerHtml += string.Format("{0}", Builder.Pager.TotalItems);
                counter.InnerHtml += span;
            }

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("e-pagination");

            if (CheckModeEnabled(mode, WebGridPagerModes.FirstLast) && currentPage > 2)
            {
                if (String.IsNullOrEmpty(firstText))
                {
                    firstText = "<<";
                }
                ul.InnerHtml += this.GetPagerButton(1, firstText, TableString.FirstPage.ToString());
            }
            if (CheckModeEnabled(mode, WebGridPagerModes.NextPrevious) && currentPage > 1)
            {
                if (String.IsNullOrEmpty(previousText))
                {
                    previousText = "<";
                }
                ul.InnerHtml += this.GetPagerButton(currentPage - 1, previousText, TableString.PreviousPage.ToString());
            }

            if (CheckModeEnabled(mode, WebGridPagerModes.Numeric) && (totalPages > 1))
            {
                int last = currentPage + (numericLinksCount / 2);
                int first = last - numericLinksCount + 1;
                if (last > lastPage)
                {
                    first -= last - lastPage;
                    last = lastPage;
                }
                if (first < 1)
                {
                    last = Math.Min(last + (1 - first), lastPage);
                    first = 1;
                }
                for (int i = first; i <= last; i++)
                {
                    if (i == Builder.Pager.PageNumber)
                    {
                        TagBuilder li = new TagBuilder("li");
                        li.AddCssClass("e-pagination__item active");
                        TagBuilder a = new TagBuilder("a");
                        a.AddCssClass("e-pagination__link current-page");
                        a.SetInnerText((i).ToString());
                        li.InnerHtml = a.ToString();

                        ul.InnerHtml += li;
                    }
                    else
                    {
                        ul.InnerHtml += this.GetPagerButton(i, i.ToString(), TableString.Page.ToString() + " " + i.ToString());
                    }
                }
            }

            if (CheckModeEnabled(mode, WebGridPagerModes.NextPrevious) && (currentPage < lastPage))
            {
                if (String.IsNullOrEmpty(nextText))
                {
                    nextText = ">";
                }
                ul.InnerHtml += this.GetPagerButton(currentPage + 1, nextText, TableString.NextPage.ToString());
            }
            if (CheckModeEnabled(mode, WebGridPagerModes.FirstLast) && (currentPage < lastPage - 1))
            {
                if (String.IsNullOrEmpty(lastText))
                {
                    lastText = ">>";
                }
                ul.InnerHtml += this.GetPagerButton(lastPage, lastText, TableString.LastPage.ToString());
            }

            divPager.InnerHtml += counter.ToString();
            divPager.InnerHtml += ul.ToString();

            return divPager;
        }

        private TagBuilder renderPaginationV2 (WebGridPagerModes mode, string firstText, string previousText, string nextText)
        {
            int currentPage = Builder.Pager.PageNumber;
			
            TagBuilder divPager = new TagBuilder("div");
            divPager.Attributes.Add("elem-identifier", "Pagination");
            divPager.Attributes.Add("style", "display:flex");
            if (LayoutConfig.config.DbEditPagerPlacement == "left")
                divPager.AddCssClass("float-left");
            else
                divPager.AddCssClass("push-pagination-right");

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("e-pagination");

            if (CheckModeEnabled(mode, WebGridPagerModes.FirstLast) && currentPage > 2)
            {
                if (String.IsNullOrEmpty(firstText))
                {
                    firstText = "<<";
                }
                ul.InnerHtml += this.GetPagerButton(1, firstText, TableString.FirstPage.ToString());
            }
            if (CheckModeEnabled(mode, WebGridPagerModes.NextPrevious) && currentPage > 1)
            {
                if (String.IsNullOrEmpty(previousText))
                {
                    previousText = "<";
                }
                ul.InnerHtml += this.GetPagerButton(currentPage - 1, previousText, TableString.PreviousPage.ToString());
            }
			
			if (currentPage > 1 || Builder.Pager.HasMore)
			{
				//  < 1/1 >  |  < N/.. >  |  < N/N >
				var pagNum = new TagBuilder("li");
				pagNum.AddCssClass("e-pagination__item");
				var pagNumSpan = new TagBuilder("span");
				pagNumSpan.AddCssClass("e-pagination__info");
				pagNumSpan.SetInnerText(string.Format("{0} / {1}", currentPage, !Builder.Pager.HasMore ? currentPage.ToString() : "..."));
				pagNum.InnerHtml += pagNumSpan;
				ul.InnerHtml += pagNum;
			}

            if (CheckModeEnabled(mode, WebGridPagerModes.NextPrevious) && Builder.Pager.HasMore)
            {
                if (String.IsNullOrEmpty(nextText))
                {
                    nextText = ">";
                }
                ul.InnerHtml += this.GetPagerButton(currentPage + 1, nextText, TableString.NextPage.ToString());
            }

            divPager.InnerHtml += ul.ToString();

            return divPager;
        }

        public TagBuilder ToHtml(WebGridPagerModes mode = WebGridPagerModes.All,
            string firstText = null, string previousText = null, string nextText = null, string lastText = null)
        {
            if (Builder.Pager.HasTotal)
                return renderPaginationV1(mode, firstText, previousText, nextText, lastText);
            else
                return renderPaginationV2(mode, firstText, previousText, nextText);
        }
    }
}
