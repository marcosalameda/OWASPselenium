using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CfaqsForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Cfaqs']"));

	public BaseInputControl LED_CFAQS___CFAQSICON____ => new BaseInputControl(driver, "[data-identifier='LED_CFAQS___CFAQSICON____']");
	public BaseInputControl LED_CFAQS___CFAQSCATEGORY => new BaseInputControl(driver, "[data-identifier='LED_CFAQS___CFAQSCATEGORY']");
	public BaseInputControl LED_CFAQS___CFAQSDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_CFAQS___CFAQSDESCRIPT']");
	public ListControl IFF_CFAQS___PSEUDEXPFAQS_ => new ListControl(driver, "ValExpfaqs", "#Cfaqs_ValExpfaqs");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CfaqsForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
