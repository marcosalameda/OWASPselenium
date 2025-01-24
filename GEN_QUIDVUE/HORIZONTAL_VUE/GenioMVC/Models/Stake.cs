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
	public class Stake : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstake klass { get { return baseklass as CSGenioAstake; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValCodparte")]
		public string ValCodparte { get { return klass.ValCodparte; } set { klass.ValCodparte = value; } }

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValSigla")]
		public string ValSigla { get { return klass.ValSigla; } set { klass.ValSigla = value; } }

		[DisplayName("Tax identification")]
		/// <summary>Field : "Tax identification" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValNif")]
		public string ValNif { get { return klass.ValNif; } set { klass.ValNif = value; } }

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Stake.ValLogotipo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogotipo { get { return new ImageModel(klass.ValLogotipo) { Ticket = ValLogotipoQTicket }; } set { klass.ValLogotipo = value; } }
		[JsonIgnore]
		public string ValLogotipoQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Stake.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Stake(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAstake(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stake(UserContext userContext, CSGenioAstake val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAstake csgenioa)
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
		public static Stake Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstake>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Stake(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Stake> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstake>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Stake>((r) => new Stake(userCtx, r));
		}

// USE /[MANUAL GQT MODEL STAKE]/
	}
}
