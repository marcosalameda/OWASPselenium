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
	public class Disst : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdisst klass { get { return baseklass as CSGenioAdisst; } set { baseklass = value; } }

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
		public string ValCoddisst { get { return klass.ValCoddisst; } set { klass.ValCoddisst = value; } }
		public bool ShouldSerializeValCoddisst() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Disst.ValCoddisst");

		[DisplayName("Status")]
		/// <summary>Field : "Status" Tipo: "C" Formula:  ""</summary>
		public string ValStatus { get { return klass.ValStatus; } set { klass.ValStatus = value; } }
		public bool ShouldSerializeValStatus() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Disst.ValStatus");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 0)); } set { klass.ValOrder = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOrder() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Disst.ValOrder");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Disst.ValDescript");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Disst.ValZzstate");

		public Disst() : this(UserContext.Current.User) { }

		public Disst(User u)
		{
			this.klass = new CSGenioAdisst(u);
		}

		public Disst(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Disst(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Disst(bool isEmpty) : this(isEmpty, null) { }

		public Disst(CSGenioAdisst val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Disst(CSGenioAdisst val) : this(val, null) { }

		public Disst(CSGenioAdisst val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Disst(CSGenioAdisst val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAdisst csgenioa)
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
		public static Disst Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Disst Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdisst>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Disst(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Disst> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAdisst>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Disst>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAdisst> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAdisst>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAdisst> All(CriteriaSet args = null)
		{
			return Where<CSGenioAdisst>(false, args, numRegs: -1);
		}

		public static List<Disst> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdisst>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Disst>((r) => new Disst(r));
		}

// USE /[MANUAL GQT MODEL DISST]/
	}
}
