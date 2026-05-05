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
	public class Menuit : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmenuit klass { get { return baseklass as CSGenioAmenuit; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValCodmenuit")]
		public string ValCodmenuit { get { return klass.ValCodmenuit; } set { klass.ValCodmenuit = value; } }

		[DisplayName("Menu Item Class")]
		/// <summary>Field : "Menu Item Class" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValMclass")]
		public string ValMclass { get { return klass.ValMclass; } set { klass.ValMclass = value; } }

		private Menuc _menuc;
		[DisplayName("Menuc")]
		[ShouldSerialize("Menuc")]
		public virtual Menuc Menuc
		{
			get
			{
				if (!isEmptyModel && (_menuc == null || (!string.IsNullOrEmpty(ValMclass) && (_menuc.isEmptyModel || _menuc.klass.QPrimaryKey != ValMclass))))
					_menuc = Models.Menuc.Find(ValMclass, m_userContext, Identifier, _fieldsToSerialize);
				_menuc ??= new Models.Menuc(m_userContext, true, _fieldsToSerialize);
				return _menuc;
			}
			set { _menuc = value; }
		}

		[DisplayName("Menu Item Type")]
		/// <summary>Field : "Menu Item Type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValMtype")]
		public string ValMtype { get { return klass.ValMtype; } set { klass.ValMtype = value; } }

		[DisplayName("Menu Type Description")]
		/// <summary>Field : "Menu Type Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValMdesc")]
		[DataType(DataType.MultilineText)]
		public string ValMdesc { get { return klass.ValMdesc; } set { klass.ValMdesc = value; } }

		[DisplayName("Menu Type Image")]
		/// <summary>Field : "Menu Type Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValMenuimg")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValMenuimg { get { return new ImageModel(klass.ValMenuimg) { Ticket = ValMenuimgQTicket }; } set { klass.ValMenuimg = value; } }
		[JsonIgnore]
		public string ValMenuimgQTicket = null;

		[DisplayName("Acronym")]
		/// <summary>Field : "Sigla" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValSigl")]
		public string ValSigl { get { return klass.ValSigl; } set { klass.ValSigl = value; } }

		[DisplayName("Example Link")]
		/// <summary>Field : "Example Link" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValLink")]
		[HyperLink]
		public string ValLink { get { return klass.ValLink; } set { klass.ValLink = value; } }

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Menuit.ValOrder")]
		[NumericAttribute(0)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValOrder, 0)); } set { klass.ValOrder = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Menuit.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Menuit(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmenuit(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Menuit(UserContext userContext, CSGenioAmenuit val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmenuit csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "menuc":
						_menuc ??= new Menuc(m_userContext, true, _fieldsToSerialize);
						_menuc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Menuit Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmenuit>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Menuit(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Menuit> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmenuit>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Menuit>((r) => new Menuit(userCtx, r));
		}

// USE /[MANUAL GQT MODEL MENUIT]/
	}
}
