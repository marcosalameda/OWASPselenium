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
	public class Tabpr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtabpr klass { get { return baseklass as CSGenioAtabpr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tabpr.ValCodtabpr")]
		public string ValCodtabpr { get { return klass.ValCodtabpr; } set { klass.ValCodtabpr = value; } }

		[DisplayName(">TYPE OF EQUIPMENT")]
		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tabpr.ValCodtpeq1")]
		public string ValCodtpeq1 { get { return klass.ValCodtpeq1; } set { klass.ValCodtpeq1 = value; } }

		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		[ShouldSerialize("Tpequ")]
		public virtual Tpequ Tpequ
		{
			get
			{
				if (!isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpeq1) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpeq1))))
					_tpequ = Models.Tpequ.Find(ValCodtpeq1, m_userContext, Identifier, _fieldsToSerialize);
				_tpequ ??= new Models.Tpequ(m_userContext, true, _fieldsToSerialize);
				return _tpequ;
			}
			set { _tpequ = value; }
		}

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Tabpr.ValSince")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }

		[DisplayName("Price-by-hour")]
		/// <summary>Field : "Price-by-hour" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Tabpr.ValPrecohor")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecohor { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecohor, 2)); } set { klass.ValPrecohor = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tabpr.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tabpr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtabpr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tabpr(UserContext userContext, CSGenioAtabpr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtabpr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
						_tpequ ??= new Tpequ(m_userContext, true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tabpr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtabpr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tabpr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tabpr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtabpr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tabpr>((r) => new Tabpr(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TABPR]/
	}
}
