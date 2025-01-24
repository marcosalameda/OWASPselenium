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
	public class Manua : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmanua klass { get { return baseklass as CSGenioAmanua; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Manua.ValCodmanua")]
		public string ValCodmanua { get { return klass.ValCodmanua; } set { klass.ValCodmanua = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Manua.ValCodkinde")]
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		private Kinde _kinde;
		[DisplayName("Kinde")]
		[ShouldSerialize("Kinde")]
		public virtual Kinde Kinde {
			get {
				if (!this.isEmptyModel && (_kinde == null || (!string.IsNullOrEmpty(ValCodkinde) && (_kinde.isEmptyModel || _kinde.klass.QPrimaryKey != ValCodkinde))))
					_kinde = Models.Kinde.Find(ValCodkinde, m_userContext, Identifier, _fieldsToSerialize);
				if (_kinde == null)
					_kinde = new Models.Kinde(m_userContext, true, _fieldsToSerialize);
				return _kinde;
			}
			set { _kinde = value; }
		}


		[DisplayName("Manual name")]
		/// <summary>Field : "Manual name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manua.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Digital document")]
		/// <summary>Field : "Digital document" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Manua.ValDigdocum")]
		[Document("ValDigdocum", true, false, false)]
		public string ValDigdocum { get { return klass.ValDigdocum; } set { klass.ValDigdocum = value; } }
		public string ValDigdocumfk { get { return klass.ValDigdocumfk; } set { klass.ValDigdocumfk = value; } }

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Manua.ValNotes")]
		[DataType(DataType.MultilineText)]
		public string ValNotes { get { return klass.ValNotes; } set { klass.ValNotes = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Manua.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Manua(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmanua(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Manua(UserContext userContext, CSGenioAmanua val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAmanua csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "kinde":
						if (_kinde == null)
							_kinde = new Kinde(m_userContext, true, _fieldsToSerialize);
						_kinde.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Manua Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmanua>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Manua(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Manua> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmanua>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Manua>((r) => new Manua(userCtx, r));
		}

// USE /[MANUAL GQT MODEL MANUA]/
	}
}
