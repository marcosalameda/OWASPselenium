namespace quidgest.uitests.controls;

public class CollapsibleZoneControl : ControlObject
{
    private IWebElement toggle => m_control.FindElement(By.CssSelector(".q-group-collapsible__header button"));

    public CollapsibleZoneControl(IWebDriver driver, By containerLocator, string css)
        : base(driver, containerLocator, By.CssSelector(css))
    {
    }

    public bool IsToggling => m_control.GetAttribute("class").Contains("q-group-collapsible--toggling");

    public bool IsExpanded
    {
        get
        {
            WaitForToggling();
            return m_control.GetAttribute("class").Contains("q-group-collapsible--open");
        }
    }

    private void WaitForToggling()
    {
        if (IsToggling)
            wait.Until(c => !IsToggling);
    }

    public void Toggle()
    {
        toggle.Click();
        WaitForToggling();
    }
}
