using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FactyForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Facty']"));

	public BaseInputControl LED_FACTY___FACTYTYPE____ => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYTYPE____']");
	public BaseInputControl LED_FACTY___FACTYLAYRNAME => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYLAYRNAME']");
	public BaseInputControl LED_FACTY___FACTYICONURL_ => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYICONURL_']");
	public BaseInputControl LED_FACTY___FACTYSHADOWUR => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYSHADOWUR']");
	public BaseInputControl LED_FACTY___FACTYICONANCX => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYICONANCX']");
	public BaseInputControl LED_FACTY___FACTYICONANCY => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYICONANCY']");
	public BaseInputControl LED_FACTY___FACTYICONHEIG => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYICONHEIG']");
	public BaseInputControl LED_FACTY___FACTYICONWID_ => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYICONWID_']");
	public BaseInputControl LED_FACTY___FACTYPOPUPANX => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYPOPUPANX']");
	public BaseInputControl LED_FACTY___FACTYPOPUPANY => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYPOPUPANY']");
	public BaseInputControl LED_FACTY___FACTYSHADOWAX => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYSHADOWAX']");
	public BaseInputControl LED_FACTY___FACTYSHADOWAY => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYSHADOWAY']");
	public BaseInputControl LED_FACTY___FACTYSHADOWHE => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYSHADOWHE']");
	public BaseInputControl LED_FACTY___FACTYSHADOWWI => new BaseInputControl(driver, "[data-identifier='LED_FACTY___FACTYSHADOWWI']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public FactyForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
