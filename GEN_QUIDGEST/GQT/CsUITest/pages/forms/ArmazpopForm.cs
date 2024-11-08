using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazpopForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Armazpop']"));

	public BaseInputControl IFF_ARMAZPOPPSEUDARMAZ01_ => new BaseInputControl(driver, "[data-identifier='IFF_ARMAZPOPPSEUDARMAZ01_']");
	public BaseInputControl IFF_ARMAZPOPPSEUDARMAZ02_ => new BaseInputControl(driver, "[data-identifier='IFF_ARMAZPOPPSEUDARMAZ02_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ArmazpopForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
