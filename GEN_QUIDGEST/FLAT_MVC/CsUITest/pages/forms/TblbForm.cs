using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TblbForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tblb']"));

	public BaseInputControl LED_TBLB____TBLB_TEXT____ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_TEXT____']");
	public BaseInputControl LED_TBLB____TBLB_TEXTML__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_TEXTML__']");
	public BaseInputControl LED_TBLB____TBLB_NUMINT__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_NUMINT__']");
	public BaseInputControl LED_TBLB____TBLB_NUMDEC__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_NUMDEC__']");
	public BaseInputControl LED_TBLB____TBLB_CURINT__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_CURINT__']");
	public BaseInputControl LED_TBLB____TBLB_CURDEC__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_CURDEC__']");
	public BaseInputControl LED_TBLB____TBLB_BOOL____ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_BOOL____']");
	public BaseInputControl LED_TBLB____TBLB_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_DATE____']");
	public BaseInputControl LED_TBLB____TBLB_DATETM__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_DATETM__']");
	public BaseInputControl LED_TBLB____TBLB_DATETS__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_DATETS__']");
	public BaseInputControl LED_TBLB____TBLB_TIMEHM__ => new BaseInputControl(driver, "[data-identifier='LED_TBLB____TBLB_TIMEHM__']");
	public EnumControl LED_TBLB____TBLB_ENUMT___ => new EnumControl(driver, "CONTAINER_LED_TBLB____TBLB_ENUMT___", "ValEnumt_chzn_Tblb");
	public EnumControl LED_TBLB____TBLB_ENUMN___ => new EnumControl(driver, "CONTAINER_LED_TBLB____TBLB_ENUMN___", "ValEnumn_chzn_Tblb");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public TblbForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
