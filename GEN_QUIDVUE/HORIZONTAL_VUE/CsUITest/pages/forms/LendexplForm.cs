using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class LendexplForm : Form
{
	/// <summary>
	/// Filtering
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#LENDEXPLPSEUDNEWGRP01-container");

	/// <summary>
	/// Lender: Gender
	/// </summary>
    public CheckboxGroupControl Pess1Gender_FG => new CheckboxGroupControl(driver, ContainerLocator, "container-LENDEXPLPESS1GENDER___FG");

	/// <summary>
	/// Equipment: Loan frequency
	/// </summary>
    public CheckboxGroupControl EquipFrequenc_FG => new CheckboxGroupControl(driver, ContainerLocator, "container-LENDEXPLEQUIPFREQUENC_FG");

	/// <summary>
	/// Equipment: Bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-LENDEXPLEQUIPBOUGHT__");

	/// <summary>
	/// Lending: Returned
	/// </summary>
	public CheckboxInputControl LendiReturned => new CheckboxInputControl(driver, ContainerLocator, "#container-LENDEXPLLENDIRETURNED");

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
}
