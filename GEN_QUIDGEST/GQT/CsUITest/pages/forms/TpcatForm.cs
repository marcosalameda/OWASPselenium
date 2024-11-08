using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TpcatForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tpcat']"));

	public BaseInputControl LED_TPCAT___CATTPTPCATEGO => new BaseInputControl(driver, "[data-identifier='LED_TPCAT___CATTPTPCATEGO']");
	public LookupControl IFF_TPCAT___SBCATSUBCATEG => new LookupControl(driver, "CONTAINER_IFF_TPCAT___SBCATSUBCATEG", "ValCodsbcat_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public TpcatForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
