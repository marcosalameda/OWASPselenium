using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CammaskForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Cammask']"));

	public BaseInputControl LED_CAMMASK_FLDS_ZIPFIELD => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_ZIPFIELD']");
	public BaseInputControl LED_CAMMASK_FLDS_VATNUMBR => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_VATNUMBR']");
	public BaseInputControl LED_CAMMASK_FLDS_LICPLATE => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_LICPLATE']");
	public BaseInputControl LED_CAMMASK_FLDS_SSNUMBER => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_SSNUMBER']");
	public BaseInputControl LED_CAMMASK_FLDS_BANKNMBR => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_BANKNMBR']");
	public BaseInputControl LED_CAMMASK_FLDS_EMAILFLD => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_EMAILFLD']");
	public BaseInputControl LED_CAMMASK_FLDS_IBANFIEL => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_IBANFIEL']");
	public BaseInputControl LED_CAMMASK_FLDS_UPPRTEXT => new BaseInputControl(driver, "[data-identifier='LED_CAMMASK_FLDS_UPPRTEXT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CammaskForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
