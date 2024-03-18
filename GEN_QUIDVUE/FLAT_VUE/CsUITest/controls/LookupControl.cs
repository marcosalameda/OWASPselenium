namespace quidgest.uitests.controls;

public class LookupControl : EnumControl
{
    protected IWebElement _seeMore => m_control.FindElement(By.CssSelector("[title=\"See more\"]"));

    public LookupControl(IWebDriver driver, By containerLocator, string controlId) 
        : base(driver, containerLocator, controlId)
    {
    }

    public void SeeMore()
    {
        //This should be testid = SeeMore, or testid = actions + testkey = SeeMore
        _seeMore.Click();
    }

}