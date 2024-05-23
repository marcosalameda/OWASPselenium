using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProduForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Produ']"));

	public BaseInputControl LED_PRODU___PRODUPRODUCT_ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUPRODUCT_']");
	public BaseInputControl LED_PRODU___PRODUIN_USE__ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUIN_USE__']");
	public BaseInputControl LED_PRODU___PRODUDESCRIPT => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUDESCRIPT']");
	public BaseInputControl LED_PRODU___PRODUSKU_____ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUSKU_____']");
	public BaseInputControl LED_PRODU___PRODUGTIN____ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUGTIN____']");
	public BaseInputControl LED_PRODU___PRODUSIZE____ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUSIZE____']");
	public BaseInputControl LED_PRODU___PRODUWEIGHT__ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUWEIGHT__']");
	public BaseInputControl LED_PRODU___PRODUPRICE___ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUPRICE___']");
	public BaseInputControl LED_PRODU___PRODUINPUTS__ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUINPUTS__']");
	public BaseInputControl LED_PRODU___PRODUOUTPUTS_ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUOUTPUTS_']");
	public BaseInputControl LED_PRODU___PRODUSTOCK___ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUSTOCK___']");
	public BaseInputControl IFF_PRODU___PSEUDNOVOGR02 => new BaseInputControl(driver, "[data-identifier='IFF_PRODU___PSEUDNOVOGR02']");
	public BaseInputControl LED_PRODU___PRODUIMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_PRODU___PRODUIMAGE___']");
	public BaseInputControl IFF_PRODU___PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_PRODU___PSEUDNOVOGR06']");
	public LookupControl IFF_PRODU___LOCATGLN_____ => new LookupControl(driver, "CONTAINER_IFF_PRODU___LOCATGLN_____", "ValCodlocat_chzn");
	public LookupControl IFF_PRODU___LCEXTGLNEXT__ => new LookupControl(driver, "CONTAINER_IFF_PRODU___LCEXTGLNEXT__", "ValCodlcext_chzn");
	public ListControl IFF_PRODU___PSEUDSTOCKEVO => new ListControl(driver, "ValStockevo", "#Produ_ValStockevo");
	public ListControl IFF_PRODU___PSEUDINPUTSRE => new ListControl(driver, "ValInputsre", "#Produ_ValInputsre");
	public ListControl IFF_PRODU___PSEUDOUTPUTSD => new ListControl(driver, "ValOutputsd", "#Produ_ValOutputsd");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ProduForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
