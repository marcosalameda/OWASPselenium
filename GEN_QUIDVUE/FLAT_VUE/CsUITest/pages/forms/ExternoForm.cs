using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ExternoForm : Form
{
	/// <summary>
	/// COMPANY
	/// </summary>
	public CollapsibleZoneControl PseudNovogr01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EXTERNO_PSEUDNOVOGR01-container");

	/// <summary>
	/// Company:
	/// </summary>
	public LookupControl CmpnyDesignat => new LookupControl(driver, ContainerLocator, "container-EXTERNO_CMPNYDESIGNAT");
	public SeeMorePage CmpnyDesignatSeeMorePage => new SeeMorePage(driver, "EXTERNO", "EXTERNO_CMPNYDESIGNAT");

	/// <summary>
	/// IDENTIFICATION
	/// </summary>
	public CollapsibleZoneControl PseudNovogr02 => new CollapsibleZoneControl(driver, ContainerLocator, "#EXTERNO_PSEUDNOVOGR02-container");

	/// <summary>
	/// Name:
	/// </summary>
	public BaseInputControl PessoName => new BaseInputControl(driver, ContainerLocator, "container-EXTERNO_PESSONAME____", "#EXTERNO_PESSONAME____");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PessoGender => new EnumControl(driver, ContainerLocator, "container-EXTERNO_PESSOGENDER__");

	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#EXTERNO_PSEUDNOVOGR03-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, ContainerLocator, "container-EXTERNO_PESSOTELEPHON", "#EXTERNO_PESSOTELEPHON");

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, ContainerLocator, "container-EXTERNO_PESSOEMAIL___", "#EXTERNO_PESSOEMAIL___");

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#EXTERNO_PSEUDNOVOGR04-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-EXTERNO_PESSOPHOTOGRA", "#EXTERNO_PESSOPHOTOGRA");

	/// <summary>
	/// @required
	/// </summary>
	public IWebElement PseudObrigato => throw new NotImplementedException();

	public ExternoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EXTERNO", containerLocator: containerLocator) { }
}
