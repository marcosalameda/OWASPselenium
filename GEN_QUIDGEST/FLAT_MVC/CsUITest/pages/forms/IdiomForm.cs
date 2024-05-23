using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class IdiomForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Idiom']"));

	public BaseInputControl LED_IDIOM___LANGULANGUA__ => new BaseInputControl(driver, "[data-identifier='LED_IDIOM___LANGULANGUA__']");
	public BaseInputControl LED_IDIOM___LANGUACRON___ => new BaseInputControl(driver, "[data-identifier='LED_IDIOM___LANGUACRON___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public IdiomForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
