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
	public class Expen : ModelBase
	{
		[JsonIgnore]
		public CSGenioAexpen klass { get { return baseklass as CSGenioAexpen; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Expen.ValCoddespe")]
		public string ValCoddespe { get { return klass.ValCoddespe; } set { klass.ValCoddespe = value; } }

		[DisplayName(">PROJECT")]
		/// <summary>Field : ">PROJECT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Expen.ValCodproje")]
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }
		private Proje _proje;
		[DisplayName("Proje")]
		[ShouldSerialize("Proje")]
		public virtual Proje Proje {
			get {
				if (!this.isEmptyModel && (_proje == null || (!string.IsNullOrEmpty(ValCodproje) && (_proje.isEmptyModel || _proje.klass.QPrimaryKey != ValCodproje))))
					_proje = Models.Proje.Find(ValCodproje, m_userContext, Identifier, _fieldsToSerialize);
				if (_proje == null)
					_proje = new Models.Proje(m_userContext, true, _fieldsToSerialize);
				return _proje;
			}
			set { _proje = value; }
		}


		[DisplayName(">ANO")]
		/// <summary>Field : ">ANO" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Expen.ValCodyear")]
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }
		private Year _year;
		[DisplayName("Year")]
		[ShouldSerialize("Year")]
		public virtual Year Year {
			get {
				if (!this.isEmptyModel && (_year == null || (!string.IsNullOrEmpty(ValCodyear) && (_year.isEmptyModel || _year.klass.QPrimaryKey != ValCodyear))))
					_year = Models.Year.Find(ValCodyear, m_userContext, Identifier, _fieldsToSerialize);
				if (_year == null)
					_year = new Models.Year(m_userContext, true, _fieldsToSerialize);
				return _year;
			}
			set { _year = value; }
		}


		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula: + "[YEAR->YEARNUM]"</summary>
		[ShouldSerialize("Expen.ValYearnumb")]
		[NumericAttribute(0)]
		public decimal? ValYearnumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearnumb, 0)); } set { klass.ValYearnumb = Convert.ToDecimal(value); } }

		[DisplayName("Previous year")]
		/// <summary>Field : "Previous year" Tipo: "N" Formula: + "[YEAR->YEARNUM]-1"</summary>
		[ShouldSerialize("Expen.ValYearprev")]
		[NumericAttribute(0)]
		public decimal? ValYearprev { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearprev, 0)); } set { klass.ValYearprev = Convert.ToDecimal(value); } }

		[DisplayName(">AGREGADOR")]
		/// <summary>Field : ">AGREGADOR" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Expen.ValCodaggre")]
		public string ValCodaggre { get { return klass.ValCodaggre; } set { klass.ValCodaggre = value; } }
		private Agreg _agreg;
		[DisplayName("Agreg")]
		[ShouldSerialize("Agreg")]
		public virtual Agreg Agreg {
			get {
				if (!this.isEmptyModel && (_agreg == null || (!string.IsNullOrEmpty(ValCodaggre) && (_agreg.isEmptyModel || _agreg.klass.QPrimaryKey != ValCodaggre))))
					_agreg = Models.Agreg.Find(ValCodaggre, m_userContext, Identifier, _fieldsToSerialize);
				if (_agreg == null)
					_agreg = new Models.Agreg(m_userContext, true, _fieldsToSerialize);
				return _agreg;
			}
			set { _agreg = value; }
		}


		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Expen.ValDescript")]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Expen.ValValue")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }

		[DisplayName("Previous Value")]
		/// <summary>Field : "Previous Value" Tipo: "$D" Formula: CT "EXPE1[EXPEN->YEARPREV][EXPE1->YEARNUMB][EXPE1->VALUE](DESC)"</summary>
		[ShouldSerialize("Expen.ValPrevval")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrevval { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrevval, 2)); } set { klass.ValPrevval = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Expen.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Expen(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAexpen(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Expen(UserContext userContext, CSGenioAexpen val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


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
							_proje = new Proje(m_userContext, true, _fieldsToSerialize);
						_proje.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "year":
						if (_year == null)
							_year = new Year(m_userContext, true, _fieldsToSerialize);
						_year.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "agreg":
						if (_agreg == null)
							_agreg = new Agreg(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Expen Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAexpen>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Expen(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Expen> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAexpen>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Expen>((r) => new Expen(userCtx, r));
		}

// USE /[MANUAL GQT MODEL EXPEN]/
	}
}
