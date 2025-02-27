using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamdocsForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Camdocs']"));

	public BaseInputControl LED_CAMDOCS_FLDS_LOGO____ => new BaseInputControl(driver, "[data-identifier='LED_CAMDOCS_FLDS_LOGO____']");
	public BaseInputControl LED_CAMDOCS_FLDS_ATTACH__ => new BaseInputControl(driver, "[data-identifier='LED_CAMDOCS_FLDS_ATTACH__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public CamdocsForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
