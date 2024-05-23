using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RegiaproForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Regiapro']"));

	public LookupControl IFF_REGIAPROCNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_REGIAPROCNTRYCOUNTRY_", "ValCodcntry_chzn");
	public BaseInputControl LED_REGIAPROREGIOREGIAO__ => new BaseInputControl(driver, "[data-identifier='LED_REGIAPROREGIOREGIAO__']");
	public LookupControl IFF_REGIAPROPAIS1COUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_REGIAPROPAIS1COUNTRY_", "ValCodcntry_chzn");
	public ListControl IFF_REGIAPROPSEUDIMOVEISS => new ListControl(driver, "ValImoveiss", "#Regiapro_ValImoveiss");
	public ListControl IFF_REGIAPROPSEUDIMOVEISL => new ListControl(driver, "ValImoveisl", "#Regiapro_ValImoveisl");
	public ListControl IFF_REGIAPROPSEUDIMOVEISG => new ListControl(driver, "ValImoveisg", "#Regiapro_ValImoveisg");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public RegiaproForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
