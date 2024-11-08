using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenioMVC.Helpers.Table.Sorting
{
    public sealed class SortDirection
    {
        private readonly String name;
        private readonly int value;

        public static readonly SortDirection Ascending = new SortDirection(1, "ASC");
        public static readonly SortDirection Descending = new SortDirection(2, "DESC");

        private SortDirection(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }

        public static SortDirection getSortDirection(string direction)
        {
            return Ascending.ToString().Equals(direction) ? Ascending : Descending;
        }
    }
}