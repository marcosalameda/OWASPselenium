using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using CSGenio.business;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.Security;

namespace CSGenio.framework
{
    public static class ElasticsearchSettingsReader
    {
        public static Dictionary<string, IndexTable> KeyValuePairsIndexTable(string fileName) => GetListFromJson(fileName, new Dictionary<string, IndexTable>());
        private static T GetListFromJson<T>(string jsonFile, T theList) where T : Dictionary<string, IndexTable>
        {
			//The file might be originally created using either Windows-1252 or iso-8859-1 instead of UTF-8
            var aggs = JsonConvert.DeserializeObject<List<IndexTable>>(File.ReadAllText(jsonFile, Encoding.GetEncoding("Windows-1252")));
            foreach (var agg in aggs)
                theList.Add(agg.Id, agg);
            return theList;
        }
    }

    public class IndexTable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool Update { get; set; }
        public string Area { get; set; }
        public string Fieldarea { get; set; }
        public string Supportform { get; set; }
        public string Resultsform { get; set; }
        public string Suggestform { get; set; }
        public IList<DocField> Fields { get; set; }
    }

    public class DocField
    {
        public int Order { get; set; }
        public string Description { get; set; }
        public string ResourceName { get; set; }
        public string Fieldname { get; set; }
        public string Area { get; set; }
        public string Relrea { get; set; }
        public string Relnnrea { get; set; }
        public string Type { get; set; }
        public string Analyzer { get; set; }
        public string Searchanalyzer { get; set; }
        public bool Searchcriteria { get; set; }
        public bool Searchastext { get; set; }
        public bool Allowsfiltering { get; set; }
        public bool Gotocard { get; set; }
        public bool Gotsuggest { get; set; }
        public bool Thumbnail { get; set; }
        public bool Highlight { get; set; }
        public double Weight { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string Aggname { get; set; }
        public string Aggtype { get; set; }
        public string Aggfield { get; set; }

        private const string attachmentName = "attachment";
        private const string attachmentContent = "content";

        /// <summary>
        /// To be included in the "fields": attribute of query_string in search
        /// For example, this function returns each one of the fields and the final result will be:
        /// "fields": ["forn1regis.nome", "tipodregis.tipodocu", "assunto", "observac", "concaten"]
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: elasticsearch doc field name to be included in the search attribute of query search</returns>
        public string GetNameField(string area) => (area == Area) ?
                string.Concat(Fieldname.ToLower(), 
                    Weight > 0.0 ? 
                    string.Concat("^", Weight.ToString()) : "") : 
                    string.Concat(Area.ToLower(), area.ToLower(), ".", string.Concat(Fieldname.ToLower(), Weight > 0.0 ? string.Concat("^", Weight.ToString()) : ""));

        /// <summary>
        /// If using ingest attachment pipeline plugin
        /// To be included in the "fields": attribute of query_string in search
        /// For example, this function returns each one of the fields and the final result will be:
        /// "fields": ["documregis.attachment.content^1", ...
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: elasticsearch doc field name to be included in the search attribute of query search</returns>
        public string GetAttachmentNameField(string area) => (area == Area) ?
                string.Concat(attachmentName, ".", attachmentContent.ToLower(), Weight > 0.0 ? string.Concat("^", Weight.ToString()) : "") :
                string.Concat(Area.ToLower(), area.ToLower(), ".", attachmentName, ".", string.Concat(attachmentContent.ToLower(), Weight > 0.0 ? string.Concat("^", Weight.ToString()) : ""));

        /// <summary>
        /// If using FSCrawler as REST service to get simulated Json
        /// Doc mappings will be customized including most of FSCrawler fields plus other fields necessary as the primarykey of the document in the table
        /// To be included in the "fields": attribute of query_string in search
        /// For example, this function returns each one of the fields and the final result will be:
        /// "fields": ["documregis.content^1", ...
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: elasticsearch doc field name to be included in the search attribute of query search</returns>
        public string GetFSCrawlerRestNameField(string area) => (area == Area) ?
                string.Concat(attachmentName, Weight > 0.0 ? string.Concat("^", Weight.ToString()) : "") :
                string.Concat(Area.ToLower(), area.ToLower(), ".", string.Concat(attachmentContent.ToLower(), Weight > 0.0 ? string.Concat("^", Weight.ToString()) : ""));

        /// <summary>
        /// Search results will be sorted accordingly this field
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: field name for sorted results</returns>
        public string GetSortField(string area) => (area == Area) ? Fieldname.ToLower() : string.Concat(Area.ToLower(), area.ToLower(), ".", Fieldname.ToLower());

        /// <summary>
        /// The highlight field to be included in search query
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: The highlight field to be included in search query</returns>
        public string GetNameToHighlight(string area) => (area == Area) ? 
                string.Concat("\"", Fieldname.ToLower(), "\"") : string.Concat("\"", Area.ToLower(), area.ToLower(), ".", Fieldname.ToLower(), "\"");

        /// <summary>
        /// If using ingest attachment pipeline plugin
        /// This will bem available in the highlight section of the search result
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: the field name using property name + type attachment name + field name</returns>
        public string GetAttachmentNameToHighlight(string area) => (area == Area) ?
                string.Concat("\"", attachmentName, ".", attachmentContent.ToLower(), "\"") :
                string.Concat("\"", Area.ToLower(), area.ToLower(), ".", attachmentName, ".", attachmentContent.ToLower(), "\"");

        /// <summary>
        /// If using FSCrawler as REST service to get simulated Json
        /// This will bem available in the highlight section inside inner_hits of the search result
        /// </summary>
        /// <param name="area"></param>
        /// <returns>string: the field name using property name + field name</returns>
        public string GetFSCrawlerRestNameToHighlight(string area) => (area == Area) ?
                string.Concat("\"", attachmentContent.ToLower(), "\"") :
                string.Concat("\"", Area.ToLower(), area.ToLower(), ".", attachmentContent.ToLower(), "\"");

    }

    public class ElasticsearchEPHCondition
    {
        public string System { get; set; }
        public string TabelaEph { get; set; }
        public string AreaEph { get; set; }
        public string CampoEph { get; set; }
        public string SearchOperator { get; set; }
        public string Value { get; set; }
        public object ValueObj { get; set; }

        public ElasticsearchEPHCondition() { }

        public ElasticsearchEPHCondition(string system, string tabelaEph, string areaEph, string campoEph, string searchOperator, string value, object valueObj = null)
        {
            System = system;
            TabelaEph = tabelaEph;
            AreaEph = areaEph;
            CampoEph = campoEph;
            SearchOperator = searchOperator;
            Value = value;
            ValueObj = valueObj;
        }
        public string GetFieldFullName(string mainArea)
        {
            return string.Concat(AreaEph.ToLower(), mainArea.ToLower(), ".", CampoEph.ToLower());
        }
    }

    /// <summary>
    /// It will serve the purpose of removing fields that are not in the Elasticsearch index.
    /// </summary>
    public class AreaFieldnamePair
    {
        public string Area { get; set; }
        public string Fieldname { get; set; }
    }

    /// <summary>
    /// This class is intended to be filled with elements to be used as filter limits in the elasticsearch query filter json
    /// </summary>
    public class ElasticsearchEPH
    {
        /// <summary>
        /// For the basic relation between elements. The purpose, in analogy of sql syntax it would be as this example:
        /// <example>WHERE  fieldA = 0 AND fieldB = 0 OR (fieldC = 1 AND fieldD = 1)</example>
        /// </summary>
        public enum Operation
        {
            And,
            Or,
            NotAnd,
            NotOr
        }

        /// <summary>
        /// Every EPHConditions and EphSubConditions will be splitted by this ConditionOperator
        /// </summary>
        public Operation ConditionOperator { get; set; }

        /// <summary>
        /// Each EPHCondition represents a field in the filter
        /// </summary>
        public List<ElasticsearchEPHCondition> EphConditions { get; set; } = new List<ElasticsearchEPHCondition>();

        /// <summary>
        /// Each EphSubConditions represents a group of fields with their own operation. List of classes of this class
        /// </summary>
        public List<ElasticsearchEPH> EphSubConditions { get; } = new List<ElasticsearchEPH>();

        /// <summary>
        /// This property will be empty by default when executing a search request.
        /// </summary>
        private JObject customJsonFilter;

        /// <summary>
        /// If you do not set using the method <c>SetCustomJsonFilter(string value)</c> this property will be empty by default when executing a search request.
        /// </summary>
        public JObject GetCustomJsonFilter()
        {
            return customJsonFilter;
        }

        /// <summary>
        /// You might want to specify one customized filter based on your use case<br/>
        /// For that you can add custom code to the <c>FTSINI</c> manwin tag to build your filter.<br/>
        /// <example>
        /// Example:
        /// <code>
        ///     JObject filter = new JObject
        ///     {
        ///         ["bool"] = new JObject {
        ///             ["must"] = new JArray {
        ///                 new JObject {
        ///                     ["range"] = new JObject {
        ///                         ["confrnivel"] = new JObject {
        ///                             ["lte"] = confrnivel
        ///                         }
        ///                     }
        ///                 }
        ///             }
        ///         }
        ///     };
        ///     return JsonConvert.SerializeObject(filter);
        /// </code>
        /// </example>
        /// </summary>
        public void SetCustomJsonFilter(JObject value)
        {
            customJsonFilter = value;
        }

        /// <summary>
        /// Store the user so it checks for the next time running into this code to if it's for the same user and level, don't repeat itself
        /// </summary>
        private User user;

        /// <summary>
        /// Get the current user stored
        /// </summary>
        /// <returns></returns>
        public User Getuser()
        {
            return user;
        }

        /// <summary>
        /// Set the current user 
        /// </summary>
        /// <param name="value"></param>
        public void Setuser(User value)
        {
            user = value;
        }

        /// <summary>
        /// Store the level of the user so it checks for the next time running into this code to if it's for the same user and level, don't repeat itself
        /// </summary>
        private int level;

        /// <summary>
        /// Get the current level of the user
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return level;
        }

        /// <summary>
        /// Store the current level of the user
        /// </summary>
        /// <returns></returns>
        public void SetLevel(int value)
        {
            level = value;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ElasticsearchEPH() { }

        /// <summary>
        /// Constructor of this class that add an element to the EPHCondition using the parameters fields
        /// </summary>
        /// <param name="system"></param>
        /// <param name="tabelaEph"></param>
        /// <param name="areaEph"></param>
        /// <param name="campoEph"></param>
        /// <param name="searchOperator"></param>
        /// <param name="value"></param>
        public ElasticsearchEPH(string system, string tabelaEph, string areaEph, string campoEph, string searchOperator, string value)
        {
            EphConditions.Add(new ElasticsearchEPHCondition(system, tabelaEph, areaEph, campoEph, searchOperator, value));
        }

        /// <summary>
        /// Remove duplicate entries in the <c>EphConditions</c> based on their properties.<br/>
        /// Using LINQ to group the items by these properties and then select the first item in each group
        /// </summary>
        public void RemoveDuplicatesEph() => EphConditions = EphConditions
            .GroupBy(a => new { a.System, a.TabelaEph, a.AreaEph, a.CampoEph, a.SearchOperator, a.Value })
            .Select(g => g.First())
            .ToList();

        /// <summary>
        /// Fields that don't belong in the Elasticsearch index doc, must not stay on this list.
        /// The filter to be incorporated in the json query must not have this fields. If it does, there will be no results in every search.
        /// </summary>
        /// <param name="elemsToVerify"></param>
        public void RemoveNotBelongingFields(List<AreaFieldnamePair> elemsToVerify)
        {
            EphConditions = EphConditions.Where(n => elemsToVerify.Any(a => a.Area == n.AreaEph && a.Fieldname == n.CampoEph)).ToList();
            RemoveNotBelongingsInnerLists(EphSubConditions, elemsToVerify);
        }

        /// <summary>
        /// Recursive method that continue the cleaning of not existing index fields form inner lists
        /// </summary>
        /// <param name="EphSubConditions"></param>
        /// <param name="elemsToVerify"></param>
        private void RemoveNotBelongingsInnerLists(List<ElasticsearchEPH> EphSubConditions, List<AreaFieldnamePair> elemsToVerify)
        {
            foreach (var item in EphSubConditions)
            {
                item.EphConditions = item.EphConditions.Where(n => elemsToVerify.Any(a => a.Area == n.AreaEph && a.Fieldname == n.CampoEph)).ToList();
                if (item.EphSubConditions != null)
                    RemoveNotBelongingsInnerLists(item.EphSubConditions, elemsToVerify);
            }
        }
    }


    /// <summary>
    /// Represent a pipeline bounded to an index mapping field.
    /// </summary>
    public class Pipeline
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
    }

    /// <summary>
    /// Settings and Mappings
    /// Will read json files with settings and mappings to be sent to Elastic
    /// It is based on these files that indexes and the data structure are created in Elasticserc
    /// </summary>
    public static class ElasticsearchConfigurations
    {
        public static string GetSettingsDexittm => SettingsAndMappings.SettingsDexittm;
        public static string GetSettingsPrepairs => SettingsAndMappings.SettingsPrepairs;
        public static string GetSettingsReparaco => SettingsAndMappings.SettingsReparaco;
        public static string GetSettingsReparaso => SettingsAndMappings.SettingsReparaso;
        public static string GetSettingsTmlinem => SettingsAndMappings.SettingsTmlinem;
        public static string GetSettingsTmlinew => SettingsAndMappings.SettingsTmlinew;
        public static string GetSettingsTmliney => SettingsAndMappings.SettingsTmliney;
        public static string GetSettingsTmlleday => SettingsAndMappings.SettingsTmlleday;
        public static string GetSettingsVisitas => SettingsAndMappings.SettingsVisitas;
        public static List<Pipeline> GetPipeline => InjestPipelines.Pipelines;
		
        private static class InjestPipelines
        {
			public static List<Pipeline> Pipelines { get; set; }
            static InjestPipelines()
            {
                Pipelines = new List<Pipeline>
                {

                };
            }

            /// <summary>
            /// Generate the JSON string to be used in injest pipeline for some given field 
            /// </summary>
            /// <param name="field"></param>
            /// <returns></returns>
            private static string CreateInjestJson(string field)
            {
                var processors = new List<object>();

                var foreach1 = new Dictionary<string, object>
                {
                    { "field", field }
                };

                var attachment = new Dictionary<string, string>
                {
                    { "target_field", "_ingest._value.attachment" },
                    { "field", "_ingest._value.data" }
                };

                foreach1.Add("processor", new Dictionary<string, object>()
                {
                    {"attachment", attachment}
                });


                processors.Add(new Dictionary<string, object>()
                {
                    {"foreach", foreach1}
                });

                var foreach2 = new Dictionary<string, object>
                {
                    { "field", field },
                    {
                        "processor",
                        new Dictionary<string, object>()
                {
                    {"remove", new Dictionary<string, string>() { { "field", "_ingest._value.data" } }}
                }
                    }
                };

                processors.Add(new Dictionary<string, object>()
                {
                    {"foreach", foreach2}
                });

                var jsonObject = new Dictionary<string, object>()
                {
                    {"description", "Extract file information from arrays of base64 from word, pdf, etc"},
                    {"version", 1},
                    {"processors", processors}
                };

                return JsonConvert.SerializeObject(jsonObject);
            }
        }

        /// <summary>
        /// To create a JSON object with the structure that must be injected into elasticsearch node
        /// </summary>
        private static class SettingsAndMappings
        {
			public static string SettingsDexittm { get; set; }
			public static string SettingsPrepairs { get; set; }
			public static string SettingsReparaco { get; set; }
			public static string SettingsReparaso { get; set; }
			public static string SettingsTmlinem { get; set; }
			public static string SettingsTmlinew { get; set; }
			public static string SettingsTmliney { get; set; }
			public static string SettingsTmlleday { get; set; }
			public static string SettingsVisitas { get; set; }
            static SettingsAndMappings()
            {
                JObject rootDexittm = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsDexittm() }
                };
                SettingsDexittm = JsonConvert.SerializeObject(rootDexittm);
                JObject rootPrepairs = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsPrepairs() }
                };
                SettingsPrepairs = JsonConvert.SerializeObject(rootPrepairs);
                JObject rootReparaco = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsReparaco() }
                };
                SettingsReparaco = JsonConvert.SerializeObject(rootReparaco);
                JObject rootReparaso = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsReparaso() }
                };
                SettingsReparaso = JsonConvert.SerializeObject(rootReparaso);
                JObject rootTmlinem = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsTmlinem() }
                };
                SettingsTmlinem = JsonConvert.SerializeObject(rootTmlinem);
                JObject rootTmlinew = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsTmlinew() }
                };
                SettingsTmlinew = JsonConvert.SerializeObject(rootTmlinew);
                JObject rootTmliney = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsTmliney() }
                };
                SettingsTmliney = JsonConvert.SerializeObject(rootTmliney);
                JObject rootTmlleday = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsTmlleday() }
                };
                SettingsTmlleday = JsonConvert.SerializeObject(rootTmlleday);
                JObject rootVisitas = new JObject
                {
                    { "settings", Settings() },
                    { "mappings", MappingsVisitas() }
                };
                SettingsVisitas = JsonConvert.SerializeObject(rootVisitas);
			}

            /// <summary>
            /// The first part is the setting. As a header common to all json
            /// </summary>
            /// <returns></returns>
            private static JObject Settings()
            {
                // Create a new JSON object
                JObject jsonObject = new JObject
                {
                    // Add properties to the object
                    ["index"] = new JObject
                    {
                        ["number_of_shards"] = 1,
                        ["number_of_replicas"] = 1
                    },
                    ["analysis"] = new JObject
                    {
                        ["filter"] = new JObject
                        {
                            ["name_ngrams"] = new JObject
                            {
                                ["max_gram"] = 20,
                                ["min_gram"] = 2,
                                ["type"] = "edge_ngram"
                            }
                        },
						["analyzer"] = new JObject
						{
							["custom_analyzer_1"] = new JObject
							{
								["filter"] = new JArray()
								{
									"lowercase",
									"asciifolding"
								},
								["type"] = "custom",
								["tokenizer"] = "standard"
							},
							["custom_analyzer_2"] = new JObject
							{
								["filter"] = new JArray()
								{
									"lowercase",
									"name_ngrams",
									"asciifolding"
								},
								["type"] = "custom",
								["tokenizer"] = "standard"
							}
						}
					}
                };
                // Return the JSON object
                return jsonObject;
            }

            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsDexittm()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["coditem"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["itemdes"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["itemcod"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["date"] = new JObject { ["type"] = "date", ["fields"] = new JObject { ["raw"] = new JObject { ["type"] = "keyword" } } }
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsPrepairs()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["codrepar"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,["pessorepar"] = new JObject 
						{ 
							["properties"] = new JObject 
							{
								
								["name"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
							}
						}
						,
						["descript"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["nrrepara"] = new JObject { ["type"] = "long" }
						,["specirepar"] = new JObject 
						{ 
							["properties"] = new JObject 
							{
								
								["especial"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
							}
						}
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsReparaco()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["codrepar"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["nrrepara"] = new JObject { ["type"] = "long" }
						,
						["descript"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,["pessorepar"] = new JObject 
						{ 
							["properties"] = new JObject 
							{
								
								["name"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
							}
						}
						,["specirepar"] = new JObject 
						{ 
							["properties"] = new JObject 
							{
								
								["especial"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
							}
						}
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsReparaso()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["codrepar"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,["pessorepar"] = new JObject 
						{ 
							["properties"] = new JObject 
							{
								
								["name"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
							}
						}
						,
						["descript"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["nrrepara"] = new JObject { ["type"] = "long" }
						,["specirepar"] = new JObject 
						{ 
							["properties"] = new JObject 
							{
								
								["especial"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
							}
						}
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsTmlinem()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["coditem"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["itemdes"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["itemcod"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["date"] = new JObject { ["type"] = "date", ["fields"] = new JObject { ["raw"] = new JObject { ["type"] = "keyword" } } }
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsTmlinew()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["coditem"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["itemdes"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["itemcod"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["date"] = new JObject { ["type"] = "date", ["fields"] = new JObject { ["raw"] = new JObject { ["type"] = "keyword" } } }
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsTmliney()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["coditem"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["itemdes"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["itemcod"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["date"] = new JObject { ["type"] = "date", ["fields"] = new JObject { ["raw"] = new JObject { ["type"] = "keyword" } } }
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsTmlleday()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["coditem"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["itemdes"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["itemcod"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["date"] = new JObject { ["type"] = "date", ["fields"] = new JObject { ["raw"] = new JObject { ["type"] = "keyword" } } }
					}

				};
                // Return the JSON object
                return jsonObject;
			}
            /// <summary>
			/// Mapping defining how a document, and the fields it contains, are stored and indexed.
			/// </summary>
			/// <returns></returns>
			private static JObject MappingsVisitas()
			{
				// Create a new JSON object
				JObject jsonObject = new JObject
				{
					// Add properties to the object
					["properties"] = new JObject
					{
						["codvisit"] = new JObject
						{
							["type"] = "keyword",
							["index"] = false
						}
						,
						["title"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
						,
						["observat"] = new JObject { ["type"] = "text", ["fielddata"] = true, ["analyzer"] = "custom_analyzer_1", ["search_analyzer"] = "custom_analyzer_2" }
					}

				};
                // Return the JSON object
                return jsonObject;
			}
			
			
            private static JArray DynamicTemplates()
            {
                return new JArray
                { 
                    new JObject
                    {
                        ["strings"] = new JObject
                        {
                            ["match_mapping_type"] = "*",
                            ["mapping"] = new JObject
                            {
                                ["type"] = "text",
                                ["fields"] = new JObject
                                {
                                    ["keyword"] = new JObject
                                    {
                                        ["type"] = "keyword",
                                        ["ignore_above"] = 256
                                    }
                                }
                            }
                        }
                    }
                };
            }
        }
    }

    public static class ElasticsearchAvailableIndexes
    {
        private class IndexConfig
        {
            private string index;
            private string id;
            private string area;
            private string url;
            private string urlfscrawler;
            private string username;
            private SecureString password;
            public IndexConfig(string index, string id, string area, string url, string urlfscrawler = "", string username = "", SecureString password = null)
            {
                this.index = index;
                this.id = id;
                this.area = area;
                this.url = url;
                this.urlfscrawler = urlfscrawler;
                this.username = username;
                this.password = password;

            }
            public string Index { get => index; set => index = value; }
            public string Id { get => id; set => id = value; }
            public string Area { get => area; set => area = value; }
            public string Url { get => url; set => url = value; }
            public string UrlFSCrawler { get => urlfscrawler; set => urlfscrawler = value; }
            public string Username { get => username; set => username = value; }
            public SecureString Password { get => password; set => password = value; }
        }

        private static readonly List<IndexConfig> list = new List<IndexConfig>();

        static ElasticsearchAvailableIndexes()
        {
            if (Configuration.ElasticsearchXml != null && Configuration.ElasticsearchXml.Colours.Count > 0)
            {
                foreach (var core in Configuration.ElasticsearchXml.Colours)
                    list.Add(new IndexConfig(core.Index, core.Name, core.Area, core.Url, core.Urlfscrawler, core.Username, core.PasswordSecured));
            }
        }
        /// <summary>
        /// Returns the index name which will be used to be queried
        /// </summary>
        /// <param name="area">Which area is selected</param>
        /// <returns>Index name where queries will be submited</returns>
        internal static string GetIndexFromArea(string area)
        {
            return list?.FirstOrDefault(s => string.Equals(s.Area, area, StringComparison.OrdinalIgnoreCase))?.Index;
        }

        /// <summary>
        /// Retrieves the index name associated with a given ID, which will be used to submit queries.
        /// </summary>
        /// <param name="indexId">The unique identifier for which the index name is to be retrieved.</param>
        /// <returns>The index name associated with the given ID, or null if no match is found or if the list is uninitialized.</returns>
        /// <remarks>
        /// This method performs a case-insensitive search through a pre-configured list to find an index name corresponding to the provided ID.
        /// If no matching ID is found or the list is null, the method returns null. This method is commonly used to map ID values to their corresponding index names for query purposes.
        /// </remarks>
        public static string GetIndexFromId(string indexId)
        {
            if (list == null || string.IsNullOrEmpty(indexId))
            {
                return null;
            }
            return list.FirstOrDefault(s => string.Equals(s.Id, indexId, StringComparison.OrdinalIgnoreCase))?.Index;
        }

        /// <summary>
        /// Returns the first id name from the specified area which will be used for a query, if any.
        /// </summary>
        /// <param name="area">Area selected to filter the IDs</param>
        /// <returns>The first ID name where a query can be submitted, or null if no match is found</returns>
        public static string GetFirstIdFromArea(string area)
        {
            return list?.FirstOrDefault(s => string.Equals(s.Area, area, StringComparison.OrdinalIgnoreCase))?.Id;
        }

        /// <summary>
        /// Retrieves a list of identifier names for a specified area, which will be used to submit queries.
        /// </summary>
        /// <param name="area">The area to filter by when selecting IDs.</param>
        /// <returns>A list of identifier names associated with the specified area. Returns an empty list if no identifiers are found or if an error occurs.</returns>
        /// <remarks>
        /// This method filters a pre-configured list by the specified area, performing a case-insensitive comparison,
        /// and returns all corresponding IDs. <br/>
        /// It is designed to handle situations where the list might be uninitialized or empty by returning an empty list instead of throwing an exception.
        /// </remarks>
        public static List<string> GetIdsFromArea(string area)
        {
            if (list == null || string.IsNullOrEmpty(area))
            {
                return new List<string>();
            }

            return list.Where(s => string.Equals(s.Area, area, StringComparison.OrdinalIgnoreCase))
                       .Select(s => s.Id)
                       .ToList();
        }

        /// <summary>
        /// Retrieves the URL associated with a given index name, which is used for querying the Elasticsearch index.
        /// </summary>
        /// <param name="index">The name of the index whose URL is needed.</param>
        /// <returns>The URL for the specified index, or null if the index name does not exist or the URL is not configured.</returns>
        /// <remarks>
        /// This method searches a pre-configured list of index names and their corresponding URLs. It performs a case-insensitive comparison
        /// to find the URL associated with the provided index name. If no matching index name is found, the method returns null.
        /// This function is typically used to retrieve the endpoint for submitting queries to an Elasticsearch index.
        /// </remarks>
        internal static string GetURLFromIndexName(string index)
        {
            // Using null conditional operator to handle cases where the list might be uninitialized
            return list?.FirstOrDefault(s => string.Equals(s.Index, index, StringComparison.OrdinalIgnoreCase))?.Url;
        }

        /// <summary>
        /// Retrieves the URL associated with a given index ID, which is used for querying the Elasticsearch index.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index whose URL is needed.</param>
        /// <returns>The URL for the specified index ID, or null if the index ID does not exist or the URL is not configured.</returns>
        /// <remarks>
        /// This method searches a pre-configured list of index IDs and their corresponding URLs.<br/>
        /// It performs a case-insensitive comparison to find the URL associated with the provided index ID.<br/>
        /// If no matching index ID is found, the method returns null.<br/>
        /// This function is typically used to retrieve the endpoint for submitting queries to an Elasticsearch index.
        /// </remarks>
        internal static string GetURLFromIndexId(string indexId)
        {
            return list?.FirstOrDefault(s => string.Equals(s.Id, indexId, StringComparison.OrdinalIgnoreCase))?.Url;
        }


        /// <summary>
        /// Retrieves the URL to the FSCrawler service associated with a given index ID.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index for which the FSCrawler URL is needed.</param>
        /// <returns>The URL to the FSCrawler service for the specified index, or null if the index ID does not exist or the URL is not configured.</returns>
        /// <remarks>
        /// This method searches a pre-configured list of index IDs and their corresponding FSCrawler URLs. <br/>
        /// It performs a case-insensitive comparison to find the URL associated with the provided index ID. <br/>
        /// If no matching index ID is found, the method returns null.<br/>
        /// This function is typically used to retrieve the endpoint for submitting files to the FSCrawler service associated with the specified index.
        /// </remarks>
        internal static string GetURLFSCrawler(string indexId)
        {
            return list?.FirstOrDefault(s => string.Equals(s.Id, indexId, StringComparison.OrdinalIgnoreCase))?.UrlFSCrawler;
        }

        /// <summary>
        /// Returns the username for the elasticsearch cluster login
        /// The atomic comparison must be url and index, because in one endpoint the index name must be unique
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Username for the elasticsearch cluster login</returns>
        internal static string GetUsername(string url, string index)
        {
            return list?.FirstOrDefault(s => string.Equals(s.Url, url, StringComparison.OrdinalIgnoreCase) && string.Equals(s.Index, index, StringComparison.OrdinalIgnoreCase))?.Username;
        }

        /// <summary>
        /// Returns the password for the elasticsearch cluster login
        /// The atomic comparison must be url and index, because in one endpoint the index name must be unique
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Username for the elasticsearch cluster login</returns>
        internal static SecureString GetPassword(string url, string index)
        {
            return list?.FirstOrDefault(s => string.Equals(s.Url, url, StringComparison.OrdinalIgnoreCase) && string.Equals(s.Index, index, StringComparison.OrdinalIgnoreCase))?.Password;
        }

    }

    /// <summary>
    /// This class is responsible for sanitizing the search text entered by a user.
    /// </summary>
    public static class Sanitize
    {
        /// <summary>
        /// Removes characters or words like "of", "or", etc.. that are in the stopwords files for the various languages, 
        /// and also escapes reserved characters.<br/>
        /// Elasticsearch reserved characters:
        /// <code>
        /// <![CDATA[+ - = && || > < ! ( ) { } [ ] ^ " ~ * ? : \ / AND OR NOT space]]>
        /// </code>
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string GetSanitized(string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";
            var parsedInput = input;
            // Escape special characters for use in an Elasticsearch query
            parsedInput = EscapeElasticsearchSpecialCharacters(parsedInput);
            // Escape boolean operators for used to combine or modify the terms in a search query
            parsedInput = EscapeElasticsearchBooleanOperators(parsedInput);
            // Escape Stopwords defined in \\Content\\Elasticsearch\\stopwords\\pt.txt and ...en.txt
            parsedInput = EscapeStopwords(parsedInput);
            // If the search text ends with the character asterisk, we assume as a wildcard mark for search
            parsedInput = WildcardFromEnd(parsedInput, "\\*");

            return parsedInput;
        }

        /// <summary>
        /// Escape Stopwords defined in \\Content\\Elasticsearch\\stopwords\\pt.txt and ...en.txt
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string EscapeStopwords(string input)
        {
            var tokens = input.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(input.Length);
            foreach (var t in tokens)
            {
                if (t.Length < 1)
                    continue;
                var word = t.ToLowerInvariant();
                if (Stopwords.ListStopwords.Contains(word))
                    continue;
                sb.Append(word);
                sb.Append(' ');
            }
            if (sb.Length > 1)
                sb.Remove(sb.Length - 1, 1);
            return sb.ToString(); ;
        }

        /// <summary>
        /// If the search text ends with the character asterisk, we assume as a wildcard mark for search
        /// </summary>
        /// <param name="input"></param>
        /// <param name="wildcard"></param>
        /// <returns></returns>
        public static string WildcardFromEnd(this string input, string wildcard)
        {
            if (input.EndsWith(wildcard))
                return string.Concat(input.Substring(0, input.Length - wildcard.Length), "*");
            else
                return input;
        }

        /// <summary>
        /// Escapes special characters to prevent them from interfering with syntax in an Elasticsearch query.
        /// This function targets the following characters:
        /// <code>
        /// <![CDATA[+ - = && || > < ! ( ) { } [ ] ^ " ~ * ? : \ /]]>
        /// </code>
        /// Note: This does not handle escaping of boolean operators or spaces.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EscapeElasticsearchSpecialCharacters(string input)
        {
            // Escape special characters for use in an Elasticsearch query
            string escapedInput = Regex.Replace(input, @"([+\-!(){}\[\]/^""~*?:\\])", @"\$1");

            // Return the escaped input
            return escapedInput;
        }

        /// <summary>
        /// Escapes boolean operators (AND, OR, NOT) in input strings for use in Elasticsearch queries.
        /// This prevents them from being interpreted as operators when they should be treated as part of the query terms.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EscapeElasticsearchBooleanOperators(string input)
        {
            // Escape boolean operators for use in an Elasticsearch query
            string escapedInput = Regex.Replace(input, @"(\bAND\b|\bOR\b|\bNOT\b)", @"\$1", RegexOptions.IgnoreCase);

            // Return the escaped input
            return escapedInput;
        }
    }

    /// <summary>
    /// StopWords
    /// </summary>
    public static class Stopwords
    {
        public static HashSet<string> ListStopwords { get; set; }
        static Stopwords()
        {
            ListStopwords = new HashSet<string>();
            using (StreamReader sr = new StreamReader(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\\Content\\Elasticsearch\\stopwords\\pt.txt")))
                while (!sr.EndOfStream)
                    ListStopwords.Add(sr.ReadLine().Trim());
            using (StreamReader sr = new StreamReader(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\\Content\\Elasticsearch\\stopwords\\en.txt")))
                while (!sr.EndOfStream)
                    ListStopwords.Add(sr.ReadLine().Trim());
        }
    }


    /// <summary>
    /// Deal with the EPH implemented in Genio Definitions for specified user level
    /// </summary>
    public class UserEPHRestrictions
    {
        private static ElasticsearchEPH EphsUser { get; set; }
        public ElasticsearchEPH GetEphsUserToElasticQuery() => EphsUser;
        private int GetModuleLevel(User user, string module) => Convert.ToInt32(user.GetModuleRoles(module)[0].ToString());
        private string GetCurrentModule(User user) => user.CurrentModule.ToLower() == "public" ? "PGI" : user.CurrentModule.ToUpper();
        private readonly User user;
        private KeyValuePair<string, IndexTable> valuesMappings;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="user"></param>
        /// <param name="valuesMappings"></param>
        public UserEPHRestrictions(User user, KeyValuePair<string, IndexTable> valuesMappings)
        {
            this.user = user;
            this.valuesMappings = valuesMappings;
        }

        /// <summary>
        /// The purpose of this methid is to populate the <c>EphsUser</c> object with the existing EPHs limitations and/or passed by manual code with the FTSINI manwin tag
        /// </summary>
        public void Initialize()
        {
            string module = GetCurrentModule(user);
            int level = GetModuleLevel(user, module);
            bool repeatItself = EphsUser == null || (EphsUser.Getuser() != user && EphsUser.GetLevel() != level);
            if (repeatItself)
            {
                EphsUser = new ElasticsearchEPH();
                EphsUser.Setuser(user);
                EphsUser.SetLevel(level);
                if (user.hasEph())
                {
                    // all the areas that exist in this search
                    var areas = valuesMappings.Value.Fields.GroupBy(x => x.Area.ToLower()).Select(z => z.Key).ToList();
                    GetEphsToElasticQuery(user, areas);
                }
            }

			// USE /[MANUAL GQT FTSINI]/

            if (repeatItself)
            {
                // There may be duplicates either by entries from the definitions in Genio or by custom code in the FTSINI manwin tag
                EphsUser.RemoveDuplicatesEph();

                // The list of all the fields that exists in the Elasticsearch index doc 
                var areasAndFields = valuesMappings.Value.Fields.Select(x => new AreaFieldnamePair { Area = x.Area, Fieldname = x.Fieldname }).ToList();

                // The previous list, is used to clean the not belonging fields that are consider in the EphsUser object that will be used in the filter construction
                EphsUser.RemoveNotBelongingFields(areasAndFields);
            }
        }

        /// <summary>
        /// Search for the Genio generated EPHs in the system
        /// </summary>
        /// <param name="user"></param>
        /// <param name="areas"></param>
        private static void GetEphsToElasticQuery(User user, List<string> areas)
        {
            foreach (var area in areas)
            {
                // Only consider eph's directly related to the result area
                var areaBase = CSGenio.business.Area.createArea(area.ToLower(), user, user.CurrentModule);
                List<EPHOfArea> ephsDaArea = areaBase.CalculateAreaEphs(user.Ephs, null, false);
                FillEphsList(ephsDaArea);
            }
        }

        /// <summary>
        /// Fills a list with the Genio generated EPHs found in the system
        /// </summary>
        /// <param name="ephsDaArea"></param>
        private static void FillEphsList(List<EPHOfArea> ephsDaArea)
        {
            foreach (EPHOfArea eph in ephsDaArea)
            {
                var ephArea = eph.Eph;

                AreaInfo tabelaEPH = Area.GetInfoArea(ephArea.Table);

                string system = tabelaEPH.QSystem.ToLower();
                string tabelaEph = tabelaEPH.TableName.ToLower().Replace(system, "");
                string areaEph = tabelaEPH.Alias.ToLower();
                string campoEph = ephArea.Field;

                EphsUser.ConditionOperator = ElasticsearchEPH.Operation.And;
                foreach (var item in eph.ValuesList)
                {
                    string value = GetValueStr(item, ephArea.Table, ephArea.Field);
                    EphsUser.EphConditions.Add(new ElasticsearchEPHCondition(system, tabelaEph, areaEph, campoEph, ephArea.Operator, value));
                }
            }
        }

        /// <summary>
        /// Parse the value base on its type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="table"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetValueStr(string value, string table, string field)
        {
            string result;
            AreaInfo areaInfo = Area.GetInfoArea(table);

            FieldFormatting format = areaInfo.DBFields[field].FieldType.GetFormatting();

            switch (format)
            {
                case FieldFormatting.DATA:
                case FieldFormatting.DATAHORA:
                case FieldFormatting.DATASEGUNDO:
                    DateTime datetime = DateTime.Parse(value);
                    result = datetime.ToString("o") + "Z";
                    break;
                default:
                    result = Conversion.internal2String(value, areaInfo.DBFields[field].FieldType);
                    break;
            }
            return result;
        }
    }

    /// <summary>
    /// Created by [HG] at [2019.10.31]
    /// Valida se a string é um format de Json válido
    /// https://stackoverflow.com/questions/14977848/how-to-make-sure-that-string-is-valid-json-using-json-net
    /// </summary>
    /// <param name="strInput"></param>
    /// <returns></returns>
    public static class JsonValidation
    {
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = Newtonsoft.Json.Linq.JToken.Parse(strInput);
                    return true;
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    return false;
                }
                catch (Exception) //some other exception
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}