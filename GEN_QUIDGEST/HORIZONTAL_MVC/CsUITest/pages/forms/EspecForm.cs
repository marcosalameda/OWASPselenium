using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EspecForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Espec']"));

	public BaseInputControl LED_ESPEC___SPECIESPECIAL => new BaseInputControl(driver, "[data-identifier='LED_ESPEC___SPECIESPECIAL']");
	public EnumControl LED_ESPEC___SPECIAREATECN => new EnumControl(driver, "CONTAINER_LED_ESPEC___SPECIAREATECN", "ValAreatecn_chzn_Espec");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EspecForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
