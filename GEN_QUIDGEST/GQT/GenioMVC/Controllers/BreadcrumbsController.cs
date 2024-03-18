using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CSGenio.persistence;
using GenioMVC.Helpers.Menus;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;

namespace GenioMVC.Controllers
{
    public class BreadcrumbsController : ControllerBase
    {
        public ActionResult Index()
        {
			Breadcrumbs_ViewModel viewModel = new Breadcrumbs_ViewModel();

            foreach (var hLevel in Navigation.History)
            {
                if (hLevel.Level <= 0) break;
                if (DBConversion.ToLogic(hLevel.GetEntry("SkipIfJustOne")) == 0 || DBConversion.ToLogic(hLevel.GetEntry("hardReload")) == 1)
                {
                    string menuFont = Menus.FindMenu(UserContext.Current.User.CurrentModule, UserContext.Current.User.CurrentModule).Font;

                    string areaAlias = hLevel.Location.Controller.ToLower();
                    string areaPrimaryKey = (Navigation.CurrentLevel.Level == hLevel.Level && Navigation.CurrentLevel.FormMode == FormMode.List) ? null : DBConversion.ToString(Navigation.GetValue(areaAlias));
                    string humanKeyValues = hLevel.HumanRoutingDescriptionCache;
                    if (humanKeyValues == null)
                    {
                        humanKeyValues = GetHumanKeyToQMessage(areaAlias, areaPrimaryKey, "|");
                        hLevel.HumanRoutingDescriptionCache = humanKeyValues;
                    }

                    viewModel.Insert(0, hLevel.Location, hLevel.FormMode, menuFont, humanKeyValues);
                }

                if (hLevel.Level == 1)
                {
                    string menuAction = hLevel.Location.Action;
                    List<string> lstMenus = Menus.MenuTextPathActionName(UserContext.Current.User.CurrentModule, menuAction);
                    viewModel.SetPathToMenu(string.Join(" > ", lstMenus));
                }
            }

            return PartialView("_Breadcrumbs", viewModel);
		}

		//existe por causa do funcionamento com duplo layout(TopMenu)
        public ActionResult IndexTop()
        {
            Breadcrumbs_ViewModel viewModel = new Breadcrumbs_ViewModel();

            foreach (var hLevel in Navigation.History)
            {
                if (hLevel.Level <= 0) break;
                if (DBConversion.ToLogic(hLevel.GetEntry("SkipIfJustOne")) == 0 || DBConversion.ToLogic(hLevel.GetEntry("hardReload")) == 1)
                {
                    string menuFont = Menus.FindMenu(UserContext.Current.User.CurrentModule, UserContext.Current.User.CurrentModule).Font;

                    string areaAlias = hLevel.Location.Controller.ToLower();
                    string areaPrimaryKey = (Navigation.CurrentLevel.Level == hLevel.Level && Navigation.CurrentLevel.FormMode == FormMode.List) ? null : DBConversion.ToString(Navigation.GetValue(areaAlias));
                    string humanKeyValues = hLevel.HumanRoutingDescriptionCache;
                    if (humanKeyValues == null)
                    {
                        humanKeyValues = GetHumanKeyToQMessage(areaAlias, areaPrimaryKey, "|");
                        hLevel.HumanRoutingDescriptionCache = humanKeyValues;
                    }

                    viewModel.Insert(0, hLevel.Location, hLevel.FormMode, menuFont, humanKeyValues);
                }

                if (hLevel.Level == 1)
                {
                    string menuAction = hLevel.Location.Action;
                    List<string> lstMenus = Menus.MenuTextPathActionName(UserContext.Current.User.CurrentModule, menuAction);
                    viewModel.SetPathToMenu(string.Join(" > ", lstMenus));
                }
            }

            return PartialView("_BreadcrumbsTop", viewModel);
        }
    }
}
