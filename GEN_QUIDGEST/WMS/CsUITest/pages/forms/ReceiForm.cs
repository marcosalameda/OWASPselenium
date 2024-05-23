using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReceiForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Recei']"));

	public BaseInputControl LED_RECEI___RECEIDTRECEIP => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEIDTRECEIP']");
	public BaseInputControl LED_RECEI___RECEINUMBER__ => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEINUMBER__']");
	public LookupControl IFF_RECEI___ENTITNAME____ => new LookupControl(driver, "CONTAINER_IFF_RECEI___ENTITNAME____", "ValCodentit_chzn");
	public ListControl IFF_RECEI___PSEUDRECEIPTL => new ListControl(driver, "ValReceiptl", "#Recei_ValReceiptl");
	public BaseInputControl LED_RECEI___RECEIDTCHECK_ => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEIDTCHECK_']");
	public BaseInputControl LED_RECEI___RECEITOCHECK_ => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEITOCHECK_']");
	public BaseInputControl LED_RECEI___RECEICHECKED_ => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEICHECKED_']");
	public BaseInputControl LED_RECEI___RECEISTORED__ => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEISTORED__']");
	public BaseInputControl LED_RECEI___RECEIDTSTORAG => new BaseInputControl(driver, "[data-identifier='LED_RECEI___RECEIDTSTORAG']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ReceiForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
