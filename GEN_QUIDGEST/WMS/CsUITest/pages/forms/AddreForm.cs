using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class AddreForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Addre']"));

	public EnumControl LED_ADDRE___ADDREADDRUSE_ => new EnumControl(driver, "CONTAINER_LED_ADDRE___ADDREADDRUSE_", "ValAddruse_chzn_Addre");
	public EnumControl LED_ADDRE___ADDREADDRTYPE => new EnumControl(driver, "CONTAINER_LED_ADDRE___ADDREADDRTYPE", "ValAddrtype_chzn_Addre");
	public BaseInputControl LED_ADDRE___ADDREADDRTEXT => new BaseInputControl(driver, "[data-identifier='LED_ADDRE___ADDREADDRTEXT']");
	public BaseInputControl LED_ADDRE___ADDREADDRCITY => new BaseInputControl(driver, "[data-identifier='LED_ADDRE___ADDREADDRCITY']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public AddreForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
