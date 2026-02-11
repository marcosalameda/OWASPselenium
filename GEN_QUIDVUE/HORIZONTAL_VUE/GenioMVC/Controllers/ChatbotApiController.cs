using Newtonsoft.Json;
using System.Text;
using System;

using CSGenio.core.ai;
using GenioMVC.Models.Navigation;

namespace GenioMVC.Controllers
{
    public class ChatbotApiController : ControllerBase
    {
        private readonly IChatbotService _chatbotService;
        private readonly IUserContextService _userContextService;

        public ChatbotApiController(IChatbotService chatbotService, IUserContextService userContextService) : base(userContextService)
        {
            _chatbotService = chatbotService;
            _userContextService = userContextService;
        }

        public async Task<string> ChatbotApiProxy()
        {
            var path = HttpContext.Request.Path.Value!.Substring("/chatbotapi/".Length);

            return await _chatbotService.SendChatbotRequestAsync(path, new HttpMethod(HttpContext.Request.Method), HttpContext.Request.Body, UserContext.Current.User);
        }


        public async Task ChatbotApiStreamProxy()
        {
            Stream stream;

            // If it's a structured prompt, it likely comes as raw JSON body (not multipart/form)
            var contentType = Request.ContentType ?? "";            

            if (contentType.Contains("application/json", StringComparison.OrdinalIgnoreCase))
            {
                stream = await _chatbotService.GetChatbotStreamAsync(Request.Body, UserContext.Current.User);
            }
            else if (contentType.Contains("multipart/form-data", StringComparison.OrdinalIgnoreCase))
            {
                stream = await GetFormDataStreamAsync();
            }
            else
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Unsupported content type.");
                return;
            }

            Response.ContentType = "text/event-stream";
            Response.Headers.Append("Cache-Control", "no-cache");
            Response.Headers.Append("Connection", "keep-alive");

            using var reader = new StreamReader(stream);
            char[] buffer = new char[1024];
            int bytesRead;
            var sb = new StringBuilder();

            while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                sb.Append(buffer, 0, bytesRead);
                var text = sb.ToString();
                int index;

                while ((index = text.IndexOf("\n\n", StringComparison.Ordinal)) >= 0)
                {
                    var eventText = text[..(index + 2)];
                    await Response.WriteAsync(eventText);
                    await Response.Body.FlushAsync();
                    text = text[(index + 2)..];
                }
                sb.Clear();
                sb.Append(text);
            }
        }

        [Obsolete]
        public async Task<T> ChatbotApiFunction<T>(StringContent content)
        {
            // Convert StringContent to object for the service call
            string jsonString = await content.ReadAsStringAsync();
            object requestData = JsonConvert.DeserializeObject(jsonString);
            return await _chatbotService.CallChatbotFunctionAsync<T>(requestData);
        }

        private async Task<Stream> GetFormDataStreamAsync()
        {
            var form = await Request.ReadFormAsync();

            var formFields = form
                .SelectMany(f => f.Value.Select(val => new KeyValuePair<string, string>(f.Key, val)));

            var formFiles = form.Files.Select(file => (file.Name, file.ContentType, file.OpenReadStream()));

            return await _chatbotService.GetChatbotStreamAsync(formFields, formFiles, UserContext.Current.User);
        }
    }
}
