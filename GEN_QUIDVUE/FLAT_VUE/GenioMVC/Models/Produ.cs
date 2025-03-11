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
	public class Produ : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprodu klass { get { return baseklass as CSGenioAprodu; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValCodprodu")]
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }

		[DisplayName(">>LOCATION")]
		/// <summary>Field : ">>LOCATION" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValCodlocat")]
		public string ValCodlocat { get { return klass.ValCodlocat; } set { klass.ValCodlocat = value; } }

		private Locat _locat;
		[DisplayName("Locat")]
		[ShouldSerialize("Locat")]
		public virtual Locat Locat
		{
			get
			{
				if (!isEmptyModel && (_locat == null || (!string.IsNullOrEmpty(ValCodlocat) && (_locat.isEmptyModel || _locat.klass.QPrimaryKey != ValCodlocat))))
					_locat = Models.Locat.Find(ValCodlocat, m_userContext, Identifier, _fieldsToSerialize);
				_locat ??= new Models.Locat(m_userContext, true, _fieldsToSerialize);
				return _locat;
			}
			set { _locat = value; }
		}

		[DisplayName(">>LOCATION EXTENSION")]
		/// <summary>Field : ">>LOCATION EXTENSION" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValCodlcext")]
		public string ValCodlcext { get { return klass.ValCodlcext; } set { klass.ValCodlcext = value; } }

		private Lcext _lcext;
		[DisplayName("Lcext")]
		[ShouldSerialize("Lcext")]
		public virtual Lcext Lcext
		{
			get
			{
				if (!isEmptyModel && (_lcext == null || (!string.IsNullOrEmpty(ValCodlcext) && (_lcext.isEmptyModel || _lcext.klass.QPrimaryKey != ValCodlcext))))
					_lcext = Models.Lcext.Find(ValCodlcext, m_userContext, Identifier, _fieldsToSerialize);
				_lcext ??= new Models.Lcext(m_userContext, true, _fieldsToSerialize);
				return _lcext;
			}
			set { _lcext = value; }
		}

		[DisplayName("Product")]
		/// <summary>Field : "Product" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValProduct")]
		public string ValProduct { get { return klass.ValProduct; } set { klass.ValProduct = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("SKU")]
		/// <summary>Field : "SKU" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValSku")]
		public string ValSku { get { return klass.ValSku; } set { klass.ValSku = value; } }

		[DisplayName("GTIN")]
		/// <summary>Field : "GTIN" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValGtin")]
		public string ValGtin { get { return klass.ValGtin; } set { klass.ValGtin = value; } }

		[DisplayName("Size")]
		/// <summary>Field : "Size" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValSize")]
		public string ValSize { get { return klass.ValSize; } set { klass.ValSize = value; } }

		[DisplayName("Weight")]
		/// <summary>Field : "Weight" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValWeight")]
		[NumericAttribute(2)]
		public decimal? ValWeight { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValWeight, 2)); } set { klass.ValWeight = Convert.ToDecimal(value); } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValPrice")]
		[CurrencyAttribute("EUR", 4)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrice, 4)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("Inputs")]
		/// <summary>Field : "Inputs" Tipo: "N" Formula: SR "[RELIN->RECEIVED]"</summary>
		[ShouldSerialize("Produ.ValInputs")]
		[NumericAttribute(0)]
		public decimal? ValInputs { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValInputs, 0)); } set { klass.ValInputs = Convert.ToDecimal(value); } }

		[DisplayName("Outputs")]
		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[DILIN->DELIVERE]"</summary>
		[ShouldSerialize("Produ.ValOutputs")]
		[NumericAttribute(0)]
		public decimal? ValOutputs { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutputs, 0)); } set { klass.ValOutputs = Convert.ToDecimal(value); } }

		[DisplayName("Stock")]
		/// <summary>Field : "Stock" Tipo: "N" Formula: SR "[RELIN->RECEIVED]-[DILIN->DELIVERE]"</summary>
		[ShouldSerialize("Produ.ValStock")]
		[NumericAttribute(0)]
		public decimal? ValStock { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValStock, 0)); } set { klass.ValStock = Convert.ToDecimal(value); } }

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValImage { get { return new ImageModel(klass.ValImage) { Ticket = ValImageQTicket }; } set { klass.ValImage = value; } }
		[JsonIgnore]
		public string ValImageQTicket = null;

		[DisplayName("In use")]
		/// <summary>Field : "In use" Tipo: "AL" Formula:  ""</summary>
		[ShouldSerialize("Produ.ValIn_use")]
		[DataArray("Yesno", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValIn_use { get { return klass.ValIn_use; } set { klass.ValIn_use = value; } }
		[JsonIgnore]
		public SelectList ArrayValin_use { get { return new SelectList(CSGenio.business.ArrayYesno.GetDictionary(), "Key", "Value", ValIn_use); } set { ValIn_use = (int)value.SelectedValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Produ.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Produ(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAprodu(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Produ(UserContext userContext, CSGenioAprodu val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAprodu csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "locat":
						_locat ??= new Locat(m_userContext, true, _fieldsToSerialize);
						_locat.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "lcext":
						_lcext ??= new Lcext(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Produ Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprodu>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Produ(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Produ> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprodu>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Produ>((r) => new Produ(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PRODU]/
	}
}
