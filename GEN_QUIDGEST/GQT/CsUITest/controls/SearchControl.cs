using System;
using OpenQA.Selenium;
using quidgest.uitests.core;

namespace quidgest.uitests.controls;

public class SearchControl: PageObject {

	//private final static Logger LOGGER = LoggerFactory.getLogger(Search.class.getName());

	private string containerId;
	private string tableId;

	private IWebElement container;
	private IWebElement input;

	public SearchControl(IWebDriver driver, string tableId, string containerId): base(driver) {
		if (string.IsNullOrEmpty(tableId)) throw new ArgumentException($"{nameof(tableId)} must contain value.");
		if (string.IsNullOrEmpty(containerId)) throw new ArgumentException($"{nameof(containerId)} must contain value.");

		this.tableId = tableId;
		this.containerId = containerId;

		init();
	}

	public SearchControl(IWebDriver driver, string tableId): this(driver, tableId, tableId + "_simple_filter") {}

	private void init() {
		// Find table container
		container = driver.FindElement(By.Id(containerId));
		//wait.until(ExpectedConditions.visibilityOf(container));

		// Find search input field within container
		input = container.FindElement(By.Id("q" + tableId));
		//wait.until(ExpectedConditions.visibilityOf(input));
	}

	public void search(String text) {
		input.SendKeys(text);
		input.SendKeys(Keys.Return);

		//wait.until(ExpectedConditions.visibilityOfElementLocated(By.id(tableId)));
		// HACK: wait a bit for the result page to load
		/*
		try {
			Thread.sleep(1000);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		*/

		//return new ListControl(driver, tableId);
	}

}
