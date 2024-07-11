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
	public class Role : ModelBase
	{
		[JsonIgnore]
		public CSGenioArole klass { get { return baseklass as CSGenioArole; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrole { get { return klass.ValCodrole; } set { klass.ValCodrole = value; } }
		public bool ShouldSerializeValCodrole() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Role.ValCodrole");

		[DisplayName("Team")]
		/// <summary>Field : "Team" Tipo: "C" Formula:  ""</summary>
		public string ValRolename { get { return klass.ValRolename; } set { klass.ValRolename = value; } }
		public bool ShouldSerializeValRolename() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Role.ValRolename");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Role.ValZzstate");

		public Role() : this(UserContext.Current.User) { }

		public Role(User u)
		{
			this.klass = new CSGenioArole(u);
		}

		public Role(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Role(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Role(bool isEmpty) : this(isEmpty, null) { }

		public Role(CSGenioArole val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Role(CSGenioArole val) : this(val, null) { }

		public Role(CSGenioArole val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Role(CSGenioArole val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioArole csgenioa)
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
		public static Role Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Role Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArole>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Role(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Role> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArole>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Role>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArole> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArole>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArole> All(CriteriaSet args = null)
		{
			return Where<CSGenioArole>(false, args, numRegs: -1);
		}

		public static List<Role> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArole>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Role>((r) => new Role(r));
		}

// USE /[MANUAL GQT MODEL ROLE]/
	}
}
