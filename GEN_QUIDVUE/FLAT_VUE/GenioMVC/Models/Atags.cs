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
	public class Atags : ModelBase
	{
		[JsonIgnore]
		public CSGenioAatags klass { get { return baseklass as CSGenioAatags; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Atags.ValCodtags")]
		public string ValCodtags { get { return klass.ValCodtags; } set { klass.ValCodtags = value; } }

		[DisplayName("Tag name")]
		/// <summary>Field : "Tag name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Atags.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Background color of the tag")]
		/// <summary>Field : "Background color of the tag" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Atags.ValColor")]
		public string ValColor { get { return klass.ValColor; } set { klass.ValColor = value; } }

		[DisplayName("Icon associated with the tag")]
		/// <summary>Field : "Icon associated with the tag" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Atags.ValIcon")]
		[DataArray("Assettags", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValIcon { get { return klass.ValIcon; } set { klass.ValIcon = value; } }
		[JsonIgnore]
		public SelectList ArrayValicon { get { return new SelectList(CSGenio.business.ArrayAssettags.GetDictionary(), "Key", "Value", ValIcon); } set { ValIcon = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Atags.ValCodasset")]
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }

		private Asset _asset;
		[DisplayName("Asset")]
		[ShouldSerialize("Asset")]
		public virtual Asset Asset
		{
			get
			{
				if (!isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset))))
					_asset = Models.Asset.Find(ValCodasset, m_userContext, Identifier, _fieldsToSerialize);
				_asset ??= new Models.Asset(m_userContext, true, _fieldsToSerialize);
				return _asset;
			}
			set { _asset = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Atags.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Atags(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAatags(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Atags(UserContext userContext, CSGenioAatags val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAatags csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asset":
						_asset ??= new Asset(m_userContext, true, _fieldsToSerialize);
						_asset.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Atags Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAatags>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Atags(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Atags> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAatags>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Atags>((r) => new Atags(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ATAGS]/
	}
}
