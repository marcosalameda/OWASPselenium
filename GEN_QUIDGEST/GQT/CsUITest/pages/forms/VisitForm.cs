using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VisitForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Visit']"));

	public LookupControl IFF_VISIT___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_VISIT___EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_VISIT___VISITTITLE___ => new BaseInputControl(driver, "[data-identifier='LED_VISIT___VISITTITLE___']");
	public BaseInputControl LED_VISIT___VISITSTARTDT_ => new BaseInputControl(driver, "[data-identifier='LED_VISIT___VISITSTARTDT_']");
	public BaseInputControl LED_VISIT___VISITDTFIM___ => new BaseInputControl(driver, "[data-identifier='LED_VISIT___VISITDTFIM___']");
	public BaseInputControl IFF_VISIT___VISITDESCRIPT => new BaseInputControl(driver, "[data-identifier='IFF_VISIT___VISITDESCRIPT']");
	public BaseInputControl LED_VISIT___VISITTODOODIA => new BaseInputControl(driver, "[data-identifier='LED_VISIT___VISITTODOODIA']");
	public BaseInputControl LED_VISIT___VISITCOLOR___ => new BaseInputControl(driver, "[data-identifier='LED_VISIT___VISITCOLOR___']");
	public BaseInputControl LED_VISIT___VISITOBSERVAT => new BaseInputControl(driver, "[data-identifier='LED_VISIT___VISITOBSERVAT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public VisitForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
