using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Armaz01Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Armaz01']"));

	public BaseInputControl LED_ARMAZ01_WAREHWAREHCOD => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ01_WAREHWAREHCOD']");
	public BaseInputControl LED_ARMAZ01_WAREHACTIVITY => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ01_WAREHACTIVITY']");
	public BaseInputControl LED_ARMAZ01_WAREHWAREHDES => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ01_WAREHWAREHDES']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Armaz01Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
