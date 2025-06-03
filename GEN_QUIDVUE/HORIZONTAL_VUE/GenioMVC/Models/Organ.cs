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
	public class Organ : ModelBase
	{
		[JsonIgnore]
		public CSGenioAorgan klass { get { return baseklass as CSGenioAorgan; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Organ.ValCodorgan")]
		public string ValCodorgan { get { return klass.ValCodorgan; } set { klass.ValCodorgan = value; } }

		[DisplayName("Organization")]
		/// <summary>Field : "Organization" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Organ.ValOrganiza")]
		public string ValOrganiza { get { return klass.ValOrganiza; } set { klass.ValOrganiza = value; } }

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Organ.ValSigla")]
		public string ValSigla { get { return klass.ValSigla; } set { klass.ValSigla = value; } }

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Organ.ValLogo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogo { get { return new ImageModel(klass.ValLogo) { Ticket = ValLogoQTicket }; } set { klass.ValLogo = value; } }
		[JsonIgnore]
		public string ValLogoQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Organ.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Organ(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAorgan(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Organ(UserContext userContext, CSGenioAorgan val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAorgan csgenioa)
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
		public static Organ Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAorgan>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Organ(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Organ> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAorgan>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Organ>((r) => new Organ(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ORGAN]/
	}
}
