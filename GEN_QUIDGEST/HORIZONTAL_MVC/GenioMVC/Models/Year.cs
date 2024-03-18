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
	public class Year : ModelBase
	{
		[JsonIgnore]
		public CSGenioAyear klass { get { return baseklass as CSGenioAyear; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }
		public bool ShouldSerializeValCodyear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year.ValCodyear");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "C" Formula:  ""</summary>
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }
		public bool ShouldSerializeValYear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year.ValYear");

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula: SR "[AGREG->VALUE]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDouble(value); } }
		public bool ShouldSerializeValValue() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year.ValValue");

		[DisplayName("Year (numbers)")]
		/// <summary>Field : "Year (numbers)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValYearnum { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearnum, 0)); } set { klass.ValYearnum = Convert.ToDouble(value); } }
		public bool ShouldSerializeValYearnum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year.ValYearnum");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year.ValZzstate");

		public Year() : this(UserContext.Current.User) { }

		public Year(User u)
		{
			this.klass = new CSGenioAyear(u);
		}

		public Year(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Year(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Year(bool isEmpty) : this(isEmpty, null) { }

		public Year(CSGenioAyear val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Year(CSGenioAyear val) : this(val, null) { }

		public Year(CSGenioAyear val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Year(CSGenioAyear val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAyear csgenioa)
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
		public static Year Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Year Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAyear>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Year(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Year> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAyear>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Year>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAyear> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAyear>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAyear> All(CriteriaSet args = null)
		{
			return Where<CSGenioAyear>(false, args, numRegs: -1);
		}

		public static List<Year> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAyear>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Year>((r) => new Year(r));
		}

// USE /[MANUAL GQT MODEL YEAR]/
	}
}
