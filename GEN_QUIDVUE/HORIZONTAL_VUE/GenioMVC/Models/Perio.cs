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
	public class Perio : ModelBase
	{
		[JsonIgnore]
		public CSGenioAperio klass { get { return baseklass as CSGenioAperio; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Perio.ValCodperio")]
		public string ValCodperio { get { return klass.ValCodperio; } set { klass.ValCodperio = value; } }

		[DisplayName("Period Start")]
		/// <summary>Field : "Period Start" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Perio.ValPeriodstart")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPeriodstart { get { return klass.ValPeriodstart; } set { klass.ValPeriodstart = value ?? DateTime.MinValue; } }

		[DisplayName("Period End")]
		/// <summary>Field : "Period End" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Perio.ValPeriodend")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPeriodend { get { return klass.ValPeriodend; } set { klass.ValPeriodend = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Perio.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Perio(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAperio(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Perio(UserContext userContext, CSGenioAperio val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAperio csgenioa)
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
		public static Perio Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAperio>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Perio(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Perio> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAperio>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Perio>((r) => new Perio(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PERIO]/
	}
}
