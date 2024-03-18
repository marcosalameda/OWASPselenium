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
	public class Inpgr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAinpgr klass { get { return baseklass as CSGenioAinpgr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodinpgr { get { return klass.ValCodinpgr; } set { klass.ValCodinpgr = value; } }
		public bool ShouldSerializeValCodinpgr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValCodinpgr");

		[DisplayName("Icon")]
		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		public string ValIcongro { get { return klass.ValIcongro; } set { klass.ValIcongro = value; } }
		public bool ShouldSerializeValIcongro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValIcongro");

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNumbgro { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumbgro, 0)); } set { klass.ValNumbgro = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNumbgro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValNumbgro");

		[DisplayName("Text Field")]
		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		public string ValTextgro { get { return klass.ValTextgro; } set { klass.ValTextgro = value; } }
		public bool ShouldSerializeValTextgro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValTextgro");

		[DisplayName("Button")]
		/// <summary>Field : "Button" Tipo: "C" Formula:  ""</summary>
		public string ValButtngro { get { return klass.ValButtngro; } set { klass.ValButtngro = value; } }
		public bool ShouldSerializeValButtngro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValButtngro");

		[DisplayName("Profile")]
		/// <summary>Field : "Profile" Tipo: "C" Formula:  ""</summary>
		public string ValSpangro { get { return klass.ValSpangro; } set { klass.ValSpangro = value; } }
		public bool ShouldSerializeValSpangro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValSpangro");

		[DisplayName("Icon")]
		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		public string ValIconspan { get { return klass.ValIconspan; } set { klass.ValIconspan = value; } }
		public bool ShouldSerializeValIconspan() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValIconspan");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValName");

		[DisplayName("Last name")]
		/// <summary>Field : "Last name" Tipo: "C" Formula:  ""</summary>
		public string ValLastname { get { return klass.ValLastname; } set { klass.ValLastname = value; } }
		public bool ShouldSerializeValLastname() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValLastname");

		[DisplayName("Address type")]
		/// <summary>Field : "Address type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Addresst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAdress { get { return klass.ValAdress; } set { klass.ValAdress = value; } }
		[JsonIgnore]
		public SelectList ArrayValadress { get { return new SelectList(CSGenio.business.ArrayAddresst.GetDictionary(), "Key", "Value", ValAdress); } set { ValAdress = value.SelectedValue as string; } }
		public bool ShouldSerializeValAdress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValAdress");

		[DisplayName("Prefix")]
		/// <summary>Field : "Prefix" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Phonepre", GenioMVC.Helpers.ArrayType.Character)]
		public string ValPrefix { get { return klass.ValPrefix; } set { klass.ValPrefix = value; } }
		[JsonIgnore]
		public SelectList ArrayValprefix { get { return new SelectList(CSGenio.business.ArrayPhonepre.GetDictionary(), "Key", "Value", ValPrefix); } set { ValPrefix = value.SelectedValue as string; } }
		public bool ShouldSerializeValPrefix() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValPrefix");

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValPhone { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPhone, 0)); } set { klass.ValPhone = Convert.ToDouble(value); } }
		public bool ShouldSerializeValPhone() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValPhone");

		[DisplayName("E-mail")]
		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValEmail");

		[DisplayName("Web")]
		/// <summary>Field : "Web" Tipo: "C" Formula:  ""</summary>
		public string ValWeb { get { return klass.ValWeb; } set { klass.ValWeb = value; } }
		public bool ShouldSerializeValWeb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValWeb");

		[DisplayName("IBAN")]
		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		public string ValIban { get { return klass.ValIban; } set { klass.ValIban = value; } }
		public bool ShouldSerializeValIban() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValIban");

		[DisplayName("Banking Account Number")]
		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		public string ValBankacco { get { return klass.ValBankacco; } set { klass.ValBankacco = value; } }
		public bool ShouldSerializeValBankacco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValBankacco");

		[DisplayName("Text")]
		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public string ValTextspan { get { return klass.ValTextspan; } set { klass.ValTextspan = value; } }
		public bool ShouldSerializeValTextspan() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValTextspan");

		[DisplayName("Adress")]
		/// <summary>Field : "Adress" Tipo: "C" Formula:  ""</summary>
		public string ValDirectio { get { return klass.ValDirectio; } set { klass.ValDirectio = value; } }
		public bool ShouldSerializeValDirectio() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValDirectio");

		[DisplayName("Entity")]
		/// <summary>Field : "Entity" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Bankcomp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBankcomp { get { return klass.ValBankcomp; } set { klass.ValBankcomp = value; } }
		[JsonIgnore]
		public SelectList ArrayValbankcomp { get { return new SelectList(CSGenio.business.ArrayBankcomp.GetDictionary(), "Key", "Value", ValBankcomp); } set { ValBankcomp = value.SelectedValue as string; } }
		public bool ShouldSerializeValBankcomp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValBankcomp");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Inpgr.ValZzstate");

		public Inpgr() : this(UserContext.Current.User) { }

		public Inpgr(User u)
		{
			this.klass = new CSGenioAinpgr(u);
		}

		public Inpgr(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Inpgr(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Inpgr(bool isEmpty) : this(isEmpty, null) { }

		public Inpgr(CSGenioAinpgr val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Inpgr(CSGenioAinpgr val) : this(val, null) { }

		public Inpgr(CSGenioAinpgr val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Inpgr(CSGenioAinpgr val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAinpgr csgenioa)
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
		public static Inpgr Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Inpgr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAinpgr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Inpgr(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Inpgr> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAinpgr>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Inpgr>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAinpgr> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAinpgr>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAinpgr> All(CriteriaSet args = null)
		{
			return Where<CSGenioAinpgr>(false, args, numRegs: -1);
		}

		public static List<Inpgr> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAinpgr>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Inpgr>((r) => new Inpgr(r));
		}

// USE /[MANUAL GQT MODEL INPGR]/
	}
}
