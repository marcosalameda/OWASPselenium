using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.ModelBinders
{
	public class DateModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState { Value = valueResult };
			object actualValue = null;

			if (valueResult == null || String.IsNullOrEmpty(valueResult.AttemptedValue))
				return actualValue;

			try
			{
				actualValue = DateTime.Parse(valueResult.AttemptedValue, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}

			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}
	}
}
