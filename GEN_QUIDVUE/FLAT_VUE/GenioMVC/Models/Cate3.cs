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
	public class Cate3 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcate3 klass { get { return baseklass as CSGenioAcate3; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Cate3.ValCodcateg")]
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }

		[DisplayName("Technical category")]
		/// <summary>Field : "Technical category" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cate3.ValCategoria")]
		public string ValCategoria { get { return klass.ValCategoria; } set { klass.ValCategoria = value; } }

		[DisplayName("Abbreviation")]
		/// <summary>Field : "Abbreviation" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cate3.ValAbbreviation")]
		public string ValAbbreviation { get { return klass.ValAbbreviation; } set { klass.ValAbbreviation = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Cate3.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Cate3(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcate3(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Cate3(UserContext userContext, CSGenioAcate3 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAcate3 csgenioa)
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
		public static Cate3 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcate3>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cate3(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Cate3> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcate3>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cate3>((r) => new Cate3(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CATE3]/
	}
}
