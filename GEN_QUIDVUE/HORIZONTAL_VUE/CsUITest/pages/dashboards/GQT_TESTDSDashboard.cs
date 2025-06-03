[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GQT_TESTDSDashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetFavoritesControl FAVORITES => new WidgetFavoritesControl(driver);
    public WidgetAlertControl ALERT => new WidgetAlertControl(driver, By.Id("w-ALERT_NOTUSEDITEMS"), ".q-widget");
    public WidgetMenuControl ALL_LENDINGS => new WidgetMenuControl(driver, By.Id("w-Menu_111"), ".q-widget");
    public WidgetMenuControl MYLENDINGS => new WidgetMenuControl(driver, By.Id("w-Menu_121"), ".q-widget");
}
