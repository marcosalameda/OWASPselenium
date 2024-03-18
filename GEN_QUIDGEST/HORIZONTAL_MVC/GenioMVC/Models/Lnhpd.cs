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
	public class Lnhpd : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhpd klass { get { return baseklass as CSGenioAlnhpd; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlnhpd { get { return klass.ValCodlnhpd; } set { klass.ValCodlnhpd = value; } }
		public bool ShouldSerializeValCodlnhpd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd.ValCodlnhpd");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpedid { get { return klass.ValCodpedid; } set { klass.ValCodpedid = value; } }
		public bool ShouldSerializeValCodpedid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd.ValCodpedid");
		private Pedid _pedid;
		[DisplayName("Pedid")]
		public virtual Pedid Pedid { get { if (!this.isEmptyModel && (_pedid == null || (!string.IsNullOrEmpty(ValCodpedid) && (_pedid.isEmptyModel || _pedid.klass.QPrimaryKey != ValCodpedid)))) _pedid = Models.Pedid.Find(ValCodpedid, Identifier, _fieldsToSerialize); if (_pedid == null) _pedid = new Models.Pedid(true, _fieldsToSerialize); return _pedid; } set { _pedid = value; } }
		public bool ShouldSerializePedid () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid");

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValLine { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLine, 0)); } set { klass.ValLine = Convert.ToDouble(value); } }
		public bool ShouldSerializeValLine() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd.ValLine");

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd.ValCodtpequ");
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		public virtual Tpequ Tpequ { get { if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ)))) _tpequ = Models.Tpequ.Find(ValCodtpequ, Identifier, _fieldsToSerialize); if (_tpequ == null) _tpequ = new Models.Tpequ(true, _fieldsToSerialize); return _tpequ; } set { _tpequ = value; } }
		public bool ShouldSerializeTpequ () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQuantida { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantida, 0)); } set { klass.ValQuantida = Convert.ToDouble(value); } }
		public bool ShouldSerializeValQuantida() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd.ValQuantida");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhpd.ValZzstate");

		public Lnhpd() : this(UserContext.Current.User) { }

		public Lnhpd(User u)
		{
			this.klass = new CSGenioAlnhpd(u);
		}

		public Lnhpd(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhpd(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Lnhpd(bool isEmpty) : this(isEmpty, null) { }

		public Lnhpd(CSGenioAlnhpd val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhpd(CSGenioAlnhpd val) : this(val, null) { }

		public Lnhpd(CSGenioAlnhpd val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Lnhpd(CSGenioAlnhpd val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlnhpd csgenioa)
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
					case "tpequ":
						if (_tpequ == null)
							_tpequ = new Tpequ(true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lnhpd Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Lnhpd Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhpd>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhpd(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Lnhpd> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlnhpd>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Lnhpd>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlnhpd> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlnhpd>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlnhpd> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlnhpd>(false, args, numRegs: -1);
		}

		public static List<Lnhpd> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhpd>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhpd>((r) => new Lnhpd(r));
		}

		public StatusMessage carga_CONJUNTO(string idsrc)
		{
			StatusMessage Qresult = null;
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			Qresult = this.klass.carga_CONJUNTO(idsrc,sp,u);

			return Qresult;
		}

// USE /[MANUAL GQT MODEL LNHPD]/
	}
}
