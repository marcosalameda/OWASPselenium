using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSGenio.framework.TableConfiguration
{
    public class ToStringArrayConverter : System.Text.Json.Serialization.JsonConverter<string[]>
    {
        public override string[] Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            List<string> stringList = new List<string>();
            object[] array;
            try
            {
                // Deserialize to an object array
                array = JsonSerializer.Deserialize<object[]>(JsonElement.ParseValue(ref reader));
            }
            catch (Exception ex) 
            {
                Log.Error(ex.Message);
                array = new object[0];
            }

            // Convert all values to strings
            foreach (object item in array) 
            {
                stringList.Add(item.ToString());
            }

            return stringList.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, string[] value, JsonSerializerOptions options)
        {
            string serializedArray;
            try 
            {
                // Serialize array
                serializedArray = JsonSerializer.Serialize(value);
            }
            catch (Exception ex) 
            {
                Log.Error(ex.Message);
                serializedArray = "[]";
            }

            // Write value as raw so it is an array of strings
            writer.WriteRawValue(serializedArray);
        }
    }

    public class SearchFilter
    {
        [JsonPropertyName("name")]
		public string Name { get; set; }

        [JsonPropertyName("active")]
		public bool Active { get; set; }

        [JsonPropertyName("conditions")]
		public SearchFilterCondition[] Conditions { get; set; }
    }

    public class SearchFilterCondition
    {
        [JsonPropertyName("name")]
		public string Name { get; set; }

        [JsonPropertyName("active")]
		public bool Active { get; set; }

        [JsonPropertyName("field")]
		public string Field { get; set; }

        [JsonPropertyName("operator")]
		public string Operator { get; set; }

        [JsonPropertyName("values")]
		[System.Text.Json.Serialization.JsonConverter(typeof(ToStringArrayConverter))]
        public string[] Values { get; set; }
    }

    public class ActiveFilter
    {
        [JsonPropertyName("date")]
		public string Date { get; set; }

        [JsonPropertyName("active")]
		public bool Active { get; set; }

        [JsonPropertyName("inactive")]
		public bool Inactive { get; set; }

        [JsonPropertyName("future")]
		public bool Future { get; set; }
    }

    public class ColumnOrderBy
    {
        [JsonPropertyName("columnName")]
		public string ColumnName { get; set; }

        [JsonPropertyName("sortOrder")]
		public string SortOrder { get; set; }
    }

    public class ColumnConfiguration
    {
        [JsonPropertyName("name")]
		public string Name { get; set; }

        [JsonPropertyName("order")]
		public int Order { get; set; }

        [JsonPropertyName("visibility")]
		public int Visibility { get; set; }
    }

    public class ColumnSizing
    {
        [JsonPropertyName("tableSize")]
		public string TableSize { get; set; }

        [JsonPropertyName("columnSizes")]
		public Dictionary<string, string> ColumnSizes { get; set; }
    }

    public class TableConfiguration
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }

		[JsonPropertyName("columnConfiguration")]
        public List<ColumnConfiguration> ColumnConfiguration { get; set; }

        [JsonPropertyName("advancedFilters")]
		public List<SearchFilter> AdvancedFilters { get; set; }

        [JsonPropertyName("columnFilters")]
		public Dictionary<string, SearchFilter> ColumnFilters { get; set; }

        [JsonPropertyName("searchBarFilters")]
		public Dictionary<string, SearchFilter> SearchBarFilters { get; set; }

        [JsonPropertyName("staticFilters")]
		public Dictionary<string, string> StaticFilters { get; set; } = new Dictionary<string, string>();

        [JsonPropertyName("activeFilter")]
		public ActiveFilter ActiveFilter { get; set; }

        [JsonPropertyName("columnOrderBy")]
		public ColumnOrderBy ColumnOrderBy { get; set; }

        [JsonPropertyName("defaultSearchColumn")]
		public string DefaultSearchColumn { get; set; }

        [JsonPropertyName("columnSizes")]
		public ColumnSizing ColumnSizes { get; set; }

        [JsonPropertyName("lineBreak")]
		public bool LineBreak { get; set; }

        [JsonPropertyName("rowsPerPage")]
		public int RowsPerPage { get; set; }

        [JsonPropertyName("page")]
		public int Page { get; set; } = 1;

        [JsonPropertyName("query")]
		public string Query { get; set; }

        // Advanced filters, column filters, and searchbar filters merged
        [JsonIgnore]
        public List<SearchFilter> SearchFilters
        {
            get
            {
                List<SearchFilter> searchFilters = new List<SearchFilter>();

                if (AdvancedFilters != null)
                    searchFilters.AddRange(AdvancedFilters);

                if (ColumnFilters != null)
                    searchFilters.AddRange(ColumnFilters.Values);

                if (SearchBarFilters != null)
                    searchFilters.AddRange(SearchBarFilters.Values);

                return searchFilters;
            }
        }
    }
}
