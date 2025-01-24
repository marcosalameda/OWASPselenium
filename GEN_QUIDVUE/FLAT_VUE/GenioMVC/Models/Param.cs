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
	public class Param : ModelBase
	{
		[JsonIgnore]
		public CSGenioAparam klass { get { return baseklass as CSGenioAparam; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Param.ValCodparam")]
		public string ValCodparam { get { return klass.ValCodparam; } set { klass.ValCodparam = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Param.ValCodkinde")]
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		private Kinde _kinde;
		[DisplayName("Kinde")]
		[ShouldSerialize("Kinde")]
		public virtual Kinde Kinde {
			get {
				if (!this.isEmptyModel && (_kinde == null || (!string.IsNullOrEmpty(ValCodkinde) && (_kinde.isEmptyModel || _kinde.klass.QPrimaryKey != ValCodkinde))))
					_kinde = Models.Kinde.Find(ValCodkinde, m_userContext, Identifier, _fieldsToSerialize);
				if (_kinde == null)
					_kinde = new Models.Kinde(m_userContext, true, _fieldsToSerialize);
				return _kinde;
			}
			set { _kinde = value; }
		}


		[DisplayName("Parameter")]
		/// <summary>Field : "Parameter" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Param.ValParameter")]
		public string ValParameter { get { return klass.ValParameter; } set { klass.ValParameter = value; } }

		[DisplayName("Data type")]
		/// <summary>Field : "Data type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Param.ValDatatype")]
		[DataArray("Datatype", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDatatype { get { return klass.ValDatatype; } set { klass.ValDatatype = value; } }
		[JsonIgnore]
		public SelectList ArrayValdatatype { get { return new SelectList(CSGenio.business.ArrayDatatype.GetDictionary(), "Key", "Value", ValDatatype); } set { ValDatatype = value.SelectedValue as string; } }

		[DisplayName("Decimal places")]
		/// <summary>Field : "Decimal places" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Param.ValDecimalplaces")]
		[DataArray("Decplace", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValDecimalplaces { get { return klass.ValDecimalplaces; } set { klass.ValDecimalplaces = value; } }
		[JsonIgnore]
		public SelectList ArrayValdecimalplaces { get { return new SelectList(CSGenio.business.ArrayDecplace.GetDictionary(), "Key", "Value", ValDecimalplaces); } set { ValDecimalplaces = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Param.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Param(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAparam(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Param(UserContext userContext, CSGenioAparam val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAparam csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "kinde":
						if (_kinde == null)
							_kinde = new Kinde(m_userContext, true, _fieldsToSerialize);
						_kinde.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Param Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAparam>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Param(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Param> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAparam>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Param>((r) => new Param(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PARAM]/
	}
}
