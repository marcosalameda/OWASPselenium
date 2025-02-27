using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GlobForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Glob']"));

	public BaseInputControl IFF_GLOB____GLOB_HOME____ => new BaseInputControl(driver, "[data-identifier='IFF_GLOB____GLOB_HOME____']");
	public BaseInputControl LED_GLOB____GLOB_APIURL__ => new BaseInputControl(driver, "[data-identifier='LED_GLOB____GLOB_APIURL__']");
	public BaseInputControl LED_GLOB____GLOB_LEGEND__ => new BaseInputControl(driver, "[data-identifier='LED_GLOB____GLOB_LEGEND__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public GlobForm(IWebDriver driver, FORM_MODE mode): base(driver) {
		this.mode = mode;
		wait.Until(c => form.GetAttribute("qform-loaded").Contains("true"));
	}

	public void Save() {
		saveBtn.Click();
	}

	public void Cancel() {
		cancelBtn.Click();
	}

}
