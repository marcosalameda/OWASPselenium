using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EmpreForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Empre']"));

	public BaseInputControl LED_EMPRE___CMPNYLOGO____ => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYLOGO____']");
	public BaseInputControl LED_EMPRE___CMPNYDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYDESIGNAT']");
	public BaseInputControl LED_EMPRE___CMPNYACRONYM_ => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYACRONYM_']");
	public BaseInputControl LED_EMPRE___CMPNYNIF_____ => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYNIF_____']");
	public BaseInputControl LED_EMPRE___CMPNYTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYTELEPHON']");
	public BaseInputControl LED_EMPRE___CMPNYEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYEMAIL___']");
	public LookupControl IFF_EMPRE___CNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_EMPRE___CNTRYCOUNTRY_", "ValCodcntry_chzn");
	public BaseInputControl LED_EMPRE___CMPNYQTDPESSO => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYQTDPESSO']");
	public BaseInputControl LED_EMPRE___CMPNYHEADLOC_ => new BaseInputControl(driver, "[data-identifier='LED_EMPRE___CMPNYHEADLOC_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EmpreForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
