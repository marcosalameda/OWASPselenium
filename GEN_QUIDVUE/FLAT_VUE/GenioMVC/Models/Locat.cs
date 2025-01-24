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
	public class Locat : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlocat klass { get { return baseklass as CSGenioAlocat; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Locat.ValCodlocat")]
		public string ValCodlocat { get { return klass.ValCodlocat; } set { klass.ValCodlocat = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Locat.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		private Entit _entit;
		[DisplayName("Entit")]
		[ShouldSerialize("Entit")]
		public virtual Entit Entit {
			get {
				if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit))))
					_entit = Models.Entit.Find(ValCodentit, m_userContext, Identifier, _fieldsToSerialize);
				if (_entit == null)
					_entit = new Models.Entit(m_userContext, true, _fieldsToSerialize);
				return _entit;
			}
			set { _entit = value; }
		}


		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Locat.ValCodfacil")]
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }
		private Facil _facil;
		[DisplayName("Facil")]
		[ShouldSerialize("Facil")]
		public virtual Facil Facil {
			get {
				if (!this.isEmptyModel && (_facil == null || (!string.IsNullOrEmpty(ValCodfacil) && (_facil.isEmptyModel || _facil.klass.QPrimaryKey != ValCodfacil))))
					_facil = Models.Facil.Find(ValCodfacil, m_userContext, Identifier, _fieldsToSerialize);
				if (_facil == null)
					_facil = new Models.Facil(m_userContext, true, _fieldsToSerialize);
				return _facil;
			}
			set { _facil = value; }
		}


		[DisplayName("Global Location Number")]
		/// <summary>Field : "Global Location Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Locat.ValGln")]
		public string ValGln { get { return klass.ValGln; } set { klass.ValGln = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Locat.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Locat(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAlocat(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Locat(UserContext userContext, CSGenioAlocat val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAlocat csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entit":
						if (_entit == null)
							_entit = new Entit(m_userContext, true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "facil":
						if (_facil == null)
							_facil = new Facil(m_userContext, true, _fieldsToSerialize);
						_facil.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Locat Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlocat>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Locat(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Locat> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlocat>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Locat>((r) => new Locat(userCtx, r));
		}

// USE /[MANUAL GQT MODEL LOCAT]/
	}
}
