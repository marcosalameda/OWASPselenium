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
	public class Cntry : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcntry klass { get { return baseklass as CSGenioAcntry; } set { baseklass = value; } }

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
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValCodcntry");

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }
		public bool ShouldSerializeValCountry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValCountry");

		[DisplayName("Active")]
		/// <summary>Field : "Active" Tipo: "L" Formula:  ""</summary>
		public bool ValActive { get { return Convert.ToBoolean(klass.ValActive); } set { klass.ValActive = Convert.ToInt32(value); } }
		public bool ShouldSerializeValActive() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValActive");

		[DisplayName("Numeric")]
		/// <summary>Field : "Numeric" Tipo: "C" Formula:  ""</summary>
		public string ValCodigonr { get { return klass.ValCodigonr; } set { klass.ValCodigonr = value; } }
		public bool ShouldSerializeValCodigonr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValCodigonr");

		[DisplayName("Alphabetic 2")]
		/// <summary>Field : "Alphabetic 2" Tipo: "C" Formula:  ""</summary>
		public string ValAlfa2 { get { return klass.ValAlfa2; } set { klass.ValAlfa2 = value; } }
		public bool ShouldSerializeValAlfa2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValAlfa2");

		[DisplayName("Alphabetic 3")]
		/// <summary>Field : "Alphabetic 3" Tipo: "C" Formula:  ""</summary>
		public string ValAlfa3 { get { return klass.ValAlfa3; } set { klass.ValAlfa3 = value; } }
		public bool ShouldSerializeValAlfa3() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValAlfa3");

		[DisplayName("Flag")]
		/// <summary>Field : "Flag" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFlag { get { return klass.ValFlag; } set { klass.ValFlag = value; } }
		public bool ShouldSerializeValFlag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValFlag");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry.ValZzstate");

		public Cntry() : this(UserContext.Current.User) { }

		public Cntry(User u)
		{
			this.klass = new CSGenioAcntry(u);
		}

		public Cntry(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cntry(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Cntry(bool isEmpty) : this(isEmpty, null) { }

		public Cntry(CSGenioAcntry val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cntry(CSGenioAcntry val) : this(val, null) { }

		public Cntry(CSGenioAcntry val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Cntry(CSGenioAcntry val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcntry csgenioa)
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
		public static Cntry Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Cntry Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcntry>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cntry(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Cntry> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcntry>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Cntry>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcntry> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcntry>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcntry> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcntry>(false, args, numRegs: -1);
		}

		public static List<Cntry> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcntry>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cntry>((r) => new Cntry(r));
		}

// USE /[MANUAL GQT MODEL CNTRY]/
	}
}
