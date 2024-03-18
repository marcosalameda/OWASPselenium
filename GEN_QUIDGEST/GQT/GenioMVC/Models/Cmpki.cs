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
	public class Cmpki : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcmpki klass { get { return baseklass as CSGenioAcmpki; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcmpki { get { return klass.ValCodcmpki; } set { klass.ValCodcmpki = value; } }
		public bool ShouldSerializeValCodcmpki() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValCodcmpki");

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValCodtpequ");
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		public virtual Tpequ Tpequ { get { if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ)))) _tpequ = Models.Tpequ.Find(ValCodtpequ, Identifier, _fieldsToSerialize); if (_tpequ == null) _tpequ = new Models.Tpequ(true, _fieldsToSerialize); return _tpequ; } set { _tpequ = value; } }
		public bool ShouldSerializeTpequ () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(1)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 1)); } set { klass.ValOrder = Convert.ToDouble(value); } }
		public bool ShouldSerializeValOrder() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValOrder");

		[DisplayName("TYPE OF COMPONENT EQUIPMENT")]
		/// <summary>Field : "TYPE OF COMPONENT EQUIPMENT" Tipo: "CE" Formula: DF "[CMPKI->CODTPEQU]"</summary>
		public string ValCodtpeq1 { get { return klass.ValCodtpeq1; } set { klass.ValCodtpeq1 = value; } }
		public bool ShouldSerializeValCodtpeq1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValCodtpeq1");
		private Tpeq1 _tpeq1;
		[DisplayName("Tpeq1")]
		public virtual Tpeq1 Tpeq1 { get { if (!this.isEmptyModel && (_tpeq1 == null || (!string.IsNullOrEmpty(ValCodtpeq1) && (_tpeq1.isEmptyModel || _tpeq1.klass.QPrimaryKey != ValCodtpeq1)))) _tpeq1 = Models.Tpeq1.Find(ValCodtpeq1, Identifier, _fieldsToSerialize); if (_tpeq1 == null) _tpeq1 = new Models.Tpeq1(true, _fieldsToSerialize); return _tpeq1; } set { _tpeq1 = value; } }
		public bool ShouldSerializeTpeq1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQuantida { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantida, 0)); } set { klass.ValQuantida = Convert.ToDouble(value); } }
		public bool ShouldSerializeValQuantida() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValQuantida");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValDescript");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }
		public bool ShouldSerializeValCode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValCode");

		[DisplayName("Site")]
		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		[HyperLink]
		public string ValUrl { get { return klass.ValUrl; } set { klass.ValUrl = value; } }
		public bool ShouldSerializeValUrl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValUrl");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpki.ValZzstate");

		public Cmpki() : this(UserContext.Current.User) { }

		public Cmpki(User u)
		{
			this.klass = new CSGenioAcmpki(u);
		}

		public Cmpki(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cmpki(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Cmpki(bool isEmpty) : this(isEmpty, null) { }

		public Cmpki(CSGenioAcmpki val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cmpki(CSGenioAcmpki val) : this(val, null) { }

		public Cmpki(CSGenioAcmpki val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Cmpki(CSGenioAcmpki val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcmpki csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
						if (_tpequ == null)
							_tpequ = new Tpequ(true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpeq1":
						if (_tpeq1 == null)
							_tpeq1 = new Tpeq1(true, _fieldsToSerialize);
						_tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Cmpki Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Cmpki Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcmpki>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cmpki(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Cmpki> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcmpki>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Cmpki>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcmpki> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcmpki>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcmpki> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcmpki>(false, args, numRegs: -1);
		}

		public static List<Cmpki> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcmpki>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cmpki>((r) => new Cmpki(r));
		}

// USE /[MANUAL GQT MODEL CMPKI]/
	}
}
