using System;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using CSGenio.framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security;
using Newtonsoft.Json;

namespace GenioServer.framework
{
    public class ElasticsearchService
    {
        /// <summary>
        /// Content in http-header is application/json by default.
        /// </summary>
        const string content = "application/json";
        /// <summary>
        /// Content-Type in http-header for FSCrawler REST is application/json by default.
        /// </summary>
        const string contentFSCrawler = "multipart/form-data";
        public HttpWebRequest HttpRequest { get; internal set; }
        public HttpWebResponse HttpResponse { get; internal set; }

        /// <summary>
        /// Enumerator of the available methods for http requests
        /// </summary>
        private enum HttpMethod
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private readonly LoginElasticsearch loginElasticsearch = new LoginElasticsearch();
        private class LoginElasticsearch
        {
            public string Username { get; set; }
            public SecureString Password { get; set; }
        }


        public void SetLoginElasticsearch(string url, string index)
        {
            loginElasticsearch.Username = ElasticsearchAvailableIndexes.GetUsername(url, index);
            loginElasticsearch.Password = ElasticsearchAvailableIndexes.GetPassword(url, index);
        }

        /// <summary>
        /// ToDo:
        /// TO REVIEW: because the HTTPS site published on ISS must have a valid certificate!
        /// We basically override the native validation by this one and just return true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cert"></param>
        /// <param name="chain"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private static bool CustomValidation(object sender,
                    X509Certificate cert,
                    X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            return true;
        }

        /// <summary>
        /// Execute an http request
        /// </summary>
        /// <param name="URLfull">The address of the elasticsearch website/service</param>
        /// <param name="method">What kind of method is it done, { POS, PUT, GET, ... }</param>
        /// <param name="streamToWrite">The string/body that will be our request from the http request</param>
        /// <returns></returns>
        private async Task<string> ExecuteHttpRequest(string URLfull, HttpMethod method, string streamToWrite = null)
        {
            // As I published elasticsearch in IIS at https, when trying to connect it gave the following message:
            //  "underlying connection was closed: Could not establish trust relationship for SSL/TLS secure channel."
            // In order not to give this error when the security certificate of the website we are accessing fails, we override the native method that does this validation by override the "CustomValidation" method
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(CustomValidation);

            HttpRequest = (HttpWebRequest)WebRequest.Create(URLfull);

            if (loginElasticsearch != null && (!string.IsNullOrWhiteSpace(loginElasticsearch.Username) && loginElasticsearch.Password != null))
            {
                var credentials = new NetworkCredential(loginElasticsearch.Username, loginElasticsearch.Password);
                HttpRequest.Credentials = credentials;
            }
            HttpRequest.ContentType = content;
            HttpRequest.Method = method.ToString();

            string strResponseValue = string.Empty;
            try
            {
                if (streamToWrite != null)
                {
                    using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(streamToWrite);
                    }
                }
                using (HttpWebResponse response = (HttpWebResponse)HttpRequest.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        strResponseValue = response.StatusCode.ToString();
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    //Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    if (response != null)
                        using (Stream data = response.GetResponseStream())
                        {
                            return await Task.FromResult(new StreamReader(data).ReadToEnd());
                        }
                    else
                        return await Task.FromResult(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
            return await Task.FromResult(strResponseValue);
        }

        /// <summary>
        /// Execute an http request to FSCrawler<br></br>
        /// The purpose is to get the simulated json for indexing a document file
        /// </summary>
        /// <param name="url">The URL where the FSCrawler is running</param>
        /// <param name="filename">The full path for the file</param>
        /// <returns></returns>
        public static async Task<string> ExecuteHttpRequestFSCrawler(string url, string filename)
        {
            var request = WebRequest.CreateHttp(url);
            var boundary = $"{Guid.NewGuid():N}"; // boundary will separate each parameter
            request.ContentType = $"multipart/form-data; {nameof(boundary)}={boundary}";//Content-Type in http-header for FSCrawler REST is application/json
            request.Method = HttpMethod.POST.ToString();

            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {

                await writer.WriteAsync( // file header
                    $"\r\n--{boundary}\r\nContent-Disposition: " +
                    $"form-data; name=\"file\"; filename=\"{Path.GetFileName(filename)}\"\r\n" +
                    "Content-Type: application/octet-stream\r\n\r\n");
                await writer.FlushAsync();
                using (var fileStream = File.OpenRead(filename))
                    fileStream.CopyTo(requestStream);

                await writer.WriteAsync($"\r\n--{boundary}--\r\n");
            }
            string strResponseValue = string.Empty;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        strResponseValue = response.StatusCode.ToString();
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    if (response != null)
                        using (Stream data = response.GetResponseStream())
                        {
                            return await Task.FromResult(new StreamReader(data).ReadToEnd());
                        }
                    else
                        return await Task.FromResult(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
            return await Task.FromResult(strResponseValue);
        }

        /// <summary>
        /// Prepares a JSON document for Elasticsearch indexing by extracting file metadata and text content using FSCrawler.
        /// </summary>
        /// <param name="indexId">The unique identifier of the Elasticsearch index for which the document is to be prepared.</param>
        /// <param name="file">The file content for which metadata and text content are to be extracted.</param>
        /// <returns>A JSON string containing the structured data ready for indexing in Elasticsearch, or an error message if the operation cannot be performed.</returns>
        /// <remarks>
        /// This method utilizes the FSCrawler REST API to process a document and extract necessary metadata and textual content.
        /// The output is a JSON string that integrates seamlessly with additional data from other sources like a SQL Server database,
        /// creating a comprehensive JSON document for indexing. This method ensures that the document is correctly formatted and complete
        /// before it is submitted for indexing to Elasticsearch.
        /// </remarks>
        public async Task<string> PrepareDocumentForIndexing(string indexId, string file)
        {
            if (string.IsNullOrEmpty(indexId))
            {
                return "PrepareDocumentForIndexing: Index ID was not provided.";
            }

            var urlFSCrawler = ElasticsearchAvailableIndexes.GetURLFSCrawler(indexId);
            if (string.IsNullOrEmpty(urlFSCrawler))
            {
                return "PrepareDocumentForIndexing: Failed to retrieve the FSCrawler URL. The provided index ID may be invalid or not configured.";
            }

            return await ExecuteHttpRequestFSCrawler(string.Concat(urlFSCrawler, "/_upload?debug=true&simulate=true"), file);
        }

        /// <summary>
        /// Checks if an index exists on the Elasticsearch server. The HTTP status code in the response indicates the existence of the index.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index to check for existence.</param>
        /// <returns>A string containing the HTTP response body. A status code of 404 means the index does not exist, and 200 means it exists.</returns>
        /// <remarks>
        /// This method constructs the URL for the specified index and sends a GET request to check if the index exists.<br/>
        /// It is important to handle the HTTP response properly: a 404 status code indicates that the index does not exist,
        /// while a 200 status code indicates that it does. <br/>
        /// If the index ID is invalid or the URL cannot be constructed,
        /// an error message is returned.
        /// </remarks>
        public async Task<string> IndexExist(string indexId)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "IndexExist: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }
            return await ExecuteHttpRequest(indexUrl, HttpMethod.GET);
        }

        /// <summary>
        /// Deletes an entire index from the Elasticsearch server.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index to be deleted.</param>
        /// <returns>A string indicating the result of the operation or an error message if the index ID is invalid or the index cannot be deleted.</returns>
        /// <remarks>
        /// This method sends a DELETE request to the Elasticsearch server to remove an entire index specified by the 'indexId'.<br/>
        /// The deletion of an index will remove all documents and configurations associated with that index. <br/>
        /// It is important to ensure that the index ID is correct and that there are no dependencies on this index before performing this operation.<br/>
        /// If the index ID is invalid or the URL cannot be constructed, an error message is returned.
        /// </remarks>
        public async Task<string> DeleteIndex(string indexId)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "DeleteIndex: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }
            return await ExecuteHttpRequest(indexUrl, HttpMethod.DELETE);
        }

        /// <summary>
        /// Deletes a specific document from an Elasticsearch index.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index from which the document will be deleted.</param>
        /// <param name="documentId">The unique identifier of the document to be deleted.</param>
        /// <returns>A string indicating the result of the operation or an error message if the index ID or document ID is invalid.</returns>
        /// <remarks>
        /// This method sends a DELETE request to the Elasticsearch server to remove a specific document identified by 'documentId'
        /// from the specified index identified by 'indexId'.<br/>
        /// It constructs the URL for the operation using the index and document IDs.<br/>
        /// If the index ID is invalid or the URL cannot be constructed, an error message is returned. Ensure both IDs are valid before calling this method.
        /// </remarks>
        public async Task<string> DestroyDocument(string indexId, string documentId)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "DestroyDocument: Failed to construct the URL. The provided index ID or document ID may be invalid.";
            }
            string endpoint = string.Concat("/_doc/", documentId);
            return await ExecuteHttpRequest(string.Concat(indexUrl, endpoint), HttpMethod.DELETE);
        }

        /// <summary>
        /// Creates or updates settings and mappings for a specific Elasticsearch index.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index for which settings and mappings are to be defined.</param>
        /// <param name="mappingsWithSettings">The JSON string containing the mappings and settings for the index.</param>
        /// <returns>A string indicating the result of the operation or an error message if the index ID is invalid.</returns>
        /// <remarks>
        /// This method sends a PUT request to the Elasticsearch index URL constructed using the provided index ID.<br/>
        /// It is used to define or update the settings and mappings which dictate how documents are stored and indexed.<br/>
        /// If the index ID is invalid or the URL cannot be constructed, an error message is returned.
        /// </remarks>
        public async Task<string> CreateMappingsWithSettings(string indexId, string mappingsWithSettings)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "CreateMappingsWithSettings: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }
            return await ExecuteHttpRequest(indexUrl, HttpMethod.PUT, mappingsWithSettings);
        }

        /// <summary>
        /// Adds or updates a JSON document in the specified Elasticsearch index.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index where the document is to be indexed.</param>
        /// <param name="item">The JSON formatted string representing the document to be indexed.</param>
        /// <param name="documentId">The unique identifier for the document. If not provided, Elasticsearch will generate one automatically.</param>
        /// <returns>A string indicating the result of the operation or an error message if the index ID is invalid.</returns>
        /// <remarks>
        /// This method constructs the URL for the Elasticsearch index operation using the provided index ID and document ID.
        /// It sends a POST request to add or update the document in the specified index. If the index ID is invalid, 
        /// the method returns an error message and the operation is not performed.
        /// </remarks>
        public async Task<string> IndexDocument(string indexId, string item, string documentId)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "IndexDocument: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }

            // Endpoint to either add or update a document with a specified document ID.
            string endpoint = string.Concat("/_doc/", documentId);
            return await ExecuteHttpRequest(string.Concat(indexUrl, endpoint), HttpMethod.POST, item);
        }

        /// <summary>
        /// Adds or updates a bulk of JSON documents to the specified index based on the provided index ID.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index where documents are to be indexed.</param>
        /// <param name="item">The JSON formatted string representing the bulk of documents to be indexed.</param>
        /// <returns>A string message indicating the result of the operation.</returns>
        /// <remarks>
        /// This method constructs the URL for the Elasticsearch index operation using the given index ID.<br/>
        /// It then sends a POST request to the Elasticsearch '_bulk' endpoint to either add or update documents in bulk.<br/>
        /// If the index ID is not valid or the URL cannot be constructed, it returns an error message.
        /// </remarks>
        public async Task<string> IndexBulkDocuments(string indexId, string item)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "IndexBulkDocuments: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }
            return await ExecuteHttpRequest(string.Concat(indexUrl, "/_bulk"), HttpMethod.POST, item);
        }

        /// <summary>
        /// Validates the name of the index exist on string, removed from slashes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static bool IsIndexValid(string index) => !string.IsNullOrEmpty(index?.Trim('/'));

        /// <summary>
        /// Explicitly refreshes one or more indices in Elasticsearch, making all recent changes searchable.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index to refresh.</param>
        /// <returns>A string indicating the result of the operation or an error message if the index ID is invalid.</returns>
        /// <remarks>
        /// This method triggers the Elasticsearch refresh API for the specified index. <br/>
        /// Refreshing an index makes all operations performed since the last refresh available for search. <br/>
        /// While Elasticsearch is near real-time by nature, the refresh operation is necessary to explicitly make recent changes searchable. <br/>
        /// By default, Elasticsearch schedules refreshes periodically, but this method can be used to force a refresh at a specific moment.
        /// </remarks>
        public async Task<string> RefreshIndex(string indexId)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "RefreshIndex: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }
            return await ExecuteHttpRequest(string.Concat(indexUrl, "/_refresh"), HttpMethod.POST);
        }

        /// <summary>
        /// Searches an Elasticsearch index for the specified text.
        /// </summary>
        /// <param name="indexId">The unique identifier of the Elasticsearch index to search.</param>
        /// <param name="search">The text to search for within the index.</param>
        /// <returns>A string containing the results of the search operation.</returns>
        /// <remarks>
        /// This method constructs a URL for the specified index and sends a search request to the Elasticsearch '_search' endpoint.<br/>
        /// It expects a JSON-formatted search query in the 'search' parameter. If the index identifier is invalid or the index URL
        /// cannot be constructed, an error message is returned.
        /// </remarks>
        public async Task<string> RequestSearch(string indexId, string search)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "RequestSearch: The search type or the index definition is not loaded, or the index is no longer valid.";
            }
            return await ExecuteHttpRequest(string.Concat(indexUrl, "/_search"), HttpMethod.POST, search);
        }

        /// <summary>
        /// Builds the Elasticsearch URL for the specified index ID.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index for which to build the URL.</param>
        /// <returns>The fully constructed URL as a string, or null if the index is not valid or does not exist.</returns>
        /// <remarks>
        /// This method constructs a URL by retrieving the index name from the unique ID using ElasticsearchAvailableIndexes.GetIndexFromId.<br/>
        /// It then fetches the base URL for this index, sets the login credentials, and appends the index as a path to the URL.<br/>
        /// This URL is used for various Elasticsearch operations. The index is validated for correctness before constructing the URL.<br/>
        /// If the index derived from the ID is invalid, the method returns null.
        /// </remarks>
        private string BuildElasticsearchUrl(string indexId)
        {
            var indexName = ElasticsearchAvailableIndexes.GetIndexFromId(indexId);
            if (!IsIndexValid(indexName))
            {
                return null;
            }
            var url = ElasticsearchAvailableIndexes.GetURLFromIndexId(indexId);
            SetLoginElasticsearch(url, indexName);
            UriBuilder builder = new UriBuilder(url)
            {
                Path = indexName.ToLower()
            };
            return builder.Uri.ToString();
        }

        /// <summary>
        /// Create a global pipeline for ingesting files
        /// Although the pipeline is of global use in the elasticsearch instance, we have to know which index we are dealing with. Because we can use multiple instances of elasticsearch per index.
        /// NOTE: There is no need to check if the injest pipeline alredy exist, because it'll be recreated if it alredy exist and allways giving the response: "acknowledged": true
        /// </summary>
        /// <param name="injestPipeline"></param>
        /// <returns>String: with the result of request execution</returns>
        public async Task<string> CreateIngestPipeline(string indexId, List<Pipeline> injestPipeline)
        {
            List<string> response = new List<string>();
            if (injestPipeline.Count > 0)
            {
                // Get Elasticsearch version
                var clusterInfo = await ClusterInfo(indexId);
                string version = GetVersionNumberFromJson(clusterInfo);

                //Get pipeline version
                //var versionPipeline = (JObject)JObject.Parse(pipeline.Json)["Version"].Value<string>();

                foreach (var pipeline in injestPipeline)
                {
                    // Get our version of pipeline json document (version 1 = compability with versions before 8)
                    var versionPipeline = JObject.Parse(pipeline.Json)["version"].Value<string>();

                    // Compability version before 8 (remove_binary = true). Getting the first character of cersion string to get the main version for comparison
                    if (int.Parse(version[0].ToString()) < 8 && int.Parse(versionPipeline) > 1)
                    {
                        IngestPipelineBeforeVersion8(pipeline);
                    }

                    var indexUrl = BuildElasticsearchUrl(indexId);
                    if (indexUrl == null)
                    {
                        response.Add(string.Format("Injest Pipeline: O URL do index id {0} está vazio.", indexId));
                    }
                    string jsonRequest = string.Concat(indexUrl, "/_ingest/pipeline/", pipeline.Name);
                    response.Add(await ExecuteHttpRequest(jsonRequest, HttpMethod.PUT, pipeline.Json));
                }
            }
            else
            {
                response.Add(string.Format("Injest Pipeline: Foi feito um pedido para criar um pipeline para o URL do index id {0}. Mas a lista de pipelines a criar está vazia.", indexId));
            }
            return string.Join("\n", response.ToArray());
        }

        /// <summary>
        /// Before Elasticsearch v.8, to clear the binary data from the document we'd must explicitly remove data field
        /// After version 8, we simply need to add the property "remove_binary = true" to the pipeline
        /// </summary>
        /// <param name="pipeline"></param>
        private static void IngestPipelineBeforeVersion8(Pipeline pipeline)
        {
            JObject jo = JObject.Parse(pipeline.Json);
            foreach (var item in jo["processors"])
            {
                JObject jo2 = (JObject)item.SelectToken("foreach.processor.attachment");
                jo2.Property("remove_binary").Remove();
                pipeline.Json = jo.ToString();
            }
        }

        /// <summary>
        /// Retrieves public information about the Elasticsearch cluster associated with the specified index.
        /// </summary>
        /// <param name="indexId">The unique identifier of the index for which to retrieve cluster information.</param>
        /// <returns>A string containing the JSON-formatted public information of the Elasticsearch cluster, or an error message if the index ID is invalid.</returns>
        /// <remarks>
        /// This method constructs the URL for the specified index and sends a GET request to obtain information about the cluster where the index is stored.<br/>
        /// It provides insights such as cluster health, node information, and other metadata related to the cluster.<br/>
        /// This can be useful for monitoring and managing the Elasticsearch infrastructure.<br/>
        /// Ensure that the index ID provided is valid to prevent errors in fetching the information.
        /// </remarks>
        public async Task<string> ClusterInfo(string indexId)
        {
            var indexUrl = BuildElasticsearchUrl(indexId);
            if (indexUrl == null)
            {
                return "ClusterInfo: Failed to construct the URL. The provided index ID may be invalid or not configured.";
            }
            return await ExecuteHttpRequest(indexUrl, HttpMethod.GET);
        }

        /// <summary>
        /// Extracts the version number from a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string containing the version number in a specific format.</param>
        /// <returns>The version number as a string if found, or an error message if not.</returns>
        /// <remarks>
        /// The method parses the JSON string to find the version number. <br/>
        /// It expects the JSON to have a specific structure where the version number is located under a 'version' object and a 'number' field. <br/>
        /// If the JSON string is not in the expected format or the parsing fails, the error message from the exception is returned.
        /// </remarks>
        public string GetVersionNumberFromJson(string jsonString)
        {
            try
            {
                JObject jObject = JObject.Parse(jsonString);
                return jObject["version"]?["number"]?.Value<string>() ?? "Version number not found";
            }
            catch (JsonReaderException ex)
            {
                return $"Invalid JSON format: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }
    }
}
