using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Regia_mlForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Regia_ml']"));

	public LookupControl IFF_REGIA_MLCNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_REGIA_MLCNTRYCOUNTRY_", "ValCodcntry_chzn");
	public BaseInputControl LED_REGIA_MLREGIOREGIAO__ => new BaseInputControl(driver, "[data-identifier='LED_REGIA_MLREGIOREGIAO__']");
	public LookupControl IFF_REGIA_MLPAIS1COUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_REGIA_MLPAIS1COUNTRY_", "ValCodcntry_chzn");
	public ListControl IFF_REGIA_MLPSEUDIMOVEISL => new ListControl(driver, "ValImoveisl", "#Regia_ml_ValImoveisl");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Regia_mlForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
