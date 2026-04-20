using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class Pessos01Form : Subform
{
	/// <summary>
	/// ACCORDION
	/// </summary>
	public IWebElement PseudNovogr06 => throw new NotImplementedException();

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr03 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR03" + IdSuffix + "-container");

	/// <summary>
	/// Telephone
	/// </summary>
	public BaseInputControl PessoTelephon => new BaseInputControl(driver, ContainerLocator, "container-PESSOS01PESSOTELEPHON" + IdSuffix, "#PESSOS01PESSOTELEPHON" + IdSuffix);

	/// <summary>
	/// Email:
	/// </summary>
	public BaseInputControl PessoEmail => new BaseInputControl(driver, ContainerLocator, "container-PESSOS01PESSOEMAIL___" + IdSuffix, "#PESSOS01PESSOEMAIL___" + IdSuffix);

	/// <summary>
	/// PHOTO
	/// </summary>
	public CollapsibleZoneControl PseudNovogr04 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR04" + IdSuffix + "-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl PessoPhotogra => new BaseInputControl(driver, ContainerLocator, "container-PESSOS01PESSOPHOTOGRA" + IdSuffix, "#PESSOS01PESSOPHOTOGRA" + IdSuffix);

	/// <summary>
	/// CAREER
	/// </summary>
	public CollapsibleZoneControl PseudNovogr05 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR05" + IdSuffix + "-container");

	/// <summary>
	/// Professional Category Evolution
	/// </summary>
	public ListControl PseudEvolucao => new ListControl(driver, ContainerLocator, "#PESSOS01PSEUDEVOLUCAO" + IdSuffix);

	/// <summary>
	/// Career record
	/// </summary>
	public EvcatForm  PseudFichacar => new EvcatForm(driver, FORM_MODE.EDIT, By.Id("PESSOS01PSEUDFICHACAR"), usePkInId: true);

	/// <summary>
	/// CONTACT
	/// </summary>
	public CollapsibleZoneControl PseudNovogr07 => new CollapsibleZoneControl(driver, ContainerLocator, "#PESSOS01PSEUDNOVOGR07" + IdSuffix + "-container");

	/// <summary>
	/// Contacts
	/// </summary>
	public ListControl PseudContacto => new ListControl(driver, ContainerLocator, "#PESSOS01PSEUDCONTACTO" + IdSuffix);

	public Pessos01Form(IWebDriver driver, FORM_MODE mode, By? containerLocator = null, bool usePkInId = false)
		: base(driver, mode, "PESSOS01", "PESSOSEP", containerLocator: containerLocator, usePkInId: usePkInId) { }
}
