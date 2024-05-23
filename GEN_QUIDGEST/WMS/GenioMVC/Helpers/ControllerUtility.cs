using System.Collections.Generic;
using System.Web;
using GenioMVC.Models.Navigation;

namespace GenioMVC.Helpers
{

    public static class ControllerUtility
    {  
        /// <summary>
        /// Returns the view suffix according to the form mode
        /// </summary>
        /// <param name="formMode">The form mode</param>
        /// <returns>The view suffix</returns>
        public static string ViewActionName(FormMode formMode)
        {
            switch (formMode)
            {
                case FormMode.List:
                    return "List";
                case FormMode.Show:
                    return "Show";
                case FormMode.New:
                    return "New";
                case FormMode.Edit:
                    return "Edit";
                case FormMode.Duplicate:
                    return "Duplicate";
                case FormMode.Delete:
                    return "Delete";
            }
            return "";
        }
    }
}