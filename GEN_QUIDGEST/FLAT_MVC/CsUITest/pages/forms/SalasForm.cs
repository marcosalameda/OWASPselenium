using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class SalasForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Salas']"));

	public BaseInputControl LED_SALAS___ROOMSROOMNR__ => new BaseInputControl(driver, "[data-identifier='LED_SALAS___ROOMSROOMNR__']");
	public BaseInputControl LED_SALAS___ROOMSDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_SALAS___ROOMSDESIGNAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public SalasForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
