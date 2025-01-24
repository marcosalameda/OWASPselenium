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
	public class Gitem : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgitem klass { get { return baseklass as CSGenioAgitem; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Gitem.ValCodgitem")]
		public string ValCodgitem { get { return klass.ValCodgitem; } set { klass.ValCodgitem = value; } }

		[DisplayName("Global article")]
		/// <summary>Field : "Global article" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Gitem.ValItemdes")]
		public string ValItemdes { get { return klass.ValItemdes; } set { klass.ValItemdes = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Gitem.ValItemgcod")]
		public string ValItemgcod { get { return klass.ValItemgcod; } set { klass.ValItemgcod = value; } }

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Gitem.ValDocument")]
		[Document("ValDocument", true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Gitem.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Gitem(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAgitem(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Gitem(UserContext userContext, CSGenioAgitem val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAgitem csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Gitem Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgitem>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Gitem(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Gitem> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgitem>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Gitem>((r) => new Gitem(userCtx, r));
		}

// USE /[MANUAL GQT MODEL GITEM]/
	}
}
