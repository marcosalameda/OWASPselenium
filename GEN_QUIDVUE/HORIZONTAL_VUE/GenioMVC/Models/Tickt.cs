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
	public class Tickt : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtickt klass { get { return baseklass as CSGenioAtickt; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tickt.ValCodtickt")]
		public string ValCodtickt { get { return klass.ValCodtickt; } set { klass.ValCodtickt = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tickt.ValCodpsngr")]
		public string ValCodpsngr { get { return klass.ValCodpsngr; } set { klass.ValCodpsngr = value; } }

		private Psngr _psngr;
		[DisplayName("Psngr")]
		[ShouldSerialize("Psngr")]
		public virtual Psngr Psngr
		{
			get
			{
				if (!isEmptyModel && (_psngr == null || (!string.IsNullOrEmpty(ValCodpsngr) && (_psngr.isEmptyModel || _psngr.klass.QPrimaryKey != ValCodpsngr))))
					_psngr = Models.Psngr.Find(ValCodpsngr, m_userContext, Identifier, _fieldsToSerialize);
				_psngr ??= new Models.Psngr(m_userContext, true, _fieldsToSerialize);
				return _psngr;
			}
			set { _psngr = value; }
		}

		[DisplayName("Ticket ID")]
		/// <summary>Field : "Ticket ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Tickt.ValTktid")]
		[NumericAttribute(0)]
		public decimal? ValTktid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTktid, 0)); } set { klass.ValTktid = Convert.ToDecimal(value); } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Tickt.ValPrice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tickt.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tickt(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtickt(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tickt(UserContext userContext, CSGenioAtickt val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtickt csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "psngr":
						_psngr ??= new Psngr(m_userContext, true, _fieldsToSerialize);
						_psngr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tickt Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtickt>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tickt(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tickt> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtickt>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tickt>((r) => new Tickt(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TICKT]/
	}
}
