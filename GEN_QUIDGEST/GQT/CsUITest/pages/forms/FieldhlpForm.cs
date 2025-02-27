using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FieldhlpForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Fieldhlp']"));

	public BaseInputControl LED_FIELDHLPFLDS_SHWRC___ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_SHWRC___']");
	public BaseInputControl LED_FIELDHLPFLDS_TXTFIELD => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_TXTFIELD']");
	public BaseInputControl LED_FIELDHLPFLDS_DESCRIP_ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_DESCRIP_']");
	public BaseInputControl LED_FIELDHLPFLDS_PRIMVIAG => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_PRIMVIAG']");
	public BaseInputControl LED_FIELDHLPFLDS_LOGICENU => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_LOGICENU']");
	public EnumControl LED_FIELDHLPFLDS_CLASSNUM => new EnumControl(driver, "CONTAINER_LED_FIELDHLPFLDS_CLASSNUM", "ValClassnum_chzn_Fieldhlp");
	public EnumControl LED_FIELDHLPFLDS_RADIOB__ => new EnumControl(driver, "CONTAINER_LED_FIELDHLPFLDS_RADIOB__", "ValRadiob_chzn_Fieldhlp");
	public BaseInputControl IFF_FIELDHLPPSEUDFIELD002 => new BaseInputControl(driver, "[data-identifier='IFF_FIELDHLPPSEUDFIELD002']");
	public BaseInputControl LED_FIELDHLPFLDS_YEAR____ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_YEAR____']");
	public BaseInputControl LED_FIELDHLPFLDS_TIME____ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_TIME____']");
	public BaseInputControl LED_FIELDHLPFLDS_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_DATE____']");
	public BaseInputControl LED_FIELDHLPFLDS_DATETIME => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_DATETIME']");
	public BaseInputControl LED_FIELDHLPFLDS_DATESECO => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_DATESECO']");
	public BaseInputControl LED_FIELDHLPFLDS_DURATION => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_DURATION']");
	public BaseInputControl LED_FIELDHLPFLDS_NPASSAGE => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_NPASSAGE']");
	public BaseInputControl LED_FIELDHLPFLDS_PRECOBIL => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_PRECOBIL']");
	public BaseInputControl LED_FIELDHLPFLDS_PRICE___ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_PRICE___']");
	public BaseInputControl LED_FIELDHLPFLDS_SSNUMBER => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_SSNUMBER']");
	public BaseInputControl LED_FIELDHLPFLDS_ZIPFIELD => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_ZIPFIELD']");
	public BaseInputControl LED_FIELDHLPFLDS_VATNUMBR => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_VATNUMBR']");
	public BaseInputControl LED_FIELDHLPFLDS_LICPLATE => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_LICPLATE']");
	public BaseInputControl LED_FIELDHLPFLDS_BANKNMBR => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_BANKNMBR']");
	public BaseInputControl LED_FIELDHLPFLDS_EMAILFLD => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_EMAILFLD']");
	public BaseInputControl LED_FIELDHLPFLDS_IBANFIEL => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_IBANFIEL']");
	public BaseInputControl LED_FIELDHLPFLDS_UPPRTEXT => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_UPPRTEXT']");
	public BaseInputControl LED_FIELDHLPFLDS_PASSFLD_ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_PASSFLD_']");
	public BaseInputControl LED_FIELDHLPFLDS_CLRPICKE => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_CLRPICKE']");
	public BaseInputControl LED_FIELDHLPFLDS_LOGO____ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_LOGO____']");
	public BaseInputControl LED_FIELDHLPFLDS_ATTACH__ => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_ATTACH__']");
	public BaseInputControl LED_FIELDHLPFLDS_CREATDAT => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_CREATDAT']");
	public BaseInputControl LED_FIELDHLPFLDS_CREATUSE => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_CREATUSE']");
	public BaseInputControl LED_FIELDHLPFLDS_CREATINS => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_CREATINS']");
	public BaseInputControl LED_FIELDHLPFLDS_CREATHOU => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_CREATHOU']");
	public LookupControl IFF_FIELDHLPAERO_NAME____ => new LookupControl(driver, "CONTAINER_IFF_FIELDHLPAERO_NAME____", "ValCodaero_chzn");
	public BaseInputControl LED_FIELDHLPFLDS_CONDITIO => new BaseInputControl(driver, "[data-identifier='LED_FIELDHLPFLDS_CONDITIO']");
	public EnumControl LED_FIELDHLPFLDS_CLASS___ => new EnumControl(driver, "CONTAINER_LED_FIELDHLPFLDS_CLASS___", "ValClass_chzn_Fieldhlp");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public FieldhlpForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
