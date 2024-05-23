using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RelinForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Relin']"));

	public LookupControl IFF_RELIN___RECEINUMBER__ => new LookupControl(driver, "CONTAINER_IFF_RELIN___RECEINUMBER__", "ValCodrecei_chzn");
	public BaseInputControl LED_RELIN___ENTITNAME____ => new BaseInputControl(driver, "[data-identifier='LED_RELIN___ENTITNAME____']");
	public BaseInputControl LED_RELIN___RELINLINENUMB => new BaseInputControl(driver, "[data-identifier='LED_RELIN___RELINLINENUMB']");
	public LookupControl IFF_RELIN___PRODUPRODUCT_ => new LookupControl(driver, "CONTAINER_IFF_RELIN___PRODUPRODUCT_", "ValCodprodu_chzn");
	public BaseInputControl LED_RELIN___RELINORDERED_ => new BaseInputControl(driver, "[data-identifier='LED_RELIN___RELINORDERED_']");
	public BaseInputControl LED_RELIN___RELINRECEIVED => new BaseInputControl(driver, "[data-identifier='LED_RELIN___RELINRECEIVED']");
	public BaseInputControl LED_RELIN___RELINOUTSTAND => new BaseInputControl(driver, "[data-identifier='LED_RELIN___RELINOUTSTAND']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public RelinForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
