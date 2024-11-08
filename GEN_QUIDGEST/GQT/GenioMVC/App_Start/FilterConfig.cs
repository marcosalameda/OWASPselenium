using System.Web.Mvc;

namespace GenioMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {		
            // Module Treatment
            filters.Add(new GenioMVC.MvcApplication.ModuleFilterAttribute());
            // Global Security Headers that have to be added programatically
            // (headers that are added through web.config are not possible to disable for certain actions)
            filters.Add(new AddHeaderAttribute("X-Frame-Options", "DENY"));
        }
    }
    
    public class AddHeaderAttribute : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Remove existing header with the same name (if it exists)
            context.HttpContext.Response.Headers.Remove(_name);

            context.HttpContext.Response.Headers.Add(_name, _value);
            base.OnResultExecuting(context);
        }
    }
}
