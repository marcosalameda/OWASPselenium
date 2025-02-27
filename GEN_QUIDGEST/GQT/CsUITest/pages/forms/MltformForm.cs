using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MltformForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Mltform']"));

	public BaseInputControl LED_MLTFORM_WAREHWAREHDES => new BaseInputControl(driver, "[data-identifier='LED_MLTFORM_WAREHWAREHDES']");
	public BaseInputControl LED_MLTFORM_WAREHWAREHCOD => new BaseInputControl(driver, "[data-identifier='LED_MLTFORM_WAREHWAREHCOD']");
	public BaseInputControl IFF_MLTFORM_PSEUDMLTFORM1 => new BaseInputControl(driver, "[data-identifier='IFF_MLTFORM_PSEUDMLTFORM1']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public MltformForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
