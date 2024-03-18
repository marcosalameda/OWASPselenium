using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
	[AttributeUsage(AttributeTargets.Property)]
	public class MaskAttribute : Attribute, IMetadataAware
	{
		private readonly string type;

		public enum MaskEnum
		{
			ZipCode, NIF, SSN, NIB, IBAN, CarPlatePT, Undefined
		}

		public MaskEnum Type
		{
			get
			{
				switch (type)
				{
					case "CP":
						return MaskEnum.ZipCode;
					case "NC":
						return MaskEnum.NIF;
					case "SS":
						return MaskEnum.SSN;
					case "IB":
						return MaskEnum.NIB;
					case "IN":
						return MaskEnum.IBAN;
					case "MA":
						return MaskEnum.CarPlatePT;
					default:
						return MaskEnum.Undefined;
				}
			}
		}

		public MaskAttribute(string type)
		{
			this.type = type;
		}

		public void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.AdditionalValues["MaskAttribute"] = Type;
		}
	}
}
