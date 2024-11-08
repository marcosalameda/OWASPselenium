using System;
using OpenQA.Selenium;
using quidgest.uitests.core;
using quidgest.uitests.controls;

namespace quidgest.uitests.pages;


public class DBEditPage: PageObject {

	private string id;
	public ListControl List => new ListControl(driver, id, "form[data-form='" + id + "']");

	public DBEditPage(IWebDriver driver, string module, string menuId): base(driver) {
		if (string.IsNullOrEmpty(module)) throw new ArgumentException($"{nameof(module)} must contain value.");
		if (string.IsNullOrEmpty(menuId)) throw new ArgumentException($"{nameof(menuId)} must contain value.");
		
		this.id = module.ToUpperInvariant() + "_Menu_" + menuId;
		wait.Until(c => driver.FindElement(By.CssSelector("form[data-form='" + this.id + "']")) != null );
	}

}
