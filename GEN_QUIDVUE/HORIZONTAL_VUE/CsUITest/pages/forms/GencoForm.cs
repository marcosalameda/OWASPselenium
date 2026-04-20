using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class GencoForm : Form
{
	/// <summary>
	/// Contact Genre
	/// </summary>
	public EnumControl GenreAgencont => new EnumControl(driver, ContainerLocator, "container-GENCO___GENREAGENCONT" + IdSuffix);

	/// <summary>
	/// Genre
	/// </summary>
	public BaseInputControl GenreGender => new BaseInputControl(driver, ContainerLocator, "container-GENCO___GENREGENDER__" + IdSuffix, "#GENCO___GENREGENDER__" + IdSuffix);

	/// <summary>
	/// Background Color
	/// </summary>
	public BaseInputControl GenreBackcolo => new BaseInputControl(driver, ContainerLocator, "container-GENCO___GENREBACKCOLO" + IdSuffix, "#GENCO___GENREBACKCOLO" + IdSuffix);

	/// <summary>
	/// Text Color
	/// </summary>
	public BaseInputControl GenreTextcolo => new BaseInputControl(driver, ContainerLocator, "container-GENCO___GENRETEXTCOLO" + IdSuffix, "#GENCO___GENRETEXTCOLO" + IdSuffix);

	public GencoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "GENCO", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
