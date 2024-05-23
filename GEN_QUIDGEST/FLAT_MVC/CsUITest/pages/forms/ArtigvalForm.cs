using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigvalForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Artigval']"));

	public BaseInputControl LED_ARTIGVALITEM_IMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_IMAGE___']");
	public LookupControl IFF_ARTIGVALGITEMITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_ARTIGVALGITEMITEMDES_", "ValCodgitem_chzn");
	public LookupControl IFF_ARTIGVALWAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_ARTIGVALWAREHWAREHDES", "ValCodwareh_chzn");
	public EnumControl LED_ARTIGVALITEM_ITEMTYPE => new EnumControl(driver, "CONTAINER_LED_ARTIGVALITEM_ITEMTYPE", "ValItemtype_chzn_Artigval");
	public BaseInputControl LED_ARTIGVALITEM_ITEMCOD_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_ITEMCOD_']");
	public BaseInputControl LED_ARTIGVALITEM_ITEMDES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_ITEMDES_']");
	public BaseInputControl LED_ARTIGVALITEM_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_DATE____']");
	public BaseInputControl LED_ARTIGVALITEM_ENTRIES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_ENTRIES_']");
	public BaseInputControl LED_ARTIGVALITEM_EXITS___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_EXITS___']");
	public BaseInputControl LED_ARTIGVALITEM_EXISTENC => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_EXISTENC']");
	public BaseInputControl LED_ARTIGVALITEM_CATEGORY => new BaseInputControl(driver, "[data-identifier='LED_ARTIGVALITEM_CATEGORY']");
	public EnumControl LED_ARTIGVALITEM_DISPONIB => new EnumControl(driver, "CONTAINER_LED_ARTIGVALITEM_DISPONIB", "ValDisponib_chzn_Artigval");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ArtigvalForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
