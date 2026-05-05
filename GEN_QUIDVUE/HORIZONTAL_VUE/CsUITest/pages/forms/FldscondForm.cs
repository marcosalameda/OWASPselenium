using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class FldscondForm : Form
{
	/// <summary>
	/// Field state
	/// </summary>
	public RadiobuttonControl FldsCond => new RadiobuttonControl(driver, ContainerLocator, "container-FLDSCONDFLDS_COND____");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudGroup4 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSCONDPSEUDGROUP4__-container");

	/// <summary>
	/// Cumprir condições da tabela
	/// </summary>
	public CheckboxInputControl FldsTblcond => new CheckboxInputControl(driver, ContainerLocator, "#container-FLDSCONDFLDS_TBLCOND_");

	/// <summary>
	/// Cumprir condições do formulário
	/// </summary>
	public CheckboxInputControl FldsFormcond => new CheckboxInputControl(driver, ContainerLocator, "#container-FLDSCONDFLDS_FORMCOND");

	/// <summary>
	/// Campos com condições na tabela
	/// </summary>
	public CollapsibleZoneControl PseudGroup1 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSCONDPSEUDGROUP1__-container");

	/// <summary>
	/// Campo com condições client-side
	/// </summary>
	public BaseInputControl FldsFclient1 => new BaseInputControl(driver, ContainerLocator, "container-FLDSCONDFLDS_FCLIENT1", "#FLDSCONDFLDS_FCLIENT1");

	/// <summary>
	/// Campo com condição de Preenchimento
	/// </summary>
	public BaseInputControl FldsFfillwhn => new BaseInputControl(driver, ContainerLocator, "container-FLDSCONDFLDS_FFILLWHN", "#FLDSCONDFLDS_FFILLWHN");

	/// <summary>
	/// Campo com condições server-side
	/// </summary>
	public DateInputControl FldsFserver1 => new DateInputControl(driver, ContainerLocator, "#FLDSCONDFLDS_FSERVER1", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// Campos com condições no formulário
	/// </summary>
	public CollapsibleZoneControl PseudGroup2 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSCONDPSEUDGROUP2__-container");

	/// <summary>
	/// Campo com condições client-side
	/// </summary>
	public CheckboxInputControl FldsFclient2 => new CheckboxInputControl(driver, ContainerLocator, "#container-FLDSCONDFLDS_FCLIENT2");

	/// <summary>
	/// Campo com condições server-side
	/// </summary>
	public BaseInputControl FldsFserver2 => new BaseInputControl(driver, ContainerLocator, "container-FLDSCONDFLDS_FSERVER2", "#FLDSCONDFLDS_FSERVER2");

	/// <summary>
	/// Campos com condições na tabela e no formulário
	/// </summary>
	public CollapsibleZoneControl PseudGroup3 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSCONDPSEUDGROUP3__-container");

	/// <summary>
	/// Campo com condições client-side
	/// </summary>
	public DocumentControl FldsFclient3 => new DocumentControl(driver, ContainerLocator, "FLDSCONDFLDS_FCLIENT3");

	/// <summary>
	/// Campo com condições server-side
	/// </summary>
	public BaseInputControl FldsFserver3 => new BaseInputControl(driver, ContainerLocator, "container-FLDSCONDFLDS_FSERVER3", "#FLDSCONDFLDS_FSERVER3");

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudGroup5 => new CollapsibleZoneControl(driver, ContainerLocator, "#FLDSCONDPSEUDGROUP5__-container");

	/// <summary>
	/// Test
	/// </summary>
	public IWebElement PseudStatictx => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public FldscondPseudGridtblGrid PseudGridtbl => new FldscondPseudGridtblGrid(driver, ContainerLocator, "#FLDSCONDPSEUDGRIDTBL_");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudListtbl => new ListControl(driver, ContainerLocator, "#FLDSCONDPSEUDLISTTBL_");

	/// <summary>
	/// Test
	/// </summary>
	public ButtonControl PseudListbtn => new ButtonControl(driver, ContainerLocator, "#FLDSCONDPSEUDLISTBTN_");

	/// <summary>
	/// Form
	/// </summary>
	public ButtonControl PseudListbtn2 => new ButtonControl(driver, ContainerLocator, "#FLDSCONDPSEUDLISTBTN2");

	public FldscondForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "FLDSCOND", containerLocator: containerLocator) { }
}
