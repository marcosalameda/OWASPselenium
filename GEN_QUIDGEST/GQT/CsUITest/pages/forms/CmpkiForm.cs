using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CmpkiForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Cmpki']"));

	public LookupControl IFF_CMPKI___TPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_CMPKI___TPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_CMPKI___CMPKIORDER___ => new BaseInputControl(driver, "[data-identifier='LED_CMPKI___CMPKIORDER___']");
	public LookupControl IFF_CMPKI___TPEQ1TIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_CMPKI___TPEQ1TIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_CMPKI___CMPKIQUANTIDA => new BaseInputControl(driver, "[data-identifier='LED_CMPKI___CMPKIQUANTIDA']");
	public BaseInputControl LED_CMPKI___CMPKICODE____ => new BaseInputControl(driver, "[data-identifier='LED_CMPKI___CMPKICODE____']");
	public BaseInputControl LED_CMPKI___CMPKIDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_CMPKI___CMPKIDESCRIPT']");
	public BaseInputControl LED_CMPKI___CMPKIURL_____ => new BaseInputControl(driver, "[data-identifier='LED_CMPKI___CMPKIURL_____']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CmpkiForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
