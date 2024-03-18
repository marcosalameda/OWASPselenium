using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Properties;

namespace GenioMVC.Helpers.Table.Builder
{
    public class Timeline<TModel> : Table<TModel>
        where TModel : class
    {
        internal string timelineName { get; private set; }
        internal string[] SelectedRows { get; private set; }

        internal Timeline(HtmlHelper helper, bool edit)
            : base(helper, TableType.Timeline, edit, true, false, false)
        {            
            this.TableCssClass.Add("timeline");
        }

        public void SetName(string name)
        {
            this.timelineName = name;
        }

        public void SetSelectedIds(string[] selectedIds)
        {
            this.SelectedRows = selectedIds;
        }
    }
}