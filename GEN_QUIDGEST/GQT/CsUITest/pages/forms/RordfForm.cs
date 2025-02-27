using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RordfForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Rordf']"));

	public BaseInputControl LED_RORDF___RORDFORDER___ => new BaseInputControl(driver, "[data-identifier='LED_RORDF___RORDFORDER___']");
	public BaseInputControl LED_RORDF___RORDFTITLE___ => new BaseInputControl(driver, "[data-identifier='LED_RORDF___RORDFTITLE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public RordfForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
