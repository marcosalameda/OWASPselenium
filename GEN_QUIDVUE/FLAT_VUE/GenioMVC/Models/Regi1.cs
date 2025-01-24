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
	public class Regi1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAregi1 klass { get { return baseklass as CSGenioAregi1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Regi1.ValCodregia")]
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Regi1.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		private Pais1 _pais1;
		[DisplayName("Pais1")]
		[ShouldSerialize("Pais1")]
		public virtual Pais1 Pais1 {
			get {
				if (!this.isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodcntry) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodcntry))))
					_pais1 = Models.Pais1.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				if (_pais1 == null)
					_pais1 = new Models.Pais1(m_userContext, true, _fieldsToSerialize);
				return _pais1;
			}
			set { _pais1 = value; }
		}


		[DisplayName("Region")]
		/// <summary>Field : "Region" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Regi1.ValRegiao")]
		public string ValRegiao { get { return klass.ValRegiao; } set { klass.ValRegiao = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Regi1.ValCodpais1")]
		public string ValCodpais1 { get { return klass.ValCodpais1; } set { klass.ValCodpais1 = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Regi1.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Regi1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAregi1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Regi1(UserContext userContext, CSGenioAregi1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAregi1 csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pais1":
						if (_pais1 == null)
							_pais1 = new Pais1(m_userContext, true, _fieldsToSerialize);
						_pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Regi1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAregi1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Regi1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Regi1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAregi1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Regi1>((r) => new Regi1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL REGI1]/
	}
}
