using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public abstract class PropertyBinderAttribute : Attribute, IMetadataAware
	{
		public abstract bool BindProperty(ControllerContext controllerContext,
		ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor);
		public abstract void OnMetadataCreated(ModelMetadata metadata);
	}
}
