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
	public class Entit : ModelBase
	{
		[JsonIgnore]
		public CSGenioAentit klass { get { return baseklass as CSGenioAentit; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValCodentit");

		[DisplayName("Legal name")]
		/// <summary>Field : "Legal name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValName");

		[DisplayName("Company initials")]
		/// <summary>Field : "Company initials" Tipo: "C" Formula:  ""</summary>
		public string ValInitials { get { return klass.ValInitials; } set { klass.ValInitials = value; } }
		public bool ShouldSerializeValInitials() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValInitials");

		[DisplayName("Legal registration")]
		/// <summary>Field : "Legal registration" Tipo: "C" Formula:  ""</summary>
		public string ValRegistra { get { return klass.ValRegistra; } set { klass.ValRegistra = value; } }
		public bool ShouldSerializeValRegistra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValRegistra");

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public string ValTaxnumbe { get { return klass.ValTaxnumbe; } set { klass.ValTaxnumbe = value; } }
		public bool ShouldSerializeValTaxnumbe() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValTaxnumbe");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValEmail");

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		public string ValPhonenum { get { return klass.ValPhonenum; } set { klass.ValPhonenum = value; } }
		public bool ShouldSerializeValPhonenum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValPhonenum");

		[DisplayName("IBAN (International Bank Account Number)")]
		/// <summary>Field : "IBAN (International Bank Account Number)" Tipo: "C" Formula:  ""</summary>
		public string ValIban { get { return klass.ValIban; } set { klass.ValIban = value; } }
		public bool ShouldSerializeValIban() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValIban");

		[DisplayName("Building/house number")]
		/// <summary>Field : "Building/house number" Tipo: "C" Formula:  ""</summary>
		public string ValBuilding { get { return klass.ValBuilding; } set { klass.ValBuilding = value; } }
		public bool ShouldSerializeValBuilding() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValBuilding");

		[DisplayName("Street")]
		/// <summary>Field : "Street" Tipo: "C" Formula:  ""</summary>
		public string ValStreet { get { return klass.ValStreet; } set { klass.ValStreet = value; } }
		public bool ShouldSerializeValStreet() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValStreet");

		[DisplayName("Town/City")]
		/// <summary>Field : "Town/City" Tipo: "C" Formula:  ""</summary>
		public string ValTown { get { return klass.ValTown; } set { klass.ValTown = value; } }
		public bool ShouldSerializeValTown() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValTown");

		[DisplayName("County/Province")]
		/// <summary>Field : "County/Province" Tipo: "C" Formula:  ""</summary>
		public string ValCounty { get { return klass.ValCounty; } set { klass.ValCounty = value; } }
		public bool ShouldSerializeValCounty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValCounty");

		[DisplayName("State/Province")]
		/// <summary>Field : "State/Province" Tipo: "C" Formula:  ""</summary>
		public string ValState { get { return klass.ValState; } set { klass.ValState = value; } }
		public bool ShouldSerializeValState() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValState");

		[DisplayName("Post office box")]
		/// <summary>Field : "Post office box" Tipo: "C" Formula:  ""</summary>
		public string ValPobox { get { return klass.ValPobox; } set { klass.ValPobox = value; } }
		public bool ShouldSerializeValPobox() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValPobox");

		[DisplayName("ZIP/Postal code")]
		/// <summary>Field : "ZIP/Postal code" Tipo: "C" Formula:  ""</summary>
		public string ValPostalco { get { return klass.ValPostalco; } set { klass.ValPostalco = value; } }
		public bool ShouldSerializeValPostalco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValPostalco");

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValTelephon");

		[DisplayName("Fax")]
		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public string ValFax { get { return klass.ValFax; } set { klass.ValFax = value; } }
		public bool ShouldSerializeValFax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValFax");

		[DisplayName("Web site")]
		/// <summary>Field : "Web site" Tipo: "C" Formula:  ""</summary>
		[HyperLink]
		public string ValWebsite { get { return klass.ValWebsite; } set { klass.ValWebsite = value; } }
		public bool ShouldSerializeValWebsite() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValWebsite");

		[DisplayName("Person/Department to contact")]
		/// <summary>Field : "Person/Department to contact" Tipo: "C" Formula:  ""</summary>
		public string ValPerson { get { return klass.ValPerson; } set { klass.ValPerson = value; } }
		public bool ShouldSerializeValPerson() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValPerson");

		[DisplayName("Contact telephone number")]
		/// <summary>Field : "Contact telephone number" Tipo: "C" Formula:  ""</summary>
		public string ValContact { get { return klass.ValContact; } set { klass.ValContact = value; } }
		public bool ShouldSerializeValContact() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValContact");

		[DisplayName("Owner")]
		/// <summary>Field : "Owner" Tipo: "L" Formula:  ""</summary>
		public bool ValOwner { get { return Convert.ToBoolean(klass.ValOwner); } set { klass.ValOwner = Convert.ToInt32(value); } }
		public bool ShouldSerializeValOwner() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValOwner");

		[DisplayName("Carrier")]
		/// <summary>Field : "Carrier" Tipo: "L" Formula:  ""</summary>
		public bool ValCarrier { get { return Convert.ToBoolean(klass.ValCarrier); } set { klass.ValCarrier = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCarrier() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValCarrier");

		[DisplayName("Supplier")]
		/// <summary>Field : "Supplier" Tipo: "L" Formula:  ""</summary>
		public bool ValSupplier { get { return Convert.ToBoolean(klass.ValSupplier); } set { klass.ValSupplier = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSupplier() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValSupplier");

		[DisplayName("Manufacturer")]
		/// <summary>Field : "Manufacturer" Tipo: "L" Formula:  ""</summary>
		public bool ValManufact { get { return Convert.ToBoolean(klass.ValManufact); } set { klass.ValManufact = Convert.ToInt32(value); } }
		public bool ShouldSerializeValManufact() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValManufact");

		[DisplayName("Founded in")]
		/// <summary>Field : "Founded in" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFounded { get { return klass.ValFounded; } set { klass.ValFounded = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValFounded() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValFounded");

		[DisplayName("First incorporated facility")]
		/// <summary>Field : "First incorporated facility" Tipo: "CE" Formula: CT "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](ASC)"</summary>
		public string ValFirstfacilitie { get { return klass.ValFirstfacilitie; } set { klass.ValFirstfacilitie = value; } }
		public bool ShouldSerializeValFirstfacilitie() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValFirstfacilitie");
		private Faci1 _faci1;
		[DisplayName("Faci1")]
		public virtual Faci1 Faci1 { get { if (!this.isEmptyModel && (_faci1 == null || (!string.IsNullOrEmpty(ValFirstfacilitie) && (_faci1.isEmptyModel || _faci1.klass.QPrimaryKey != ValFirstfacilitie)))) _faci1 = Models.Faci1.Find(ValFirstfacilitie, Identifier, _fieldsToSerialize); if (_faci1 == null) _faci1 = new Models.Faci1(true, _fieldsToSerialize); return _faci1; } set { _faci1 = value; } }
		public bool ShouldSerializeFaci1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1");

		[DisplayName("Last incorporated facility")]
		/// <summary>Field : "Last incorporated facility" Tipo: "CE" Formula: CS "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](DESC)"</summary>
		public string ValLastfacilitie { get { return klass.ValLastfacilitie; } set { klass.ValLastfacilitie = value; } }
		public bool ShouldSerializeValLastfacilitie() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValLastfacilitie");
		private Faci2 _faci2;
		[DisplayName("Faci2")]
		public virtual Faci2 Faci2 { get { if (!this.isEmptyModel && (_faci2 == null || (!string.IsNullOrEmpty(ValLastfacilitie) && (_faci2.isEmptyModel || _faci2.klass.QPrimaryKey != ValLastfacilitie)))) _faci2 = Models.Faci2.Find(ValLastfacilitie, Identifier, _fieldsToSerialize); if (_faci2 == null) _faci2 = new Models.Faci2(true, _fieldsToSerialize); return _faci2; } set { _faci2 = value; } }
		public bool ShouldSerializeFaci2 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci2");

		[DisplayName("Language")]
		/// <summary>Field : "Language" Tipo: "C" Formula:  ""</summary>
		public string ValLanguage { get { return klass.ValLanguage; } set { klass.ValLanguage = value; } }
		public bool ShouldSerializeValLanguage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValLanguage");

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "C" Formula:  ""</summary>
		public string ValCurrency { get { return klass.ValCurrency; } set { klass.ValCurrency = value; } }
		public bool ShouldSerializeValCurrency() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValCurrency");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit.ValZzstate");

		public Entit() : this(UserContext.Current.User) { }

		public Entit(User u)
		{
			this.klass = new CSGenioAentit(u);
		}

		public Entit(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Entit(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Entit(bool isEmpty) : this(isEmpty, null) { }

		public Entit(CSGenioAentit val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Entit(CSGenioAentit val) : this(val, null) { }

		public Entit(CSGenioAentit val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Entit(CSGenioAentit val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_faci1 = new Faci1(true, _fieldsToSerialize);
						_faci1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "faci2":
						if (_faci2 == null)
							_faci2 = new Faci2(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Entit Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Entit Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAentit>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Entit(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Entit> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAentit>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Entit>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAentit> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAentit>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAentit> All(CriteriaSet args = null)
		{
			return Where<CSGenioAentit>(false, args, numRegs: -1);
		}

		public static List<Entit> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAentit>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Entit>((r) => new Entit(r));
		}

// USE /[MANUAL GQT MODEL ENTIT]/
	}
}
