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
	public class Up_rules : ModelBase
	{
		[JsonIgnore]
		public CSGenioAup_rules klass { get { return baseklass as CSGenioAup_rules; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Up_rules.ValCodup_rules")]
		public string ValCodup_rules { get { return klass.ValCodup_rules; } set { klass.ValCodup_rules = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Up_rules.ValDescript")]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Place where you run")]
		/// <summary>Field : "Place where you run" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Up_rules.ValLocal")]
		[DataArray("Alocregr", GenioMVC.Helpers.ArrayType.Character)]
		public string ValLocal { get { return klass.ValLocal; } set { klass.ValLocal = value; } }
		[JsonIgnore]
		public SelectList ArrayVallocal { get { return new SelectList(CSGenio.business.ArrayAlocregr.GetDictionary(), "Key", "Value", ValLocal); } set { ValLocal = value.SelectedValue as string; } }

		[DisplayName("Allow all")]
		/// <summary>Field : "Allow all" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Up_rules.ValAllow_all")]
		public bool ValAllow_all { get { return Convert.ToBoolean(klass.ValAllow_all); } set { klass.ValAllow_all = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Up_rules.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Up_rules(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAup_rules(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Up_rules(UserContext userContext, CSGenioAup_rules val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAup_rules csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Up_rules Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAup_rules>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Up_rules(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Up_rules> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAup_rules>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Up_rules>((r) => new Up_rules(userCtx, r));
		}

// USE /[MANUAL GQT MODEL UP_RULES]/
	}
}
