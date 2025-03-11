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
	public class Item : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitem klass { get { return baseklass as CSGenioAitem; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCoditem")]
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }

		[DisplayName(">GLOBAL ARTICLE")]
		/// <summary>Field : ">GLOBAL ARTICLE" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCodgitem")]
		public string ValCodgitem { get { return klass.ValCodgitem; } set { klass.ValCodgitem = value; } }

		private Gitem _gitem;
		[DisplayName("Gitem")]
		[ShouldSerialize("Gitem")]
		public virtual Gitem Gitem
		{
			get
			{
				if (!isEmptyModel && (_gitem == null || (!string.IsNullOrEmpty(ValCodgitem) && (_gitem.isEmptyModel || _gitem.klass.QPrimaryKey != ValCodgitem))))
					_gitem = Models.Gitem.Find(ValCodgitem, m_userContext, Identifier, _fieldsToSerialize);
				_gitem ??= new Models.Gitem(m_userContext, true, _fieldsToSerialize);
				return _gitem;
			}
			set { _gitem = value; }
		}

		[DisplayName(">WAREHOUSE")]
		/// <summary>Field : ">WAREHOUSE" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Item.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }

		private Wareh _wareh;
		[DisplayName("Wareh")]
		[ShouldSerialize("Wareh")]
		public virtual Wareh Wareh
		{
			get
			{
				if (!isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh))))
					_wareh = Models.Wareh.Find(ValCodwareh, m_userContext, Identifier, _fieldsToSerialize);
				_wareh ??= new Models.Wareh(m_userContext, true, _fieldsToSerialize);
				return _wareh;
			}
			set { _wareh = value; }
		}

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Item.ValItemtype")]
		[DataArray("Tipoarti", GenioMVC.Helpers.ArrayType.Character)]
		public string ValItemtype { get { return klass.ValItemtype; } set { klass.ValItemtype = value; } }
		[JsonIgnore]
		public SelectList ArrayValitemtype { get { return new SelectList(CSGenio.business.ArrayTipoarti.GetDictionary(), "Key", "Value", ValItemtype); } set { ValItemtype = value.SelectedValue as string; } }

		[DisplayName("Article")]
		/// <summary>Field : "Article" Tipo: "C" Formula: DF "[GITEM->ITEMDES]"</summary>
		[ShouldSerialize("Item.ValItemdes")]
		public string ValItemdes { get { return klass.ValItemdes; } set { klass.ValItemdes = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula: DF "[GITEM->ITEMGCOD]"</summary>
		[ShouldSerialize("Item.ValItemcod")]
		public string ValItemcod { get { return klass.ValItemcod; } set { klass.ValItemcod = value; } }

		[DisplayName("Entries")]
		/// <summary>Field : "Entries" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]"</summary>
		[ShouldSerialize("Item.ValEntries")]
		[NumericAttribute(0)]
		public decimal? ValEntries { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValEntries, 0)); } set { klass.ValEntries = Convert.ToDecimal(value); } }

		[DisplayName("Outputs")]
		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[OUTPU->EXITQNTY]"</summary>
		[ShouldSerialize("Item.ValExits")]
		[NumericAttribute(0)]
		public decimal? ValExits { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExits, 0)); } set { klass.ValExits = Convert.ToDecimal(value); } }

		[DisplayName("Stocks")]
		/// <summary>Field : "Stocks" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]-[OUTPU->EXITQNTY]"</summary>
		[ShouldSerialize("Item.ValExistenc")]
		[NumericAttribute(0)]
		public decimal? ValExistenc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExistenc, 0)); } set { klass.ValExistenc = Convert.ToDecimal(value); } }

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Item.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValImage { get { return new ImageModel(klass.ValImage) { Ticket = ValImageQTicket }; } set { klass.ValImage = value; } }
		[JsonIgnore]
		public string ValImageQTicket = null;

		[DisplayName("Categorization")]
		/// <summary>Field : "Categorization" Tipo: "MO" Formula: CL "ITEMC[ITEMC->TPCATEG][ITEMC->TPCATEG](; )"</summary>
		[ShouldSerialize("Item.ValCategory")]
		[DataType(DataType.MultilineText)]
		public string ValCategory { get { return klass.ValCategory; } set { klass.ValCategory = value; } }

		[DisplayName("In use")]
		/// <summary>Field : "In use" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Item.ValValid")]
		public bool ValValid { get { return Convert.ToBoolean(klass.ValValid); } set { klass.ValValid = Convert.ToInt32(value); } }

		[DisplayName("Availability")]
		/// <summary>Field : "Availability" Tipo: "AC" Formula: + "iif([ITEM->EXISTENC]>0,"A",iif([ITEM->EXISTENC]<=0,"O","D"))"</summary>
		[ShouldSerialize("Item.ValDisponib")]
		[DataArray("Dsiponib", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDisponib { get { return klass.ValDisponib; } set { klass.ValDisponib = value; } }
		[JsonIgnore]
		public SelectList ArrayValdisponib { get { return new SelectList(CSGenio.business.ArrayDsiponib.GetDictionary(), "Key", "Value", ValDisponib); } set { ValDisponib = value.SelectedValue as string; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Item.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Specifications")]
		/// <summary>Field : "Specifications" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Item.ValTechspec")]
		[Document("ValTechspec", true, false, false)]
		public string ValTechspec { get { return klass.ValTechspec; } set { klass.ValTechspec = value; } }
		public string ValTechspecfk { get { return klass.ValTechspecfk; } set { klass.ValTechspecfk = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Item.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Item(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAitem(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Item(UserContext userContext, CSGenioAitem val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAitem csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "gitem":
						_gitem ??= new Gitem(m_userContext, true, _fieldsToSerialize);
						_gitem.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "wareh":
						_wareh ??= new Wareh(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Item Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitem>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Item(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Item> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitem>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Item>((r) => new Item(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ITEM]/
	}
}
