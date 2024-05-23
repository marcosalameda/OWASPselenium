using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
	[AttributeUsage(AttributeTargets.Property)]
	public class DateAttribute : Attribute, IMetadataAware
	{
		private readonly string type;

		public enum DateEnum
		{
			Date, DateTime, DateTimeSeconds, Time, Undefined
		}

		public DateEnum Type
		{
			get
			{
				switch (type)
				{
					case "D":
					case "OD":
					case "ED":
						return DateEnum.Date;
					case "DS":
					case "OI":
						return DateEnum.DateTimeSeconds;
					case "DT":
						return DateEnum.DateTime;
					case "OT":
					case "ET":
					case "T":
						return DateEnum.Time;
					default:
						return DateEnum.Undefined;
				}
			}
		}

		public DateAttribute(string type)
		{
			this.type = type;
		}

		public void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.AdditionalValues["DateAttribute"] = Type;
			metadata.AdditionalValues["InternalType"] = this.type;
		}

		public static DateEnum ConvertToDateAttribute(Attribute a) {
			if (a == null)
				return DateEnum.Undefined;
			DateAttribute tmp = a as DateAttribute;
			return tmp.Type;
		}
	}
}
