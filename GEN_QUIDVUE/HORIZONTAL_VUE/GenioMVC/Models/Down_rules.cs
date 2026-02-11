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
	public class Down_rules : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdown_rules klass { get { return baseklass as CSGenioAdown_rules; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Down_rules.ValCoddown_rules")]
		public string ValCoddown_rules { get { return klass.ValCoddown_rules; } set { klass.ValCoddown_rules = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Down_rules.ValDescript")]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Down_rules.ValCodregra")]
		public string ValCodregra { get { return klass.ValCodregra; } set { klass.ValCodregra = value; } }

		private Rules _rules;
		[DisplayName("Rules")]
		[ShouldSerialize("Rules")]
		public virtual Rules Rules
		{
			get
			{
				if (!isEmptyModel && (_rules == null || (!string.IsNullOrEmpty(ValCodregra) && (_rules.isEmptyModel || _rules.klass.QPrimaryKey != ValCodregra))))
					_rules = Models.Rules.Find(ValCodregra, m_userContext, Identifier, _fieldsToSerialize);
				_rules ??= new Models.Rules(m_userContext, true, _fieldsToSerialize);
				return _rules;
			}
			set { _rules = value; }
		}

		[DisplayName("Place where you run")]
		/// <summary>Field : "Place where you run" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Down_rules.ValLocal")]
		[DataArray("Alocregr", GenioMVC.Helpers.ArrayType.Character)]
		public string ValLocal { get { return klass.ValLocal; } set { klass.ValLocal = value; } }
		[JsonIgnore]
		public SelectList ArrayVallocal { get { return new SelectList(CSGenio.business.ArrayAlocregr.GetDictionary(), "Key", "Value", ValLocal); } set { ValLocal = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Down_rules.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Down_rules(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAdown_rules(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Down_rules(UserContext userContext, CSGenioAdown_rules val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAdown_rules csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "rules":
						_rules ??= new Rules(m_userContext, true, _fieldsToSerialize);
						_rules.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Down_rules Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdown_rules>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Down_rules(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Down_rules> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdown_rules>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Down_rules>((r) => new Down_rules(userCtx, r));
		}

// USE /[MANUAL GQT MODEL DOWN_RULES]/
	}
}
