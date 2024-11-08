using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessohisForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pessohis']"));

	public BaseInputControl IFF_PESSOHISPSEUDFIELD002 => new BaseInputControl(driver, "[data-identifier='IFF_PESSOHISPSEUDFIELD002']");
	public BaseInputControl LED_PESSOHISPESSOIDFUNCIO => new BaseInputControl(driver, "[data-identifier='LED_PESSOHISPESSOIDFUNCIO']");
	public BaseInputControl LED_PESSOHISPESSONAME____ => new BaseInputControl(driver, "[data-identifier='LED_PESSOHISPESSONAME____']");
	public ListControl IFF_PESSOHISPSEUDFIELD001 => new ListControl(driver, "ValField001", "#Pessohis_ValField001");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public PessohisForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
