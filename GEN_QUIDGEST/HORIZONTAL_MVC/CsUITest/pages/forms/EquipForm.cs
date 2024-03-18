using System;
using quidgest.uitests.core;
using quidgest.uitests.controls;
using OpenQA.Selenium;

namespace quidgest.uitests.pages;


[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquipForm: PageObject {

	private IWebElement form => driver.FindElement(By.CssSelector("[data-form='Equip']"));

	public BaseInputControl IFF_EQUIP___PSEUDNOVOGR02 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDNOVOGR02']");
	public LookupControl IFF_EQUIP___CMPNYDESIGNAT => new LookupControl(driver, "CONTAINER_IFF_EQUIP___CMPNYDESIGNAT", "ValCodempre_chzn");
	public LookupControl IFF_EQUIP___PESS1NAME____ => new LookupControl(driver, "CONTAINER_IFF_EQUIP___PESS1NAME____", "ValCodpesso_chzn");
	public BaseInputControl LED_EQUIP___EQUIPSEQUENNR => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPSEQUENNR']");
	public BaseInputControl LED_EQUIP___EQUIPREGISTNR => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPREGISTNR']");
	public LookupControl IFF_EQUIP___TPEQUTIPOEQUI => new LookupControl(driver, "CONTAINER_IFF_EQUIP___TPEQUTIPOEQUI", "ValCodtpequ_chzn");
	public BaseInputControl LED_EQUIP___EQUIPSITEFABR => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPSITEFABR']");
	public LookupControl IFF_EQUIP___WAREHWAREHDES => new LookupControl(driver, "CONTAINER_IFF_EQUIP___WAREHWAREHDES", "ValCodwareh_chzn");
	public LookupControl IFF_EQUIP___ITEM_ITEMDES_ => new LookupControl(driver, "CONTAINER_IFF_EQUIP___ITEM_ITEMDES_", "ValCoditem_chzn");
	public BaseInputControl LED_EQUIP___EQUIPDESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPDESIGNAT']");
	public EnumControl LED_EQUIP___EQUIPFREQUENC => new EnumControl(driver, "CONTAINER_LED_EQUIP___EQUIPFREQUENC", "ValFrequenc_chzn_Equip");
	public BaseInputControl LED_EQUIP___EQUIPVALORTOT => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPVALORTOT']");
	public BaseInputControl LED_EQUIP___EQUIPDTAQUISI => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPDTAQUISI']");
	public BaseInputControl LED_EQUIP___EQUIPDTDECO__ => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPDTDECO__']");
	public BaseInputControl LED_EQUIP___EQUIPBOUGHT__ => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPBOUGHT__']");
	public LookupControl IFF_EQUIP___ROOM1ROOMNR__ => new LookupControl(driver, "CONTAINER_IFF_EQUIP___ROOM1ROOMNR__", "ValCodrooms_chzn");
	public BaseInputControl LED_EQUIP___ROOM1DESIGNAT => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___ROOM1DESIGNAT']");
	public BaseInputControl LED_EQUIP___EQUIPDTREFERE => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPDTREFERE']");
	public BaseInputControl LED_EQUIP___EQUIPFIRST___ => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPFIRST___']");
	public BaseInputControl LED_EQUIP___EQUIPBEFORE__ => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPBEFORE__']");
	public BaseInputControl LED_EQUIP___EQUIPFOLLOWIN => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPFOLLOWIN']");
	public BaseInputControl LED_EQUIP___EQUIPLAST____ => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPLAST____']");
	public BaseInputControl LED_EQUIP___EQUIPQTDMOVIM => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPQTDMOVIM']");
	public BaseInputControl LED_EQUIP___EQUIPMOVIMENT => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPMOVIMENT']");
	public BaseInputControl IFF_EQUIP___PSEUDNOVOGR10 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDNOVOGR10']");
	public BaseInputControl IFF_EQUIP___PSEUDMOVIMEVV => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDMOVIMEVV']");
	public BaseInputControl IFF_EQUIP___PSEUDROOMSMVE => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDROOMSMVE']");
	public BaseInputControl IFF_EQUIP___PSEUDNOVOGR06 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDNOVOGR06']");
	public BaseInputControl LED_EQUIP___EQUIPPHOTOGRA => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPPHOTOGRA']");
	public BaseInputControl LED_EQUIP___EQUIPLASTPHO_ => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPLASTPHO_']");
	public BaseInputControl IFF_EQUIP___PSEUDNOVOGR05 => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDNOVOGR05']");
	public ListControl IFF_EQUIP___PSEUDINSTALAG => new ListControl(driver, "ValInstalag", "#Equip_ValInstalag");
	public ListControl IFF_EQUIP___PSEUDINSTALAC => new ListControl(driver, "ValInstalac", "#Equip_ValInstalac");
	public ListControl IFF_EQUIP___PSEUDREPARACO => new ListControl(driver, "ValReparaco", "#Equip_ValReparaco");
	public ListControl IFF_EQUIP___PSEUDFOTOEQUI => new ListControl(driver, "ValFotoequi", "#Equip_ValFotoequi");
	public ListControl IFF_EQUIP___PSEUDVISEQUIP => new ListControl(driver, "ValVisequip", "#Equip_ValVisequip");
	public LookupControl IFF_EQUIP___DECOMDECOMNR_ => new LookupControl(driver, "CONTAINER_IFF_EQUIP___DECOMDECOMNR_", "ValCoddeco_chzn");
	public BaseInputControl LED_EQUIP___EQUIPIFABATIF => new BaseInputControl(driver, "[data-identifier='LED_EQUIP___EQUIPIFABATIF']");
	public ListControl IFF_EQUIP___PSEUDANEXOS__ => new ListControl(driver, "ValAnexos", "#Equip_ValAnexos");
	public BaseInputControl IFF_EQUIP___PSEUDTLEQUIPA => new BaseInputControl(driver, "[data-identifier='IFF_EQUIP___PSEUDTLEQUIPA']");
	public ListControl IFF_EQUIP___PSEUDMOVIMELS => new ListControl(driver, "ValMovimels", "#Equip_ValMovimels");

	private IWebElement saveBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='ok']"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector(".form-actions [qbutton='cancel']"));
	public FORM_MODE mode {get; private set;}

	public EquipForm(IWebDriver driver, FORM_MODE mode): base(driver) {
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
