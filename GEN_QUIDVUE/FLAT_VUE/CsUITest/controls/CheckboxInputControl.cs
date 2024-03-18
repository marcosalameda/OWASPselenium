namespace quidgest.uitests.controls;

public class CheckboxInputControl : ControlObject
{
    //the input is hidden and not clickable, but its where we can fetch the value
    private IWebElement input => m_control.FindElement(By.CssSelector("input"));

    public CheckboxInputControl(IWebDriver driver, By containerLocator, string css) 
        : base(driver, containerLocator, By.CssSelector(css))
    {
    }

    public bool GetValue()
    {
        return input.Selected;
    }

    public void Toggle()
    {
        m_control.Click();
    }

    public void SetValue(bool val)
    {
        if (GetValue() != val)
            Toggle();
    }
}