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
	public class Decom : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdecom klass { get { return baseklass as CSGenioAdecom; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValCoddeco")]
		public string ValCoddeco { get { return klass.ValCoddeco; } set { klass.ValCoddeco = value; } }

		[DisplayName("Decomission")]
		/// <summary>Field : "Decomission" Tipo: "DT" Formula: DF "[Now]"</summary>
		[ShouldSerialize("Decom.ValDtdeco")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtdeco { get { return klass.ValDtdeco; } set { klass.ValDtdeco = value ?? DateTime.MinValue; } }

		[DisplayName("No bate")]
		/// <summary>Field : "No bate" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValDecomnr")]
		[NumericAttribute(0)]
		public decimal? ValDecomnr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDecomnr, 0)); } set { klass.ValDecomnr = Convert.ToDouble(value); } }

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValNote")]
		[DataType(DataType.MultilineText)]
		public string ValNote { get { return klass.ValNote; } set { klass.ValNote = value; } }

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValChngdate")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Decom.ValOperchng")]
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Decom.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Decom(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAdecom(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Decom(UserContext userContext, CSGenioAdecom val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAdecom csgenioa)
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
		public static Decom Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdecom>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Decom(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Decom> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdecom>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Decom>((r) => new Decom(userCtx, r));
		}

// USE /[MANUAL GQT MODEL DECOM]/
	}
}
