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
	public class Feeca : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfeeca klass { get { return baseklass as CSGenioAfeeca; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Feeca.ValCodfeeca")]
		public string ValCodfeeca { get { return klass.ValCodfeeca; } set { klass.ValCodfeeca = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Feeca.ValCodflds")]
		public string ValCodflds { get { return klass.ValCodflds; } set { klass.ValCodflds = value; } }
		private Flds _flds;
		[DisplayName("Flds")]
		[ShouldSerialize("Flds")]
		public virtual Flds Flds {
			get {
				if (!this.isEmptyModel && (_flds == null || (!string.IsNullOrEmpty(ValCodflds) && (_flds.isEmptyModel || _flds.klass.QPrimaryKey != ValCodflds))))
					_flds = Models.Flds.Find(ValCodflds, m_userContext, Identifier, _fieldsToSerialize);
				if (_flds == null)
					_flds = new Models.Flds(m_userContext, true, _fieldsToSerialize);
				return _flds;
			}
			set { _flds = value; }
		}


		[DisplayName("Feedback")]
		/// <summary>Field : "Feedback" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Feeca.ValFeedback")]
		public string ValFeedback { get { return klass.ValFeedback; } set { klass.ValFeedback = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Feeca.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Feeca(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfeeca(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Feeca(UserContext userContext, CSGenioAfeeca val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAfeeca csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "flds":
						if (_flds == null)
							_flds = new Flds(m_userContext, true, _fieldsToSerialize);
						_flds.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Feeca Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfeeca>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Feeca(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Feeca> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfeeca>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Feeca>((r) => new Feeca(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FEECA]/
	}
}
