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
	public class Expe1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAexpe1 klass { get { return baseklass as CSGenioAexpe1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddespe { get { return klass.ValCoddespe; } set { klass.ValCoddespe = value; } }
		public bool ShouldSerializeValCoddespe() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValCoddespe");

		[DisplayName(">PROJECT")]
		/// <summary>Field : ">PROJECT" Tipo: "CF" Formula:  ""</summary>
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }
		public bool ShouldSerializeValCodproje() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValCodproje");

		[DisplayName(">YEAR")]
		/// <summary>Field : ">YEAR" Tipo: "CF" Formula:  ""</summary>
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }
		public bool ShouldSerializeValCodyear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValCodyear");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValYearnumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearnumb, 0)); } set { klass.ValYearnumb = Convert.ToDouble(value); } }
		public bool ShouldSerializeValYearnumb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValYearnumb");

		[DisplayName("Previous year")]
		/// <summary>Field : "Previous year" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValYearprev { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearprev, 0)); } set { klass.ValYearprev = Convert.ToDouble(value); } }
		public bool ShouldSerializeValYearprev() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValYearprev");

		[DisplayName(">AGGREGATOR")]
		/// <summary>Field : ">AGGREGATOR" Tipo: "CF" Formula:  ""</summary>
		public string ValCodaggre { get { return klass.ValCodaggre; } set { klass.ValCodaggre = value; } }
		public bool ShouldSerializeValCodaggre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValCodaggre");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValDescript");

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDouble(value); } }
		public bool ShouldSerializeValValue() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValValue");

		[DisplayName("Previous value")]
		/// <summary>Field : "Previous value" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrevval { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrevval, 2)); } set { klass.ValPrevval = Convert.ToDouble(value); } }
		public bool ShouldSerializeValPrevval() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValPrevval");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expe1.ValZzstate");

		public Expe1() : this(UserContext.Current.User) { }

		public Expe1(User u)
		{
			this.klass = new CSGenioAexpe1(u);
		}

		public Expe1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Expe1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Expe1(bool isEmpty) : this(isEmpty, null) { }

		public Expe1(CSGenioAexpe1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Expe1(CSGenioAexpe1 val) : this(val, null) { }

		public Expe1(CSGenioAexpe1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Expe1(CSGenioAexpe1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAexpe1 csgenioa)
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
		public static Expe1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Expe1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAexpe1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Expe1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Expe1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAexpe1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Expe1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAexpe1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAexpe1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAexpe1> All(CriteriaSet args = null)
		{
			return Where<CSGenioAexpe1>(false, args, numRegs: -1);
		}

		public static List<Expe1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAexpe1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Expe1>((r) => new Expe1(r));
		}

// USE /[MANUAL GQT MODEL EXPE1]/
	}
}
