using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GencoForm : Form
{
	/// <summary>
	/// Contact Genre
	/// </summary>
	public EnumControl GenreAgencont => new EnumControl(driver, ContainerLocator, "container-GENCO___GENREAGENCONT");

	/// <summary>
	/// Genre
	/// </summary>
	public BaseInputControl GenreGender => new BaseInputControl(driver, ContainerLocator, "container-GENCO___GENREGENDER__", "#GENCO___GENREGENDER__");

	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl GenreBackcolo => new BaseInputControl(driver, ContainerLocator, "container-GENCO___GENREBACKCOLO", "#GENCO___GENREBACKCOLO");

	/// <summary>
	/// Text Color
	/// </summary>
	public BaseInputControl GenreTextcolo => new BaseInputControl(driver, ContainerLocator, "container-GENCO___GENRETEXTCOLO", "#GENCO___GENRETEXTCOLO");

	public GencoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "GENCO", containerLocator: containerLocator) { }
}
