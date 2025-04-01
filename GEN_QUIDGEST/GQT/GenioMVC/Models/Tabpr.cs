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
	public class Tabpr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtabpr klass { get { return baseklass as CSGenioAtabpr; } set { baseklass = value; } }

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
		public string ValCodtabpr { get { return klass.ValCodtabpr; } set { klass.ValCodtabpr = value; } }
		public bool ShouldSerializeValCodtabpr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tabpr.ValCodtabpr");

		[DisplayName(">TYPE OF EQUIPMENT")]
		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpeq1 { get { return klass.ValCodtpeq1; } set { klass.ValCodtpeq1 = value; } }
		public bool ShouldSerializeValCodtpeq1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tabpr.ValCodtpeq1");
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		public virtual Tpequ Tpequ { get { if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpeq1) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpeq1)))) _tpequ = Models.Tpequ.Find(ValCodtpeq1, Identifier, _fieldsToSerialize); if (_tpequ == null) _tpequ = new Models.Tpequ(true, _fieldsToSerialize); return _tpequ; } set { _tpequ = value; } }
		public bool ShouldSerializeTpequ () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ");

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValSince() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tabpr.ValSince");

		[DisplayName("Price-by-hour")]
		/// <summary>Field : "Price-by-hour" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecohor { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecohor, 2)); } set { klass.ValPrecohor = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecohor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tabpr.ValPrecohor");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tabpr.ValZzstate");

		public Tabpr() : this(UserContext.Current.User) { }

		public Tabpr(User u)
		{
			this.klass = new CSGenioAtabpr(u);
		}

		public Tabpr(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tabpr(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tabpr(bool isEmpty) : this(isEmpty, null) { }

		public Tabpr(CSGenioAtabpr val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tabpr(CSGenioAtabpr val) : this(val, null) { }

		public Tabpr(CSGenioAtabpr val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tabpr(CSGenioAtabpr val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtabpr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Tabpr Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tabpr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtabpr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tabpr(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tabpr> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtabpr>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tabpr>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtabpr> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtabpr>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtabpr> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtabpr>(false, args, numRegs: -1);
		}

		public static List<Tabpr> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtabpr>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tabpr>((r) => new Tabpr(r));
		}

// USE /[MANUAL GQT MODEL TABPR]/
	}
}
