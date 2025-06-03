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
	public class Tradu : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtradu klass { get { return baseklass as CSGenioAtradu; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tradu.ValCodtradu")]
		public string ValCodtradu { get { return klass.ValCodtradu; } set { klass.ValCodtradu = value; } }

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tradu.ValReferenc")]
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }

		[DisplayName("language")]
		/// <summary>Field : "language" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tradu.ValCodidio1")]
		public string ValCodidio1 { get { return klass.ValCodidio1; } set { klass.ValCodidio1 = value; } }

		private Lang1 _lang1;
		[DisplayName("Lang1")]
		[ShouldSerialize("Lang1")]
		public virtual Lang1 Lang1
		{
			get
			{
				if (!isEmptyModel && (_lang1 == null || (!string.IsNullOrEmpty(ValCodidio1) && (_lang1.isEmptyModel || _lang1.klass.QPrimaryKey != ValCodidio1))))
					_lang1 = Models.Lang1.Find(ValCodidio1, m_userContext, Identifier, _fieldsToSerialize);
				_lang1 ??= new Models.Lang1(m_userContext, true, _fieldsToSerialize);
				return _lang1;
			}
			set { _lang1 = value; }
		}

		[DisplayName("To review")]
		/// <summary>Field : "To review" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tradu.ValAtraduzi")]
		public string ValAtraduzi { get { return klass.ValAtraduzi; } set { klass.ValAtraduzi = value; } }

		[DisplayName("Language")]
		/// <summary>Field : "Language" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tradu.ValCodidio2")]
		public string ValCodidio2 { get { return klass.ValCodidio2; } set { klass.ValCodidio2 = value; } }

		private Lang2 _lang2;
		[DisplayName("Lang2")]
		[ShouldSerialize("Lang2")]
		public virtual Lang2 Lang2
		{
			get
			{
				if (!isEmptyModel && (_lang2 == null || (!string.IsNullOrEmpty(ValCodidio2) && (_lang2.isEmptyModel || _lang2.klass.QPrimaryKey != ValCodidio2))))
					_lang2 = Models.Lang2.Find(ValCodidio2, m_userContext, Identifier, _fieldsToSerialize);
				_lang2 ??= new Models.Lang2(m_userContext, true, _fieldsToSerialize);
				return _lang2;
			}
			set { _lang2 = value; }
		}

		[DisplayName("Translated")]
		/// <summary>Field : "Translated" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tradu.ValTraduzid")]
		public string ValTraduzid { get { return klass.ValTraduzid; } set { klass.ValTraduzid = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tradu.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tradu(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtradu(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tradu(UserContext userContext, CSGenioAtradu val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtradu csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lang1":
						_lang1 ??= new Lang1(m_userContext, true, _fieldsToSerialize);
						_lang1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "lang2":
						_lang2 ??= new Lang2(m_userContext, true, _fieldsToSerialize);
						_lang2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tradu Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtradu>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tradu(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tradu> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtradu>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tradu>((r) => new Tradu(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TRADU]/
	}
}
