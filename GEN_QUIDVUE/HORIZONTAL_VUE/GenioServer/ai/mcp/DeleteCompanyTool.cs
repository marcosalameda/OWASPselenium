
namespace CSGenio.core.ai;

using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System;
using Quidgest.Persistence.GenericQuery;

public class DeleteCompanyTool : McpTool
{
    public override string Name => "DeleteCompany";

    public override string Title => "";

    public override string Description => @"Deletes a company record. Only companies without employees can be deleted.";

    public override McpToolAnnotations Annotations => new McpToolAnnotations()
    {
        ReadOnlyHint = false,
        IdempotentHint = false,
        DestructiveHint = true
    };

    public override McpSchemaBase InputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {
            { "primaryKey", new McpProperty() {
                Type = "string",
                Format = "uuid",
                Description = "The primary key of the record"
                }
            },
        },
        Required = new List<string>() {
            "primaryKey",
        }
    };

    public override McpSchemaBase OutputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {

        },
        Required = new List<string>() {
        }
    };

    /// <summary>
    /// Builds a criteria set that checks if the user has access to a given key
    /// </summary>
    /// <param name="user">User to check access</param>
    /// <param name="areaName">The area we are using</param>
    /// <returns>A criteria set ready to run on a search</returns>
    private CriteriaSet RecordAccessCriteriaSet(User user, string areaName)
    {
        var area = Area.createArea(areaName, user, this.AppModule);
        return Listing.CalculateConditionsEphGeneric(area, this.Name);
    }

    public override object Execute(PersistentSupport sp, User user, JsonElement input)
    {
        //Prepare record
        //Fetch record while validating EPH
        // Using Primary Key
        string key = input.GetProperty("primaryKey").GetString();
        var ephConditions = RecordAccessCriteriaSet(user, "cmpny");
        var records = CSGenioAcmpny.searchList(sp, user, CriteriaSet.And()
            .SubSet(ephConditions)
            .Equal(CSGenioAcmpny.FldCodempre, key)
            ,
            new[] { CSGenioAcmpny.FldCodempre.Field }
            );
        if (records.Count == 0)
        {
            string msg = $"Record not found.";
            throw new BusinessException(msg, "DeleteCompany", msg);
        }
        CSGenioAcmpny record = records[0];
        record.delete(sp);
        return new
        {
            content = new[]
            {
                new {
                    text = "Record deleted successfully",
                    type = "text"
                }
            },
            structuredContent = new
            {
            }
        };
    }
    public override Role MininumRole => Role.ROLE_20;

    public override string AppModule => "GQT";
}
