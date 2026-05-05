using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Card1Form : Subform
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudCardnormal => new ListControl(driver, ContainerLocator, "#CARD1__PSEUD__CARDNORMAL");

	/// <summary>
	/// Configurations
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#CARD1___PSEUDNEWGRP01-container");

	/// <summary>
	/// Actions placement
	/// </summary>
	public RadiobuttonControl CardsActionsplace => new RadiobuttonControl(driver, ContainerLocator, "container-CARD1__CARDS__ACTIONSPLACE");

	/// <summary>
	/// Actions alignment
	/// </summary>
	public RadiobuttonControl CardsActonsalign => new RadiobuttonControl(driver, ContainerLocator, "container-CARD1__CARDS__ACTONSALIGN");

	/// <summary>
	/// Actions style
	/// </summary>
	public RadiobuttonControl CardsActionsstyle => new RadiobuttonControl(driver, ContainerLocator, "container-CARD1__CARDS__ACTIONSSTYLE");

	public Card1Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CARD1", "CARDS", containerLocator: containerLocator) { }
}
