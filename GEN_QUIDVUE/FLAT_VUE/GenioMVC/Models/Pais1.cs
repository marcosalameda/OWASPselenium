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
	public class Pais1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioApais1 klass { get { return baseklass as CSGenioApais1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValCountry")]
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }

		[DisplayName("Active")]
		/// <summary>Field : "Active" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValActive")]
		public bool ValActive { get { return Convert.ToBoolean(klass.ValActive); } set { klass.ValActive = Convert.ToInt32(value); } }

		[DisplayName("Numeric")]
		/// <summary>Field : "Numeric" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValCodigonr")]
		public string ValCodigonr { get { return klass.ValCodigonr; } set { klass.ValCodigonr = value; } }

		[DisplayName("Alphabetic 2")]
		/// <summary>Field : "Alphabetic 2" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValAlfa2")]
		public string ValAlfa2 { get { return klass.ValAlfa2; } set { klass.ValAlfa2 = value; } }

		[DisplayName("Alphabetic 3")]
		/// <summary>Field : "Alphabetic 3" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValAlfa3")]
		public string ValAlfa3 { get { return klass.ValAlfa3; } set { klass.ValAlfa3 = value; } }

		[DisplayName("Flag")]
		/// <summary>Field : "Flag" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Pais1.ValFlag")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFlag { get { return new ImageModel(klass.ValFlag) { Ticket = ValFlagQTicket }; } set { klass.ValFlag = value; } }
		[JsonIgnore]
		public string ValFlagQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Pais1.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Pais1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApais1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pais1(UserContext userContext, CSGenioApais1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioApais1 csgenioa)
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
		public static Pais1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApais1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pais1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Pais1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApais1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pais1>((r) => new Pais1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PAIS1]/
	}
}
