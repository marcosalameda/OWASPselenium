using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DilinForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Dilin']"));

	public LookupControl IFF_DILIN___DISPADISPANR_ => new LookupControl(driver, "CONTAINER_IFF_DILIN___DISPADISPANR_", "ValCoddispa_chzn");
	public BaseInputControl LED_DILIN___DILINLINENUMB => new BaseInputControl(driver, "[data-identifier='LED_DILIN___DILINLINENUMB']");
	public LookupControl IFF_DILIN___PRODUPRODUCT_ => new LookupControl(driver, "CONTAINER_IFF_DILIN___PRODUPRODUCT_", "ValCodprodu_chzn");
	public BaseInputControl LED_DILIN___DILINORDERED_ => new BaseInputControl(driver, "[data-identifier='LED_DILIN___DILINORDERED_']");
	public BaseInputControl LED_DILIN___DILINDELIVERE => new BaseInputControl(driver, "[data-identifier='LED_DILIN___DILINDELIVERE']");
	public BaseInputControl LED_DILIN___DILINOUTSTAND => new BaseInputControl(driver, "[data-identifier='LED_DILIN___DILINOUTSTAND']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public DilinForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
