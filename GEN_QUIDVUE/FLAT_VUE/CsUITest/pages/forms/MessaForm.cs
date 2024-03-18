namespace quidgest.uitests.pages;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class MessaForm: PageObject {

	private By formLocator = By.CssSelector("#form-container");
	private IWebElement form => driver.FindElement(formLocator);

	/// <summary>
	/// Notification ID
	/// </summary>
	public BaseInputControl MessaIdnotif => new BaseInputControl(driver, formLocator, "#MESSA___MESSAIDNOTIF_");
	/// <summary>
	/// Message ID
	/// </summary>
	public BaseInputControl MessaIdmsg => new BaseInputControl(driver, formLocator, "#MESSA___MESSAIDMSG___");
	/// <summary>
	/// E-mail sent
	/// </summary>
	public CheckboxInputControl MessaMailsent => new CheckboxInputControl(driver, formLocator, "#container-MESSA___MESSAMAILSENT");
	/// <summary>
	/// Error sending mail
	/// </summary>
	public BaseInputControl MessaMailerr => new BaseInputControl(driver, formLocator, "#MESSA___MESSAMAILERR_");
	/// <summary>
	/// Entity name
	/// </summary>
	public LookupControl EntitName => new LookupControl(driver, formLocator, "container-MESSA___ENTITNAME____");
	public SeeMorePage EntitNameSeeMorePage => new SeeMorePage(driver, "MESSA", "ENTIT.NAME");
	/// <summary>
	/// Person name
	/// </summary>
	public LookupControl PersoName => new LookupControl(driver, formLocator, "container-MESSA___PERSONAME____");
	public SeeMorePage PersoNameSeeMorePage => new SeeMorePage(driver, "MESSA", "PERSO.NAME");
	/// <summary>
	/// Document number
	/// </summary>
	public BaseInputControl MessaDocum_nr => new BaseInputControl(driver, formLocator, "#MESSA___MESSADOCUM_NR");
	/// <summary>
	/// To whom the message was sent
	/// </summary>
	public BaseInputControl MessaDesignat => new BaseInputControl(driver, formLocator, "#MESSA___MESSADESIGNAT");
	/// <summary>
	/// E-mail to whom the message was sent
	/// </summary>
	public BaseInputControl MessaEmail => new BaseInputControl(driver, formLocator, "#MESSA___MESSAEMAIL___");
	/// <summary>
	/// Message
	/// </summary>
	public BaseInputControl MessaMessage => new BaseInputControl(driver, formLocator, "#MESSA___MESSAMESSAGE_");
	/// <summary>
	/// Created by
	/// </summary>
	public BaseInputControl MessaCreatope => new BaseInputControl(driver, formLocator, "#MESSA___MESSACREATOPE");
	/// <summary>
	/// Created on
	/// </summary>
	public BaseInputControl MessaCreatdat => new BaseInputControl(driver, formLocator, "#MESSA___MESSACREATDAT");

	private IWebElement saveBtn => form.FindElement(By.CssSelector("#bottom-save-btn"));
	private IWebElement cancelBtn => form.FindElement(By.CssSelector("#bottom-cancel-btn"));
	public FORM_MODE mode {get; private set;}

	public MessaForm(IWebDriver driver, FORM_MODE mode, By subformLocator=null): base(driver) {
		this.mode = mode;
		formLocator = subformLocator ?? formLocator;

		wait.Until(c => form);
		WaitForLoading();
	}

	public void WaitForLoading()
	{
        wait.Until(c => form.FindElement(ByData.Key("MESSA")).GetAttribute("data-loading") != "true");
    }

	public void Save() {
		WaitForLoading();
		saveBtn.Click();
	}

	public void Cancel() {
		WaitForLoading();
		cancelBtn.Click();
	}

}
