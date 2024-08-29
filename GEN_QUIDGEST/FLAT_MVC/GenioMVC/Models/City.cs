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
	public class City : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcity klass { get { return baseklass as CSGenioAcity; } set { baseklass = value; } }

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
		public string ValCodcity { get { return klass.ValCodcity; } set { klass.ValCodcity = value; } }
		public bool ShouldSerializeValCodcity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("City.ValCodcity");

		[DisplayName("City")]
		/// <summary>Field : "City" Tipo: "C" Formula:  ""</summary>
		public string ValCity { get { return klass.ValCity; } set { klass.ValCity = value; } }
		public bool ShouldSerializeValCity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("City.ValCity");

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "CE" Formula:  ""</summary>
		public string ValCodctry { get { return klass.ValCodctry; } set { klass.ValCodctry = value; } }
		public bool ShouldSerializeValCodctry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("City.ValCodctry");
		private Ctry _ctry;
		[DisplayName("Ctry")]
		public virtual Ctry Ctry { get { if (!this.isEmptyModel && (_ctry == null || (!string.IsNullOrEmpty(ValCodctry) && (_ctry.isEmptyModel || _ctry.klass.QPrimaryKey != ValCodctry)))) _ctry = Models.Ctry.Find(ValCodctry, Identifier, _fieldsToSerialize); if (_ctry == null) _ctry = new Models.Ctry(true, _fieldsToSerialize); return _ctry; } set { _ctry = value; } }
		public bool ShouldSerializeCtry () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ctry");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("City.ValZzstate");

		public City() : this(UserContext.Current.User) { }

		public City(User u)
		{
			this.klass = new CSGenioAcity(u);
		}

		public City(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public City(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public City(bool isEmpty) : this(isEmpty, null) { }

		public City(CSGenioAcity val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public City(CSGenioAcity val) : this(val, null) { }

		public City(CSGenioAcity val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public City(CSGenioAcity val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcity csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "ctry":
						if (_ctry == null)
							_ctry = new Ctry(true, _fieldsToSerialize);
						_ctry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static City Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static City Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcity>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new City(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<City> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcity>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<City>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcity> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcity>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcity> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcity>(false, args, numRegs: -1);
		}

		public static List<City> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcity>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<City>((r) => new City(r));
		}

// USE /[MANUAL GQT MODEL CITY]/
	}
}
