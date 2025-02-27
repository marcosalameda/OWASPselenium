using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Propr02Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Propr02']"));

	public BaseInputControl LED_PROPR02_PROPRQTD_WC__ => new BaseInputControl(driver, "[data-identifier='LED_PROPR02_PROPRQTD_WC__']");
	public BaseInputControl LED_PROPR02_PROPRQTDQUART => new BaseInputControl(driver, "[data-identifier='LED_PROPR02_PROPRQTDQUART']");
	public BaseInputControl LED_PROPR02_PROPRM2______ => new BaseInputControl(driver, "[data-identifier='LED_PROPR02_PROPRM2______']");
	public BaseInputControl LED_PROPR02_PROPRDTDISPON => new BaseInputControl(driver, "[data-identifier='LED_PROPR02_PROPRDTDISPON']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Propr02Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
