using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Tpeq1Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tpeq1']"));

	public LookupControl IFF_TPEQ1___FAMI1FAMILY__ => new LookupControl(driver, "CONTAINER_IFF_TPEQ1___FAMI1FAMILY__", "ValCodfamil_chzn");
	public BaseInputControl LED_TPEQ1___TPEQ1TPEQUCOD => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1TPEQUCOD']");
	public BaseInputControl LED_TPEQ1___TPEQ1NIVEL___ => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1NIVEL___']");
	public BaseInputControl LED_TPEQ1___TPEQ1TIPOEQUI => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1TIPOEQUI']");
	public BaseInputControl LED_TPEQ1___TPEQ1TPEQUPAI => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1TPEQUPAI']");
	public BaseInputControl LED_TPEQ1___TPEQ1BACKCOLO => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1BACKCOLO']");
	public BaseInputControl LED_TPEQ1___TPEQ1CORLETRA => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1CORLETRA']");
	public BaseInputControl LED_TPEQ1___TPEQ1PRECOMAX => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1PRECOMAX']");
	public BaseInputControl LED_TPEQ1___TPEQ1PRECOULT => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1PRECOULT']");
	public BaseInputControl LED_TPEQ1___TPEQ1SINCE___ => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1SINCE___']");
	public BaseInputControl LED_TPEQ1___TPEQ1QTDEQUIP => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1QTDEQUIP']");
	public BaseInputControl LED_TPEQ1___TPEQ1KIT_____ => new BaseInputControl(driver, "[data-identifier='LED_TPEQ1___TPEQ1KIT_____']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Tpeq1Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
