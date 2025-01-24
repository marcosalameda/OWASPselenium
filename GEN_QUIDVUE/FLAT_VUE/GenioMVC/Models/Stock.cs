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
	public class Stock : ModelBase
	{
		[JsonIgnore]
		public CSGenioAstock klass { get { return baseklass as CSGenioAstock; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValCodstock")]
		public string ValCodstock { get { return klass.ValCodstock; } set { klass.ValCodstock = value; } }

		[DisplayName("Sequence")]
		/// <summary>Field : "Sequence" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValSequence")]
		[NumericAttribute(0)]
		public decimal? ValSequence { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSequence, 0)); } set { klass.ValSequence = Convert.ToDecimal(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValType")]
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }

		[DisplayName(">>PRODUCT")]
		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValCodprodu")]
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }
		private Produ _produ;
		[DisplayName("Produ")]
		[ShouldSerialize("Produ")]
		public virtual Produ Produ {
			get {
				if (!this.isEmptyModel && (_produ == null || (!string.IsNullOrEmpty(ValCodprodu) && (_produ.isEmptyModel || _produ.klass.QPrimaryKey != ValCodprodu))))
					_produ = Models.Produ.Find(ValCodprodu, m_userContext, Identifier, _fieldsToSerialize);
				if (_produ == null)
					_produ = new Models.Produ(m_userContext, true, _fieldsToSerialize);
				return _produ;
			}
			set { _produ = value; }
		}


		[DisplayName(">>RECEIPT")]
		/// <summary>Field : ">>RECEIPT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValCodrecei")]
		public string ValCodrecei { get { return klass.ValCodrecei; } set { klass.ValCodrecei = value; } }
		private Recei _recei;
		[DisplayName("Recei")]
		[ShouldSerialize("Recei")]
		public virtual Recei Recei {
			get {
				if (!this.isEmptyModel && (_recei == null || (!string.IsNullOrEmpty(ValCodrecei) && (_recei.isEmptyModel || _recei.klass.QPrimaryKey != ValCodrecei))))
					_recei = Models.Recei.Find(ValCodrecei, m_userContext, Identifier, _fieldsToSerialize);
				if (_recei == null)
					_recei = new Models.Recei(m_userContext, true, _fieldsToSerialize);
				return _recei;
			}
			set { _recei = value; }
		}


		[DisplayName(">>DISPATCH")]
		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValCoddispa")]
		public string ValCoddispa { get { return klass.ValCoddispa; } set { klass.ValCoddispa = value; } }
		private Dispa _dispa;
		[DisplayName("Dispa")]
		[ShouldSerialize("Dispa")]
		public virtual Dispa Dispa {
			get {
				if (!this.isEmptyModel && (_dispa == null || (!string.IsNullOrEmpty(ValCoddispa) && (_dispa.isEmptyModel || _dispa.klass.QPrimaryKey != ValCoddispa))))
					_dispa = Models.Dispa.Find(ValCoddispa, m_userContext, Identifier, _fieldsToSerialize);
				if (_dispa == null)
					_dispa = new Models.Dispa(m_userContext, true, _fieldsToSerialize);
				return _dispa;
			}
			set { _dispa = value; }
		}


		[DisplayName("Quantity")]
		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValQuantity")]
		[NumericAttribute(0)]
		public decimal? ValQuantity { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantity, 0)); } set { klass.ValQuantity = Convert.ToDecimal(value); } }

		[DisplayName("Balance")]
		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValBalance")]
		[NumericAttribute(0)]
		public decimal? ValBalance { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBalance, 0)); } set { klass.ValBalance = Convert.ToDecimal(value); } }

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Stock.ValReferenc")]
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Stock.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Stock(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAstock(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Stock(UserContext userContext, CSGenioAstock val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


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
							_produ = new Produ(m_userContext, true, _fieldsToSerialize);
						_produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "recei":
						if (_recei == null)
							_recei = new Recei(m_userContext, true, _fieldsToSerialize);
						_recei.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "dispa":
						if (_dispa == null)
							_dispa = new Dispa(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Stock Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAstock>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Stock(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Stock> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAstock>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Stock>((r) => new Stock(userCtx, r));
		}

// USE /[MANUAL GQT MODEL STOCK]/
	}
}
