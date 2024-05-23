using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

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
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrooms { get { return klass.ValCodrooms; } set { klass.ValCodrooms = value; } }
		public bool ShouldSerializeValCodrooms() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rooms.ValCodrooms");

		[DisplayName("N.R. Room")]
		/// <summary>Field : "N.R. Room" Tipo: "C" Formula:  ""</summary>
		public string ValRoomnr { get { return klass.ValRoomnr; } set { klass.ValRoomnr = value; } }
		public bool ShouldSerializeValRoomnr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rooms.ValRoomnr");

		[DisplayName("Room designation")]
		/// <summary>Field : "Room designation" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rooms.ValDesignat");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rooms.ValZzstate");

		public Rooms() : this(UserContext.Current.User) { }

		public Rooms(User u)
		{
			this.klass = new CSGenioArooms(u);
		}

		public Rooms(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rooms(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Rooms(bool isEmpty) : this(isEmpty, null) { }

		public Rooms(CSGenioArooms val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rooms(CSGenioArooms val) : this(val, null) { }

		public Rooms(CSGenioArooms val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Rooms(CSGenioArooms val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Rooms Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			return Find(id, UserContext.Current, identifier, fieldsToSerialize, fieldsToQuery);
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
			return record == null ? null : new Rooms(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Rooms> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArooms>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Rooms>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArooms> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArooms>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArooms> All(CriteriaSet args = null)
		{
			return Where<CSGenioArooms>(false, args, numRegs: -1);
		}

		public static List<Rooms> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArooms>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Rooms>((r) => new Rooms(r));
		}

// USE /[MANUAL GQT MODEL ROOMS]/
	}
}
