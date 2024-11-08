using System;
using OpenQA.Selenium;
using quidgest.uitests.core;
using quidgest.uitests.controls;

namespace quidgest.uitests.pages;


public class SeeMorePage: PageObject {

	private string id;
	public ListControl List => new ListControl(driver, id);

	public SeeMorePage(IWebDriver driver, string form, string fieldRef): base(driver) {
		if (string.IsNullOrEmpty(form)) throw new ArgumentException($"{nameof(form)} must contain value.");
		if (string.IsNullOrEmpty(fieldRef)) throw new ArgumentException($"{nameof(fieldRef)} must contain value.");

		var parts = fieldRef.Split('.',2);
		//example: Lnhfa_FactuValNome
		this.id = CapFirst(form) + "_" + CapFirst(parts[0]) + "Val" + CapFirst(parts[1]);
		wait.Until(c => driver.FindElement(By.Id(this.id)) != null );
	}

	private string CapFirst(string s)
	{
		if(s.Length == 0) return s;
		if(s.Length == 1) return s.ToUpperInvariant();
		return s.Substring(0,1).ToUpperInvariant() + s.Substring(1).ToLowerInvariant();
	}

	public void Cancel(){
		//Normal IWebElement SendKeys on a div throws an ElementNotInteractableException, had to use Actions Api
		var a = new OpenQA.Selenium.Interactions.Actions(driver);
		a.MoveToElement(driver.FindElement(By.Id(this.id)));
		a.Click();
		a.SendKeys(Keys.Escape);
		a.Perform();
	}

}
