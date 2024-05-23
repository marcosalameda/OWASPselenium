using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PedidForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Pedid']"));

	public BaseInputControl LED_PEDID___PEDIDDTPEDIDO => new BaseInputControl(driver, "[data-identifier='LED_PEDID___PEDIDDTPEDIDO']");
	public BaseInputControl LED_PEDID___PEDIDNRPEDIDO => new BaseInputControl(driver, "[data-identifier='LED_PEDID___PEDIDNRPEDIDO']");
	public BaseInputControl LED_PEDID___PEDIDMOTIVO__ => new BaseInputControl(driver, "[data-identifier='LED_PEDID___PEDIDMOTIVO__']");
	public ListControl IFF_PEDID___PSEUDLINHAS__ => new ListControl(driver, "ValLinhas", "#Pedid_ValLinhas");
	public ListControl IFF_PEDID___PSEUDDESAGREG => new ListControl(driver, "ValDesagreg", "#Pedid_ValDesagreg");
	public ListControl IFF_PEDID___PSEUDAGRUPAME => new ListControl(driver, "ValAgrupame", "#Pedid_ValAgrupame");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public PedidForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
