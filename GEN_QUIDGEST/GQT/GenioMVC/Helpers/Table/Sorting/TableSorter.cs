using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using GenioMVC.Helpers.Table.Builder;

namespace GenioMVC.Helpers.Table.Sorting
{
    public class TableSorter
    {
        public const string SORT_COLUMN_QUERYSTRING = "s";
        public const string SORT_DIRECTION_QUERYSTRING = "d";

        public string Column { get; set; }
        public SortDirection Direction { get; set; }

        public bool InternalSorting { get; set; }

        public string qsSortColumn { get; set; }
        public string qsSortDirection { get; set; }

        public TableSorter(string column = null, SortDirection direction = null)
        {
            Column = column;
            Direction = direction ?? SortDirection.Ascending;

            this.InternalSorting = false;

            this.qsSortColumn = SORT_COLUMN_QUERYSTRING;
            this.qsSortDirection = SORT_DIRECTION_QUERYSTRING;
        }

        public void SetSortColumnQS(string sColumnQs)
        {
            this.qsSortColumn = sColumnQs;
        }

        public void SetSortDirectionQS(string sDirectionQs)
        {
            this.qsSortDirection = sDirectionQs;
        }

        public void UseInternalSorting()
        {
            this.InternalSorting = true;
        }

        internal void InternalSort<TModel>(Table<TModel> t) where TModel : class
        {
            if (!string.IsNullOrEmpty(t.Sorter.Column))
            {
                Columns.ITableColumnInternal<TModel> column = t.TableColumns.Where(x => x.ColumnField == t.Sorter.Column).FirstOrDefault();
                if (column != default(Columns.ITableColumnInternal<TModel>) && column.LambdaExpression != null)
                {
                    t.SetDataSource(OrderByField<TModel>(t.Data.AsQueryable<TModel>(), column.LambdaExpression, t.Sorter.Direction == SortDirection.Ascending));
                }
            }
        }

        private IQueryable<TModel> OrderByField<TModel>(IQueryable<TModel> q, Expression sortfield, bool ascending)
        {
            var p = Expression.Parameter(typeof(TModel), "p");
            var x = sortfield as LambdaExpression;

            return q.Provider.CreateQuery<TModel>(
                       Expression.Call(typeof(Queryable),
                                       ascending ? "OrderBy" : "OrderByDescending",
                                       new Type[] { q.ElementType, x.Body.Type },
                                       q.Expression,
                                       x));
        }
    }
}