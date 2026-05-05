using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class HeroimgForm : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROIMG_PSEUDNEWGRP02-container");

	/// <summary>
	/// 
	/// </summary>
	public IWebElement PseudField007 => throw new NotImplementedException();

	/// <summary>
	/// Module<p><strong>WMS</strong>
	/// </summary>
	public IWebElement PseudField004 => throw new NotImplementedException();

	/// <summary>
	/// Module designation<p><strong>Warehouse Management System</strong>
	/// </summary>
	public IWebElement PseudField005 => throw new NotImplementedException();

	/// <summary>
	/// Order<p><strong>721</strong>
	/// </summary>
	public IWebElement PseudField006 => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROIMG_PSEUDNEWGRP03-container");

	/// <summary>
	/// Menu item Type
	/// </summary>
	public IWebElement PseudField008 => throw new NotImplementedException();

	/// <summary>
	/// Menu item Type
	/// </summary>
	public IWebElement PseudField009 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HerodescripHrdescripmod => new BaseInputControl(driver, ContainerLocator, "container-HEROIMG__HERODESCRIP__HRDESCRIPMOD", "#HEROIMG__HERODESCRIP__HRDESCRIPMOD");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROIMG_PSEUDNEWGRP01-container");

	/// <summary>
	/// Static Image test
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// Employee N.<p><strong>55</strong></p>Birth date<p><strong>15/08/2000</strong></p
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Name<p><strong>John Doe</strong></p>Label<p><strong>Lorem ipsum </strong></p
	/// </summary>
	public IWebElement PseudField003 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HerodescripHrdescripimage => new BaseInputControl(driver, ContainerLocator, "container-HEROIMG__HERODESCRIP__HRDESCRIPIMAGE", "#HEROIMG__HERODESCRIP__HRDESCRIPIMAGE");

	public HeroimgForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "HEROIMG", "HEROCSEC", containerLocator: containerLocator) { }
}
