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
	public class Compc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcompc klass { get { return baseklass as CSGenioAcompc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Compc.ValCodcompc")]
		public string ValCodcompc { get { return klass.ValCodcompc; } set { klass.ValCodcompc = value; } }

		[DisplayName("Components Class")]
		/// <summary>Field : "Components Class" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Compc.ValCompclas")]
		public string ValCompclas { get { return klass.ValCompclas; } set { klass.ValCompclas = value; } }

		[DisplayName("Class Description")]
		/// <summary>Field : "Class Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compc.ValClassdes")]
		[DataType(DataType.MultilineText)]
		public string ValClassdes { get { return klass.ValClassdes; } set { klass.ValClassdes = value; } }

		[DisplayName("Class icon")]
		/// <summary>Field : "Class icon" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Compc.ValClassico")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValClassico { get { return new ImageModel(klass.ValClassico) { Ticket = ValClassicoQTicket }; } set { klass.ValClassico = value; } }
		[JsonIgnore]
		public string ValClassicoQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Compc.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Compc(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcompc(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compc(UserContext userContext, CSGenioAcompc val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcompc csgenioa)
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
		public static Compc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcompc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Compc(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Compc> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcompc>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Compc>((r) => new Compc(userCtx, r));
		}

// USE /[MANUAL GQT MODEL COMPC]/
	}
}
