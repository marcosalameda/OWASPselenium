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
	public class Agreg : ModelBase
	{
		[JsonIgnore]
		public CSGenioAagreg klass { get { return baseklass as CSGenioAagreg; } set { baseklass = value; } }

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
		public string ValCodaggre { get { return klass.ValCodaggre; } set { klass.ValCodaggre = value; } }
		public bool ShouldSerializeValCodaggre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValCodaggre");

		[DisplayName(">PROJECT")]
		/// <summary>Field : ">PROJECT" Tipo: "CE" Formula: ST "[EXPEN->CODPROJE]"</summary>
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }
		public bool ShouldSerializeValCodproje() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValCodproje");
		private Proje _proje;
		[DisplayName("Proje")]
		public virtual Proje Proje { get { if (!this.isEmptyModel && (_proje == null || (!string.IsNullOrEmpty(ValCodproje) && (_proje.isEmptyModel || _proje.klass.QPrimaryKey != ValCodproje)))) _proje = Models.Proje.Find(ValCodproje, Identifier, _fieldsToSerialize); if (_proje == null) _proje = new Models.Proje(true, _fieldsToSerialize); return _proje; } set { _proje = value; } }
		public bool ShouldSerializeProje () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: ST "[EXPEN->CODYEAR]"</summary>
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }
		public bool ShouldSerializeValCodyear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValCodyear");
		private Year _year;
		[DisplayName("Year")]
		public virtual Year Year { get { if (!this.isEmptyModel && (_year == null || (!string.IsNullOrEmpty(ValCodyear) && (_year.isEmptyModel || _year.klass.QPrimaryKey != ValCodyear)))) _year = Models.Year.Find(ValCodyear, Identifier, _fieldsToSerialize); if (_year == null) _year = new Models.Year(true, _fieldsToSerialize); return _year; } set { _year = value; } }
		public bool ShouldSerializeYear () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "C" Formula: ++ "[YEAR->YEAR]"</summary>
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }
		public bool ShouldSerializeValYear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValYear");

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula: SR "[EXPEN->VALUE]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValValue() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValValue");

		[DisplayName("Year NUMBER")]
		/// <summary>Field : "Year NUMBER" Tipo: "N" Formula: ++ "[YEAR->YEARNUM]"</summary>
		[NumericAttribute(0)]
		public decimal? ValYearnumb { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValYearnumb, 0)); } set { klass.ValYearnumb = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValYearnumb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValYearnumb");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg.ValZzstate");

		public Agreg() : this(UserContext.Current.User) { }

		public Agreg(User u)
		{
			this.klass = new CSGenioAagreg(u);
		}

		public Agreg(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Agreg(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Agreg(bool isEmpty) : this(isEmpty, null) { }

		public Agreg(CSGenioAagreg val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Agreg(CSGenioAagreg val) : this(val, null) { }

		public Agreg(CSGenioAagreg val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Agreg(CSGenioAagreg val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAagreg csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "proje":
						if (_proje == null)
							_proje = new Proje(true, _fieldsToSerialize);
						_proje.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "year":
						if (_year == null)
							_year = new Year(true, _fieldsToSerialize);
						_year.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Agreg Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Agreg Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAagreg>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Agreg(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Agreg> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAagreg>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Agreg>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAagreg> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAagreg>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAagreg> All(CriteriaSet args = null)
		{
			return Where<CSGenioAagreg>(false, args, numRegs: -1);
		}

		public static List<Agreg> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAagreg>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Agreg>((r) => new Agreg(r));
		}

// USE /[MANUAL GQT MODEL AGREG]/
	}
}
