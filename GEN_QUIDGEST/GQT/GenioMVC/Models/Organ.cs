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
	public class Organ : ModelBase
	{
		[JsonIgnore]
		public CSGenioAorgan klass { get { return baseklass as CSGenioAorgan; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodorgan { get { return klass.ValCodorgan; } set { klass.ValCodorgan = value; } }
		public bool ShouldSerializeValCodorgan() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ.ValCodorgan");

		[DisplayName("Organization")]
		/// <summary>Field : "Organization" Tipo: "C" Formula:  ""</summary>
		public string ValOrganiza { get { return klass.ValOrganiza; } set { klass.ValOrganiza = value; } }
		public bool ShouldSerializeValOrganiza() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ.ValOrganiza");

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValSigla { get { return klass.ValSigla; } set { klass.ValSigla = value; } }
		public bool ShouldSerializeValSigla() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ.ValSigla");

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLogo { get { return klass.ValLogo; } set { klass.ValLogo = value; } }
		public bool ShouldSerializeValLogo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ.ValLogo");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ.ValZzstate");

		public Organ() : this(UserContext.Current.User) { }

		public Organ(User u)
		{
			this.klass = new CSGenioAorgan(u);
		}

		public Organ(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Organ(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Organ(bool isEmpty) : this(isEmpty, null) { }

		public Organ(CSGenioAorgan val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Organ(CSGenioAorgan val) : this(val, null) { }

		public Organ(CSGenioAorgan val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Organ(CSGenioAorgan val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAorgan csgenioa)
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
		public static Organ Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Organ Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAorgan>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Organ(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Organ> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAorgan>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Organ>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAorgan> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAorgan>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAorgan> All(CriteriaSet args = null)
		{
			return Where<CSGenioAorgan>(false, args, numRegs: -1);
		}

		public static List<Organ> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAorgan>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Organ>((r) => new Organ(r));
		}

// USE /[MANUAL GQT MODEL ORGAN]/
	}
}
