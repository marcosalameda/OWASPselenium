using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace quidgest.uitests.controls;

public class HorizontalMenuControl : PageObject, IMenuControl
{
    // Cambiamos a localizadores para que el Wait pueda buscarlos en el momento justo
    private By navbarLocator => By.Id("main-header-navbar");
    private By modulesLocator => By.ClassName("modules__container");
    private By menusLocator => By.Id("menu-navbar");

    protected MenuTree _menuTree;

    public HorizontalMenuControl(IWebDriver driver, MenuTree menuTree) : base(driver)
    {
        _menuTree = menuTree;
        // Esperamos a que la estructura básica del menú esté presente
        wait.Until(d => d.FindElement(navbarLocator).Displayed);
        wait.Until(d => d.FindElement(menusLocator).Displayed);
    }

    protected virtual void WaitForLoading()
    {
        // Aseguramos que los contenedores no solo existan, sino que sean visibles
        wait.Until(d => d.FindElement(menusLocator).Displayed);
        wait.Until(d => d.FindElement(modulesLocator).Displayed);
    }

    public void ActivateMenu(string moduleId, string itemId)
    {
        WaitForLoading();
        var menuNode = _menuTree.FindMenu(moduleId, itemId);
        ClickParentRecursive(moduleId, menuNode);
    }

    protected virtual void ClickParentRecursive(string moduleId, MenuTreeNode node)
    {
        var parent = node.Parent;
        if (parent != null)
            ClickParentRecursive(moduleId, parent);

        // ARREGLO ERROR 4: Esperamos a que el enlace sea clicable antes de interactuar
        var selector = $"#{moduleId}{node.Id} a";
        var liTarget = wait.Until(d => {
            var el = d.FindElement(By.CssSelector(selector));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        liTarget.Click();
    }

    public void ActivateModule(string moduleId)
    {
        WaitForLoading();
        var modulesContainer = driver.FindElement(modulesLocator);
        var currentModule = modulesContainer.FindElement(By.CssSelector(".modules__header"));

        var cm = currentModule.GetAttribute("data-key");
        if (cm == moduleId) return;

        modulesContainer.Click();

        // Esperamos a que la opción del módulo aparezca tras el clic anterior
        var item = wait.Until(d => {
            var el = d.FindElement(ByData.Key(moduleId));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        item.Click();
    }

    public void ActivateFavorite(string itemId)
    {
        var bookmarksContainer = driver.FindElement(By.ClassName("bookmarks__container"));
        bookmarksContainer.Click();

        var item = wait.Until(d => {
            var el = d.FindElement(ByData.Key(itemId));
            return (el.Displayed && el.Enabled) ? el : null;
        });

        item.Click();
    }

    public int GetMenuCount(string moduleId, string itemId)
    {
        WaitForLoading();
        var menuNode = wait.Until(d => d.FindElement(By.Id(moduleId + itemId)));

        try
        {
            IWebElement counterElem = menuNode
                .FindElement(By.CssSelector("a"))
                .FindElement(By.CssSelector("span"))
                .FindElement(By.CssSelector("span"));

            string counterElemText = counterElem?.GetDomProperty("innerText");
            return counterElemText == null ? 0 : counterElemText.ToInteger(0);
        }
        catch (NoSuchElementException)
        {
            return 0;
        }
    }

    public int GetBookmarkCount()
    {
        var bookmarksContainer = driver.FindElement(By.ClassName("bookmarks__container"));
        return bookmarksContainer.FindElements(By.CssSelector(".bookmarks__btn--link")).Count;
    }

    // Métodos vacíos mantenidos por interfaz
    public bool HasBookmark(string name = null) => false;
    public void AddBookmark(string name = null) { }
    public void RemoveBookmark(string name = null) { }
    public void ActivateBookmark(string name = null) { }
}