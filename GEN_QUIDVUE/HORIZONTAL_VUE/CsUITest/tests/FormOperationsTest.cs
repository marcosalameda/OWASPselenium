namespace SeleniumWebTest.tests;

public class FormOperationsTest : BaseSeleniumTest
{
    private AppPage Authenticate()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.Login("quidgest", "zph2lab");

        Assert.That(a.IsAuthenticated());
        return a;
    }

    [Test]
    public void LoginTest()
    {
        var a = Authenticate();

        a.Menu.ActivateModule("GQT");
        a.Menu.ActivateMenu("GQT", "291");

        var list = new MenuListPage(Driver, "GQT", "2911").List;

        list.Search.Search("Bomba");
        list.ClickRow(0);

        var form = new TpequForm(Driver, FORM_MODE.EDIT);

        form.PseudNovogr04.Toggle();
        var x = form.PseudComponen.GetValue(0, "tpeq1.tipoequi");
        Assert.That(x, Is.EqualTo("Bomba de água"));

        var l = form.TpequKit.GetValue();
        Assert.That(l, Is.False);
        form.TpequKit.SetValue(true);
        l = form.TpequKit.GetValue();
        Assert.That(l, Is.True);

        form.TpequTpequcod.SetValue("08");
    }

    [Test]
    public void ShowsUserAndPasswordRequiredErrors()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.Login("", "");

        bool error = p.HasErrorMessage("error-message");
        Assert.That(error, Is.True);

        error = p.HasErrorMessage("user-error");
        Assert.That(error, Is.True);
    }

    [Test]
    public void InvalidLoginAttemptShowsError()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.Login("xpto-user", "123456");

        bool error = p.HasErrorMessage("error-message");
        Assert.That(error, Is.True);
    }

    [Test]
    public void FillingUserNameClearsError()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.Login("", "1234567");

        p.FillUsername("my-user");

        bool error = p.HasErrorMessage("user-error");
        Assert.That(error, Is.False);
    }

    [Test]
    public void FillingPasswordClearsError()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.Login("my-user", "");

        p.FillPassword("1234567");

        bool error = p.HasErrorMessage("error-message");
        Assert.That(error, Is.False);
    }

    [Test]
    public void VerifyInvalidEmail()
    {
        var a = new AppPage(Driver);
        a.ClickLogin();

        var p = new LoginPage(Driver);
        p.ForgotPassword();

        var recoveryPage = new PasswordRecoveryPage(Driver);
        recoveryPage.RecoverPassword("invalidEmail");

        bool error = recoveryPage.HasErrorMessage("error-message");
        Assert.That(error, Is.True);
    }

    [Test]
    public void PopupForm()
    {
        var a = Authenticate();

        a.Menu.ActivateModule("GQT");
        a.Menu.ActivateMenu("GQT", "62");

        var list = new MenuListPage(Driver, "GQT", "621").List;
        list.ExecuteAction(0, CrudAction.View);

        var empre = new EmpreForm(Driver, FORM_MODE.SHOW);
        var x = empre.CmpnyAcronym.GetValue();
        Assert.That(x, Is.EqualTo("CR"));
    }

    [Test]
    public void ExtendedSupportForm()
    {
        var a = Authenticate();

        // Not working correctly if we are already on that module, needs a data-key
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "24");

        var list = new MenuListPage(Driver, "STY", "MODAL").List;
        list.ExecuteAction(0, CrudAction.Edit);

        var armaz = new Armaz03Form(Driver, FORM_MODE.EDIT);
        armaz.PseudArtigos.Search.Search("Verde");
        armaz.PseudArtigos.ClickRow(0);

        var artigext = armaz.PseudArtigapo;
        var x = artigext.ItemItemdes.GetValue();
        Assert.That(x, Is.EqualTo("Esferográfica verde (Lisboa)"));
    }

    [Test]
    public void Tabs()
    {
        var a = Authenticate();
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "26");

        var form = new ListacamForm(Driver, FORM_MODE.EDIT);
        form.PseudCamdate.Activate();

        DateTime now = DateTime.Now;
        form.CamdateFldsDate.SetValue(now);
        var y = form.CamdateFldsDate.GetValue();
        Assert.That(y, Is.EqualTo(now.Date));

        form.CamdateFldsDatetime.SetValue(now);
        y = form.CamdateFldsDatetime.GetValue();
        Assert.That(y, Is.EqualTo(now.Date.AddMinutes(Math.Floor(now.TimeOfDay.TotalMinutes))));

        form.CamdateFldsDateseco.SetValue(now);
        y = form.CamdateFldsDateseco.GetValue();
        Assert.That(y, Is.EqualTo(now.Date.AddSeconds(Math.Floor(now.TimeOfDay.TotalSeconds))));

        form.Cancel();
        var p = new ConfirmationPopup(Driver);
        p.Confirm();
    }

    /*
    [Test]
    public void Document()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("GQT");
        app.Menu.ActivateMenu("GQT", "93");

        ListControl list = new MenuListPage(Driver, "GQT", "931").List;
        list.ExecuteAction(0, CrudAction.Edit);

        AnexdForm form = new(Driver, FORM_MODE.EDIT);
        string oldFileName = form.AnexdDocument.GetFileName();

        // Get the file path
        string baseDirectory = AppContext.BaseDirectory;
        string relativePath = "../../../TestSupport/Sunset.jpg";
        string filePath = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));

        // Upload the file
        form.AnexdDocument.UploadFile(filePath);
        string fileName = form.AnexdDocument.GetFileName();
        Assert.That(fileName, Is.EqualTo("Sunset.jpg"));

        // Upon cancel, the file should be unchanged
        form.Cancel(true);
        list = new MenuListPage(Driver, "GQT", "931").List;
        list.ExecuteAction(0, CrudAction.Edit);
        form = new(Driver, FORM_MODE.EDIT);
        fileName = form.AnexdDocument.GetFileName();
        Assert.That(fileName, Is.EqualTo(oldFileName));

        // Upload the file again
        form.AnexdDocument.UploadFile(filePath);

        // Save the form
        form.Save();

        // When going back to the form, the new file should be there
        list = new MenuListPage(Driver, "GQT", "931").List;
        list.ExecuteAction(0, CrudAction.Edit);
        form = new(Driver, FORM_MODE.EDIT);
        fileName = form.AnexdDocument.GetFileName();
        Assert.That(fileName, Is.EqualTo("Sunset.jpg"));

        // Delete the file
        form.AnexdDocument.DeleteFile();
        fileName = form.AnexdDocument.GetFileName();
        Assert.That(fileName, Is.EqualTo(string.Empty));

        // Save the form again
        form.Save();

        // When going back to the form, the file should have been deleted
        list = new MenuListPage(Driver, "GQT", "931").List;
        list.ExecuteAction(0, CrudAction.Edit);
        form = new(Driver, FORM_MODE.EDIT);
        fileName = form.AnexdDocument.GetFileName();
        Assert.That(fileName, Is.EqualTo(string.Empty));
    }
    */

    [Test]
    public void ConditionsPerRow()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "27");

        MenuListPage menu = new(Driver, "PTN", "271");
        menu.List.ExecuteAction(0, CrudAction.Edit);

        FldscondForm form = new(Driver, FORM_MODE.EDIT);

        var list = form.PseudListtbl;
        var grid = form.PseudGridtbl;
        grid.SetCurrentRow(0);

        // If there are no rows, or there's no empty one, inserts an empty record.
        if (list.RowCount == 0 || !string.IsNullOrWhiteSpace(grid.FeecaFeedback.GetValue()))
        {
            list.Insert();
            FeecaForm subForm = new(Driver, FORM_MODE.EDIT);
            subForm.Save();
        }

        grid.SetCurrentRow(list.RowCount - 1);

        // If the last row is empty, insert a non-empty record.
        if (string.IsNullOrWhiteSpace(grid.FeecaFeedback.GetValue()))
        {
            list.Insert();
            FeecaForm subForm = new(Driver, FORM_MODE.EDIT);
            subForm.FeecaFeedback.SetValue("Testing!!");
            subForm.Save();
        }

        // Check that an empty row has an action more than a filled one.
        // Because of the show when condition by record.
        Assert.That(list.GetActionCount(list.RowCount - 1), Is.EqualTo(5));
        Assert.That(list.GetActionCount(0), Is.EqualTo(6));

        string actionId = "BE_LISTBTN2";
        Assert.That(!list.IsActionAvailable(list.RowCount - 1, actionId));
        Assert.That(list.IsActionAvailable(0, actionId));
    }

    [Test]
    public void BlockConditions()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "27");

        MenuListPage menu = new(Driver, "PTN", "271");
        menu.List.ExecuteAction(0, CrudAction.Edit);

        FldscondForm form = new(Driver, FORM_MODE.EDIT);

        // Deactivate all conditions.
        var radioGroup = form.FldsCond;
        radioGroup.SetValue("");
        form.FldsTblcond.SetValue(false);
        form.FldsFormcond.SetValue(false);

        Assert.That(!form.FldsFclient1.IsBlocked);
        Assert.That(!form.FldsFclient2.IsBlocked);
        Assert.That(!form.FldsFclient3.IsBlocked);

        // Activate only the table conditions.
        radioGroup.SetValue("BLOCK");
        form.FldsTblcond.SetValue(true);

        Assert.That(form.FldsFclient1.IsBlocked);
        Assert.That(!form.FldsFclient2.IsBlocked);
        Assert.That(form.FldsFclient3.IsBlocked);

        // Activate only the form conditions.
        form.FldsTblcond.SetValue(false);
        form.FldsFormcond.SetValue(true);

        Assert.That(!form.FldsFclient1.IsBlocked);
        Assert.That(form.FldsFclient2.IsBlocked);
        Assert.That(form.FldsFclient3.IsBlocked);

        // Activate both table and form conditions.
        form.FldsTblcond.SetValue(true);

        Assert.That(form.FldsFclient1.IsBlocked);
        Assert.That(form.FldsFclient2.IsBlocked);
        Assert.That(form.FldsFclient3.IsBlocked);
    }

    [Test]
    public void Containers()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("GQT");
        app.Menu.ActivateMenu("GQT", "27");

        MenuListPage menu = new(Driver, "GQT", "271");
        menu.List.ExecuteAction(0, CrudAction.Edit);

        PessoForm supportForm = new(Driver, FORM_MODE.EDIT);

        // Ensure internal is marked, so that we enter form PESSOSEP on row click.
        if (!supportForm.PessoInterna.GetValue())
        {
            supportForm.PessoInterna.Toggle();
            supportForm.Save();
        }
        else
            supportForm.Cancel();

        menu.List.ClickRow(0);
        PessosepForm form = new(Driver, FORM_MODE.EDIT);

        // Navigate to tab.
        form.PseudPessos01.Activate();
        // Open collapsible group.
        form.Pessos01PseudNovogr05.Toggle();

        Assert.That(form.PseudPessos01.IsOpen);
        Assert.That(form.Pessos01PseudNovogr05.IsExpanded);

        // Navigate to a different form.
        form.Pessos01PseudEvolucao.Insert();
        EvcatForm subForm = new(Driver, FORM_MODE.EDIT);
        subForm.Cancel(true);

        // When coming back, the previously selected tab/group should still be selected/expanded.
        form = new(Driver, FORM_MODE.EDIT);
        Assert.That(form.PseudPessos01.IsOpen);
        Assert.That(form.Pessos01PseudNovogr05.IsExpanded);
    }

    [Test]
    public void Grid()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "27");

        MenuListPage menu = new(Driver, "PTN", "271");
        menu.List.ExecuteAction(0, CrudAction.Edit);

        FldscondForm form = new(Driver, FORM_MODE.EDIT);
        form.FldsFormcond.SetValue(false);

        var grid = form.PseudGridtbl;
        grid.SetCurrentRow(0);
        grid.FeecaFeedback.SetValue("xpto");
        grid.SetInsertRow();
        grid.FeecaFeedback.SetValue("new record");
        grid.FeecaFeedback.Confirm();

        int gridRows = grid.RowCount;

        // Navigate to a different form.
        form.PseudListtbl.Insert();
        FeecaForm subForm = new(Driver, FORM_MODE.EDIT);
        subForm.Cancel(true);

        form = new(Driver, FORM_MODE.EDIT);
        grid = form.PseudGridtbl;

        // When coming back, the changed rows that weren't saved should still be there.
        Assert.That(gridRows, Is.EqualTo(grid.RowCount));
    }

    [Test]
    public void CurrencyCellDecimalPlaces2()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        string value = list.GetValue(0, "ValCurint");

        string[] valueParts = value.Split('.');

        int numDecimalPlaces = valueParts[1].Length;

        Assert.That(numDecimalPlaces == 2);
    }

    [Test]
    public void CurrencyCellDecimalPlaces4()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        string value = list.GetValue(0, "ValCurdec");

        string[] valueParts = value.Split('.');

        int numDecimalPlaces = valueParts[1].Length;

        Assert.That(numDecimalPlaces == 4);
    }

    [Test]
    public void AdvancedFilterText()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.AddAdvancedFilter("Text", FilterOperators.Text.Equal, "first");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValText").Equals("first"));
    }

    [Test]
    public void AdvancedFilterInteger()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.AddAdvancedFilter("Numeric (Integer)", FilterOperators.Text.Equal, "30");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValNumint").Equals("30"));
    }

    [Test]
    public void AdvancedFilterDecimal()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.AddAdvancedFilter("Numeric (Decimal)", FilterOperators.Text.Equal, "20.890");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValNumdec").Equals("20.890"));
    }

    [Test]
    public void AdvancedFilterDate()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.AddAdvancedFilter("Date", FilterOperators.Text.Equal, "03/02/2023");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDate").Equals("03/02/2023"));
    }

    [Test]
    public void AdvancedFilterDateTime()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.AddAdvancedFilter("DateTime (Minutes)", FilterOperators.Text.Equal, "24/02/2023 15:13");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDatetm").Equals("24/02/2023 15:13"));
    }

    [Test]
    public void AdvancedFilterDateTimeSeconds()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.AddAdvancedFilter("DateTime (Seconds)", FilterOperators.Text.Equal, "24/02/2023 15:17:34");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDatets").Equals("24/02/2023 15:17:34"));
    }

    [Test]
    public void ColumnFilterText()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.FilterByColumn("ValText", FilterOperators.Text.Equal, "first");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValText").Equals("first"));
    }

    [Test]
    public void ColumnFilterInteger()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.FilterByColumn("ValNumint", FilterOperators.Number.Equal, "30");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValNumint"), Is.EqualTo("30"));
    }

    [Test]
    public void ColumnFilterDecimal()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.FilterByColumn("ValNumdec", FilterOperators.Number.Equal, "20.890");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValNumdec"), Is.EqualTo("20.890"));
    }

    [Test]
    public void ColumnFilterDate()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.FilterByColumn("ValDate", FilterOperators.Date.Equal, "03/02/2023");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDate").Equals("03/02/2023"));
    }

    [Test]
    public void ColumnFilterDateTime()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.FilterByColumn("ValDatetm", FilterOperators.Date.Equal, "24/02/2023 15:13");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDatetm").Equals("24/02/2023 15:13"));
    }

    [Test]
    public void ColumnFilterDateTimeSeconds()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.FilterByColumn("ValDatets", FilterOperators.Date.Equal, "24/02/2023 15:17:34");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDatets").Equals("24/02/2023 15:17:34"));
    }

    [Test]
    public void SearchBarFilterText()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("first", "TEXT");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValText").Equals("first"));
    }

    [Test]
    public void SearchBarFilterInteger()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("50", "NUMINT");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValNumint").Equals("50"));
    }

    [Test]
    public void SearchBarFilterDecimal()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("12.058", "NUMDEC");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValNumdec").Equals("12.058"));
    }

    [Test]
    public void SearchBarFilterDate()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("03/02/2023", "DATE");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDate").Equals("03/02/2023"));
    }

    [Test]
    public void SearchBarFilterDateTime()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("24/02/2023 15:13", "DATETM");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDatetm").Equals("24/02/2023 15:13"));
    }

    [Test]
    public void SearchBarFilterDateTimeSeconds()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("24/02/2023 15:14:47", "DATETS");

        Assert.That(list.RowCount == 1);
        Assert.That(list.GetValue(0, "ValDatets").Equals("24/02/2023 15:14:47"));
    }

    [Test]
    public void SearchBarFilterTime()
    {
        AppPage app = Authenticate();

        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "313");

        var list = new MenuListPage(Driver, "PTN", "3131").List;

        list.Search.Search("00:00", "TIMEHM");

        Assert.That(list.RowCount == 3);
        Assert.That(list.GetValue(0, "ValTimehm").Equals("00:00"));
        Assert.That(list.GetValue(1, "ValTimehm").Equals("00:00"));
        Assert.That(list.GetValue(2, "ValTimehm").Equals("00:00"));
    }

    private TableConfigurationPage GetTableConfigPage()
    {
        var tableConfigPage = new TableConfigurationPage(Driver);

        Assert.That(tableConfigPage != null);

        return tableConfigPage;
    }

    private void ReorderMenuListColumn(string module, string menuNumber, string menuListNumber, int currentRowIndex, int newRowIndex)
    {
        var a = Authenticate();

        a.Menu.ActivateModule(module);
        a.Menu.ActivateMenu(module, menuNumber);

        var list = new MenuListPage(Driver, module, menuListNumber).List;

        // Get name of column before reordering
        string currentColumnName = list.GetColumnNameByIndex(currentRowIndex);

        list.OpenColumnConfig();

        var tableConfigPage = GetTableConfigPage();

        var columnConfigList = tableConfigPage.columnConfigList;

        // Get value of column name cell before reordering
        string currentRowNameCellText = columnConfigList.GetValue(currentRowIndex, "name");

        columnConfigList.ExecuteAction(currentRowIndex, ReorderAction.Reorder, newRowIndex);

        // Get value of column name cell at it's new location after reordering
        string newRowNameCellText = columnConfigList.GetValue(newRowIndex, "name");

        Assert.That(newRowNameCellText.Equals(currentRowNameCellText));

        tableConfigPage.ApplyColumnConfig();

        // Get name of column at new index after reordering
        string newColumnName = list.GetColumnNameByIndex(newRowIndex);

        Assert.That(newColumnName.Equals(currentColumnName));
    }

    [Test]
    public void ReorderMenuListColumnByInput_1()
    {
        ReorderMenuListColumn("GQT", "11", "111", 0, 1);
    }

    private void ReorderMenuListColumnUpOrDown(string module, string menuNumber, string menuListNumber, int currentRowIndex, bool increment)
    {
        var a = Authenticate();

        a.Menu.ActivateModule(module);
        a.Menu.ActivateMenu(module, menuNumber);

        var list = new MenuListPage(Driver, module, menuListNumber).List;

        // Get name of column before reordering
        string currentColumnName = list.GetColumnNameByIndex(currentRowIndex);

        list.OpenColumnConfig();

        var tableConfigPage = GetTableConfigPage();

        var columnConfigList = tableConfigPage.columnConfigList;

        // Get value of column name cell before reordering
        string currentRowNameCellText = columnConfigList.GetValue(currentRowIndex, "name");

        // Get action name
        string actionName = increment ? ReorderAction.ReorderDown : ReorderAction.ReorderUp;

        columnConfigList.ExecuteAction(currentRowIndex, actionName);

        // Indexes start at 0 so they are 1 less than the corresponding order values
        int newRowIndex = increment ? currentRowIndex + 1 : currentRowIndex - 1;

        // Get value of column name cell at it's new location after reordering
        string newRowNameCellText = columnConfigList.GetValue(newRowIndex, "name");

        Assert.That(newRowNameCellText.Equals(currentRowNameCellText));

        tableConfigPage.ApplyColumnConfig();

        // Get name of column at new index after reordering
        string newColumnName = list.GetColumnNameByIndex(newRowIndex);

        Assert.That(newColumnName.Equals(currentColumnName));
    }

    [Test]
    public void ReorderMenuListColumnByButtonDown_1()
    {
        ReorderMenuListColumnUpOrDown("GQT", "11", "111", 0, true);
    }

    [Test]
    public void ReorderMenuListColumnByButtonUp_1()
    {
        ReorderMenuListColumnUpOrDown("GQT", "11", "111", 1, false);
    }

    /*
    [Test]
    public void MenuButtons()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "36");

        MenuListPage menu = new(Driver, "PTN", "361");

        var actionId = "MB_3611";

        // Checks to see if the MB exists
        Assert.That(menu.List.IsActionAvailable(0, actionId));

        menu.List.ExecuteAction(0, actionId);

        DespeForm form = new(Driver, FORM_MODE.SHOW);

        // Checks that the form mode is the one set for the MB
        Assert.That(form.ValidateFormMode());
    }
    */

    [Test]
    public void MenuColumnShowWhen()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "317");

        // List PTN3161 has a true show-when condition on the first column and a false condition on the last column
        var list = new MenuListPage(Driver, "PTN", "3171").List;
        string firstCol = list.GetColumnNameByIndex(0);
        string lastCol = list.GetColumnNameByIndex(2);

        Assert.That(firstCol.Equals("Equip.ValRegistnr"));
        Assert.That(lastCol, Is.Null);

        // False show-when conditions should also hide the column from the configuration
        list.OpenColumnConfig();

        var columnConfig = GetTableConfigPage().columnConfigList;

        Assert.That(columnConfig.RowCount.Equals(2));
        // first column has a true show-when condition
        Assert.That(columnConfig.GetValue(0, "name").Equals("No. register"));
        // last column (3rd) has a false show-when condition, so it shouldn't appear in the config
        Assert.That(columnConfig.GetValue(2, "name"), Is.Null);
    }

    [Test]
    public void DashboardMenuWidget()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("GQT");
        app.Menu.ActivateMenu("GQT", "C");

        var dashboard = new MenuDashboardPage<GQT_TESTDSDashboard>(Driver, "GQT", "TESTDS").Dashboard;

        // Two shortcuts, one alert and all bookmarks
        Assert.That(dashboard.VisibleWidgetCount, Is.EqualTo(3 + app.Menu.GetBookmarkCount()));

        //LENDINGS widget
        var lendingsWidget = dashboard.ALL_LENDINGS;
        Assert.That(lendingsWidget.IsVisible, Is.True);
        Assert.That(lendingsWidget.GetTitle(), Is.EqualTo("All Lendings"));
        Assert.That(lendingsWidget.GetGroupTitle(), Is.EqualTo("Lendings".ToUpperInvariant()));

        // Execute menu action (GQT-111)
        lendingsWidget.ExecuteAction();
        Assert.That(app.ValidateMenuNavigation("GQT", "111"), Is.True);
    }

    [Test]
    public void DashboardAlertWidget()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("GQT");
        app.Menu.ActivateMenu("GQT", "C");

        var dashboard = new MenuDashboardPage<GQT_TESTDSDashboard>(Driver, "GQT", "TESTDS").Dashboard;

        var alertWidget = dashboard.ALERT;
        //ALERT widget
        Assert.That(alertWidget.IsVisible, Is.True);
        Assert.That(alertWidget.GetTitle(), Is.EqualTo("Unused items"));
        Assert.That(alertWidget.GetGroupTitle(), Is.EqualTo("Items".ToUpperInvariant()));

        int alertCount = alertWidget.GetCount();

        // Execute alert action (GQT-4A1)
        alertWidget.ExecuteAction();
        Assert.That(app.ValidateMenuNavigation("GQT", "UNUSED_ITEMS"), Is.True);

        // The count on the alert should be the number of valid records in GQT-4A1
        var list = new MenuListPage(Driver, "GQT", "UNUSED_ITEMS").List;
        Assert.That(list.TotalRecordCount, Is.EqualTo(alertCount));
    }

    [Test]
    public void DashboardFavouritesWidget()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("GQT");
        app.Menu.ActivateMenu("GQT", "C");

        var dashboard = new MenuDashboardPage<GQT_TESTDSDashboard>(Driver, "GQT", "TESTDS").Dashboard;

        var favorites = dashboard.FAVORITES;

        // All bookmarks should be in the dashboard as widgets
        Assert.That(favorites.Widgets.Count, Is.EqualTo(app.Menu.GetBookmarkCount()));

        // Favorite widgets work as menu widgets - navigate to bookmarked menu or form (STY-Overview-Accordions)
        var accordionsWidget = favorites.GetBookmarkWidget("Accordions");
        accordionsWidget.ExecuteAction();
        var accordionsForm = new AccordiForm(Driver, FORM_MODE.SHOW);
        Assert.That(accordionsForm.ValidateFormMode(), Is.True);
    }
}
