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
	public class Asspa : ModelBase
	{
		[JsonIgnore]
		public CSGenioAasspa klass { get { return baseklass as CSGenioAasspa; } set { baseklass = value; } }

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
		public string ValCodasspa { get { return klass.ValCodasspa; } set { klass.ValCodasspa = value; } }
		public bool ShouldSerializeValCodasspa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValCodasspa");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }
		public bool ShouldSerializeValCodasset() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValCodasset");
		private Asset _asset;
		[DisplayName("Asset")]
		public virtual Asset Asset { get { if (!this.isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset)))) _asset = Models.Asset.Find(ValCodasset, Identifier, _fieldsToSerialize); if (_asset == null) _asset = new Models.Asset(true, _fieldsToSerialize); return _asset; } set { _asset = value; } }
		public bool ShouldSerializeAsset () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		public bool ShouldSerializeValCodkinde() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValCodkinde");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodparam { get { return klass.ValCodparam; } set { klass.ValCodparam = value; } }
		public bool ShouldSerializeValCodparam() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValCodparam");
		private Param _param;
		[DisplayName("Param")]
		public virtual Param Param { get { if (!this.isEmptyModel && (_param == null || (!string.IsNullOrEmpty(ValCodparam) && (_param.isEmptyModel || _param.klass.QPrimaryKey != ValCodparam)))) _param = Models.Param.Find(ValCodparam, Identifier, _fieldsToSerialize); if (_param == null) _param = new Models.Param(true, _fieldsToSerialize); return _param; } set { _param = value; } }
		public bool ShouldSerializeParam () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param");

		[DisplayName("Data type")]
		/// <summary>Field : "Data type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Datatype", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDatatype { get { return klass.ValDatatype; } set { klass.ValDatatype = value; } }
		[JsonIgnore]
		public SelectList ArrayValdatatype { get { return new SelectList(CSGenio.business.ArrayDatatype.GetDictionary(), "Key", "Value", ValDatatype); } set { ValDatatype = value.SelectedValue as string; } }
		public bool ShouldSerializeValDatatype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValDatatype");

		[DisplayName("Decimal places")]
		/// <summary>Field : "Decimal places" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDecimalplaces { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDecimalplaces, 0)); } set { klass.ValDecimalplaces = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDecimalplaces() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValDecimalplaces");

		[DisplayName("Text")]
		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public string ValText { get { return klass.ValText; } set { klass.ValText = value; } }
		public bool ShouldSerializeValText() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValText");

		[DisplayName("Quantity")]
		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(4)]
		public decimal? ValQuantity { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantity, 4)); } set { klass.ValQuantity = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQuantity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValQuantity");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValDate");

		[DisplayName("To show")]
		/// <summary>Field : "To show" Tipo: "C" Formula: + "iif([ASSPA->DATATYPE]=="T",[ASSPA->TEXT],iif([ASSPA->DATATYPE]=="N",NumericToString([ASSPA->QUANTITY],0),iif([ASSPA->DATATYPE]=="D",NumericToString(Year([ASSPA->DATE]),0)+"-"+RIGHT("00"+NumericToString(Month([ASSPA->DATE]),0),2)+"-"+RIGHT("00"+NumericToString(Day([ASSPA->DATE]),0),2),"") ) )"</summary>
		public string ValToshow { get { return klass.ValToshow; } set { klass.ValToshow = value; } }
		public bool ShouldSerializeValToshow() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValToshow");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asspa.ValZzstate");

		public Asspa() : this(UserContext.Current.User) { }

		public Asspa(User u)
		{
			this.klass = new CSGenioAasspa(u);
		}

		public Asspa(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Asspa(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Asspa(bool isEmpty) : this(isEmpty, null) { }

		public Asspa(CSGenioAasspa val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Asspa(CSGenioAasspa val) : this(val, null) { }

		public Asspa(CSGenioAasspa val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Asspa(CSGenioAasspa val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAasspa csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asset":
						if (_asset == null)
							_asset = new Asset(true, _fieldsToSerialize);
						_asset.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "param":
						if (_param == null)
							_param = new Param(true, _fieldsToSerialize);
						_param.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Asspa Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Asspa Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAasspa>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Asspa(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Asspa> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAasspa>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Asspa>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAasspa> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAasspa>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAasspa> All(CriteriaSet args = null)
		{
			return Where<CSGenioAasspa>(false, args, numRegs: -1);
		}

		public static List<Asspa> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAasspa>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Asspa>((r) => new Asspa(r));
		}

// USE /[MANUAL GQT MODEL ASSPA]/
	}
}
