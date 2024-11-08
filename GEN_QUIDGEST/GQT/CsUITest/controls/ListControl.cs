using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using quidgest.uitests.core;

namespace quidgest.uitests.controls;


public class ListControl: PageObject {

	private string id;
	private string locator;

	private IWebElement table => driver.FindElement(By.CssSelector(locator));
	private IList<IWebElement> rows => table.FindElements(By.CssSelector("tbody tr"));
	private IWebElement insertBtn => table.FindElement(By.CssSelector("button[qbutton='insert']"));
	public SearchControl Search => new SearchControl(driver, id);

	public ListControl(IWebDriver driver, string id, string locator): base(driver) {
		if (string.IsNullOrEmpty(id)) throw new ArgumentException($"{nameof(id)} must contain value.");

		this.id = id;
		this.locator = locator;
		wait.Until( c => driver.FindElement(By.Id(id)).GetAttribute("qcontrol-loaded") == "true");
	}

	public ListControl(IWebDriver driver, string id): this(driver, id, "#"+id) {}

    public int GetRowByPk(string pk) {
		return rows.FindIndex(r => r.GetAttribute("data-key") == pk);
	}

	public int GetColumn(string fieldRef)
	{
		var parts = fieldRef.Split('.',2);
		var column_locator = CapFirst(parts[0]) + "_" + id + "_Val" + CapFirst(parts[1]);
		var columns = table.FindElements(By.TagName("th"));
		//Console.WriteLine("locator:" + column_locator);
		return columns.FindIndex(h => h.GetAttribute("id") == column_locator);
	}

	private string CapFirst(string s)
	{
		if(s.Length == 0) return s;
		if(s.Length == 1) return s.ToUpperInvariant();
		return s.Substring(0,1).ToUpperInvariant() + s.Substring(1).ToLowerInvariant();
	}

	public string GetValue(int row, string fieldRef)
	{
		int cix = GetColumn(fieldRef);
		// Console.WriteLine("row:" + row);
		// Console.WriteLine("col:" + cix);
		var cell = rows[row].FindElements(By.TagName("td"))[cix];
		return cell.Text;
	}

    public void ClickRow(int index) {
		if (index >= rows.Count)
			throw new Exception($"Invalid row index: {index}");

		rows[index].Click();
	}

	public void Insert() {
		insertBtn.Click();
	}

	public void executeAction(int index, String action) {
		if (index >= rows.Count)
			throw new Exception($"Invalid row index: {index}");

		var row = rows[index];
		var cell = row.FindElement(By.CssSelector("td.row-actions"));
		var link = cell.FindElement(By.CssSelector("[qbutton='" + action + "']"));

		if (!link.Displayed) {
			cell.FindElement(By.CssSelector("div button")).Click();
		}

		link.Click();
	}

	public void sortTable(int index) {
		var header = table.FindElement(By.CssSelector("thead tr"));
		var cells = header.FindElements(By.CssSelector("th"));

		cells[index].Click();
	}


}
