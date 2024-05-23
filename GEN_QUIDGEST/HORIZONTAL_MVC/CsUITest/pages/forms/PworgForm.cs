using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PworgForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pworg']"));

	public LookupControl IFF_PWORG___PSW__NOME____ => new LookupControl(driver, "CONTAINER_IFF_PWORG___PSW__NOME____", "ValCodpsw_chzn");
	public LookupControl IFF_PWORG___ORGANORGANIZA => new LookupControl(driver, "CONTAINER_IFF_PWORG___ORGANORGANIZA", "ValCodorgan_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public PworgForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
