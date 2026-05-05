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
	public class Cards : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcards klass { get { return baseklass as CSGenioAcards; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValCodcards")]
		public string ValCodcards { get { return klass.ValCodcards; } set { klass.ValCodcards = value; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Subtitle")]
		/// <summary>Field : "Subtitle" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValSubtitle")]
		public string ValSubtitle { get { return klass.ValSubtitle; } set { klass.ValSubtitle = value; } }

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValImage { get { return new ImageModel(klass.ValImage) { Ticket = ValImageQTicket }; } set { klass.ValImage = value; } }
		[JsonIgnore]
		public string ValImageQTicket = null;

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValDescription")]
		[DataType(DataType.MultilineText)]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("Actions style")]
		/// <summary>Field : "Actions style" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValActionsstyle")]
		[DataArray("Dropdown", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValActionsstyle { get { return klass.ValActionsstyle; } set { klass.ValActionsstyle = value; } }
		[JsonIgnore]
		public SelectList ArrayValactionsstyle { get { return new SelectList(CSGenio.business.ArrayDropdown.GetDictionary(), "Key", "Value", ValActionsstyle); } set { ValActionsstyle = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Actions placement")]
		/// <summary>Field : "Actions placement" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValActionsplace")]
		[DataArray("Header", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValActionsplace { get { return klass.ValActionsplace; } set { klass.ValActionsplace = value; } }
		[JsonIgnore]
		public SelectList ArrayValactionsplace { get { return new SelectList(CSGenio.business.ArrayHeader.GetDictionary(), "Key", "Value", ValActionsplace); } set { ValActionsplace = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Actions alignment")]
		/// <summary>Field : "Actions alignment" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Cards.ValActonsalign")]
		[DataArray("Side", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValActonsalign { get { return klass.ValActonsalign; } set { klass.ValActonsalign = value; } }
		[JsonIgnore]
		public SelectList ArrayValactonsalign { get { return new SelectList(CSGenio.business.ArraySide.GetDictionary(), "Key", "Value", ValActonsalign); } set { ValActonsalign = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Cards.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Cards(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcards(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cards(UserContext userContext, CSGenioAcards val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcards csgenioa)
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
		public static Cards Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcards>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cards(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Cards> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcards>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cards>((r) => new Cards(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CARDS]/
	}
}
