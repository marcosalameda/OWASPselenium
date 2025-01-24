using System.IO;

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

        //int col = list.GetColumn("tpequ.tipoequi");

        list.Search.Search("Bomba");
        //list.WaitForLoading();

        //list.Search.clear();

        list.ClickRow(0);

        //list.Insert();

        var form = new TpequForm(Driver, FORM_MODE.EDIT);

        form.PseudNovogr04.Toggle();
        var x = form.PseudComponen.GetValue(0, "tpeq1.tipoequi");
        Assert.That(x, Is.EqualTo("Bomba de água"));

        var l = form.TpequKit.GetValue();
        Assert.That(l, Is.False);
        form.TpequKit.SetValue(true);
        l = form.TpequKit.GetValue();
        Assert.That(l, Is.True);

        //form.Cancel();
        form.TpequTpequcod.SetValue("08");
        //form.IFF_TPEQU___FAMILFAMILY__.TypeText("Ferramentas");
        //int ix = form.IFF_TPEQU___FAMILFAMILY__.GetRowByText("Ferramentas");
        //form.FamilFamily.SetValue("Ferramentas");
        //form.TPEQU___FAMILFAMILY__.Clear();

        /*
        //See more
        form.TPEQU___FAMILFAMILY__.SeeMore();
        var sml = form.TPEQU___FAMILFAMILY__SeeMorePage.List;
        sml.Search.search("Ferramentas");
        sml.ClickRow(0);
        */
    }

    [Test]
    public void FailedLoginShowsErrors()
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

        //Not working correctly if we are already on that module, needs a data-key
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
        AppPage a = Authenticate();

        a.Menu.ActivateModule("GQT");
        a.Menu.ActivateMenu("GQT", "93");

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

        Assert.That(!form.FldsFclient1.IsBlocked());
        Assert.That(!form.FldsFclient2.IsBlocked());
        Assert.That(!form.FldsFclient3.IsBlocked());

        // Activate only the table conditions.
        radioGroup.SetValue("BLOCK");
        form.FldsTblcond.SetValue(true);

        Assert.That(form.FldsFclient1.IsBlocked());
        Assert.That(!form.FldsFclient2.IsBlocked());
        Assert.That(form.FldsFclient3.IsBlocked());

        // Activate only the form conditions.
        form.FldsTblcond.SetValue(false);
        form.FldsFormcond.SetValue(true);

        Assert.That(!form.FldsFclient1.IsBlocked());
        Assert.That(form.FldsFclient2.IsBlocked());
        Assert.That(form.FldsFclient3.IsBlocked());

        // Activate both table and form conditions.
        form.FldsTblcond.SetValue(true);

        Assert.That(form.FldsFclient1.IsBlocked());
        Assert.That(form.FldsFclient2.IsBlocked());
        Assert.That(form.FldsFclient3.IsBlocked());
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
        
        // Navigate to another form.
        form.PseudListtbl.ExecuteAction(0, CrudAction.Edit);
        FeecaForm subForm = new(Driver, FORM_MODE.EDIT);
        subForm.Cancel();
        
        form = new(Driver, FORM_MODE.EDIT);
        grid = form.PseudGridtbl;
        
        // When coming back, the changed rows that weren't saved should still be there.
        Assert.That(gridRows == grid.RowCount);
    }
    */

    [Test]
    public void Grid()
    {
        AppPage app = Authenticate();
        app.Menu.ActivateModule("PTN");
        app.Menu.ActivateMenu("PTN", "27");
        
        MenuListPage menu = new(Driver, "PTN", "271");
        menu.List.ExecuteAction(0, CrudAction.Edit);
        
        FldscondForm form = new(Driver, FORM_MODE.EDIT);
        
        var grid = form.PseudGridtbl;
        grid.SetCurrentRow(0);
        grid.FeecaFeedback.SetValue("xpto");
        grid.SetInsertRow();
        grid.FeecaFeedback.SetValue("new record");
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
}
