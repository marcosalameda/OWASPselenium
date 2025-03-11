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
	public class Itemc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitemc klass { get { return baseklass as CSGenioAitemc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Itemc.ValCodcatar")]
		public string ValCodcatar { get { return klass.ValCodcatar; } set { klass.ValCodcatar = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Itemc.ValCoditem")]
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
		[ShouldSerialize("Itemc.ValCodtpcat")]
		public string ValCodtpcat { get { return klass.ValCodtpcat; } set { klass.ValCodtpcat = value; } }

		private Cattp _cattp;
		[DisplayName("Cattp")]
		[ShouldSerialize("Cattp")]
		public virtual Cattp Cattp
		{
			get
			{
				if (!isEmptyModel && (_cattp == null || (!string.IsNullOrEmpty(ValCodtpcat) && (_cattp.isEmptyModel || _cattp.klass.QPrimaryKey != ValCodtpcat))))
					_cattp = Models.Cattp.Find(ValCodtpcat, m_userContext, Identifier, _fieldsToSerialize);
				_cattp ??= new Models.Cattp(m_userContext, true, _fieldsToSerialize);
				return _cattp;
			}
			set { _cattp = value; }
		}

		[DisplayName("Category type")]
		/// <summary>Field : "Category type" Tipo: "C" Formula: ++ "[CATTP->TPCATEGO]"</summary>
		[ShouldSerialize("Itemc.ValTpcateg")]
		public string ValTpcateg { get { return klass.ValTpcateg; } set { klass.ValTpcateg = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Itemc.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Itemc(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAitemc(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Itemc(UserContext userContext, CSGenioAitemc val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAitemc csgenioa)
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
					case "cattp":
						_cattp ??= new Cattp(m_userContext, true, _fieldsToSerialize);
						_cattp.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Itemc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitemc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Itemc(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Itemc> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitemc>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Itemc>((r) => new Itemc(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ITEMC]/
	}
}
