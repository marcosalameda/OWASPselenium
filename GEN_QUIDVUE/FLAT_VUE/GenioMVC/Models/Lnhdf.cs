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
	public class Lnhdf : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhdf klass { get { return baseklass as CSGenioAlnhdf; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Lnhdf.ValCodlnhdf")]
		public string ValCodlnhdf { get { return klass.ValCodlnhdf; } set { klass.ValCodlnhdf = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lnhdf.ValCodlnhde")]
		public string ValCodlnhde { get { return klass.ValCodlnhde; } set { klass.ValCodlnhde = value; } }

		private Lnhde _lnhde;
		[DisplayName("Lnhde")]
		[ShouldSerialize("Lnhde")]
		public virtual Lnhde Lnhde
		{
			get
			{
				if (!isEmptyModel && (_lnhde == null || (!string.IsNullOrEmpty(ValCodlnhde) && (_lnhde.isEmptyModel || _lnhde.klass.QPrimaryKey != ValCodlnhde))))
					_lnhde = Models.Lnhde.Find(ValCodlnhde, m_userContext, Identifier, _fieldsToSerialize);
				_lnhde ??= new Models.Lnhde(m_userContext, true, _fieldsToSerialize);
				return _lnhde;
			}
			set { _lnhde = value; }
		}

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Lnhdf.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Lnhdf.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Lnhdf(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAlnhdf(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhdf(UserContext userContext, CSGenioAlnhdf val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAlnhdf csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lnhde":
						_lnhde ??= new Lnhde(m_userContext, true, _fieldsToSerialize);
						_lnhde.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lnhdf Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhdf>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhdf(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Lnhdf> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhdf>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhdf>((r) => new Lnhdf(userCtx, r));
		}

// USE /[MANUAL GQT MODEL LNHDF]/
	}
}
