using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhdeForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Lnhde']"));

	public LookupControl IFF_LNHDE___PEDIDNRPEDIDO => new LookupControl(driver, "CONTAINER_IFF_LNHDE___PEDIDNRPEDIDO", "ValCodpedid_chzn");
	public LookupControl IFF_LNHDE___LNHPDLINE____ => new LookupControl(driver, "CONTAINER_IFF_LNHDE___LNHPDLINE____", "ValCodlnhpd_chzn");
	public BaseInputControl LED_LNHDE___LNHDEORDEM___ => new BaseInputControl(driver, "[data-identifier='LED_LNHDE___LNHDEORDEM___']");
	public LookupControl IFF_LNHDE___TPEQ1TIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_LNHDE___TPEQ1TIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_LNHDE___LNHDEQUANTIDA => new BaseInputControl(driver, "[data-identifier='LED_LNHDE___LNHDEQUANTIDA']");
	public BaseInputControl LED_LNHDE___LNHDEQUANTDEC => new BaseInputControl(driver, "[data-identifier='LED_LNHDE___LNHDEQUANTDEC']");
	public BaseInputControl LED_LNHDE___LNHDECODE____ => new BaseInputControl(driver, "[data-identifier='LED_LNHDE___LNHDECODE____']");
	public BaseInputControl LED_LNHDE___LNHDEDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_LNHDE___LNHDEDESCRIPT']");
	public BaseInputControl LED_LNHDE___LNHDEURL_____ => new BaseInputControl(driver, "[data-identifier='LED_LNHDE___LNHDEURL_____']");
	public ListControl IFF_LNHDE___PSEUDLNPROPS_ => new ListControl(driver, "ValLnprops", "#Lnhde_ValLnprops");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LnhdeForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
