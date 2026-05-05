using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class RecordinforForm : Form
{
	/// <summary>
	/// record information
	/// </summary>
	public IWebElement PseudNewgrp01 => throw new NotImplementedException();

	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl RecordinfoReccreationdate => new BaseInputControl(driver, ContainerLocator, "container-RECORDINFOR__RECORDINFO__RECCREATIONDATE", "#RECORDINFOR__RECORDINFO__RECCREATIONDATE");

	/// <summary>
	/// by
	/// </summary>
	public BaseInputControl RecordinfoReccreator => new BaseInputControl(driver, ContainerLocator, "container-RECORDINFOR__RECORDINFO__RECCREATOR", "#RECORDINFOR__RECORDINFO__RECCREATOR");

	/// <summary>
	/// Changed on
	/// </summary>
	public BaseInputControl RecordinfoRecchangedate => new BaseInputControl(driver, ContainerLocator, "container-RECORDINFOR__RECORDINFO__RECCHANGEDATE", "#RECORDINFOR__RECORDINFO__RECCHANGEDATE");

	/// <summary>
	/// by
	/// </summary>
	public BaseInputControl RecordinfoRecchange => new BaseInputControl(driver, ContainerLocator, "container-RECORDINFOR__RECORDINFO__RECCHANGE", "#RECORDINFOR__RECORDINFO__RECCHANGE");

	/// <summary>
	/// Description
	/// </summary>
	public BaseInputControl RecordinfoRecdescript => new BaseInputControl(driver, ContainerLocator, "container-RECORDINFOR__RECORDINFO__RECDESCRIPT", "#RECORDINFOR__RECORDINFO__RECDESCRIPT");

	public RecordinforForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "RECORDINFOR", containerLocator: containerLocator) { }
}
