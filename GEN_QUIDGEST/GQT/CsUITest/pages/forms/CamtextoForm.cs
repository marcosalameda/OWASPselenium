using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamtextoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Camtexto']"));

	public BaseInputControl LED_CAMTEXTOFLDS_TXTFIELD => new BaseInputControl(driver, "[data-identifier='LED_CAMTEXTOFLDS_TXTFIELD']");
	public BaseInputControl LED_CAMTEXTOFLDS_DESCRIP_ => new BaseInputControl(driver, "[data-identifier='LED_CAMTEXTOFLDS_DESCRIP_']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public CamtextoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
