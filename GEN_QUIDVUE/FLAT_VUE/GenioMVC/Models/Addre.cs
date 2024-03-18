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
	public class Addre : ModelBase
	{
		[JsonIgnore]
		public CSGenioAaddre klass { get { return baseklass as CSGenioAaddre; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValCodaddre")]
		public string ValCodaddre { get { return klass.ValCodaddre; } set { klass.ValCodaddre = value; } }

		[DisplayName("Address Use")]
		/// <summary>Field : "Address Use" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddressuse")]
		[DataArray("Addressu", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAddressuse { get { return klass.ValAddressuse; } set { klass.ValAddressuse = value; } }
		[JsonIgnore]
		public SelectList ArrayValaddressuse { get { return new SelectList(CSGenio.business.ArrayAddressu.GetDictionary(), "Key", "Value", ValAddressuse); } set { ValAddressuse = value.SelectedValue as string; } }

		[DisplayName("Address Type")]
		/// <summary>Field : "Address Type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddresstype")]
		[DataArray("Addresst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAddresstype { get { return klass.ValAddresstype; } set { klass.ValAddresstype = value; } }
		[JsonIgnore]
		public SelectList ArrayValaddresstype { get { return new SelectList(CSGenio.business.ArrayAddresst.GetDictionary(), "Key", "Value", ValAddresstype); } set { ValAddresstype = value.SelectedValue as string; } }

		[DisplayName("Entire address")]
		/// <summary>Field : "Entire address" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddresstext")]
		[DataType(DataType.MultilineText)]
		public string ValAddresstext { get { return klass.ValAddresstext; } set { klass.ValAddresstext = value; } }

		[DisplayName("Address City")]
		/// <summary>Field : "Address City" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddresscity")]
		public string ValAddresscity { get { return klass.ValAddresscity; } set { klass.ValAddresscity = value; } }

		[DisplayName("Address District")]
		/// <summary>Field : "Address District" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddressdistrict")]
		public string ValAddressdistrict { get { return klass.ValAddressdistrict; } set { klass.ValAddressdistrict = value; } }

		[DisplayName("Address State")]
		/// <summary>Field : "Address State" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddressstate")]
		public string ValAddressstate { get { return klass.ValAddressstate; } set { klass.ValAddressstate = value; } }

		[DisplayName("Address Postal Code")]
		/// <summary>Field : "Address Postal Code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddresspostalcode")]
		public string ValAddresspostalcode { get { return klass.ValAddresspostalcode; } set { klass.ValAddresspostalcode = value; } }

		[DisplayName("Address Country")]
		/// <summary>Field : "Address Country" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValAddresscountry")]
		public string ValAddresscountry { get { return klass.ValAddresscountry; } set { klass.ValAddresscountry = value; } }

		[DisplayName("Period Start")]
		/// <summary>Field : "Period Start" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValPeriodstart")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPeriodstart { get { return klass.ValPeriodstart; } set { klass.ValPeriodstart = value ?? DateTime.MinValue; } }

		[DisplayName("Period End")]
		/// <summary>Field : "Period End" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Addre.ValPeriodend")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPeriodend { get { return klass.ValPeriodend; } set { klass.ValPeriodend = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Addre.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Addre(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAaddre(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Addre(UserContext userContext, CSGenioAaddre val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAaddre csgenioa)
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
		public static Addre Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAaddre>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Addre(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Addre> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAaddre>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Addre>((r) => new Addre(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ADDRE]/
	}
}
