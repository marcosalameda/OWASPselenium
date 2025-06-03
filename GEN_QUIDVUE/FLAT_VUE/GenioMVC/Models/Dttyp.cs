using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Dttyp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdttyp klass { get { return baseklass as CSGenioAdttyp; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValCoddttyp")]
		public string ValCoddttyp { get { return klass.ValCoddttyp; } set { klass.ValCoddttyp = value; } }

		[DisplayName("string")]
		/// <summary>Field : "string" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValString")]
		public string ValString { get { return klass.ValString; } set { klass.ValString = value; } }

		[DisplayName("UUID (aka GUID)")]
		/// <summary>Field : "UUID (aka GUID)" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValUuid")]
		public string ValUuid { get { return klass.ValUuid; } set { klass.ValUuid = value; } }

		[DisplayName("Upper case")]
		/// <summary>Field : "Upper case" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValUppercas")]
		public string ValUppercas { get { return klass.ValUppercas; } set { klass.ValUppercas = value; } }

		[DisplayName("QR Code")]
		/// <summary>Field : "QR Code" Tipo: "C" Formula: + "[DTTYP->STRING]"</summary>
		[ShouldSerialize("Dttyp.ValQrcode")]
		public string ValQrcode { get { return klass.ValQrcode; } set { klass.ValQrcode = value; } }

		[DisplayName("Multiline text")]
		/// <summary>Field : "Multiline text" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValMultilin")]
		[DataType(DataType.MultilineText)]
		public string ValMultilin { get { return klass.ValMultilin; } set { klass.ValMultilin = value; } }

		[DisplayName("Multiline text (Text editor)")]
		/// <summary>Field : "Multiline text (Text editor)" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValMultili3")]
		[DataType(DataType.MultilineText)]
		public string ValMultili3 { get { return klass.ValMultili3; } set { klass.ValMultili3 = value; } }

		[DisplayName("Logical (tinyint) (storage 1 byte)")]
		/// <summary>Field : "Logical (tinyint) (storage 1 byte)" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValBoolean")]
		public bool ValBoolean { get { return Convert.ToBoolean(klass.ValBoolean); } set { klass.ValBoolean = Convert.ToInt32(value); } }

		[DisplayName("Conditional (smallint) (storage: 2 byte)")]
		/// <summary>Field : "Conditional (smallint) (storage: 2 byte)" Tipo: "IF" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValBoolean2")]
		public decimal ValBoolean2 { get { return klass.ValBoolean2; } set { klass.ValBoolean2 = value; } }

		[DisplayName("Numeric  4.0 - small integer (storage: 2 byte)")]
		/// <summary>Field : "Numeric  4.0 - small integer (storage: 2 byte)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValSmallint")]
		[NumericAttribute(0)]
		public decimal? ValSmallint { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSmallint, 0)); } set { klass.ValSmallint = Convert.ToDecimal(value); } }

		[DisplayName("Numeric  9.0 - integer (storage: 4 byte)")]
		/// <summary>Field : "Numeric  9.0 - integer (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValInteger")]
		[NumericAttribute(0)]
		public decimal? ValInteger { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValInteger, 0)); } set { klass.ValInteger = Convert.ToDecimal(value); } }

		[DisplayName("Numeric 15.0 - big integer (storage: 8 byte)")]
		/// <summary>Field : "Numeric 15.0 - big integer (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValBigint")]
		[NumericAttribute(0)]
		public decimal? ValBigint { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBigint, 0)); } set { klass.ValBigint = Convert.ToDecimal(value); } }

		[DisplayName("Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)")]
		/// <summary>Field : "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValReal")]
		[NumericAttribute(2)]
		public decimal? ValReal { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValReal, 2)); } set { klass.ValReal = Convert.ToDecimal(value); } }

		[DisplayName("Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)")]
		/// <summary>Field : "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValFloat")]
		[NumericAttribute(2)]
		public decimal? ValFloat { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValFloat, 2)); } set { klass.ValFloat = Convert.ToDecimal(value); } }

		[DisplayName("Decimal (1-10) (storage: 5 byte)")]
		/// <summary>Field : "Decimal (1-10) (storage: 5 byte)" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValDecimal")]
		[NumericAttribute(4)]
		public decimal? ValDecimal { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDecimal, 4)); } set { klass.ValDecimal = Convert.ToDecimal(value); } }

		[DisplayName("Decimal (11-15) (storage: 9 byte)")]
		/// <summary>Field : "Decimal (11-15) (storage: 9 byte)" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValDecimal9")]
		[NumericAttribute(4)]
		public decimal? ValDecimal9 { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDecimal9, 4)); } set { klass.ValDecimal9 = Convert.ToDecimal(value); } }

		[DisplayName("Money - decimal (1-10) (storage: 5 byte)")]
		/// <summary>Field : "Money - decimal (1-10) (storage: 5 byte)" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValMoney")]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValMoney { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMoney, 4)); } set { klass.ValMoney = Convert.ToDecimal(value); } }

		[DisplayName("Money - decimal (11-15) (storage: 9 byte)")]
		/// <summary>Field : "Money - decimal (11-15) (storage: 9 byte)" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValMoney9")]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValMoney9 { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMoney9, 4)); } set { klass.ValMoney9 = Convert.ToDecimal(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Date Time")]
		/// <summary>Field : "Date Time" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValDatetime")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get { return klass.ValDatetime; } set { klass.ValDatetime = value ?? DateTime.MinValue; } }

		[DisplayName("Date Time Second")]
		/// <summary>Field : "Date Time Second" Tipo: "DS" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValDtsesond")]
		[DataType(DataType.Date)]
		[DateAttribute("DS")]
		public DateTime? ValDtsesond { get { return klass.ValDtsesond; } set { klass.ValDtsesond = value ?? DateTime.MinValue; } }

		[DisplayName("Time")]
		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValTime")]
		[DateAttribute("T")]
		public string ValTime { get { return klass.ValTime; } set { klass.ValTime = value; } }

		[DisplayName("Starting time with inclusive boundary")]
		/// <summary>Field : "Starting time with inclusive boundary" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValStart")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStart { get { return klass.ValStart; } set { klass.ValStart = value ?? DateTime.MinValue; } }

		[DisplayName("End time with inclusive boundary, if not ongoing")]
		/// <summary>Field : "End time with inclusive boundary, if not ongoing" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValEnd")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get { return klass.ValEnd; } set { klass.ValEnd = value ?? DateTime.MinValue; } }

		[DisplayName("Image (binary)")]
		/// <summary>Field : "Image (binary)" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Dttyp.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValImage { get { return new ImageModel(klass.ValImage) { Ticket = ValImageQTicket }; } set { klass.ValImage = value; } }
		[JsonIgnore]
		public string ValImageQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Dttyp.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Dttyp(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAdttyp(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dttyp(UserContext userContext, CSGenioAdttyp val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAdttyp csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Dttyp Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdttyp>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Dttyp(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Dttyp> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdttyp>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Dttyp>((r) => new Dttyp(userCtx, r));
		}

// USE /[MANUAL GQT MODEL DTTYP]/
	}
}
