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
	public class Ware1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAware1 klass { get { return baseklass as CSGenioAware1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Ware1.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }

		[DisplayName("Warehouse")]
		/// <summary>Field : "Warehouse" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Ware1.ValWarehdes")]
		public string ValWarehdes { get { return klass.ValWarehdes; } set { klass.ValWarehdes = value; } }

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Ware1.ValWarehcod")]
		public string ValWarehcod { get { return klass.ValWarehcod; } set { klass.ValWarehcod = value; } }

		[DisplayName("Activity")]
		/// <summary>Field : "Activity" Tipo: "AL" Formula:  ""</summary>
		[ShouldSerialize("Ware1.ValActivity")]
		[DataArray("Activida", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValActivity { get { return klass.ValActivity; } set { klass.ValActivity = value; } }
		[JsonIgnore]
		public SelectList ArrayValactivity { get { return new SelectList(CSGenio.business.ArrayActivida.GetDictionary(), "Key", "Value", ValActivity); } set { ValActivity = (int)value.SelectedValue; } }

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Ware1.ValShowreco")]
		public bool ValShowreco { get { return Convert.ToBoolean(klass.ValShowreco); } set { klass.ValShowreco = Convert.ToInt32(value); } }

		[DisplayName("Number of employees")]
		/// <summary>Field : "Number of employees" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Ware1.ValNum_employee")]
		[NumericAttribute(0)]
		public decimal? ValNum_employee { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNum_employee, 0)); } set { klass.ValNum_employee = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Ware1.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Ware1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAware1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ware1(UserContext userContext, CSGenioAware1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAware1 csgenioa)
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
		public static Ware1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAware1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ware1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Ware1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAware1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ware1>((r) => new Ware1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL WARE1]/
	}
}
