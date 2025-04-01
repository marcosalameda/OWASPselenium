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
	public class Produ : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprodu klass { get { return baseklass as CSGenioAprodu; } set { baseklass = value; } }

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
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }
		public bool ShouldSerializeValCodprodu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValCodprodu");

		[DisplayName(">>LOCATION")]
		/// <summary>Field : ">>LOCATION" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlocat { get { return klass.ValCodlocat; } set { klass.ValCodlocat = value; } }
		public bool ShouldSerializeValCodlocat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValCodlocat");
		private Locat _locat;
		[DisplayName("Locat")]
		public virtual Locat Locat { get { if (!this.isEmptyModel && (_locat == null || (!string.IsNullOrEmpty(ValCodlocat) && (_locat.isEmptyModel || _locat.klass.QPrimaryKey != ValCodlocat)))) _locat = Models.Locat.Find(ValCodlocat, Identifier, _fieldsToSerialize); if (_locat == null) _locat = new Models.Locat(true, _fieldsToSerialize); return _locat; } set { _locat = value; } }
		public bool ShouldSerializeLocat () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat");

		[DisplayName(">>LOCATION EXTENSION")]
		/// <summary>Field : ">>LOCATION EXTENSION" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlcext { get { return klass.ValCodlcext; } set { klass.ValCodlcext = value; } }
		public bool ShouldSerializeValCodlcext() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValCodlcext");
		private Lcext _lcext;
		[DisplayName("Lcext")]
		public virtual Lcext Lcext { get { if (!this.isEmptyModel && (_lcext == null || (!string.IsNullOrEmpty(ValCodlcext) && (_lcext.isEmptyModel || _lcext.klass.QPrimaryKey != ValCodlcext)))) _lcext = Models.Lcext.Find(ValCodlcext, Identifier, _fieldsToSerialize); if (_lcext == null) _lcext = new Models.Lcext(true, _fieldsToSerialize); return _lcext; } set { _lcext = value; } }
		public bool ShouldSerializeLcext () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext");

		[DisplayName("Product")]
		/// <summary>Field : "Product" Tipo: "C" Formula:  ""</summary>
		public string ValProduct { get { return klass.ValProduct; } set { klass.ValProduct = value; } }
		public bool ShouldSerializeValProduct() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValProduct");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValDescript");

		[DisplayName("SKU")]
		/// <summary>Field : "SKU" Tipo: "C" Formula:  ""</summary>
		public string ValSku { get { return klass.ValSku; } set { klass.ValSku = value; } }
		public bool ShouldSerializeValSku() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValSku");

		[DisplayName("GTIN")]
		/// <summary>Field : "GTIN" Tipo: "C" Formula:  ""</summary>
		public string ValGtin { get { return klass.ValGtin; } set { klass.ValGtin = value; } }
		public bool ShouldSerializeValGtin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValGtin");

		[DisplayName("Size")]
		/// <summary>Field : "Size" Tipo: "C" Formula:  ""</summary>
		public string ValSize { get { return klass.ValSize; } set { klass.ValSize = value; } }
		public bool ShouldSerializeValSize() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValSize");

		[DisplayName("Weight")]
		/// <summary>Field : "Weight" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValWeight { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValWeight, 2)); } set { klass.ValWeight = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValWeight() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValWeight");

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrice, 4)); } set { klass.ValPrice = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrice() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValPrice");

		[DisplayName("Inputs")]
		/// <summary>Field : "Inputs" Tipo: "N" Formula: SR "[RELIN->RECEIVED]"</summary>
		[NumericAttribute(0)]
		public decimal? ValInputs { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValInputs, 0)); } set { klass.ValInputs = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValInputs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValInputs");

		[DisplayName("Outputs")]
		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[DILIN->DELIVERE]"</summary>
		[NumericAttribute(0)]
		public decimal? ValOutputs { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValOutputs, 0)); } set { klass.ValOutputs = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOutputs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValOutputs");

		[DisplayName("Stock")]
		/// <summary>Field : "Stock" Tipo: "N" Formula: SR "[RELIN->RECEIVED]-[DILIN->DELIVERE]"</summary>
		[NumericAttribute(0)]
		public decimal? ValStock { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValStock, 0)); } set { klass.ValStock = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValStock() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValStock");

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }
		public bool ShouldSerializeValImage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValImage");

		[DisplayName("In use")]
		/// <summary>Field : "In use" Tipo: "AL" Formula:  ""</summary>
		[DataArray("Yesno", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValIn_use { get { return klass.ValIn_use; } set { klass.ValIn_use = value; } }
		[JsonIgnore]
		public SelectList ArrayValin_use { get { return new SelectList(CSGenio.business.ArrayYesno.GetDictionary(), "Key", "Value", ValIn_use); } set { ValIn_use = (int)value.SelectedValue; } }
		public bool ShouldSerializeValIn_use() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValIn_use");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ.ValZzstate");

		public Produ() : this(UserContext.Current.User) { }

		public Produ(User u)
		{
			this.klass = new CSGenioAprodu(u);
		}

		public Produ(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Produ(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Produ(bool isEmpty) : this(isEmpty, null) { }

		public Produ(CSGenioAprodu val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Produ(CSGenioAprodu val) : this(val, null) { }

		public Produ(CSGenioAprodu val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Produ(CSGenioAprodu val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAprodu csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "locat":
						if (_locat == null)
							_locat = new Locat(true, _fieldsToSerialize);
						_locat.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "lcext":
						if (_lcext == null)
							_lcext = new Lcext(true, _fieldsToSerialize);
						_lcext.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Produ Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Produ Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprodu>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Produ(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Produ> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAprodu>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Produ>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAprodu> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAprodu>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAprodu> All(CriteriaSet args = null)
		{
			return Where<CSGenioAprodu>(false, args, numRegs: -1);
		}

		public static List<Produ> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprodu>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Produ>((r) => new Produ(r));
		}

// USE /[MANUAL GQT MODEL PRODU]/
	}
}
