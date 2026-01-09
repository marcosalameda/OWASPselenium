
using NUnit.Framework;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

// USE /[MANUAL GQT IMPORTS]/
//Platform: CS | Type: IMPORTS | Module: GQT | Parameter: McpTests | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:87fe187a-51fc-4f97-b923-61b956b60d88
using CSGenio.core.ai;
using System.Text.Json;
using Quidgest.Persistence.GenericQuery;
//END_MANUALCODE

namespace WebTest
{
//Platform: CS | Type: SERVER_UNIT_TEST | Module: GQT | Parameter: McpTests | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:e6d7ea74-cc26-40d8-b0b8-41585f1485e3
public class McpTests : DatabaseTransactionFixture {

    private IToolRepo toolRepo;

    [SetUp]
    public void Setup() { 
        toolRepo = McpToolFactory.AllGenioTools();
    }

    [Test]
    public void LowLevelToolListTest()
    {
        if (!Configuration.Application.Modules.ContainsKey("GQT"))
            Assert.Ignore();

        var user = new CSGenio.framework.User("queryUser", "", "0");
        user.AddModuleRole("TBS", Role.ROLE_1);
        user.AddModuleRole("GQT", Role.ROLE_1);


        //Act
        var tools = toolRepo.GetToolsForUser(user);

        //Assert
        Assert.That(tools.Any(t=>t.Name == "ListAllCountries"), "ListAllCountries should be returned");
        Assert.That(!tools.Any(t=>t.Name == "DeleteCompany"), "DeleteCompanyTool should not be returned");
    }

    [Test]
    public void HighLevelToolListTest() 
    {
        if (!Configuration.Application.Modules.ContainsKey("GQT"))
            Assert.Ignore();

            var user = new CSGenio.framework.User("adminUser", "", "0");
        user.AddModuleRole("TBS", Role.ROLE_20);
        user.AddModuleRole("GQT", Role.ROLE_20);

        //Act
        var tools = toolRepo.GetToolsForUser(user);

        //Assert
        Assert.That(tools.Any(t => t.Name == "ListAllCountries"), "ListAllCountries should be returned");
        Assert.That(tools.Any(t => t.Name == "DeleteCompany"), "DeleteCompanyTool should be returned");
    }

    [Test]
    public void NoAccessInModuleTest()
    {
        if (!Configuration.Application.Modules.ContainsKey("GQT"))
            Assert.Ignore();
        
        var user = new CSGenio.framework.User("gqtUser", "", "0");            
        user.AddModuleRole("GQT", Role.ADMINISTRATION);

        //Act
        var tools = toolRepo.GetToolsForUser(user);

        //Assert
        Assert.That(!tools.Any(t => t.Name == "ListAllCountries"), "ListAllCountries should not be returned");
        Assert.That(tools.Any(t => t.Name == "DeleteCompany"), "DeleteCompanyTool should be returned");
    }

        [Test]
        public void CreateCompanyTool_NoMandatoryParameterFails()
        {
            var tool = new CreateCompanyTool();

            var input = JsonDocument.Parse("{ \"email\": \"quidgest@quidgest.pt\" }").RootElement;

            Assert.Throws<ArgumentException>(() =>
                tool.Execute(sp, _user, input)
            );
        }

        [Test]
        public void CreateCompanyTool_Succeeds()
        {
            var tool = new CreateCompanyTool();
            const string companyName = "Stark Industries";

            var result = CSGenioAcmpny.searchList(sp, _user, CriteriaSet.And().Equal(CSGenioAcmpny.FldDesignat, companyName));
            Assert.That(result.Count == 0, $"Precondition failed: Company '{companyName}' should not exist before test.");

            var input = JsonDocument.Parse($"{{ \"designation\": \"{companyName}\" }}").RootElement;

            tool.Execute(sp, _user, input);

            result = CSGenioAcmpny.searchList(sp, _user, CriteriaSet.And().Equal(CSGenioAcmpny.FldDesignat, companyName));
            Assert.That(result.Count == 1, $"Company '{companyName}' should exist after tool execution.");
        }

        [Test]
        public void CreateCompanyTool_ValidForeignKey()
        {
            var tool = new CreateCompanyTool();
            const string companyName = "Stark Industries";

            var countries = CSGenioAcntry.searchList(sp, _user, CriteriaSet.And().Equal(CSGenioAcntry.FldCountry, "Portugal"));
            CSGenioAcntry portugal;
            if(countries.Count == 0)
            {
                portugal = new CSGenioAcntry(_user);
                portugal.insert(sp);
            }
            else
            {
                portugal = countries[0];
            }

            var input = JsonDocument.Parse($"{{ \"designation\": \"{companyName}\"," +
                $"\"countryForeignKey\": \"{portugal.ValCodcntry}\" " +
                $" }}").RootElement;

            tool.Execute(sp, _user, input);

            var result = CSGenioAcmpny.searchList(sp, _user, CriteriaSet.And().Equal(CSGenioAcmpny.FldDesignat, companyName));
            Assert.That(result.Count == 1, $"Company '{companyName}' should exist after tool execution.");
            Assert.AreEqual(portugal.ValCodcntry, result[0].ValCodcntry, "Country foreign key should match the one provided.");
        }

        [Test]
        public void CreateCompanyTool_InvalidForeignKey()
        {
            var tool = new CreateCompanyTool();
            const string companyName = "Stark Industries";

            var fakeGuid = Guid.NewGuid().ToString();

            var input = JsonDocument.Parse($"{{ \"designation\": \"{companyName}\"," +
                $"\"countryForeignKey\": \"{fakeGuid}\" " +
                $" }}").RootElement;

            Assert.Throws<ArgumentException>(() =>
                tool.Execute(sp, _user, input)
            );

        }

        [Test]
        public void DeleteKey_Succeeds()
        {
            var tool = new DeleteCompanyTool();
            const string companyName = "Stark Industries";

            var newRecord = new CSGenioAcmpny(_user);
            newRecord.ValDesignat = companyName;
            newRecord.insert(sp);

            var input = JsonDocument.Parse($"{{ \"primaryKey\": \"{newRecord.QPrimaryKey}\" }}").RootElement;

            tool.Execute(sp, _user, input);

            var result = CSGenioAcntry.search(sp, newRecord.ValCodcntry, _user);
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteKey_InvalidKey()
        {
            var tool = new DeleteCompanyTool();

            var fakeGuid = Guid.NewGuid().ToString();

            var input = JsonDocument.Parse($"{{ \"primaryKey\": \"{fakeGuid}\" }}").RootElement;

            Assert.Throws<BusinessException>(() =>
                tool.Execute(sp, _user, input)
            );

        }

        [Test]
        public void ListTool_NoParameters_Succeeds()
        {
            var tool = new ListAllCountriesTool();

            var input = JsonDocument.Parse($"{{}}").RootElement;
            var result = tool.Execute(sp, _user, input);

            Assert.IsNotNull(result);
        }


        [Test]
        public void ListTool_Sorting_Succeeds()
        {
            var tool = new ListAllCountriesTool();

            var newRecord = new CSGenioAcntry(_user);
            newRecord.ValCountry = "Wakanda";
            newRecord.insert(sp);

            var input = JsonDocument.Parse($"{{ \"sortBy\" : \"country\", " +
                $"\"sortOrder\" : \"desc\"" +
                $" }}").RootElement;
            var result = tool.Execute(sp, _user, input);

            Assert.IsNotNull(result);
            var strResult = JsonSerializer.Serialize(result);
            Assert.That(strResult, Contains.Substring("Wakanda"), "Wakanda was not found in the response");
        }

    }
//END_MANUALCODE
}