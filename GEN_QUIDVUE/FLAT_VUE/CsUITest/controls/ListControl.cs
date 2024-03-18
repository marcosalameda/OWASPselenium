using System.Collections.Generic;
using System.Linq;

namespace quidgest.uitests.controls;

public class ListControl : ControlObject
{
    private IList<IWebElement> rows => m_control.FindElements(By.CssSelector("tbody tr"));
	private IList<IWebElement> columns => m_control.FindElements(By.CssSelector("thead th"));
    private IWebElement insertBtn => m_control.FindElement(By.CssSelector("button[qbutton='insert']"));
    private bool loading => m_control.FindElements(By.CssSelector("tbody.c-table__body--loading")).Any();

    public SearchControl Search => new SearchControl(driver, m_containerLocator, m_controlLocator);


    public ListControl(IWebDriver driver, By containerLocator, string css) :
        base(driver, containerLocator, By.CssSelector(css))
    {
        WaitForLoading();
    }


    private void WaitForLoading()
    {
        wait.Until(c => !loading);
    }

    public int GetRowByPk(string pk)
    {
        WaitForLoading();
        return rows.FindIndex(r => r.GetAttribute("data-key") == pk);
    }

    public int GetColumn(string fieldRef)
    {
        WaitForLoading();
        var parts = fieldRef.Split('.', 2);
        var column_locator = CapFirst(parts[0]) + ".Val" + CapFirst(parts[1]);
        return columns.FindIndex(h => h.GetAttribute("data-column-name") == column_locator);
    }

    private string CapFirst(string s)
    {
        if (s.Length == 0) return s;
        if (s.Length == 1) return s.ToUpperInvariant();
        return s.Substring(0, 1).ToUpperInvariant() + s.Substring(1).ToLowerInvariant();
    }

    public string GetValue(int row, string fieldRef)
    {
        WaitForLoading();
        int cix = GetColumn(fieldRef);
        // Console.WriteLine("row:" + row);
        // Console.WriteLine("col:" + cix);
        var cell = rows[row].FindElements(By.TagName("td"))[cix];
        return cell.Text;
    }

    public void ClickRow(int index)
    {
        WaitForLoading();
        if (index >= rows.Count)
            throw new ArgumentException($"Invalid row index: {index}");

        rows[index].Click();
    }

    public void Insert()
    {
        insertBtn.Click();
    }

    public void ExecuteAction(int index, String action)
    {
        WaitForLoading();
        if (index >= rows.Count || index < 0)
            throw new ArgumentException($"Invalid row index: {index}");

        var row = rows[index];

        var cell = row.FindElement(By.CssSelector("td.row-actions"));
        var button = cell.FindElement(By.CssSelector("[data-testid=options-btn]"));
        button.Click();

        //TODO: instead of title it should be data-key=action
        var link = cell.FindElement(By.CssSelector("[data-testid=table-action][title='" + action + "']"));

        link.Click();
    }

    public void SortTable(int index)
    {
        WaitForLoading();
        var header = m_control.FindElement(By.CssSelector("thead tr"));
        var cells = header.FindElements(By.CssSelector("th"));

        cells[index].Click();
    }


}
