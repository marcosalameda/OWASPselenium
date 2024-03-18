using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Models.Navigation;
using GenioMVC.Helpers.Menus;
using Lucene.Net.Store;
using GenioMVC.Helpers.Attributes;
using System.Threading;

namespace GenioMVC.Controllers
{
    public class MenuSearchController : ControllerExtention
    {
        // GET: /Menu/
        [ActionSessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
        public ActionResult Search(string searchString)
        {
            var results = MenuSearch.Search(UserContext.Current, searchString, UserContext.Current.User,
                Thread.CurrentThread.CurrentCulture);
            foreach(var result in results)
                result.MenuObj = Menus.FindMenu(result.Module, result.Id);
            return PartialView("_SearchResults", results);
        }
    }
}
