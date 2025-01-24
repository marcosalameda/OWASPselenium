using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReparForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-REPAR___EQUIPREGISTNR");
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "REPAR", "REPAR___EQUIPREGISTNR");

	/// <summary>
	/// Designation
	/// </summary>
	public IWebElement EquipDesignat => throw new NotImplementedException();

	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement EquipPhotogra => throw new NotImplementedException();

	/// <summary>
	/// Repaired on
	/// </summary>
	public DateInputControl ReparDtrepara => new DateInputControl(driver, ContainerLocator, "#REPAR___REPARDTREPARA", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Company Repair Number
	/// </summary>
	public BaseInputControl ReparNrrepara => new BaseInputControl(driver, ContainerLocator, "#REPAR___REPARNRREPARA");

	/// <summary>
	/// Technical area
	/// </summary>
	public RadiobuttonControl ReparTipoarea => new RadiobuttonControl(driver, ContainerLocator, "container-REPAR___REPARTIPOAREA");

	/// <summary>
	/// Specialty
	/// </summary>
	public LookupControl SpeciEspecial => new LookupControl(driver, ContainerLocator, "container-REPAR___SPECIESPECIAL");
	public SeeMorePage SpeciEspecialSeeMorePage => new SeeMorePage(driver, "REPAR", "REPAR___SPECIESPECIAL");

	/// <summary>
	/// Technician
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-REPAR___PESSONAME____");
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "REPAR", "REPAR___PESSONAME____");

	/// <summary>
	/// Repair Description
	/// </summary>
	public BaseInputControl ReparDescript => new BaseInputControl(driver, ContainerLocator, "#REPAR___REPARDESCRIPT");

	/// <summary>
	/// Spent in Hours
	/// </summary>
	public BaseInputControl ReparHours => new BaseInputControl(driver, ContainerLocator, "#REPAR___REPARHOURS___");

	public ReparForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "REPAR", containerLocator: containerLocator) { }
}
