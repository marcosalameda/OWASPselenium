using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using RESTGenio;
using RESTGenio.XRS;
using System.Net.Http.Json;

namespace RestTest;

[TestFixture]
public class UnitTestXRSResource : BaseWebappTest
{
    public UnitTestXRSResource() : base() { }

    private const string testFilePath = "./TestData/TestImage.png";

    private string testRowPk = "579448BF-A57F-4ED8-B91B-02E87FD017AA";

    [OneTimeSetUp]
    public void Init()
    {
		CSGenio.GenioDIDefault.Use();
        var sp = PersistentSupport.getPersistentSupport("0");
        try
        {
            sp.openTransaction();
            var user = new User("test", "", "0");
            var item = new CSGenioAitem(user);
            item.QPrimaryKey = sp.codIntInsertion(item, false);
            item.ValItemdes = "Rest test item";
            item.ValItemcod = "un123";
            item.ValItemtype = "I";
            item.ValDisponib = "O";
            item.insertDirect(sp);
            testRowPk = item.QPrimaryKey;
        }
        finally 
        { 
            sp.closeTransaction(); 
        }
    }

    [OneTimeTearDown]
    public void Cleanup() 
    {
        var sp = PersistentSupport.getPersistentSupport("0");
        try
        {
            sp.openTransaction();
            User user = new User("test", "", "0");
            var item = CSGenioAitem.search(sp, testRowPk, user);
            item.deleteDirect(sp);
        }
        finally
        {
            sp.closeTransaction();
        }
    }

    [Test, Order(1)]
    public async Task UploadDownloadBinaryEmpty()
    {
        var _client = _factory.CreateClient();
        await Authenticate(_client);

        var response = await _client.GetAsync("XRS/Articles/Select/" + testRowPk);
        var row = await response.Content.ReadFromJsonAsync<ArticlesFormResponse>(_jsonop);
        Assert.That(row?.record, Is.Not.Null);
        var ticket = row.record.Image_Ticket;
        Assert.That(ticket, Is.Not.Empty);

        // UPLOAD
        response = await _client.PostAsync("Resources/file/" + ticket, null);
        var r = await response.Content.ReadFromJsonAsync<Response>(_jsonop);
        Assert.That(r, Is.Not.Null);
        Assert.That(r.status, Is.EqualTo(RESTStatus.Ok));

        // DOWNLOAD
        response = await _client.GetAsync("Resources/file/" + ticket);
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
    }


    [Test, Order(2)]
    public async Task UploadDownloadBinaryFile()
    {
        var _client = _factory.CreateClient();
        await Authenticate(_client);

        var response = await _client.GetAsync("XRS/Articles/Select/" + testRowPk);
        var row = await response.Content.ReadFromJsonAsync<ArticlesFormResponse>(_jsonop);
        Assert.That(row?.record, Is.Not.Null);
        var ticket = row.record.Image_Ticket;
        Assert.That(ticket, Is.Not.Empty);

        // UPLOAD
        using (var stream = new FileStream(testFilePath, FileMode.Open))
        {
            MultipartFormDataContent content = CreateUploadFileContent(stream, Path.GetFileName(testFilePath));
            response = await _client.PostAsync("Resources/file/" + ticket, content);
            var r = await response.Content.ReadFromJsonAsync<Response>(_jsonop);
            Assert.That(r, Is.Not.Null);
            Assert.That(r.status, Is.EqualTo(RESTStatus.Ok));
        }

        //DOWNLOAD
        using (var mem = new MemoryStream())
        {
            response = await _client.GetAsync("Resources/file/" + ticket);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var download = await response.Content.ReadAsStreamAsync();
            await download.CopyToAsync(mem);

            var filesize = new FileInfo(testFilePath).Length;
            Assert.That(mem.Length, Is.EqualTo(filesize));
        }
    }



    [Test, Order(3)]
    public async Task UploadDownloadDocumentEmpty()
    {
        var _client = _factory.CreateClient();
        await Authenticate(_client);

        var response = await _client.GetAsync("XRS/Articles/Select/" + testRowPk);
        var row = await response.Content.ReadFromJsonAsync<ArticlesFormResponse>(_jsonop);
        Assert.That(row?.record, Is.Not.Null);
        var ticket = row.record.Specifications_Ticket;
        Assert.That(ticket, Is.Not.Empty);

        // UPLOAD
        response = await _client.PostAsync("Resources/file/" + ticket, null);
        var r = await response.Content.ReadFromJsonAsync<Response>(_jsonop);
        Assert.That(r, Is.Not.Null);
        Assert.That(r.status, Is.EqualTo(RESTStatus.Ok));

        //check that the filename is returned empty but not the ticket
        response = await _client.GetAsync("XRS/Articles/Select/" + testRowPk);
        row = await response.Content.ReadFromJsonAsync<ArticlesFormResponse>(_jsonop);
        Assert.That(row?.record, Is.Not.Null);
        Assert.That(row.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(row.record.Specifications, Is.Empty);
        Assert.That(row.record.Specifications_Ticket, Is.Not.Empty);

        // DOWNLOAD
        response = await _client.GetAsync("Resources/file/" + ticket);
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
    }


    [Test, Order(4)]
    public async Task UploadDownloadDocumentFile()
    {
        var _client = _factory.CreateClient();
        await Authenticate(_client);

        var response = await _client.GetAsync("XRS/Articles/Select/" + testRowPk);
        var row = await response.Content.ReadFromJsonAsync<ArticlesFormResponse>(_jsonop);
        Assert.That(row?.record, Is.Not.Null);
        var ticket = row.record.Specifications_Ticket;
        Assert.That(ticket, Is.Not.Empty);

        // UPLOAD
        using (var stream = new FileStream(testFilePath, FileMode.Open))
        {
            MultipartFormDataContent content = CreateUploadFileContent(stream, Path.GetFileName(testFilePath));
            response = await _client.PostAsync("Resources/file/" + ticket, content);
            var r = await response.Content.ReadFromJsonAsync<Response>(_jsonop);
            Assert.That(r, Is.Not.Null);
            Assert.That(r.status, Is.EqualTo(RESTStatus.Ok));
        }

        //check that the filename is returned 
        response = await _client.GetAsync("XRS/Articles/Select/" + testRowPk);
        row = await response.Content.ReadFromJsonAsync<ArticlesFormResponse>(_jsonop);
        Assert.That(row?.record, Is.Not.Null);
        Assert.That(row.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(row.record.Specifications, Is.EqualTo(Path.GetFileName(testFilePath)));
        Assert.That(row.record.Specifications_Ticket, Is.Not.Empty);

        //DOWNLOAD
        using (var mem = new MemoryStream())
        {
            response = await _client.GetAsync("Resources/file/" + ticket);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var download = await response.Content.ReadAsStreamAsync();
            await download.CopyToAsync(mem);

            var filesize = new FileInfo(testFilePath).Length;
            Assert.That(mem.Length, Is.EqualTo(filesize));
        }
    }


}