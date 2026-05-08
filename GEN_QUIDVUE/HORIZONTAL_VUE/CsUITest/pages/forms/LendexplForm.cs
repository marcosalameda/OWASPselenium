using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LendexplForm : Form
{
	/// <summary>
	/// Filtering
	/// </summary>
	public IWebElement PseudNewgrp01 => throw new NotImplementedException();

	/// <summary>
	/// Lender: Gender
	/// </summary>
	public IWebElement Pess1Gender => throw new NotImplementedException();

	/// <summary>
	/// Equipment: Loan frequency
	/// </summary>
	public IWebElement EquipFrequenc => throw new NotImplementedException();

	/// <summary>
	/// Equipment: Bought
	/// </summary>
	public IWebElement EquipBought => throw new NotImplementedException();

	/// <summary>
	/// Lending: Returned
	/// </summary>
	public IWebElement LendiReturned => throw new NotImplementedException();

	/// <summary>
	/// Lenders
	/// </summary>
	public ListControl PseudLenders => new ListControl(driver, ContainerLocator, "#LENDEXPLPSEUDLENDERS_");

	/// <summary>
	/// Equipment
	/// </summary>
	public ListControl PseudEquips => new ListControl(driver, ContainerLocator, "#LENDEXPLPSEUDEQUIPS__");

	/// <summary>
	/// Lendings
	/// </summary>
	public ListControl PseudLendings => new ListControl(driver, ContainerLocator, "#LENDEXPLPSEUDLENDINGS");

	public LendexplForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "LENDEXPL", containerLocator: containerLocator) { }
    public IWebElement LendiReturned_FG => null;
    public IWebElement EquipBought_FG => null;
    public IWebElement Pess1Gender_FG => null;

}
