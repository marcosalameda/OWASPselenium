using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpconForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tpcon']"));

	public LookupControl IFF_TPCON___GENREGENDER__ => new LookupControl(driver, "CONTAINER_IFF_TPCON___GENREGENDER__", "ValCodgenre_chzn");
	public BaseInputControl LED_TPCON___TPCONTIPOCONT => new BaseInputControl(driver, "[data-identifier='LED_TPCON___TPCONTIPOCONT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public TpconForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
