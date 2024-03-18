using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamauditForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Camaudit']"));

	public BaseInputControl LED_CAMAUDITFLDS_CREATUSE => new BaseInputControl(driver, "[data-identifier='LED_CAMAUDITFLDS_CREATUSE']");
	public BaseInputControl LED_CAMAUDITFLDS_CREATDAT => new BaseInputControl(driver, "[data-identifier='LED_CAMAUDITFLDS_CREATDAT']");
	public BaseInputControl LED_CAMAUDITFLDS_CREATHOU => new BaseInputControl(driver, "[data-identifier='LED_CAMAUDITFLDS_CREATHOU']");
	public BaseInputControl LED_CAMAUDITFLDS_CREATINS => new BaseInputControl(driver, "[data-identifier='LED_CAMAUDITFLDS_CREATINS']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CamauditForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
