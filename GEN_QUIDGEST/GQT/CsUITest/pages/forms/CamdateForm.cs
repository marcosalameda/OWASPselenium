using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamdateForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Camdate']"));

	public BaseInputControl LED_CAMDATE_FLDS_YEAR____ => new BaseInputControl(driver, "[data-identifier='LED_CAMDATE_FLDS_YEAR____']");
	public BaseInputControl LED_CAMDATE_FLDS_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_CAMDATE_FLDS_DATE____']");
	public BaseInputControl LED_CAMDATE_FLDS_DATETIME => new BaseInputControl(driver, "[data-identifier='LED_CAMDATE_FLDS_DATETIME']");
	public BaseInputControl LED_CAMDATE_FLDS_DATESECO => new BaseInputControl(driver, "[data-identifier='LED_CAMDATE_FLDS_DATESECO']");
	public BaseInputControl LED_CAMDATE_FLDS_TIME____ => new BaseInputControl(driver, "[data-identifier='LED_CAMDATE_FLDS_TIME____']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CamdateForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
