using System;
using OpenQA.Selenium;

namespace quidgest.uitests.controls;

//LookupEdit
public class LookupControl: EnumControl {

	public LookupControl(IWebDriver driver, string containerId, string chznSelectId): base(driver, containerId, chznSelectId) {
	}

	public void SeeMore()
	{
		container.Click();
		container.FindElement(By.CssSelector("li#seeMore")).Click();
	}

	public void Insert()
	{
		container.Click();
		container.FindElement(By.CssSelector("li#supportForm")).Click();
	}

}
