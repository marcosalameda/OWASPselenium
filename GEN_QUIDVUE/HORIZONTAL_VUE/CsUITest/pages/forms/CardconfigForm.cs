using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class CardconfigForm : Form
{
	/// <summary>
	/// Image
	/// </summary>
	public BaseInputControl CardsImage => new BaseInputControl(driver, ContainerLocator, "container-CARDCONFIG__CARDS__IMAGE", "#CARDCONFIG__CARDS__IMAGE");

	/// <summary>
	/// Title
	/// </summary>
	public BaseInputControl CardsTitle => new BaseInputControl(driver, ContainerLocator, "container-CARDCONFIG__CARDS__TITLE", "#CARDCONFIG__CARDS__TITLE");

	/// <summary>
	/// Subtitle
	/// </summary>
	public BaseInputControl CardsSubtitle => new BaseInputControl(driver, ContainerLocator, "container-CARDCONFIG__CARDS__SUBTITLE", "#CARDCONFIG__CARDS__SUBTITLE");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl CardsDescription => new BaseInputControl(driver, ContainerLocator, "container-CARDCONFIG__CARDS__DESCRIPTION", "#CARDCONFIG__CARDS__DESCRIPTION");

	public CardconfigForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CARDCONFIG", containerLocator: containerLocator) { }
}
