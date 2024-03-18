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
	public class Speci : ModelBase
	{
		[JsonIgnore]
		public CSGenioAspeci klass { get { return baseklass as CSGenioAspeci; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Speci.ValCodespec")]
		public string ValCodespec { get { return klass.ValCodespec; } set { klass.ValCodespec = value; } }

		[DisplayName("Specialty")]
		/// <summary>Field : "Specialty" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Speci.ValEspecial")]
		public string ValEspecial { get { return klass.ValEspecial; } set { klass.ValEspecial = value; } }

		[DisplayName("Technical area")]
		/// <summary>Field : "Technical area" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Speci.ValAreatecn")]
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAreatecn { get { return klass.ValAreatecn; } set { klass.ValAreatecn = value; } }
		[JsonIgnore]
		public SelectList ArrayValareatecn { get { return new SelectList(CSGenio.business.ArrayAreatecn.GetDictionary(), "Key", "Value", ValAreatecn); } set { ValAreatecn = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Speci.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Speci(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAspeci(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Speci(UserContext userContext, CSGenioAspeci val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAspeci csgenioa)
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
		public static Speci Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAspeci>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Speci(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Speci> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAspeci>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Speci>((r) => new Speci(userCtx, r));
		}

// USE /[MANUAL GQT MODEL SPECI]/
	}
}
