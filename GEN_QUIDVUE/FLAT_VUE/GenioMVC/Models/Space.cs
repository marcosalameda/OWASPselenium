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
	public class Space : ModelBase
	{
		[JsonIgnore]
		public CSGenioAspace klass { get { return baseklass as CSGenioAspace; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Space.ValCodespac")]
		public string ValCodespac { get { return klass.ValCodespac; } set { klass.ValCodespac = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		[ShouldSerialize("Space.ValCode")]
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Space.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Space.ValSigla")]
		public string ValSigla { get { return klass.ValSigla; } set { klass.ValSigla = value; } }

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		[ShouldSerialize("Space.ValNivel")]
		public double ValNivel { get { return klass.ValNivel; } set { klass.ValNivel = value; } }

		[DisplayName("Dependency")]
		/// <summary>Field : "Dependency" Tipo: "TP" Formula:  ""</summary>
		[ShouldSerialize("Space.ValCodigode")]
		public string ValCodigode { get { return klass.ValCodigode; } set { klass.ValCodigode = value; } }

		[DisplayName("Moving")]
		/// <summary>Field : "Moving" Tipo: "TM" Formula:  ""</summary>
		[ShouldSerialize("Space.ValMoviment")]
		public bool ValMoviment { get { return Convert.ToBoolean(klass.ValMoviment); } set { klass.ValMoviment = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Space.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Space(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAspace(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Space(UserContext userContext, CSGenioAspace val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAspace csgenioa)
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
		public static Space Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAspace>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Space(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Space> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAspace>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Space>((r) => new Space(userCtx, r));
		}

// USE /[MANUAL GQT MODEL SPACE]/
	}
}
