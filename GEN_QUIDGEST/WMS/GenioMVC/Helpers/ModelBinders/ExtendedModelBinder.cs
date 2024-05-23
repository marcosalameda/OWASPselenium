using GenioMVC.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.ModelBinders
{
	public class ExtendedModelBinder : DefaultModelBinder
	{
		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			var propBindAttr = propertyDescriptor.Attributes.OfType<PropertyBinderAttribute>().FirstOrDefault();

			if (propBindAttr != null && propBindAttr.BindProperty(controllerContext, bindingContext, propertyDescriptor))
				return;

			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
		}
	}
}
