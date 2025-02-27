using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LnhpdForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Lnhpd']"));

	public LookupControl IFF_LNHPD___PEDIDNRPEDIDO => new LookupControl(driver, "CONTAINER_IFF_LNHPD___PEDIDNRPEDIDO", "ValCodpedid_chzn");
	public BaseInputControl LED_LNHPD___LNHPDLINE____ => new BaseInputControl(driver, "[data-identifier='LED_LNHPD___LNHPDLINE____']");
	public LookupControl IFF_LNHPD___TPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_LNHPD___TPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public IWebElement IFF_LNHPD___PSEUDDESCONJU => throw new NotImplementedException();
	public BaseInputControl LED_LNHPD___LNHPDQUANTIDA => new BaseInputControl(driver, "[data-identifier='LED_LNHPD___LNHPDQUANTIDA']");
	public BaseInputControl LED_LNHPD___LNHPDQUANTDEC => new BaseInputControl(driver, "[data-identifier='LED_LNHPD___LNHPDQUANTDEC']");
	public ListControl IFF_LNHPD___PSEUDDESAGREG => new ListControl(driver, "ValDesagreg", "#Lnhpd_ValDesagreg");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public LnhpdForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
