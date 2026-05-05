using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class HerocsecForm : Form
{
	/// <summary>
	/// A callout or hero section is the prominent, visually dominant area at the top
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// of a webpage designed to make a strong first impression
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// Text only
	/// </summary>
	public TabControl PseudHerotext => new TabControl(driver, ContainerLocator, "#tab-container-HEROCSECPSEUDHEROTEXT");

	/// <summary>
	/// With image
	/// </summary>
	public TabControl PseudHeroimg => new TabControl(driver, ContainerLocator, "#tab-container-HEROCSECPSEUDHEROIMG_");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl HerotextPseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROTEXTPSEUDNEWGRP01-container");

	/// <summary>
	/// <p><small><strong>SUB-TITLE</strong></small></p>
	/// </summary>
	public IWebElement HerotextPseudField002 => throw new NotImplementedException();

	/// <summary>
	/// <h2><strong>Title</strong></h2>
	/// </summary>
	public IWebElement HerotextPseudField001 => throw new NotImplementedException();

	/// <summary>
	/// <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut <p>
	/// </summary>
	public IWebElement HerotextPseudField003 => throw new NotImplementedException();

	/// <summary>
	/// Action
	/// </summary>
	public IWebElement HerotextPseudHerobut => throw new NotImplementedException();

	/// <summary>
	/// Updated in DD/MM/YYYY
	/// </summary>
	public IWebElement HerotextPseudField007 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HerotextHerodescripHrdescrip => new BaseInputControl(driver, ContainerLocator, "container-HEROTEXT__HERODESCRIP__HRDESCRIP", "#HEROTEXT__HERODESCRIP__HRDESCRIP");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl HerotextPseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROTEXTPSEUDNEWGRP02-container");

	/// <summary>
	/// New Data Display
	/// </summary>
	public IWebElement HerotextPseudField006 => throw new NotImplementedException();

	/// <summary>
	/// <h2><strong>Title</strong></h2>
	/// </summary>
	public IWebElement HerotextPseudField004 => throw new NotImplementedException();

	/// <summary>
	/// <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut <p>
	/// </summary>
	public IWebElement HerotextPseudField005 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HerotextHerodescripHrdescripicon => new BaseInputControl(driver, ContainerLocator, "container-HEROTEXT__HERODESCRIP__HRDESCRIPICON", "#HEROTEXT__HERODESCRIP__HRDESCRIPICON");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl HeroimgPseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROIMG_PSEUDNEWGRP02-container");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement HeroimgPseudField007 => throw new NotImplementedException();

	/// <summary>
	/// Module<p><strong>WMS</strong>
	/// </summary>
	public IWebElement HeroimgPseudField004 => throw new NotImplementedException();

	/// <summary>
	/// Module designation<p><strong>Warehouse Management System</strong>
	/// </summary>
	public IWebElement HeroimgPseudField005 => throw new NotImplementedException();

	/// <summary>
	/// Order<p><strong>721</strong>
	/// </summary>
	public IWebElement HeroimgPseudField006 => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl HeroimgPseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROIMG_PSEUDNEWGRP03-container");

	/// <summary>
	/// Menu item Type
	/// </summary>
	public IWebElement HeroimgPseudField008 => throw new NotImplementedException();

	/// <summary>
	/// Menu item Type
	/// </summary>
	public IWebElement HeroimgPseudField009 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HeroimgHerodescripHrdescripmod => new BaseInputControl(driver, ContainerLocator, "container-HEROIMG__HERODESCRIP__HRDESCRIPMOD", "#HEROIMG__HERODESCRIP__HRDESCRIPMOD");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl HeroimgPseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROIMG_PSEUDNEWGRP01-container");

	/// <summary>
	/// Static Image test
	/// </summary>
	public IWebElement HeroimgPseudField002 => throw new NotImplementedException();

	/// <summary>
	/// Employee N.<p><strong>55</strong></p>Birth date<p><strong>15/08/2000</strong></p
	/// </summary>
	public IWebElement HeroimgPseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Name<p><strong>John Doe</strong></p>Label<p><strong>Lorem ipsum </strong></p
	/// </summary>
	public IWebElement HeroimgPseudField003 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HeroimgHerodescripHrdescripimage => new BaseInputControl(driver, ContainerLocator, "container-HEROIMG__HERODESCRIP__HRDESCRIPIMAGE", "#HEROIMG__HERODESCRIP__HRDESCRIPIMAGE");

	public HerocsecForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "HEROCSEC", containerLocator: containerLocator) { }
}
