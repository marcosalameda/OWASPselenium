using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class VendaForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Venda']"));

	public LookupControl IFF_VENDA___ORGANORGANIZA => new LookupControl(driver, "CONTAINER_IFF_VENDA___ORGANORGANIZA", "ValCodorgan_chzn");
	public BaseInputControl LED_VENDA___SALE_NRLIDE__ => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_NRLIDE__']");
	public BaseInputControl LED_VENDA___SALE_STARTDT_ => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_STARTDT_']");
	public BaseInputControl LED_VENDA___SALE_IDENTIFI => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_IDENTIFI']");
	public BaseInputControl LED_VENDA___SALE_POTCOMPR => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_POTCOMPR']");
	public BaseInputControl LED_VENDA___SALE_PROSPECC => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_PROSPECC']");
	public BaseInputControl LED_VENDA___SALE_INTERESS => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_INTERESS']");
	public BaseInputControl LED_VENDA___SALE_SEMRFINA => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_SEMRFINA']");
	public BaseInputControl LED_VENDA___SALE_SEMCAPAC => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_SEMCAPAC']");
	public BaseInputControl LED_VENDA___SALE_DTQUALIF => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_DTQUALIF']");
	public BaseInputControl LED_VENDA___SALE_QUALIFIC => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_QUALIFIC']");
	public BaseInputControl LED_VENDA___SALE_PREABORD => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_PREABORD']");
	public BaseInputControl LED_VENDA___SALE_HOMEWORK => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_HOMEWORK']");
	public BaseInputControl LED_VENDA___SALE_DTABORDA => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_DTABORDA']");
	public BaseInputControl LED_VENDA___SALE_APPROACH => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_APPROACH']");
	public BaseInputControl LED_VENDA___SALE_DTAPRESE => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_DTAPRESE']");
	public BaseInputControl LED_VENDA___SALE_APRESENT => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_APRESENT']");
	public BaseInputControl LED_VENDA___SALE_DTSUPERA => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_DTSUPERA']");
	public BaseInputControl LED_VENDA___SALE_TENTFECH => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_TENTFECH']");
	public BaseInputControl LED_VENDA___SALE_DTVENDA_ => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_DTVENDA_']");
	public BaseInputControl LED_VENDA___SALE_DTACOMPA => new BaseInputControl(driver, "[data-identifier='LED_VENDA___SALE_DTACOMPA']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public VendaForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
