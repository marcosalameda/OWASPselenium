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
	public class Psw : ModelBase
	{
		[JsonIgnore]
		public CSGenioApsw klass { get { return baseklass as CSGenioApsw; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		public bool ShouldSerializeValCodpsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValCodpsw");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValNome { get { return klass.ValNome; } set { klass.ValNome = value; } }
		public bool ShouldSerializeValNome() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValNome");

		[DisplayName("Password")]
		/// <summary>Field : "Password" Tipo: "C" Formula:  ""</summary>
		[DataType(DataType.Password), JsonIgnore]
		public string ValPassword { get { return klass.ValPassword; } set { klass.ValPassword = value; } }
		[DataType(DataType.Password), JsonIgnore]
		public string ValPasswordDecrypted { get { return klass.ValPasswordDecrypted; } set { klass.ValPasswordDecrypted = value; } }
		public bool ShouldSerializeValPassword() => false;

		[DisplayName("Certified Series Number")]
		/// <summary>Field : "Certified Series Number" Tipo: "C" Formula:  ""</summary>
		public string ValCertsn { get { return klass.ValCertsn; } set { klass.ValCertsn = value; } }
		public bool ShouldSerializeValCertsn() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValCertsn");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValEmail");

		[DisplayName("Password type")]
		/// <summary>Field : "Password type" Tipo: "C" Formula:  ""</summary>
		public string ValPswtype { get { return klass.ValPswtype; } set { klass.ValPswtype = value; } }
		public bool ShouldSerializeValPswtype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValPswtype");

		[DisplayName("Salt")]
		/// <summary>Field : "Salt" Tipo: "C" Formula:  ""</summary>
		public string ValSalt { get { return klass.ValSalt; } set { klass.ValSalt = value; } }
		public bool ShouldSerializeValSalt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValSalt");

		[DisplayName("Password date")]
		/// <summary>Field : "Password date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDatapsw { get { return klass.ValDatapsw; } set { klass.ValDatapsw = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatapsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValDatapsw");

		[DisplayName("User ID")]
		/// <summary>Field : "User ID" Tipo: "C" Formula:  ""</summary>
		public string ValUserid { get { return klass.ValUserid; } set { klass.ValUserid = value; } }
		public bool ShouldSerializeValUserid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValUserid");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		public string ValPsw2favl { get { return klass.ValPsw2favl; } set { klass.ValPsw2favl = value; } }
		public bool ShouldSerializeValPsw2favl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValPsw2favl");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		public string ValPsw2fatp { get { return klass.ValPsw2fatp; } set { klass.ValPsw2fatp = value; } }
		public bool ShouldSerializeValPsw2fatp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValPsw2fatp");

		[DisplayName("Expiration date")]
		/// <summary>Field : "Expiration date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDatexp { get { return klass.ValDatexp; } set { klass.ValDatexp = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatexp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValDatexp");

		[DisplayName("Login attempts")]
		/// <summary>Field : "Login attempts" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValAttempts { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValAttempts, 0)); } set { klass.ValAttempts = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValAttempts() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValAttempts");

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		public string ValPhone { get { return klass.ValPhone; } set { klass.ValPhone = value; } }
		public bool ShouldSerializeValPhone() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValPhone");

		[DisplayName("Status")]
		/// <summary>Field : "Status" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValStatus { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValStatus, 0)); } set { klass.ValStatus = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValStatus() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValStatus");

		[DisplayName("Has login?")]
		/// <summary>Field : "Has login?" Tipo: "L" Formula:  ""</summary>
		public bool ValAssocia { get { return Convert.ToBoolean(klass.ValAssocia); } set { klass.ValAssocia = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAssocia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValAssocia");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }
		public bool ShouldSerializeValOpercria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValOpercria");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValDatacria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValDatacria");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOpermuda { get { return klass.ValOpermuda; } set { klass.ValOpermuda = value; } }
		public bool ShouldSerializeValOpermuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValOpermuda");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValDatamuda { get { return klass.ValDatamuda; } set { klass.ValDatamuda = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValDatamuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValDatamuda");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw.ValZzstate");

		public Psw() : this(UserContext.Current.User) { }

		public Psw(User u)
		{
			this.klass = new CSGenioApsw(u);
		}

		public Psw(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Psw(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Psw(bool isEmpty) : this(isEmpty, null) { }

		public Psw(CSGenioApsw val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Psw(CSGenioApsw val) : this(val, null) { }

		public Psw(CSGenioApsw val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Psw(CSGenioApsw val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApsw csgenioa)
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
		public static Psw Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Psw Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApsw>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Psw(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Psw> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApsw>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Psw>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApsw> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApsw>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApsw> All(CriteriaSet args = null)
		{
			return Where<CSGenioApsw>(false, args, numRegs: -1);
		}

		public static List<Psw> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApsw>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Psw>((r) => new Psw(r));
		}

// USE /[MANUAL GQT MODEL PSW]/
	}
}
