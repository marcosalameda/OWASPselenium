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
	public class Lnhde : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhde klass { get { return baseklass as CSGenioAlnhde; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValCodlnhde")]
		public string ValCodlnhde { get { return klass.ValCodlnhde; } set { klass.ValCodlnhde = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValCodlnhpd")]
		public string ValCodlnhpd { get { return klass.ValCodlnhpd; } set { klass.ValCodlnhpd = value; } }

		private Lnhpd _lnhpd;
		[DisplayName("Lnhpd")]
		[ShouldSerialize("Lnhpd")]
		public virtual Lnhpd Lnhpd
		{
			get
			{
				if (!isEmptyModel && (_lnhpd == null || (!string.IsNullOrEmpty(ValCodlnhpd) && (_lnhpd.isEmptyModel || _lnhpd.klass.QPrimaryKey != ValCodlnhpd))))
					_lnhpd = Models.Lnhpd.Find(ValCodlnhpd, m_userContext, Identifier, _fieldsToSerialize);
				_lnhpd ??= new Models.Lnhpd(m_userContext, true, _fieldsToSerialize);
				return _lnhpd;
			}
			set { _lnhpd = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: ++ "[LNHPD->CODPEDID]"</summary>
		[ShouldSerialize("Lnhde.ValCodpedid")]
		public string ValCodpedid { get { return klass.ValCodpedid; } set { klass.ValCodpedid = value; } }

		private Pedid _pedid;
		[DisplayName("Pedid")]
		[ShouldSerialize("Pedid")]
		public virtual Pedid Pedid
		{
			get
			{
				if (!isEmptyModel && (_pedid == null || (!string.IsNullOrEmpty(ValCodpedid) && (_pedid.isEmptyModel || _pedid.klass.QPrimaryKey != ValCodpedid))))
					_pedid = Models.Pedid.Find(ValCodpedid, m_userContext, Identifier, _fieldsToSerialize);
				_pedid ??= new Models.Pedid(m_userContext, true, _fieldsToSerialize);
				return _pedid;
			}
			set { _pedid = value; }
		}

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValOrdem")]
		[NumericAttribute(0)]
		public decimal? ValOrdem { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrdem, 0)); } set { klass.ValOrdem = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }

		private Tpeq1 _tpeq1;
		[DisplayName("Tpeq1")]
		[ShouldSerialize("Tpeq1")]
		public virtual Tpeq1 Tpeq1
		{
			get
			{
				if (!isEmptyModel && (_tpeq1 == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpeq1.isEmptyModel || _tpeq1.klass.QPrimaryKey != ValCodtpequ))))
					_tpeq1 = Models.Tpeq1.Find(ValCodtpequ, m_userContext, Identifier, _fieldsToSerialize);
				_tpeq1 ??= new Models.Tpeq1(m_userContext, true, _fieldsToSerialize);
				return _tpeq1;
			}
			set { _tpeq1 = value; }
		}

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValQuantida")]
		[NumericAttribute(0)]
		public decimal? ValQuantida { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantida, 0)); } set { klass.ValQuantida = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValCodlnhag")]
		public string ValCodlnhag { get { return klass.ValCodlnhag; } set { klass.ValCodlnhag = value; } }

		private Lnhag _lnhag;
		[DisplayName("Lnhag")]
		[ShouldSerialize("Lnhag")]
		public virtual Lnhag Lnhag
		{
			get
			{
				if (!isEmptyModel && (_lnhag == null || (!string.IsNullOrEmpty(ValCodlnhag) && (_lnhag.isEmptyModel || _lnhag.klass.QPrimaryKey != ValCodlnhag))))
					_lnhag = Models.Lnhag.Find(ValCodlnhag, m_userContext, Identifier, _fieldsToSerialize);
				_lnhag ??= new Models.Lnhag(m_userContext, true, _fieldsToSerialize);
				return _lnhag;
			}
			set { _lnhag = value; }
		}

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValCode")]
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }

		[DisplayName("Site")]
		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Lnhde.ValUrl")]
		[HyperLink]
		public string ValUrl { get { return klass.ValUrl; } set { klass.ValUrl = value; } }

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "ND" Formula: DF "[LNHPD->QUANTDEC]"</summary>
		[ShouldSerialize("Lnhde.ValQuantdec")]
		[NumericAttribute(2)]
		public decimal? ValQuantdec { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantdec, 2)); } set { klass.ValQuantdec = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Lnhde.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Lnhde(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAlnhde(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhde(UserContext userContext, CSGenioAlnhde val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAlnhde csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lnhpd":
						_lnhpd ??= new Lnhpd(m_userContext, true, _fieldsToSerialize);
						_lnhpd.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pedid":
						_pedid ??= new Pedid(m_userContext, true, _fieldsToSerialize);
						_pedid.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpeq1":
						_tpeq1 ??= new Tpeq1(m_userContext, true, _fieldsToSerialize);
						_tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "lnhag":
						_lnhag ??= new Lnhag(m_userContext, true, _fieldsToSerialize);
						_lnhag.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lnhde Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhde>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhde(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Lnhde> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhde>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhde>((r) => new Lnhde(userCtx, r));
		}

// USE /[MANUAL GQT MODEL LNHDE]/
	}
}
