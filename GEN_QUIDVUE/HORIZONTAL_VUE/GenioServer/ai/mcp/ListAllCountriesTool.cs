
namespace CSGenio.core.ai;

using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.business;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System;
using Quidgest.Persistence.GenericQuery;

public class ListAllCountriesTool : ListToolBase<CSGenioAcntry>
{
    public override string Name => "ListAllCountries";

    public override string Title => "Lists all countries";

    public override string Description => @"Lists all countries";

    public override McpToolAnnotations Annotations => new McpToolAnnotations()
    {
        ReadOnlyHint = true,
        IdempotentHint = true,
        DestructiveHint = false
    };

    protected override Quidgest.Persistence.FieldRef[] GetEntityFields()
    {
        return new Quidgest.Persistence.FieldRef[] {
            CSGenioAcntry.FldAlfa3,
            CSGenioAcntry.FldCodigonr,
            CSGenioAcntry.FldCountry,
            CSGenioAcntry.FldAlfa2,
            CSGenioAcntry.FldCodcntry,
        };
    }

    protected override Quidgest.Persistence.FieldRef MapFieldName(string fieldName)
    {
        switch (fieldName)
        {
            case "alpha3":
                return CSGenioAcntry.FldAlfa3;
            case "code3166":
                return CSGenioAcntry.FldCodigonr;
            case "country":
                return CSGenioAcntry.FldCountry;
            case "alpha2":
                return CSGenioAcntry.FldAlfa2;
            default:
                throw new ArgumentException($"Invalid field name: '{fieldName}'");
        }
    }

    protected override string[] GetSortableFields()
    {
        return new string[]
        {
            "alpha3",
            "code3166",
            "country",
            "alpha2",
        };
    }

    protected override string[] GetSearchableFields()
    {
        return new string[]
        {
            "alpha3",
            "code3166",
            "country",
            "alpha2",
        };
    }

    protected override void ExecuteSearch(PersistentSupport sp, User user, CriteriaSet filters, ListingMVC<CSGenioAcntry> list)
    {
        var result = Area.createArea("cntry", user, user.CurrentModule);        
        var ephCriteria = Listing.CalculateConditionsEphGeneric(result, this.Name);
        CSGenioAcntry.searchListAdvancedWhere(sp, user, CriteriaSet.And().SubSet(filters).SubSet(ephCriteria), list);
    }

    protected override object MapOutputRecord(CSGenioAcntry record)
    {
        return new
        {
            alpha3 = record.ValAlfa3,
            code3166 = record.ValCodigonr,
            country = record.ValCountry,
            alpha2 = record.ValAlfa2,
            primaryKey = record.ValCodcntry,
        };
    }

    protected override Dictionary<string, McpProperty> GetOutputRecordProperties()
    {
        return new Dictionary<string, McpProperty>()
        {
            { "alpha3", new McpProperty() {
                Type = "string",
                Description = "Alpha 3 code"
                }
            },
            { "code3166", new McpProperty() {
                Type = "string",
                Description = "Numeric ISO-3166 country code"
                }
            },
            { "country", new McpProperty() {
                Type = "string",
                Description = "Country name"
                }
            },
            { "alpha2", new McpProperty() {
                Type = "string",
                Description = "Alpha 2 code"
                }
            },
            { "primaryKey", new McpProperty() {
                Type = "string",
                Format = "uuid",
                Description = "The primary key of the row record"
                }
            },
        };
    }

    public override Role MininumRole => Role.ROLE_1;

    public override string AppModule => "TBS";
}
