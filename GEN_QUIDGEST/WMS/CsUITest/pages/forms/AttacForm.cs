using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AttacForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Attac']"));

	public LookupControl IFF_ATTAC___ASSETNAME____ => new LookupControl(driver, "CONTAINER_IFF_ATTAC___ASSETNAME____", "ValCodasset_chzn");
	public BaseInputControl LED_ATTAC___ATTACATTACHED => new BaseInputControl(driver, "[data-identifier='LED_ATTAC___ATTACATTACHED']");
	public BaseInputControl LED_ATTAC___ATTACNOTE____ => new BaseInputControl(driver, "[data-identifier='LED_ATTAC___ATTACNOTE____']");
	public BaseInputControl LED_ATTAC___ATTACDOCUMENT => new BaseInputControl(driver, "[data-identifier='LED_ATTAC___ATTACDOCUMENT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AttacForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
