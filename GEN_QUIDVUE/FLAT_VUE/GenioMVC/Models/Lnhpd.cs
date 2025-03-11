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
	public class Lnhpd : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhpd klass { get { return baseklass as CSGenioAlnhpd; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Lnhpd.ValCodlnhpd")]
		public string ValCodlnhpd { get { return klass.ValCodlnhpd; } set { klass.ValCodlnhpd = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lnhpd.ValCodpedid")]
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

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Lnhpd.ValLine")]
		[NumericAttribute(0)]
		public decimal? ValLine { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLine, 0)); } set { klass.ValLine = Convert.ToDecimal(value); } }

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lnhpd.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }

		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		[ShouldSerialize("Tpequ")]
		public virtual Tpequ Tpequ
		{
			get
			{
				if (!isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ))))
					_tpequ = Models.Tpequ.Find(ValCodtpequ, m_userContext, Identifier, _fieldsToSerialize);
				_tpequ ??= new Models.Tpequ(m_userContext, true, _fieldsToSerialize);
				return _tpequ;
			}
			set { _tpequ = value; }
		}

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Lnhpd.ValQuantida")]
		[NumericAttribute(0)]
		public decimal? ValQuantida { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantida, 0)); } set { klass.ValQuantida = Convert.ToDecimal(value); } }

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Lnhpd.ValQuantdec")]
		[NumericAttribute(2)]
		public decimal? ValQuantdec { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantdec, 2)); } set { klass.ValQuantdec = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Lnhpd.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Lnhpd(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAlnhpd(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhpd(UserContext userContext, CSGenioAlnhpd val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAlnhpd csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pedid":
						_pedid ??= new Pedid(m_userContext, true, _fieldsToSerialize);
						_pedid.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Lnhpd Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhpd>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhpd(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Lnhpd> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhpd>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhpd>((r) => new Lnhpd(userCtx, r));
		}

		public StatusMessage carga_CONJUNTO(string idsrc)
		{
			User u = m_userContext.User;
			PersistentSupport sp = m_userContext.PersistentSupport;
			StatusMessage Qresult = this.klass.carga_CONJUNTO(idsrc,sp,u);

			return Qresult;
		}

// USE /[MANUAL GQT MODEL LNHPD]/
	}
}
