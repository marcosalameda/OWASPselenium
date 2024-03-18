using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace GenioMVC.Helpers.ModelBinders
{
	public class DynamicJsonModelBinder : IModelBinder
	{
		private readonly bool matchName;

		public DynamicJsonModelBinder(bool matchName)
		{
			this.matchName = matchName;
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var contentType = controllerContext.HttpContext.Request.ContentType;
			if (!contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
				return null;

			string bodyText;
			using (var stream = controllerContext.HttpContext.Request.InputStream)
			{
				stream.Seek(0, SeekOrigin.Begin);
				using (var reader = new StreamReader(stream))
					bodyText = reader.ReadToEnd();
			}

			if (string.IsNullOrEmpty(bodyText))
				return null;

			var desiralized = Json.Decode(bodyText);
			if (!matchName)
				return desiralized;

			var members = desiralized.GetDynamicMemberNames() as IEnumerable<string>;
			return members == null
				|| members.Contains(bindingContext.ModelName)
				? desiralized[bindingContext.ModelName] : null;
		}
	}
}
