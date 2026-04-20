using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ReparForm : Form
{
	/// <summary>
	/// Registration No.
	/// </summary>
	public LookupControl EquipRegistnr => new LookupControl(driver, ContainerLocator, "container-REPAR___EQUIPREGISTNR" + IdSuffix);
	public SeeMorePage EquipRegistnrSeeMorePage => new SeeMorePage(driver, "REPAR", "REPAR___EQUIPREGISTNR" + IdSuffix);

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
	public DateInputControl ReparDtrepara => new DateInputControl(driver, ContainerLocator, "#REPAR___REPARDTREPARA" + IdSuffix, "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Company Repair Number
	/// </summary>
	public BaseInputControl ReparNrrepara => new BaseInputControl(driver, ContainerLocator, "container-REPAR___REPARNRREPARA" + IdSuffix, "#REPAR___REPARNRREPARA" + IdSuffix);

	/// <summary>
	/// Technical area
	/// </summary>
	public RadiobuttonControl ReparTipoarea => new RadiobuttonControl(driver, ContainerLocator, "container-REPAR___REPARTIPOAREA" + IdSuffix);

	/// <summary>
	/// Specialty
	/// </summary>
	public LookupControl SpeciEspecial => new LookupControl(driver, ContainerLocator, "container-REPAR___SPECIESPECIAL" + IdSuffix);
	public SeeMorePage SpeciEspecialSeeMorePage => new SeeMorePage(driver, "REPAR", "REPAR___SPECIESPECIAL" + IdSuffix);

	/// <summary>
	/// Technician
	/// </summary>
	public LookupControl PessoName => new LookupControl(driver, ContainerLocator, "container-REPAR___PESSONAME____" + IdSuffix);
	public SeeMorePage PessoNameSeeMorePage => new SeeMorePage(driver, "REPAR", "REPAR___PESSONAME____" + IdSuffix);

	/// <summary>
	/// Repair Description
	/// </summary>
	public BaseInputControl ReparDescript => new BaseInputControl(driver, ContainerLocator, "container-REPAR___REPARDESCRIPT" + IdSuffix, "#REPAR___REPARDESCRIPT" + IdSuffix);

	/// <summary>
	/// Spent in Hours
	/// </summary>
	public BaseInputControl ReparHours => new BaseInputControl(driver, ContainerLocator, "container-REPAR___REPARHOURS___" + IdSuffix, "#REPAR___REPARHOURS___" + IdSuffix);

	public ReparForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "REPAR", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
