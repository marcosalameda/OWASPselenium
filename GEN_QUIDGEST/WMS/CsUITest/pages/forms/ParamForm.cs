using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ParamForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Param']"));

	public LookupControl IFF_PARAM___KINDEDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_PARAM___KINDEDESIGNAT", "ValCodkinde_chzn");
	public BaseInputControl LED_PARAM___PARAMPARAMETE => new BaseInputControl(driver, "[data-identifier='LED_PARAM___PARAMPARAMETE']");
	public EnumControl LED_PARAM___PARAMDATATYPE => new EnumControl(driver, "CONTAINER_LED_PARAM___PARAMDATATYPE", "ValDatatype_chzn_Param");
	public EnumControl LED_PARAM___PARAMDECPLACE => new EnumControl(driver, "CONTAINER_LED_PARAM___PARAMDECPLACE", "ValDecplace_chzn_Param");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ParamForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
