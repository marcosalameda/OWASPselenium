using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSGenio.core.ai
{
    public interface IChatbotService
    {
        /// <summary>
        /// Sends a request to the chatbot service with specified path, method and optional content
        /// </summary>
        Task<string> SendChatbotRequestAsync(string path, HttpMethod method, Stream content);
        Task<string> SendChatbotRequestAsync(HttpRequestMessage request);

        /// <summary>
        /// Gets a stream response from the chatbot service
        /// </summary>
        Task<Stream> GetChatbotStreamAsync(Stream requestData);
		
        /// <summary>
        /// Makes a function call to the chatbot service and returns the result of type T
        /// </summary>
        Task<T> CallChatbotFunctionAsync<T>(object requestData);

        /// <summary>
        /// TODO
        /// </summary>
        Task<HttpRequestMessage> BuildRequest(string path, HttpMethod method, Stream content);
    }
}