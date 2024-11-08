using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.Models
{
	public class Dttyp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdttyp klass { get { return baseklass as CSGenioAdttyp; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddttyp { get { return klass.ValCoddttyp; } set { klass.ValCoddttyp = value; } }
		public bool ShouldSerializeValCoddttyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValCoddttyp");

		[DisplayName("string")]
		/// <summary>Field : "string" Tipo: "C" Formula:  ""</summary>
		public string ValString { get { return klass.ValString; } set { klass.ValString = value; } }
		public bool ShouldSerializeValString() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValString");

		[DisplayName("UUID (aka GUID)")]
		/// <summary>Field : "UUID (aka GUID)" Tipo: "C" Formula:  ""</summary>
		public string ValUuid { get { return klass.ValUuid; } set { klass.ValUuid = value; } }
		public bool ShouldSerializeValUuid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValUuid");

		[DisplayName("Upper case")]
		/// <summary>Field : "Upper case" Tipo: "C" Formula:  ""</summary>
		public string ValUppercas { get { return klass.ValUppercas; } set { klass.ValUppercas = value; } }
		public bool ShouldSerializeValUppercas() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValUppercas");

		[DisplayName("QR Code")]
		/// <summary>Field : "QR Code" Tipo: "C" Formula: + "[DTTYP->STRING]"</summary>
		public string ValQrcode { get { return klass.ValQrcode; } set { klass.ValQrcode = value; } }
		public bool ShouldSerializeValQrcode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValQrcode");

		[DisplayName("Multiline text")]
		/// <summary>Field : "Multiline text" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValMultilin { get { return klass.ValMultilin; } set { klass.ValMultilin = value; } }
		public bool ShouldSerializeValMultilin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValMultilin");

		[DisplayName("Multiline text (Text editor)")]
		/// <summary>Field : "Multiline text (Text editor)" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValMultili3 { get { return klass.ValMultili3; } set { klass.ValMultili3 = value; } }
		public bool ShouldSerializeValMultili3() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValMultili3");

		[DisplayName("Logical (tinyint) (storage 1 byte)")]
		/// <summary>Field : "Logical (tinyint) (storage 1 byte)" Tipo: "L" Formula:  ""</summary>
		public bool ValBoolean { get { return Convert.ToBoolean(klass.ValBoolean); } set { klass.ValBoolean = Convert.ToInt32(value); } }
		public bool ShouldSerializeValBoolean() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValBoolean");

		[DisplayName("Conditional (smallint) (storage: 2 byte)")]
		/// <summary>Field : "Conditional (smallint) (storage: 2 byte)" Tipo: "IF" Formula:  ""</summary>
		public decimal ValBoolean2 { get { return klass.ValBoolean2; } set { klass.ValBoolean2 = value; } }
		public bool ShouldSerializeValBoolean2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValBoolean2");

		[DisplayName("Numeric  4.0 - small integer (storage: 2 byte)")]
		/// <summary>Field : "Numeric  4.0 - small integer (storage: 2 byte)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValSmallint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSmallint, 0)); } set { klass.ValSmallint = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSmallint() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValSmallint");

		[DisplayName("Numeric  9.0 - integer (storage: 4 byte)")]
		/// <summary>Field : "Numeric  9.0 - integer (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValInteger { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValInteger, 0)); } set { klass.ValInteger = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValInteger() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValInteger");

		[DisplayName("Numeric 15.0 - big integer (storage: 8 byte)")]
		/// <summary>Field : "Numeric 15.0 - big integer (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValBigint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBigint, 0)); } set { klass.ValBigint = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBigint() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValBigint");

		[DisplayName("Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)")]
		/// <summary>Field : "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValReal { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValReal, 2)); } set { klass.ValReal = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValReal() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValReal");

		[DisplayName("Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)")]
		/// <summary>Field : "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValFloat { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValFloat, 2)); } set { klass.ValFloat = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValFloat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValFloat");

		[DisplayName("Decimal (1-10) (storage: 5 byte)")]
		/// <summary>Field : "Decimal (1-10) (storage: 5 byte)" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(4)]
		public decimal? ValDecimal { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDecimal, 4)); } set { klass.ValDecimal = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDecimal() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValDecimal");

		[DisplayName("Decimal (11-15) (storage: 9 byte)")]
		/// <summary>Field : "Decimal (11-15) (storage: 9 byte)" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(4)]
		public decimal? ValDecimal9 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDecimal9, 4)); } set { klass.ValDecimal9 = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDecimal9() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValDecimal9");

		[DisplayName("Money - decimal (1-10) (storage: 5 byte)")]
		/// <summary>Field : "Money - decimal (1-10) (storage: 5 byte)" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValMoney { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValMoney, 4)); } set { klass.ValMoney = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValMoney() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValMoney");

		[DisplayName("Money - decimal (11-15) (storage: 9 byte)")]
		/// <summary>Field : "Money - decimal (11-15) (storage: 9 byte)" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValMoney9 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValMoney9, 4)); } set { klass.ValMoney9 = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValMoney9() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValMoney9");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValDate");

		[DisplayName("Date Time")]
		/// <summary>Field : "Date Time" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get { return klass.ValDatetime; } set { klass.ValDatetime = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatetime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValDatetime");

		[DisplayName("Date Time Second")]
		/// <summary>Field : "Date Time Second" Tipo: "DS" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DS")]
		public DateTime? ValDtsesond { get { return klass.ValDtsesond; } set { klass.ValDtsesond = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtsesond() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValDtsesond");

		[DisplayName("Time")]
		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		[DateAttribute("T")]
		public string ValTime { get { return klass.ValTime; } set { klass.ValTime = value; } }
		public bool ShouldSerializeValTime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValTime");

		[DisplayName("Starting time with inclusive boundary")]
		/// <summary>Field : "Starting time with inclusive boundary" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStart { get { return klass.ValStart; } set { klass.ValStart = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValStart() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValStart");

		[DisplayName("End time with inclusive boundary, if not ongoing")]
		/// <summary>Field : "End time with inclusive boundary, if not ongoing" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get { return klass.ValEnd; } set { klass.ValEnd = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValEnd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValEnd");

		[DisplayName("Image (binary)")]
		/// <summary>Field : "Image (binary)" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }
		public bool ShouldSerializeValImage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValImage");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dttyp.ValZzstate");

		public Dttyp() : this(UserContext.Current.User) { }

		public Dttyp(User u)
		{
			this.klass = new CSGenioAdttyp(u);
		}

		public Dttyp(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dttyp(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Dttyp(bool isEmpty) : this(isEmpty, null) { }

		public Dttyp(CSGenioAdttyp val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dttyp(CSGenioAdttyp val) : this(val, null) { }

		public Dttyp(CSGenioAdttyp val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Dttyp(CSGenioAdttyp val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Dttyp Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			return Find(id, UserContext.Current, identifier, fieldsToSerialize, fieldsToQuery);
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
			return record == null ? null : new Dttyp(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Dttyp> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAdttyp>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Dttyp>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAdttyp> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAdttyp>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAdttyp> All(CriteriaSet args = null)
		{
			return Where<CSGenioAdttyp>(false, args, numRegs: -1);
		}

		public static List<Dttyp> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdttyp>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Dttyp>((r) => new Dttyp(r));
		}

// USE /[MANUAL GQT MODEL DTTYP]/
	}
}
