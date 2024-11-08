using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EqudocumForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Equdocum']"));

	public BaseInputControl LED_EQUDOCUMEQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_EQUDOCUMEQUIPDESIGNAT']");
	public IWebElement IFF_EQUDOCUMPSEUDBTN_ANEX => throw new NotImplementedException();
	public ListControl IFF_EQUDOCUMPSEUDLISANEX_ => new ListControl(driver, "ValLisanex", "#Equdocum_ValLisanex");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EqudocumForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
