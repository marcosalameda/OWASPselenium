using System.Collections.Generic;
using System.IO;

using Deque.AxeCore.Commons;
using Deque.AxeCore.Selenium;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SeleniumWebTest.tests;

public class AccessibilityTest : BaseAccessibilityTest
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
    public void AccessibilityAppLayout()
    {
        var a = Authenticate();

        // Navigate to page
        a.Menu.ActivateModule("PTN");

        // Page header
        AccessibilityScanAndLog("APP__HEADER", ".layout-container > .c-header");

        // Page footer
        AccessibilityScanAndLog("APP__FOOTER", "#q-footer");

        // Navigation menu
        AccessibilityScanAndLog("APP__NAVIGATION_MENU", "#main-header-navbar");

        // Right sidebar
        AccessibilityScanAndLog("APP__RIGHT_SIDEBAR", "#right-sidenav");
    }

    [Test]
    public void AccessibilityFormControls()
    {
        var a = Authenticate();

        // Main form controls with helps
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "61");

        var ptn61List = new MenuListPage(Driver, "PTN", "611").List;
        ptn61List.ExecuteAction(1, CrudAction.Edit);

        var fieldhlpForm = new FieldhlpForm(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_FIELDHLP__(FIELD_CONTROLS)", "#main");
    }

    [Test]
    public void AccessibilityFormControlDocument()
    {
        var a = Authenticate();

        // Form document controls
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "62");

        var ptn62List = new MenuListPage(Driver, "PTN", "621").List;
        ptn62List.ExecuteAction(0, CrudAction.Edit);

        var equdocumForm = new EqudocumForm(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_EQUDOCUM_(TABLE_HELP)", "#main");
    }

    [Test]
    public void AccessibilityFormTabs()
    {
        var a = Authenticate();

        // Form with tabs
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "26");

        var listacamForm = new ListacamForm(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_LISTACAM__TABS", "#q-tabs-LISTACAM");
    }

    [Test]
    public void AccessibilityFormAnchors()
    {
        var a = Authenticate();

        // Form anchors - Side
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "37");

        var ptn37List = new MenuListPage(Driver, "STY", "371").List;
        ptn37List.ExecuteAction(0, CrudAction.Edit);

        var equigrouForm = new EquigrouForm(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_EQUIGROU__(ANCHORS_ZONES)", "#main");
    }

    [Test]
    public void AccessibilityMenuList()
    {
        var a = Authenticate();

        // Menu list
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "313");

        var ptn313List = new MenuListPage(Driver, "PTN", "3131").List;

        // Accessibility scan
        AccessibilityScanAndLog("MENU_PTN_313__MENU_LIST", "#main");
    }

    [Test]
    public void AccessibilityMenuListRowReorder()
    {
        var a = Authenticate();

        // Menu list table with row reordering
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "41");

        var ptn41List = new MenuListPage(Driver, "PTN", "411").List;
        ptn41List.ToggleRowReorderMode();

        // Accessibility scan
        AccessibilityScanAndLog("MENU_PTN_41__ROW_REORDER", "#main");
    }

    [Test]
    public void AccessibilityMenuListColumnConfig()
    {
        var a = Authenticate();

        // Menu list column configuration
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "313");

        var ptn313ListOcc = new MenuListPage(Driver, "PTN", "3131").List;
        // Open column configuration popup
        ptn313ListOcc.OpenColumnConfig();
        var ptn313ListOccTableConfigPage = new TableConfigurationPage(Driver);

        // Accessibility scan
        AccessibilityScanAndLog("MENU_PTN_313__COLUMN_CONFIG", "#main");

        // Close column configuration popup
        ptn313ListOccTableConfigPage.CancelColumnConfig();
    }

    [Test]
    public void AccessibilityFormTableMultiSelect()
    {
        var a = Authenticate();

        // Form with multiple select table list
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "22");

        var ptn22List = new MenuListPage(Driver, "PTN", "221").List;
        ptn22List.ExecuteAction(3, CrudAction.Edit);

        var formRegia_ml = new Regia_mlForm(Driver, FORM_MODE.EDIT);
        var formRegia_mlTable = new ListControl(Driver, By.Id("form-container"), "#REGIA_MLPSEUDIMOVEISL");

        // Accessibility scan
        AccessibilityScanAndLog("FORM_REGIA_ML__TABLE_MULTISELECT", "#REGIA_MLPSEUDIMOVEISL");
    }

    /*
    [Test]
    public void AccessibilityFormTreeTable()
    {
        var a = Authenticate();

        // Tree table
        // Navigate to page
        a.Menu.ActivateModule("GQT");
        a.Menu.ActivateMenu("GQT", "292");

        var ptn292List = new MenuListPage(Driver, "GQT", "2921").List;
        ptn292List.ExecuteAction(0, CrudAction.Edit);

        var fami1Form = new Fami1Form(Driver, FORM_MODE.EDIT);
        var fami1FormTreeTable = new ListControl(Driver, By.Id("form-container"), "#FAMI1___PSEUDTIPOSEQ1");

        // Accessibility scan
        AccessibilityScanAndLog("FORM_FAMI1__TREE_TABLE", "#FAMI1___PSEUDTIPOSEQ1");
    }
    */

    [Test]
    public void AccessibilityFormEditableTable()
    {
        var a = Authenticate();

        // Form with editable table list
        // Navigate to page
        a.Menu.ActivateModule("PTN");
        a.Menu.ActivateMenu("PTN", "EDITABLETABLE");

        var ptnEditableTableList = new MenuListPage(Driver, "PTN", "EDITABLETABLELIST").List;
        ptnEditableTableList.ExecuteAction(0, CrudAction.Edit);

        var grpbForm = new GrpbForm(Driver, FORM_MODE.EDIT);
        var grpbFormEditableTable = new ListControl(Driver, By.Id("form-container"), ".q-grid-table-list");

        // Accessibility scan
        AccessibilityScanAndLog("FORM_GRPB__EDITABLE_TABLE", ".q-grid-table-list");
    }

    /*
    [Test]
    public void AccessibilityMenuListCardMode()
    {
        var a = Authenticate();

        // Menu list card mode
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "CARDIMGTOP");

        // Switch to card display mode

        // Accessibility scan
        AccessibilityScanAndLog("MENU_STY_CARDIMGTOP", "#main");
    }
    */

    [Test]
    public void AccessibilityMenuListDashboard()
    {
        var a = Authenticate();

        // Menu list dashboard
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "43");

        var styDashboard = new MenuListPage(Driver, "STY", "DASHBOARD");

        // Accessibility scan
        AccessibilityScanAndLog("MENU_STY_43__DASHBOARD", "#main");
    }

    [Test]
    public void AccessibilityWizardHorizontal()
    {
        var a = Authenticate();

        // Wizard - Horizontal
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "421");

        var vendaw01FormH = new Vendaw01Form(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_VENDAW__WIZARD_HORIZONTAL", "#main");
    }

    [Test]
    public void AccessibilityWizardVertical()
    {
        var a = Authenticate();

        // Wizard - Vertical
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "422");

        var vendaw01FormV = new Vendaw01Form(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_VENDAWV__WIZARD_VERTICAL", "#main");
    }

    [Test]
    public void AccessibilityWizardProgressBar()
    {
        var a = Authenticate();

        // Wizard - Progress bar
        // Navigate to page
        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "423");

        var vendaw01FormP = new Vendaw01Form(Driver, FORM_MODE.EDIT);

        // Accessibility scan
        AccessibilityScanAndLog("FORM_VENDAWP__WIZARD_PROGRESSBAR", "#main");
    }
}
