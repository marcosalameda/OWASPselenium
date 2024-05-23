using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LocatForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Locat']"));

	public LookupControl IFF_LOCAT___ENTITNAME____ => new LookupControl(driver, "CONTAINER_IFF_LOCAT___ENTITNAME____", "ValCodentit_chzn");
	public LookupControl IFF_LOCAT___FACILNAME____ => new LookupControl(driver, "CONTAINER_IFF_LOCAT___FACILNAME____", "ValCodfacil_chzn");
	public BaseInputControl LED_LOCAT___LOCATGLN_____ => new BaseInputControl(driver, "[data-identifier='LED_LOCAT___LOCATGLN_____']");
	public ListControl IFF_LOCAT___PSEUDLOCALEXT => new ListControl(driver, "ValLocalext", "#Locat_ValLocalext");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LocatForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
