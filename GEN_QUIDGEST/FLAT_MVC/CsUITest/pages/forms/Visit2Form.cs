using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Visit2Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Visit2']"));

	public LookupControl IFF_VISIT2__EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_VISIT2__EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_VISIT2__VISITTITLE___ => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITTITLE___']");
	public BaseInputControl LED_VISIT2__VISITSTARTDT_ => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITSTARTDT_']");
	public BaseInputControl LED_VISIT2__VISITDTFIM___ => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITDTFIM___']");
	public BaseInputControl LED_VISIT2__VISITDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITDESCRIPT']");
	public BaseInputControl LED_VISIT2__VISITTODOODIA => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITTODOODIA']");
	public BaseInputControl LED_VISIT2__VISITCOLOR___ => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITCOLOR___']");
	public BaseInputControl LED_VISIT2__VISITBACK____ => new BaseInputControl(driver, "[data-identifier='LED_VISIT2__VISITBACK____']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Visit2Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
