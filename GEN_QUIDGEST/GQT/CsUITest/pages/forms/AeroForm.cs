using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AeroForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Aero']"));

	public BaseInputControl LED_AERO____AERO_NAME____ => new BaseInputControl(driver, "[data-identifier='LED_AERO____AERO_NAME____']");
	public BaseInputControl LED_AERO____AERO_CODCMAER => new BaseInputControl(driver, "[data-identifier='LED_AERO____AERO_CODCMAER']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AeroForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
