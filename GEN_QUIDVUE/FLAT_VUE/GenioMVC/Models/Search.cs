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
	public class Search : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsearch klass { get { return baseklass as CSGenioAsearch; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Search.ValCodsearch")]
		public string ValCodsearch { get { return klass.ValCodsearch; } set { klass.ValCodsearch = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Search.ValCodpais")]
		public string ValCodpais { get { return klass.ValCodpais; } set { klass.ValCodpais = value; } }

		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry
		{
			get
			{
				if (!isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodpais) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodpais))))
					_cntry = Models.Cntry.Find(ValCodpais, m_userContext, Identifier, _fieldsToSerialize);
				_cntry ??= new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Search.ValCodregia")]
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }

		private Regio _regio;
		[DisplayName("Regio")]
		[ShouldSerialize("Regio")]
		public virtual Regio Regio
		{
			get
			{
				if (!isEmptyModel && (_regio == null || (!string.IsNullOrEmpty(ValCodregia) && (_regio.isEmptyModel || _regio.klass.QPrimaryKey != ValCodregia))))
					_regio = Models.Regio.Find(ValCodregia, m_userContext, Identifier, _fieldsToSerialize);
				_regio ??= new Models.Regio(m_userContext, true, _fieldsToSerialize);
				return _regio;
			}
			set { _regio = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Search.ValHkey")]
		public string ValHkey { get { return klass.ValHkey; } set { klass.ValHkey = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Search.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Search(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAsearch(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Search(UserContext userContext, CSGenioAsearch val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAsearch csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						_cntry ??= new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "regio":
						_regio ??= new Regio(m_userContext, true, _fieldsToSerialize);
						_regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Search Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsearch>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Search(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Search> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsearch>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Search>((r) => new Search(userCtx, r));
		}

// USE /[MANUAL GQT MODEL SEARCH]/
	}
}
