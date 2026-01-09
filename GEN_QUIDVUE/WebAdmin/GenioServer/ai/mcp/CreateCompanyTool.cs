
namespace CSGenio.core.ai;

using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System;
using Quidgest.Persistence.GenericQuery;

public class CreateCompanyTool : McpTool
{
    public override string Name => "CreateCompany";

    public override string Title => "Creates a company";

    public override string Description => @"Create a company record";

    public override McpToolAnnotations Annotations => new McpToolAnnotations()
    {
        ReadOnlyHint = false,
        IdempotentHint = false,
        DestructiveHint = false
    };

    public override McpSchemaBase InputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {
            { "email", new McpProperty() {
                Type = "string",
                Description = "Email"
                }
            },
            { "countryForeignKey", new McpProperty() {
                Type = "string",
                Format = "uuid",
                Description = "The foreign key to the country"
                }
            },
            { "designation", new McpProperty() {
                Type = "string",
                Description = "Company name"
                }
            },
            { "telephone", new McpProperty() {
                Type = "string",
                Description = "Telephone number"
                }
            },
            { "acronym", new McpProperty() {
                Type = "string",
                Description = "Acronym"
                }
            },
            { "vat", new McpProperty() {
                Type = "string",
                Description = "Company VAT (or equivalent)"
                }
            },
        },
        Required = new List<string>() {
            "designation",
        }
    };

    public override McpSchemaBase OutputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {
            { "primaryKey", new McpProperty() {
                Type = "string",
                Format = "uuid",
                Description = "The primary key of the record to be deleted"
                }
            },
        },
        Required = new List<string>() {
            "primaryKey",
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
        var record = new CSGenioAcmpny(user);
        //Set record values
        if (input.TryGetProperty("email", out var propemail))
            record.ValEmail = propemail.GetString();
        if (input.TryGetProperty("countryForeignKey", out var propcountryForeignKey))
        {
            var countryForeignKey = propcountryForeignKey.GetString();
            var fkEphConditions = RecordAccessCriteriaSet(user, "cntry");
            var fkRecords = CSGenioAcntry.searchList(sp, user, CriteriaSet.And()
                .SubSet(fkEphConditions)
                .Equal(CSGenioAcntry.FldCodcntry, countryForeignKey),
                [ CSGenioAcntry.FldCodcntry ]
            );
            if (fkRecords.Count == 1)            
                record.ValCodcntry = countryForeignKey;
            else 
                throw new ArgumentException($"countryForeignKey is not valid");
        }
        if (input.TryGetProperty("designation", out var propdesignation))
            record.ValDesignat = propdesignation.GetString();
        else
            throw new ArgumentException($"designation is a required parameter");
        if (input.TryGetProperty("telephone", out var proptelephone))
            record.ValTelephon = proptelephone.GetString();
        if (input.TryGetProperty("acronym", out var propacronym))
            record.ValAcronym = propacronym.GetString();
        if (input.TryGetProperty("vat", out var propvat))
            record.ValNif = propvat.GetString();
        record.insert(sp);
        return new
        {
            content = new[]
            {
                new {
                    text = "Record created successfully",
                    type = "text"
                }
            },
            structuredContent = new
            {
                primaryKey = record.ValCodempre,
            }
        };
    }
    public override Role MininumRole => Role.ROLE_20;

    public override string AppModule => "GQT";
}
