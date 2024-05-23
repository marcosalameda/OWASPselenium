using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ProprallForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Proprall']"));

	public BaseInputControl LED_PROPRALLPROPRPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRPHOTOGRA']");
	public BaseInputControl LED_PROPRALLPROPRNAME____ => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRNAME____']");
	public BaseInputControl LED_PROPRALLPROPRPRECOEST => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRPRECOEST']");
	public LookupControl IFF_PROPRALLTPPROTPPROPRI => new LookupControl(driver, "CONTAINER_IFF_PROPRALLTPPROTPPROPRI", "ValCodtppro_chzn");
	public BaseInputControl LED_PROPRALLPROPRMOBILADA => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRMOBILADA']");
	public LookupControl IFF_PROPRALLCNTRYCOUNTRY_ => new LookupControl(driver, "CONTAINER_IFF_PROPRALLCNTRYCOUNTRY_", "ValCodcntry_chzn");
	public LookupControl IFF_PROPRALLREGIOREGIAO__ => new LookupControl(driver, "CONTAINER_IFF_PROPRALLREGIOREGIAO__", "ValCodregia_chzn");
	public BaseInputControl LED_PROPRALLPROPRENDERECO => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRENDERECO']");
	public BaseInputControl LED_PROPRALLPROPRLOCALIDA => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRLOCALIDA']");
	public BaseInputControl LED_PROPRALLPROPRPOSTALCO => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRPOSTALCO']");
	public BaseInputControl LED_PROPRALLPROPRPOSTALLO => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRPOSTALLO']");
	public BaseInputControl LED_PROPRALLPROPRQTD_WC__ => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRQTD_WC__']");
	public BaseInputControl LED_PROPRALLPROPRQTDQUART => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRQTDQUART']");
	public BaseInputControl LED_PROPRALLPROPRM2______ => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRM2______']");
	public BaseInputControl LED_PROPRALLPROPRDTDISPON => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRDTDISPON']");
	public BaseInputControl IFF_PROPRALLPROPRDESCRIPT => new BaseInputControl(driver, "[data-identifier='IFF_PROPRALLPROPRDESCRIPT']");
	public BaseInputControl LED_PROPRALLPROPRCOORDGEO => new BaseInputControl(driver, "[data-identifier='LED_PROPRALLPROPRCOORDGEO']");
	public LookupControl IFF_PROPRALLPESSONAME____ => new LookupControl(driver, "CONTAINER_IFF_PROPRALLPESSONAME____", "ValCodpesso_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ProprallForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
