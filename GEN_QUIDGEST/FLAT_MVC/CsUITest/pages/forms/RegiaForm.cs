using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Regia']"));

	public LookupControl IFF_REGIA___CNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_REGIA___CNTRYCOUNTRY_", "ValCodcntry_chzn");
	public BaseInputControl LED_REGIA___REGIOREGIAO__ => new BaseInputControl(driver, "[data-identifier='LED_REGIA___REGIOREGIAO__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public RegiaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
