using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GroupbxForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Groupbx']"));

	public BaseInputControl LED_GROUPBX_EQUIPSEQUENNR => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPSEQUENNR']");
	public BaseInputControl LED_GROUPBX_EQUIPREGISTNR => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPREGISTNR']");
	public LookupControl IFF_GROUPBX_TPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_GROUPBX_TPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_GROUPBX_EQUIPSITEFABR => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPSITEFABR']");
	public LookupControl IFF_GROUPBX_WAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_GROUPBX_WAREHWAREHDES", "ValCodwareh_chzn");
	public LookupControl IFF_GROUPBX_ITEM_ITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_GROUPBX_ITEM_ITEMDES_", "ValCoditem_chzn");
	public BaseInputControl LED_GROUPBX_EQUIPDTDECO__ => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPDTDECO__']");
	public LookupControl IFF_GROUPBX_ROOM1ROOMNR__ => new LookupControl(driver, "CONTAINER_IFF_GROUPBX_ROOM1ROOMNR__", "ValCodrooms_chzn");
	public BaseInputControl LED_GROUPBX_ROOM1DESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_ROOM1DESIGNAT']");
	public BaseInputControl LED_GROUPBX_EQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPDESIGNAT']");
	public BaseInputControl LED_GROUPBX_EQUIPDTAQUISI => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPDTAQUISI']");
	public BaseInputControl LED_GROUPBX_EQUIPVALORTOT => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPVALORTOT']");
	public EnumControl LED_GROUPBX_EQUIPFREQUENC => new EnumControl(driver, "CONTAINER_LED_GROUPBX_EQUIPFREQUENC", "ValFrequenc_chzn_Groupbx");
	public BaseInputControl LED_GROUPBX_EQUIPDTREFERE => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPDTREFERE']");
	public BaseInputControl LED_GROUPBX_EQUIPFIRST___ => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPFIRST___']");
	public BaseInputControl LED_GROUPBX_EQUIPBEFORE__ => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPBEFORE__']");
	public BaseInputControl LED_GROUPBX_EQUIPBOUGHT__ => new BaseInputControl(driver, "[data-identifier='LED_GROUPBX_EQUIPBOUGHT__']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode { get; private set; }

	public GroupbxForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
