using System.Collections.Generic;
using System.Linq;

namespace quidgest.uitests.controls;

public class EnumControl : ControlObject
{
    protected IWebElement _display => m_control.FindElement(By.CssSelector("[role=combobox]"));
    protected IWebElement _input => m_control.FindElement(By.CssSelector("[role=combobox]"));
    protected IWebElement _clear => m_control.FindElement(By.CssSelector(".q-combobox__clear"));

    //dropdown is opened in a completely different global html location
    protected IWebElement _dropdown => driver.FindElement(ByData.Testid("combobox-dropdown"));
    protected IEnumerable<IWebElement> _rows => _dropdown.FindElements(By.CssSelector("[role=listbox] li"));

    public EnumControl(IWebDriver driver, By containerLocator, string controlId) 
        : base(driver, containerLocator, By.Id(controlId))
    {
        WaitForLoad();
    }

    private void WaitForLoad()
    {
        wait.Until(c => m_control.GetAttribute("data-loading") == null);
    }

    public string GetValue()
    {
        //TODO: how to I obtain the pk value from the component. I only have the text.
        WaitForLoad();
        return _display.GetAttribute("value");
    }

    public void Clear()
    {
        WaitForLoad();
        _clear.Click();
    }

    public void SetValue(string val)
    {
        Clear();
        TypeText(val);
        int ix = GetRowByText(val);
        if (ix != -1)
            _rows.ElementAt(ix).Click();
    }

    public void TypeText(string text)
    {
        WaitForLoad();
        _input.SendKeys(text);
    }

    public string GetText()
    {
        WaitForLoad();
        return _display.GetAttribute("value");
    }

    public int GetRowByPk(string pk)
    {
        //TODO: needs a data-key attribute
        WaitForLoad();
        return _rows.FindIndex(o => o.GetAttribute("data-key") == pk);
    }

    public int GetRowByText(string text)
    {
        //The text inside the element has an extra space and will not match
        WaitForLoad();
        return _rows.FindIndex(o => o.GetAttribute("aria-label") == text);
    }


}

