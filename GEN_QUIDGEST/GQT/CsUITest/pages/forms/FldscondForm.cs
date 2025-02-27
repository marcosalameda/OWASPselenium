using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FldscondForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Fldscond']"));

	public EnumControl LED_FLDSCONDFLDS_COND____ => new EnumControl(driver, "CONTAINER_LED_FLDSCONDFLDS_COND____", "ValCond_chzn_Fldscond");
	public BaseInputControl LED_FLDSCONDFLDS_TBLCOND_ => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_TBLCOND_']");
	public BaseInputControl LED_FLDSCONDFLDS_FORMCOND => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FORMCOND']");
	public BaseInputControl LED_FLDSCONDFLDS_FCLIENT1 => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FCLIENT1']");
	public BaseInputControl LED_FLDSCONDFLDS_FFILLWHN => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FFILLWHN']");
	public BaseInputControl LED_FLDSCONDFLDS_FSERVER1 => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FSERVER1']");
	public BaseInputControl LED_FLDSCONDFLDS_FCLIENT2 => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FCLIENT2']");
	public BaseInputControl LED_FLDSCONDFLDS_FSERVER2 => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FSERVER2']");
	public BaseInputControl LED_FLDSCONDFLDS_FCLIENT3 => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FCLIENT3']");
	public BaseInputControl LED_FLDSCONDFLDS_FSERVER3 => new BaseInputControl(driver, "[data-identifier='LED_FLDSCONDFLDS_FSERVER3']");
	public BaseInputControl IFF_FLDSCONDPSEUDSTATICTX => new BaseInputControl(driver, "[data-identifier='IFF_FLDSCONDPSEUDSTATICTX']");
	public ListControl IFF_FLDSCONDPSEUDGRIDTBL_ => new ListControl(driver, "ValGridtbl", "#Fldscond_ValGridtbl");
	public ListControl IFF_FLDSCONDPSEUDLISTTBL_ => new ListControl(driver, "ValListtbl", "#Fldscond_ValListtbl");
	public IWebElement IFF_FLDSCONDPSEUDLISTBTN_ => throw new NotImplementedException();

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public FldscondForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
