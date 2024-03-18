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
	public class Teamp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAteamp klass { get { return baseklass as CSGenioAteamp; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Teamp.ValCodeqjog")]
		public string ValCodeqjog { get { return klass.ValCodeqjog; } set { klass.ValCodeqjog = value; } }

		[DisplayName("Team")]
		/// <summary>Field : "Team" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Teamp.ValEquipa")]
		public string ValEquipa { get { return klass.ValEquipa; } set { klass.ValEquipa = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Teamp.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Teamp(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAteamp(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Teamp(UserContext userContext, CSGenioAteamp val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAteamp csgenioa)
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
		public static Teamp Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAteamp>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Teamp(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Teamp> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAteamp>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Teamp>((r) => new Teamp(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TEAMP]/
	}
}
