using System;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
	[AttributeUsage(AttributeTargets.Property)]
	public class NumericAttribute : Attribute, IMetadataAware
	{
		public int Decimals { get; set; }

		public NumericAttribute(int decimalDigits)
		{
			Decimals = decimalDigits;
		}

		public void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.AdditionalValues["Decimals"] = Decimals;
		}
	}
}
