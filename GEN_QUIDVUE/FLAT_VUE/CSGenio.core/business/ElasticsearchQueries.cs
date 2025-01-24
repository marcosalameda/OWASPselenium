using System;
using System.Collections.Generic;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.IO;
using CSGenio.framework;
using System.Linq;
using GenioServer.framework;
using GenioServer.business;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace CSGenio.business
{

    /// <remarks>
    /// Created by [HG] at [2019.10.29]
    /// <br></br>
    /// Updated by [HG] at [2019.12.10]
    /// </remarks>
    /// <summary>
    /// <b>This class provides functionality for working with Elasticsearch indexes, including:</b><br></br>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Indexing new documents or updating existing ones
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Deleting documents from Elasticsearch, with a trigger method for handling deleted documents
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Searching for the corresponding index name using an ID
    /// </description>
    /// </item>
    /// </list>
    /// The class can be used to manage the indexing and deletion of documents in Elasticsearch, and to retrieve the index name associated with a specific ID.
    /// </summary>
    public static class ElasticsearchDocument
    {
        /// <summary>
        /// To index a new document or an already existing one
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doc"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        public static async Task<string> CreateOrUpdate(string id, string doc, string cod)
        {
            if (!String.IsNullOrEmpty(id))
                return await new ElasticsearchService().IndexDocument(id, doc, cod);
            else
                return "";
        }

        /// <summary>
        /// To delete a document from <c>Elasticsearch</c>.<br></br>
        /// If it has been deleted from the system, a method responsible for making this request is triggered.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        public static async Task<string> DestroyDocument(string id, string cod)
        {
            if (!String.IsNullOrEmpty(id))
                return await new ElasticsearchService().DestroyDocument(id, cod);
            else
                return "";
        }

        /// <summary>
        /// Given the id name it will search for the correspondent index name defined in configuration and return it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string GetIndexFromId(string id) => ElasticsearchAvailableIndexes.GetIndexFromId(id);
    }

    /// <remarks>
    /// Created by [HG] at [2019.10.29]
    /// <br></br>
    /// Updated by [HG] at [2022.05.18]
    /// </remarks>
    /// <summary>
    /// This class is responsible for preparing a set of values that will be used for the search request. Those values are:<br></br>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Which index will be used to perform the searches
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The text the user provided for search
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Page number, i.e. location of the group of records we want to see
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Number of records to be returned by elastic (it will be the size of a page)
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The field that is used for sorting the results
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// For example: the level of confidentiality of the collaborator associated with the user who does the research (this example works with manwin code)
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If it is a search without text, that is, everything, it will return the search for the top hits
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The user selected faceted list of group elements to be included in the search
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// All existing areas involved in this search
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    public class ElasticsearchPrepareSearch
    {
        public class SearchFilter
        {
            public string Name { get; set; }
            public bool Active { get; set; }
            public SearchFilterCondition[] Conditions { get; set; }
        }

        public class SearchFilterCondition
        {
            public string Name { get; set; }
            public bool Active { get; set; }
            public string Field { get; set; }
            public string Operator { get; set; }
            public string[] Values { get; set; }
            public Field FieldInfo { get; set; }
        }

        //readonly, they are defined in the class constructor
        private readonly SearchType tipoPesquisa;//which index will be used to perform the searches
        private readonly string searchText;//the text the user provided for search
        private readonly int pageNumber;//page number, i.e. location of the group of records we want to see
        private readonly int size;//number of records to be returned by elastic (it will be the size of a page)
        private readonly string sortField;//the field that is used for sorting the results
        private readonly ElasticsearchEPH ephs;//For example: the level of confidentiality of the collaborator associated with the user who does the research (this example works with manwin code)
        private readonly bool firstLook; //if it is a search without text, that is, everything, it will return the search for the top hits
        private readonly Dictionary<string, string> ArrayFacetList;//The user selected faceted list of group elements to be included in the search
        private readonly KeyValuePair<string, IndexTable> docConfig;//Contains all existing areas involved in this search
        private SearchFilter[] _searchFilters;
        private readonly bool allowOperators;

        /// <summary>
        /// Class constructor. This class is responsible for preparing a set of values that will be used for the search request.
        /// </summary>
        /// <param name="searchText">The text the user provided for search</param>
        /// <param name="pageNumber">Number of the page that we want to return within a total of pages found (works with pagination)</param>
        /// <param name="sortField">Sort field selected</param>
        /// <param name="docConfig">Contains all existing areas involved in this search</param>
        /// <param name="tipoPesquisa">What type of search, i.e. { "Works", "Authorities", "Subjects" }</param>
        /// <param name="ephs">EPH limitations for the user</param>
        /// <param name="arrayFacetList">List facet groups selected</param>
        /// <param name="size">Maximum number of lines (records/docs) per page</param>
        public ElasticsearchPrepareSearch(string searchText,
                                          int pageNumber,
                                          string sortField,
                                          KeyValuePair<string, IndexTable> docConfig,
                                          SearchType tipoPesquisa,
                                          ElasticsearchEPH ephs,
                                          Dictionary<string, string> arrayFacetList,
                                          int? size,
                                          bool allowOperators)
        {
            this.searchText = searchText;
            this.pageNumber = pageNumber;
            this.sortField = sortField;
            this.tipoPesquisa = tipoPesquisa;
            this.size = (int)size;
            this.ephs = ephs;
            this.ArrayFacetList = arrayFacetList;
            this.docConfig = docConfig;
            this.allowOperators = allowOperators;

            if (!allowOperators)
            {
                this.searchText = Sanitize.GetSanitized(this.searchText);
            }

            // Convert string to Json string
            //this.searchText = Newtonsoft.Json.JsonConvert.ToString(this.searchText);

            this.firstLook = string.IsNullOrEmpty(searchText) || searchText == "\"\"";
        }

        //expression bodies versus block bodies for methods. There is no difference because it is translated into IL in the same way.
        //but seem like a good practice due to a more compact and readable code.
        public string GetJsonQuery() => ElasticsearchQueries.GetQuerySearch_Generic(this);
        public SearchType GetTipoPesquisa() => tipoPesquisa;
        public string GetSearchText() => searchText;
        public int GetPageNumber() => pageNumber;
        public int GetSize() => size;
        public string GetSort() => sortField;
        public ElasticsearchEPH GetEPHs() => ephs;
        public bool IsFirstLook() => firstLook;
        public Dictionary<string, string> GetArrayFacetList() => ArrayFacetList;
        public KeyValuePair<string, IndexTable> GetDoc() => docConfig;
        public SearchFilter[] SearchFilters { get => _searchFilters; set => this._searchFilters = value; }
        public void SanitizeSearchFiltersValues()
        {
            foreach (var filter in _searchFilters)
            {
                foreach (var condition in filter.Conditions)
                {
                    for (int i = 0; i < condition.Values.Length; i++)
                    {
                        condition.Values[i] = Sanitize.GetSanitized(condition.Values[i]);
                        // Convert string to Json string
                        condition.Values[i] = Newtonsoft.Json.JsonConvert.ToString(condition.Values[i]);
                    }
                }
            }
        }
    }


    public class ElasticsearchQueries
    {
        public delegate void DelegateImagesValidation(List<string> ids, PersistentSupport sp, string area);
        private static DelegateImagesValidation m_ImagesValidation;
        public static void RegisterMethodImagesValidation(DelegateImagesValidation method) { m_ImagesValidation = method; }
        /// <summary>
        /// Para uma lista de uma determinada página de resultados, 
        /// vai tratar de ir buscar as imagens respectivas ao catálogo pela chave da obra.
        /// Vai usar uma pasta de imagens específica para o efeito, para as criar caso ainda não existam, 
        /// pois vamos usar com cache as imagens já existentes.
        ///     Definir um limite para o máximo de imagens a reter nesta pasta.
        ///     Se atinge o tal limite máximo, limpar as que já existem na mesma proporção para inserir as novas
        /// ******************************************************
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sp"></param>
        /// <param name="area"></param>
        public static void ImagesValidation(List<string> ids, PersistentSupport sp, string area)
        {
            m_ImagesValidation(ids, sp, area);
        }

        /// <summary>
        /// Devolve a lista numa string, com os campos separados por vírgula
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private static string MappingFields(string[] fields)
        {
            return "\"" + string.Join("\", \"", fields) + "\"";
        }

        private static JObject searchJson;

        /// <summary>
        /// Building the search query to send to Elasticsearch in Json string format
        /// </summary>
        /// <param name="pesquisa"></param>
        /// <returns>string: Json string. The search query to send to Elasticsearch</returns>
        public static string GetQuerySearch_Generic(ElasticsearchPrepareSearch pesquisa)
        {
            bool emptySearchText = pesquisa.GetSearchText() == "\"\"";
            bool haveSearchFilters = !(pesquisa.SearchFilters?.Any() ?? false);
            if (!emptySearchText || !haveSearchFilters) // if there is some text in the search textfield...
            {
                BuildHeader(pesquisa);
                BuildQuerySearch(pesquisa);
                BuildHighlight(pesquisa);
                BuildAggregations(pesquisa);
            }
            else
            {
                BuildEmptySearchMatchNone();
            }

            return searchJson.ToString(Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// The match none query may sound silly but is usefull in this case where we don't have nothing to search for but the search method was executed somehow
        /// </summary>
        private static void BuildEmptySearchMatchNone()
        {
            searchJson = new JObject
            {
                ["query"] = new JObject
                {
                    ["match_none"] = new JObject()
                }
            };
        }

        /// <summary>
        /// Determines if the given condition string contains complex syntax elements.
        /// Since query_string allows advanced query expressions, we can check for the presence of special characters that indicate complex syntax, such as operator keywords, parentheses, wildcards, etc.
        /// </summary>
        /// <param name="condition">The condition string to analyze.</param>
        /// <returns>True if the condition contains complex syntax elements, false otherwise.</returns>
        public static bool IsComplexSyntax(string condition)
        {
            string[] operatorKeywords = { "AND", "OR", "NOT" };
            string specialCharsPattern = @"[\+\-!()\{\}\[\]/\^""~*?:\\]";
            return Regex.IsMatch(condition, specialCharsPattern) || operatorKeywords.Any(keyword => condition.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) > -1);
        }

        /// <summary>
        /// Builds the query header for Elasticsearch search requests.
        /// </summary>
        /// <remarks>
        /// Returns a <c>JObject</c> with the search query header, including page number, page size, and sort field/order.
        /// </remarks>
        /// <param name="pesquisa">An <c>ElasticsearchPrepareSearch</c> object containing search request parameters.</param>
        /// <returns>A <c>JObject</c> containing the search query header.</returns>
        private static void BuildHeader(ElasticsearchPrepareSearch pesquisa)
        {
            int numberOfItems = 10; //default
            if (pesquisa.GetSize() > 0)
            {
                numberOfItems = pesquisa.GetSize();
                if (10000 - pesquisa.GetPageNumber() < pesquisa.GetSize()) //Elasticsearch: from + size must be less than or equal to: [10000]
                {
                    numberOfItems = 10000 - pesquisa.GetPageNumber();
                }
            }

            searchJson = new JObject
            {
                ["from"] = pesquisa.GetPageNumber(),
                ["size"] = numberOfItems
            };

            // if no sort is selected, the default will be _doc _score descending (more points first) whatever that is
            string sortField = pesquisa.GetSort();
            sortField = !string.IsNullOrEmpty(sortField) ? string.Concat(sortField, ".raw") : "_score";

            JObject sortJson = new JObject
            {
                [sortField] = new JObject
                {
                    ["order"] = "asc"
                }
            };

            searchJson["sort"] = new JArray(sortJson);
        }

        /// <summary>
        /// Builds the search query for Elasticsearch search requests.
        /// </summary>
        /// <remarks>
        /// Generates a query JSON object based on the specified search parameters, including input search text,<br></br>
        /// advanced filter conditions, nested field queries for document content, a special filter block <br></br>
        /// for a permanent history list, and faceted choice lists.
        /// </remarks>
        /// <param name="pesquisa">An <c>ElasticsearchPrepareSearch</c> object containing search request parameters.</param>
        private static void BuildQuerySearch(ElasticsearchPrepareSearch pesquisa)
        {
            var isNested = false;
            var fieldName = "";
            var attrIsNested = typeof(SearchType).GetField(pesquisa.GetTipoPesquisa().ToString()).GetCustomAttributes(typeof(ElasticsearchNestedAttribute), false);
            if (attrIsNested.Any())
            {
                isNested = ((ElasticsearchNestedAttribute)attrIsNested[0]).IsNested;
                fieldName = ((ElasticsearchNestedAttribute)attrIsNested[0]).FieldName;
            }

            //must means: (AND) Clauses that must match for the document to be included.
            //should means: (OR) If these clauses match, they increase the _score; otherwise, they have no effect. They are simply used to refine the relevance score for each document.

            //ATTENTION: If the user has clicked in a bucket, then we musta change from "should" to "must". Otherwise it will give all docs in the index having the term of the selected bucket.

            //This block of string are harcoded for now...
            string type_search = "query_string"; //match, multi_match, query_string, ...
            string customAnalyzer = "custom_analyzer_1"; //This is defined in the Json file that have the settings of the index
            string type_query = "most_fields"; //best_fields, most_fields, cross_fields, phrase, phrase_prefix, bool_prefix
            string default_operator = "AND"; //AND, OR

            string textToSearch = pesquisa.GetSearchText();

            JObject query = new JObject
            {
                    ["bool"] = new JObject()
            };

            // Start advanced search
            JArray advancedFilterConditions = new JArray();

            foreach (var searchFilter in pesquisa.SearchFilters ?? Enumerable.Empty<ElasticsearchPrepareSearch.SearchFilter>())
            {
                if (!searchFilter.Active || searchFilter.Conditions == null || searchFilter.Conditions.Length == 0)
                    continue;

                JArray shouldConditions = new JArray();

                foreach (var condition in searchFilter.Conditions)
                {
                    if (!condition.Active || string.IsNullOrEmpty(condition.Field) || string.IsNullOrEmpty(condition.Operator))
                        continue;

                    int idx = condition.Field.LastIndexOf('.');
                    if (idx != -1)
                    {
                        string table = condition.Field.Substring(0, idx);
                        string field = condition.Field.Substring(idx + 1);
                        var area = pesquisa.GetTipoPesquisa().ToString();
                        if (area.Equals(table, StringComparison.OrdinalIgnoreCase))
                            condition.Field = field;
                    }


                    if (condition.Operator.Equals("LIKE", StringComparison.OrdinalIgnoreCase))
                    {
                        var wildcardValue = $"*{condition.Values[0]}*";

                        JObject queryProperty = new JObject(
                            new JProperty("query_string", new JObject(
                                new JProperty("default_field", condition.Field),
                                new JProperty("query", wildcardValue)
                            ))
                        );

                        shouldConditions.Add(queryProperty);
                    }
                    else if (condition.Operator.Equals("STRTWTH", StringComparison.OrdinalIgnoreCase))
                    {
                        JObject matchPhrasePrefix = new JObject(
                            new JProperty("match_phrase_prefix", new JObject(
                                new JProperty(condition.Field, condition.Values[0])
                            ))
                        );

                        shouldConditions.Add(matchPhrasePrefix);
                    }
                    else if (condition.Operator.Equals("CON", StringComparison.OrdinalIgnoreCase))
                    {
                        // Handle contains operator
                        JObject match = new JObject(
                            new JProperty("match", new JObject(
                                new JProperty(condition.Field, new JObject(
                                    new JProperty("query", condition.Values[0])
                                ))
                            ))
                        );
                        shouldConditions.Add(match);
                    }
                    else if (condition.Operator.Equals("NOTCON", StringComparison.OrdinalIgnoreCase))
                    {
                        // Handle not contains operator
                        JObject match = new JObject(
                            new JProperty("match", new JObject(
                                new JProperty(condition.Field, new JObject(
                                    new JProperty("query", condition.Values[0])
                                ))
                            ))
                        );
                        shouldConditions.Add(match);
                    }
                    else if (condition.Operator.Equals("EQ", StringComparison.OrdinalIgnoreCase))
                    {
                        // Handle equal to operator
                        JObject termQuery = new JObject(new JProperty("term", new JObject(new JProperty(condition.Field, condition.Values[0]))));

                        JObject mustCondition = new JObject(
                            new JProperty("bool", new JObject(
                                new JProperty("must", new JArray(termQuery))
                            ))
                        );
                        shouldConditions.Add(mustCondition);
                    }
                    else if (condition.Operator.Equals("NOTEQ", StringComparison.OrdinalIgnoreCase))
                    {
                        // Handle not equal to operator
                        JObject termQuery = new JObject(new JProperty("term", new JObject(new JProperty(condition.Field, condition.Values[0]))));

                        JObject mustNotCondition = new JObject(
                            new JProperty("bool", new JObject(
                                new JProperty("must_not", new JArray(termQuery))
                            ))
                        );
                        shouldConditions.Add(mustNotCondition);
                    }
                    else if (condition.Operator.Equals("SET", StringComparison.OrdinalIgnoreCase))
                    {
                        // Handle is defined operator
                        JObject existsQuery = new JObject(new JProperty("exists", new JObject(new JProperty("field", condition.Field))));

                        JObject mustCondition = new JObject(
                            new JProperty("bool", new JObject(
                                new JProperty("must", new JArray(existsQuery))
                            ))
                        );
                        shouldConditions.Add(mustCondition);
                    }
                    else if (condition.Operator.Equals("NOTSET", StringComparison.OrdinalIgnoreCase))
                    {
                        // Handle not defined operator
                        JObject missingQuery = new JObject(new JProperty("exists", new JObject(new JProperty("field", condition.Field))));

                        JObject mustCondition = new JObject(
                            new JProperty("bool", new JObject(
                                new JProperty("must_not", new JArray(missingQuery))
                            ))
                        );
                        shouldConditions.Add(mustCondition);
                    }
                }

                if (shouldConditions.Count > 0)
                {
                    JObject shouldClause = new JObject
                    {
                        ["bool"] = new JObject
                        {
                            ["should"] = shouldConditions
                        }
                    };

                    advancedFilterConditions.Add(shouldClause);
                }
            }

            if (advancedFilterConditions.Count > 0)
            {
                ((JObject)query["bool"]).Add("must", advancedFilterConditions);
            }
            // End advanced search block

            // Start input search block
            List<string> fieldsMappings = GetFieldsMappings(pesquisa);

            if (fieldsMappings?.Count > 0)
            {
                switch (type_search)
                {
                    case "match":
                        break;
                    case "multi_match":
                        {
                            JObject queryProperty = new JObject(
                                new JProperty("multi_match", new JObject(
                                    new JProperty("query", textToSearch),
                                    new JProperty("type", type_query),
                                    new JProperty("analyzer", customAnalyzer),
                                    new JProperty("fields", new JArray(MappingFields(fieldsMappings.ToArray())))
                                ))
                            );
                            if (advancedFilterConditions.Count > 0)
                            {
                                ((JObject)query["bool"]["must"]).Add(queryProperty);
                            }
                            else
                            {
                                ((JObject)query["bool"]).Add("must", queryProperty);
                            }
                            break;
                        }
                    case "query_string":
                        {
                            JObject queryProperty = new JObject(
                                new JProperty("query_string", new JObject(
                                    new JProperty("query", textToSearch),
                                    new JProperty("analyzer", customAnalyzer),
                                    new JProperty("default_operator", default_operator),
                                    new JProperty("fields", new JArray(MappingFields(fieldsMappings.ToArray())))
                                ))
                            );
                            if (advancedFilterConditions.Count > 0)
                            {
                                ((JObject)query["bool"]["must"]).Add(queryProperty);
                            }
                            else
                            {
                                ((JObject)query["bool"]).Add("must", queryProperty);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            // End input search block

            // Start nested block for nested fields (in our case we developed this for file documents)
            if (isNested && !string.IsNullOrWhiteSpace(fieldName))
            {
                List<string> fieldsDocContentMappings = GetFieldsDocContentMappings(pesquisa);

                JObject nestedQuery = new JObject
                {
                    ["nested"] = new JObject
                    {
                        ["path"] = new JArray(fieldName),
                        ["query"] = new JObject
                        {
                            ["bool"] = new JObject
                            {
                                ["must"] = new JArray
                                {
                                    new JObject
                                    {
                                        ["query_string"] = new JObject
                                        {
                                            ["query"] = new JValue(textToSearch),
                                            ["type"] = type_query,
                                            ["analyzer"] = customAnalyzer,
                                            ["default_operator"] = default_operator,
                                            ["fields"] = new JArray(fieldsDocContentMappings.ToArray())
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                // Only suports ONE field in inner_hits and the number_of_fragments value are harcoded
                JObject inner_hits = new JObject
                {
                    ["_source"] = new JArray(),
                    ["highlight"] = new JObject
                    {
                        ["number_of_fragments"] = 20,
                        ["fragment_size"] = 200,
                        ["fields"] = new JObject
                        {
                            [fieldName + ".content"] = new JObject
                            {
                                ["pre_tags"] = new JArray("<b style=\"background-color: #FFFF00\">"),
                                ["post_tags"] = new JArray("</b>")
                            }
                        }
                    }
                };
                ((JObject)nestedQuery["nested"]).Add("inner_hits", inner_hits);

                ((JObject)query["bool"]).Add("should", nestedQuery);
                // If "minimum_should_match" were set to numEPHs, then all clauses would have to match, which would be more restrictive.
                // Why bool should is minimum_should_match is set to 1?
                //  A classical example is if we have a user who belongs to a higher level organic unit, he will be able to search and see documents from his organizational units below.
                //  Let's imagine that the user belongs to the code with primary key '00000000-0000-0000-0000-000000000001' and the level in the tree is "001.002".
                //  He must be able to see documents that are in the branches of the level below, that is, all from "001.002.(...)".
                //  So the filter would be:
                //      codunido": "00000000-0000-0000-0000-000000000001"
                //      level": "001.002"
                // But to include all branches below 001.002 we will have to have at least one of the conditions true by setting "minimum_should_match" to 1, the filter allows either of the two clauses to match
                ((JObject)query["bool"]).Add("minimum_should_match", 1);
            }

            // End nested block

            // Start filter block
            var customJsonFilter = pesquisa.GetEPHs().GetCustomJsonFilter();

            if (pesquisa.GetEPHs() != null && ((customJsonFilter != null && customJsonFilter.HasValues)
                || (pesquisa.GetEPHs().EphConditions.Count > 0 || pesquisa.GetEPHs().EphSubConditions.Count > 0)
                || (pesquisa.GetArrayFacetList() != null && pesquisa.GetArrayFacetList().Count > 0)))
            {
                JArray filter = new JArray();
                // Use the custom json if exists
                if (customJsonFilter != null && customJsonFilter.HasValues)
                {
                    filter.Add(customJsonFilter);
                }
                else
                {
                    string area = pesquisa.GetDoc().Value.Area;

                    // Distinct AreaEph for query bools or direct terms
                    var listAreasEphs = pesquisa.GetEPHs();

                    foreach (var areaEph in listAreasEphs.EphConditions)
                    {
                        var ephs = pesquisa.GetEPHs().EphConditions.Where(x => x.AreaEph == areaEph.AreaEph);
                        int numEPHs = ephs.Count();

                        JObject boolQuery = new JObject();

                        if (numEPHs > 1)
                        {
                            JArray shouldArray = new JArray();

                            foreach (var eph in ephs)
                            {
                                JObject subQuery = new JObject();

                                switch (eph.SearchOperator)
                                {
                                    case "L":
                                        subQuery["prefix"] = new JObject
                                        {
                                            { eph.GetFieldFullName(area), eph.Value }
                                        };
                                        break;
                                    case "=":
                                        subQuery["term"] = new JObject
                                        {
                                            { eph.GetFieldFullName(area), eph.Value }
                                        };
                                        break;
                                    case ">":
                                        subQuery["range"] = new JObject
                                        {
                                            {
                                                eph.GetFieldFullName(area), new JObject
                                                {
                                                    { "gt", eph.Value }
                                                }
                                            }
                                        };
                                        break;
                                    case ">=":
                                        subQuery["range"] = new JObject
                                        {
                                            {
                                                eph.GetFieldFullName(area), new JObject
                                                {
                                                    { "gte", eph.Value }
                                                }
                                            }
                                        };
                                        break;
                                    case "<":
                                        subQuery["range"] = new JObject
                                        {
                                            {
                                                eph.GetFieldFullName(area), new JObject
                                                {
                                                    { "lt", eph.Value }
                                                }
                                            }
                                        };
                                        break;
                                    case "<=":
                                        subQuery["range"] = new JObject
                                        {
                                            {
                                                eph.GetFieldFullName(area), new JObject
                                                {
                                                    { "lte", eph.Value }
                                                }
                                            }
                                        };
                                        break;
                                }

                                shouldArray.Add(subQuery);
                            }

                            boolQuery["bool"] = new JObject
                            {
                                { "should", shouldArray },
                                { "minimum_should_match", 1 }
                            };
                        }
                        filter.Add(boolQuery["bool"]);
                    }
                }





                var arrayFacetedList = pesquisa.GetArrayFacetList();

                if (arrayFacetedList != null && arrayFacetedList.Count > 0)
                {
                    foreach (KeyValuePair<string, string> entry in arrayFacetedList.Where(x => x.Key.ToLower().Contains("filterbetween")))
                    {
                        string strEntryKey = entry.Key.ToLower();
                        string strEntryVal = entry.Value;

                        // Check if is datetime to properly format to the request
                        DateTime dateTime;
                        bool isDateTime = DateTime.TryParse(entry.Value, out dateTime);
                        if (isDateTime)
                            strEntryVal = dateTime.ToString("yyyy-MM-ddTHH:mm:ss");
                        strEntryKey = strEntryKey.Replace("filterbetween", "");

                        var liststrEntryKey = strEntryKey.Split('_');
                        var strOperator = liststrEntryKey[0];
                        var strKey = liststrEntryKey[1];

                        if (!string.IsNullOrWhiteSpace(strEntryVal))
                        {
                            JObject rangeObject = new JObject
                            {
                                ["range"] = new JObject
                                {
                                    [strKey] = new JObject
                                    {
                                        [strOperator] = strEntryVal
                                    }
                                }
                            };
                            filter.Add(rangeObject);
                        }
                    }
                    foreach (KeyValuePair<string, string> entry in pesquisa.GetArrayFacetList().Where(x => x.Key.ToLower().Contains("filterbetween") == false))
                    {
                        string strEntryKey = entry.Key.ToLower();
                        string strEntryVal = entry.Value;

                        // Check if is datetime to properly format to the request
                        DateTime dateTime;
                        bool isDateTime = DateTime.TryParse(entry.Value, out dateTime);
                        if (isDateTime)
                            strEntryVal = dateTime.ToString("yyyy-MM-ddTHH:mm:ss");

                        JObject termObject = new JObject
                        {
                            ["term"] = new JObject
                            {
                                [strEntryKey] = strEntryVal
                            }
                        };
                        filter.Add(termObject);
                    }
                }

                ((JObject)query["bool"]).Add("filter", filter);
            }
            // End filter block

            searchJson["query"] = query;
        }

        private static List<string> GetFieldsMappings(ElasticsearchPrepareSearch pesquisa)
        {
            var fieldsMappings = new List<string>();

            // Getting the main Area to reject fields that are of type "attachment" or "fscrawler" that belong to other areas
            // because they are reserved for nested query fields
            var mainArea = pesquisa.GetDoc().Value.Area;
            foreach (var e in pesquisa.GetDoc().Value.Fields.Where(x => x.Searchcriteria == true && x.Type != "byte" && !((x.Type == "attachment" || x.Type == "fscrawler") && x.Area != mainArea))) // cannot perform search on byte fields
            {
                if ((e.Type == "attachment" || e.Type == "fscrawler") && e.Area != mainArea)
                {
                    //if (e.Type == "attachment")
                    //{
                    //    fieldsMappings.Add(e.GetAttachmentNameField(pesquisa.GetDoc().Value.Area));
                    //}
                    //else if (e.Type == "fscrawler")
                    //{
                    //    fieldsMappings.Add(e.GetFSCrawlerRestNameField(pesquisa.GetDoc().Value.Area));
                    //}
                }
                else
                {
                    fieldsMappings.Add(e.GetNameField(pesquisa.GetDoc().Value.Area));
                }
            }

            return fieldsMappings;
        }

        private static List<string> GetFieldsDocContentMappings(ElasticsearchPrepareSearch pesquisa)
        {
            var fieldsMappings = new List<string>();
            foreach (var e in pesquisa.GetDoc().Value.Fields.Where(x => x.Searchcriteria == true && x.Type != "byte" && (x.Type == "attachment" || x.Type == "fscrawler"))) // cannot perform search on byte fields
            {
                if (e.Type == "attachment")
                {
                    fieldsMappings.Add(e.GetAttachmentNameField(pesquisa.GetDoc().Value.Area));
                }
                else if (e.Type == "fscrawler")
                {
                    fieldsMappings.Add(e.GetFSCrawlerRestNameField(pesquisa.GetDoc().Value.Area));
                }
            }

            return fieldsMappings;
        }

        private static void BuildHighlight(ElasticsearchPrepareSearch pesquisa)
        {
            var highlightedFields = pesquisa.GetDoc().Value.Fields.Where(x => x.Highlight == true).ToArray();
            if (highlightedFields.Length > 0)
            {
                var highlightSection = new JObject
                {
                    ["number_of_fragments"] = 3,
                    ["fields"] = new JObject()
                };

                foreach (var entry in highlightedFields)
                {
                    if (entry.Type == "attachment")
                    {
                        ((JObject)highlightSection["fields"]).Add(entry.GetAttachmentNameToHighlight(pesquisa.GetDoc().Value.Area), new JObject
                        {
                            ["pre_tags"] = new JArray("<b style=\"background-color: #FFFF00\">"),
                            ["post_tags"] = new JArray("</b>")
                        });
                    }
                    else
                    {
                        ((JObject)highlightSection["fields"]).Add(entry.GetNameToHighlight(pesquisa.GetDoc().Value.Area), new JObject
                        {
                            ["pre_tags"] = new JArray("<b style=\"background-color: #FFFF00\">"),
                            ["post_tags"] = new JArray("</b>")
                        });
                    }
                }

                searchJson["highlight"] = highlightSection;
            }
        }

        private static void BuildAggregations(ElasticsearchPrepareSearch pesquisa)
        {
            var aggsFields = pesquisa.GetDoc().Value.Fields.Where(x => !string.IsNullOrEmpty(x.Aggfield)).ToArray();
            if (aggsFields.Length > 0)
            {
                var aggsSection = new JObject();

                foreach (var entry in aggsFields)
                {
                    var sources = new JArray
                    {
                        new JObject
                        {
                            [entry.Aggfield] = new JObject
                            {
                                ["terms"] = new JObject
                                {
                                    ["field"] = entry.Aggfield
                                }
                            }
                        }
                    };

                    aggsSection[entry.Aggname] = new JObject
                    {
                        [entry.Aggtype] = new JObject
                        {
                            ["size"] = entry.Maximum,
                            ["sources"] = sources
                        }
                    };
                }

                searchJson["aggs"] = aggsSection;
            }
        }
    }
	
    public class ElasticsearchCreateOrUpdate	
    {
        public delegate Task<string> DelegateExecuteRecreateFullIndex(string id, PersistentSupport sp);
        private static DelegateExecuteRecreateFullIndex m_ExecuteRecreateFullIndex;
        public static void RegisterMethodExecuteRecreateFullIndex(DelegateExecuteRecreateFullIndex method) { m_ExecuteRecreateFullIndex = method; }
        public async Task<string> ExecuteRecreateFullIndex(string id, PersistentSupport sp)
        {
            return await m_ExecuteRecreateFullIndex(id, sp);
        }

        public delegate Task<string> DelegateExecute(string area, string cod, PersistentSupport sp);
        private static DelegateExecute m_Execute;
        public static void RegisterMethodExecute(DelegateExecute method) { m_Execute = method; }
        public async Task<string> Execute(string area, string cod, PersistentSupport sp)
        {
            return await m_Execute(area, cod, sp);
        }
	
        public delegate Task<string> DelegateDexittm(string id, string cod, PersistentSupport sp);
        private static DelegateDexittm m_Dexittm;
        public static void RegisterMethodDexittm(DelegateDexittm method) { m_Dexittm = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Dexittm(string id, string cod, PersistentSupport sp)
        {
            return await m_Dexittm(id, cod, sp);
        }
        public delegate Task<string> DelegatePrepairs(string id, string cod, PersistentSupport sp);
        private static DelegatePrepairs m_Prepairs;
        public static void RegisterMethodPrepairs(DelegatePrepairs method) { m_Prepairs = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Prepairs(string id, string cod, PersistentSupport sp)
        {
            return await m_Prepairs(id, cod, sp);
        }
        public delegate Task<string> DelegateReparaco(string id, string cod, PersistentSupport sp);
        private static DelegateReparaco m_Reparaco;
        public static void RegisterMethodReparaco(DelegateReparaco method) { m_Reparaco = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Reparaco(string id, string cod, PersistentSupport sp)
        {
            return await m_Reparaco(id, cod, sp);
        }
        public delegate Task<string> DelegateReparaso(string id, string cod, PersistentSupport sp);
        private static DelegateReparaso m_Reparaso;
        public static void RegisterMethodReparaso(DelegateReparaso method) { m_Reparaso = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Reparaso(string id, string cod, PersistentSupport sp)
        {
            return await m_Reparaso(id, cod, sp);
        }
        public delegate Task<string> DelegateTmlinem(string id, string cod, PersistentSupport sp);
        private static DelegateTmlinem m_Tmlinem;
        public static void RegisterMethodTmlinem(DelegateTmlinem method) { m_Tmlinem = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Tmlinem(string id, string cod, PersistentSupport sp)
        {
            return await m_Tmlinem(id, cod, sp);
        }
        public delegate Task<string> DelegateTmlinew(string id, string cod, PersistentSupport sp);
        private static DelegateTmlinew m_Tmlinew;
        public static void RegisterMethodTmlinew(DelegateTmlinew method) { m_Tmlinew = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Tmlinew(string id, string cod, PersistentSupport sp)
        {
            return await m_Tmlinew(id, cod, sp);
        }
        public delegate Task<string> DelegateTmliney(string id, string cod, PersistentSupport sp);
        private static DelegateTmliney m_Tmliney;
        public static void RegisterMethodTmliney(DelegateTmliney method) { m_Tmliney = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Tmliney(string id, string cod, PersistentSupport sp)
        {
            return await m_Tmliney(id, cod, sp);
        }
        public delegate Task<string> DelegateTmlleday(string id, string cod, PersistentSupport sp);
        private static DelegateTmlleday m_Tmlleday;
        public static void RegisterMethodTmlleday(DelegateTmlleday method) { m_Tmlleday = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Tmlleday(string id, string cod, PersistentSupport sp)
        {
            return await m_Tmlleday(id, cod, sp);
        }
        public delegate Task<string> DelegateVisitas(string id, string cod, PersistentSupport sp);
        private static DelegateVisitas m_Visitas;
        public static void RegisterMethodVisitas(DelegateVisitas method) { m_Visitas = method; }

        /// <summary>
        /// Indexes a specific record or the entire catalog in Elasticsearch.
        /// If the 'cod' parameter is empty, it indexes the entire catalog; otherwise, it updates the specific document with the provided primary key.
        /// </summary>
        /// <param name="id">Identifier of the index in Elasticsearch.</param>
        /// <param name="cod">Primary key of the record to be indexed. If empty, the entire catalog is indexed.</param>
        /// <param name="sp">Persistent support used for database operations.</param>
        /// <returns>String with the result of the operation, containing possible error messages or confirmation.</returns>
        /// <remarks>
        /// Created by [HG] at [2019.10.31]<br/>
        /// Last update by [HG] at [2020.04.21]<br/>
        /// The function makes HTTP API calls to Elasticsearch to insert or update records.<br/>
        /// Example of a created JSON document for insertion:
        /// <code>
        /// { "index": { "_id": "95c9019c-8ddc-4535-ba87-008f6a0382ef" } }
        /// { "codobra": "95c9019c-8ddc-4535-ba87-008f6a0382ef",
        ///   "dominio": { "designac": "Imagens em movimento", "sigla": "IM" },
        ///   "tipob": "Filme",
        ///   "titulo": "Star Trek: Generations",
        ///   "tituloova": "Star Trek: Gera??es",
        ///   "autores": [
        ///     { "codautor": "5a9a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "patrick stewart", ... },
        ///     { "codautor": "987a78a8-0c4e-42b2-9461-1559e5b0d192", "nome": "william shatner", ... }
        ///   ],
        ///   "paises": [{ "iso_3166_1": "US", "nome": "United States of America" }],
        ///   "idiomas": [{ "isocod": "PT", "designac": "Portugal" }],
        ///   ...
        /// }
        /// </code>
        /// Operations are asynchronous and can return multiple result messages, depending on the number of records processed.
        /// </remarks>
        public async Task<string> Visitas(string id, string cod, PersistentSupport sp)
        {
            return await m_Visitas(id, cod, sp);
        }

        public delegate void DelegateBuildQueryMainWhere(string id, string cod, SelectQuery queryMain);
        private static DelegateBuildQueryMainWhere m_BuildQueryMainWhere;
        public static void RegisterMethodBuildQueryMainWhere(DelegateBuildQueryMainWhere method) { m_BuildQueryMainWhere = method; }
        private static void BuildQueryMainWhere(string id, string cod, SelectQuery queryMain)
        {
            m_BuildQueryMainWhere(id, cod, queryMain);
        }

        public delegate SelectQuery DelegateGetQueryMain(string id, string cod);
        private static DelegateGetQueryMain m_GetQueryMain;
        public static void RegisterMethodGetQueryMain(DelegateGetQueryMain method) { m_GetQueryMain = method; }
        /// <summary>
        /// Build the query related to the main area to indexing into elasticsearch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        private static SelectQuery GetQueryMain(string id, string cod)
        {
            return m_GetQueryMain(id, cod);
        }
    }
}	
