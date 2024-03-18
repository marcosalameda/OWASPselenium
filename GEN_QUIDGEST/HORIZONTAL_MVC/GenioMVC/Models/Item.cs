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
	public class Item : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitem klass { get { return baseklass as CSGenioAitem; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValCoditem");

		[DisplayName(">GLOBAL ARTICLE")]
		/// <summary>Field : ">GLOBAL ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodgitem { get { return klass.ValCodgitem; } set { klass.ValCodgitem = value; } }
		public bool ShouldSerializeValCodgitem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValCodgitem");
		private Gitem _gitem;
		[DisplayName("Gitem")]
		public virtual Gitem Gitem { get { if (!this.isEmptyModel && (_gitem == null || (!string.IsNullOrEmpty(ValCodgitem) && (_gitem.isEmptyModel || _gitem.klass.QPrimaryKey != ValCodgitem)))) _gitem = Models.Gitem.Find(ValCodgitem, Identifier, _fieldsToSerialize); if (_gitem == null) _gitem = new Models.Gitem(true, _fieldsToSerialize); return _gitem; } set { _gitem = value; } }
		public bool ShouldSerializeGitem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Gitem");

		[DisplayName(">WAREHOUSE")]
		/// <summary>Field : ">WAREHOUSE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValCodwareh");
		private Wareh _wareh;
		[DisplayName("Wareh")]
		public virtual Wareh Wareh { get { if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh)))) _wareh = Models.Wareh.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_wareh == null) _wareh = new Models.Wareh(true, _fieldsToSerialize); return _wareh; } set { _wareh = value; } }
		public bool ShouldSerializeWareh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh");

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Tipoarti", GenioMVC.Helpers.ArrayType.Character)]
		public string ValItemtype { get { return klass.ValItemtype; } set { klass.ValItemtype = value; } }
		[JsonIgnore]
		public SelectList ArrayValitemtype { get { return new SelectList(CSGenio.business.ArrayTipoarti.GetDictionary(), "Key", "Value", ValItemtype); } set { ValItemtype = value.SelectedValue as string; } }
		public bool ShouldSerializeValItemtype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValItemtype");

		[DisplayName("Article")]
		/// <summary>Field : "Article" Tipo: "C" Formula: DF "[GITEM->ITEMDES]"</summary>
		public string ValItemdes { get { return klass.ValItemdes; } set { klass.ValItemdes = value; } }
		public bool ShouldSerializeValItemdes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValItemdes");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula: DF "[GITEM->ITEMGCOD]"</summary>
		public string ValItemcod { get { return klass.ValItemcod; } set { klass.ValItemcod = value; } }
		public bool ShouldSerializeValItemcod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValItemcod");

		[DisplayName("Entries")]
		/// <summary>Field : "Entries" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]"</summary>
		[NumericAttribute(0)]
		public decimal? ValEntries { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValEntries, 0)); } set { klass.ValEntries = Convert.ToDouble(value); } }
		public bool ShouldSerializeValEntries() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValEntries");

		[DisplayName("Outputs")]
		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[OUTPU->EXITQNTY]"</summary>
		[NumericAttribute(0)]
		public decimal? ValExits { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExits, 0)); } set { klass.ValExits = Convert.ToDouble(value); } }
		public bool ShouldSerializeValExits() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValExits");

		[DisplayName("Stocks")]
		/// <summary>Field : "Stocks" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]-[OUTPU->EXITQNTY]"</summary>
		[NumericAttribute(0)]
		public decimal? ValExistenc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExistenc, 0)); } set { klass.ValExistenc = Convert.ToDouble(value); } }
		public bool ShouldSerializeValExistenc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValExistenc");

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }
		public bool ShouldSerializeValImage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValImage");

		[DisplayName("Categorization")]
		/// <summary>Field : "Categorization" Tipo: "MO" Formula: CL "ITEMC[ITEMC->TPCATEG][ITEMC->TPCATEG](; )"</summary>
		[DataType(DataType.MultilineText)]
		public string ValCategory { get { return klass.ValCategory; } set { klass.ValCategory = value; } }
		public bool ShouldSerializeValCategory() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValCategory");

		[DisplayName("In use")]
		/// <summary>Field : "In use" Tipo: "L" Formula:  ""</summary>
		public bool ValValid { get { return Convert.ToBoolean(klass.ValValid); } set { klass.ValValid = Convert.ToInt32(value); } }
		public bool ShouldSerializeValValid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValValid");

		[DisplayName("Availability")]
		/// <summary>Field : "Availability" Tipo: "AC" Formula: + "iif([ITEM->EXISTENC]>0,"A",iif([ITEM->EXISTENC]<=0,"O","D"))"</summary>
		[DataArray("Dsiponib", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDisponib { get { return klass.ValDisponib; } set { klass.ValDisponib = value; } }
		[JsonIgnore]
		public SelectList ArrayValdisponib { get { return new SelectList(CSGenio.business.ArrayDsiponib.GetDictionary(), "Key", "Value", ValDisponib); } set { ValDisponib = value.SelectedValue as string; } }
		public bool ShouldSerializeValDisponib() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValDisponib");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValDate");

		[DisplayName("Specifications")]
		/// <summary>Field : "Specifications" Tipo: "IB" Formula:  ""</summary>
		[Document("ValTechspec", false, true, false, false)]
		public string ValTechspec { get { return klass.ValTechspec; } set { klass.ValTechspec = value; } }
		public string ValTechspecfk { get { return klass.ValTechspecfk; } set { klass.ValTechspecfk = value; } }
		public bool ShouldSerializeValTechspec() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValTechspec");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item.ValZzstate");

		public Item() : this(UserContext.Current.User) { }

		public Item(User u)
		{
			this.klass = new CSGenioAitem(u);
		}

		public Item(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Item(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Item(bool isEmpty) : this(isEmpty, null) { }

		public Item(CSGenioAitem val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Item(CSGenioAitem val) : this(val, null) { }

		public Item(CSGenioAitem val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Item(CSGenioAitem val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAitem csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "gitem":
						if (_gitem == null)
							_gitem = new Gitem(true, _fieldsToSerialize);
						_gitem.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "wareh":
						if (_wareh == null)
							_wareh = new Wareh(true, _fieldsToSerialize);
						_wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Item Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Item Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitem>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Item(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Item> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAitem>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Item>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAitem> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAitem>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAitem> All(CriteriaSet args = null)
		{
			return Where<CSGenioAitem>(false, args, numRegs: -1);
		}

		public static List<Item> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitem>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Item>((r) => new Item(r));
		}

// USE /[MANUAL GQT MODEL ITEM]/
	}
}
