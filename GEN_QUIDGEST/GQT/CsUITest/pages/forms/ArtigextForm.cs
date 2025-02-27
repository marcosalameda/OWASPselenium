using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigextForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Artigext']"));

	public LookupControl IFF_ARTIGEXTWAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_ARTIGEXTWAREHWAREHDES", "ValCodwareh_chzn");
	public LookupControl IFF_ARTIGEXTGITEMITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_ARTIGEXTGITEMITEMDES_", "ValCodgitem_chzn");
	public BaseInputControl LED_ARTIGEXTGITEMITEMGCOD => new BaseInputControl(driver, "[data-identifier='LED_ARTIGEXTGITEMITEMGCOD']");
	public BaseInputControl LED_ARTIGEXTITEM_ITEMDES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGEXTITEM_ITEMDES_']");
	public BaseInputControl LED_ARTIGEXTITEM_ITEMCOD_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGEXTITEM_ITEMCOD_']");
	public BaseInputControl LED_ARTIGEXTITEM_IMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGEXTITEM_IMAGE___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public ArtigextForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
