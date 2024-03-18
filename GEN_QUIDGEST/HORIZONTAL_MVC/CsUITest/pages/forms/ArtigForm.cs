using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ArtigForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Artig']"));

	public BaseInputControl LED_ARTIG___ITEM_ITEMCOD_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_ITEMCOD_']");
	public LookupControl IFF_ARTIG___WAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_ARTIG___WAREHWAREHDES", "ValCodwareh_chzn");
	public BaseInputControl LED_ARTIG___GITEMITEMGCOD => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___GITEMITEMGCOD']");
	public LookupControl IFF_ARTIG___GITEMITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_ARTIG___GITEMITEMDES_", "ValCodgitem_chzn");
	public BaseInputControl LED_ARTIG___ITEM_ITEMDES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_ITEMDES_']");
	public BaseInputControl LED_ARTIG___ITEM_VALID___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_VALID___']");
	public EnumControl LED_ARTIG___ITEM_ITEMTYPE => new EnumControl(driver, "CONTAINER_LED_ARTIG___ITEM_ITEMTYPE", "ValItemtype_chzn_Artig");
	public BaseInputControl LED_ARTIG___ITEM_ENTRIES_ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_ENTRIES_']");
	public BaseInputControl LED_ARTIG___ITEM_EXITS___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_EXITS___']");
	public BaseInputControl LED_ARTIG___ITEM_IMAGE___ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_IMAGE___']");
	public ListControl IFF_ARTIG___PSEUDCONTACOR => new ListControl(driver, "ValContacor", "#Artig_ValContacor");
	public ListControl IFF_ARTIG___PSEUDLENTRADA => new ListControl(driver, "ValLentrada", "#Artig_ValLentrada");
	public ListControl IFF_ARTIG___PSEUDLSAIDAS_ => new ListControl(driver, "ValLsaidas", "#Artig_ValLsaidas");
	public BaseInputControl IFF_ARTIG___PSEUDNOVOGR05 => new BaseInputControl(driver, "[data-identifier='IFF_ARTIG___PSEUDNOVOGR05']");
	public BaseInputControl IFF_ARTIG___PSEUDCATEGORI => new BaseInputControl(driver, "[data-identifier='IFF_ARTIG___PSEUDCATEGORI']");
	public BaseInputControl IFF_ARTIG___PSEUDESCCATEG => new BaseInputControl(driver, "[data-identifier='IFF_ARTIG___PSEUDESCCATEG']");
	public BaseInputControl IFF_ARTIG___PSEUDCATEGOR_ => new BaseInputControl(driver, "[data-identifier='IFF_ARTIG___PSEUDCATEGOR_']");
	public BaseInputControl LED_ARTIG___ITEM_CATEGORY => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_CATEGORY']");
	public BaseInputControl IFF_ARTIG___PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_ARTIG___PSEUDNOVOGR06']");
	public BaseInputControl LED_ARTIG___ITEM_EXISTENC => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_EXISTENC']");
	public EnumControl LED_ARTIG___ITEM_DISPONIB => new EnumControl(driver, "CONTAINER_LED_ARTIG___ITEM_DISPONIB", "ValDisponib_chzn_Artig");
	public BaseInputControl IFF_ARTIG___PSEUDNOVOGR08 => new BaseInputControl(driver, "[data-identifier='IFF_ARTIG___PSEUDNOVOGR08']");
	public BaseInputControl LED_ARTIG___ITEM_DATE____ => new BaseInputControl(driver, "[data-identifier='LED_ARTIG___ITEM_DATE____']");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public ArtigForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
