using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamnumForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Camnum']"));

	public BaseInputControl LED_CAMNUM__FLDS_NPASSAGE => new BaseInputControl(driver, "[data-identifier='LED_CAMNUM__FLDS_NPASSAGE']");
	public BaseInputControl LED_CAMNUM__FLDS_DURATION => new BaseInputControl(driver, "[data-identifier='LED_CAMNUM__FLDS_DURATION']");
	public BaseInputControl LED_CAMNUM__FLDS_PRICE___ => new BaseInputControl(driver, "[data-identifier='LED_CAMNUM__FLDS_PRICE___']");
	public BaseInputControl LED_CAMNUM__FLDS_PRECOBIL => new BaseInputControl(driver, "[data-identifier='LED_CAMNUM__FLDS_PRECOBIL']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CamnumForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
