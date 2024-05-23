using GenioMVC.Helpers.Table.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Table.Builder
{

    public class Multiform<TModel> : Table<TModel>
        where TModel : class
    {
        public String HelpForm { get; protected set; }
        public String InsertLink { get; protected set; }
        public String BuilderForm { get; protected set; }

        public Multiform(HtmlHelper helper, TableType type, bool edit, bool canFilter, bool canPage) : base(helper, type, edit, canPage, false, false) {
            this.hasPagination = canPage;
        }

        public void SetRequestLink(string link)
        {
            this.requestsLink = link;
        }

        public void SetInsertLink(string link)
        {
            this.InsertLink = link;
        }

        public void SetBuilderForm(string form)
        {
            this.BuilderForm = form;
        }

        public void SetPermissions(bool canView = true, bool canInsert = true, bool canEdit = true,
    bool canDuplicate = true, bool canDelete = true)
        {
            this.Permissions = new TablePermissions(true, canInsert, canEdit, canDuplicate, canDelete, this.IsInEditMode);
        }

        public void SetForm(string helpForm)
        {
            this.HelpForm = helpForm;
        }

    }
}
