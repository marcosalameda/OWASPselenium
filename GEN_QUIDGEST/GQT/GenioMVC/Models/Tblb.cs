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
	public class Tblb : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtblb klass { get { return baseklass as CSGenioAtblb; } set { baseklass = value; } }

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
		public string ValCodtblb { get { return klass.ValCodtblb; } set { klass.ValCodtblb = value; } }
		public bool ShouldSerializeValCodtblb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValCodtblb");

		[DisplayName("Foreign Key")]
		/// <summary>Field : "Foreign Key" Tipo: "CE" Formula:  ""</summary>
		public string ValFkey1 { get { return klass.ValFkey1; } set { klass.ValFkey1 = value; } }
		public bool ShouldSerializeValFkey1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValFkey1");
		private Grpb _grpb;
		[DisplayName("Grpb")]
		public virtual Grpb Grpb { get { if (!this.isEmptyModel && (_grpb == null || (!string.IsNullOrEmpty(ValFkey1) && (_grpb.isEmptyModel || _grpb.klass.QPrimaryKey != ValFkey1)))) _grpb = Models.Grpb.Find(ValFkey1, Identifier, _fieldsToSerialize); if (_grpb == null) _grpb = new Models.Grpb(true, _fieldsToSerialize); return _grpb; } set { _grpb = value; } }
		public bool ShouldSerializeGrpb () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Grpb");

		[DisplayName("Text")]
		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public string ValText { get { return klass.ValText; } set { klass.ValText = value; } }
		public bool ShouldSerializeValText() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValText");

		[DisplayName("Multiline Text")]
		/// <summary>Field : "Multiline Text" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValTextml { get { return klass.ValTextml; } set { klass.ValTextml = value; } }
		public bool ShouldSerializeValTextml() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValTextml");

		[DisplayName("Numeric (Integer)")]
		/// <summary>Field : "Numeric (Integer)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNumint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumint, 0)); } set { klass.ValNumint = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNumint() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValNumint");

		[DisplayName("Numeric (Decimal)")]
		/// <summary>Field : "Numeric (Decimal)" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(3)]
		public decimal? ValNumdec { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumdec, 3)); } set { klass.ValNumdec = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNumdec() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValNumdec");

		[DisplayName("Currency (Interger)")]
		/// <summary>Field : "Currency (Interger)" Tipo: "$" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValCurint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValCurint, 2)); } set { klass.ValCurint = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValCurint() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValCurint");

		[DisplayName("Currency (Decimal)")]
		/// <summary>Field : "Currency (Decimal)" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValCurdec { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValCurdec, 4)); } set { klass.ValCurdec = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValCurdec() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValCurdec");

		[DisplayName("Boolean")]
		/// <summary>Field : "Boolean" Tipo: "L" Formula:  ""</summary>
		public bool ValBool { get { return Convert.ToBoolean(klass.ValBool); } set { klass.ValBool = Convert.ToInt32(value); } }
		public bool ShouldSerializeValBool() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValBool");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValDate");

		[DisplayName("DateTime (Minutes)")]
		/// <summary>Field : "DateTime (Minutes)" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatetm { get { return klass.ValDatetm; } set { klass.ValDatetm = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatetm() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValDatetm");

		[DisplayName("DateTime (Seconds)")]
		/// <summary>Field : "DateTime (Seconds)" Tipo: "DS" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DS")]
		public DateTime? ValDatets { get { return klass.ValDatets; } set { klass.ValDatets = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatets() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValDatets");

		[DisplayName("Time (Hours-Minutes)")]
		/// <summary>Field : "Time (Hours-Minutes)" Tipo: "T" Formula:  ""</summary>
		[DateAttribute("T")]
		public string ValTimehm { get { return klass.ValTimehm; } set { klass.ValTimehm = value; } }
		public bool ShouldSerializeValTimehm() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValTimehm");

		[DisplayName("Enumeration (Text)")]
		/// <summary>Field : "Enumeration (Text)" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Typet", GenioMVC.Helpers.ArrayType.Character)]
		public string ValEnumt { get { return klass.ValEnumt; } set { klass.ValEnumt = value; } }
		[JsonIgnore]
		public SelectList ArrayValenumt { get { return new SelectList(CSGenio.business.ArrayTypet.GetDictionary(), "Key", "Value", ValEnumt); } set { ValEnumt = value.SelectedValue as string; } }
		public bool ShouldSerializeValEnumt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValEnumt");

		[DisplayName("Enumeration (Numeric)")]
		/// <summary>Field : "Enumeration (Numeric)" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Typen", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValEnumn { get { return klass.ValEnumn; } set { klass.ValEnumn = value; } }
		[JsonIgnore]
		public SelectList ArrayValenumn { get { return new SelectList(CSGenio.business.ArrayTypen.GetDictionary(), "Key", "Value", ValEnumn); } set { ValEnumn = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValEnumn() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValEnumn");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblb.ValZzstate");

		public Tblb() : this(UserContext.Current.User) { }

		public Tblb(User u)
		{
			this.klass = new CSGenioAtblb(u);
		}

		public Tblb(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tblb(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tblb(bool isEmpty) : this(isEmpty, null) { }

		public Tblb(CSGenioAtblb val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tblb(CSGenioAtblb val) : this(val, null) { }

		public Tblb(CSGenioAtblb val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tblb(CSGenioAtblb val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtblb csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "grpb":
						if (_grpb == null)
							_grpb = new Grpb(true, _fieldsToSerialize);
						_grpb.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Tblb Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tblb Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtblb>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tblb(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tblb> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtblb>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tblb>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtblb> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtblb>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtblb> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtblb>(false, args, numRegs: -1);
		}

		public static List<Tblb> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtblb>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tblb>((r) => new Tblb(r));
		}

// USE /[MANUAL GQT MODEL TBLB]/
	}
}
