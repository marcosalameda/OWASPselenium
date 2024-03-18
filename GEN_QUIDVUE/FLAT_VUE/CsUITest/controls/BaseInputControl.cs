namespace quidgest.uitests.controls;

public class BaseInputControl : ControlObject
{
    public BaseInputControl(IWebDriver driver, By containerLocator, string css) 
        : base(driver, containerLocator, By.CssSelector(css))
    {
    }

    public string GetValue()
    {
        return m_control.GetAttribute("value");
    }

    public void SetValue(string val)
    {
        m_control.Clear();
        m_control.SendKeys(val);
    }
}