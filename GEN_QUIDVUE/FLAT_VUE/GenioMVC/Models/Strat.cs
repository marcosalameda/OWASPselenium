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
	public class Strat : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstrat klass { get { return baseklass as CSGenioAstrat; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValCodestra")]
		public string ValCodestra { get { return klass.ValCodestra; } set { klass.ValCodestra = value; } }

		[DisplayName("Strategy")]
		/// <summary>Field : "Strategy" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValEstrateg")]
		public string ValEstrateg { get { return klass.ValEstrateg; } set { klass.ValEstrateg = value; } }

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValChngdate")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValOperchng")]
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Strat.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Strat.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Strat(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAstrat(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Strat(UserContext userContext, CSGenioAstrat val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAstrat csgenioa)
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
		public static Strat Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstrat>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Strat(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Strat> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstrat>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Strat>((r) => new Strat(userCtx, r));
		}

// USE /[MANUAL GQT MODEL STRAT]/
	}
}
