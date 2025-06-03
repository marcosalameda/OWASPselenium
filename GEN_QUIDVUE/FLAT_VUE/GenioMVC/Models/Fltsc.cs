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
	public class Fltsc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfltsc klass { get { return baseklass as CSGenioAfltsc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Fltsc.ValCodfltsc")]
		public string ValCodfltsc { get { return klass.ValCodfltsc; } set { klass.ValCodfltsc = value; } }

		[DisplayName("Scale ID")]
		/// <summary>Field : "Scale ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Fltsc.ValScaleid")]
		[NumericAttribute(0)]
		public decimal? ValScaleid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValScaleid, 0)); } set { klass.ValScaleid = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fltsc.ValCodfligh")]
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }

		private Fligh _fligh;
		[DisplayName("Fligh")]
		[ShouldSerialize("Fligh")]
		public virtual Fligh Fligh
		{
			get
			{
				if (!isEmptyModel && (_fligh == null || (!string.IsNullOrEmpty(ValCodfligh) && (_fligh.isEmptyModel || _fligh.klass.QPrimaryKey != ValCodfligh))))
					_fligh = Models.Fligh.Find(ValCodfligh, m_userContext, Identifier, _fieldsToSerialize);
				_fligh ??= new Models.Fligh(m_userContext, true, _fieldsToSerialize);
				return _fligh;
			}
			set { _fligh = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Fltsc.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Fltsc(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfltsc(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fltsc(UserContext userContext, CSGenioAfltsc val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAfltsc csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fligh":
						_fligh ??= new Fligh(m_userContext, true, _fieldsToSerialize);
						_fligh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Fltsc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfltsc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Fltsc(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Fltsc> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfltsc>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Fltsc>((r) => new Fltsc(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FLTSC]/
	}
}
