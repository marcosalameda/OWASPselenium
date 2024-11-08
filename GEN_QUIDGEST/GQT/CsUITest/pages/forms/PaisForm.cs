using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PaisForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pais']"));

	public BaseInputControl LED_PAIS____CNTRYCOUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_PAIS____CNTRYCOUNTRY_']");
	public BaseInputControl LED_PAIS____CNTRYACTIVE__ => new BaseInputControl(driver, "[data-identifier='LED_PAIS____CNTRYACTIVE__']");
	public BaseInputControl LED_PAIS____CNTRYCODIGONR => new BaseInputControl(driver, "[data-identifier='LED_PAIS____CNTRYCODIGONR']");
	public BaseInputControl LED_PAIS____CNTRYALFA2___ => new BaseInputControl(driver, "[data-identifier='LED_PAIS____CNTRYALFA2___']");
	public BaseInputControl LED_PAIS____CNTRYALFA3___ => new BaseInputControl(driver, "[data-identifier='LED_PAIS____CNTRYALFA3___']");
	public BaseInputControl LED_PAIS____CNTRYFLAG____ => new BaseInputControl(driver, "[data-identifier='LED_PAIS____CNTRYFLAG____']");
	public BaseInputControl IFF_PAIS____PSEUDIMOVEL__ => new BaseInputControl(driver, "[data-identifier='IFF_PAIS____PSEUDIMOVEL__']");
	public ListControl IFF_PAIS____PSEUDPROPRIE1 => new ListControl(driver, "ValProprie1", "#Pais_ValProprie1");
	public ListControl IFF_PAIS____PSEUDPROPRIED => new ListControl(driver, "ValPropried", "#Pais_ValPropried");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public PaisForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
