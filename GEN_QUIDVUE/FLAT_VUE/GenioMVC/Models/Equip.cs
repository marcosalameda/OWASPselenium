using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Equip : ModelBase
	{
		[JsonIgnore]
		public CSGenioAequip klass { get { return baseklass as CSGenioAequip; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCodempre")]
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		[ShouldSerialize("Cmpny")]
		public virtual Cmpny Cmpny { 
			get { 
				if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre))))
					_cmpny = Models.Cmpny.Find(ValCodempre, m_userContext, Identifier, _fieldsToSerialize);
				if (_cmpny == null)
					_cmpny = new Models.Cmpny(m_userContext, true, _fieldsToSerialize);
				return _cmpny;
			}
			set { _cmpny = value; } 
		}
		

		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCodpess1")]
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		[ShouldSerialize("Pess1")]
		public virtual Pess1 Pess1 { 
			get { 
				if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1))))
					_pess1 = Models.Pess1.Find(ValCodpess1, m_userContext, Identifier, _fieldsToSerialize);
				if (_pess1 == null)
					_pess1 = new Models.Pess1(m_userContext, true, _fieldsToSerialize);
				return _pess1;
			}
			set { _pess1 = value; } 
		}
		

		[DisplayName("Sequential no.")]
		/// <summary>Field : "Sequential no." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValSequennr")]
		[NumericAttribute(0)]
		public decimal? ValSequennr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSequennr, 0)); } set { klass.ValSequennr = Convert.ToDouble(value); } }

		[DisplayName("No. register")]
		/// <summary>Field : "No. register" Tipo: "C" Formula: + "RIGHT("000000"+NumericToString([EQUIP->SEQUENNR],0),6)"</summary>
		[ShouldSerialize("Equip.ValRegistnr")]
		public string ValRegistnr { get { return klass.ValRegistnr; } set { klass.ValRegistnr = value; } }

		[DisplayName(">TYPE OF EQUIPMENT")]
		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		[ShouldSerialize("Tpequ")]
		public virtual Tpequ Tpequ { 
			get { 
				if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ))))
					_tpequ = Models.Tpequ.Find(ValCodtpequ, m_userContext, Identifier, _fieldsToSerialize);
				if (_tpequ == null)
					_tpequ = new Models.Tpequ(m_userContext, true, _fieldsToSerialize);
				return _tpequ;
			}
			set { _tpequ = value; } 
		}
		

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		private Wareh _wareh;
		[DisplayName("Wareh")]
		[ShouldSerialize("Wareh")]
		public virtual Wareh Wareh { 
			get { 
				if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh))))
					_wareh = Models.Wareh.Find(ValCodwareh, m_userContext, Identifier, _fieldsToSerialize);
				if (_wareh == null)
					_wareh = new Models.Wareh(m_userContext, true, _fieldsToSerialize);
				return _wareh;
			}
			set { _wareh = value; } 
		}
		

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCoditem")]
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		private Item _item;
		[DisplayName("Item")]
		[ShouldSerialize("Item")]
		public virtual Item Item { 
			get { 
				if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem))))
					_item = Models.Item.Find(ValCoditem, m_userContext, Identifier, _fieldsToSerialize);
				if (_item == null)
					_item = new Models.Item(m_userContext, true, _fieldsToSerialize);
				return _item;
			}
			set { _item = value; } 
		}
		

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula: DF "[ITEM->ITEMDES]"</summary>
		[ShouldSerialize("Equip.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("Acquisition")]
		/// <summary>Field : "Acquisition" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValDtaquisi")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtaquisi { get { return klass.ValDtaquisi; } set { klass.ValDtaquisi = value ?? DateTime.MinValue; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValCoddeco")]
		public string ValCoddeco { get { return klass.ValCoddeco; } set { klass.ValCoddeco = value; } }
		private Decom _decom;
		[DisplayName("Decom")]
		[ShouldSerialize("Decom")]
		public virtual Decom Decom { 
			get { 
				if (!this.isEmptyModel && (_decom == null || (!string.IsNullOrEmpty(ValCoddeco) && (_decom.isEmptyModel || _decom.klass.QPrimaryKey != ValCoddeco))))
					_decom = Models.Decom.Find(ValCoddeco, m_userContext, Identifier, _fieldsToSerialize);
				if (_decom == null)
					_decom = new Models.Decom(m_userContext, true, _fieldsToSerialize);
				return _decom;
			}
			set { _decom = value; } 
		}
		

		[DisplayName("Decomission")]
		/// <summary>Field : "Decomission" Tipo: "D" Formula: ++ "[DECOM->DTDECO]"</summary>
		[ShouldSerialize("Equip.ValDtdeco")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtdeco { get { return klass.ValDtdeco; } set { klass.ValDtdeco = value ?? DateTime.MinValue; } }

		[DisplayName("Downed equipment")]
		/// <summary>Field : "Downed equipment" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTDECO])==1,0,1)"</summary>
		[ShouldSerialize("Equip.ValIfabatif")]
		public bool ValIfabatif { get { return Convert.ToBoolean(klass.ValIfabatif); } set { klass.ValIfabatif = Convert.ToInt32(value); } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValPhotogra")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValPhotogra { get { return klass.ValPhotogra; } set { klass.ValPhotogra = value; } }

		[DisplayName("Total value")]
		/// <summary>Field : "Total value" Tipo: "$D" Formula: SR "[INSTA->VALUE]"</summary>
		[ShouldSerialize("Equip.ValValortot")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValortot { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValortot, 2)); } set { klass.ValValortot = Convert.ToDouble(value); } }

		[DisplayName("Loan frequency")]
		/// <summary>Field : "Loan frequency" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValFrequenc")]
		[DataArray("Freqempr", GenioMVC.Helpers.ArrayType.Numeric)]
		public double ValFrequenc { get { return klass.ValFrequenc; } set { klass.ValFrequenc = value; } }
		[JsonIgnore]
		public SelectList ArrayValfrequenc { get { return new SelectList(CSGenio.business.ArrayFreqempr.GetDictionary(), "Key", "Value", ValFrequenc); } set { ValFrequenc = Convert.ToDouble(value.SelectedValue); } }

		[DisplayName("Bought")]
		/// <summary>Field : "Bought" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTAQUISI])==1,0,1)"</summary>
		[ShouldSerialize("Equip.ValBought")]
		public bool ValBought { get { return Convert.ToBoolean(klass.ValBought); } set { klass.ValBought = Convert.ToInt32(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula: U1 "MOVIM[MOVIM->DHMUDANC][MOVIM->CODROOMS][Today]"</summary>
		[ShouldSerialize("Equip.ValCodrooms")]
		public string ValCodrooms { get { return klass.ValCodrooms; } set { klass.ValCodrooms = value; } }
		private Room1 _room1;
		[DisplayName("Room1")]
		[ShouldSerialize("Room1")]
		public virtual Room1 Room1 { 
			get { 
				if (!this.isEmptyModel && (_room1 == null || (!string.IsNullOrEmpty(ValCodrooms) && (_room1.isEmptyModel || _room1.klass.QPrimaryKey != ValCodrooms))))
					_room1 = Models.Room1.Find(ValCodrooms, m_userContext, Identifier, _fieldsToSerialize);
				if (_room1 == null)
					_room1 = new Models.Room1(m_userContext, true, _fieldsToSerialize);
				return _room1;
			}
			set { _room1 = value; } 
		}
		

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValDtrefere")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtrefere { get { return klass.ValDtrefere; } set { klass.ValDtrefere = value ?? DateTime.MinValue; } }

		[DisplayName("First")]
		/// <summary>Field : "First" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		[ShouldSerialize("Equip.ValFirst")]
		public string ValFirst { get { return klass.ValFirst; } set { klass.ValFirst = value; } }

		[DisplayName("Before")]
		/// <summary>Field : "Before" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR](DESC)"</summary>
		[ShouldSerialize("Equip.ValBefore")]
		public string ValBefore { get { return klass.ValBefore; } set { klass.ValBefore = value; } }

		[DisplayName("Following")]
		/// <summary>Field : "Following" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		[ShouldSerialize("Equip.ValFollowin")]
		public string ValFollowin { get { return klass.ValFollowin; } set { klass.ValFollowin = value; } }

		[DisplayName("Last")]
		/// <summary>Field : "Last" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](DESC)"</summary>
		[ShouldSerialize("Equip.ValLast")]
		public string ValLast { get { return klass.ValLast; } set { klass.ValLast = value; } }

		[DisplayName("Manufacturer's website")]
		/// <summary>Field : "Manufacturer's website" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValSitefabr")]
		[HyperLink]
		public string ValSitefabr { get { return klass.ValSitefabr; } set { klass.ValSitefabr = value; } }

		[DisplayName("Last photo attached")]
		/// <summary>Field : "Last photo attached" Tipo: "IJ" Formula: U1 "PHOTO[PHOTO->ANEXED][PHOTO->PHOTOGRA][Today]"</summary>
		[ShouldSerialize("Equip.ValLastpho")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValLastpho { get { return klass.ValLastpho; } set { klass.ValLastpho = value; } }

		[DisplayName("Drives")]
		/// <summary>Field : "Drives" Tipo: "MO" Formula: CL "MOVIM[MOVIM->ROOMNR][MOVIM->DHMUDANC](; )"</summary>
		[ShouldSerialize("Equip.ValMoviment")]
		[DataType(DataType.MultilineText)]
		public string ValMoviment { get { return klass.ValMoviment; } set { klass.ValMoviment = value; } }

		[DisplayName("Qtd. movimentações")]
		/// <summary>Field : "Qtd. movimentações" Tipo: "N" Formula: SR "[MOVIM->1]"</summary>
		[ShouldSerialize("Equip.ValQtdmovim")]
		[NumericAttribute(0)]
		public decimal? ValQtdmovim { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdmovim, 0)); } set { klass.ValQtdmovim = Convert.ToDouble(value); } }

		[DisplayName("Show record")]
		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Equip.ValShowrc")]
		public bool ValShowrc { get { return Convert.ToBoolean(klass.ValShowrc); } set { klass.ValShowrc = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Equip.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Equip(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAequip(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Equip(UserContext userContext, CSGenioAequip val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


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
							_cmpny = new Cmpny(m_userContext, true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(m_userContext, true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpequ":
						if (_tpequ == null)
							_tpequ = new Tpequ(m_userContext, true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "wareh":
						if (_wareh == null)
							_wareh = new Wareh(m_userContext, true, _fieldsToSerialize);
						_wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "item":
						if (_item == null)
							_item = new Item(m_userContext, true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "decom":
						if (_decom == null)
							_decom = new Decom(m_userContext, true, _fieldsToSerialize);
						_decom.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "room1":
						if (_room1 == null)
							_room1 = new Room1(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Equip Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAequip>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Equip(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Equip> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAequip>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Equip>((r) => new Equip(userCtx, r));
		}

// USE /[MANUAL GQT MODEL EQUIP]/
	}
}
