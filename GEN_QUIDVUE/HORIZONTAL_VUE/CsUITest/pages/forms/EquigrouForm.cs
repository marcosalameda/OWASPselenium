using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class EquigrouForm : Form
{
	/// <summary>
	/// Default style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp19 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP19-container");

	/// <summary>
	/// Owner
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp13 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP13-container");

	/// <summary>
	/// Photo
	/// </summary>
	public IWebElement Pess1Photogra => throw new NotImplementedException();

	/// <summary>
	/// Name
	/// </summary>
	public LookupControl Pess1Name => new LookupControl(driver, ContainerLocator, "container-EQUIGROUPESS1NAME____");
	public SeeMorePage Pess1NameSeeMorePage => new SeeMorePage(driver, "EQUIGROU", "EQUIGROUPESS1NAME____");

	/// <summary>
	/// Genre
	/// </summary>
	public IWebElement Pess1Gender => throw new NotImplementedException();

	/// <summary>
	/// 
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp14 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP14-container");

	/// <summary>
	/// Birth
	/// </summary>
	public IWebElement Pess1Dtnascim => throw new NotImplementedException();

	/// <summary>
	/// Age
	/// </summary>
	public IWebElement Pess1Idade => throw new NotImplementedException();

	/// <summary>
	/// New Group
	/// </summary>
	public IWebElement PseudNewgrp17 => throw new NotImplementedException();

	/// <summary>
	/// group in accordian 1st
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp15 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP15-container");

	/// <summary>
	/// Official No.
	/// </summary>
	public IWebElement Pess1Idfuncio => throw new NotImplementedException();

	/// <summary>
	/// Phone
	/// </summary>
	public IWebElement Pess1Telephon => throw new NotImplementedException();

	/// <summary>
	/// group in accordian 2nd
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp16 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP16-container");

	/// <summary>
	/// Email 1
	/// </summary>
	public IWebElement Pess1Email => throw new NotImplementedException();

	/// <summary>
	/// Email 2
	/// </summary>
	public IWebElement Pess1Email2 => throw new NotImplementedException();

	/// <summary>
	/// Mixed style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp18 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP18-container");

	/// <summary>
	/// @mixed_zones
	/// </summary>
	public IWebElement PseudField001 => throw new NotImplementedException();

	/// <summary>
	/// Company
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP01-container");

	/// <summary>
	/// Identification
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP02-container");

	/// <summary>
	/// Logo
	/// </summary>
	public IWebElement CmpnyLogo => throw new NotImplementedException();

	/// <summary>
	/// Designation
	/// </summary>
	public IWebElement CmpnyDesignat => throw new NotImplementedException();

	/// <summary>
	/// Acronym
	/// </summary>
	public IWebElement CmpnyAcronym => throw new NotImplementedException();

	/// <summary>
	/// Tax identification
	/// </summary>
	public IWebElement CmpnyNif => throw new NotImplementedException();

	/// <summary>
	/// Contacts
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP03-container");

	/// <summary>
	/// Phone
	/// </summary>
	public IWebElement CmpnyTelephon => throw new NotImplementedException();

	/// <summary>
	/// Email
	/// </summary>
	public IWebElement CmpnyEmail => throw new NotImplementedException();

	/// <summary>
	/// Collapsible style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp21 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP21-container");

	/// <summary>
	/// Audit
	/// </summary>
	public IWebElement PseudNewgrp08 => throw new NotImplementedException();

	/// <summary>
	/// Changes number
	/// </summary>
	public BaseInputControl EquipQtdmovim => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPQTDMOVIM");

	/// <summary>
	/// Acquisition
	/// </summary>
	public DateInputControl EquipDtaquisi => new DateInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPDTAQUISI");

	/// <summary>
	/// Groupbox styles
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp23 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP23-container");

	/// <summary>
	/// 1. c-groupbox--title-background
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp09 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP09-container");

	/// <summary>
	/// It is nest within the first zone and it has the same style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp10 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP10-container");

	/// <summary>
	/// TYPE OF EQUIPMENT
	/// </summary>
	public LookupControl TpequTipoequi => new LookupControl(driver, ContainerLocator, "container-EQUIGROUTPEQUTIPOEQUI");
	public SeeMorePage TpequTipoequiSeeMorePage => new SeeMorePage(driver, "EQUIGROU", "EQUIGROUTPEQUTIPOEQUI");

	/// <summary>
	/// Code
	/// </summary>
	public IWebElement TpequTpequcod => throw new NotImplementedException();

	/// <summary>
	/// Maximum price
	/// </summary>
	public IWebElement TpequPrecomax => throw new NotImplementedException();

	/// <summary>
	/// It is nest within the second zone and it has the default style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp11 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP11-container");

	/// <summary>
	/// Dependent on
	/// </summary>
	public IWebElement TpequTpequpai => throw new NotImplementedException();

	/// <summary>
	/// Level
	/// </summary>
	public IWebElement TpequNivel => throw new NotImplementedException();

	/// <summary>
	/// It is nest within the third zone and it has the default style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp12 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP12-container");

	/// <summary>
	/// Background color
	/// </summary>
	public IWebElement TpequBackcolo => throw new NotImplementedException();

	/// <summary>
	/// Letter color
	/// </summary>
	public IWebElement TpequCorletra => throw new NotImplementedException();

	/// <summary>
	/// 2. c-groupbox--minor
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp07 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP07-container");

	/// <summary>
	/// Sequential no.
	/// </summary>
	public BaseInputControl EquipSequennr => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPSEQUENNR");

	/// <summary>
	/// No. register
	/// </summary>
	public BaseInputControl EquipRegistnr => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPREGISTNR");

	/// <summary>
	/// Total value
	/// </summary>
	public BaseInputControl EquipValortot => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPVALORTOT");

	/// <summary>
	/// It is nest within the first zone and it has the same style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp05 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP05-container");

	/// <summary>
	/// Loan frequency
	/// </summary>
	public EnumControl EquipFrequenc => new EnumControl(driver, ContainerLocator, "container-EQUIGROUEQUIPFREQUENC");

	/// <summary>
	/// Bought
	/// </summary>
	public CheckboxInputControl EquipBought => new CheckboxInputControl(driver, ContainerLocator, "#container-EQUIGROUEQUIPBOUGHT__");

	/// <summary>
	/// Reference
	/// </summary>
	public DateInputControl EquipDtrefere => new DateInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPDTREFERE", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// First
	/// </summary>
	public BaseInputControl EquipFirst => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPFIRST___");

	/// <summary>
	/// 3. c-groupbox--minor-border-top
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp04 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP04-container");

	/// <summary>
	/// Photo
	/// </summary>
	public BaseInputControl EquipPhotogra => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPPHOTOGRA");

	/// <summary>
	/// It is nest within the first zone and it has the same style
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp06 => new CollapsibleZoneControl(driver, ContainerLocator, "#EQUIGROUPSEUDNEWGRP06-container");

	/// <summary>
	/// Designation
	/// </summary>
	public BaseInputControl EquipDesignat => new BaseInputControl(driver, ContainerLocator, "#EQUIGROUEQUIPDESIGNAT");

	public EquigrouForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EQUIGROU", containerLocator: containerLocator) { }
}
