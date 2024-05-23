using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Equip04Form: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Equip04']"));

	public IWebElement IFF_EQUIP04_PSEUDPARAMLOA => throw new NotImplementedException();
	public IWebElement IFF_EQUIP04_PSEUDMANUALS_ => throw new NotImplementedException();
	public ListControl IFF_EQUIP04_PSEUDPARAMETE => new ListControl(driver, "ValParamete", "#Equip04_ValParamete");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public Equip04Form(IWebDriver driver, FORM_MODE mode): base(driver) {
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
