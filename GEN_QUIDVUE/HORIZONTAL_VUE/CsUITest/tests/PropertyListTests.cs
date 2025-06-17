namespace SeleniumWebTest.tests;

public class PropertyListTests : BaseSeleniumTest
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
    public void PropertyListApplyValuesFromStore()
    {
        var a = Authenticate();

        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "44");

        var list = new MenuListPage(Driver, "STY", "441").List;
        list.ExecuteAction(0, CrudAction.Edit);

        var plistForm = new PlistForm(Driver, FORM_MODE.EDIT);

        var inputValue = "New Value";
        plistForm.PseudPlist.Txtprop.SetValue(inputValue);

        plistForm.WarehWarehdes.SeeMore();
        var seeMoreList = plistForm.WarehWarehdesSeeMorePage.List;
        seeMoreList.ExecuteAction(0, CrudAction.View);

        var seeMoreForm = new Ware_wsForm(Driver, FORM_MODE.SHOW);
        seeMoreForm.Back();

        Assert.That(plistForm.PseudPlist.Txtprop.GetValue(), Is.EqualTo(inputValue));
    }


    [Test]
    public void PropertyListApplyValuesFromStoreNewForm()
    {
        var a = Authenticate();

        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "44");

        var list = new MenuListPage(Driver, "STY", "441").List;
        list.Insert();

        var plistForm = new PlistForm(Driver, FORM_MODE.EDIT);
        var plist = plistForm.PseudPlist;

        var inputValue = "New Value";
        plist.Txtprop.SetValue(inputValue);

        plistForm.WarehWarehdes.SeeMore();
        var seeMoreList = plistForm.WarehWarehdesSeeMorePage.List;
        seeMoreList.ExecuteAction(0, CrudAction.View);

        var seeMoreForm = new Ware_wsForm(Driver, FORM_MODE.SHOW);
        seeMoreForm.Back();

        Assert.That(plistForm.PseudPlist.Txtprop.GetValue(), Is.EqualTo(inputValue));
        
        plistForm.Cancel(true);
    }

    [Test]
    public void PropertyListSave()
    {
        var a = Authenticate();

        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "44");

        var list = new MenuListPage(Driver, "STY", "441").List;
        list.ExecuteAction(0, CrudAction.Edit);

        var form = new PlistForm(Driver, FORM_MODE.EDIT);

        var value1 = "xpto";
        var value2 = "Test Value";

        var propValue = form.PseudPlist.Txtprop.GetValue();

        //Alternate between what value gets saved, because property list won't update a row if it wasn't changed
        if (propValue == value1)
            form.PseudPlist.Txtprop.SetValue(value2);
        else
            form.PseudPlist.Txtprop.SetValue(value1);

        var expectedValue = form.PseudPlist.Txtprop.GetValue();

        form.PseudPlist.LoseFocus();
        form.Save();

        list.ExecuteAction(0, CrudAction.Edit);

        Assert.That(form.PseudPlist.Txtprop.GetValue(), Is.EqualTo(expectedValue));
    }

    [Test]
    public void PropertyListRequiredRows()
    {
        var a = Authenticate();

        a.Menu.ActivateModule("STY");
        a.Menu.ActivateMenu("STY", "44");

        var list = new MenuListPage(Driver, "STY", "441").List;
        list.ExecuteAction(0, CrudAction.Edit);

        var form = new PlistForm(Driver, FORM_MODE.EDIT);

        form.PseudPlist.Txtprop.ClearValue();

        form.PseudPlist.LoseFocus();
        form.Save();

        var error = form.Error;
        Assert.That(error.Message, Is.Not.Empty);
    }
}
