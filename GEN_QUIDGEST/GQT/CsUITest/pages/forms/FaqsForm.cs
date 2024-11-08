using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FaqsForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Faqs']"));

	public BaseInputControl LED_FAQS____FAQS_QUESTION => new BaseInputControl(driver, "[data-identifier='LED_FAQS____FAQS_QUESTION']");
	public BaseInputControl IFF_FAQS____FAQS_ANSWER__ => new BaseInputControl(driver, "[data-identifier='IFF_FAQS____FAQS_ANSWER__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public FaqsForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
