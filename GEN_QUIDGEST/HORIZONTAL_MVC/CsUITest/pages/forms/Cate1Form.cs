using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Cate1Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Cate1']"));

	public BaseInputControl LED_CATE1___CATE1ABBREVIA => new BaseInputControl(driver, "[data-identifier='LED_CATE1___CATE1ABBREVIA']");
	public BaseInputControl LED_CATE1___CATE1CATEGORY => new BaseInputControl(driver, "[data-identifier='LED_CATE1___CATE1CATEGORY']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Cate1Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
