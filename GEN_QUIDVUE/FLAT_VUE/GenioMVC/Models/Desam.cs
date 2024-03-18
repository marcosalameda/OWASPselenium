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
	public class Desam : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdesam klass { get { return baseklass as CSGenioAdesam; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValCoddesam")]
		public string ValCoddesam { get { return klass.ValCoddesam; } set { klass.ValCoddesam = value; } }

		[DisplayName("Start date")]
		/// <summary>Field : "Start date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValDtini")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtini { get { return klass.ValDtini; } set { klass.ValDtini = value ?? DateTime.MinValue; } }

		[DisplayName("End date")]
		/// <summary>Field : "End date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValDtfim")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtfim { get { return klass.ValDtfim; } set { klass.ValDtfim = value ?? DateTime.MinValue; } }

		[DisplayName("Observations")]
		/// <summary>Field : "Observations" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValObservat")]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValOperchng")]
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Desam.ValChngdate")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Desam.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Desam(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAdesam(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Desam(UserContext userContext, CSGenioAdesam val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAdesam csgenioa)
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
		public static Desam Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdesam>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Desam(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Desam> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdesam>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Desam>((r) => new Desam(userCtx, r));
		}

// USE /[MANUAL GQT MODEL DESAM]/
	}
}
