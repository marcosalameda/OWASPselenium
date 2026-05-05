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
	public class Menuc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmenuc klass { get { return baseklass as CSGenioAmenuc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Menuc.ValCodmenuc")]
		public string ValCodmenuc { get { return klass.ValCodmenuc; } set { klass.ValCodmenuc = value; } }

		[DisplayName("Menu Item Class")]
		/// <summary>Field : "Menu Item Class" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Menuc.ValMenucl")]
		public string ValMenucl { get { return klass.ValMenucl; } set { klass.ValMenucl = value; } }

		[DisplayName("Class Description")]
		/// <summary>Field : "Class Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Menuc.ValCldesc")]
		[DataType(DataType.MultilineText)]
		public string ValCldesc { get { return klass.ValCldesc; } set { klass.ValCldesc = value; } }

		[DisplayName("Class Icon")]
		/// <summary>Field : "Class Icon" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Menuc.ValIcon")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValIcon { get { return new ImageModel(klass.ValIcon) { Ticket = ValIconQTicket }; } set { klass.ValIcon = value; } }
		[JsonIgnore]
		public string ValIconQTicket = null;

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Menuc.ValOrder")]
		[NumericAttribute(0)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValOrder, 0)); } set { klass.ValOrder = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Menuc.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Menuc(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmenuc(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Menuc(UserContext userContext, CSGenioAmenuc val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmenuc csgenioa)
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
		public static Menuc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmenuc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Menuc(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Menuc> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmenuc>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Menuc>((r) => new Menuc(userCtx, r));
		}

// USE /[MANUAL GQT MODEL MENUC]/
	}
}
