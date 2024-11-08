using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegisForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Regis']"));

	public BaseInputControl LED_REGIS___REGISNAME____ => new BaseInputControl(driver, "[data-identifier='LED_REGIS___REGISNAME____']");
	public BaseInputControl LED_REGIS___REGISNIF_____ => new BaseInputControl(driver, "[data-identifier='LED_REGIS___REGISNIF_____']");
	public BaseInputControl LED_REGIS___REGISTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_REGIS___REGISTELEPHON']");
	public BaseInputControl LED_REGIS___REGISEMAIL1__ => new BaseInputControl(driver, "[data-identifier='LED_REGIS___REGISEMAIL1__']");
	public BaseInputControl LED_REGIS___REGISEMAIL2__ => new BaseInputControl(driver, "[data-identifier='LED_REGIS___REGISEMAIL2__']");
	public BaseInputControl IFF_REGIS___PSEUDOBRIGATO => new BaseInputControl(driver, "[data-identifier='IFF_REGIS___PSEUDOBRIGATO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public RegisForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
