using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class InfieldsForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Infields']"));

	public BaseInputControl LED_INFIELDSFLDS_TXTFIELD => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_TXTFIELD']");
	public BaseInputControl LED_INFIELDSFLDS_DESCRIP_ => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_DESCRIP_']");
	public BaseInputControl LED_INFIELDSFLDS_YEAR____ => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_YEAR____']");
	public BaseInputControl LED_INFIELDSFLDS_TIME____ => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_TIME____']");
	public BaseInputControl LED_INFIELDSFLDS_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_DATE____']");
	public BaseInputControl LED_INFIELDSFLDS_DATETIME => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_DATETIME']");
	public BaseInputControl LED_INFIELDSFLDS_DATESECO => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_DATESECO']");
	public BaseInputControl LED_INFIELDSFLDS_NPASSAGE => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_NPASSAGE']");
	public BaseInputControl LED_INFIELDSFLDS_DURATION => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_DURATION']");
	public BaseInputControl LED_INFIELDSFLDS_PRECOBIL => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_PRECOBIL']");
	public BaseInputControl LED_INFIELDSFLDS_PRICE___ => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_PRICE___']");
	public BaseInputControl LED_INFIELDSFLDS_SSNUMBER => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_SSNUMBER']");
	public BaseInputControl LED_INFIELDSFLDS_ZIPFIELD => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_ZIPFIELD']");
	public BaseInputControl LED_INFIELDSFLDS_VATNUMBR => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_VATNUMBR']");
	public BaseInputControl LED_INFIELDSFLDS_LICPLATE => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_LICPLATE']");
	public BaseInputControl LED_INFIELDSFLDS_BANKNMBR => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_BANKNMBR']");
	public BaseInputControl LED_INFIELDSFLDS_EMAILFLD => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_EMAILFLD']");
	public BaseInputControl LED_INFIELDSFLDS_IBANFIEL => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_IBANFIEL']");
	public BaseInputControl LED_INFIELDSFLDS_UPPRTEXT => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_UPPRTEXT']");
	public BaseInputControl LED_INFIELDSFLDS_PASSFLD_ => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_PASSFLD_']");
	public BaseInputControl LED_INFIELDSFLDS_CLRPICKE => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_CLRPICKE']");
	public BaseInputControl LED_INFIELDSFLDS_PRIMVIAG => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_PRIMVIAG']");
	public BaseInputControl LED_INFIELDSFLDS_LOGICENU => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_LOGICENU']");
	public BaseInputControl LED_INFIELDSFLDS_CREATUSE => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_CREATUSE']");
	public BaseInputControl LED_INFIELDSFLDS_CREATDAT => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_CREATDAT']");
	public BaseInputControl LED_INFIELDSFLDS_CREATINS => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_CREATINS']");
	public BaseInputControl LED_INFIELDSFLDS_CREATHOU => new BaseInputControl(driver, "[data-identifier='LED_INFIELDSFLDS_CREATHOU']");
	public EnumControl LED_INFIELDSFLDS_RADIOB__ => new EnumControl(driver, "CONTAINER_LED_INFIELDSFLDS_RADIOB__", "ValRadiob_chzn_Infields");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public InfieldsForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
