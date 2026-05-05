using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CardsForm : Form
{
	/// <summary>
	/// card
	/// </summary>
	public TabControl PseudCard1 => new TabControl(driver, ContainerLocator, "#tab-container-CARDS___PSEUDCARD1___");

	/// <summary>
	/// 
	/// </summary>
	public ListControl Card1PseudCardnormal => new ListControl(driver, ContainerLocator, "#CARD1__PSEUD__CARDNORMAL");

	/// <summary>
	/// Configurations
	/// </summary>
	public CollapsibleZoneControl Card1PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#CARD1___PSEUDNEWGRP01-container");

	/// <summary>
	/// Actions placement
	/// </summary>
	public RadiobuttonControl Card1CardsActionsplace => new RadiobuttonControl(driver, ContainerLocator, "container-CARD1__CARDS__ACTIONSPLACE");

	/// <summary>
	/// Actions alignment
	/// </summary>
	public RadiobuttonControl Card1CardsActonsalign => new RadiobuttonControl(driver, ContainerLocator, "container-CARD1__CARDS__ACTONSALIGN");

	/// <summary>
	/// Actions style
	/// </summary>
	public RadiobuttonControl Card1CardsActionsstyle => new RadiobuttonControl(driver, ContainerLocator, "container-CARD1__CARDS__ACTIONSSTYLE");

	public CardsForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CARDS", containerLocator: containerLocator) { }
}
