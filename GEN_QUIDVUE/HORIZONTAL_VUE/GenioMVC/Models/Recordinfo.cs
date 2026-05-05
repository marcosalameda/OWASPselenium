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
	public class Recordinfo : ModelBase
	{
		[JsonIgnore]
		public CSGenioArecordinfo klass { get { return baseklass as CSGenioArecordinfo; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Recordinfo.ValCodrecordinfo")]
		public string ValCodrecordinfo { get { return klass.ValCodrecordinfo; } set { klass.ValCodrecordinfo = value; } }

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Recordinfo.ValReccreationdate")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValReccreationdate { get { return klass.ValReccreationdate; } set { klass.ValReccreationdate = value ?? DateTime.Now;  } }

		[DisplayName("Change date")]
		/// <summary>Field : "Change date" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Recordinfo.ValRecchangedate")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValRecchangedate { get { return klass.ValRecchangedate; } set { klass.ValRecchangedate = value ?? DateTime.MinValue;  } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Recordinfo.ValReccreator")]
		public string ValReccreator { get { return klass.ValReccreator; } set { klass.ValReccreator = value; } }

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Recordinfo.ValRecchange")]
		public string ValRecchange { get { return klass.ValRecchange; } set { klass.ValRecchange = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Recordinfo.ValRecdescript")]
		[DataType(DataType.MultilineText)]
		public string ValRecdescript { get { return klass.ValRecdescript; } set { klass.ValRecdescript = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Recordinfo.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Recordinfo(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArecordinfo(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Recordinfo(UserContext userContext, CSGenioArecordinfo val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioArecordinfo csgenioa)
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
		public static Recordinfo Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArecordinfo>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Recordinfo(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Recordinfo> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArecordinfo>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Recordinfo>((r) => new Recordinfo(userCtx, r));
		}

// USE /[MANUAL GQT MODEL RECORDINFO]/
	}
}
