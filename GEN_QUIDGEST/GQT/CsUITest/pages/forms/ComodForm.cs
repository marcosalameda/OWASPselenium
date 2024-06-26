using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ComodForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Comod']"));

	public LookupControl IFF_COMOD___PESS1NAME____ => new LookupControl(driver, "CONTAINER_IFF_COMOD___PESS1NAME____", "ValCodpesso_chzn");
	public LookupControl IFF_COMOD___PESS2NAME____ => new LookupControl(driver, "CONTAINER_IFF_COMOD___PESS2NAME____", "ValCodpesso_chzn");
	public LookupControl IFF_COMOD___EQUIPREGISTNR => new LookupControl(driver, "CONTAINER_IFF_COMOD___EQUIPREGISTNR", "ValCodequip_chzn");
	public BaseInputControl LED_COMOD___EQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_COMOD___EQUIPDESIGNAT']");
	public EnumControl LED_COMOD___EQUIPFREQUENC => new EnumControl(driver, "CONTAINER_LED_COMOD___EQUIPFREQUENC", "ValFrequenc_chzn_Comod");
	public BaseInputControl LED_COMOD___LENDILENDINNR => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDILENDINNR']");
	public BaseInputControl LED_COMOD___LENDISTART___ => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDISTART___']");
	public BaseInputControl LED_COMOD___LENDIWARNDT__ => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDIWARNDT__']");
	public BaseInputControl LED_COMOD___LENDIEND_____ => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDIEND_____']");
	public BaseInputControl LED_COMOD___LENDIOBSERVAT => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDIOBSERVAT']");
	public BaseInputControl LED_COMOD___LENDIRETURNDT => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDIRETURNDT']");
	public BaseInputControl LED_COMOD___LENDIRETURNED => new BaseInputControl(driver, "[data-identifier='LED_COMOD___LENDIRETURNED']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ComodForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
