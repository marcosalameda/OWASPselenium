using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

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
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValCodentit");

		[DisplayName("Legal name")]
		/// <summary>Field : "Legal name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValName");

		[DisplayName("Company initials")]
		/// <summary>Field : "Company initials" Tipo: "C" Formula:  ""</summary>
		public string ValInitials { get { return klass.ValInitials; } set { klass.ValInitials = value; } }
		public bool ShouldSerializeValInitials() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValInitials");

		[DisplayName("Legal registration")]
		/// <summary>Field : "Legal registration" Tipo: "C" Formula:  ""</summary>
		public string ValRegistra { get { return klass.ValRegistra; } set { klass.ValRegistra = value; } }
		public bool ShouldSerializeValRegistra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValRegistra");

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public string ValTaxnumbe { get { return klass.ValTaxnumbe; } set { klass.ValTaxnumbe = value; } }
		public bool ShouldSerializeValTaxnumbe() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValTaxnumbe");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValEmail");

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		public string ValPhonenum { get { return klass.ValPhonenum; } set { klass.ValPhonenum = value; } }
		public bool ShouldSerializeValPhonenum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValPhonenum");

		[DisplayName("IBAN (International Bank Account Number)")]
		/// <summary>Field : "IBAN (International Bank Account Number)" Tipo: "C" Formula:  ""</summary>
		public string ValIban { get { return klass.ValIban; } set { klass.ValIban = value; } }
		public bool ShouldSerializeValIban() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValIban");

		[DisplayName("Building/house number")]
		/// <summary>Field : "Building/house number" Tipo: "C" Formula:  ""</summary>
		public string ValBuilding { get { return klass.ValBuilding; } set { klass.ValBuilding = value; } }
		public bool ShouldSerializeValBuilding() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValBuilding");

		[DisplayName("Street")]
		/// <summary>Field : "Street" Tipo: "C" Formula:  ""</summary>
		public string ValStreet { get { return klass.ValStreet; } set { klass.ValStreet = value; } }
		public bool ShouldSerializeValStreet() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValStreet");

		[DisplayName("Town/City")]
		/// <summary>Field : "Town/City" Tipo: "C" Formula:  ""</summary>
		public string ValTown { get { return klass.ValTown; } set { klass.ValTown = value; } }
		public bool ShouldSerializeValTown() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValTown");

		[DisplayName("County/Province")]
		/// <summary>Field : "County/Province" Tipo: "C" Formula:  ""</summary>
		public string ValCounty { get { return klass.ValCounty; } set { klass.ValCounty = value; } }
		public bool ShouldSerializeValCounty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValCounty");

		[DisplayName("State/Province")]
		/// <summary>Field : "State/Province" Tipo: "C" Formula:  ""</summary>
		public string ValState { get { return klass.ValState; } set { klass.ValState = value; } }
		public bool ShouldSerializeValState() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValState");

		[DisplayName("Post office box")]
		/// <summary>Field : "Post office box" Tipo: "C" Formula:  ""</summary>
		public string ValPobox { get { return klass.ValPobox; } set { klass.ValPobox = value; } }
		public bool ShouldSerializeValPobox() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValPobox");

		[DisplayName("ZIP/Popstal code")]
		/// <summary>Field : "ZIP/Popstal code" Tipo: "C" Formula:  ""</summary>
		public string ValPostalco { get { return klass.ValPostalco; } set { klass.ValPostalco = value; } }
		public bool ShouldSerializeValPostalco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValPostalco");

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValTelephon");

		[DisplayName("Fax")]
		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public string ValFax { get { return klass.ValFax; } set { klass.ValFax = value; } }
		public bool ShouldSerializeValFax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValFax");

		[DisplayName("Web site")]
		/// <summary>Field : "Web site" Tipo: "C" Formula:  ""</summary>
		[HyperLink]
		public string ValWebsite { get { return klass.ValWebsite; } set { klass.ValWebsite = value; } }
		public bool ShouldSerializeValWebsite() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValWebsite");

		[DisplayName("Person/Department to contact")]
		/// <summary>Field : "Person/Department to contact" Tipo: "C" Formula:  ""</summary>
		public string ValPerson { get { return klass.ValPerson; } set { klass.ValPerson = value; } }
		public bool ShouldSerializeValPerson() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValPerson");

		[DisplayName("Contact telephone number")]
		/// <summary>Field : "Contact telephone number" Tipo: "C" Formula:  ""</summary>
		public string ValContact { get { return klass.ValContact; } set { klass.ValContact = value; } }
		public bool ShouldSerializeValContact() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValContact");

		[DisplayName("Owner")]
		/// <summary>Field : "Owner" Tipo: "L" Formula:  ""</summary>
		public bool ValOwner { get { return Convert.ToBoolean(klass.ValOwner); } set { klass.ValOwner = Convert.ToInt32(value); } }
		public bool ShouldSerializeValOwner() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValOwner");

		[DisplayName("Carrier")]
		/// <summary>Field : "Carrier" Tipo: "L" Formula:  ""</summary>
		public bool ValCarrier { get { return Convert.ToBoolean(klass.ValCarrier); } set { klass.ValCarrier = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCarrier() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValCarrier");

		[DisplayName("Supplier")]
		/// <summary>Field : "Supplier" Tipo: "L" Formula:  ""</summary>
		public bool ValSupplier { get { return Convert.ToBoolean(klass.ValSupplier); } set { klass.ValSupplier = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSupplier() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValSupplier");

		[DisplayName("Manufacturer")]
		/// <summary>Field : "Manufacturer" Tipo: "L" Formula:  ""</summary>
		public bool ValManufact { get { return Convert.ToBoolean(klass.ValManufact); } set { klass.ValManufact = Convert.ToInt32(value); } }
		public bool ShouldSerializeValManufact() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValManufact");

		[DisplayName("Founded in")]
		/// <summary>Field : "Founded in" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFounded { get { return klass.ValFounded; } set { klass.ValFounded = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValFounded() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValFounded");

		[DisplayName("First incorporated facility")]
		/// <summary>Field : "First incorporated facility" Tipo: "CF" Formula:  ""</summary>
		public string ValFirstfacilitie { get { return klass.ValFirstfacilitie; } set { klass.ValFirstfacilitie = value; } }
		public bool ShouldSerializeValFirstfacilitie() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValFirstfacilitie");

		[DisplayName("Last incorporated facility")]
		/// <summary>Field : "Last incorporated facility" Tipo: "CF" Formula:  ""</summary>
		public string ValLastfacilitie { get { return klass.ValLastfacilitie; } set { klass.ValLastfacilitie = value; } }
		public bool ShouldSerializeValLastfacilitie() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValLastfacilitie");

		[DisplayName("Language")]
		/// <summary>Field : "Language" Tipo: "C" Formula:  ""</summary>
		public string ValLanguage { get { return klass.ValLanguage; } set { klass.ValLanguage = value; } }
		public bool ShouldSerializeValLanguage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValLanguage");

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "C" Formula:  ""</summary>
		public string ValCurrency { get { return klass.ValCurrency; } set { klass.ValCurrency = value; } }
		public bool ShouldSerializeValCurrency() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValCurrency");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf.ValZzstate");

		public Manuf() : this(UserContext.Current.User) { }

		public Manuf(User u)
		{
			this.klass = new CSGenioAmanuf(u);
		}

		public Manuf(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Manuf(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Manuf(bool isEmpty) : this(isEmpty, null) { }

		public Manuf(CSGenioAmanuf val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Manuf(CSGenioAmanuf val) : this(val, null) { }

		public Manuf(CSGenioAmanuf val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Manuf(CSGenioAmanuf val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Manuf Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			return Find(id, UserContext.Current, identifier, fieldsToSerialize, fieldsToQuery);
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
			return record == null ? null : new Manuf(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Manuf> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAmanuf>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Manuf>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAmanuf> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAmanuf>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAmanuf> All(CriteriaSet args = null)
		{
			return Where<CSGenioAmanuf>(false, args, numRegs: -1);
		}

		public static List<Manuf> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmanuf>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Manuf>((r) => new Manuf(r));
		}

// USE /[MANUAL GQT MODEL MANUF]/
	}
}
