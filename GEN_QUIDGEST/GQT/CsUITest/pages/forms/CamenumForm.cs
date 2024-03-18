using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CamenumForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Camenum']"));

	public EnumControl LED_CAMENUM_FLDS_CLASSNUM => new EnumControl(driver, "CONTAINER_LED_CAMENUM_FLDS_CLASSNUM", "ValClassnum_chzn_Camenum");
	public EnumControl LED_CAMENUM_FLDS_CLASS___ => new EnumControl(driver, "CONTAINER_LED_CAMENUM_FLDS_CLASS___", "ValClass_chzn_Camenum");
	public BaseInputControl LED_CAMENUM_FLDS_LOGICENU => new BaseInputControl(driver, "[data-identifier='LED_CAMENUM_FLDS_LOGICENU']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CamenumForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
