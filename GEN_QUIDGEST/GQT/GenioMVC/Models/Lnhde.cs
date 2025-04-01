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
	public class Lnhde : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhde klass { get { return baseklass as CSGenioAlnhde; } set { baseklass = value; } }

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
		public string ValCodlnhde { get { return klass.ValCodlnhde; } set { klass.ValCodlnhde = value; } }
		public bool ShouldSerializeValCodlnhde() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValCodlnhde");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlnhpd { get { return klass.ValCodlnhpd; } set { klass.ValCodlnhpd = value; } }
		public bool ShouldSerializeValCodlnhpd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValCodlnhpd");
		private Lnhpd _lnhpd;
		[DisplayName("Lnhpd")]
		public virtual Lnhpd Lnhpd { get { if (!this.isEmptyModel && (_lnhpd == null || (!string.IsNullOrEmpty(ValCodlnhpd) && (_lnhpd.isEmptyModel || _lnhpd.klass.QPrimaryKey != ValCodlnhpd)))) _lnhpd = Models.Lnhpd.Find(ValCodlnhpd, Identifier, _fieldsToSerialize); if (_lnhpd == null) _lnhpd = new Models.Lnhpd(true, _fieldsToSerialize); return _lnhpd; } set { _lnhpd = value; } }
		public bool ShouldSerializeLnhpd () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: ++ "[LNHPD->CODPEDID]"</summary>
		public string ValCodpedid { get { return klass.ValCodpedid; } set { klass.ValCodpedid = value; } }
		public bool ShouldSerializeValCodpedid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValCodpedid");
		private Pedid _pedid;
		[DisplayName("Pedid")]
		public virtual Pedid Pedid { get { if (!this.isEmptyModel && (_pedid == null || (!string.IsNullOrEmpty(ValCodpedid) && (_pedid.isEmptyModel || _pedid.klass.QPrimaryKey != ValCodpedid)))) _pedid = Models.Pedid.Find(ValCodpedid, Identifier, _fieldsToSerialize); if (_pedid == null) _pedid = new Models.Pedid(true, _fieldsToSerialize); return _pedid; } set { _pedid = value; } }
		public bool ShouldSerializePedid () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOrdem { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValOrdem, 0)); } set { klass.ValOrdem = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOrdem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValOrdem");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValCodtpequ");
		private Tpeq1 _tpeq1;
		[DisplayName("Tpeq1")]
		public virtual Tpeq1 Tpeq1 { get { if (!this.isEmptyModel && (_tpeq1 == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpeq1.isEmptyModel || _tpeq1.klass.QPrimaryKey != ValCodtpequ)))) _tpeq1 = Models.Tpeq1.Find(ValCodtpequ, Identifier, _fieldsToSerialize); if (_tpeq1 == null) _tpeq1 = new Models.Tpeq1(true, _fieldsToSerialize); return _tpeq1; } set { _tpeq1 = value; } }
		public bool ShouldSerializeTpeq1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQuantida { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQuantida, 0)); } set { klass.ValQuantida = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQuantida() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValQuantida");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlnhag { get { return klass.ValCodlnhag; } set { klass.ValCodlnhag = value; } }
		public bool ShouldSerializeValCodlnhag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValCodlnhag");
		private Lnhag _lnhag;
		[DisplayName("Lnhag")]
		public virtual Lnhag Lnhag { get { if (!this.isEmptyModel && (_lnhag == null || (!string.IsNullOrEmpty(ValCodlnhag) && (_lnhag.isEmptyModel || _lnhag.klass.QPrimaryKey != ValCodlnhag)))) _lnhag = Models.Lnhag.Find(ValCodlnhag, Identifier, _fieldsToSerialize); if (_lnhag == null) _lnhag = new Models.Lnhag(true, _fieldsToSerialize); return _lnhag; } set { _lnhag = value; } }
		public bool ShouldSerializeLnhag () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhag");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValDescript");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }
		public bool ShouldSerializeValCode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValCode");

		[DisplayName("Site")]
		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		[HyperLink]
		public string ValUrl { get { return klass.ValUrl; } set { klass.ValUrl = value; } }
		public bool ShouldSerializeValUrl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValUrl");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "ND" Formula: DF "[LNHPD->QUANTDEC]"</summary>
		[NumericAttribute(2)]
		public decimal? ValQuantdec { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQuantdec, 2)); } set { klass.ValQuantdec = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQuantdec() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValQuantdec");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde.ValZzstate");

		public Lnhde() : this(UserContext.Current.User) { }

		public Lnhde(User u)
		{
			this.klass = new CSGenioAlnhde(u);
		}

		public Lnhde(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhde(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Lnhde(bool isEmpty) : this(isEmpty, null) { }

		public Lnhde(CSGenioAlnhde val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhde(CSGenioAlnhde val) : this(val, null) { }

		public Lnhde(CSGenioAlnhde val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Lnhde(CSGenioAlnhde val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlnhde csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lnhpd":
						if (_lnhpd == null)
							_lnhpd = new Lnhpd(true, _fieldsToSerialize);
						_lnhpd.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pedid":
						if (_pedid == null)
							_pedid = new Pedid(true, _fieldsToSerialize);
						_pedid.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpeq1":
						if (_tpeq1 == null)
							_tpeq1 = new Tpeq1(true, _fieldsToSerialize);
						_tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "lnhag":
						if (_lnhag == null)
							_lnhag = new Lnhag(true, _fieldsToSerialize);
						_lnhag.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lnhde Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Lnhde Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhde>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhde(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Lnhde> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlnhde>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Lnhde>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlnhde> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlnhde>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlnhde> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlnhde>(false, args, numRegs: -1);
		}

		public static List<Lnhde> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhde>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhde>((r) => new Lnhde(r));
		}

// USE /[MANUAL GQT MODEL LNHDE]/
	}
}
