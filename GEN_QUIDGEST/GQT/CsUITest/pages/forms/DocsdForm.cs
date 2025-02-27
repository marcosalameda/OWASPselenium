using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DocsdForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Docsd']"));

	public BaseInputControl LED_DOCSD___OUDOCNRDOCSDA => new BaseInputControl(driver, "[data-identifier='LED_DOCSD___OUDOCNRDOCSDA']");
	public BaseInputControl LED_DOCSD___OUDOCDTDOCSDA => new BaseInputControl(driver, "[data-identifier='LED_DOCSD___OUDOCDTDOCSDA']");
	public BaseInputControl LED_DOCSD___OUDOCTITLE___ => new BaseInputControl(driver, "[data-identifier='LED_DOCSD___OUDOCTITLE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public DocsdForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
