using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Attributes
{
	public class DynamicJsonAttribute : CustomModelBinderAttribute
	{
		public override IModelBinder GetBinder()
		{
			return new ModelBinders.DynamicJsonModelBinder(MatchName);
		}

		public bool MatchName { get; set; }
	}
}
