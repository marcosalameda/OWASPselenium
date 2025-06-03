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
	public class Ccorr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAccorr klass { get { return baseklass as CSGenioAccorr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValCodccorr")]
		public string ValCodccorr { get { return klass.ValCodccorr; } set { klass.ValCodccorr = value; } }

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValNorder")]
		[NumericAttribute(0)]
		public decimal? ValNorder { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNorder, 0)); } set { klass.ValNorder = Convert.ToDecimal(value); } }

		[DisplayName("Instant")]
		/// <summary>Field : "Instant" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Type")]
		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValType")]
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValCoditem")]
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }

		private Item _item;
		[DisplayName("Item")]
		[ShouldSerialize("Item")]
		public virtual Item Item
		{
			get
			{
				if (!isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem))))
					_item = Models.Item.Find(ValCoditem, m_userContext, Identifier, _fieldsToSerialize);
				_item ??= new Models.Item(m_userContext, true, _fieldsToSerialize);
				return _item;
			}
			set { _item = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValCoddentr")]
		public string ValCoddentr { get { return klass.ValCoddentr; } set { klass.ValCoddentr = value; } }

		private Indoc _indoc;
		[DisplayName("Indoc")]
		[ShouldSerialize("Indoc")]
		public virtual Indoc Indoc
		{
			get
			{
				if (!isEmptyModel && (_indoc == null || (!string.IsNullOrEmpty(ValCoddentr) && (_indoc.isEmptyModel || _indoc.klass.QPrimaryKey != ValCoddentr))))
					_indoc = Models.Indoc.Find(ValCoddentr, m_userContext, Identifier, _fieldsToSerialize);
				_indoc ??= new Models.Indoc(m_userContext, true, _fieldsToSerialize);
				return _indoc;
			}
			set { _indoc = value; }
		}

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValQnty")]
		[NumericAttribute(0)]
		public decimal? ValQnty { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQnty, 0)); } set { klass.ValQnty = Convert.ToDecimal(value); } }

		[DisplayName("Balance")]
		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValBalance")]
		[NumericAttribute(0)]
		public decimal? ValBalance { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBalance, 0)); } set { klass.ValBalance = Convert.ToDecimal(value); } }

		[DisplayName("Ref")]
		/// <summary>Field : "Ref" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Ccorr.ValReferenc")]
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Ccorr.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Ccorr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAccorr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ccorr(UserContext userContext, CSGenioAccorr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAccorr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
						_item ??= new Item(m_userContext, true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "indoc":
						_indoc ??= new Indoc(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Ccorr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAccorr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ccorr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Ccorr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAccorr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ccorr>((r) => new Ccorr(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CCORR]/
	}
}
