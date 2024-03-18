using System;
using System.Collections.Generic;

namespace GenioMVC.Helpers
{
    /// <summary>
    /// Define
    /// </summary>
    public interface ITreeBuilder
    {
        TreeBuilder Id(string id);
        TreeBuilder SetPermissions(bool canView = false, bool canInsert = false, bool canEdit = false, bool canDuplicate = false, bool canDelete = false);
        TreeBuilder AddTableAction(string action, string icon, string title, bool isRoutine = false, object htmlAttributes = null, bool isFollowUpAction = false, bool isAjaxAction = false);
        TreeBuilder DataSource(List<TreeNode> dataSource);
        TreeBuilder SetForm(string controller, string helpForm, bool openInPopup, bool repeatInsertion);
    }
}
