using System.Linq;

namespace quidgest.uitests.pages;

public class AppPage: PageObject {

    private IWebElement Container => driver.FindElement(By.ClassName("layout-container"));

	public IMenuControl Menu => new VerticalMenuControl(driver, _menuTree);

	private By loginBtnLocator => By.Id("logon-menu-btn");
    private IWebElement loginBtn => Container.FindElement(loginBtnLocator);
    private By avatarLocator => By.Name("user-avatar");
    private IWebElement avatar => Container.FindElement(avatarLocator);

    public AppPage(IWebDriver driver) : base(driver) {
		string url = Configuration.Instance.BaseUrl;
		driver.Navigate().GoToUrl(url);

		wait.Until(c => Container);
	}

	private void WaitForLoading()
	{
		wait.Until(c => Container.GetAttribute("data-loading") != "true");
	}

	public void ClickLogin()
    {
		WaitForLoading();
        loginBtn.Click();
	}

	public bool IsAuthenticated()
	{
        WaitForLoading();
		//Until vue has a global way to determine layout loading state we have to hack it like this
		//making this method only usable for IsAuthenticated == true.
		//Don't use this for asserting IsAuthentication == false, it will throw exception.
		//To test when its ok to remove this add a Thread.Sleep(1000) to LogOn in AccountController
		// to simulate slow database access.
        wait.Until(c => avatar);
        if (Container.FindElements(avatarLocator).Any())
            return true;

		return false;
	}

	//Header
		//logo
		//avatar
	//Menu
	//MainContent
		//breadcrumbs
		//sidebar
	//Footer
		//version

	private readonly static MenuTree _menuTree = DeclareMenuTree();

    private static MenuTree DeclareMenuTree()
    {
        MenuTree res = new MenuTree();
		string module;

		module = "STY";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "21", "2");
		res.AddMenu(module, "22", "2");
		res.AddMenu(module, "221", "22");
		res.AddMenu(module, "CARDCENT", "22");
		res.AddMenu(module, "CARDTOP", "22");
		res.AddMenu(module, "CARDTHUMB", "22");
		res.AddMenu(module, "23", "2");
		res.AddMenu(module, "24", "2");
		res.AddMenu(module, "25", "2");
		res.AddMenu(module, "26", "2");
		res.AddMenu(module, "3", null);
		res.AddMenu(module, "31", "3");
		res.AddMenu(module, "AUTHENTICATION", "3");
		res.AddMenu(module, "33", "3");
		res.AddMenu(module, "34", "3");
		res.AddMenu(module, "35", "3");
		res.AddMenu(module, "351", "35");
		res.AddMenu(module, "352", "35");
		res.AddMenu(module, "353", "35");
		res.AddMenu(module, "354", "35");
		res.AddMenu(module, "355", "35");
		res.AddMenu(module, "356", "35");
		res.AddMenu(module, "357", "35");
		res.AddMenu(module, "3571", "357");
		res.AddMenu(module, "3572", "357");
		res.AddMenu(module, "358", "35");
		res.AddMenu(module, "3581", "358");
		res.AddMenu(module, "3582", "358");
		res.AddMenu(module, "359", "35");
		res.AddMenu(module, "36", "3");
		res.AddMenu(module, "4", null);
		res.AddMenu(module, "41", "4");
		res.AddMenu(module, "42", "4");
		res.AddMenu(module, "421", "42");
		res.AddMenu(module, "422", "42");
		res.AddMenu(module, "423", "42");
		res.AddMenu(module, "43", "4");
		module = "GQT";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "11", "1");
		res.AddMenu(module, "12", "1");
		res.AddMenu(module, "13", "1");
		res.AddMenu(module, "14", "1");
		res.AddMenu(module, "15", "1");
		res.AddMenu(module, "16", "1");
		res.AddMenu(module, "17", "1");
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "21", "2");
		res.AddMenu(module, "22", "2");
		res.AddMenu(module, "23", "2");
		res.AddMenu(module, "24", "2");
		res.AddMenu(module, "25", "2");
		res.AddMenu(module, "26", "2");
		res.AddMenu(module, "27", "2");
		res.AddMenu(module, "28", "2");
		res.AddMenu(module, "29", "2");
		res.AddMenu(module, "291", "29");
		res.AddMenu(module, "292", "29");
		res.AddMenu(module, "2A", "2");
		res.AddMenu(module, "2B", "2");
		res.AddMenu(module, "2C", "2");
		res.AddMenu(module, "2C1", "2C");
		res.AddMenu(module, "2C2", "2C");
		res.AddMenu(module, "2C3", "2C");
		res.AddMenu(module, "2D", "2");
		res.AddMenu(module, "2D1", "2D");
		res.AddMenu(module, "2D2", "2D");
		res.AddMenu(module, "3", null);
		res.AddMenu(module, "31", "3");
		res.AddMenu(module, "32", "3");
		res.AddMenu(module, "33", "3");
		res.AddMenu(module, "4", null);
		res.AddMenu(module, "41", "4");
		res.AddMenu(module, "42", "4");
		res.AddMenu(module, "43", "4");
		res.AddMenu(module, "44", "4");
		res.AddMenu(module, "45", "4");
		res.AddMenu(module, "46", "4");
		res.AddMenu(module, "47", "4");
		res.AddMenu(module, "48", "4");
		res.AddMenu(module, "49", "4");
		res.AddMenu(module, "4A", "4");
		res.AddMenu(module, "5", null);
		res.AddMenu(module, "51", "5");
		res.AddMenu(module, "52", "5");
		res.AddMenu(module, "53", "5");
		res.AddMenu(module, "54", "5");
		res.AddMenu(module, "55", "5");
		res.AddMenu(module, "56", "5");
		res.AddMenu(module, "57", "5");
		res.AddMenu(module, "58", "5");
		res.AddMenu(module, "59", "5");
		res.AddMenu(module, "5A", "5");
		res.AddMenu(module, "5B", "5");
		res.AddMenu(module, "6", null);
		res.AddMenu(module, "61", "6");
		res.AddMenu(module, "611", "61");
		res.AddMenu(module, "612", "61");
		res.AddMenu(module, "613", "61");
		res.AddMenu(module, "614", "61");
		res.AddMenu(module, "62", "6");
		res.AddMenu(module, "7", null);
		res.AddMenu(module, "71", "7");
		res.AddMenu(module, "8", null);
		res.AddMenu(module, "9", null);
		res.AddMenu(module, "91", "9");
		res.AddMenu(module, "92", "9");
		res.AddMenu(module, "93", "9");
		res.AddMenu(module, "A", null);
		res.AddMenu(module, "A1", "A");
		res.AddMenu(module, "A2", "A");
		res.AddMenu(module, "A3", "A");
		res.AddMenu(module, "A4", "A");
		res.AddMenu(module, "B", null);
		module = "PTN";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "11", "1");
		res.AddMenu(module, "111", "11");
		res.AddMenu(module, "112", "11");
		res.AddMenu(module, "113", "11");
		res.AddMenu(module, "114", "11");
		res.AddMenu(module, "115", "11");
		res.AddMenu(module, "12", "1");
		res.AddMenu(module, "121", "12");
		res.AddMenu(module, "13", "1");
		res.AddMenu(module, "14", "1");
		res.AddMenu(module, "15", "1");
		res.AddMenu(module, "151", "15");
		res.AddMenu(module, "152", "15");
		res.AddMenu(module, "153", "15");
		res.AddMenu(module, "154", "15");
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "21", "2");
		res.AddMenu(module, "22", "2");
		res.AddMenu(module, "23", "2");
		res.AddMenu(module, "3", null);
		res.AddMenu(module, "31", "3");
		res.AddMenu(module, "32", "3");
		res.AddMenu(module, "321", "32");
		res.AddMenu(module, "322", "32");
		res.AddMenu(module, "323", "32");
		res.AddMenu(module, "4", null);
		res.AddMenu(module, "41", "4");
		res.AddMenu(module, "42", "4");
		res.AddMenu(module, "43", "4");
		res.AddMenu(module, "44", "4");
		res.AddMenu(module, "45", "4");
		res.AddMenu(module, "5", null);
		res.AddMenu(module, "51", "5");
		res.AddMenu(module, "52", "5");
		module = "TBS";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "11", "1");
		res.AddMenu(module, "12", "1");
		res.AddMenu(module, "13", "1");
		res.AddMenu(module, "14", "1");
		res.AddMenu(module, "15", "1");
		res.AddMenu(module, "16", "1");
		res.AddMenu(module, "17", "1");
		res.AddMenu(module, "18", "1");
		res.AddMenu(module, "19", "1");
		res.AddMenu(module, "191", "19");
		res.AddMenu(module, "192", "19");
		res.AddMenu(module, "193", "19");
		module = "WMS";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "11", "1");
		res.AddMenu(module, "12", "1");
		res.AddMenu(module, "13", "1");
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "21", "2");
		res.AddMenu(module, "22", "2");
		res.AddMenu(module, "23", "2");
		res.AddMenu(module, "3", null);
		res.AddMenu(module, "31", "3");
		res.AddMenu(module, "32", "3");
		res.AddMenu(module, "4", null);
		res.AddMenu(module, "41", "4");
		res.AddMenu(module, "411", "41");
		res.AddMenu(module, "412", "41");
		res.AddMenu(module, "42", "4");
		res.AddMenu(module, "421", "42");
		res.AddMenu(module, "422", "42");
		res.AddMenu(module, "423", "42");
		res.AddMenu(module, "424", "42");
		res.AddMenu(module, "425", "42");
		res.AddMenu(module, "426", "42");
		res.AddMenu(module, "43", "4");
		res.AddMenu(module, "431", "43");
		res.AddMenu(module, "432", "43");
		res.AddMenu(module, "433", "43");
		res.AddMenu(module, "5", null);
		res.AddMenu(module, "51", "5");
		res.AddMenu(module, "52", "5");
		res.AddMenu(module, "53", "5");
		res.AddMenu(module, "54", "5");
		res.AddMenu(module, "55", "5");
		res.AddMenu(module, "6", null);
		res.AddMenu(module, "61", "6");
		res.AddMenu(module, "7", null);
		res.AddMenu(module, "71", "7");
		res.AddMenu(module, "711", "71");
		res.AddMenu(module, "72", "7");
		res.AddMenu(module, "73", "7");
		module = "REG";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "11", "1");
		module = "IMO";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "11", "1");
		res.AddMenu(module, "12", "1");
		res.AddMenu(module, "13", "1");
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "21", "2");
		res.AddMenu(module, "22", "2");
		res.AddMenu(module, "23", "2");
		res.AddMenu(module, "3", null);
        return res;
    }
}