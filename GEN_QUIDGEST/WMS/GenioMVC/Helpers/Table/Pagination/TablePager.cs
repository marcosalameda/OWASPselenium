using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using GenioMVC.Helpers.Table.Builder;

namespace GenioMVC.Helpers.Table.Pagination
{
    public class TablePager
    {
        public const string PAGE_NUMBER_QUERYSTRING = "p";

        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public bool HasMore { get; set; }
        public bool HasTotal { get; set; }
        public int TotalItems { get; set; }

        public int MaxDisplayedPages { get; set; }
        public bool InternalPagination { get; set; }

        public string qsPageNumber { get; set; }

        public TablePager(int pageNumber = 1, int itemsPerPage = 10, bool hasMore = false, bool hasTotal = false, int totalItems = 0)
        {
            this.PageNumber = pageNumber;
            this.ItemsPerPage = itemsPerPage;
            this.HasMore = hasMore;
            this.HasTotal = hasTotal;
            this.TotalItems = totalItems;

            this.MaxDisplayedPages = 5;
            this.InternalPagination = false;

            this.qsPageNumber = PAGE_NUMBER_QUERYSTRING;
        }

        public void SetPageNumberQS(string pageNumberQs)
        {
            this.qsPageNumber = pageNumberQs;
        }

        public void UseInternalPagination()
        {
            this.InternalPagination = true;
        }

        internal void InternalPaginate<TModel>(Table<TModel> t) where TModel : class
        {
            IEnumerable<TModel> items = t.Data;

            int start = (t.Pager.PageNumber - 1) * t.Pager.ItemsPerPage;
            int end = t.Pager.ItemsPerPage;

            if (start + end > items.Count())
            {
                end = t.Pager.ItemsPerPage + (items.Count() - (start + end));
            }

            t.SetDataSource(items.ToList().GetRange(start, end));
        }
    }
}