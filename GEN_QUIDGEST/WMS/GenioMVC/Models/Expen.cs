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
	public class Expen : ModelBase
	{
		[JsonIgnore]
		public CSGenioAexpen klass { get { return baseklass as CSGenioAexpen; } set { baseklass = value; } }

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
		public string ValCoddespe { get { return klass.ValCoddespe; } set { klass.ValCoddespe = value; } }
		public bool ShouldSerializeValCoddespe() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValCoddespe");

		[DisplayName(">PROJECT")]
		/// <summary>Field : ">PROJECT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }
		public bool ShouldSerializeValCodproje() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValCodproje");
		private Proje _proje;
		[DisplayName("Proje")]
		public virtual Proje Proje { get { if (!this.isEmptyModel && (_proje == null || (!string.IsNullOrEmpty(ValCodproje) && (_proje.isEmptyModel || _proje.klass.QPrimaryKey != ValCodproje)))) _proje = Models.Proje.Find(ValCodproje, Identifier, _fieldsToSerialize); if (_proje == null) _proje = new Models.Proje(true, _fieldsToSerialize); return _proje; } set { _proje = value; } }
		public bool ShouldSerializeProje () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje");

		[DisplayName(">ANO")]
		/// <summary>Field : ">ANO" Tipo: "CE" Formula:  ""</summary>
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }
		public bool ShouldSerializeValCodyear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValCodyear");
		private Year _year;
		[DisplayName("Year")]
		public virtual Year Year { get { if (!this.isEmptyModel && (_year == null || (!string.IsNullOrEmpty(ValCodyear) && (_year.isEmptyModel || _year.klass.QPrimaryKey != ValCodyear)))) _year = Models.Year.Find(ValCodyear, Identifier, _fieldsToSerialize); if (_year == null) _year = new Models.Year(true, _fieldsToSerialize); return _year; } set { _year = value; } }
		public bool ShouldSerializeYear () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula: + "[YEAR->YEARNUM]"</summary>
		[NumericAttribute(0)]
		public decimal? ValYearnumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearnumb, 0)); } set { klass.ValYearnumb = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValYearnumb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValYearnumb");

		[DisplayName("Previous year")]
		/// <summary>Field : "Previous year" Tipo: "N" Formula: + "[YEAR->YEARNUM]-1"</summary>
		[NumericAttribute(0)]
		public decimal? ValYearprev { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearprev, 0)); } set { klass.ValYearprev = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValYearprev() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValYearprev");

		[DisplayName(">AGREGADOR")]
		/// <summary>Field : ">AGREGADOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodaggre { get { return klass.ValCodaggre; } set { klass.ValCodaggre = value; } }
		public bool ShouldSerializeValCodaggre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValCodaggre");
		private Agreg _agreg;
		[DisplayName("Agreg")]
		public virtual Agreg Agreg { get { if (!this.isEmptyModel && (_agreg == null || (!string.IsNullOrEmpty(ValCodaggre) && (_agreg.isEmptyModel || _agreg.klass.QPrimaryKey != ValCodaggre)))) _agreg = Models.Agreg.Find(ValCodaggre, Identifier, _fieldsToSerialize); if (_agreg == null) _agreg = new Models.Agreg(true, _fieldsToSerialize); return _agreg; } set { _agreg = value; } }
		public bool ShouldSerializeAgreg () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agreg");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValDescript");

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValValue() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValValue");

		[DisplayName("Previous Value")]
		/// <summary>Field : "Previous Value" Tipo: "$D" Formula: CT "EXPE1[EXPEN->YEARPREV][EXPE1->YEARNUMB][EXPE1->VALUE](DESC)"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrevval { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrevval, 2)); } set { klass.ValPrevval = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrevval() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValPrevval");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Expen.ValZzstate");

		public Expen() : this(UserContext.Current.User) { }

		public Expen(User u)
		{
			this.klass = new CSGenioAexpen(u);
		}

		public Expen(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Expen(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Expen(bool isEmpty) : this(isEmpty, null) { }

		public Expen(CSGenioAexpen val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Expen(CSGenioAexpen val) : this(val, null) { }

		public Expen(CSGenioAexpen val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Expen(CSGenioAexpen val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAexpen csgenioa)
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
					case "agreg":
						if (_agreg == null)
							_agreg = new Agreg(true, _fieldsToSerialize);
						_agreg.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Expen Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Expen Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAexpen>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Expen(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Expen> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAexpen>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Expen>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAexpen> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAexpen>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAexpen> All(CriteriaSet args = null)
		{
			return Where<CSGenioAexpen>(false, args, numRegs: -1);
		}

		public static List<Expen> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAexpen>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Expen>((r) => new Expen(r));
		}

// USE /[MANUAL GQT MODEL EXPEN]/
	}
}
