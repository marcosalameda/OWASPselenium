using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AgregForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Agreg']"));

	public LookupControl IFF_AGREG___PROJEPROJECTO => new LookupControl(driver, "CONTAINER_IFF_AGREG___PROJEPROJECTO", "ValCodproje_chzn");
	public LookupControl IFF_AGREG___YEAR_YEAR____ => new LookupControl(driver, "CONTAINER_IFF_AGREG___YEAR_YEAR____", "ValCodyear_chzn");
	public BaseInputControl LED_AGREG___AGREGVALUE___ => new BaseInputControl(driver, "[data-identifier='LED_AGREG___AGREGVALUE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AgregForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
