using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
	[AttributeUsage(AttributeTargets.Property)]
	public class HyperLinkAttribute : Attribute, IMetadataAware
	{
		public HyperLinkAttribute() { }

		public void OnMetadataCreated(ModelMetadata metadata) { }
	}
}
