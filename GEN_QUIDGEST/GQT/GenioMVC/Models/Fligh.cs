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
	public class Fligh : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfligh klass { get { return baseklass as CSGenioAfligh; } set { baseklass = value; } }

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
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }
		public bool ShouldSerializeValCodfligh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValCodfligh");

		[DisplayName("Flight ID")]
		/// <summary>Field : "Flight ID" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValFlightid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValFlightid, 0)); } set { klass.ValFlightid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValFlightid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValFlightid");

		[DisplayName("Departure Date")]
		/// <summary>Field : "Departure Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDepdate { get { return klass.ValDepdate; } set { klass.ValDepdate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDepdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValDepdate");

		[DisplayName("Departure Time")]
		/// <summary>Field : "Departure Time" Tipo: "T" Formula:  ""</summary>
		[DateAttribute("T")]
		public string ValDeptime { get { return klass.ValDeptime; } set { klass.ValDeptime = value; } }
		public bool ShouldSerializeValDeptime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValDeptime");

		[DisplayName("Arrival Date")]
		/// <summary>Field : "Arrival Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValArvdate { get { return klass.ValArvdate; } set { klass.ValArvdate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValArvdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValArvdate");

		[DisplayName("Arrival Time")]
		/// <summary>Field : "Arrival Time" Tipo: "T" Formula:  ""</summary>
		[DateAttribute("T")]
		public string ValArrtime { get { return klass.ValArrtime; } set { klass.ValArrtime = value; } }
		public bool ShouldSerializeValArrtime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValArrtime");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairln { get { return klass.ValCodairln; } set { klass.ValCodairln = value; } }
		public bool ShouldSerializeValCodairln() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValCodairln");
		private Airln _airln;
		[DisplayName("Airln")]
		public virtual Airln Airln { get { if (!this.isEmptyModel && (_airln == null || (!string.IsNullOrEmpty(ValCodairln) && (_airln.isEmptyModel || _airln.klass.QPrimaryKey != ValCodairln)))) _airln = Models.Airln.Find(ValCodairln, Identifier, _fieldsToSerialize); if (_airln == null) _airln = new Models.Airln(true, _fieldsToSerialize); return _airln; } set { _airln = value; } }
		public bool ShouldSerializeAirln () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airln");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairpt { get { return klass.ValCodairpt; } set { klass.ValCodairpt = value; } }
		public bool ShouldSerializeValCodairpt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValCodairpt");
		private Airpt _airpt;
		[DisplayName("Airpt")]
		public virtual Airpt Airpt { get { if (!this.isEmptyModel && (_airpt == null || (!string.IsNullOrEmpty(ValCodairpt) && (_airpt.isEmptyModel || _airpt.klass.QPrimaryKey != ValCodairpt)))) _airpt = Models.Airpt.Find(ValCodairpt, Identifier, _fieldsToSerialize); if (_airpt == null) _airpt = new Models.Airpt(true, _fieldsToSerialize); return _airpt; } set { _airpt = value; } }
		public bool ShouldSerializeAirpt () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airpt");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairfr { get { return klass.ValCodairfr; } set { klass.ValCodairfr = value; } }
		public bool ShouldSerializeValCodairfr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValCodairfr");
		private Airfr _airfr;
		[DisplayName("Airfr")]
		public virtual Airfr Airfr { get { if (!this.isEmptyModel && (_airfr == null || (!string.IsNullOrEmpty(ValCodairfr) && (_airfr.isEmptyModel || _airfr.klass.QPrimaryKey != ValCodairfr)))) _airfr = Models.Airfr.Find(ValCodairfr, Identifier, _fieldsToSerialize); if (_airfr == null) _airfr = new Models.Airfr(true, _fieldsToSerialize); return _airfr; } set { _airfr = value; } }
		public bool ShouldSerializeAirfr () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airfr");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairto { get { return klass.ValCodairto; } set { klass.ValCodairto = value; } }
		public bool ShouldSerializeValCodairto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValCodairto");
		private Airto _airto;
		[DisplayName("Airto")]
		public virtual Airto Airto { get { if (!this.isEmptyModel && (_airto == null || (!string.IsNullOrEmpty(ValCodairto) && (_airto.isEmptyModel || _airto.klass.QPrimaryKey != ValCodairto)))) _airto = Models.Airto.Find(ValCodairto, Identifier, _fieldsToSerialize); if (_airto == null) _airto = new Models.Airto(true, _fieldsToSerialize); return _airto; } set { _airto = value; } }
		public bool ShouldSerializeAirto () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Airto");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh.ValZzstate");

		public Fligh() : this(UserContext.Current.User) { }

		public Fligh(User u)
		{
			this.klass = new CSGenioAfligh(u);
		}

		public Fligh(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fligh(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Fligh(bool isEmpty) : this(isEmpty, null) { }

		public Fligh(CSGenioAfligh val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fligh(CSGenioAfligh val) : this(val, null) { }

		public Fligh(CSGenioAfligh val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Fligh(CSGenioAfligh val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAfligh csgenioa)
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
					case "airpt":
						if (_airpt == null)
							_airpt = new Airpt(true, _fieldsToSerialize);
						_airpt.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airfr":
						if (_airfr == null)
							_airfr = new Airfr(true, _fieldsToSerialize);
						_airfr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airto":
						if (_airto == null)
							_airto = new Airto(true, _fieldsToSerialize);
						_airto.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Fligh Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Fligh Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfligh>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Fligh(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Fligh> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfligh>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Fligh>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfligh> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfligh>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfligh> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfligh>(false, args, numRegs: -1);
		}

		public static List<Fligh> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfligh>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Fligh>((r) => new Fligh(r));
		}

// USE /[MANUAL GQT MODEL FLIGH]/
	}
}
