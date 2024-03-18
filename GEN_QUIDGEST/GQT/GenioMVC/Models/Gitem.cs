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
	public class Gitem : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgitem klass { get { return baseklass as CSGenioAgitem; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodgitem { get { return klass.ValCodgitem; } set { klass.ValCodgitem = value; } }
		public bool ShouldSerializeValCodgitem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Gitem.ValCodgitem");

		[DisplayName("Global article")]
		/// <summary>Field : "Global article" Tipo: "C" Formula:  ""</summary>
		public string ValItemdes { get { return klass.ValItemdes; } set { klass.ValItemdes = value; } }
		public bool ShouldSerializeValItemdes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Gitem.ValItemdes");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public string ValItemgcod { get { return klass.ValItemgcod; } set { klass.ValItemgcod = value; } }
		public bool ShouldSerializeValItemgcod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Gitem.ValItemgcod");

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDocument", false, true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }
		public bool ShouldSerializeValDocument() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Gitem.ValDocument");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Gitem.ValZzstate");

		public Gitem() : this(UserContext.Current.User) { }

		public Gitem(User u)
		{
			this.klass = new CSGenioAgitem(u);
		}

		public Gitem(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Gitem(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Gitem(bool isEmpty) : this(isEmpty, null) { }

		public Gitem(CSGenioAgitem val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Gitem(CSGenioAgitem val) : this(val, null) { }

		public Gitem(CSGenioAgitem val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Gitem(CSGenioAgitem val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAgitem csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Gitem Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Gitem Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgitem>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Gitem(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Gitem> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAgitem>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Gitem>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAgitem> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAgitem>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAgitem> All(CriteriaSet args = null)
		{
			return Where<CSGenioAgitem>(false, args, numRegs: -1);
		}

		public static List<Gitem> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgitem>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Gitem>((r) => new Gitem(r));
		}

// USE /[MANUAL GQT MODEL GITEM]/
	}
}
