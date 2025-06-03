using System;
using System.Collections.Generic;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.IO;
using CSGenio.framework;
using System.Linq;
using GenioServer.framework;
using System.Threading.Tasks;
using System.Drawing;

namespace CSGenio.business
{

    public class ElasticsearchQueriesExtra
    {
        /// <summary>
        /// For a list of a given page of results, it will try to fetch the respective images from the catalog by the registry key.
        /// Use a specific folder of images for this purpose, to create them if they don't already exist, because we're going to cache the existing images.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sp"></param>
        /// <param name="area"></param>
        public static void ImagesValidation(List<string> ids, PersistentSupport sp, string area)
        {
            if (ids.Count > 0)
            {
                SelectQuery sql = null;
                switch (area.ToLower())
                {
                    default:
                        break;
                }

                if (sql == null)
                    return;

                string caminho = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "Content\\Elasticsearch\\img\\");
                string extension = ".png";

                DataMatrix values = sp.Execute(sql);

                for (int i = 0; i < values.NumRows; i++)
                {
                    Byte[] bytesFicheiro = null;
                    bytesFicheiro = values.GetBinary(i, 1);
                    int size = bytesFicheiro.Length;
                    string nomeFicheiro = string.Concat(caminho, values.GetKey(i, 0), extension);
                    if (size != 0)
                    {
                        if (!File.Exists(nomeFicheiro) == true)
                        {
                            try
                            {
                                FileStream file = File.Create(nomeFicheiro);
                                file.Write(bytesFicheiro, 0, bytesFicheiro.Length);
                                file.Close();
                            }
                            catch (Exception e)
                            {
                                string eMsg = e.Message;
                            }
                        }
                    }
                }
            }
        }

        public static void Use()
        {
            ElasticsearchQueries.RegisterMethodImagesValidation(ImagesValidation);
            ElasticsearchCreateOrUpdateExtra.Use();
        }
    }
	
	    public class ElasticsearchCreateOrUpdateExtra
    {
        private static int maxDocsDefault = 60;

        /// <summary>
        /// Completely recreates a specified index based on the provided ID, reindexing all relevant entries.
        /// </summary>
        /// <param name="id">The identifier of the index to be recreated.</param>
        /// <param name="sp">Persistent support needed for database operations.</param>
        /// <returns>A string resulting from the operation or a message indicating that no valid index was provided.</returns>
        public static async Task<string> ExecuteRecreateFullIndex(string id, PersistentSupport sp)
        {
            switch (id.ToLower())
            {
                case "dexittm":
                    return await Dexittm(id, "", sp);
                case "prepairs":
                    return await Prepairs(id, "", sp);
                case "reparaco":
                    return await Reparaco(id, "", sp);
                case "reparaso":
                    return await Reparaso(id, "", sp);
                case "tmlinem":
                    return await Tmlinem(id, "", sp);
                case "tmlinew":
                    return await Tmlinew(id, "", sp);
                case "tmliney":
                    return await Tmliney(id, "", sp);
                case "tmlleday":
                    return await Tmlleday(id, "", sp);
                case "visitas":
                    return await Visitas(id, "", sp);
                default:
                    throw new ArgumentException("Unrecognized index ID.");
            }
        }
		
        /// <summary>
        /// Executes a specific operation based on the area and provided code.
        /// </summary>
        /// <param name="area">The area to identify which IDs to operate on.</param>
        /// <param name="cod">The primary key of the record of the area table. If empty, it will go through the entire index</param>
        /// <param name="sp">A persistence support object needed for database operations.</param>
        /// <returns>A string result from the executed operation or an error message if no IDs are found.</returns>
        public static async Task<string> Execute(string area, string cod, PersistentSupport sp)
        {
            var listIds = ElasticsearchAvailableIndexes.GetIdsFromArea(area);
            if (listIds.Count == 0)
            {
                return $"Could not find any IDs for the specified area: {area}.";
            }
            else
            {
                string result = "";
                foreach (var id in listIds)
                {
                    switch (id.ToLower())
                    {
                        case "dexittm":
                            {
                                result = await Dexittm(id, cod, sp);
                            }
                            break;
                        case "prepairs":
                            {
                                result = await Prepairs(id, cod, sp);
                            }
                            break;
                        case "reparaco":
                            {
                                result = await Reparaco(id, cod, sp);
                            }
                            break;
                        case "reparaso":
                            {
                                result = await Reparaso(id, cod, sp);
                            }
                            break;
                        case "tmlinem":
                            {
                                result = await Tmlinem(id, cod, sp);
                            }
                            break;
                        case "tmlinew":
                            {
                                result = await Tmlinew(id, cod, sp);
                            }
                            break;
                        case "tmliney":
                            {
                                result = await Tmliney(id, cod, sp);
                            }
                            break;
                        case "tmlleday":
                            {
                                result = await Tmlleday(id, cod, sp);
                            }
                            break;
                        case "visitas":
                            {
                                result = await Visitas(id, cod, sp);
                            }
                            break;
                    }
                }
                return result;
            }
        }
	
	
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Dexittm(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsDexittm));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                          // Captures the links below for search ITEM
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                           jsonString += @"""coditem"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + @",";
                        jsonString += @"""itemdes"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemdes")) + @",";
                        jsonString += @"""itemcod"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemcod")) + @",";
                        jsonString += @"""date"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetDate(i, "item.date"));
  						//Tabelas acima
// Relationships below for ITEM table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Prepairs(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsPrepairs));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                             // Captures the links below for search REPAR
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "repar.codrepar")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                            jsonString += @"""codrepar"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "repar.codrepar")) + @",";
                        jsonString += @"""descript"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "repar.descript")) + @",";
                        jsonString += @"""nrrepara"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetInteger(i, "repar.nrrepara"));
     						//Tabelas acima
						jsonString += @","; //entre o main e tabelas acima
						//PESSO
						jsonString += @"""pessorepar"" : [";
						jsonString += @"{ ""name"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "pesso.name")) + @"}";
						jsonString += @"]";
                        jsonString += @","; //entre
						//SPECI
						jsonString += @"""specirepar"" : [";
						jsonString += @"{ ""especial"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "speci.especial")) + @"}";
						jsonString += @"]";
// Relationships below for REPAR table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Reparaco(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsReparaco));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                             // Captures the links below for search REPAR
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "repar.codrepar")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                            jsonString += @"""codrepar"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "repar.codrepar")) + @",";
                        jsonString += @"""nrrepara"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetInteger(i, "repar.nrrepara")) + @",";
                        jsonString += @"""descript"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "repar.descript"));
     						//Tabelas acima
						jsonString += @","; //entre o main e tabelas acima
						//PESSO
						jsonString += @"""pessorepar"" : [";
						jsonString += @"{ ""name"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "pesso.name")) + @"}";
						jsonString += @"]";
                        jsonString += @","; //entre
						//SPECI
						jsonString += @"""specirepar"" : [";
						jsonString += @"{ ""especial"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "speci.especial")) + @"}";
						jsonString += @"]";
// Relationships below for REPAR table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Reparaso(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsReparaso));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                             // Captures the links below for search REPAR
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "repar.codrepar")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                            jsonString += @"""codrepar"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "repar.codrepar")) + @",";
                        jsonString += @"""descript"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "repar.descript")) + @",";
                        jsonString += @"""nrrepara"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetInteger(i, "repar.nrrepara"));
     						//Tabelas acima
						jsonString += @","; //entre o main e tabelas acima
						//PESSO
						jsonString += @"""pessorepar"" : [";
						jsonString += @"{ ""name"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "pesso.name")) + @"}";
						jsonString += @"]";
                        jsonString += @","; //entre
						//SPECI
						jsonString += @"""specirepar"" : [";
						jsonString += @"{ ""especial"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "speci.especial")) + @"}";
						jsonString += @"]";
// Relationships below for REPAR table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Tmlinem(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsTmlinem));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                          // Captures the links below for search ITEM
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                           jsonString += @"""coditem"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + @",";
                        jsonString += @"""itemdes"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemdes")) + @",";
                        jsonString += @"""itemcod"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemcod")) + @",";
                        jsonString += @"""date"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetDate(i, "item.date"));
  						//Tabelas acima
// Relationships below for ITEM table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Tmlinew(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsTmlinew));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                          // Captures the links below for search ITEM
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                           jsonString += @"""coditem"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + @",";
                        jsonString += @"""itemdes"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemdes")) + @",";
                        jsonString += @"""itemcod"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemcod")) + @",";
                        jsonString += @"""date"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetDate(i, "item.date"));
  						//Tabelas acima
// Relationships below for ITEM table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Tmliney(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsTmliney));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                          // Captures the links below for search ITEM
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                           jsonString += @"""coditem"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + @",";
                        jsonString += @"""itemdes"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemdes")) + @",";
                        jsonString += @"""itemcod"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemcod")) + @",";
                        jsonString += @"""date"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetDate(i, "item.date"));
  						//Tabelas acima
// Relationships below for ITEM table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Tmlleday(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsTmlleday));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                          // Captures the links below for search ITEM
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                           jsonString += @"""coditem"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "item.coditem")) + @",";
                        jsonString += @"""itemdes"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemdes")) + @",";
                        jsonString += @"""itemcod"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "item.itemcod")) + @",";
                        jsonString += @"""date"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetDate(i, "item.date"));
  						//Tabelas acima
// Relationships below for ITEM table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }
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
        ///   "tituloova": "Star Trek: Gerações",
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
        private static async Task<string> Visitas(string id, string cod, PersistentSupport sp)
        {
            // Create an independent folder per user request. This will avoid conflicts between users who are saving the same records.
            // It will be used to save files to be read by fscrawler
            var tempFolderPathUnique = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + string.Format(@"{0}", Guid.NewGuid());
            try
            {
                // Create the unique directory for this user request
                System.IO.Directory.CreateDirectory(tempFolderPathUnique);

                string indexName = ElasticsearchAvailableIndexes.GetIndexFromId(id);
                if (string.IsNullOrWhiteSpace(indexName))
                {
                    return "ExecuteIndexDocument: Failed to get the index name. The provided index ID may be invalid or not configured.";
                }

                var elasticService = new ElasticsearchService();
                List<string> response = new List<string>();
                // Get the pipelines for this index
                var pipelines = ElasticsearchConfigurations.GetPipeline.Where(s => string.Equals(s.Index, indexName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (string.IsNullOrEmpty(cod))
                {
                    // Step 1/4 - If dealing with documents that need injestion pipelines, it will be created
                    response.Add(await elasticService.CreateIngestPipeline(id, pipelines));
                    // Step 2/4 - Delete the index
                    response.Add(await elasticService.DeleteIndex(id));
                    // Step 3/4 - Create a new index with the settings and mappings registered in our solution json files
                    response.Add(await elasticService.CreateMappingsWithSettings(id, ElasticsearchConfigurations.GetSettingsVisitas));
                }
                // Step 4/4 Insert JSon docs (the records on the db table are requested in Bulks of 100)
                List<string> bulkList = new List<string>();

                // Build the query for the main area with the relationships of the tables above
                SelectQuery queryMain = GetQueryMain(id, cod);

                BuildQueryMainWhere(id, cod, queryMain);

                // All the records from the main table
                DataMatrix matrix = sp.Execute(queryMain);
                string jsonString = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
                // Note: Maximum bulk size is 100, but when inserting bulk records with document content it gets timeout
                // and depends on the size of the content, because i got timeout having only two records in the bulk request
                int maxDocs = maxDocsDefault;
                int runningTotalDocs = maxDocs;

                ElasticsearchService els = new ElasticsearchService();

                // For each, get the rest of the information we want to index from the tables below, or N:M relationships
                if (matrix.NumRows > 0)
                {
                    for (int i = 0; i < matrix.NumRows; i++)
                    {
                         // Captures the links below for search VISIT
						string keyId = matrix.GetKey(i, 0);


                        sb.Clear();
                         string strPipeline = "";
                        //string commaSeparated = string.Join(",", pipelines.Select(item => item.ToString()));
                        //var numCountPipeline = 0;
                        //foreach (var pipeline in pipelines)
                        //{
                        //    if (numCountPipeline > 0) strPipeline += ",";
                        //    strPipeline += pipeline.Name;
                        //    numCountPipeline++;
                        //}
                        //Example: "{"index":{"_index":"waf","_type":"logs","_id":"325d05bb6900440e", "pipeline": "geoip-info"}}"
                        //if (!string.IsNullOrWhiteSpace(strPipeline))
                        //    strPipeline = string.Concat(", \"pipeline\": \"",strPipeline,"\"");

                        // metadata field used by elasticsearch. The document must have a unique identifier, elasticsearch generates an ID automatically if we do not define one in the _id field.
                        jsonString = @"{ ""index"":{ ""_id"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "visit.codvisit")) + strPipeline + @" } }";
                        sb.AppendLine(jsonString);
                        jsonString = @"{";
                          jsonString += @"""codvisit"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetKey(i, "visit.codvisit")) + @",";
                        jsonString += @"""title"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "visit.title")) + @",";
                        jsonString += @"""observat"" : " + Newtonsoft.Json.JsonConvert.ToString(matrix.GetString(i, "visit.observat"));
 						//Tabelas acima
// Relationships below for VISIT table

						// Below tables N:M

                        jsonString += @"}";
                        sb.AppendLine(jsonString);

                        bulkList.Add(sb.ToString());

                        maxDocs--;
                        if (maxDocs == 0)
                        {
                            response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));
                            bulkList.Clear();
                            maxDocs = 60;
                        }
                    }
                    // Request para bulk insert dos �ltimos
                    if (maxDocs > 0)
                        response.Add(await elasticService.IndexBulkDocuments(id, string.Join("", bulkList.ToArray())));

                    // refresh index
                    response.Add(await elasticService.RefreshIndex(id));

                    // do something with that info?
                    return string.Join("\n", response.ToArray());
                }
                else
                    return "";

            }
            catch (System.Exception e)
            {
                //ToDo
                string ex = e.Message;
                return "";
            }
            finally
            {
                try
                {
                    System.IO.Directory.Delete(tempFolderPathUnique, true);
                }
                catch (Exception e)
                {
                    //ToDo
                    string ex = e.Message;
                }
            }
        }

        private static void GetFSCrawlerValuesFromJson(string json)
        {

        }
		
        /// <summary>
        /// ATTENTION! When recording a record, this method is invoked and brings in the argument the primary key of the record to update the doc in elasticsearch, 
        /// if the cod argument is empty, it means that we are going to index THE WHOLE TABLE
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="queryMain"></param>
        private static void BuildQueryMainWhere(string id, string cod, SelectQuery queryMain)
        {
            switch (id.ToLower())
            {
			case "dexittm":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                    break;
			case "prepairs":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioArepar.FldCodrepar, cod));
                    break;
			case "reparaco":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioArepar.FldCodrepar, cod));
                    break;
			case "reparaso":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioArepar.FldCodrepar, cod));
                    break;
			case "tmlinem":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                    break;
			case "tmlinew":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                    break;
			case "tmliney":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                    break;
			case "tmlleday":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                    break;
			case "visitas":
                    if (!string.IsNullOrEmpty(cod))
                        queryMain.Where(CriteriaSet.And().Equal(CSGenioAvisit.FldCodvisit, cod));
                    break;
            }
        }

        /// <summary>
        /// Build the query related to the main area to indexing into elasticsearch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        private static SelectQuery GetQueryMain(string id, string cod)
        {
            try
            {
				SelectQuery queryMain = new SelectQuery();
                switch (id.ToLower())
                {
                    case "dexittm":
                        queryMain = new SelectQuery()
                                .Select(CSGenioAitem.FldCoditem)
                            .Select(CSGenioAitem.FldItemdes)
                            .Select(CSGenioAitem.FldItemcod)
                            .Select(CSGenioAitem.FldDate)
                              .From(Area.AreaITEM)
                            .Where(CriteriaSet.And().Equal(CSGenioAitem.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                        return queryMain;
                    case "prepairs":
                        queryMain = new SelectQuery()
                                 .Select(CSGenioArepar.FldCodrepar)
                            .Select(CSGenioArepar.FldDescript)
                            .Select(CSGenioArepar.FldNrrepara)
                                 .Select(CSGenioApesso.FldName)
                            .Select(CSGenioAspeci.FldEspecial)
                            .From(Area.AreaREPAR)
                             .Join(Area.AreaPESSO, TableJoinType.Left).On(CriteriaSet.And().Equal(CSGenioApesso.FldCodpesso, CSGenioArepar.FldCodpesso))
                             .Join(Area.AreaSPECI, TableJoinType.Left).On(CriteriaSet.And().Equal(CSGenioAspeci.FldCodespec, CSGenioArepar.FldCodespec))
                            .Where(CriteriaSet.And().Equal(CSGenioArepar.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioArepar.FldCodrepar, cod));
                        return queryMain;
                    case "reparaco":
                        queryMain = new SelectQuery()
                                 .Select(CSGenioArepar.FldCodrepar)
                            .Select(CSGenioArepar.FldNrrepara)
                            .Select(CSGenioArepar.FldDescript)
                                 .Select(CSGenioApesso.FldName)
                            .Select(CSGenioAspeci.FldEspecial)
                            .From(Area.AreaREPAR)
                             .Join(Area.AreaPESSO, TableJoinType.Left).On(CriteriaSet.And().Equal(CSGenioApesso.FldCodpesso, CSGenioArepar.FldCodpesso))
                             .Join(Area.AreaSPECI, TableJoinType.Left).On(CriteriaSet.And().Equal(CSGenioAspeci.FldCodespec, CSGenioArepar.FldCodespec))
                            .Where(CriteriaSet.And().Equal(CSGenioArepar.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioArepar.FldCodrepar, cod));
                        return queryMain;
                    case "reparaso":
                        queryMain = new SelectQuery()
                                 .Select(CSGenioArepar.FldCodrepar)
                            .Select(CSGenioArepar.FldDescript)
                            .Select(CSGenioArepar.FldNrrepara)
                                 .Select(CSGenioApesso.FldName)
                            .Select(CSGenioAspeci.FldEspecial)
                            .From(Area.AreaREPAR)
                             .Join(Area.AreaPESSO, TableJoinType.Left).On(CriteriaSet.And().Equal(CSGenioApesso.FldCodpesso, CSGenioArepar.FldCodpesso))
                             .Join(Area.AreaSPECI, TableJoinType.Left).On(CriteriaSet.And().Equal(CSGenioAspeci.FldCodespec, CSGenioArepar.FldCodespec))
                            .Where(CriteriaSet.And().Equal(CSGenioArepar.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioArepar.FldCodrepar, cod));
                        return queryMain;
                    case "tmlinem":
                        queryMain = new SelectQuery()
                                .Select(CSGenioAitem.FldCoditem)
                            .Select(CSGenioAitem.FldItemdes)
                            .Select(CSGenioAitem.FldItemcod)
                            .Select(CSGenioAitem.FldDate)
                              .From(Area.AreaITEM)
                            .Where(CriteriaSet.And().Equal(CSGenioAitem.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                        return queryMain;
                    case "tmlinew":
                        queryMain = new SelectQuery()
                                .Select(CSGenioAitem.FldCoditem)
                            .Select(CSGenioAitem.FldItemdes)
                            .Select(CSGenioAitem.FldItemcod)
                            .Select(CSGenioAitem.FldDate)
                              .From(Area.AreaITEM)
                            .Where(CriteriaSet.And().Equal(CSGenioAitem.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                        return queryMain;
                    case "tmliney":
                        queryMain = new SelectQuery()
                                .Select(CSGenioAitem.FldCoditem)
                            .Select(CSGenioAitem.FldItemdes)
                            .Select(CSGenioAitem.FldItemcod)
                            .Select(CSGenioAitem.FldDate)
                              .From(Area.AreaITEM)
                            .Where(CriteriaSet.And().Equal(CSGenioAitem.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                        return queryMain;
                    case "tmlleday":
                        queryMain = new SelectQuery()
                                .Select(CSGenioAitem.FldCoditem)
                            .Select(CSGenioAitem.FldItemdes)
                            .Select(CSGenioAitem.FldItemcod)
                            .Select(CSGenioAitem.FldDate)
                              .From(Area.AreaITEM)
                            .Where(CriteriaSet.And().Equal(CSGenioAitem.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioAitem.FldCoditem, cod));
                        return queryMain;
                    case "visitas":
                        queryMain = new SelectQuery()
                               .Select(CSGenioAvisit.FldCodvisit)
                            .Select(CSGenioAvisit.FldTitle)
                            .Select(CSGenioAvisit.FldObservat)
                             .From(Area.AreaVISIT)
                            .Where(CriteriaSet.And().Equal(CSGenioAvisit.FldZzstate, 0));
                        if (!string.IsNullOrEmpty(cod))
                            queryMain.Where(CriteriaSet.And().Equal(CSGenioAvisit.FldCodvisit, cod));
                        return queryMain;
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException(null, "ElasticSearch.GetQueryMain " + id, "Error getting main query: " + ex.Message, ex);
            }
        }

        public static void Use()
        {
            ElasticsearchCreateOrUpdate.RegisterMethodExecuteRecreateFullIndex(ExecuteRecreateFullIndex);
            ElasticsearchCreateOrUpdate.RegisterMethodExecute(Execute);
            ElasticsearchCreateOrUpdate.RegisterMethodDexittm(Dexittm);
            ElasticsearchCreateOrUpdate.RegisterMethodPrepairs(Prepairs);
            ElasticsearchCreateOrUpdate.RegisterMethodReparaco(Reparaco);
            ElasticsearchCreateOrUpdate.RegisterMethodReparaso(Reparaso);
            ElasticsearchCreateOrUpdate.RegisterMethodTmlinem(Tmlinem);
            ElasticsearchCreateOrUpdate.RegisterMethodTmlinew(Tmlinew);
            ElasticsearchCreateOrUpdate.RegisterMethodTmliney(Tmliney);
            ElasticsearchCreateOrUpdate.RegisterMethodTmlleday(Tmlleday);
            ElasticsearchCreateOrUpdate.RegisterMethodVisitas(Visitas);
            ElasticsearchCreateOrUpdate.RegisterMethodBuildQueryMainWhere(BuildQueryMainWhere);
            ElasticsearchCreateOrUpdate.RegisterMethodGetQueryMain(GetQueryMain);
        }
		
        /// <summary>
        /// To future developments. We could use tesseract directly to OCR image files or images in pdf or word documents
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static bool IsValidImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }

        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            // see http://www.mikekunz.com/image_file_header.html  
            var bmp = System.Text.Encoding.ASCII.GetBytes("BM");    // BMP
            var gif = System.Text.Encoding.ASCII.GetBytes("GIF");   // GIF
            var png = new byte[] { 137, 80, 78, 71 };               // PNG
            var tiff = new byte[] { 73, 73, 42 };                   // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                  // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };           // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };          // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
    }
}	
