using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArmapessForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Armapess']"));

	public BaseInputControl LED_ARMAPESSWPESSNFUNC___ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSNFUNC___']");
	public BaseInputControl LED_ARMAPESSWPESSPFOTO___ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSPFOTO___']");
	public BaseInputControl LED_ARMAPESSWPESSNAME____ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSNAME____']");
	public BaseInputControl LED_ARMAPESSWPESSDATE____ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSDATE____']");
	public EnumControl LED_ARMAPESSWPESSSEX_____ => new EnumControl(driver, "CONTAINER_LED_ARMAPESSWPESSSEX_____", "ValSex_chzn_Armapess");
	public BaseInputControl LED_ARMAPESSWPESSNATURALI => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSNATURALI']");
	public BaseInputControl LED_ARMAPESSWPESSNACIONAL => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSNACIONAL']");
	public BaseInputControl LED_ARMAPESSWPESSADRESS__ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSADRESS__']");
	public BaseInputControl LED_ARMAPESSWPESSZIPCODE_ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSZIPCODE_']");
	public BaseInputControl LED_ARMAPESSWPESSCOUNTRY_ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSCOUNTRY_']");
	public BaseInputControl LED_ARMAPESSWPESSEMAIL___ => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSEMAIL___']");
	public BaseInputControl LED_ARMAPESSWPESSCELLPHON => new BaseInputControl(driver, "[data-identifier='LED_ARMAPESSWPESSCELLPHON']");
	public LookupControl IFF_ARMAPESSWAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_ARMAPESSWAREHWAREHDES", "ValCodwareh_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public ArmapessForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
