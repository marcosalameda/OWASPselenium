using CSGenio.core.di;
using CSGenio.framework;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSGenio.core.ai
{
    // Core service for interacting with the Chatbot API. Ensures endpoints are correctly formatted and requests are securely sent.
    public class ChatbotService : IChatbotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _chatbotEndpointUrl;

        public ChatbotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _chatbotEndpointUrl = Configuration.APIEndpoint?.TrimEnd('/');
        }

        public ChatbotService()
        {
            _httpClient = GenioDI.HttpFactory.CreateClient();
            _chatbotEndpointUrl = Configuration.APIEndpoint?.TrimEnd('/');
        }

        // Constructs the full endpoint URL by appending the specified path.
        private string BuildEndpoint(string path)
        {
            if (string.IsNullOrEmpty(_chatbotEndpointUrl))
            {
                throw new InvalidOperationException("ChatbotEndpointUrl is not configured.");
            }

            string targetUrl = _chatbotEndpointUrl;
            if (!string.IsNullOrEmpty(path))
            {
                path = path.TrimStart('/');
                targetUrl = $"{_chatbotEndpointUrl}/{path}";
            }
            return targetUrl;
        }

        /// <summary>
        /// Sends a JSON-based HTTP request to the Chatbot API.
        /// </summary>
        /// <param name="path">The API endpoint path</param>
        /// <param name="method">The HTTP method to use</param>
        /// <param name="content">The request content as a stream</param>
        /// <returns>The response content as a string</returns>
        public async Task<string> SendChatbotRequestAsync(string path, HttpMethod method, Stream content)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(BuildEndpoint(path))
            };

            string jsonContent;

            using (StreamReader reader = new StreamReader(content))
                jsonContent = await reader.ReadToEndAsync();

            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpRequestMessage> BuildRequest(string path, HttpMethod method, Stream content){
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(BuildEndpoint(path))
            };

            string jsonContent;

            using (StreamReader reader = new StreamReader(content))
                jsonContent = await reader.ReadToEndAsync();

            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            return request;

        }

        public async Task<string> SendChatbotRequestAsync(HttpRequestMessage request){
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Sends a prompt to the Chatbot API and retrieves the response as a stream.
        /// </summary>
        /// <param name="requestData">The request data as a stream</param>
        /// <returns>The response stream from the API</returns>
        public async Task<Stream> GetChatbotStreamAsync(Stream requestData)
        {
            string jsonContent;
            using (StreamReader reader = new StreamReader(requestData))
                jsonContent = await reader.ReadToEndAsync();

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, BuildEndpoint("prompt/message"))
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Calls a specific function on the Chatbot API and deserializes the response.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response into</typeparam>
        /// <param name="requestData">The request data to send</param>
        /// <returns>The deserialized response data</returns>
        public async Task<T> CallChatbotFunctionAsync<T>(object requestData)
        {
            if (string.IsNullOrWhiteSpace(_chatbotEndpointUrl))
            {
                throw new InvalidOperationException("Chatbot endpoint URL is not configured. Please check the client configuration.");
            }

            var content = new StringContent(
                JsonConvert.SerializeObject(requestData),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_chatbotEndpointUrl}/function/json", content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                return apiResponse.Data;
            }
            catch (JsonException jsonEx)
            {
                throw new InvalidOperationException("Failed to deserialize the response from the chatbot.", jsonEx);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An unexpected error occurred while calling the chatbot function.", ex);
            }
        }

        // Represents the standard API response structure used by the Chatbot service.
        private class ApiResponse<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }
    }
}
