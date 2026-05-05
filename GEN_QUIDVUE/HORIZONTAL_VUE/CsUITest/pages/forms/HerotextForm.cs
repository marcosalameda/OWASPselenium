using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class HerotextForm : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROTEXTPSEUDNEWGRP01-container");

	/// <summary>
	/// <p><small><strong>SUB-TITLE</strong></small></p>
	/// </summary>
	public IWebElement PseudField002 => throw new NotImplementedException();

	/// <summary>
	/// <h2><strong>Title</strong></h2>
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut <p>
	/// </summary>
	public IWebElement PseudField003 => throw new NotImplementedException();

	/// <summary>
	/// Action
	/// </summary>
	public IWebElement PseudHerobut => throw new NotImplementedException();

	/// <summary>
	/// Updated in DD/MM/YYYY
	/// </summary>
	public IWebElement PseudField007 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HerodescripHrdescrip => new BaseInputControl(driver, ContainerLocator, "container-HEROTEXT__HERODESCRIP__HRDESCRIP", "#HEROTEXT__HERODESCRIP__HRDESCRIP");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#HEROTEXTPSEUDNEWGRP02-container");

	/// <summary>
	/// New Data Display
	/// </summary>
	public IWebElement PseudField006 => throw new NotImplementedException();

	/// <summary>
	/// <h2><strong>Title</strong></h2>
	/// </summary>
	public IWebElement PseudField004 => throw new NotImplementedException();

	/// <summary>
	/// <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut <p>
	/// </summary>
	public IWebElement PseudField005 => throw new NotImplementedException();

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl HerodescripHrdescripicon => new BaseInputControl(driver, ContainerLocator, "container-HEROTEXT__HERODESCRIP__HRDESCRIPICON", "#HEROTEXT__HERODESCRIP__HRDESCRIPICON");

	public HerotextForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "HEROTEXT", "HEROCSEC", containerLocator: containerLocator) { }
}
