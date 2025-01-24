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
	public class Entit : ModelBase
	{
		[JsonIgnore]
		public CSGenioAentit klass { get { return baseklass as CSGenioAentit; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		[DisplayName("Legal name")]
		/// <summary>Field : "Legal name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Company initials")]
		/// <summary>Field : "Company initials" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValInitials")]
		public string ValInitials { get { return klass.ValInitials; } set { klass.ValInitials = value; } }

		[DisplayName("Legal registration")]
		/// <summary>Field : "Legal registration" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValRegistra")]
		public string ValRegistra { get { return klass.ValRegistra; } set { klass.ValRegistra = value; } }

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValTaxnumbe")]
		public string ValTaxnumbe { get { return klass.ValTaxnumbe; } set { klass.ValTaxnumbe = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValPhonenum")]
		public string ValPhonenum { get { return klass.ValPhonenum; } set { klass.ValPhonenum = value; } }

		[DisplayName("IBAN (International Bank Account Number)")]
		/// <summary>Field : "IBAN (International Bank Account Number)" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValIban")]
		public string ValIban { get { return klass.ValIban; } set { klass.ValIban = value; } }

		[DisplayName("Building/house number")]
		/// <summary>Field : "Building/house number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValBuilding")]
		public string ValBuilding { get { return klass.ValBuilding; } set { klass.ValBuilding = value; } }

		[DisplayName("Street")]
		/// <summary>Field : "Street" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValStreet")]
		public string ValStreet { get { return klass.ValStreet; } set { klass.ValStreet = value; } }

		[DisplayName("Town/City")]
		/// <summary>Field : "Town/City" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValTown")]
		public string ValTown { get { return klass.ValTown; } set { klass.ValTown = value; } }

		[DisplayName("County/Province")]
		/// <summary>Field : "County/Province" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValCounty")]
		public string ValCounty { get { return klass.ValCounty; } set { klass.ValCounty = value; } }

		[DisplayName("State/Province")]
		/// <summary>Field : "State/Province" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValState")]
		public string ValState { get { return klass.ValState; } set { klass.ValState = value; } }

		[DisplayName("Post office box")]
		/// <summary>Field : "Post office box" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValPobox")]
		public string ValPobox { get { return klass.ValPobox; } set { klass.ValPobox = value; } }

		[DisplayName("ZIP/Postal code")]
		/// <summary>Field : "ZIP/Postal code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValPostalco")]
		public string ValPostalco { get { return klass.ValPostalco; } set { klass.ValPostalco = value; } }

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Fax")]
		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValFax")]
		public string ValFax { get { return klass.ValFax; } set { klass.ValFax = value; } }

		[DisplayName("Web site")]
		/// <summary>Field : "Web site" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValWebsite")]
		[HyperLink]
		public string ValWebsite { get { return klass.ValWebsite; } set { klass.ValWebsite = value; } }

		[DisplayName("Person/Department to contact")]
		/// <summary>Field : "Person/Department to contact" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValPerson")]
		public string ValPerson { get { return klass.ValPerson; } set { klass.ValPerson = value; } }

		[DisplayName("Contact telephone number")]
		/// <summary>Field : "Contact telephone number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValContact")]
		public string ValContact { get { return klass.ValContact; } set { klass.ValContact = value; } }

		[DisplayName("Owner")]
		/// <summary>Field : "Owner" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValOwner")]
		public string ValOwner { get { return klass.ValOwner; } set { klass.ValOwner = value; } }

		[DisplayName("Carrier")]
		/// <summary>Field : "Carrier" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValCarrier")]
		public bool ValCarrier { get { return Convert.ToBoolean(klass.ValCarrier); } set { klass.ValCarrier = Convert.ToInt32(value); } }

		[DisplayName("Supplier")]
		/// <summary>Field : "Supplier" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValSupplier")]
		public bool ValSupplier { get { return Convert.ToBoolean(klass.ValSupplier); } set { klass.ValSupplier = Convert.ToInt32(value); } }

		[DisplayName("Manufacturer")]
		/// <summary>Field : "Manufacturer" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValManufact")]
		public bool ValManufact { get { return Convert.ToBoolean(klass.ValManufact); } set { klass.ValManufact = Convert.ToInt32(value); } }

		[DisplayName("Founded in")]
		/// <summary>Field : "Founded in" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValFounded")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFounded { get { return klass.ValFounded; } set { klass.ValFounded = value ?? DateTime.MinValue; } }

		[DisplayName("First incorporated facility")]
		/// <summary>Field : "First incorporated facility" Tipo: "CE" Formula: CT "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](ASC)"</summary>
		[ShouldSerialize("Entit.ValFirstfacilitie")]
		public string ValFirstfacilitie { get { return klass.ValFirstfacilitie; } set { klass.ValFirstfacilitie = value; } }
		private Faci1 _faci1;
		[DisplayName("Faci1")]
		[ShouldSerialize("Faci1")]
		public virtual Faci1 Faci1 {
			get {
				if (!this.isEmptyModel && (_faci1 == null || (!string.IsNullOrEmpty(ValFirstfacilitie) && (_faci1.isEmptyModel || _faci1.klass.QPrimaryKey != ValFirstfacilitie))))
					_faci1 = Models.Faci1.Find(ValFirstfacilitie, m_userContext, Identifier, _fieldsToSerialize);
				if (_faci1 == null)
					_faci1 = new Models.Faci1(m_userContext, true, _fieldsToSerialize);
				return _faci1;
			}
			set { _faci1 = value; }
		}


		[DisplayName("Last incorporated facility")]
		/// <summary>Field : "Last incorporated facility" Tipo: "CE" Formula: CS "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](DESC)"</summary>
		[ShouldSerialize("Entit.ValLastfacilitie")]
		public string ValLastfacilitie { get { return klass.ValLastfacilitie; } set { klass.ValLastfacilitie = value; } }
		private Faci2 _faci2;
		[DisplayName("Faci2")]
		[ShouldSerialize("Faci2")]
		public virtual Faci2 Faci2 {
			get {
				if (!this.isEmptyModel && (_faci2 == null || (!string.IsNullOrEmpty(ValLastfacilitie) && (_faci2.isEmptyModel || _faci2.klass.QPrimaryKey != ValLastfacilitie))))
					_faci2 = Models.Faci2.Find(ValLastfacilitie, m_userContext, Identifier, _fieldsToSerialize);
				if (_faci2 == null)
					_faci2 = new Models.Faci2(m_userContext, true, _fieldsToSerialize);
				return _faci2;
			}
			set { _faci2 = value; }
		}


		[DisplayName("Language")]
		/// <summary>Field : "Language" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValLanguage")]
		public string ValLanguage { get { return klass.ValLanguage; } set { klass.ValLanguage = value; } }

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entit.ValCurrency")]
		public string ValCurrency { get { return klass.ValCurrency; } set { klass.ValCurrency = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Entit.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Entit(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAentit(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Entit(UserContext userContext, CSGenioAentit val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAentit csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "faci1":
						if (_faci1 == null)
							_faci1 = new Faci1(m_userContext, true, _fieldsToSerialize);
						_faci1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "faci2":
						if (_faci2 == null)
							_faci2 = new Faci2(m_userContext, true, _fieldsToSerialize);
						_faci2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Entit Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAentit>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Entit(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Entit> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAentit>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Entit>((r) => new Entit(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ENTIT]/
	}
}
