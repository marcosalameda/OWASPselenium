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
	public class Agent : ModelBase
	{
		[JsonIgnore]
		public CSGenioAagent klass { get { return baseklass as CSGenioAagent; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValCodagent")]
		public string ValCodagent { get { return klass.ValCodagent; } set { klass.ValCodagent = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Birthdate")]
		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValBirthdat")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValBirthdat { get { return klass.ValBirthdat; } set { klass.ValBirthdat = value ?? DateTime.MinValue; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula: DF ""@agency.com""</summary>
		[ShouldSerialize("Agent.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Agent.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Agent(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAagent(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Agent(UserContext userContext, CSGenioAagent val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAagent csgenioa)
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
		public static Agent Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAagent>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Agent(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Agent> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAagent>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Agent>((r) => new Agent(userCtx, r));
		}

// USE /[MANUAL GQT MODEL AGENT]/
	}
}
