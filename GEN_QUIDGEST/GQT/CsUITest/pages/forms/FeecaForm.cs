using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FeecaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Feeca']"));

	public LookupControl IFF_FEECA___FLDS_DESCRIP_ => new LookupControl(driver, "CONTAINER_IFF_FEECA___FLDS_DESCRIP_", "ValCodflds_chzn");
	public BaseInputControl LED_FEECA___FEECAFEEDBACK => new BaseInputControl(driver, "[data-identifier='LED_FEECA___FEECAFEEDBACK']");
	public BaseInputControl LED_FEECA___FLDS_ATTACH__ => new BaseInputControl(driver, "[data-identifier='LED_FEECA___FLDS_ATTACH__']");
	public BaseInputControl LED_FEECA___FLDS_NPASSAGE => new BaseInputControl(driver, "[data-identifier='LED_FEECA___FLDS_NPASSAGE']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public FeecaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
