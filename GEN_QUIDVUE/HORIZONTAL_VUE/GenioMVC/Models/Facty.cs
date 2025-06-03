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
	public class Facty : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfacty klass { get { return baseklass as CSGenioAfacty; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValCodfacty")]
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValType")]
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }

		[DisplayName("Layer name")]
		/// <summary>Field : "Layer name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValLayrname")]
		public string ValLayrname { get { return klass.ValLayrname; } set { klass.ValLayrname = value; } }

		[DisplayName("Icon URL")]
		/// <summary>Field : "Icon URL" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValIconurl")]
		public string ValIconurl { get { return klass.ValIconurl; } set { klass.ValIconurl = value; } }

		[DisplayName("Shadow URL")]
		/// <summary>Field : "Shadow URL" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValShadowur")]
		public string ValShadowur { get { return klass.ValShadowur; } set { klass.ValShadowur = value; } }

		[DisplayName("Icon anchor (x-axis)")]
		/// <summary>Field : "Icon anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValIconancx")]
		[NumericAttribute(0)]
		public decimal? ValIconancx { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIconancx, 0)); } set { klass.ValIconancx = Convert.ToDecimal(value); } }

		[DisplayName("Icon anchor (y-axis)")]
		/// <summary>Field : "Icon anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValIconancy")]
		[NumericAttribute(0)]
		public decimal? ValIconancy { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIconancy, 0)); } set { klass.ValIconancy = Convert.ToDecimal(value); } }

		[DisplayName("Icon height")]
		/// <summary>Field : "Icon height" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValIconheig")]
		[NumericAttribute(0)]
		public decimal? ValIconheig { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIconheig, 0)); } set { klass.ValIconheig = Convert.ToDecimal(value); } }

		[DisplayName("Icon width")]
		/// <summary>Field : "Icon width" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValIconwid")]
		[NumericAttribute(0)]
		public decimal? ValIconwid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIconwid, 0)); } set { klass.ValIconwid = Convert.ToDecimal(value); } }

		[DisplayName("Popup anchor (x-axis)")]
		/// <summary>Field : "Popup anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValPopupanx")]
		[NumericAttribute(0)]
		public decimal? ValPopupanx { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPopupanx, 0)); } set { klass.ValPopupanx = Convert.ToDecimal(value); } }

		[DisplayName("Popup anchor (y-axis)")]
		/// <summary>Field : "Popup anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValPopupany")]
		[NumericAttribute(0)]
		public decimal? ValPopupany { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPopupany, 0)); } set { klass.ValPopupany = Convert.ToDecimal(value); } }

		[DisplayName("Shadow anchor (x-axis)")]
		/// <summary>Field : "Shadow anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValShadowax")]
		[NumericAttribute(0)]
		public decimal? ValShadowax { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValShadowax, 0)); } set { klass.ValShadowax = Convert.ToDecimal(value); } }

		[DisplayName("Shadow anchor (y-axis)")]
		/// <summary>Field : "Shadow anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValShadoway")]
		[NumericAttribute(0)]
		public decimal? ValShadoway { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValShadoway, 0)); } set { klass.ValShadoway = Convert.ToDecimal(value); } }

		[DisplayName("Shadow height")]
		/// <summary>Field : "Shadow height" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValShadowhe")]
		[NumericAttribute(0)]
		public decimal? ValShadowhe { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValShadowhe, 0)); } set { klass.ValShadowhe = Convert.ToDecimal(value); } }

		[DisplayName("Shadow width")]
		/// <summary>Field : "Shadow width" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Facty.ValShadowwi")]
		[NumericAttribute(0)]
		public decimal? ValShadowwi { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValShadowwi, 0)); } set { klass.ValShadowwi = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Facty.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Facty(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfacty(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Facty(UserContext userContext, CSGenioAfacty val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAfacty csgenioa)
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
		public static Facty Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfacty>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Facty(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Facty> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfacty>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Facty>((r) => new Facty(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FACTY]/
	}
}
