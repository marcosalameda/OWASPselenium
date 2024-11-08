using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmazForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Armaz']"));

	public BaseInputControl LED_ARMAZ___WAREHWAREHCOD => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ___WAREHWAREHCOD']");
	public BaseInputControl LED_ARMAZ___WAREHWAREHDES => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ___WAREHWAREHDES']");
	public BaseInputControl LED_ARMAZ___WAREHACTIVITY => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ___WAREHACTIVITY']");
	public BaseInputControl LED_ARMAZ___WAREHSHOWRECO => new BaseInputControl(driver, "[data-identifier='LED_ARMAZ___WAREHSHOWRECO']");
	public ListControl IFF_ARMAZ___PSEUDPESSARMA => new ListControl(driver, "ValPessarma", "#Armaz_ValPessarma");
	public IWebElement IFF_ARMAZ___PSEUDEXPOSETB => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ArmazForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
