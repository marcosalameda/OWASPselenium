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
	public class Rules : ModelBase
	{
		[JsonIgnore]
		public CSGenioArules klass { get { return baseklass as CSGenioArules; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Rules.ValCodregra")]
		public string ValCodregra { get { return klass.ValCodregra; } set { klass.ValCodregra = value; } }

		[DisplayName("Condition type")]
		/// <summary>Field : "Condition type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Rules.ValTipocond")]
		[DataArray("Tipocond", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipocond { get { return klass.ValTipocond; } set { klass.ValTipocond = value; } }
		[JsonIgnore]
		public SelectList ArrayValtipocond { get { return new SelectList(CSGenio.business.ArrayTipocond.GetDictionary(), "Key", "Value", ValTipocond); } set { ValTipocond = value.SelectedValue as string; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Rules.ValDescript")]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Place where you run")]
		/// <summary>Field : "Place where you run" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Rules.ValLocal")]
		[DataArray("Alocregr", GenioMVC.Helpers.ArrayType.Character)]
		public string ValLocal { get { return klass.ValLocal; } set { klass.ValLocal = value; } }
		[JsonIgnore]
		public SelectList ArrayVallocal { get { return new SelectList(CSGenio.business.ArrayAlocregr.GetDictionary(), "Key", "Value", ValLocal); } set { ValLocal = value.SelectedValue as string; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Rules.ValCodup_rules")]
		public string ValCodup_rules { get { return klass.ValCodup_rules; } set { klass.ValCodup_rules = value; } }

		private Up_rules _up_rules;
		[DisplayName("Up_rules")]
		[ShouldSerialize("Up_rules")]
		public virtual Up_rules Up_rules
		{
			get
			{
				if (!isEmptyModel && (_up_rules == null || (!string.IsNullOrEmpty(ValCodup_rules) && (_up_rules.isEmptyModel || _up_rules.klass.QPrimaryKey != ValCodup_rules))))
					_up_rules = Models.Up_rules.Find(ValCodup_rules, m_userContext, Identifier, _fieldsToSerialize);
				_up_rules ??= new Models.Up_rules(m_userContext, true, _fieldsToSerialize);
				return _up_rules;
			}
			set { _up_rules = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Rules.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Rules(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArules(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rules(UserContext userContext, CSGenioArules val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioArules csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "up_rules":
						_up_rules ??= new Up_rules(m_userContext, true, _fieldsToSerialize);
						_up_rules.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Rules Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArules>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Rules(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Rules> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArules>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Rules>((r) => new Rules(userCtx, r));
		}

// USE /[MANUAL GQT MODEL RULES]/
	}
}
