using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LdentnorForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Ldentnor']"));

	public LookupControl IFF_LDENTNORINDOCDOCUMENR => new LookupControl(driver, "CONTAINER_IFF_LDENTNORINDOCDOCUMENR", "ValCoddentr_chzn");
	public LookupControl IFF_LDENTNORWAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_LDENTNORWAREHWAREHDES", "ValCodwareh_chzn");
	public BaseInputControl LED_LDENTNORLDENTLINE____ => new BaseInputControl(driver, "[data-identifier='LED_LDENTNORLDENTLINE____']");
	public LookupControl IFF_LDENTNORITEM_ITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_LDENTNORITEM_ITEMDES_", "ValCoditem_chzn");
	public BaseInputControl LED_LDENTNORLDENTQTDENTRA => new BaseInputControl(driver, "[data-identifier='LED_LDENTNORLDENTQTDENTRA']");
	public BaseInputControl LED_LDENTNORINDOCCODWAREH => new BaseInputControl(driver, "[data-identifier='LED_LDENTNORINDOCCODWAREH']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public LdentnorForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
