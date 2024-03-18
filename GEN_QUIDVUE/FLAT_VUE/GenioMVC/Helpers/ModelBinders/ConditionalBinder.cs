using GenioMVC.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.ModelBinders
{
	public class ConditionalBinder : PropertyBinderAttribute
	{
		public override bool BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			if (propertyDescriptor.PropertyType == typeof(double))
			{
				if (bindingContext.ValueProvider.GetValue(propertyDescriptor.Name) == null)
					return false;

				string value = bindingContext.ValueProvider.GetValue(propertyDescriptor.Name).AttemptedValue.ToString();

				if (value == "1")
					propertyDescriptor.SetValue(bindingContext.Model, 1.0);
				else if (value == "0")
					propertyDescriptor.SetValue(bindingContext.Model, 0.0);
				else
				{ // OLD ...
					bool result;
					Boolean.TryParse(value, out result);

					propertyDescriptor.SetValue(bindingContext.Model,
						result ? 1.0 : 0.0);
				}

				return true;
			}

			return false;
		}

		public override void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.AdditionalValues["ConditionalBinder"] = true;
		}
	}
}
