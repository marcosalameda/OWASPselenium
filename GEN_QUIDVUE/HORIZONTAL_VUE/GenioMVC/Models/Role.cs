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
	public class Role : ModelBase
	{
		[JsonIgnore]
		public CSGenioArole klass { get { return baseklass as CSGenioArole; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Role.ValCodrole")]
		public string ValCodrole { get { return klass.ValCodrole; } set { klass.ValCodrole = value; } }

		[DisplayName("Team")]
		/// <summary>Field : "Team" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Role.ValRolename")]
		public string ValRolename { get { return klass.ValRolename; } set { klass.ValRolename = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Role.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Role(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArole(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Role(UserContext userContext, CSGenioArole val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioArole csgenioa)
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
		public static Role Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArole>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Role(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Role> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArole>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Role>((r) => new Role(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ROLE]/
	}
}
