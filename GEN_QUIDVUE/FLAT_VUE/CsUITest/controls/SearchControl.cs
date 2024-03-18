namespace quidgest.uitests.controls;

public class SearchControl : ControlObject
{
    private IWebElement input => m_control.FindElement(By.CssSelector("input[role='searchbox']"));
    private IWebElement clearBtn => m_control.FindElement(By.CssSelector(".q-table-search__field button"));

    public SearchControl(IWebDriver driver, By containerLocator, By controlLocator) 
		: base(driver, containerLocator, controlLocator)
    {
    }

    public void Search(string text)
    {
        input.SendKeys(text);
        input.SendKeys(Keys.Return);
    }

    public void Clear()
    {
        clearBtn.Click();
    }

}
