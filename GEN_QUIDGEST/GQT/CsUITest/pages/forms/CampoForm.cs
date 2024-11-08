using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CampoForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Campo']"));

	public LookupControl IFF_CAMPO___AERO_NAME____ => new LookupControl(driver, "CONTAINER_IFF_CAMPO___AERO_NAME____", "ValCodaero_chzn");
	public BaseInputControl LED_CAMPO___FLDS_DESCRIP_ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_DESCRIP_']");
	public BaseInputControl LED_CAMPO___FLDS_NPASSAGE => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_NPASSAGE']");
	public BaseInputControl LED_CAMPO___FLDS_DURATION => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_DURATION']");
	public BaseInputControl LED_CAMPO___FLDS_PRICE___ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_PRICE___']");
	public BaseInputControl LED_CAMPO___FLDS_PRECOBIL => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_PRECOBIL']");
	public BaseInputControl LED_CAMPO___FLDS_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_DATE____']");
	public BaseInputControl LED_CAMPO___FLDS_DATETIME => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_DATETIME']");
	public BaseInputControl LED_CAMPO___FLDS_DATESECO => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_DATESECO']");
	public BaseInputControl LED_CAMPO___FLDS_TIME____ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_TIME____']");
	public BaseInputControl LED_CAMPO___FLDS_YEAR____ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_YEAR____']");
	public BaseInputControl LED_CAMPO___FLDS_PRIMVIAG => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_PRIMVIAG']");
	public BaseInputControl LED_CAMPO___FLDS_CONDITIO => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_CONDITIO']");
	public EnumControl LED_CAMPO___FLDS_CLASS___ => new EnumControl(driver, "CONTAINER_LED_CAMPO___FLDS_CLASS___", "ValClass_chzn_Campo");
	public EnumControl LED_CAMPO___FLDS_CLASSNUM => new EnumControl(driver, "CONTAINER_LED_CAMPO___FLDS_CLASSNUM", "ValClassnum_chzn_Campo");
	public BaseInputControl LED_CAMPO___FLDS_LOGICENU => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_LOGICENU']");
	public BaseInputControl LED_CAMPO___FLDS_LOGO____ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_LOGO____']");
	public BaseInputControl LED_CAMPO___FLDS_ATTACH__ => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_ATTACH__']");
	public BaseInputControl LED_CAMPO___FLDS_CREATUSE => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_CREATUSE']");
	public BaseInputControl LED_CAMPO___FLDS_CREATDAT => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_CREATDAT']");
	public BaseInputControl LED_CAMPO___FLDS_CREATHOU => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_CREATHOU']");
	public BaseInputControl LED_CAMPO___FLDS_CREATINS => new BaseInputControl(driver, "[data-identifier='LED_CAMPO___FLDS_CREATINS']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public CampoForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
