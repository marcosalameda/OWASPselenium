using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using quidgest.uitests.core;

namespace quidgest.uitests.controls;


public class EnumControl: PageObject {

	protected string containerId;
	protected string chznSelectId;

	protected IWebElement container => driver.FindElement(By.Id(containerId));
	protected SelectElement _select => new SelectElement(container.FindElement(By.TagName("select")));

	public EnumControl(IWebDriver driver, string containerId, string chznSelectId): base(driver) {
		if (string.IsNullOrEmpty(containerId)) throw new ArgumentException($"{nameof(containerId)} must contain value.");

		this.containerId = containerId;
		this.chznSelectId = chznSelectId;

		WaitForLoad();
		wait.Until(c => container != null);
	}

	private void WaitForLoad()
	{
		wait.Until(c => _select.WrappedElement.GetAttribute("qcontrol-loaded")=="true");
	}

	public string GetValue() {		
		WaitForLoad();
		return _select.SelectedOption.GetAttribute("value");
	}

	public void SetValue(string val) {
		int ix = GetRowByPk(val);
		if(ix != -1)
		{
			container.Click();
			container.FindElement(By.Id(chznSelectId + "_o_" + ix)).Click();
		}
	}

	public void TypeText(string text)
	{
		var i = container.FindElement(By.TagName("input"));
		container.Click();
		i.SendKeys(text);
		i.SendKeys(Keys.Enter);
	}

	public string GetText()
	{
		WaitForLoad();
		return _select.SelectedOption.GetAttribute("text");
	}

	public int GetRowByPk(string pk)
	{
		WaitForLoad();
		return _select.Options.FindIndex(o => o.GetAttribute("value") == pk);
	}

	public int GetRowByText(string text)
	{
		WaitForLoad();
		return _select.Options.FindIndex(o => o.GetAttribute("text") == text);
	}


}
