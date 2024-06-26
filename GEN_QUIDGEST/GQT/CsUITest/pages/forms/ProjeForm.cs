using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProjeForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Proje']"));

	public BaseInputControl LED_PROJE___PROJEPROJECTO => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJEPROJECTO']");
	public LookupControl IFF_PROJE___YEAR1YEAR____ => new LookupControl(driver, "CONTAINER_IFF_PROJE___YEAR1YEAR____", "ValCodyear_chzn");
	public BaseInputControl LED_PROJE___PROJEPRIMEIRO => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJEPRIMEIRO']");
	public BaseInputControl LED_PROJE___PROJEBEFORE__ => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJEBEFORE__']");
	public BaseInputControl LED_PROJE___PROJEFOLLOWIN => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJEFOLLOWIN']");
	public BaseInputControl LED_PROJE___PROJEULTIMO__ => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJEULTIMO__']");
	public BaseInputControl LED_PROJE___PROJESALDO1__ => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJESALDO1__']");
	public BaseInputControl LED_PROJE___PROJESALDO2__ => new BaseInputControl(driver, "[data-identifier='LED_PROJE___PROJESALDO2__']");
	public ListControl IFF_PROJE___PSEUDDESPESAS => new ListControl(driver, "ValDespesas", "#Proje_ValDespesas");
	public ListControl IFF_PROJE___PSEUDAGREGADO => new ListControl(driver, "ValAgregado", "#Proje_ValAgregado");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ProjeForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
