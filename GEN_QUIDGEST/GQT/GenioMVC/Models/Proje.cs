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
	public class Proje : ModelBase
	{
		[JsonIgnore]
		public CSGenioAproje klass { get { return baseklass as CSGenioAproje; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodproje { get { return klass.ValCodproje; } set { klass.ValCodproje = value; } }
		public bool ShouldSerializeValCodproje() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValCodproje");

		[DisplayName("Project")]
		/// <summary>Field : "Project" Tipo: "C" Formula:  ""</summary>
		public string ValProjecto { get { return klass.ValProjecto; } set { klass.ValProjecto = value; } }
		public bool ShouldSerializeValProjecto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValProjecto");

		[DisplayName(">REFERENCE YEAR")]
		/// <summary>Field : ">REFERENCE YEAR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodyear { get { return klass.ValCodyear; } set { klass.ValCodyear = value; } }
		public bool ShouldSerializeValCodyear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValCodyear");
		private Year1 _year1;
		[DisplayName("Year1")]
		public virtual Year1 Year1 { get { if (!this.isEmptyModel && (_year1 == null || (!string.IsNullOrEmpty(ValCodyear) && (_year1.isEmptyModel || _year1.klass.QPrimaryKey != ValCodyear)))) _year1 = Models.Year1.Find(ValCodyear, Identifier, _fieldsToSerialize); if (_year1 == null) _year1 = new Models.Year1(true, _fieldsToSerialize); return _year1; } set { _year1 = value; } }
		public bool ShouldSerializeYear1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Year1");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "C" Formula: ++ "[YEAR1->YEAR]"</summary>
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }
		public bool ShouldSerializeValYear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValYear");

		[DisplayName("First")]
		/// <summary>Field : "First" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEAR][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrimeiro { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrimeiro, 2)); } set { klass.ValPrimeiro = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrimeiro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValPrimeiro");

		[DisplayName("Before")]
		/// <summary>Field : "Before" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEAR][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValBefore { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBefore, 2)); } set { klass.ValBefore = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBefore() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValBefore");

		[DisplayName("Following")]
		/// <summary>Field : "Following" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEAR][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValFollowin { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValFollowin, 2)); } set { klass.ValFollowin = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValFollowin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValFollowin");

		[DisplayName("Last")]
		/// <summary>Field : "Last" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEAR][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValUltimo { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValUltimo, 2)); } set { klass.ValUltimo = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValUltimo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValUltimo");

		[DisplayName("Next - Previous =")]
		/// <summary>Field : "Next - Previous =" Tipo: "$D" Formula: + "[PROJE->FOLLOWIN]-[PROJE->BEFORE]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValSaldo1 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSaldo1, 2)); } set { klass.ValSaldo1 = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSaldo1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValSaldo1");

		[DisplayName("Last - First =")]
		/// <summary>Field : "Last - First =" Tipo: "$D" Formula: + "[PROJE->ULTIMO]-[PROJE->PRIMEIRO]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValSaldo2 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSaldo2, 2)); } set { klass.ValSaldo2 = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSaldo2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValSaldo2");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Proje.ValZzstate");

		public Proje() : this(UserContext.Current.User) { }

		public Proje(User u)
		{
			this.klass = new CSGenioAproje(u);
		}

		public Proje(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Proje(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Proje(bool isEmpty) : this(isEmpty, null) { }

		public Proje(CSGenioAproje val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Proje(CSGenioAproje val) : this(val, null) { }

		public Proje(CSGenioAproje val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Proje(CSGenioAproje val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAproje csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "year1":
						if (_year1 == null)
							_year1 = new Year1(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Proje Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Proje Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAproje>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Proje(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Proje> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAproje>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Proje>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAproje> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAproje>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAproje> All(CriteriaSet args = null)
		{
			return Where<CSGenioAproje>(false, args, numRegs: -1);
		}

		public static List<Proje> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAproje>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Proje>((r) => new Proje(r));
		}

// USE /[MANUAL GQT MODEL PROJE]/
	}
}
