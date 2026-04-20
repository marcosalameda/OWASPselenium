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
	public class Proje : ModelBase
	{
		[JsonIgnore]
		public CSGenioAproje klass { get { return baseklass as CSGenioAproje; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Proje.ValCodproje")]
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }

		[DisplayName("Project")]
		/// <summary>Field : "Project" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Proje.ValProjecto")]
		public string ValProjecto { get { return klass.ValProjecto; } set { klass.ValProjecto = value; } }

		[DisplayName(">REFERENCE YEAR")]
		/// <summary>Field : ">REFERENCE YEAR" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Proje.ValCodyear")]
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }

		private Year1 _year1;
		[DisplayName("Year1")]
		[ShouldSerialize("Year1")]
		public virtual Year1 Year1
		{
			get
			{
				if (!isEmptyModel && (_year1 == null || (!string.IsNullOrEmpty(ValCodyear) && (_year1.isEmptyModel || _year1.klass.QPrimaryKey != ValCodyear))))
					_year1 = Models.Year1.Find(ValCodyear, m_userContext, Identifier, _fieldsToSerialize);
				_year1 ??= new Models.Year1(m_userContext, true, _fieldsToSerialize);
				return _year1;
			}
			set { _year1 = value; }
		}

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "C" Formula: ++ "[YEAR1->YEAR]"</summary>
		[ShouldSerialize("Proje.ValYear")]
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }

		[DisplayName("First")]
		/// <summary>Field : "First" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		[ShouldSerialize("Proje.ValPrimeiro")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrimeiro { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrimeiro, 2)); } set { klass.ValPrimeiro = Convert.ToDecimal(value); } }

		[DisplayName("Before")]
		/// <summary>Field : "Before" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		[ShouldSerialize("Proje.ValBefore")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValBefore { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBefore, 2)); } set { klass.ValBefore = Convert.ToDecimal(value); } }

		[DisplayName("Following")]
		/// <summary>Field : "Following" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		[ShouldSerialize("Proje.ValFollowin")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValFollowin { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValFollowin, 2)); } set { klass.ValFollowin = Convert.ToDecimal(value); } }

		[DisplayName("Last")]
		/// <summary>Field : "Last" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		[ShouldSerialize("Proje.ValUltimo")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValUltimo { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValUltimo, 2)); } set { klass.ValUltimo = Convert.ToDecimal(value); } }

		[DisplayName("Next - Previous =")]
		/// <summary>Field : "Next - Previous =" Tipo: "$D" Formula: + "[PROJE->FOLLOWIN]-[PROJE->BEFORE]"</summary>
		[ShouldSerialize("Proje.ValSaldo1")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValSaldo1 { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSaldo1, 2)); } set { klass.ValSaldo1 = Convert.ToDecimal(value); } }

		[DisplayName("Last - First =")]
		/// <summary>Field : "Last - First =" Tipo: "$D" Formula: + "[PROJE->ULTIMO]-[PROJE->PRIMEIRO]"</summary>
		[ShouldSerialize("Proje.ValSaldo2")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValSaldo2 { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSaldo2, 2)); } set { klass.ValSaldo2 = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Proje.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Proje(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAproje(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Proje(UserContext userContext, CSGenioAproje val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAproje csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "year1":
						_year1 ??= new Year1(m_userContext, true, _fieldsToSerialize);
						_year1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Proje Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAproje>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Proje(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Proje> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAproje>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Proje>((r) => new Proje(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PROJE]/
	}
}
