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
	public class Rooms : ModelBase
	{
		[JsonIgnore]
		public CSGenioArooms klass { get { return baseklass as CSGenioArooms; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Rooms.ValCodrooms")]
		public string ValCodrooms { get { return klass.ValCodrooms; } set { klass.ValCodrooms = value; } }

		[DisplayName("N.R. Room")]
		/// <summary>Field : "N.R. Room" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Rooms.ValRoomnr")]
		public string ValRoomnr { get { return klass.ValRoomnr; } set { klass.ValRoomnr = value; } }

		[DisplayName("Room designation")]
		/// <summary>Field : "Room designation" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Rooms.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Rooms.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Rooms(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArooms(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Rooms(UserContext userContext, CSGenioArooms val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioArooms csgenioa)
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
		public static Rooms Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArooms>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Rooms(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Rooms> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArooms>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Rooms>((r) => new Rooms(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ROOMS]/
	}
}
