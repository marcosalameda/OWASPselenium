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
	public class Expe1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAexpe1 klass { get { return baseklass as CSGenioAexpe1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValCoddespe")]
		public string ValCoddespe { get { return klass.ValCoddespe; } set { klass.ValCoddespe = value; } }

		[DisplayName(">PROJECT")]
		/// <summary>Field : ">PROJECT" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValCodproje")]
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }

		[DisplayName(">YEAR")]
		/// <summary>Field : ">YEAR" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValCodyear")]
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValYearnumb")]
		[NumericAttribute(0)]
		public decimal? ValYearnumb { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValYearnumb, 0)); } set { klass.ValYearnumb = Convert.ToDecimal(value); } }

		[DisplayName("Previous year")]
		/// <summary>Field : "Previous year" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValYearprev")]
		[NumericAttribute(0)]
		public decimal? ValYearprev { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValYearprev, 0)); } set { klass.ValYearprev = Convert.ToDecimal(value); } }

		[DisplayName(">AGGREGATOR")]
		/// <summary>Field : ">AGGREGATOR" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValCodaggre")]
		public string ValCodaggre { get { return klass.ValCodaggre; } set { klass.ValCodaggre = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValDescript")]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValValue")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }

		[DisplayName("Previous value")]
		/// <summary>Field : "Previous value" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Expe1.ValPrevval")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrevval { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrevval, 2)); } set { klass.ValPrevval = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Expe1.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Expe1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAexpe1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Expe1(UserContext userContext, CSGenioAexpe1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Expe1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAexpe1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Expe1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Expe1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAexpe1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Expe1>((r) => new Expe1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL EXPE1]/
	}
}
