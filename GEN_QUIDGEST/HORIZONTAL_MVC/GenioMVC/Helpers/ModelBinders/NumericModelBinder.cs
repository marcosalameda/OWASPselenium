using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.ModelBinders
{
	public class NumericModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState { Value = valueResult };
			object actualValue = null;

			bool isNullValue = (valueResult == null || string.IsNullOrEmpty(valueResult.AttemptedValue));

			Type modelType = bindingContext.ModelType;

			if (isNullValue && (modelType == typeof(decimal?) || modelType == typeof(double?) || modelType == typeof(int?)))
				return actualValue;
			else if (isNullValue)
				return 0;

			bool isAjaxRequest = controllerContext.HttpContext.Request.IsAjaxRequest();
			// MH - No caso de ser um pedido ajax, os numericos ficam (e devem) enviados com "." no separador dos decimais.
			CultureInfo formatCulture = isAjaxRequest ? GetJSNumericCulture() : HtmlHelpers.GetNumericCulture();

			string attemptedValue = null;
			if (valueResult.RawValue.GetType().IsArray)
				attemptedValue = Convert.ToString(((string[])valueResult.RawValue)[0], CultureInfo.InvariantCulture);
			else
				attemptedValue = Convert.ToString(valueResult.RawValue, CultureInfo.InvariantCulture);

			try
			{
				if (modelType == typeof(decimal?) || modelType == typeof(decimal))
				{
					decimal tempout;
					Decimal.TryParse(attemptedValue, NumberStyles.Number, formatCulture, out tempout);
					actualValue = tempout;
				}
				else if (modelType == typeof(double?) || modelType == typeof(double))
				{
					double tempout;
					Double.TryParse(attemptedValue, NumberStyles.Number, formatCulture, out tempout);
					actualValue = tempout;
				}
				else if (modelType == typeof(int?) || modelType == typeof(int))
					actualValue = Int32.Parse(attemptedValue, NumberStyles.Number, formatCulture);
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}

			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}

		private static CultureInfo GetJSNumericCulture()
		{
			var ci = (CultureInfo)CultureInfo.InvariantCulture.Clone();

			ci.NumberFormat.NumberDecimalSeparator = ".";
			ci.NumberFormat.NumberGroupSeparator = "";
			ci.NumberFormat.CurrencyDecimalSeparator = ".";
			ci.NumberFormat.CurrencyGroupSeparator = "";

			return ci;
		}
	}
}
