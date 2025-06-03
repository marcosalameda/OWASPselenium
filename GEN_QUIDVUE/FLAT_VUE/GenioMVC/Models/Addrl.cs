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
	public class Addrl : ModelBase
	{
		[JsonIgnore]
		public CSGenioAaddrl klass { get { return baseklass as CSGenioAaddrl; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "Address" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValCustomeraddressid")]
		public string ValCustomeraddressid { get { return klass.ValCustomeraddressid; } set { klass.ValCustomeraddressid = value; } }

		[DisplayName("Parent")]
		/// <summary>Field : "Parent" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValParentid")]
		public string ValParentid { get { return klass.ValParentid; } set { klass.ValParentid = value; } }

		[DisplayName("parentId Type")]
		/// <summary>Field : "parentId Type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValParentidtypecode")]
		public string ValParentidtypecode { get { return klass.ValParentidtypecode; } set { klass.ValParentidtypecode = value; } }

		[DisplayName("Address Number")]
		/// <summary>Field : "Address Number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValAddressnumber")]
		[NumericAttribute(0)]
		public decimal? ValAddressnumber { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAddressnumber, 0)); } set { klass.ValAddressnumber = Convert.ToDecimal(value); } }

		[DisplayName("Object Type")]
		/// <summary>Field : "Object Type" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValObjecttypecode")]
		[DataArray("Objetype", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValObjecttypecode { get { return klass.ValObjecttypecode; } set { klass.ValObjecttypecode = value; } }
		[JsonIgnore]
		public SelectList ArrayValobjecttypecode { get { return new SelectList(CSGenio.business.ArrayObjetype.GetDictionary(), "Key", "Value", ValObjecttypecode); } set { ValObjecttypecode = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("objectTypeCode_display")]
		/// <summary>Field : "objectTypeCode_display" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValObjecttypecode_display")]
		public string ValObjecttypecode_display { get { return klass.ValObjecttypecode_display; } set { klass.ValObjecttypecode_display = value; } }

		[DisplayName("Address Type Code")]
		/// <summary>Field : "Address Type Code" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Addrl.ValAddresstypecode")]
		[DataArray("Addrtyco", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValAddresstypecode { get { return klass.ValAddresstypecode; } set { klass.ValAddresstypecode = value; } }
		[JsonIgnore]
		public SelectList ArrayValaddresstypecode { get { return new SelectList(CSGenio.business.ArrayAddrtyco.GetDictionary(), "Key", "Value", ValAddresstypecode); } set { ValAddresstypecode = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Addrl.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Addrl(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAaddrl(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Addrl(UserContext userContext, CSGenioAaddrl val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAaddrl csgenioa)
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
		public static Addrl Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAaddrl>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Addrl(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Addrl> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAaddrl>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Addrl>((r) => new Addrl(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ADDRL]/
	}
}
