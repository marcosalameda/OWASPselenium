using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class DentrForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Dentr']"));

	public LookupControl IFF_DENTR___CNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_DENTR___CNTRYCOUNTRY_", "ValCodcntry_chzn");
	public LookupControl IFF_DENTR___CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_DENTR___CMPNYDESIGNAT", "ValCodempre_chzn");
	public LookupControl IFF_DENTR___PESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_DENTR___PESSONAME____", "ValCodpesso_chzn");
	public LookupControl IFF_DENTR___WARE1WAREHDES => new LookupControl(driver, "CONTAINER_IFF_DENTR___WARE1WAREHDES", "ValCodwareh_chzn");
	public BaseInputControl LED_DENTR___INDOCDATE____ => new BaseInputControl(driver, "[data-identifier='LED_DENTR___INDOCDATE____']");
	public BaseInputControl LED_DENTR___INDOCDOCUMENR => new BaseInputControl(driver, "[data-identifier='LED_DENTR___INDOCDOCUMENR']");
	public BaseInputControl LED_DENTR___INDOCDHDOCUME => new BaseInputControl(driver, "[data-identifier='LED_DENTR___INDOCDHDOCUME']");
	public ListControl IFF_DENTR___PSEUDENTRADAS => new ListControl(driver, "ValEntradas", "#Dentr_ValEntradas");
	public IWebElement IFF_DENTR___PSEUDNORMAL__ => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public DentrForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
