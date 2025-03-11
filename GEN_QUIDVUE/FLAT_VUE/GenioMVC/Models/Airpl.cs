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
	public class Airpl : ModelBase
	{
		[JsonIgnore]
		public CSGenioAairpl klass { get { return baseklass as CSGenioAairpl; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Airpl.ValCodairpl")]
		public string ValCodairpl { get { return klass.ValCodairpl; } set { klass.ValCodairpl = value; } }

		[DisplayName("Airplane ID")]
		/// <summary>Field : "Airplane ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Airpl.ValAirplid")]
		[NumericAttribute(0)]
		public decimal? ValAirplid { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValAirplid, 0)); } set { klass.ValAirplid = Convert.ToDecimal(value); } }

		[DisplayName("Airplane Name")]
		/// <summary>Field : "Airplane Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Airpl.ValAirplnm")]
		public string ValAirplnm { get { return klass.ValAirplnm; } set { klass.ValAirplnm = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Airpl.ValAirpdsc")]
		[DataType(DataType.MultilineText)]
		public string ValAirpdsc { get { return klass.ValAirpdsc; } set { klass.ValAirpdsc = value; } }

		[DisplayName("Seating Capacity")]
		/// <summary>Field : "Seating Capacity" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Airpl.ValSeatcap")]
		[NumericAttribute(0)]
		public decimal? ValSeatcap { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSeatcap, 0)); } set { klass.ValSeatcap = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Airpl.ValCodairln")]
		public string ValCodairln { get { return klass.ValCodairln; } set { klass.ValCodairln = value; } }

		private Airln _airln;
		[DisplayName("Airln")]
		[ShouldSerialize("Airln")]
		public virtual Airln Airln
		{
			get
			{
				if (!isEmptyModel && (_airln == null || (!string.IsNullOrEmpty(ValCodairln) && (_airln.isEmptyModel || _airln.klass.QPrimaryKey != ValCodairln))))
					_airln = Models.Airln.Find(ValCodairln, m_userContext, Identifier, _fieldsToSerialize);
				_airln ??= new Models.Airln(m_userContext, true, _fieldsToSerialize);
				return _airln;
			}
			set { _airln = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Airpl.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Airpl(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAairpl(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Airpl(UserContext userContext, CSGenioAairpl val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAairpl csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "airln":
						_airln ??= new Airln(m_userContext, true, _fieldsToSerialize);
						_airln.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Airpl Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAairpl>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Airpl(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Airpl> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAairpl>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Airpl>((r) => new Airpl(userCtx, r));
		}

// USE /[MANUAL GQT MODEL AIRPL]/
	}
}
