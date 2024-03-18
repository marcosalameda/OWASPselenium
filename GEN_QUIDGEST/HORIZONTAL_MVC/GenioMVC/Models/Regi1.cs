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
	public class Regi1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAregi1 klass { get { return baseklass as CSGenioAregi1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		public bool ShouldSerializeValCodregia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regi1.ValCodregia");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regi1.ValCodcntry");
		private Pais1 _pais1;
		[DisplayName("Pais1")]
		public virtual Pais1 Pais1 { get { if (!this.isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodcntry) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodcntry)))) _pais1 = Models.Pais1.Find(ValCodcntry, Identifier, _fieldsToSerialize); if (_pais1 == null) _pais1 = new Models.Pais1(true, _fieldsToSerialize); return _pais1; } set { _pais1 = value; } }
		public bool ShouldSerializePais1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1");

		[DisplayName("Region")]
		/// <summary>Field : "Region" Tipo: "C" Formula:  ""</summary>
		public string ValRegiao { get { return klass.ValRegiao; } set { klass.ValRegiao = value; } }
		public bool ShouldSerializeValRegiao() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regi1.ValRegiao");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodpais1 { get { return klass.ValCodpais1; } set { klass.ValCodpais1 = value; } }
		public bool ShouldSerializeValCodpais1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regi1.ValCodpais1");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regi1.ValZzstate");

		public Regi1() : this(UserContext.Current.User) { }

		public Regi1(User u)
		{
			this.klass = new CSGenioAregi1(u);
		}

		public Regi1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Regi1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Regi1(bool isEmpty) : this(isEmpty, null) { }

		public Regi1(CSGenioAregi1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Regi1(CSGenioAregi1 val) : this(val, null) { }

		public Regi1(CSGenioAregi1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Regi1(CSGenioAregi1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAregi1 csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Regi1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Regi1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAregi1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Regi1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Regi1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAregi1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Regi1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAregi1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAregi1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAregi1> All(CriteriaSet args = null)
		{
			return Where<CSGenioAregi1>(false, args, numRegs: -1);
		}

		public static List<Regi1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAregi1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Regi1>((r) => new Regi1(r));
		}

// USE /[MANUAL GQT MODEL REGI1]/
	}
}
