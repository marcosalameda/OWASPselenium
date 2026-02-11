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
	public class Compb : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcompb klass { get { return baseklass as CSGenioAcompb; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Compb.ValCodcompb")]
		public string ValCodcompb { get { return klass.ValCodcompb; } set { klass.ValCodcompb = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Compb.ValCodcompo")]
		public string ValCodcompo { get { return klass.ValCodcompo; } set { klass.ValCodcompo = value; } }

		private Compo _compo;
		[DisplayName("Compo")]
		[ShouldSerialize("Compo")]
		public virtual Compo Compo
		{
			get
			{
				if (!isEmptyModel && (_compo == null || (!string.IsNullOrEmpty(ValCodcompo) && (_compo.isEmptyModel || _compo.klass.QPrimaryKey != ValCodcompo))))
					_compo = Models.Compo.Find(ValCodcompo, m_userContext, Identifier, _fieldsToSerialize);
				_compo ??= new Models.Compo(m_userContext, true, _fieldsToSerialize);
				return _compo;
			}
			set { _compo = value; }
		}

		[DisplayName("Behavior")]
		/// <summary>Field : "Behavior" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compb.ValCmpbehav")]
		[DataType(DataType.MultilineText)]
		public string ValCmpbehav { get { return klass.ValCmpbehav; } set { klass.ValCmpbehav = value; } }

		[DisplayName("Interaction")]
		/// <summary>Field : "Interaction" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Compb.ValCompint")]
		public string ValCompint { get { return klass.ValCompint; } set { klass.ValCompint = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Compb.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Compb(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcompb(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compb(UserContext userContext, CSGenioAcompb val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcompb csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "compo":
						_compo ??= new Compo(m_userContext, true, _fieldsToSerialize);
						_compo.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Compb Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcompb>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Compb(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Compb> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcompb>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Compb>((r) => new Compb(userCtx, r));
		}

// USE /[MANUAL GQT MODEL COMPB]/
	}
}
