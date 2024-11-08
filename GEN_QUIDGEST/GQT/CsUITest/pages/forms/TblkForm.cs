using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TblkForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Tblk']"));

	public BaseInputControl LED_TBLK____TBLK_NAME____ => new BaseInputControl(driver, "[data-identifier='LED_TBLK____TBLK_NAME____']");
	public LookupControl IFF_TBLK____GRPB_NAME____ => new LookupControl(driver, "CONTAINER_IFF_TBLK____GRPB_NAME____", "ValCodgrpb_chzn");
	public LookupControl IFF_TBLK____TRSB_NAME____ => new LookupControl(driver, "CONTAINER_IFF_TBLK____TRSB_NAME____", "ValCodtrsb_chzn");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public TblkForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
