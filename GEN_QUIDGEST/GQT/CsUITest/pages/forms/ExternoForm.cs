using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ExternoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Externo']"));

	public LookupControl IFF_EXTERNO_CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_EXTERNO_CMPNYDESIGNAT", "ValCodempre_chzn");
	public BaseInputControl LED_EXTERNO_PESSONAME____ => new BaseInputControl(driver, "[data-identifier='LED_EXTERNO_PESSONAME____']");
	public EnumControl LED_EXTERNO_PESSOGENDER__ => new EnumControl(driver, "CONTAINER_LED_EXTERNO_PESSOGENDER__", "ValGender_chzn_Externo");
	public BaseInputControl IFF_EXTERNO_PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_EXTERNO_PSEUDNOVOGR06']");
	public BaseInputControl LED_EXTERNO_PESSOTELEPHON => new BaseInputControl(driver, "[data-identifier='LED_EXTERNO_PESSOTELEPHON']");
	public BaseInputControl LED_EXTERNO_PESSOEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_EXTERNO_PESSOEMAIL___']");
	public BaseInputControl LED_EXTERNO_PESSOPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_EXTERNO_PESSOPHOTOGRA']");
	public BaseInputControl IFF_EXTERNO_PSEUDOBRIGATO => new BaseInputControl(driver, "[data-identifier='IFF_EXTERNO_PSEUDOBRIGATO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ExternoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
