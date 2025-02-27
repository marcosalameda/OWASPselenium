using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ListacamForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Listacam']"));

	public BaseInputControl IFF_LISTACAMPSEUDCAMTEXTO => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMTEXTO']");
	public BaseInputControl IFF_LISTACAMPSEUDCAMNUM__ => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMNUM__']");
	public BaseInputControl IFF_LISTACAMPSEUDCAMDATE_ => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMDATE_']");
	public BaseInputControl IFF_LISTACAMPSEUDCAMMASK_ => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMMASK_']");
	public BaseInputControl IFF_LISTACAMPSEUDCAMENUM_ => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMENUM_']");
	public BaseInputControl IFF_LISTACAMPSEUDCAMDOCS_ => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMDOCS_']");
	public BaseInputControl IFF_LISTACAMPSEUDCAMAUDIT => new BaseInputControl(driver, "[data-identifier='IFF_LISTACAMPSEUDCAMAUDIT']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public ListacamForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
