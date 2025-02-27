using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DespeForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Despe']"));

	public LookupControl IFF_DESPE___PROJEPROJECTO => new LookupControl(driver, "CONTAINER_IFF_DESPE___PROJEPROJECTO", "ValCodproje_chzn");
	public LookupControl IFF_DESPE___YEAR_YEAR____ => new LookupControl(driver, "CONTAINER_IFF_DESPE___YEAR_YEAR____", "ValCodyear_chzn");
	public LookupControl IFF_DESPE___AGREGVALUE___ => new LookupControl(driver, "CONTAINER_IFF_DESPE___AGREGVALUE___", "ValCodaggre_chzn");
	public BaseInputControl LED_DESPE___EXPENDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_DESPE___EXPENDESCRIPT']");
	public BaseInputControl LED_DESPE___EXPENVALUE___ => new BaseInputControl(driver, "[data-identifier='LED_DESPE___EXPENVALUE___']");
	public BaseInputControl LED_DESPE___EXPENPREVVAL_ => new BaseInputControl(driver, "[data-identifier='LED_DESPE___EXPENPREVVAL_']");
	public BaseInputControl LED_DESPE___EXPENYEARPREV => new BaseInputControl(driver, "[data-identifier='LED_DESPE___EXPENYEARPREV']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public DespeForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
