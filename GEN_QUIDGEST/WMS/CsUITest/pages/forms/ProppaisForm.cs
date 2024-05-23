using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProppaisForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Proppais']"));

	public BaseInputControl LED_PROPPAISCNTRYCOUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_PROPPAISCNTRYCOUNTRY_']");
	public BaseInputControl LED_PROPPAISCNTRYACTIVE__ => new BaseInputControl(driver, "[data-identifier='LED_PROPPAISCNTRYACTIVE__']");
	public BaseInputControl IFF_PROPPAISPSEUDNOVOGR01 => new BaseInputControl(driver, "[data-identifier='IFF_PROPPAISPSEUDNOVOGR01']");
	public BaseInputControl LED_PROPPAISCNTRYCODIGONR => new BaseInputControl(driver, "[data-identifier='LED_PROPPAISCNTRYCODIGONR']");
	public BaseInputControl LED_PROPPAISCNTRYALFA2___ => new BaseInputControl(driver, "[data-identifier='LED_PROPPAISCNTRYALFA2___']");
	public BaseInputControl LED_PROPPAISCNTRYALFA3___ => new BaseInputControl(driver, "[data-identifier='LED_PROPPAISCNTRYALFA3___']");
	public BaseInputControl IFF_PROPPAISPSEUDPROPRIED => new BaseInputControl(driver, "[data-identifier='IFF_PROPPAISPSEUDPROPRIED']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ProppaisForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
