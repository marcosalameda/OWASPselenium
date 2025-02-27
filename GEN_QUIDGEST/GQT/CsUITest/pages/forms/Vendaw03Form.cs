using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw03Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Vendaw03']"));

	public BaseInputControl LED_VENDAW03SALE_PREABORD => new BaseInputControl(driver, "[data-identifier='LED_VENDAW03SALE_PREABORD']");
	public BaseInputControl LED_VENDAW03SALE_HOMEWORK => new BaseInputControl(driver, "[data-identifier='LED_VENDAW03SALE_HOMEWORK']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Vendaw03Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
