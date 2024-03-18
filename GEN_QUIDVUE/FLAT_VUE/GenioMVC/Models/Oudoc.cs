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
	public class Oudoc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoudoc klass { get { return baseklass as CSGenioAoudoc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Oudoc.ValCoddocsd")]
		public string ValCoddocsd { get { return klass.ValCoddocsd; } set { klass.ValCoddocsd = value; } }

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Oudoc.ValNrdocsda")]
		[NumericAttribute(0)]
		public decimal? ValNrdocsda { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrdocsda, 0)); } set { klass.ValNrdocsda = Convert.ToDouble(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Oudoc.ValDtdocsda")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtdocsda { get { return klass.ValDtdocsda; } set { klass.ValDtdocsda = value ?? DateTime.MinValue; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Oudoc.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Oudoc.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Oudoc(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAoudoc(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Oudoc(UserContext userContext, CSGenioAoudoc val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAoudoc csgenioa)
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
		public static Oudoc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoudoc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Oudoc(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Oudoc> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoudoc>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Oudoc>((r) => new Oudoc(userCtx, r));
		}

// USE /[MANUAL GQT MODEL OUDOC]/
	}
}
