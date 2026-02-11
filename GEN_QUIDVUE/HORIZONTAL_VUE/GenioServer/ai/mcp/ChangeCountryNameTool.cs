
namespace CSGenio.core.ai;

using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System;
using Quidgest.Persistence.GenericQuery;

public class ChangeCountryNameTool : McpTool
{
    public override string Name => "ChangeCountryName";

    public override string Title => "Change the name of a country";

    public override string Description => @"Change the name of a country";

    public override McpToolAnnotations Annotations => new McpToolAnnotations()
    {
        ReadOnlyHint = false,
        IdempotentHint = true,
        DestructiveHint = true
    };

    public override McpSchemaBase InputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {
            { "countryName", new McpProperty() {
                Type = "string",
                Description = "The new country name"
                }
            },
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
        var ephConditions = RecordAccessCriteriaSet(user, "cntry");
        var records = CSGenioAcntry.searchList(sp, user, CriteriaSet.And()
            .SubSet(ephConditions)
            .Equal(CSGenioAcntry.FldCodcntry, key)
            ,
            new[] { CSGenioAcntry.FldCodcntry.Field }
            );
        if (records.Count == 0)
        {
            string msg = $"Record not found.";
            throw new BusinessException(msg, "ChangeCountryName", msg);
        }
        CSGenioAcntry record = records[0];
        //Set record values
        if (input.TryGetProperty("countryName", out var propcountryName))
            record.ValCountry = propcountryName.GetString();
        else
            throw new ArgumentException($"countryName is a required parameter");
        record.update(sp);
        return new
        {
            content = new[]
            {
                new {
                    text = "Record updated successfully",
                    type = "text"
                }
            },
            structuredContent = new
            {
            }
        };
    }
    public override Role MininumRole => Role.ROLE_20;

    public override string AppModule => "TBS";
}
