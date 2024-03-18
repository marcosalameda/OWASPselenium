namespace quidgest.uitests.pages;

public class MenuListPage: PageObject {

	private string id;

	private IWebElement page => driver.FindElement(By.ClassName(this.id));

    public ListControl List => new ListControl(driver, By.Id("form-container"), "form .q-table-list");

	public MenuListPage(IWebDriver driver, string module, string menuId): base(driver) {
		if (string.IsNullOrEmpty(module)) throw new ArgumentException($"{nameof(module)} must contain value.");
		if (string.IsNullOrEmpty(menuId)) throw new ArgumentException($"{nameof(menuId)} must contain value.");
		
		this.id = module.ToUpperInvariant() + "-menu-" + module.ToUpperInvariant() + "_" + menuId;
		wait.Until(c => page);
	}

}
