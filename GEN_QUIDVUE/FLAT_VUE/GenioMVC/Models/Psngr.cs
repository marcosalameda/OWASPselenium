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
	public class Psngr : ModelBase
	{
		[JsonIgnore]
		public CSGenioApsngr klass { get { return baseklass as CSGenioApsngr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValCodpsngr")]
		public string ValCodpsngr { get { return klass.ValCodpsngr; } set { klass.ValCodpsngr = value; } }

		[DisplayName("Passenger ID")]
		/// <summary>Field : "Passenger ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValPsngrid")]
		[NumericAttribute(0)]
		public decimal? ValPsngrid { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPsngrid, 0)); } set { klass.ValPsngrid = Convert.ToDecimal(value); } }

		[DisplayName("First Name")]
		/// <summary>Field : "First Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValFstname")]
		public string ValFstname { get { return klass.ValFstname; } set { klass.ValFstname = value; } }

		[DisplayName("Last Name")]
		/// <summary>Field : "Last Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValLstname")]
		public string ValLstname { get { return klass.ValLstname; } set { klass.ValLstname = value; } }

		[DisplayName("Full Name")]
		/// <summary>Field : "Full Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValFullname")]
		public string ValFullname { get { return klass.ValFullname; } set { klass.ValFullname = value; } }

		[DisplayName("Passport Number")]
		/// <summary>Field : "Passport Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValPassprtn")]
		public string ValPassprtn { get { return klass.ValPassprtn; } set { klass.ValPassprtn = value; } }

		[DisplayName("Date of Birth")]
		/// <summary>Field : "Date of Birth" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValPsngrdob")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValPsngrdob { get { return klass.ValPsngrdob; } set { klass.ValPsngrdob = value ?? DateTime.MinValue; } }

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValPaddress")]
		[DataType(DataType.MultilineText)]
		public string ValPaddress { get { return klass.ValPaddress; } set { klass.ValPaddress = value; } }

		[DisplayName("Email Address")]
		/// <summary>Field : "Email Address" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValPsemail")]
		public string ValPsemail { get { return klass.ValPsemail; } set { klass.ValPsemail = value; } }

		[DisplayName("Contact Number")]
		/// <summary>Field : "Contact Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Psngr.ValCtcnumbr")]
		public string ValCtcnumbr { get { return klass.ValCtcnumbr; } set { klass.ValCtcnumbr = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Psngr.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Psngr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApsngr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Psngr(UserContext userContext, CSGenioApsngr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioApsngr csgenioa)
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
		public static Psngr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApsngr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Psngr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Psngr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApsngr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Psngr>((r) => new Psngr(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PSNGR]/
	}
}
