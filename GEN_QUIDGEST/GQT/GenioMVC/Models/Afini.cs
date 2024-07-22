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
	public class Afini : ModelBase
	{
		[JsonIgnore]
		public CSGenioAafini klass { get { return baseklass as CSGenioAafini; } set { baseklass = value; } }

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
		public string ValCodafini { get { return klass.ValCodafini; } set { klass.ValCodafini = value; } }
		public bool ShouldSerializeValCodafini() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValCodafini");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIniafini { get { return klass.ValIniafini; } set { klass.ValIniafini = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValIniafini() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValIniafini");

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValEndafini { get { return klass.ValEndafini; } set { klass.ValEndafini = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValEndafini() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValEndafini");

		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		public bool ShouldSerializeValCodpess1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValCodpess1");
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		public virtual Pess1 Pess1 { get { if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1)))) _pess1 = Models.Pess1.Find(ValCodpess1, Identifier, _fieldsToSerialize); if (_pess1 == null) _pess1 = new Models.Pess1(true, _fieldsToSerialize); return _pess1; } set { _pess1 = value; } }
		public bool ShouldSerializePess1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess1");

		[DisplayName(">AFFINITY GENRE")]
		/// <summary>Field : ">AFFINITY GENRE" Tipo: "CF" Formula:  ""</summary>
		public string ValCodgafin { get { return klass.ValCodgafin; } set { klass.ValCodgafin = value; } }
		public bool ShouldSerializeValCodgafin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValCodgafin");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess2 { get { return klass.ValCodpess2; } set { klass.ValCodpess2 = value; } }
		public bool ShouldSerializeValCodpess2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValCodpess2");
		private Pess2 _pess2;
		[DisplayName("Pess2")]
		public virtual Pess2 Pess2 { get { if (!this.isEmptyModel && (_pess2 == null || (!string.IsNullOrEmpty(ValCodpess2) && (_pess2.isEmptyModel || _pess2.klass.QPrimaryKey != ValCodpess2)))) _pess2 = Models.Pess2.Find(ValCodpess2, Identifier, _fieldsToSerialize); if (_pess2 == null) _pess2 = new Models.Pess2(true, _fieldsToSerialize); return _pess2; } set { _pess2 = value; } }
		public bool ShouldSerializePess2 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Afini.ValZzstate");

		public Afini() : this(UserContext.Current.User) { }

		public Afini(User u)
		{
			this.klass = new CSGenioAafini(u);
		}

		public Afini(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Afini(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Afini(bool isEmpty) : this(isEmpty, null) { }

		public Afini(CSGenioAafini val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Afini(CSGenioAafini val) : this(val, null) { }

		public Afini(CSGenioAafini val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Afini(CSGenioAafini val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAafini csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess2":
						if (_pess2 == null)
							_pess2 = new Pess2(true, _fieldsToSerialize);
						_pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Afini Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Afini Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAafini>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Afini(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Afini> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAafini>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Afini>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAafini> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAafini>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAafini> All(CriteriaSet args = null)
		{
			return Where<CSGenioAafini>(false, args, numRegs: -1);
		}

		public static List<Afini> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAafini>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Afini>((r) => new Afini(r));
		}

// USE /[MANUAL GQT MODEL AFINI]/
	}
}
