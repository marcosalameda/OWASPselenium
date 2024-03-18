using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers.Table.Properties;

namespace GenioMVC.Helpers.Table.Builder
{
    public class CheckList<TModel> : Table<TModel> 
        where TModel : class
    {
        internal string CheckListName { get; private set; }
        internal string[] SelectedRows { get; private set; }
        internal string CheckListSizeCss { get; private set; }

        internal bool IsExtended { get; private set; }
        internal string CheckListExtendedName { get; private set; }
        internal string CheckListExtendedSizeCss { get; private set; }

        internal CheckList(HtmlHelper helper, bool edit)
            : base(helper, TableType.CheckList, edit, false, false, false)
        {
            this.CheckListSizeCss = this.CheckListExtendedSizeCss = "input-medium";
            this.TableCssClass.Add("checkList");
        }

        public void SetSize(string cssClass)
        {
            if (!String.IsNullOrEmpty(cssClass))
            {
                this.TableColumns.Where(x => x.ColumnVisible && !x.IsCheckListColumn).First().AddCssClass(cssClass);
                this.CheckListSizeCss = cssClass;
            }
        }

        public void SetName(string name)
        {
            this.CheckListName = name;
        }

        public void SetSelectedIds(string[] selectedIds)
        {
            this.SelectedRows = selectedIds;
        }

        public void SetExtended(string name, string cssClass)
        {
            this.IsExtended = true;
            this.CheckListExtendedName = name;

            if(!String.IsNullOrEmpty(cssClass))
                this.CheckListExtendedSizeCss = cssClass;
        }
    }
}