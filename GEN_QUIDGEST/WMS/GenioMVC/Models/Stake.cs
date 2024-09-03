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
	public class Stake : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstake klass { get { return baseklass as CSGenioAstake; } set { baseklass = value; } }

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
		public string ValCodparte { get { return klass.ValCodparte; } set { klass.ValCodparte = value; } }
		public bool ShouldSerializeValCodparte() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValCodparte");

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValDesignat");

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValSigla { get { return klass.ValSigla; } set { klass.ValSigla = value; } }
		public bool ShouldSerializeValSigla() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValSigla");

		[DisplayName("Tax identification")]
		/// <summary>Field : "Tax identification" Tipo: "C" Formula:  ""</summary>
		public string ValNif { get { return klass.ValNif; } set { klass.ValNif = value; } }
		public bool ShouldSerializeValNif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValNif");

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValTelephon");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValEmail");

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLogotipo { get { return klass.ValLogotipo; } set { klass.ValLogotipo = value; } }
		public bool ShouldSerializeValLogotipo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValLogotipo");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake.ValZzstate");

		public Stake() : this(UserContext.Current.User) { }

		public Stake(User u)
		{
			this.klass = new CSGenioAstake(u);
		}

		public Stake(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stake(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Stake(bool isEmpty) : this(isEmpty, null) { }

		public Stake(CSGenioAstake val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stake(CSGenioAstake val) : this(val, null) { }

		public Stake(CSGenioAstake val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Stake(CSGenioAstake val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAstake csgenioa)
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
		public static Stake Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Stake Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstake>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Stake(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Stake> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAstake>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Stake>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAstake> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAstake>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAstake> All(CriteriaSet args = null)
		{
			return Where<CSGenioAstake>(false, args, numRegs: -1);
		}

		public static List<Stake> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstake>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Stake>((r) => new Stake(r));
		}

// USE /[MANUAL GQT MODEL STAKE]/
	}
}
