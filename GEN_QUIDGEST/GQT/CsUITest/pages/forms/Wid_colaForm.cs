using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_colaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Wid_cola']"));

	public BaseInputControl LED_WID_COLACMPNYLOGO____ => new BaseInputControl(driver, "[data-identifier='LED_WID_COLACMPNYLOGO____']");
	public BaseInputControl LED_WID_COLACMPNYDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_WID_COLACMPNYDESIGNAT']");
	public ListControl IFF_WID_COLAPSEUDPESSLIST => new ListControl(driver, "ValPesslist", "#Wid_cola_ValPesslist");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Wid_colaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
