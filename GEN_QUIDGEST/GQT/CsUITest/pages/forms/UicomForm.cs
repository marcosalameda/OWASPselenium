using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class UicomForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Uicom']"));

	public BaseInputControl LED_UICOM___UICOMTHUMBNAI => new BaseInputControl(driver, "[data-identifier='LED_UICOM___UICOMTHUMBNAI']");
	public BaseInputControl LED_UICOM___UICOMNAME____ => new BaseInputControl(driver, "[data-identifier='LED_UICOM___UICOMNAME____']");
	public BaseInputControl LED_UICOM___UICOMCATEGORY => new BaseInputControl(driver, "[data-identifier='LED_UICOM___UICOMCATEGORY']");
	public BaseInputControl LED_UICOM___UICOMMENUID__ => new BaseInputControl(driver, "[data-identifier='LED_UICOM___UICOMMENUID__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public UicomForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
