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
	public class Manuf : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmanuf klass { get { return baseklass as CSGenioAmanuf; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		[DisplayName("Legal name")]
		/// <summary>Field : "Legal name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Company initials")]
		/// <summary>Field : "Company initials" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValInitials")]
		public string ValInitials { get { return klass.ValInitials; } set { klass.ValInitials = value; } }

		[DisplayName("Legal registration")]
		/// <summary>Field : "Legal registration" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValRegistra")]
		public string ValRegistra { get { return klass.ValRegistra; } set { klass.ValRegistra = value; } }

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValTaxnumbe")]
		public string ValTaxnumbe { get { return klass.ValTaxnumbe; } set { klass.ValTaxnumbe = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValPhonenum")]
		public string ValPhonenum { get { return klass.ValPhonenum; } set { klass.ValPhonenum = value; } }

		[DisplayName("IBAN (International Bank Account Number)")]
		/// <summary>Field : "IBAN (International Bank Account Number)" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValIban")]
		public string ValIban { get { return klass.ValIban; } set { klass.ValIban = value; } }

		[DisplayName("Building/house number")]
		/// <summary>Field : "Building/house number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValBuilding")]
		public string ValBuilding { get { return klass.ValBuilding; } set { klass.ValBuilding = value; } }

		[DisplayName("Street")]
		/// <summary>Field : "Street" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValStreet")]
		public string ValStreet { get { return klass.ValStreet; } set { klass.ValStreet = value; } }

		[DisplayName("Town/City")]
		/// <summary>Field : "Town/City" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValTown")]
		public string ValTown { get { return klass.ValTown; } set { klass.ValTown = value; } }

		[DisplayName("County/Province")]
		/// <summary>Field : "County/Province" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValCounty")]
		public string ValCounty { get { return klass.ValCounty; } set { klass.ValCounty = value; } }

		[DisplayName("State/Province")]
		/// <summary>Field : "State/Province" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValState")]
		public string ValState { get { return klass.ValState; } set { klass.ValState = value; } }

		[DisplayName("Post office box")]
		/// <summary>Field : "Post office box" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValPobox")]
		public string ValPobox { get { return klass.ValPobox; } set { klass.ValPobox = value; } }

		[DisplayName("ZIP/Popstal code")]
		/// <summary>Field : "ZIP/Popstal code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValPostalco")]
		public string ValPostalco { get { return klass.ValPostalco; } set { klass.ValPostalco = value; } }

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Fax")]
		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValFax")]
		public string ValFax { get { return klass.ValFax; } set { klass.ValFax = value; } }

		[DisplayName("Web site")]
		/// <summary>Field : "Web site" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValWebsite")]
		[HyperLink]
		public string ValWebsite { get { return klass.ValWebsite; } set { klass.ValWebsite = value; } }

		[DisplayName("Person/Department to contact")]
		/// <summary>Field : "Person/Department to contact" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValPerson")]
		public string ValPerson { get { return klass.ValPerson; } set { klass.ValPerson = value; } }

		[DisplayName("Contact telephone number")]
		/// <summary>Field : "Contact telephone number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValContact")]
		public string ValContact { get { return klass.ValContact; } set { klass.ValContact = value; } }

		[DisplayName("Owner")]
		/// <summary>Field : "Owner" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValOwner")]
		public string ValOwner { get { return klass.ValOwner; } set { klass.ValOwner = value; } }

		[DisplayName("Carrier")]
		/// <summary>Field : "Carrier" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValCarrier")]
		public bool ValCarrier { get { return Convert.ToBoolean(klass.ValCarrier); } set { klass.ValCarrier = Convert.ToInt32(value); } }

		[DisplayName("Supplier")]
		/// <summary>Field : "Supplier" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValSupplier")]
		public bool ValSupplier { get { return Convert.ToBoolean(klass.ValSupplier); } set { klass.ValSupplier = Convert.ToInt32(value); } }

		[DisplayName("Manufacturer")]
		/// <summary>Field : "Manufacturer" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValManufact")]
		public bool ValManufact { get { return Convert.ToBoolean(klass.ValManufact); } set { klass.ValManufact = Convert.ToInt32(value); } }

		[DisplayName("Founded in")]
		/// <summary>Field : "Founded in" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValFounded")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFounded { get { return klass.ValFounded; } set { klass.ValFounded = value ?? DateTime.MinValue; } }

		[DisplayName("First incorporated facility")]
		/// <summary>Field : "First incorporated facility" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValFirstfacilitie")]
		public string ValFirstfacilitie { get { return klass.ValFirstfacilitie; } set { klass.ValFirstfacilitie = value; } }

		[DisplayName("Last incorporated facility")]
		/// <summary>Field : "Last incorporated facility" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValLastfacilitie")]
		public string ValLastfacilitie { get { return klass.ValLastfacilitie; } set { klass.ValLastfacilitie = value; } }

		[DisplayName("Language")]
		/// <summary>Field : "Language" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValLanguage")]
		public string ValLanguage { get { return klass.ValLanguage; } set { klass.ValLanguage = value; } }

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Manuf.ValCurrency")]
		public string ValCurrency { get { return klass.ValCurrency; } set { klass.ValCurrency = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Manuf.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Manuf(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmanuf(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Manuf(UserContext userContext, CSGenioAmanuf val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAmanuf csgenioa)
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
		public static Manuf Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmanuf>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Manuf(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Manuf> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmanuf>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Manuf>((r) => new Manuf(userCtx, r));
		}

// USE /[MANUAL GQT MODEL MANUF]/
	}
}
