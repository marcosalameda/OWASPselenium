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
	public class Ccorr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAccorr klass { get { return baseklass as CSGenioAccorr; } set { baseklass = value; } }

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
		public string ValCodccorr { get { return klass.ValCodccorr; } set { klass.ValCodccorr = value; } }
		public bool ShouldSerializeValCodccorr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValCodccorr");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNorder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNorder, 0)); } set { klass.ValNorder = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNorder() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValNorder");

		[DisplayName("Instant")]
		/// <summary>Field : "Instant" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValDate");

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }
		public bool ShouldSerializeValType() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValType");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValCoditem");
		private Item _item;
		[DisplayName("Item")]
		public virtual Item Item { get { if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem)))) _item = Models.Item.Find(ValCoditem, Identifier, _fieldsToSerialize); if (_item == null) _item = new Models.Item(true, _fieldsToSerialize); return _item; } set { _item = value; } }
		public bool ShouldSerializeItem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddentr { get { return klass.ValCoddentr; } set { klass.ValCoddentr = value; } }
		public bool ShouldSerializeValCoddentr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValCoddentr");
		private Indoc _indoc;
		[DisplayName("Indoc")]
		public virtual Indoc Indoc { get { if (!this.isEmptyModel && (_indoc == null || (!string.IsNullOrEmpty(ValCoddentr) && (_indoc.isEmptyModel || _indoc.klass.QPrimaryKey != ValCoddentr)))) _indoc = Models.Indoc.Find(ValCoddentr, Identifier, _fieldsToSerialize); if (_indoc == null) _indoc = new Models.Indoc(true, _fieldsToSerialize); return _indoc; } set { _indoc = value; } }
		public bool ShouldSerializeIndoc () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQnty { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQnty, 0)); } set { klass.ValQnty = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQnty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValQnty");

		[DisplayName("Balance")]
		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValBalance { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBalance, 0)); } set { klass.ValBalance = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBalance() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValBalance");

		[DisplayName("Ref")]
		/// <summary>Field : "Ref" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }
		public bool ShouldSerializeValReferenc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValReferenc");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ccorr.ValZzstate");

		public Ccorr() : this(UserContext.Current.User) { }

		public Ccorr(User u)
		{
			this.klass = new CSGenioAccorr(u);
		}

		public Ccorr(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ccorr(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Ccorr(bool isEmpty) : this(isEmpty, null) { }

		public Ccorr(CSGenioAccorr val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ccorr(CSGenioAccorr val) : this(val, null) { }

		public Ccorr(CSGenioAccorr val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Ccorr(CSGenioAccorr val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAccorr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
						if (_item == null)
							_item = new Item(true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "indoc":
						if (_indoc == null)
							_indoc = new Indoc(true, _fieldsToSerialize);
						_indoc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Ccorr Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Ccorr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAccorr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ccorr(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Ccorr> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAccorr>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Ccorr>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAccorr> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAccorr>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAccorr> All(CriteriaSet args = null)
		{
			return Where<CSGenioAccorr>(false, args, numRegs: -1);
		}

		public static List<Ccorr> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAccorr>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ccorr>((r) => new Ccorr(r));
		}

// USE /[MANUAL GQT MODEL CCORR]/
	}
}
