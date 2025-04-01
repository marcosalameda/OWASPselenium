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
	public class Airpl : ModelBase
	{
		[JsonIgnore]
		public CSGenioAairpl klass { get { return baseklass as CSGenioAairpl; } set { baseklass = value; } }

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
		public string ValCodairpl { get { return klass.ValCodairpl; } set { klass.ValCodairpl = value; } }
		public bool ShouldSerializeValCodairpl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValCodairpl");

		[DisplayName("Airplane ID")]
		/// <summary>Field : "Airplane ID" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValAirplid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAirplid, 0)); } set { klass.ValAirplid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValAirplid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValAirplid");

		[DisplayName("Airplane Name")]
		/// <summary>Field : "Airplane Name" Tipo: "C" Formula:  ""</summary>
		public string ValAirplnm { get { return klass.ValAirplnm; } set { klass.ValAirplnm = value; } }
		public bool ShouldSerializeValAirplnm() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValAirplnm");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValAirpdsc { get { return klass.ValAirpdsc; } set { klass.ValAirpdsc = value; } }
		public bool ShouldSerializeValAirpdsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValAirpdsc");

		[DisplayName("Seating Capacity")]
		/// <summary>Field : "Seating Capacity" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValSeatcap { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSeatcap, 0)); } set { klass.ValSeatcap = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSeatcap() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValSeatcap");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairln { get { return klass.ValCodairln; } set { klass.ValCodairln = value; } }
		public bool ShouldSerializeValCodairln() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValCodairln");
		private Airln _airln;
		[DisplayName("Airln")]
		public virtual Airln Airln { get { if (!this.isEmptyModel && (_airln == null || (!string.IsNullOrEmpty(ValCodairln) && (_airln.isEmptyModel || _airln.klass.QPrimaryKey != ValCodairln)))) _airln = Models.Airln.Find(ValCodairln, Identifier, _fieldsToSerialize); if (_airln == null) _airln = new Models.Airln(true, _fieldsToSerialize); return _airln; } set { _airln = value; } }
		public bool ShouldSerializeAirln () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airln");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpl.ValZzstate");

		public Airpl() : this(UserContext.Current.User) { }

		public Airpl(User u)
		{
			this.klass = new CSGenioAairpl(u);
		}

		public Airpl(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Airpl(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Airpl(bool isEmpty) : this(isEmpty, null) { }

		public Airpl(CSGenioAairpl val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Airpl(CSGenioAairpl val) : this(val, null) { }

		public Airpl(CSGenioAairpl val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Airpl(CSGenioAairpl val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAairpl csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "airln":
						if (_airln == null)
							_airln = new Airln(true, _fieldsToSerialize);
						_airln.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Airpl Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Airpl Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAairpl>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Airpl(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Airpl> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAairpl>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Airpl>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAairpl> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAairpl>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAairpl> All(CriteriaSet args = null)
		{
			return Where<CSGenioAairpl>(false, args, numRegs: -1);
		}

		public static List<Airpl> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAairpl>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Airpl>((r) => new Airpl(r));
		}

// USE /[MANUAL GQT MODEL AIRPL]/
	}
}
