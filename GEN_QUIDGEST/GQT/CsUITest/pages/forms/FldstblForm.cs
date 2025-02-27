using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FldstblForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Fldstbl']"));

	public BaseInputControl LED_FLDSTBL_FLDS_SHWRC___ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_SHWRC___']");
	public BaseInputControl LED_FLDSTBL_FLDS_TXTFIELD => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_TXTFIELD']");
	public BaseInputControl LED_FLDSTBL_FLDS_DESCRIP_ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_DESCRIP_']");
	public BaseInputControl LED_FLDSTBL_FLDS_PRIMVIAG => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_PRIMVIAG']");
	public BaseInputControl LED_FLDSTBL_FLDS_LOGICENU => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_LOGICENU']");
	public EnumControl LED_FLDSTBL_FLDS_CLASSNUM => new EnumControl(driver, "CONTAINER_LED_FLDSTBL_FLDS_CLASSNUM", "ValClassnum_chzn_Fldstbl");
	public EnumControl LED_FLDSTBL_FLDS_RADIOB__ => new EnumControl(driver, "CONTAINER_LED_FLDSTBL_FLDS_RADIOB__", "ValRadiob_chzn_Fldstbl");
	public BaseInputControl IFF_FLDSTBL_PSEUDFIELD002 => new BaseInputControl(driver, "[data-identifier='IFF_FLDSTBL_PSEUDFIELD002']");
	public BaseInputControl LED_FLDSTBL_FLDS_YEAR____ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_YEAR____']");
	public BaseInputControl LED_FLDSTBL_FLDS_TIME____ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_TIME____']");
	public BaseInputControl LED_FLDSTBL_FLDS_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_DATE____']");
	public BaseInputControl LED_FLDSTBL_FLDS_DATETIME => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_DATETIME']");
	public BaseInputControl LED_FLDSTBL_FLDS_DATESECO => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_DATESECO']");
	public BaseInputControl LED_FLDSTBL_FLDS_DURATION => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_DURATION']");
	public BaseInputControl LED_FLDSTBL_FLDS_NPASSAGE => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_NPASSAGE']");
	public BaseInputControl LED_FLDSTBL_FLDS_PRECOBIL => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_PRECOBIL']");
	public BaseInputControl LED_FLDSTBL_FLDS_PRICE___ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_PRICE___']");
	public BaseInputControl LED_FLDSTBL_FLDS_SSNUMBER => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_SSNUMBER']");
	public BaseInputControl LED_FLDSTBL_FLDS_ZIPFIELD => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_ZIPFIELD']");
	public BaseInputControl LED_FLDSTBL_FLDS_VATNUMBR => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_VATNUMBR']");
	public BaseInputControl LED_FLDSTBL_FLDS_LICPLATE => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_LICPLATE']");
	public BaseInputControl LED_FLDSTBL_FLDS_BANKNMBR => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_BANKNMBR']");
	public BaseInputControl LED_FLDSTBL_FLDS_EMAILFLD => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_EMAILFLD']");
	public BaseInputControl LED_FLDSTBL_FLDS_IBANFIEL => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_IBANFIEL']");
	public BaseInputControl LED_FLDSTBL_FLDS_UPPRTEXT => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_UPPRTEXT']");
	public BaseInputControl LED_FLDSTBL_FLDS_NRCNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_NRCNTRY_']");
	public BaseInputControl LED_FLDSTBL_FLDS_PASSFLD_ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_PASSFLD_']");
	public BaseInputControl LED_FLDSTBL_FLDS_CLRPICKE => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_CLRPICKE']");
	public BaseInputControl LED_FLDSTBL_FLDS_LOGO____ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_LOGO____']");
	public BaseInputControl LED_FLDSTBL_FLDS_ATTACH__ => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_ATTACH__']");
	public BaseInputControl LED_FLDSTBL_FLDS_CREATDAT => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_CREATDAT']");
	public BaseInputControl LED_FLDSTBL_FLDS_CREATUSE => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_CREATUSE']");
	public BaseInputControl LED_FLDSTBL_FLDS_CREATINS => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_CREATINS']");
	public BaseInputControl LED_FLDSTBL_FLDS_CREATHOU => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_CREATHOU']");
	public LookupControl IFF_FLDSTBL_AERO_NAME____ => new LookupControl(driver, "CONTAINER_IFF_FLDSTBL_AERO_NAME____", "ValCodaero_chzn");
	public BaseInputControl LED_FLDSTBL_FLDS_CONDITIO => new BaseInputControl(driver, "[data-identifier='LED_FLDSTBL_FLDS_CONDITIO']");
	public EnumControl LED_FLDSTBL_FLDS_CLASS___ => new EnumControl(driver, "CONTAINER_LED_FLDSTBL_FLDS_CLASS___", "ValClass_chzn_Fldstbl");
	public ListControl IFF_FLDSTBL_PSEUDFEECA___ => new ListControl(driver, "ValFeeca", "#Fldstbl_ValFeeca");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public FldstblForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
