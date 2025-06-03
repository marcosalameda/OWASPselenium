[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PTN_3L1Dashboard(IWebDriver driver, By containerLocator, string css) : BaseDashboardControl(driver, containerLocator, css)
{
    public WidgetMenuControl MENU3 => new WidgetMenuControl(driver, By.Id("w-Menu_111"), ".q-widget");
    public IWebElement COLAB => throw new NotImplementedException();
    public WidgetMenuControl MENU1 => new WidgetMenuControl(driver, By.Id("w-Menu_1211"), ".q-widget");
    public WidgetAlertControl ALERT1 => new WidgetAlertControl(driver, By.Id("w-ALERT_NCARDSDANGER"), ".q-widget");
    public WidgetAlertControl ALERT3 => new WidgetAlertControl(driver, By.Id("w-ALERT_NCARDSSUCESS"), ".q-widget");
    public IWebElement WID_EQUI => throw new NotImplementedException();
    public IWebElement EMPLOY => throw new NotImplementedException();
    public WidgetMenuControl MENU5 => new WidgetMenuControl(driver, By.Id("w-Menu_441"), ".q-widget");
    public WidgetAlertControl ALERT2 => new WidgetAlertControl(driver, By.Id("w-ALERT_NCARDSINFO"), ".q-widget");
    public IWebElement WID_INFO_EQUIP => throw new NotImplementedException();
    public WidgetAlertControl ALERT4 => new WidgetAlertControl(driver, By.Id("w-ALERT_NCARDSWARNING"), ".q-widget");
    public WidgetFavoritesControl FAVS => new WidgetFavoritesControl(driver);
    public WidgetMenuControl MENU2 => new WidgetMenuControl(driver, By.Id("w-Menu_211"), ".q-widget");
    public IWebElement GRAPH_COUNT => throw new NotImplementedException();
    public WidgetMenuControl MENU4 => new WidgetMenuControl(driver, By.Id("w-Menu_REPAIR_LIST"), ".q-widget");
}
