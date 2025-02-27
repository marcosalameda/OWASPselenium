using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Vendaw02Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Vendaw02']"));

	public BaseInputControl LED_VENDAW02SALE_INTERESS => new BaseInputControl(driver, "[data-identifier='LED_VENDAW02SALE_INTERESS']");
	public BaseInputControl LED_VENDAW02SALE_SEMRFINA => new BaseInputControl(driver, "[data-identifier='LED_VENDAW02SALE_SEMRFINA']");
	public BaseInputControl LED_VENDAW02SALE_SEMCAPAC => new BaseInputControl(driver, "[data-identifier='LED_VENDAW02SALE_SEMCAPAC']");
	public BaseInputControl LED_VENDAW02SALE_DTQUALIF => new BaseInputControl(driver, "[data-identifier='LED_VENDAW02SALE_DTQUALIF']");
	public BaseInputControl LED_VENDAW02SALE_QUALIFIC => new BaseInputControl(driver, "[data-identifier='LED_VENDAW02SALE_QUALIFIC']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Vendaw02Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
