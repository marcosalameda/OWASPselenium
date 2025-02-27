using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PessosepForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pessosep']"));

	public BaseInputControl LED_PESSOSEPPESSOIDFUNCIO => new BaseInputControl(driver, "[data-identifier='LED_PESSOSEPPESSOIDFUNCIO']");
	public BaseInputControl LED_PESSOSEPPESSONAME____ => new BaseInputControl(driver, "[data-identifier='LED_PESSOSEPPESSONAME____']");
	public BaseInputControl LED_PESSOSEPPESSODTNASCIM => new BaseInputControl(driver, "[data-identifier='LED_PESSOSEPPESSODTNASCIM']");
	public EnumControl LED_PESSOSEPPESSOGENDER__ => new EnumControl(driver, "CONTAINER_LED_PESSOSEPPESSOGENDER__", "ValGender_chzn_Pessosep");
	public BaseInputControl LED_PESSOSEPPESSOINTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESSOSEPPESSOINTERNA_']");
	public BaseInputControl LED_PESSOSEPPESSOEXTERNA_ => new BaseInputControl(driver, "[data-identifier='LED_PESSOSEPPESSOEXTERNA_']");
	public LookupControl IFF_PESSOSEPCATEGCATEGORY => new LookupControl(driver, "CONTAINER_IFF_PESSOSEPCATEGCATEGORY", "ValCodcateg_chzn");
	public BaseInputControl LED_PESSOSEPPESSODTULTCAT => new BaseInputControl(driver, "[data-identifier='LED_PESSOSEPPESSODTULTCAT']");
	public BaseInputControl IFF_PESSOSEPPSEUDOBRIGATO => new BaseInputControl(driver, "[data-identifier='IFF_PESSOSEPPSEUDOBRIGATO']");
	public BaseInputControl IFF_PESSOSEPPSEUDPESSOS00 => new BaseInputControl(driver, "[data-identifier='IFF_PESSOSEPPSEUDPESSOS00']");
	public BaseInputControl IFF_PESSOSEPPSEUDPESSOS01 => new BaseInputControl(driver, "[data-identifier='IFF_PESSOSEPPSEUDPESSOS01']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public PessosepForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
