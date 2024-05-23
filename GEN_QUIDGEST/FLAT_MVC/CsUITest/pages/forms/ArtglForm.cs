using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtglForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Artgl']"));

	public BaseInputControl LED_ARTGL___GITEMITEMDES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTGL___GITEMITEMDES_']");
	public BaseInputControl LED_ARTGL___GITEMITEMGCOD => new BaseInputControl(driver, "[data-identifier='LED_ARTGL___GITEMITEMGCOD']");
	public BaseInputControl LED_ARTGL___GITEMDOCUMENT => new BaseInputControl(driver, "[data-identifier='LED_ARTGL___GITEMDOCUMENT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ArtglForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
