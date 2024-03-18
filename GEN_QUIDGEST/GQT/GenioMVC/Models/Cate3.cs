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
	public class Cate3 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcate3 klass { get { return baseklass as CSGenioAcate3; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		public bool ShouldSerializeValCodcateg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cate3.ValCodcateg");

		[DisplayName("Technical category")]
		/// <summary>Field : "Technical category" Tipo: "C" Formula:  ""</summary>
		public string ValCategoria { get { return klass.ValCategoria; } set { klass.ValCategoria = value; } }
		public bool ShouldSerializeValCategoria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cate3.ValCategoria");

		[DisplayName("Abbreviation")]
		/// <summary>Field : "Abbreviation" Tipo: "C" Formula:  ""</summary>
		public string ValAbbreviation { get { return klass.ValAbbreviation; } set { klass.ValAbbreviation = value; } }
		public bool ShouldSerializeValAbbreviation() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cate3.ValAbbreviation");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cate3.ValZzstate");

		public Cate3() : this(UserContext.Current.User) { }

		public Cate3(User u)
		{
			this.klass = new CSGenioAcate3(u);
		}

		public Cate3(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cate3(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Cate3(bool isEmpty) : this(isEmpty, null) { }

		public Cate3(CSGenioAcate3 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cate3(CSGenioAcate3 val) : this(val, null) { }

		public Cate3(CSGenioAcate3 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Cate3(CSGenioAcate3 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcate3 csgenioa)
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
		public static Cate3 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Cate3 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcate3>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cate3(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Cate3> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcate3>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Cate3>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcate3> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcate3>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcate3> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcate3>(false, args, numRegs: -1);
		}

		public static List<Cate3> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcate3>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cate3>((r) => new Cate3(r));
		}

// USE /[MANUAL GQT MODEL CATE3]/
	}
}
