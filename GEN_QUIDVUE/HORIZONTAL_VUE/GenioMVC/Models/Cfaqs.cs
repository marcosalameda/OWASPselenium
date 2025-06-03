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
	public class Cfaqs : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcfaqs klass { get { return baseklass as CSGenioAcfaqs; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Cfaqs.ValCodcfaqs")]
		public string ValCodcfaqs { get { return klass.ValCodcfaqs; } set { klass.ValCodcfaqs = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Cfaqs.ValIcon")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValIcon { get { return new ImageModel(klass.ValIcon) { Ticket = ValIconQTicket }; } set { klass.ValIcon = value; } }
		[JsonIgnore]
		public string ValIconQTicket = null;

		[DisplayName("Category")]
		/// <summary>Field : "Category" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Cfaqs.ValCategory")]
		[DataType(DataType.MultilineText)]
		public string ValCategory { get { return klass.ValCategory; } set { klass.ValCategory = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Cfaqs.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Cfaqs.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Cfaqs(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcfaqs(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cfaqs(UserContext userContext, CSGenioAcfaqs val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcfaqs csgenioa)
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
		public static Cfaqs Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcfaqs>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cfaqs(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Cfaqs> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcfaqs>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cfaqs>((r) => new Cfaqs(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CFAQS]/
	}
}
