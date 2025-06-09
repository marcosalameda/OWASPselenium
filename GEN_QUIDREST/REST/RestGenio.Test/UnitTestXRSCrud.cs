using RESTGenio;
using RESTGenio.XRS;
using System.Net.Http.Json;

namespace RestTest;

[TestFixture]
public class UnitTestXRSCrud : BaseWebappTest
{
    public UnitTestXRSCrud() : base() { }

    [Test, Order(1)]
    public async Task ListWarehouses()
    {
        var _client = _factory.CreateClient();
        await Authenticate(_client);

        var response = await _client.PostAsJsonAsync("XRS/Warehouses/List", new ListRequest()
        {
            order = new Order()
            {
                orders = new List<OrderBy> {
                    new OrderBy() { Field = "numberOfEmployees", Direction = OrderByDirection.ASC }
                }
            }
        });
        var message = await response.Content.ReadFromJsonAsync<ListResponseWarehouses>(_jsonop);
        Assert.That(message?.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(message.Data, Is.Not.Null);
        Assert.That(message.Data.Count, Is.AtLeast(1));
    }


    [Test, Order(2)]
    public async Task CrudWarehouses()
    {
        var _client = _factory.CreateClient();
        await Authenticate(_client);

        //INSERT
        var response = await _client.PostAsJsonAsync("XRS/Warehouse/Insert", new WarehouseFormRequest()
        {
            record = new FormRecordWarehouse()
            {
                Warehouse = "test",
                Acronym = "TT",
                Activity = ArrayActividade.V1
            }
        }, _jsonop);
        var message = await response.Content.ReadFromJsonAsync<WarehouseFormResponse>(_jsonop);
        Assert.That(message?.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(message?.record, Is.Not.Null);
        Assert.That(message.record.primaryKey, Is.Not.Empty);
        var pk = message.record.primaryKey;

        //check
        response = await _client.GetAsync($"XRS/Warehouse/Select/{pk}");
        var message2 = await response.Content.ReadFromJsonAsync<WarehouseFormResponse>(_jsonop);
        Assert.That(message2?.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(message2.record, Is.Not.Null);
        Assert.That(message2.record.primaryKey, Is.EqualTo(pk));
        Assert.That(message2.record.Warehouse, Is.EqualTo("test"));
        Assert.That(message2.record.Acronym, Is.EqualTo("TT"));
        Assert.That(message2.record.Activity, Is.EqualTo(ArrayActividade.V1));


        //UPDATE
        response = await _client.PutAsJsonAsync("XRS/Warehouse/Update", new WarehouseFormRequest()
        {
            record = new FormRecordWarehouse()
            {
                primaryKey = pk,
                Acronym = "T1",
            }
        }, _jsonop);
        var message3 = await response.Content.ReadFromJsonAsync<Response>(_jsonop);
        Assert.That(message3?.status, Is.EqualTo(RESTStatus.Ok));

        //check
        response = await _client.GetAsync($"XRS/Warehouse/Select/{pk}");
        var message4 = await response.Content.ReadFromJsonAsync<WarehouseFormResponse>(_jsonop);
        Assert.That(message4?.status, Is.EqualTo(RESTStatus.Ok));
        Assert.That(message4.record, Is.Not.Null);
        Assert.That(message4.record.primaryKey, Is.EqualTo(pk));
        Assert.That(message4.record.Warehouse, Is.EqualTo("test"));
        Assert.That(message4.record.Acronym, Is.EqualTo("T1"));
        Assert.That(message4.record.Activity, Is.EqualTo(ArrayActividade.V1));

        //DELETE
        response = await _client.DeleteAsync($"XRS/Warehouse/Delete/{pk}");
        var message5 = await response.Content.ReadFromJsonAsync<Response>(_jsonop);
        Assert.That(message5?.status, Is.EqualTo(RESTStatus.Ok));

        //check
        response = await _client.GetAsync($"XRS/Warehouse/Select/{pk}");
        var message6 = await response.Content.ReadFromJsonAsync<WarehouseFormResponse>(_jsonop);
        Assert.That(message6?.status, Is.EqualTo(RESTStatus.Error));
    }

}