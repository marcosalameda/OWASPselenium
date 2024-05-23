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
	public class Regio : ModelBase
	{
		[JsonIgnore]
		public CSGenioAregio klass { get { return baseklass as CSGenioAregio; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		public bool ShouldSerializeValCodregia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio.ValCodregia");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio.ValCodcntry");
		private Cntry _cntry;
		[DisplayName("Cntry")]
		public virtual Cntry Cntry { get { if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry)))) _cntry = Models.Cntry.Find(ValCodcntry, Identifier, _fieldsToSerialize); if (_cntry == null) _cntry = new Models.Cntry(true, _fieldsToSerialize); return _cntry; } set { _cntry = value; } }
		public bool ShouldSerializeCntry () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry");

		[DisplayName("Region")]
		/// <summary>Field : "Region" Tipo: "C" Formula:  ""</summary>
		public string ValRegiao { get { return klass.ValRegiao; } set { klass.ValRegiao = value; } }
		public bool ShouldSerializeValRegiao() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio.ValRegiao");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpais1 { get { return klass.ValCodpais1; } set { klass.ValCodpais1 = value; } }
		public bool ShouldSerializeValCodpais1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio.ValCodpais1");
		private Pais1 _pais1;
		[DisplayName("Pais1")]
		public virtual Pais1 Pais1 { get { if (!this.isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodpais1) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodpais1)))) _pais1 = Models.Pais1.Find(ValCodpais1, Identifier, _fieldsToSerialize); if (_pais1 == null) _pais1 = new Models.Pais1(true, _fieldsToSerialize); return _pais1; } set { _pais1 = value; } }
		public bool ShouldSerializePais1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio.ValZzstate");

		public Regio() : this(UserContext.Current.User) { }

		public Regio(User u)
		{
			this.klass = new CSGenioAregio(u);
		}

		public Regio(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Regio(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Regio(bool isEmpty) : this(isEmpty, null) { }

		public Regio(CSGenioAregio val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Regio(CSGenioAregio val) : this(val, null) { }

		public Regio(CSGenioAregio val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Regio(CSGenioAregio val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAregio csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pais1":
						if (_pais1 == null)
							_pais1 = new Pais1(true, _fieldsToSerialize);
						_pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Regio Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Regio Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAregio>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Regio(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Regio> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAregio>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Regio>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAregio> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAregio>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAregio> All(CriteriaSet args = null)
		{
			return Where<CSGenioAregio>(false, args, numRegs: -1);
		}

		public static List<Regio> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAregio>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Regio>((r) => new Regio(r));
		}

// USE /[MANUAL GQT MODEL REGIO]/
	}
}
