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
	public class Tblb : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtblb klass { get { return baseklass as CSGenioAtblb; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValCodtblb")]
		public string ValCodtblb { get { return klass.ValCodtblb; } set { klass.ValCodtblb = value; } }

		[DisplayName("Foreign Key")]
		/// <summary>Field : "Foreign Key" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValFkey1")]
		public string ValFkey1 { get { return klass.ValFkey1; } set { klass.ValFkey1 = value; } }

		private Grpb _grpb;
		[DisplayName("Grpb")]
		[ShouldSerialize("Grpb")]
		public virtual Grpb Grpb
		{
			get
			{
				if (!isEmptyModel && (_grpb == null || (!string.IsNullOrEmpty(ValFkey1) && (_grpb.isEmptyModel || _grpb.klass.QPrimaryKey != ValFkey1))))
					_grpb = Models.Grpb.Find(ValFkey1, m_userContext, Identifier, _fieldsToSerialize);
				_grpb ??= new Models.Grpb(m_userContext, true, _fieldsToSerialize);
				return _grpb;
			}
			set { _grpb = value; }
		}

		[DisplayName("Text")]
		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValText")]
		public string ValText { get { return klass.ValText; } set { klass.ValText = value; } }

		[DisplayName("Multiline Text")]
		/// <summary>Field : "Multiline Text" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValTextml")]
		[DataType(DataType.MultilineText)]
		public string ValTextml { get { return klass.ValTextml; } set { klass.ValTextml = value; } }

		[DisplayName("Numeric (Integer)")]
		/// <summary>Field : "Numeric (Integer)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValNumint")]
		[NumericAttribute(0)]
		public decimal? ValNumint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumint, 0)); } set { klass.ValNumint = Convert.ToDecimal(value); } }

		[DisplayName("Numeric (Decimal)")]
		/// <summary>Field : "Numeric (Decimal)" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValNumdec")]
		[NumericAttribute(3)]
		public decimal? ValNumdec { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumdec, 3)); } set { klass.ValNumdec = Convert.ToDecimal(value); } }

		[DisplayName("Currency (Interger)")]
		/// <summary>Field : "Currency (Interger)" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValCurint")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValCurint { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValCurint, 2)); } set { klass.ValCurint = Convert.ToDecimal(value); } }

		[DisplayName("Currency (Decimal)")]
		/// <summary>Field : "Currency (Decimal)" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValCurdec")]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValCurdec { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValCurdec, 4)); } set { klass.ValCurdec = Convert.ToDecimal(value); } }

		[DisplayName("Boolean")]
		/// <summary>Field : "Boolean" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValBool")]
		public bool ValBool { get { return Convert.ToBoolean(klass.ValBool); } set { klass.ValBool = Convert.ToInt32(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("DateTime (Minutes)")]
		/// <summary>Field : "DateTime (Minutes)" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValDatetm")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatetm { get { return klass.ValDatetm; } set { klass.ValDatetm = value ?? DateTime.MinValue; } }

		[DisplayName("DateTime (Seconds)")]
		/// <summary>Field : "DateTime (Seconds)" Tipo: "DS" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValDatets")]
		[DataType(DataType.Date)]
		[DateAttribute("DS")]
		public DateTime? ValDatets { get { return klass.ValDatets; } set { klass.ValDatets = value ?? DateTime.MinValue; } }

		[DisplayName("Time (Hours-Minutes)")]
		/// <summary>Field : "Time (Hours-Minutes)" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValTimehm")]
		[DateAttribute("T")]
		public string ValTimehm { get { return klass.ValTimehm; } set { klass.ValTimehm = value; } }

		[DisplayName("Enumeration (Text)")]
		/// <summary>Field : "Enumeration (Text)" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValEnumt")]
		[DataArray("Typet", GenioMVC.Helpers.ArrayType.Character)]
		public string ValEnumt { get { return klass.ValEnumt; } set { klass.ValEnumt = value; } }
		[JsonIgnore]
		public SelectList ArrayValenumt { get { return new SelectList(CSGenio.business.ArrayTypet.GetDictionary(), "Key", "Value", ValEnumt); } set { ValEnumt = value.SelectedValue as string; } }

		[DisplayName("Enumeration (Numeric)")]
		/// <summary>Field : "Enumeration (Numeric)" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Tblb.ValEnumn")]
		[DataArray("Typen", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValEnumn { get { return klass.ValEnumn; } set { klass.ValEnumn = value; } }
		[JsonIgnore]
		public SelectList ArrayValenumn { get { return new SelectList(CSGenio.business.ArrayTypen.GetDictionary(), "Key", "Value", ValEnumn); } set { ValEnumn = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tblb.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tblb(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtblb(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tblb(UserContext userContext, CSGenioAtblb val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtblb csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "grpb":
						_grpb ??= new Grpb(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Tblb Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtblb>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tblb(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tblb> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtblb>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tblb>((r) => new Tblb(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TBLB]/
	}
}
