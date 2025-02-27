using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw04Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Vendaw04']"));

	public BaseInputControl LED_VENDAW04SALE_DTABORDA => new BaseInputControl(driver, "[data-identifier='LED_VENDAW04SALE_DTABORDA']");
	public BaseInputControl LED_VENDAW04SALE_APPROACH => new BaseInputControl(driver, "[data-identifier='LED_VENDAW04SALE_APPROACH']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Vendaw04Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
