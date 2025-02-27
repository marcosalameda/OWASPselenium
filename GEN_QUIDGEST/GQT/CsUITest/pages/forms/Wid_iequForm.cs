using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Wid_iequForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Wid_iequ']"));

	public BaseInputControl LED_WID_IEQUEQUIPSEQUENNR => new BaseInputControl(driver, "[data-identifier='LED_WID_IEQUEQUIPSEQUENNR']");
	public BaseInputControl LED_WID_IEQUEQUIPREGISTNR => new BaseInputControl(driver, "[data-identifier='LED_WID_IEQUEQUIPREGISTNR']");
	public LookupControl IFF_WID_IEQUTPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_WID_IEQUTPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public LookupControl IFF_WID_IEQUWAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_WID_IEQUWAREHWAREHDES", "ValCodwareh_chzn");
	public BaseInputControl LED_WID_IEQUEQUIPVALORTOT => new BaseInputControl(driver, "[data-identifier='LED_WID_IEQUEQUIPVALORTOT']");
	public BaseInputControl LED_WID_IEQUEQUIPDTAQUISI => new BaseInputControl(driver, "[data-identifier='LED_WID_IEQUEQUIPDTAQUISI']");
	public BaseInputControl LED_WID_IEQUEQUIPDTDECO__ => new BaseInputControl(driver, "[data-identifier='LED_WID_IEQUEQUIPDTDECO__']");
	public BaseInputControl LED_WID_IEQUEQUIPBOUGHT__ => new BaseInputControl(driver, "[data-identifier='LED_WID_IEQUEQUIPBOUGHT__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public Wid_iequForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
