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
	public class Stock : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstock klass { get { return baseklass as CSGenioAstock; } set { baseklass = value; } }

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
		public string ValCodstock { get { return klass.ValCodstock; } set { klass.ValCodstock = value; } }
		public bool ShouldSerializeValCodstock() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValCodstock");

		[DisplayName("Sequence")]
		/// <summary>Field : "Sequence" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValSequence { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSequence, 0)); } set { klass.ValSequence = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSequence() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValSequence");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValDate");

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }
		public bool ShouldSerializeValType() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValType");

		[DisplayName(">>PRODUCT")]
		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }
		public bool ShouldSerializeValCodprodu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValCodprodu");
		private Produ _produ;
		[DisplayName("Produ")]
		public virtual Produ Produ { get { if (!this.isEmptyModel && (_produ == null || (!string.IsNullOrEmpty(ValCodprodu) && (_produ.isEmptyModel || _produ.klass.QPrimaryKey != ValCodprodu)))) _produ = Models.Produ.Find(ValCodprodu, Identifier, _fieldsToSerialize); if (_produ == null) _produ = new Models.Produ(true, _fieldsToSerialize); return _produ; } set { _produ = value; } }
		public bool ShouldSerializeProdu () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ");

		[DisplayName(">>RECEIPT")]
		/// <summary>Field : ">>RECEIPT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodrecei { get { return klass.ValCodrecei; } set { klass.ValCodrecei = value; } }
		public bool ShouldSerializeValCodrecei() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValCodrecei");
		private Recei _recei;
		[DisplayName("Recei")]
		public virtual Recei Recei { get { if (!this.isEmptyModel && (_recei == null || (!string.IsNullOrEmpty(ValCodrecei) && (_recei.isEmptyModel || _recei.klass.QPrimaryKey != ValCodrecei)))) _recei = Models.Recei.Find(ValCodrecei, Identifier, _fieldsToSerialize); if (_recei == null) _recei = new Models.Recei(true, _fieldsToSerialize); return _recei; } set { _recei = value; } }
		public bool ShouldSerializeRecei () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei");

		[DisplayName(">>DISPATCH")]
		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddispa { get { return klass.ValCoddispa; } set { klass.ValCoddispa = value; } }
		public bool ShouldSerializeValCoddispa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValCoddispa");
		private Dispa _dispa;
		[DisplayName("Dispa")]
		public virtual Dispa Dispa { get { if (!this.isEmptyModel && (_dispa == null || (!string.IsNullOrEmpty(ValCoddispa) && (_dispa.isEmptyModel || _dispa.klass.QPrimaryKey != ValCoddispa)))) _dispa = Models.Dispa.Find(ValCoddispa, Identifier, _fieldsToSerialize); if (_dispa == null) _dispa = new Models.Dispa(true, _fieldsToSerialize); return _dispa; } set { _dispa = value; } }
		public bool ShouldSerializeDispa () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa");

		[DisplayName("Quantity")]
		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQuantity { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantity, 0)); } set { klass.ValQuantity = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQuantity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValQuantity");

		[DisplayName("Balance")]
		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValBalance { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBalance, 0)); } set { klass.ValBalance = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBalance() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValBalance");

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }
		public bool ShouldSerializeValReferenc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValReferenc");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stock.ValZzstate");

		public Stock() : this(UserContext.Current.User) { }

		public Stock(User u)
		{
			this.klass = new CSGenioAstock(u);
		}

		public Stock(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stock(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Stock(bool isEmpty) : this(isEmpty, null) { }

		public Stock(CSGenioAstock val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stock(CSGenioAstock val) : this(val, null) { }

		public Stock(CSGenioAstock val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Stock(CSGenioAstock val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAstock csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "produ":
						if (_produ == null)
							_produ = new Produ(true, _fieldsToSerialize);
						_produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "recei":
						if (_recei == null)
							_recei = new Recei(true, _fieldsToSerialize);
						_recei.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "dispa":
						if (_dispa == null)
							_dispa = new Dispa(true, _fieldsToSerialize);
						_dispa.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Stock Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Stock Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstock>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Stock(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Stock> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAstock>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Stock>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAstock> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAstock>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAstock> All(CriteriaSet args = null)
		{
			return Where<CSGenioAstock>(false, args, numRegs: -1);
		}

		public static List<Stock> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstock>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Stock>((r) => new Stock(r));
		}

// USE /[MANUAL GQT MODEL STOCK]/
	}
}
