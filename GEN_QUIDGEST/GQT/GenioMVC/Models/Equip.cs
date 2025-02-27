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
	public class Equip : ModelBase
	{
		[JsonIgnore]
		public CSGenioAequip klass { get { return baseklass as CSGenioAequip; } set { baseklass = value; } }

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
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCodequip");

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		public bool ShouldSerializeValCodempre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCodempre");
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		public virtual Cmpny Cmpny { get { if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre)))) _cmpny = Models.Cmpny.Find(ValCodempre, Identifier, _fieldsToSerialize); if (_cmpny == null) _cmpny = new Models.Cmpny(true, _fieldsToSerialize); return _cmpny; } set { _cmpny = value; } }
		public bool ShouldSerializeCmpny () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny");

		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		public bool ShouldSerializeValCodpess1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCodpess1");
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		public virtual Pess1 Pess1 { get { if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1)))) _pess1 = Models.Pess1.Find(ValCodpess1, Identifier, _fieldsToSerialize); if (_pess1 == null) _pess1 = new Models.Pess1(true, _fieldsToSerialize); return _pess1; } set { _pess1 = value; } }
		public bool ShouldSerializePess1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess1");

		[DisplayName("Sequential no.")]
		/// <summary>Field : "Sequential no." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValSequennr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSequennr, 0)); } set { klass.ValSequennr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSequennr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValSequennr");

		[DisplayName("No. register")]
		/// <summary>Field : "No. register" Tipo: "C" Formula: + "RIGHT("000000"+NumericToString([EQUIP->SEQUENNR],0),6)"</summary>
		public string ValRegistnr { get { return klass.ValRegistnr; } set { klass.ValRegistnr = value; } }
		public bool ShouldSerializeValRegistnr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValRegistnr");

		[DisplayName(">TYPE OF EQUIPMENT")]
		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCodtpequ");
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		public virtual Tpequ Tpequ { get { if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ)))) _tpequ = Models.Tpequ.Find(ValCodtpequ, Identifier, _fieldsToSerialize); if (_tpequ == null) _tpequ = new Models.Tpequ(true, _fieldsToSerialize); return _tpequ; } set { _tpequ = value; } }
		public bool ShouldSerializeTpequ () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCodwareh");
		private Wareh _wareh;
		[DisplayName("Wareh")]
		public virtual Wareh Wareh { get { if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh)))) _wareh = Models.Wareh.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_wareh == null) _wareh = new Models.Wareh(true, _fieldsToSerialize); return _wareh; } set { _wareh = value; } }
		public bool ShouldSerializeWareh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCoditem");
		private Item _item;
		[DisplayName("Item")]
		public virtual Item Item { get { if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem)))) _item = Models.Item.Find(ValCoditem, Identifier, _fieldsToSerialize); if (_item == null) _item = new Models.Item(true, _fieldsToSerialize); return _item; } set { _item = value; } }
		public bool ShouldSerializeItem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item");

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula: DF "[ITEM->ITEMDES]"</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValDesignat");

		[DisplayName("Acquisition")]
		/// <summary>Field : "Acquisition" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtaquisi { get { return klass.ValDtaquisi; } set { klass.ValDtaquisi = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtaquisi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValDtaquisi");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddeco { get { return klass.ValCoddeco; } set { klass.ValCoddeco = value; } }
		public bool ShouldSerializeValCoddeco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCoddeco");
		private Decom _decom;
		[DisplayName("Decom")]
		public virtual Decom Decom { get { if (!this.isEmptyModel && (_decom == null || (!string.IsNullOrEmpty(ValCoddeco) && (_decom.isEmptyModel || _decom.klass.QPrimaryKey != ValCoddeco)))) _decom = Models.Decom.Find(ValCoddeco, Identifier, _fieldsToSerialize); if (_decom == null) _decom = new Models.Decom(true, _fieldsToSerialize); return _decom; } set { _decom = value; } }
		public bool ShouldSerializeDecom () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom");

		[DisplayName("Decomission")]
		/// <summary>Field : "Decomission" Tipo: "DT" Formula: ++ "[DECOM->DTDECO]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtdeco { get { return klass.ValDtdeco; } set { klass.ValDtdeco = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtdeco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValDtdeco");

		[DisplayName("Downed equipment")]
		/// <summary>Field : "Downed equipment" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTDECO])==1,0,1)"</summary>
		public bool ValIfabatif { get { return Convert.ToBoolean(klass.ValIfabatif); } set { klass.ValIfabatif = Convert.ToInt32(value); } }
		public bool ShouldSerializeValIfabatif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValIfabatif");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhotogra { get { return klass.ValPhotogra; } set { klass.ValPhotogra = value; } }
		public bool ShouldSerializeValPhotogra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValPhotogra");

		[DisplayName("Total value")]
		/// <summary>Field : "Total value" Tipo: "$D" Formula: SR "[INSTA->VALUE]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValortot { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValortot, 2)); } set { klass.ValValortot = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValValortot() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValValortot");

		[DisplayName("Loan frequency")]
		/// <summary>Field : "Loan frequency" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Freqempr", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValFrequenc { get { return klass.ValFrequenc; } set { klass.ValFrequenc = value; } }
		[JsonIgnore]
		public SelectList ArrayValfrequenc { get { return new SelectList(CSGenio.business.ArrayFreqempr.GetDictionary(), "Key", "Value", ValFrequenc); } set { ValFrequenc = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValFrequenc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValFrequenc");

		[DisplayName("Bought")]
		/// <summary>Field : "Bought" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTAQUISI])==1,0,1)"</summary>
		public bool ValBought { get { return Convert.ToBoolean(klass.ValBought); } set { klass.ValBought = Convert.ToInt32(value); } }
		public bool ShouldSerializeValBought() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValBought");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: U1 "MOVIM[MOVIM->DHMUDANC][MOVIM->CODROOMS][Today]"</summary>
		public string ValCodrooms { get { return klass.ValCodrooms; } set { klass.ValCodrooms = value; } }
		public bool ShouldSerializeValCodrooms() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValCodrooms");
		private Room1 _room1;
		[DisplayName("Room1")]
		public virtual Room1 Room1 { get { if (!this.isEmptyModel && (_room1 == null || (!string.IsNullOrEmpty(ValCodrooms) && (_room1.isEmptyModel || _room1.klass.QPrimaryKey != ValCodrooms)))) _room1 = Models.Room1.Find(ValCodrooms, Identifier, _fieldsToSerialize); if (_room1 == null) _room1 = new Models.Room1(true, _fieldsToSerialize); return _room1; } set { _room1 = value; } }
		public bool ShouldSerializeRoom1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Room1");

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtrefere { get { return klass.ValDtrefere; } set { klass.ValDtrefere = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtrefere() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValDtrefere");

		[DisplayName("First")]
		/// <summary>Field : "First" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		public string ValFirst { get { return klass.ValFirst; } set { klass.ValFirst = value; } }
		public bool ShouldSerializeValFirst() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValFirst");

		[DisplayName("Before")]
		/// <summary>Field : "Before" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR](DESC)"</summary>
		public string ValBefore { get { return klass.ValBefore; } set { klass.ValBefore = value; } }
		public bool ShouldSerializeValBefore() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValBefore");

		[DisplayName("Following")]
		/// <summary>Field : "Following" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		public string ValFollowin { get { return klass.ValFollowin; } set { klass.ValFollowin = value; } }
		public bool ShouldSerializeValFollowin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValFollowin");

		[DisplayName("Last")]
		/// <summary>Field : "Last" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](DESC)"</summary>
		public string ValLast { get { return klass.ValLast; } set { klass.ValLast = value; } }
		public bool ShouldSerializeValLast() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValLast");

		[DisplayName("Manufacturer's website")]
		/// <summary>Field : "Manufacturer's website" Tipo: "C" Formula:  ""</summary>
		[HyperLink]
		public string ValSitefabr { get { return klass.ValSitefabr; } set { klass.ValSitefabr = value; } }
		public bool ShouldSerializeValSitefabr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValSitefabr");

		[DisplayName("Last photo attached")]
		/// <summary>Field : "Last photo attached" Tipo: "IJ" Formula: U1 "PHOTO[PHOTO->ANEXED][PHOTO->PHOTOGRA][Today]"</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLastpho { get { return klass.ValLastpho; } set { klass.ValLastpho = value; } }
		public bool ShouldSerializeValLastpho() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValLastpho");

		[DisplayName("Drives")]
		/// <summary>Field : "Drives" Tipo: "MO" Formula: CL "MOVIM[MOVIM->ROOMNR][MOVIM->DHMUDANC](; )"</summary>
		[DataType(DataType.MultilineText)]
		public string ValMoviment { get { return klass.ValMoviment; } set { klass.ValMoviment = value; } }
		public bool ShouldSerializeValMoviment() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValMoviment");

		[DisplayName("Qtd. movimentações")]
		/// <summary>Field : "Qtd. movimentações" Tipo: "N" Formula: SR "[MOVIM->1]"</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdmovim { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdmovim, 0)); } set { klass.ValQtdmovim = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQtdmovim() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValQtdmovim");

		[DisplayName("Show record")]
		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		public bool ValShowrc { get { return Convert.ToBoolean(klass.ValShowrc); } set { klass.ValShowrc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShowrc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValShowrc");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip.ValZzstate");

		public Equip() : this(UserContext.Current.User) { }

		public Equip(User u)
		{
			this.klass = new CSGenioAequip(u);
		}

		public Equip(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Equip(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Equip(bool isEmpty) : this(isEmpty, null) { }

		public Equip(CSGenioAequip val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Equip(CSGenioAequip val) : this(val, null) { }

		public Equip(CSGenioAequip val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Equip(CSGenioAequip val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAequip csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cmpny":
						if (_cmpny == null)
							_cmpny = new Cmpny(true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpequ":
						if (_tpequ == null)
							_tpequ = new Tpequ(true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "wareh":
						if (_wareh == null)
							_wareh = new Wareh(true, _fieldsToSerialize);
						_wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "item":
						if (_item == null)
							_item = new Item(true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "decom":
						if (_decom == null)
							_decom = new Decom(true, _fieldsToSerialize);
						_decom.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "room1":
						if (_room1 == null)
							_room1 = new Room1(true, _fieldsToSerialize);
						_room1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Equip Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Equip Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAequip>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Equip(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Equip> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAequip>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Equip>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAequip> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAequip>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAequip> All(CriteriaSet args = null)
		{
			return Where<CSGenioAequip>(false, args, numRegs: -1);
		}

		public static List<Equip> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAequip>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Equip>((r) => new Equip(r));
		}

// USE /[MANUAL GQT MODEL EQUIP]/
	}
}
