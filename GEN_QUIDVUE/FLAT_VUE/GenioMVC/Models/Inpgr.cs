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
	public class Inpgr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAinpgr klass { get { return baseklass as CSGenioAinpgr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValCodinpgr")]
		public string ValCodinpgr { get { return klass.ValCodinpgr; } set { klass.ValCodinpgr = value; } }

		[DisplayName("Icon")]
		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValIcongro")]
		public string ValIcongro { get { return klass.ValIcongro; } set { klass.ValIcongro = value; } }

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValNumbgro")]
		[NumericAttribute(0)]
		public decimal? ValNumbgro { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumbgro, 0)); } set { klass.ValNumbgro = Convert.ToDecimal(value); } }

		[DisplayName("Text Field")]
		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValTextgro")]
		public string ValTextgro { get { return klass.ValTextgro; } set { klass.ValTextgro = value; } }

		[DisplayName("Button")]
		/// <summary>Field : "Button" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValButtngro")]
		public string ValButtngro { get { return klass.ValButtngro; } set { klass.ValButtngro = value; } }

		[DisplayName("Profile")]
		/// <summary>Field : "Profile" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValSpangro")]
		public string ValSpangro { get { return klass.ValSpangro; } set { klass.ValSpangro = value; } }

		[DisplayName("Icon")]
		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValIconspan")]
		public string ValIconspan { get { return klass.ValIconspan; } set { klass.ValIconspan = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Last name")]
		/// <summary>Field : "Last name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValLastname")]
		public string ValLastname { get { return klass.ValLastname; } set { klass.ValLastname = value; } }

		[DisplayName("Address type")]
		/// <summary>Field : "Address type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValAdress")]
		[DataArray("Addresst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAdress { get { return klass.ValAdress; } set { klass.ValAdress = value; } }
		[JsonIgnore]
		public SelectList ArrayValadress { get { return new SelectList(CSGenio.business.ArrayAddresst.GetDictionary(), "Key", "Value", ValAdress); } set { ValAdress = value.SelectedValue as string; } }

		[DisplayName("Prefix")]
		/// <summary>Field : "Prefix" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValPrefix")]
		[DataArray("Phonepre", GenioMVC.Helpers.ArrayType.Character)]
		public string ValPrefix { get { return klass.ValPrefix; } set { klass.ValPrefix = value; } }
		[JsonIgnore]
		public SelectList ArrayValprefix { get { return new SelectList(CSGenio.business.ArrayPhonepre.GetDictionary(), "Key", "Value", ValPrefix); } set { ValPrefix = value.SelectedValue as string; } }

		[DisplayName("Phone number")]
		/// <summary>Field : "Phone number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValPhone")]
		[NumericAttribute(0)]
		public decimal? ValPhone { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPhone, 0)); } set { klass.ValPhone = Convert.ToDecimal(value); } }

		[DisplayName("E-mail")]
		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Web")]
		/// <summary>Field : "Web" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValWeb")]
		public string ValWeb { get { return klass.ValWeb; } set { klass.ValWeb = value; } }

		[DisplayName("IBAN")]
		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValIban")]
		public string ValIban { get { return klass.ValIban; } set { klass.ValIban = value; } }

		[DisplayName("Banking Account Number")]
		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValBankacco")]
		public string ValBankacco { get { return klass.ValBankacco; } set { klass.ValBankacco = value; } }

		[DisplayName("Text")]
		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValTextspan")]
		public string ValTextspan { get { return klass.ValTextspan; } set { klass.ValTextspan = value; } }

		[DisplayName("Adress")]
		/// <summary>Field : "Adress" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValDirectio")]
		public string ValDirectio { get { return klass.ValDirectio; } set { klass.ValDirectio = value; } }

		[DisplayName("Entity")]
		/// <summary>Field : "Entity" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Inpgr.ValBankcomp")]
		[DataArray("Bankcomp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBankcomp { get { return klass.ValBankcomp; } set { klass.ValBankcomp = value; } }
		[JsonIgnore]
		public SelectList ArrayValbankcomp { get { return new SelectList(CSGenio.business.ArrayBankcomp.GetDictionary(), "Key", "Value", ValBankcomp); } set { ValBankcomp = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Inpgr.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Inpgr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAinpgr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Inpgr(UserContext userContext, CSGenioAinpgr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Inpgr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAinpgr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Inpgr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Inpgr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAinpgr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Inpgr>((r) => new Inpgr(userCtx, r));
		}

// USE /[MANUAL GQT MODEL INPGR]/
	}
}
