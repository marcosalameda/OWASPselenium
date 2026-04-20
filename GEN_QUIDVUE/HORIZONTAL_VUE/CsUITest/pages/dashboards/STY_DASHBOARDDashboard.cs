[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class STY_DASHBOARDDashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetAlertControl ALERT => new WidgetAlertControl(driver, By.Id("w-ALERT_DEVOLUCAO"), ".q-widget");
    public WidgetFavoritesControl  => new WidgetFavoritesControl(driver);
}
