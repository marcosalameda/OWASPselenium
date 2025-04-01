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
	public class Lendi : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlendi klass { get { return baseklass as CSGenioAlendi; } set { baseklass = value; } }

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
		public string ValCodlendi { get { return klass.ValCodlendi; } set { klass.ValCodlendi = value; } }
		public bool ShouldSerializeValCodlendi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValCodlendi");

		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		public bool ShouldSerializeValCodpess1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValCodpess1");
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		public virtual Pess1 Pess1 { get { if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1)))) _pess1 = Models.Pess1.Find(ValCodpess1, Identifier, _fieldsToSerialize); if (_pess1 == null) _pess1 = new Models.Pess1(true, _fieldsToSerialize); return _pess1; } set { _pess1 = value; } }
		public bool ShouldSerializePess1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess1");

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName(">DADATARY")]
		/// <summary>Field : ">DADATARY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess2 { get { return klass.ValCodpess2; } set { klass.ValCodpess2 = value; } }
		public bool ShouldSerializeValCodpess2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValCodpess2");
		private Pess2 _pess2;
		[DisplayName("Pess2")]
		public virtual Pess2 Pess2 { get { if (!this.isEmptyModel && (_pess2 == null || (!string.IsNullOrEmpty(ValCodpess2) && (_pess2.isEmptyModel || _pess2.klass.QPrimaryKey != ValCodpess2)))) _pess2 = Models.Pess2.Find(ValCodpess2, Identifier, _fieldsToSerialize); if (_pess2 == null) _pess2 = new Models.Pess2(true, _fieldsToSerialize); return _pess2; } set { _pess2 = value; } }
		public bool ShouldSerializePess2 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2");

		[DisplayName("Number of lending")]
		/// <summary>Field : "Number of lending" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValLendinnr { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValLendinnr, 0)); } set { klass.ValLendinnr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLendinnr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValLendinnr");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStart { get { return klass.ValStart; } set { klass.ValStart = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValStart() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValStart");

		[DisplayName("Warning")]
		/// <summary>Field : "Warning" Tipo: "DT" Formula: + "SomaDias([LENDI->START],[EQUIP->FREQUENC])"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValWarndt { get { return klass.ValWarndt; } set { klass.ValWarndt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValWarndt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValWarndt");

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula: + "SomaDias([LENDI->WARNDT],1)"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get { return klass.ValEnd; } set { klass.ValEnd = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValEnd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValEnd");

		[DisplayName("Observations")]
		/// <summary>Field : "Observations" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }
		public bool ShouldSerializeValObservat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValObservat");

		[DisplayName("Return")]
		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValReturndt { get { return klass.ValReturndt; } set { klass.ValReturndt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValReturndt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValReturndt");

		[DisplayName("Returned")]
		/// <summary>Field : "Returned" Tipo: "L" Formula: + "iif(emptyD([LENDI->RETURNDT])==1,0,1)"</summary>
		public bool ValReturned { get { return Convert.ToBoolean(klass.ValReturned); } set { klass.ValReturned = Convert.ToInt32(value); } }
		public bool ShouldSerializeValReturned() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValReturned");

		[DisplayName("Days for return period")]
		/// <summary>Field : "Days for return period" Tipo: "N" Formula: +H "iif(emptyD([LENDI->END])==1,0,Diferenca_entre_Datas([Today],[LENDI->END],"D"))"</summary>
		[NumericAttribute(0)]
		public decimal? ValDayslimi { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDayslimi, 0)); } set { klass.ValDayslimi = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDayslimi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValDayslimi");

		[DisplayName("If out of date")]
		/// <summary>Field : "If out of date" Tipo: "L" Formula: + "iif([LENDI->DAYSLIMI]<0,1,0)"</summary>
		public bool ValIfoutdt { get { return Convert.ToBoolean(klass.ValIfoutdt); } set { klass.ValIfoutdt = Convert.ToInt32(value); } }
		public bool ShouldSerializeValIfoutdt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValIfoutdt");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lendi.ValZzstate");

		public Lendi() : this(UserContext.Current.User) { }

		public Lendi(User u)
		{
			this.klass = new CSGenioAlendi(u);
		}

		public Lendi(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lendi(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Lendi(bool isEmpty) : this(isEmpty, null) { }

		public Lendi(CSGenioAlendi val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lendi(CSGenioAlendi val) : this(val, null) { }

		public Lendi(CSGenioAlendi val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Lendi(CSGenioAlendi val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlendi csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "equip":
						if (_equip == null)
							_equip = new Equip(true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess2":
						if (_pess2 == null)
							_pess2 = new Pess2(true, _fieldsToSerialize);
						_pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lendi Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Lendi Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlendi>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lendi(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Lendi> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlendi>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Lendi>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlendi> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlendi>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlendi> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlendi>(false, args, numRegs: -1);
		}

		public static List<Lendi> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlendi>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lendi>((r) => new Lendi(r));
		}

// USE /[MANUAL GQT MODEL LENDI]/
	}
}
