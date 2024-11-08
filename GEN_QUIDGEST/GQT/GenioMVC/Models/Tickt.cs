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
	public class Tickt : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtickt klass { get { return baseklass as CSGenioAtickt; } set { baseklass = value; } }

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
		public string ValCodtickt { get { return klass.ValCodtickt; } set { klass.ValCodtickt = value; } }
		public bool ShouldSerializeValCodtickt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tickt.ValCodtickt");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsngr { get { return klass.ValCodpsngr; } set { klass.ValCodpsngr = value; } }
		public bool ShouldSerializeValCodpsngr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tickt.ValCodpsngr");
		private Psngr _psngr;
		[DisplayName("Psngr")]
		public virtual Psngr Psngr { get { if (!this.isEmptyModel && (_psngr == null || (!string.IsNullOrEmpty(ValCodpsngr) && (_psngr.isEmptyModel || _psngr.klass.QPrimaryKey != ValCodpsngr)))) _psngr = Models.Psngr.Find(ValCodpsngr, Identifier, _fieldsToSerialize); if (_psngr == null) _psngr = new Models.Psngr(true, _fieldsToSerialize); return _psngr; } set { _psngr = value; } }
		public bool ShouldSerializePsngr () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr");

		[DisplayName("Ticket ID")]
		/// <summary>Field : "Ticket ID" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValTktid { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValTktid, 0)); } set { klass.ValTktid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValTktid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tickt.ValTktid");

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrice() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tickt.ValPrice");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tickt.ValZzstate");

		public Tickt() : this(UserContext.Current.User) { }

		public Tickt(User u)
		{
			this.klass = new CSGenioAtickt(u);
		}

		public Tickt(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tickt(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tickt(bool isEmpty) : this(isEmpty, null) { }

		public Tickt(CSGenioAtickt val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tickt(CSGenioAtickt val) : this(val, null) { }

		public Tickt(CSGenioAtickt val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tickt(CSGenioAtickt val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtickt csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "psngr":
						if (_psngr == null)
							_psngr = new Psngr(true, _fieldsToSerialize);
						_psngr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tickt Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tickt Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtickt>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tickt(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tickt> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtickt>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tickt>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtickt> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtickt>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtickt> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtickt>(false, args, numRegs: -1);
		}

		public static List<Tickt> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtickt>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tickt>((r) => new Tickt(r));
		}

// USE /[MANUAL GQT MODEL TICKT]/
	}
}
