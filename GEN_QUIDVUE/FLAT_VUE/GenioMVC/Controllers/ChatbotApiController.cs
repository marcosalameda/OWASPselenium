using Newtonsoft.Json;
using System.Text;

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
            return await _chatbotService.SendChatbotRequestAsync(HttpContext.Request.RouteValues["values"]?.ToString(), new HttpMethod(HttpContext.Request.Method), HttpContext.Request.Body);
        }

        public async Task ChatbotApiStreamProxy()
        {
            var stream = await _chatbotService.GetChatbotStreamAsync(HttpContext.Request.Body);
            Response.ContentType = "text/event-stream";

            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var chunk = await reader.ReadLineAsync();
                    if (!string.IsNullOrEmpty(chunk))
                    {
                        await Response.WriteAsync(chunk);
                        await Response.Body.FlushAsync();
                    }
                }
            }
        }

        public async Task<string> ChatbotApiAuth()
        {
            var request = await _chatbotService.BuildRequest("auth", new HttpMethod("POST"), HttpContext.Request.Body);
            var user = _userContextService.Current.User;

            var newContent = new {
                content = request.Content,
                userName = user.Name,
                ModuleRoles = user.GetModuleRoles(user.CurrentModule)
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(newContent), Encoding.UTF8, "application/json");
            return await _chatbotService.SendChatbotRequestAsync(request);
        }

        public async Task<T> ChatbotApiFunction<T>(StringContent content)
        {
            // Convert StringContent to object for the service call
            string jsonString = await content.ReadAsStringAsync();
            object requestData = JsonConvert.DeserializeObject(jsonString);
            return await _chatbotService.CallChatbotFunctionAsync<T>(requestData);
        }
    }
}
