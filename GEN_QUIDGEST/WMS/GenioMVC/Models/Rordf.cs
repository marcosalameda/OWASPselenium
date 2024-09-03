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
	public class Rordf : ModelBase
	{
		[JsonIgnore]
		public CSGenioArordf klass { get { return baseklass as CSGenioArordf; } set { baseklass = value; } }

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
		public string ValCodrordf { get { return klass.ValCodrordf; } set { klass.ValCodrordf = value; } }
		public bool ShouldSerializeValCodrordf() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rordf.ValCodrordf");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(1)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 1)); } set { klass.ValOrder = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOrder() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rordf.ValOrder");

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }
		public bool ShouldSerializeValTitle() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rordf.ValTitle");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rordf.ValZzstate");

		public Rordf() : this(UserContext.Current.User) { }

		public Rordf(User u)
		{
			this.klass = new CSGenioArordf(u);
		}

		public Rordf(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rordf(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Rordf(bool isEmpty) : this(isEmpty, null) { }

		public Rordf(CSGenioArordf val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rordf(CSGenioArordf val) : this(val, null) { }

		public Rordf(CSGenioArordf val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Rordf(CSGenioArordf val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioArordf csgenioa)
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
		public static Rordf Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Rordf Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArordf>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Rordf(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Rordf> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArordf>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Rordf>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArordf> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArordf>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArordf> All(CriteriaSet args = null)
		{
			return Where<CSGenioArordf>(false, args, numRegs: -1);
		}

		public static List<Rordf> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArordf>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Rordf>((r) => new Rordf(r));
		}

// USE /[MANUAL GQT MODEL RORDF]/
	}
}
