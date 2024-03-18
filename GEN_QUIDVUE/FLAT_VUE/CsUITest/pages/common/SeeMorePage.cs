namespace quidgest.uitests.pages;

public class SeeMorePage: PageObject {

    private string id;

	private IWebElement page => driver.FindElement(By.Id(id));
	private IWebElement cancel => page.FindElement(By.CssSelector(".c-modal__header button[title=Close]"));

	public ListControl List => new ListControl(driver, By.Id(id), ".q-table-list");

	public SeeMorePage(IWebDriver driver, string form, string fieldRef): base(driver) {
		ArgumentException.ThrowIfNullOrEmpty(nameof(form));
        ArgumentException.ThrowIfNullOrEmpty(nameof(fieldRef));

		var parts = fieldRef.Split('.',2);
		this.id = $"q-modal-see-more-{form}-{parts[0]}{parts[1]}".ToLowerInvariant();
		wait.Until(c => page);
	}

	public void Cancel(){
		cancel.Click();
	}

}
