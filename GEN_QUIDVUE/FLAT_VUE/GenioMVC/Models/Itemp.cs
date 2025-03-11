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
	public class Itemp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitemp klass { get { return baseklass as CSGenioAitemp; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Itemp.ValCoditemp")]
		public string ValCoditemp { get { return klass.ValCoditemp; } set { klass.ValCoditemp = value; } }

		[DisplayName("Item")]
		/// <summary>Field : "Item" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Itemp.ValCoditem")]
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

		[DisplayName("Property Name")]
		/// <summary>Field : "Property Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Itemp.ValPropid")]
		public string ValPropid { get { return klass.ValPropid; } set { klass.ValPropid = value; } }

		[DisplayName("Property Value")]
		/// <summary>Field : "Property Value" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Itemp.ValPropval")]
		public string ValPropval { get { return klass.ValPropval; } set { klass.ValPropval = value; } }

		[DisplayName("Property Type")]
		/// <summary>Field : "Property Type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Itemp.ValProptype")]
		public string ValProptype { get { return klass.ValProptype; } set { klass.ValProptype = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Itemp.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Itemp(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAitemp(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Itemp(UserContext userContext, CSGenioAitemp val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAitemp csgenioa)
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
		public static Itemp Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitemp>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Itemp(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Itemp> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitemp>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Itemp>((r) => new Itemp(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ITEMP]/
	}
}
