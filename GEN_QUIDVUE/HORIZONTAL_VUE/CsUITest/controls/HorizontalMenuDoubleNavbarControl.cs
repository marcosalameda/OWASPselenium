using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace quidgest.uitests.controls;

public class HorizontalMenuDoubleNavbarControl : HorizontalMenuControl
{
    // Usamos localizadores By para que las esperas sean efectivas
    private By secondNavMenusLocator => By.ClassName("n-menu__navbar--double-l2");
    private By primaryMenusLocator => By.Id("menu-navbar");

    public HorizontalMenuDoubleNavbarControl(IWebDriver driver, MenuTree menuTree) : base(driver, menuTree)
    {
        // Esperamos a que la segunda barra de navegación esté presente
        wait.Until(d => d.FindElement(secondNavMenusLocator).Displayed);
    }

    protected override void WaitForLoading()
    {
        base.WaitForLoading();
        // Aseguramos que ambas barras estén listas
        wait.Until(d => d.FindElement(primaryMenusLocator).Displayed);
        wait.Until(d => d.FindElement(secondNavMenusLocator).Displayed);
    }

    protected override void ClickParentRecursive(string moduleId, MenuTreeNode node)
    {
        var parent = node.Parent;
        if (parent != null)
            ClickParentRecursive(moduleId, parent);

        if (parent == null)
        {
            // --- CORRECCIÓN: El menú pertenece a la primera Navbar ---
            // Reemplazamos la variable 'menus' por una búsqueda segura
            var primaryMenus = wait.Until(d => d.FindElement(primaryMenusLocator));
            var liTarget = primaryMenus.FindElement(By.Id(moduleId + node.Id));

            wait.Until(d => liTarget.Displayed && liTarget.Enabled);
            liTarget.Click();
        }
        else
        {
            // --- CORRECCIÓN: El menú pertenece a la segunda Navbar ---
            var secondNav = wait.Until(d => d.FindElement(secondNavMenusLocator));
            var liTarget = secondNav.FindElement(By.Id(moduleId + node.Id));

            wait.Until(d => liTarget.Displayed && liTarget.Enabled);

            try
            {
                // Intentamos hacer clic en el desplegable si existe
                var btn = liTarget.FindElement(By.ClassName("dropdown-toggle"));
                btn.Click();
            }
            catch (NoSuchElementException)
            {
                // Si no es un desplegable, es un enlace directo
                liTarget.Click();
            }
            catch (ElementNotInteractableException)
            {
                // Si el elemento está tapado, forzamos el clic por JS
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", liTarget);
            }
        }
    }
}