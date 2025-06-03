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
	public class Pedid : ModelBase
	{
		[JsonIgnore]
		public CSGenioApedid klass { get { return baseklass as CSGenioApedid; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Pedid.ValCodpedid")]
		public string ValCodpedid { get { return klass.ValCodpedid; } set { klass.ValCodpedid = value; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Pedid.ValDtpedido")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtpedido { get { return klass.ValDtpedido; } set { klass.ValDtpedido = value ?? DateTime.MinValue; } }

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pedid.ValNrpedido")]
		[NumericAttribute(0)]
		public decimal? ValNrpedido { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNrpedido, 0)); } set { klass.ValNrpedido = Convert.ToDecimal(value); } }

		[DisplayName("Reason")]
		/// <summary>Field : "Reason" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Pedid.ValMotivo")]
		[DataType(DataType.MultilineText)]
		public string ValMotivo { get { return klass.ValMotivo; } set { klass.ValMotivo = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Pedid.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Pedid(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApedid(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pedid(UserContext userContext, CSGenioApedid val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioApedid csgenioa)
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
		public static Pedid Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApedid>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pedid(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Pedid> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApedid>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pedid>((r) => new Pedid(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PEDID]/
	}
}
