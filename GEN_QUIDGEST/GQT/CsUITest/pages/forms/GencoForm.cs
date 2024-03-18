using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GencoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Genco']"));

	public EnumControl LED_GENCO___GENREAGENCONT => new EnumControl(driver, "CONTAINER_LED_GENCO___GENREAGENCONT", "ValAgencont_chzn_Genco");
	public BaseInputControl LED_GENCO___GENREGENDER__ => new BaseInputControl(driver, "[data-identifier='LED_GENCO___GENREGENDER__']");
	public BaseInputControl LED_GENCO___GENREBACKCOLO => new BaseInputControl(driver, "[data-identifier='LED_GENCO___GENREBACKCOLO']");
	public BaseInputControl LED_GENCO___GENRETEXTCOLO => new BaseInputControl(driver, "[data-identifier='LED_GENCO___GENRETEXTCOLO']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public GencoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
