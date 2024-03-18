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
	public class Lnhag : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhag klass { get { return baseklass as CSGenioAlnhag; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlnhag { get { return klass.ValCodlnhag; } set { klass.ValCodlnhag = value; } }
		public bool ShouldSerializeValCodlnhag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhag.ValCodlnhag");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: ST "[LNHDE->CODPEDID]"</summary>
		public string ValCodpedid { get { return klass.ValCodpedid; } set { klass.ValCodpedid = value; } }
		public bool ShouldSerializeValCodpedid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhag.ValCodpedid");
		private Pedid _pedid;
		[DisplayName("Pedid")]
		public virtual Pedid Pedid { get { if (!this.isEmptyModel && (_pedid == null || (!string.IsNullOrEmpty(ValCodpedid) && (_pedid.isEmptyModel || _pedid.klass.QPrimaryKey != ValCodpedid)))) _pedid = Models.Pedid.Find(ValCodpedid, Identifier, _fieldsToSerialize); if (_pedid == null) _pedid = new Models.Pedid(true, _fieldsToSerialize); return _pedid; } set { _pedid = value; } }
		public bool ShouldSerializePedid () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: ST "[LNHDE->CODTPEQU]"</summary>
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhag.ValCodtpequ");
		private Tpeq1 _tpeq1;
		[DisplayName("Tpeq1")]
		public virtual Tpeq1 Tpeq1 { get { if (!this.isEmptyModel && (_tpeq1 == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpeq1.isEmptyModel || _tpeq1.klass.QPrimaryKey != ValCodtpequ)))) _tpeq1 = Models.Tpeq1.Find(ValCodtpequ, Identifier, _fieldsToSerialize); if (_tpeq1 == null) _tpeq1 = new Models.Tpeq1(true, _fieldsToSerialize); return _tpeq1; } set { _tpeq1 = value; } }
		public bool ShouldSerializeTpeq1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula: SR "[LNHDE->QUANTIDA]"</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdtpequ { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdtpequ, 0)); } set { klass.ValQtdtpequ = Convert.ToDouble(value); } }
		public bool ShouldSerializeValQtdtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhag.ValQtdtpequ");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhag.ValZzstate");

		public Lnhag() : this(UserContext.Current.User) { }

		public Lnhag(User u)
		{
			this.klass = new CSGenioAlnhag(u);
		}

		public Lnhag(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhag(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Lnhag(bool isEmpty) : this(isEmpty, null) { }

		public Lnhag(CSGenioAlnhag val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhag(CSGenioAlnhag val) : this(val, null) { }

		public Lnhag(CSGenioAlnhag val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Lnhag(CSGenioAlnhag val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlnhag csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Lnhag Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Lnhag Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhag>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhag(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Lnhag> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlnhag>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Lnhag>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlnhag> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlnhag>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlnhag> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlnhag>(false, args, numRegs: -1);
		}

		public static List<Lnhag> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhag>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhag>((r) => new Lnhag(r));
		}

// USE /[MANUAL GQT MODEL LNHAG]/
	}
}
