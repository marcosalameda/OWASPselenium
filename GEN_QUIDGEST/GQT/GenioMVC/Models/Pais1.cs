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
	public class Pais1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioApais1 klass { get { return baseklass as CSGenioApais1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValCodcntry");

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }
		public bool ShouldSerializeValCountry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValCountry");

		[DisplayName("Active")]
		/// <summary>Field : "Active" Tipo: "L" Formula:  ""</summary>
		public bool ValActive { get { return Convert.ToBoolean(klass.ValActive); } set { klass.ValActive = Convert.ToInt32(value); } }
		public bool ShouldSerializeValActive() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValActive");

		[DisplayName("Numeric")]
		/// <summary>Field : "Numeric" Tipo: "C" Formula:  ""</summary>
		public string ValCodigonr { get { return klass.ValCodigonr; } set { klass.ValCodigonr = value; } }
		public bool ShouldSerializeValCodigonr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValCodigonr");

		[DisplayName("Alphabetic 2")]
		/// <summary>Field : "Alphabetic 2" Tipo: "C" Formula:  ""</summary>
		public string ValAlfa2 { get { return klass.ValAlfa2; } set { klass.ValAlfa2 = value; } }
		public bool ShouldSerializeValAlfa2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValAlfa2");

		[DisplayName("Alphabetic 3")]
		/// <summary>Field : "Alphabetic 3" Tipo: "C" Formula:  ""</summary>
		public string ValAlfa3 { get { return klass.ValAlfa3; } set { klass.ValAlfa3 = value; } }
		public bool ShouldSerializeValAlfa3() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValAlfa3");

		[DisplayName("Flag")]
		/// <summary>Field : "Flag" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFlag { get { return klass.ValFlag; } set { klass.ValFlag = value; } }
		public bool ShouldSerializeValFlag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValFlag");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1.ValZzstate");

		public Pais1() : this(UserContext.Current.User) { }

		public Pais1(User u)
		{
			this.klass = new CSGenioApais1(u);
		}

		public Pais1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pais1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Pais1(bool isEmpty) : this(isEmpty, null) { }

		public Pais1(CSGenioApais1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pais1(CSGenioApais1 val) : this(val, null) { }

		public Pais1(CSGenioApais1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Pais1(CSGenioApais1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApais1 csgenioa)
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
		public static Pais1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Pais1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApais1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pais1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Pais1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApais1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Pais1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApais1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApais1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApais1> All(CriteriaSet args = null)
		{
			return Where<CSGenioApais1>(false, args, numRegs: -1);
		}

		public static List<Pais1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApais1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pais1>((r) => new Pais1(r));
		}

// USE /[MANUAL GQT MODEL PAIS1]/
	}
}
