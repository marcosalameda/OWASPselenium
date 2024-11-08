using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtiginvForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Artiginv']"));

	public BaseInputControl LED_ARTIGINVITEM_IMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGINVITEM_IMAGE___']");
	public LookupControl IFF_ARTIGINVGITEMITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_ARTIGINVGITEMITEMDES_", "ValCodgitem_chzn");
	public LookupControl IFF_ARTIGINVWAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_ARTIGINVWAREHWAREHDES", "ValCodwareh_chzn");
	public EnumControl LED_ARTIGINVITEM_ITEMTYPE => new EnumControl(driver, "CONTAINER_LED_ARTIGINVITEM_ITEMTYPE", "ValItemtype_chzn_Artiginv");
	public BaseInputControl LED_ARTIGINVITEM_ITEMCOD_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGINVITEM_ITEMCOD_']");
	public BaseInputControl LED_ARTIGINVITEM_ITEMDES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGINVITEM_ITEMDES_']");
	public BaseInputControl LED_ARTIGINVITEM_VALID___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGINVITEM_VALID___']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ArtiginvForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
