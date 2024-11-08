using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PesspopForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pesspop']"));

	public BaseInputControl LED_PESSPOP_WPESSNFUNC___ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSNFUNC___']");
	public BaseInputControl LED_PESSPOP_WPESSPFOTO___ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSPFOTO___']");
	public BaseInputControl LED_PESSPOP_WPESSNAME____ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSNAME____']");
	public BaseInputControl LED_PESSPOP_WPESSDATE____ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSDATE____']");
	public EnumControl LED_PESSPOP_WPESSSEX_____ => new EnumControl(driver, "CONTAINER_LED_PESSPOP_WPESSSEX_____", "ValSex_chzn_Pesspop");
	public BaseInputControl LED_PESSPOP_WPESSNATURALI => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSNATURALI']");
	public BaseInputControl LED_PESSPOP_WPESSNACIONAL => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSNACIONAL']");
	public BaseInputControl LED_PESSPOP_WPESSADRESS__ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSADRESS__']");
	public BaseInputControl LED_PESSPOP_WPESSZIPCODE_ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSZIPCODE_']");
	public BaseInputControl LED_PESSPOP_WPESSCOUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSCOUNTRY_']");
	public BaseInputControl LED_PESSPOP_WPESSEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSEMAIL___']");
	public BaseInputControl LED_PESSPOP_WPESSCELLPHON => new BaseInputControl(driver, "[data-identifier='LED_PESSPOP_WPESSCELLPHON']");
	public LookupControl IFF_PESSPOP_WAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_PESSPOP_WAREHWAREHDES", "ValCodwareh_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public PesspopForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
