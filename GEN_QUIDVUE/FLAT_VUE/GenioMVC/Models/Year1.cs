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
	public class Year1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAyear1 klass { get { return baseklass as CSGenioAyear1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Year1.ValCodyear")]
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Year1.ValYear")]
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Year1.ValValue")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }

		[DisplayName("Year (numbers)")]
		/// <summary>Field : "Year (numbers)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Year1.ValYearnum")]
		[NumericAttribute(0)]
		public decimal? ValYearnum { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYearnum, 0)); } set { klass.ValYearnum = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Year1.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Year1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAyear1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Year1(UserContext userContext, CSGenioAyear1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAyear1 csgenioa)
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
		public static Year1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAyear1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Year1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Year1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAyear1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Year1>((r) => new Year1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL YEAR1]/
	}
}
