using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AnoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Ano']"));

	public BaseInputControl LED_ANO_____YEAR_YEAR____ => new BaseInputControl(driver, "[data-identifier='LED_ANO_____YEAR_YEAR____']");
	public BaseInputControl LED_ANO_____YEAR_YEARNUM_ => new BaseInputControl(driver, "[data-identifier='LED_ANO_____YEAR_YEARNUM_']");
	public ListControl IFF_ANO_____PSEUDTODASDES => new ListControl(driver, "ValTodasdes", "#Ano_ValTodasdes");
	public ListControl IFF_ANO_____PSEUDAGREGADO => new ListControl(driver, "ValAgregado", "#Ano_ValAgregado");
	public BaseInputControl LED_ANO_____YEAR_VALUE___ => new BaseInputControl(driver, "[data-identifier='LED_ANO_____YEAR_VALUE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AnoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
