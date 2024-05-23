using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LcextForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Lcext']"));

	public LookupControl IFF_LCEXT___LOCATGLN_____ => new LookupControl(driver, "CONTAINER_IFF_LCEXT___LOCATGLN_____", "ValCodlocat_chzn");
	public BaseInputControl LED_LCEXT___LCEXTGLNEXT__ => new BaseInputControl(driver, "[data-identifier='LED_LCEXT___LCEXTGLNEXT__']");
	public EnumControl LED_LCEXT___LCEXTSPACETYP => new EnumControl(driver, "CONTAINER_LED_LCEXT___LCEXTSPACETYP", "ValSpacetyp_chzn_Lcext");
	public BaseInputControl LED_LCEXT___LCEXTSPACEOBS => new BaseInputControl(driver, "[data-identifier='LED_LCEXT___LCEXTSPACEOBS']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LcextForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
