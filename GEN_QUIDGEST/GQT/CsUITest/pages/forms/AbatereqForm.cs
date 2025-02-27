using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AbatereqForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Abatereq']"));

	public BaseInputControl IFF_ABATEREQPSEUDREQTEXT_ => new BaseInputControl(driver, "[data-identifier='IFF_ABATEREQPSEUDREQTEXT_']");
	public BaseInputControl LED_ABATEREQDECOMDECOMNR_ => new BaseInputControl(driver, "[data-identifier='LED_ABATEREQDECOMDECOMNR_']");
	public BaseInputControl LED_ABATEREQDECOMNOTE____ => new BaseInputControl(driver, "[data-identifier='LED_ABATEREQDECOMNOTE____']");
	public BaseInputControl IFF_ABATEREQPSEUDCOLLAPSE => new BaseInputControl(driver, "[data-identifier='IFF_ABATEREQPSEUDCOLLAPSE']");
	public BaseInputControl IFF_ABATEREQPSEUDABATETAB => new BaseInputControl(driver, "[data-identifier='IFF_ABATEREQPSEUDABATETAB']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public AbatereqForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
