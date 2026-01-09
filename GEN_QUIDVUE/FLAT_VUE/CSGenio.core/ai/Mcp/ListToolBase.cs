
namespace CSGenio.core.ai;

using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System;
using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
/// <summary>
/// Base class for list tools that query entities and return paginated results with filtering and sorting.
/// </summary>
/// <typeparam name="TEntity">The entity type that inherits from DbArea</typeparam>
public abstract class ListToolBase<TEntity> : McpTool where TEntity : DbArea
{
    public override McpSchemaBase InputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {
            {"offset" , new McpProperty() {
                Type = "integer",
                Description = "The number of items to skip before starting to collect the result set"
                }
            },
            {"numRecords" , new McpProperty() {
                Type = "integer",
                Description = "The number of records to return"
                }
            },
            {"sortBy" , new McpProperty() {
                Type = "string",
                Description = $"Column to sort by. Allowed values: {string.Join(", ", GetSortableFields())}"
                }
            },
            {"sortOrder" , new McpProperty() {
                Type = "string",
                Description = "Sort order. Allowed values: 'asc' (ascending) or 'desc' (descending). Default is 'asc'"
                }
            },
            {"filters" , new McpProperty() {
                Type = "object",
                Description = $@"Filter conditions in JSON format. Structure: {{""operator"": ""AND""|""OR"", ""conditions"": [{{""field"": string, ""operator"": string, ""value"": any}}]}}.
Supported fields: {string.Join(", ", GetSearchableFields())}.
Supported operators: 'equals', 'notEquals', 'greaterThan', 'greaterOrEqual', 'lessThan', 'lessOrEqual', 'contains', 'notContains', 'in', 'notIn'.
Conditions can be nested for complex logic. Example: {{""operator"": ""AND"", ""conditions"": [{{""field"": ""name"", ""operator"": ""contains"", ""value"": ""test""}}]}}"
                }
            },
        },
        Required = new List<string>() {
            "sortBy",
        }
    };

    public override McpSchemaBase OutputSchema => new McpSchemaBase()
    {
        Properties = new Dictionary<string, McpProperty>()
        {
            { "list", new McpProperty() {
                Type = "array",
                Description = "An array with the records",
                Items = new McpProperty() {
                    Type = "object",
                    Properties = GetOutputRecordProperties()
                }
            }
            },
            {
                "totalRecords", new McpProperty() {
                Type = "integer",
                Description = "The total number of records that fit the criteria, ignoring numRecords"
            } }
        },
        Required = new List<string>() {"list", "totalRecords" }
    };

    /// <summary>
    /// Returns the fields to retrieve from the database for this entity
    /// </summary>
    protected abstract Quidgest.Persistence.FieldRef[] GetEntityFields();

    /// <summary>
    /// Maps a field name string to a FieldRef for this entity
    /// </summary>
    /// <param name="fieldName">The field name (e.g., "name", "description")</param>
    /// <returns>The FieldRef for the field</returns>
    protected abstract Quidgest.Persistence.FieldRef MapFieldName(string fieldName);

    /// <summary>
    /// Returns an array of field names that can be used for sorting
    /// </summary>
    protected abstract string[] GetSortableFields();

    /// <summary>
    /// Returns an array of field names that can be used for filtering/searching
    /// </summary>
    protected abstract string[] GetSearchableFields();

    /// <summary>
    /// Executes the entity-specific search with the provided listing
    /// </summary>
    protected abstract void ExecuteSearch(PersistentSupport sp, User user, CriteriaSet filters, ListingMVC<TEntity> list);

    /// <summary>
    /// Maps an entity record to the output format
    /// </summary>
    protected abstract object MapOutputRecord(TEntity record);

    /// <summary>
    /// Returns the properties definition for the output record schema
    /// </summary>
    protected abstract Dictionary<string, McpProperty> GetOutputRecordProperties();

    private IList<ColumnSort> ParseSortParameters(JsonElement input)
    {
        // Parse sorting parameters
        string sortBy = null;
        if (input.TryGetProperty("sortBy", out var propSortBy))
            sortBy = propSortBy.GetString();

        string sortOrder = "asc";
        if (input.TryGetProperty("sortOrder", out var propSortOrder))
            sortOrder = propSortOrder.GetString()?.ToLower() ?? "asc";

        // Map sortBy to FieldRef and validate
        Quidgest.Persistence.FieldRef sortField = null;
        if (!string.IsNullOrEmpty(sortBy))
        {
            // Validate that the field is in the sortable fields list
            var sortableFields = GetSortableFields();
            if (!sortableFields.Contains(sortBy))
            {
                throw new ArgumentException($"Invalid sortBy value: '{sortBy}'. Allowed values are: {string.Join(", ", sortableFields)}");
            }

            sortField = MapFieldName(sortBy);
        }

        // Create sort specification
        if (sortField != null)
        {
            var order = sortOrder == "desc" ? SortOrder.Descending : SortOrder.Ascending;
            var sorts = new List<ColumnSort>();
            sorts.Add(new ColumnSort(new ColumnReference(sortField.Area, sortField.Field), order));
            return sorts;
        }

        return null;
    }

    private object ExtractValue(JsonElement valueElement)
    {
        switch (valueElement.ValueKind)
        {
            case JsonValueKind.String:
                return valueElement.GetString();
            case JsonValueKind.Number:
                if (valueElement.TryGetInt32(out int intValue))
                    return intValue;
                if (valueElement.TryGetInt64(out long longValue))
                    return longValue;
                if (valueElement.TryGetDouble(out double doubleValue))
                    return doubleValue;
                return valueElement.GetDecimal();
            case JsonValueKind.True:
                return true;
            case JsonValueKind.False:
                return false;
            case JsonValueKind.Null:
                return null;
            case JsonValueKind.Array:
                var list = new List<object>();
                foreach (var item in valueElement.EnumerateArray())
                {
                    list.Add(ExtractValue(item));
                }
                return list;
            default:
                return valueElement.GetRawText();
        }
    }

    private void AddSimpleCondition(CriteriaSet criteriaSet, JsonElement condition)
    {
        if (!condition.TryGetProperty("field", out var fieldProp))
            throw new ArgumentException("Filter condition must have a 'field' property");

        if (!condition.TryGetProperty("operator", out var opProp))
            throw new ArgumentException("Filter condition must have an 'operator' property");

        if (!condition.TryGetProperty("value", out var valueProp))
            throw new ArgumentException("Filter condition must have a 'value' property");

        string field = fieldProp.GetString();
        string op = opProp.GetString();

        // Validate that the field is in the searchable fields list
        var searchableFields = GetSearchableFields();
        if (!searchableFields.Contains(field))
        {
            throw new ArgumentException($"Invalid filter field: '{field}'. Allowed values are: {string.Join(", ", searchableFields)}");
        }

        Quidgest.Persistence.FieldRef fieldRef = MapFieldName(field);
        object value = ExtractValue(valueProp);

        switch (op?.ToLower())
        {
            case "equals":
                criteriaSet.Equal(fieldRef, value);
                break;
            case "notequals":
                criteriaSet.NotEqual(fieldRef, value);
                break;
            case "greaterthan":
                criteriaSet.Greater(fieldRef, value);
                break;
            case "greaterorequal":
                criteriaSet.GreaterOrEqual(fieldRef, value);
                break;
            case "lessthan":
                criteriaSet.Lesser(fieldRef, value);
                break;
            case "lessorequal":
                criteriaSet.LesserOrEqual(fieldRef, value);
                break;
            case "contains":
                // Add wildcards for LIKE operator
                criteriaSet.Like(fieldRef, $"%{value}%");
                break;
            case "notcontains":
                criteriaSet.NotLike(fieldRef, $"%{value}%");
                break;
            case "in":
                if (value is List<object> listValue)
                    criteriaSet.In(fieldRef, listValue);
                else
                    throw new ArgumentException("The 'in' operator requires an array value");
                break;
            case "notin":
                if (value is List<object> listValue2)
                    criteriaSet.NotIn(fieldRef, listValue2);
                else
                    throw new ArgumentException("The 'notIn' operator requires an array value");
                break;
            default:
                throw new ArgumentException($"Invalid operator: '{op}'. Allowed values are: 'equals', 'notEquals', 'greaterThan', 'greaterOrEqual', 'lessThan', 'lessOrEqual', 'contains', 'notContains', 'in', 'notIn'");
        }
    }

    private CriteriaSet ParseFilters(JsonElement filterElement)
    {
        // Handle null or undefined filter
        if (filterElement.ValueKind == JsonValueKind.Null || filterElement.ValueKind == JsonValueKind.Undefined)
            return null;

        // If no operator property, return null (no filtering)
        if (!filterElement.TryGetProperty("operator", out var opProp))
            return null;

        string logicalOp = opProp.GetString()?.ToUpper();
        if (string.IsNullOrEmpty(logicalOp))
            return null;

        CriteriaSet criteriaSet;
        switch (logicalOp)
        {
            case "AND":
                criteriaSet = CriteriaSet.And();
                break;
            case "OR":
                criteriaSet = CriteriaSet.Or();
                break;
            case "NOTAND":
                criteriaSet = CriteriaSet.NotAnd();
                break;
            case "NOTOR":
                criteriaSet = CriteriaSet.NotOr();
                break;
            default:
                throw new ArgumentException($"Invalid logical operator: '{logicalOp}'. Allowed values are: 'AND', 'OR', 'NOTAND', 'NOTOR'");
        }

        if (filterElement.TryGetProperty("conditions", out var conditionsArray))
        {
            foreach (var condition in conditionsArray.EnumerateArray())
            {
                // Check if this is a simple condition (has "field" property) or nested (has "operator" property)
                if (condition.TryGetProperty("field", out var _))
                {
                    // Simple condition
                    AddSimpleCondition(criteriaSet, condition);
                }
                else if (condition.TryGetProperty("operator", out var _))
                {
                    // Nested condition - recursive call
                    var subSet = ParseFilters(condition);
                    if (subSet != null)
                        criteriaSet.SubSet(subSet);
                }
                else
                {
                    throw new ArgumentException("Each condition must have either a 'field' property (simple condition) or an 'operator' property (nested condition)");
                }
            }
        }

        // Return null if no conditions were added
        if (criteriaSet.Criterias.Count == 0 && criteriaSet.SubSets.Count == 0)
            return null;

        return criteriaSet;
    }

    public override object Execute(PersistentSupport sp, User user, JsonElement input)
    {
        //Prepare record
        int offset = 0;
        if (input.TryGetProperty("offset", out var propOffset))
            offset = propOffset.GetInt32();

        int numRecords = 10;
        if (input.TryGetProperty("numRecords", out var propNumRecords))
            numRecords = propNumRecords.GetInt32();

        var sorts = ParseSortParameters(input);

        // Parse filters if provided
        CriteriaSet filters = null;
        if (input.TryGetProperty("filters", out var propFilters))
        {
            filters = ParseFilters(propFilters);
        }

        var list = new ListingMVC<TEntity>(
            fields: GetEntityFields(),
            sorts: sorts,
            offset: offset,
            numRegs: numRecords-1, //The list returns plus 1 results to know if there are more records, but in this case we always return the total number
            distinct:false,
            user: user,
            noLock:false,
            getTotal: true
        );

        //Set record values
        ExecuteSearch(sp, user, filters, list);

        return new
        {
            content = new[]
            {
                new {
                    text = "List returned successfully",
                    type = "text"
                }
            },
            structuredContent = new
            {
                list = list.Rows.Select(r => MapOutputRecord(r)),
                totalRecords = list.TotalRecords
            }
        };
    }
}
