using System.Linq;

namespace quidgest.uitests.pages;

public class AppPage: PageObject {

    private IWebElement Container => driver.FindElement(By.ClassName("layout-container"));
    public IMenuControl Menu => new HorizontalMenuControl(driver);

	private By loginBtnLocator => By.Id("logon-menu-btn");
    private IWebElement loginBtn => driver.FindElement(loginBtnLocator);
    private By avatarLocator => By.Name("user-avatar");
    private IWebElement avatar => driver.FindElement(avatarLocator);

    public AppPage(IWebDriver driver) : base(driver) {
		string url = Configuration.Instance.BaseUrl;
		driver.Navigate().GoToUrl(url);

		wait.Until(c => Container);
	}

	private void WaitForLoading()
	{
		wait.Until(c => loginBtn);
	}

	public void ClickLogin()
    {
		WaitForLoading();
        loginBtn.Click();
	}

	public bool IsAuthenticated()
	{
        //TODO: should be a better wait for loading based on data-loading attribute
        wait.Until(c => avatar); 
        if (driver.FindElements(loginBtnLocator).Any())
			return false;
        if (driver.FindElements(avatarLocator).Any())
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
}